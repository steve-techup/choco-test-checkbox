using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Service_Station
{
    [DesignerGenerated()]
    public partial class Form_Exit : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Exit));
            this.Label1 = new System.Windows.Forms.Label();
            this._ButtonLogOut = new System.Windows.Forms.Button();
            this._ButtonShutDown = new System.Windows.Forms.Button();
            this.TextBoxUserName = new System.Windows.Forms.TextBox();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.Label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.Name = "Label1";
            // 
            // _ButtonLogOut
            // 
            resources.ApplyResources(this._ButtonLogOut, "_ButtonLogOut");
            this._ButtonLogOut.ForeColor = System.Drawing.Color.Teal;
            this._ButtonLogOut.Name = "_ButtonLogOut";
            this._ButtonLogOut.Tag = "            ";
            this._ButtonLogOut.UseVisualStyleBackColor = true;
            this._ButtonLogOut.Click += new System.EventHandler(this.ButtonLogOut_Click);
            // 
            // _ButtonShutDown
            // 
            resources.ApplyResources(this._ButtonShutDown, "_ButtonShutDown");
            this._ButtonShutDown.ForeColor = System.Drawing.Color.Coral;
            this._ButtonShutDown.Name = "_ButtonShutDown";
            this._ButtonShutDown.Tag = "";
            this._ButtonShutDown.UseVisualStyleBackColor = true;
            this._ButtonShutDown.Click += new System.EventHandler(this.ButtonShutDown_Click);
            // 
            // TextBoxUserName
            // 
            resources.ApplyResources(this.TextBoxUserName, "TextBoxUserName");
            this.TextBoxUserName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TextBoxUserName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TextBoxUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxUserName.Name = "TextBoxUserName";
            this.TextBoxUserName.ReadOnly = true;
            // 
            // PictureBox1
            // 
            resources.ApplyResources(this.PictureBox1, "PictureBox1");
            this.PictureBox1.Image = global::Service_Station.My.Resources.Resources.GareTag_Logo_Transfer;
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.TabStop = false;
            // 
            // Label2
            // 
            resources.ApplyResources(this.Label2, "Label2");
            this.Label2.ForeColor = System.Drawing.Color.Teal;
            this.Label2.Name = "Label2";
            // 
            // Form_Exit
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ControlBox = false;
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.TextBoxUserName);
            this.Controls.Add(this._ButtonShutDown);
            this.Controls.Add(this._ButtonLogOut);
            this.Controls.Add(this.Label1);
            this.Name = "Form_Exit";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frm_Exit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        internal Label Label1;
        private Button _ButtonLogOut;

        internal Button ButtonLogOut
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ButtonLogOut;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ButtonLogOut != null)
                {
                    _ButtonLogOut.Click -= ButtonLogOut_Click;
                }

                _ButtonLogOut = value;
                if (_ButtonLogOut != null)
                {
                    _ButtonLogOut.Click += ButtonLogOut_Click;
                }
            }
        }

        private Button _ButtonShutDown;

        internal Button ButtonShutDown
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ButtonShutDown;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ButtonShutDown != null)
                {
                    _ButtonShutDown.Click -= ButtonShutDown_Click;
                }

                _ButtonShutDown = value;
                if (_ButtonShutDown != null)
                {
                    _ButtonShutDown.Click += ButtonShutDown_Click;
                }
            }
        }

        internal TextBox TextBoxUserName;
        internal PictureBox PictureBox1;
        internal Label Label2;
    }
}