
namespace RFIDAbstractionLayer.WinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sidePanel = new System.Windows.Forms.Panel();
            this.btnEventReading = new System.Windows.Forms.Button();
            this.btnImpinjTester = new System.Windows.Forms.Button();
            this.readerPowerBar = new UIControls.WinForms.Controls.ReaderPowerBar();
            this.gbWriteTag = new System.Windows.Forms.GroupBox();
            this.btnOpenWriteDialog = new System.Windows.Forms.Button();
            this.groupMulti = new System.Windows.Forms.GroupBox();
            this.cbUseSimulator = new System.Windows.Forms.CheckBox();
            this.btnAllReaders = new System.Windows.Forms.Button();
            this.createGroupBox = new System.Windows.Forms.GroupBox();
            this.btnForceReaderType = new System.Windows.Forms.Button();
            this.readerTypeBox = new System.Windows.Forms.ComboBox();
            this.forceReaderLbl = new System.Windows.Forms.Label();
            this.readTagsGroup = new System.Windows.Forms.GroupBox();
            this.btnReadTag = new System.Windows.Forms.Button();
            this.readerListView = new System.Windows.Forms.ListView();
            this.brandColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.modelColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tagListView = new System.Windows.Forms.ListView();
            this.columnRaw = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnEPC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSEQ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.sidePanel.SuspendLayout();
            this.gbWriteTag.SuspendLayout();
            this.groupMulti.SuspendLayout();
            this.createGroupBox.SuspendLayout();
            this.readTagsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidePanel
            // 
            this.sidePanel.Controls.Add(this.btnEventReading);
            this.sidePanel.Controls.Add(this.btnImpinjTester);
            this.sidePanel.Controls.Add(this.readerPowerBar);
            this.sidePanel.Controls.Add(this.gbWriteTag);
            this.sidePanel.Controls.Add(this.groupMulti);
            this.sidePanel.Controls.Add(this.createGroupBox);
            this.sidePanel.Controls.Add(this.readTagsGroup);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Margin = new System.Windows.Forms.Padding(4);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(244, 746);
            this.sidePanel.TabIndex = 0;
            // 
            // btnEventReading
            // 
            this.btnEventReading.Location = new System.Drawing.Point(24, 648);
            this.btnEventReading.Name = "btnEventReading";
            this.btnEventReading.Size = new System.Drawing.Size(200, 40);
            this.btnEventReading.TabIndex = 12;
            this.btnEventReading.Text = "Event Based reading";
            this.btnEventReading.UseVisualStyleBackColor = true;
            // 
            // btnImpinjTester
            // 
            this.btnImpinjTester.Location = new System.Drawing.Point(24, 696);
            this.btnImpinjTester.Name = "btnImpinjTester";
            this.btnImpinjTester.Size = new System.Drawing.Size(200, 39);
            this.btnImpinjTester.TabIndex = 11;
            this.btnImpinjTester.Text = "Open Impinj Tester";
            this.btnImpinjTester.UseVisualStyleBackColor = true;
            this.btnImpinjTester.Click += new System.EventHandler(this.btnImpinjTester_Click);
            // 
            // readerPowerBar
            // 
            this.readerPowerBar.Location = new System.Drawing.Point(11, 286);
            this.readerPowerBar.Margin = new System.Windows.Forms.Padding(5);
            this.readerPowerBar.Name = "readerPowerBar";
            this.readerPowerBar.Size = new System.Drawing.Size(203, 69);
            this.readerPowerBar.TabIndex = 10;
            // 
            // gbWriteTag
            // 
            this.gbWriteTag.Controls.Add(this.btnOpenWriteDialog);
            this.gbWriteTag.Location = new System.Drawing.Point(16, 472);
            this.gbWriteTag.Margin = new System.Windows.Forms.Padding(4);
            this.gbWriteTag.Name = "gbWriteTag";
            this.gbWriteTag.Padding = new System.Windows.Forms.Padding(4);
            this.gbWriteTag.Size = new System.Drawing.Size(224, 66);
            this.gbWriteTag.TabIndex = 9;
            this.gbWriteTag.TabStop = false;
            this.gbWriteTag.Text = " Write Tag ";
            // 
            // btnOpenWriteDialog
            // 
            this.btnOpenWriteDialog.Enabled = false;
            this.btnOpenWriteDialog.Location = new System.Drawing.Point(5, 23);
            this.btnOpenWriteDialog.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenWriteDialog.Name = "btnOpenWriteDialog";
            this.btnOpenWriteDialog.Size = new System.Drawing.Size(209, 28);
            this.btnOpenWriteDialog.TabIndex = 0;
            this.btnOpenWriteDialog.Text = "Open write dialog ...";
            this.btnOpenWriteDialog.UseVisualStyleBackColor = true;
            this.btnOpenWriteDialog.Click += new System.EventHandler(this.btnOpenWriteDialog_Click);
            // 
            // groupMulti
            // 
            this.groupMulti.Controls.Add(this.cbUseSimulator);
            this.groupMulti.Controls.Add(this.btnAllReaders);
            this.groupMulti.Location = new System.Drawing.Point(9, 158);
            this.groupMulti.Margin = new System.Windows.Forms.Padding(4);
            this.groupMulti.Name = "groupMulti";
            this.groupMulti.Padding = new System.Windows.Forms.Padding(4);
            this.groupMulti.Size = new System.Drawing.Size(225, 113);
            this.groupMulti.TabIndex = 7;
            this.groupMulti.TabStop = false;
            this.groupMulti.Text = " Multi Readers ";
            // 
            // cbUseSimulator
            // 
            this.cbUseSimulator.AutoSize = true;
            this.cbUseSimulator.Location = new System.Drawing.Point(12, 34);
            this.cbUseSimulator.Margin = new System.Windows.Forms.Padding(4);
            this.cbUseSimulator.Name = "cbUseSimulator";
            this.cbUseSimulator.Size = new System.Drawing.Size(118, 21);
            this.cbUseSimulator.TabIndex = 1;
            this.cbUseSimulator.Text = "Use Simulator";
            this.cbUseSimulator.UseVisualStyleBackColor = true;
            // 
            // btnAllReaders
            // 
            this.btnAllReaders.Location = new System.Drawing.Point(8, 63);
            this.btnAllReaders.Margin = new System.Windows.Forms.Padding(4);
            this.btnAllReaders.Name = "btnAllReaders";
            this.btnAllReaders.Size = new System.Drawing.Size(209, 28);
            this.btnAllReaders.TabIndex = 0;
            this.btnAllReaders.Text = "Scan For All Readers";
            this.btnAllReaders.UseVisualStyleBackColor = true;
            this.btnAllReaders.Click += new System.EventHandler(this.btnAllReaders_Click);
            // 
            // createGroupBox
            // 
            this.createGroupBox.Controls.Add(this.btnForceReaderType);
            this.createGroupBox.Controls.Add(this.readerTypeBox);
            this.createGroupBox.Controls.Add(this.forceReaderLbl);
            this.createGroupBox.Location = new System.Drawing.Point(9, 15);
            this.createGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.createGroupBox.Name = "createGroupBox";
            this.createGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.createGroupBox.Size = new System.Drawing.Size(225, 123);
            this.createGroupBox.TabIndex = 6;
            this.createGroupBox.TabStop = false;
            this.createGroupBox.Text = " Reader Creation ";
            // 
            // btnForceReaderType
            // 
            this.btnForceReaderType.Location = new System.Drawing.Point(8, 91);
            this.btnForceReaderType.Margin = new System.Windows.Forms.Padding(4);
            this.btnForceReaderType.Name = "btnForceReaderType";
            this.btnForceReaderType.Size = new System.Drawing.Size(209, 25);
            this.btnForceReaderType.TabIndex = 3;
            this.btnForceReaderType.Text = "ConnectAll Reader Type";
            this.btnForceReaderType.UseVisualStyleBackColor = true;
            this.btnForceReaderType.Click += new System.EventHandler(this.btnForceReaderType_Click);
            // 
            // readerTypeBox
            // 
            this.readerTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.readerTypeBox.FormattingEnabled = true;
            this.readerTypeBox.Location = new System.Drawing.Point(8, 52);
            this.readerTypeBox.Margin = new System.Windows.Forms.Padding(4);
            this.readerTypeBox.Name = "readerTypeBox";
            this.readerTypeBox.Size = new System.Drawing.Size(208, 24);
            this.readerTypeBox.TabIndex = 1;
            this.readerTypeBox.SelectedIndexChanged += new System.EventHandler(this.readerTypeBox_SelectedIndexChanged);
            // 
            // forceReaderLbl
            // 
            this.forceReaderLbl.AutoSize = true;
            this.forceReaderLbl.Location = new System.Drawing.Point(8, 32);
            this.forceReaderLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.forceReaderLbl.Name = "forceReaderLbl";
            this.forceReaderLbl.Size = new System.Drawing.Size(131, 17);
            this.forceReaderLbl.TabIndex = 2;
            this.forceReaderLbl.Text = "Force Reader Type";
            // 
            // readTagsGroup
            // 
            this.readTagsGroup.Controls.Add(this.btnReadTag);
            this.readTagsGroup.Location = new System.Drawing.Point(11, 384);
            this.readTagsGroup.Margin = new System.Windows.Forms.Padding(4);
            this.readTagsGroup.Name = "readTagsGroup";
            this.readTagsGroup.Padding = new System.Windows.Forms.Padding(4);
            this.readTagsGroup.Size = new System.Drawing.Size(225, 80);
            this.readTagsGroup.TabIndex = 5;
            this.readTagsGroup.TabStop = false;
            this.readTagsGroup.Text = " Read Tags ";
            // 
            // btnReadTag
            // 
            this.btnReadTag.Location = new System.Drawing.Point(7, 33);
            this.btnReadTag.Margin = new System.Windows.Forms.Padding(4);
            this.btnReadTag.Name = "btnReadTag";
            this.btnReadTag.Size = new System.Drawing.Size(209, 25);
            this.btnReadTag.TabIndex = 0;
            this.btnReadTag.Text = "Read RFID Tag";
            this.btnReadTag.UseVisualStyleBackColor = true;
            this.btnReadTag.Click += new System.EventHandler(this.btnReadTags_Click);
            // 
            // readerListView
            // 
            this.readerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.brandColumn,
            this.modelColumn});
            this.readerListView.Dock = System.Windows.Forms.DockStyle.Left;
            this.readerListView.HideSelection = false;
            this.readerListView.Location = new System.Drawing.Point(244, 0);
            this.readerListView.Margin = new System.Windows.Forms.Padding(4);
            this.readerListView.Name = "readerListView";
            this.readerListView.Size = new System.Drawing.Size(275, 746);
            this.readerListView.TabIndex = 1;
            this.readerListView.UseCompatibleStateImageBehavior = false;
            this.readerListView.View = System.Windows.Forms.View.Details;
            // 
            // brandColumn
            // 
            this.brandColumn.Text = "Brand";
            this.brandColumn.Width = 100;
            // 
            // modelColumn
            // 
            this.modelColumn.Text = "Model";
            this.modelColumn.Width = 100;
            // 
            // tagListView
            // 
            this.tagListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnRaw,
            this.columnEPC,
            this.columnSEQ});
            this.tagListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagListView.HideSelection = false;
            this.tagListView.Location = new System.Drawing.Point(519, 0);
            this.tagListView.Margin = new System.Windows.Forms.Padding(4);
            this.tagListView.Name = "tagListView";
            this.tagListView.Size = new System.Drawing.Size(849, 746);
            this.tagListView.TabIndex = 2;
            this.tagListView.UseCompatibleStateImageBehavior = false;
            this.tagListView.View = System.Windows.Forms.View.Details;
            // 
            // columnRaw
            // 
            this.columnRaw.Text = "Raw";
            this.columnRaw.Width = 200;
            // 
            // columnEPC
            // 
            this.columnEPC.Text = "EPC";
            this.columnEPC.Width = 200;
            // 
            // columnSEQ
            // 
            this.columnSEQ.Text = "SEQ";
            this.columnSEQ.Width = 200;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(519, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(4);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 746);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 746);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tagListView);
            this.Controls.Add(this.readerListView);
            this.Controls.Add(this.sidePanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IRFIDReader Testing App";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.sidePanel.ResumeLayout(false);
            this.gbWriteTag.ResumeLayout(false);
            this.groupMulti.ResumeLayout(false);
            this.groupMulti.PerformLayout();
            this.createGroupBox.ResumeLayout(false);
            this.createGroupBox.PerformLayout();
            this.readTagsGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Button btnReadTag;
        private System.Windows.Forms.ListView readerListView;
        private System.Windows.Forms.ColumnHeader brandColumn;
        private System.Windows.Forms.ColumnHeader modelColumn;
        private System.Windows.Forms.Label forceReaderLbl;
        private System.Windows.Forms.ComboBox readerTypeBox;
        private System.Windows.Forms.Button btnForceReaderType;
        private System.Windows.Forms.GroupBox readTagsGroup;
        private System.Windows.Forms.GroupBox createGroupBox;
        private System.Windows.Forms.ListView tagListView;
        private System.Windows.Forms.ColumnHeader columnRaw;
        private System.Windows.Forms.ColumnHeader columnEPC;
        private System.Windows.Forms.ColumnHeader columnSEQ;
        private System.Windows.Forms.GroupBox groupMulti;
        private System.Windows.Forms.Button btnAllReaders;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.CheckBox cbUseSimulator;
        private System.Windows.Forms.GroupBox gbWriteTag;
        private System.Windows.Forms.Button btnOpenWriteDialog;
        private UIControls.WinForms.Controls.ReaderPowerBar readerPowerBar;
        private System.Windows.Forms.Button btnImpinjTester;
        private System.Windows.Forms.Button btnEventReading;
    }
}

