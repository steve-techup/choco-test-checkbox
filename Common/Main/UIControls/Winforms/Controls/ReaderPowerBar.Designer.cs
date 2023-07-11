
namespace UIControls.WinForms.Controls
{
    partial class ReaderPowerBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReaderPowerBar));
            this.gbPower = new System.Windows.Forms.GroupBox();
            this._tbPower = new System.Windows.Forms.TrackBar();
            this.gbPower.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._tbPower)).BeginInit();
            this.SuspendLayout();
            // 
            // gbPower
            // 
            this.gbPower.Controls.Add(this._tbPower);
            this.gbPower.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.gbPower, "gbPower");
            this.gbPower.Name = "gbPower";
            this.gbPower.TabStop = false;
            // 
            // _tbPower
            // 
            resources.ApplyResources(this._tbPower, "_tbPower");
            this._tbPower.LargeChange = 2;
            this._tbPower.Maximum = 4;
            this._tbPower.Name = "_tbPower";
            this._tbPower.TickStyle = System.Windows.Forms.TickStyle.Both;
            this._tbPower.ValueChanged += new System.EventHandler(this._tbPower_ValueChanged);
            // 
            // ReaderPowerBar
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbPower);
            this.Name = "ReaderPowerBar";
            this.gbPower.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._tbPower)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPower;
        private System.Windows.Forms.TrackBar _tbPower;
    }
}
