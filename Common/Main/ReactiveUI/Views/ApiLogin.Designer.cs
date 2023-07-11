namespace Main.ReactiveUI.Views
{
    partial class ApiLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApiLogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.errorMessageLabel = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.loginButton = new DevExpress.XtraEditors.SimpleButton();
            this.exitButton = new DevExpress.XtraEditors.SimpleButton();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.TextBoxUserName = new System.Windows.Forms.TextBox();
            this.TextBoxPassword = new System.Windows.Forms.TextBox();
            this.TextBoxTitle = new System.Windows.Forms.TextBox();
            this.btnOSK1 = new UIControls.WinForms.Controls.BtnOSK();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.errorMessageLabel);
            this.panel1.Controls.Add(this.btnOSK1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.loginButton);
            this.panel1.Controls.Add(this.exitButton);
            this.panel1.Controls.Add(this.Label2);
            this.panel1.Controls.Add(this.Label1);
            this.panel1.Controls.Add(this.TextBoxUserName);
            this.panel1.Controls.Add(this.TextBoxPassword);
            this.panel1.Controls.Add(this.TextBoxTitle);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.TabStop = false;
            // 
            // errorMessageLabel
            // 
            this.errorMessageLabel.BackColor = System.Drawing.Color.White;
            this.errorMessageLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorMessageLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            resources.ApplyResources(this.errorMessageLabel, "errorMessageLabel");
            this.errorMessageLabel.ForeColor = System.Drawing.Color.Red;
            this.errorMessageLabel.Name = "errorMessageLabel";
            this.errorMessageLabel.ReadOnly = true;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // loginButton
            // 
            this.loginButton.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("loginButton.Appearance.Font")));
            this.loginButton.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.loginButton, "loginButton");
            this.loginButton.Name = "loginButton";
            // 
            // exitButton
            // 
            this.exitButton.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("exitButton.Appearance.Font")));
            this.exitButton.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.exitButton, "exitButton");
            this.exitButton.Name = "exitButton";
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
            // TextBoxUserName
            // 
            this.TextBoxUserName.AcceptsReturn = true;
            resources.ApplyResources(this.TextBoxUserName, "TextBoxUserName");
            this.TextBoxUserName.Name = "TextBoxUserName";
            // 
            // TextBoxPassword
            // 
            resources.ApplyResources(this.TextBoxPassword, "TextBoxPassword");
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.UseSystemPasswordChar = true;
            // 
            // TextBoxTitle
            // 
            resources.ApplyResources(this.TextBoxTitle, "TextBoxTitle");
            this.TextBoxTitle.BackColor = System.Drawing.Color.White;
            this.TextBoxTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxTitle.ForeColor = System.Drawing.Color.Black;
            this.TextBoxTitle.Name = "TextBoxTitle";
            this.TextBoxTitle.ReadOnly = true;
            this.TextBoxTitle.TabStop = false;
            // 
            // btnOSK1
            // 
            resources.ApplyResources(this.btnOSK1, "btnOSK1");
            this.btnOSK1.Name = "btnOSK1";
            // 
            // ApiLogin
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ApiLogin";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private UIControls.WinForms.Controls.BtnOSK btnOSK1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.SimpleButton loginButton;
        private DevExpress.XtraEditors.SimpleButton exitButton;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox TextBoxUserName;
        private System.Windows.Forms.TextBox TextBoxPassword;
        internal System.Windows.Forms.TextBox TextBoxTitle;
        private System.Windows.Forms.TextBox errorMessageLabel;
        internal System.Windows.Forms.TextBox textBox1;
    }
}