using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Caretag_Class.EventReporting;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Service_Station
{
    public partial class Form_LifeCycle
    {
        private readonly EventReporter _eventReporter;

        public Form_LifeCycle(EventReporter eventReporter)
        {
            _eventReporter = eventReporter;
            InitializeComponent();
            _TopTitle.Name = "TopTitle";
            _ButtonExit.Name = "ButtonExit";
            _ButtonPrintAllRules.Name = "ButtonPrintAllRules";
        }

        public string Description_Text = "";
        public string Description_ID = "";
        public string The_EPC = "";
        private XtraReportALL_Rules Report = new XtraReportALL_Rules();
        private Dictionary<string, int> Columns_Dic = new Dictionary<string, int>();

        private void FrmLifeCycle_Load(object sender, EventArgs e)
        {
            try
            {
                TextBoxInstru_Descrip.Text = Description_Text + Constants.vbCrLf;
                if (this.Find_Columns("Instrument_RFID_Life").Trim().Length == 0)
                {
                    throw new Exception("Getting Database Failed !");
                }

                string Columns_Text = Caretag_Class.SQLUtil.LookUpInDataBase_Columns("Instrument_RFID_Life", " EPC_Nr='" + The_EPC + "'");
                var Array_Info = Columns_Text.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                Fill_TextBoxs(Array_Info);
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while loading the page", "An error occurred while loading the page", "ServiceStation-38", true, true);
                Close();
            }
        }

        private string Find_Columns(string The_Table)
        {
            try
            {
                IList<string> No_DataTypes = new[] { "varbinary" };  // ADD any type that should NOT use
                var The_DataTable = new DataTable();
                string str_SQL = "Select DATA_TYPE, TABLE_NAME, COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS " + " WHERE  (TABLE_NAME = '" + The_Table + "')";
                Caretag_Class.SQLUtil.FillDataTable(str_SQL, ref The_DataTable);
                for (int i = 0, loopTo = The_DataTable.Rows.Count - 1; i <= loopTo; i++)
                {
                    try
                    {
                        Columns_Dic.Add(The_DataTable.Rows[i]["COLUMN_NAME"].ToString(), i);
                    }
                    catch (Exception ex)
                    {
                    }
                }

                return str_SQL;
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while trying to find the columns", "An error occurred while trying to find the columns", "ServiceStation-39", true, true);
                return "";
            }
        }

        private void Fill_TextBoxs(Array The_Array)
        {
            if (The_Array.Length == 0)
                return;
            try
            {
                int The_Value = 0;
                if (Columns_Dic.TryGetValue("Steri_In", out The_Value))
                {
                    Fill_Text_Date(TextBoxCSSDIn, Conversions.ToString(The_Array.GetValue(The_Value)));
                }

                if (Columns_Dic.TryGetValue("Steri_Out", out The_Value))
                {
                    Fill_Text_Date(TextBoxCSSDOut, Conversions.ToString(The_Array.GetValue(The_Value)));
                }

                if (Columns_Dic.TryGetValue("Passed_Steri", out The_Value))
                {
                    Fill_Text_Number(TextBoxCSSDCounter, Conversions.ToString(The_Array.GetValue(The_Value)));
                }

                if (Columns_Dic.TryGetValue("OR_In", out The_Value))
                {
                    Fill_Text_Date(TextBoxORIn, Conversions.ToString(The_Array.GetValue(The_Value)));
                }

                if (Columns_Dic.TryGetValue("OR_Out", out The_Value))
                {
                    Fill_Text_Date(TextBoxOROut, Conversions.ToString(The_Array.GetValue(The_Value)));
                }

                if (Columns_Dic.TryGetValue("Used_In_OR", out The_Value))
                {
                    Fill_Text_Number(TextBoxORCounter, Conversions.ToString(The_Array.GetValue(The_Value)));
                }

                if (Columns_Dic.TryGetValue("Return_Service", out The_Value))
                {
                    Fill_Text_Date(TextBoxreturnService, Conversions.ToString(The_Array.GetValue(The_Value)));
                }

                if (Columns_Dic.TryGetValue("Sent_Service", out The_Value))
                {
                    Fill_Text_Date(TextBoxSentService, Conversions.ToString(The_Array.GetValue(The_Value)));
                }

                if (Columns_Dic.TryGetValue("Number_Service", out The_Value))
                {
                    Fill_Text_Number(TextBoxNumberService, Conversions.ToString(The_Array.GetValue(The_Value)));
                }

                if (Columns_Dic.TryGetValue("DaysInService", out The_Value))
                {
                    Fill_Text_Number(TextBoxServiceDays, Conversions.ToString(The_Array.GetValue(The_Value)));
                }

                if (Columns_Dic.TryGetValue("Demand_Service_Number", out The_Value))
                {
                    Fill_Text_Number(TextBoxDemandService, Conversions.ToString(The_Array.GetValue(The_Value)));
                }
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while trying fill the text boxes", "An error occurred while trying fill the text boxes", "ServiceStation-40", true, true);
            }
        }

        public bool Fill_Text_Date(TextBox The_TextBox, string The_Date)
        {
            try
            {
                if (Information.IsDate(The_Date))
                {
                    The_TextBox.Text = Strings.Format(Conversions.ToDate(The_Date), "yyyy-MM-dd") + "  (" + DateAndTime.DateDiff(DateInterval.Day, Conversions.ToDate(The_Date), DateAndTime.Now) + " Days)";
                }
                else
                {
                    The_TextBox.Text = " - ";
                }
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while trying fill the date boxes", "An error occurred while trying fill the date boxes", "ServiceStation-41", true, true);
            }

            return default;
        }

        public bool Fill_Text_Number(TextBox The_TextBox, string The_Number)
        {
            try
            {
                if (Information.IsNumeric(The_Number))
                {
                    The_TextBox.Text = The_Number;
                }
                else
                {
                    The_TextBox.Text = " - ";
                }
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while trying fill the number boxes", "An error occurred while trying fill the number boxes", "ServiceStation-42", true, true);
            }

            return default;
        }

        private void TopTitle_Click(object sender, EventArgs e)
        {
            bool Choose_Dir = false;
            if (My.MyProject.Computer.Keyboard.CtrlKeyDown)
            {
                Choose_Dir = true;
            }

            Caretag_Class.Caretag_Common.Functions.ScreenDump(Handle, Choose_Dir);
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void ButtonPrintAllRules_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            Report = new XtraReportALL_Rules();
            var param2 = new Parameter();
            param2.Name = "DescriptionID";
            param2.Type = typeof(string);
            param2.Value = Description_ID.ToString();
            // param2.Visible = True
            Report.Parameters.Add(param2);
            Report.FilterString = "[Description_ID] Like [Parameters.DescriptionID] OR [Description_ID] = 'Default_Rule' ";
            Report.RequestParameters = false;
            Report.PrintingSystem.EndPrint += PrintingSystem_EndPrint;
            var tool = new ReportPrintTool(Report);
            DevExpress.XtraBars.Ribbon.RibbonForm form = tool.PreviewRibbonForm as DevExpress.XtraBars.Ribbon.RibbonForm;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.CloseBox = false;
            // ******************************************************************************************************
            // form.ControlBox = False
            // ******************************************************************************************************
            Report.BringToFront();
            tool.ShowRibbonPreviewDialog();
            Cursor = Cursors.Default;
        }

        private void PrintingSystem_EndPrint(object sender, EventArgs e)
        {
            Report.CloseRibbonPreview();
        }
    }
}