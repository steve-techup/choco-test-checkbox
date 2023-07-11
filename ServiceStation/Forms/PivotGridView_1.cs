using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Caretag_Class.EventReporting;
using DevExpress.LookAndFeel;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Service_Station
{
    public partial class PivotGridView_1
    {
        private readonly EventReporter _eventReporter;

        public PivotGridView_1(EventReporter eventReporter)
        {
            _eventReporter = eventReporter;
            InitializeComponent();
            _PivotGridControl1.Name = "PivotGridControl1";
            _TopTitle.Name = "TopTitle";
            _Button_Exit.Name = "Button_Exit";
            _Button_Preview1.Name = "Button_Preview1";
            _ButtonExportExcel.Name = "ButtonExportExcel";
            _ButtonPrintReport.Name = "ButtonPrintReport";
            _CheckBoxServiceToday.Name = "CheckBoxServiceToday";
        }

        private string Extra_Where = "";
        private string Where_SentService = " (Sent_Service Is Not NULL)";
        private bool Loaded_Form = false;
        private bool Row_Collapses = true;
        private int The_Security;
        private string The_UserName = "";
        private ResourceManager LocRM = new ResourceManager("ServiceStation.WinformStrings", typeof(PivotGridView_1).Assembly);
        private XtraReportServiceLog Report = new XtraReportServiceLog();

        private void FormGridView_1_Load(object sender, EventArgs e)
        {
            try
            {
                string str_Text = Caretag_Class.SQLUtil.LookUpInDataBase("TblPassword", "UserID = '" + Caretag_Class.Function_Module.GlobalPersonID + "'", "SecurityLevel");
                if (!int.TryParse(str_Text, out The_Security))
                {
                    The_Security = 1;
                }

                The_UserName = Caretag_Class.SQLUtil.LookUpInDataBase("TblPassword", "UserID = '" + Caretag_Class.Function_Module.GlobalPersonID + "'", "UserName");
                var Test_Date = new DateTime(DateAndTime.Now.Year, DateAndTime.Now.Month, DateAndTime.Now.Day, 0, 0, 0);
                Extra_Where = " WHERE Return_Service > '" + Test_Date + "' AND " + Where_SentService;
                if (!Load_Pivotgrid("SELECT * FROM View_Service_GridView" + Extra_Where))
                {
                    throw new ApplicationException(LocRM.GetString("Pivot_Not_Loading"));
                }

                Loaded_Form = true;
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while loading the pivot data grid", "An error occurred while loading the pivot data grid", "ServiceStation-43", true, true);
                Dispose();
            }
        }

        private bool Load_Pivotgrid(string SQL_str)
        {
            bool Load_PivotgridRet = default;
            var objConnection = new SqlConnection(Caretag_Class.Function_Module.SQL_ConnectionString);
            try
            {
                // Create a data adapter.
                var objDataAdapter = new SqlDataAdapter(SQL_str, objConnection);

                // Create and fill a dataset.
                var sourceDataSet = new DataSet();
                objDataAdapter.Fill(sourceDataSet, "ViewItems");
                PivotGridControl1.Fields.Clear();
                // Assign the data source to the XtraPivotGrid control.
                PivotGridControl1.DataSource = sourceDataSet.Tables["ViewItems"];

                // Create a row PivotGridControl field bound to the Country data-source field.
                var field_Number_Service = new PivotGridField("Number_Service", PivotArea.RowArea);
                var field_Instrument_LastSeen_Date = new PivotGridField("Sent_Service", PivotArea.RowArea) { Caption = "Sent To Service" };
                var field_Instrument_LastSeen_Place = new PivotGridField("Return_Service", PivotArea.RowArea) { Caption = "Return From Service" };
                var field_Full_Name = new PivotGridField("Full_Name", PivotArea.RowArea);
                var field_Date_Birth = new PivotGridField("Date_Birth", PivotArea.FilterArea) { Caption = "Date Birth" };
                var field_Passed_Steri = new PivotGridField("Passed_Steri", PivotArea.FilterArea);
                var field_Used_In_OR = new PivotGridField("Used_In_OR", PivotArea.FilterArea);
                var field_DaysInService = new PivotGridField("DaysInService", PivotArea.FilterArea);
                var field_EPC_Nr = new PivotGridField("EPC_Nr", PivotArea.DataArea) { SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count };

                // Add the fields to the control's field collection.         
                PivotGridControl1.Fields.AddRange(new PivotGridField[] { field_Number_Service, field_Instrument_LastSeen_Date, field_Instrument_LastSeen_Place, field_Full_Name, field_EPC_Nr, field_DaysInService, field_Date_Birth, field_Passed_Steri, field_Used_In_OR });
                field_Full_Name.AreaIndex = 0;
                field_Instrument_LastSeen_Date.ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                field_Instrument_LastSeen_Date.ValueFormat.FormatString = "yyyy/MMM/dd";
                field_Date_Birth.ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                field_Date_Birth.ValueFormat.FormatString = "yyyy/MMM/dd";
                field_Instrument_LastSeen_Place.ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                field_Instrument_LastSeen_Place.ValueFormat.FormatString = "yyyy/MMM/dd";

                // PivotGridControl1.OptionsView.ShowColumnGrandTotals = True
                PivotGridControl1.OptionsBehavior.HorizontalScrolling = PivotGridScrolling.Control;
                PivotGridControl1.BestFit();

                // Customize the control's look-and-feel via the Default LookAndFeel object.
                UserLookAndFeel.Default.UseWindowsXPTheme = false;
                UserLookAndFeel.Default.Style = LookAndFeelStyle.Skin;
                UserLookAndFeel.Default.SkinName = "Money Twins";
                Load_PivotgridRet = true;
            }
            catch (Exception ex)
            {
                Load_PivotgridRet = false;
            }

            return Load_PivotgridRet;
        }

        private void pivotGridControl1_FieldValueDisplayText(object sender, PivotFieldDisplayTextEventArgs e)
        {
            try
            {
            }
            // If e.Field Is PivotGridControl1.Fields.Item("Instrument_InUse") Then
            // Select Case Convert.ToInt32(e.Value)
            // Case -1
            // e.DisplayText = "OutSide"
            // Case 0
            // e.DisplayText = "Stationary"
            // Case 1
            // e.DisplayText = "InSide"
            // Case 2
            // e.DisplayText = "TTT"
            // End Select
            // End If
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while trying to display a value in the pivot data grid", "An error occurred while trying to display a value in the pivot data grid", "ServiceStation-44", true, true);
            }
        }

        private void Button_Preview1_Click_1(object sender, EventArgs e)
        {
            PivotGridControl1.OptionsPrint.PageSettings.Landscape = true;
            PivotGridControl1.OptionsPrint.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            PivotGridControl1.BringToFront();
            PivotGridControl1.ShowRibbonPrintPreview();
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

        private void ButtonExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string The_Location = "";
                var MyFolderBrowser = new FolderBrowserDialog();
                // Description that displays above the dialog box control. 

                MyFolderBrowser.Description = "Select the Folder";
                // Sets the root folder where the browsing starts from 
                MyFolderBrowser.RootFolder = Environment.SpecialFolder.MyDocuments;
                var dlgResult = MyFolderBrowser.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    The_Location = MyFolderBrowser.SelectedPath + @"\pivotGrid_" + DateAndTime.Now.Millisecond + ".xls";
                    var pivotExportOptions = new PivotXlsxExportOptions();
                    pivotExportOptions.ExportType = DevExpress.Export.ExportType.WYSIWYG;
                    PivotGridControl1.ExportToXlsx(The_Location, pivotExportOptions);
                    MessageBox.Show(LocRM.GetString("File_Saved") + " : " + The_Location, "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while trying to export the Excel", "An error occurred while trying to export the Excel", "ServiceStation-45", true, true);
            }
        }

        private void ButtonPrintReport_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;

            Report = new XtraReportServiceLog();
            var Test_Date = new DateTime(DateAndTime.Now.Year, DateAndTime.Now.Month, DateAndTime.Now.Day, 0, 0, 0);
            if (The_Security == 9)
            {
                var param1 = new Parameter() { Name = "Service_From", Type = typeof(DateTime), Value = Test_Date, Visible = true };
                Report.Parameters.Add(param1);
                var param2 = new Parameter() { Name = "UserName", Type = typeof(string), Value = "%", Visible = true };
                Report.Parameters.Add(param2);
                Report.FilterString = "[UserName] Like [Parameters.UserName] AND [ChangeDate] >= [Parameters.Service_From] ";
                Report.RequestParameters = true;
            }
            else
            {
                var param1 = new Parameter() { Name = "Service_From", Type = typeof(DateTime), Value = Test_Date, Visible = true };
                Report.Parameters.Add(param1);
                var param2 = new Parameter() { Name = "UserName", Type = typeof(string), Value = The_UserName, Visible = false };
                Report.Parameters.Add(param2);
                Report.FilterString = "[UserName] = [Parameters.UserName] AND [ChangeDate] >= [Parameters.Service_From]";
                Report.RequestParameters = true;
            }

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

        private void CheckBoxServiceToday_CheckedChanged(object sender, EventArgs e)
        {
            if (!Loaded_Form)
                return;
            try
            {
                if (CheckBoxServiceToday.Checked)
                {
                    var Test_Date = new DateTime(DateAndTime.Now.Year, DateAndTime.Now.Month, DateAndTime.Now.Day, 0, 0, 0);
                    Extra_Where = " WHERE Return_Service > '" + Test_Date + "' AND " + Where_SentService;
                }
                else
                {
                    Extra_Where = " WHERE " + Where_SentService;
                }

                if (!Load_Pivotgrid("SELECT * FROM View_Service_GridView" + Extra_Where))
                {
                    throw new ApplicationException(LocRM.GetString("Pivot_Not_Loading"));
                }
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while trying to load the pivot grid", "An error occurred while trying to load the pivot grid", "ServiceStation-46", true, true);
            }
        }

        private void PivotGridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (Row_Collapses)
                {
                    PivotGridControl1.CollapseAllRows();
                    Row_Collapses = false;
                }
                else
                {
                    PivotGridControl1.ExpandAllRows();
                    Row_Collapses = true;
                }
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while trying to collapse or expand the pivot grid control rows", "An error occurred while trying to collapse or expand the pivot grid control rows", "ServiceStation-47", true, true);
            }
        }
    }
}