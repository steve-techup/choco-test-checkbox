using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RFIDAbstractionLayer;
using RFIDAbstractionLayer.Readers;
using UIControls.WinForms;

namespace UIControls.WinForms
{
    public partial class TestForm : Form
    {
        private Image loadedImage = null;

        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            PowerTrackBarParams parameters =
                new PowerTrackBarParams("Power", new[] {"Lowest", "Low", "Normal", "High", "Highest"}, new List<IRFIDReader>());
            readerPowerBar.InitTrackBar(parameters);
            
        }

        private void btnLogOut_OnLogout()
        {
            MessageBox.Show("Logging Out");
        }

        private void btnBrowsePicture_Click(object sender, EventArgs e)
        {
            if (browsePictureFileDialog.ShowDialog() != DialogResult.OK)
                return;

            string filename = browsePictureFileDialog.FileName;

            loadedImage = Image.FromFile(filename);
            thumbnailBox.Image = loadedImage;
        }

    }
}
