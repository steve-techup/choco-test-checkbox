
namespace UIControls.WinForms
{
    partial class TestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
            this.groupBoxPicture = new System.Windows.Forms.GroupBox();
            this.thumbnailBox = new UIControls.Winforms.Controls.ThumbnailBox();
            this.btnBrowsePicture = new System.Windows.Forms.Button();
            this.browsePictureFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnLogOut = new UIControls.WinForms.Controls.BtnLogOut();
            this.readerPowerBar = new UIControls.WinForms.Controls.ReaderPowerBar();
            this.btnOSK1 = new UIControls.WinForms.Controls.BtnOSK();
            this.thumbnailBox1 = new UIControls.Winforms.Controls.ThumbnailBox();
            this.groupBoxPicture.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPicture
            // 
            this.groupBoxPicture.Controls.Add(this.thumbnailBox);
            this.groupBoxPicture.Controls.Add(this.btnBrowsePicture);
            resources.ApplyResources(this.groupBoxPicture, "groupBoxPicture");
            this.groupBoxPicture.Name = "groupBoxPicture";
            this.groupBoxPicture.TabStop = false;
            // 
            // thumbnailBox
            // 
            this.thumbnailBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.thumbnailBox, "thumbnailBox");
            this.thumbnailBox.Name = "thumbnailBox";
            // 
            // btnBrowsePicture
            // 
            resources.ApplyResources(this.btnBrowsePicture, "btnBrowsePicture");
            this.btnBrowsePicture.Name = "btnBrowsePicture";
            this.btnBrowsePicture.UseVisualStyleBackColor = true;
            this.btnBrowsePicture.Click += new System.EventHandler(this.btnBrowsePicture_Click);
            // 
            // browsePictureFileDialog
            // 
            resources.ApplyResources(this.browsePictureFileDialog, "browsePictureFileDialog");
            // 
            // btnLogOut
            // 
            this.btnLogOut.ButtonType = UIControls.WinForms.Controls.BtnLogOutLabel.Logout;
            resources.ApplyResources(this.btnLogOut, "btnLogOut");
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.OnLogout += new UIControls.WinForms.Controls._OnLogout(this.btnLogOut_OnLogout);
            // 
            // readerPowerBar
            // 
            resources.ApplyResources(this.readerPowerBar, "readerPowerBar");
            this.readerPowerBar.Name = "readerPowerBar";
            // 
            // btnOSK1
            // 
            resources.ApplyResources(this.btnOSK1, "btnOSK1");
            this.btnOSK1.Name = "btnOSK1";
            // 
            // thumbnailBox1
            // 
            this.thumbnailBox1.Image = null;
            resources.ApplyResources(this.thumbnailBox1, "thumbnailBox1");
            this.thumbnailBox1.Name = "thumbnailBox1";
            // 
            // TestForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.thumbnailBox1);
            this.Controls.Add(this.groupBoxPicture);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.readerPowerBar);
            this.Controls.Add(this.btnOSK1);
            this.Name = "TestForm";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.groupBoxPicture.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private WinForms.Controls.BtnOSK btnOSK1;
        private WinForms.Controls.ReaderPowerBar readerPowerBar;
        private Controls.BtnLogOut btnLogOut;
        private System.Windows.Forms.GroupBox groupBoxPicture;
        private System.Windows.Forms.Button btnBrowsePicture;
        private System.Windows.Forms.OpenFileDialog browsePictureFileDialog;
        private Winforms.Controls.ThumbnailBox thumbnailBox;
        private Winforms.Controls.ThumbnailBox thumbnailBox1;
    }
}

