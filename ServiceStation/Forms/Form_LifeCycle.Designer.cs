using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Service_Station
{
    [DesignerGenerated()]
    public partial class Form_LifeCycle : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_LifeCycle));
            Panel1 = new Panel();
            PictureBox1 = new PictureBox();
            _TopTitle = new Label();
            _TopTitle.Click += new EventHandler(TopTitle_Click);
            Label4 = new Label();
            Label5 = new Label();
            Label6 = new Label();
            Label7 = new Label();
            Label8 = new Label();
            Label9 = new Label();
            Label10 = new Label();
            Label11 = new Label();
            Label12 = new Label();
            Label13 = new Label();
            TextBoxSentService = new TextBox();
            TextBoxNumberService = new TextBox();
            TextBoxServiceDays = new TextBox();
            TextBoxreturnService = new TextBox();
            TextBoxCSSDCounter = new TextBox();
            TextBoxORCounter = new TextBox();
            TextBoxCSSDIn = new TextBox();
            TextBoxCSSDOut = new TextBox();
            TextBoxORIn = new TextBox();
            TextBoxOROut = new TextBox();
            TextBoxInstru_Descrip = new TextBox();
            Label14 = new Label();
            Label15 = new Label();
            _ButtonExit = new Button();
            _ButtonExit.Click += new EventHandler(ButtonExit_Click);
            _ButtonPrintAllRules = new Button();
            _ButtonPrintAllRules.Click += new EventHandler(ButtonPrintAllRules_Click);
            Label2 = new Label();
            TextBoxDemandService = new TextBox();
            SeparatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            SeparatorControl2 = new DevExpress.XtraEditors.SeparatorControl();
            Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SeparatorControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SeparatorControl2).BeginInit();
            SuspendLayout();
            // 
            // Panel1
            // 
            Panel1.BackColor = Color.DarkOrange;
            Panel1.Controls.Add(PictureBox1);
            Panel1.Controls.Add(_TopTitle);
            resources.ApplyResources(Panel1, "Panel1");
            Panel1.Name = "Panel1";
            // 
            // PictureBox1
            // 
            PictureBox1.BackColor = Color.Transparent;
            PictureBox1.Image = My.Resources.Resources.Knowledge_Hub_logo;
            resources.ApplyResources(PictureBox1, "PictureBox1");
            PictureBox1.Name = "PictureBox1";
            PictureBox1.TabStop = false;
            // 
            // TopTitle
            // 
            resources.ApplyResources(_TopTitle, "TopTitle");
            _TopTitle.ForeColor = SystemColors.ButtonHighlight;
            _TopTitle.Name = "_TopTitle";
            // 
            // Label4
            // 
            resources.ApplyResources(Label4, "Label4");
            Label4.Name = "Label4";
            // 
            // Label5
            // 
            resources.ApplyResources(Label5, "Label5");
            Label5.Name = "Label5";
            // 
            // Label6
            // 
            resources.ApplyResources(Label6, "Label6");
            Label6.Name = "Label6";
            // 
            // Label7
            // 
            resources.ApplyResources(Label7, "Label7");
            Label7.Name = "Label7";
            // 
            // Label8
            // 
            resources.ApplyResources(Label8, "Label8");
            Label8.Name = "Label8";
            // 
            // Label9
            // 
            resources.ApplyResources(Label9, "Label9");
            Label9.Name = "Label9";
            // 
            // Label10
            // 
            resources.ApplyResources(Label10, "Label10");
            Label10.Name = "Label10";
            // 
            // Label11
            // 
            resources.ApplyResources(Label11, "Label11");
            Label11.Name = "Label11";
            // 
            // Label12
            // 
            resources.ApplyResources(Label12, "Label12");
            Label12.Name = "Label12";
            // 
            // Label13
            // 
            resources.ApplyResources(Label13, "Label13");
            Label13.Name = "Label13";
            // 
            // TextBoxSentService
            // 
            TextBoxSentService.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(TextBoxSentService, "TextBoxSentService");
            TextBoxSentService.Name = "TextBoxSentService";
            TextBoxSentService.ReadOnly = true;
            TextBoxSentService.TabStop = false;
            // 
            // TextBoxNumberService
            // 
            TextBoxNumberService.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(TextBoxNumberService, "TextBoxNumberService");
            TextBoxNumberService.Name = "TextBoxNumberService";
            TextBoxNumberService.ReadOnly = true;
            TextBoxNumberService.TabStop = false;
            // 
            // TextBoxServiceDays
            // 
            TextBoxServiceDays.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(TextBoxServiceDays, "TextBoxServiceDays");
            TextBoxServiceDays.Name = "TextBoxServiceDays";
            TextBoxServiceDays.ReadOnly = true;
            TextBoxServiceDays.TabStop = false;
            // 
            // TextBoxreturnService
            // 
            TextBoxreturnService.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(TextBoxreturnService, "TextBoxreturnService");
            TextBoxreturnService.Name = "TextBoxreturnService";
            TextBoxreturnService.ReadOnly = true;
            TextBoxreturnService.TabStop = false;
            // 
            // TextBoxCSSDCounter
            // 
            TextBoxCSSDCounter.BackColor = SystemColors.Control;
            TextBoxCSSDCounter.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(TextBoxCSSDCounter, "TextBoxCSSDCounter");
            TextBoxCSSDCounter.Name = "TextBoxCSSDCounter";
            TextBoxCSSDCounter.ReadOnly = true;
            TextBoxCSSDCounter.TabStop = false;
            // 
            // TextBoxORCounter
            // 
            TextBoxORCounter.BackColor = SystemColors.Control;
            TextBoxORCounter.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(TextBoxORCounter, "TextBoxORCounter");
            TextBoxORCounter.Name = "TextBoxORCounter";
            TextBoxORCounter.ReadOnly = true;
            TextBoxORCounter.TabStop = false;
            // 
            // TextBoxCSSDIn
            // 
            TextBoxCSSDIn.BackColor = SystemColors.Control;
            TextBoxCSSDIn.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(TextBoxCSSDIn, "TextBoxCSSDIn");
            TextBoxCSSDIn.Name = "TextBoxCSSDIn";
            TextBoxCSSDIn.ReadOnly = true;
            TextBoxCSSDIn.TabStop = false;
            // 
            // TextBoxCSSDOut
            // 
            TextBoxCSSDOut.BackColor = SystemColors.Control;
            TextBoxCSSDOut.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(TextBoxCSSDOut, "TextBoxCSSDOut");
            TextBoxCSSDOut.Name = "TextBoxCSSDOut";
            TextBoxCSSDOut.ReadOnly = true;
            TextBoxCSSDOut.TabStop = false;
            // 
            // TextBoxORIn
            // 
            TextBoxORIn.BackColor = SystemColors.Control;
            TextBoxORIn.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(TextBoxORIn, "TextBoxORIn");
            TextBoxORIn.Name = "TextBoxORIn";
            TextBoxORIn.ReadOnly = true;
            TextBoxORIn.TabStop = false;
            // 
            // TextBoxOROut
            // 
            TextBoxOROut.BackColor = SystemColors.Control;
            TextBoxOROut.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(TextBoxOROut, "TextBoxOROut");
            TextBoxOROut.Name = "TextBoxOROut";
            TextBoxOROut.ReadOnly = true;
            TextBoxOROut.TabStop = false;
            // 
            // TextBoxInstru_Descrip
            // 
            TextBoxInstru_Descrip.BackColor = SystemColors.ControlLightLight;
            TextBoxInstru_Descrip.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(TextBoxInstru_Descrip, "TextBoxInstru_Descrip");
            TextBoxInstru_Descrip.Name = "TextBoxInstru_Descrip";
            TextBoxInstru_Descrip.ReadOnly = true;
            TextBoxInstru_Descrip.TabStop = false;
            // 
            // Label14
            // 
            resources.ApplyResources(Label14, "Label14");
            Label14.ForeColor = Color.Coral;
            Label14.Name = "Label14";
            // 
            // Label15
            // 
            resources.ApplyResources(Label15, "Label15");
            Label15.ForeColor = Color.Coral;
            Label15.Name = "Label15";
            // 
            // ButtonExit
            // 
            resources.ApplyResources(_ButtonExit, "ButtonExit");
            _ButtonExit.Name = "_ButtonExit";
            _ButtonExit.UseVisualStyleBackColor = true;
            // 
            // ButtonPrintAllRules
            // 
            resources.ApplyResources(_ButtonPrintAllRules, "ButtonPrintAllRules");
            _ButtonPrintAllRules.Name = "_ButtonPrintAllRules";
            _ButtonPrintAllRules.UseVisualStyleBackColor = true;
            // 
            // Label2
            // 
            resources.ApplyResources(Label2, "Label2");
            Label2.Name = "Label2";
            // 
            // TextBoxDemandService
            // 
            TextBoxDemandService.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(TextBoxDemandService, "TextBoxDemandService");
            TextBoxDemandService.Name = "TextBoxDemandService";
            TextBoxDemandService.ReadOnly = true;
            TextBoxDemandService.TabStop = false;
            // 
            // SeparatorControl1
            // 
            SeparatorControl1.LineColor = Color.Gray;
            SeparatorControl1.LineThickness = 2;
            resources.ApplyResources(SeparatorControl1, "SeparatorControl1");
            SeparatorControl1.Name = "SeparatorControl1";
            // 
            // SeparatorControl2
            // 
            SeparatorControl2.LineColor = Color.Gray;
            SeparatorControl2.LineThickness = 2;
            resources.ApplyResources(SeparatorControl2, "SeparatorControl2");
            SeparatorControl2.Name = "SeparatorControl2";
            // 
            // Form_LifeCycle
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ControlBox = false;
            Controls.Add(SeparatorControl2);
            Controls.Add(SeparatorControl1);
            Controls.Add(TextBoxDemandService);
            Controls.Add(Label2);
            Controls.Add(_ButtonPrintAllRules);
            Controls.Add(_ButtonExit);
            Controls.Add(Label15);
            Controls.Add(Label14);
            Controls.Add(TextBoxInstru_Descrip);
            Controls.Add(TextBoxOROut);
            Controls.Add(TextBoxORIn);
            Controls.Add(TextBoxCSSDOut);
            Controls.Add(TextBoxCSSDIn);
            Controls.Add(TextBoxORCounter);
            Controls.Add(TextBoxCSSDCounter);
            Controls.Add(TextBoxreturnService);
            Controls.Add(TextBoxServiceDays);
            Controls.Add(TextBoxNumberService);
            Controls.Add(TextBoxSentService);
            Controls.Add(Label13);
            Controls.Add(Label11);
            Controls.Add(Label12);
            Controls.Add(Label10);
            Controls.Add(Label9);
            Controls.Add(Label8);
            Controls.Add(Label7);
            Controls.Add(Label6);
            Controls.Add(Label5);
            Controls.Add(Label4);
            Controls.Add(Panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form_LifeCycle";
            ShowIcon = false;
            Panel1.ResumeLayout(false);
            Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)SeparatorControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)SeparatorControl2).EndInit();
            Load += new EventHandler(FrmLifeCycle_Load);
            ResumeLayout(false);
            PerformLayout();
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

        internal Label Label4;
        internal Label Label5;
        internal Label Label6;
        internal Label Label7;
        internal Label Label8;
        internal Label Label9;
        internal Label Label10;
        internal Label Label11;
        internal Label Label12;
        internal Label Label13;
        internal TextBox TextBoxSentService;
        internal TextBox TextBoxNumberService;
        internal TextBox TextBoxServiceDays;
        internal TextBox TextBoxreturnService;
        internal TextBox TextBoxCSSDCounter;
        internal TextBox TextBoxORCounter;
        internal TextBox TextBoxCSSDIn;
        internal TextBox TextBoxCSSDOut;
        internal TextBox TextBoxORIn;
        internal TextBox TextBoxOROut;
        internal TextBox TextBoxInstru_Descrip;
        internal Label Label14;
        internal Label Label15;
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

        private Button _ButtonPrintAllRules;

        internal Button ButtonPrintAllRules
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ButtonPrintAllRules;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ButtonPrintAllRules != null)
                {
                    _ButtonPrintAllRules.Click -= ButtonPrintAllRules_Click;
                }

                _ButtonPrintAllRules = value;
                if (_ButtonPrintAllRules != null)
                {
                    _ButtonPrintAllRules.Click += ButtonPrintAllRules_Click;
                }
            }
        }

        internal TextBox TextBoxDemandService;
        internal Label Label2;
        private DevExpress.XtraEditors.SeparatorControl SeparatorControl1;
        private DevExpress.XtraEditors.SeparatorControl SeparatorControl2;
    }
}