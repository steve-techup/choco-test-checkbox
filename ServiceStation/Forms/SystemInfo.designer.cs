using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Service_Station
{
    [DesignerGenerated()]
    public partial class SystemInfo : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemInfo));
            this.OSSystem = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.TextBox();
            this.LatestVersion = new System.Windows.Forms.TextBox();
            this.MachineName = new System.Windows.Forms.TextBox();
            this.SystemFolder = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this._TopTitle = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.DataBase = new System.Windows.Forms.TextBox();
            this.State = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.ServerVersion = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.DriverText = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.Button1 = new System.Windows.Forms.Button();
            this.PrintForm1 = new Microsoft.VisualBasic.PowerPacks.Printing.PrintForm(this.components);
            this.Label2 = new System.Windows.Forms.Label();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.TextBoxLanguage = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // OSSystem
            // 
            resources.ApplyResources(this.OSSystem, "OSSystem");
            this.OSSystem.Name = "OSSystem";
            // 
            // Label1
            // 
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.Name = "Label1";
            // 
            // UserName
            // 
            resources.ApplyResources(this.UserName, "UserName");
            this.UserName.Name = "UserName";
            // 
            // LatestVersion
            // 
            resources.ApplyResources(this.LatestVersion, "LatestVersion");
            this.LatestVersion.ForeColor = System.Drawing.Color.OrangeRed;
            this.LatestVersion.Name = "LatestVersion";
            // 
            // MachineName
            // 
            resources.ApplyResources(this.MachineName, "MachineName");
            this.MachineName.Name = "MachineName";
            // 
            // SystemFolder
            // 
            resources.ApplyResources(this.SystemFolder, "SystemFolder");
            this.SystemFolder.Name = "SystemFolder";
            // 
            // Label4
            // 
            resources.ApplyResources(this.Label4, "Label4");
            this.Label4.Name = "Label4";
            // 
            // Label6
            // 
            resources.ApplyResources(this.Label6, "Label6");
            this.Label6.Name = "Label6";
            // 
            // Label7
            // 
            resources.ApplyResources(this.Label7, "Label7");
            this.Label7.Name = "Label7";
            // 
            // _TopTitle
            // 
            resources.ApplyResources(this._TopTitle, "_TopTitle");
            this._TopTitle.Name = "_TopTitle";
            this._TopTitle.Click += new System.EventHandler(this.TopTitle_Click);
            // 
            // Label3
            // 
            resources.ApplyResources(this.Label3, "Label3");
            this.Label3.Name = "Label3";
            // 
            // DataBase
            // 
            resources.ApplyResources(this.DataBase, "DataBase");
            this.DataBase.Name = "DataBase";
            // 
            // State
            // 
            resources.ApplyResources(this.State, "State");
            this.State.ForeColor = System.Drawing.Color.OrangeRed;
            this.State.Name = "State";
            // 
            // Label9
            // 
            resources.ApplyResources(this.Label9, "Label9");
            this.Label9.Name = "Label9";
            // 
            // Label10
            // 
            resources.ApplyResources(this.Label10, "Label10");
            this.Label10.Name = "Label10";
            // 
            // ServerVersion
            // 
            resources.ApplyResources(this.ServerVersion, "ServerVersion");
            this.ServerVersion.Name = "ServerVersion";
            // 
            // Label5
            // 
            resources.ApplyResources(this.Label5, "Label5");
            this.Label5.Name = "Label5";
            // 
            // DriverText
            // 
            resources.ApplyResources(this.DriverText, "DriverText");
            this.DriverText.Name = "DriverText";
            // 
            // Label8
            // 
            resources.ApplyResources(this.Label8, "Label8");
            this.Label8.Name = "Label8";
            // 
            // Button1
            // 
            resources.ApplyResources(this.Button1, "Button1");
            this.Button1.Name = "Button1";
            this.Button1.UseVisualStyleBackColor = true;
            // 
            // PrintForm1
            // 
            this.PrintForm1.DocumentName = "document";
            this.PrintForm1.Form = this;
            this.PrintForm1.PrintAction = System.Drawing.Printing.PrintAction.PrintToPrinter;
            this.PrintForm1.PrinterSettings = ((System.Drawing.Printing.PrinterSettings)(resources.GetObject("PrintForm1.PrinterSettings")));
            this.PrintForm1.PrintFileName = null;
            // 
            // Label2
            // 
            resources.ApplyResources(this.Label2, "Label2");
            this.Label2.ForeColor = System.Drawing.Color.Silver;
            this.Label2.Name = "Label2";
            // 
            // PictureBox2
            // 
            this.PictureBox2.Image = global::Service_Station.My.Resources.Resources.Knowledge_Hub_logo;
            resources.ApplyResources(this.PictureBox2, "PictureBox2");
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.TabStop = false;
            // 
            // TextBoxLanguage
            // 
            resources.ApplyResources(this.TextBoxLanguage, "TextBoxLanguage");
            this.TextBoxLanguage.Name = "TextBoxLanguage";
            // 
            // Label11
            // 
            resources.ApplyResources(this.Label11, "Label11");
            this.Label11.Name = "Label11";
            // 
            // SystemInfo
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.TextBoxLanguage);
            this.Controls.Add(this.PictureBox2);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.DriverText);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.ServerVersion);
            this.Controls.Add(this.Label10);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.State);
            this.Controls.Add(this.DataBase);
            this.Controls.Add(this._TopTitle);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.SystemFolder);
            this.Controls.Add(this.MachineName);
            this.Controls.Add(this.LatestVersion);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.OSSystem);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SystemInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.SystemInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        internal TextBox OSSystem;
        internal Label Label1;
        internal TextBox UserName;
        internal TextBox LatestVersion;
        internal TextBox MachineName;
        internal TextBox SystemFolder;
        internal Label Label4;
        internal Label Label6;
        internal Label Label7;
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

        internal Label Label3;
        internal TextBox DataBase;
        internal TextBox State;
        internal Label Label9;
        internal Label Label10;
        internal TextBox ServerVersion;
        internal Label Label5;
        internal TextBox DriverText;
        internal Label Label8;
        internal Button Button1;
        internal Microsoft.VisualBasic.PowerPacks.Printing.PrintForm PrintForm1;
        internal Label Label2;
        internal PictureBox PictureBox2;
        internal Label Label11;
        internal TextBox TextBoxLanguage;
    }
}