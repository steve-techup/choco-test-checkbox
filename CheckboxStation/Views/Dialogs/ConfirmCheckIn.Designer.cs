namespace CheckboxStation
{
    partial class ConfirmCheckIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmCheckIn));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Panel1 = new System.Windows.Forms.Panel();
            this._TopTitle = new System.Windows.Forms.Label();
            this.addToCurrentButton = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            this.scanNewButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.operationsGridView = new System.Windows.Forms.DataGridView();
            this.OperationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperatingRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.operationsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.DarkOrange;
            this.Panel1.Controls.Add(this._TopTitle);
            resources.ApplyResources(this.Panel1, "Panel1");
            this.Panel1.Name = "Panel1";
            // 
            // _TopTitle
            // 
            resources.ApplyResources(this._TopTitle, "_TopTitle");
            this._TopTitle.BackColor = System.Drawing.Color.Transparent;
            this._TopTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this._TopTitle.Name = "_TopTitle";
            // 
            // addToCurrentButton
            // 
            this.addToCurrentButton.BackColor = System.Drawing.Color.DarkOrange;
            resources.ApplyResources(this.addToCurrentButton, "addToCurrentButton");
            this.addToCurrentButton.ForeColor = System.Drawing.Color.White;
            this.addToCurrentButton.Name = "addToCurrentButton";
            this.addToCurrentButton.UseVisualStyleBackColor = false;
            // 
            // messageLabel
            // 
            resources.ApplyResources(this.messageLabel, "messageLabel");
            this.messageLabel.Name = "messageLabel";
            // 
            // scanNewButton
            // 
            resources.ApplyResources(this.scanNewButton, "scanNewButton");
            this.scanNewButton.ForeColor = System.Drawing.Color.DarkOrange;
            this.scanNewButton.Name = "scanNewButton";
            this.scanNewButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // operationsGridView
            // 
            this.operationsGridView.AllowUserToAddRows = false;
            this.operationsGridView.AllowUserToDeleteRows = false;
            this.operationsGridView.AllowUserToResizeColumns = false;
            this.operationsGridView.AllowUserToResizeRows = false;
            this.operationsGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.operationsGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.operationsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.operationsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OperationId,
            this.OperatingRoom,
            this.State});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.operationsGridView.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.operationsGridView, "operationsGridView");
            this.operationsGridView.MultiSelect = false;
            this.operationsGridView.Name = "operationsGridView";
            this.operationsGridView.ReadOnly = true;
            this.operationsGridView.RowHeadersVisible = false;
            this.operationsGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.operationsGridView.RowTemplate.Height = 40;
            this.operationsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.operationsGridView.ShowCellErrors = false;
            this.operationsGridView.ShowCellToolTips = false;
            this.operationsGridView.ShowEditingIcon = false;
            this.operationsGridView.ShowRowErrors = false;
            // 
            // OperationId
            // 
            this.OperationId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OperationId.DataPropertyName = "OperationId";
            resources.ApplyResources(this.OperationId, "OperationId");
            this.OperationId.Name = "OperationId";
            this.OperationId.ReadOnly = true;
            // 
            // OperatingRoom
            // 
            this.OperatingRoom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OperatingRoom.DataPropertyName = "OperatingRoom";
            resources.ApplyResources(this.OperatingRoom, "OperatingRoom");
            this.OperatingRoom.Name = "OperatingRoom";
            this.OperatingRoom.ReadOnly = true;
            // 
            // State
            // 
            this.State.DataPropertyName = "State";
            resources.ApplyResources(this.State, "State");
            this.State.Name = "State";
            this.State.ReadOnly = true;
            // 
            // ConfirmCheckIn
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.operationsGridView);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.scanNewButton);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.addToCurrentButton);
            this.Controls.Add(this.Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConfirmCheckIn";
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.operationsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.Label _TopTitle;
        private System.Windows.Forms.Button addToCurrentButton;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Button scanNewButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.DataGridView operationsGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperatingRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
    }
}