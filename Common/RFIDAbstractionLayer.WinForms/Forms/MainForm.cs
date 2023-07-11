using System;
using System.Linq;
using System.Windows.Forms;
using RFIDAbstractionLayer.Readers;
using Serilog;
using System.Collections.Generic;
using UIControls.WinForms;
using UIControls;

namespace RFIDAbstractionLayer.WinForms
{
    public partial class MainForm : Form
    {
        private RFIDReaderFactory _rfidReaderFactory;
        private List<IRFIDReader> readers = new List<IRFIDReader>();
        private enum Readers { Auto, Simulation, CAEN, NordicID, Impinj };
        private Dictionary<ReadingResult, ListViewGroup> rfidDictionary = new Dictionary<ReadingResult, ListViewGroup>();
        private List<IRFIDReader> listOfWriters = new List<IRFIDReader>();
        private List<DeviceInformation> devInfoList = new List<DeviceInformation>();

        public MainForm(RFIDReaderFactory rfidReaderFactory, ILogger logger)
        {
            _rfidReaderFactory = rfidReaderFactory;
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            // Populate the combobox with all the enumerator types from ReaderType
            readerTypeBox.Items.Clear();
            foreach (var item in Enum.GetValues(typeof(Readers)))
            {
                readerTypeBox.Items.Add(item);
            }
            readerTypeBox.SelectedIndex = 0;

        }

        private void btnReadTags_Click(object sender, EventArgs e)
        {
            if (readers.Count == 0)
            {
                MessageBox.Show("Please create a reader before use", "No reader loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowLoadingCursor();
            
            var tags = ReadTagsAcrossAllReaders();

            UpdateTagListView(tags);

            ShowDefaultCursor();
        }

        private void readerTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update text on button when the selected item in the combobox is changed.
            btnForceReaderType.Text = "ConnectAll " + readerTypeBox.Text + " reader";
        }

        private void btnForceReaderType_Click(object sender, EventArgs e)
        {
            ShowLoadingCursor();

            UnloadAllReaders();

            var singleReader = CreateReader(readerTypeBox.Text);

            if (singleReader != null)
            {
                readers.Add(singleReader);

                // Load localization Strings - Init PowerBar
                string[] powerLocalizationStrings = System.Enum.GetNames(typeof(PowerLevel));
                PowerTrackBarParams ptbp =
                    new PowerTrackBarParams("Power", powerLocalizationStrings, readers);
                readerPowerBar.InitTrackBar(ptbp);
            }

            UpdateReaderListView();

            ShowDefaultCursor();
        }

        private IRFIDReader CreateReader(string name)
        {
            // "Auto", "Simulation", "CAEN", "NordicID", "Impinj"

            switch ((Readers)Enum.Parse(typeof(Readers), name))
            {
                case Readers.Auto:
                    return _rfidReaderFactory.ConnectAll(new RfIdConfig{ ReaderType = ReaderType.NordicIdOrCAEN}).FirstOrDefault();
                case Readers.CAEN:
                    return _rfidReaderFactory.Create<CAENReader>();
                case Readers.Impinj:
                    return _rfidReaderFactory.Create<ImpinjReader>();
                case Readers.NordicID:
                    return _rfidReaderFactory.Create<NordicIDReader>();
                case Readers.Simulation:
                    return _rfidReaderFactory.Create<SimulationReader>();
                default:
                    return null;
            }
        }

        private void UnloadAllReaders()
        {
            readerListView.Items.Clear();
            tagListView.Items.Clear();

            // if a reader is loaded, terminate it before creating a new
            if (readers.Count > 0)
            {
                foreach (IRFIDReader reader in readers)
                {
                    reader.Disconnect();
                }

                readers.Clear();
            }
        }

        private void ShowLoadingCursor()
        {
            this.Cursor = Cursors.AppStarting;
        }

        private void ShowDefaultCursor()
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Adds an item to the Listview showing DeviceInfo from the RFID reader
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private void AddToDeviceInfoView(string key, string value)
        {
            var item = new ListViewItem(key)
            {
                Text = key
            };
            item.SubItems.Add(value);
            readerListView.Items.Add(item);
        }

        private void AddToTagListView(RFIDTag tag)
        {
            ListViewItem item = new ListViewItem();
            item.SubItems.Add(tag.EPC);
            tagListView.Items.Add(item);
        }

        private string RawTagToString(byte[] tag)
        {
            if (tag.Length == 0)
                return "- EMPTY -";
            string result = "[" + tag[0].ToString() + "]";
            for (int i = 1; i < tag.Length; i++)
            {
                result = result + "-[" + tag[i].ToString() + "]";
            }
            return result;
        }

        private List<ReadingResult> ReadTagsAcrossAllReaders()
        {
            List<ReadingResult> result = new List<ReadingResult>();

            rfidDictionary.Clear();
            devInfoList.Clear();
            tagListView.Groups.Clear();


            if (readers.Count > 0)
            {
                foreach (IRFIDReader reader in readers)
                {
                    var devInfo = reader.GetDeviceInformation();
                    devInfoList.Add(devInfo);

                    string groupCaption = devInfo.Brand + " (Model: " +
                                          devInfo.Model + " [" +
                                          devInfo.Serial + "])";
                    ListViewGroup lvGroup = new ListViewGroup(groupCaption);
                    tagListView.Groups.Add(lvGroup);

                    var ReadTags = reader.ReadTags();

                    foreach (var tag in ReadTags)
                    {
                        result.Add(tag);
                        rfidDictionary.Add(tag, lvGroup);
                    }

                }
            }

            return result;
        }

        private void UpdateTagListView(List<ReadingResult> tags)
        {
            tagListView.BeginUpdate();
            tagListView.Items.Clear();

            foreach (ReadingResult tag in tags)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = tag.Value;


                ListViewGroup group;
                rfidDictionary.TryGetValue(tag, out group);
                if (group != null)
                    lvItem.Group = group;

                tagListView.Items.Add(lvItem);
            }

            if (tags.Count == 0)
            {
                ListViewItem lvItem = new ListViewItem("--- No Tags ---");
                tagListView.Items.Add(lvItem);
            }

            tagListView.EndUpdate();
        }

        private void btnAllReaders_Click(object sender, EventArgs e)
        {
            ShowLoadingCursor();

            UnloadAllReaders();

            try
            {
                readers = _rfidReaderFactory.ConnectAll(new RfIdConfig{AutoRead = true});
                // *** TODO ***
                // Load localization Strings
                string[] powerLocalizationStrings = System.Enum.GetNames(typeof(PowerLevel));
                PowerTrackBarParams ptbp =
                    new PowerTrackBarParams("Power", powerLocalizationStrings, readers);
                readerPowerBar.InitTrackBar(ptbp);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateReaderListView();
            UpdateTagListView(ReadTagsAcrossAllReaders());

            btnOpenWriteDialog.Enabled = true;

            ShowDefaultCursor();
        }

        private void UpdateReaderListView()
        {
            readerListView.BeginUpdate();
            readerListView.Items.Clear();
            readerListView.Groups.Clear();

            string readerCaption = "RFID Reader";
            ListViewGroup readerGroup = new ListViewGroup(readerCaption);
            readerListView.Groups.Add(readerGroup);
            string writerCaption = "RFID Reader/Writer";
            ListViewGroup writerGroup = new ListViewGroup(writerCaption);
            readerListView.Groups.Add(writerGroup);


            foreach (var reader in readers)
            {
                ListViewItem lvItem = new ListViewItem();
                var devInfo = reader.GetDeviceInformation();
                lvItem.Text = devInfo.Brand;
                lvItem.SubItems.Add(devInfo.Model);

                if (reader is IRFIDWriter)
                {
                    lvItem.Group = writerGroup;
                }
                else
                {
                    lvItem.Group = readerGroup;
                }

                readerListView.Items.Add(lvItem);
            }

            readerListView.EndUpdate();
        }

        private void btnOpenWriteDialog_Click(object sender, EventArgs e)
        {
            WriteTagForm dialog = new WriteTagForm();

            IRFIDWriter writer = null;
            foreach (var reader in readers)
            {
                if (reader.IsConnected())
                {
                    if (reader is IRFIDWriter)
                    {
                        writer = reader as IRFIDWriter;
                        break;
                    }
                }
            }

            dialog.Execute(this, writer);
        }

        private void btnImpinjTester_Click(object sender, EventArgs e)
        {
            var form = new ImpinjForm();
            if (!form.Execute())
                return;
        }

    }
    
}
