namespace CheckboxStation
{
    partial class CheckInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckInForm));
            this.operationComboBox = new System.Windows.Forms.ComboBox();
            this.Panel1 = new System.Windows.Forms.Panel();
            this._TopTitle = new System.Windows.Forms.Label();
            this.mainLabel = new System.Windows.Forms.Label();
            this.operationLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // operationComboBox
            // 
            this.operationComboBox.DisplayMember = "OperationId";
            this.operationComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.operationComboBox, "operationComboBox");
            this.operationComboBox.Name = "operationComboBox";
            this.operationComboBox.ValueMember = "Id";
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
            // mainLabel
            // 
            resources.ApplyResources(this.mainLabel, "mainLabel");
            this.mainLabel.Name = "mainLabel";
            // 
            // operationLabel
            // 
            resources.ApplyResources(this.operationLabel, "operationLabel");
            this.operationLabel.Name = "operationLabel";
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
            // statusLabel
            // 
            resources.ApplyResources(this.statusLabel, "statusLabel");
            this.statusLabel.Name = "statusLabel";
            // 
            // CheckInForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.operationLabel);
            this.Controls.Add(this.mainLabel);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.operationComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CheckInForm";
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox operationComboBox;
        internal System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.Label _TopTitle;
        private System.Windows.Forms.Label mainLabel;
        private System.Windows.Forms.Label operationLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label statusLabel;
    }
}