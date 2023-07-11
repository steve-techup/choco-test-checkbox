using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Service_Station
{
    [DesignerGenerated()]
    public partial class Print_Service_Report : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Print_Service_Report));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.TopTitle = new System.Windows.Forms.Label();
            this._ButtonExit = new System.Windows.Forms.Button();
            this._ComboBoxServiceVendor = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this._TextBoxSpecial = new System.Windows.Forms.TextBox();
            this.LabelSpecialInformation = new System.Windows.Forms.Label();
            this._ButtonPrintReport = new System.Windows.Forms.Button();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this._ButtonInformation = new System.Windows.Forms.Button();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnOSK1 = new UIControls.WinForms.Controls.BtnOSK();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.DarkOrange;
            this.Panel1.Controls.Add(this.PictureBox1);
            this.Panel1.Controls.Add(this.TopTitle);
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
            // TopTitle
            // 
            resources.ApplyResources(this.TopTitle, "TopTitle");
            this.TopTitle.BackColor = System.Drawing.Color.Transparent;
            this.TopTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TopTitle.Name = "TopTitle";
            // 
            // _ButtonExit
            // 
            resources.ApplyResources(this._ButtonExit, "_ButtonExit");
            this._ButtonExit.Name = "_ButtonExit";
            this._ButtonExit.UseVisualStyleBackColor = true;
            this._ButtonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // _ComboBoxServiceVendor
            // 
            resources.ApplyResources(this._ComboBoxServiceVendor, "_ComboBoxServiceVendor");
            this._ComboBoxServiceVendor.FormattingEnabled = true;
            this._ComboBoxServiceVendor.Name = "_ComboBoxServiceVendor";
            this._ComboBoxServiceVendor.SelectedIndexChanged += new System.EventHandler(this.ComboBoxServiceVendor_SelectedIndexChanged);
            // 
            // Label1
            // 
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.Name = "Label1";
            // 
            // _TextBoxSpecial
            // 
            this._TextBoxSpecial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this._TextBoxSpecial, "_TextBoxSpecial");
            this._TextBoxSpecial.Name = "_TextBoxSpecial";
            this._TextBoxSpecial.TabStop = false;
            this.ToolTip1.SetToolTip(this._TextBoxSpecial, resources.GetString("_TextBoxSpecial.ToolTip"));
            this._TextBoxSpecial.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxSpecial_TextChanged);
            // 
            // LabelSpecialInformation
            // 
            resources.ApplyResources(this.LabelSpecialInformation, "LabelSpecialInformation");
            this.LabelSpecialInformation.Name = "LabelSpecialInformation";
            // 
            // _ButtonPrintReport
            // 
            resources.ApplyResources(this._ButtonPrintReport, "_ButtonPrintReport");
            this._ButtonPrintReport.Name = "_ButtonPrintReport";
            this._ButtonPrintReport.UseVisualStyleBackColor = true;
            this._ButtonPrintReport.Click += new System.EventHandler(this.ButtonPrintReport_Click);
            // 
            // TextBox2
            // 
            this.TextBox2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.TextBox2, "TextBox2");
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.ReadOnly = true;
            this.TextBox2.TabStop = false;
            // 
            // _ButtonInformation
            // 
            resources.ApplyResources(this._ButtonInformation, "_ButtonInformation");
            this._ButtonInformation.Name = "_ButtonInformation";
            this._ButtonInformation.TabStop = false;
            this._ButtonInformation.UseVisualStyleBackColor = true;
            this._ButtonInformation.Click += new System.EventHandler(this.ButtonInformation_Click);
            // 
            // btnOSK1
            // 
            resources.ApplyResources(this.btnOSK1, "btnOSK1");
            this.btnOSK1.Name = "btnOSK1";
            // 
            // Print_Service_Report
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ControlBox = false;
            this.Controls.Add(this.btnOSK1);
            this.Controls.Add(this._ButtonInformation);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this._ButtonPrintReport);
            this.Controls.Add(this.LabelSpecialInformation);
            this.Controls.Add(this._TextBoxSpecial);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this._ComboBoxServiceVendor);
            this.Controls.Add(this._ButtonExit);
            this.Controls.Add(this.Panel1);
            this.Name = "Print_Service_Report";
            this.Load += new System.EventHandler(this.Print_Service_Report_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        internal Panel Panel1;
        internal PictureBox PictureBox1;
        internal Label TopTitle;
        private Button _ButtonExit;

        internal Button ButtonExit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ButtonExit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ButtonExit != null)
                {
                    _ButtonExit.Click -= ButtonExit_Click;
                }

                _ButtonExit = value;
                if (_ButtonExit != null)
                {
                    _ButtonExit.Click += ButtonExit_Click;
                }
            }
        }

        private ComboBox _ComboBoxServiceVendor;

        internal ComboBox ComboBoxServiceVendor
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ComboBoxServiceVendor;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ComboBoxServiceVendor != null)
                {
                    _ComboBoxServiceVendor.SelectedIndexChanged -= ComboBoxServiceVendor_SelectedIndexChanged;
                }

                _ComboBoxServiceVendor = value;
                if (_ComboBoxServiceVendor != null)
                {
                    _ComboBoxServiceVendor.SelectedIndexChanged += ComboBoxServiceVendor_SelectedIndexChanged;
                }
            }
        }

        internal Label Label1;
        private TextBox _TextBoxSpecial;

        internal TextBox TextBoxSpecial
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBoxSpecial;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBoxSpecial != null)
                {
                    _TextBoxSpecial.MouseClick -= TextBoxSpecial_TextChanged;
                }

                _TextBoxSpecial = value;
                if (_TextBoxSpecial != null)
                {
                    _TextBoxSpecial.MouseClick += TextBoxSpecial_TextChanged;
                }
            }
        }

        internal Label LabelSpecialInformation;
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

        internal TextBox TextBox2;
        private Button _ButtonInformation;

        internal Button ButtonInformation
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ButtonInformation;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ButtonInformation != null)
                {
                    _ButtonInformation.Click -= ButtonInformation_Click;
                }

                _ButtonInformation = value;
                if (_ButtonInformation != null)
                {
                    _ButtonInformation.Click += ButtonInformation_Click;
                }
            }
        }

        internal ToolTip ToolTip1;
        private UIControls.WinForms.Controls.BtnOSK btnOSK1;
    }
}