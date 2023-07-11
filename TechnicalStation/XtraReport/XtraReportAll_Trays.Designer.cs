using System.Data;
using System.Diagnostics;
using System.Drawing;
using Microsoft.VisualBasic.CompilerServices;
using TechnicalStation.DataSets;

namespace TechnicalStation
{
    [DesignerGenerated()]
    public partial class XtraReportAll_Trays : DevExpress.XtraReports.UI.XtraReport
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
            components = new System.ComponentModel.Container();
            var XrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            var CustomSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraReportAll_Trays));
            Detail = new DevExpress.XtraReports.UI.DetailBand();
            XrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            XrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            XrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            XrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            XrLine3 = new DevExpress.XtraReports.UI.XRLine();
            XrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            XrLine1 = new DevExpress.XtraReports.UI.XRLine();
            GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            XrLine2 = new DevExpress.XtraReports.UI.XRLine();
            XrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            SqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(components);
            DataSet11 = new DataSet_Tray();
            View_Trays_In_DatabaseTableAdapter = new DataSets.DataSet_TrayTableAdapters.Trays_In_DatabaseTableAdapter();
            XrPageInfo3 = new DevExpress.XtraReports.UI.XRPageInfo();
            ((System.ComponentModel.ISupportInitialize)DataSet11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            // 
            // Detail
            // 
            Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel13, XrLabel12, XrLabel14 });
            Detail.Dpi = 254.0f;
            Detail.HeightF = 58.42f;
            Detail.Name = "Detail";
            Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254.0f);
            Detail.SortFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] { new DevExpress.XtraReports.UI.GroupField("Tray_LastSeen_Date", DevExpress.XtraReports.UI.XRColumnSortOrder.Descending) });
            Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // XrLabel13
            // 
            XrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "View_Trays_In_Database.Tray_LastSeen_Place") });
            XrLabel13.Dpi = 254.0f;
            XrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(1147.869f, 0f);
            XrLabel13.Name = "XrLabel13";
            XrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel13.SizeF = new SizeF(712.152f, 58.42f);
            XrLabel13.StylePriority.UseTextAlignment = false;
            XrLabel13.Text = "XrLabel13";
            XrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XrLabel12
            // 
            XrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "View_Trays_In_Database.Tray_LastSeen_Date", "{0:yyyy MMM dd H:mm:ss}") });
            XrLabel12.Dpi = 254.0f;
            XrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(695.8547f, 0f);
            XrLabel12.Name = "XrLabel12";
            XrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel12.SizeF = new SizeF(418.0417f, 58.42f);
            XrLabel12.StylePriority.UseTextAlignment = false;
            XrLabel12.Text = "XrLabel12";
            XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XrLabel14
            // 
            XrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "View_Trays_In_Database.EPC_Nr") });
            XrLabel14.Dpi = 254.0f;
            XrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(0f, 0f);
            XrLabel14.Name = "XrLabel14";
            XrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel14.SizeF = new SizeF(645.5833f, 58.42f);
            XrLabel14.StylePriority.UseTextAlignment = false;
            XrLabel14.Text = "XrLabel14";
            XrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TopMargin
            // 
            TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrPageInfo3, XrPageInfo2, XrLabel1 });
            TopMargin.Dpi = 254.0f;
            TopMargin.HeightF = 602.0f;
            TopMargin.Name = "TopMargin";
            TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254.0f);
            TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // XrPageInfo2
            // 
            XrPageInfo2.Dpi = 254.0f;
            XrPageInfo2.Format = "{0:yyyy MMM dd H:mm:ss}";
            XrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(0f, 81.91505f);
            XrPageInfo2.Name = "XrPageInfo2";
            XrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            XrPageInfo2.SizeF = new SizeF(370.4169f, 58.41998f);
            XrPageInfo2.StylePriority.UseTextAlignment = false;
            XrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XrLabel1
            // 
            XrLabel1.Dpi = 254.0f;
            XrLabel1.Font = new Font("Times New Roman", 26.25f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            XrLabel1.ForeColor = Color.Teal;
            XrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(7.937741f, 312.1025f);
            XrLabel1.Name = "XrLabel1";
            XrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel1.SizeF = new SizeF(1845.31f, 96.41418f);
            XrLabel1.StylePriority.UseFont = false;
            XrLabel1.StylePriority.UseForeColor = false;
            XrLabel1.StylePriority.UseTextAlignment = false;
            XrLabel1.Text = "Overview for All Tray's in Database";
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
            XrPageInfo1.Format = "Pages {0} of {1}";
            XrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(1613.958f, 68.79166f);
            XrPageInfo1.Name = "XrPageInfo1";
            XrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrPageInfo1.SizeF = new SizeF(254.0f, 58.42f);
            XrPageInfo1.StylePriority.UseTextAlignment = false;
            XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XrLine3
            // 
            XrLine3.Dpi = 254.0f;
            XrLine3.LineWidth = 3f;
            XrLine3.LocationFloat = new DevExpress.Utils.PointFloat(0f, 0f);
            XrLine3.Name = "XrLine3";
            XrLine3.SizeF = new SizeF(1860.021f, 5.079987f);
            // 
            // XrLabel11
            // 
            XrLabel11.Dpi = 254.0f;
            XrLabel11.Font = new Font("Times New Roman", 12.0f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            XrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(1147.785f, 6.690968f);
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
            XrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(695.771f, 6.690968f);
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
            XrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(0f, 6.690968f);
            XrLabel9.Name = "XrLabel9";
            XrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel9.SizeF = new SizeF(254.0f, 47.83664f);
            XrLabel9.StylePriority.UseFont = false;
            XrLabel9.Text = "EPC_Nr";
            // 
            // XrLine1
            // 
            XrLine1.Dpi = 254.0f;
            XrLine1.LineWidth = 3f;
            XrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0f, 54.52752f);
            XrLine1.Name = "XrLine1";
            XrLine1.SizeF = new SizeF(1860.021f, 5.079987f);
            // 
            // GroupHeader2
            // 
            GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLine1, XrLabel9, XrLabel10, XrLabel11, XrLine3 });
            GroupHeader2.Dpi = 254.0f;
            GroupHeader2.HeightF = 59.60751f;
            GroupHeader2.Name = "GroupHeader2";
            // 
            // GroupFooter2
            // 
            GroupFooter2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLine2, XrLabel3, XrLabel4 });
            GroupFooter2.Dpi = 254.0f;
            GroupFooter2.HeightF = 130.0f;
            GroupFooter2.Level = 1;
            GroupFooter2.Name = "GroupFooter2";
            // 
            // XrLine2
            // 
            XrLine2.Dpi = 254.0f;
            XrLine2.LineWidth = 3f;
            XrLine2.LocationFloat = new DevExpress.Utils.PointFloat(0f, 87.3125f);
            XrLine2.Name = "XrLine2";
            XrLine2.SizeF = new SizeF(1867.958f, 5.080002f);
            // 
            // XrLabel3
            // 
            XrLabel3.Dpi = 254.0f;
            XrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(383.6458f, 26.03507f);
            XrLabel3.Name = "XrLabel3";
            XrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel3.SizeF = new SizeF(650.8751f, 58.42f);
            XrLabel3.StylePriority.UseTextAlignment = false;
            XrLabel3.Text = "Total Number of TRAY's with  RFID: ";
            XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // XrLabel4
            // 
            XrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "View_Trays_In_Database.EPC_Nr") });
            XrLabel4.Dpi = 254.0f;
            XrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(1034.521f, 26.03507f);
            XrLabel4.Name = "XrLabel4";
            XrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel4.SizeF = new SizeF(254.0f, 58.42f);
            XrLabel4.StylePriority.UseTextAlignment = false;
            XrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.DCount;
            XrSummary1.IgnoreNullValues = true;
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            XrLabel4.Summary = XrSummary1;
            XrLabel4.Text = "XrLabel4";
            XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // SqlDataSource1
            // 
            SqlDataSource1.ConnectionName = "TechnicalStation.Settings.Caretag_SurgicalConnectionStringSQL";
            SqlDataSource1.Name = "SqlDataSource1";
            CustomSqlQuery1.Name = "Query";
            CustomSqlQuery1.Sql = "SELECT        EPC_Nr, Tray_Name, Tray_LastSeen_Place, Tray_LastSeen_Date, Tray_De" + "scription, Tray_Lock, Date_Changed, Description_ID" + '\r' + '\n' + "FROM            View_Trays_A" + "LL_Report";
            SqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] { CustomSqlQuery1 });
            SqlDataSource1.ResultSchemaSerializable = resources.GetString("SqlDataSource1.ResultSchemaSerializable");
            // 
            // DataSet11
            // 
            DataSet11.DataSetName = "DataSet1";
            DataSet11.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            // 
            // View_Trays_In_DatabaseTableAdapter
            // 
            View_Trays_In_DatabaseTableAdapter.ClearBeforeFill = true;
            // 
            // XrPageInfo3
            // 
            XrPageInfo3.Dpi = 254.0f;
            XrPageInfo3.Format = "{0:yyyy MMM dd H:mm:ss}";
            XrPageInfo3.LocationFloat = new DevExpress.Utils.PointFloat(968.3743f, 81.91505f);
            XrPageInfo3.Name = "XrPageInfo3";
            XrPageInfo3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrPageInfo3.PageInfo = DevExpress.XtraPrinting.PageInfo.UserName;
            XrPageInfo3.SizeF = new SizeF(899.5836f, 58.41998f);
            XrPageInfo3.StylePriority.UseTextAlignment = false;
            XrPageInfo3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // XtraReportAll_Trays
            // 
            Bands.AddRange(new DevExpress.XtraReports.UI.Band[] { Detail, TopMargin, BottomMargin, GroupHeader2, GroupFooter2 });
            Bookmark = "Table of Contents";
            BorderColor = Color.BlanchedAlmond;
            ComponentStorage.AddRange(new System.ComponentModel.IComponent[] { SqlDataSource1 });
            DataAdapter = View_Trays_In_DatabaseTableAdapter;
            DataMember = "Trays_In_Database";
            DataSource = DataSet11;
            Dpi = 254.0f;
            Margins = new System.Drawing.Printing.Margins(132, 91, 602, 254);
            PageHeight = 2970;
            PageWidth = 2100;
            PaperKind = System.Drawing.Printing.PaperKind.A4;
            ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            SnapGridSize = 31.75f;
            Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)DataSet11).EndInit();
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
        }

        internal DevExpress.XtraReports.UI.DetailBand Detail;
        internal DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        internal DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        // Friend WithEvents DataSet11 As Tray_TechnicalStation.DataSet1
        // Friend WithEvents View_Trays_In_DatabaseTableAdapter As Tray_TechnicalStation.DataSet1TableAdapters.View_Trays_In_DatabaseTableAdapter
        internal DevExpress.XtraReports.UI.XRLabel XrLabel1;
        internal DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader2;
        internal DevExpress.XtraReports.UI.GroupFooterBand GroupFooter2;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel4;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel3;
        internal DevExpress.XtraReports.UI.XRLine XrLine1;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo2;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel10;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel9;
        internal DevExpress.XtraReports.UI.XRLine XrLine2;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel11;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel12;
        internal DevExpress.XtraReports.UI.XRLine XrLine3;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel14;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel13;
        internal DevExpress.DataAccess.Sql.SqlDataSource SqlDataSource1;
        internal DataSet_Tray DataSet11;
        internal DataSets.DataSet_TrayTableAdapters.Trays_In_DatabaseTableAdapter View_Trays_In_DatabaseTableAdapter;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo3;
    }
}