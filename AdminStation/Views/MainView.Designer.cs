using System.Windows.Forms;

namespace AdminStation.Views
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instrumentTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.costCentersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scansToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packingLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.costLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.routedControlHost = new ReactiveUI.Winforms.RoutedControlHost();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.assetsToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToExcelToolStripMenuItem,
            this.logOutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exportToExcelToolStripMenuItem
            // 
            this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
            this.exportToExcelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // assetsToolStripMenuItem
            // 
            this.assetsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instrumentTypesToolStripMenuItem,
            this.importToolStripMenuItem,
            this.traysToolStripMenuItem,
            this.costCentersToolStripMenuItem});
            this.assetsToolStripMenuItem.Name = "assetsToolStripMenuItem";
            this.assetsToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.assetsToolStripMenuItem.Text = "Assets";
            // 
            // instrumentTypesToolStripMenuItem
            // 
            this.instrumentTypesToolStripMenuItem.Name = "instrumentTypesToolStripMenuItem";
            this.instrumentTypesToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.instrumentTypesToolStripMenuItem.Text = "Instrument Types";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.importToolStripMenuItem.Text = "Import from CSV";
            // 
            // traysToolStripMenuItem
            // 
            this.traysToolStripMenuItem.Name = "traysToolStripMenuItem";
            this.traysToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.traysToolStripMenuItem.Text = "Trays";
            // 
            // costCentersToolStripMenuItem
            // 
            this.costCentersToolStripMenuItem.Name = "costCentersToolStripMenuItem";
            this.costCentersToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.costCentersToolStripMenuItem.Text = "Cost Centers";
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scansToolStripMenuItem,
            this.packingLogsToolStripMenuItem,
            this.costLogToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // scansToolStripMenuItem
            // 
            this.scansToolStripMenuItem.Name = "scansToolStripMenuItem";
            this.scansToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.scansToolStripMenuItem.Text = "Checkbox Scans";
            // 
            // packingLogsToolStripMenuItem
            // 
            this.packingLogsToolStripMenuItem.Name = "packingLogsToolStripMenuItem";
            this.packingLogsToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.packingLogsToolStripMenuItem.Text = "Packing Logs";
            // 
            // costLogToolStripMenuItem
            // 
            this.costLogToolStripMenuItem.Name = "costLogToolStripMenuItem";
            this.costLogToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.costLogToolStripMenuItem.Text = "Cost Log";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersToolStripMenuItem1});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // usersToolStripMenuItem1
            // 
            this.usersToolStripMenuItem1.Name = "usersToolStripMenuItem1";
            this.usersToolStripMenuItem1.Size = new System.Drawing.Size(102, 22);
            this.usersToolStripMenuItem1.Text = "Users";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.usersToolStripMenuItem.Text = "Users";
            // 
            // routedControlHost
            // 
            this.routedControlHost.DefaultContent = null;
            this.routedControlHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.routedControlHost.Location = new System.Drawing.Point(0, 24);
            this.routedControlHost.Name = "routedControlHost";
            this.routedControlHost.Router = null;
            this.routedControlHost.Size = new System.Drawing.Size(1800, 976);
            this.routedControlHost.TabIndex = 1;
            this.routedControlHost.ViewLocator = null;
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.logOutToolStripMenuItem.Text = "Log Out";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1800, 1000);
            this.Controls.Add(this.routedControlHost);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainView";
            this.Text = "Admin Station";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private ReactiveUI.Winforms.RoutedControlHost routedControlHost;
        private System.Windows.Forms.ToolStripMenuItem instrumentTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem costCentersToolStripMenuItem;
        private ToolStripMenuItem usersToolStripMenuItem;
        private ToolStripMenuItem scansToolStripMenuItem;
        private ToolStripMenuItem packingLogsToolStripMenuItem;
        private ToolStripMenuItem usersToolStripMenuItem1;
        private ToolStripMenuItem costLogToolStripMenuItem;
        private ToolStripMenuItem exportToExcelToolStripMenuItem;
        private ToolStripMenuItem logOutToolStripMenuItem;
    }
}