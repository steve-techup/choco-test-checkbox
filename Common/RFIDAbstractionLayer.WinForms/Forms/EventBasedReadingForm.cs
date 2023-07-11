using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.VisualEffects;
using RFIDAbstractionLayer.Readers;
using Serilog;
using UIControls;
using UIControls.WinForms;

namespace RFIDAbstractionLayer.WinForms
{
    public partial class EventBasedReadingForm : Form
    {
        private List<IRFIDReader> readers = new List<IRFIDReader>();
        private RFIDReaderCommon RFIDCommon = new RFIDReaderCommon();
        private ReadingResult[] tags;
        private int tempCount = 0;

        private delegate void SafeUpdate(ReadingResult[] readingResults);

        public EventBasedReadingForm()
        {
            InitializeComponent();
        }

        private void cbReaders_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnLoadReader.Enabled = cbReaders.SelectedIndex > -1;
        }

        private void btnLoadReader_Click(object sender, EventArgs e)
        {
            switch (cbReaders.SelectedIndex)
            {
                case 0:
                    LoadCAEN();
                    break;
                case 1:
                    // Impinj
                    throw new NotImplementedException();
                    break;
                case 2:
                    LoadNordicID();
                    break;
                case 3:
                    LoadSimulation();
                    break;
                default:
                    break;
            }
            if (readers is null || readers.Count == 0)
                return;

            BindPowerBar();
        }

        private void LoadSimulation()
        {
            Cursor = Cursors.AppStarting;

            var sim = new SimulationReader();
            sim.Connect();
            if (!sim.IsConnected())
            {
                MessageBox.Show("Could not connect to Simulation Program", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Cursor = Cursors.Default;
                return;
            }
        
            readers.Add(sim);

            UpdateUI();

            btnUnload.Enabled = true;
            gbSubscription.Enabled = true;

            Cursor = Cursors.Default;
        }

        private void LoadCAEN()
        {
            Cursor = Cursors.AppStarting;
            var ports = new PortCacheAllAvailableComPorts();
            CAENReaderFactory caenFac = new CAENReaderFactory(null, ports);
            RFIDReaderFactory factory = new RFIDReaderFactory(caenFac, null);
            var caen = factory.Create<CAENReader>();
            readers.Add(caen);
            
            UpdateUI();
            
            btnUnload.Enabled = true;
            gbSubscription.Enabled = true;

            Cursor = Cursors.Default;
        }

        private void LoadNordicID()
        {
            // *** TODO ***
            // Check this method works if it is switched from
            // var nordic = new NordicIDReader(null)
            // to
            // var nordic = factory.Create<NordicIDReader>();

            Cursor = Cursors.AppStarting;
            var nordic = new NordicIDReader(null);
            nordic.Connect();
            if (nordic.IsConnected())
                readers.Add(nordic);

            nordic.Subscribe(OnReaderEvent);
            UpdateUI();
            btnUnload.Enabled = true;
            gbSubscription.Enabled = true;

            Cursor = Cursors.Default;
        }

        private void UpdateUI()
        {
            listBoxReaders.BeginUpdate();
            listViewReadings.BeginUpdate();

            listBoxReaders.Items.Clear();
            foreach (var reader in readers)
            {
                listBoxReaders.Items.Add(RFIDCommon.GetReaderOriginName(reader));
            }

            listViewReadings.Items.Clear();
            if (tags != null)
            {
                foreach (var tag in tags)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = tag.ReadingType.ToString();
                    item.SubItems.Add(tag.Value);
                    item.SubItems.Add(string.Format("{0} dB", tag.SignalStrength));
                    item.SubItems.Add(tag.OriginatingReader);
                    listViewReadings.Items.Add(item);
                }
            }

            this.Text = tempCount.ToString();

            listBoxReaders.EndUpdate();
            listViewReadings.EndUpdate();
        }

        private void BindPowerBar()
        {
            if ((readers is null) || (readers.Count == 0))
            {
                powerBar.Enabled = false;
                return;
            }

            string[] powerLocalizationStrings = System.Enum.GetNames(typeof(PowerLevel));
            PowerTrackBarParams ptbp =
                new PowerTrackBarParams("Power", powerLocalizationStrings, readers);
            powerBar.InitTrackBar(ptbp);

            powerBar.Enabled = true;

        }
        private void OnReaderEvent(ReadingResult[] readingResults)
        {
            tempCount += 1;
            ThreadSafeOnReading(readingResults);
        }

        private void ThreadSafeOnReading(ReadingResult[] readingResults)
        {

            if (listViewReadings.InvokeRequired)
            {
                var d = new SafeUpdate(ThreadSafeOnReading);
                listViewReadings.Invoke(d, new object[] {readingResults});
            }
            else
            {
                tags = readingResults;
                UpdateUI();
            }
        }

        private void btnUnload_Click_1(object sender, EventArgs e)
        {
            foreach (var reader in readers)
            {
                reader.Disconnect();
            }
            readers.Clear();
            tags = Array.Empty<ReadingResult>();

            gbSubscription.Enabled = false;

            UpdateUI();
        }

        private void btnSubscribe_Click(object sender, EventArgs e)
        {
            foreach (var reader in readers)
            {
                reader.Subscribe(OnReaderEvent);
            }

            btnUnsubscribe.Enabled = true;
            btnSubscribe.Enabled = false;
        }

        private void btnUnsubscribe_Click(object sender, EventArgs e)
        {
            foreach (var reader in readers)
            {
                reader.UnsubscribeAll();
            }

            btnUnsubscribe.Enabled = false;
            btnSubscribe.Enabled = true;
        }
    }
}
