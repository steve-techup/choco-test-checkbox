namespace CheckboxStation
{
    partial class InstrumentList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstrumentList));
            this.Panel1 = new System.Windows.Forms.Panel();
            this._TopTitle = new System.Windows.Forms.Label();
            this.assetScanListView = new System.Windows.Forms.ListView();
            this.type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.operationLabel = new System.Windows.Forms.Label();
            this.operationDataLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.amountColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
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
            // assetScanListView
            // 
            this.assetScanListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.amountColumn,
            this.type,
            this.description,
            this.status});
            resources.ApplyResources(this.assetScanListView, "assetScanListView");
            this.assetScanListView.HideSelection = false;
            this.assetScanListView.Name = "assetScanListView";
            this.assetScanListView.ShowGroups = false;
            this.assetScanListView.UseCompatibleStateImageBehavior = false;
            this.assetScanListView.View = System.Windows.Forms.View.Details;
            // 
            // type
            // 
            resources.ApplyResources(this.type, "type");
            // 
            // description
            // 
            resources.ApplyResources(this.description, "description");
            // 
            // status
            // 
            resources.ApplyResources(this.status, "status");
            // 
            // operationLabel
            // 
            resources.ApplyResources(this.operationLabel, "operationLabel");
            this.operationLabel.Name = "operationLabel";
            // 
            // operationDataLabel
            // 
            resources.ApplyResources(this.operationDataLabel, "operationDataLabel");
            this.operationDataLabel.Name = "operationDataLabel";
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // amountColumn
            // 
            resources.ApplyResources(this.amountColumn, "amountColumn");
            // 
            // InstrumentList
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.operationDataLabel);
            this.Controls.Add(this.operationLabel);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.assetScanListView);
            this.Name = "InstrumentList";
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.Label _TopTitle;
        private System.Windows.Forms.ListView assetScanListView;
        private System.Windows.Forms.ColumnHeader type;
        private System.Windows.Forms.ColumnHeader description;
        private System.Windows.Forms.ColumnHeader status;
        private System.Windows.Forms.Label operationLabel;
        private System.Windows.Forms.Label operationDataLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ColumnHeader amountColumn;
    }
}

