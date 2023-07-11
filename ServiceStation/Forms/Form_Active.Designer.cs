using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Service_Station
{
    [DesignerGenerated()]
    public partial class Form_Active : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Active));
            this.TextBoxUserName = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.TextBoxPgrName = new System.Windows.Forms.TextBox();
            this._ButtonExit = new System.Windows.Forms.Button();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.BackgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Label3 = new System.Windows.Forms.Label();
            this.LabelSecurity = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBoxUserName
            // 
            this.TextBoxUserName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.TextBoxUserName, "TextBoxUserName");
            this.TextBoxUserName.Name = "TextBoxUserName";
            this.TextBoxUserName.ReadOnly = true;
            // 
            // Label2
            // 
            resources.ApplyResources(this.Label2, "Label2");
            this.Label2.Name = "Label2";
            // 
            // Label1
            // 
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.Name = "Label1";
            // 
            // TextBoxPgrName
            // 
            this.TextBoxPgrName.BackColor = System.Drawing.Color.White;
            this.TextBoxPgrName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.TextBoxPgrName, "TextBoxPgrName");
            this.TextBoxPgrName.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.TextBoxPgrName.Name = "TextBoxPgrName";
            this.TextBoxPgrName.ReadOnly = true;
            this.TextBoxPgrName.TabStop = false;
            // 
            // _ButtonExit
            // 
            resources.ApplyResources(this._ButtonExit, "_ButtonExit");
            this._ButtonExit.Name = "_ButtonExit";
            this._ButtonExit.TabStop = false;
            this._ButtonExit.UseVisualStyleBackColor = true;
            this._ButtonExit.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = global::Service_Station.My.Resources.Resources.Knowledge_Hub_logo;
            resources.ApplyResources(this.PictureBox1, "PictureBox1");
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.TabStop = false;
            // 
            // BackgroundWorker1
            // 
            this.BackgroundWorker1.WorkerReportsProgress = true;
            this.BackgroundWorker1.WorkerSupportsCancellation = true;
            // 
            // Label3
            // 
            resources.ApplyResources(this.Label3, "Label3");
            this.Label3.ForeColor = System.Drawing.Color.Red;
            this.Label3.Name = "Label3";
            // 
            // LabelSecurity
            // 
            resources.ApplyResources(this.LabelSecurity, "LabelSecurity");
            this.LabelSecurity.ForeColor = System.Drawing.Color.Gainsboro;
            this.LabelSecurity.Name = "LabelSecurity";
            // 
            // Form_Active
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ControlBox = false;
            this.Controls.Add(this.LabelSecurity);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this._ButtonExit);
            this.Controls.Add(this.TextBoxPgrName);
            this.Controls.Add(this.TextBoxUserName);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Name = "Form_Active";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        internal TextBox TextBoxUserName;
        internal Label Label2;
        internal Label Label1;
        internal TextBox TextBoxPgrName;
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
                    _ButtonExit.Click -= ButtonCancel_Click;
                }

                _ButtonExit = value;
                if (_ButtonExit != null)
                {
                    _ButtonExit.Click += ButtonCancel_Click;
                }
            }
        }

        internal PictureBox PictureBox1;
        internal System.ComponentModel.BackgroundWorker BackgroundWorker1;
        internal Label Label3;
        internal Label LabelSecurity;
        // Friend WithEvents Label3 As Label
    }
}