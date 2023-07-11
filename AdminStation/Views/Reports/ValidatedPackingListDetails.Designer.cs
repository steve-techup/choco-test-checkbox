namespace AdminStation.Views.Reports
{
    partial class ValidatedPackingListDetails
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
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.validatedPackingListGridControl = new DevExpress.XtraGrid.GridControl();
            this.validatedPackingListGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.idGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.timestampGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.expectedGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.actualGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.packedManuallyGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.instrumentsGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.descriptionIdGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.descriptionGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.validatedPackingListGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.validatedPackingListGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.validatedPackingListGridControl;
            this.gridView1.Name = "gridView1";
            // 
            // validatedPackingListGridControl
            // 
            this.validatedPackingListGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.validatedPackingListGridControl.Location = new System.Drawing.Point(0, 0);
            this.validatedPackingListGridControl.MainView = this.validatedPackingListGridView;
            this.validatedPackingListGridControl.Name = "validatedPackingListGridControl";
            this.validatedPackingListGridControl.Size = new System.Drawing.Size(953, 610);
            this.validatedPackingListGridControl.TabIndex = 0;
            this.validatedPackingListGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.validatedPackingListGridView,
            this.gridView1});
            // 
            // validatedPackingListGridView
            // 
            this.validatedPackingListGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.idGridColumn,
            this.timestampGridColumn,
            this.expectedGridColumn,
            this.actualGridColumn,
            this.packedManuallyGridColumn,
            this.instrumentsGridColumn,
            this.descriptionIdGridColumn,
            this.descriptionGridColumn});
            this.validatedPackingListGridView.GridControl = this.validatedPackingListGridControl;
            this.validatedPackingListGridView.Name = "validatedPackingListGridView";
            this.validatedPackingListGridView.OptionsBehavior.Editable = false;
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
            // expectedGridColumn
            // 
            this.expectedGridColumn.Caption = "Expected";
            this.expectedGridColumn.FieldName = "Expected";
            this.expectedGridColumn.Name = "expectedGridColumn";
            this.expectedGridColumn.Visible = true;
            this.expectedGridColumn.VisibleIndex = 1;
            this.expectedGridColumn.Width = 56;
            // 
            // actualGridColumn
            // 
            this.actualGridColumn.Caption = "Actual";
            this.actualGridColumn.FieldName = "Actual";
            this.actualGridColumn.Name = "actualGridColumn";
            this.actualGridColumn.Visible = true;
            this.actualGridColumn.VisibleIndex = 2;
            this.actualGridColumn.Width = 56;
            // 
            // packedManuallyGridColumn
            // 
            this.packedManuallyGridColumn.Caption = "Packed Manually";
            this.packedManuallyGridColumn.FieldName = "PackedManually";
            this.packedManuallyGridColumn.Name = "packedManuallyGridColumn";
            this.packedManuallyGridColumn.Visible = true;
            this.packedManuallyGridColumn.VisibleIndex = 3;
            this.packedManuallyGridColumn.Width = 56;
            // 
            // instrumentsGridColumn
            // 
            this.instrumentsGridColumn.Caption = "Instruments";
            this.instrumentsGridColumn.FieldName = "Instruments";
            this.instrumentsGridColumn.Name = "instrumentsGridColumn";
            this.instrumentsGridColumn.Visible = true;
            this.instrumentsGridColumn.VisibleIndex = 6;
            this.instrumentsGridColumn.Width = 56;
            // 
            // descriptionIdGridColumn
            // 
            this.descriptionIdGridColumn.Caption = "Description Id";
            this.descriptionIdGridColumn.FieldName = "DescriptionId";
            this.descriptionIdGridColumn.Name = "descriptionIdGridColumn";
            this.descriptionIdGridColumn.Visible = true;
            this.descriptionIdGridColumn.VisibleIndex = 4;
            this.descriptionIdGridColumn.Width = 56;
            // 
            // descriptionGridColumn
            // 
            this.descriptionGridColumn.Caption = "Description";
            this.descriptionGridColumn.FieldName = "Description";
            this.descriptionGridColumn.Name = "descriptionGridColumn";
            this.descriptionGridColumn.Visible = true;
            this.descriptionGridColumn.VisibleIndex = 5;
            this.descriptionGridColumn.Width = 56;
            // 
            // ValidatedPackingListDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 610);
            this.Controls.Add(this.validatedPackingListGridControl);
            this.Name = "ValidatedPackingListDetails";
            this.Text = "ValidatedPackingListDetails";
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.validatedPackingListGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.validatedPackingListGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl validatedPackingListGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView validatedPackingListGridView;
        private DevExpress.XtraGrid.Columns.GridColumn idGridColumn;
        private DevExpress.XtraGrid.Columns.GridColumn timestampGridColumn;
        private DevExpress.XtraGrid.Columns.GridColumn expectedGridColumn;
        private DevExpress.XtraGrid.Columns.GridColumn actualGridColumn;
        private DevExpress.XtraGrid.Columns.GridColumn packedManuallyGridColumn;
        private DevExpress.XtraGrid.Columns.GridColumn instrumentsGridColumn;
        private DevExpress.XtraGrid.Columns.GridColumn descriptionIdGridColumn;
        private DevExpress.XtraGrid.Columns.GridColumn descriptionGridColumn;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}