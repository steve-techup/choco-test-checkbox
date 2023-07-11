using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIControls.WinForms;

namespace UIControls.Winforms.Dialogs
{
    public partial class ImagePreviewDlg : Form
    {
        private Image _image;

        public ImagePreviewDlg()
        {
            InitializeComponent();
        }

        public bool Execute(Image image)
        {
            _image = image;

            ReloadImage();

            return this.ShowDialog() != DialogResult.OK;
        }

        private void ReloadImage()
        {
            if (_image == null)
                return;

            if ((_image.Width > previewImage.Width) || (_image.Height > previewImage.Height))
            {
                // bigger than preview box, use thumbnail
                _image.Thumbnail(previewImage);
            }
            else
            {
                previewImage.Image = _image;
            }
        }

        private void ImagePreviewDlg_Resize(object sender, EventArgs e)
        {
            ReloadImage();
        }
    }
}
