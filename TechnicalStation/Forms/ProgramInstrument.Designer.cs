namespace TechnicalStation.Forms
{
    partial class ProgramInstrument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgramInstrument));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TopTitle = new System.Windows.Forms.Label();
            this.tabWizardControl = new System.Windows.Forms.TabControl();
            this.frontPage = new System.Windows.Forms.TabPage();
            this.frontPageGroupBox = new System.Windows.Forms.GroupBox();
            this.frontPageLabel = new System.Windows.Forms.Label();
            this.scanButton = new System.Windows.Forms.Button();
            this.instrumentReadPage = new System.Windows.Forms.TabPage();
            this.resetButton = new System.Windows.Forms.Button();
            this.programButton = new System.Windows.Forms.Button();
            this.restartButton = new System.Windows.Forms.Button();
            this.instrumentReadGroupBox = new System.Windows.Forms.GroupBox();
            this.programTagAccessPasswordLabel = new System.Windows.Forms.Label();
            this.accessPasswordTextBox = new System.Windows.Forms.TextBox();
            this.instrumentReadLabel = new System.Windows.Forms.Label();
            this.instrumentReadLinkAssetButton = new System.Windows.Forms.Button();
            this.saveInstrumentPage = new System.Windows.Forms.TabPage();
            this.saveInstrumentInDatabaseGroupBox = new System.Windows.Forms.GroupBox();
            this.extraDataGroupBox = new System.Windows.Forms.GroupBox();
            this.productiondDateHintLabel = new System.Windows.Forms.Label();
            this.productionDateTextBox = new System.Windows.Forms.TextBox();
            this.extraDataLabel = new System.Windows.Forms.Label();
            this.productionDateLabel = new System.Windows.Forms.Label();
            this.lotTextBox = new System.Windows.Forms.TextBox();
            this.lotLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sterilizationCartRadioButton = new System.Windows.Forms.RadioButton();
            this.trolleyRadioButton = new System.Windows.Forms.RadioButton();
            this.containerRadioButton = new System.Windows.Forms.RadioButton();
            this.trayRadioButton = new System.Windows.Forms.RadioButton();
            this.instrumentRadioButton = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.instrumentTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.saveInstrumentLabel = new System.Windows.Forms.Label();
            this.instrumentTypeListBoxControl = new DevExpress.XtraEditors.ListBoxControl();
            this.instrumentTypeSearchLabel = new System.Windows.Forms.Label();
            this.instrumentTypeSearchTextBox = new System.Windows.Forms.TextBox();
            this.saveInstrumentRestartButton = new System.Windows.Forms.Button();
            this.saveInstrumentNextButton = new System.Windows.Forms.Button();
            this.searchBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.readerPowerBar = new UIControls.WinForms.Controls.ReaderPowerBar();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.programmingBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.Panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabWizardControl.SuspendLayout();
            this.frontPage.SuspendLayout();
            this.frontPageGroupBox.SuspendLayout();
            this.instrumentReadPage.SuspendLayout();
            this.instrumentReadGroupBox.SuspendLayout();
            this.saveInstrumentPage.SuspendLayout();
            this.saveInstrumentInDatabaseGroupBox.SuspendLayout();
            this.extraDataGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.instrumentTypeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.instrumentTypeListBoxControl)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.DarkOrange;
            this.tableLayoutPanel2.SetColumnSpan(this.Panel1, 2);
            this.Panel1.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.Panel1, "Panel1");
            this.Panel1.Name = "Panel1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.LightGray;
            this.tableLayoutPanel1.Controls.Add(this.TopTitle, 0, 0);
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // TopTitle
            // 
            resources.ApplyResources(this.TopTitle, "TopTitle");
            this.TopTitle.ForeColor = System.Drawing.Color.Black;
            this.TopTitle.Name = "TopTitle";
            // 
            // tabWizardControl
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.tabWizardControl, 2);
            this.tabWizardControl.Controls.Add(this.frontPage);
            this.tabWizardControl.Controls.Add(this.instrumentReadPage);
            this.tabWizardControl.Controls.Add(this.saveInstrumentPage);
            resources.ApplyResources(this.tabWizardControl, "tabWizardControl");
            this.tabWizardControl.Name = "tabWizardControl";
            this.tabWizardControl.SelectedIndex = 0;
            this.tabWizardControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tabControl1_KeyDown);
            // 
            // frontPage
            // 
            this.frontPage.Controls.Add(this.frontPageGroupBox);
            this.frontPage.Controls.Add(this.scanButton);
            resources.ApplyResources(this.frontPage, "frontPage");
            this.frontPage.Name = "frontPage";
            this.frontPage.UseVisualStyleBackColor = true;
            // 
            // frontPageGroupBox
            // 
            this.frontPageGroupBox.Controls.Add(this.frontPageLabel);
            resources.ApplyResources(this.frontPageGroupBox, "frontPageGroupBox");
            this.frontPageGroupBox.Name = "frontPageGroupBox";
            this.frontPageGroupBox.TabStop = false;
            this.frontPageGroupBox.Enter += new System.EventHandler(this.frontPageGroupBox_Enter);
            // 
            // frontPageLabel
            // 
            resources.ApplyResources(this.frontPageLabel, "frontPageLabel");
            this.frontPageLabel.Name = "frontPageLabel";
            // 
            // scanButton
            // 
            resources.ApplyResources(this.scanButton, "scanButton");
            this.scanButton.Name = "scanButton";
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Click += new System.EventHandler(this.scanButton_Click);
            // 
            // instrumentReadPage
            // 
            this.instrumentReadPage.Controls.Add(this.resetButton);
            this.instrumentReadPage.Controls.Add(this.programButton);
            this.instrumentReadPage.Controls.Add(this.restartButton);
            this.instrumentReadPage.Controls.Add(this.instrumentReadGroupBox);
            this.instrumentReadPage.Controls.Add(this.instrumentReadLinkAssetButton);
            resources.ApplyResources(this.instrumentReadPage, "instrumentReadPage");
            this.instrumentReadPage.Name = "instrumentReadPage";
            this.instrumentReadPage.UseVisualStyleBackColor = true;
            // 
            // resetButton
            // 
            resources.ApplyResources(this.resetButton, "resetButton");
            this.resetButton.Name = "resetButton";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // programButton
            // 
            resources.ApplyResources(this.programButton, "programButton");
            this.programButton.Name = "programButton";
            this.programButton.UseVisualStyleBackColor = true;
            this.programButton.Click += new System.EventHandler(this.programButton_Click);
            // 
            // restartButton
            // 
            resources.ApplyResources(this.restartButton, "restartButton");
            this.restartButton.Name = "restartButton";
            this.restartButton.UseVisualStyleBackColor = true;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // instrumentReadGroupBox
            // 
            this.instrumentReadGroupBox.Controls.Add(this.programTagAccessPasswordLabel);
            this.instrumentReadGroupBox.Controls.Add(this.accessPasswordTextBox);
            this.instrumentReadGroupBox.Controls.Add(this.instrumentReadLabel);
            resources.ApplyResources(this.instrumentReadGroupBox, "instrumentReadGroupBox");
            this.instrumentReadGroupBox.Name = "instrumentReadGroupBox";
            this.instrumentReadGroupBox.TabStop = false;
            this.instrumentReadGroupBox.Resize += new System.EventHandler(this.instrumentReadGroupBox_Resize);
            // 
            // programTagAccessPasswordLabel
            // 
            resources.ApplyResources(this.programTagAccessPasswordLabel, "programTagAccessPasswordLabel");
            this.programTagAccessPasswordLabel.Name = "programTagAccessPasswordLabel";
            // 
            // accessPasswordTextBox
            // 
            resources.ApplyResources(this.accessPasswordTextBox, "accessPasswordTextBox");
            this.accessPasswordTextBox.Name = "accessPasswordTextBox";
            // 
            // instrumentReadLabel
            // 
            resources.ApplyResources(this.instrumentReadLabel, "instrumentReadLabel");
            this.instrumentReadLabel.Name = "instrumentReadLabel";
            // 
            // instrumentReadLinkAssetButton
            // 
            resources.ApplyResources(this.instrumentReadLinkAssetButton, "instrumentReadLinkAssetButton");
            this.instrumentReadLinkAssetButton.Name = "instrumentReadLinkAssetButton";
            this.instrumentReadLinkAssetButton.UseVisualStyleBackColor = true;
            this.instrumentReadLinkAssetButton.Click += new System.EventHandler(this.linkAssetButton_Click);
            // 
            // saveInstrumentPage
            // 
            this.saveInstrumentPage.Controls.Add(this.saveInstrumentInDatabaseGroupBox);
            this.saveInstrumentPage.Controls.Add(this.saveInstrumentRestartButton);
            this.saveInstrumentPage.Controls.Add(this.saveInstrumentNextButton);
            resources.ApplyResources(this.saveInstrumentPage, "saveInstrumentPage");
            this.saveInstrumentPage.Name = "saveInstrumentPage";
            this.saveInstrumentPage.UseVisualStyleBackColor = true;
            // 
            // saveInstrumentInDatabaseGroupBox
            // 
            this.saveInstrumentInDatabaseGroupBox.Controls.Add(this.extraDataGroupBox);
            this.saveInstrumentInDatabaseGroupBox.Controls.Add(this.groupBox1);
            this.saveInstrumentInDatabaseGroupBox.Controls.Add(this.label4);
            this.saveInstrumentInDatabaseGroupBox.Controls.Add(this.instrumentTypeGroupBox);
            resources.ApplyResources(this.saveInstrumentInDatabaseGroupBox, "saveInstrumentInDatabaseGroupBox");
            this.saveInstrumentInDatabaseGroupBox.Name = "saveInstrumentInDatabaseGroupBox";
            this.saveInstrumentInDatabaseGroupBox.TabStop = false;
            // 
            // extraDataGroupBox
            // 
            this.extraDataGroupBox.Controls.Add(this.productiondDateHintLabel);
            this.extraDataGroupBox.Controls.Add(this.productionDateTextBox);
            this.extraDataGroupBox.Controls.Add(this.extraDataLabel);
            this.extraDataGroupBox.Controls.Add(this.productionDateLabel);
            this.extraDataGroupBox.Controls.Add(this.lotTextBox);
            this.extraDataGroupBox.Controls.Add(this.lotLabel);
            resources.ApplyResources(this.extraDataGroupBox, "extraDataGroupBox");
            this.extraDataGroupBox.Name = "extraDataGroupBox";
            this.extraDataGroupBox.TabStop = false;
            // 
            // productiondDateHintLabel
            // 
            resources.ApplyResources(this.productiondDateHintLabel, "productiondDateHintLabel");
            this.productiondDateHintLabel.Name = "productiondDateHintLabel";
            // 
            // productionDateTextBox
            // 
            resources.ApplyResources(this.productionDateTextBox, "productionDateTextBox");
            this.productionDateTextBox.Name = "productionDateTextBox";
            this.productionDateTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            this.productionDateTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // extraDataLabel
            // 
            resources.ApplyResources(this.extraDataLabel, "extraDataLabel");
            this.extraDataLabel.Name = "extraDataLabel";
            // 
            // productionDateLabel
            // 
            resources.ApplyResources(this.productionDateLabel, "productionDateLabel");
            this.productionDateLabel.Name = "productionDateLabel";
            // 
            // lotTextBox
            // 
            resources.ApplyResources(this.lotTextBox, "lotTextBox");
            this.lotTextBox.Name = "lotTextBox";
            this.lotTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            this.lotTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // lotLabel
            // 
            resources.ApplyResources(this.lotLabel, "lotLabel");
            this.lotLabel.Name = "lotLabel";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sterilizationCartRadioButton);
            this.groupBox1.Controls.Add(this.trolleyRadioButton);
            this.groupBox1.Controls.Add(this.containerRadioButton);
            this.groupBox1.Controls.Add(this.trayRadioButton);
            this.groupBox1.Controls.Add(this.instrumentRadioButton);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // sterilizationCartRadioButton
            // 
            resources.ApplyResources(this.sterilizationCartRadioButton, "sterilizationCartRadioButton");
            this.sterilizationCartRadioButton.Name = "sterilizationCartRadioButton";
            this.sterilizationCartRadioButton.TabStop = true;
            this.sterilizationCartRadioButton.UseVisualStyleBackColor = true;
            // 
            // trolleyRadioButton
            // 
            resources.ApplyResources(this.trolleyRadioButton, "trolleyRadioButton");
            this.trolleyRadioButton.Name = "trolleyRadioButton";
            this.trolleyRadioButton.TabStop = true;
            this.trolleyRadioButton.UseVisualStyleBackColor = true;
            // 
            // containerRadioButton
            // 
            resources.ApplyResources(this.containerRadioButton, "containerRadioButton");
            this.containerRadioButton.Name = "containerRadioButton";
            this.containerRadioButton.TabStop = true;
            this.containerRadioButton.UseVisualStyleBackColor = true;
            // 
            // trayRadioButton
            // 
            resources.ApplyResources(this.trayRadioButton, "trayRadioButton");
            this.trayRadioButton.Name = "trayRadioButton";
            this.trayRadioButton.TabStop = true;
            this.trayRadioButton.UseVisualStyleBackColor = true;
            // 
            // instrumentRadioButton
            // 
            resources.ApplyResources(this.instrumentRadioButton, "instrumentRadioButton");
            this.instrumentRadioButton.Checked = true;
            this.instrumentRadioButton.Name = "instrumentRadioButton";
            this.instrumentRadioButton.TabStop = true;
            this.instrumentRadioButton.UseVisualStyleBackColor = true;
            this.instrumentRadioButton.CheckedChanged += new System.EventHandler(this.instrumentRadioButton_CheckedChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // instrumentTypeGroupBox
            // 
            this.instrumentTypeGroupBox.Controls.Add(this.searchButton);
            this.instrumentTypeGroupBox.Controls.Add(this.saveInstrumentLabel);
            this.instrumentTypeGroupBox.Controls.Add(this.instrumentTypeListBoxControl);
            this.instrumentTypeGroupBox.Controls.Add(this.instrumentTypeSearchLabel);
            this.instrumentTypeGroupBox.Controls.Add(this.instrumentTypeSearchTextBox);
            resources.ApplyResources(this.instrumentTypeGroupBox, "instrumentTypeGroupBox");
            this.instrumentTypeGroupBox.Name = "instrumentTypeGroupBox";
            this.instrumentTypeGroupBox.TabStop = false;
            // 
            // searchButton
            // 
            resources.ApplyResources(this.searchButton, "searchButton");
            this.searchButton.Name = "searchButton";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // saveInstrumentLabel
            // 
            resources.ApplyResources(this.saveInstrumentLabel, "saveInstrumentLabel");
            this.saveInstrumentLabel.Name = "saveInstrumentLabel";
            // 
            // instrumentTypeListBoxControl
            // 
            resources.ApplyResources(this.instrumentTypeListBoxControl, "instrumentTypeListBoxControl");
            this.instrumentTypeListBoxControl.Name = "instrumentTypeListBoxControl";
            // 
            // instrumentTypeSearchLabel
            // 
            resources.ApplyResources(this.instrumentTypeSearchLabel, "instrumentTypeSearchLabel");
            this.instrumentTypeSearchLabel.Name = "instrumentTypeSearchLabel";
            // 
            // instrumentTypeSearchTextBox
            // 
            resources.ApplyResources(this.instrumentTypeSearchTextBox, "instrumentTypeSearchTextBox");
            this.instrumentTypeSearchTextBox.Name = "instrumentTypeSearchTextBox";
            this.instrumentTypeSearchTextBox.TextChanged += new System.EventHandler(this.instrumentTypeSearchTextBox_TextChanged);
            this.instrumentTypeSearchTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            this.instrumentTypeSearchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.instrumentTypeSearchTextBox_KeyPress);
            this.instrumentTypeSearchTextBox.Leave += new System.EventHandler(this.instrumentTypeSearchTextBox_Leave);
            // 
            // saveInstrumentRestartButton
            // 
            resources.ApplyResources(this.saveInstrumentRestartButton, "saveInstrumentRestartButton");
            this.saveInstrumentRestartButton.Name = "saveInstrumentRestartButton";
            this.saveInstrumentRestartButton.UseVisualStyleBackColor = true;
            this.saveInstrumentRestartButton.Click += new System.EventHandler(this.saveInstrumentPreviousButton_Click);
            // 
            // saveInstrumentNextButton
            // 
            resources.ApplyResources(this.saveInstrumentNextButton, "saveInstrumentNextButton");
            this.saveInstrumentNextButton.Name = "saveInstrumentNextButton";
            this.saveInstrumentNextButton.UseVisualStyleBackColor = true;
            this.saveInstrumentNextButton.Click += new System.EventHandler(this.saveInstrumentNextButton_Click);
            // 
            // searchBackgroundWorker
            // 
            this.searchBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.searchBackgroundWorker_DoWork);
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.readerPowerBar, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.progressBar, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.Panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tabWizardControl, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.messageTextBox, 0, 1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // readerPowerBar
            // 
            resources.ApplyResources(this.readerPowerBar, "readerPowerBar");
            this.readerPowerBar.Name = "readerPowerBar";
            // 
            // progressBar
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.progressBar, 2);
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.MarqueeAnimationSpeed = 0;
            this.progressBar.Name = "progressBar";
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // messageTextBox
            // 
            resources.ApplyResources(this.messageTextBox, "messageTextBox");
            this.messageTextBox.Name = "messageTextBox";
            // 
            // programmingBackgroundWorker
            // 
            this.programmingBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.programmingBackgroundWorker_DoWork);
            this.programmingBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.programmingBackgroundWorker_RunWorkerCompleted);
            // 
            // ProgramInstrument
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "ProgramInstrument";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProgramInstrument_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProgramInstrument_FormClosed);
            this.Load += new System.EventHandler(this.ProgramInstrument_Load);
            this.Panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabWizardControl.ResumeLayout(false);
            this.frontPage.ResumeLayout(false);
            this.frontPageGroupBox.ResumeLayout(false);
            this.frontPageGroupBox.PerformLayout();
            this.instrumentReadPage.ResumeLayout(false);
            this.instrumentReadGroupBox.ResumeLayout(false);
            this.instrumentReadGroupBox.PerformLayout();
            this.saveInstrumentPage.ResumeLayout(false);
            this.saveInstrumentInDatabaseGroupBox.ResumeLayout(false);
            this.saveInstrumentInDatabaseGroupBox.PerformLayout();
            this.extraDataGroupBox.ResumeLayout(false);
            this.extraDataGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.instrumentTypeGroupBox.ResumeLayout(false);
            this.instrumentTypeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.instrumentTypeListBoxControl)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Label TopTitle;
        private System.Windows.Forms.TabControl tabWizardControl;
        private System.Windows.Forms.TabPage frontPage;
        private System.Windows.Forms.Label frontPageLabel;
        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.TabPage instrumentReadPage;
        private System.Windows.Forms.Button instrumentReadLinkAssetButton;
        private System.Windows.Forms.Label instrumentReadLabel;
        private System.Windows.Forms.GroupBox instrumentReadGroupBox;
        private System.Windows.Forms.GroupBox frontPageGroupBox;
        private System.Windows.Forms.TabPage saveInstrumentPage;
        private System.Windows.Forms.GroupBox saveInstrumentInDatabaseGroupBox;
        private System.Windows.Forms.Button saveInstrumentRestartButton;
        private System.Windows.Forms.Button saveInstrumentNextButton;
        private System.Windows.Forms.Label saveInstrumentLabel;
        private System.Windows.Forms.GroupBox instrumentTypeGroupBox;
        private DevExpress.XtraEditors.ListBoxControl instrumentTypeListBoxControl;
        private System.Windows.Forms.Label instrumentTypeSearchLabel;
        private System.Windows.Forms.TextBox instrumentTypeSearchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.ComponentModel.BackgroundWorker searchBackgroundWorker;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Button programButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton containerRadioButton;
        private System.Windows.Forms.RadioButton trayRadioButton;
        private System.Windows.Forms.RadioButton instrumentRadioButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label programTagAccessPasswordLabel;
        private System.Windows.Forms.TextBox accessPasswordTextBox;
        internal System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.ComponentModel.BackgroundWorker programmingBackgroundWorker;
        private UIControls.WinForms.Controls.ReaderPowerBar readerPowerBar;
        private System.Windows.Forms.GroupBox extraDataGroupBox;
        private System.Windows.Forms.Label extraDataLabel;
        private System.Windows.Forms.Label productionDateLabel;
        private System.Windows.Forms.TextBox lotTextBox;
        private System.Windows.Forms.Label lotLabel;
        private System.Windows.Forms.Label productiondDateHintLabel;
        private System.Windows.Forms.TextBox productionDateTextBox;
        private System.Windows.Forms.RadioButton trolleyRadioButton;
        private System.Windows.Forms.RadioButton sterilizationCartRadioButton;
    }
}