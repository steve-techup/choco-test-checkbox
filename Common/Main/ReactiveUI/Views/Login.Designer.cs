namespace Main.ReactiveUI.Views
{
    partial class Login
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOSK1 = new UIControls.WinForms.Controls.BtnOSK();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.loginButton = new DevExpress.XtraEditors.SimpleButton();
            this.exitButton = new DevExpress.XtraEditors.SimpleButton();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.TextBoxUserName = new System.Windows.Forms.TextBox();
            this.TextBoxPassword = new System.Windows.Forms.TextBox();
            this.LabelErrorMessage = new System.Windows.Forms.Label();
            this.TextBoxTitle = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnOSK1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.loginButton);
            this.panel1.Controls.Add(this.exitButton);
            this.panel1.Controls.Add(this.Label2);
            this.panel1.Controls.Add(this.Label1);
            this.panel1.Controls.Add(this.TextBoxUserName);
            this.panel1.Controls.Add(this.TextBoxPassword);
            this.panel1.Controls.Add(this.LabelErrorMessage);
            this.panel1.Controls.Add(this.TextBoxTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(821, 436);
            this.panel1.TabIndex = 123;
            // 
            // btnOSK1
            // 
            this.btnOSK1.Location = new System.Drawing.Point(688, 352);
            this.btnOSK1.Margin = new System.Windows.Forms.Padding(4);
            this.btnOSK1.Name = "btnOSK1";
            this.btnOSK1.Size = new System.Drawing.Size(72, 49);
            this.btnOSK1.TabIndex = 132;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Caretag_Class.My.Resources.Resources.caretag_logo;
            this.pictureBox1.Location = new System.Drawing.Point(48, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 104);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 131;
            this.pictureBox1.TabStop = false;
            // 
            // loginButton
            // 
            this.loginButton.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.Appearance.Options.UseFont = true;
            this.loginButton.Location = new System.Drawing.Point(304, 352);
            this.loginButton.Margin = new System.Windows.Forms.Padding(6);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(212, 48);
            this.loginButton.TabIndex = 130;
            this.loginButton.Text = "Login";
            // 
            // exitButton
            // 
            this.exitButton.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Appearance.Options.UseFont = true;
            this.exitButton.Location = new System.Drawing.Point(48, 352);
            this.exitButton.Margin = new System.Windows.Forms.Padding(6);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(80, 48);
            this.exitButton.TabIndex = 129;
            this.exitButton.Text = "Exit";
            // 
            // Label2
            // 
            this.Label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label2.Location = new System.Drawing.Point(246, 203);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(98, 25);
            this.Label2.TabIndex = 127;
            this.Label2.Text = "Password";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label1
            // 
            this.Label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label1.Location = new System.Drawing.Point(246, 115);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(102, 25);
            this.Label1.TabIndex = 123;
            this.Label1.Text = "Username";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TextBoxUserName
            // 
            this.TextBoxUserName.AcceptsReturn = true;
            this.TextBoxUserName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextBoxUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.TextBoxUserName.Location = new System.Drawing.Point(246, 139);
            this.TextBoxUserName.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxUserName.Name = "TextBoxUserName";
            this.TextBoxUserName.Size = new System.Drawing.Size(336, 38);
            this.TextBoxUserName.TabIndex = 124;
            this.TextBoxUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextBoxPassword
            // 
            this.TextBoxPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.TextBoxPassword.Location = new System.Drawing.Point(246, 227);
            this.TextBoxPassword.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.Size = new System.Drawing.Size(336, 38);
            this.TextBoxPassword.TabIndex = 125;
            this.TextBoxPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxPassword.UseSystemPasswordChar = true;
            // 
            // LabelErrorMessage
            // 
            this.LabelErrorMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelErrorMessage.AutoSize = true;
            this.LabelErrorMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.LabelErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.LabelErrorMessage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LabelErrorMessage.Location = new System.Drawing.Point(216, 283);
            this.LabelErrorMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.LabelErrorMessage.Name = "LabelErrorMessage";
            this.LabelErrorMessage.Size = new System.Drawing.Size(415, 36);
            this.LabelErrorMessage.TabIndex = 128;
            this.LabelErrorMessage.Text = "Wrong username or password";
            this.LabelErrorMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LabelErrorMessage.Visible = false;
            // 
            // TextBoxTitle
            // 
            this.TextBoxTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextBoxTitle.BackColor = System.Drawing.Color.White;
            this.TextBoxTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxTitle.Enabled = false;
            this.TextBoxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.TextBoxTitle.ForeColor = System.Drawing.Color.Black;
            this.TextBoxTitle.Location = new System.Drawing.Point(216, 41);
            this.TextBoxTitle.Margin = new System.Windows.Forms.Padding(0);
            this.TextBoxTitle.Name = "TextBoxTitle";
            this.TextBoxTitle.ReadOnly = true;
            this.TextBoxTitle.Size = new System.Drawing.Size(400, 38);
            this.TextBoxTitle.TabIndex = 126;
            this.TextBoxTitle.TabStop = false;
            this.TextBoxTitle.Text = "Welcome to Caretag";
            this.TextBoxTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(821, 436);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.SimpleButton loginButton;
        private DevExpress.XtraEditors.SimpleButton exitButton;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox TextBoxUserName;
        private System.Windows.Forms.TextBox TextBoxPassword;
        internal System.Windows.Forms.Label LabelErrorMessage;
        internal System.Windows.Forms.TextBox TextBoxTitle;
        private UIControls.WinForms.Controls.BtnOSK btnOSK1;
    }
}