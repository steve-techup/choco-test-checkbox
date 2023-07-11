namespace Caretag_Class.ReactiveUI.Views
{
    partial class TouchscreenPackingListView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGridViewInstruments = new System.Windows.Forms.DataGridView();
            this.manualImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.AssetTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityManuallyPackedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityRenderedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InstrumentDescriptionColumnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InstrumentVendorColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackedInTrayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPacked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CanPackManually = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewInstruments)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewInstruments
            // 
            this.DataGridViewInstruments.AllowUserToAddRows = false;
            this.DataGridViewInstruments.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DataGridViewInstruments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridViewInstruments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewInstruments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.manualImageColumn,
            this.AssetTypeId,
            this.quantityManuallyPackedColumn,
            this.QuantityRenderedColumn,
            this.InstrumentDescriptionColumnt,
            this.DescriptionIdColumn,
            this.InstrumentVendorColumn,
            this.StatusColumn,
            this.QuantityColumn,
            this.PackedInTrayColumn,
            this.TotalPacked,
            this.CanPackManually});
            this.DataGridViewInstruments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridViewInstruments.Location = new System.Drawing.Point(0, 0);
            this.DataGridViewInstruments.Margin = new System.Windows.Forms.Padding(2);
            this.DataGridViewInstruments.MultiSelect = false;
            this.DataGridViewInstruments.Name = "DataGridViewInstruments";
            this.DataGridViewInstruments.RowHeadersVisible = false;
            this.DataGridViewInstruments.RowHeadersWidth = 51;
            this.DataGridViewInstruments.RowTemplate.Height = 32;
            this.DataGridViewInstruments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewInstruments.ShowEditingIcon = false;
            this.DataGridViewInstruments.ShowRowErrors = false;
            this.DataGridViewInstruments.Size = new System.Drawing.Size(477, 356);
            this.DataGridViewInstruments.TabIndex = 89;
            this.DataGridViewInstruments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewInstruments_CellClick);
            this.DataGridViewInstruments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewInstruments_CellContentClick);
            this.DataGridViewInstruments.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewInstruments_CellContentDoubleClick);
            this.DataGridViewInstruments.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewInstruments_CellDoubleClick);
            this.DataGridViewInstruments.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewInstruments_CellFormatting);
            this.DataGridViewInstruments.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.DataGridViewInstruments_CellParsing);
            this.DataGridViewInstruments.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridViewInstruments_DataBindingComplete);
            this.DataGridViewInstruments.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DataGridViewInstruments_RowsAdded);
            this.DataGridViewInstruments.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DataGridViewInstruments_MouseDown);
            // 
            // manualImageColumn
            // 
            this.manualImageColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.manualImageColumn.DataPropertyName = "ManualImageColumnValue";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.manualImageColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.manualImageColumn.HeaderText = "";
            this.manualImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.manualImageColumn.MinimumWidth = 40;
            this.manualImageColumn.Name = "manualImageColumn";
            this.manualImageColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.manualImageColumn.Width = 40;
            // 
            // AssetTypeId
            // 
            this.AssetTypeId.DataPropertyName = "AssetTypeId";
            this.AssetTypeId.HeaderText = "AssetTypeId";
            this.AssetTypeId.Name = "AssetTypeId";
            this.AssetTypeId.Visible = false;
            // 
            // quantityManuallyPackedColumn
            // 
            this.quantityManuallyPackedColumn.DataPropertyName = "QuantityPackedManually";
            this.quantityManuallyPackedColumn.HeaderText = "Quantity Packed Manually";
            this.quantityManuallyPackedColumn.MinimumWidth = 6;
            this.quantityManuallyPackedColumn.Name = "quantityManuallyPackedColumn";
            this.quantityManuallyPackedColumn.Visible = false;
            this.quantityManuallyPackedColumn.Width = 125;
            // 
            // QuantityRenderedColumn
            // 
            this.QuantityRenderedColumn.DataPropertyName = "QuantityRendered";
            this.QuantityRenderedColumn.HeaderText = "Quantity";
            this.QuantityRenderedColumn.MinimumWidth = 6;
            this.QuantityRenderedColumn.Name = "QuantityRenderedColumn";
            this.QuantityRenderedColumn.ReadOnly = true;
            // 
            // InstrumentDescriptionColumnt
            // 
            this.InstrumentDescriptionColumnt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InstrumentDescriptionColumnt.DataPropertyName = "InstrumentDescription";
            this.InstrumentDescriptionColumnt.HeaderText = "Description";
            this.InstrumentDescriptionColumnt.MinimumWidth = 6;
            this.InstrumentDescriptionColumnt.Name = "InstrumentDescriptionColumnt";
            this.InstrumentDescriptionColumnt.ReadOnly = true;
            // 
            // DescriptionIdColumn
            // 
            this.DescriptionIdColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DescriptionIdColumn.DataPropertyName = "DescriptionId";
            this.DescriptionIdColumn.HeaderText = "Description Id";
            this.DescriptionIdColumn.MinimumWidth = 6;
            this.DescriptionIdColumn.Name = "DescriptionIdColumn";
            this.DescriptionIdColumn.ReadOnly = true;
            this.DescriptionIdColumn.Width = 97;
            // 
            // InstrumentVendorColumn
            // 
            this.InstrumentVendorColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.InstrumentVendorColumn.DataPropertyName = "InstrumentVendor";
            this.InstrumentVendorColumn.HeaderText = "Brand";
            this.InstrumentVendorColumn.MinimumWidth = 6;
            this.InstrumentVendorColumn.Name = "InstrumentVendorColumn";
            this.InstrumentVendorColumn.ReadOnly = true;
            this.InstrumentVendorColumn.Width = 60;
            // 
            // StatusColumn
            // 
            this.StatusColumn.DataPropertyName = "Status";
            this.StatusColumn.HeaderText = "Status";
            this.StatusColumn.MinimumWidth = 6;
            this.StatusColumn.Name = "StatusColumn";
            this.StatusColumn.Width = 125;
            // 
            // QuantityColumn
            // 
            this.QuantityColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.QuantityColumn.DataPropertyName = "Quantity";
            this.QuantityColumn.HeaderText = "Expected Quantity";
            this.QuantityColumn.MinimumWidth = 6;
            this.QuantityColumn.Name = "QuantityColumn";
            this.QuantityColumn.ReadOnly = true;
            this.QuantityColumn.Visible = false;
            this.QuantityColumn.Width = 119;
            // 
            // PackedInTrayColumn
            // 
            this.PackedInTrayColumn.DataPropertyName = "PackedInTray";
            this.PackedInTrayColumn.HeaderText = "Packed In Tray";
            this.PackedInTrayColumn.MinimumWidth = 6;
            this.PackedInTrayColumn.Name = "PackedInTrayColumn";
            this.PackedInTrayColumn.ReadOnly = true;
            this.PackedInTrayColumn.Visible = false;
            this.PackedInTrayColumn.Width = 125;
            // 
            // TotalPacked
            // 
            this.TotalPacked.DataPropertyName = "TotalPacked";
            this.TotalPacked.HeaderText = "Total Packed";
            this.TotalPacked.MinimumWidth = 6;
            this.TotalPacked.Name = "TotalPacked";
            this.TotalPacked.Visible = false;
            this.TotalPacked.Width = 125;
            // 
            // CanPackManually
            // 
            this.CanPackManually.DataPropertyName = "CanPackManually";
            this.CanPackManually.HeaderText = "Can Pack Manually";
            this.CanPackManually.MinimumWidth = 6;
            this.CanPackManually.Name = "CanPackManually";
            this.CanPackManually.Visible = false;
            this.CanPackManually.Width = 125;
            // 
            // TouchscreenPackingListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DataGridViewInstruments);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TouchscreenPackingListView";
            this.Size = new System.Drawing.Size(477, 356);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewInstruments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridViewInstruments;
        private System.Windows.Forms.DataGridViewImageColumn manualImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssetTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityManuallyPackedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityRenderedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstrumentDescriptionColumnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstrumentVendorColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackedInTrayColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPacked;
        private System.Windows.Forms.DataGridViewTextBoxColumn CanPackManually;
    }
}
