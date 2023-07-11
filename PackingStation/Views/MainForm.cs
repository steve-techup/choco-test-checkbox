using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Media;
using System.Reactive;
using System.Reactive.Linq;
using System.Resources;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caretag_Class;
using Caretag_Class.Caretag_Common;
using Caretag_Class.Configuration;
using Caretag_Class.EventReporting;
using Caretag_Class.Forms;
using Caretag_Class.Logging;
using Caretag_Class.Model;
using Caretag_Class.ReactiveUI.Services;
using Caretag_Class.Repositories;
using Caretag_Class.Services;
using Caretag_Class.Util.UI;
using DevExpress.Data.Helpers;
using DevExpress.Utils.Diagnostics;
using DevExpress.Utils.Helpers;
using DevExpress.XtraGrid.Views.Grid;
using DynamicData;
using DynamicData.Binding;
using Main.Model.PackingList;
using Main.ReactiveUI.Interactions;
using Main.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PackingStation.Configuration;
using PackingStation.My;
using PackingStation.My.Resources;
using PackingStation.Repositories;
using PackingStation.Services;
using PackingStation.ViewModels;
using ReactiveUI;
using RFIDAbstractionLayer.Readers;
using Surgical_Admin.Interactions;
using UIControls;
using Constants = Microsoft.VisualBasic.Constants;

namespace PackingStation.Views
{
    public partial class FrmMain : Form, IViewFor<PackingStationMainViewModel>
    {
        private PackingStationMainViewModel _vm;

        object IViewFor.ViewModel
        {
            get => _vm;
            set => _vm = (PackingStationMainViewModel)value;
        }

        PackingStationMainViewModel IViewFor<PackingStationMainViewModel>.ViewModel
        {
            get => _vm;
            set => _vm = value;
        }
        
        private readonly EventReporter _eventReporter;
        private readonly AppSettingsBase _appSettingsBase;

        private readonly RFIDReaderCollection _rfidReaderCollection;
        
        private bool _loadedForm;
        private readonly ResourceManager Local_RM = new("PackingStation.WinFormStrings", typeof(FrmMain).Assembly);
        private readonly int _maxElement = 100;
        public bool NoCancel = true;
        
        

        private int _theOldLoginId;
        private readonly string _theUiLanguage;


        public FrmMain(RFIDReaderCollection rfidReaderCollection, AppSettingsBase appSettingsBase,
            PackingStationAppSettings packingStationAppSettings, ReactiveCommandService reactiveCommandService, 
            EventReporter eventReporter, PackingStationUnitOfWorkFactory packingStationUnitOfWorkFactory,
            PackedTrayReportService packedTrayReportService, CommonInteractionsFactory commonInteractionsFactory,
            ZebraPrintService zebraPrintService, ExcelExportService excelExportService, VerboseLogger verboseLogger)
        {
            _eventReporter = eventReporter;
            _rfidReaderCollection = rfidReaderCollection;
            _appSettingsBase = appSettingsBase;
            
            Load += FormMain_Load;
            
            // *********************************************************************************************************************************
            Function_Module.SQL_ConnectionString = _appSettingsBase.ConnectionStrings.SQLServer;
            Function_Module.The_Reader_Name = _appSettingsBase.StationUniqueID;
            Function_Module.DeskTopReader_Name = "PackingStation";
            Function_Module.Program_Name = "PackingStation";
            Function_Module.Program_User = "Pgr_Admin";
            Function_Module.The_Product_Code = "SPD3100"; // IF NOT correct License fails !!!
            Function_Module.Programs_Security_Level = 4;
            Text = string.Format("Packing Station - Caretag Surgical Aps All Copy Rights {0} - V: {1}",
                DateAndTime.Now.Year, System.Windows.Forms.Application.ProductVersion);
            // *********************************************************************************************************************************
            _theUiLanguage = _appSettingsBase.UILanguage;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(_theUiLanguage);
            InitializeComponent();

            _vm = new PackingStationMainViewModel(_rfidReaderCollection,
                packingStationUnitOfWorkFactory,
                packingStationAppSettings,
                packedTrayReportService,
                commonInteractionsFactory,
                reactiveCommandService,
                zebraPrintService,
                excelExportService,
                verboseLogger,
            RxApp.MainThreadScheduler);

            touchscreenPackingListView.ViewModel = _vm.TouchscreenPackingListViewModel;

            //Set up reactiveui
            this.WhenActivated(d =>
            {
                var colorSelector = (MessageViewModel msg) =>
                {
                    switch (msg?.Type)
                    {
                        case MessageType.Error:
                            return Color.Red;
                        case MessageType.Warning:
                            return Color.Orange;
                        case MessageType.Info:
                            return Color.LawnGreen;
                        default:
                            return Color.White;
                    }
                };
                this.BindCommand(_vm, vm => vm.GoPackTray, view => view.packTrayMenuButton);
                this.BindCommand(_vm, vm => vm.GoInstrumentLookup, view => view.instrumentLookupMenuButton);
                this.BindCommand(_vm, vm => vm.GoViewPackedTrays, view => view.viewPackedTraysMenuButton);
                
                this.BindCommand(_vm, vm => vm.ScanNewTray, view => view.buttonScanTray);
                this.BindCommand(_vm, vm => vm.StartPacking, view => view.startPackingButton);
                this.BindCommand(_vm, vm => vm.CancelPacking, view => view.cancelPackingPackTrayPage);
                this.BindCommand(_vm, vm => vm.FinishPacking, view => view.ButtonPackingNext);
                this.BindCommand(_vm, vm => vm.ScanContainer, view => view.scanContainerButton);
                this.BindCommand(_vm, vm => vm.CancelPacking, view => view.cancelPackingContainerPageButton);
                this.BindCommand(_vm, vm => vm.GoChooseCostCenter, view => view.nextContainerPageButton);
                this.BindCommand(_vm, vm => vm.GoAdditionalInformation, view => view.costCenterNextButton);
                
                this.BindCommand(_vm, vm => vm.CancelPacking, view => view.cancelPackingCostCenterPageButton);
                this.BindCommand(_vm, vm => vm.SaveAndGoToReportAndFinalize, view => view.saveButton);
                this.BindCommand(_vm, vm => vm.CancelPacking, view => view.cancelPackingContainerPageButton);
                this.BindCommand(_vm, vm => vm.CancelPacking, view => view.cancelPackingExtraInfoPageButton);

                this.BindCommand(_vm, vm => vm.Restart, view => view.instrumentLookupBackToMenuButton);
                this.BindCommand(_vm, vm => vm.Restart, view => view.viewPackedTraysBackToMenuButton);
                this.BindCommand(_vm, vm => vm.Restart, view => view.scanTrayBackButton);
                this.BindCommand(_vm, vm => vm.FinishAndPrintLabel, view => view.reportFinishButton);
                this.BindCommand(_vm, vm => vm.GoToReportAndPrintLabel, view => view.packingLogViewDetailsButton);
                this.BindCommand(_vm, vm => vm.GoViewPackedTrays, view => view.trayReportBackButton);
                this.BindCommand(_vm, vm => vm.FinishAndPrintLabel, view => view.trayReportPrintButton);

                this.BindCommand(_vm, vm => vm.GenericBack, view => view.selectTrayTypeBackButton);
                this.BindCommand(_vm, vm => vm.BackWithConfirm, view => view.packTrayBackButton);
                this.BindCommand(_vm, vm => vm.GenericBack, view => view.containerPageBackButton);
                this.BindCommand(_vm, vm => vm.BackWithConfirm, view => view.backCostCenterButton);
                this.BindCommand(_vm, vm => vm.GenericBack, view => view.backExtraInfoPageButton);
                this.BindCommand(_vm, vm => vm.ScanInstrumentForLookup, view => view.scanInstrumentButton);
                this.BindCommand(_vm, vm => vm.Logout, view => view.logoutButton);
                this.BindCommand(_vm, vm => vm.ExportPacklistToExcel, view => view.exportTrayButton);

                this.OneWayBind(_vm, vm => vm.CurrentMessage, view => view.textBoxErrorMessageTray.Text, msg => msg?.Message ?? "");
                this.OneWayBind(_vm, vm => vm.CurrentMessage, view => view.textBoxErrorMessageTray.BackColor, colorSelector);
                this.OneWayBind(_vm, vm => vm.CurrentMessage, view => view.TextBoxDescriptionText.Text, msg => msg?.Message ?? "");
                this.OneWayBind(_vm, vm => vm.CurrentMessage, view => view.TextBoxDescriptionText.BackColor, colorSelector);
                this.OneWayBind(_vm, vm => vm.CurrentMessage, view => view.textBoxMessageContainerPage.Text, msg => msg?.Message ?? "");
                this.OneWayBind(_vm, vm => vm.CurrentMessage, view => view.textBoxMessageContainerPage.BackColor, colorSelector);
                this.OneWayBind(_vm, vm => vm.CurrentMessage, view => view.messageSelectTrayTypePageTextbox.Text, msg => msg?.Message ?? "");
                this.OneWayBind(_vm, vm => vm.CurrentMessage, view => view.messageSelectTrayTypePageTextbox.BackColor, colorSelector);
                this.OneWayBind(_vm, vm => vm.CurrentMessage, view => view.costCenterMessageTextBox.Text, msg => msg?.Message ?? "");
                this.OneWayBind(_vm, vm => vm.CurrentMessage, view => view.costCenterMessageTextBox.BackColor, colorSelector);
                this.OneWayBind(_vm, vm => vm.CurrentMessage, view => view.extraInfoMessageBox.Text, msg => msg?.Message ?? "");
                this.OneWayBind(_vm, vm => vm.CurrentMessage, view => view.extraInfoMessageBox.BackColor, colorSelector);
                this.OneWayBind(_vm, vm => vm.CurrentMessage, view => view.textBoxMessageInstrumentLookup.Text, msg => msg?.Message ?? "");
                this.OneWayBind(_vm, vm => vm.CurrentMessage, view => view.textBoxMessageInstrumentLookup.BackColor, colorSelector);

                this.OneWayBind(_vm, vm => vm.CurrentPage, view => view.tabWizardControl.SelectedIndex);
                
                this.OneWayBind(_vm, vm => vm.SelectedTrayType, view => view.trayNameLabel.Text, tray => tray?.Tray_Name);
                this.OneWayBind(_vm, vm => vm.SelectedTrayType, view => view.trayLockedCheckbox.Checked, tray => tray?.Tray_Lock ?? true);
                this.OneWayBind(_vm, vm => vm.TotalScanned, view => view.totalTextBox.Text);
                
                Observable.FromEventPattern(traysListBoxControl, "SelectedIndexChanged").Select(_ => traysListBoxControl.SelectedItem).BindTo(_vm, vm => vm.SelectedTrayType);
                
                this.OneWayBind(_vm, vm => vm.TrayTypes, view => view.traysListBoxControl.DataSource);
                traySearchControl.Client = traysListBoxControl;
                this.Bind(_vm, vm => vm.IsLocked, view => view.trayLockedCheckbox.Checked);
                this.OneWayBind(_vm, vm => vm.SideImage, view => view.selectTrayTypePictureBox.Image);
                this.OneWayBind(_vm, vm => vm.SideImage, view => view.PictureBoxTray.Image);
                
                this.Bind(_vm, vm => vm.ChooseCostCenter, view => view.chooseCostCenterRadioButton.Checked);
                this.Bind(_vm, vm => vm.ChooseCostCenter, view => view.noCostCenterRadioButton.Checked, value => !value, value => !value);
                this.Bind(_vm, vm => vm.CostCenters, view => view.costCenterListBoxControl.DataSource);
                this.Bind(_vm, vm => vm.CostTypes, view => view.costTypeListBoxControl.DataSource);
                this.OneWayBind(_vm, vm => vm.ChooseCostCenter, view => view.costCenterListBoxControl.Enabled);
                this.OneWayBind(_vm, vm => vm.ChooseCostCenter, view => view.costTypeListBoxControl.Enabled);
                this.Bind(_vm, vm => vm.CostCenterNote, view => view.costCenterCommentTextbox.Text);

                Observable.FromEventPattern(costCenterListBoxControl, "SelectedIndexChanged").Select(_ => costCenterListBoxControl.SelectedItem)
                    .BindTo(_vm, vm => vm.SelectedCostCenter);
                
                Observable.FromEventPattern(costTypeListBoxControl, "SelectedIndexChanged").Select(_ => costTypeListBoxControl.SelectedItem)
                    .BindTo(_vm, vm => vm.SelectedCostType);

                this.OneWayBind(_vm, vm => vm.PackingReport, view => view.packingReport.DataSource,
                    list =>
                    {
                        packingReport.Refresh();
                        return list;
                    });
                
                this.Bind(_vm, vm => vm.SterilizationIndicatorLotNumber, view => view.sterilizationIndicatorLotNumber.Text);
                this.Bind(_vm, vm => vm.PackingLogXPServerCollectionSource, view => view.packingLogGridControl.DataSource);

                var gridview = ((GridView)packingLogGridControl.ViewCollection[0]);
                Observable.FromEventPattern(gridview, "SelectionChanged")
                    .Select(_ =>
                    {
                        var packingLog = (PackingLog?)gridview.GetRow(gridview.FocusedRowHandle);
                        return packingLog?.Id; //TODO: Consider using the object itself to avoid some db rount-tripping
                    }).BindTo(_vm, vm => vm.SelectedPackingLogId);

                this.Bind(_vm, vm => vm.PackingReport, view => view.trayReportDataGridView.DataSource);
                this.OneWayBind(_vm, vm => vm.TrayContentsReport, view => view.trayReportContentsDataGridView.DataSource);

                this.Bind(_vm, vm => vm.CurrentInstrumentPackTrayTypes,
                    view => view.instrumentPackingListsDataGridView.DataSource);

                this.OneWayBind(_vm, vm => vm.CurrentInstrument, view => view.instrumentNameAndIDLabel.Text, 
                    instrument => $"{instrument?.Description_ID ?? ""} {instrument?.GetFullDescription() ?? ""}");
            });
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

            Label_Taken_ID.Visible = false;
            TotalNumber.Visible = false;
            var formWelcome = new SplashScreen(_appSettingsBase.StationUniqueID, "Packing Station");
            formWelcome.Show();
            
            tabWizardControl.Appearance = TabAppearance.FlatButtons;
            tabWizardControl.ItemSize = new Size(0, 1);
            tabWizardControl.SizeMode = TabSizeMode.Fixed;
            
            try
            {
                var connectionString = new SqlConnectionStringBuilder(_appSettingsBase.ConnectionStrings.SQLServer);
                formWelcome.Message = Local_RM.GetString("ConectSql") + connectionString.DataSource;
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred when trying to connect to the database. ",
                    "An error occurred when trying to connect to the database.", "PackingStation-2", true, true);

                formWelcome.Close();
                System.Windows.Forms.Application.Exit();
            }

            System.Windows.Forms.Application.DoEvents();

            try
            {
                formWelcome.Message = Local_RM.GetString("FindingReader");
                _rfidReaderCollection.ConnectAll();
                _rfidReaderCollection.Readers.ForEach(r => r.SetPower(PowerLevel.Low));
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred when trying to connect to the RFID reader. ", "An error occurred when trying to connect to the RFID reader.", "PackingStation-3", true, true);
            }

            if (_rfidReaderCollection.Count == 0)
            {
                _eventReporter.ReportError("An error occurred, no RFID reader was found. ", "An error occurred, no RFID reader was found.", "PackingStation-4", true, true);

                formWelcome.Close();
                System.Windows.Forms.Application.Exit();
            }
            // *** TODO ***
            // Load localization Strings
            string[] powerLocalizationStrings = System.Enum.GetNames(typeof(PowerLevel));
            PowerTrackBarParams ptbp =
                new PowerTrackBarParams("Power", powerLocalizationStrings, _rfidReaderCollection.Readers);
            readerPowerBar.InitTrackBar(ptbp);
            formWelcome.Close();

            _vm.Login.Execute().ObserveOn(RxApp.MainThreadScheduler).Subscribe(result =>
            {
                if (!result)
                {
                    Close();
                    System.Windows.Forms.Application.Exit();
                }
                else
                {
                    try
                    {
                        System.Windows.Forms.Application.DoEvents();

                        _loadedForm = true;

                        WindowState = FormWindowState.Normal;
                    }
                    catch (Exception ex)
                    {
                        _eventReporter.ReportError(ex, "An error occurred when loading the application. ", "An error occurred when loading the form", "PackingStation-5", true, true);
                    }
                }
            });
        }
        

        private void packingLogButtonEdit_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            // get data bound item from the row where the button was clicked
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _vm.CleanUp();
        }
    }
}
