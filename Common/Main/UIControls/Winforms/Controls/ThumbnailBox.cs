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
using UIControls.Winforms.Dialogs;

namespace UIControls.Winforms.Controls
{
    public partial class ThumbnailBox : UserControl
    {
        private Image _image;

        public ThumbnailBox()
        {
            InitializeComponent();
        }

        public Image Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                LoadThumbnail();
            }
        }

        public Image Thumbnail
        {
            get
            {
                return ThumbnailPictureBox.Image;
            }
        }


        private void LoadThumbnail()
        {
            if (_image == null)
            {
                ClearImage();
                return;
            }

            _image.Thumbnail(ThumbnailPictureBox);
        }

        private void ClearImage()
        {
            _image = null;
            ThumbnailPictureBox.Image = null;
        }

        private void ThumbnailPictureBox_Click(object sender, EventArgs e)
        {
            var previewDlg = new ImagePreviewDlg();
            previewDlg.Execute(_image);
        }
    }
}
