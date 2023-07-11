using System.Runtime.CompilerServices;
using System.Windows.Forms;
using PackingStation.DataSets;

namespace PackingStation.Views
{
    public partial class FrmMain
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
            if (disposing && components is object)
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.RectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.TotalNumber = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslReadPause = new System.Windows.Forms.ToolStripStatusLabel();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.readerPowerBar = new UIControls.WinForms.Controls.ReaderPowerBar();
            this.Label_ShutDown = new System.Windows.Forms.Label();
            this._TopTitle = new System.Windows.Forms.Label();
            this.TextBoxPower = new System.Windows.Forms.TextBox();
            this.LabelPackedInstr = new System.Windows.Forms.Label();
            this.Label_Taken_ID = new System.Windows.Forms.Label();
            this._Button_Control = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabWizardControl = new PackingStation.WizardTabControl();
            this.chooseTaskPage = new System.Windows.Forms.TabPage();
            this.logoutButton = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.viewPackedTraysMenuButton = new DevExpress.XtraEditors.SimpleButton();
            this.instrumentLookupMenuButton = new DevExpress.XtraEditors.SimpleButton();
            this.packTrayMenuButton = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.scanTrayPage = new System.Windows.Forms.TabPage();
            this.scanTrayBackButton = new DevExpress.XtraEditors.SimpleButton();
            this.scanTrayTabDescription = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonScanTray = new DevExpress.XtraEditors.SimpleButton();
            this.textBoxErrorMessageTray = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.selectTrayTypePage = new System.Windows.Forms.TabPage();
            this.selectTrayTypeBackButton = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.startPackingButton = new DevExpress.XtraEditors.SimpleButton();
            this.btnOSK1 = new UIControls.WinForms.Controls.BtnOSK();
            this.messageSelectTrayTypePageTextbox = new System.Windows.Forms.TextBox();
            this.traySearchControl = new DevExpress.XtraEditors.SearchControl();
            this.traysListBoxControl = new DevExpress.XtraEditors.ListBoxControl();
            this.Label_Tray = new System.Windows.Forms.Label();
            this.selectTrayTypeDescription = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.selectTrayTypePictureBox = new System.Windows.Forms.PictureBox();
            this.packTrayPage = new System.Windows.Forms.TabPage();
            this.ButtonPackingNext = new DevExpress.XtraEditors.SimpleButton();
            this.cancelPackingPackTrayPage = new DevExpress.XtraEditors.SimpleButton();
            this.packTrayBackButton = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.exportTrayButton = new DevExpress.XtraEditors.SimpleButton();
            this.PictureBoxTray = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.touchscreenPackingListView = new Caretag_Class.ReactiveUI.Views.TouchscreenPackingListView();
            this.totalInstrumentsLabel = new System.Windows.Forms.Label();
            this.totalTextBox = new System.Windows.Forms.TextBox();
            this.TextBoxDescriptionText = new System.Windows.Forms.TextBox();
            this.trayNameLabel = new System.Windows.Forms.Label();
            this.trayLockedCheckbox = new System.Windows.Forms.CheckBox();
            this.packContainerPage = new System.Windows.Forms.TabPage();
            this.nextContainerPageButton = new DevExpress.XtraEditors.SimpleButton();
            this.cancelPackingContainerPageButton = new DevExpress.XtraEditors.SimpleButton();
            this.containerPageBackButton = new DevExpress.XtraEditors.SimpleButton();
            this.containerGroupbox = new System.Windows.Forms.GroupBox();
            this.scanContainerButton = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMessageContainerPage = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.costCenterPage = new System.Windows.Forms.TabPage();
            this.costCenterNextButton = new DevExpress.XtraEditors.SimpleButton();
            this.cancelPackingCostCenterPageButton = new DevExpress.XtraEditors.SimpleButton();
            this.backCostCenterButton = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.costCenterCommentTextbox = new System.Windows.Forms.TextBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.costTypeListBoxControl = new DevExpress.XtraEditors.ListBoxControl();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.costCenterListBoxControl = new DevExpress.XtraEditors.ListBoxControl();
            this.costCenterMessageTextBox = new System.Windows.Forms.TextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.noCostCenterRadioButton = new System.Windows.Forms.RadioButton();
            this.chooseCostCenterRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.extraInfoTabPage = new System.Windows.Forms.TabPage();
            this.saveButton = new DevExpress.XtraEditors.SimpleButton();
            this.cancelPackingExtraInfoPageButton = new DevExpress.XtraEditors.SimpleButton();
            this.backExtraInfoPageButton = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.sterilizationIndicatorLotNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.extraInfoMessageBox = new System.Windows.Forms.TextBox();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.reportAndFinalizePage = new System.Windows.Forms.TabPage();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.reportFinishButton = new DevExpress.XtraEditors.SimpleButton();
            this.packingReport = new System.Windows.Forms.DataGridView();
            this.Property = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.instrumentLookupPage = new System.Windows.Forms.TabPage();
            this.instrumentLookupBackToMenuButton = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.instrumentNameAndIDLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.instrumentPackingListsDataGridView = new System.Windows.Forms.DataGridView();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChangedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HiddenColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeletedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrayLockColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpecialTextColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scanInstrumentButton = new DevExpress.XtraEditors.SimpleButton();
            this.textBoxMessageInstrumentLookup = new System.Windows.Forms.TextBox();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.viewPackedTrays = new System.Windows.Forms.TabPage();
            this.viewPackedTraysBackToMenuButton = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.packingLogViewDetailsButton = new DevExpress.XtraEditors.SimpleButton();
            this.packingLogGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.timestamp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.trayDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lotNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.packedLocked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.totalInstruments = new DevExpress.XtraGrid.Columns.GridColumn();
            this.totalInstrumentTypes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.totalPackedManually = new DevExpress.XtraGrid.Columns.GridColumn();
            this.packedByUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.detailsColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.packingLogButtonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.packedTrayReportPage = new System.Windows.Forms.TabPage();
            this.trayReportBackButton = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.trayReportPrintButton = new DevExpress.XtraEditors.SimpleButton();
            this.trayReportDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.trayReportContentsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLogOut1 = new UIControls.WinForms.Controls.BtnLogOut();
            this.Caretag_SurgicalDataSet = new PackingStation.DataSets.Caretag_SurgicalDataSet();
            this.ViewPackedTraysBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.View_Packed_TraysTableAdapter = new PackingStation.DataSets.Caretag_SurgicalDataSetTableAdapters.View_Packed_TraysTableAdapter();
            this.btnOSK2 = new UIControls.WinForms.Controls.BtnOSK();
            this.statusStrip1.SuspendLayout();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabWizardControl.SuspendLayout();
            this.chooseTaskPage.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.scanTrayPage.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.selectTrayTypePage.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.traySearchControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.traysListBoxControl)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectTrayTypePictureBox)).BeginInit();
            this.packTrayPage.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxTray)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.packContainerPage.SuspendLayout();
            this.containerGroupbox.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.costCenterPage.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.costTypeListBoxControl)).BeginInit();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.costCenterListBoxControl)).BeginInit();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.extraInfoTabPage.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.reportAndFinalizePage.SuspendLayout();
            this.groupBox14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.packingReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.groupBox19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.instrumentLookupPage.SuspendLayout();
            this.groupBox20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.instrumentPackingListsDataGridView)).BeginInit();
            this.groupBox21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.viewPackedTrays.SuspendLayout();
            this.groupBox22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.packingLogGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.packingLogButtonEdit)).BeginInit();
            this.groupBox23.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.packedTrayReportPage.SuspendLayout();
            this.groupBox24.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trayReportDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            this.groupBox25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trayReportContentsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Caretag_SurgicalDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewPackedTraysBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            // 
            // RectangleShape1
            // 
            resources.ApplyResources(this.RectangleShape1, "RectangleShape1");
            this.RectangleShape1.Name = "RectangleShape1";
            // 
            // TotalNumber
            // 
            resources.ApplyResources(this.TotalNumber, "TotalNumber");
            this.TotalNumber.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.TotalNumber.Name = "TotalNumber";
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus,
            this.tsslReadPause});
            this.statusStrip1.Name = "statusStrip1";
            // 
            // tsslStatus
            // 
            resources.ApplyResources(this.tsslStatus, "tsslStatus");
            this.tsslStatus.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tsslStatus.Name = "tsslStatus";
            // 
            // tsslReadPause
            // 
            this.tsslReadPause.BackColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.tsslReadPause, "tsslReadPause");
            this.tsslReadPause.Name = "tsslReadPause";
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.LightGray;
            this.Panel1.Controls.Add(this.pictureBox10);
            this.Panel1.Controls.Add(this.label6);
            this.Panel1.Controls.Add(this.readerPowerBar);
            this.Panel1.Controls.Add(this.Label_ShutDown);
            this.Panel1.Controls.Add(this._TopTitle);
            resources.ApplyResources(this.Panel1, "Panel1");
            this.Panel1.Name = "Panel1";
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::PackingStation.My.Resources.Resources.caretag_logo;
            resources.ApplyResources(this.pictureBox10, "pictureBox10");
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.TabStop = false;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.LightGray;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Name = "label6";
            // 
            // readerPowerBar
            // 
            this.readerPowerBar.BackColor = System.Drawing.Color.LightGray;
            resources.ApplyResources(this.readerPowerBar, "readerPowerBar");
            this.readerPowerBar.Name = "readerPowerBar";
            // 
            // Label_ShutDown
            // 
            resources.ApplyResources(this.Label_ShutDown, "Label_ShutDown");
            this.Label_ShutDown.Name = "Label_ShutDown";
            // 
            // _TopTitle
            // 
            resources.ApplyResources(this._TopTitle, "_TopTitle");
            this._TopTitle.BackColor = System.Drawing.Color.Transparent;
            this._TopTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this._TopTitle.Name = "_TopTitle";
            // 
            // TextBoxPower
            // 
            this.TextBoxPower.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TextBoxPower.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.TextBoxPower, "TextBoxPower");
            this.TextBoxPower.Name = "TextBoxPower";
            this.TextBoxPower.ReadOnly = true;
            // 
            // LabelPackedInstr
            // 
            resources.ApplyResources(this.LabelPackedInstr, "LabelPackedInstr");
            this.LabelPackedInstr.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.LabelPackedInstr.Name = "LabelPackedInstr";
            // 
            // Label_Taken_ID
            // 
            resources.ApplyResources(this.Label_Taken_ID, "Label_Taken_ID");
            this.Label_Taken_ID.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Taken_ID.Name = "Label_Taken_ID";
            // 
            // _Button_Control
            // 
            this._Button_Control.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this._Button_Control, "_Button_Control");
            this._Button_Control.ForeColor = System.Drawing.Color.Transparent;
            this._Button_Control.Name = "_Button_Control";
            this._Button_Control.Tag = "NOT";
            this._Button_Control.UseVisualStyleBackColor = false;
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabWizardControl);
            // 
            // tabWizardControl
            // 
            this.tabWizardControl.Controls.Add(this.chooseTaskPage);
            this.tabWizardControl.Controls.Add(this.scanTrayPage);
            this.tabWizardControl.Controls.Add(this.selectTrayTypePage);
            this.tabWizardControl.Controls.Add(this.packTrayPage);
            this.tabWizardControl.Controls.Add(this.packContainerPage);
            this.tabWizardControl.Controls.Add(this.costCenterPage);
            this.tabWizardControl.Controls.Add(this.extraInfoTabPage);
            this.tabWizardControl.Controls.Add(this.reportAndFinalizePage);
            this.tabWizardControl.Controls.Add(this.instrumentLookupPage);
            this.tabWizardControl.Controls.Add(this.viewPackedTrays);
            this.tabWizardControl.Controls.Add(this.packedTrayReportPage);
            resources.ApplyResources(this.tabWizardControl, "tabWizardControl");
            this.tabWizardControl.Multiline = true;
            this.tabWizardControl.Name = "tabWizardControl";
            this.tabWizardControl.SelectedIndex = 0;
            // 
            // chooseTaskPage
            // 
            this.chooseTaskPage.BackColor = System.Drawing.Color.White;
            this.chooseTaskPage.Controls.Add(this.logoutButton);
            this.chooseTaskPage.Controls.Add(this.groupBox17);
            this.chooseTaskPage.Controls.Add(this.groupBox18);
            resources.ApplyResources(this.chooseTaskPage, "chooseTaskPage");
            this.chooseTaskPage.Name = "chooseTaskPage";
            // 
            // logoutButton
            // 
            this.logoutButton.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("logoutButton.Appearance.Font")));
            this.logoutButton.Appearance.Options.UseFont = true;
            this.logoutButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.logoutButton.ImageOptions.ImageToTextIndent = 15;
            this.logoutButton.ImageOptions.SvgImage = global::PackingStation.My.Resources.Resources.logout_line_icon;
            this.logoutButton.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            resources.ApplyResources(this.logoutButton, "logoutButton");
            this.logoutButton.Name = "logoutButton";
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.label5);
            this.groupBox17.Controls.Add(this.viewPackedTraysMenuButton);
            this.groupBox17.Controls.Add(this.instrumentLookupMenuButton);
            this.groupBox17.Controls.Add(this.packTrayMenuButton);
            resources.ApplyResources(this.groupBox17, "groupBox17");
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.TabStop = false;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // viewPackedTraysMenuButton
            // 
            this.viewPackedTraysMenuButton.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("viewPackedTraysMenuButton.Appearance.Font")));
            this.viewPackedTraysMenuButton.Appearance.Options.UseFont = true;
            this.viewPackedTraysMenuButton.Appearance.Options.UseTextOptions = true;
            this.viewPackedTraysMenuButton.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.viewPackedTraysMenuButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("viewPackedTraysMenuButton.ImageOptions.Image")));
            this.viewPackedTraysMenuButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.viewPackedTraysMenuButton.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("viewPackedTraysMenuButton.ImageOptions.SvgImage")));
            this.viewPackedTraysMenuButton.ImageOptions.SvgImageSize = new System.Drawing.Size(50, 50);
            resources.ApplyResources(this.viewPackedTraysMenuButton, "viewPackedTraysMenuButton");
            this.viewPackedTraysMenuButton.Name = "viewPackedTraysMenuButton";
            // 
            // instrumentLookupMenuButton
            // 
            this.instrumentLookupMenuButton.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("instrumentLookupMenuButton.Appearance.Font")));
            this.instrumentLookupMenuButton.Appearance.Options.UseFont = true;
            this.instrumentLookupMenuButton.Appearance.Options.UseTextOptions = true;
            this.instrumentLookupMenuButton.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.instrumentLookupMenuButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("instrumentLookupMenuButton.ImageOptions.Image")));
            this.instrumentLookupMenuButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.instrumentLookupMenuButton.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("instrumentLookupMenuButton.ImageOptions.SvgImage")));
            this.instrumentLookupMenuButton.ImageOptions.SvgImageSize = new System.Drawing.Size(50, 50);
            resources.ApplyResources(this.instrumentLookupMenuButton, "instrumentLookupMenuButton");
            this.instrumentLookupMenuButton.Name = "instrumentLookupMenuButton";
            // 
            // packTrayMenuButton
            // 
            this.packTrayMenuButton.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("packTrayMenuButton.Appearance.Font")));
            this.packTrayMenuButton.Appearance.Options.UseFont = true;
            this.packTrayMenuButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("packTrayMenuButton.ImageOptions.Image")));
            this.packTrayMenuButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.packTrayMenuButton.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("packTrayMenuButton.ImageOptions.SvgImage")));
            this.packTrayMenuButton.ImageOptions.SvgImageSize = new System.Drawing.Size(50, 50);
            resources.ApplyResources(this.packTrayMenuButton, "packTrayMenuButton");
            this.packTrayMenuButton.Name = "packTrayMenuButton";
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.pictureBox6);
            resources.ApplyResources(this.groupBox18, "groupBox18");
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::PackingStation.My.Resources.Resources.Caretag_Banner;
            resources.ApplyResources(this.pictureBox6, "pictureBox6");
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.TabStop = false;
            // 
            // scanTrayPage
            // 
            this.scanTrayPage.BackColor = System.Drawing.Color.White;
            this.scanTrayPage.Controls.Add(this.scanTrayBackButton);
            this.scanTrayPage.Controls.Add(this.scanTrayTabDescription);
            this.scanTrayPage.Controls.Add(this.groupBox3);
            this.scanTrayPage.Controls.Add(this.groupBox1);
            resources.ApplyResources(this.scanTrayPage, "scanTrayPage");
            this.scanTrayPage.Name = "scanTrayPage";
            // 
            // scanTrayBackButton
            // 
            this.scanTrayBackButton.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("scanTrayBackButton.Appearance.Font")));
            this.scanTrayBackButton.Appearance.Options.UseFont = true;
            this.scanTrayBackButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.scanTrayBackButton.ImageOptions.ImageToTextIndent = 15;
            this.scanTrayBackButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.scanTrayBackButton.ImageOptions.SvgImage = global::PackingStation.My.Resources.Resources.arrow_round_left_icon;
            this.scanTrayBackButton.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            resources.ApplyResources(this.scanTrayBackButton, "scanTrayBackButton");
            this.scanTrayBackButton.Name = "scanTrayBackButton";
            // 
            // scanTrayTabDescription
            // 
            resources.ApplyResources(this.scanTrayTabDescription, "scanTrayTabDescription");
            this.scanTrayTabDescription.Name = "scanTrayTabDescription";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonScanTray);
            this.groupBox3.Controls.Add(this.textBoxErrorMessageTray);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // buttonScanTray
            // 
            this.buttonScanTray.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("buttonScanTray.Appearance.Font")));
            this.buttonScanTray.Appearance.Options.UseFont = true;
            this.buttonScanTray.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.buttonScanTray.ImageOptions.ImageToTextIndent = 15;
            this.buttonScanTray.ImageOptions.SvgImage = global::PackingStation.My.Resources.Resources.scan_icon;
            this.buttonScanTray.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            resources.ApplyResources(this.buttonScanTray, "buttonScanTray");
            this.buttonScanTray.Name = "buttonScanTray";
            // 
            // textBoxErrorMessageTray
            // 
            resources.ApplyResources(this.textBoxErrorMessageTray, "textBoxErrorMessageTray");
            this.textBoxErrorMessageTray.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxErrorMessageTray.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxErrorMessageTray.Name = "textBoxErrorMessageTray";
            this.textBoxErrorMessageTray.ReadOnly = true;
            this.textBoxErrorMessageTray.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PackingStation.My.Resources.Resources.Caretag_Banner;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // selectTrayTypePage
            // 
            this.selectTrayTypePage.BackColor = System.Drawing.Color.White;
            this.selectTrayTypePage.Controls.Add(this.selectTrayTypeBackButton);
            this.selectTrayTypePage.Controls.Add(this.groupBox4);
            this.selectTrayTypePage.Controls.Add(this.groupBox2);
            resources.ApplyResources(this.selectTrayTypePage, "selectTrayTypePage");
            this.selectTrayTypePage.Name = "selectTrayTypePage";
            // 
            // selectTrayTypeBackButton
            // 
            this.selectTrayTypeBackButton.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("selectTrayTypeBackButton.Appearance.Font")));
            this.selectTrayTypeBackButton.Appearance.Options.UseFont = true;
            this.selectTrayTypeBackButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.selectTrayTypeBackButton.ImageOptions.ImageToTextIndent = 15;
            this.selectTrayTypeBackButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.selectTrayTypeBackButton.ImageOptions.SvgImage = global::PackingStation.My.Resources.Resources.arrow_round_left_icon;
            this.selectTrayTypeBackButton.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            resources.ApplyResources(this.selectTrayTypeBackButton, "selectTrayTypeBackButton");
            this.selectTrayTypeBackButton.Name = "selectTrayTypeBackButton";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.startPackingButton);
            this.groupBox4.Controls.Add(this.btnOSK1);
            this.groupBox4.Controls.Add(this.messageSelectTrayTypePageTextbox);
            this.groupBox4.Controls.Add(this.traySearchControl);
            this.groupBox4.Controls.Add(this.traysListBoxControl);
            this.groupBox4.Controls.Add(this.Label_Tray);
            this.groupBox4.Controls.Add(this.selectTrayTypeDescription);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // startPackingButton
            // 
            this.startPackingButton.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("startPackingButton.Appearance.Font")));
            this.startPackingButton.Appearance.Options.UseFont = true;
            this.startPackingButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.startPackingButton.ImageOptions.ImageToTextIndent = 15;
            this.startPackingButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.startPackingButton.ImageOptions.SvgImage = global::PackingStation.My.Resources.Resources.tray_icon;
            this.startPackingButton.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            resources.ApplyResources(this.startPackingButton, "startPackingButton");
            this.startPackingButton.Name = "startPackingButton";
            // 
            // btnOSK1
            // 
            resources.ApplyResources(this.btnOSK1, "btnOSK1");
            this.btnOSK1.Name = "btnOSK1";
            // 
            // messageSelectTrayTypePageTextbox
            // 
            resources.ApplyResources(this.messageSelectTrayTypePageTextbox, "messageSelectTrayTypePageTextbox");
            this.messageSelectTrayTypePageTextbox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.messageSelectTrayTypePageTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.messageSelectTrayTypePageTextbox.Name = "messageSelectTrayTypePageTextbox";
            this.messageSelectTrayTypePageTextbox.ReadOnly = true;
            this.messageSelectTrayTypePageTextbox.TabStop = false;
            // 
            // traySearchControl
            // 
            resources.ApplyResources(this.traySearchControl, "traySearchControl");
            this.traySearchControl.Name = "traySearchControl";
            this.traySearchControl.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("traySearchControl.Properties.Appearance.Font")));
            this.traySearchControl.Properties.Appearance.Options.UseFont = true;
            this.traySearchControl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            // 
            // traysListBoxControl
            // 
            this.traysListBoxControl.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("traysListBoxControl.Appearance.Font")));
            this.traysListBoxControl.Appearance.Options.UseFont = true;
            this.traysListBoxControl.DisplayMember = "Tray_Name";
            resources.ApplyResources(this.traysListBoxControl, "traysListBoxControl");
            this.traysListBoxControl.Name = "traysListBoxControl";
            this.traysListBoxControl.ValueMember = "Description_ID";
            // 
            // Label_Tray
            // 
            resources.ApplyResources(this.Label_Tray, "Label_Tray");
            this.Label_Tray.ForeColor = System.Drawing.Color.Black;
            this.Label_Tray.Name = "Label_Tray";
            // 
            // selectTrayTypeDescription
            // 
            resources.ApplyResources(this.selectTrayTypeDescription, "selectTrayTypeDescription");
            this.selectTrayTypeDescription.Name = "selectTrayTypeDescription";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.selectTrayTypePictureBox);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // selectTrayTypePictureBox
            // 
            this.selectTrayTypePictureBox.Image = global::PackingStation.My.Resources.Resources.Caretag_Banner;
            resources.ApplyResources(this.selectTrayTypePictureBox, "selectTrayTypePictureBox");
            this.selectTrayTypePictureBox.Name = "selectTrayTypePictureBox";
            this.selectTrayTypePictureBox.TabStop = false;
            // 
            // packTrayPage
            // 
            this.packTrayPage.BackColor = System.Drawing.Color.White;
            this.packTrayPage.Controls.Add(this.ButtonPackingNext);
            this.packTrayPage.Controls.Add(this.cancelPackingPackTrayPage);
            this.packTrayPage.Controls.Add(this.packTrayBackButton);
            this.packTrayPage.Controls.Add(this.groupBox6);
            this.packTrayPage.Controls.Add(this.groupBox5);
            resources.ApplyResources(this.packTrayPage, "packTrayPage");
            this.packTrayPage.Name = "packTrayPage";
            // 
            // ButtonPackingNext
            // 
            this.ButtonPackingNext.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("ButtonPackingNext.Appearance.Font")));
            this.ButtonPackingNext.Appearance.Options.UseFont = true;
            this.ButtonPackingNext.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.ButtonPackingNext.ImageOptions.ImageToTextIndent = 15;
            this.ButtonPackingNext.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.ButtonPackingNext.ImageOptions.SvgImage = global::PackingStation.My.Resources.Resources.arrow_round_right_icon;
            this.ButtonPackingNext.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            resources.ApplyResources(this.ButtonPackingNext, "ButtonPackingNext");
            this.ButtonPackingNext.Name = "ButtonPackingNext";
            // 
            // cancelPackingPackTrayPage
            // 
            this.cancelPackingPackTrayPage.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("cancelPackingPackTrayPage.Appearance.Font")));
            this.cancelPackingPackTrayPage.Appearance.Options.UseFont = true;
            this.cancelPackingPackTrayPage.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.cancelPackingPackTrayPage.ImageOptions.ImageToTextIndent = 15;
            this.cancelPackingPackTrayPage.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.cancelPackingPackTrayPage.ImageOptions.SvgImage = global::PackingStation.My.Resources.Resources.cancel_icon;
            this.cancelPackingPackTrayPage.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            resources.ApplyResources(this.cancelPackingPackTrayPage, "cancelPackingPackTrayPage");
            this.cancelPackingPackTrayPage.Name = "cancelPackingPackTrayPage";
            // 
            // packTrayBackButton
            // 
            this.packTrayBackButton.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("packTrayBackButton.Appearance.Font")));
            this.packTrayBackButton.Appearance.Options.UseFont = true;
            this.packTrayBackButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.packTrayBackButton.ImageOptions.ImageToTextIndent = 15;
            this.packTrayBackButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.packTrayBackButton.ImageOptions.SvgImage = global::PackingStation.My.Resources.Resources.arrow_round_left_icon;
            this.packTrayBackButton.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            resources.ApplyResources(this.packTrayBackButton, "packTrayBackButton");
            this.packTrayBackButton.Name = "packTrayBackButton";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.exportTrayButton);
            this.groupBox6.Controls.Add(this.PictureBoxTray);
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            // 
            // exportTrayButton
            // 
            this.exportTrayButton.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("exportTrayButton.Appearance.Font")));
            this.exportTrayButton.Appearance.Options.UseFont = true;
            this.exportTrayButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.exportTrayButton.ImageOptions.ImageToTextIndent = -5;
            this.exportTrayButton.ImageOptions.SvgImage = global::PackingStation.My.Resources.Resources.xlsx_file_icon;
            this.exportTrayButton.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            resources.ApplyResources(this.exportTrayButton, "exportTrayButton");
            this.exportTrayButton.Name = "exportTrayButton";
            // 
            // PictureBoxTray
            // 
            resources.ApplyResources(this.PictureBoxTray, "PictureBoxTray");
            this.PictureBoxTray.Image = global::PackingStation.My.Resources.Resources.Caretag_Banner;
            this.PictureBoxTray.Name = "PictureBoxTray";
            this.PictureBoxTray.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.touchscreenPackingListView);
            this.groupBox5.Controls.Add(this.totalInstrumentsLabel);
            this.groupBox5.Controls.Add(this.totalTextBox);
            this.groupBox5.Controls.Add(this.TextBoxDescriptionText);
            this.groupBox5.Controls.Add(this.trayNameLabel);
            this.groupBox5.Controls.Add(this.trayLockedCheckbox);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // touchscreenPackingListView
            // 
            resources.ApplyResources(this.touchscreenPackingListView, "touchscreenPackingListView");
            this.touchscreenPackingListView.Name = "touchscreenPackingListView";
            this.touchscreenPackingListView.ViewModel = null;
            // 
            // totalInstrumentsLabel
            // 
            resources.ApplyResources(this.totalInstrumentsLabel, "totalInstrumentsLabel");
            this.totalInstrumentsLabel.Name = "totalInstrumentsLabel";
            // 
            // totalTextBox
            // 
            resources.ApplyResources(this.totalTextBox, "totalTextBox");
            this.totalTextBox.Name = "totalTextBox";
            // 
            // TextBoxDescriptionText
            // 
            resources.ApplyResources(this.TextBoxDescriptionText, "TextBoxDescriptionText");
            this.TextBoxDescriptionText.Name = "TextBoxDescriptionText";
            // 
            // trayNameLabel
            // 
            resources.ApplyResources(this.trayNameLabel, "trayNameLabel");
            this.trayNameLabel.Name = "trayNameLabel";
            // 
            // trayLockedCheckbox
            // 
            resources.ApplyResources(this.trayLockedCheckbox, "trayLockedCheckbox");
            this.trayLockedCheckbox.Name = "trayLockedCheckbox";
            this.trayLockedCheckbox.UseVisualStyleBackColor = true;
            // 
            // packContainerPage
            // 
            this.packContainerPage.BackColor = System.Drawing.Color.White;
            this.packContainerPage.Controls.Add(this.nextContainerPageButton);
            this.packContainerPage.Controls.Add(this.cancelPackingContainerPageButton);
            this.packContainerPage.Controls.Add(this.containerPageBackButton);
            this.packContainerPage.Controls.Add(this.containerGroupbox);
            this.packContainerPage.Controls.Add(this.groupBox7);
            resources.ApplyResources(this.packContainerPage, "packContainerPage");
            this.packContainerPage.Name = "packContainerPage";
            // 
            // nextContainerPageButton
            // 
            this.nextContainerPageButton.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("nextContainerPageButton.Appearance.Font")));
            this.nextContainerPageButton.Appearance.Options.UseFont = true;
            this.nextContainerPageButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.nextContainerPageButton.ImageOptions.ImageToTextIndent = 15;
            this.nextContainerPageButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.nextContainerPageButton.ImageOptions.SvgImage = global::PackingStation.My.Resources.Resources.arrow_round_right_icon;
            this.nextContainerPageButton.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            resources.ApplyResources(this.nextContainerPageButton, "nextContainerPageButton");
            this.nextContainerPageButton.Name = "nextContainerPageButton";
            // 
            // cancelPackingContainerPageButton
            // 
            this.cancelPackingContainerPageButton.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("cancelPackingContainerPageButton.Appearance.Font")));
            this.cancelPackingContainerPageButton.Appearance.Options.UseFont = true;
            this.cancelPackingContainerPageButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.cancelPackingContainerPageButton.ImageOptions.ImageToTextIndent = 15;
            this.cancelPackingContainerPageButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.cancelPackingContainerPageButton.ImageOptions.SvgImage = global::PackingStation.My.Resources.Resources.cancel_icon;
            this.cancelPackingContainerPageButton.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            resources.ApplyResources(this.cancelPackingContainerPageButton, "cancelPackingContainerPageButton");
            this.cancelPackingContainerPageButton.Name = "cancelPackingContainerPageButton";
            // 
            // containerPageBackButton
            // 
            this.containerPageBackButton.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("containerPageBackButton.Appearance.Font")));
            this.containerPageBackButton.Appearance.Options.UseFont = true;
            this.containerPageBackButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.containerPageBackButton.ImageOptions.ImageToTextIndent = 15;
            this.containerPageBackButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.containerPageBackButton.ImageOptions.SvgImage = global::PackingStation.My.Resources.Resources.arrow_round_left_icon;
            this.containerPageBackButton.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            resources.ApplyResources(this.containerPageBackButton, "containerPageBackButton");
            this.containerPageBackButton.Name = "containerPageBackButton";
            // 
            // containerGroupbox
            // 
            this.containerGroupbox.Controls.Add(this.scanContainerButton);
            this.containerGroupbox.Controls.Add(this.label1);
            this.containerGroupbox.Controls.Add(this.textBoxMessageContainerPage);
            resources.ApplyResources(this.containerGroupbox, "containerGroupbox");
            this.containerGroupbox.Name = "containerGroupbox";
            this.containerGroupbox.TabStop = false;
            // 
            // scanContainerButton
            // 
            this.scanContainerButton.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("scanContainerButton.Appearance.Font")));
            this.scanContainerButton.Appearance.Options.UseFont = true;
            this.scanContainerButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.scanContainerButton.ImageOptions.ImageToTextIndent = 15;
            this.scanContainerButton.ImageOptions.SvgImage = global::PackingStation.My.Resources.Resources.scan_icon;
            this.scanContainerButton.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            resources.ApplyResources(this.scanContainerButton, "scanContainerButton");
            this.scanContainerButton.Name = "scanContainerButton";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // textBoxMessageContainerPage
            // 
            resources.ApplyResources(this.textBoxMessageContainerPage, "textBoxMessageContainerPage");
            this.textBoxMessageContainerPage.Name = "textBoxMessageContainerPage";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.pictureBox2);
            resources.ApplyResources(this.groupBox7, "groupBox7");
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.TabStop = false;
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Image = global::PackingStation.My.Resources.Resources.Caretag_Banner;
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // costCenterPage
            // 
            this.costCenterPage.BackColor = System.Drawing.Color.White;
            this.costCenterPage.Controls.Add(this.costCenterNextButton);
            this.costCenterPage.Controls.Add(this.cancelPackingCostCenterPageButton);
            this.costCenterPage.Controls.Add(this.backCostCenterButton);
            this.costCenterPage.Controls.Add(this.groupBox8);
            this.costCenterPage.Controls.Add(this.groupBox9);
            resources.ApplyResources(this.costCenterPage, "costCenterPage");
            this.costCenterPage.Name = "costCenterPage";
            // 
            // costCenterNextButton
            // 
            this.costCenterNextButton.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("costCenterNextButton.Appearance.Font")));
            this.costCenterNextButton.Appearance.Options.UseFont = true;
            this.costCenterNextButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.costCenterNextButton.ImageOptions.ImageToTextIndent = 15;
            this.costCenterNextButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.costCenterNextButton.ImageOptions.SvgImage = global::PackingStation.My.Resources.Resources.arrow_round_right_icon;
            this.costCenterNextButton.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            resources.ApplyResources(this.costCenterNextButton, "costCenterNextButton");
            this.costCenterNextButton.Name = "costCenterNextButton";
            // 
            // cancelPackingCostCenterPageButton
            // 
            this.cancelPackingCostCenterPageButton.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("cancelPackingCostCenterPageButton.Appearance.Font")));
            this.cancelPackingCostCenterPageButton.Appearance.Options.UseFont = true;
            this.cancelPackingCostCenterPageButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.cancelPackingCostCenterPageButton.ImageOptions.ImageToTextIndent = 15;
            this.cancelPackingCostCenterPageButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.cancelPackingCostCenterPageButton.ImageOptions.SvgImage = global::PackingStation.My.Resources.Resources.cancel_icon;
            this.cancelPackingCostCenterPageButton.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            resources.ApplyResources(this.cancelPackingCostCenterPageButton, "cancelPackingCostCenterPageButton");
            this.cancelPackingCostCenterPageButton.Name = "cancelPackingCostCenterPageButton";
            // 
            // backCostCenterButton
            // 
            this.backCostCenterButton.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("backCostCenterButton.Appearance.Font")));
            this.backCostCenterButton.Appearance.Options.UseFont = true;
            this.backCostCenterButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.backCostCenterButton.ImageOptions.ImageToTextIndent = 15;
            this.backCostCenterButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.backCostCenterButton.ImageOptions.SvgImage = global::PackingStation.My.Resources.Resources.arrow_round_left_icon;
            this.backCostCenterButton.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            resources.ApplyResources(this.backCostCenterButton, "backCostCenterButton");
            this.backCostCenterButton.Name = "backCostCenterButton";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.groupBox13);
            this.groupBox8.Controls.Add(this.groupBox12);
            this.groupBox8.Controls.Add(this.groupBox11);
            this.groupBox8.Controls.Add(this.costCenterMessageTextBox);
            this.groupBox8.Controls.Add(this.groupBox10);
            resources.ApplyResources(this.groupBox8, "groupBox8");
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.TabStop = false;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.costCenterCommentTextbox);
            resources.ApplyResources(this.groupBox13, "groupBox13");
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.TabStop = false;
            // 
            // costCenterCommentTextbox
            // 
            resources.ApplyResources(this.costCenterCommentTextbox, "costCenterCommentTextbox");
            this.costCenterCommentTextbox.Name = "costCenterCommentTextbox";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.costTypeListBoxControl);
            resources.ApplyResources(this.groupBox12, "groupBox12");
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.TabStop = false;
            // 
            // costTypeListBoxControl
            // 
            this.costTypeListBoxControl.DisplayMember = "Cost_Type1";
            resources.ApplyResources(this.costTypeListBoxControl, "costTypeListBoxControl");
            this.costTypeListBoxControl.Name = "costTypeListBoxControl";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.costCenterListBoxControl);
            resources.ApplyResources(this.groupBox11, "groupBox11");
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.TabStop = false;
            // 
            // costCenterListBoxControl
            // 
            this.costCenterListBoxControl.DisplayMember = "Cost_Center_Name";
            resources.ApplyResources(this.costCenterListBoxControl, "costCenterListBoxControl");
            this.costCenterListBoxControl.Name = "costCenterListBoxControl";
            // 
            // costCenterMessageTextBox
            // 
            resources.ApplyResources(this.costCenterMessageTextBox, "costCenterMessageTextBox");
            this.costCenterMessageTextBox.Name = "costCenterMessageTextBox";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.noCostCenterRadioButton);
            this.groupBox10.Controls.Add(this.chooseCostCenterRadioButton);
            resources.ApplyResources(this.groupBox10, "groupBox10");
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.TabStop = false;
            // 
            // noCostCenterRadioButton
            // 
            resources.ApplyResources(this.noCostCenterRadioButton, "noCostCenterRadioButton");
            this.noCostCenterRadioButton.Name = "noCostCenterRadioButton";
            this.noCostCenterRadioButton.TabStop = true;
            this.noCostCenterRadioButton.UseVisualStyleBackColor = true;
            // 
            // chooseCostCenterRadioButton
            // 
            resources.ApplyResources(this.chooseCostCenterRadioButton, "chooseCostCenterRadioButton");
            this.chooseCostCenterRadioButton.Name = "chooseCostCenterRadioButton";
            this.chooseCostCenterRadioButton.TabStop = true;
            this.chooseCostCenterRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.pictureBox3);
            resources.ApplyResources(this.groupBox9, "groupBox9");
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.TabStop = false;
            // 
            // pictureBox3
            // 
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.Image = global::PackingStation.My.Resources.Resources.Caretag_Banner;
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // extraInfoTabPage
            // 
            this.extraInfoTabPage.BackColor = System.Drawing.Color.White;
            this.extraInfoTabPage.Controls.Add(this.saveButton);
            this.extraInfoTabPage.Controls.Add(this.cancelPackingExtraInfoPageButton);
            this.extraInfoTabPage.Controls.Add(this.backExtraInfoPageButton);
            this.extraInfoTabPage.Controls.Add(this.groupBox15);
            this.extraInfoTabPage.Controls.Add(this.groupBox16);
            resources.ApplyResources(this.extraInfoTabPage, "extraInfoTabPage");
            this.extraInfoTabPage.Name = "extraInfoTabPage";
            // 
            // saveButton
            // 
            this.saveButton.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("saveButton.Appearance.Font")));
            this.saveButton.Appearance.Options.UseFont = true;
            this.saveButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.saveButton.ImageOptions.ImageToTextIndent = 15;
            this.saveButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.saveButton.ImageOptions.SvgImage = global::PackingStation.My.Resources.Resources.confirm_icon;
            this.saveButton.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            // 
            // cancelPackingExtraInfoPageButton
            // 
            this.cancelPackingExtraInfoPageButton.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("cancelPackingExtraInfoPageButton.Appearance.Font")));
            this.cancelPackingExtraInfoPageButton.Appearance.Options.UseFont = true;
            this.cancelPackingExtraInfoPageButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.cancelPackingExtraInfoPageButton.ImageOptions.ImageToTextIndent = 15;
            this.cancelPackingExtraInfoPageButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.cancelPackingExtraInfoPageButton.ImageOptions.SvgImage = global::PackingStation.My.Resources.Resources.cancel_icon;
            this.cancelPackingExtraInfoPageButton.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            resources.ApplyResources(this.cancelPackingExtraInfoPageButton, "cancelPackingExtraInfoPageButton");
            this.cancelPackingExtraInfoPageButton.Name = "cancelPackingExtraInfoPageButton";
            // 
            // backExtraInfoPageButton
            // 
            this.backExtraInfoPageButton.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("backExtraInfoPageButton.Appearance.Font")));
            this.backExtraInfoPageButton.Appearance.Options.UseFont = true;
            this.backExtraInfoPageButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.backExtraInfoPageButton.ImageOptions.ImageToTextIndent = 15;
            this.backExtraInfoPageButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.backExtraInfoPageButton.ImageOptions.SvgImage = global::PackingStation.My.Resources.Resources.arrow_round_left_icon;
            this.backExtraInfoPageButton.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            resources.ApplyResources(this.backExtraInfoPageButton, "backExtraInfoPageButton");
            this.backExtraInfoPageButton.Name = "backExtraInfoPageButton";
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.btnOSK2);
            this.groupBox15.Controls.Add(this.sterilizationIndicatorLotNumber);
            this.groupBox15.Controls.Add(this.label4);
            this.groupBox15.Controls.Add(this.extraInfoMessageBox);
            resources.ApplyResources(this.groupBox15, "groupBox15");
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.TabStop = false;
            // 
            // sterilizationIndicatorLotNumber
            // 
            resources.ApplyResources(this.sterilizationIndicatorLotNumber, "sterilizationIndicatorLotNumber");
            this.sterilizationIndicatorLotNumber.Name = "sterilizationIndicatorLotNumber";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // extraInfoMessageBox
            // 
            resources.ApplyResources(this.extraInfoMessageBox, "extraInfoMessageBox");
            this.extraInfoMessageBox.Name = "extraInfoMessageBox";
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.pictureBox7);
            resources.ApplyResources(this.groupBox16, "groupBox16");
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.TabStop = false;
            // 
            // pictureBox7
            // 
            resources.ApplyResources(this.pictureBox7, "pictureBox7");
            this.pictureBox7.Image = global::PackingStation.My.Resources.Resources.Caretag_Banner;
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.TabStop = false;
            // 
            // reportAndFinalizePage
            // 
            this.reportAndFinalizePage.BackColor = System.Drawing.Color.White;
            this.reportAndFinalizePage.Controls.Add(this.groupBox14);
            this.reportAndFinalizePage.Controls.Add(this.groupBox19);
            resources.ApplyResources(this.reportAndFinalizePage, "reportAndFinalizePage");
            this.reportAndFinalizePage.Name = "reportAndFinalizePage";
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.reportFinishButton);
            this.groupBox14.Controls.Add(this.packingReport);
            this.groupBox14.Controls.Add(this.numericUpDown1);
            this.groupBox14.Controls.Add(this.pictureBox5);
            this.groupBox14.Controls.Add(this.label3);
            this.groupBox14.Controls.Add(this.label2);
            this.groupBox14.Controls.Add(this.textBox2);
            resources.ApplyResources(this.groupBox14, "groupBox14");
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.TabStop = false;
            // 
            // reportFinishButton
            // 
            this.reportFinishButton.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("reportFinishButton.Appearance.Font")));
            this.reportFinishButton.Appearance.Options.UseFont = true;
            this.reportFinishButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.reportFinishButton.ImageOptions.ImageToTextIndent = 15;
            this.reportFinishButton.ImageOptions.SvgImage = global::PackingStation.My.Resources.Resources.racing_flags_icon;
            this.reportFinishButton.ImageOptions.SvgImageSize = new System.Drawing.Size(60, 34);
            resources.ApplyResources(this.reportFinishButton, "reportFinishButton");
            this.reportFinishButton.Name = "reportFinishButton";
            // 
            // packingReport
            // 
            this.packingReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.packingReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Property,
            this.Value});
            resources.ApplyResources(this.packingReport, "packingReport");
            this.packingReport.Name = "packingReport";
            this.packingReport.RowHeadersVisible = false;
            this.packingReport.RowTemplate.Height = 24;
            // 
            // Property
            // 
            this.Property.DataPropertyName = "Item1";
            resources.ApplyResources(this.Property, "Property");
            this.Property.Name = "Property";
            // 
            // Value
            // 
            this.Value.DataPropertyName = "Item2";
            resources.ApplyResources(this.Value, "Value");
            this.Value.Name = "Value";
            // 
            // numericUpDown1
            // 
            resources.ApplyResources(this.numericUpDown1, "numericUpDown1");
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::PackingStation.My.Resources.Resources.file_checkmark_icon;
            resources.ApplyResources(this.pictureBox5, "pictureBox5");
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.TabStop = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.pictureBox4);
            resources.ApplyResources(this.groupBox19, "groupBox19");
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.TabStop = false;
            // 
            // pictureBox4
            // 
            resources.ApplyResources(this.pictureBox4, "pictureBox4");
            this.pictureBox4.Image = global::PackingStation.My.Resources.Resources.Caretag_Banner;
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.TabStop = false;
            // 
            // instrumentLookupPage
            // 
            this.instrumentLookupPage.BackColor = System.Drawing.Color.White;
            this.instrumentLookupPage.Controls.Add(this.instrumentLookupBackToMenuButton);
            this.instrumentLookupPage.Controls.Add(this.groupBox20);
            this.instrumentLookupPage.Controls.Add(this.groupBox21);
            resources.ApplyResources(this.instrumentLookupPage, "instrumentLookupPage");
            this.instrumentLookupPage.Name = "instrumentLookupPage";
            // 
            // instrumentLookupBackToMenuButton
            // 
            this.instrumentLookupBackToMenuButton.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("instrumentLookupBackToMenuButton.Appearance.Font")));
            this.instrumentLookupBackToMenuButton.Appearance.Options.UseFont = true;
            this.instrumentLookupBackToMenuButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.instrumentLookupBackToMenuButton.ImageOptions.ImageToTextIndent = 15;
            this.instrumentLookupBackToMenuButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.instrumentLookupBackToMenuButton.ImageOptions.SvgImage = global::PackingStation.My.Resources.Resources.arrow_round_left_icon;
            this.instrumentLookupBackToMenuButton.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            resources.ApplyResources(this.instrumentLookupBackToMenuButton, "instrumentLookupBackToMenuButton");
            this.instrumentLookupBackToMenuButton.Name = "instrumentLookupBackToMenuButton";
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.instrumentNameAndIDLabel);
            this.groupBox20.Controls.Add(this.label10);
            this.groupBox20.Controls.Add(this.instrumentPackingListsDataGridView);
            this.groupBox20.Controls.Add(this.scanInstrumentButton);
            this.groupBox20.Controls.Add(this.textBoxMessageInstrumentLookup);
            resources.ApplyResources(this.groupBox20, "groupBox20");
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.TabStop = false;
            // 
            // instrumentNameAndIDLabel
            // 
            resources.ApplyResources(this.instrumentNameAndIDLabel, "instrumentNameAndIDLabel");
            this.instrumentNameAndIDLabel.Name = "instrumentNameAndIDLabel";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // instrumentPackingListsDataGridView
            // 
            this.instrumentPackingListsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.instrumentPackingListsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.DescriptionColumn,
            this.ChangedColumn,
            this.HiddenColumn,
            this.DeletedColumn,
            this.DescriptionIDColumn,
            this.TrayLockColumn,
            this.CostIDColumn,
            this.SpecialTextColumn});
            resources.ApplyResources(this.instrumentPackingListsDataGridView, "instrumentPackingListsDataGridView");
            this.instrumentPackingListsDataGridView.Name = "instrumentPackingListsDataGridView";
            this.instrumentPackingListsDataGridView.RowHeadersVisible = false;
            this.instrumentPackingListsDataGridView.RowTemplate.Height = 24;
            // 
            // NameColumn
            // 
            this.NameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NameColumn.DataPropertyName = "Tray_Name";
            resources.ApplyResources(this.NameColumn, "NameColumn");
            this.NameColumn.Name = "NameColumn";
            // 
            // DescriptionColumn
            // 
            this.DescriptionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DescriptionColumn.DataPropertyName = "Tray_Description1";
            resources.ApplyResources(this.DescriptionColumn, "DescriptionColumn");
            this.DescriptionColumn.Name = "DescriptionColumn";
            // 
            // ChangedColumn
            // 
            this.ChangedColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ChangedColumn.DataPropertyName = "Date_Changed";
            resources.ApplyResources(this.ChangedColumn, "ChangedColumn");
            this.ChangedColumn.Name = "ChangedColumn";
            // 
            // HiddenColumn
            // 
            this.HiddenColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.HiddenColumn.DataPropertyName = "Hide_Tray";
            resources.ApplyResources(this.HiddenColumn, "HiddenColumn");
            this.HiddenColumn.Name = "HiddenColumn";
            // 
            // DeletedColumn
            // 
            this.DeletedColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DeletedColumn.DataPropertyName = "Deleted_Tray";
            resources.ApplyResources(this.DeletedColumn, "DeletedColumn");
            this.DeletedColumn.Name = "DeletedColumn";
            // 
            // DescriptionIDColumn
            // 
            this.DescriptionIDColumn.DataPropertyName = "Description_ID";
            resources.ApplyResources(this.DescriptionIDColumn, "DescriptionIDColumn");
            this.DescriptionIDColumn.Name = "DescriptionIDColumn";
            // 
            // TrayLockColumn
            // 
            this.TrayLockColumn.DataPropertyName = "Tray_Lock";
            resources.ApplyResources(this.TrayLockColumn, "TrayLockColumn");
            this.TrayLockColumn.Name = "TrayLockColumn";
            // 
            // CostIDColumn
            // 
            this.CostIDColumn.DataPropertyName = "Cost_ID";
            resources.ApplyResources(this.CostIDColumn, "CostIDColumn");
            this.CostIDColumn.Name = "CostIDColumn";
            // 
            // SpecialTextColumn
            // 
            this.SpecialTextColumn.DataPropertyName = "Special_Text";
            resources.ApplyResources(this.SpecialTextColumn, "SpecialTextColumn");
            this.SpecialTextColumn.Name = "SpecialTextColumn";
            // 
            // scanInstrumentButton
            // 
            this.scanInstrumentButton.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("scanInstrumentButton.Appearance.Font")));
            this.scanInstrumentButton.Appearance.Options.UseFont = true;
            this.scanInstrumentButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.scanInstrumentButton.ImageOptions.ImageToTextIndent = 15;
            this.scanInstrumentButton.ImageOptions.SvgImage = global::PackingStation.My.Resources.Resources.scan_icon;
            this.scanInstrumentButton.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            resources.ApplyResources(this.scanInstrumentButton, "scanInstrumentButton");
            this.scanInstrumentButton.Name = "scanInstrumentButton";
            // 
            // textBoxMessageInstrumentLookup
            // 
            resources.ApplyResources(this.textBoxMessageInstrumentLookup, "textBoxMessageInstrumentLookup");
            this.textBoxMessageInstrumentLookup.Name = "textBoxMessageInstrumentLookup";
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.pictureBox9);
            resources.ApplyResources(this.groupBox21, "groupBox21");
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.TabStop = false;
            // 
            // pictureBox9
            // 
            resources.ApplyResources(this.pictureBox9, "pictureBox9");
            this.pictureBox9.Image = global::PackingStation.My.Resources.Resources.Caretag_Banner;
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.TabStop = false;
            // 
            // viewPackedTrays
            // 
            this.viewPackedTrays.BackColor = System.Drawing.Color.White;
            this.viewPackedTrays.Controls.Add(this.viewPackedTraysBackToMenuButton);
            this.viewPackedTrays.Controls.Add(this.groupBox22);
            this.viewPackedTrays.Controls.Add(this.groupBox23);
            resources.ApplyResources(this.viewPackedTrays, "viewPackedTrays");
            this.viewPackedTrays.Name = "viewPackedTrays";
            // 
            // viewPackedTraysBackToMenuButton
            // 
            this.viewPackedTraysBackToMenuButton.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("viewPackedTraysBackToMenuButton.Appearance.Font")));
            this.viewPackedTraysBackToMenuButton.Appearance.Options.UseFont = true;
            this.viewPackedTraysBackToMenuButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.viewPackedTraysBackToMenuButton.ImageOptions.ImageToTextIndent = 15;
            this.viewPackedTraysBackToMenuButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.viewPackedTraysBackToMenuButton.ImageOptions.SvgImage = global::PackingStation.My.Resources.Resources.arrow_round_left_icon;
            this.viewPackedTraysBackToMenuButton.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            resources.ApplyResources(this.viewPackedTraysBackToMenuButton, "viewPackedTraysBackToMenuButton");
            this.viewPackedTraysBackToMenuButton.Name = "viewPackedTraysBackToMenuButton";
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.packingLogViewDetailsButton);
            this.groupBox22.Controls.Add(this.packingLogGridControl);
            this.groupBox22.Controls.Add(this.textBox3);
            resources.ApplyResources(this.groupBox22, "groupBox22");
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.TabStop = false;
            // 
            // packingLogViewDetailsButton
            // 
            this.packingLogViewDetailsButton.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("packingLogViewDetailsButton.Appearance.Font")));
            this.packingLogViewDetailsButton.Appearance.Options.UseFont = true;
            this.packingLogViewDetailsButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.packingLogViewDetailsButton.ImageOptions.ImageToTextIndent = 15;
            this.packingLogViewDetailsButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.packingLogViewDetailsButton.ImageOptions.SvgImage = global::PackingStation.My.Resources.Resources.info_note_icon;
            this.packingLogViewDetailsButton.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            resources.ApplyResources(this.packingLogViewDetailsButton, "packingLogViewDetailsButton");
            this.packingLogViewDetailsButton.Name = "packingLogViewDetailsButton";
            // 
            // packingLogGridControl
            // 
            resources.ApplyResources(this.packingLogGridControl, "packingLogGridControl");
            this.packingLogGridControl.MainView = this.gridView1;
            this.packingLogGridControl.Name = "packingLogGridControl";
            this.packingLogGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.packingLogButtonEdit});
            this.packingLogGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.timestamp,
            this.trayDescription,
            this.lotNumber,
            this.packedLocked,
            this.totalInstruments,
            this.totalInstrumentTypes,
            this.totalPackedManually,
            this.packedByUser,
            this.detailsColumn});
            this.gridView1.GridControl = this.packingLogGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.timestamp, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // id
            // 
            resources.ApplyResources(this.id, "id");
            this.id.FieldName = "Id";
            this.id.Name = "id";
            // 
            // timestamp
            // 
            resources.ApplyResources(this.timestamp, "timestamp");
            this.timestamp.FieldName = "Timestamp";
            this.timestamp.Name = "timestamp";
            // 
            // trayDescription
            // 
            resources.ApplyResources(this.trayDescription, "trayDescription");
            this.trayDescription.FieldName = "TrayDescription";
            this.trayDescription.Name = "trayDescription";
            // 
            // lotNumber
            // 
            resources.ApplyResources(this.lotNumber, "lotNumber");
            this.lotNumber.FieldName = "SterilizationIndicatorLotNumber";
            this.lotNumber.Name = "lotNumber";
            // 
            // packedLocked
            // 
            resources.ApplyResources(this.packedLocked, "packedLocked");
            this.packedLocked.FieldName = "PackedLocked";
            this.packedLocked.Name = "packedLocked";
            // 
            // totalInstruments
            // 
            resources.ApplyResources(this.totalInstruments, "totalInstruments");
            this.totalInstruments.FieldName = "TotalInstruments";
            this.totalInstruments.Name = "totalInstruments";
            // 
            // totalInstrumentTypes
            // 
            resources.ApplyResources(this.totalInstrumentTypes, "totalInstrumentTypes");
            this.totalInstrumentTypes.FieldName = "TotalInstrumentTypes";
            this.totalInstrumentTypes.Name = "totalInstrumentTypes";
            // 
            // totalPackedManually
            // 
            resources.ApplyResources(this.totalPackedManually, "totalPackedManually");
            this.totalPackedManually.FieldName = "TotalPackedManually";
            this.totalPackedManually.Name = "totalPackedManually";
            // 
            // packedByUser
            // 
            resources.ApplyResources(this.packedByUser, "packedByUser");
            this.packedByUser.FieldName = "PackedByUser";
            this.packedByUser.Name = "packedByUser";
            // 
            // detailsColumn
            // 
            resources.ApplyResources(this.detailsColumn, "detailsColumn");
            this.detailsColumn.ColumnEdit = this.packingLogButtonEdit;
            this.detailsColumn.Name = "detailsColumn";
            // 
            // packingLogButtonEdit
            // 
            resources.ApplyResources(this.packingLogButtonEdit, "packingLogButtonEdit");
            this.packingLogButtonEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.packingLogButtonEdit.Name = "packingLogButtonEdit";
            this.packingLogButtonEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.packingLogButtonEdit_ButtonPressed);
            // 
            // textBox3
            // 
            resources.ApplyResources(this.textBox3, "textBox3");
            this.textBox3.Name = "textBox3";
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.pictureBox8);
            resources.ApplyResources(this.groupBox23, "groupBox23");
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.TabStop = false;
            // 
            // pictureBox8
            // 
            resources.ApplyResources(this.pictureBox8, "pictureBox8");
            this.pictureBox8.Image = global::PackingStation.My.Resources.Resources.Caretag_Banner;
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.TabStop = false;
            // 
            // packedTrayReportPage
            // 
            this.packedTrayReportPage.BackColor = System.Drawing.Color.White;
            this.packedTrayReportPage.Controls.Add(this.trayReportBackButton);
            this.packedTrayReportPage.Controls.Add(this.groupBox24);
            this.packedTrayReportPage.Controls.Add(this.groupBox25);
            resources.ApplyResources(this.packedTrayReportPage, "packedTrayReportPage");
            this.packedTrayReportPage.Name = "packedTrayReportPage";
            // 
            // trayReportBackButton
            // 
            this.trayReportBackButton.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("trayReportBackButton.Appearance.Font")));
            this.trayReportBackButton.Appearance.Options.UseFont = true;
            this.trayReportBackButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.trayReportBackButton.ImageOptions.ImageToTextIndent = 15;
            this.trayReportBackButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.trayReportBackButton.ImageOptions.SvgImage = global::PackingStation.My.Resources.Resources.arrow_round_left_icon;
            this.trayReportBackButton.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            resources.ApplyResources(this.trayReportBackButton, "trayReportBackButton");
            this.trayReportBackButton.Name = "trayReportBackButton";
            // 
            // groupBox24
            // 
            this.groupBox24.Controls.Add(this.trayReportPrintButton);
            this.groupBox24.Controls.Add(this.trayReportDataGridView);
            this.groupBox24.Controls.Add(this.numericUpDown2);
            this.groupBox24.Controls.Add(this.pictureBox11);
            this.groupBox24.Controls.Add(this.label7);
            this.groupBox24.Controls.Add(this.label8);
            this.groupBox24.Controls.Add(this.textBox4);
            resources.ApplyResources(this.groupBox24, "groupBox24");
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.TabStop = false;
            // 
            // trayReportPrintButton
            // 
            this.trayReportPrintButton.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("trayReportPrintButton.Appearance.Font")));
            this.trayReportPrintButton.Appearance.Options.UseFont = true;
            this.trayReportPrintButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.trayReportPrintButton.ImageOptions.ImageToTextIndent = 15;
            this.trayReportPrintButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.trayReportPrintButton.ImageOptions.SvgImage = global::PackingStation.My.Resources.Resources.printer_icon;
            this.trayReportPrintButton.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            resources.ApplyResources(this.trayReportPrintButton, "trayReportPrintButton");
            this.trayReportPrintButton.Name = "trayReportPrintButton";
            // 
            // trayReportDataGridView
            // 
            this.trayReportDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.trayReportDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            resources.ApplyResources(this.trayReportDataGridView, "trayReportDataGridView");
            this.trayReportDataGridView.Name = "trayReportDataGridView";
            this.trayReportDataGridView.RowHeadersVisible = false;
            this.trayReportDataGridView.RowTemplate.Height = 24;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Item1";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Item2";
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // numericUpDown2
            // 
            resources.ApplyResources(this.numericUpDown2, "numericUpDown2");
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pictureBox11
            // 
            this.pictureBox11.Image = global::PackingStation.My.Resources.Resources.file_checkmark_icon;
            resources.ApplyResources(this.pictureBox11, "pictureBox11");
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.TabStop = false;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // textBox4
            // 
            resources.ApplyResources(this.textBox4, "textBox4");
            this.textBox4.Name = "textBox4";
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.trayReportContentsDataGridView);
            resources.ApplyResources(this.groupBox25, "groupBox25");
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.TabStop = false;
            // 
            // trayReportContentsDataGridView
            // 
            this.trayReportContentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.trayReportContentsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            resources.ApplyResources(this.trayReportContentsDataGridView, "trayReportContentsDataGridView");
            this.trayReportContentsDataGridView.Name = "trayReportContentsDataGridView";
            this.trayReportContentsDataGridView.RowHeadersVisible = false;
            this.trayReportContentsDataGridView.RowTemplate.Height = 24;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Item1";
            resources.ApplyResources(this.dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Item2";
            resources.ApplyResources(this.dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // btnLogOut1
            // 
            this.btnLogOut1.ButtonType = UIControls.WinForms.Controls.BtnLogOutLabel.Logout;
            resources.ApplyResources(this.btnLogOut1, "btnLogOut1");
            this.btnLogOut1.Name = "btnLogOut1";
            // 
            // Caretag_SurgicalDataSet
            // 
            this.Caretag_SurgicalDataSet.DataSetName = "Caretag_SurgicalDataSet";
            this.Caretag_SurgicalDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ViewPackedTraysBindingSource
            // 
            this.ViewPackedTraysBindingSource.DataMember = "View_Packed_Trays";
            this.ViewPackedTraysBindingSource.DataSource = this.Caretag_SurgicalDataSet;
            // 
            // View_Packed_TraysTableAdapter
            // 
            this.View_Packed_TraysTableAdapter.ClearBeforeFill = true;
            // 
            // btnOSK2
            // 
            resources.ApplyResources(this.btnOSK2, "btnOSK2");
            this.btnOSK2.Name = "btnOSK2";
            // 
            // FrmMain
            // 
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnLogOut1);
            this.Controls.Add(this._Button_Control);
            this.Controls.Add(this.Label_Taken_ID);
            this.Controls.Add(this.LabelPackedInstr);
            this.Controls.Add(this.TextBoxPower);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.TotalNumber);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.ToolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabWizardControl.ResumeLayout(false);
            this.chooseTaskPage.ResumeLayout(false);
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.scanTrayPage.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.selectTrayTypePage.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.traySearchControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.traysListBoxControl)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.selectTrayTypePictureBox)).EndInit();
            this.packTrayPage.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxTray)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.packContainerPage.ResumeLayout(false);
            this.containerGroupbox.ResumeLayout(false);
            this.containerGroupbox.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.costCenterPage.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.costTypeListBoxControl)).EndInit();
            this.groupBox11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.costCenterListBoxControl)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.extraInfoTabPage.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.reportAndFinalizePage.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.packingReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.groupBox19.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.instrumentLookupPage.ResumeLayout(false);
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.instrumentPackingListsDataGridView)).EndInit();
            this.groupBox21.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.viewPackedTrays.ResumeLayout(false);
            this.groupBox22.ResumeLayout(false);
            this.groupBox22.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.packingLogGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.packingLogButtonEdit)).EndInit();
            this.groupBox23.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.packedTrayReportPage.ResumeLayout(false);
            this.groupBox24.ResumeLayout(false);
            this.groupBox24.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trayReportDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            this.groupBox25.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trayReportContentsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Caretag_SurgicalDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewPackedTraysBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStripMenuItem settingsToolStripMenuItem;
        internal ToolTip ToolTip1;
        
        internal Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
        internal Microsoft.VisualBasic.PowerPacks.RectangleShape RectangleShape1;
        
        internal Label TotalNumber;
        
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tsslStatus;
        private ToolStripStatusLabel tsslReadPause;
        internal Panel Panel1;
        
        private Label _TopTitle;

        internal Label TopTitle
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TopTitle;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TopTitle != null)
                {
                }

                _TopTitle = value;
                if (_TopTitle != null)
                {
                }
            }
        }
        

        internal TextBox TextBoxPower;
        private Label Label_Tray;
        
        internal Label LabelPackedInstr;
        

        internal Button Button_Finish
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return Button_Finish;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (Button_Finish != null)
                {
                }

                Button_Finish = value;
                if (Button_Finish != null)
                {
                }
            }
        }
        

        internal Label Label_Taken_ID;

        internal Label Label_ShutDown;
        private Button _Button_Control;

        internal Button Button_Control
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button_Control;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button_Control != null)
                {
                }

                _Button_Control = value;
                if (_Button_Control != null)
                {
                }
            }
        }
        
        internal Caretag_SurgicalDataSet Caretag_SurgicalDataSet;
        internal BindingSource ViewPackedTraysBindingSource;
        internal DataSets.Caretag_SurgicalDataSetTableAdapters.View_Packed_TraysTableAdapter View_Packed_TraysTableAdapter;
        private UIControls.WinForms.Controls.ReaderPowerBar readerPowerBar;
        private UIControls.WinForms.Controls.BtnLogOut btnLogOut1;
        private TabPage scanTrayPage;
        private TabPage selectTrayTypePage;
        private Label selectTrayTypeDescription;
        private TabPage packTrayPage;
        private WizardTabControl tabWizardControl;
        private Label scanTrayTabDescription;
        private SplitContainer splitContainer1;
        private TextBox textBoxErrorMessageTray;
        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private PictureBox selectTrayTypePictureBox;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private TextBox TextBoxDescriptionText;
        private Label trayNameLabel;
        private PictureBox PictureBoxTray;
        private CheckBox trayLockedCheckbox;
        private GroupBox groupBox6;
        private GroupBox groupBox5;
        private Label totalInstrumentsLabel;
        private TextBox totalTextBox;
        private DevExpress.XtraEditors.ListBoxControl traysListBoxControl;
        private DevExpress.XtraEditors.SearchControl traySearchControl;
        private TabPage packContainerPage;
        private GroupBox groupBox7;
        private PictureBox pictureBox2;
        private GroupBox containerGroupbox;
        private Label label1;
        private TextBox textBoxMessageContainerPage;
        private TabPage costCenterPage;
        private TabPage reportAndFinalizePage;
        private TabPage instrumentLookupPage;
        private TextBox messageSelectTrayTypePageTextbox;
        private GroupBox groupBox8;
        private TextBox costCenterMessageTextBox;
        private GroupBox groupBox10;
        private RadioButton noCostCenterRadioButton;
        private RadioButton chooseCostCenterRadioButton;
        private GroupBox groupBox9;
        private PictureBox pictureBox3;
        private GroupBox groupBox13;
        private TextBox costCenterCommentTextbox;
        private GroupBox groupBox12;
        private DevExpress.XtraEditors.ListBoxControl costTypeListBoxControl;
        private GroupBox groupBox11;
        private DevExpress.XtraEditors.ListBoxControl costCenterListBoxControl;
        private GroupBox groupBox14;
        private Label label3;
        private TextBox textBox2;
        private GroupBox groupBox19;
        private DataGridView packingReport;
        private NumericUpDown numericUpDown1;
        private TabPage extraInfoTabPage;
        private GroupBox groupBox15;
        private TextBox extraInfoMessageBox;
        private GroupBox groupBox16;
        private PictureBox pictureBox7;
        private TextBox sterilizationIndicatorLotNumber;
        private Label label4;
        private TabPage chooseTaskPage;
        private GroupBox groupBox17;
        private DevExpress.XtraEditors.SimpleButton packTrayMenuButton;
        private GroupBox groupBox18;
        private PictureBox pictureBox6;
        private Label label5;
        private DevExpress.XtraEditors.SimpleButton viewPackedTraysMenuButton;
        private DevExpress.XtraEditors.SimpleButton instrumentLookupMenuButton;
        private TabPage viewPackedTrays;
        private GroupBox groupBox20;
        private TextBox textBoxMessageInstrumentLookup;
        private GroupBox groupBox21;
        private GroupBox groupBox22;
        private TextBox textBox3;
        private GroupBox groupBox23;
        private PictureBox pictureBox8;
        private DevExpress.XtraGrid.GridControl packingLogGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn timestamp;
        private DevExpress.XtraGrid.Columns.GridColumn trayDescription;
        private DevExpress.XtraGrid.Columns.GridColumn lotNumber;
        private DevExpress.XtraGrid.Columns.GridColumn packedLocked;
        private DevExpress.XtraGrid.Columns.GridColumn totalInstruments;
        private DevExpress.XtraGrid.Columns.GridColumn totalInstrumentTypes;
        private DevExpress.XtraGrid.Columns.GridColumn totalPackedManually;
        private DevExpress.XtraGrid.Columns.GridColumn packedByUser;
        private DevExpress.XtraGrid.Columns.GridColumn detailsColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit packingLogButtonEdit;
        private Label label6;
        private PictureBox pictureBox10;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private PictureBox pictureBox5;
        private Label label2;
        private PictureBox pictureBox4;
        private TabPage packedTrayReportPage;
        private GroupBox groupBox24;
        private DataGridView trayReportDataGridView;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private NumericUpDown numericUpDown2;
        private PictureBox pictureBox11;
        private Label label7;
        private Label label8;
        private TextBox textBox4;
        private GroupBox groupBox25;
        private DataGridView trayReportContentsDataGridView;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn Property;
        private DataGridViewTextBoxColumn Value;
        private Caretag_Class.ReactiveUI.Views.TouchscreenPackingListView touchscreenPackingListView;
        private DevExpress.XtraEditors.SimpleButton instrumentLookupBackToMenuButton;
        private DevExpress.XtraEditors.SimpleButton scanInstrumentButton;
        private Label label10;
        private DataGridView instrumentPackingListsDataGridView;
        private DataGridViewTextBoxColumn NameColumn;
        private DataGridViewTextBoxColumn DescriptionColumn;
        private DataGridViewTextBoxColumn ChangedColumn;
        private DataGridViewTextBoxColumn HiddenColumn;
        private DataGridViewTextBoxColumn DeletedColumn;
        private DataGridViewTextBoxColumn DescriptionIDColumn;
        private DataGridViewTextBoxColumn TrayLockColumn;
        private DataGridViewTextBoxColumn CostIDColumn;
        private DataGridViewTextBoxColumn SpecialTextColumn;
        private Label instrumentNameAndIDLabel;
        private PictureBox pictureBox9;
        private DevExpress.XtraEditors.SimpleButton logoutButton;
        private DevExpress.XtraEditors.SimpleButton scanTrayBackButton;
        private DevExpress.XtraEditors.SimpleButton buttonScanTray;
        private DevExpress.XtraEditors.SimpleButton selectTrayTypeBackButton;
        private DevExpress.XtraEditors.SimpleButton startPackingButton;
        private UIControls.WinForms.Controls.BtnOSK btnOSK1;
        private DevExpress.XtraEditors.SimpleButton cancelPackingPackTrayPage;
        private DevExpress.XtraEditors.SimpleButton packTrayBackButton;
        private DevExpress.XtraEditors.SimpleButton ButtonPackingNext;
        private DevExpress.XtraEditors.SimpleButton nextContainerPageButton;
        private DevExpress.XtraEditors.SimpleButton cancelPackingContainerPageButton;
        private DevExpress.XtraEditors.SimpleButton containerPageBackButton;
        private DevExpress.XtraEditors.SimpleButton scanContainerButton;
        private DevExpress.XtraEditors.SimpleButton costCenterNextButton;
        private DevExpress.XtraEditors.SimpleButton cancelPackingCostCenterPageButton;
        private DevExpress.XtraEditors.SimpleButton backCostCenterButton;
        private DevExpress.XtraEditors.SimpleButton saveButton;
        private DevExpress.XtraEditors.SimpleButton cancelPackingExtraInfoPageButton;
        private DevExpress.XtraEditors.SimpleButton backExtraInfoPageButton;
        private DevExpress.XtraEditors.SimpleButton reportFinishButton;
        private DevExpress.XtraEditors.SimpleButton viewPackedTraysBackToMenuButton;
        private DevExpress.XtraEditors.SimpleButton packingLogViewDetailsButton;
        private DevExpress.XtraEditors.SimpleButton trayReportBackButton;
        private DevExpress.XtraEditors.SimpleButton trayReportPrintButton;
        private DevExpress.XtraEditors.SimpleButton exportTrayButton;
        private UIControls.WinForms.Controls.BtnOSK btnOSK2;
    }
}