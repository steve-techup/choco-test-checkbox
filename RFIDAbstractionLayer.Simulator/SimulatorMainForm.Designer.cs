
namespace RFID.Simulator
{
    partial class SimulatorMainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.connectionStatusLabel = new System.Windows.Forms.Label();
            this.tagBox = new System.Windows.Forms.TextBox();
            this.groupBoxTag = new System.Windows.Forms.GroupBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxTag.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.AutoSize = true;
            this.connectionStatusLabel.Location = new System.Drawing.Point(57, 45);
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Size = new System.Drawing.Size(88, 15);
            this.connectionStatusLabel.TabIndex = 0;
            this.connectionStatusLabel.Text = "Not Connected";
            this.connectionStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tagBox
            // 
            this.tagBox.Location = new System.Drawing.Point(6, 22);
            this.tagBox.Name = "tagBox";
            this.tagBox.Size = new System.Drawing.Size(188, 23);
            this.tagBox.TabIndex = 1;
            // 
            // groupBoxTag
            // 
            this.groupBoxTag.Controls.Add(this.buttonSend);
            this.groupBoxTag.Controls.Add(this.tagBox);
            this.groupBoxTag.Location = new System.Drawing.Point(12, 12);
            this.groupBoxTag.Name = "groupBoxTag";
            this.groupBoxTag.Size = new System.Drawing.Size(200, 100);
            this.groupBoxTag.TabIndex = 2;
            this.groupBoxTag.TabStop = false;
            this.groupBoxTag.Text = "Tag";
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(57, 60);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.connectionStatusLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBoxConnection";
            // 
            // SimulatorMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 246);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxTag);
            this.Name = "SimulatorMainForm";
            this.Text = "RFID Simulator";
            this.groupBoxTag.ResumeLayout(false);
            this.groupBoxTag.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label connectionStatusLabel;
        private System.Windows.Forms.TextBox tagBox;
        private System.Windows.Forms.GroupBox groupBoxTag;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

