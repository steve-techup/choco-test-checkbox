using System.Diagnostics;
using System.Windows.Forms;

namespace Caretag_Class
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class SplashScreen : System.Windows.Forms.Form
    {
        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is object)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.companyInfoLabel = new System.Windows.Forms.Label();
            this.LabelID = new System.Windows.Forms.Label();
            this.LabelVersion = new System.Windows.Forms.Label();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.HeaderTextBox = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // companyInfoLabel
            // 
            resources.ApplyResources(this.companyInfoLabel, "companyInfoLabel");
            this.companyInfoLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.companyInfoLabel.ForeColor = System.Drawing.Color.DimGray;
            this.companyInfoLabel.Name = "companyInfoLabel";
            // 
            // LabelID
            // 
            resources.ApplyResources(this.LabelID, "LabelID");
            this.LabelID.ForeColor = System.Drawing.Color.DimGray;
            this.LabelID.Name = "LabelID";
            this.LabelID.UseMnemonic = false;
            // 
            // LabelVersion
            // 
            resources.ApplyResources(this.LabelVersion, "LabelVersion");
            this.LabelVersion.ForeColor = System.Drawing.Color.DimGray;
            this.LabelVersion.Name = "LabelVersion";
            // 
            // txtMsg
            // 
            resources.ApplyResources(this.txtMsg, "txtMsg");
            this.txtMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel1.SetColumnSpan(this.txtMsg, 2);
            this.txtMsg.ForeColor = System.Drawing.Color.Black;
            this.txtMsg.Name = "txtMsg";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.LabelID, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.companyInfoLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LabelVersion, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtMsg, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.PictureBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.HeaderTextBox, 0, 1);
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // PictureBox1
            // 
            resources.ApplyResources(this.PictureBox1, "PictureBox1");
            this.PictureBox1.Image = global::Caretag_Class.My.Resources.Resources.caretag_sm;
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.TabStop = false;
            // 
            // HeaderTextBox
            // 
            resources.ApplyResources(this.HeaderTextBox, "HeaderTextBox");
            this.tableLayoutPanel1.SetColumnSpan(this.HeaderTextBox, 2);
            this.HeaderTextBox.Name = "HeaderTextBox";
            // 
            // SplashScreen
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreen";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        public System.Windows.Forms.PictureBox PictureBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label companyInfoLabel;
        private Label LabelID;
        private Label LabelVersion;
        private TextBox txtMsg;
        private Label HeaderTextBox;
    }
}