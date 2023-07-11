using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Caretag_Class.Forms
{
    [DesignerGenerated()]
    public partial class LoginForm : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this._TextBoxPassword = new System.Windows.Forms.TextBox();
            this._TextBoxUserName = new System.Windows.Forms.TextBox();
            this._PictureBox1 = new System.Windows.Forms.PictureBox();
            this._BtnExit = new System.Windows.Forms.Button();
            this._ButtonLogin = new System.Windows.Forms.Button();
            this.Label_Message = new System.Windows.Forms.Label();
            this.TextBoxPgrName = new System.Windows.Forms.TextBox();
            this.btnOSK = new UIControls.WinForms.Controls.BtnOSK();
            this._BackgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.kbdImgList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Label2
            // 
            resources.ApplyResources(this.Label2, "Label2");
            this.Label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.Label2.Name = "Label2";
            // 
            // Label1
            // 
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.Label1.Name = "Label1";
            // 
            // _TextBoxPassword
            // 
            resources.ApplyResources(this._TextBoxPassword, "_TextBoxPassword");
            this._TextBoxPassword.Name = "_TextBoxPassword";
            this._TextBoxPassword.UseSystemPasswordChar = true;
            this._TextBoxPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxPassword_KeyPress);
            this._TextBoxPassword.LostFocus += new System.EventHandler(this.TextBoxPassword_LostFocus);
            // 
            // _TextBoxUserName
            // 
            this._TextBoxUserName.AcceptsReturn = true;
            resources.ApplyResources(this._TextBoxUserName, "_TextBoxUserName");
            this._TextBoxUserName.Name = "_TextBoxUserName";
            this._TextBoxUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxUserName_KeyPress);
            // 
            // _PictureBox1
            // 
            resources.ApplyResources(this._PictureBox1, "_PictureBox1");
            this._PictureBox1.Image = global::Caretag_Class.My.Resources.Resources.CaretagClassicLogo;
            this._PictureBox1.Name = "_PictureBox1";
            this._PictureBox1.TabStop = false;
            this._PictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // _BtnExit
            // 
            resources.ApplyResources(this._BtnExit, "_BtnExit");
            this._BtnExit.Name = "_BtnExit";
            this._BtnExit.TabStop = false;
            this._BtnExit.UseVisualStyleBackColor = true;
            this._BtnExit.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // _ButtonLogin
            // 
            resources.ApplyResources(this._ButtonLogin, "_ButtonLogin");
            this._ButtonLogin.ForeColor = System.Drawing.Color.Black;
            this._ButtonLogin.Name = "_ButtonLogin";
            this._ButtonLogin.UseVisualStyleBackColor = true;
            this._ButtonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // Label_Message
            // 
            resources.ApplyResources(this.Label_Message, "Label_Message");
            this.Label_Message.ForeColor = System.Drawing.Color.Red;
            this.Label_Message.Name = "Label_Message";
            // 
            // TextBoxPgrName
            // 
            resources.ApplyResources(this.TextBoxPgrName, "TextBoxPgrName");
            this.TextBoxPgrName.BackColor = System.Drawing.Color.White;
            this.TextBoxPgrName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxPgrName.ForeColor = System.Drawing.Color.Navy;
            this.TextBoxPgrName.Name = "TextBoxPgrName";
            this.TextBoxPgrName.ReadOnly = true;
            this.TextBoxPgrName.TabStop = false;
            // 
            // btnOSK
            // 
            resources.ApplyResources(this.btnOSK, "btnOSK");
            this.btnOSK.Name = "btnOSK";
            // 
            // _BackgroundWorker1
            // 
            this._BackgroundWorker1.WorkerReportsProgress = true;
            this._BackgroundWorker1.WorkerSupportsCancellation = true;
            this._BackgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            this._BackgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker1_progress);
            this._BackgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker1_RunWorkerCompleted);
            // 
            // kbdImgList
            // 
            this.kbdImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.kbdImgList, "kbdImgList");
            this.kbdImgList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Frm_Login
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ControlBox = false;
            this.Controls.Add(this._PictureBox1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this._TextBoxUserName);
            this.Controls.Add(this._TextBoxPassword);
            this.Controls.Add(this._ButtonLogin);
            this.Controls.Add(this._BtnExit);
            this.Controls.Add(this.Label_Message);
            this.Controls.Add(this.TextBoxPgrName);
            this.Controls.Add(this.btnOSK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LoginForm";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this._PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox _TextBoxPassword;

        internal System.Windows.Forms.TextBox TextBoxPassword
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBoxPassword;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBoxPassword != null)
                {
                    _TextBoxPassword.KeyPress -= TextBoxPassword_KeyPress;
                    _TextBoxPassword.LostFocus -= TextBoxPassword_LostFocus;
                }

                _TextBoxPassword = value;
                if (_TextBoxPassword != null)
                {
                    _TextBoxPassword.KeyPress += TextBoxPassword_KeyPress;
                    _TextBoxPassword.LostFocus += TextBoxPassword_LostFocus;
                }
            }
        }

        private System.Windows.Forms.TextBox _TextBoxUserName;

        internal System.Windows.Forms.TextBox TextBoxUserName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBoxUserName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBoxUserName != null)
                {
                    _TextBoxUserName.KeyPress -= TextBoxUserName_KeyPress;
                }

                _TextBoxUserName = value;
                if (_TextBoxUserName != null)
                {
                    _TextBoxUserName.KeyPress += TextBoxUserName_KeyPress;
                }
            }
        }

        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox TextBoxPgrName;

        internal System.Windows.Forms.Button ButtonLogin
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ButtonLogin;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ButtonLogin != null)
                {
                    _ButtonLogin.Click -= ButtonLogin_Click;
                }

                _ButtonLogin = value;
                if (_ButtonLogin != null)
                {
                    _ButtonLogin.Click += ButtonLogin_Click;
                }
            }
        }

        internal System.Windows.Forms.Button ButtonCancel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BtnExit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_BtnExit != null)
                {
                    _BtnExit.Click -= ButtonCancel_Click;
                }

                _BtnExit = value;
                if (_BtnExit != null)
                {
                    _BtnExit.Click += ButtonCancel_Click;
                }
            }
        }

        private System.Windows.Forms.PictureBox _PictureBox1;

        internal System.Windows.Forms.PictureBox PictureBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PictureBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PictureBox1 != null)
                {
                    _PictureBox1.Click -= PictureBox1_Click;
                }

                _PictureBox1 = value;
                if (_PictureBox1 != null)
                {
                    _PictureBox1.Click += PictureBox1_Click;
                }
            }
        }
        private System.ComponentModel.BackgroundWorker _BackgroundWorker1;

        internal System.ComponentModel.BackgroundWorker BackgroundWorker1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BackgroundWorker1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_BackgroundWorker1 != null)
                {
                    _BackgroundWorker1.ProgressChanged -= BackgroundWorker1_progress;
                    _BackgroundWorker1.DoWork -= BackgroundWorker1_DoWork;
                    _BackgroundWorker1.RunWorkerCompleted -= BackgroundWorker1_RunWorkerCompleted;
                }

                _BackgroundWorker1 = value;
                if (_BackgroundWorker1 != null)
                {
                    _BackgroundWorker1.ProgressChanged += BackgroundWorker1_progress;
                    _BackgroundWorker1.DoWork += BackgroundWorker1_DoWork;
                    _BackgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
                }
            }
        }

        internal System.Windows.Forms.Label Label_Message;
        private System.Windows.Forms.ImageList kbdImgList;
        private UIControls.WinForms.Controls.BtnOSK btnOSK;
        private System.Windows.Forms.Button _BtnExit;
        private System.Windows.Forms.Button _ButtonLogin;
        // Friend WithEvents Label3 As Label
    }
}