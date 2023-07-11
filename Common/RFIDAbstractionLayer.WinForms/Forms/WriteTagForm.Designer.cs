
namespace RFIDAbstractionLayer.WinForms
{
    partial class WriteTagForm
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
            this.gbReadTag = new System.Windows.Forms.GroupBox();
            this.btnReadTag = new System.Windows.Forms.Button();
            this.tbReadEPC = new System.Windows.Forms.TextBox();
            this.lblReadEPC = new System.Windows.Forms.Label();
            this.gbWriteTag = new System.Windows.Forms.GroupBox();
            this.cbLockTag = new System.Windows.Forms.CheckBox();
            this.btnChangeEPC = new System.Windows.Forms.Button();
            this.tbWriteEPC = new System.Windows.Forms.TextBox();
            this.lblWriteEPC = new System.Windows.Forms.Label();
            this.gbVerify = new System.Windows.Forms.GroupBox();
            this.lblReadBackEPC = new System.Windows.Forms.Label();
            this.lblRead = new System.Windows.Forms.Label();
            this.lblOperationStatus = new System.Windows.Forms.Label();
            this.lblNewEPC = new System.Windows.Forms.Label();
            this.lblOldEPC = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblNew = new System.Windows.Forms.Label();
            this.lblOld = new System.Windows.Forms.Label();
            this.btnOnceMore = new System.Windows.Forms.Button();
            this.bntClose = new System.Windows.Forms.Button();
            this.lblWriteIncorrectSize = new System.Windows.Forms.Label();
            this.gbReadTag.SuspendLayout();
            this.gbWriteTag.SuspendLayout();
            this.gbVerify.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbReadTag
            // 
            this.gbReadTag.Controls.Add(this.btnReadTag);
            this.gbReadTag.Controls.Add(this.tbReadEPC);
            this.gbReadTag.Controls.Add(this.lblReadEPC);
            this.gbReadTag.Location = new System.Drawing.Point(12, 12);
            this.gbReadTag.Name = "gbReadTag";
            this.gbReadTag.Size = new System.Drawing.Size(445, 100);
            this.gbReadTag.TabIndex = 0;
            this.gbReadTag.TabStop = false;
            this.gbReadTag.Text = " Read Tag ";
            // 
            // btnReadTag
            // 
            this.btnReadTag.Location = new System.Drawing.Point(22, 64);
            this.btnReadTag.Name = "btnReadTag";
            this.btnReadTag.Size = new System.Drawing.Size(394, 23);
            this.btnReadTag.TabIndex = 2;
            this.btnReadTag.Text = "Read tag from Reader";
            this.btnReadTag.UseVisualStyleBackColor = true;
            this.btnReadTag.Click += new System.EventHandler(this.btnReadTag_Click);
            // 
            // tbReadEPC
            // 
            this.tbReadEPC.Enabled = false;
            this.tbReadEPC.Location = new System.Drawing.Point(22, 38);
            this.tbReadEPC.Name = "tbReadEPC";
            this.tbReadEPC.Size = new System.Drawing.Size(394, 20);
            this.tbReadEPC.TabIndex = 1;
            // 
            // lblReadEPC
            // 
            this.lblReadEPC.AutoSize = true;
            this.lblReadEPC.Location = new System.Drawing.Point(19, 22);
            this.lblReadEPC.Name = "lblReadEPC";
            this.lblReadEPC.Size = new System.Drawing.Size(152, 13);
            this.lblReadEPC.TabIndex = 0;
            this.lblReadEPC.Text = "Electronic Product Code (EPC)";
            // 
            // gbWriteTag
            // 
            this.gbWriteTag.Controls.Add(this.lblWriteIncorrectSize);
            this.gbWriteTag.Controls.Add(this.cbLockTag);
            this.gbWriteTag.Controls.Add(this.btnChangeEPC);
            this.gbWriteTag.Controls.Add(this.tbWriteEPC);
            this.gbWriteTag.Controls.Add(this.lblWriteEPC);
            this.gbWriteTag.Enabled = false;
            this.gbWriteTag.Location = new System.Drawing.Point(12, 118);
            this.gbWriteTag.Name = "gbWriteTag";
            this.gbWriteTag.Size = new System.Drawing.Size(445, 114);
            this.gbWriteTag.TabIndex = 1;
            this.gbWriteTag.TabStop = false;
            this.gbWriteTag.Text = " Write new tag ";
            // 
            // cbLockTag
            // 
            this.cbLockTag.AutoSize = true;
            this.cbLockTag.Location = new System.Drawing.Point(22, 60);
            this.cbLockTag.Name = "cbLockTag";
            this.cbLockTag.Size = new System.Drawing.Size(72, 17);
            this.cbLockTag.TabIndex = 6;
            this.cbLockTag.Text = "Lock Tag";
            this.cbLockTag.UseVisualStyleBackColor = true;
            // 
            // btnChangeEPC
            // 
            this.btnChangeEPC.Location = new System.Drawing.Point(20, 83);
            this.btnChangeEPC.Name = "btnChangeEPC";
            this.btnChangeEPC.Size = new System.Drawing.Size(396, 23);
            this.btnChangeEPC.TabIndex = 5;
            this.btnChangeEPC.Text = "Change EPC";
            this.btnChangeEPC.UseVisualStyleBackColor = true;
            this.btnChangeEPC.Click += new System.EventHandler(this.btnChangeEPC_Click);
            // 
            // tbWriteEPC
            // 
            this.tbWriteEPC.Location = new System.Drawing.Point(22, 34);
            this.tbWriteEPC.Name = "tbWriteEPC";
            this.tbWriteEPC.Size = new System.Drawing.Size(394, 20);
            this.tbWriteEPC.TabIndex = 4;
            // 
            // lblWriteEPC
            // 
            this.lblWriteEPC.AutoSize = true;
            this.lblWriteEPC.Location = new System.Drawing.Point(19, 18);
            this.lblWriteEPC.Name = "lblWriteEPC";
            this.lblWriteEPC.Size = new System.Drawing.Size(177, 13);
            this.lblWriteEPC.TabIndex = 3;
            this.lblWriteEPC.Text = "New Electronic Product Code (EPC)";
            // 
            // gbVerify
            // 
            this.gbVerify.Controls.Add(this.lblReadBackEPC);
            this.gbVerify.Controls.Add(this.lblRead);
            this.gbVerify.Controls.Add(this.lblOperationStatus);
            this.gbVerify.Controls.Add(this.lblNewEPC);
            this.gbVerify.Controls.Add(this.lblOldEPC);
            this.gbVerify.Controls.Add(this.lblStatus);
            this.gbVerify.Controls.Add(this.lblNew);
            this.gbVerify.Controls.Add(this.lblOld);
            this.gbVerify.Location = new System.Drawing.Point(12, 238);
            this.gbVerify.Name = "gbVerify";
            this.gbVerify.Size = new System.Drawing.Size(445, 121);
            this.gbVerify.TabIndex = 2;
            this.gbVerify.TabStop = false;
            this.gbVerify.Text = " Verify New EPC ";
            // 
            // lblReadBackEPC
            // 
            this.lblReadBackEPC.AutoSize = true;
            this.lblReadBackEPC.Location = new System.Drawing.Point(62, 71);
            this.lblReadBackEPC.Name = "lblReadBackEPC";
            this.lblReadBackEPC.Size = new System.Drawing.Size(60, 13);
            this.lblReadBackEPC.TabIndex = 7;
            this.lblReadBackEPC.Text = "<Dynamic>";
            // 
            // lblRead
            // 
            this.lblRead.AutoSize = true;
            this.lblRead.Location = new System.Drawing.Point(17, 71);
            this.lblRead.Name = "lblRead";
            this.lblRead.Size = new System.Drawing.Size(33, 13);
            this.lblRead.TabIndex = 6;
            this.lblRead.Text = "Read";
            // 
            // lblOperationStatus
            // 
            this.lblOperationStatus.AutoSize = true;
            this.lblOperationStatus.Location = new System.Drawing.Point(62, 94);
            this.lblOperationStatus.Name = "lblOperationStatus";
            this.lblOperationStatus.Size = new System.Drawing.Size(60, 13);
            this.lblOperationStatus.TabIndex = 5;
            this.lblOperationStatus.Text = "<Dynamic>";
            // 
            // lblNewEPC
            // 
            this.lblNewEPC.AutoSize = true;
            this.lblNewEPC.Location = new System.Drawing.Point(62, 47);
            this.lblNewEPC.Name = "lblNewEPC";
            this.lblNewEPC.Size = new System.Drawing.Size(60, 13);
            this.lblNewEPC.TabIndex = 4;
            this.lblNewEPC.Text = "<Dynamic>";
            // 
            // lblOldEPC
            // 
            this.lblOldEPC.AutoSize = true;
            this.lblOldEPC.Location = new System.Drawing.Point(62, 24);
            this.lblOldEPC.Name = "lblOldEPC";
            this.lblOldEPC.Size = new System.Drawing.Size(60, 13);
            this.lblOldEPC.TabIndex = 3;
            this.lblOldEPC.Text = "<Dynamic>";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(17, 94);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status";
            // 
            // lblNew
            // 
            this.lblNew.AutoSize = true;
            this.lblNew.Location = new System.Drawing.Point(17, 47);
            this.lblNew.Name = "lblNew";
            this.lblNew.Size = new System.Drawing.Size(29, 13);
            this.lblNew.TabIndex = 1;
            this.lblNew.Text = "New";
            // 
            // lblOld
            // 
            this.lblOld.AutoSize = true;
            this.lblOld.Location = new System.Drawing.Point(17, 24);
            this.lblOld.Name = "lblOld";
            this.lblOld.Size = new System.Drawing.Size(23, 13);
            this.lblOld.TabIndex = 0;
            this.lblOld.Text = "Old";
            // 
            // btnOnceMore
            // 
            this.btnOnceMore.Enabled = false;
            this.btnOnceMore.Location = new System.Drawing.Point(12, 375);
            this.btnOnceMore.Name = "btnOnceMore";
            this.btnOnceMore.Size = new System.Drawing.Size(122, 23);
            this.btnOnceMore.TabIndex = 3;
            this.btnOnceMore.Text = "Do another tag";
            this.btnOnceMore.UseVisualStyleBackColor = true;
            this.btnOnceMore.Click += new System.EventHandler(this.btnOnceMore_Click);
            // 
            // bntClose
            // 
            this.bntClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bntClose.Location = new System.Drawing.Point(351, 375);
            this.bntClose.Name = "bntClose";
            this.bntClose.Size = new System.Drawing.Size(106, 23);
            this.bntClose.TabIndex = 4;
            this.bntClose.Text = "Close Dialog";
            this.bntClose.UseVisualStyleBackColor = true;
            // 
            // lblWriteIncorrectSize
            // 
            this.lblWriteIncorrectSize.AutoSize = true;
            this.lblWriteIncorrectSize.ForeColor = System.Drawing.Color.Red;
            this.lblWriteIncorrectSize.Location = new System.Drawing.Point(331, 18);
            this.lblWriteIncorrectSize.Name = "lblWriteIncorrectSize";
            this.lblWriteIncorrectSize.Size = new System.Drawing.Size(85, 13);
            this.lblWriteIncorrectSize.TabIndex = 7;
            this.lblWriteIncorrectSize.Text = "Incorrect Length";
            this.lblWriteIncorrectSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblWriteIncorrectSize.Visible = false;
            // 
            // WriteTagForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 410);
            this.Controls.Add(this.bntClose);
            this.Controls.Add(this.btnOnceMore);
            this.Controls.Add(this.gbVerify);
            this.Controls.Add(this.gbWriteTag);
            this.Controls.Add(this.gbReadTag);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "WriteTagForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WriteTag";
            this.gbReadTag.ResumeLayout(false);
            this.gbReadTag.PerformLayout();
            this.gbWriteTag.ResumeLayout(false);
            this.gbWriteTag.PerformLayout();
            this.gbVerify.ResumeLayout(false);
            this.gbVerify.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbReadTag;
        private System.Windows.Forms.Button btnReadTag;
        private System.Windows.Forms.TextBox tbReadEPC;
        private System.Windows.Forms.Label lblReadEPC;
        private System.Windows.Forms.GroupBox gbWriteTag;
        private System.Windows.Forms.Button btnChangeEPC;
        private System.Windows.Forms.TextBox tbWriteEPC;
        private System.Windows.Forms.Label lblWriteEPC;
        private System.Windows.Forms.GroupBox gbVerify;
        private System.Windows.Forms.Label lblOperationStatus;
        private System.Windows.Forms.Label lblNewEPC;
        private System.Windows.Forms.Label lblOldEPC;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblNew;
        private System.Windows.Forms.Label lblOld;
        private System.Windows.Forms.Button btnOnceMore;
        private System.Windows.Forms.Button bntClose;
        private System.Windows.Forms.Label lblReadBackEPC;
        private System.Windows.Forms.Label lblRead;
        private System.Windows.Forms.CheckBox cbLockTag;
        private System.Windows.Forms.Label lblWriteIncorrectSize;
    }
}