namespace AdminStation.Views.Reports
{
    partial class CostLogView
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.costLogGridControl = new DevExpress.XtraGrid.GridControl();
            this.costLogGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.trayNameGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.timestampGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.priceGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fromDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.toDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.costCentersComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.costItemsComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.generateReportSimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.fromDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.toDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.costCentersLayoutItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.costItemsLayoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.costLogGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costLogGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costCentersComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costItemsComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costCentersLayoutItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costItemsLayoutControlItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.costLogGridControl);
            this.layoutControl1.Controls.Add(this.fromDateEdit);
            this.layoutControl1.Controls.Add(this.toDateEdit);
            this.layoutControl1.Controls.Add(this.costCentersComboBoxEdit);
            this.layoutControl1.Controls.Add(this.costItemsComboBoxEdit);
            this.layoutControl1.Controls.Add(this.generateReportSimpleButton);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1073, 453, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1144, 718);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // costLogGridControl
            // 
            this.costLogGridControl.Location = new System.Drawing.Point(12, 38);
            this.costLogGridControl.MainView = this.costLogGridView;
            this.costLogGridControl.Name = "costLogGridControl";
            this.costLogGridControl.Size = new System.Drawing.Size(1119, 668);
            this.costLogGridControl.TabIndex = 8;
            this.costLogGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.costLogGridView});
            // 
            // costLogGridView
            // 
            this.costLogGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.trayNameGridColumn,
            this.timestampGridColumn,
            this.priceGridColumn});
            this.costLogGridView.GridControl = this.costLogGridControl;
            this.costLogGridView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Price", this.priceGridColumn, "")});
            this.costLogGridView.Name = "costLogGridView";
            this.costLogGridView.OptionsView.ShowFooter = true;
            this.costLogGridView.OptionsView.ShowGroupPanel = false;
            // 
            // trayNameGridColumn
            // 
            this.trayNameGridColumn.Caption = "Tray Name";
            this.trayNameGridColumn.FieldName = "TrayName";
            this.trayNameGridColumn.Name = "trayNameGridColumn";
            this.trayNameGridColumn.Visible = true;
            this.trayNameGridColumn.VisibleIndex = 0;
            // 
            // timestampGridColumn
            // 
            this.timestampGridColumn.Caption = "Timestamp";
            this.timestampGridColumn.FieldName = "Timestamp";
            this.timestampGridColumn.Name = "timestampGridColumn";
            this.timestampGridColumn.Visible = true;
            this.timestampGridColumn.VisibleIndex = 1;
            // 
            // priceGridColumn
            // 
            this.priceGridColumn.Caption = "Price";
            this.priceGridColumn.FieldName = "Price";
            this.priceGridColumn.Name = "priceGridColumn";
            this.priceGridColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Price", "SUM={0:0.##}")});
            this.priceGridColumn.Visible = true;
            this.priceGridColumn.VisibleIndex = 2;
            // 
            // fromDateEdit
            // 
            this.fromDateEdit.EditValue = null;
            this.fromDateEdit.Location = new System.Drawing.Point(87, 12);
            this.fromDateEdit.Name = "fromDateEdit";
            this.fromDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fromDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fromDateEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.fromDateEdit.Size = new System.Drawing.Size(108, 20);
            this.fromDateEdit.StyleController = this.layoutControl1;
            this.fromDateEdit.TabIndex = 4;
            // 
            // toDateEdit
            // 
            this.toDateEdit.EditValue = null;
            this.toDateEdit.Location = new System.Drawing.Point(274, 12);
            this.toDateEdit.Name = "toDateEdit";
            this.toDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.toDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.toDateEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.toDateEdit.Size = new System.Drawing.Size(124, 20);
            this.toDateEdit.StyleController = this.layoutControl1;
            this.toDateEdit.TabIndex = 5;
            // 
            // costCentersComboBoxEdit
            // 
            this.costCentersComboBoxEdit.Location = new System.Drawing.Point(477, 12);
            this.costCentersComboBoxEdit.Name = "costCentersComboBoxEdit";
            this.costCentersComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.costCentersComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.costCentersComboBoxEdit.Size = new System.Drawing.Size(151, 20);
            this.costCentersComboBoxEdit.StyleController = this.layoutControl1;
            this.costCentersComboBoxEdit.TabIndex = 9;
            // 
            // costItemsComboBoxEdit
            // 
            this.costItemsComboBoxEdit.Location = new System.Drawing.Point(707, 12);
            this.costItemsComboBoxEdit.Name = "costItemsComboBoxEdit";
            this.costItemsComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.costItemsComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.costItemsComboBoxEdit.Size = new System.Drawing.Size(147, 20);
            this.costItemsComboBoxEdit.StyleController = this.layoutControl1;
            this.costItemsComboBoxEdit.TabIndex = 10;
            // 
            // generateReportSimpleButton
            // 
            this.generateReportSimpleButton.Location = new System.Drawing.Point(858, 12);
            this.generateReportSimpleButton.Name = "generateReportSimpleButton";
            this.generateReportSimpleButton.Size = new System.Drawing.Size(274, 22);
            this.generateReportSimpleButton.StyleController = this.layoutControl1;
            this.generateReportSimpleButton.TabIndex = 11;
            this.generateReportSimpleButton.Text = "Generate Report";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.simpleSeparator1,
            this.fromDate,
            this.toDate,
            this.layoutControlItem3,
            this.costCentersLayoutItem,
            this.costItemsLayoutControlItem,
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1144, 718);
            this.Root.TextVisible = false;
            // 
            // simpleSeparator1
            // 
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.Location = new System.Drawing.Point(1123, 26);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Size = new System.Drawing.Size(1, 672);
            // 
            // fromDate
            // 
            this.fromDate.Control = this.fromDateEdit;
            this.fromDate.Location = new System.Drawing.Point(0, 0);
            this.fromDate.Name = "fromDate";
            this.fromDate.Size = new System.Drawing.Size(187, 26);
            this.fromDate.Text = "From: ";
            this.fromDate.TextSize = new System.Drawing.Size(63, 13);
            // 
            // toDate
            // 
            this.toDate.Control = this.toDateEdit;
            this.toDate.Location = new System.Drawing.Point(187, 0);
            this.toDate.Name = "toDate";
            this.toDate.Size = new System.Drawing.Size(203, 26);
            this.toDate.Text = "To:";
            this.toDate.TextSize = new System.Drawing.Size(63, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.costLogGridControl;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1123, 672);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // costCentersLayoutItem
            // 
            this.costCentersLayoutItem.Control = this.costCentersComboBoxEdit;
            this.costCentersLayoutItem.Location = new System.Drawing.Point(390, 0);
            this.costCentersLayoutItem.Name = "costCentersLayoutItem";
            this.costCentersLayoutItem.Size = new System.Drawing.Size(230, 26);
            this.costCentersLayoutItem.Text = "Cost Centers";
            this.costCentersLayoutItem.TextSize = new System.Drawing.Size(63, 13);
            // 
            // costItemsLayoutControlItem
            // 
            this.costItemsLayoutControlItem.Control = this.costItemsComboBoxEdit;
            this.costItemsLayoutControlItem.Location = new System.Drawing.Point(620, 0);
            this.costItemsLayoutControlItem.Name = "costItemsLayoutControlItem";
            this.costItemsLayoutControlItem.Size = new System.Drawing.Size(226, 26);
            this.costItemsLayoutControlItem.Text = "Cost Items";
            this.costItemsLayoutControlItem.TextSize = new System.Drawing.Size(63, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.generateReportSimpleButton;
            this.layoutControlItem1.Location = new System.Drawing.Point(846, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(278, 26);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // CostLogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "CostLogView";
            this.Size = new System.Drawing.Size(1144, 718);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.costLogGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costLogGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costCentersComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costItemsComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costCentersLayoutItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costItemsLayoutControlItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.DateEdit fromDateEdit;
        private DevExpress.XtraEditors.DateEdit toDateEdit;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private DevExpress.XtraLayout.LayoutControlItem fromDate;
        private DevExpress.XtraLayout.LayoutControlItem toDate;
        private DevExpress.XtraGrid.GridControl costLogGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView costLogGridView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.ComboBoxEdit costCentersComboBoxEdit;
        private DevExpress.XtraEditors.ComboBoxEdit costItemsComboBoxEdit;
        private DevExpress.XtraLayout.LayoutControlItem costCentersLayoutItem;
        private DevExpress.XtraLayout.LayoutControlItem costItemsLayoutControlItem;
        private DevExpress.XtraEditors.SimpleButton generateReportSimpleButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn priceGridColumn;
        private DevExpress.XtraGrid.Columns.GridColumn trayNameGridColumn;
        private DevExpress.XtraGrid.Columns.GridColumn timestampGridColumn;
    }
}