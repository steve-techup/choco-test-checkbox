
namespace RFIDAbstractionLayer.Forms
{
    partial class RFIDSimulationMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RFIDSimulationMainForm));
            this.tagsListBox = new System.Windows.Forms.ListBox();
            this.lblTagsList = new System.Windows.Forms.Label();
            this.toolStripTop = new System.Windows.Forms.ToolStrip();
            this.rfidTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.tsbBtnAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiClearList = new System.Windows.Forms.ToolStripMenuItem();
            this.popUpMenuSeperator = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAdd10 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAdd25 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAdd50 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAdd100 = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblHowTo = new System.Windows.Forms.Label();
            this.cbDeleteWhenRead = new System.Windows.Forms.CheckBox();
            this.toolStripTop.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tagsListBox
            // 
            this.tagsListBox.FormattingEnabled = true;
            resources.ApplyResources(this.tagsListBox, "tagsListBox");
            this.tagsListBox.Name = "tagsListBox";
            this.tagsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            // 
            // lblTagsList
            // 
            resources.ApplyResources(this.lblTagsList, "lblTagsList");
            this.lblTagsList.Name = "lblTagsList";
            // 
            // toolStripTop
            // 
            this.toolStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rfidTextBox,
            this.tsbBtnAdd,
            this.toolStripSeparator,
            this.toolStripDropDownButton1});
            resources.ApplyResources(this.toolStripTop, "toolStripTop");
            this.toolStripTop.Name = "toolStripTop";
            // 
            // rfidTextBox
            // 
            resources.ApplyResources(this.rfidTextBox, "rfidTextBox");
            this.rfidTextBox.Name = "rfidTextBox";
            // 
            // tsbBtnAdd
            // 
            this.tsbBtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.tsbBtnAdd, "tsbBtnAdd");
            this.tsbBtnAdd.Name = "tsbBtnAdd";
            this.tsbBtnAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            resources.ApplyResources(this.toolStripSeparator, "toolStripSeparator");
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiClearList,
            this.popUpMenuSeperator,
            this.tsmiAdd10,
            this.tsmiAdd25,
            this.tsmiAdd50,
            this.tsmiAdd100});
            resources.ApplyResources(this.toolStripDropDownButton1, "toolStripDropDownButton1");
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            // 
            // tsmiClearList
            // 
            this.tsmiClearList.Name = "tsmiClearList";
            resources.ApplyResources(this.tsmiClearList, "tsmiClearList");
            this.tsmiClearList.Click += new System.EventHandler(this.tsmiClearList_Click);
            // 
            // popUpMenuSeperator
            // 
            this.popUpMenuSeperator.Name = "popUpMenuSeperator";
            resources.ApplyResources(this.popUpMenuSeperator, "popUpMenuSeperator");
            // 
            // tsmiAdd10
            // 
            this.tsmiAdd10.Name = "tsmiAdd10";
            resources.ApplyResources(this.tsmiAdd10, "tsmiAdd10");
            this.tsmiAdd10.Tag = "10";
            this.tsmiAdd10.Click += new System.EventHandler(this.btnAddXItems_Click);
            // 
            // tsmiAdd25
            // 
            this.tsmiAdd25.Name = "tsmiAdd25";
            resources.ApplyResources(this.tsmiAdd25, "tsmiAdd25");
            this.tsmiAdd25.Tag = "25";
            this.tsmiAdd25.Click += new System.EventHandler(this.btnAddXItems_Click);
            // 
            // tsmiAdd50
            // 
            this.tsmiAdd50.Name = "tsmiAdd50";
            resources.ApplyResources(this.tsmiAdd50, "tsmiAdd50");
            this.tsmiAdd50.Tag = "50";
            this.tsmiAdd50.Click += new System.EventHandler(this.btnAddXItems_Click);
            // 
            // tsmiAdd100
            // 
            this.tsmiAdd100.Name = "tsmiAdd100";
            resources.ApplyResources(this.tsmiAdd100, "tsmiAdd100");
            this.tsmiAdd100.Tag = "100";
            this.tsmiAdd100.Click += new System.EventHandler(this.btnAddXItems_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.MistyRose;
            this.mainPanel.Controls.Add(this.lblDescription);
            this.mainPanel.Controls.Add(this.lblHowTo);
            resources.ApplyResources(this.mainPanel, "mainPanel");
            this.mainPanel.Name = "mainPanel";
            // 
            // lblDescription
            // 
            resources.ApplyResources(this.lblDescription, "lblDescription");
            this.lblDescription.Name = "lblDescription";
            // 
            // lblHowTo
            // 
            resources.ApplyResources(this.lblHowTo, "lblHowTo");
            this.lblHowTo.Name = "lblHowTo";
            // 
            // cbDeleteWhenRead
            // 
            resources.ApplyResources(this.cbDeleteWhenRead, "cbDeleteWhenRead");
            this.cbDeleteWhenRead.Checked = true;
            this.cbDeleteWhenRead.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDeleteWhenRead.Name = "cbDeleteWhenRead";
            this.cbDeleteWhenRead.UseVisualStyleBackColor = true;
            // 
            // RFIDSimulationMainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbDeleteWhenRead);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.toolStripTop);
            this.Controls.Add(this.lblTagsList);
            this.Controls.Add(this.tagsListBox);
            this.Name = "RFIDSimulationMainForm";
            this.TopMost = true;
            this.toolStripTop.ResumeLayout(false);
            this.toolStripTop.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox tagsListBox;
        private System.Windows.Forms.Label lblTagsList;
        private System.Windows.Forms.ToolStrip toolStripTop;
        private System.Windows.Forms.ToolStripTextBox rfidTextBox;
        private System.Windows.Forms.ToolStripButton tsbBtnAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem tsmiClearList;
        private System.Windows.Forms.ToolStripSeparator popUpMenuSeperator;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdd10;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdd25;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdd50;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdd100;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblHowTo;
        private System.Windows.Forms.CheckBox cbDeleteWhenRead;
    }
}