using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Service_Station
{
    [DesignerGenerated()]
    public partial class PivotGridView_1 : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is object)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PivotGridView_1));
            this._PivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this._TopTitle = new System.Windows.Forms.Label();
            this._Button_Exit = new System.Windows.Forms.Button();
            this._Button_Preview1 = new System.Windows.Forms.Button();
            this._ButtonExportExcel = new System.Windows.Forms.Button();
            this.PrintForm1 = new Microsoft.VisualBasic.PowerPacks.Printing.PrintForm(this.components);
            this.FolderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this._ButtonPrintReport = new System.Windows.Forms.Button();
            this._CheckBoxServiceToday = new System.Windows.Forms.CheckBox();
            this.btnOSK1 = new UIControls.WinForms.Controls.BtnOSK();
            ((System.ComponentModel.ISupportInitialize)(this._PivotGridControl1)).BeginInit();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // _PivotGridControl1
            // 
            this._PivotGridControl1.Appearance.FieldHeader.Font = ((System.Drawing.Font)(resources.GetObject("_PivotGridControl1.Appearance.FieldHeader.Font")));
            this._PivotGridControl1.Appearance.FieldHeader.Options.UseFont = true;
            this._PivotGridControl1.AppearancePrint.FieldHeader.ForeColor = ((System.Drawing.Color)(resources.GetObject("_PivotGridControl1.AppearancePrint.FieldHeader.ForeColor")));
            this._PivotGridControl1.AppearancePrint.FieldHeader.Options.UseForeColor = true;
            this._PivotGridControl1.AppearancePrint.FieldValue.BackColor = ((System.Drawing.Color)(resources.GetObject("_PivotGridControl1.AppearancePrint.FieldValue.BackColor")));
            this._PivotGridControl1.AppearancePrint.FieldValue.BackColor2 = ((System.Drawing.Color)(resources.GetObject("_PivotGridControl1.AppearancePrint.FieldValue.BackColor2")));
            this._PivotGridControl1.AppearancePrint.FieldValue.Options.UseBackColor = true;
            resources.ApplyResources(this._PivotGridControl1, "_PivotGridControl1");
            this._PivotGridControl1.LookAndFeel.SkinName = "Office 2010 Silver";
            this._PivotGridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this._PivotGridControl1.Name = "_PivotGridControl1";
            this._PivotGridControl1.OptionsPrint.UsePrintAppearance = true;
            this._PivotGridControl1.FieldValueDisplayText += new DevExpress.XtraPivotGrid.PivotFieldDisplayTextEventHandler(this.pivotGridControl1_FieldValueDisplayText);
            this._PivotGridControl1.DoubleClick += new System.EventHandler(this.PivotGridControl1_DoubleClick);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.DarkOrange;
            this.Panel1.Controls.Add(this.PictureBox1);
            this.Panel1.Controls.Add(this._TopTitle);
            resources.ApplyResources(this.Panel1, "Panel1");
            this.Panel1.Name = "Panel1";
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = global::Service_Station.My.Resources.Resources.Knowledge_Hub_logo;
            resources.ApplyResources(this.PictureBox1, "PictureBox1");
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.TabStop = false;
            // 
            // _TopTitle
            // 
            resources.ApplyResources(this._TopTitle, "_TopTitle");
            this._TopTitle.BackColor = System.Drawing.Color.Transparent;
            this._TopTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this._TopTitle.Name = "_TopTitle";
            this._TopTitle.Click += new System.EventHandler(this.TopTitle_Click);
            // 
            // _Button_Exit
            // 
            this._Button_Exit.BackColor = System.Drawing.SystemColors.HotTrack;
            resources.ApplyResources(this._Button_Exit, "_Button_Exit");
            this._Button_Exit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this._Button_Exit.Name = "_Button_Exit";
            this._Button_Exit.UseVisualStyleBackColor = false;
            this._Button_Exit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // _Button_Preview1
            // 
            resources.ApplyResources(this._Button_Preview1, "_Button_Preview1");
            this._Button_Preview1.Name = "_Button_Preview1";
            this._Button_Preview1.UseVisualStyleBackColor = true;
            this._Button_Preview1.Click += new System.EventHandler(this.Button_Preview1_Click_1);
            // 
            // _ButtonExportExcel
            // 
            resources.ApplyResources(this._ButtonExportExcel, "_ButtonExportExcel");
            this._ButtonExportExcel.Name = "_ButtonExportExcel";
            this._ButtonExportExcel.UseVisualStyleBackColor = true;
            this._ButtonExportExcel.Click += new System.EventHandler(this.ButtonExportExcel_Click);
            // 
            // PrintForm1
            // 
            this.PrintForm1.DocumentName = "document";
            this.PrintForm1.Form = this;
            this.PrintForm1.PrintAction = System.Drawing.Printing.PrintAction.PrintToPrinter;
            this.PrintForm1.PrinterSettings = ((System.Drawing.Printing.PrinterSettings)(resources.GetObject("PrintForm1.PrinterSettings")));
            this.PrintForm1.PrintFileName = null;
            // 
            // _ButtonPrintReport
            // 
            resources.ApplyResources(this._ButtonPrintReport, "_ButtonPrintReport");
            this._ButtonPrintReport.Name = "_ButtonPrintReport";
            this._ButtonPrintReport.UseVisualStyleBackColor = true;
            this._ButtonPrintReport.Click += new System.EventHandler(this.ButtonPrintReport_Click);
            // 
            // _CheckBoxServiceToday
            // 
            resources.ApplyResources(this._CheckBoxServiceToday, "_CheckBoxServiceToday");
            this._CheckBoxServiceToday.Checked = true;
            this._CheckBoxServiceToday.CheckState = System.Windows.Forms.CheckState.Checked;
            this._CheckBoxServiceToday.Name = "_CheckBoxServiceToday";
            this._CheckBoxServiceToday.UseVisualStyleBackColor = true;
            this._CheckBoxServiceToday.CheckedChanged += new System.EventHandler(this.CheckBoxServiceToday_CheckedChanged);
            // 
            // btnOSK1
            // 
            resources.ApplyResources(this.btnOSK1, "btnOSK1");
            this.btnOSK1.Name = "btnOSK1";
            // 
            // PivotGridView_1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.btnOSK1);
            this.Controls.Add(this._CheckBoxServiceToday);
            this.Controls.Add(this._ButtonPrintReport);
            this.Controls.Add(this._ButtonExportExcel);
            this.Controls.Add(this._Button_Preview1);
            this.Controls.Add(this._Button_Exit);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this._PivotGridControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PivotGridView_1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FormGridView_1_Load);
            ((System.ComponentModel.ISupportInitialize)(this._PivotGridControl1)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private DevExpress.XtraPivotGrid.PivotGridControl _PivotGridControl1;

        internal DevExpress.XtraPivotGrid.PivotGridControl PivotGridControl1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PivotGridControl1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PivotGridControl1 != null)
                {
                    _PivotGridControl1.FieldValueDisplayText -= pivotGridControl1_FieldValueDisplayText;
                    _PivotGridControl1.DoubleClick -= PivotGridControl1_DoubleClick;
                }

                _PivotGridControl1 = value;
                if (_PivotGridControl1 != null)
                {
                    _PivotGridControl1.FieldValueDisplayText += pivotGridControl1_FieldValueDisplayText;
                    _PivotGridControl1.DoubleClick += PivotGridControl1_DoubleClick;
                }
            }
        }

        internal Panel Panel1;
        internal PictureBox PictureBox1;
        private Label _TopTitle;

        internal Label TopTitle
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TopTitle;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TopTitle != null)
                {
                    _TopTitle.Click -= TopTitle_Click;
                }

                _TopTitle = value;
                if (_TopTitle != null)
                {
                    _TopTitle.Click += TopTitle_Click;
                }
            }
        }

        private Button _Button_Exit;

        internal Button Button_Exit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button_Exit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button_Exit != null)
                {
                    _Button_Exit.Click -= ButtonExit_Click;
                }

                _Button_Exit = value;
                if (_Button_Exit != null)
                {
                    _Button_Exit.Click += ButtonExit_Click;
                }
            }
        }

        private Button _Button_Preview1;

        internal Button Button_Preview1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button_Preview1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button_Preview1 != null)
                {
                    _Button_Preview1.Click -= Button_Preview1_Click_1;
                }

                _Button_Preview1 = value;
                if (_Button_Preview1 != null)
                {
                    _Button_Preview1.Click += Button_Preview1_Click_1;
                }
            }
        }

        private Button _ButtonExportExcel;

        internal Button ButtonExportExcel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ButtonExportExcel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ButtonExportExcel != null)
                {
                    _ButtonExportExcel.Click -= ButtonExportExcel_Click;
                }

                _ButtonExportExcel = value;
                if (_ButtonExportExcel != null)
                {
                    _ButtonExportExcel.Click += ButtonExportExcel_Click;
                }
            }
        }

        internal Microsoft.VisualBasic.PowerPacks.Printing.PrintForm PrintForm1;
        internal FolderBrowserDialog FolderBrowserDialog1;
        private Button _ButtonPrintReport;

        internal Button ButtonPrintReport
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ButtonPrintReport;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ButtonPrintReport != null)
                {
                    _ButtonPrintReport.Click -= ButtonPrintReport_Click;
                }

                _ButtonPrintReport = value;
                if (_ButtonPrintReport != null)
                {
                    _ButtonPrintReport.Click += ButtonPrintReport_Click;
                }
            }
        }

        private CheckBox _CheckBoxServiceToday;
        private UIControls.WinForms.Controls.BtnOSK btnOSK1;

        internal CheckBox CheckBoxServiceToday
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CheckBoxServiceToday;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CheckBoxServiceToday != null)
                {
                    _CheckBoxServiceToday.CheckedChanged -= CheckBoxServiceToday_CheckedChanged;
                }

                _CheckBoxServiceToday = value;
                if (_CheckBoxServiceToday != null)
                {
                    _CheckBoxServiceToday.CheckedChanged += CheckBoxServiceToday_CheckedChanged;
                }
            }
        }
    }
}