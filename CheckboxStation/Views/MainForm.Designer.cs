using System;
using System.Drawing;
using System.Windows.Forms;

namespace CheckboxStation.Views
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this._TopTitle = new System.Windows.Forms.Label();
            this.amountColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabs = new System.Windows.Forms.TabControl();
            this.scanPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.reportButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.expectedLabel = new System.Windows.Forms.Label();
            this.expectedDataLabel = new System.Windows.Forms.Label();
            this.instrumentTotalCountDataLabel = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tagCountTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.scanInProgressLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.scannedLabel = new System.Windows.Forms.Label();
            this.scannedDataLabel = new System.Windows.Forms.Label();
            this.assetScanGridView = new Caretag_Class.ReactiveUI.Views.TouchscreenPackingListView();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkinButton = new System.Windows.Forms.Button();
            this.checkoutButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.trayLabel = new System.Windows.Forms.Label();
            this.trayDataLabel = new System.Windows.Forms.Label();
            this.scanExtraButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.packingListStatusLabel = new System.Windows.Forms.Label();
            this.packingListIcon = new System.Windows.Forms.PictureBox();
            this.scanButton = new System.Windows.Forms.Button();
            this.operationPage = new System.Windows.Forms.TabPage();
            this.showFinishedCheckbox = new System.Windows.Forms.CheckBox();
            this.toLabel = new System.Windows.Forms.Label();
            this.fromLabel = new System.Windows.Forms.Label();
            this.toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.operationStatusGroupBox = new System.Windows.Forms.GroupBox();
            this.operatingRoomDataLabel = new System.Windows.Forms.Label();
            this.operatingRoomLabel = new System.Windows.Forms.Label();
            this.instrumentsCheckedOutDataLabel = new System.Windows.Forms.Label();
            this.instrumentsCheckedInDataLabel = new System.Windows.Forms.Label();
            this.totalInstrumentsDataLabel = new System.Windows.Forms.Label();
            this.inspectInstrumentsButton = new System.Windows.Forms.Button();
            this.assetsAccountForLabel = new System.Windows.Forms.Label();
            this.activeInstrumentsLabel = new System.Windows.Forms.Label();
            this.totalAssetCount = new System.Windows.Forms.Label();
            this.stateDataLabel = new System.Windows.Forms.Label();
            this.stateLabel = new System.Windows.Forms.Label();
            this.newOperationButton = new System.Windows.Forms.Button();
            this.operationFinishButton = new System.Windows.Forms.Button();
            this.operationStartButton = new System.Windows.Forms.Button();
            this.operationsListBox = new System.Windows.Forms.ListBox();
            this.lifeCyclePage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lifecycleTagCountTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.lifecycleScanProgressLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.lifecycleScannedTagsLabel = new System.Windows.Forms.Label();
            this.lifecycleScannedTagsDataLabel = new System.Windows.Forms.Label();
            this.lifecycleScanProgressBar = new System.Windows.Forms.ProgressBar();
            this.lvInstrumentsLifecycle = new System.Windows.Forms.ListView();
            this.instrumentLyfecycleTypeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.instrumentLyfecycleDescriptionColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lifecycleHeaderLabel = new System.Windows.Forms.Label();
            this.btnScanLifecycleInstruments = new System.Windows.Forms.Button();
            this.btnSendToService = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbInstrumentsLifecycle = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblInstrumentsLifecycle = new System.Windows.Forms.Label();
            this.lifecycleTotalInstrumentsDataLabel = new System.Windows.Forms.Label();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabs.SuspendLayout();
            this.scanPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tagCountTablePanel.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.packingListIcon)).BeginInit();
            this.operationPage.SuspendLayout();
            this.operationStatusGroupBox.SuspendLayout();
            this.lifeCyclePage.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.lifecycleTagCountTablePanel.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.DarkOrange;
            this.Panel1.Controls.Add(this.tableLayoutPanel3);
            resources.ApplyResources(this.Panel1, "Panel1");
            this.Panel1.Name = "Panel1";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.LightGray;
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this._TopTitle, 0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // _TopTitle
            // 
            resources.ApplyResources(this._TopTitle, "_TopTitle");
            this._TopTitle.BackColor = System.Drawing.Color.Transparent;
            this._TopTitle.ForeColor = System.Drawing.Color.Black;
            this._TopTitle.Name = "_TopTitle";
            // 
            // amountColumn
            // 
            resources.ApplyResources(this.amountColumn, "amountColumn");
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
            // tabs
            // 
            this.tabs.Controls.Add(this.scanPage);
            this.tabs.Controls.Add(this.operationPage);
            this.tabs.Controls.Add(this.lifeCyclePage);
            resources.ApplyResources(this.tabs, "tabs");
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            // 
            // scanPage
            // 
            this.scanPage.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.scanPage, "scanPage");
            this.scanPage.Name = "scanPage";
            this.scanPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.reportButton, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.scanExtraButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.scanButton, 4, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // reportButton
            // 
            resources.ApplyResources(this.reportButton, "reportButton");
            this.reportButton.Name = "reportButton";
            this.reportButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel6
            // 
            resources.ApplyResources(this.tableLayoutPanel6, "tableLayoutPanel6");
            this.tableLayoutPanel6.Controls.Add(this.expectedLabel, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.expectedDataLabel, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.instrumentTotalCountDataLabel, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.totalLabel, 0, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            // 
            // expectedLabel
            // 
            resources.ApplyResources(this.expectedLabel, "expectedLabel");
            this.expectedLabel.Name = "expectedLabel";
            // 
            // expectedDataLabel
            // 
            resources.ApplyResources(this.expectedDataLabel, "expectedDataLabel");
            this.expectedDataLabel.Name = "expectedDataLabel";
            // 
            // instrumentTotalCountDataLabel
            // 
            resources.ApplyResources(this.instrumentTotalCountDataLabel, "instrumentTotalCountDataLabel");
            this.instrumentTotalCountDataLabel.Name = "instrumentTotalCountDataLabel";
            // 
            // totalLabel
            // 
            resources.ApplyResources(this.totalLabel, "totalLabel");
            this.totalLabel.Name = "totalLabel";
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 5);
            this.panel2.Controls.Add(this.tagCountTablePanel);
            this.panel2.Controls.Add(this.assetScanGridView);
            this.panel2.Controls.Add(this.progressBar);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // tagCountTablePanel
            // 
            resources.ApplyResources(this.tagCountTablePanel, "tagCountTablePanel");
            this.tagCountTablePanel.Controls.Add(this.scanInProgressLabel, 0, 0);
            this.tagCountTablePanel.Controls.Add(this.flowLayoutPanel6, 0, 1);
            this.tagCountTablePanel.Name = "tagCountTablePanel";
            // 
            // scanInProgressLabel
            // 
            resources.ApplyResources(this.scanInProgressLabel, "scanInProgressLabel");
            this.scanInProgressLabel.Name = "scanInProgressLabel";
            // 
            // flowLayoutPanel6
            // 
            resources.ApplyResources(this.flowLayoutPanel6, "flowLayoutPanel6");
            this.flowLayoutPanel6.Controls.Add(this.scannedLabel);
            this.flowLayoutPanel6.Controls.Add(this.scannedDataLabel);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            // 
            // scannedLabel
            // 
            resources.ApplyResources(this.scannedLabel, "scannedLabel");
            this.scannedLabel.Name = "scannedLabel";
            // 
            // scannedDataLabel
            // 
            resources.ApplyResources(this.scannedDataLabel, "scannedDataLabel");
            this.scannedDataLabel.Name = "scannedDataLabel";
            // 
            // assetScanGridView
            // 
            resources.ApplyResources(this.assetScanGridView, "assetScanGridView");
            this.assetScanGridView.Name = "assetScanGridView";
            this.assetScanGridView.ViewModel = null;
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 5);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // flowLayoutPanel4
            // 
            resources.ApplyResources(this.flowLayoutPanel4, "flowLayoutPanel4");
            this.flowLayoutPanel4.Controls.Add(this.checkinButton);
            this.flowLayoutPanel4.Controls.Add(this.checkoutButton);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            // 
            // checkinButton
            // 
            resources.ApplyResources(this.checkinButton, "checkinButton");
            this.checkinButton.Name = "checkinButton";
            this.checkinButton.UseVisualStyleBackColor = true;
            // 
            // checkoutButton
            // 
            resources.ApplyResources(this.checkoutButton, "checkoutButton");
            this.checkoutButton.Name = "checkoutButton";
            this.checkoutButton.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.trayLabel);
            this.flowLayoutPanel1.Controls.Add(this.trayDataLabel);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // trayLabel
            // 
            resources.ApplyResources(this.trayLabel, "trayLabel");
            this.trayLabel.Name = "trayLabel";
            // 
            // trayDataLabel
            // 
            resources.ApplyResources(this.trayDataLabel, "trayDataLabel");
            this.trayDataLabel.Name = "trayDataLabel";
            this.trayDataLabel.LocationChanged += new System.EventHandler(this.trayDataLabel_LocationChanged);
            this.trayDataLabel.TextChanged += new System.EventHandler(this.trayDataLabel_LocationChanged);
            // 
            // scanExtraButton
            // 
            resources.ApplyResources(this.scanExtraButton, "scanExtraButton");
            this.scanExtraButton.Name = "scanExtraButton";
            this.scanExtraButton.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
            this.flowLayoutPanel2.Controls.Add(this.packingListStatusLabel);
            this.flowLayoutPanel2.Controls.Add(this.packingListIcon);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // packingListStatusLabel
            // 
            resources.ApplyResources(this.packingListStatusLabel, "packingListStatusLabel");
            this.packingListStatusLabel.Name = "packingListStatusLabel";
            // 
            // packingListIcon
            // 
            resources.ApplyResources(this.packingListIcon, "packingListIcon");
            this.packingListIcon.Name = "packingListIcon";
            this.packingListIcon.TabStop = false;
            // 
            // scanButton
            // 
            resources.ApplyResources(this.scanButton, "scanButton");
            this.scanButton.Name = "scanButton";
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Click += new System.EventHandler(this.scanButton_Click);
            // 
            // operationPage
            // 
            this.operationPage.Controls.Add(this.showFinishedCheckbox);
            this.operationPage.Controls.Add(this.toLabel);
            this.operationPage.Controls.Add(this.fromLabel);
            this.operationPage.Controls.Add(this.toDateTimePicker);
            this.operationPage.Controls.Add(this.fromDateTimePicker);
            this.operationPage.Controls.Add(this.operationStatusGroupBox);
            this.operationPage.Controls.Add(this.newOperationButton);
            this.operationPage.Controls.Add(this.operationFinishButton);
            this.operationPage.Controls.Add(this.operationStartButton);
            this.operationPage.Controls.Add(this.operationsListBox);
            resources.ApplyResources(this.operationPage, "operationPage");
            this.operationPage.Name = "operationPage";
            this.operationPage.UseVisualStyleBackColor = true;
            // 
            // showFinishedCheckbox
            // 
            resources.ApplyResources(this.showFinishedCheckbox, "showFinishedCheckbox");
            this.showFinishedCheckbox.Name = "showFinishedCheckbox";
            this.showFinishedCheckbox.UseVisualStyleBackColor = true;
            // 
            // toLabel
            // 
            resources.ApplyResources(this.toLabel, "toLabel");
            this.toLabel.Name = "toLabel";
            // 
            // fromLabel
            // 
            resources.ApplyResources(this.fromLabel, "fromLabel");
            this.fromLabel.Name = "fromLabel";
            // 
            // toDateTimePicker
            // 
            resources.ApplyResources(this.toDateTimePicker, "toDateTimePicker");
            this.toDateTimePicker.Name = "toDateTimePicker";
            // 
            // fromDateTimePicker
            // 
            resources.ApplyResources(this.fromDateTimePicker, "fromDateTimePicker");
            this.fromDateTimePicker.Name = "fromDateTimePicker";
            // 
            // operationStatusGroupBox
            // 
            this.operationStatusGroupBox.Controls.Add(this.operatingRoomDataLabel);
            this.operationStatusGroupBox.Controls.Add(this.operatingRoomLabel);
            this.operationStatusGroupBox.Controls.Add(this.instrumentsCheckedOutDataLabel);
            this.operationStatusGroupBox.Controls.Add(this.instrumentsCheckedInDataLabel);
            this.operationStatusGroupBox.Controls.Add(this.totalInstrumentsDataLabel);
            this.operationStatusGroupBox.Controls.Add(this.inspectInstrumentsButton);
            this.operationStatusGroupBox.Controls.Add(this.assetsAccountForLabel);
            this.operationStatusGroupBox.Controls.Add(this.activeInstrumentsLabel);
            this.operationStatusGroupBox.Controls.Add(this.totalAssetCount);
            this.operationStatusGroupBox.Controls.Add(this.stateDataLabel);
            this.operationStatusGroupBox.Controls.Add(this.stateLabel);
            resources.ApplyResources(this.operationStatusGroupBox, "operationStatusGroupBox");
            this.operationStatusGroupBox.Name = "operationStatusGroupBox";
            this.operationStatusGroupBox.TabStop = false;
            // 
            // operatingRoomDataLabel
            // 
            resources.ApplyResources(this.operatingRoomDataLabel, "operatingRoomDataLabel");
            this.operatingRoomDataLabel.Name = "operatingRoomDataLabel";
            // 
            // operatingRoomLabel
            // 
            resources.ApplyResources(this.operatingRoomLabel, "operatingRoomLabel");
            this.operatingRoomLabel.Name = "operatingRoomLabel";
            // 
            // instrumentsCheckedOutDataLabel
            // 
            resources.ApplyResources(this.instrumentsCheckedOutDataLabel, "instrumentsCheckedOutDataLabel");
            this.instrumentsCheckedOutDataLabel.Name = "instrumentsCheckedOutDataLabel";
            // 
            // instrumentsCheckedInDataLabel
            // 
            resources.ApplyResources(this.instrumentsCheckedInDataLabel, "instrumentsCheckedInDataLabel");
            this.instrumentsCheckedInDataLabel.Name = "instrumentsCheckedInDataLabel";
            // 
            // totalInstrumentsDataLabel
            // 
            resources.ApplyResources(this.totalInstrumentsDataLabel, "totalInstrumentsDataLabel");
            this.totalInstrumentsDataLabel.Name = "totalInstrumentsDataLabel";
            // 
            // inspectInstrumentsButton
            // 
            resources.ApplyResources(this.inspectInstrumentsButton, "inspectInstrumentsButton");
            this.inspectInstrumentsButton.Name = "inspectInstrumentsButton";
            this.inspectInstrumentsButton.UseVisualStyleBackColor = true;
            // 
            // assetsAccountForLabel
            // 
            resources.ApplyResources(this.assetsAccountForLabel, "assetsAccountForLabel");
            this.assetsAccountForLabel.Name = "assetsAccountForLabel";
            // 
            // activeInstrumentsLabel
            // 
            resources.ApplyResources(this.activeInstrumentsLabel, "activeInstrumentsLabel");
            this.activeInstrumentsLabel.Name = "activeInstrumentsLabel";
            // 
            // totalAssetCount
            // 
            resources.ApplyResources(this.totalAssetCount, "totalAssetCount");
            this.totalAssetCount.Name = "totalAssetCount";
            // 
            // stateDataLabel
            // 
            resources.ApplyResources(this.stateDataLabel, "stateDataLabel");
            this.stateDataLabel.Name = "stateDataLabel";
            // 
            // stateLabel
            // 
            resources.ApplyResources(this.stateLabel, "stateLabel");
            this.stateLabel.Name = "stateLabel";
            // 
            // newOperationButton
            // 
            resources.ApplyResources(this.newOperationButton, "newOperationButton");
            this.newOperationButton.Name = "newOperationButton";
            this.newOperationButton.UseVisualStyleBackColor = true;
            // 
            // operationFinishButton
            // 
            resources.ApplyResources(this.operationFinishButton, "operationFinishButton");
            this.operationFinishButton.Name = "operationFinishButton";
            this.operationFinishButton.UseVisualStyleBackColor = true;
            // 
            // operationStartButton
            // 
            resources.ApplyResources(this.operationStartButton, "operationStartButton");
            this.operationStartButton.Name = "operationStartButton";
            this.operationStartButton.UseVisualStyleBackColor = true;
            // 
            // operationsListBox
            // 
            this.operationsListBox.FormattingEnabled = true;
            resources.ApplyResources(this.operationsListBox, "operationsListBox");
            this.operationsListBox.Name = "operationsListBox";
            // 
            // lifeCyclePage
            // 
            this.lifeCyclePage.Controls.Add(this.tableLayoutPanel4);
            resources.ApplyResources(this.lifeCyclePage, "lifeCyclePage");
            this.lifeCyclePage.Name = "lifeCyclePage";
            this.lifeCyclePage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.lifecycleHeaderLabel, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnScanLifecycleInstruments, 2, 2);
            this.tableLayoutPanel4.Controls.Add(this.btnSendToService, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.panel4, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel3, 0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // panel3
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.panel3, 2);
            this.panel3.Controls.Add(this.lifecycleTagCountTablePanel);
            this.panel3.Controls.Add(this.lifecycleScanProgressBar);
            this.panel3.Controls.Add(this.lvInstrumentsLifecycle);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // lifecycleTagCountTablePanel
            // 
            resources.ApplyResources(this.lifecycleTagCountTablePanel, "lifecycleTagCountTablePanel");
            this.lifecycleTagCountTablePanel.Controls.Add(this.lifecycleScanProgressLabel, 0, 0);
            this.lifecycleTagCountTablePanel.Controls.Add(this.flowLayoutPanel5, 0, 1);
            this.lifecycleTagCountTablePanel.Name = "lifecycleTagCountTablePanel";
            // 
            // lifecycleScanProgressLabel
            // 
            resources.ApplyResources(this.lifecycleScanProgressLabel, "lifecycleScanProgressLabel");
            this.lifecycleScanProgressLabel.Name = "lifecycleScanProgressLabel";
            // 
            // flowLayoutPanel5
            // 
            resources.ApplyResources(this.flowLayoutPanel5, "flowLayoutPanel5");
            this.flowLayoutPanel5.Controls.Add(this.lifecycleScannedTagsLabel);
            this.flowLayoutPanel5.Controls.Add(this.lifecycleScannedTagsDataLabel);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            // 
            // lifecycleScannedTagsLabel
            // 
            resources.ApplyResources(this.lifecycleScannedTagsLabel, "lifecycleScannedTagsLabel");
            this.lifecycleScannedTagsLabel.Name = "lifecycleScannedTagsLabel";
            // 
            // lifecycleScannedTagsDataLabel
            // 
            resources.ApplyResources(this.lifecycleScannedTagsDataLabel, "lifecycleScannedTagsDataLabel");
            this.lifecycleScannedTagsDataLabel.Name = "lifecycleScannedTagsDataLabel";
            // 
            // lifecycleScanProgressBar
            // 
            resources.ApplyResources(this.lifecycleScanProgressBar, "lifecycleScanProgressBar");
            this.lifecycleScanProgressBar.Name = "lifecycleScanProgressBar";
            // 
            // lvInstrumentsLifecycle
            // 
            this.lvInstrumentsLifecycle.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.instrumentLyfecycleTypeColumn,
            this.instrumentLyfecycleDescriptionColumn});
            resources.ApplyResources(this.lvInstrumentsLifecycle, "lvInstrumentsLifecycle");
            this.lvInstrumentsLifecycle.FullRowSelect = true;
            this.lvInstrumentsLifecycle.HideSelection = false;
            this.lvInstrumentsLifecycle.MultiSelect = false;
            this.lvInstrumentsLifecycle.Name = "lvInstrumentsLifecycle";
            this.lvInstrumentsLifecycle.ShowGroups = false;
            this.lvInstrumentsLifecycle.ShowItemToolTips = true;
            this.lvInstrumentsLifecycle.UseCompatibleStateImageBehavior = false;
            this.lvInstrumentsLifecycle.View = System.Windows.Forms.View.Details;
            this.lvInstrumentsLifecycle.SelectedIndexChanged += new System.EventHandler(this.lvInstrumentsLifecycle_SelectedIndexChanged);
            // 
            // instrumentLyfecycleTypeColumn
            // 
            resources.ApplyResources(this.instrumentLyfecycleTypeColumn, "instrumentLyfecycleTypeColumn");
            // 
            // instrumentLyfecycleDescriptionColumn
            // 
            resources.ApplyResources(this.instrumentLyfecycleDescriptionColumn, "instrumentLyfecycleDescriptionColumn");
            // 
            // lifecycleHeaderLabel
            // 
            resources.ApplyResources(this.lifecycleHeaderLabel, "lifecycleHeaderLabel");
            this.lifecycleHeaderLabel.Name = "lifecycleHeaderLabel";
            // 
            // btnScanLifecycleInstruments
            // 
            resources.ApplyResources(this.btnScanLifecycleInstruments, "btnScanLifecycleInstruments");
            this.btnScanLifecycleInstruments.Name = "btnScanLifecycleInstruments";
            this.btnScanLifecycleInstruments.UseVisualStyleBackColor = true;
            // 
            // btnSendToService
            // 
            resources.ApplyResources(this.btnSendToService, "btnSendToService");
            this.btnSendToService.Name = "btnSendToService";
            this.btnSendToService.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lbInstrumentsLifecycle);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // lbInstrumentsLifecycle
            // 
            this.lbInstrumentsLifecycle.DisplayMember = "DisplayText";
            resources.ApplyResources(this.lbInstrumentsLifecycle, "lbInstrumentsLifecycle");
            this.lbInstrumentsLifecycle.FormattingEnabled = true;
            this.lbInstrumentsLifecycle.Name = "lbInstrumentsLifecycle";
            this.lbInstrumentsLifecycle.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbInstrumentsLifecycle.ValueMember = "Id";
            // 
            // flowLayoutPanel3
            // 
            resources.ApplyResources(this.flowLayoutPanel3, "flowLayoutPanel3");
            this.flowLayoutPanel3.Controls.Add(this.lblInstrumentsLifecycle);
            this.flowLayoutPanel3.Controls.Add(this.lifecycleTotalInstrumentsDataLabel);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            // 
            // lblInstrumentsLifecycle
            // 
            resources.ApplyResources(this.lblInstrumentsLifecycle, "lblInstrumentsLifecycle");
            this.lblInstrumentsLifecycle.Name = "lblInstrumentsLifecycle";
            // 
            // lifecycleTotalInstrumentsDataLabel
            // 
            resources.ApplyResources(this.lifecycleTotalInstrumentsDataLabel, "lifecycleTotalInstrumentsDataLabel");
            this.lifecycleTotalInstrumentsDataLabel.Name = "lifecycleTotalInstrumentsDataLabel";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "Manual";
            resources.ApplyResources(this.dataGridViewCheckBoxColumn1, "dataGridViewCheckBoxColumn1");
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.Panel1);
            this.Name = "MainForm";
            this.Panel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tabs.ResumeLayout(false);
            this.scanPage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tagCountTablePanel.ResumeLayout(false);
            this.tagCountTablePanel.PerformLayout();
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.packingListIcon)).EndInit();
            this.operationPage.ResumeLayout(false);
            this.operationPage.PerformLayout();
            this.operationStatusGroupBox.ResumeLayout(false);
            this.operationStatusGroupBox.PerformLayout();
            this.lifeCyclePage.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.lifecycleTagCountTablePanel.ResumeLayout(false);
            this.lifecycleTagCountTablePanel.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btnSendToService;

        private System.Windows.Forms.Label lifecycleHeaderLabel;

        private System.Windows.Forms.Label lblInstrumentsLifecycle;

        private System.Windows.Forms.TabPage lifeCyclePage;

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.Label _TopTitle;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage scanPage;
        private System.Windows.Forms.TabPage operationPage;
        private System.Windows.Forms.GroupBox operationStatusGroupBox;
        private System.Windows.Forms.Button inspectInstrumentsButton;
        private System.Windows.Forms.Label assetsAccountForLabel;
        private System.Windows.Forms.Label activeInstrumentsLabel;
        private System.Windows.Forms.Label totalAssetCount;
        private System.Windows.Forms.Label stateDataLabel;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Button newOperationButton;
        private System.Windows.Forms.Button operationFinishButton;
        private System.Windows.Forms.Button operationStartButton;
        private System.Windows.Forms.ListBox operationsListBox;
        private System.Windows.Forms.Label instrumentsCheckedOutDataLabel;
        private System.Windows.Forms.Label instrumentsCheckedInDataLabel;
        private System.Windows.Forms.Label totalInstrumentsDataLabel;
        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.Label operatingRoomDataLabel;
        private System.Windows.Forms.Label operatingRoomLabel;
        private System.Windows.Forms.ColumnHeader type;
        private System.Windows.Forms.ColumnHeader description;
        private System.Windows.Forms.ColumnHeader status;
        private System.Windows.Forms.ColumnHeader amountColumn;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.DateTimePicker toDateTimePicker;
        private System.Windows.Forms.DateTimePicker fromDateTimePicker;
        private System.Windows.Forms.CheckBox showFinishedCheckbox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lifecycleScanProgressLabel;
        private Label lifecycleScannedTagsLabel;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private Panel panel3;
        private TableLayoutPanel tableLayoutPanel6;
        private Label expectedLabel;
        private Label expectedDataLabel;
        private Label instrumentTotalCountDataLabel;
        private Label totalLabel;
        private FlowLayoutPanel flowLayoutPanel4;
        private Button checkinButton;
        private Button checkoutButton;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label trayLabel;
        private Label trayDataLabel;
        private Button scanExtraButton;
        private FlowLayoutPanel flowLayoutPanel2;
        private PictureBox packingListIcon;
        private Label packingListStatusLabel;
        private Button btnScanLifecycleInstruments;
        private ProgressBar lifecycleScanProgressBar;
        private ListView lvInstrumentsLifecycle;
        private ColumnHeader instrumentLyfecycleTypeColumn;
        private ColumnHeader instrumentLyfecycleDescriptionColumn;
        private Panel panel4;
        private ListBox lbInstrumentsLifecycle;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label lifecycleTotalInstrumentsDataLabel;
        private TableLayoutPanel lifecycleTagCountTablePanel;
        private FlowLayoutPanel flowLayoutPanel5;
        private Label lifecycleScannedTagsDataLabel;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private TableLayoutPanel tagCountTablePanel;
        private Label scanInProgressLabel;
        private FlowLayoutPanel flowLayoutPanel6;
        private Label scannedLabel;
        private Label scannedDataLabel;
        private Caretag_Class.ReactiveUI.Views.TouchscreenPackingListView assetScanGridView;
        private Button reportButton;
    }
}


