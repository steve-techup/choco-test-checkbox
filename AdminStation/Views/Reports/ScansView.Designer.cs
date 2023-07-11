using System.ComponentModel;

namespace AdminStation.Views.Reports;

partial class ScansView
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScansView));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.trayBarNewButton = new DevExpress.XtraBars.BarButtonItem();
            this.trayBarEditButton = new DevExpress.XtraBars.BarButtonItem();
            this.trayBarDeleteButton = new DevExpress.XtraBars.BarButtonItem();
            this.traysPane = new DevExpress.XtraBars.Navigation.TabPane();
            this.traysListPage = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.scansGridControl = new DevExpress.XtraGrid.GridControl();
            this.scansGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.idGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.timestampGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.locationGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.resultGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.prettyResultGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.trayEPCGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.trayIdGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.trayNameGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.totalPackedGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.totalExpectedGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.editPage = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.removeButton = new DevExpress.XtraEditors.SimpleButton();
            this.addButton = new DevExpress.XtraEditors.SimpleButton();
            this.detailsLabel = new System.Windows.Forms.Label();
            this.instrumentsListLabel = new System.Windows.Forms.Label();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.traysPane)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scansGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scansGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            this.editPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockWindowTabFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.trayBarNewButton,
            this.trayBarEditButton,
            this.trayBarDeleteButton});
            this.barManager1.MaxItemId = 4;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1209, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 774);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1209, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 774);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1209, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 774);
            // 
            // trayBarNewButton
            // 
            this.trayBarNewButton.Caption = "New";
            this.trayBarNewButton.Id = 0;
            this.trayBarNewButton.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("trayBarNewButton.ImageOptions.SvgImage")));
            this.trayBarNewButton.Name = "trayBarNewButton";
            // 
            // trayBarEditButton
            // 
            this.trayBarEditButton.Caption = "Edit";
            this.trayBarEditButton.Id = 1;
            this.trayBarEditButton.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("trayBarEditButton.ImageOptions.SvgImage")));
            this.trayBarEditButton.Name = "trayBarEditButton";
            // 
            // trayBarDeleteButton
            // 
            this.trayBarDeleteButton.Caption = "Delete";
            this.trayBarDeleteButton.Id = 3;
            this.trayBarDeleteButton.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("trayBarDeleteButton.ImageOptions.SvgImage")));
            this.trayBarDeleteButton.Name = "trayBarDeleteButton";
            // 
            // traysPane
            // 
            this.traysPane.Location = new System.Drawing.Point(0, 0);
            this.traysPane.Name = "traysPane";
            this.traysPane.SelectedPage = null;
            this.traysPane.Size = new System.Drawing.Size(0, 0);
            this.traysPane.TabIndex = 0;
            // 
            // traysListPage
            // 
            this.traysListPage.Caption = "traysListPage";
            this.traysListPage.Name = "traysListPage";
            this.traysListPage.Size = new System.Drawing.Size(200, 100);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.scansGridControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1660, 509, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1209, 774);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // scansGridControl
            // 
            this.scansGridControl.Location = new System.Drawing.Point(12, 12);
            this.scansGridControl.MainView = this.scansGridView;
            this.scansGridControl.MenuManager = this.barManager1;
            this.scansGridControl.Name = "scansGridControl";
            this.scansGridControl.Size = new System.Drawing.Size(1184, 750);
            this.scansGridControl.TabIndex = 4;
            this.scansGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.scansGridView});
            // 
            // scansGridView
            // 
            this.scansGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.idGridColumn,
            this.timestampGridColumn,
            this.locationGridColumn,
            this.resultGridColumn,
            this.prettyResultGridColumn,
            this.trayEPCGridColumn,
            this.trayIdGridColumn,
            this.trayNameGridColumn,
            this.totalPackedGridColumn,
            this.totalExpectedGridColumn});
            this.scansGridView.GridControl = this.scansGridControl;
            this.scansGridView.Name = "scansGridView";
            this.scansGridView.NewItemRowText = "Click to create new";
            this.scansGridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.scansGridView.OptionsBehavior.Editable = false;
            // 
            // idGridColumn
            // 
            this.idGridColumn.Caption = "Id";
            this.idGridColumn.FieldName = "Id";
            this.idGridColumn.Name = "idGridColumn";
            this.idGridColumn.Width = 56;
            // 
            // timestampGridColumn
            // 
            this.timestampGridColumn.Caption = "Timestamp";
            this.timestampGridColumn.FieldName = "Timestamp";
            this.timestampGridColumn.Name = "timestampGridColumn";
            this.timestampGridColumn.Visible = true;
            this.timestampGridColumn.VisibleIndex = 0;
            this.timestampGridColumn.Width = 56;
            // 
            // locationGridColumn
            // 
            this.locationGridColumn.Caption = "Location";
            this.locationGridColumn.FieldName = "Location";
            this.locationGridColumn.Name = "locationGridColumn";
            this.locationGridColumn.Visible = true;
            this.locationGridColumn.VisibleIndex = 1;
            this.locationGridColumn.Width = 56;
            // 
            // resultGridColumn
            // 
            this.resultGridColumn.Caption = "Result";
            this.resultGridColumn.FieldName = "Result";
            this.resultGridColumn.Name = "resultGridColumn";
            this.resultGridColumn.Width = 56;
            // 
            // prettyResultGridColumn
            // 
            this.prettyResultGridColumn.Caption = "Result";
            this.prettyResultGridColumn.FieldName = "PrettyResult";
            this.prettyResultGridColumn.Name = "prettyResultGridColumn";
            this.prettyResultGridColumn.Visible = true;
            this.prettyResultGridColumn.VisibleIndex = 2;
            this.prettyResultGridColumn.Width = 56;
            // 
            // trayEPCGridColumn
            // 
            this.trayEPCGridColumn.Caption = "TrayEPC";
            this.trayEPCGridColumn.FieldName = "TrayEPC";
            this.trayEPCGridColumn.Name = "trayEPCGridColumn";
            this.trayEPCGridColumn.Width = 56;
            // 
            // trayIdGridColumn
            // 
            this.trayIdGridColumn.Caption = "TrayId";
            this.trayIdGridColumn.FieldName = "TrayId";
            this.trayIdGridColumn.Name = "trayIdGridColumn";
            this.trayIdGridColumn.Width = 56;
            // 
            // trayNameGridColumn
            // 
            this.trayNameGridColumn.Caption = "Tray Name";
            this.trayNameGridColumn.FieldName = "TrayName";
            this.trayNameGridColumn.Name = "trayNameGridColumn";
            this.trayNameGridColumn.Visible = true;
            this.trayNameGridColumn.VisibleIndex = 3;
            this.trayNameGridColumn.Width = 56;
            // 
            // totalPackedGridColumn
            // 
            this.totalPackedGridColumn.Caption = "Total Packed";
            this.totalPackedGridColumn.FieldName = "TotalPacked";
            this.totalPackedGridColumn.Name = "totalPackedGridColumn";
            this.totalPackedGridColumn.Visible = true;
            this.totalPackedGridColumn.VisibleIndex = 4;
            this.totalPackedGridColumn.Width = 56;
            // 
            // totalExpectedGridColumn
            // 
            this.totalExpectedGridColumn.Caption = "Total Expected";
            this.totalExpectedGridColumn.FieldName = "TotalExpected";
            this.totalExpectedGridColumn.Name = "totalExpectedGridColumn";
            this.totalExpectedGridColumn.Visible = true;
            this.totalExpectedGridColumn.VisibleIndex = 5;
            this.totalExpectedGridColumn.Width = 56;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.simpleSeparator1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1209, 774);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.scansGridControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1188, 754);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // simpleSeparator1
            // 
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.Location = new System.Drawing.Point(1188, 0);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Size = new System.Drawing.Size(1, 754);
            // 
            // editPage
            // 
            this.editPage.Caption = "Edit";
            this.editPage.Controls.Add(this.gridControl2);
            this.editPage.Controls.Add(this.removeButton);
            this.editPage.Controls.Add(this.addButton);
            this.editPage.Controls.Add(this.detailsLabel);
            this.editPage.Controls.Add(this.instrumentsListLabel);
            this.editPage.Name = "editPage";
            this.editPage.Size = new System.Drawing.Size(787, 516);
            // 
            // gridControl2
            // 
            this.gridControl2.Location = new System.Drawing.Point(16, 40);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.MenuManager = this.barManager1;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(744, 232);
            this.gridControl2.TabIndex = 5;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(680, 288);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 4;
            this.removeButton.Text = "Remove";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(592, 288);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "Add";
            // 
            // detailsLabel
            // 
            this.detailsLabel.AutoSize = true;
            this.detailsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailsLabel.Location = new System.Drawing.Point(16, 320);
            this.detailsLabel.Name = "detailsLabel";
            this.detailsLabel.Size = new System.Drawing.Size(78, 25);
            this.detailsLabel.TabIndex = 2;
            this.detailsLabel.Text = "Details";
            // 
            // instrumentsListLabel
            // 
            this.instrumentsListLabel.AutoSize = true;
            this.instrumentsListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instrumentsListLabel.Location = new System.Drawing.Point(16, 8);
            this.instrumentsListLabel.Name = "instrumentsListLabel";
            this.instrumentsListLabel.Size = new System.Drawing.Size(123, 25);
            this.instrumentsListLabel.TabIndex = 1;
            this.instrumentsListLabel.Text = "Instruments";
            // 
            // ScansView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ScansView";
            this.Size = new System.Drawing.Size(1209, 774);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.traysPane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scansGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scansGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            this.editPage.ResumeLayout(false);
            this.editPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private DevExpress.XtraBars.BarManager barManager1;
    private DevExpress.XtraBars.BarButtonItem trayBarNewButton;
    private DevExpress.XtraBars.BarDockControl barDockControlTop;
    private DevExpress.XtraBars.BarDockControl barDockControlBottom;
    private DevExpress.XtraBars.BarDockControl barDockControlLeft;
    private DevExpress.XtraBars.BarDockControl barDockControlRight;
    private DevExpress.XtraBars.BarButtonItem trayBarEditButton;
    private DevExpress.XtraBars.BarButtonItem trayBarDeleteButton;
    private DevExpress.XtraBars.Navigation.TabPane traysPane;
    private DevExpress.XtraBars.Navigation.TabNavigationPage traysListPage;
    private DevExpress.XtraBars.Navigation.TabNavigationPage editPage;
    private System.Windows.Forms.Label detailsLabel;
    private System.Windows.Forms.Label instrumentsListLabel;
    private DevExpress.XtraEditors.SimpleButton removeButton;
    private DevExpress.XtraEditors.SimpleButton addButton;
    private DevExpress.XtraGrid.GridControl gridControl2;
    private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
    private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
    private DevExpress.XtraLayout.LayoutControl layoutControl1;
    private DevExpress.XtraGrid.GridControl scansGridControl;
    private DevExpress.XtraGrid.Views.Grid.GridView scansGridView;
    private DevExpress.XtraLayout.LayoutControlGroup Root;
    private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
    private DevExpress.XtraGrid.Columns.GridColumn idGridColumn;
    private DevExpress.XtraGrid.Columns.GridColumn timestampGridColumn;
    private DevExpress.XtraGrid.Columns.GridColumn locationGridColumn;
    private DevExpress.XtraGrid.Columns.GridColumn resultGridColumn;
    private DevExpress.XtraGrid.Columns.GridColumn prettyResultGridColumn;
    private DevExpress.XtraGrid.Columns.GridColumn trayEPCGridColumn;
    private DevExpress.XtraGrid.Columns.GridColumn trayIdGridColumn;
    private DevExpress.XtraGrid.Columns.GridColumn trayNameGridColumn;
    private DevExpress.XtraGrid.Columns.GridColumn totalPackedGridColumn;
    private DevExpress.XtraGrid.Columns.GridColumn totalExpectedGridColumn;
}