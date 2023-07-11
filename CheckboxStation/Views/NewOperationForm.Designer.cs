namespace CheckboxStation.Views
{
    partial class NewOperationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewOperationForm));
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this._TopTitle = new System.Windows.Forms.Label();
            this.operationIdTextBox = new System.Windows.Forms.TextBox();
            this.operationIdLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.operatingRoomTextbox = new System.Windows.Forms.TextBox();
            this.btnOSK1 = new UIControls.WinForms.Controls.BtnOSK();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.DarkOrange;
            this.Panel1.Controls.Add(this._TopTitle);
            resources.ApplyResources(this.Panel1, "Panel1");
            this.Panel1.Name = "Panel1";
            // 
            // _TopTitle
            // 
            resources.ApplyResources(this._TopTitle, "_TopTitle");
            this._TopTitle.BackColor = System.Drawing.Color.Transparent;
            this._TopTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this._TopTitle.Name = "_TopTitle";
            // 
            // operationIdTextBox
            // 
            resources.ApplyResources(this.operationIdTextBox, "operationIdTextBox");
            this.operationIdTextBox.Name = "operationIdTextBox";
            // 
            // operationIdLabel
            // 
            resources.ApplyResources(this.operationIdLabel, "operationIdLabel");
            this.operationIdLabel.Name = "operationIdLabel";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // operatingRoomTextbox
            // 
            resources.ApplyResources(this.operatingRoomTextbox, "operatingRoomTextbox");
            this.operatingRoomTextbox.Name = "operatingRoomTextbox";
            // 
            // btnOSK1
            // 
            resources.ApplyResources(this.btnOSK1, "btnOSK1");
            this.btnOSK1.Name = "btnOSK1";
            // 
            // NewOperationForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.operatingRoomTextbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.operationIdLabel);
            this.Controls.Add(this.btnOSK1);
            this.Controls.Add(this.operationIdTextBox);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewOperationForm";
            this.ShowInTaskbar = false;
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        internal System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.Label _TopTitle;
        private UIControls.WinForms.Controls.BtnOSK btnOSK1;
        private System.Windows.Forms.Label operationIdLabel;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox operationIdTextBox;
        internal System.Windows.Forms.TextBox operatingRoomTextbox;
    }
}