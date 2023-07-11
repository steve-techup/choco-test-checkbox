using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Caretag_Class.EventReporting;
using DevExpress.XtraReports.UI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Service_Station.CARETAG_Main;

namespace Service_Station
{
    public partial class Print_Service_Report
    {
        private readonly EventReporter _eventReporter;

        public Print_Service_Report(EventReporter eventReporter)
        {
            _eventReporter = eventReporter;
            InitializeComponent();
            _ButtonExit.Name = "ButtonExit";
            _ComboBoxServiceVendor.Name = "ComboBoxServiceVendor";
            _TextBoxSpecial.Name = "TextBoxSpecial";
            _ButtonPrintReport.Name = "ButtonPrintReport";
            _ButtonInformation.Name = "ButtonInformation";
        }

        private bool Form_Loaded = false;
        private string Vendor_Name = string.Empty;
        private string Vendor_Street_1 = string.Empty;
        private string Vendor_Street_2 = string.Empty;
        private string Vendor_City = string.Empty;
        private string Vendor_Zip_code = string.Empty;
        private string Vendor_Country = string.Empty;
        private string Vendor_Special_Text = string.Empty;
        private string CSSD_Name = string.Empty;
        private string CSSD_Street_1 = string.Empty;
        private string CSSD_Street_2 = string.Empty;
        private string CSSD_City = string.Empty;
        private string CSSD_Zip_code = string.Empty;
        private string CSSD_Country = string.Empty;
        private string CSSD_Special_Text = string.Empty;
        private XtraReport_Service_One report = new XtraReport_Service_One();
        private Image picture;
        public bool Do_RePrint = false;
        public int The_Vendor_ID = 0;
        public DateTime The_Service_Time;
        public string The_EPC_Nr_Service = string.Empty;
        public DataTable The_Service_Table;

        private void Print_Service_Report_Load(object sender, EventArgs e)
        {
            string str_SQL = "ServiceVendor_ID,Vendor_Name";
            Caretag_Class.SQLUtil.ReadyComboBox(ComboBoxServiceVendor, str_SQL, "Service_Vendor", string.Empty, " - Choose Service Vendor - ");
            ButtonPrintReport.Enabled = true;
            var objConnection = new SqlConnection(Caretag_Class.Function_Module.SQL_ConnectionString);
            if (objConnection.State == ConnectionState.Closed)
            {
                objConnection.Open();
            }

            var com1 = objConnection.CreateCommand();
            string Check_Exist = Caretag_Class.SQLUtil.LookUpInDataBase("Instrument_RFID_Life", "EPC_Nr ='" + The_EPC_Nr_Service + "'", "ServiceVendor_ID");
            int.TryParse(Check_Exist, out The_Vendor_ID);
            Get_Service_Vendor_Info(com1, The_Vendor_ID);
            ComboBoxServiceVendor.SelectedIndex = -1;
            for (int i = 0, loopTo = ComboBoxServiceVendor.Items.Count - 1; i <= loopTo; i++)
            {
                if (Conversions.ToDouble(((DataRowView)ComboBoxServiceVendor.Items[i]).Row.ItemArray[0].ToString()) == The_Vendor_ID)
                {
                    ComboBoxServiceVendor.SelectedIndex = i;
                    break;
                }
            }

            Program.Kernel.GetRequiredService<FrmMain>().The_Vendor_ID = Conversions.ToInteger(((DataRowView)ComboBoxServiceVendor.SelectedItem).Row.ItemArray[0]);
            Caretag_Class.SQLUtil.UpdateToDatabase("Rules_Log", "ServiceVendor_ID='" + The_Vendor_ID + "' WHERE EPC_Nr='" + The_EPC_Nr_Service + "' AND ServiceVendor_ID IS NULL", false);
            Load_CSSD_Info();

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
                }

                Load_CSSD_InfoRet = true;
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while trying to load the CSSD information", "An error occurred while trying to load the CSSD information", "ServiceStation-48", true, true);
                Load_CSSD_InfoRet = false;
            }

            return Load_CSSD_InfoRet;
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            if (ComboBoxServiceVendor.SelectedIndex < 1)
            {
                ComboBoxServiceVendor.Select();
                return;
            }

            if (ButtonPrintReport.Visible)
            {
                Caretag_Class.SQLUtil.DeleteContent("Rules_Log WHERE EPC_Nr='" + The_EPC_Nr_Service + "' AND ServiceVendor_ID IS NULL");
            }

            try
            {
                Process.GetProcessesByName("osk")[0].Kill();
            }
            catch (Exception ex)
            {
            }

            Close();
        }

        private void ComboBoxServiceVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Form_Loaded)
                return;
            TextBox2.Clear();
            TextBoxSpecial.Clear();
            LabelSpecialInformation.ForeColor = Color.Black;
            if (ComboBoxServiceVendor.SelectedIndex == 0)
            {
                ButtonPrintReport.Enabled = false;
                return;
            }

            ButtonPrintReport.Enabled = true;
            try
            {
                var objConnection = new SqlConnection(Caretag_Class.Function_Module.SQL_ConnectionString);
                try
                {
                    if (objConnection.State == ConnectionState.Closed)
                    {
                        objConnection.Open();
                    }

                    var com1 = objConnection.CreateCommand();
                    Get_Service_Vendor_Info(com1, Conversions.ToInteger(((DataRowView)ComboBoxServiceVendor.SelectedItem).Row.ItemArray[0]));
                    Caretag_Class.SQLUtil.UpdateToDatabase("Instrument_RFID_Life", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("ServiceVendor_ID='", ((DataRowView)ComboBoxServiceVendor.SelectedItem).Row.ItemArray[0]), "' WHERE EPC_Nr='"), The_EPC_Nr_Service), "'")));
                    Caretag_Class.SQLUtil.UpdateToDatabase("Instrument_Maintenance_RFID", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("ServiceVendor_ID='", ((DataRowView)ComboBoxServiceVendor.SelectedItem).Row.ItemArray[0]), "' WHERE EPC_Nr='"), The_EPC_Nr_Service), "'")), false);
                    Program.Kernel.GetRequiredService<FrmMain>().The_Vendor_ID = Conversions.ToInteger(((DataRowView)ComboBoxServiceVendor.SelectedItem).Row.ItemArray[0]);
                }
                catch (Exception ex)
                {
                    _eventReporter.ReportError(ex, "An error occurred while trying to change the selected index", "An error occurred while trying to change the selected index", "ServiceStation-50", true, true);
                }

                objConnection.Close();
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while trying to change the selected index", "An error occurred while trying to change the selected index", "ServiceStation-49", true, true);
            }
        }

        private void Get_Service_Vendor_Info(SqlCommand The_Com, int The_Vendor_ID)
        {
            try
            {
                The_Com.CommandType = CommandType.Text;
                The_Com.CommandText = "SELECT * FROM Service_Vendor WHERE ServiceVendor_ID='" + The_Vendor_ID + "';";
                var reader = The_Com.ExecuteReader();
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
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while trying to retrieve the vendor service information", "An error occurred while trying to retrieve the vendor service information", "ServiceStation-51", true, true);
            }
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
                        // MessageBox.Show("This is not an integer")
                        throw new Exception();
                    }
                }

                string str_SQL = "  Special_Text =@Field_0 " + " WHERE ServiceVendor_ID='" + The_Vendor_ID.ToString() + "'";
                if (Caretag_Class.SQLUtil.UpdateToDatabase_ParaM("Service_Vendor", str_SQL, Field_Array, true))
                {
                    LabelSpecialInformation.ForeColor = Color.Green;
                }
                else
                {
                    LabelSpecialInformation.ForeColor = Color.Red;
                    throw new Exception("Update  Cost Item   Failed !");
                }
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while trying to click the information button", "An error occurred while trying to click the information button", "ServiceStation-52", true, true);
            }
        }

        private void ButtonPrintReport_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            try
            {
                ButtonPrintReport.Enabled = false;
                report = new XtraReport_Service_One();
                report.XrRichTextCompName.Text = Vendor_Name;
                report.XrRichTextAdress1.Text = Vendor_Street_1;
                report.XrRichTextAdress2.Text = Vendor_Street_2;
                report.XrRichTextZipp.Text = Vendor_Zip_code;
                report.XrRichTextCity.Text = Vendor_City;
                report.XrRichTextCountry.Text = Vendor_Country;
                report.XrRichTextCSSD.Text = CSSD_Name;
                report.XrLabelNameTopCSSD.Text = CSSD_Name;
                report.XrRichTextCityCSSD.Text = CSSD_City;
                report.XrLabelCityTopCSSD.Text = CSSD_City;
                report.XrRichTextStr1CSSD.Text = CSSD_Street_1;
                report.XrRichTextStr2CSSD.Text = CSSD_Street_2;
                report.XrRichTextZipCSSD.Text = CSSD_Zip_code;
                report.XrRichTextCityCSSD.Text = CSSD_City;
                report.XrRichTextCountCSSD.Text = CSSD_Country;
                report.DataSource = The_Service_Table;
                var Binding = new XRBinding("Text", report.DataSource, "Maintenance Text");
                report.XrRichTextService.DataBindings.Add(Binding);
                var Binding_Z = new XRBinding("Text", report.DataSource, "Service_Date");
                report.XrLabelSentBack.DataBindings.Add(Binding_Z);
                string The_Text = Caretag_Class.SQLUtil.LookUpInDataBase("View_GridView_1", " EPC_Nr ='" + The_EPC_Nr_Service + "'", "Description_Name");
                report.XrRichTextInstrument.Text = Program.Kernel.GetRequiredService<FrmMain>().The_Description_ID + "  " + The_Text;
                report.XrRichTextSpecialInfo.Text = Vendor_Special_Text;
                try
                {
                    Caretag_Class.SQLUtil.Loading_Logo_From_Database("SELECT The_Logo FROM Steril_Central", false, ref picture);
                    report.XrPictureBox1.Image = picture;
                }
                catch (Exception ex)
                {
                    _eventReporter.ReportError(ex, "An error occurred while trying to print the report", "An error occurred while trying to print the report", "ServiceStation-53", true, true);
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
                Cursor = Cursors.Default;
                Close();
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while trying to print the report", "An error occurred while trying to print the report", "ServiceStation-54", true, true);
            }
        }

        private void PrintingSystem_EndPrint(object sender, EventArgs e)
        {
            report.CloseRibbonPreview();
        }

        private int Do_Log(string The_EPC, long The_Maint_ID, long The_Vendor_ID)
        {
            int Do_LogRet = default;
            Do_LogRet = 1;       // Not Used
            try
            {
                // Dim InsertSQL As String = "(UserID,EPC_Nr,Rules_ID, Types_Service)  VALUES('" & Function_Module.Function_Module.GlobalPersonID & "','" & The_EPC & "','" & The_Maint_ID & "','" & Service_Type & "')"
                // Dim UpdatedNumber As Integer = Function_Module.SQLUtil.WriteToDatabase("Rules_Log", InsertSQL, "Rules_ID")

                string InsertSQL = "(UserID,EPC_Nr,Rules_ID, ServiceVendor_ID)  VALUES('" + Caretag_Class.Function_Module.GlobalPersonID + "','" + The_EPC + "','" + The_Maint_ID + "','" + The_Vendor_ID + "')";
                int UpdatedNumber = Caretag_Class.SQLUtil.WriteToDatabase("Service_Log", InsertSQL, "Rules_ID");
                return UpdatedNumber;
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while trying to save the Log in the database", "An error occurred while trying to save the Log in the database", "ServiceStation-55", true, true);
                Do_LogRet = 0;
            }

            return Do_LogRet;
        }
    }
}