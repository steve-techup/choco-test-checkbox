
namespace UIControls.WinForms.Controls
{
    partial class BtnOSK
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BtnOSK));
            this.ilOSK = new System.Windows.Forms.ImageList(this.components);
            this.Panel = new System.Windows.Forms.Panel();
            this.BtnOnScreenKeyboard = new DevExpress.XtraEditors.SimpleButton();
            this.Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ilOSK
            // 
            this.ilOSK.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilOSK.ImageStream")));
            this.ilOSK.TransparentColor = System.Drawing.Color.Transparent;
            this.ilOSK.Images.SetKeyName(0, "kbdBlack.png");
            this.ilOSK.Images.SetKeyName(1, "kbdWhite.png");
            // 
            // Panel
            // 
            this.Panel.Controls.Add(this.BtnOnScreenKeyboard);
            resources.ApplyResources(this.Panel, "Panel");
            this.Panel.Name = "Panel";
            // 
            // BtnOnScreenKeyboard
            // 
            resources.ApplyResources(this.BtnOnScreenKeyboard, "BtnOnScreenKeyboard");
            this.BtnOnScreenKeyboard.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnOnScreenKeyboard.ImageOptions.SvgImage = global::Caretag_Class.My.Resources.Resources.computer_keyboard_wireless_icon;
            this.BtnOnScreenKeyboard.ImageOptions.SvgImageSize = new System.Drawing.Size(45, 23);
            this.BtnOnScreenKeyboard.Name = "BtnOnScreenKeyboard";
            this.BtnOnScreenKeyboard.Click += new System.EventHandler(this.BtnOnScreenKeyboard_Click_1);
            // 
            // BtnOSK
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Panel);
            this.Name = "BtnOSK";
            this.Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList ilOSK;
        private System.Windows.Forms.Panel Panel;
        private DevExpress.XtraEditors.SimpleButton BtnOnScreenKeyboard;
    }
}
