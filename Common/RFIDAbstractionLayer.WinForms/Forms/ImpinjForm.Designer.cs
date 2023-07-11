
namespace RFIDAbstractionLayer.WinForms
{
    partial class ImpinjForm
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
            this.sidePanel = new System.Windows.Forms.Panel();
            this.gbSubscription = new System.Windows.Forms.GroupBox();
            this.btnUnSub = new System.Windows.Forms.Button();
            this.btnSub = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSerial = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbIPAdr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCreateReader = new System.Windows.Forms.Button();
            this.lvTags = new System.Windows.Forms.ListView();
            this.epcHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sidePanel.SuspendLayout();
            this.gbSubscription.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidePanel
            // 
            this.sidePanel.Controls.Add(this.gbSubscription);
            this.sidePanel.Controls.Add(this.groupBox2);
            this.sidePanel.Controls.Add(this.groupBox1);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(304, 777);
            this.sidePanel.TabIndex = 6;
            // 
            // gbSubscription
            // 
            this.gbSubscription.Controls.Add(this.btnUnSub);
            this.gbSubscription.Controls.Add(this.btnSub);
            this.gbSubscription.Location = new System.Drawing.Point(8, 280);
            this.gbSubscription.Name = "gbSubscription";
            this.gbSubscription.Size = new System.Drawing.Size(288, 136);
            this.gbSubscription.TabIndex = 6;
            this.gbSubscription.TabStop = false;
            this.gbSubscription.Text = " Subscription ";
            // 
            // btnUnSub
            // 
            this.btnUnSub.Location = new System.Drawing.Point(16, 80);
            this.btnUnSub.Name = "btnUnSub";
            this.btnUnSub.Size = new System.Drawing.Size(256, 40);
            this.btnUnSub.TabIndex = 1;
            this.btnUnSub.Text = "Unsubscribe";
            this.btnUnSub.UseVisualStyleBackColor = true;
            this.btnUnSub.Click += new System.EventHandler(this.btnUnSub_Click);
            // 
            // btnSub
            // 
            this.btnSub.Location = new System.Drawing.Point(16, 32);
            this.btnSub.Name = "btnSub";
            this.btnSub.Size = new System.Drawing.Size(256, 40);
            this.btnSub.TabIndex = 0;
            this.btnSub.Text = "Subscribe";
            this.btnSub.UseVisualStyleBackColor = true;
            this.btnSub.Click += new System.EventHandler(this.btnSub_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSerial);
            this.groupBox2.Controls.Add(this.lblModel);
            this.groupBox2.Controls.Add(this.lblVersion);
            this.groupBox2.Controls.Add(this.lblBrand);
            this.groupBox2.Location = new System.Drawing.Point(8, 152);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 120);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Device Information ";
            // 
            // lblSerial
            // 
            this.lblSerial.AutoSize = true;
            this.lblSerial.Location = new System.Drawing.Point(24, 72);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(60, 17);
            this.lblSerial.TabIndex = 3;
            this.lblSerial.Text = "<Serial>";
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(24, 48);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(62, 17);
            this.lblModel.TabIndex = 2;
            this.lblModel.Text = "<Model>";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(24, 96);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(72, 17);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "<Version>";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(24, 24);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(62, 17);
            this.lblBrand.TabIndex = 0;
            this.lblBrand.Text = "<Brand>";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbIPAdr);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BtnCreateReader);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 136);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " IP ";
            // 
            // tbIPAdr
            // 
            this.tbIPAdr.Location = new System.Drawing.Point(16, 56);
            this.tbIPAdr.Name = "tbIPAdr";
            this.tbIPAdr.Size = new System.Drawing.Size(264, 22);
            this.tbIPAdr.TabIndex = 5;
            this.tbIPAdr.Text = "speedwayr-11-ad-f2.local";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Impinj Reader IP";
            // 
            // BtnCreateReader
            // 
            this.BtnCreateReader.Location = new System.Drawing.Point(16, 88);
            this.BtnCreateReader.Name = "BtnCreateReader";
            this.BtnCreateReader.Size = new System.Drawing.Size(264, 32);
            this.BtnCreateReader.TabIndex = 3;
            this.BtnCreateReader.Text = "Create Impinj Reader";
            this.BtnCreateReader.UseVisualStyleBackColor = true;
            this.BtnCreateReader.Click += new System.EventHandler(this.BtnCreateReader_Click);
            // 
            // lvTags
            // 
            this.lvTags.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.epcHeader});
            this.lvTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTags.HideSelection = false;
            this.lvTags.Location = new System.Drawing.Point(304, 0);
            this.lvTags.Name = "lvTags";
            this.lvTags.Size = new System.Drawing.Size(880, 777);
            this.lvTags.TabIndex = 7;
            this.lvTags.UseCompatibleStateImageBehavior = false;
            this.lvTags.View = System.Windows.Forms.View.Details;
            // 
            // epcHeader
            // 
            this.epcHeader.Text = "EPC";
            this.epcHeader.Width = 400;
            // 
            // ImpinjForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 777);
            this.Controls.Add(this.lvTags);
            this.Controls.Add(this.sidePanel);
            this.Name = "ImpinjForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ImpinjForm";
            this.sidePanel.ResumeLayout(false);
            this.gbSubscription.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.GroupBox gbSubscription;
        private System.Windows.Forms.Button btnUnSub;
        private System.Windows.Forms.Button btnSub;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblSerial;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbIPAdr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnCreateReader;
        private System.Windows.Forms.ListView lvTags;
        private System.Windows.Forms.ColumnHeader epcHeader;
    }
}