using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;
using PackingStation.DataSets;

namespace PackingStation
{
    [DesignerGenerated()]
    public partial class XtraReport_PackList : DevExpress.XtraReports.UI.XtraReport
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraReport_PackList));
            var XrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            var XrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            Detail = new DevExpress.XtraReports.UI.DetailBand();
            XrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            GroupHeaderBand2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            XrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            XrLine1 = new DevExpress.XtraReports.UI.XRLine();
            XrLine2 = new DevExpress.XtraReports.UI.XRLine();
            PageFooterBand1 = new DevExpress.XtraReports.UI.PageFooterBand();
            XrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            XrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            XrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            ReportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            XrLabel_CostCenter = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabelExtra = new DevExpress.XtraReports.UI.XRLabel();
            XrCheckBox1 = new DevExpress.XtraReports.UI.XRCheckBox();
            _XrLabel_Hidden = new DevExpress.XtraReports.UI.XRLabel();
            _XrLabel_Hidden.BeforePrint += new System.Drawing.Printing.PrintEventHandler(XrLabel_Hidden_BeforePrint);
            XrLabelDescription = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            Title = new DevExpress.XtraReports.UI.XRControlStyle();
            FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
            PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            DataField = new DevExpress.XtraReports.UI.XRControlStyle();
            TopMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            XrPageInfo4 = new DevExpress.XtraReports.UI.XRPageInfo();
            XrPageInfo3 = new DevExpress.XtraReports.UI.XRPageInfo();
            BottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            XrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            XrLine3 = new DevExpress.XtraReports.UI.XRLine();
            XrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            Parameter1 = new DevExpress.XtraReports.Parameters.Parameter();
            DataSet_Tray1 = new DataSet_Tray();
            View_Tray_PackListTableAdapter = new DataSets.DataSet_TrayTableAdapters.View_Tray_PackListTableAdapter();
            ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            XrLine4 = new DevExpress.XtraReports.UI.XRLine();
            XrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)DataSet_Tray1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            // 
            // Detail
            // 
            Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel2, XrLabel7, XrLabel8, XrLabel9, XrLabel10 });
            resources.ApplyResources(Detail, "Detail");
            Detail.Name = "Detail";
            Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0f);
            Detail.SortFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] { new DevExpress.XtraReports.UI.GroupField("Description_Name", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending) });
            Detail.StyleName = "DataField";
            // 
            // XrLabel2
            // 
            XrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "View_Tray_PackList.Description_ID") });
            resources.ApplyResources(XrLabel2, "XrLabel2");
            XrLabel2.Name = "XrLabel2";
            XrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel2.StylePriority.UseTextAlignment = false;
            // 
            // XrLabel7
            // 
            XrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "View_Container_PackList.Number") });
            resources.ApplyResources(XrLabel7, "XrLabel7");
            XrLabel7.Name = "XrLabel7";
            XrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel7.StylePriority.UseTextAlignment = false;
            // 
            // XrLabel8
            // 
            XrLabel8.AutoWidth = true;
            XrLabel8.CanShrink = true;
            XrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "View_Container_PackList.Description_Name") });
            resources.ApplyResources(XrLabel8, "XrLabel8");
            XrLabel8.Name = "XrLabel8";
            XrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel8.StylePriority.UseTextAlignment = false;
            // 
            // XrLabel9
            // 
            XrLabel9.CanShrink = true;
            XrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "View_Container_PackList.D") });
            resources.ApplyResources(XrLabel9, "XrLabel9");
            XrLabel9.Name = "XrLabel9";
            XrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel9.StylePriority.UseTextAlignment = false;
            // 
            // XrLabel10
            // 
            XrLabel10.AutoWidth = true;
            XrLabel10.CanShrink = true;
            XrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "View_Container_PackList.E") });
            resources.ApplyResources(XrLabel10, "XrLabel10");
            XrLabel10.Name = "XrLabel10";
            XrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel10.StylePriority.UseTextAlignment = false;
            // 
            // GroupHeaderBand2
            // 
            GroupHeaderBand2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel13, XrLabel3, XrLabel4, XrLine1, XrLine2 });
            resources.ApplyResources(GroupHeaderBand2, "GroupHeaderBand2");
            GroupHeaderBand2.Name = "GroupHeaderBand2";
            GroupHeaderBand2.StyleName = "FieldCaption";
            // 
            // XrLabel13
            // 
            resources.ApplyResources(XrLabel13, "XrLabel13");
            XrLabel13.Name = "XrLabel13";
            XrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            // 
            // XrLabel3
            // 
            resources.ApplyResources(XrLabel3, "XrLabel3");
            XrLabel3.Name = "XrLabel3";
            XrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            // 
            // XrLabel4
            // 
            resources.ApplyResources(XrLabel4, "XrLabel4");
            XrLabel4.Name = "XrLabel4";
            XrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            // 
            // XrLine1
            // 
            resources.ApplyResources(XrLine1, "XrLine1");
            XrLine1.Name = "XrLine1";
            // 
            // XrLine2
            // 
            resources.ApplyResources(XrLine2, "XrLine2");
            XrLine2.Name = "XrLine2";
            // 
            // PageFooterBand1
            // 
            PageFooterBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel20, XrLabel21, XrLabel1, XrPageInfo1, XrPageInfo2 });
            resources.ApplyResources(PageFooterBand1, "PageFooterBand1");
            PageFooterBand1.Name = "PageFooterBand1";
            // 
            // XrLabel20
            // 
            resources.ApplyResources(XrLabel20, "XrLabel20");
            XrLabel20.Name = "XrLabel20";
            XrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel20.StylePriority.UseFont = false;
            XrLabel20.StylePriority.UseTextAlignment = false;
            // 
            // XrLabel21
            // 
            resources.ApplyResources(XrLabel21, "XrLabel21");
            XrLabel21.Name = "XrLabel21";
            XrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel21.StylePriority.UseTextAlignment = false;
            // 
            // XrLabel1
            // 
            resources.ApplyResources(XrLabel1, "XrLabel1");
            XrLabel1.Name = "XrLabel1";
            XrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel1.StylePriority.UseFont = false;
            XrLabel1.StylePriority.UseTextAlignment = false;
            // 
            // XrPageInfo1
            // 
            resources.ApplyResources(XrPageInfo1, "XrPageInfo1");
            XrPageInfo1.Name = "XrPageInfo1";
            XrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            XrPageInfo1.StyleName = "PageInfo";
            XrPageInfo1.StylePriority.UseTextAlignment = false;
            // 
            // XrPageInfo2
            // 
            resources.ApplyResources(XrPageInfo2, "XrPageInfo2");
            XrPageInfo2.Name = "XrPageInfo2";
            XrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrPageInfo2.StyleName = "PageInfo";
            XrPageInfo2.StylePriority.UseTextAlignment = false;
            // 
            // ReportHeaderBand1
            // 
            ReportHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel_CostCenter, XrLabel18, XrLabelExtra, XrCheckBox1, _XrLabel_Hidden, XrLabelDescription, XrLabel14, XrLabel11 });
            resources.ApplyResources(ReportHeaderBand1, "ReportHeaderBand1");
            ReportHeaderBand1.Name = "ReportHeaderBand1";
            // 
            // XrLabel_CostCenter
            // 
            resources.ApplyResources(XrLabel_CostCenter, "XrLabel_CostCenter");
            XrLabel_CostCenter.Name = "XrLabel_CostCenter";
            XrLabel_CostCenter.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel_CostCenter.StylePriority.UseFont = false;
            XrLabel_CostCenter.StylePriority.UseTextAlignment = false;
            // 
            // XrLabel18
            // 
            resources.ApplyResources(XrLabel18, "XrLabel18");
            XrLabel18.Name = "XrLabel18";
            XrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel18.StyleName = "FieldCaption";
            XrLabel18.StylePriority.UseFont = false;
            XrLabel18.StylePriority.UseTextAlignment = false;
            // 
            // XrLabelExtra
            // 
            resources.ApplyResources(XrLabelExtra, "XrLabelExtra");
            XrLabelExtra.Multiline = true;
            XrLabelExtra.Name = "XrLabelExtra";
            XrLabelExtra.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabelExtra.StylePriority.UseFont = false;
            XrLabelExtra.StylePriority.UseTextAlignment = false;
            // 
            // XrCheckBox1
            // 
            XrCheckBox1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("CheckState", null, "View_Tray_PackList.Hide_Tray") });
            resources.ApplyResources(XrCheckBox1, "XrCheckBox1");
            XrCheckBox1.Name = "XrCheckBox1";
            // 
            // XrLabel_Hidden
            // 
            resources.ApplyResources(_XrLabel_Hidden, "XrLabel_Hidden");
            _XrLabel_Hidden.Name = "_XrLabel_Hidden";
            _XrLabel_Hidden.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            _XrLabel_Hidden.StylePriority.UseFont = false;
            _XrLabel_Hidden.StylePriority.UseForeColor = false;
            _XrLabel_Hidden.StylePriority.UseTextAlignment = false;
            // 
            // XrLabelDescription
            // 
            XrLabelDescription.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "View_Tray_PackList.Tray_Description") });
            resources.ApplyResources(XrLabelDescription, "XrLabelDescription");
            XrLabelDescription.Name = "XrLabelDescription";
            XrLabelDescription.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            // 
            // XrLabel14
            // 
            XrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "View_Tray_PackList.Tray_Name") });
            resources.ApplyResources(XrLabel14, "XrLabel14");
            XrLabel14.Name = "XrLabel14";
            XrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel14.StylePriority.UseFont = false;
            // 
            // XrLabel11
            // 
            resources.ApplyResources(XrLabel11, "XrLabel11");
            XrLabel11.Name = "XrLabel11";
            XrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel11.StyleName = "Title";
            XrLabel11.StylePriority.UseFont = false;
            // 
            // Title
            // 
            Title.BackColor = Color.Transparent;
            Title.BorderColor = Color.Black;
            Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
            Title.BorderWidth = 1.0f;
            Title.Font = new Font("Tahoma", 24.0f, FontStyle.Bold);
            Title.ForeColor = Color.Teal;
            Title.Name = "Title";
            // 
            // FieldCaption
            // 
            FieldCaption.BackColor = Color.Transparent;
            FieldCaption.BorderColor = Color.Black;
            FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.None;
            FieldCaption.BorderWidth = 1.0f;
            FieldCaption.Font = new Font("Arial", 10.0f, FontStyle.Bold);
            FieldCaption.ForeColor = Color.Black;
            FieldCaption.Name = "FieldCaption";
            // 
            // PageInfo
            // 
            PageInfo.BackColor = Color.Transparent;
            PageInfo.BorderColor = Color.Black;
            PageInfo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            PageInfo.BorderWidth = 1.0f;
            PageInfo.Font = new Font("Arial", 9.0f);
            PageInfo.ForeColor = Color.Black;
            PageInfo.Name = "PageInfo";
            // 
            // DataField
            // 
            DataField.BackColor = Color.Transparent;
            DataField.BorderColor = Color.Black;
            DataField.Borders = DevExpress.XtraPrinting.BorderSide.None;
            DataField.BorderWidth = 1.0f;
            DataField.Font = new Font("Arial", 10.0f);
            DataField.ForeColor = Color.Black;
            DataField.Name = "DataField";
            DataField.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            // 
            // TopMarginBand1
            // 
            TopMarginBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrPageInfo4, XrPageInfo3 });
            resources.ApplyResources(TopMarginBand1, "TopMarginBand1");
            TopMarginBand1.Name = "TopMarginBand1";
            // 
            // XrPageInfo4
            // 
            resources.ApplyResources(XrPageInfo4, "XrPageInfo4");
            XrPageInfo4.Name = "XrPageInfo4";
            XrPageInfo4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrPageInfo4.PageInfo = DevExpress.XtraPrinting.PageInfo.UserName;
            XrPageInfo4.StylePriority.UseTextAlignment = false;
            // 
            // XrPageInfo3
            // 
            resources.ApplyResources(XrPageInfo3, "XrPageInfo3");
            XrPageInfo3.Name = "XrPageInfo3";
            XrPageInfo3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrPageInfo3.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            XrPageInfo3.StylePriority.UseTextAlignment = false;
            // 
            // BottomMarginBand1
            // 
            resources.ApplyResources(BottomMarginBand1, "BottomMarginBand1");
            BottomMarginBand1.Name = "BottomMarginBand1";
            // 
            // GroupFooter1
            // 
            GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel17, XrLabel16, XrLabel15, XrLine3, XrLabel6, XrLabel12, XrLabel5 });
            resources.ApplyResources(GroupFooter1, "GroupFooter1");
            GroupFooter1.Name = "GroupFooter1";
            // 
            // XrLabel17
            // 
            resources.ApplyResources(XrLabel17, "XrLabel17");
            XrLabel17.Name = "XrLabel17";
            XrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel17.StyleName = "FieldCaption";
            XrLabel17.StylePriority.UseFont = false;
            XrLabel17.StylePriority.UseTextAlignment = false;
            // 
            // XrLabel16
            // 
            XrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "View_Tray_PackList.Department_Name") });
            resources.ApplyResources(XrLabel16, "XrLabel16");
            XrLabel16.Name = "XrLabel16";
            XrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel16.StylePriority.UseFont = false;
            XrLabel16.StylePriority.UseTextAlignment = false;
            // 
            // XrLabel15
            // 
            resources.ApplyResources(XrLabel15, "XrLabel15");
            XrLabel15.Name = "XrLabel15";
            XrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel15.StyleName = "FieldCaption";
            XrLabel15.StylePriority.UseFont = false;
            XrLabel15.StylePriority.UseTextAlignment = false;
            // 
            // XrLine3
            // 
            resources.ApplyResources(XrLine3, "XrLine3");
            XrLine3.Name = "XrLine3";
            // 
            // XrLabel6
            // 
            XrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "View_Container_PackList.Number") });
            resources.ApplyResources(XrLabel6, "XrLabel6");
            XrLabel6.Name = "XrLabel6";
            XrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel6.StylePriority.UseFont = false;
            XrLabel6.StylePriority.UseTextAlignment = false;
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            XrLabel6.Summary = XrSummary1;
            // 
            // XrLabel12
            // 
            resources.ApplyResources(XrLabel12, "XrLabel12");
            XrLabel12.Name = "XrLabel12";
            XrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel12.StyleName = "FieldCaption";
            XrLabel12.StylePriority.UseFont = false;
            XrLabel12.StylePriority.UseTextAlignment = false;
            // 
            // XrLabel5
            // 
            XrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] { new DevExpress.XtraReports.UI.XRBinding("Text", null, "View_Container_PackList.Number") });
            resources.ApplyResources(XrLabel5, "XrLabel5");
            XrLabel5.Name = "XrLabel5";
            XrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel5.StylePriority.UseFont = false;
            XrLabel5.StylePriority.UseTextAlignment = false;
            XrSummary2.Func = DevExpress.XtraReports.UI.SummaryFunc.Count;
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            XrLabel5.Summary = XrSummary2;
            // 
            // Parameter1
            // 
            resources.ApplyResources(Parameter1, "Parameter1");
            Parameter1.Name = "Parameter1";
            Parameter1.Type = typeof(int);
            Parameter1.ValueInfo = "0";
            // 
            // DataSet_Tray1
            // 
            DataSet_Tray1.DataSetName = "DataSet_Tray";
            DataSet_Tray1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            // 
            // View_Tray_PackListTableAdapter
            // 
            View_Tray_PackListTableAdapter.ClearBeforeFill = true;
            // 
            // ReportFooter
            // 
            ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLine4, XrLabel19 });
            resources.ApplyResources(ReportFooter, "ReportFooter");
            ReportFooter.Name = "ReportFooter";
            // 
            // XrLine4
            // 
            resources.ApplyResources(XrLine4, "XrLine4");
            XrLine4.Name = "XrLine4";
            // 
            // XrLabel19
            // 
            resources.ApplyResources(XrLabel19, "XrLabel19");
            XrLabel19.Name = "XrLabel19";
            XrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel19.StylePriority.UseFont = false;
            // 
            // XtraReport_PackList
            // 
            Bands.AddRange(new DevExpress.XtraReports.UI.Band[] { Detail, GroupHeaderBand2, PageFooterBand1, ReportHeaderBand1, TopMarginBand1, BottomMarginBand1, GroupFooter1, ReportFooter });
            DataAdapter = View_Tray_PackListTableAdapter;
            DataMember = "View_Tray_PackList";
            DataSource = DataSet_Tray1;
            FilterString = "[Tray_Descrip_ID] = ?Parameter1";
            resources.ApplyResources(this, "$this");
            Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] { Parameter1 });
            ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic;
            StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] { Title, FieldCaption, PageInfo, DataField });
            Version = "19.2";
            ((System.ComponentModel.ISupportInitialize)DataSet_Tray1).EndInit();
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
        }

        internal DevExpress.XtraReports.UI.DetailBand Detail;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel7;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel8;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel9;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel10;
        // Friend WithEvents View_Container_PackListAdapter1 As Surgical_Admin.PackListTableAdapters.View_Container_PackListAdapter
        // Friend WithEvents PackList1 As Surgical_Admin.PackList
        internal DevExpress.XtraReports.UI.GroupHeaderBand GroupHeaderBand2;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel3;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel4;
        internal DevExpress.XtraReports.UI.XRLine XrLine1;
        internal DevExpress.XtraReports.UI.XRLine XrLine2;
        internal DevExpress.XtraReports.UI.PageFooterBand PageFooterBand1;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo1;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo2;
        internal DevExpress.XtraReports.UI.ReportHeaderBand ReportHeaderBand1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel11;
        internal DevExpress.XtraReports.UI.XRControlStyle Title;
        internal DevExpress.XtraReports.UI.XRControlStyle FieldCaption;
        internal DevExpress.XtraReports.UI.XRControlStyle PageInfo;
        internal DevExpress.XtraReports.UI.XRControlStyle DataField;
        internal DevExpress.XtraReports.UI.TopMarginBand TopMarginBand1;
        internal DevExpress.XtraReports.UI.BottomMarginBand BottomMarginBand1;
        internal DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel5;
        internal DevExpress.XtraReports.UI.XRLine XrLine3;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel12;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel6;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel14;
        internal DevExpress.XtraReports.Parameters.Parameter Parameter1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabelDescription;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel2;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel13;
        private DevExpress.XtraReports.UI.XRLabel _XrLabel_Hidden;

        internal DevExpress.XtraReports.UI.XRLabel XrLabel_Hidden
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _XrLabel_Hidden;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_XrLabel_Hidden != null)
                {
                    _XrLabel_Hidden.BeforePrint -= XrLabel_Hidden_BeforePrint;
                }

                _XrLabel_Hidden = value;
                if (_XrLabel_Hidden != null)
                {
                    _XrLabel_Hidden.BeforePrint += XrLabel_Hidden_BeforePrint;
                }
            }
        }
        // Friend WithEvents PackList2 As PackList
        internal DevExpress.XtraReports.UI.XRCheckBox XrCheckBox1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel17;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel16;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel15;
        internal DataSet_Tray DataSet_Tray1;
        internal DataSets.DataSet_TrayTableAdapters.View_Tray_PackListTableAdapter View_Tray_PackListTableAdapter;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel_CostCenter;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel18;
        internal DevExpress.XtraReports.UI.XRLabel XrLabelExtra;
        internal DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        internal DevExpress.XtraReports.UI.XRLine XrLine4;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel19;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel20;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel21;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo4;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo3;
    }
}