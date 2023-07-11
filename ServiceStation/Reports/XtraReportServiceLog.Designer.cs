using System.Data;
using System.Diagnostics;
using System.Drawing;
using Microsoft.VisualBasic.CompilerServices;
using Service_Station.DataSets;

namespace Service_Station
{
    [DesignerGenerated()]
    public partial class XtraReportServiceLog : DevExpress.XtraReports.UI.XtraReport
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
            XrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            XrPageInfo3 = new DevExpress.XtraReports.UI.XRPageInfo();
            XrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            XrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            Caretag_SurgicalDataSet11 = new Caretag_SurgicalDataSet1();
            Service_LogTableAdapter = new DataSets.Caretag_SurgicalDataSet1TableAdapters.Service_LogTableAdapter();
            GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            XrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            XrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            XrLine1 = new DevExpress.XtraReports.UI.XRLine();
            GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            XrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            XrLine2 = new DevExpress.XtraReports.UI.XRLine();
            ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            XrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            GroupHeader3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            XrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            XrLine3 = new DevExpress.XtraReports.UI.XRLine();
            ((System.ComponentModel.ISupportInitialize)Caretag_SurgicalDataSet11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            // 
            // Detail
            // 
            Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel6, XrLabel5 });
            Detail.Dpi = 100.0f;
            Detail.HeightF = 20.83334f;
            Detail.Name = "Detail";
            Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0f);
            Detail.SortFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] { new DevExpress.XtraReports.UI.GroupField("ChangeDate", DevExpress.XtraReports.UI.XRColumnSortOrder.Descending) });
            Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // XrLabel6
            // 
            XrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "Service_Log.ChangeDate", "{0:yyyy MMM dd H:mm:ss}") });
            XrLabel6.Dpi = 100.0f;
            XrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(545.25f, 0f);
            XrLabel6.Name = "XrLabel6";
            XrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel6.SizeF = new SizeF(143.75f, 20.83334f);
            XrLabel6.Text = "XrLabel6";
            // 
            // XrLabel5
            // 
            XrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "Service_Log.Maintenance_Text") });
            XrLabel5.Dpi = 100.0f;
            XrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0f, 0f);
            XrLabel5.Name = "XrLabel5";
            XrLabel5.NullValueText = " - - -";
            XrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel5.SizeF = new SizeF(545.2499f, 20.83334f);
            XrLabel5.Text = "XrLabel5";
            // 
            // XrLabel4
            // 
            XrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "Service_Log.Description_Text") });
            XrLabel4.Dpi = 100.0f;
            XrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(1.041698f, 31.33335f);
            XrLabel4.Name = "XrLabel4";
            XrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel4.SizeF = new SizeF(685.8749f, 23.0f);
            XrLabel4.StylePriority.UseTextAlignment = false;
            XrLabel4.Text = "XrLabel4";
            XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
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
            XrPageInfo3.LocationFloat = new DevExpress.Utils.PointFloat(436.9167f, 31.20834f);
            XrPageInfo3.Name = "XrPageInfo3";
            XrPageInfo3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrPageInfo3.PageInfo = DevExpress.XtraPrinting.PageInfo.UserName;
            XrPageInfo3.SizeF = new SizeF(252.0832f, 23.0f);
            XrPageInfo3.StylePriority.UseTextAlignment = false;
            XrPageInfo3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // XrPageInfo2
            // 
            XrPageInfo2.Dpi = 100.0f;
            XrPageInfo2.Format = "{0:yyyy MMM dd H:mm:ss}";
            XrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(0f, 31.20834f);
            XrPageInfo2.Name = "XrPageInfo2";
            XrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            XrPageInfo2.SizeF = new SizeF(213.5417f, 23.0f);
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
            XrPageInfo1.Format = "Page {0} of {1}";
            XrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(300.0f, 25.0f);
            XrPageInfo1.Name = "XrPageInfo1";
            XrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrPageInfo1.SizeF = new SizeF(100.0f, 23.0f);
            XrPageInfo1.StylePriority.UseTextAlignment = false;
            XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Caretag_SurgicalDataSet11
            // 
            Caretag_SurgicalDataSet11.DataSetName = "Caretag_SurgicalDataSet1";
            Caretag_SurgicalDataSet11.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            // 
            // Service_LogTableAdapter
            // 
            Service_LogTableAdapter.ClearBeforeFill = true;
            // 
            // GroupHeader1
            // 
            GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel8, XrLabel2 });
            GroupHeader1.Dpi = 100.0f;
            GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] { new DevExpress.XtraReports.UI.GroupField("UserName", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending) });
            GroupHeader1.HeightF = 63.54167f;
            GroupHeader1.Level = 2;
            GroupHeader1.Name = "GroupHeader1";
            // 
            // XrLabel8
            // 
            XrLabel8.Dpi = 100.0f;
            XrLabel8.Font = new Font("Times New Roman", 14.0f, FontStyle.Bold);
            XrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(2.083365f, 10.00001f);
            XrLabel8.Name = "XrLabel8";
            XrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel8.SizeF = new SizeF(225.0f, 29.25f);
            XrLabel8.StylePriority.UseFont = false;
            XrLabel8.StylePriority.UseTextAlignment = false;
            XrLabel8.Text = "Recived From Service by:";
            XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XrLabel2
            // 
            XrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "Service_Log.UserName") });
            XrLabel2.Dpi = 100.0f;
            XrLabel2.Font = new Font("Times New Roman", 14.0f, FontStyle.Bold);
            XrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(227.0833f, 10.00001f);
            XrLabel2.Name = "XrLabel2";
            XrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel2.SizeF = new SizeF(461.9165f, 29.25f);
            XrLabel2.StylePriority.UseFont = false;
            XrLabel2.StylePriority.UseTextAlignment = false;
            XrLabel2.Text = "XrLabel2";
            XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupHeader2
            // 
            GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLine3, XrLabel10, XrLabel3, XrLabel1 });
            GroupHeader2.Dpi = 100.0f;
            GroupHeader2.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] { new DevExpress.XtraReports.UI.GroupField("ServiceVendor_ID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending) });
            GroupHeader2.HeightF = 79.16666f;
            GroupHeader2.Level = 1;
            GroupHeader2.Name = "GroupHeader2";
            // 
            // XrLabel10
            // 
            XrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "Service_Log.Vendor_City", "City : {0}") });
            XrLabel10.Dpi = 100.0f;
            XrLabel10.Font = new Font("Times New Roman", 12.0f);
            XrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(0f, 45.7916f);
            XrLabel10.Name = "XrLabel10";
            XrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel10.SizeF = new SizeF(654.2082f, 23.0f);
            XrLabel10.StylePriority.UseFont = false;
            XrLabel10.StylePriority.UseTextAlignment = false;
            XrLabel10.Text = "XrLabel10";
            XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XrLabel3
            // 
            XrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "Service_Log.Vendor_Name", "Company Name : {0}") });
            XrLabel3.Dpi = 100.0f;
            XrLabel3.Font = new Font("Times New Roman", 12.0f);
            XrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0f, 22.79161f);
            XrLabel3.Name = "XrLabel3";
            XrLabel3.NullValueText = "- ? -";
            XrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel3.SizeF = new SizeF(689.0f, 23.0f);
            XrLabel3.StylePriority.UseFont = false;
            XrLabel3.Text = "XrLabel3";
            // 
            // XrLabel1
            // 
            XrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "Service_Log.ServiceVendor_ID") });
            XrLabel1.Dpi = 100.0f;
            XrLabel1.Font = new Font("Times New Roman", 7.0f);
            XrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(656.2916f, 45.7916f);
            XrLabel1.Name = "XrLabel1";
            XrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel1.SizeF = new SizeF(32.70825f, 23.0f);
            XrLabel1.StylePriority.UseFont = false;
            XrLabel1.Text = "XrLabel1";
            // 
            // XrLine1
            // 
            XrLine1.Dpi = 100.0f;
            XrLine1.LocationFloat = new DevExpress.Utils.PointFloat(1.041698f, 54.33337f);
            XrLine1.Name = "XrLine1";
            XrLine1.SizeF = new SizeF(685.8749f, 7.291664f);
            // 
            // GroupFooter1
            // 
            GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel7, XrLine2 });
            GroupFooter1.Dpi = 100.0f;
            GroupFooter1.HeightF = 54.16667f;
            GroupFooter1.Level = 1;
            GroupFooter1.Name = "GroupFooter1";
            // 
            // XrLabel7
            // 
            XrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "Service_Log.EPC_Nr") });
            XrLabel7.Dpi = 100.0f;
            XrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(250.0f, 12.5f);
            XrLabel7.Name = "XrLabel7";
            XrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel7.SizeF = new SizeF(178.4314f, 23.0f);
            XrSummary1.FormatString = "Number of Service Items : {0}";
            XrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.Count;
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            XrLabel7.Summary = XrSummary1;
            XrLabel7.Text = "XrLabel7";
            // 
            // XrLine2
            // 
            XrLine2.Dpi = 100.0f;
            XrLine2.LocationFloat = new DevExpress.Utils.PointFloat(2.083365f, 0f);
            XrLine2.Name = "XrLine2";
            XrLine2.SizeF = new SizeF(686.9166f, 2.083333f);
            // 
            // ReportHeader
            // 
            ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel9 });
            ReportHeader.Dpi = 100.0f;
            ReportHeader.HeightF = 100.0f;
            ReportHeader.Name = "ReportHeader";
            // 
            // XrLabel9
            // 
            XrLabel9.Dpi = 100.0f;
            XrLabel9.Font = new Font("Times New Roman", 24.0f, FontStyle.Bold);
            XrLabel9.ForeColor = Color.Teal;
            XrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(0f, 38.49999f);
            XrLabel9.Name = "XrLabel9";
            XrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel9.SizeF = new SizeF(689.0f, 38.625f);
            XrLabel9.StylePriority.UseFont = false;
            XrLabel9.StylePriority.UseForeColor = false;
            XrLabel9.StylePriority.UseTextAlignment = false;
            XrLabel9.Text = "Report for Instruments from Service";
            XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // GroupHeader3
            // 
            GroupHeader3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel12, XrLabel4, XrLine1 });
            GroupHeader3.Dpi = 100.0f;
            GroupHeader3.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] { new DevExpress.XtraReports.UI.GroupField("EPC_Nr", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending) });
            GroupHeader3.HeightF = 79.16666f;
            GroupHeader3.Name = "GroupHeader3";
            // 
            // XrLabel12
            // 
            XrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "Service_Log.EPC_Nr", "EPC_Nr : {0}") });
            XrLabel12.Dpi = 100.0f;
            XrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(2.083365f, 0f);
            XrLabel12.Name = "XrLabel12";
            XrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel12.SizeF = new SizeF(683.7914f, 23.0f);
            XrLabel12.StylePriority.UseTextAlignment = false;
            XrLabel12.Text = "XrLabel12";
            XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XrLine3
            // 
            XrLine3.Dpi = 100.0f;
            XrLine3.LocationFloat = new DevExpress.Utils.PointFloat(0f, 68.79158f);
            XrLine3.Name = "XrLine3";
            XrLine3.SizeF = new SizeF(685.8749f, 7.291664f);
            // 
            // XtraReportServiceLog
            // 
            Bands.AddRange(new DevExpress.XtraReports.UI.Band[] { Detail, TopMargin, BottomMargin, GroupHeader1, GroupHeader2, GroupFooter1, ReportHeader, GroupHeader3 });
            DataAdapter = Service_LogTableAdapter;
            DataMember = "Service_Log";
            DataSource = Caretag_SurgicalDataSet11;
            Margins = new System.Drawing.Printing.Margins(100, 61, 100, 100);
            Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)Caretag_SurgicalDataSet11).EndInit();
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
        }

        internal DevExpress.XtraReports.UI.DetailBand Detail;
        internal DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        internal DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        internal Caretag_SurgicalDataSet1 Caretag_SurgicalDataSet11;
        internal DataSets.Caretag_SurgicalDataSet1TableAdapters.Service_LogTableAdapter Service_LogTableAdapter;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel5;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel4;
        internal DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel2;
        internal DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader2;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel3;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel6;
        internal DevExpress.XtraReports.UI.XRLine XrLine1;
        internal DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        internal DevExpress.XtraReports.UI.XRLine XrLine2;
        internal DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel9;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo3;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo2;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel10;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel7;
        internal DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader3;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel12;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel8;
        internal DevExpress.XtraReports.UI.XRLine XrLine3;
    }
}