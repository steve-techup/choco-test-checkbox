using System.Data;
using System.Diagnostics;
using System.Drawing;
using Microsoft.VisualBasic.CompilerServices;
using TechnicalStation.DataSets;

namespace TechnicalStation
{
    [DesignerGenerated()]
    public partial class XtraReportAll_Containers : DevExpress.XtraReports.UI.XtraReport
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
            XrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            XrPageInfo3 = new DevExpress.XtraReports.UI.XRPageInfo();
            XrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            XrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            XrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            XrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            XrLine3 = new DevExpress.XtraReports.UI.XRLine();
            XrLine1 = new DevExpress.XtraReports.UI.XRLine();
            DataSet_Container1 = new DataSet_Container();
            Containers_RFIDTableAdapter = new DataSets.DataSet_ContainerTableAdapters.Containers_RFIDTableAdapter();
            ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            XrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)DataSet_Container1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            // 
            // Detail
            // 
            Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel14, XrLabel12, XrLabel13 });
            Detail.Dpi = 254.0f;
            Detail.HeightF = 58.42f;
            Detail.Name = "Detail";
            Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254.0f);
            Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // XrLabel14
            // 
            XrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "View_Containers_In_Database.EPC_Nr") });
            XrLabel14.Dpi = 254.0f;
            XrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(3.781423f, 0f);
            XrLabel14.Name = "XrLabel14";
            XrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel14.SizeF = new SizeF(645.5833f, 58.42f);
            XrLabel14.StylePriority.UseTextAlignment = false;
            XrLabel14.Text = "XrLabel14";
            XrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XrLabel12
            // 
            XrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "View_Containers_In_Database.Container_LastSeen_Date", "{0:yyyy MMM dd H:mm:ss}") });
            XrLabel12.Dpi = 254.0f;
            XrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(707.5732f, 0f);
            XrLabel12.Name = "XrLabel12";
            XrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel12.SizeF = new SizeF(418.0417f, 58.42f);
            XrLabel12.StylePriority.UseTextAlignment = false;
            XrLabel12.Text = "XrLabel12";
            XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XrLabel13
            // 
            XrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "View_Containers_In_Database.Container_LastSeen_Place") });
            XrLabel13.Dpi = 254.0f;
            XrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(1159.588f, 0f);
            XrLabel13.Name = "XrLabel13";
            XrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel13.SizeF = new SizeF(712.152f, 58.42f);
            XrLabel13.StylePriority.UseTextAlignment = false;
            XrLabel13.Text = "XrLabel13";
            XrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TopMargin
            // 
            TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrPageInfo3, XrPageInfo2, XrLabel1 });
            TopMargin.Dpi = 254.0f;
            TopMargin.HeightF = 541.0f;
            TopMargin.Name = "TopMargin";
            TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254.0f);
            TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // XrPageInfo3
            // 
            XrPageInfo3.Dpi = 254.0f;
            XrPageInfo3.LocationFloat = new DevExpress.Utils.PointFloat(927.1776f, 100.5417f);
            XrPageInfo3.Name = "XrPageInfo3";
            XrPageInfo3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrPageInfo3.PageInfo = DevExpress.XtraPrinting.PageInfo.UserName;
            XrPageInfo3.SizeF = new SizeF(944.5626f, 58.41999f);
            XrPageInfo3.StylePriority.UseTextAlignment = false;
            XrPageInfo3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            XrPageInfo3.TextFormatString = "{0:yyyy MMM dd H:mm:ss}";
            // 
            // XrPageInfo2
            // 
            XrPageInfo2.Dpi = 254.0f;
            XrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(3.781423f, 97.89584f);
            XrPageInfo2.Name = "XrPageInfo2";
            XrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            XrPageInfo2.SizeF = new SizeF(325.4375f, 58.41999f);
            XrPageInfo2.StylePriority.UseTextAlignment = false;
            XrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            XrPageInfo2.TextFormatString = "{0:yyyy MMM dd H:mm:ss}";
            // 
            // XrLabel1
            // 
            XrLabel1.Dpi = 254.0f;
            XrLabel1.Font = new Font("Times New Roman", 26.25f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            XrLabel1.ForeColor = Color.Teal;
            XrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0f, 283.1042f);
            XrLabel1.Name = "XrLabel1";
            XrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel1.SizeF = new SizeF(1845.31f, 96.41418f);
            XrLabel1.StylePriority.UseFont = false;
            XrLabel1.StylePriority.UseForeColor = false;
            XrLabel1.StylePriority.UseTextAlignment = false;
            XrLabel1.Text = "Overview for All Container's in Database";
            XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // BottomMargin
            // 
            BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrPageInfo1 });
            BottomMargin.Dpi = 254.0f;
            BottomMargin.HeightF = 254.0f;
            BottomMargin.Name = "BottomMargin";
            BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254.0f);
            BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // XrPageInfo1
            // 
            XrPageInfo1.Dpi = 254.0f;
            XrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(1617.74f, 92.60416f);
            XrPageInfo1.Name = "XrPageInfo1";
            XrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrPageInfo1.SizeF = new SizeF(254.0f, 58.42f);
            XrPageInfo1.StylePriority.UseTextAlignment = false;
            XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            XrPageInfo1.TextFormatString = "Pages {0} of {1}";
            // 
            // GroupHeader1
            // 
            GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel11, XrLabel10, XrLabel9, XrLine3, XrLine1 });
            GroupHeader1.Dpi = 254.0f;
            GroupHeader1.HeightF = 76.72916f;
            GroupHeader1.Name = "GroupHeader1";
            // 
            // XrLabel11
            // 
            XrLabel11.Dpi = 254.0f;
            XrLabel11.Font = new Font("Times New Roman", 12.0f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            XrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(1163.369f, 12.43561f);
            XrLabel11.Name = "XrLabel11";
            XrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel11.SizeF = new SizeF(367.771f, 47.83664f);
            XrLabel11.StylePriority.UseFont = false;
            XrLabel11.Text = "Last Seen Place";
            // 
            // XrLabel10
            // 
            XrLabel10.Dpi = 254.0f;
            XrLabel10.Font = new Font("Times New Roman", 12.0f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            XrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(711.3545f, 12.43561f);
            XrLabel10.Name = "XrLabel10";
            XrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel10.SizeF = new SizeF(367.771f, 47.83664f);
            XrLabel10.StylePriority.UseFont = false;
            XrLabel10.Text = "Last Seen Date";
            // 
            // XrLabel9
            // 
            XrLabel9.Dpi = 254.0f;
            XrLabel9.Font = new Font("Times New Roman", 12.0f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            XrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(15.50043f, 12.43561f);
            XrLabel9.Name = "XrLabel9";
            XrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel9.SizeF = new SizeF(254.0f, 47.83664f);
            XrLabel9.StylePriority.UseFont = false;
            XrLabel9.Text = "EPC_Nr";
            // 
            // XrLine3
            // 
            XrLine3.Dpi = 254.0f;
            XrLine3.LocationFloat = new DevExpress.Utils.PointFloat(12.85435f, 4.709661f);
            XrLine3.Name = "XrLine3";
            XrLine3.SizeF = new SizeF(1860.021f, 5.079987f);
            // 
            // XrLine1
            // 
            XrLine1.Dpi = 254.0f;
            XrLine1.LocationFloat = new DevExpress.Utils.PointFloat(11.719f, 60.27216f);
            XrLine1.Name = "XrLine1";
            XrLine1.SizeF = new SizeF(1860.021f, 5.079987f);
            // 
            // DataSet_Container1
            // 
            DataSet_Container1.DataSetName = "DataSet_Container";
            DataSet_Container1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            // 
            // Containers_RFIDTableAdapter
            // 
            Containers_RFIDTableAdapter.ClearBeforeFill = true;
            // 
            // ReportFooter
            // 
            ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel4, XrLabel3 });
            ReportFooter.Dpi = 254.0f;
            ReportFooter.HeightF = 254.0f;
            ReportFooter.Name = "ReportFooter";
            // 
            // XrLabel4
            // 
            XrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "View_Carts_In_Database.EPC_Nr") });
            XrLabel4.Dpi = 254.0f;
            XrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(1137.938f, 97.79f);
            XrLabel4.Name = "XrLabel4";
            XrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel4.SizeF = new SizeF(254.0f, 58.42f);
            XrLabel4.StylePriority.UseTextAlignment = false;
            XrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.DCount;
            XrSummary1.IgnoreNullValues = true;
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            XrLabel4.Summary = XrSummary1;
            XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XrLabel3
            // 
            XrLabel3.Dpi = 254.0f;
            XrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(487.0624f, 97.79f);
            XrLabel3.Name = "XrLabel3";
            XrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel3.SizeF = new SizeF(650.8751f, 58.42f);
            XrLabel3.StylePriority.UseTextAlignment = false;
            XrLabel3.Text = "Total Number of CART's with  RFID: ";
            XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // XtraReportAll_Containers
            // 
            Bands.AddRange(new DevExpress.XtraReports.UI.Band[] { Detail, TopMargin, BottomMargin, GroupHeader1, ReportFooter });
            DataAdapter = Containers_RFIDTableAdapter;
            DataMember = "Containers_RFID";
            DataSource = DataSet_Container1;
            Dpi = 254.0f;
            Margins = new System.Drawing.Printing.Margins(137, 142, 541, 254);
            PageHeight = 2794;
            PageWidth = 2159;
            ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic;
            SnapGridSize = 31.75f;
            Version = "20.1";
            ((System.ComponentModel.ISupportInitialize)DataSet_Container1).EndInit();
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
        }

        internal DevExpress.XtraReports.UI.DetailBand Detail;
        internal DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        internal DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel1;
        internal DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel11;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel10;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel9;
        internal DevExpress.XtraReports.UI.XRLine XrLine3;
        internal DevExpress.XtraReports.UI.XRLine XrLine1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel14;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel12;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel13;
        // Friend WithEvents Caretag_SurgicalDataSet11 As Caretag_SurgicalDataSet1
        // Friend WithEvents View_Containers_In_DatabaseTableAdapter As Caretag_SurgicalDataSet1.View_Containers_In_DatabaseDataTable
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo1;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo2;
        internal DataSet_Container DataSet_Container1;
        internal DataSets.DataSet_ContainerTableAdapters.Containers_RFIDTableAdapter Containers_RFIDTableAdapter;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo3;
        internal DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel4;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel3;
    }
}