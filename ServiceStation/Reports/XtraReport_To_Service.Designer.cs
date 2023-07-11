using System.Diagnostics;
using System.Drawing;
using Microsoft.VisualBasic.CompilerServices;

namespace Service_Station
{
    [DesignerGenerated()]
    public partial class XtraReport_To_Service : DevExpress.XtraReports.UI.XtraReport
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraReport_To_Service));
            TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            XrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            XrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            XrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            Detail = new DevExpress.XtraReports.UI.DetailBand();
            XrLabel_EPC = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel_Sent = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            XrLabel_Filter = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            XrLine1 = new DevExpress.XtraReports.UI.XRLine();
            XrLabel_City = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel_ZIP = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel_Service_Vendor = new DevExpress.XtraReports.UI.XRLabel();
            GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            XrLabel_Sort = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel_Period = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            XrLine2 = new DevExpress.XtraReports.UI.XRLine();
            GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            XrLine4 = new DevExpress.XtraReports.UI.XRLine();
            XrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            XrLine3 = new DevExpress.XtraReports.UI.XRLine();
            XrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            XrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            XrLine5 = new DevExpress.XtraReports.UI.XRLine();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            // 
            // TopMargin
            // 
            TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrPageInfo1, XrPictureBox1 });
            TopMargin.HeightF = 118.625f;
            TopMargin.Name = "TopMargin";
            // 
            // XrPageInfo1
            // 
            XrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(17.875f, 56.25f);
            XrPageInfo1.Name = "XrPageInfo1";
            XrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            XrPageInfo1.SizeF = new SizeF(363.5417f, 23.0f);
            XrPageInfo1.TextFormatString = "{0:dddd, d MMMM yyyy HH.mm}";
            // 
            // XrPictureBox1
            // 
            XrPictureBox1.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("XrPictureBox1.ImageSource"));
            XrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(877.1669f, 28.75001f);
            XrPictureBox1.Name = "XrPictureBox1";
            XrPictureBox1.SizeF = new SizeF(170.8333f, 56.33331f);
            XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            // 
            // BottomMargin
            // 
            BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrPageInfo2 });
            BottomMargin.Name = "BottomMargin";
            // 
            // XrPageInfo2
            // 
            XrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(948.0001f, 27.04169f);
            XrPageInfo2.Name = "XrPageInfo2";
            XrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrPageInfo2.SizeF = new SizeF(100.0f, 23.0f);
            XrPageInfo2.StylePriority.UseTextAlignment = false;
            XrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            XrPageInfo2.TextFormatString = "Pages {0} of {1}";
            // 
            // Detail
            // 
            Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel_EPC, XrLabel_Sent, XrLabel2 });
            Detail.HeightF = 26.16666f;
            Detail.KeepTogether = true;
            Detail.Name = "Detail";
            // 
            // XrLabel_EPC
            // 
            XrLabel_EPC.LocationFloat = new DevExpress.Utils.PointFloat(740.7917f, 0f);
            XrLabel_EPC.Multiline = true;
            XrLabel_EPC.Name = "XrLabel_EPC";
            XrLabel_EPC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel_EPC.SizeF = new SizeF(100.0f, 23.0f);
            XrLabel_EPC.Text = "XrLabel_EPC";
            XrLabel_EPC.Visible = false;
            // 
            // XrLabel_Sent
            // 
            XrLabel_Sent.LocationFloat = new DevExpress.Utils.PointFloat(814.2501f, 0f);
            XrLabel_Sent.Multiline = true;
            XrLabel_Sent.Name = "XrLabel_Sent";
            XrLabel_Sent.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel_Sent.SizeF = new SizeF(243.75f, 23.0f);
            XrLabel_Sent.StylePriority.UseTextAlignment = false;
            XrLabel_Sent.Text = "XrLabel_Sent";
            XrLabel_Sent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XrLabel2
            // 
            XrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0f, 0f);
            XrLabel2.Multiline = true;
            XrLabel2.Name = "XrLabel2";
            XrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel2.SizeF = new SizeF(802.875f, 23.0f);
            XrLabel2.Text = "XrLabel2";
            // 
            // ReportHeader
            // 
            ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel_Filter, XrLabel1 });
            ReportHeader.HeightF = 123.2917f;
            ReportHeader.Name = "ReportHeader";
            // 
            // XrLabel_Filter
            // 
            XrLabel_Filter.Font = new Font("Times New Roman", 21.75f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            XrLabel_Filter.LocationFloat = new DevExpress.Utils.PointFloat(0.0005404155f, 69.91663f);
            XrLabel_Filter.Multiline = true;
            XrLabel_Filter.Name = "XrLabel_Filter";
            XrLabel_Filter.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel_Filter.SizeF = new SizeF(1048.0f, 41.04169f);
            XrLabel_Filter.StylePriority.UseFont = false;
            XrLabel_Filter.StylePriority.UseTextAlignment = false;
            XrLabel_Filter.Text = "XrLabel_Filter";
            XrLabel_Filter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XrLabel1
            // 
            XrLabel1.Font = new Font("Times New Roman", 27.75f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            XrLabel1.ForeColor = Color.OliveDrab;
            XrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0.0005404155f, 10.00001f);
            XrLabel1.Name = "XrLabel1";
            XrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel1.SizeF = new SizeF(1048.0f, 48.00001f);
            XrLabel1.StylePriority.UseFont = false;
            XrLabel1.StylePriority.UseForeColor = false;
            XrLabel1.StylePriority.UseTextAlignment = false;
            XrLabel1.Text = "Instruments To Service";
            XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // GroupHeader1
            // 
            GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLine1, XrLabel_City, XrLabel_ZIP, XrLabel_Service_Vendor });
            GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] { new DevExpress.XtraReports.UI.GroupField("Vendor_Name", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending) });
            GroupHeader1.HeightF = 106.9166f;
            GroupHeader1.KeepTogether = true;
            GroupHeader1.Level = 1;
            GroupHeader1.Name = "GroupHeader1";
            // 
            // XrLine1
            // 
            XrLine1.LineWidth = 3.0f;
            XrLine1.LocationFloat = new DevExpress.Utils.PointFloat(4.333337f, 91.58328f);
            XrLine1.Name = "XrLine1";
            XrLine1.SizeF = new SizeF(1051.042f, 11.45833f);
            // 
            // XrLabel_City
            // 
            XrLabel_City.Font = new Font("Arial", 14.25f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            XrLabel_City.LocationFloat = new DevExpress.Utils.PointFloat(372.0421f, 52.9583f);
            XrLabel_City.Multiline = true;
            XrLabel_City.Name = "XrLabel_City";
            XrLabel_City.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel_City.SizeF = new SizeF(675.9584f, 38.62498f);
            XrLabel_City.StylePriority.UseFont = false;
            XrLabel_City.StylePriority.UseTextAlignment = false;
            XrLabel_City.Text = "XrLabel_City";
            XrLabel_City.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XrLabel_ZIP
            // 
            XrLabel_ZIP.Font = new Font("Arial", 14.25f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            XrLabel_ZIP.LocationFloat = new DevExpress.Utils.PointFloat(0f, 52.9583f);
            XrLabel_ZIP.Multiline = true;
            XrLabel_ZIP.Name = "XrLabel_ZIP";
            XrLabel_ZIP.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel_ZIP.SizeF = new SizeF(361.4583f, 38.62498f);
            XrLabel_ZIP.StylePriority.UseFont = false;
            XrLabel_ZIP.StylePriority.UseTextAlignment = false;
            XrLabel_ZIP.Text = "XrLabel_ZIP";
            XrLabel_ZIP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XrLabel_Service_Vendor
            // 
            XrLabel_Service_Vendor.Font = new Font("Arial", 15.75f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            XrLabel_Service_Vendor.LocationFloat = new DevExpress.Utils.PointFloat(0f, 0f);
            XrLabel_Service_Vendor.Multiline = true;
            XrLabel_Service_Vendor.Name = "XrLabel_Service_Vendor";
            XrLabel_Service_Vendor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel_Service_Vendor.SizeF = new SizeF(1048.0f, 39.66669f);
            XrLabel_Service_Vendor.StylePriority.UseFont = false;
            XrLabel_Service_Vendor.StylePriority.UseTextAlignment = false;
            XrLabel_Service_Vendor.Text = "XrLabel_Service_Vendor";
            XrLabel_Service_Vendor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // GroupHeader2
            // 
            GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel_Sort, XrLabel_Period, XrLabel4, XrLabel3, XrLine2 });
            GroupHeader2.HeightF = 98.00002f;
            GroupHeader2.KeepTogether = true;
            GroupHeader2.Name = "GroupHeader2";
            // 
            // XrLabel_Sort
            // 
            XrLabel_Sort.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            XrLabel_Sort.LocationFloat = new DevExpress.Utils.PointFloat(4.333337f, 9.999974f);
            XrLabel_Sort.Multiline = true;
            XrLabel_Sort.Name = "XrLabel_Sort";
            XrLabel_Sort.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel_Sort.SizeF = new SizeF(47.91667f, 23.0f);
            XrLabel_Sort.StylePriority.UseFont = false;
            XrLabel_Sort.Text = "XrLabel_Sort";
            XrLabel_Sort.Visible = false;
            // 
            // XrLabel_Period
            // 
            XrLabel_Period.Font = new Font("Arial", 12.0f, FontStyle.Bold);
            XrLabel_Period.LocationFloat = new DevExpress.Utils.PointFloat(52.25f, 9.999974f);
            XrLabel_Period.Multiline = true;
            XrLabel_Period.Name = "XrLabel_Period";
            XrLabel_Period.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel_Period.SizeF = new SizeF(995.7504f, 35.87507f);
            XrLabel_Period.StylePriority.UseFont = false;
            XrLabel_Period.StylePriority.UseTextAlignment = false;
            XrLabel_Period.Text = "XrLabel_Period";
            XrLabel_Period.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XrLabel4
            // 
            XrLabel4.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            XrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(814.2501f, 62.99999f);
            XrLabel4.Multiline = true;
            XrLabel4.Name = "XrLabel4";
            XrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel4.SizeF = new SizeF(233.7501f, 23.00001f);
            XrLabel4.StylePriority.UseFont = false;
            XrLabel4.StylePriority.UseTextAlignment = false;
            XrLabel4.Text = "Sent To Service";
            XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XrLabel3
            // 
            XrLabel3.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            XrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(4.333337f, 62.99998f);
            XrLabel3.Multiline = true;
            XrLabel3.Name = "XrLabel3";
            XrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel3.SizeF = new SizeF(110.0f, 23.0f);
            XrLabel3.StylePriority.UseFont = false;
            XrLabel3.StylePriority.UseTextAlignment = false;
            XrLabel3.Text = "Instrument";
            XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XrLine2
            // 
            XrLine2.LocationFloat = new DevExpress.Utils.PointFloat(0f, 86.0f);
            XrLine2.Name = "XrLine2";
            XrLine2.SizeF = new SizeF(1053.125f, 2.0f);
            // 
            // GroupFooter1
            // 
            GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLine4, XrLabel5 });
            GroupFooter1.HeightF = 51.66664f;
            GroupFooter1.Name = "GroupFooter1";
            // 
            // XrLine4
            // 
            XrLine4.LocationFloat = new DevExpress.Utils.PointFloat(0f, 39.66662f);
            XrLine4.Name = "XrLine4";
            XrLine4.SizeF = new SizeF(1053.125f, 2.0f);
            // 
            // XrLabel5
            // 
            XrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(52.25f, 9.999974f);
            XrLabel5.Multiline = true;
            XrLabel5.Name = "XrLabel5";
            XrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel5.SizeF = new SizeF(938.4588f, 23.0f);
            XrLabel5.StylePriority.UseTextAlignment = false;
            XrLabel5.Text = "XrLabel5";
            XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ReportFooter
            // 
            ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLine3, XrLabel7, XrLabel6 });
            ReportFooter.Name = "ReportFooter";
            // 
            // XrLine3
            // 
            XrLine3.LocationFloat = new DevExpress.Utils.PointFloat(0f, 87.99998f);
            XrLine3.Name = "XrLine3";
            XrLine3.SizeF = new SizeF(1053.125f, 2.0f);
            // 
            // XrLabel7
            // 
            XrLabel7.Font = new Font("Arial", 14.25f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            XrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(52.25f, 9.499995f);
            XrLabel7.Multiline = true;
            XrLabel7.Name = "XrLabel7";
            XrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel7.SizeF = new SizeF(100.0f, 23.0f);
            XrLabel7.StylePriority.UseFont = false;
            XrLabel7.Text = "Report:";
            // 
            // XrLabel6
            // 
            XrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(52.25f, 44.08334f);
            XrLabel6.Multiline = true;
            XrLabel6.Name = "XrLabel6";
            XrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel6.SizeF = new SizeF(938.4588f, 23.0f);
            XrLabel6.Text = "XrLabel6";
            // 
            // GroupFooter2
            // 
            GroupFooter2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLine5, XrLabel8 });
            GroupFooter2.HeightF = 54.37489f;
            GroupFooter2.Level = 1;
            GroupFooter2.Name = "GroupFooter2";
            // 
            // XrLabel8
            // 
            XrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(52.25f, 10.00004f);
            XrLabel8.Multiline = true;
            XrLabel8.Name = "XrLabel8";
            XrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0f);
            XrLabel8.SizeF = new SizeF(938.4588f, 23.0f);
            XrLabel8.StylePriority.UseTextAlignment = false;
            XrLabel8.Text = "XrLabel8";
            XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XrLine5
            // 
            XrLine5.LocationFloat = new DevExpress.Utils.PointFloat(0f, 45.29165f);
            XrLine5.Name = "XrLine5";
            XrLine5.SizeF = new SizeF(1053.125f, 2.0f);
            // 
            // XtraReport_To_Service
            // 
            Bands.AddRange(new DevExpress.XtraReports.UI.Band[] { TopMargin, BottomMargin, Detail, ReportHeader, GroupHeader1, GroupHeader2, GroupFooter1, ReportFooter, GroupFooter2 });
            Font = new Font("Arial", 9.75f);
            Landscape = true;
            Margins = new System.Drawing.Printing.Margins(54, 57, 119, 100);
            PageHeight = 827;
            PageWidth = 1169;
            PaperKind = System.Drawing.Printing.PaperKind.A4;
            Version = "20.1";
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
        }

        internal DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        internal DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        internal DevExpress.XtraReports.UI.DetailBand Detail;
        internal DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel1;
        internal DevExpress.XtraReports.UI.XRPictureBox XrPictureBox1;
        internal DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel_Service_Vendor;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel_Sent;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel2;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel_City;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel_ZIP;
        internal DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader2;
        internal DevExpress.XtraReports.UI.XRLine XrLine1;
        internal DevExpress.XtraReports.UI.XRLine XrLine2;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel4;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel3;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel_EPC;
        internal DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        internal DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel5;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel6;
        internal DevExpress.XtraReports.UI.XRLine XrLine3;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel7;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo1;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo2;
        internal DevExpress.XtraReports.UI.XRLine XrLine4;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel_Sort;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel_Period;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel_Filter;
        internal DevExpress.XtraReports.UI.GroupFooterBand GroupFooter2;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel8;
        internal DevExpress.XtraReports.UI.XRLine XrLine5;
    }
}