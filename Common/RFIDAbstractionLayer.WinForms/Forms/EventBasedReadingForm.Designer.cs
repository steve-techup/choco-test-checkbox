
namespace RFIDAbstractionLayer.WinForms
{
    partial class EventBasedReadingForm
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
            this.SidePanel = new System.Windows.Forms.Panel();
            this.gbSubscription = new System.Windows.Forms.GroupBox();
            this.btnSubscribe = new System.Windows.Forms.Button();
            this.btnUnsubscribe = new System.Windows.Forms.Button();
            this.gbLoadedReaders = new System.Windows.Forms.GroupBox();
            this.listBoxReaders = new System.Windows.Forms.ListBox();
            this.gbReader = new System.Windows.Forms.GroupBox();
            this.powerBar = new UIControls.WinForms.Controls.ReaderPowerBar();
            this.btnUnload = new System.Windows.Forms.Button();
            this.btnLoadReader = new System.Windows.Forms.Button();
            this.cbReaders = new System.Windows.Forms.ComboBox();
            this.lblReader = new System.Windows.Forms.Label();
            this.listViewReadings = new System.Windows.Forms.ListView();
            this.columnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSignal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnOrigin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SidePanel.SuspendLayout();
            this.gbSubscription.SuspendLayout();
            this.gbLoadedReaders.SuspendLayout();
            this.gbReader.SuspendLayout();
            this.SuspendLayout();
            // 
            // SidePanel
            // 
            this.SidePanel.Controls.Add(this.gbSubscription);
            this.SidePanel.Controls.Add(this.gbLoadedReaders);
            this.SidePanel.Controls.Add(this.gbReader);
            this.SidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.SidePanel.Location = new System.Drawing.Point(0, 0);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(264, 815);
            this.SidePanel.TabIndex = 1;
            // 
            // gbSubscription
            // 
            this.gbSubscription.Controls.Add(this.btnSubscribe);
            this.gbSubscription.Controls.Add(this.btnUnsubscribe);
            this.gbSubscription.Enabled = false;
            this.gbSubscription.Location = new System.Drawing.Point(8, 263);
            this.gbSubscription.Name = "gbSubscription";
            this.gbSubscription.Size = new System.Drawing.Size(240, 104);
            this.gbSubscription.TabIndex = 3;
            this.gbSubscription.TabStop = false;
            this.gbSubscription.Text = " Subscription ";
            // 
            // btnSubscribe
            // 
            this.btnSubscribe.Location = new System.Drawing.Point(16, 24);
            this.btnSubscribe.Name = "btnSubscribe";
            this.btnSubscribe.Size = new System.Drawing.Size(208, 32);
            this.btnSubscribe.TabIndex = 5;
            this.btnSubscribe.Text = "Subscribe";
            this.btnSubscribe.UseVisualStyleBackColor = true;
            this.btnSubscribe.Click += new System.EventHandler(this.btnSubscribe_Click);
            // 
            // btnUnsubscribe
            // 
            this.btnUnsubscribe.Enabled = false;
            this.btnUnsubscribe.Location = new System.Drawing.Point(16, 64);
            this.btnUnsubscribe.Name = "btnUnsubscribe";
            this.btnUnsubscribe.Size = new System.Drawing.Size(208, 32);
            this.btnUnsubscribe.TabIndex = 4;
            this.btnUnsubscribe.Text = "Unsubscribe";
            this.btnUnsubscribe.UseVisualStyleBackColor = true;
            this.btnUnsubscribe.Click += new System.EventHandler(this.btnUnsubscribe_Click);
            // 
            // gbLoadedReaders
            // 
            this.gbLoadedReaders.Controls.Add(this.listBoxReaders);
            this.gbLoadedReaders.Location = new System.Drawing.Point(8, 373);
            this.gbLoadedReaders.Name = "gbLoadedReaders";
            this.gbLoadedReaders.Size = new System.Drawing.Size(240, 248);
            this.gbLoadedReaders.TabIndex = 2;
            this.gbLoadedReaders.TabStop = false;
            this.gbLoadedReaders.Text = " Loaded Reader List ";
            // 
            // listBoxReaders
            // 
            this.listBoxReaders.FormattingEnabled = true;
            this.listBoxReaders.ItemHeight = 16;
            this.listBoxReaders.Location = new System.Drawing.Point(8, 24);
            this.listBoxReaders.Name = "listBoxReaders";
            this.listBoxReaders.Size = new System.Drawing.Size(224, 212);
            this.listBoxReaders.TabIndex = 0;
            // 
            // gbReader
            // 
            this.gbReader.Controls.Add(this.powerBar);
            this.gbReader.Controls.Add(this.btnUnload);
            this.gbReader.Controls.Add(this.btnLoadReader);
            this.gbReader.Controls.Add(this.cbReaders);
            this.gbReader.Controls.Add(this.lblReader);
            this.gbReader.Location = new System.Drawing.Point(8, 8);
            this.gbReader.Name = "gbReader";
            this.gbReader.Size = new System.Drawing.Size(240, 249);
            this.gbReader.TabIndex = 1;
            this.gbReader.TabStop = false;
            this.gbReader.Text = " RFID Reader ";
            // 
            // powerBar
            // 
            this.powerBar.Enabled = false;
            this.powerBar.Location = new System.Drawing.Point(16, 168);
            this.powerBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.powerBar.Name = "powerBar";
            this.powerBar.Size = new System.Drawing.Size(195, 69);
            this.powerBar.TabIndex = 4;
            // 
            // btnUnload
            // 
            this.btnUnload.Enabled = false;
            this.btnUnload.Location = new System.Drawing.Point(16, 120);
            this.btnUnload.Name = "btnUnload";
            this.btnUnload.Size = new System.Drawing.Size(208, 32);
            this.btnUnload.TabIndex = 3;
            this.btnUnload.Text = "Unload";
            this.btnUnload.UseVisualStyleBackColor = true;
            this.btnUnload.Click += new System.EventHandler(this.btnUnload_Click_1);
            // 
            // btnLoadReader
            // 
            this.btnLoadReader.Enabled = false;
            this.btnLoadReader.Location = new System.Drawing.Point(16, 80);
            this.btnLoadReader.Name = "btnLoadReader";
            this.btnLoadReader.Size = new System.Drawing.Size(208, 32);
            this.btnLoadReader.TabIndex = 2;
            this.btnLoadReader.Text = "Load Reader";
            this.btnLoadReader.UseVisualStyleBackColor = true;
            this.btnLoadReader.Click += new System.EventHandler(this.btnLoadReader_Click);
            // 
            // cbReaders
            // 
            this.cbReaders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReaders.FormattingEnabled = true;
            this.cbReaders.Items.AddRange(new object[] {
            "CAEN",
            "Impinj",
            "NordicID",
            "Simulator"});
            this.cbReaders.Location = new System.Drawing.Point(16, 48);
            this.cbReaders.Name = "cbReaders";
            this.cbReaders.Size = new System.Drawing.Size(208, 24);
            this.cbReaders.TabIndex = 1;
            this.cbReaders.SelectedIndexChanged += new System.EventHandler(this.cbReaders_SelectedIndexChanged);
            // 
            // lblReader
            // 
            this.lblReader.AutoSize = true;
            this.lblReader.Location = new System.Drawing.Point(16, 24);
            this.lblReader.Name = "lblReader";
            this.lblReader.Size = new System.Drawing.Size(138, 16);
            this.lblReader.TabIndex = 0;
            this.lblReader.Text = "Choose Reader Type";
            // 
            // listViewReadings
            // 
            this.listViewReadings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnType,
            this.columnValue,
            this.columnSignal,
            this.columnOrigin});
            this.listViewReadings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewReadings.HideSelection = false;
            this.listViewReadings.Location = new System.Drawing.Point(264, 0);
            this.listViewReadings.Name = "listViewReadings";
            this.listViewReadings.Size = new System.Drawing.Size(1034, 815);
            this.listViewReadings.TabIndex = 2;
            this.listViewReadings.UseCompatibleStateImageBehavior = false;
            this.listViewReadings.View = System.Windows.Forms.View.Details;
            // 
            // columnType
            // 
            this.columnType.Text = "Reading Type";
            this.columnType.Width = 200;
            // 
            // columnValue
            // 
            this.columnValue.Text = "Value";
            this.columnValue.Width = 200;
            // 
            // columnSignal
            // 
            this.columnSignal.Text = "Signal Strength";
            this.columnSignal.Width = 200;
            // 
            // columnOrigin
            // 
            this.columnOrigin.Text = "Origin Reader";
            this.columnOrigin.Width = 200;
            // 
            // EventBasedReadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 815);
            this.Controls.Add(this.listViewReadings);
            this.Controls.Add(this.SidePanel);
            this.Name = "EventBasedReadingForm";
            this.Text = "EventBasedReadingForm";
            this.SidePanel.ResumeLayout(false);
            this.gbSubscription.ResumeLayout(false);
            this.gbLoadedReaders.ResumeLayout(false);
            this.gbReader.ResumeLayout(false);
            this.gbReader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SidePanel;
        private System.Windows.Forms.GroupBox gbLoadedReaders;
        private System.Windows.Forms.ListBox listBoxReaders;
        private System.Windows.Forms.GroupBox gbReader;
        private System.Windows.Forms.Button btnLoadReader;
        private System.Windows.Forms.ComboBox cbReaders;
        private System.Windows.Forms.Label lblReader;
        private System.Windows.Forms.ListView listViewReadings;
        private System.Windows.Forms.ColumnHeader columnType;
        private System.Windows.Forms.ColumnHeader columnValue;
        private System.Windows.Forms.ColumnHeader columnSignal;
        private System.Windows.Forms.ColumnHeader columnOrigin;
        private System.Windows.Forms.GroupBox gbSubscription;
        private System.Windows.Forms.Button btnSubscribe;
        private System.Windows.Forms.Button btnUnsubscribe;
        private System.Windows.Forms.Button btnUnload;
        private UIControls.WinForms.Controls.ReaderPowerBar powerBar;
    }
}