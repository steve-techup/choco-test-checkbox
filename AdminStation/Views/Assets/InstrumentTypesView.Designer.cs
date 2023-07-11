namespace AdminStation.Views.Assets
{
    partial class InstrumentTypesView
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.descriptionIdColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.instrumentCompanyColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.descriptionNameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.eColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dateChangedColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.vendorIdColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSearchLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.rfidUntaggableColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.imageGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSearchLookUpEdit1,
            this.repositoryItemImageEdit1});
            this.gridControl1.Size = new System.Drawing.Size(832, 641);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.descriptionIdColumn,
            this.instrumentCompanyColumn,
            this.descriptionNameColumn,
            this.dColumn,
            this.eColumn,
            this.dateChangedColumn,
            this.vendorIdColumn,
            this.rfidUntaggableColumn,
            this.imageGridColumn});
            this.gridView1.DetailHeight = 284;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            // 
            // descriptionIdColumn
            // 
            this.descriptionIdColumn.Caption = "Description ID";
            this.descriptionIdColumn.FieldName = "Description_ID";
            this.descriptionIdColumn.Name = "descriptionIdColumn";
            this.descriptionIdColumn.Visible = true;
            this.descriptionIdColumn.VisibleIndex = 0;
            // 
            // instrumentCompanyColumn
            // 
            this.instrumentCompanyColumn.Caption = "Vendor";
            this.instrumentCompanyColumn.FieldName = "Instrument_Company";
            this.instrumentCompanyColumn.Name = "instrumentCompanyColumn";
            // 
            // descriptionNameColumn
            // 
            this.descriptionNameColumn.Caption = "Name";
            this.descriptionNameColumn.FieldName = "Description_Name";
            this.descriptionNameColumn.Name = "descriptionNameColumn";
            this.descriptionNameColumn.Visible = true;
            this.descriptionNameColumn.VisibleIndex = 1;
            // 
            // dColumn
            // 
            this.dColumn.Caption = "Description 1";
            this.dColumn.FieldName = "D";
            this.dColumn.Name = "dColumn";
            this.dColumn.Visible = true;
            this.dColumn.VisibleIndex = 2;
            // 
            // eColumn
            // 
            this.eColumn.Caption = "Description 2";
            this.eColumn.FieldName = "E";
            this.eColumn.Name = "eColumn";
            this.eColumn.Visible = true;
            this.eColumn.VisibleIndex = 3;
            // 
            // dateChangedColumn
            // 
            this.dateChangedColumn.Caption = "Date Changed";
            this.dateChangedColumn.FieldName = "Date_Changed";
            this.dateChangedColumn.Name = "dateChangedColumn";
            this.dateChangedColumn.OptionsColumn.AllowEdit = false;
            this.dateChangedColumn.Visible = true;
            this.dateChangedColumn.VisibleIndex = 4;
            // 
            // vendorIdColumn
            // 
            this.vendorIdColumn.Caption = "Vendor";
            this.vendorIdColumn.ColumnEdit = this.repositoryItemSearchLookUpEdit1;
            this.vendorIdColumn.FieldName = "Vendor_ID";
            this.vendorIdColumn.Name = "vendorIdColumn";
            this.vendorIdColumn.Visible = true;
            this.vendorIdColumn.VisibleIndex = 5;
            // 
            // repositoryItemSearchLookUpEdit1
            // 
            this.repositoryItemSearchLookUpEdit1.AutoHeight = false;
            this.repositoryItemSearchLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSearchLookUpEdit1.Name = "repositoryItemSearchLookUpEdit1";
            this.repositoryItemSearchLookUpEdit1.PopupView = this.gridView2;
            this.repositoryItemSearchLookUpEdit1.ViewType = DevExpress.XtraEditors.Repository.GridLookUpViewType.GridView;
            // 
            // gridView2
            // 
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // rfidUntaggableColumn
            // 
            this.rfidUntaggableColumn.Caption = "RFID Untaggable";
            this.rfidUntaggableColumn.FieldName = "RfidUntaggable";
            this.rfidUntaggableColumn.Name = "rfidUntaggableColumn";
            this.rfidUntaggableColumn.Visible = true;
            this.rfidUntaggableColumn.VisibleIndex = 6;
            // 
            // imageGridColumn
            // 
            this.imageGridColumn.Caption = "Image";
            this.imageGridColumn.ColumnEdit = this.repositoryItemImageEdit1;
            this.imageGridColumn.FieldName = "Image";
            this.imageGridColumn.Name = "imageGridColumn";
            this.imageGridColumn.Visible = true;
            this.imageGridColumn.VisibleIndex = 7;
            this.imageGridColumn.Width = 56;
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            this.repositoryItemImageEdit1.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.Image;
            this.repositoryItemImageEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            // 
            // InstrumentTypesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "InstrumentTypesView";
            this.Size = new System.Drawing.Size(832, 641);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn descriptionIdColumn;
        private DevExpress.XtraGrid.Columns.GridColumn instrumentCompanyColumn;
        private DevExpress.XtraGrid.Columns.GridColumn descriptionNameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn dColumn;
        private DevExpress.XtraGrid.Columns.GridColumn eColumn;
        private DevExpress.XtraGrid.Columns.GridColumn dateChangedColumn;
        private DevExpress.XtraGrid.Columns.GridColumn vendorIdColumn;
        private DevExpress.XtraGrid.Columns.GridColumn rfidUntaggableColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repositoryItemSearchLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn imageGridColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
    }
}