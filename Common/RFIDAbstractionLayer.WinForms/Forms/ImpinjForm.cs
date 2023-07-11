using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RFIDAbstractionLayer.Readers;
using UIControls.WinForms;


namespace RFIDAbstractionLayer.WinForms
{
    public partial class ImpinjForm : Form
    {
        private ImpinjReader reader = null;

        public ImpinjForm()
        {
            InitializeComponent();
        }

        public bool Execute()
        {
            // init
            
            // Show form
            var result = this.ShowDialog() == DialogResult.OK;

            if (result)
            {
                // post

            }

            return result;
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            reader.Subscribe(UpdateTags);
        }

        private void btnUnSub_Click(object sender, EventArgs e)
        {
            reader.UnsubscribeAll();
        }

        private void BtnCreateReader_Click(object sender, EventArgs e)
        {
            LoadReader(tbIPAdr.Text);
        }


        private void LoadDeviceInformation(DeviceInformation devInfo)
        {
            if (devInfo == null)
                devInfo = DeviceInformation.CreateEmpty();

            lblBrand.Text = "Brand: " + devInfo.Brand;
            lblModel.Text = "Model: " + devInfo.Model;
            lblSerial.Text = "Serial: " + devInfo.Serial;
            lblVersion.Text = "Firmware: " + devInfo.Version;
        }

        private void LoadReader(string ip)
        {
            try
            {
                reader = new ImpinjReader(ip, null);
                LoadDeviceInformation(reader.GetDeviceInformation());
            }
            catch (Exception e)
            {
                string title = "Exception!";
                string message = e.Message;
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void UpdateTags(ReadingResult[] tags)
        {
            lvTags.BeginUpdate();
            lvTags.Items.Clear();

            foreach (var tag in tags)
            {
                lvTags.Items.Add(new ListViewItem() { Name = tag.Value });
            }

            lvTags.EndUpdate();
        }

    }
}
