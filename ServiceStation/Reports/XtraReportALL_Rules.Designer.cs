using System.Data;
using System.Diagnostics;
using System.Drawing;
using Microsoft.VisualBasic.CompilerServices;
using Service_Station.DataSets;

namespace Service_Station
{
    [DesignerGenerated()]
    public partial class XtraReportALL_Rules : DevExpress.XtraReports.UI.XtraReport
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
            Detail = new DevExpress.XtraReports.UI.DetailBand();
            XrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            XrPageInfo3 = new DevExpress.XtraReports.UI.XRPageInfo();
            XrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            XrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            XrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            XrLine2 = new DevExpress.XtraReports.UI.XRLine();
            XrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            XrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            XrLine1 = new DevExpress.XtraReports.UI.XRLine();
            XrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            XrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            DataSet11 = new DataSet1();
            Instrument_Maintenance_RulesTableAdapter = new DataSets.DataSet1TableAdapters.Instrument_Maintenance_RulesTableAdapter();
            Instrument_Maintenance_RulesTableAdapter1 = new DataSets.DataSet1TableAdapters.Instrument_Maintenance_RulesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)DataSet11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            // 
            // Detail
            // 
            Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel12, XrLabel11, XrLabel7, XrLabel2, XrLabel3 });
            Detail.Dpi = 100.0f;
            Detail.HeightF = 24.37501f;
            Detail.Name = "Detail";
            Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0f);
            Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // XrLabel12
            // 
            XrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "Instrument_Maintenance_Rules.Maintenance_ID") });
            XrLabel12.Dpi = 100.0f;
            XrLabel12.Font = new Font("Times New Roman", 9.75f, FontStyle.Italic);
            XrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(959.666f, 0f);
            XrLabel12.Name = "XrLabel12";
            XrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel12.SizeF = new SizeF(58.3338f, 23.0f);
            XrLabel12.StylePriority.UseFont = false;
            XrLabel12.StylePriority.UseTextAlignment = false;
            XrLabel12.Text = "XrLabel12";
            XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // XrLabel11
            // 
            XrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "Instrument_Maintenance_Rules.Maintenance_Period_Start", "{0:dd-MMMM-yyyy}") });
            XrLabel11.Dpi = 100.0f;
            XrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(821.25f, 0f);
            XrLabel11.Name = "XrLabel11";
            XrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel11.SizeF = new SizeF(128.4164f, 23.0f);
            XrLabel11.StylePriority.UseTextAlignment = false;
            XrLabel11.Text = "XrLabel11";
            XrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XrLabel7
            // 
            XrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "Instrument_Maintenance_Rules.Maintenance_Periods") });
            XrLabel7.Dpi = 100.0f;
            XrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(740.0f, 0f);
            XrLabel7.Name = "XrLabel7";
            XrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel7.SizeF = new SizeF(81.25f, 23.0f);
            XrLabel7.StylePriority.UseTextAlignment = false;
            XrLabel7.Text = "XrLabel7";
            XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XrLabel2
            // 
            XrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "Instrument_Maintenance_Rules.Maintenance_Value") });
            XrLabel2.Dpi = 100.0f;
            XrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(640.0f, 0f);
            XrLabel2.Name = "XrLabel2";
            XrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel2.SizeF = new SizeF(100.0f, 23.0f);
            XrLabel2.StylePriority.UseTextAlignment = false;
            XrLabel2.Text = "XrLabel2";
            XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XrLabel3
            // 
            XrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "Instrument_Maintenance_Rules.Maintenance_Text") });
            XrLabel3.Dpi = 100.0f;
            XrLabel3.Font = new Font("Times New Roman", 9.75f);
            XrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0f, 0f);
            XrLabel3.Name = "XrLabel3";
            XrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel3.SizeF = new SizeF(640.0f, 23.0f);
            XrLabel3.StylePriority.UseFont = false;
            XrLabel3.StylePriority.UseTextAlignment = false;
            XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TopMargin
            // 
            TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrPageInfo3, XrPageInfo2 });
            TopMargin.Dpi = 100.0f;
            TopMargin.HeightF = 100.0f;
            TopMargin.Name = "TopMargin";
            TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0f);
            TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // XrPageInfo3
            // 
            XrPageInfo3.Dpi = 100.0f;
            XrPageInfo3.LocationFloat = new DevExpress.Utils.PointFloat(574.2498f, 46.83334f);
            XrPageInfo3.Name = "XrPageInfo3";
            XrPageInfo3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrPageInfo3.PageInfo = DevExpress.XtraPrinting.PageInfo.UserName;
            XrPageInfo3.SizeF = new SizeF(443.75f, 23.0f);
            XrPageInfo3.StylePriority.UseTextAlignment = false;
            XrPageInfo3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // XrPageInfo2
            // 
            XrPageInfo2.Dpi = 100.0f;
            XrPageInfo2.Format = "{0:dd. MMMM yyyy}";
            XrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(0f, 46.83334f);
            XrPageInfo2.Name = "XrPageInfo2";
            XrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            XrPageInfo2.SizeF = new SizeF(133.3333f, 23.0f);
            XrPageInfo2.StylePriority.UseTextAlignment = false;
            XrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // BottomMargin
            // 
            BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrPageInfo1 });
            BottomMargin.Dpi = 100.0f;
            BottomMargin.HeightF = 100.0f;
            BottomMargin.Name = "BottomMargin";
            BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0f);
            BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // XrPageInfo1
            // 
            XrPageInfo1.Dpi = 100.0f;
            XrPageInfo1.Format = "Pages {0} of {1}";
            XrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(907.9998f, 22.87502f);
            XrPageInfo1.Name = "XrPageInfo1";
            XrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrPageInfo1.SizeF = new SizeF(100.0f, 23.0f);
            XrPageInfo1.StylePriority.UseTextAlignment = false;
            XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // GroupHeader1
            // 
            GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel14, XrLabel13, XrLabel10, XrLabel9, XrLabel8, XrLine2, XrLabel1 });
            GroupHeader1.Dpi = 100.0f;
            GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] { new DevExpress.XtraReports.UI.GroupField("Description_ID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending) });
            GroupHeader1.HeightF = 70.83334f;
            GroupHeader1.KeepTogether = true;
            GroupHeader1.Level = 1;
            GroupHeader1.Name = "GroupHeader1";
            // 
            // XrLabel14
            // 
            XrLabel14.Dpi = 100.0f;
            XrLabel14.Font = new Font("Times New Roman", 12.0f, FontStyle.Bold);
            XrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(836.1247f, 42.62502f);
            XrLabel14.Name = "XrLabel14";
            XrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel14.SizeF = new SizeF(97.91669f, 23.0f);
            XrLabel14.StylePriority.UseFont = false;
            XrLabel14.StylePriority.UseTextAlignment = false;
            XrLabel14.Text = "Maint. Start";
            XrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // XrLabel13
            // 
            XrLabel13.Dpi = 100.0f;
            XrLabel13.Font = new Font("Times New Roman", 10.0f, FontStyle.Bold);
            XrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(742.0834f, 42.62502f);
            XrLabel13.Name = "XrLabel13";
            XrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel13.SizeF = new SizeF(79.16663f, 23.0f);
            XrLabel13.StylePriority.UseFont = false;
            XrLabel13.StylePriority.UseTextAlignment = false;
            XrLabel13.Text = "Maint. Peri";
            XrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // XrLabel10
            // 
            XrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "Instrument_Maintenance_Rules.Description_ID") });
            XrLabel10.Dpi = 100.0f;
            XrLabel10.Font = new Font("Times New Roman", 16.0f, FontStyle.Bold);
            XrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(0f, 0f);
            XrLabel10.Name = "XrLabel10";
            XrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel10.SizeF = new SizeF(247.9167f, 32.08333f);
            XrLabel10.StylePriority.UseFont = false;
            XrLabel10.Text = "XrLabel10";
            // 
            // XrLabel9
            // 
            XrLabel9.Dpi = 100.0f;
            XrLabel9.Font = new Font("Times New Roman", 10.0f, FontStyle.Bold);
            XrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(647.5833f, 42.62502f);
            XrLabel9.Name = "XrLabel9";
            XrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel9.SizeF = new SizeF(82.29169f, 23.0f);
            XrLabel9.StylePriority.UseFont = false;
            XrLabel9.StylePriority.UseTextAlignment = false;
            XrLabel9.Text = "Maint. Value";
            XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // XrLabel8
            // 
            XrLabel8.Dpi = 100.0f;
            XrLabel8.Font = new Font("Times New Roman", 12.0f, FontStyle.Bold);
            XrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(0f, 42.62502f);
            XrLabel8.Name = "XrLabel8";
            XrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel8.SizeF = new SizeF(100.0f, 23.0f);
            XrLabel8.StylePriority.UseFont = false;
            XrLabel8.StylePriority.UseTextAlignment = false;
            XrLabel8.Text = "Rule";
            XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XrLine2
            // 
            XrLine2.Dpi = 100.0f;
            XrLine2.LocationFloat = new DevExpress.Utils.PointFloat(0f, 65.625f);
            XrLine2.Name = "XrLine2";
            XrLine2.SizeF = new SizeF(1018.0f, 5.208336f);
            // 
            // XrLabel1
            // 
            XrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "Instrument_Maintenance_Rules.Description_Name") });
            XrLabel1.Dpi = 100.0f;
            XrLabel1.Font = new Font("Times New Roman", 16.0f, FontStyle.Bold);
            XrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(247.9167f, 0f);
            XrLabel1.Name = "XrLabel1";
            XrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel1.SizeF = new SizeF(760.0831f, 32.08333f);
            XrLabel1.StylePriority.UseFont = false;
            // 
            // GroupFooter1
            // 
            GroupFooter1.Dpi = 100.0f;
            GroupFooter1.HeightF = 18.75f;
            GroupFooter1.Name = "GroupFooter1";
            // 
            // XrLabel4
            // 
            XrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "Instrument_Maintenance_Rules.Maintenance_ID") });
            XrLabel4.Dpi = 100.0f;
            XrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(521.4999f, 13.12497f);
            XrLabel4.Name = "XrLabel4";
            XrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel4.SizeF = new SizeF(78.12503f, 23.0f);
            XrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.DCount;
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            XrLabel4.Summary = XrSummary1;
            XrLabel4.Text = "XrLabel4";
            // 
            // GroupFooter2
            // 
            GroupFooter2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLine1, XrLabel6, XrLabel4 });
            GroupFooter2.Dpi = 100.0f;
            GroupFooter2.HeightF = 95.125f;
            GroupFooter2.Level = 1;
            GroupFooter2.Name = "GroupFooter2";
            // 
            // XrLine1
            // 
            XrLine1.Dpi = 100.0f;
            XrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0f, 36.12493f);
            XrLine1.Name = "XrLine1";
            XrLine1.SizeF = new SizeF(1018.0f, 8.666706f);
            // 
            // XrLabel6
            // 
            XrLabel6.Dpi = 100.0f;
            XrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(418.375f, 13.12497f);
            XrLabel6.Name = "XrLabel6";
            XrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel6.SizeF = new SizeF(103.125f, 23.0f);
            XrLabel6.Text = "Number of Rules:";
            // 
            // ReportHeader
            // 
            ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel5 });
            ReportHeader.Dpi = 100.0f;
            ReportHeader.HeightF = 134.375f;
            ReportHeader.Name = "ReportHeader";
            // 
            // XrLabel5
            // 
            XrLabel5.Dpi = 100.0f;
            XrLabel5.Font = new Font("Times New Roman", 24.0f, FontStyle.Bold);
            XrLabel5.ForeColor = Color.Teal;
            XrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(4.16673f, 27.04166f);
            XrLabel5.Name = "XrLabel5";
            XrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel5.SizeF = new SizeF(1013.833f, 48.00001f);
            XrLabel5.StylePriority.UseFont = false;
            XrLabel5.StylePriority.UseForeColor = false;
            XrLabel5.StylePriority.UseTextAlignment = false;
            XrLabel5.Text = "Instruments Types Related to Rules";
            XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // DataSet11
            // 
            DataSet11.DataSetName = "DataSet1";
            DataSet11.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            // 
            // Instrument_Maintenance_RulesTableAdapter
            // 
            Instrument_Maintenance_RulesTableAdapter.ClearBeforeFill = true;
            // 
            // Instrument_Maintenance_RulesTableAdapter1
            // 
            Instrument_Maintenance_RulesTableAdapter1.ClearBeforeFill = true;
            // 
            // XtraReportALL_Rules
            // 
            Bands.AddRange(new DevExpress.XtraReports.UI.Band[] { Detail, TopMargin, BottomMargin, GroupHeader1, GroupFooter1, GroupFooter2, ReportHeader });
            DataAdapter = Instrument_Maintenance_RulesTableAdapter1;
            DataMember = "Instrument_Maintenance_Rules";
            DataSource = DataSet11;
            Landscape = true;
            Margins = new System.Drawing.Printing.Margins(81, 70, 100, 100);
            PageHeight = 827;
            PageWidth = 1169;
            PaperKind = System.Drawing.Printing.PaperKind.A4;
            Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)DataSet11).EndInit();
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
        }

        internal DevExpress.XtraReports.UI.DetailBand Detail;
        internal DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        internal DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        internal DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel3;
        internal DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel4;
        internal DevExpress.XtraReports.UI.GroupFooterBand GroupFooter2;
        internal DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel5;
        internal DevExpress.XtraReports.UI.XRLine XrLine2;
        internal DevExpress.XtraReports.UI.XRLine XrLine1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel6;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo2;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel9;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel8;
        internal DataSet1 DataSet11;
        internal DataSets.DataSet1TableAdapters.Instrument_Maintenance_RulesTableAdapter Instrument_Maintenance_RulesTableAdapter;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel10;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel11;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel7;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel2;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel12;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel14;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel13;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo3;
        internal DataSets.DataSet1TableAdapters.Instrument_Maintenance_RulesTableAdapter Instrument_Maintenance_RulesTableAdapter1;
    }
}