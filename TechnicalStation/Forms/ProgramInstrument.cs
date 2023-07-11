using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caretag_Class;
using Caretag_Class.Configuration;
using Caretag_Class.EventReporting;
using Caretag_Class.Model;
using Microsoft.VisualBasic;
using NurApiDotNet;
using RFIDAbstractionLayer;
using RFIDAbstractionLayer.Exceptions;
using RFIDAbstractionLayer.Readers;
using Serilog;
using TechnicalStation.Configuration;
using TechnicalStation.Services;
using UIControls;
using Caretag_Class.Util;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using TechnicalStation.My.Resources;
using System.Media;

namespace TechnicalStation.Forms
{
    public partial class ProgramInstrument : Form
    {
        enum TagAssetState
        {
            NotRecognized,
            GS1Recognized,
            KnownInstrument,
            KnownTray,
            KnownContainer
        }

        private readonly TechnicalStationAppSettings _technicalStationAppSettings;
        private readonly RFIDReaderCollection _rfidReader;
        private readonly EventReporter _eventReporter;
        private readonly RFIDReaderCommon _readerCommon;
        private readonly ILogger _logger;
        private readonly EPCService _epcService;
        private readonly ConfigurationWriter _configurationWriter;
        private string _currentEpc;
        private readonly Stack<string> _pages = new();
        private Instrument_RFID _currentInstrument;
        private readonly AppSettingsBase _appSettingsBase;

        private ResourceManager Local_RM = new ResourceManager("TechnicalStation.WinFormStrings", typeof(ProgramInstrument).Assembly);
        private SoundPlayer _beepPlayer = new SoundPlayer(Resources.beep_ok);

        public ProgramInstrument(AppSettingsBase appSettings, TechnicalStationAppSettings technicalStationAppSettings, RFIDReaderCollection readerCollection, EventReporter eventReporter, 
            RFIDReaderCommon readerCommon, ILogger logger, EPCService epcService, ConfigurationWriter _configurationWriter)

        {
            _appSettingsBase = appSettings;
            _technicalStationAppSettings = technicalStationAppSettings;
            _rfidReader = readerCollection;
            _eventReporter = eventReporter;
            _readerCommon = readerCommon;
            _logger = logger;
            _epcService = epcService;
            this._configurationWriter = _configurationWriter;


            // **********************************************************************************************************************

            Function_Module.SQL_ConnectionString = _appSettingsBase.ConnectionStrings.SQLServer;
            Function_Module.The_Reader_Name = _appSettingsBase.StationUniqueID;
            Function_Module.DeskTopReader_Name = "TechnicalStation";
            Function_Module.Program_Name = "TechnicalStation";
            Function_Module.Program_User = "Pgr_Admin";
            Function_Module.Programs_Security_Level = 4;
            Text = string.Format("Technical Station - Caretag Aps All Copy Rights {0} - V: {1}", DateAndTime.Now.Year, Application.ProductVersion);
            // **********************************************************************************************************************
            var The_UI_Language = _appSettingsBase.UILanguage;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(The_UI_Language);
            InitializeComponent();
            Restart();

            SetInProgress(false);
            scanButton.Select();

            if (technicalStationAppSettings.ResetEnabled)
                resetButton.Visible = true;

            if (!technicalStationAppSettings.AccessPasswordEnabled)
            {
                accessPasswordTextBox.Visible = false;
                programTagAccessPasswordLabel.Visible = false;
            }

            productiondDateHintLabel.Text =
                System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
        }

        private void Restart()
        {
            tabWizardControl.SelectedIndex = 0;
            _pages.Clear();
            _currentEpc = null;
            _currentInstrument = null;
            progressBar.MarqueeAnimationSpeed = 0;
            instrumentTypeSearchTextBox.Text = "";
            instrumentTypeListBoxControl.DataSource = null;
        }
        
        CancellationTokenSource warningCancellationTokenSource = null;

        private void ShowMessage(string message, Color color)
        {
            try
            {
                messageTextBox.InvokeIfRequired(() =>
                {
                    messageTextBox.Text = message;
                    messageTextBox.BackColor = color;
                });
                if (warningCancellationTokenSource != null)
                {
                    warningCancellationTokenSource.Cancel();
                    warningCancellationTokenSource.Dispose();
                }

                warningCancellationTokenSource = new CancellationTokenSource();

                Task.Delay(4000).ContinueWith(t => ResetMessage(), warningCancellationTokenSource.Token);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error showing message");
            }
        }

        private void ResetMessage()
        {
            try
            {
                messageTextBox.InvokeIfRequired(() =>
                {
                    messageTextBox.BackColor = Color.White;
                    messageTextBox.ForeColor = Color.Black;
                    messageTextBox.Text = "";
                });
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error resetting message");
            }

        }

        private void SetInProgress(bool inProgress)
        {
            try
            {
                progressBar.InvokeIfRequired(() =>
                {
                    if (inProgress)
                    {
                        progressBar.Style = ProgressBarStyle.Marquee;
                        progressBar.MarqueeAnimationSpeed = 30;
                        progressBar.Value = 100;
                        progressBar.Enabled = false;
                    }
                    else
                    {
                        progressBar.Style = ProgressBarStyle.Blocks;
                        progressBar.Value = 0;
                        progressBar.Enabled = false;
                        progressBar.MarqueeAnimationSpeed = 0;
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error setting progress");
            }
        }

        private void scanButton_Click(object sender, EventArgs e)
        {
            try
            {
                scanButton.InvokeIfRequired(() => scanButton.Enabled = false);

                SetInProgress(true);

                _rfidReader.SubscribeAll(result =>
                {
                    var orderedBySignalStrength = result.OrderByDescending(x => x.SignalStrength).ToList();
                    var strongest = orderedBySignalStrength.First();
                    var minStrength = _technicalStationAppSettings.MinimumStrength == 0
                        ? -55
                        : _technicalStationAppSettings.MinimumStrength;
                    if (strongest.SignalStrength < minStrength)
                    {
                        ShowMessage(Local_RM.GetString("NoTagFound"), Color.Red);
                        return;
                    }

                    if (result.Length > 1 && strongest.SignalStrength <
                        orderedBySignalStrength.Skip(1).First().SignalStrength + 3)
                    {
                        ShowMessage(
                            Local_RM.GetString("OnlyOneTagShouldBeOnTheReader"),
                            Color.Coral);
                    }
                    else
                    {
                        _rfidReader.UnsubscribeAll();
                        _currentEpc = strongest.Value;

                        var assetInfo = getAssetInfo(_currentEpc);
                        if (assetInfo.Item1 == TagAssetState.KnownInstrument)
                            _currentInstrument = assetInfo.Item3;
                        instrumentReadLabel.InvokeIfRequired(
                            () => instrumentReadLabel.Text = $"Read tag with EPC: {_currentEpc}.\n{assetInfo.Item2}");
                        tabWizardControl.InvokeIfRequired(() => tabWizardControl.SelectedIndex = 1);
                        setTagReadButtonState();

                        ShowMessage(Local_RM.GetString("SuccessfullyTag"), Color.LightGreen);
                        SetInProgress(false);
                        scanButton.InvokeIfRequired(() => scanButton.Enabled = true);

                    }
                });

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error while scanning tag");
            }
        }

        private void setTagReadButtonState()
        {
            try
            {
                var assetInfo = getAssetInfo(_currentEpc);
                if (assetInfo.Item1 == TagAssetState.NotRecognized)
                {
                    programButton.InvokeIfRequired(() => programButton.Enabled = true);
                    instrumentReadLinkAssetButton.InvokeIfRequired(() => instrumentReadLinkAssetButton.Enabled = false);
                }
                else
                {
                    programButton.InvokeIfRequired(() => programButton.Enabled = false);
                    instrumentReadLinkAssetButton.InvokeIfRequired(() => instrumentReadLinkAssetButton.Enabled = true);
                }

                progressBar.InvokeIfRequired(() => progressBar.Value = 0);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error setting tag read button state");
            }
        }


        private Tuple<TagAssetState, string, Instrument_RFID> getAssetInfo(string epc)
        {
            try
            {
                if (!_epcService.MatchesGS1Prefix(epc))
                    return new Tuple<TagAssetState, string, Instrument_RFID>(TagAssetState.NotRecognized,
                        Local_RM.GetString(
"TagDoesNotMatchGS1Prefix"),
                        null);

                var instrument = _epcService.GetInstrumentRfidByEpc(epc);
                if (instrument != null)
                {
                    string instrumentDescription = null;
                    if (instrument.InstrumentDescription != null)
                    {
                        instrumentDescription =
                            $"{instrument.InstrumentDescription.Description_Name} {instrument.InstrumentDescription.D} {instrument.InstrumentDescription.E}";

                    }
                    
                    return new Tuple<TagAssetState, string, Instrument_RFID>(TagAssetState.KnownInstrument,
                        $"{Local_RM.GetString("TagMatchesInstrument")} {instrument.Description_ID} - {(instrumentDescription ?? instrument.Description_Text + Local_RM.GetString("ChangeInstrumentType"))}\nLot nr: {instrument.LotNumber ?? "Not set"}\nProduction date: {instrument.InstrumentProductionDate?.ToString(Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortDatePattern, Thread.CurrentThread.CurrentUICulture) ?? "Not set"}",
                        instrument);
                }
                var tray = _epcService.GetTrayRfidByEpc(epc);
                if (tray != null)
                    return new Tuple<TagAssetState, string, Instrument_RFID>(TagAssetState.KnownTray,
                         Local_RM.GetString("TagMatchesTray"), null);
                var container = _epcService.GetContainerRfidByEpc(epc);
                if (container != null)
                    return new Tuple<TagAssetState, string, Instrument_RFID>(TagAssetState.KnownContainer,
                        Local_RM.GetString("TagMatchesContainer"), null);

                return new Tuple<TagAssetState, string, Instrument_RFID>(TagAssetState.GS1Recognized,
                    Local_RM.GetString(
"NotRecognizedPrefix"),
                    null);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error while getting asset info");
                return null;
            }

        }


        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            bool isArrowKey = e.KeyCode == Keys.Up || e.KeyCode == Keys.Down ||
                              e.KeyCode == Keys.Left || e.KeyCode == Keys.Right;

            e.Handled = isArrowKey;
        }

        private void ProgramInstrument_Load(object sender, EventArgs e)
        {
            SplashScreen splash = null;
            try
            {
                tabWizardControl.Appearance = TabAppearance.FlatButtons;
                tabWizardControl.ItemSize = new Size(0, 1);
                tabWizardControl.SizeMode = TabSizeMode.Fixed;
                splash = new SplashScreen(_appSettingsBase.StationUniqueID, Local_RM.GetString("TechnicalStation"));

                Application.CurrentCulture = new CultureInfo("en-us");

                splash.Show();
                try
                {
                    splash.Message = Local_RM.GetString("ConnectingDB");
                    var theServerName = new SqlConnectionStringBuilder(Function_Module.SQL_ConnectionString).DataSource;
                    splash.Message = Local_RM.GetString("ConnectingDB") + theServerName;
                    var con = new SqlConnection();
                    con.ConnectionString = Function_Module.SQL_ConnectionString;
                    con.Open();
                    con.Close();
                }
                catch (Exception ex)
                {
                    _eventReporter.ReportError(ex, "An error occurred when trying to connect to the database", "An error occurred when trying to connect to the database", "TechnicalStation-1", true, true);
                    splash.Close();
                    Close();
                    Application.Exit();
                }

                splash.Message = Local_RM.GetString("FindingRFIDreader");

                _rfidReader.ConnectAll();
                if (_rfidReader.Count > 0)
                {
                    splash.Message = _readerCommon.GetReaderSplashScreenPresentationString(_rfidReader.Readers.First());

                    foreach (var reader in _rfidReader.Readers)
                    {
                        reader.GetDeviceInformation();
                    }
                }
                else
                {
                    splash.Message = Local_RM.GetString("NoReaderFound");
                    _eventReporter.ReportError("No RFID Readers found", "No RFID Readers found", "TechnicalStation-1", true, true);
                    splash.Close();
                    Close();
                    Application.Exit();

                }
                Application.DoEvents();
                splash.Close();
                readerPowerBar.InitTrackBar(new PowerTrackBarParams(){ActiveReaders = _rfidReader.Readers, PowerStepNames = new[]{"Lowest", "Lower", "Medium", "Higher", "Highest"}, PowerTitle = ""});

            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while loading the application", "An error occurred while loading the application", "TechnicalStation-2", true, true);

                splash.Close();
                Close();

                Application.Exit();
            }
        }


        private void saveInstrumentPreviousButton_Click(object sender, EventArgs e)
        {
            Restart();
        }

        private void instrumentTypeSearchTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void saveInstrumentNextButton_Click(object sender, EventArgs e)
        {
            try
            {
                saveInstrumentNextButton.InvokeIfRequired(() => saveInstrumentNextButton.Enabled = false);
                var assetInfo = getAssetInfo(_currentEpc);


                if (trayRadioButton.Checked)
                {
                    if (assetInfo.Item1 == TagAssetState.KnownContainer ||
                        assetInfo.Item1 == TagAssetState.KnownInstrument)
                    {
                        ShowMessage(
                            Local_RM.GetString("CannotChangeAssetTypeToTray"),
                            Color.Red);
                        return;
                    }
                    else if (assetInfo.Item1 == TagAssetState.KnownTray)
                    {
                        ShowMessage(Local_RM.GetString("AssetIsTray"), Color.LightBlue);
                        tabWizardControl.InvokeIfRequired(() => tabWizardControl.SelectedIndex = 0);
                        return;
                    }

                    _epcService.CreateNewTray(_currentEpc);
                    tabWizardControl.SelectedIndex = 0;
                    ShowMessage(Local_RM.GetString("TraySaved"), Color.LightGreen);
                    _beepPlayer.Play();
                    return;
                }
                else if (containerRadioButton.Checked)
                {
                    if (assetInfo.Item1 == TagAssetState.KnownTray || assetInfo.Item1 == TagAssetState.KnownInstrument)
                    {
                        ShowMessage(
                            Local_RM.GetString("CannotChangeAssetTypeToContainer"),
                            Color.Red);
                        return;
                    }
                    else if (assetInfo.Item1 == TagAssetState.KnownContainer)
                    {
                        ShowMessage(Local_RM.GetString("AssetIsContainer"), Color.LightBlue);
                        tabWizardControl.InvokeIfRequired(() => tabWizardControl.SelectedIndex = 0);
                        return;
                    }

                    _epcService.CreateNewContainer(_currentEpc);
                    tabWizardControl.SelectedIndex = 0;
                    ShowMessage(Local_RM.GetString("ContainerSaved"), Color.LightGreen);
                    _beepPlayer.Play();
                    return;
                }

                if (assetInfo.Item1 == TagAssetState.KnownTray || assetInfo.Item1 == TagAssetState.KnownContainer)
                {
                    ShowMessage(
                        Local_RM.GetString("CannotChangeAssetTypeToInstrument"),
                        Color.Red);
                    return;
                }

                if (instrumentTypeListBoxControl.SelectedValue == null)
                {
                    ShowMessage(Local_RM.GetString("SelectInstrument"), Color.Coral);
                    return;
                }
                if (lotTextBox.Text == "")
                {
                    ShowMessage(Local_RM.GetString("EnterLot"), Color.Coral);
                    return;
                }
                
                if (string.IsNullOrWhiteSpace(productionDateTextBox.Text))
                {
                    ShowMessage(Local_RM.GetString("EnterProductionDate"), Color.Coral);
                    return;
                }
                DateTime productionDate;
                
                if (productionDateTextBox.Text.Length < 8 || !DateTime.TryParse(productionDateTextBox.Text, Thread.CurrentThread.CurrentUICulture, DateTimeStyles.None, out productionDate))
                {
                    ShowMessage(Local_RM.GetString("ProductionDateFormatIncorrect"), Color.Coral);
                    return;
                }
                if (productionDate.Date > DateTime.Now.Date)
                {
                    ShowMessage(Local_RM.GetString("ProductionDateInFuture"), Color.Coral);
                    return;
                }


                var selectedType = (Instrument_Description)instrumentTypeListBoxControl.SelectedValue;
                SetInProgress(true);

                if (_currentInstrument != null)
                {
                    _currentInstrument.LotNumber = lotTextBox.Text;
                    _currentInstrument.InstrumentProductionDate = productionDate;
                    _epcService.UpdateInstrument(_currentInstrument, selectedType);
                }
                else
                    _epcService.CreateNewInstrument(_currentEpc, lotTextBox.Text, productionDate, selectedType);


                ShowMessage(Local_RM.GetString("InstrumentSaved"), Color.LightGreen);

                SetInProgress(false);
                _beepPlayer.Play();
                Restart();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error while saving instrument");
            }
            finally
            {
                saveInstrumentNextButton.InvokeIfRequired(() => saveInstrumentNextButton.Enabled = true);
            }
        }

        private void instrumentTypeSearchTextBox_Leave(object sender, EventArgs e)
        {
            Search();
        }

        private void instrumentTypeSearchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            lock (this)
            {
                if (!searchBackgroundWorker.IsBusy)
                    searchBackgroundWorker.RunWorkerAsync();
            }
        }

        private void searchBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var query = instrumentTypeSearchTextBox.Text;
                if (query.Length < 4)
                {

                    ShowMessage(Local_RM.GetString("Enter4CharactersForSearch"), Color.Coral);
                    return;
                }

                SetInProgress(true);

                if (instrumentTypeSearchTextBox.InvokeRequired)
                {
                    instrumentTypeSearchTextBox.Invoke(new MethodInvoker(() =>
                        instrumentTypeSearchTextBox.Enabled = false));
                }
                else
                {
                    instrumentTypeSearchTextBox.Enabled = false;
                }

                if (searchButton.InvokeRequired)
                {
                    searchButton.Invoke(new MethodInvoker(() => searchButton.Enabled = false));
                }
                else
                {
                    searchButton.Enabled = false;
                }

                var searchResult =
                    _epcService.SearchInstrumentType(query).ToList()
                        .Select(x => new
                        { Name = $"{x.Description_ID} {x.Description_Name} {x.D} {x.E}", Description = x }).ToArray();

                instrumentTypeListBoxControl.InvokeIfRequired(() =>
                {
                    instrumentTypeListBoxControl.DisplayMember = "Name";
                    instrumentTypeListBoxControl.ValueMember = "Description";
                    instrumentTypeListBoxControl.DataSource = searchResult;
                    SetInProgress(false);
                });

                instrumentTypeSearchTextBox.InvokeIfRequired(() => instrumentTypeSearchTextBox.Enabled = true);
                searchButton.InvokeIfRequired(() => searchButton.Enabled = true);

                e.Result = "";
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error while searching for instrument type");
            }
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            Restart();
        }


        private void linkAssetButton_Click(object sender, EventArgs e)
        {
            tabWizardControl.SelectedIndex = 2;

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private readonly Mutex programmingBackgroundWorkerMutex = new();
        private void programButton_Click(object sender, EventArgs e)
        {
            try
            {
                programmingBackgroundWorkerMutex.WaitOne();
                setProgrammingButtonsEnabled(false);

                if (programmingBackgroundWorker.IsBusy)
                {
                    ShowMessage("Programming in progress, please wait for programming to finish. ", Color.Coral);
                    return;
                }

                programmingBackgroundWorker.RunWorkerAsync();
            }
            catch (Exception exception)
            {
                _logger.Error(exception, "Error while starting programming. ");
            }
            finally
            {
                programmingBackgroundWorkerMutex.ReleaseMutex();
            }
        }

        private void setProgrammingButtonsEnabled(bool enabled)
        {
            programButton.InvokeIfRequired(() => programButton.Enabled = enabled);
            resetButton.InvokeIfRequired(() => resetButton.Enabled = enabled);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            try
            {
                setProgrammingButtonsEnabled(false);
                SetInProgress(true);
                var accessPassword = string.IsNullOrWhiteSpace(accessPasswordTextBox.Text)
                    ? "0"
                    : accessPasswordTextBox.Text;

                if (_epcService.ResetTag(accessPassword, msg => ShowMessage(msg, Color.Coral)).Item1)
                    ShowMessage(Local_RM.GetString("TagReset"), Color.LightGreen);
                else
                    ShowMessage(Local_RM.GetString("ErrorResettingTag"), Color.Coral);

                SetInProgress(false);
                setProgrammingButtonsEnabled(true);
                Restart();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error while resetting tag");
            }
        }

        private void instrumentRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            instrumentTypeGroupBox.Enabled = instrumentRadioButton.Checked;
            lotTextBox.Enabled = instrumentRadioButton.Checked;
            productionDateTextBox.Enabled = instrumentRadioButton.Checked;
        }

        private int getNextInternalIdAndUpdate()
        {
            if (_technicalStationAppSettings.NextInternalId == 0)
                return 0;
            var nextId = _technicalStationAppSettings.NextInternalId;
            
            _configurationWriter.UpdateConfigurationFile("appsettings.json", "NextInternalId", ++_technicalStationAppSettings.NextInternalId);
            return nextId;
        }
        
        private void programmingBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                SetInProgress(true);
                var accessPassword = string.IsNullOrWhiteSpace(accessPasswordTextBox.Text)
                    ? "0"
                    : accessPasswordTextBox.Text;

                ShowMessage(Local_RM.GetString("AttemptingToProgramTag"), Color.LightBlue);

                var uncommittedEpc = _epcService.CreateNewUncommittedEpc();
                
                for (int i = 0; i < 10; i++)
                {
                    var programmingResult =
                        _epcService.ProgramTag(accessPassword, uncommittedEpc, msg => ShowMessage(msg, Color.Coral));
                    if (programmingResult.Item1)
                    {
                        _currentEpc = programmingResult.Item2;
                        _epcService.CommitEpc(uncommittedEpc);
                        ShowMessage(Local_RM.GetString("TagProgrammed"), Color.LightGreen);
                        
                        var internalId = getNextInternalIdAndUpdate();
                        var msg =
                            $"Tag has been programmed! EPC: {_currentEpc}{(internalId > 0 ? ", Internal Id: " + internalId : "")}";
                        ShowMessage(msg, Color.LightGreen);
                        _logger.Information(msg);
                        _beepPlayer.Play();
                        
                        tabWizardControl.InvokeIfRequired(() => tabWizardControl.SelectedIndex = 2);
                        return;
                    }

                    Thread.Sleep(100);
                }

                //Todo: Scavenge unused ID?

                ShowMessage(
                    Local_RM.GetString("CouldNotProgramTag"),
                    Color.Coral);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error while programming tag");
            }
            finally
            {
                SetInProgress(false);
                e.Result = "";
                setProgrammingButtonsEnabled(true);
            }

        }

        private void programmingBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void ProgramInstrument_FormClosing(object sender, FormClosingEventArgs e)
        {
            _rfidReader.UnsubscribeAll();
            Thread.Sleep(100); // wait for the unsubscribe to finish
            _rfidReader.Dispose();
        }

        private void ProgramInstrument_FormClosed(object sender, FormClosedEventArgs e)
        {
            //If it's still not dead let's make sure...

            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void frontPageGroupBox_Enter(object sender, EventArgs e)
        {

        }
    }
}
