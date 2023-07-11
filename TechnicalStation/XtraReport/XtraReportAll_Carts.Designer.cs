using System.Data;
using System.Diagnostics;
using System.Drawing;
using Microsoft.VisualBasic.CompilerServices;
using TechnicalStation.DataSets;

namespace TechnicalStation
{
    [DesignerGenerated()]
    public partial class XtraReportAll_Carts : DevExpress.XtraReports.UI.XtraReport
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
            var CustomSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraReportAll_Carts));
            var XrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            Detail = new DevExpress.XtraReports.UI.DetailBand();
            XrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            XrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            XrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            XrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            XrLine3 = new DevExpress.XtraReports.UI.XRLine();
            XrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            XrLine1 = new DevExpress.XtraReports.UI.XRLine();
            // Me.Caretag_SurgicalDataSet11 = New TechnicalStation.Caretag_SurgicalDataSet1()
            // Me.View_Containers_In_DatabaseTableAdapter = New TechnicalStation.Caretag_SurgicalDataSet1TableAdapters.View_Containers_In_DatabaseTableAdapter()
            // Me.Caretag_SurgicalDataSet12 = New TechnicalStation.Caretag_SurgicalDataSet1()
            // Me.Caretag_SurgicalDataSet13 = New TechnicalStation.Caretag_SurgicalDataSet1()
            SqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(components);
            DataSet_Carts1 = new DataSet_Carts();
            ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            XrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            DataSet_Carts2 = new DataSet_Carts();
            Carts_In_DatabaseTableAdapter = new DataSets.DataSet_CartsTableAdapters.Carts_In_DatabaseTableAdapter();
            XrPageInfo3 = new DevExpress.XtraReports.UI.XRPageInfo();
            // CType(Me.Caretag_SurgicalDataSet11, System.ComponentModel.ISupportInitialize).BeginInit()
            // CType(Me.Caretag_SurgicalDataSet12, System.ComponentModel.ISupportInitialize).BeginInit()
            // CType(Me.Caretag_SurgicalDataSet13, System.ComponentModel.ISupportInitialize).BeginInit()
            ((System.ComponentModel.ISupportInitialize)DataSet_Carts1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DataSet_Carts2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            // 
            // Detail
            // 
            Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel14, XrLabel12, XrLabel13 });
            Detail.Dpi = 254.0f;
            Detail.HeightF = 63.5f;
            Detail.Name = "Detail";
            Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254.0f);
            Detail.SortFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] { new DevExpress.XtraReports.UI.GroupField("Cart_LastSeen_Date", DevExpress.XtraReports.UI.XRColumnSortOrder.Descending) });
            Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // XrLabel14
            // 
            XrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "View_Carts_In_Database.EPC_Nr") });
            XrLabel14.Dpi = 254.0f;
            XrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(2.781403f, 0f);
            XrLabel14.Name = "XrLabel14";
            XrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel14.SizeF = new SizeF(645.5833f, 58.42f);
            XrLabel14.StylePriority.UseTextAlignment = false;
            XrLabel14.Text = "XrLabel14";
            XrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XrLabel12
            // 
            XrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "View_Carts_In_Database.Cart_LastSeen_Date", "{0:yyyy MMM dd H:mm:ss}") });
            XrLabel12.Dpi = 254.0f;
            XrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(700.0941f, 0f);
            XrLabel12.Name = "XrLabel12";
            XrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel12.SizeF = new SizeF(418.0417f, 58.42f);
            XrLabel12.StylePriority.UseTextAlignment = false;
            XrLabel12.Text = "XrLabel12";
            XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XrLabel13
            // 
            XrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "View_Carts_In_Database.Cart_LastSeen_Place") });
            XrLabel13.Dpi = 254.0f;
            XrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(1133.158f, 0f);
            XrLabel13.Name = "XrLabel13";
            XrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel13.SizeF = new SizeF(712.152f, 58.42f);
            XrLabel13.StylePriority.UseTextAlignment = false;
            XrLabel13.Text = "XrLabel13";
            XrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TopMargin
            // 
            TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrPageInfo3, XrPageInfo1, XrLabel1 });
            TopMargin.Dpi = 254.0f;
            TopMargin.HeightF = 503.0f;
            TopMargin.Name = "TopMargin";
            TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254.0f);
            TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // XrPageInfo1
            // 
            XrPageInfo1.Dpi = 254.0f;
            XrPageInfo1.Format = "{0:yyyy MMM dd H:mm:ss}";
            XrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(13.22917f, 52.81085f);
            XrPageInfo1.Name = "XrPageInfo1";
            XrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            XrPageInfo1.SizeF = new SizeF(436.5625f, 58.41999f);
            XrPageInfo1.StylePriority.UseTextAlignment = false;
            XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XrLabel1
            // 
            XrLabel1.Dpi = 254.0f;
            XrLabel1.Font = new Font("Times New Roman", 26.25f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            XrLabel1.ForeColor = Color.Teal;
            XrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0f, 243.4167f);
            XrLabel1.Name = "XrLabel1";
            XrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel1.SizeF = new SizeF(1845.31f, 96.41418f);
            XrLabel1.StylePriority.UseFont = false;
            XrLabel1.StylePriority.UseForeColor = false;
            XrLabel1.StylePriority.UseTextAlignment = false;
            XrLabel1.Text = "Overview for All Cart's in Database";
            XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
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
            XrPageInfo2.Format = "Page {0} of  {1}";
            XrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(1608.938f, 95.25f);
            XrPageInfo2.Name = "XrPageInfo2";
            XrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrPageInfo2.SizeF = new SizeF(254.0f, 58.42f);
            XrPageInfo2.StylePriority.UseTextAlignment = false;
            XrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // GroupHeader1
            // 
            GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLine3, XrLabel9, XrLabel10, XrLabel11, XrLine1 });
            GroupHeader1.Dpi = 254.0f;
            GroupHeader1.HeightF = 63.5f;
            GroupHeader1.Name = "GroupHeader1";
            // 
            // XrLine3
            // 
            XrLine3.Dpi = 254.0f;
            XrLine3.LineWidth = 3f;
            XrLine3.LocationFloat = new DevExpress.Utils.PointFloat(2.916731f, 0f);
            XrLine3.Name = "XrLine3";
            XrLine3.SizeF = new SizeF(1860.021f, 5.079987f);
            // 
            // XrLabel9
            // 
            XrLabel9.Dpi = 254.0f;
            XrLabel9.Font = new Font("Times New Roman", 12.0f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            XrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(5.562807f, 5.821027f);
            XrLabel9.Name = "XrLabel9";
            XrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel9.SizeF = new SizeF(254.0f, 47.83664f);
            XrLabel9.StylePriority.UseFont = false;
            XrLabel9.Text = "EPC_Nr";
            // 
            // XrLabel10
            // 
            XrLabel10.Dpi = 254.0f;
            XrLabel10.Font = new Font("Times New Roman", 12.0f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            XrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(701.4171f, 5.821027f);
            XrLabel10.Name = "XrLabel10";
            XrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel10.SizeF = new SizeF(367.771f, 47.83664f);
            XrLabel10.StylePriority.UseFont = false;
            XrLabel10.Text = "Last Seen Date";
            // 
            // XrLabel11
            // 
            XrLabel11.Dpi = 254.0f;
            XrLabel11.Font = new Font("Times New Roman", 12.0f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            XrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(1135.939f, 5.821027f);
            XrLabel11.Name = "XrLabel11";
            XrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrLabel11.SizeF = new SizeF(367.771f, 47.83664f);
            XrLabel11.StylePriority.UseFont = false;
            XrLabel11.Text = "Last Seen Place";
            // 
            // XrLine1
            // 
            XrLine1.Dpi = 254.0f;
            XrLine1.LineWidth = 3f;
            XrLine1.LocationFloat = new DevExpress.Utils.PointFloat(2.781403f, 53.65758f);
            XrLine1.Name = "XrLine1";
            XrLine1.SizeF = new SizeF(1860.021f, 5.079987f);
            // 
            // Caretag_SurgicalDataSet11
            // 
            // Me.Caretag_SurgicalDataSet11.DataSetName = "Caretag_SurgicalDataSet1"
            // Me.Caretag_SurgicalDataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            // '
            // 'View_Containers_In_DatabaseTableAdapter
            // '
            // Me.View_Containers_In_DatabaseTableAdapter.ClearBeforeFill = True
            // '
            // 'Caretag_SurgicalDataSet12
            // '
            // Me.Caretag_SurgicalDataSet12.DataSetName = "Caretag_SurgicalDataSet1"
            // Me.Caretag_SurgicalDataSet12.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            // '
            // 'Caretag_SurgicalDataSet13
            // '
            // Me.Caretag_SurgicalDataSet13.DataSetName = "Caretag_SurgicalDataSet1"
            // Me.Caretag_SurgicalDataSet13.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            // 
            // SqlDataSource1
            // 
            SqlDataSource1.ConnectionName = "TechnicalStation.Settings.Caretag_SurgicalConnectionStringSQL";
            SqlDataSource1.Name = "SqlDataSource1";
            CustomSqlQuery1.Name = "Query";
            CustomSqlQuery1.Sql = resources.GetString("CustomSqlQuery1.Sql");
            SqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] { CustomSqlQuery1 });
            SqlDataSource1.ResultSchemaSerializable = resources.GetString("SqlDataSource1.ResultSchemaSerializable");
            // 
            // DataSet_Carts1
            // 
            DataSet_Carts1.DataSetName = "DataSet_Carts";
            DataSet_Carts1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            // 
            // ReportFooter
            // 
            ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel3, XrLabel4 });
            ReportFooter.Dpi = 254.0f;
            ReportFooter.HeightF = 254.0f;
            ReportFooter.Name = "ReportFooter";
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
            // DataSet_Carts2
            // 
            DataSet_Carts2.DataSetName = "DataSet_Carts";
            DataSet_Carts2.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            // 
            // Carts_In_DatabaseTableAdapter
            // 
            Carts_In_DatabaseTableAdapter.ClearBeforeFill = true;
            // 
            // XrPageInfo3
            // 
            XrPageInfo3.Dpi = 254.0f;
            XrPageInfo3.Format = "{0:yyyy MMM dd H:mm:ss}";
            XrPageInfo3.LocationFloat = new DevExpress.Utils.PointFloat(1417.437f, 52.81085f);
            XrPageInfo3.Name = "XrPageInfo3";
            XrPageInfo3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0f);
            XrPageInfo3.PageInfo = DevExpress.XtraPrinting.PageInfo.UserName;
            XrPageInfo3.SizeF = new SizeF(436.5625f, 58.41999f);
            XrPageInfo3.StylePriority.UseTextAlignment = false;
            XrPageInfo3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // XtraReportAll_Carts
            // 
            Bands.AddRange(new DevExpress.XtraReports.UI.Band[] { Detail, TopMargin, BottomMargin, GroupHeader1, ReportFooter });
            ComponentStorage.AddRange(new System.ComponentModel.IComponent[] { SqlDataSource1 });
            DataAdapter = Carts_In_DatabaseTableAdapter;
            DataMember = "Carts_In_Database";
            DataSource = DataSet_Carts2;
            Dpi = 254.0f;
            Margins = new System.Drawing.Printing.Margins(132, 148, 503, 254);
            PageHeight = 2794;
            PageWidth = 2159;
            ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic;
            SnapGridSize = 31.75f;
            Version = "16.1";
            // CType(Me.Caretag_SurgicalDataSet11, System.ComponentModel.ISupportInitialize).EndInit()
            // CType(Me.Caretag_SurgicalDataSet12, System.ComponentModel.ISupportInitialize).EndInit()
            // CType(Me.Caretag_SurgicalDataSet13, System.ComponentModel.ISupportInitialize).EndInit()
            ((System.ComponentModel.ISupportInitialize)DataSet_Carts1).EndInit();
            ((System.ComponentModel.ISupportInitialize)DataSet_Carts2).EndInit();
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
        }

        internal DevExpress.XtraReports.UI.DetailBand Detail;
        internal DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        internal DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        // Friend WithEvents Caretag_SurgicalDataSet1 As Caretag_SurgicalDataSet
        // Friend WithEvents View_Carts_In_DatabaseTableAdapter As Caretag_SurgicalDataSetTableAdapters.View_Carts_In_DatabaseTableAdapter
        internal DevExpress.XtraReports.UI.XRLabel XrLabel1;
        internal DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        internal DevExpress.XtraReports.UI.XRLine XrLine3;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel9;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel10;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel11;
        internal DevExpress.XtraReports.UI.XRLine XrLine1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel14;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel12;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel13;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo1;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo2;
        // Friend WithEvents Caretag_SurgicalDataSet11 As Caretag_SurgicalDataSet1
        // Friend WithEvents View_Containers_In_DatabaseTableAdapter As Caretag_SurgicalDataSet1TableAdapters.View_Containers_In_DatabaseTableAdapter
        // Friend WithEvents Caretag_SurgicalDataSet12 As Caretag_SurgicalDataSet1
        // Friend WithEvents Caretag_SurgicalDataSet13 As Caretag_SurgicalDataSet1
        internal DevExpress.DataAccess.Sql.SqlDataSource SqlDataSource1;
        internal DataSet_Carts DataSet_Carts1;
        internal DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel3;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel4;
        internal DataSet_Carts DataSet_Carts2;
        internal DataSets.DataSet_CartsTableAdapters.Carts_In_DatabaseTableAdapter Carts_In_DatabaseTableAdapter;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo3;
    }
}