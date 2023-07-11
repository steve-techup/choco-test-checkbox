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
using TechnicalStation.Configuration;
using TechnicalStation.Services;
using UIControls;
using Caretag_Class.Util;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using TechnicalStation.My.Resources;
using System.Media;
using DevExpress.LookAndFeel.Design;
using RFIDAbstractionLayer.TagEncoding;
using DevExpress.DashboardCommon.Native.DashboardRestfulService;
using TechnicalStation.Infrastructure;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Microsoft.Extensions.Logging;
using Caretag.Contracts.Enums;
using OnScreenKeyboard;
using Main.Extensions;
using Caretag.Contracts.Api.v1;

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
            KnownContainer,
            ErrorScanning,
            KnownTrolley,
            KnownSterilizationCart
        }

        //private readonly TechnicalStationAppSettings _technicalStationAppSettings;
        private readonly RFIDReaderCollection _rfidReader;
        private readonly EventReporter _eventReporter;
        private readonly RFIDReaderCommon _readerCommon;
        private readonly ILogger<ProgramInstrument> _logger;
        private readonly EPCService _epcService;
        private readonly ConfigurationWriter _configurationWriter;
        private string _currentEpc;
        private readonly Stack<string> _pages = new();
        private Instrument_RFID _currentInstrument;
        private readonly AppSettingsBase _appSettingsBase;
        private int? _assetTagId;
        private readonly IDataRepository _dataRepository;   

        private ResourceManager Local_RM = new ResourceManager("TechnicalStation.WinFormStrings", typeof(ProgramInstrument).Assembly);
        private SoundPlayer _beepPlayer = new SoundPlayer(Resources.beep_ok);
        private TechnicalStationConfig _technicalStationConfig;

        public ProgramInstrument(
            AppSettingsBase appSettings, 
            //TechnicalStationAppSettings technicalStationAppSettings, 
            RFIDReaderCollection readerCollection, 
            EventReporter eventReporter,
            RFIDReaderCommon readerCommon, 
            ILogger<ProgramInstrument> logger, 
            EPCService epcService, 
            ConfigurationWriter _configurationWriter, 
            IDataRepository dataRepository)

        {
            _appSettingsBase = appSettings;
            //_technicalStationAppSettings = technicalStationAppSettings;
            _rfidReader = readerCollection;
            _eventReporter = eventReporter;
            _readerCommon = readerCommon;
            _logger = logger;
            _epcService = epcService;
            _dataRepository = dataRepository;
            this._configurationWriter = _configurationWriter;


            // **********************************************************************************************************************

            Function_Module.The_Reader_Name = _appSettingsBase.StationUniqueID;
            Function_Module.DeskTopReader_Name = "TechnicalStation";
            Function_Module.Program_Name = "TechnicalStation";
            Function_Module.Program_User = "Pgr_Admin";
            Function_Module.Programs_Security_Level = 4;
            Text = string.Format("Technical Station - Caretag Aps All Copy Rights {0} - V: {1}", DateAndTime.Now.Year, Application.ProductVersion);
            // **********************************************************************************************************************
            
            InitializeComponent();
            Restart();

            SetInProgress(false);
            scanButton.Select();

            productiondDateHintLabel.Text =
                System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;


            foreach (var control in ControlExtensions.GetAllControlsRecusrvive<TextBox>(this).Where(c => c.Name != "messageTextBox"))
            {
                OskUiController.Instance.AddControl(control);
            }
        }

        private void Restart()
        {
            SetInProgress(false);
            _assetTagId = null;
            tabWizardControl.SelectedIndex = 0;
            _pages.Clear();
            _currentEpc = null;
            _currentInstrument = null;
            lotTextBox.Text = "";
            productionDateTextBox.Text = "";
            progressBar.MarqueeAnimationSpeed = 0;
            instrumentTypeSearchTextBox.Text = "";
            instrumentTypeListBoxControl.DataSource = null;
            instrumentRadioButton.InvokeIfRequired(() => instrumentRadioButton.Checked = true);
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
                _logger.LogError(ex, "Error showing message");
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
                _logger.LogError(ex, "Error resetting message");
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
                _logger.LogError(ex, "Error setting progress");
            }
        }

        private void scanButton_Click(object sender, EventArgs e)
        {
            try
            {
                scanButton.InvokeIfRequired(() => scanButton.Enabled = false);
                resetButton.InvokeIfRequired(() => resetButton.Enabled = true);

                SetInProgress(true);

                _rfidReader.SubscribeAll(async result =>
                {
                    var orderedBySignalStrength = result.OrderByDescending(x => x.SignalStrength).ToList();
                    var strongest = orderedBySignalStrength.First();
                    var minStrength = _technicalStationConfig.AppSettings.MinimumStrength == 0
                        ? -55
                        : _technicalStationConfig.AppSettings.MinimumStrength;
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

                        var assetInfo = await getAssetInfo(_currentEpc);

                        if (assetInfo.Item1 == TagAssetState.ErrorScanning)
                        {
                            setTagReadButtonState(assetInfo);
                            ShowMessage(Local_RM.GetString("ErrorGettingAssetInfo"), Color.Coral);
                        }
                        else
                        {
                            if (assetInfo.Item1 == TagAssetState.KnownInstrument || 
                                assetInfo.Item1 == TagAssetState.KnownTray || 
                                assetInfo.Item1 == TagAssetState.KnownContainer || 
                                assetInfo.Item1 == TagAssetState.KnownTrolley ||
                                assetInfo.Item1 == TagAssetState.KnownSterilizationCart)
                            {
                                _currentInstrument = assetInfo.Item2;
                                containerRadioButton.InvokeIfRequired(() => containerRadioButton.Checked = assetInfo.Item1 == TagAssetState.KnownContainer);
                                trayRadioButton.InvokeIfRequired(() => trayRadioButton.Checked = assetInfo.Item1 == TagAssetState.KnownTray);
                                trolleyRadioButton.InvokeIfRequired(() => trolleyRadioButton.Checked = assetInfo.Item1 == TagAssetState.KnownTrolley);
                                sterilizationCartRadioButton.InvokeIfRequired(() => sterilizationCartRadioButton.Checked = assetInfo.Item1 == TagAssetState.KnownSterilizationCart);
                            }
                            else
                                resetButton.InvokeIfRequired(() => resetButton.Enabled = false);



                            if (assetInfo.Item1 == TagAssetState.GS1Recognized)
                            {
                                instrumentReadLabel.InvokeIfRequired(() => instrumentReadLabel.Text = Local_RM.GetString("NotRecognizedPrefix"));
                            }
                            else if (assetInfo.Item1 == TagAssetState.NotRecognized)
                            {
                                instrumentReadLabel.InvokeIfRequired(() => instrumentReadLabel.Text = Local_RM.GetString("TagDoesNotMatchGS1Prefix"));
                            }
                            else
                            {
                                SetAssetDetailsText(assetInfo.Item3);
                            }

                            //instrumentReadLabel.InvokeIfRequired(
                            //    () => instrumentReadLabel.Text = $"Read tag with EPC: {_currentEpc}.\n{assetInfo.Item2}");
                            tabWizardControl.InvokeIfRequired(() => tabWizardControl.SelectedIndex = 1);
                            setTagReadButtonState(assetInfo);

                            ShowMessage(Local_RM.GetString("SuccessfullyTag"), Color.LightGreen);
                        }
                        SetInProgress(false);
                        scanButton.InvokeIfRequired(() => scanButton.Enabled = true);
                    }
                });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while scanning tag");
            }
        }

        private void SetAssetDetailsText(AssetDetailsItem details)
        {
            if (details == null)
            {
                instrumentReadLabel.InvokeIfRequired(() => instrumentReadLabel.Text = Local_RM.GetString("ErrorGettingAssetInfo"));
                return;
            }

            var assetInfoText = new StringBuilder();
            assetInfoText.AppendLine(Local_RM.GetString("RfidSuccessfullyScanned"));
            assetInfoText.AppendLine();
            assetInfoText.AppendLine($"EPC: {details.Epc}");
            assetInfoText.AppendLine($"{Local_RM.GetString("Type")}: {details.Type}");

            if (!string.IsNullOrEmpty(details.Name))
                assetInfoText.AppendLine($"{Local_RM.GetString("Name")}: {details.Name}");

            if (!string.IsNullOrEmpty(details.Description))
                assetInfoText.AppendLine($"{Local_RM.GetString("Description")}: {details.Description}");

            if (!string.IsNullOrEmpty(details.Status) && _appSettingsBase.UseApi)
                assetInfoText.AppendLine($"{Local_RM.GetString("Status")}: {details.Status}");

            assetInfoText.AppendLine();
            if (!string.IsNullOrEmpty(details.Sku))
                assetInfoText.AppendLine($"{Local_RM.GetString("ArticleSKU")}: {details.Sku}");

            if (!string.IsNullOrEmpty(details.Manufacturer))
                assetInfoText.AppendLine($"{Local_RM.GetString("Manufacturer")}: {details.Manufacturer}");


            if (!string.IsNullOrEmpty(details.LotNumber))
                assetInfoText.AppendLine($"{Local_RM.GetString("LotNo")}: {details.LotNumber}");

            if (details.ManufacturingDate != null)
                assetInfoText.AppendLine($"{Local_RM.GetString("ManufacturingDate")}: {details.ManufacturingDate.Value.ToString("MM/dd/yyyy")}");

            assetInfoText.AppendLine();
            if (details.Status == "Active")
                assetInfoText.AppendLine(Local_RM.GetString("ActiveAssetOptions"));
            else
                assetInfoText.AppendLine(Local_RM.GetString("InactiveAssetOptions"));

            instrumentReadLabel.InvokeIfRequired(() => instrumentReadLabel.Text = assetInfoText.ToString());
        }

        private async void setTagReadButtonState(Tuple<TagAssetState, Instrument_RFID, AssetDetailsItem> assetInfo)
        {
            try
            {
                //var assetInfo = await getAssetInfo(_currentEpc);
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

                var allowedStatuses = new List<string> { "Active", "Locked" };

                if (assetInfo.Item3 != null && !allowedStatuses.Contains(assetInfo.Item3.Status))
                {
                    resetButton.InvokeIfRequired(() => resetButton.Enabled = false);
                    programButton.InvokeIfRequired(() => programButton.Enabled = false);
                    instrumentReadLinkAssetButton.InvokeIfRequired(() => instrumentReadLinkAssetButton.Enabled = false);
                }

                progressBar.InvokeIfRequired(() => progressBar.Value = 0);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error setting tag read button state");
            }
        }


        private async Task<Tuple<TagAssetState, Instrument_RFID, AssetDetailsItem>> getAssetInfo(string epc)
        {
            try
            {
                var assetTag = await _dataRepository.GetAssetTag(epc);
                if (!(await _epcService.MatchesGS1Prefix(epc)) || assetTag == null || !assetTag.Item1)
                    return new Tuple<TagAssetState, Instrument_RFID, AssetDetailsItem>(TagAssetState.NotRecognized, null, null);

                _assetTagId = assetTag.Item2;
                var instrument = await _dataRepository.GetInstrumentRfidByEpc(epc);

                if (instrument != null && instrument.Item1 != null)
                {
                    return new Tuple<TagAssetState, Instrument_RFID, AssetDetailsItem>(TagAssetState.KnownInstrument, instrument.Item1, instrument.Item2);
                }


                var tray = await _dataRepository.GetTrayRfidByEpc(epc);
                if (tray != null && tray.Item1 != null)
                {
                    var instrumentRfid = new Instrument_RFID
                    {
                        Instrument_ID = tray.Item1.Tray_ID,
                        Description_ID = tray.Item1.Description_ID.ToString(),
                        InstrumentProductionDate = tray.Item2?.ManufacturingDate,
                        LotNumber = tray.Item2.LotNumber
                    };
                    return new Tuple<TagAssetState, Instrument_RFID, AssetDetailsItem>(TagAssetState.KnownTray, instrumentRfid, tray.Item2);
                }

                var container = await _dataRepository.GetContainerRfidByEpc(epc);
                if (container != null && container.Item1 != null)
                {
                    var instrumentRfid = new Instrument_RFID
                    {
                        Instrument_ID = container.Item1.Container_ID,
                        Description_ID = container.Item1.Description_ID.ToString(),
                        InstrumentProductionDate = container.Item2?.ManufacturingDate,
                        LotNumber = container.Item2.LotNumber
                    };
                    return new Tuple<TagAssetState, Instrument_RFID, AssetDetailsItem>(TagAssetState.KnownContainer, instrumentRfid, container.Item2);
                }

                if (_appSettingsBase.UseApi)
                {
                    var trolley = await _dataRepository.GetTrolleyRfidByEpc(epc);

                    if (trolley != null && trolley.Item1 != null)
                    {
                        return new Tuple<TagAssetState, Instrument_RFID, AssetDetailsItem>(TagAssetState.KnownTrolley, trolley.Item1, trolley.Item2);
                    }

                    var sterilizationCart = await _dataRepository.GetSterilizationCartRfidByEpc(epc);

                    if (sterilizationCart != null && sterilizationCart.Item1 != null)
                    {
                        var instrumentRfid = new Instrument_RFID
                        {
                            Instrument_ID = sterilizationCart.Item1.Tray_ID,
                            Description_ID = sterilizationCart.Item1.Description_ID.ToString(),
                            InstrumentProductionDate = sterilizationCart.Item2?.ManufacturingDate,
                            LotNumber = sterilizationCart.Item2.LotNumber
                        };
                        return new Tuple<TagAssetState, Instrument_RFID, AssetDetailsItem>(TagAssetState.KnownSterilizationCart, instrumentRfid, sterilizationCart.Item2);
                    }
                }

                return new Tuple<TagAssetState, Instrument_RFID, AssetDetailsItem>(TagAssetState.GS1Recognized, null, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting asset info");
                return new Tuple<TagAssetState, Instrument_RFID, AssetDetailsItem>(TagAssetState.ErrorScanning, null, null);
            }
        }

        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            bool isArrowKey = e.KeyCode == Keys.Up || e.KeyCode == Keys.Down ||
                              e.KeyCode == Keys.Left || e.KeyCode == Keys.Right;

            e.Handled = isArrowKey;
        }

        private async void ProgramInstrument_Load(object sender, EventArgs e)
        {
            SplashScreen splash = null;
            try
            {

                splash = new SplashScreen(_appSettingsBase.StationUniqueID, Local_RM.GetString("TechnicalStation"));

                tabWizardControl.Appearance = TabAppearance.FlatButtons;
                tabWizardControl.ItemSize = new Size(0, 1);
                tabWizardControl.SizeMode = TabSizeMode.Fixed;
                Application.CurrentCulture = new CultureInfo("en-us");

                splash.Show();

                if (!_appSettingsBase.UseApi)
                {
                    trolleyRadioButton.Visible = false;
                    groupBox1.InvokeIfRequired(() => groupBox1.Size = new Size(groupBox1.Width, 115));
                    //If using the old implementation
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
                }
                else
                {
                    if (_appSettingsBase.AppData == null || string.IsNullOrEmpty(_appSettingsBase.AppData.AppInstanceId))
                    {
                        _eventReporter.ReportFatal(null, Local_RM.GetString("AppinstanceIdMissing"),
                                                         "AppInstanceId is missing. Please ensure that the configuration contains an AppData section containing the AppInstanceId and restart the application.",
                                                         "TechnicalStation-1", true, true);
                        splash.Close();
                        Close();
                        Environment.Exit(0);
                    }
                }
                _technicalStationConfig = await _dataRepository.GetStationConfig();

                TopTitle.Text = _technicalStationConfig.StationName;


                if (_technicalStationConfig.AppSettings.ResetEnabled == true)
                    resetButton.Visible = true;

                if (!_technicalStationConfig.AppSettings.AccessPasswordEnabled)
                {
                    accessPasswordTextBox.Visible = false;
                    programTagAccessPasswordLabel.Visible = false;
                }

                splash.Message = Local_RM.GetString("FindingRFIDreader");

                _rfidReader.ConnectAll(_technicalStationConfig.RFID);
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
                readerPowerBar.InitTrackBar(new PowerTrackBarParams() { ActiveReaders = _rfidReader.Readers, PowerStepNames = new[] { "Lowest", "Lower", "Medium", "Higher", "Highest" }, PowerTitle = "" });

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

        private async void saveInstrumentNextButton_Click(object sender, EventArgs e)
        {
            try
            {

                if (instrumentTypeListBoxControl.SelectedValue == null)
                {
                    ShowMessage(Local_RM.GetString("SelectInstrument"), Color.Coral);
                    SetInProgress(false);
                    return;
                }

                var selectedType = (Instrument_Description)instrumentTypeListBoxControl.SelectedValue;

                SetInProgress(true);
                saveInstrumentNextButton.InvokeIfRequired(() => saveInstrumentNextButton.Enabled = false);
                var assetInfo = await getAssetInfo(_currentEpc);


                if (trayRadioButton.Checked)
                {
                    if (assetInfo.Item1 == TagAssetState.KnownContainer ||
                        assetInfo.Item1 == TagAssetState.KnownInstrument ||
                        assetInfo.Item1 == TagAssetState.KnownTrolley ||
                        assetInfo.Item1 == TagAssetState.KnownSterilizationCart)
                    {
                        ShowMessage(
                            Local_RM.GetString("CannotChangeAssetTypeToTray"),
                            Color.Red);
                        SetInProgress(false);
                        return;
                    }
                    else
                    {
                        DateTime manufacturingDate;

                        if (_appSettingsBase.UseApi)
                        {
                            if (productionDateTextBox.Text.Length < 8 || !DateTime.TryParse(productionDateTextBox.Text, Thread.CurrentThread.CurrentUICulture, DateTimeStyles.None, out manufacturingDate))
                            {
                                ShowMessage(Local_RM.GetString("ProductionDateFormatIncorrect"), Color.Coral);
                                SetInProgress(false);
                                return;
                            }
                            if (manufacturingDate.Date > DateTime.Now.Date)
                            {
                                ShowMessage(Local_RM.GetString("ProductionDateInFuture"), Color.Coral);
                                SetInProgress(false);
                                return;
                            }
                        }
                        else
                            manufacturingDate = default;

                        if (assetInfo.Item1 == TagAssetState.KnownTray)
                        {
                            if (_appSettingsBase.UseApi)
                            {
                                await _dataRepository.UpdateInstrument(assetInfo.Item2, selectedType, lotTextBox.Text, manufacturingDate);
                                tabWizardControl.SelectedIndex = 0;
                                ShowMessage(Local_RM.GetString("TraySaved"), Color.LightGreen);
                                _beepPlayer.Play();
                                Restart();
                                return;
                            }

                            ShowMessage(Local_RM.GetString("AssetIsTray"), Color.LightBlue);
                            tabWizardControl.InvokeIfRequired(() => tabWizardControl.SelectedIndex = 0);
                            Restart();
                            return;
                        }

                        await _dataRepository.CreateNewTray(_currentEpc, _assetTagId, _appSettingsBase.UseApi ? lotTextBox.Text : null, _appSettingsBase.UseApi ? manufacturingDate : null, selectedType);
                        tabWizardControl.SelectedIndex = 0;
                        ShowMessage(Local_RM.GetString("TraySaved"), Color.LightGreen);
                        _beepPlayer.Play();
                        Restart();
                        return;
                    }
                }
                else if (containerRadioButton.Checked)
                {

                    if (assetInfo.Item1 == TagAssetState.KnownTray ||
                        assetInfo.Item1 == TagAssetState.KnownInstrument ||
                        assetInfo.Item1 == TagAssetState.KnownTrolley ||
                        assetInfo.Item1 == TagAssetState.KnownSterilizationCart)
                    {
                        ShowMessage(
                            Local_RM.GetString("CannotChangeAssetTypeToContainer"),
                            Color.Red);
                        SetInProgress(false);
                        return;
                    }
                    else
                    {
                        DateTime manufacturingDate;

                        if (_appSettingsBase.UseApi)
                        {
                            if (productionDateTextBox.Text.Length < 8 || !DateTime.TryParse(productionDateTextBox.Text, Thread.CurrentThread.CurrentUICulture, DateTimeStyles.None, out manufacturingDate))
                            {
                                ShowMessage(Local_RM.GetString("ProductionDateFormatIncorrect"), Color.Coral);
                                SetInProgress(false);
                                return;
                            }
                            if (manufacturingDate.Date > DateTime.Now.Date)
                            {
                                ShowMessage(Local_RM.GetString("ProductionDateInFuture"), Color.Coral);
                                SetInProgress(false);
                                return;
                            }
                        }
                        else
                            manufacturingDate = default;

                        if (assetInfo.Item1 == TagAssetState.KnownContainer)
                        {
                            if (_appSettingsBase.UseApi)
                            {
                                await _dataRepository.UpdateInstrument(assetInfo.Item2, selectedType, lotTextBox.Text, manufacturingDate);
                                tabWizardControl.SelectedIndex = 0;
                                ShowMessage(Local_RM.GetString("ContainerSaved"), Color.LightGreen);
                                _beepPlayer.Play();
                                Restart();
                                return;
                            }

                            ShowMessage(Local_RM.GetString("AssetIsContainer"), Color.LightBlue);
                            tabWizardControl.InvokeIfRequired(() => tabWizardControl.SelectedIndex = 0);
                            Restart();
                            return;
                        }

                        await _dataRepository.CreateNewContainer(_currentEpc, _assetTagId, _appSettingsBase.UseApi ? lotTextBox.Text : null, _appSettingsBase.UseApi ? manufacturingDate : null, selectedType);
                        tabWizardControl.SelectedIndex = 0;
                        ShowMessage(Local_RM.GetString("ContainerSaved"), Color.LightGreen);
                        _beepPlayer.Play();
                        Restart();
                        return;
                    }

                }
                else if (trolleyRadioButton.Checked)
                {

                    if (assetInfo.Item1 == TagAssetState.KnownTray ||
                        assetInfo.Item1 == TagAssetState.KnownInstrument ||
                        assetInfo.Item1 == TagAssetState.KnownContainer)
                    {
                        ShowMessage(
                            Local_RM.GetString("CannotChangeAssetTypeToTrolley"),
                            Color.Red);
                        SetInProgress(false);
                        return;
                    }
                    else
                    {
                        DateTime manufacturingDate;

                        if (productionDateTextBox.Text.Length < 8 || !DateTime.TryParse(productionDateTextBox.Text, Thread.CurrentThread.CurrentUICulture, DateTimeStyles.None, out manufacturingDate))
                        {
                            ShowMessage(Local_RM.GetString("ProductionDateFormatIncorrect"), Color.Coral);
                            SetInProgress(false);
                            return;
                        }
                        if (manufacturingDate.Date > DateTime.Now.Date)
                        {
                            ShowMessage(Local_RM.GetString("ProductionDateInFuture"), Color.Coral);
                            SetInProgress(false);
                            return;
                        }

                        if (assetInfo.Item1 == TagAssetState.KnownTrolley)
                        {
                            if (_appSettingsBase.UseApi)
                            {
                                await _dataRepository.UpdateInstrument(assetInfo.Item2, selectedType, lotTextBox.Text, manufacturingDate);
                                tabWizardControl.SelectedIndex = 0;
                                ShowMessage(Local_RM.GetString("TrolleySaved"), Color.LightGreen);
                                _beepPlayer.Play();
                                Restart();
                                return;
                            }
                        }

                        if (assetInfo.Item1 == TagAssetState.KnownSterilizationCart)
                        {
                            if (_appSettingsBase.UseApi)
                            {
                                await _dataRepository.UpdateInstrument(assetInfo.Item2, selectedType, lotTextBox.Text, manufacturingDate);
                                tabWizardControl.SelectedIndex = 0;
                                ShowMessage(Local_RM.GetString("SterilizationCartSaved"), Color.LightGreen);
                                _beepPlayer.Play();
                                Restart();
                                return;
                            }
                        }

                        await _dataRepository.CreateNewTrolley(_currentEpc, _assetTagId, _appSettingsBase.UseApi ? lotTextBox.Text : null, _appSettingsBase.UseApi ? manufacturingDate : null, selectedType);
                        tabWizardControl.SelectedIndex = 0;
                        ShowMessage(Local_RM.GetString("TrolleySaved"), Color.LightGreen);
                        _beepPlayer.Play();
                        Restart();
                        return;
                    }

                }
                else if (sterilizationCartRadioButton.Checked)
                {
                    if (assetInfo.Item1 == TagAssetState.KnownContainer ||
                        assetInfo.Item1 == TagAssetState.KnownInstrument ||
                        assetInfo.Item1 == TagAssetState.KnownTrolley ||
                        assetInfo.Item1 == TagAssetState.KnownTray)
                    {
                        ShowMessage(
                            Local_RM.GetString("CannotChangeAssetTypeToSterilizationCart"),
                            Color.Red);
                        SetInProgress(false);
                        return;
                    }
                    else
                    {
                        DateTime manufacturingDate;

                        if (_appSettingsBase.UseApi)
                        {
                            if (productionDateTextBox.Text.Length < 8 || !DateTime.TryParse(productionDateTextBox.Text, Thread.CurrentThread.CurrentUICulture, DateTimeStyles.None, out manufacturingDate))
                            {
                                ShowMessage(Local_RM.GetString("ProductionDateFormatIncorrect"), Color.Coral);
                                SetInProgress(false);
                                return;
                            }
                            if (manufacturingDate.Date > DateTime.Now.Date)
                            {
                                ShowMessage(Local_RM.GetString("ProductionDateInFuture"), Color.Coral);
                                SetInProgress(false);
                                return;
                            }
                        }
                        else
                            manufacturingDate = default;

                        if (assetInfo.Item1 == TagAssetState.KnownSterilizationCart)
                        {
                            if (_appSettingsBase.UseApi)
                            {
                                await _dataRepository.UpdateInstrument(assetInfo.Item2, selectedType, lotTextBox.Text, manufacturingDate);
                                tabWizardControl.SelectedIndex = 0;
                                ShowMessage(Local_RM.GetString("SterilizationCartSaved"), Color.LightGreen);
                                _beepPlayer.Play();
                                Restart();
                                return;
                            }

                            ShowMessage(Local_RM.GetString("AssetIsTray"), Color.LightBlue);
                            tabWizardControl.InvokeIfRequired(() => tabWizardControl.SelectedIndex = 0);
                            Restart();
                            return;
                        }

                        await _dataRepository.CreateNewSterilizationCart(_currentEpc, _assetTagId, _appSettingsBase.UseApi ? lotTextBox.Text : null, _appSettingsBase.UseApi ? manufacturingDate : null, selectedType);
                        tabWizardControl.SelectedIndex = 0;
                        ShowMessage(Local_RM.GetString("SterilizationCartSaved"), Color.LightGreen);
                        _beepPlayer.Play();
                        Restart();
                        return;
                    }
                }

                if (assetInfo.Item1 == TagAssetState.KnownTray || 
                    assetInfo.Item1 == TagAssetState.KnownContainer || 
                    assetInfo.Item1 == TagAssetState.KnownTrolley ||
                    assetInfo.Item1 == TagAssetState.KnownSterilizationCart)
                {
                    ShowMessage(
                        Local_RM.GetString("CannotChangeAssetTypeToInstrument"),
                        Color.Red);
                    SetInProgress(false);
                    return;
                }
                if (lotTextBox.Text == "")
                {
                    ShowMessage(Local_RM.GetString("EnterLot"), Color.Coral);
                    SetInProgress(false);
                    return;
                }

                if (string.IsNullOrWhiteSpace(productionDateTextBox.Text))
                {
                    ShowMessage(Local_RM.GetString("EnterProductionDate"), Color.Coral);
                    SetInProgress(false);
                    return;
                }
                DateTime productionDate;

                if (productionDateTextBox.Text.Length < 8 || !DateTime.TryParse(productionDateTextBox.Text, Thread.CurrentThread.CurrentUICulture, DateTimeStyles.None, out productionDate))
                {
                    ShowMessage(Local_RM.GetString("ProductionDateFormatIncorrect"), Color.Coral);
                    SetInProgress(false);
                    return;
                }
                if (productionDate.Date > DateTime.Now.Date)
                {
                    ShowMessage(Local_RM.GetString("ProductionDateInFuture"), Color.Coral);
                    SetInProgress(false);
                    return;
                }



                if (_currentInstrument != null)
                {
                    _currentInstrument.LotNumber = lotTextBox.Text;
                    _currentInstrument.InstrumentProductionDate = productionDate;
                    await _dataRepository.UpdateInstrument(_currentInstrument, selectedType, lotTextBox.Text, productionDate);
                }
                else
                    await _dataRepository.CreateNewInstrument(_currentEpc, lotTextBox.Text, productionDate, selectedType, _assetTagId);


                ShowMessage(Local_RM.GetString("InstrumentSaved"), Color.LightGreen);

                SetInProgress(false);
                _beepPlayer.Play();
                Restart();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while saving instrument");
                ShowMessage(Local_RM.GetString("InstrumentSaveError"), Color.Coral);
                SetInProgress(false);
            }
            finally
            {
                saveInstrumentNextButton.InvokeIfRequired(() => saveInstrumentNextButton.Enabled = true);
            }
        }

        private void instrumentTypeSearchTextBox_Leave(object sender, EventArgs e)
        {
            Search();
            textBox_Leave(sender, e);
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

        private async void searchBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
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

                var classTypes = new AssetClassType[] { AssetClassType.Instrument };

                if (trayRadioButton.Checked)
                {
                    classTypes = new AssetClassType[] { AssetClassType.Tray } ;
                }
                else if (containerRadioButton.Checked)
                {
                    classTypes = new AssetClassType[] { AssetClassType.Container };
                }
                else if (trolleyRadioButton.Checked)
                {
                    classTypes = new AssetClassType[] { AssetClassType.TrolleyOpen, AssetClassType.TrolleyClosed };
                }
                else if (sterilizationCartRadioButton.Checked)
                {
                    classTypes = new AssetClassType[] { AssetClassType.SterilizationCart };
                }

                var searchResult =
                    (await _dataRepository.SearchInstrumentType(query, classTypes))
                        .Select(x => new
                        { Name = $"{x.E} {x.Description_Name} {x.D} {x.E}", Description = x }).ToArray();

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
                _logger.LogError(ex, "Error while searching for instrument type");
                ShowMessage(Local_RM.GetString("InstrumentTypeSearchError"), Color.Coral);
                instrumentTypeSearchTextBox.InvokeIfRequired(() => instrumentTypeSearchTextBox.Enabled = true);
                searchButton.InvokeIfRequired(() => searchButton.Enabled = true);
                SetInProgress(false);
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
                _logger.LogError(exception, "Error while starting programming. ");
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

        private async void resetButton_Click(object sender, EventArgs e)
        {
            try
            {
                SetInProgress(true);
                resetButton.InvokeIfRequired(() => resetButton.Enabled = false);
                instrumentReadLinkAssetButton.InvokeIfRequired(() => instrumentReadLinkAssetButton.Enabled = false);
                restartButton.InvokeIfRequired(() => restartButton.Enabled = false);
                var accessPassword = string.IsNullOrWhiteSpace(accessPasswordTextBox.Text)
                    ? "0"
                    : accessPasswordTextBox.Text;

                if ((await _epcService.ResetTag(accessPassword, msg => ShowMessage(msg, Color.Coral), _currentInstrument.Instrument_ID, _currentInstrument.LotNumber, _currentInstrument.InstrumentProductionDate)).Item1)
                {
                    ShowMessage(Local_RM.GetString("TagReset"), Color.LightGreen);
                    _beepPlayer.Play();
                }
                else
                    ShowMessage(Local_RM.GetString("ErrorResettingTag"), Color.Coral);

                programButton.InvokeIfRequired(() => resetButton.Enabled = true);
                Restart();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while resetting tag");
                ShowMessage(Local_RM.GetString("ErrorResettingTag"), Color.Coral);
            }
            finally
            {
                instrumentReadLinkAssetButton.InvokeIfRequired(() => instrumentReadLinkAssetButton.Enabled = true);
                restartButton.InvokeIfRequired(() => restartButton.Enabled = true);
                resetButton.InvokeIfRequired(() => resetButton.Enabled = true);
                SetInProgress(false);
            }
        }

        private void instrumentRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //instrumentTypeGroupBox.Enabled = instrumentRadioButton.Checked;

            //if (!_appSettingsBase.UseApi)
            //{
            //    lotTextBox.Enabled = instrumentRadioButton.Checked;
            //    productionDateTextBox.Enabled = instrumentRadioButton.Checked;
            //}
        }

        private int getNextInternalIdAndUpdate()
        {
            if (_technicalStationConfig.AppSettings.NextInternalId == 0)
                return 0;
            var nextId = _technicalStationConfig.AppSettings.NextInternalId;

            _configurationWriter.UpdateConfigurationFile("appsettings.json", "NextInternalId", ++_technicalStationConfig.AppSettings.NextInternalId);
            return nextId;
        }

        private async void programmingBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                SetInProgress(true);
                var accessPassword = string.IsNullOrWhiteSpace(accessPasswordTextBox.Text)
                    ? "0"
                    : accessPasswordTextBox.Text;

                ShowMessage(Local_RM.GetString("AttemptingToProgramTag"), Color.LightBlue);

                var uncommittedEpc = await _dataRepository.CreateNewUncommittedEpc(_epcService.Gs1CompanyPrefix, _epcService.TenantId);

                if (_technicalStationConfig.RFID.ReaderType != RFIDAbstractionLayer.ReaderType.Simulator)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        var programmingResult =
                            _epcService.ProgramTag(accessPassword, uncommittedEpc, msg => ShowMessage(msg, Color.Coral));
                        if (programmingResult.Item1)
                        {
                            _currentEpc = programmingResult.Item2;
                            await _dataRepository.CommitEpc(uncommittedEpc);
                            ShowMessage(Local_RM.GetString("TagProgrammed"), Color.LightGreen);

                            var internalId = getNextInternalIdAndUpdate();
                            var msg =
                                $"Tag has been programmed! EPC: {_currentEpc}{(internalId > 0 ? ", Internal Id: " + internalId : "")}";
                            ShowMessage(msg, Color.LightGreen);
                            _logger.LogInformation(msg);
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
                else
                {
                    _currentEpc = uncommittedEpc.ToString();
                    _assetTagId = uncommittedEpc.AssetTagId;

                    var msg = $" EPC: {_currentEpc} " + Local_RM.GetString("WritingToTagSkippedWhenUsingSimulator");
                    ShowMessage(msg, Color.LightGreen);
                    _logger.LogInformation(msg);
                    _beepPlayer.Play();
                    tabWizardControl.InvokeIfRequired(() => tabWizardControl.SelectedIndex = 2);
                    return;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while programming tag");
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
            if (_rfidReader.Readers != null)
            {
                _rfidReader.UnsubscribeAll();
                Thread.Sleep(100); // wait for the unsubscribe to finish
                _rfidReader.Dispose();
            }

            foreach (var control in ControlExtensions.GetAllControlsRecusrvive<TextBox>(this).Where(c => c.Name != "messageTextBox"))
            {
                OskUiController.Instance.DeleteControl(control);
            }
        }

        private void ProgramInstrument_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (OSK.Instance.IsRunning)
                OSK.Instance.HideKeyboard();

            //If it's still not dead let's make sure...
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void frontPageGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void instrumentReadGroupBox_Resize(object sender, EventArgs e)
        {
            instrumentReadLabel.MaximumSize = new Size(((GroupBox)sender).Width + 200, ((GroupBox)sender).Height);
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
        }
    }
}
