using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Caretag_Class;
using DevExpress.XtraReports.UI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using RulesStation;
using Serilog;

namespace Caretag_Class.Rules.Form
{
    public partial class Print_Service_Report
    {
        public Print_Service_Report(ILogger logger,string descriptionText, string maintenanceText, List<string> maintenanceList, bool showCancel)
        {
            InitializeComponent();
            _Button_Save.Name = "Button_Save";
            _ComboBoxServiceVendor.Name = "ComboBoxServiceVendor";
            _TextBoxSpecial.Name = "TextBoxSpecial";
            _ButtonPrintReport.Name = "ButtonPrintReport";
            _ButtonInformation.Name = "ButtonInformation";
            _Button_Cancel.Name = "Button_Cancel";
            Logger = logger;
            _descriptionText = descriptionText;
            _maintenanceText = maintenanceText;
            _maintenanceList = maintenanceList;
            _Button_Cancel.Visible = showCancel;
        }

        private bool Form_Loaded = false;
        private string Vendor_Name = "";
        private string Vendor_Street_1 = "";
        private string Vendor_Street_2 = "";
        private string Vendor_City = "";
        private string Vendor_Zip_code = "";
        private string Vendor_Country = "";
        private string Vendor_Special_Text = "";
        private string CSSD_Name = "";
        private string CSSD_Street_1 = "";
        private string CSSD_Street_2 = "";
        private string CSSD_City = "";
        private string CSSD_Zip_code = "";
        private string CSSD_Country = "";
        private string CSSD_Special_Text = "";
        private XtraReport_Service_One report = new();
        private Image picture;
        public bool Do_RePrint = false;
        public int The_Vendor_ID = 0;
        public DateTime The_Service_Time;
        public bool Specific_One = false;
        private ILogger Logger;
        private ResourceManager Local_RM = new ResourceManager("RulesStation.WinFormStrings", typeof(Print_Service_Report).Assembly);

        public bool CancelService { get; set; }
        public int ServiceVendorId { get; set; }
        private readonly string _descriptionText;
        private readonly string _maintenanceText;
        private readonly List<string> _maintenanceList;

        public string[] MaintenanceInstructions { get; set; }

        private void Print_Service_Report_Load(object sender, EventArgs e)
        {
            try
            {
                string str_SQL = "ServiceVendor_ID,Vendor_Name";
                SQLUtil.ReadyComboBox(ComboBoxServiceVendor, str_SQL, "Service_Vendor", "", " - Choose Service Vendor - ");
                if (Do_RePrint)
                {
                    ComboBoxServiceVendor.Enabled = false;
                    ButtonPrintReport.Enabled = true;
                    var objConnection = new SqlConnection(Caretag_Class.Function_Module.SQL_ConnectionString);
                    if (objConnection.State == ConnectionState.Closed)
                    {
                        objConnection.Open();
                    }

                    var com1 = objConnection.CreateCommand();
                    Get_Service_Vendor_Info(The_Vendor_ID);
                }
                else
                {
                    string The_ServiceVendor_ID = SQLUtil.LookUpInDataBase("Service_Log", " EPC_Nr='" + Caretag_Class.Function_Module.The_EPC + "'", "ServiceVendor_ID");
                    Label_Vendor.Text = SQLUtil.LookUpInDataBase_Empty("Service_Vendor", " ServiceVendor_ID='" + The_ServiceVendor_ID + "'", "Vendor_Name");
                }

                Load_CSSD_Info();

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error Code: {@ErrorCode} , An error occurred while loading the form", "rules56");
                var Message = Local_RM.GetString("Please restart the application and if this does not solve the problem, contact Caretag Support and report the Error Code");
                MessageBox.Show(Local_RM.GetString("An error occurred while loading the form.") + Message, "Error Code: rules56", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            Form_Loaded = true;
        }

        private bool Load_CSSD_Info()
        {
            bool Load_CSSD_InfoRet = default;
            var objConnection = new SqlConnection(Caretag_Class.Function_Module.SQL_ConnectionString);
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                var com1 = objConnection.CreateCommand();
                com1.CommandType = CommandType.Text;
                com1.CommandText = "SELECT  TOP (1) * FROM Steril_Central ;";
                var reader = com1.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (Information.IsDBNull(reader["Steril_Name"]))
                        {
                            CSSD_Name = "No Name";
                        }
                        else
                        {
                            CSSD_Name = reader["Steril_Name"].ToString();
                        }

                        if (Information.IsDBNull(reader["Steril_Street_1"]))
                        {
                            CSSD_Street_1 = " - ";
                        }
                        else
                        {
                            CSSD_Street_1 = reader["Steril_Street_1"].ToString();
                        }

                        if (Information.IsDBNull(reader["Steril_Street_2"]))
                        {
                            CSSD_Street_2 = " - ";
                        }
                        else
                        {
                            CSSD_Street_2 = reader["Steril_Street_2"].ToString();
                        }

                        if (Information.IsDBNull(reader["Steril_City"]))
                        {
                            CSSD_City = " - ";
                        }
                        else
                        {
                            CSSD_City = reader["Steril_City"].ToString();
                        }

                        if (Information.IsDBNull(reader["Steril_Zip_Code"]))
                        {
                            CSSD_Zip_code = " - ";
                        }
                        else
                        {
                            CSSD_Zip_code = reader["Steril_Zip_Code"].ToString();
                        }

                        if (Information.IsDBNull(reader["Steril_Country"]))
                        {
                            CSSD_Country = " - ";
                        }
                        else
                        {
                            CSSD_Country = reader["Steril_Country"].ToString();
                        }

                        if (Information.IsDBNull(reader["Special_Text"]))
                        {
                            CSSD_Special_Text = " - ";
                        }
                        else
                        {
                            CSSD_Special_Text = reader["Special_Text"].ToString();
                        }
                    }

                    // TextBox2.Text += Vendor_Name & vbCrLf & Vendor_Street_1 & vbCrLf & Vendor_Street_2 & vbCrLf _
                    // & Vendor_Zip_code & "    " & Vendor_City & vbCrLf & Vendor_Country

                    // TextBoxSpecial.Text = Vendor_Special_Text
                }

                Load_CSSD_InfoRet = true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error Code: {@ErrorCode} , An error occurred while loading the CSSD information", "rules57");
                var Message = Local_RM.GetString("Please restart the application and if this does not solve the problem, contact Caretag Support and report the Error Code");
                MessageBox.Show(Local_RM.GetString("An error occurred while loading the CSSD information.") + Message, "Error Code: rules57", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Load_CSSD_InfoRet = false;
            }

            return Load_CSSD_InfoRet;
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (ButtonPrintReport.Visible)
                {
                    // TODO Not sure if this is needed .....
                    SQLUtil.DeleteContent("Rules_Log WHERE EPC_Nr='" + Caretag_Class.Function_Module.The_EPC + "' AND ServiceVendor_ID IS NULL");
                }

                if (ComboBoxServiceVendor.SelectedIndex == 0)
                {
                    CancelService= true;
                }

                try
                {
                    Process.GetProcessesByName("osk")[0].Kill();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, "Error Code: {@ErrorCode} , An error occurred while trying to stop the process", "rules58");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error Code: {@ErrorCode} , An error occurred while trying to save the information", "rules59");
                var Message = Local_RM.GetString("Please restart the application and if this does not solve the problem, contact Caretag Support and report the Error Code");
                MessageBox.Show(Local_RM.GetString("An error occurred while trying to save the information.") + Message, "Error Code: rules59", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            Close();
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            CancelService = true;
            Close();
        }

        private void ComboBoxServiceVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Form_Loaded)
                return;
            try
            {
                TextBox2.Clear();
                TextBoxSpecial.Clear();
                LabelSpecialInformation.ForeColor = Color.Black;
                if (ComboBoxServiceVendor.SelectedIndex == 0)
                {
                    ButtonPrintReport.Enabled = false;
                    CancelService = true;
                    Button_Save.Visible = false;
                    return;
                }

                ButtonPrintReport.Enabled = true;
                Button_Save.Visible = true;
                try
                {
                    // Just to be Sure No Shit in Database....
                    if (ComboBoxServiceVendor.SelectedIndex > 0)
                    {
                        CancelService = false;
                        Get_Service_Vendor_Info(Conversions.ToInteger(((DataRowView)ComboBoxServiceVendor.SelectedItem).Row.ItemArray[0]));
                        ServiceVendorId = Conversions.ToInteger(((DataRowView)ComboBoxServiceVendor.SelectedItem).Row.ItemArray[0]);
                        The_Vendor_ID = Conversions.ToInteger(((DataRowView)ComboBoxServiceVendor.SelectedItem).Row.ItemArray[0]);
                        SQLUtil.UpdateToDatabase("Instrument_RFID_Life", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("ServiceVendor_ID='", ((DataRowView)ComboBoxServiceVendor.SelectedItem).Row.ItemArray[0]), "' WHERE EPC_Nr='"), Caretag_Class.Function_Module.The_EPC), "'")));
                        // '******************************************************************************************************
                        // TODO is this needed ?
                        if (!SQLUtil.UpdateToDatabase("Instrument_Maintenance_RFID", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("ServiceVendor_ID='", ((DataRowView)ComboBoxServiceVendor.SelectedItem).Row.ItemArray[0]), "' WHERE EPC_Nr='"), Caretag_Class.Function_Module.The_EPC), "' AND Sendt_To_Service = '1'")), false))
                        {
                            MessageBox.Show("Issue ... Please Report Missing Information in Instrument_Maintenance_RFID: " + Caretag_Class.Function_Module.The_EPC, "Update Instrument_Maintenance_RFID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        // '******************************************************************************************************
                        // Function_Module.Caretag_Common.Functions.UpdateToDatabase("Rules_Log", CType("ServiceVendor_ID='" & ComboBoxServiceVendor.SelectedItem(0) & "' WHERE EPC_Nr='" & Function_Module.The_EPC & "' AND ServiceVendor_ID IS NULL", String), False)
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, "Error Code: {@ErrorCode} , An error occurred while checking the database information", "rules60");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error Code: {@ErrorCode} , An error occurred while changing the selected index", "rules61");
                var Message = Local_RM.GetString("Please restart the application and if this does not solve the problem, contact Caretag Support and report the Error Code");
                MessageBox.Show(Local_RM.GetString("An error occurred while changing the selected index.") + Message, "Error Code: rules61", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void Get_Service_Vendor_Info(int The_Vendor_ID)
        {
            var objConnection = new SqlConnection(Caretag_Class.Function_Module.SQL_ConnectionString);
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                using (var com1 = objConnection.CreateCommand())
                {
                    com1.CommandType = CommandType.Text;
                    com1.CommandText = "SELECT * FROM Service_Vendor WHERE ServiceVendor_ID='" + The_Vendor_ID + "';";
                    var reader = com1.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (Information.IsDBNull(reader["Vendor_Name"]))
                            {
                                Vendor_Name = "No Name";
                            }
                            else
                            {
                                Vendor_Name = reader["Vendor_Name"].ToString();
                            }

                            Label_Vendor.Text = Vendor_Name;
                            if (Information.IsDBNull(reader["Vendor_Street_1"]))
                            {
                                Vendor_Street_1 = " - ";
                            }
                            else
                            {
                                Vendor_Street_1 = reader["Vendor_Street_1"].ToString();
                            }

                            if (Information.IsDBNull(reader["Vendor_Street_2"]))
                            {
                                Vendor_Street_2 = " - ";
                            }
                            else
                            {
                                Vendor_Street_2 = reader["Vendor_Street_2"].ToString();
                            }

                            if (Information.IsDBNull(reader["Vendor_City"]))
                            {
                                Vendor_City = " - ";
                            }
                            else
                            {
                                Vendor_City = reader["Vendor_City"].ToString();
                            }

                            if (Information.IsDBNull(reader["Vendor_Zip_Code"]))
                            {
                                Vendor_Zip_code = " - ";
                            }
                            else
                            {
                                Vendor_Zip_code = reader["Vendor_Zip_Code"].ToString();
                            }

                            if (Information.IsDBNull(reader["Vendor_Country"]))
                            {
                                Vendor_Country = " - ";
                            }
                            else
                            {
                                Vendor_Country = reader["Vendor_Country"].ToString();
                            }

                            if (Information.IsDBNull(reader["Special_Text"]))
                            {
                                Vendor_Special_Text = " - ";
                            }
                            else
                            {
                                Vendor_Special_Text = reader["Special_Text"].ToString();
                            }
                        }

                        TextBox2.Text += Vendor_Name + Constants.vbCrLf + Vendor_Street_1 + Constants.vbCrLf + Vendor_Street_2 + Constants.vbCrLf + Vendor_Zip_code + "    " + Vendor_City + Constants.vbCrLf + Vendor_Country;
                        TextBoxSpecial.Text = Vendor_Special_Text;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error Code: {@ErrorCode} , An error occurred while getting the vendor service information", "rules62");
                var Message = Local_RM.GetString("Please restart the application and if this does not solve the problem, contact Caretag Support and report the Error Code");
                MessageBox.Show(Local_RM.GetString("An error occurred while getting the vendor service information.") + Message, "Error Code: rules62", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            objConnection.Close();
        }

        private void TextBoxSpecial_TextChanged(object sender, EventArgs e)
        {
            ButtonInformation.Visible = !ButtonInformation.Visible;
        }

        private void ButtonInformation_Click(object sender, EventArgs e)
        {
            ButtonInformation.Visible = !ButtonInformation.Visible;
            try
            {
                var Field_Array = new string[] { TextBoxSpecial.Text };
                if (!Do_RePrint)
                {
                    if (!int.TryParse(((DataRowView)ComboBoxServiceVendor.SelectedItem).Row.ItemArray[0].ToString(), out The_Vendor_ID))
                    {
                        throw new Exception();
                    }
                }

                string str_SQL = "  Special_Text =@Field_0 " + " WHERE ServiceVendor_ID='" + The_Vendor_ID.ToString() + "'";
                if (SQLUtil.UpdateToDatabase_ParaM("Service_Vendor", str_SQL, Field_Array, true))
                {
                    LabelSpecialInformation.ForeColor = Color.Green;
                }
                else
                {
                    LabelSpecialInformation.ForeColor = Color.Red;
                    throw new Exception("Update  Cost Item   Failed !");
                }
            }

            // Dim Results As Boolean = Function_Module.Caretag_Common.Functions.UpdateToDatabase("Service_Vendor", " Special_Text ='" & TextBoxSpecial.Text & "'" & " WHERE ServiceVendor_ID='" & ComboBoxServiceVendor.SelectedItem(0) & "'")
            // If Results Then
            // LabelSpecialInformation.ForeColor = Color.Green
            // Else
            // LabelSpecialInformation.ForeColor = Color.Red
            // End If



            catch (Exception ex)
            {
                Logger.Error(ex, "Error Code: {@ErrorCode} , An error occurred while getting the vendor information", "rules63");
                var Message = Local_RM.GetString("Please restart the application and if this does not solve the problem, contact Caretag Support and report the Error Code");
                MessageBox.Show(Local_RM.GetString("An error occurred while getting the vendor information.") + Message, "Error Code: rules63", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void ButtonPrintReport_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            ButtonPrintReport.Enabled = false;
            try
            {
                Vendor_Special_Text = SQLUtil.LookUpInDataBase_Empty("Service_Vendor", "  ServiceVendor_ID = '" + The_Vendor_ID + "'", "Special_Text");
                report = new XtraReport_Service_One();
                report.XrRichTextCompName.Text = Vendor_Name;
                report.XrRichTextAdress1.Text = Vendor_Street_1;
                report.XrRichTextAdress2.Text = Vendor_Street_2;
                report.XrRichTextZipp.Text = Vendor_Zip_code;
                report.XrRichTextCity.Text = Vendor_City;
                report.XrRichTextCountry.Text = Vendor_Country;
                report.XrRichTextInstrument.Text = _descriptionText;
                report.XrRichTextCSSD.Text = CSSD_Name;
                report.XrLabelNameTopCSSD.Text = CSSD_Name;
                report.XrRichTextCityCSSD.Text = CSSD_City;
                report.XrLabelCityTopCSSD.Text = CSSD_City;
                report.XrRichTextStr1CSSD.Text = CSSD_Street_1;
                report.XrRichTextStr2CSSD.Text = CSSD_Street_2;
                report.XrRichTextZipCSSD.Text = CSSD_Zip_code;
                report.XrRichTextCityCSSD.Text = CSSD_City;
                report.XrRichTextCountCSSD.Text = CSSD_Country;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error Code: {@ErrorCode} , An error occurred while trying to retrieve the vendor information from the database", "rules64");
                var Message = Local_RM.GetString("Please restart the application and if this does not solve the problem, contact Caretag Support and report the Error Code");
                MessageBox.Show(Local_RM.GetString("An error occurred while trying to retrieve the vendor information from the database.") + Message, "Error Code: rules64", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            var Report_DataTable = new DataTable();
            try
            {

                // TODO laves helt om: finde default rules PLUS de valgte .....
                if (Specific_One)
                {
                    report.XrRichTextService.Text = _maintenanceText;
                    report.XrRichTextSpecialInfo.Text = Vendor_Special_Text;
                }
                else
                {
                    if (!Do_RePrint)
                    {
                        SQLUtil.FillDataTable("SELECT * FROM View_Rules_Report WHERE EPC_Nr='" + Caretag_Class.Function_Module.The_EPC + "'", ref Report_DataTable);
                        Report_DataTable.Clear();
                        Report_DataTable.Columns.Add("Print", typeof(int));
                        Report_DataTable.Columns.Add("Text", typeof(string));
                        int taeller = 0;
                        foreach (var maintenanceInstruction in _maintenanceList)
                        {
                            var The_Table_Row = Report_DataTable.NewRow();
                            The_Table_Row["Maintenance_Text"] = maintenanceInstruction;
                            Report_DataTable.Rows.Add(The_Table_Row);
                        }

                        report.DataSource = Report_DataTable;
                        var BindingA = new XRBinding("Text", report.DataSource, "Maintenance_Text");
                        report.XrRichTextService.DataBindings.Add(BindingA);
                        report.XrRichTextSpecialInfo.Text = Vendor_Special_Text;
                    }
                    else
                    {
                        string str_SQL = @"SELECT  dbo.Instrument_Rules.Rules_ID, dbo.Instrument_Rules.Description_ID, dbo.Instrument_Rules.Default_Rule, dbo.Instrument_Rules.Maintenance_Text, dbo.Instrument_Rules.Maintenance_Value, 
                         dbo.Instrument_Rules.Maintenance_Periods, dbo.Instrument_Rules.Maintenance_Period_Start, dbo.Instrument_Maintenance_RFID.Maintenance_RFID_ID, dbo.Instrument_Maintenance_RFID.EPC_Nr, 
                         dbo.Instrument_Maintenance_RFID.Sendt_To_Service, dbo.Instrument_Maintenance_RFID.Return_From_Service, dbo.Instrument_Maintenance_RFID.ServiceVendor_ID, dbo.Instrument_Maintenance_RFID.Service_Counter, 
                         dbo.Instrument_Maintenance_RFID.Service_Date, dbo.Instrument_RFID_Life.Demand_Service, dbo.Service_Vendor.Vendor_Name, dbo.Service_Vendor.Vendor_City
FROM            dbo.Instrument_RFID_Life INNER JOIN
                         dbo.Instrument_Maintenance_RFID ON dbo.Instrument_RFID_Life.EPC_Nr = dbo.Instrument_Maintenance_RFID.EPC_Nr INNER JOIN
                         dbo.Service_Vendor ON dbo.Instrument_RFID_Life.ServiceVendor_ID = dbo.Service_Vendor.ServiceVendor_ID INNER JOIN
                         dbo.Instrument_Rules ON dbo.Instrument_Maintenance_RFID.Rules_ID = dbo.Instrument_Rules.Rules_ID
WHERE        (dbo.Instrument_Maintenance_RFID.Sendt_To_Service = 'True') AND (dbo.Instrument_Maintenance_RFID.EPC_Nr = N'" + Caretag_Class.Function_Module.The_EPC + "')";
                        SQLUtil.FillDataTable(str_SQL, ref Report_DataTable);
                        report.DataSource = Report_DataTable;
                    }

                    var Binding = new XRBinding("Text", report.DataSource, "Maintenance_Text");
                    report.XrRichTextService.DataBindings.Add(Binding);
                    report.XrRichTextSpecialInfo.Text = Vendor_Special_Text;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error Code: {@ErrorCode} , An error occurred while trying to print the report", "rules65");
                var Message = Local_RM.GetString("Please restart the application and if this does not solve the problem, contact Caretag Support and report the Error Code");
                MessageBox.Show(Local_RM.GetString("An error occurred while trying to print the report.") + Message, "Error Code: rules65", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            try
            {
                SQLUtil.Loading_Logo_From_Database("SELECT The_Logo FROM Steril_Central", false, ref picture);
                report.XrPictureBox1.Image = picture;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error Code: {@ErrorCode} , An error occurred while trying to load the logo", "rules66");
                var Message = Local_RM.GetString("Please restart the application and if this does not solve the problem, contact Caretag Support and report the Error Code");
                MessageBox.Show(Local_RM.GetString("An error occurred while trying to load the logo.") + Message, "Error Code: rules66", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                // Okay !
            }

            report.PrintingSystem.EndPrint += PrintingSystem_EndPrint;
            var tool = new ReportPrintTool(report);
            DevExpress.XtraBars.Ribbon.RibbonForm form = tool.PreviewRibbonForm as DevExpress.XtraBars.Ribbon.RibbonForm;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.CloseBox = false;
            // ******************************************************************************************************
            // form.ControlBox = False
            // ******************************************************************************************************
            report.BringToFront();
            tool.ShowRibbonPreviewDialog();

            // report.ShowRibbonPreview
            Cursor = Cursors.Default;
        }

        private void PrintingSystem_EndPrint(object sender, EventArgs e)
        {
            report.CloseRibbonPreview();
        }
    }
}
