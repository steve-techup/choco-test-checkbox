using System.Data;
using System.Diagnostics;
using System.Drawing;
using Microsoft.VisualBasic.CompilerServices;
using TechnicalStation.DataSets;

namespace TechnicalStation
{
    [DesignerGenerated()]
    public partial class XtraReport_ToDay : DevExpress.XtraReports.UI.XtraReport
    {

        // XtraReport overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            if (disposing && components is object)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        // Required by the Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Designer
        // It can be modified using the Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var XrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            var XrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            var XrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            Detail = new DevExpress.XtraReports.UI.DetailBand();
            XrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            XrPageInfo3 = new DevExpress.XtraReports.UI.XRPageInfo();
            XrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            XrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            XrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            XrLine1 = new DevExpress.XtraReports.UI.XRLine();
            XrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            XrLine2 = new DevExpress.XtraReports.UI.XRLine();
            ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            XrLabel_Filter = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            DataSet21 = new DataSet_Instru();
            ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            XrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            XrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            Technical_LogTableAdapter1 = new DataSets.DataSet_InstruTableAdapters.DataTable1TableAdapter();
            DataSet_Instru1 = new DataSet_Instru();
            DataTable1TableAdapter = new DataSets.DataSet_InstruTableAdapters.DataTable1TableAdapter();
            XrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)DataSet21).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DataSet_Instru1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            // 
            // Detail
            // 
            Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel4, XrLabel3, XrLabel2 });
            Detail.Dpi = 254.0f;
            Detail.HeightF = 58.0f;
            Detail.Name = "Detail";
            Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254.0f);
            Detail.SortFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] { new DevExpress.XtraReports.UI.GroupField("ChangeDate", DevExpress.XtraReports.UI.XRColumnSortOrder.Descending) });
            Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // XrLabel4
            // 
            XrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "Technical_Log.ChangeDate", "{0:yyyy MMM dd H:mm:ss}") });
            XrLabel4.Dpi = 254.0f;
            XrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(1412.875f, 0f);
            XrLabel4.Name = "XrLabel4";
            XrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel4.SizeF = new SizeF(418.0413f, 58.42f);
            XrLabel4.Text = "XrLabel4";
            // 
            // XrLabel3
            // 
            XrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "Technical_Log.Technical_Type", "{0:dd-MMMM-yyyy HH:mm}") });
            XrLabel3.Dpi = 254.0f;
            XrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(915.4584f, 0f);
            XrLabel3.Name = "XrLabel3";
            XrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel3.SizeF = new SizeF(497.4166f, 58.42f);
            XrLabel3.Text = "XrLabel3";
            // 
            // XrLabel2
            // 
            XrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "Technical_Log.EPC_Nr") });
            XrLabel2.Dpi = 254.0f;
            XrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0f, 0f);
            XrLabel2.Name = "XrLabel2";
            XrLabel2.NullValueText = "  -";
            XrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel2.SizeF = new SizeF(899.5834f, 58.42f);
            XrLabel2.Text = "XrLabel2";
            // 
            // TopMargin
            // 
            TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrPageInfo3, XrPageInfo1 });
            TopMargin.Dpi = 254.0f;
            TopMargin.HeightF = 254.0f;
            TopMargin.Name = "TopMargin";
            TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254.0f);
            TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // XrPageInfo3
            // 
            XrPageInfo3.Dpi = 254.0f;
            XrPageInfo3.ForeColor = Color.DarkGray;
            XrPageInfo3.LocationFloat = new DevExpress.Utils.PointFloat(926.0419f, 92.49835f);
            XrPageInfo3.Name = "XrPageInfo3";
            XrPageInfo3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrPageInfo3.PageInfo = DevExpress.XtraPrinting.PageInfo.UserName;
            XrPageInfo3.SizeF = new SizeF(937.9582f, 58.42001f);
            XrPageInfo3.StylePriority.UseForeColor = false;
            XrPageInfo3.StylePriority.UseTextAlignment = false;
            XrPageInfo3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            XrPageInfo3.TextFormatString = "{0:yyyy MMM dd H:mm:ss}";
            // 
            // XrPageInfo1
            // 
            XrPageInfo1.Dpi = 254.0f;
            XrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(25.40002f, 92.49834f);
            XrPageInfo1.Name = "XrPageInfo1";
            XrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            XrPageInfo1.SizeF = new SizeF(376.7666f, 58.42001f);
            XrPageInfo1.StylePriority.UseTextAlignment = false;
            XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            XrPageInfo1.TextFormatString = "{0:yyyy MMM dd H:mm:ss}";
            // 
            // BottomMargin
            // 
            BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrPageInfo2 });
            BottomMargin.Dpi = 254.0f;
            BottomMargin.HeightF = 254.0f;
            BottomMargin.Name = "BottomMargin";
            BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254.0f);
            BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // XrPageInfo2
            // 
            XrPageInfo2.Dpi = 254.0f;
            XrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(817.5f, 103.1875f);
            XrPageInfo2.Name = "XrPageInfo2";
            XrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrPageInfo2.SizeF = new SizeF(254.0f, 58.42f);
            XrPageInfo2.StylePriority.UseTextAlignment = false;
            XrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            XrPageInfo2.TextFormatString = "Page {0} of  {1}";
            // 
            // GroupHeader1
            // 
            GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel12, XrLabel7, XrLabel6, XrLabel5, XrLine1, XrLabel1 });
            GroupHeader1.Dpi = 254.0f;
            GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] { new DevExpress.XtraReports.UI.GroupField("Description_ID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending) });
            GroupHeader1.HeightF = 177.0f;
            GroupHeader1.Name = "GroupHeader1";
            // 
            // XrLabel12
            // 
            XrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "Technical_Log.Full_Name") });
            XrLabel12.Dpi = 254.0f;
            XrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(574.675f, 25.40002f);
            XrLabel12.Name = "XrLabel12";
            XrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel12.SizeF = new SizeF(1266.825f, 58.42f);
            XrLabel12.Text = "XrLabel12";
            // 
            // XrLabel7
            // 
            XrLabel7.Dpi = 254.0f;
            XrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(1423.458f, 102.9759f);
            XrLabel7.Name = "XrLabel7";
            XrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel7.SizeF = new SizeF(254.0f, 58.42001f);
            XrLabel7.StylePriority.UseTextAlignment = false;
            XrLabel7.Text = "Change Date";
            XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XrLabel6
            // 
            XrLabel6.Dpi = 254.0f;
            XrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(926.0419f, 101.3884f);
            XrLabel6.Name = "XrLabel6";
            XrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel6.SizeF = new SizeF(254.0f, 58.42f);
            XrLabel6.StylePriority.UseTextAlignment = false;
            XrLabel6.Text = "Process Type";
            XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XrLabel5
            // 
            XrLabel5.Dpi = 254.0f;
            XrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(10.58341f, 101.3884f);
            XrLabel5.Name = "XrLabel5";
            XrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel5.SizeF = new SizeF(254.0f, 58.42f);
            XrLabel5.StylePriority.UseTextAlignment = false;
            XrLabel5.Text = "EPC_Nr";
            XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XrLine1
            // 
            XrLine1.Dpi = 254.0f;
            XrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0f, 161.3958f);
            XrLine1.Name = "XrLine1";
            XrLine1.SizeF = new SizeF(1828.271f, 5.291672f);
            // 
            // XrLabel1
            // 
            XrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "Technical_Log.Description_ID", "Description ID: {0}") });
            XrLabel1.Dpi = 254.0f;
            XrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0f, 25.40002f);
            XrLabel1.Name = "XrLabel1";
            XrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel1.SizeF = new SizeF(574.675f, 58.42f);
            XrLabel1.Text = "XrLabel1";
            // 
            // XrLabel8
            // 
            XrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "View_Life_GridView.EPC_Nr") });
            XrLabel8.Dpi = 254.0f;
            XrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(694.7083f, 25.41334f);
            XrLabel8.Name = "XrLabel8";
            XrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel8.SizeF = new SizeF(470.9584f, 58.42f);
            XrLabel8.StylePriority.UseTextAlignment = false;
            XrSummary1.FormatString = "Instruments Coded : {0}";
            XrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.Count;
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            XrLabel8.Summary = XrSummary1;
            XrLabel8.Text = "XrLabel8";
            XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupFooter1
            // 
            GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLine2, XrLabel8 });
            GroupFooter1.Dpi = 254.0f;
            GroupFooter1.HeightF = 124.7083f;
            GroupFooter1.Name = "GroupFooter1";
            // 
            // XrLine2
            // 
            XrLine2.Dpi = 254.0f;
            XrLine2.LocationFloat = new DevExpress.Utils.PointFloat(0f, 0f);
            XrLine2.Name = "XrLine2";
            XrLine2.SizeF = new SizeF(1828.271f, 5.291674f);
            // 
            // ReportHeader
            // 
            ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel14, XrLabel_Filter, XrLabel10 });
            ReportHeader.Dpi = 254.0f;
            ReportHeader.HeightF = 280.0f;
            ReportHeader.Name = "ReportHeader";
            // 
            // XrLabel_Filter
            // 
            XrLabel_Filter.Dpi = 254.0f;
            XrLabel_Filter.ForeColor = Color.Teal;
            XrLabel_Filter.LocationFloat = new DevExpress.Utils.PointFloat(889.0001f, 209.8092f);
            XrLabel_Filter.Multiline = true;
            XrLabel_Filter.Name = "XrLabel_Filter";
            XrLabel_Filter.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel_Filter.SizeF = new SizeF(629.7083f, 58.42f);
            XrLabel_Filter.StylePriority.UseForeColor = false;
            XrLabel_Filter.StylePriority.UseTextAlignment = false;
            XrLabel_Filter.Text = "[Parameters.Coded_From!yyyy-MMM-dd]";
            XrLabel_Filter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XrLabel10
            // 
            XrLabel10.Dpi = 254.0f;
            XrLabel10.Font = new Font("Times New Roman", 28.0f, FontStyle.Bold);
            XrLabel10.ForeColor = Color.Teal;
            XrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(25.40002f, 68.68581f);
            XrLabel10.Name = "XrLabel10";
            XrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel10.SizeF = new SizeF(1802.871f, 122.8725f);
            XrLabel10.StylePriority.UseFont = false;
            XrLabel10.StylePriority.UseForeColor = false;
            XrLabel10.StylePriority.UseTextAlignment = false;
            XrLabel10.Text = "Instruments Coded ";
            XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // DataSet21
            // 
            DataSet21.DataSetName = "DataSet2";
            DataSet21.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            // 
            // ReportFooter
            // 
            ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel13, XrLabel9 });
            ReportFooter.Dpi = 254.0f;
            ReportFooter.HeightF = 254.0f;
            ReportFooter.Name = "ReportFooter";
            // 
            // XrLabel13
            // 
            XrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "DataTable1.ChangeDate") });
            XrLabel13.Dpi = 254.0f;
            XrLabel13.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
            XrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(942.9747f, 51.18744f);
            XrLabel13.Name = "XrLabel13";
            XrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel13.SizeF = new SizeF(873.1252f, 58.41998f);
            XrLabel13.StylePriority.UseFont = false;
            XrLabel13.StylePriority.UseTextAlignment = false;
            XrSummary2.FormatString = "Coded from Day: {0:yyyy-MMM-dd HH:mm}";
            XrSummary2.Func = DevExpress.XtraReports.UI.SummaryFunc.Min;
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            XrLabel13.Summary = XrSummary2;
            XrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XrLabel9
            // 
            XrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "View_Life_GridView.EPC_Nr") });
            XrLabel9.Dpi = 254.0f;
            XrLabel9.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
            XrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(271.6458f, 51.18744f);
            XrLabel9.Name = "XrLabel9";
            XrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel9.SizeF = new SizeF(568.8544f, 58.41998f);
            XrLabel9.StylePriority.UseFont = false;
            XrLabel9.StylePriority.UseTextAlignment = false;
            XrSummary3.FormatString = "Total Coded Instruments  :  {0}";
            XrSummary3.Func = DevExpress.XtraReports.UI.SummaryFunc.Count;
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            XrLabel9.Summary = XrSummary3;
            XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupHeader2
            // 
            GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel11 });
            GroupHeader2.Dpi = 254.0f;
            GroupHeader2.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] { new DevExpress.XtraReports.UI.GroupField("UserID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending) });
            GroupHeader2.HeightF = 193.0f;
            GroupHeader2.Level = 1;
            GroupHeader2.Name = "GroupHeader2";
            // 
            // XrLabel11
            // 
            XrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "Technical_Log.UserName", "For User: {0}") });
            XrLabel11.Dpi = 254.0f;
            XrLabel11.Font = new Font("Times New Roman", 18.0f, FontStyle.Bold);
            XrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(0f, 81.91497f);
            XrLabel11.Name = "XrLabel11";
            XrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel11.SizeF = new SizeF(1816.1f, 76.94083f);
            XrLabel11.StylePriority.UseFont = false;
            XrLabel11.Text = "XrLabel11";
            // 
            // Technical_LogTableAdapter1
            // 
            Technical_LogTableAdapter1.ClearBeforeFill = true;
            // 
            // DataSet_Instru1
            // 
            DataSet_Instru1.DataSetName = "DataSet_Instru";
            DataSet_Instru1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            // 
            // DataTable1TableAdapter
            // 
            DataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // XrLabel14
            // 
            XrLabel14.Dpi = 254.0f;
            XrLabel14.ForeColor = Color.Teal;
            XrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(635.0001f, 209.8092f);
            XrLabel14.Multiline = true;
            XrLabel14.Name = "XrLabel14";
            XrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0f);
            XrLabel14.SizeF = new SizeF(254.0f, 58.42f);
            XrLabel14.StylePriority.UseForeColor = false;
            XrLabel14.StylePriority.UseTextAlignment = false;
            XrLabel14.Text = "Date Filter from :";
            XrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XtraReport_ToDay
            // 
            Bands.AddRange(new DevExpress.XtraReports.UI.Band[] { Detail, TopMargin, BottomMargin, GroupHeader1, GroupFooter1, ReportHeader, ReportFooter, GroupHeader2 });
            DataAdapter = Technical_LogTableAdapter1;
            DataMember = "DataTable1";
            DataSource = DataSet_Instru1;
            Dpi = 254.0f;
            Margins = new System.Drawing.Printing.Margins(107, 104, 254, 254);
            PageHeight = 2970;
            PageWidth = 2100;
            PaperKind = System.Drawing.Printing.PaperKind.A4;
            ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic;
            SnapGridSize = 25.0f;
            Version = "18.2";
            ((System.ComponentModel.ISupportInitialize)DataSet21).EndInit();
            ((System.ComponentModel.ISupportInitialize)DataSet_Instru1).EndInit();
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
        }

        internal DevExpress.XtraReports.UI.DetailBand Detail;
        internal DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        internal DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        // Friend WithEvents Caretag_SurgicalDataSet1 As TechnicalStation.Caretag_SurgicalDataSet
        // Friend WithEvents View_Life_GridViewTableAdapter As TechnicalStation.Caretag_SurgicalDataSetTableAdapters.View_Life_GridViewTableAdapter
        internal DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel4;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel3;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel2;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel7;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel6;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel5;
        internal DevExpress.XtraReports.UI.XRLine XrLine1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel8;
        internal DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        internal DevExpress.XtraReports.UI.XRLine XrLine2;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo1;
        internal DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel10;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo2;
        internal DataSet_Instru DataSet21;
        internal DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel9;
        internal DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader2;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel11;
        internal DataSets.DataSet_InstruTableAdapters.DataTable1TableAdapter Technical_LogTableAdapter1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel12;
        internal DataSet_Instru DataSet_Instru1;
        internal DataSets.DataSet_InstruTableAdapters.DataTable1TableAdapter DataTable1TableAdapter;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo3;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel13;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel_Filter;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel14;
    }
}