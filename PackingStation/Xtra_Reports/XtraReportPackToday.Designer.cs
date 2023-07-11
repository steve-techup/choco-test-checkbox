using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;
using PackingStation.DataSets;

namespace PackingStation
{
    [DesignerGenerated()]
    public partial class XtraReportPackToday : DevExpress.XtraReports.UI.XtraReport
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraReportPackToday));
            var XrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            Detail = new DevExpress.XtraReports.UI.DetailBand();
            XrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            XrPageInfo3 = new DevExpress.XtraReports.UI.XRPageInfo();
            XrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            XrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            Caretag_SurgicalDataSet1 = new Caretag_SurgicalDataSet();
            View_Packed_TraysTableAdapter = new DataSets.Caretag_SurgicalDataSetTableAdapters.View_Packed_TraysTableAdapter();
            GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            XrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            XrLine1 = new DevExpress.XtraReports.UI.XRLine();
            XrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            GroupHeader3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            XrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            XrLine3 = new DevExpress.XtraReports.UI.XRLine();
            XrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            XrLine2 = new DevExpress.XtraReports.UI.XRLine();
            _XrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            _XrLabel6.BeforePrint += new System.Drawing.Printing.PrintEventHandler(XrLabel6_BeforePrint);
            XrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            XrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            XrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            XrLine4 = new DevExpress.XtraReports.UI.XRLine();
            _XrLabel_Report_Tray = new DevExpress.XtraReports.UI.XRLabel();
            _XrLabel_Report_Tray.BeforePrint += new System.Drawing.Printing.PrintEventHandler(XrLabel_Report_Tray_BeforePrint);
            XrLabel_Report_Instru = new DevExpress.XtraReports.UI.XRLabel();
            XrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)Caretag_SurgicalDataSet1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            // 
            // Detail
            // 
            Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel8, XrLabel7 });
            resources.ApplyResources(Detail, "Detail");
            Detail.Name = "Detail";
            Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0f);
            // 
            // XrLabel8
            // 
            resources.ApplyResources(XrLabel8, "XrLabel8");
            XrLabel8.Name = "XrLabel8";
            XrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel8.StylePriority.UseTextAlignment = false;
            // 
            // XrLabel7
            // 
            resources.ApplyResources(XrLabel7, "XrLabel7");
            XrLabel7.Name = "XrLabel7";
            XrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel7.StylePriority.UseTextAlignment = false;
            // 
            // TopMargin
            // 
            TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrPageInfo3, XrPageInfo1 });
            TopMargin.Name = "TopMargin";
            TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0f);
            resources.ApplyResources(TopMargin, "TopMargin");
            // 
            // XrPageInfo3
            // 
            resources.ApplyResources(XrPageInfo3, "XrPageInfo3");
            XrPageInfo3.Name = "XrPageInfo3";
            XrPageInfo3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrPageInfo3.PageInfo = DevExpress.XtraPrinting.PageInfo.UserName;
            XrPageInfo3.StylePriority.UseTextAlignment = false;
            // 
            // XrPageInfo1
            // 
            resources.ApplyResources(XrPageInfo1, "XrPageInfo1");
            XrPageInfo1.Name = "XrPageInfo1";
            XrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            XrPageInfo1.StylePriority.UseTextAlignment = false;
            // 
            // BottomMargin
            // 
            BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrPageInfo2 });
            BottomMargin.Name = "BottomMargin";
            BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0f);
            resources.ApplyResources(BottomMargin, "BottomMargin");
            // 
            // XrPageInfo2
            // 
            resources.ApplyResources(XrPageInfo2, "XrPageInfo2");
            XrPageInfo2.Name = "XrPageInfo2";
            XrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrPageInfo2.StylePriority.UseTextAlignment = false;
            // 
            // Caretag_SurgicalDataSet1
            // 
            Caretag_SurgicalDataSet1.DataSetName = "Caretag_SurgicalDataSet";
            Caretag_SurgicalDataSet1.EnforceConstraints = false;
            Caretag_SurgicalDataSet1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            // 
            // View_Packed_TraysTableAdapter
            // 
            View_Packed_TraysTableAdapter.ClearBeforeFill = true;
            // 
            // GroupHeader1
            // 
            GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel4, XrLabel1 });
            GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] { new DevExpress.XtraReports.UI.GroupField("Pack_User_ID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending) });
            resources.ApplyResources(GroupHeader1, "GroupHeader1");
            GroupHeader1.Level = 2;
            GroupHeader1.Name = "GroupHeader1";
            // 
            // XrLabel4
            // 
            resources.ApplyResources(XrLabel4, "XrLabel4");
            XrLabel4.Name = "XrLabel4";
            XrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel4.StylePriority.UseFont = false;
            XrLabel4.StylePriority.UseTextAlignment = false;
            // 
            // XrLabel1
            // 
            resources.ApplyResources(XrLabel1, "XrLabel1");
            XrLabel1.Name = "XrLabel1";
            XrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel1.StylePriority.UseFont = false;
            XrLabel1.StylePriority.UseTextAlignment = false;
            // 
            // GroupHeader2
            // 
            GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLine1, XrLabel3 });
            resources.ApplyResources(GroupHeader2, "GroupHeader2");
            GroupHeader2.Level = 1;
            GroupHeader2.Name = "GroupHeader2";
            // 
            // XrLine1
            // 
            XrLine1.LineWidth = 2.0f;
            resources.ApplyResources(XrLine1, "XrLine1");
            XrLine1.Name = "XrLine1";
            // 
            // XrLabel3
            // 
            resources.ApplyResources(XrLabel3, "XrLabel3");
            XrLabel3.Name = "XrLabel3";
            XrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel3.StylePriority.UseFont = false;
            XrLabel3.StylePriority.UseTextAlignment = false;
            // 
            // GroupHeader3
            // 
            GroupHeader3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel12, XrLine3, XrLabel9, XrLine2, _XrLabel6, XrLabel5 });
            resources.ApplyResources(GroupHeader3, "GroupHeader3");
            GroupHeader3.Name = "GroupHeader3";
            // 
            // XrLabel12
            // 
            resources.ApplyResources(XrLabel12, "XrLabel12");
            XrLabel12.Name = "XrLabel12";
            XrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel12.StylePriority.UseTextAlignment = false;
            // 
            // XrLine3
            // 
            XrLine3.LineWidth = 2.0f;
            resources.ApplyResources(XrLine3, "XrLine3");
            XrLine3.Name = "XrLine3";
            // 
            // XrLabel9
            // 
            resources.ApplyResources(XrLabel9, "XrLabel9");
            XrLabel9.Name = "XrLabel9";
            XrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel9.StylePriority.UseTextAlignment = false;
            // 
            // XrLine2
            // 
            resources.ApplyResources(XrLine2, "XrLine2");
            XrLine2.Name = "XrLine2";
            // 
            // XrLabel6
            // 
            resources.ApplyResources(_XrLabel6, "XrLabel6");
            _XrLabel6.Name = "_XrLabel6";
            _XrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            _XrLabel6.StylePriority.UseFont = false;
            _XrLabel6.StylePriority.UseTextAlignment = false;
            // 
            // XrLabel5
            // 
            resources.ApplyResources(XrLabel5, "XrLabel5");
            XrLabel5.Name = "XrLabel5";
            XrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            // 
            // GroupFooter1
            // 
            GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel10 });
            resources.ApplyResources(GroupFooter1, "GroupFooter1");
            GroupFooter1.Name = "GroupFooter1";
            // 
            // XrLabel10
            // 
            resources.ApplyResources(XrLabel10, "XrLabel10");
            XrLabel10.Name = "XrLabel10";
            XrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel10.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(XrSummary1, "XrSummary1");
            XrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.Count;
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            XrLabel10.Summary = XrSummary1;
            // 
            // ReportHeader
            // 
            ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLabel13 });
            ReportHeader.Name = "ReportHeader";
            // 
            // XrLabel13
            // 
            resources.ApplyResources(XrLabel13, "XrLabel13");
            XrLabel13.Name = "XrLabel13";
            XrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel13.StylePriority.UseFont = false;
            XrLabel13.StylePriority.UseForeColor = false;
            XrLabel13.StylePriority.UseTextAlignment = false;
            // 
            // ReportFooter
            // 
            ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { XrLine4, _XrLabel_Report_Tray, XrLabel_Report_Instru, XrLabel2 });
            resources.ApplyResources(ReportFooter, "ReportFooter");
            ReportFooter.KeepTogether = true;
            ReportFooter.Name = "ReportFooter";
            // 
            // XrLine4
            // 
            XrLine4.LineWidth = 2.0f;
            resources.ApplyResources(XrLine4, "XrLine4");
            XrLine4.Name = "XrLine4";
            // 
            // XrLabel_Report_Tray
            // 
            resources.ApplyResources(_XrLabel_Report_Tray, "XrLabel_Report_Tray");
            _XrLabel_Report_Tray.Multiline = true;
            _XrLabel_Report_Tray.Name = "_XrLabel_Report_Tray";
            _XrLabel_Report_Tray.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            _XrLabel_Report_Tray.StylePriority.UseFont = false;
            // 
            // XrLabel_Report_Instru
            // 
            resources.ApplyResources(XrLabel_Report_Instru, "XrLabel_Report_Instru");
            XrLabel_Report_Instru.Multiline = true;
            XrLabel_Report_Instru.Name = "XrLabel_Report_Instru";
            XrLabel_Report_Instru.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel_Report_Instru.StylePriority.UseFont = false;
            // 
            // XrLabel2
            // 
            resources.ApplyResources(XrLabel2, "XrLabel2");
            XrLabel2.Multiline = true;
            XrLabel2.Name = "XrLabel2";
            XrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            XrLabel2.StylePriority.UseFont = false;
            // 
            // XtraReportPackToday
            // 
            Bands.AddRange(new DevExpress.XtraReports.UI.Band[] { Detail, TopMargin, BottomMargin, GroupHeader1, GroupHeader2, GroupHeader3, GroupFooter1, ReportHeader, ReportFooter });
            resources.ApplyResources(this, "$this");
            ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic;
            Version = "19.2";
            ((System.ComponentModel.ISupportInitialize)Caretag_SurgicalDataSet1).EndInit();
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
        }

        internal DevExpress.XtraReports.UI.DetailBand Detail;
        internal DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        internal DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel8;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel7;
        internal Caretag_SurgicalDataSet Caretag_SurgicalDataSet1;
        internal DataSets.Caretag_SurgicalDataSetTableAdapters.View_Packed_TraysTableAdapter View_Packed_TraysTableAdapter;
        internal DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel4;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel1;
        internal DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader2;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel3;
        internal DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader3;
        private DevExpress.XtraReports.UI.XRLabel _XrLabel6;

        internal DevExpress.XtraReports.UI.XRLabel XrLabel6
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _XrLabel6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_XrLabel6 != null)
                {
                    _XrLabel6.BeforePrint -= XrLabel6_BeforePrint;
                }

                _XrLabel6 = value;
                if (_XrLabel6 != null)
                {
                    _XrLabel6.BeforePrint += XrLabel6_BeforePrint;
                }
            }
        }

        internal DevExpress.XtraReports.UI.XRLabel XrLabel5;
        internal DevExpress.XtraReports.UI.XRLine XrLine3;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel9;
        internal DevExpress.XtraReports.UI.XRLine XrLine2;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo1;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo2;
        internal DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel10;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel12;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo3;
        internal DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel13;
        internal DevExpress.XtraReports.UI.XRLine XrLine1;
        internal DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel _XrLabel_Report_Tray;

        internal DevExpress.XtraReports.UI.XRLabel XrLabel_Report_Tray
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _XrLabel_Report_Tray;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_XrLabel_Report_Tray != null)
                {
                    _XrLabel_Report_Tray.BeforePrint -= XrLabel_Report_Tray_BeforePrint;
                }

                _XrLabel_Report_Tray = value;
                if (_XrLabel_Report_Tray != null)
                {
                    _XrLabel_Report_Tray.BeforePrint += XrLabel_Report_Tray_BeforePrint;
                }
            }
        }

        internal DevExpress.XtraReports.UI.XRLabel XrLabel_Report_Instru;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel2;
        internal DevExpress.XtraReports.UI.XRLine XrLine4;
    }
}