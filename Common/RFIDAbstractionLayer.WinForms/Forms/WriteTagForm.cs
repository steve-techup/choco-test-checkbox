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

namespace RFIDAbstractionLayer.WinForms
{
    public partial class WriteTagForm : Form
    {
        private IRFIDWriter _writer;
        private IRFIDReader _reader;

        public WriteTagForm()
        {
            InitializeComponent();
        }

        public DialogResult Execute(Form windowOwner, IRFIDWriter physicalWriter)
        {
            _writer = physicalWriter;

            // Check for nordic ID reader connected
            if ((physicalWriter == null) || (!VerifyNordicIDWriter()))
            {
                MessageBox.Show("This feature requires a NordicID RFID reader to be connected to the system",
                    "NordicID RFID Reader not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return DialogResult.Abort;
            }
            else
            {
                _reader = _writer as IRFIDReader;
            }

            ResetUI();
            var result = this.ShowDialog(windowOwner);

            return result;
        }

        private bool VerifyNordicIDWriter()
        {
            IRFIDReader asReader = _writer as IRFIDReader;
            var info = asReader.GetDeviceInformation();
            return info.Brand.ToLowerInvariant() == "nordicid";
        }

        private void btnReadTag_Click(object sender, EventArgs e)
        {
            var tags = _reader.ReadTags();
            if (tags.Length == 0)
            {
                MessageBox.Show("No ta found on RFID reader", "No tag found", MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                return;
            }

            if (tags.Length > 1)
            {
                MessageBox.Show(
                    "Found " + tags.Length +
                    " tags on the reader. For this operation there can only be one tag on the reader.",
                    "Too many tags on reader", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            tbReadEPC.Text = tags[0].Value;

            gbWriteTag.Enabled = true;
            gbReadTag.Enabled = false;
        }

        private void ResetUI()
        {
            gbReadTag.Enabled = true;
            gbWriteTag.Enabled = false;
            tbReadEPC.Text = "";
            tbWriteEPC.Text = "";
            lblNewEPC.Text = "-";
            lblOldEPC.Text = "-";
            lblOperationStatus.Text = "-";
            lblOperationStatus.ForeColor = Color.Black;
            lblReadBackEPC.Text = "-";
            btnOnceMore.Enabled = false;
        }

        private void btnOnceMore_Click(object sender, EventArgs e)
        {
            ResetUI();
        }

        private void btnChangeEPC_Click(object sender, EventArgs e)
        {
            string oldTag = tbReadEPC.Text;
            string newTag = tbWriteEPC.Text;

            if (newTag.Length != 24)
            {
                lblWriteIncorrectSize.Visible = true;
                tbWriteEPC.BackColor = Color.Red;
                tbWriteEPC.ForeColor = Color.White;
                return;
            }
            else
            {
                lblWriteIncorrectSize.Visible = false;
                tbWriteEPC.BackColor = Color.White;
                tbWriteEPC.ForeColor = Color.Black;

            }

            lblOldEPC.Text = oldTag;
            lblNewEPC.Text = newTag;
            bool result = false;

            btnOnceMore.Enabled = true;
            gbWriteTag.Enabled = false;

            try
            {
                RFIDReaderCommon common = new RFIDReaderCommon();
                result = _writer.WriteEPC(oldTag, newTag);
            }
            catch (Exception exception)
            {
                result = false;
                MessageBox.Show("EXCEPTION" + Environment.NewLine + exception.Message + Environment.NewLine + "Inner Exception" + Environment.NewLine + exception.InnerException.Message, "Failure!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                lblOperationStatus.Text = "Failure!";
                lblOperationStatus.ForeColor = Color.Red;
                return;
            }

            var tags = _reader.ReadTags();
            if (tags.Length != 1)
            {
                lblOperationStatus.Text = "Unknown - More than one tag on reader when trying to verify";
                lblOperationStatus.ForeColor = Color.Yellow;
                return;
            }

            lblReadBackEPC.Text = tags[0].Value;
            result = tags[0].Value == newTag;

            if (result)
            {
                lblOperationStatus.Text = "Success";
                lblOperationStatus.ForeColor = Color.ForestGreen;
            }
            else
            {
                lblOperationStatus.Text = "Failure!";
                lblOperationStatus.ForeColor = Color.Red;
            }
        }
    }

}
