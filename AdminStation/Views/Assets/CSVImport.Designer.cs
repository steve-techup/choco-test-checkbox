namespace AdminStation.Views.Assets
{
    partial class CSVImport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CSVImport));
            this.openButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.filenameTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabWizardControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.importCSVBox = new System.Windows.Forms.GroupBox();
            this.delimiterTextBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.selectColumnsBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.untaggableCombobox = new System.Windows.Forms.ComboBox();
            this.packingSetNameLabel = new System.Windows.Forms.Label();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.descriptionIdLabel = new System.Windows.Forms.Label();
            this.quantityComboBox = new System.Windows.Forms.ComboBox();
            this.descriptionIdComboBox = new System.Windows.Forms.ComboBox();
            this.instrumentDescriptionLabel = new System.Windows.Forms.Label();
            this.instrumentDescriptionComboBox = new System.Windows.Forms.ComboBox();
            this.imageUrlComboBox = new System.Windows.Forms.ComboBox();
            this.imageSearchLabel = new System.Windows.Forms.Label();
            this.autoImageSearchCheckBox = new System.Windows.Forms.CheckBox();
            this.imageUrlLabel = new System.Windows.Forms.Label();
            this.imageSearchPatternLabel = new System.Windows.Forms.Label();
            this.imageSearchPatternTextBox = new System.Windows.Forms.TextBox();
            this.InstrumentVendorLabel = new System.Windows.Forms.Label();
            this.instrumentVendorComboBox = new System.Windows.Forms.ComboBox();
            this.backButton = new System.Windows.Forms.Button();
            this.uploadButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.packingSetNameComboBox = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabWizardControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.importCSVBox.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.selectColumnsBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openButton
            // 
            this.openButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.openButton, "openButton");
            this.openButton.Name = "openButton";
            this.openButton.UseVisualStyleBackColor = false;
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "packingList";
            // 
            // filenameTextbox
            // 
            resources.ApplyResources(this.filenameTextbox, "filenameTextbox");
            this.filenameTextbox.Name = "filenameTextbox";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // tabWizardControl
            // 
            this.tabWizardControl.Controls.Add(this.tabPage1);
            this.tabWizardControl.Controls.Add(this.tabPage2);
            resources.ApplyResources(this.tabWizardControl, "tabWizardControl");
            this.tabWizardControl.Name = "tabWizardControl";
            this.tabWizardControl.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.importCSVBox);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // importCSVBox
            // 
            this.importCSVBox.BackColor = System.Drawing.Color.Transparent;
            this.importCSVBox.Controls.Add(this.delimiterTextBox);
            this.importCSVBox.Controls.Add(this.browseButton);
            this.importCSVBox.Controls.Add(this.label1);
            this.importCSVBox.Controls.Add(this.openButton);
            this.importCSVBox.Controls.Add(this.label3);
            this.importCSVBox.Controls.Add(this.filenameTextbox);
            resources.ApplyResources(this.importCSVBox, "importCSVBox");
            this.importCSVBox.Name = "importCSVBox";
            this.importCSVBox.TabStop = false;
            // 
            // delimiterTextBox
            // 
            resources.ApplyResources(this.delimiterTextBox, "delimiterTextBox");
            this.delimiterTextBox.Name = "delimiterTextBox";
            // 
            // browseButton
            // 
            resources.ApplyResources(this.browseButton, "browseButton");
            this.browseButton.Name = "browseButton";
            this.browseButton.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.selectColumnsBox);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            // 
            // selectColumnsBox
            // 
            this.selectColumnsBox.BackColor = System.Drawing.Color.Transparent;
            this.selectColumnsBox.Controls.Add(this.tableLayoutPanel2);
            resources.ApplyResources(this.selectColumnsBox, "selectColumnsBox");
            this.selectColumnsBox.Name = "selectColumnsBox";
            this.selectColumnsBox.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.untaggableCombobox, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.packingSetNameLabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.quantityLabel, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.descriptionIdLabel, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.quantityComboBox, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.descriptionIdComboBox, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.instrumentDescriptionLabel, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.instrumentDescriptionComboBox, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.imageUrlComboBox, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.imageSearchLabel, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.autoImageSearchCheckBox, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.imageUrlLabel, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.imageSearchPatternLabel, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.imageSearchPatternTextBox, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.InstrumentVendorLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.instrumentVendorComboBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.packingSetNameComboBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.uploadButton, 1, 10);
            this.tableLayoutPanel2.Controls.Add(this.backButton, 0, 10);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // untaggableCombobox
            // 
            this.untaggableCombobox.FormattingEnabled = true;
            resources.ApplyResources(this.untaggableCombobox, "untaggableCombobox");
            this.untaggableCombobox.Name = "untaggableCombobox";
            // 
            // packingSetNameLabel
            // 
            resources.ApplyResources(this.packingSetNameLabel, "packingSetNameLabel");
            this.packingSetNameLabel.Name = "packingSetNameLabel";
            // 
            // quantityLabel
            // 
            resources.ApplyResources(this.quantityLabel, "quantityLabel");
            this.quantityLabel.Name = "quantityLabel";
            // 
            // descriptionIdLabel
            // 
            resources.ApplyResources(this.descriptionIdLabel, "descriptionIdLabel");
            this.descriptionIdLabel.Name = "descriptionIdLabel";
            // 
            // quantityComboBox
            // 
            this.quantityComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.quantityComboBox, "quantityComboBox");
            this.quantityComboBox.Name = "quantityComboBox";
            // 
            // descriptionIdComboBox
            // 
            this.descriptionIdComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.descriptionIdComboBox, "descriptionIdComboBox");
            this.descriptionIdComboBox.Name = "descriptionIdComboBox";
            // 
            // instrumentDescriptionLabel
            // 
            resources.ApplyResources(this.instrumentDescriptionLabel, "instrumentDescriptionLabel");
            this.instrumentDescriptionLabel.Name = "instrumentDescriptionLabel";
            // 
            // instrumentDescriptionComboBox
            // 
            this.instrumentDescriptionComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.instrumentDescriptionComboBox, "instrumentDescriptionComboBox");
            this.instrumentDescriptionComboBox.Name = "instrumentDescriptionComboBox";
            // 
            // imageUrlComboBox
            // 
            this.imageUrlComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.imageUrlComboBox, "imageUrlComboBox");
            this.imageUrlComboBox.Name = "imageUrlComboBox";
            // 
            // imageSearchLabel
            // 
            resources.ApplyResources(this.imageSearchLabel, "imageSearchLabel");
            this.imageSearchLabel.Name = "imageSearchLabel";
            // 
            // autoImageSearchCheckBox
            // 
            resources.ApplyResources(this.autoImageSearchCheckBox, "autoImageSearchCheckBox");
            this.autoImageSearchCheckBox.Name = "autoImageSearchCheckBox";
            this.autoImageSearchCheckBox.UseVisualStyleBackColor = true;
            // 
            // imageUrlLabel
            // 
            resources.ApplyResources(this.imageUrlLabel, "imageUrlLabel");
            this.imageUrlLabel.Name = "imageUrlLabel";
            // 
            // imageSearchPatternLabel
            // 
            resources.ApplyResources(this.imageSearchPatternLabel, "imageSearchPatternLabel");
            this.imageSearchPatternLabel.Name = "imageSearchPatternLabel";
            // 
            // imageSearchPatternTextBox
            // 
            resources.ApplyResources(this.imageSearchPatternTextBox, "imageSearchPatternTextBox");
            this.imageSearchPatternTextBox.Name = "imageSearchPatternTextBox";
            // 
            // InstrumentVendorLabel
            // 
            resources.ApplyResources(this.InstrumentVendorLabel, "InstrumentVendorLabel");
            this.InstrumentVendorLabel.Name = "InstrumentVendorLabel";
            // 
            // instrumentVendorComboBox
            // 
            resources.ApplyResources(this.instrumentVendorComboBox, "instrumentVendorComboBox");
            this.instrumentVendorComboBox.FormattingEnabled = true;
            this.instrumentVendorComboBox.Name = "instrumentVendorComboBox";
            // 
            // backButton
            // 
            resources.ApplyResources(this.backButton, "backButton");
            this.backButton.Name = "backButton";
            this.backButton.UseVisualStyleBackColor = true;
            // 
            // uploadButton
            // 
            resources.ApplyResources(this.uploadButton, "uploadButton");
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // packingSetNameComboBox
            // 
            resources.ApplyResources(this.packingSetNameComboBox, "packingSetNameComboBox");
            this.packingSetNameComboBox.FormattingEnabled = true;
            this.packingSetNameComboBox.Name = "packingSetNameComboBox";
            // 
            // CSVImport
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.tabWizardControl);
            this.Name = "CSVImport";
            this.tabWizardControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.importCSVBox.ResumeLayout(false);
            this.importCSVBox.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.selectColumnsBox.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox filenameTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabWizardControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox importCSVBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TabPage tabPage2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox selectColumnsBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label packingSetNameLabel;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.Label descriptionIdLabel;
        private System.Windows.Forms.ComboBox packingSetNameComboBox;
        private System.Windows.Forms.ComboBox quantityComboBox;
        private System.Windows.Forms.ComboBox descriptionIdComboBox;
        private System.Windows.Forms.Label instrumentDescriptionLabel;
        private System.Windows.Forms.ComboBox instrumentDescriptionComboBox;
        private System.Windows.Forms.Label imageUrlLabel;
        private System.Windows.Forms.ComboBox imageUrlComboBox;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.Label imageSearchLabel;
        private System.Windows.Forms.CheckBox autoImageSearchCheckBox;
        private System.Windows.Forms.Label imageSearchPatternLabel;
        private System.Windows.Forms.TextBox imageSearchPatternTextBox;
        private System.Windows.Forms.Label InstrumentVendorLabel;
        private System.Windows.Forms.ComboBox instrumentVendorComboBox;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TextBox delimiterTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox untaggableCombobox;
    }
}