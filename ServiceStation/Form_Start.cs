using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Caretag_Class;
using Caretag_Class.Caretag_Common;
using Caretag_Class.Configuration;
using Caretag_Class.EventReporting;
using Caretag_Class.Forms;
using Caretag_Class.Model;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using RFIDAbstractionLayer;
using RFIDAbstractionLayer.Readers;
using Service_Station.My;
using UIControls;
using UIControls.WinForms;

namespace Service_Station.CARETAG_Main
{
    public partial class FrmMain : Form
    {
        private int ContStop;
        private bool Loaded_Form;
        private bool PgrChangeCombox;
        private int The_Sleeper = 300;
        private int The_Old_Login_ID;
        private string str_SQL_Service;
        private string Extra_Where;
        private bool There_Is_Demand = false;
        private int The_Maintenance_RFID_ID;
        private int The_Service_Log_ID;
        public string The_Description_ID = "";
        public int The_Vendor_ID;
        public bool NoCancel = true;

        private readonly RFIDReaderCollection _rfidReaderCollection;
        private RFIDReaderCommon _rfidReaderCommon = new RFIDReaderCommon();

        private LoginForm _Loginform;
        private readonly CaretagModel _model;

        public LoginForm Loginform
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get { return _Loginform; }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Loginform != null)
                {
                    _Loginform.LogInfo -= Get_ID_Back;
                }

                _Loginform = value;
                if (_Loginform != null)
                {
                    _Loginform.LogInfo += Get_ID_Back;
                }
            }
        }

        private ResourceManager Local_RM =
            new ResourceManager("Service_Station.WinFormStrings", typeof(FrmMain).Assembly);

        private string The_UI_Language;

        private string[,] Week_Items =
        {
            {"ALL Service", "-1"}, {"This Week", "0"}, {"One Week", "7"}, {"Two Weeks", "14"}, {"Three Weeks", "21"},
            {"Four Weeks", "28"}, {"Five Weeks", "35"}, {"Six Weeks", "42"}, {"Seven Weeks", "49"},
            {"Eight Weeks", "56"}, {"Half Year", "182"}, {"The Rest", "183"}
        };

        private readonly AppSettingsBase _appSettingsBase;
        private ConfigurationWriter _configurationWriter;
        private readonly EventReporter _eventReporter;
        private readonly CaretagModel _database;

        public FrmMain(RFIDReaderCollection rfidReaderCollection,
            AppSettingsBase appSettingsBase,
            ConfigurationWriter configurationWriter,
            EventReporter eventReporter,
            CaretagModel database)
        {
            _eventReporter = eventReporter;
            _database = database;
            _rfidReaderCollection = rfidReaderCollection;
            _appSettingsBase = appSettingsBase;
            _configurationWriter = configurationWriter;
            _model = Program.Kernel.GetRequiredService<CaretagModel>();
            Load += FrmMain_Load;

            // ***********************************************************************************************************************************
            Function_Module.SQL_ConnectionString = _appSettingsBase.ConnectionStrings.SQLServer;
            Function_Module.The_Reader_Name = _appSettingsBase.StationUniqueID;
            Function_Module.DeskTopReader_Name = "ServiceStation";
            Function_Module.Program_Name = "ServiceStation";
            Function_Module.Program_User = "Pgr_Admin";
            Function_Module.The_Product_Code = "SPD3300"; // IF NOT correct License fails !!!
            Function_Module.Programs_Security_Level = 4;
            Text = string.Format("Service Station - Caretag Surgical Aps All Copy Rights {0} - V: {1}",
                DateAndTime.Now.Year, Application.ProductVersion);
            // ***********************************************************************************************************************************
            The_UI_Language = _appSettingsBase.UILanguage;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(The_UI_Language);
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((keyData & Keys.Alt) != 0)
            {
                FormBorderStyle = FormBorderStyle == FormBorderStyle.None
                    ? FormBorderStyle.Sizable
                    : FormBorderStyle.None;
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                Label1.Text = The_UI_Language;
                Application.CurrentCulture = new CultureInfo("en-us");

                var formWelcome = new SplashScreen(_appSettingsBase.StationUniqueID, "Service Station");
                formWelcome.Show();
                try
                {
                    formWelcome.Message = Local_RM.GetString("Connecting to SQL_SERVER ...");
                    var theServerName = new SqlConnectionStringBuilder(Function_Module.SQL_ConnectionString).DataSource;
                    formWelcome.Message = Local_RM.GetString("Connecting to SQL_SERVER:") + theServerName;
                    _database.Database.Exists();
                }
                catch (Exception ex)
                {
                    _eventReporter.ReportError(ex, "An error occurred when trying to connect to the database",
                        "An error occurred when trying to connect to the database", "ServiceStation-1", true, true);
                    formWelcome.Close();
                    Stop_Program();
                }
                
                formWelcome.Message = Local_RM.GetString("Loading Program Settings ...");
                Application.DoEvents();

                formWelcome.Message = Local_RM.GetString("Finding Reader ...");

                _rfidReaderCollection.ConnectAll();
                if (_rfidReaderCollection.Count > 0)
                {
                    formWelcome.Message =
                        _rfidReaderCommon.GetReaderSplashScreenPresentationString(_rfidReaderCollection.Readers
                            .First());
                }
                else
                {
                    formWelcome.Message = "Reader not found!";
                }

                Application.DoEvents();
                // *** TODO ***
                // Load localization Strings
                string[] powerLocalizationStrings = Enum.GetNames(typeof(PowerLevel));
                PowerTrackBarParams ptbp =
                    new PowerTrackBarParams("Power", powerLocalizationStrings, _rfidReaderCollection.Readers);
                readerPowerBar.InitTrackBar(ptbp);


                formWelcome.Close();

                if (!Do_LogIn())
                {
                    ButtonExit_DoubleClick(sender, e);
                }

                str_SQL_Service =
                    @"SELECT  dbo.Instrument_RFID_Life.EPC_Nr, dbo.Instrument_RFID_Life.Sent_Service, dbo.Instrument_RFID_Life.Return_Service, dbo.Instrument_RFID_Life.Number_Service, 
                         dbo.Instrument_Description.Description_Name + dbo.Instrument_Description.D + dbo.Instrument_Description.E AS Full_Name, dbo.Instrument_RFID_Life.DaysInService, dbo.Service_Vendor.Vendor_Name
                        FROM  dbo.Instrument_RFID_Life INNER JOIN
                         dbo.Instrument_Description ON dbo.Instrument_RFID_Life.Description_ID = dbo.Instrument_Description.Description_ID INNER JOIN
                         dbo.Service_Vendor ON dbo.Instrument_RFID_Life.ServiceVendor_ID = dbo.Service_Vendor.ServiceVendor_ID
                WHERE        (dbo.Instrument_RFID_Life.Sent_Service IS NOT NULL)  ";
                var argTheDataGridView = DataGridView_Service;
                bool argMakeReadOnly = true;
                SQLUtil.FillDataInDatagridview(ref argTheDataGridView, str_SQL_Service + " ORDER BY Sent_Service DESC",
                    ref argMakeReadOnly);
                DataGridView_Service = argTheDataGridView;
                SetUp_DataGridView_Service(true);
                Fill_Combox_Week();
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while loading the page",
                    "An error occurred while loading the page", "ServiceStation-2", true, true);
                Stop_Program();
            }
        }

        #region Upstart

        private void PictureBox_World_Click(object sender, EventArgs e)
        {
        }

        private bool Do_LogIn()
        {
            try
            {
                NoCancel = true; // Not ReBoot = False
                if (!Make_Login())
                {
                    Stop_Program();
                }

                if (The_Old_Login_ID == Function_Module.GlobalPersonID)
                {
                    // Go Back to where it was left
                    return true;
                }

                The_Old_Login_ID = Function_Module.GlobalPersonID;
                TotalNumber.Text = "";
                LabelInserted.Text = "0";
                TextBoxEPC.Clear();
                TextBox_InstrumentName.Clear();
                TextBox_InstrumentName.BackColor = Color.White;
                DataGridViewRules.DataSource = null;
                TrackBarControl1.Properties.ShowValueToolTip = true;
                TextBoxPower.Text = 20.ToString();
                TrackBarControl1.Value = Conversions.ToInteger(TextBoxPower.Text);
                Loaded_Form = true;
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while trying to LogIn",
                    "An error occurred while trying to LogIn", "ServiceStation-4", true, true);
                return false;
            }

            return true;
        }

        private bool Make_Login()
        {
            try
            {
                Loginform = new LoginForm(_rfidReaderCollection, NoCancel, Function_Module.SQL_ConnectionString,
                    Function_Module.The_Reader_Name, Function_Module.Programs_Security_Level, "g@B8w*AcRi6pht",
                    The_UI_Language, Local_RM.GetString("Service_Station"));
                Loginform.ShowDialog();
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while trying to LogIn",
                    "An error occurred while trying to LogIn", "ServiceStation-5", true, true);
                return false;
            }

            return true;
        }

        private void Get_ID_Back(string The_Data)
        {
            try
            {
                if (The_Data.Trim().Length > 0)
                {
                    Function_Module.Program_User = The_Data;
                    Function_Module.GlobalPersonID =
                        Conversions.ToInteger(SQLUtil.LookUpInDataBase("TblPassword", " UserName ='" + The_Data + "'",
                            "UserID"));
                }
                else
                {
                    throw new Exception();
                } // Should not happen 
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while trying to retrieve the ID for the LogIn",
                    "An error occurred while trying to retrieve the ID for the LogIn", "ServiceStation-5", true, true);
                Close();
                Functions.ExecuteShutdown("-s -t 00");
            }
        }

        private void SetLanguage(string language)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            _configurationWriter.UpdateConfigurationFile("appsettings.json", "UILanguage", language);
            Close();
        }

        #endregion

        private void TrackBarControl1_BeforeShowValueToolTip(object sender, TrackBarValueToolTipEventArgs e)
        {
            e.ShowArgs.ToolTip = string.Format("Power = {0}", TrackBarControl1.Value);
            TextBoxPower.Text = TrackBarControl1.Value.ToString();
        }

        private void TrackBarControl1_B(object sender, EventArgs e)
        {
            TrackBarControl1.ShowToolTips = true;
            TrackBarControl1.ToolTip = TrackBarControl1.Value.ToString();
            TextBoxPower.Text = TrackBarControl1.Value.ToString();
            TextBoxPower.BringToFront();
        }

        #region Program ....

        private bool SetUp_DataGridView_Service(bool ShowGrid)
        {
            bool SetUp_DataGridView_ServiceRet = default;
            try
            {
                DataGridView_Service.Visible = ShowGrid;
                DataGridView_Service.Columns["Return_Service"].Visible = false;
                DataGridView_Service.Columns["Full_Name"].Visible = true;
                DataGridView_Service.Columns["Number_Service"].Visible = true;
                DataGridView_Service.Columns["Number_Service"].HeaderText = Local_RM.GetString("Number Service");
                DataGridView_Service.Columns["Number_Service"].Width = 170;
                DataGridView_Service.Columns["Number_Service"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
                DataGridView_Service.Columns["Sent_Service"].Visible = true;
                DataGridView_Service.Columns["Sent_Service"].HeaderText = Local_RM.GetString("Sent To Service");
                DataGridView_Service.Columns["Sent_Service"].DefaultCellStyle.Format = "yyyy-MMM-dd";
                DataGridView_Service.Columns["Sent_Service"].Width = 60;
                DataGridView_Service.Columns["Sent_Service"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
                DataGridView_Service.Columns["Vendor_Name"].Visible = true;
                DataGridView_Service.Columns["Vendor_Name"].HeaderText = Local_RM.GetString("Service Vendor");
                DataGridView_Service.Columns["Vendor_Name"].Width = 80;
                DataGridView_Service.Columns["DaysInService"].Visible = true;
                DataGridView_Service.Columns["DaysInService"].HeaderText = Local_RM.GetString("Days In Service");
                DataGridView_Service.Columns["DaysInService"].Width = 170;
                DataGridView_Service.Columns["DaysInService"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                // ******************************************************************************************************
                DataGridView_Service.Columns["Sent_Service"].DisplayIndex = 1;
                DataGridView_Service.Columns["DaysInService"].DisplayIndex = 2;
                DataGridView_Service.Columns["Number_Service"].DisplayIndex = 3;
                DataGridView_Service.Columns["Full_Name"].DisplayIndex = 4;
                DataGridView_Service.Columns["Vendor_Name"].DisplayIndex = 5;
                DataGridView_Service.Columns["EPC_Nr"].DisplayIndex = 6;
                // ******************************************************************************************************

                DataGridView_Service.ColumnHeadersDefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                // Remember to change Row in Row Template to 32 can't be done through code
                var font = new Font(DataGridViewRules.DefaultCellStyle.Font.FontFamily, 12f, FontStyle.Regular);
                try
                {
                    DataGridView_Service.DefaultCellStyle.Font = font;
                }
                finally
                {
                    font.Dispose();
                }

                SetUp_DataGridView_ServiceRet = true;
            }
            catch (Exception ex)
            {
                SetUp_DataGridView_ServiceRet = false;
                _eventReporter.ReportError(ex, "An error occurred while trying to set up the data grid view",
                    "An error occurred while trying to set up the data grid view", "ServiceStation-6", true, true);
            }

            return SetUp_DataGridView_ServiceRet;
        }

        private bool SetUp_DataGridViewRules(bool ShowGrid)
        {
            bool SetUp_DataGridViewRulesRet = default;
            if (!Loaded_Form)
                return SetUp_DataGridViewRulesRet;
            try
            {
                DataGridViewRules.Visible = ShowGrid;
                DataGridViewRules.Columns["EPC_Nr"].Visible = false;
                DataGridViewRules.Columns["Check_Ciffer"].Visible = false;
                DataGridViewRules.Columns["Check_Status"].Visible = false;
                DataGridViewRules.Columns["Deleted"].Visible = false;
                DataGridViewRules.Columns["Maintenance_RFID_ID"].Visible = false;
                DataGridViewRules.Columns["Description_ID"].Visible = false;
                DataGridViewRules.Columns["Rules_ID"].Visible = false;
                DataGridViewRules.Columns["Default_Rule"].Visible = false;
                DataGridViewRules.Columns["Maintenance_Alarm"].Visible = false;
                DataGridViewRules.Columns["ServiceVendor_ID"].Visible = false;
                DataGridViewRules.Columns["Maintenance_Text"].Visible = true;
                DataGridViewRules.Columns["Maintenance_Text"].HeaderText = Local_RM.GetString("Maintenance Text");
                DataGridViewRules.Columns["Maintenance_Text"].Width = 500;
                DataGridViewRules.Columns["Maintenance_Text"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleLeft;
                DataGridViewRules.Columns["Sendt_To_Service"].Visible = true;
                DataGridViewRules.Columns["Sendt_To_Service"].HeaderText = Local_RM.GetString("Sent To Service");
                DataGridViewRules.Columns["Sendt_To_Service"].Width = 60;
                DataGridViewRules.Columns["Service_Date"].Visible = true;
                DataGridViewRules.Columns["Service_Date"].HeaderText = Local_RM.GetString("Last Service");
                DataGridViewRules.Columns["Service_Date"].Width = 60;
                DataGridViewRules.Columns["Service_Date"].DefaultCellStyle.Format = "yyyy-MMM-dd";
                DataGridViewRules.Columns["Service_Counter"].Visible = true;
                DataGridViewRules.Columns["Service_Counter"].HeaderText = Local_RM.GetString("Service Counter");
                DataGridViewRules.Columns["Service_Counter"].Width = 80;
                DataGridViewRules.Columns["Demand_Service"].Visible = true;
                DataGridViewRules.Columns["Demand_Service"].HeaderText = Local_RM.GetString("Demand Service");
                DataGridViewRules.Columns["Demand_Service"].Width = 170;
                DataGridViewRules.Columns["Demand_Service"].DefaultCellStyle.Format = "yyyy-MMM-dd";
                DataGridViewRules.Columns["Maintenance_Value"].Visible = true;
                DataGridViewRules.Columns["Maintenance_Value"].HeaderText = Local_RM.GetString("Maintenance Value");
                DataGridViewRules.Columns["Maintenance_Value"].Width = 90;
                DataGridViewRules.Columns["Maintenance_Periods"].Visible = true;
                DataGridViewRules.Columns["Maintenance_Periods"].HeaderText = Local_RM.GetString("Maintenance Periods");
                DataGridViewRules.Columns["Maintenance_Periods"].Width = 90;

                // ******************************************************************************************************
                DataGridViewRules.Columns["Maintenance_Text"].DisplayIndex = 2;
                DataGridViewRules.Columns["Demand_Service"].DisplayIndex = 3;
                DataGridViewRules.Columns["Service_Date"].DisplayIndex = 4;
                DataGridViewRules.Columns["Service_Counter"].DisplayIndex = 5;
                DataGridViewRules.Columns["Maintenance_Value"].DisplayIndex = 9;
                DataGridViewRules.Columns["Maintenance_Periods"].DisplayIndex = 10;
                DataGridViewRules.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Remember to change Row in Row Template to 32 can't be done through code
                var font = new Font(DataGridViewRules.DefaultCellStyle.Font.FontFamily, 14f, FontStyle.Regular);
                try
                {
                    DataGridViewRules.DefaultCellStyle.Font = font;
                }
                finally
                {
                    font.Dispose();
                }

                SetUp_DataGridViewRulesRet = true;
            }
            catch (Exception ex)
            {
                SetUp_DataGridViewRulesRet = false;
                _eventReporter.ReportError(ex, "An error occurred while trying to set up the data grid view",
                    "An error occurred while trying to set up the data grid view", "ServiceStation-7", true, true);
            }

            return SetUp_DataGridViewRulesRet;
        }

        private bool SetUp_Service_DataGridViewRules(bool ShowGrid)
        {
            bool SetUp_Service_DataGridViewRulesRet = default;
            if (!Loaded_Form)
                return SetUp_Service_DataGridViewRulesRet;
            try
            {
                DataGridViewRules.Visible = ShowGrid;
                DataGridViewRules.Columns["EPC_Nr"].Visible = false;
                DataGridViewRules.Columns["Description_ID"].Visible = false;
                DataGridViewRules.Columns["Rules_ID"].Visible = false;
                DataGridViewRules.Columns["Default_Rule"].Visible = false;
                DataGridViewRules.Columns["Demand_Service"].Visible = false;
                DataGridViewRules.Columns["ServiceVendor_ID"].Visible = false;
                DataGridViewRules.Columns["Sendt_To_Service"].Visible = false;
                DataGridViewRules.Columns["Sent_To_Service"].Visible = false;
                DataGridViewRules.Columns["Sent_To_Service1"].Visible = false;
                DataGridViewRules.Columns["Maintenance_Period_Start"].Visible = false;
                DataGridViewRules.Columns["Maintenance_Alarm"].Visible = false;
                DataGridViewRules.Columns["ServiceVendor_ID"].Visible = false;
                DataGridViewRules.Columns["Maintenance_Text"].Visible = true;
                DataGridViewRules.Columns["Maintenance_Text"].HeaderText = Local_RM.GetString("Maintenance Text");
                DataGridViewRules.Columns["Maintenance_Text"].Width = 500;
                DataGridViewRules.Columns["Maintenance_Text"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleLeft;
                DataGridViewRules.Columns["Service_Date"].Visible = true;
                DataGridViewRules.Columns["Service_Date"].HeaderText = Local_RM.GetString("Sent To Service");
                DataGridViewRules.Columns["Service_Date"].Width = 60;
                DataGridViewRules.Columns["Service_Date"].DefaultCellStyle.Format = "yyyy-MMM-dd";
                DataGridViewRules.Columns["Number_Service"].Visible = true;
                DataGridViewRules.Columns["Number_Service"].HeaderText = Local_RM.GetString("Service Counter");
                DataGridViewRules.Columns["Number_Service"].Width = 80;
                DataGridViewRules.Columns["Maintenance_Value"].Visible = true;
                DataGridViewRules.Columns["Maintenance_Value"].HeaderText = Local_RM.GetString("Maintenance Value");
                DataGridViewRules.Columns["Maintenance_Value"].Width = 90;
                DataGridViewRules.Columns["Maintenance_Periods"].Visible = true;
                DataGridViewRules.Columns["Maintenance_Periods"].HeaderText = Local_RM.GetString("Maintenance Periods");
                DataGridViewRules.Columns["Maintenance_Periods"].Width = 90;
                // ******************************************************************************************************
                // DataGridViewRules.Columns("Sent_Service").DisplayIndex = 2
                DataGridViewRules.Columns["Service_Date"].DisplayIndex = 2;
                DataGridViewRules.Columns["DaysInService"].DisplayIndex = 3;
                DataGridViewRules.Columns["Maintenance_Text"].DisplayIndex = 4;
                DataGridViewRules.Columns["Maintenance_Value"].DisplayIndex = 9;
                DataGridViewRules.Columns["Maintenance_Periods"].DisplayIndex = 10;
                DataGridViewRules.Columns["Number_Service"].DisplayIndex = 12;
                DataGridViewRules.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Remember to change Row in Row Template to 32 can't be done through code
                var font = new Font(DataGridViewRules.DefaultCellStyle.Font.FontFamily, 14f, FontStyle.Regular);
                try
                {
                    DataGridViewRules.DefaultCellStyle.Font = font;
                }
                finally
                {
                    font.Dispose();
                }

                SetUp_Service_DataGridViewRulesRet = true;
            }
            catch (Exception ex)
            {
                SetUp_Service_DataGridViewRulesRet = false;
                _eventReporter.ReportError(ex, "An error occurred while trying to set up the data grid view",
                    "An error occurred while trying to set up the data grid view", "ServiceStation-8", true, true);
            }

            return SetUp_Service_DataGridViewRulesRet;
        }

        private void Update_TagInfo(string id)
        {
            try
            {
                TextBox_InstrumentName.ForeColor = Color.Black;
                var dbContext = Program.Kernel.GetService<CaretagModel>();
                var instrumentRfid = dbContext.Instrument_RFID.FirstOrDefault(m => m.EPC_Nr == TextBoxEPC.Text);
                if (instrumentRfid != null)
                {
                    // The Tag is in Database
                    The_Description_ID = instrumentRfid.Description_ID;
                    ButtonLifeCycle.Visible = true;
                    TextBoxEPC.BackColor = Color.LightGreen;
                    instrumentRfid.Instrument_LastSeen_Place = Function_Module.The_Reader_Name;
                    instrumentRfid.Instrument_LastSeen_Date = DateTime.Now;
                    dbContext.SaveChanges();
                    
                    TextBox_InstrumentName.Text = SQLUtil.LookUpInDataBase("View_GridView_1",
                        "EPC_Nr ='" + TextBoxEPC.Text + "'", "Description_Name");
                    TextBox_InstrumentName.Text += " - " + SQLUtil.LookUpInDataBase("View_GridView_1",
                        " EPC_Nr='" + TextBoxEPC.Text + "'", "Description_ID");
                    Which_Button();
                    Button_SentBack.Visible = false;
                    string Is_Service = SQLUtil.LookUpInDataBase("Instrument_RFID_Life",
                        "EPC_Nr ='" + TextBoxEPC.Text + "'", "Sent_To_Service");
                    if (!Conversions.ToBoolean(Is_Service))
                    {
                        var argTheDataGridView = DataGridViewRules;
                        bool argMakeReadOnly = true;
                        SQLUtil.FillDataInDatagridview(ref argTheDataGridView,
                            Make_DataGridView() + "  ORDER BY Default_Rule ", ref argMakeReadOnly);
                        DataGridViewRules = argTheDataGridView;
                        if (Check_Rows_DataGridView() > 0)
                        {
                            SetUp_DataGridViewRules(true);
                            Button_Check_All.Enabled = true;
                        }
                        else
                        {
                            // TODO if NO Rules exist ! ???? Default Rules = 0
                            Button_Check_All.Enabled = false;
                        }
                    }
                    else
                    {
                        var argTheDataGridView1 = DataGridViewRules;
                        bool argMakeReadOnly1 = true;
                        SQLUtil.FillDataInDatagridview(ref argTheDataGridView1,
                            Make_Service_DataGridView() + " AND dbo.Instrument_RFID_Life.EPC_Nr='" + TextBoxEPC.Text +
                            "'", ref argMakeReadOnly1);
                        DataGridViewRules = argTheDataGridView1;
                        if (Check_Rows_DataGridView() > 0)
                        {
                            SetUp_Service_DataGridViewRules(true);
                            Button_Check_All.Enabled = true;
                        }
                        else
                        {
                            // TODO if NO Rules exist ! ???? Default Rules = 0
                            Button_Check_All.Enabled = false;
                        }
                    }

                }
                else
                {
                    TextBox_InstrumentName.Text +=
                        Constants.vbCrLf + Constants.vbCrLf + "  Instrument is NOT known  - Check ! ";
                    TextBox_InstrumentName.ForeColor = Color.LightCoral;
                    TextBoxEPC.BackColor = Color.LightCoral;
                    Button_SentBack.Visible = false;
                    Button_Check_All.Enabled = false;
                    ButtonLifeCycle.Visible = false;
                }
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while trying to update the tag information",
                    "An error occurred while trying to update the tag information", "ServiceStation-9", true, true);
            }

            ButtonReadInstrument.BackColor = Color.White;
        }

        private string Make_DataGridView()
        {
            string View_SQL =
                @"SELECT        dbo.Instrument_RFID_Life.Demand_Service, dbo.Instrument_RFID_Life.EPC_Nr, dbo.Instrument_Rules.Description_ID, dbo.Instrument_Rules.Default_Rule, dbo.Instrument_Rules.Maintenance_Text, 
                                     dbo.Instrument_Rules.Maintenance_Value, dbo.Instrument_Rules.Maintenance_Periods, dbo.Instrument_Rules.Maintenance_Period_Start, dbo.Instrument_Rules.Maintenance_Alarm, dbo.Instrument_Rules.Deleted, 
                                     dbo.Instrument_Maintenance_RFID.Check_Status, dbo.Instrument_Maintenance_RFID.Sendt_To_Service, dbo.Instrument_Maintenance_RFID.Return_From_Service, dbo.Instrument_Maintenance_RFID.ServiceVendor_ID, 
                                     dbo.Instrument_Maintenance_RFID.Service_Counter, dbo.Instrument_Maintenance_RFID.Service_Date, dbo.Instrument_Maintenance_RFID.Check_Ciffer, dbo.Instrument_Maintenance_RFID.Maintenance_RFID_ID, 
                                     dbo.Instrument_Rules.Rules_ID
                                     FROM dbo.Instrument_RFID_Life INNER JOIN
                                     dbo.Instrument_Maintenance_RFID ON dbo.Instrument_RFID_Life.EPC_Nr = dbo.Instrument_Maintenance_RFID.EPC_Nr INNER JOIN
                                     dbo.Instrument_Rules ON dbo.Instrument_Maintenance_RFID.Rules_ID = dbo.Instrument_Rules.Rules_ID
            WHERE        (NOT (dbo.Instrument_Maintenance_RFID.Maintenance_RFID_ID IS NULL)) AND (dbo.Instrument_RFID_Life.EPC_Nr = '" +
                TextBoxEPC.Text + "')";
            return View_SQL;
        }

        private string Make_Service_DataGridView()
        {
            string View_SQL =
                @"SELECT  dbo.Instrument_RFID_Life.Demand_Service, dbo.Instrument_RFID_Life.EPC_Nr, dbo.Instrument_Rules.Description_ID, dbo.Instrument_Rules.Default_Rule, dbo.Instrument_Rules.Maintenance_Text, 
                         dbo.Instrument_Rules.Maintenance_Value, dbo.Instrument_Rules.Maintenance_Periods, dbo.Instrument_Rules.Maintenance_Period_Start, dbo.Instrument_Rules.Maintenance_Alarm, 
                          dbo.Instrument_Maintenance_RFID.ServiceVendor_ID, dbo.Instrument_Maintenance_RFID.Service_Date, dbo.Instrument_RFID_Life.Sent_To_Service,  dbo.Instrument_Maintenance_RFID.Sendt_To_Service,
                         dbo.Instrument_Rules.Rules_ID, dbo.Instrument_RFID_Life.Sent_To_Service, dbo.Instrument_RFID_Life.Sent_Service, dbo.Service_Vendor.Vendor_Name,dbo.Instrument_RFID_Life.DaysInService, dbo.Instrument_RFID_Life.Number_Service
FROM            dbo.Instrument_RFID_Life INNER JOIN
                         dbo.Instrument_Maintenance_RFID ON dbo.Instrument_RFID_Life.EPC_Nr = dbo.Instrument_Maintenance_RFID.EPC_Nr INNER JOIN
                         dbo.Instrument_Rules ON dbo.Instrument_Maintenance_RFID.Rules_ID = dbo.Instrument_Rules.Rules_ID INNER JOIN
                         dbo.Service_Vendor ON dbo.Instrument_RFID_Life.ServiceVendor_ID = dbo.Service_Vendor.ServiceVendor_ID
WHERE        (NOT (dbo.Instrument_Maintenance_RFID.Maintenance_RFID_ID IS NULL)) AND (dbo.Instrument_RFID_Life.EPC_Nr = '" +
                TextBoxEPC.Text + "')";
            return View_SQL;
        }

        private int Check_Rows_DataGridView(bool Only_Issues = false)
        {
            int Check_Rows_DataGridViewRet = default;
            try
            {
                int Rules_Counter = 0;
                int Issues_Counter = 0;
                foreach (DataGridViewRow row in DataGridViewRules.Rows)
                {
                    if (Conversions.ToBoolean(row.Cells["Sendt_To_Service"].Value))
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                        DataGridViewRules.CurrentCell = row.Cells[0];
                        // Button_SentBack.Visible = True
                        Issues_Counter += 1;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.Wheat;
                    }

                    Rules_Counter += 1;
                }

                if (Only_Issues)
                {
                    Check_Rows_DataGridViewRet = Issues_Counter;
                }
                else
                {
                    Check_Rows_DataGridViewRet = Rules_Counter;
                }
            }
            catch (Exception ex)
            {
                Check_Rows_DataGridViewRet = 0;
                _eventReporter.ReportError(ex, "An error occurred while checking the rows of the data grid view",
                    "An error occurred while checking the rows of the data grid view", "ServiceStation-10", true, true);
            }

            return Check_Rows_DataGridViewRet;
        }

        private void DataGridViewRules_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!Conversions.ToBoolean(DataGridViewRules.Rows[e.RowIndex].Cells[0].Value))
                {
                    DataGridViewRules.Rows[e.RowIndex].Cells[0].Value = true;
                    DataGridViewRules.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                    string Check_Exist = SQLUtil.LookUpInDataBase_Empty("Instrument_RFID_Life",
                        "EPC_Nr ='" + TextBoxEPC.Text + "'", "Demand_Service");
                    DateTime Test_Date;
                    if (DateTime.TryParse(Check_Exist, out Test_Date))
                    {
                        if (Information.IsDate(Check_Exist))
                        {
                            TextBox_InstrumentName.Text += Constants.vbCrLf + Constants.vbCrLf +
                                                           Local_RM.GetString("Demand Service") +
                                                           Strings.Format(Conversions.ToDate(Check_Exist),
                                                               "dd-MMM-yyyy");
                            TextBox_InstrumentName.Text += "  " + Local_RM.GetString("Days from Demand") +
                                                           DateAndTime.DateDiff(DateInterval.Day,
                                                               Conversions.ToDate(Check_Exist),
                                                               DateAndTime.Now.AddHours(8d));
                            Label_DataGrid_Green.BackColor = Color.LightGreen;
                            Button_Send_To_Service.Visible = true;
                        }
                    }

                    Check_Exist = Strings.Format(DateAndTime.Now, "yyyy-MMM-dd HH:mm");
                    TextBox_InstrumentName.Text += Constants.vbCrLf + Constants.vbCrLf +
                                                   Local_RM.GetString("Demand Service") +
                                                   Strings.Format(Conversions.ToDate(Check_Exist), "dd-MMM-yyyy");
                    TextBox_InstrumentName.Text += "  " + Local_RM.GetString("Days from Demand") +
                                                   DateAndTime.DateDiff(DateInterval.Day,
                                                       Conversions.ToDate(Check_Exist), DateAndTime.Now.AddHours(8d));
                    Label_DataGrid_Green.BackColor = Color.LightGreen;
                }
                else
                {
                    DataGridViewRules.Rows[e.RowIndex].Cells[0].Value = false;
                    if ((bool) DataGridViewRules.Rows[e.RowIndex].Cells["Sendt_To_Service"].Value)
                        DataGridViewRules.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                    else
                        DataGridViewRules.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Wheat;
                    Label_DataGrid_Green.BackColor = Color.White;
                }

                DataGridViewRules.Refresh();

                var isCheckedList = (from DataGridViewRow row in DataGridViewRules.Rows
                    select Conversions.ToBoolean(row.Cells[0].Value)).ToList();
                Button_Send_To_Service.Visible = isCheckedList.Any(isChecked => isChecked)
                    && !Button_AcceptService.Visible;
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while clicking a cell in the data grid view",
                    "An error occurred while clicking a cell in the data grid view", "ServiceStation-11", true, true);
            }
        }
    

        private int Which_Button()
        {
            int whichButtonRet = default;
            try
            {
                Button_AcceptService.Visible = false;
                Button_Send_To_Service.Visible = false;
                whichButtonRet = 0;
                var Check_Exist = SQLUtil.LookUpInDataBase("Instrument_RFID_Life", "EPC_Nr ='" + TextBoxEPC.Text + "'",
                    "Sent_To_Service");
                if (Conversions.ToBoolean(Check_Exist))
                {
                    Check_Exist = SQLUtil.LookUpInDataBase("Instrument_RFID_Life", "EPC_Nr ='" + TextBoxEPC.Text + "'",
                        "Sent_Service");
                    // TextBox_InstrumentName.Text += "  " & Local_RM.GetString("Already Sent to Service !") & ": " & Format(CDate(Check_Exist), "dd-MMM-yyyy")

                    Check_Exist = SQLUtil.LookUpInDataBase("Instrument_RFID_Life", "EPC_Nr ='" + TextBoxEPC.Text + "'",
                        "Sent_Service");
                    if (Information.IsDate(Check_Exist))
                    {
                        TextBox_InstrumentName.Text += Constants.vbCrLf + Constants.vbCrLf +
                                                       Local_RM.GetString("Sent To Service") + " " +
                                                       Strings.Format(Conversions.ToDate(Check_Exist), "dd-MMM-yyyy");
                        TextBox_InstrumentName.Text += "  " + Local_RM.GetString("Days from Sent To Service") + " " +
                                                       DateAndTime.DateDiff(DateInterval.Day,
                                                           Conversions.ToDate(Check_Exist),
                                                           DateAndTime.Now.AddHours(8d));
                    }

                    DataGridViewRules.Columns[0].HeaderText = "From_Service";
                    Button_AcceptService.Visible = true;
                    Button_Send_To_Service.Visible = false;
                    whichButtonRet = 1;
                    return whichButtonRet;
                }

                DateTime Test_Date;
                Check_Exist = SQLUtil.LookUpInDataBase_Empty("Instrument_RFID_Life",
                    "EPC_Nr ='" + TextBoxEPC.Text + "'", "Demand_Service");
                DateTime Get_Date;
                if (DateTime.TryParse(Check_Exist, out Get_Date))
                {
                    if (Information.IsDate(Check_Exist))
                    {
                        if (DateTime.TryParse(Check_Exist, out Test_Date))
                        {
                            if (Information.IsDate(Check_Exist))
                            {
                                TextBox_InstrumentName.Text += Constants.vbCrLf + Constants.vbCrLf +
                                                               Local_RM.GetString("Demand Service") +
                                                               Strings.Format(Conversions.ToDate(Check_Exist),
                                                                   "dd-MMM-yyyy");
                                TextBox_InstrumentName.Text += "  " + Local_RM.GetString("Days from Demand") +
                                                               DateAndTime.DateDiff(DateInterval.Day,
                                                                   Conversions.ToDate(Check_Exist),
                                                                   DateAndTime.Now.AddHours(8d));
                                Button_Send_To_Service.Visible = true;
                                whichButtonRet = 2;
                            }
                        }
                        else if (Label_DataGrid_Green.BackColor == Color.LightGreen)
                        {
                            TextBox_InstrumentName.Text += Constants.vbCrLf + Constants.vbCrLf +
                                                           Local_RM.GetString("Demand Service") +
                                                           Strings.Format(Conversions.ToDate(Check_Exist),
                                                               "dd-MMM-yyyy");
                            TextBox_InstrumentName.Text += "  " + Local_RM.GetString("Days from Demand") +
                                                           DateAndTime.DateDiff(DateInterval.Day,
                                                               Conversions.ToDate(Check_Exist),
                                                               DateAndTime.Now.AddHours(8d));
                            Button_Send_To_Service.Visible = true;
                            whichButtonRet = 2;
                        }
                    }
                }

                // ***************************FEJL*************************************
                DataGridViewRules.Columns[0].HeaderText = "To_Service";
            }
            // *******************************************************************


            catch (Exception ex)
            {
                whichButtonRet = 0;
                _eventReporter.ReportError(ex, "An error occurred while retrieving information about the instrument",
                    "An error occurred while retrieving information about the instrument", "ServiceStation-13", true,
                    true);
            }

            return whichButtonRet;
        }

        private void Button_Send_To_Service_Click(object sender, EventArgs e)
        {
            try
            {
                var dbModel = Program.Kernel.GetRequiredService<CaretagModel>();
                var list = new ArrayList();
                int Counter = 0;
                var qwer = new SqlCommand();
                qwer.CommandText = "SELECT EPC_Nr, Rules_ID FROM Instrument_Maintenance_RFID WHERE EPC_Nr ='" +
                                   TextBoxEPC.Text + "'";
                qwer.Connection = new SqlConnection(Function_Module.SQL_ConnectionString);
                qwer.Connection.Open();
                var qwerDatareader = qwer.ExecuteReader();
                if (qwerDatareader.HasRows)
                {
                    while (qwerDatareader.Read())
                    {
                        list.Add(qwerDatareader[0].ToString());
                        list.Add(qwerDatareader[1].ToString());
                    }
                }
                else
                {
                    MessageBox.Show(" Issue in No DATA to Process .... ", "No DATA", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                qwerDatareader.Close();
                qwer.Dispose();
                int Issues_Counter = 0;
                if (DataGridViewRules.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in DataGridViewRules.Rows)
                    {
                        if (Conversions.ToBoolean(row.Cells[0].Value))
                        {
                            if (row.DefaultCellStyle.BackColor == Color.LightGreen)
                            {
                                Write_Service(true, row, dbModel);
                                Do_Service_Log(TextBoxEPC.Text,
                                    Conversions.ToLong(row.Cells["Rules_ID"].Value), dbModel);
                                Counter += 1;
                            }
                            else
                            {
                                Write_Service(false, row, dbModel);
                            }
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = Color.White;
                        }
                    }
                }

                dbModel.SaveChanges();
                using (var frmOpen = new Print_Service_Report(_eventReporter)
                           {The_Service_Table = Make_Service_Table(), The_EPC_Nr_Service = TextBoxEPC.Text})
                {
                    frmOpen.ShowDialog();
                }

                Button_Send_To_Service.Visible = false;
                Button_AcceptService.Visible = false;
                Label_DataGrid_Green.BackColor = Color.White;
                DataGridViewRules.DataSource = null;
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while sending the instrument to service",
                    "An error occurred while sending the instrument to service", "ServiceStation-14", true, true);
            }
        }

        private bool Write_Service(bool Do_Service, DataGridViewRow row, CaretagModel dbModel)
        {
            try
            {
                var maintenance_RFID_ID = (long) row.Cells["Maintenance_RFID_ID"].Value;
                var maintenanceRfid = dbModel.Instrument_Maintenance_RFID.FirstOrDefault(m =>
                    m.EPC_Nr == TextBoxEPC.Text
                    && m.Maintenance_RFID_ID == maintenance_RFID_ID);
                
                if (maintenanceRfid == null)
                {
                    dbModel.Instrument_Maintenance_RFID.Add(new Instrument_Maintenance_RFID
                    {
                        EPC_Nr = TextBoxEPC.Text,
                        Description_ID = The_Description_ID,
                        Rules_ID = (int)row.Cells["Maintenance_RFID_ID"].Value,
                        Maintenance_Period_Start =  (DateTime?)row.Cells["Maintenance_Period_Start"].Value,
                        Check_Ciffer = 1,
                        Sendt_To_Service = Do_Service,
                        Return_From_Service = false,
                        Service_Date = DateTime.Now,
                        ChangeDate = DateTime.Now
                    });
                }
                else
                {
                    maintenanceRfid.Sendt_To_Service = Do_Service;
                    maintenanceRfid.Return_From_Service = false;
                    maintenanceRfid.ChangeDate = DateTime.Now;

                    var instrumentRfidLife = dbModel.Instrument_RFID_Life.FirstOrDefault(m =>
                        m.EPC_Nr == TextBoxEPC.Text);
                    if(instrumentRfidLife != null)
                    {
                        instrumentRfidLife.Sent_To_Service = Do_Service;
                        instrumentRfidLife.Sent_Service = DateTime.Now;
                        instrumentRfidLife.Last_Change = DateTime.Now;
                    }
                }
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while writing the service",
                    "An error occurred while writing the service", "ServiceStation-16", true, true);
                return false;
            }

            return true;
        }

        private void DataGridViewRules_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Check_Rows_DataGridView();
        }

        private int Color_Rows_DataGridView_Service(bool Only_Issues = false)
        {
            int Color_Rows_DataGridView_ServiceRet = default;
            try
            {
                if (TextBoxEPC.Text.Trim().Length < 1)
                    return Color_Rows_DataGridView_ServiceRet;
                int Rules_Counter = 0;
                int Issues_Counter = 0;
                foreach (DataGridViewRow row in DataGridView_Service.Rows)
                {
                    if ((row.Cells["EPC_Nr"].Value.ToString() ?? "") == (TextBoxEPC.Text ?? ""))
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    // DataGridViewRules.CurrentCell = row.Cells(0)
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                Color_Rows_DataGridView_ServiceRet = 0;
                _eventReporter.ReportError(ex, "An error occurred while coloring the data grid view rows",
                    "An error occurred while coloring the data grid view rows", "ServiceStation-17", true, true);
            }

            return Color_Rows_DataGridView_ServiceRet;
        }

        #endregion

        #region Button's

        private void ButtonReadInstrument_Click(object sender, EventArgs e)
        {
            if (!Loaded_Form)
                return;
            try
            {
                StatusUpdate.BackColor = Color.White;
                Clean_Up_UI("");
                if (ButtonReadInstrument.BackColor == Color.LightGreen)
                {
                    ButtonReadInstrument.BackColor = Color.White;
                    ContStop = 0;
                }
                else
                {
                    ButtonReadInstrument.BackColor = Color.LightGreen;
                    Read_Next_Instrument();
                }

                Color_Rows_DataGridView_Service();
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while clicking the read instrument button",
                    "An error occurred while clicking the read instrument button", "ServiceStation-18", true, true);
            }
        }

        private void Read_Next_Instrument()
        {
            TextBoxEPC.Text = "";
            ContStop = 1;
            while (ContStop == 1)
            {
                try
                {
                    var tags = _rfidReaderCollection.ReadTags();

                    foreach (ReadingResult tag in tags)
                    {
                        if (tag.Value != "")
                        {
                            TextBoxEPC.Text = tag.Value;
                            try
                            {
                                Update_TagInfo(tag.Value);
                                ContStop = 0;
                            }
                            catch (Exception)
                            {
                                StatusUpdate.BackColor = Color.Red;
                                break;
                            }

                            ContStop = 0;
                            SaveScanEvent(tag.Value);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _eventReporter.ReportError(ex, "An error occurred while trying to read the next instrument",
                        "An error occurred while trying to read the next instrument", "ServiceStation-19", true, true);
                }

                Application.DoEvents();
            } // Fine While ContStop
        }

        private void SaveScanEvent(string epc)
        {
            try
            {
                var scanEvent = new ScanEvent
                {
                    EPC = epc,
                    Time_stamp = DateTime.Now,
                    Scan_location = _appSettingsBase.StationUniqueID
                };

                _model.ScanEvent.Add(scanEvent);
                _model.SaveChanges();
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while saving the scan log (scan event) in the database. ", "An error occurred while saving the scan log (scan event) in the database.", "ServiceStation-56", true, true);
            }
        }

        private bool Clean_Up_UI(string Message_Text)
        {
            TextBox_InstrumentName.Text = Message_Text;
            TextBox_InstrumentName.BackColor = Color.White;
            TextBoxEPC.BackColor = Color.White;
            TextBoxEPC.Text = "";
            Button_Check_All.Enabled = false;
            Button_AcceptService.Visible = false;
            PgrChangeCombox = true;
            DataGridViewRules.DataSource = null;
            ButtonReadInstrument.Focus();
            TextBox_Service_Info.Visible = false;
            return default;
        }

        private void Button_Check_All_Click(object sender, EventArgs e)
        {
            if (!Loaded_Form)
                return;
            try
            {
                foreach (DataGridViewRow row in DataGridViewRules.Rows)
                {
                    if (row.DefaultCellStyle.BackColor == Color.Wheat)
                    {
                        var Result = MessageBox.Show(
                            Local_RM.GetString("This Part of The Service:") + row.Cells["Maintenance_Text"].Value +
                            Local_RM.GetString("has Not been Ordered - Has It been Done ?"),
                            Local_RM.GetString("Sure to Accept ?"), MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2);
                        if (Result == DialogResult.Yes)
                        {
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                            row.Cells[0].Value = true;
                        }
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        row.Cells[0].Value = true;
                    }
                }
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while clicking the check all button",
                    "An error occurred while clicking the check all button", "ServiceStation-20", true, true);
            }
        }

        private void Button_AcceptService_Click(object sender, EventArgs e)
        {
            if (!Loaded_Form)
                return;
            try
            {
                foreach (DataGridViewRow row in DataGridViewRules.Rows)
                {
                    if (row.DefaultCellStyle.BackColor == Color.LightCoral)
                    {
                        MessageBox.Show(
                            Local_RM.GetString(
                                "All triggered rules (marked with red) must be accepted to accept item from service. "),
                            Local_RM.GetString("Not all rules accepted"));
                        return;
                    }
                }

                var dbModel = Program.Kernel.GetService<CaretagModel>();
                var maintenanceRfids = dbModel.Instrument_Maintenance_RFID.Where(m => m.EPC_Nr == TextBoxEPC.Text);
                if (maintenanceRfids.Any())
                {
                    foreach (var maintenanceRfid in maintenanceRfids)
                    {
                        maintenanceRfid.Sendt_To_Service = false;
                    }
                }

                var rfidLife = dbModel.Instrument_RFID_Life.FirstOrDefault(m => m.EPC_Nr == TextBoxEPC.Text);
                if (rfidLife != null && rfidLife.Sent_Service.HasValue)
                {
                    rfidLife.DaysInService += Math.Abs((DateTime.Now.Date - rfidLife.Sent_Service.GetValueOrDefault()).Days) + 1;
                    rfidLife.Demand_Service = null;
                    rfidLife.Sent_Service = null;
                    rfidLife.Sent_To_Service = false;
                    rfidLife.Return_Service = DateTime.Now;
                }
                
                var instrumentRfid = dbModel.Instrument_RFID.FirstOrDefault(m => m.EPC_Nr == TextBoxEPC.Text);
                if (instrumentRfid != null)
                {
                    instrumentRfid.Instrument_InUse = true;
                    instrumentRfid.Instrument_LastSeen_Place = Function_Module.The_Reader_Name;
                    instrumentRfid.Instrument_LastSeen_Date = DateTime.Now;
                }
                Button_SentBack.Visible = false;
                var argTheDataGridView = DataGridViewRules;
                bool argMakeReadOnly = true;
                DataGridViewRules = argTheDataGridView;
                if (Check_Rows_DataGridView() > 0)
                {
                    SetUp_Service_DataGridViewRules(true);
                }
                else
                {
                    // TODO if NO Rules exist ! ???? Default Rules = 0
                    Button_AcceptService.Visible = true;
                    Button_Send_To_Service.Visible = false;
                }

                if (DataGridViewRules.RowCount > 0)
                {
                    Updating_Maintance_Service(dbModel);
                }
                else
                {
                    Do_Service_Log(TextBoxEPC.Text, 0, dbModel);
                }

                dbModel.SaveChanges();
                
                StatusUpdate.BackColor = Color.LightGreen;

                SQLUtil.FillDataInDatagridview(ref argTheDataGridView,
                    Make_Service_DataGridView() + " AND dbo.Instrument_RFID_Life.EPC_Nr='" + TextBoxEPC.Text + "'",
                    ref argMakeReadOnly);
                if (Check_Rows_DataGridView(true) < 1)
                {
                    Clean_Up_UI(" Accepted & Updated with New Service Data !");
                    TextBox_InstrumentName.Text = " Accepted & Updated with New Service Data !";
                    TextBox_InstrumentName.BackColor = Color.LightGreen;
                    Button_SentBack.Visible = false;
                    Button_AcceptService.Visible = false;
                    Button_Check_All.Enabled = false;
                }
                else
                {
                    SetUp_DataGridViewRules(true);
                    TextBox_InstrumentName.Text = " Accepted & Updated with New Service Data !" + Constants.vbCrLf +
                                                  " There are Still Service Issues !";
                    TextBox_InstrumentName.BackColor = Color.LightCoral;
                    Button_Check_All.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while accepting the service",
                    "An error occurred while accepting the service", "ServiceStation-21", true, true);
                TextBoxEPC.BackColor = Color.LightCoral;
            }
        }

        private void Updating_Maintance_Service(CaretagModel dbModel)
        {
            try
            {
                foreach (DataGridViewRow row in DataGridViewRules.Rows)
                {
                    if (row.IsNewRow) continue;
                    if (Conversions.ToBoolean(row.Cells[0].EditedFormattedValue))
                    {
                        var rulesId = Int64.Parse(row.Cells["Rules_ID"].Value.ToString());
                        var maintenanceRfid = dbModel.Instrument_Maintenance_RFID
                            .FirstOrDefault(m => m.EPC_Nr == TextBoxEPC.Text && m.Rules_ID == rulesId);

                        if (maintenanceRfid != null)
                        {
                            maintenanceRfid.Check_Ciffer = 0; 
                            maintenanceRfid.Sendt_To_Service = false;
                            maintenanceRfid.Return_From_Service = true;
                            maintenanceRfid.Service_Counter += 1;
                            maintenanceRfid.ChangeDate = DateTime.Now;

                            if (Information.IsDate(row.Cells["Maintenance_Period_Start"].Value))
                            {
                                var ruleId = (long) row.Cells["Rules_ID"].Value;
                                var rule = dbModel.Instrument_Rules
                                    .FirstOrDefault(m => m.Rules_ID == ruleId);
                                if (rule != null)
                                {
                                    maintenanceRfid.Maintenance_Period_Start = DateTime.Now.AddDays(rule.Maintenance_Periods.GetValueOrDefault());
                                }
                            }

                            Do_Service_Log(TextBoxEPC.Text, (long)row.Cells["Rules_ID"].Value, dbModel);
                        }
                    }
                }

                dbModel.SaveChanges();

                int Count_From_Service = 0;
                for (int j = DataGridViewRules.RowCount - 1; j >= 0; j -= 1)
                {
                    if (Conversions.ToBoolean(DataGridViewRules.Rows[j].Cells[0].Value))
                    {
                        Count_From_Service += 1;
                        DataGridViewRules.Rows.RemoveAt(j);
                    }
                }
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while updating the maintenance",
                    "An error occurred while updating the maintenance", "ServiceStation-22", true, true);
            }
        }

        private void Do_Service_Log(string epc, long ruleId, CaretagModel dbModel)
        {
            try
            {
                int The_Vendor = 0;
                string Check_Exist = SQLUtil.LookUpInDataBase("Instrument_RFID_Life",
                    "EPC_Nr ='" + TextBoxEPC.Text + "'", "ServiceVendor_ID");
                int.TryParse(Check_Exist, out The_Vendor);
                dbModel.Service_Log.Add(new Service_Log
                {
                    UserID = Function_Module.GlobalPersonID,
                    EPC_Nr = epc,
                    Rules_ID = ruleId,
                    ServiceVendor_ID = The_Vendor_ID
                });
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while logging the service into the database",
                    "An error occurred while logging the service into the database", "ServiceStation-23", true, true);
            }
        }

        #endregion

        #region Buttons & Etc.

        private void TopTitle_Click(object sender, EventArgs e)
        {
            bool Choose_Dir = false;
            if (MyProject.Computer.Keyboard.CtrlKeyDown)
            {
                Choose_Dir = true;
            }

            Functions.ScreenDump(Handle, Choose_Dir);
        }

        private void ButtonStatus_Click(object sender, EventArgs e)
        {
            if (!Loaded_Form)
                return;
            Cursor = Cursors.AppStarting;
            using (var frm_To_Show = new PivotGridView_1(_eventReporter))
            {
                frm_To_Show.ShowDialog();
            }

            Cursor = Cursors.Default;
        }

        private void ButtonExit_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                using (var frmeditdata = new Form_Exit())
                {
                    frmeditdata.ShowDialog();
                }

                if (NoCancel)
                {
                    // Application.Restart()
                    Do_LogIn();
                }
                else
                {
                    Stop_Program();
                }
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while trying to exit",
                    "An error occurred while trying to exit", "ServiceStation-24", true, true);
                Stop_Program();
            }
        }

        private bool Stop_Program()
        {
            ContStop = 0;

            Application.Exit();
            return default;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            label3.Visible = !label3.Visible;
            TextBoxEPC.Visible = !TextBoxEPC.Visible;
            TotalNumber.Visible = !TotalNumber.Visible;
            LabelPower.Visible = !LabelPower.Visible;
            TextBoxPower.Visible = !TextBoxPower.Visible;
            TrackBarControl1.Visible = !TrackBarControl1.Visible;
            PowerStatus.Visible = !PowerStatus.Visible;
            PictureBox_World.Visible = !PictureBox_World.Visible;
            readerPowerBar.Visible = !readerPowerBar.Visible;
        }

        private void ButtonLifeCycle_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            using (var frmOpen = new Form_LifeCycle(_eventReporter)
                   {
                       The_EPC = TextBoxEPC.Text, Description_Text = TextBox_InstrumentName.Text,
                       Description_ID = The_Description_ID
                   })
            {
                frmOpen.ShowDialog();
            }

            Cursor = Cursors.Default;
        }

        private void ButtonSentBack_Click(object sender, EventArgs e)
        {
            var dbModel = Program.Kernel.GetService<CaretagModel>();
            try
            {
                var dt = new DataTable();
                for (int i = 0, loopTo = DataGridViewRules.ColumnCount - 1; i <= loopTo; i++)
                    dt.Columns.Add(DataGridViewRules.Columns[i].HeaderText, Type.GetType("System.String"));
                if (DataGridViewRules.RowCount > 0)
                {
                    for (int j = 0, loopTo1 = DataGridViewRules.RowCount - 1; j <= loopTo1; j++)
                    {
                        var dr = dt.NewRow();
                        for (int i = 0, loopTo2 = DataGridViewRules.ColumnCount - 1; i <= loopTo2; i++)
                            dr[i] = DataGridViewRules.Rows[j].Cells[i].Value;
                        if (Information.IsNothing(DataGridViewRules.Rows[j].Cells[0].Value) &
                            Conversions.ToBoolean(DataGridViewRules.Rows[j].Cells["Sendt_To_Service"].Value))
                        {
                            dt.Rows.Add(dr);
                            var rfidLife = dbModel.Instrument_RFID_Life.FirstOrDefault(m => m.EPC_Nr == DataGridViewRules.Rows[j].Cells["EPC_Nr"].Value);
                            if (rfidLife != null && rfidLife.Sent_Service.HasValue)
                            {
                                rfidLife.Sent_Service = DateTime.Now;
                                rfidLife.Sent_To_Service = true;
                                rfidLife.Return_Service = null;
                            }
                            Do_Service_Log(TextBoxEPC.Text,
                                Conversions.ToLong(DataGridViewRules.Rows[j].Cells["Rules_ID"].Value), dbModel);
                        }
                    }
                }
                else
                {
                    var rfidLife = dbModel.Instrument_RFID_Life.FirstOrDefault(m => m.EPC_Nr == TextBoxEPC.Text);
                    if (rfidLife != null && rfidLife.Sent_Service.HasValue)
                    {
                        rfidLife.Sent_Service = DateTime.Now;
                        rfidLife.Sent_To_Service = false;
                        rfidLife.Return_Service = null;
                    }
                    Do_Service_Log(TextBoxEPC.Text, 0, dbModel);
                }

                dbModel.SaveChanges();

                Cursor = Cursors.AppStarting;
                using (var frmOpen = new Print_Service_Report(_eventReporter)
                           {The_Service_Table = dt, The_EPC_Nr_Service = TextBoxEPC.Text})
                {
                    frmOpen.ShowDialog();
                }

                var argTheDataGridView = DataGridViewRules;
                bool argMakeReadOnly = true;
                SQLUtil.FillDataInDatagridview(ref argTheDataGridView,
                    "SELECT * FROM View_Rules_Station WHERE EPC_Nr='" + TextBoxEPC.Text + "'", ref argMakeReadOnly);
                DataGridViewRules = argTheDataGridView;
                Cursor = Cursors.Default;
                Button_SentBack.Visible = false;
                Clean_Up_UI("Please Remember to Send Instrument Back");
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while trying to send the instrument out",
                    "An error occurred while trying to send the instrument out", "ServiceStation-25", true, true);
                Clean_Up_UI("");
            }
        }

        private void Button_Service_Click(object sender, EventArgs e)
        {
            ComboBox_Weeks.SelectedIndex = 0;
            var argTheDataGridView = DataGridView_Service;
            bool argMakeReadOnly = true;
            SQLUtil.FillDataInDatagridview(ref argTheDataGridView, str_SQL_Service + " ORDER BY Sent_Service DESC",
                ref argMakeReadOnly);
            DataGridView_Service = argTheDataGridView;
            SetUp_DataGridView_Service(true);
        }

        private bool Show_ListView()
        {
            bool Show_ListViewRet = default;
            if (!Loaded_Form)
                return Show_ListViewRet;
            string Text_Info;
            try
            {
                TextBox_Service_Info.Clear();
                TextBox_Service_Info.Visible = true;
                Text_Info = SQLUtil.LookUpInDataBase_Empty("Instrument_RFID_Life",
                    " EPC_Nr ='" + Label_EPC_NR.Text + "'", "Description_ID");
                if (Text_Info.Trim().Length < 1)
                {
                    TextBox_Service_Info.Text +=
                        "**********************************************************************************" +
                        Constants.vbCrLf;
                    TextBox_Service_Info.Text += "Description_ID: NOT Known " + Constants.vbCrLf;
                    TextBox_Service_Info.Text +=
                        "**********************************************************************************" +
                        Constants.vbCrLf;

                    return Show_ListViewRet;
                }

                TextBox_Service_Info.Text +=
                    "**********************************************************************************" +
                    Constants.vbCrLf;
                TextBox_Service_Info.Text += "Description_ID: " + Text_Info + Constants.vbCrLf;
                Text_Info = SQLUtil.LookUpInDataBase_Empty("Instrument_Description",
                    " Description_ID ='" + Text_Info + "'", "Description_Name");
                TextBox_Service_Info.Text += "Description_Text: " + Text_Info + Constants.vbCrLf;
                TextBox_Service_Info.Text +=
                    "**********************************************************************************" +
                    Constants.vbCrLf;
                if (Label_EPC_NR.Text.Trim().Length > 0)
                {
                    Text_Info = SQLUtil.LookUpInDataBase_Empty("Instrument_RFID",
                        " EPC_Nr ='" + Label_EPC_NR.Text + "'", "Instrument_LastSeen_Place");
                    if (Text_Info.Trim().Length > 0)
                    {
                        TextBox_Service_Info.Text += "Instrument LastSeen Place: " + Text_Info + Constants.vbCrLf;
                        Text_Info = SQLUtil.LookUpInDataBase_Empty("Instrument_RFID",
                            " EPC_Nr ='" + Label_EPC_NR.Text + "'", "Instrument_LastSeen_Date");
                        if (Information.IsDate(Text_Info))
                        {
                            Text_Info = Strings.Format(Conversions.ToDate(Text_Info), "yyyy-MM-dd HH:mm:ss");
                            TextBox_Service_Info.Text += "Instrument LastSeen Date: " + Text_Info + Constants.vbCrLf;
                        }
                    }
                }

                Text_Info = SQLUtil.LookUpInDataBase_Empty("Instrument_RFID_Life",
                    " EPC_Nr ='" + Label_EPC_NR.Text + "'", "ServiceVendor_ID");
                Text_Info = SQLUtil.LookUpInDataBase_Columns("Service_Vendor",
                    " ServiceVendor_ID ='" + Text_Info + "'");
                var Result = Strings.Split(Text_Info, ";");
                TextBox_Service_Info.Text += Constants.vbCrLf + "Service Vendor: " + Result[1] + Constants.vbCrLf;
                TextBox_Service_Info.Text += Result[2] + Constants.vbCrLf;
                TextBox_Service_Info.Text += Result[3] + "  " + Result[4] + Constants.vbCrLf;
                TextBox_Service_Info.Text += Result[5] + Constants.vbCrLf;
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while showing the list view",
                    "An error occurred while showing the list view", "ServiceStation-26", true, true);
            }
            finally
            {
                Show_ListViewRet = true;
            }

            return Show_ListViewRet;
        }

        private void DataGridView_Service_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0)
                return;
            if (e.RowIndex < 0)
                return;
            if ((Label_EPC_NR.Text ?? "") ==
                (DataGridView_Service.Rows[e.RowIndex].Cells["EPC_Nr"].Value.ToString() ?? ""))
            {
                TextBox_Service_Info.Visible = false;
                Label_EPC_NR.Text = "";
                return;
            }

            Label_EPC_NR.Text = DataGridView_Service.Rows[e.RowIndex].Cells["EPC_Nr"].Value.ToString();
            Show_ListView();
        }

        private void TextBox_Service_Info_Click(object sender, EventArgs e)
        {
            TextBox_Service_Info.Visible = false;
        }

        private bool Fill_Combox_Week()
        {
            bool Fill_Combox_WeekRet = default;
            try
            {
                for (int row = 0, loopTo = Week_Items.GetUpperBound(0); row <= loopTo; row++)
                    ComboBox_Weeks.Items.Add("  " + Week_Items[row, 0]);
                ComboBox_Weeks.Text = "Use Filter";
                Fill_Combox_WeekRet = true;
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while filling the week combo box",
                    "An error occurred while filling the week combo box", "ServiceStation-28", true, true);
            }

            return Fill_Combox_WeekRet;
        }

        private void ComboBox_Weeks_SelectedIndexChanged(object sender, EventArgs e)
        {
            Extra_Where = The_Extra_Where();
            var argTheDataGridView = DataGridView_Service;
            bool argMakeReadOnly = true;
            SQLUtil.FillDataInDatagridview(ref argTheDataGridView,
                str_SQL_Service + Extra_Where + " ORDER BY Sent_Service DESC", ref argMakeReadOnly);
            DataGridView_Service = argTheDataGridView;
            SetUp_DataGridView_Service(true);
            Color_Rows_DataGridView_Service();
        }

        private string The_Extra_Where()
        {
            string theExtraWhereRet;
            int Days_From_Nows = Convert.ToInt16(Week_Items[ComboBox_Weeks.SelectedIndex, 1]);
            if (Days_From_Nows == 0)
            {
                theExtraWhereRet = " AND (DATEDIFF(day, dbo.Instrument_RFID_Life.Sent_Service, GETDATE()) < '8')";
            }
            else
            {
                if (Days_From_Nows == -1)
                {
                    theExtraWhereRet = "";
                    return theExtraWhereRet;
                }

                if (Days_From_Nows == 183)
                {
                    theExtraWhereRet = " AND (DATEDIFF(day, dbo.Instrument_RFID_Life.Sent_Service, GETDATE()) >= '" +
                                       Days_From_Nows + "')";
                }
                else
                {
                    theExtraWhereRet = " AND (DATEDIFF(day, dbo.Instrument_RFID_Life.Sent_Service, GETDATE()) <= '" +
                                       Days_From_Nows + "')";
                }
            }

            return theExtraWhereRet;
        }

        private void Button_Report_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.AppStarting;
                var dt = new DataTable();
                int Fill_Records_Org = 0;
                if (CheckBox_UseFilter.Checked)
                {
                    Extra_Where = The_Extra_Where();
                }
                else
                {
                    Extra_Where = "";
                }

                string str_SQL =
                    @"SELECT   dbo.Instrument_RFID_Life.EPC_Nr, dbo.Instrument_RFID_Life.Sent_Service, dbo.Instrument_RFID_Life.Return_Service, dbo.Instrument_RFID_Life.Number_Service, 
                         dbo.Instrument_Description.Description_Name + dbo.Instrument_Description.D + dbo.Instrument_Description.E AS Full_Name, dbo.Instrument_RFID_Life.DaysInService, dbo.Service_Vendor.Vendor_Name, 
                         dbo.Service_Vendor.Vendor_City, dbo.Service_Vendor.Vendor_Zip_Code
FROM            dbo.Instrument_RFID_Life INNER JOIN
                         dbo.Instrument_Description ON dbo.Instrument_RFID_Life.Description_ID = dbo.Instrument_Description.Description_ID INNER JOIN
                         dbo.Service_Vendor ON dbo.Instrument_RFID_Life.ServiceVendor_ID = dbo.Service_Vendor.ServiceVendor_ID
WHERE        (dbo.Instrument_RFID_Life.Sent_Service IS NOT NULL) ";
                using (var objDataAdapter =
                       new SqlDataAdapter(str_SQL + Extra_Where + ";", Function_Module.SQL_ConnectionString))
                {
                    var ds = new DataSet();
                    Fill_Records_Org = objDataAdapter.Fill(ds, "Org_Table");
                    dt = ds.Tables["Org_Table"];
                }

                if (dt.Rows.Count < 1)
                {
                    Cursor = Cursors.Default;
                    return;
                }

                Add_Periods(ref dt);

                // Assign the data source to the report. 
                var report = new XtraReport_To_Service {DataSource = dt};
                var groupField_Vendor = new GroupField("Vendor_Name");
                report.GroupHeader1.GroupFields.Add(groupField_Vendor);
                report.XrLabel_Service_Vendor.DataBindings.Add("Text", dt, "Vendor_Name");
                report.XrLabel_ZIP.DataBindings.Add("Text", dt, "Vendor_Zip_Code", " Zip Code: {0}");
                report.XrLabel_City.DataBindings.Add("Text", dt, "Vendor_City", " City: {0}");
                var groupField_InService = new GroupField("Sort");
                report.GroupHeader2.GroupFields.Add(groupField_InService);
                report.XrLabel_Period.DataBindings.Add("Text", dt, "Period", " Period: {0}");
                report.XrLabel_Sort.DataBindings.Add("Text", dt, "Sort", "Sort: {0}");
                report.XrLabel_Sent.DataBindings.Add("Text", dt, "Sent_Service", "{0:dd'-'MMM'-'yyyy HH:mm}");
                report.XrLabel2.DataBindings.Add("Text", dt, "Full_Name");
                report.XrLabel_EPC.DataBindings.Add("Text", dt, "EPC_Nr");
                if (CheckBox_UseFilter.Checked)
                {
                    report.XrLabel_Filter.Text = "Filter in use: " + Week_Items[ComboBox_Weeks.SelectedIndex, 0];
                }
                else
                {
                    report.XrLabel_Filter.Visible = false;
                }

                var summary = new XRSummary();
                report.XrLabel5.DataBindings.Add("Text", dt, "EPC_Nr");
                summary.Func = SummaryFunc.DCount;
                summary.Running = SummaryRunning.Group;
                summary.IgnoreNullValues = true;
                summary.FormatString = "Number Of Instruments: {0:N0}";
                report.XrLabel5.Summary = summary;
                var Summary_Group = new XRSummary();
                report.XrLabel8.DataBindings.Add("Text", dt, "EPC_Nr");
                Summary_Group.Func = SummaryFunc.DCount;
                Summary_Group.Running = SummaryRunning.Group;
                Summary_Group.IgnoreNullValues = true;
                Summary_Group.FormatString = " Instruments at Service Vendor: {0:N0}";
                report.XrLabel8.Summary = Summary_Group;
                var T_Summary_Sum = new XRSummary();
                report.XrLabel6.DataBindings.Add("Text", dt, "EPC_Nr");
                T_Summary_Sum.Func = SummaryFunc.DCount;
                T_Summary_Sum.Running = SummaryRunning.Report;
                T_Summary_Sum.IgnoreNullValues = true;
                T_Summary_Sum.FormatString = "Total Number of Instruments to Service:  {0:N0}";
                report.XrLabel6.Summary = T_Summary_Sum;
                report.ShowRibbonPreviewDialog();
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while trying to report",
                    "An error occurred while trying to report", "ServiceStation-29", true, true);
            }
        }

        private int Add_Periods(ref DataTable The_DataTable)
        {
            int Counter = 0;
            try
            {
                The_DataTable.Columns.Add("Sort", typeof(int));
                The_DataTable.Columns.Add("Period", typeof(string));
                foreach (DataRow row in The_DataTable.Rows)
                {
                    int Service_Days = 0;
                    string str_Text = row["Sent_Service"].ToString();
                    if (Information.IsDate(str_Text))
                    {
                        Service_Days = (int) DateAndTime.DateDiff(DateInterval.Day, Conversions.ToDate(str_Text),
                            DateAndTime.Now);
                        Counter += 1;
                    }

                    switch (Service_Days)
                    {
                        case < 8:
                        {
                            row["Period"] = " 1 Week ";
                            row["Sort"] = 1;
                            break;
                        }

                        case <= 14:
                        {
                            row["Period"] = " 2 Week ";
                            row["Sort"] = 2;
                            break;
                        }

                        case <= 21:
                        {
                            row["Period"] = " 3 Week ";
                            row["Sort"] = 3;
                            break;
                        }

                        case <= 28:
                        {
                            row["Period"] = " 4 Week ";
                            row["Sort"] = 4;
                            break;
                        }

                        case <= 60:
                        {
                            row["Period"] = " 2 Month ";
                            row["Sort"] = 5;
                            break;
                        }

                        case <= 90:
                        {
                            row["Period"] = " 3 Month ";
                            row["Sort"] = 6;
                            break;
                        }

                        case <= 121:
                        {
                            row["Period"] = " 4 Month ";
                            row["Sort"] = 7;
                            break;
                        }

                        case <= 152:
                        {
                            row["Period"] = " 5 Month ";
                            row["Sort"] = 8;
                            break;
                        }

                        case >= 153 and <= 182:
                        {
                            row["Period"] = " 6 Month ";
                            row["Sort"] = 9;
                            break;
                        }

                        case <= 360:
                        {
                            row["Period"] = " 6 Month to 1 Year ";
                            row["Sort"] = 10;
                            break;
                        }

                        case var _ when true:
                        {
                            row["Period"] = " More than 1 Year ";
                            row["Sort"] = 11;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while adding periods",
                    "An error occurred while adding periods", "ServiceStation-30", true, true);
            }

            return Counter;
        }

        private void Button_RESET_Click(object sender, EventArgs e)
        {
            var dbModel = Program.Kernel.GetRequiredService<CaretagModel>();
            Updating_Maintance_Service(dbModel);
            try
            {
                string str_SQL;
                var list = new ArrayList();
                var qwer = new SqlCommand();
                qwer.CommandText = "SELECT EPC_Nr, Rules_ID FROM Instrument_Maintenance_RFID WHERE EPC_Nr ='" +
                                   TextBoxEPC.Text + "'";
                qwer.Connection = new SqlConnection(Function_Module.SQL_ConnectionString);
                qwer.Connection.Open();
                var qwer_Datareader = qwer.ExecuteReader();
                if (qwer_Datareader.HasRows)
                {
                    while (qwer_Datareader.Read())
                    {
                        list.Add(qwer_Datareader[0].ToString());
                        list.Add(qwer_Datareader[1].ToString());
                    }
                }
                else
                {
                    MessageBox.Show(" Issue in No DATA to Process .... ", "No DATA", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                var instrumentRfidLife = dbModel.Instrument_RFID_Life.FirstOrDefault(m =>
                    m.EPC_Nr == TextBoxEPC.Text);
                if(instrumentRfidLife != null)
                {
                    instrumentRfidLife.Sent_To_Service = false;
                    instrumentRfidLife.Sent_Service = null;
                    instrumentRfidLife.Return_Service = DateTime.Now;
                    instrumentRfidLife.Demand_Service = DateTime.Now;
                }
               
                for (int i = list.Count - 1; i >= 0; i -= 2)
                {
                    var maintenanceRfid = dbModel.Instrument_Maintenance_RFID.FirstOrDefault(m =>
                        m.EPC_Nr == TextBoxEPC.Text
                        && m.Rules_ID == (int)list[i]);
                    if(maintenanceRfid != null)
                    {
                        maintenanceRfid.Sendt_To_Service = false;
                        maintenanceRfid.Service_Date = DateTime.Now;
                    }
                }

                qwer_Datareader.Close();
                qwer.Dispose();
                dbModel.SaveChanges();
                using (var frmOpen = new Print_Service_Report(_eventReporter)
                           {The_Service_Table = Make_Service_Table(), The_EPC_Nr_Service = TextBoxEPC.Text})
                {
                    frmOpen.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while clicking the reset button",
                    "An error occurred while clicking the reset button", "ServiceStation-31", true, true);
            }
        }

        private DataTable Make_Service_Table()
        {
            try
            {
                var dt = new DataTable();
                for (int i = 0, loopTo = DataGridViewRules.ColumnCount - 1; i <= loopTo; i++)
                    dt.Columns.Add(DataGridViewRules.Columns[i].HeaderText, Type.GetType("System.String"));
                if (DataGridViewRules.RowCount > 0)
                {
                    for (int j = 0, loopTo1 = DataGridViewRules.RowCount - 1; j <= loopTo1; j++)
                    {
                        var dr = dt.NewRow();
                        for (int i = 0, loopTo2 = DataGridViewRules.ColumnCount - 1; i <= loopTo2; i++)
                        {
                            if (Conversions.ToBoolean(DataGridViewRules.Rows[j].Cells[0].Value))
                            {
                                dr[i] = DataGridViewRules.Rows[j].Cells[i].Value;
                            }
                        }

                        dt.Rows.Add(dr);
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while trying to make the service table",
                    "An error occurred while trying to make the service table", "ServiceStation-32", true, true);
            }

            return default;
        }

        #endregion

        private void btnLogOut_OnLogout()
        {
            Hide();
            if (Do_LogIn())
            {
                if (IsDisposed)
                    return;
                Show();
            }
        }
    }
}