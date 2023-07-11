using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RFIDAbstractionLayer;
using RFIDAbstractionLayer.Readers;

namespace UIControls.WinForms.Controls
{
    /// <summary>
    /// UI Control to handle power management of RFID reader. InitTrackBar() must be called before use.
    /// </summary>
    public partial class ReaderPowerBar : UserControl
    {
        private string[] _localizationStrings;
        private List<IRFIDReader> _readers;
        private string _locPower;

        public ReaderPowerBar()
        {
            InitializeComponent();
        }

        public void InitTrackBar(PowerTrackBarParams powerTrackBarParams)
        {
            _locPower = powerTrackBarParams.PowerTitle;
            _localizationStrings = powerTrackBarParams.PowerStepNames;
            _readers = powerTrackBarParams.ActiveReaders;
            _tbPower.Value = 2;
        }

        private void UpdateRFIDPower(int newPower)
        {
            PowerLevel pl = (PowerLevel)newPower;
            foreach (var reader in _readers)
            {
                reader.SetPower(pl);
            }
        }

        private void UpdateUI(int powerValue)
        {
            gbPower.Text = String.Format(" {0} - {1} ", _locPower, _localizationStrings[powerValue]);
        }

        private void _tbPower_ValueChanged(object sender, EventArgs e)
        {
            int newPower = _tbPower.Value;
            UpdateUI(newPower);
            UpdateRFIDPower(newPower);
        }
    }
}
