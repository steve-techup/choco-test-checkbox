using DevExpress.XtraGrid.Columns;

namespace AdminStation.Views.Assets
{
    partial class CostCentersView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.removeCostItemButton = new DevExpress.XtraEditors.SimpleButton();
            this.addCostItemButton = new DevExpress.XtraEditors.SimpleButton();
            this.costTypesGridControl = new DevExpress.XtraGrid.GridControl();
            this.costTypesGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.costTypeColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.costPriceColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.costType_changeDateColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.costItemsGridControl = new DevExpress.XtraGrid.GridControl();
            this.costItemsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.index_IDColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.change_DateColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.default_CostColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.costItemcostTypeColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.priceColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.costCentersGridControl = new DevExpress.XtraGrid.GridControl();
            this.costCentersGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.indexIDColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.costCenterNameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.costCenterCodeColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.hiddenCenterColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.changeDateColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.extraTextColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.defaultAlwaysColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panelControl11 = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem2 = new DevExpress.XtraLayout.SplitterItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.labelCostCenters = new DevExpress.XtraLayout.SimpleLabelItem();
            this.labelCostItems = new DevExpress.XtraLayout.SimpleLabelItem();
            this.labelCostTypes = new DevExpress.XtraLayout.SimpleLabelItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.costTypesGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costTypesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costItemsGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costItemsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costCentersGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costCentersGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl11)).BeginInit();
            this.panelControl11.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelCostCenters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelCostItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelCostTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.panelControl1);
            this.layoutControl1.Controls.Add(this.costTypesGridControl);
            this.layoutControl1.Controls.Add(this.costItemsGridControl);
            this.layoutControl1.Controls.Add(this.costCentersGridControl);
            this.layoutControl1.Controls.Add(this.panelControl11);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1612, 953);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.tableLayoutPanel1);
            this.panelControl1.Location = new System.Drawing.Point(1100, 14);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(57, 925);
            this.panelControl1.TabIndex = 9;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.removeCostItemButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.addCostItemButton, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(53, 921);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // removeCostItemButton
            // 
            this.removeCostItemButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.removeCostItemButton.Location = new System.Drawing.Point(4, 397);
            this.removeCostItemButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.removeCostItemButton.Name = "removeCostItemButton";
            this.removeCostItemButton.Size = new System.Drawing.Size(44, 59);
            this.removeCostItemButton.TabIndex = 9;
            this.removeCostItemButton.Text = "-->";
            // 
            // addCostItemButton
            // 
            this.addCostItemButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.addCostItemButton.Location = new System.Drawing.Point(4, 464);
            this.addCostItemButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addCostItemButton.Name = "addCostItemButton";
            this.addCostItemButton.Size = new System.Drawing.Size(44, 59);
            this.addCostItemButton.TabIndex = 10;
            this.addCostItemButton.Text = "<--";
            // 
            // costTypesGridControl
            // 
            this.costTypesGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.costTypesGridControl.Location = new System.Drawing.Point(1163, 34);
            this.costTypesGridControl.MainView = this.costTypesGridView;
            this.costTypesGridControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.costTypesGridControl.Name = "costTypesGridControl";
            this.costTypesGridControl.Size = new System.Drawing.Size(433, 905);
            this.costTypesGridControl.TabIndex = 7;
            this.costTypesGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.costTypesGridView});
            // 
            // costTypesGridView
            // 
            this.costTypesGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.costTypeColumn,
            this.costPriceColumn,
            this.costType_changeDateColumn});
            this.costTypesGridView.DetailHeight = 431;
            this.costTypesGridView.GridControl = this.costTypesGridControl;
            this.costTypesGridView.Name = "costTypesGridView";
            this.costTypesGridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.costTypesGridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.costTypesGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            // 
            // costTypeColumn
            // 
            this.costTypeColumn.Caption = "Cost Type";
            this.costTypeColumn.FieldName = "Cost_Type";
            this.costTypeColumn.MinWidth = 25;
            this.costTypeColumn.Name = "costTypeColumn";
            this.costTypeColumn.Visible = true;
            this.costTypeColumn.VisibleIndex = 0;
            this.costTypeColumn.Width = 200;
            // 
            // costPriceColumn
            // 
            this.costPriceColumn.Caption = "Cost Price";
            this.costPriceColumn.FieldName = "Cost_Price";
            this.costPriceColumn.MinWidth = 25;
            this.costPriceColumn.Name = "costPriceColumn";
            this.costPriceColumn.Visible = true;
            this.costPriceColumn.VisibleIndex = 1;
            this.costPriceColumn.Width = 160;
            // 
            // costType_changeDateColumn
            // 
            this.costType_changeDateColumn.Caption = "Change Date";
            this.costType_changeDateColumn.FieldName = "Change_Date";
            this.costType_changeDateColumn.MinWidth = 25;
            this.costType_changeDateColumn.Name = "costType_changeDateColumn";
            this.costType_changeDateColumn.OptionsColumn.AllowEdit = false;
            this.costType_changeDateColumn.Visible = true;
            this.costType_changeDateColumn.VisibleIndex = 2;
            this.costType_changeDateColumn.Width = 200;
            // 
            // costItemsGridControl
            // 
            this.costItemsGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.costItemsGridControl.Location = new System.Drawing.Point(526, 34);
            this.costItemsGridControl.MainView = this.costItemsGridView;
            this.costItemsGridControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.costItemsGridControl.Name = "costItemsGridControl";
            this.costItemsGridControl.Size = new System.Drawing.Size(556, 905);
            this.costItemsGridControl.TabIndex = 6;
            this.costItemsGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.costItemsGridView});
            // 
            // costItemsGridView
            // 
            this.costItemsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.index_IDColumn,
            this.change_DateColumn,
            this.default_CostColumn,
            this.costItemcostTypeColumn,
            this.priceColumn});
            this.costItemsGridView.DetailHeight = 431;
            this.costItemsGridView.GridControl = this.costItemsGridControl;
            this.costItemsGridView.Name = "costItemsGridView";
            this.costItemsGridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.costItemsGridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            // 
            // index_IDColumn
            // 
            this.index_IDColumn.Caption = "Index_ID";
            this.index_IDColumn.FieldName = "Index_ID";
            this.index_IDColumn.MinWidth = 25;
            this.index_IDColumn.Name = "index_IDColumn";
            this.index_IDColumn.Width = 93;
            // 
            // change_DateColumn
            // 
            this.change_DateColumn.Caption = "Last Change";
            this.change_DateColumn.FieldName = "ChangeDate";
            this.change_DateColumn.MinWidth = 25;
            this.change_DateColumn.Name = "change_DateColumn";
            this.change_DateColumn.OptionsColumn.AllowEdit = false;
            this.change_DateColumn.Visible = true;
            this.change_DateColumn.VisibleIndex = 0;
            this.change_DateColumn.Width = 93;
            // 
            // default_CostColumn
            // 
            this.default_CostColumn.Caption = "DefaultCost";
            this.default_CostColumn.FieldName = "DefaultCost";
            this.default_CostColumn.MinWidth = 25;
            this.default_CostColumn.Name = "default_CostColumn";
            this.default_CostColumn.Visible = true;
            this.default_CostColumn.VisibleIndex = 1;
            this.default_CostColumn.Width = 93;
            // 
            // costItemcostTypeColumn
            // 
            this.costItemcostTypeColumn.Caption = "Cost Type";
            this.costItemcostTypeColumn.FieldName = "CostType";
            this.costItemcostTypeColumn.MinWidth = 25;
            this.costItemcostTypeColumn.Name = "costItemcostTypeColumn";
            this.costItemcostTypeColumn.OptionsColumn.AllowEdit = false;
            this.costItemcostTypeColumn.Visible = true;
            this.costItemcostTypeColumn.VisibleIndex = 2;
            this.costItemcostTypeColumn.Width = 93;
            // 
            // priceColumn
            // 
            this.priceColumn.Caption = "Price";
            this.priceColumn.FieldName = "Price";
            this.priceColumn.MinWidth = 25;
            this.priceColumn.Name = "priceColumn";
            this.priceColumn.OptionsColumn.AllowEdit = false;
            this.priceColumn.Visible = true;
            this.priceColumn.VisibleIndex = 3;
            this.priceColumn.Width = 93;
            // 
            // costCentersGridControl
            // 
            this.costCentersGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            gridLevelNode1.RelationName = "Level1";
            this.costCentersGridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.costCentersGridControl.Location = new System.Drawing.Point(16, 34);
            this.costCentersGridControl.MainView = this.costCentersGridView;
            this.costCentersGridControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.costCentersGridControl.Name = "costCentersGridControl";
            this.costCentersGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
            this.costCentersGridControl.Size = new System.Drawing.Size(492, 905);
            this.costCentersGridControl.TabIndex = 5;
            this.costCentersGridControl.UseEmbeddedNavigator = true;
            this.costCentersGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.costCentersGridView});
            // 
            // costCentersGridView
            // 
            this.costCentersGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.indexIDColumn,
            this.costCenterNameColumn,
            this.costCenterCodeColumn,
            this.hiddenCenterColumn,
            this.changeDateColumn,
            this.extraTextColumn,
            this.defaultAlwaysColumn});
            this.costCentersGridView.DetailHeight = 431;
            this.costCentersGridView.GridControl = this.costCentersGridControl;
            this.costCentersGridView.Name = "costCentersGridView";
            this.costCentersGridView.NewItemRowText = "Click to create new";
            this.costCentersGridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.costCentersGridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.costCentersGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            // 
            // indexIDColumn
            // 
            this.indexIDColumn.Caption = "Index ID";
            this.indexIDColumn.FieldName = "Index_ID";
            this.indexIDColumn.MinWidth = 25;
            this.indexIDColumn.Name = "indexIDColumn";
            this.indexIDColumn.OptionsColumn.AllowEdit = false;
            this.indexIDColumn.Width = 93;
            // 
            // costCenterNameColumn
            // 
            this.costCenterNameColumn.Caption = "Cost Center Name";
            this.costCenterNameColumn.FieldName = "Cost_Center_Name";
            this.costCenterNameColumn.MinWidth = 25;
            this.costCenterNameColumn.Name = "costCenterNameColumn";
            this.costCenterNameColumn.Visible = true;
            this.costCenterNameColumn.VisibleIndex = 0;
            this.costCenterNameColumn.Width = 200;
            // 
            // costCenterCodeColumn
            // 
            this.costCenterCodeColumn.Caption = "Cost Center Code";
            this.costCenterCodeColumn.FieldName = "Cost_Center_Code";
            this.costCenterCodeColumn.MinWidth = 25;
            this.costCenterCodeColumn.Name = "costCenterCodeColumn";
            this.costCenterCodeColumn.Visible = true;
            this.costCenterCodeColumn.VisibleIndex = 1;
            this.costCenterCodeColumn.Width = 133;
            // 
            // hiddenCenterColumn
            // 
            this.hiddenCenterColumn.Caption = "Hidden Center";
            this.hiddenCenterColumn.FieldName = "Hidden_Center";
            this.hiddenCenterColumn.MinWidth = 25;
            this.hiddenCenterColumn.Name = "hiddenCenterColumn";
            this.hiddenCenterColumn.Visible = true;
            this.hiddenCenterColumn.VisibleIndex = 2;
            this.hiddenCenterColumn.Width = 93;
            // 
            // changeDateColumn
            // 
            this.changeDateColumn.Caption = "Change Date";
            this.changeDateColumn.FieldName = "Change_Date";
            this.changeDateColumn.MinWidth = 25;
            this.changeDateColumn.Name = "changeDateColumn";
            this.changeDateColumn.OptionsColumn.AllowEdit = false;
            this.changeDateColumn.Visible = true;
            this.changeDateColumn.VisibleIndex = 3;
            this.changeDateColumn.Width = 160;
            // 
            // extraTextColumn
            // 
            this.extraTextColumn.Caption = "Extra Text";
            this.extraTextColumn.FieldName = "Extra_Text";
            this.extraTextColumn.MinWidth = 25;
            this.extraTextColumn.Name = "extraTextColumn";
            this.extraTextColumn.Visible = true;
            this.extraTextColumn.VisibleIndex = 4;
            this.extraTextColumn.Width = 200;
            // 
            // defaultAlwaysColumn
            // 
            this.defaultAlwaysColumn.Caption = "Default Always";
            this.defaultAlwaysColumn.FieldName = "Default_Always";
            this.defaultAlwaysColumn.MinWidth = 25;
            this.defaultAlwaysColumn.Name = "defaultAlwaysColumn";
            this.defaultAlwaysColumn.Visible = true;
            this.defaultAlwaysColumn.VisibleIndex = 5;
            this.defaultAlwaysColumn.Width = 200;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // panelControl11
            // 
            this.panelControl11.Controls.Add(this.tableLayoutPanel11);
            this.panelControl11.Location = new System.Drawing.Point(16, 937);
            this.panelControl11.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelControl11.Name = "panelControl11";
            this.panelControl11.Size = new System.Drawing.Size(1580, 1);
            this.panelControl11.TabIndex = 8;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 1;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel11.Controls.Add(this.simpleButton1, 0, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(2, 1);
            this.tableLayoutPanel11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 2;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(1576, 0);
            this.tableLayoutPanel11.TabIndex = 11;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.simpleButton1.Location = new System.Drawing.Point(762, 4);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(51, 1);
            this.simpleButton1.TabIndex = 9;
            this.simpleButton1.Text = "-->";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.splitterItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.splitterItem2,
            this.layoutControlItem4,
            this.labelCostCenters,
            this.labelCostItems,
            this.labelCostTypes});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1612, 953);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.costCentersGridControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(498, 909);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.Location = new System.Drawing.Point(498, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(12, 929);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.costItemsGridControl;
            this.layoutControlItem2.Location = new System.Drawing.Point(510, 20);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(562, 909);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.costTypesGridControl;
            this.layoutControlItem3.Location = new System.Drawing.Point(1147, 20);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(439, 909);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // splitterItem2
            // 
            this.splitterItem2.AllowHotTrack = true;
            this.splitterItem2.Location = new System.Drawing.Point(1072, 0);
            this.splitterItem2.Name = "splitterItem2";
            this.splitterItem2.Size = new System.Drawing.Size(12, 929);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.panelControl1;
            this.layoutControlItem4.Location = new System.Drawing.Point(1084, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(63, 929);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // labelCostCenters
            // 
            this.labelCostCenters.AllowHotTrack = false;
            this.labelCostCenters.Location = new System.Drawing.Point(0, 0);
            this.labelCostCenters.Name = "labelCostCenters";
            this.labelCostCenters.Size = new System.Drawing.Size(498, 20);
            this.labelCostCenters.Text = "Cost Centers";
            this.labelCostCenters.TextSize = new System.Drawing.Size(73, 16);
            // 
            // labelCostItems
            // 
            this.labelCostItems.AllowHotTrack = false;
            this.labelCostItems.Location = new System.Drawing.Point(510, 0);
            this.labelCostItems.Name = "labelCostItems";
            this.labelCostItems.Size = new System.Drawing.Size(562, 20);
            this.labelCostItems.Text = "Cost Items";
            this.labelCostItems.TextSize = new System.Drawing.Size(73, 16);
            // 
            // labelCostTypes
            // 
            this.labelCostTypes.AllowHotTrack = false;
            this.labelCostTypes.Location = new System.Drawing.Point(1147, 0);
            this.labelCostTypes.Name = "labelCostTypes";
            this.labelCostTypes.Size = new System.Drawing.Size(439, 20);
            this.labelCostTypes.Text = "Cost Types";
            this.labelCostTypes.TextSize = new System.Drawing.Size(73, 16);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 754);
            this.layoutControlGroup1.Name = "LayoutRootGroupForRestore";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1189, 30);
            this.layoutControlGroup1.Tag = "LayoutRootGroupForRestore";
            // 
            // CostCentersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CostCentersView";
            this.Size = new System.Drawing.Size(1612, 953);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.costTypesGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costTypesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costItemsGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costItemsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costCentersGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costCentersGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl11)).EndInit();
            this.panelControl11.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelCostCenters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelCostItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelCostTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl costCentersGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView costCentersGridView;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraGrid.GridControl costItemsGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView costItemsGridView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.SplitterItem splitterItem2;
        private DevExpress.XtraEditors.PanelControl panelControl11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl costTypesGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView costTypesGridView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton removeCostItemButton;
        private DevExpress.XtraEditors.SimpleButton addCostItemButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.SimpleLabelItem labelCostCenters;
        private DevExpress.XtraLayout.SimpleLabelItem labelCostItems;
        private DevExpress.XtraLayout.SimpleLabelItem labelCostTypes;
        private GridColumn indexIDColumn;
        private GridColumn costCenterNameColumn;
        private GridColumn costCenterCodeColumn;
        private GridColumn hiddenCenterColumn;
        private GridColumn changeDateColumn;
        private GridColumn extraTextColumn;
        private GridColumn defaultAlwaysColumn;
        private GridColumn costTypeColumn;
        private GridColumn costPriceColumn;
        private GridColumn costType_changeDateColumn;
        private GridColumn index_IDColumn;
        private GridColumn change_DateColumn;
        private GridColumn default_CostColumn;
        private GridColumn costItemcostTypeColumn;
        private GridColumn priceColumn;
    }
}
