namespace AdminStation.Views.Reports
{
    partial class PackingLogView
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
            this.packingLogGridControl = new DevExpress.XtraGrid.GridControl();
            this.packingLogGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.packingLogGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.packingLogGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // packingLogGridControl
            // 
            this.packingLogGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.packingLogGridControl.Location = new System.Drawing.Point(0, 0);
            this.packingLogGridControl.MainView = this.packingLogGridView;
            this.packingLogGridControl.Name = "packingLogGridControl";
            this.packingLogGridControl.Size = new System.Drawing.Size(863, 666);
            this.packingLogGridControl.TabIndex = 0;
            this.packingLogGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.packingLogGridView});
            // 
            // packingLogGridView
            // 
            this.packingLogGridView.GridControl = this.packingLogGridControl;
            this.packingLogGridView.Name = "packingLogGridView";
            this.packingLogGridView.OptionsBehavior.AllowIncrementalSearch = true;
            this.packingLogGridView.OptionsBehavior.Editable = false;
            this.packingLogGridView.OptionsFind.Behavior = DevExpress.XtraEditors.FindPanelBehavior.Search;
            this.packingLogGridView.OptionsFind.SearchInPreview = true;
            // 
            // PackingLogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.packingLogGridControl);
            this.Name = "PackingLogView";
            this.Size = new System.Drawing.Size(863, 666);
            ((System.ComponentModel.ISupportInitialize)(this.packingLogGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.packingLogGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl packingLogGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView packingLogGridView;
    }
}
