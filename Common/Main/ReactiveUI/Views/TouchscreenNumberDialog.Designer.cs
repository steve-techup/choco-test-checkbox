namespace Caretag_Class.ReactiveUI.Views
{
    partial class TouchscreenNumberDialog
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.messageLabel = new System.Windows.Forms.Label();
            this.minusButton = new DevExpress.XtraEditors.SimpleButton();
            this.plusButton = new DevExpress.XtraEditors.SimpleButton();
            this.okButton = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.63255F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.73491F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.63255F));
            this.tableLayoutPanel1.Controls.Add(this.numberTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.messageLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.minusButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.plusButton, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.okButton, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(421, 277);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // numberTextBox
            // 
            this.numberTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberTextBox.Location = new System.Drawing.Point(178, 119);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.ReadOnly = true;
            this.numberTextBox.Size = new System.Drawing.Size(62, 38);
            this.numberTextBox.TabIndex = 0;
            // 
            // messageLabel
            // 
            this.messageLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.messageLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.messageLabel, 3);
            this.messageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLabel.Location = new System.Drawing.Point(135, 29);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(150, 33);
            this.messageLabel.TabIndex = 1;
            this.messageLabel.Text = "[message]";
            // 
            // minusButton
            // 
            this.minusButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.minusButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.minusButton.ImageOptions.SvgImage = global::Caretag_Class.My.Resources.Resources.subtract_color_icon;
            this.minusButton.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.minusButton.Location = new System.Drawing.Point(76, 109);
            this.minusButton.Name = "minusButton";
            this.minusButton.Size = new System.Drawing.Size(87, 57);
            this.minusButton.TabIndex = 2;
            // 
            // plusButton
            // 
            this.plusButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.plusButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.plusButton.ImageOptions.SvgImage = global::Caretag_Class.My.Resources.Resources.addition_color_icon;
            this.plusButton.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.plusButton.Location = new System.Drawing.Point(256, 109);
            this.plusButton.Name = "plusButton";
            this.plusButton.Size = new System.Drawing.Size(87, 57);
            this.plusButton.TabIndex = 3;
            // 
            // okButton
            // 
            this.okButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.okButton.Location = new System.Drawing.Point(169, 202);
            this.okButton.Name = "okButton";
            this.okButton.ShowToolTips = false;
            this.okButton.Size = new System.Drawing.Size(81, 57);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            // 
            // TouchscreenNumberDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 277);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TouchscreenNumberDialog";
            this.Text = "TouchscreenNumberDialog";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.Label messageLabel;
        private DevExpress.XtraEditors.SimpleButton minusButton;
        private DevExpress.XtraEditors.SimpleButton plusButton;
        private DevExpress.XtraEditors.SimpleButton okButton;
    }
}