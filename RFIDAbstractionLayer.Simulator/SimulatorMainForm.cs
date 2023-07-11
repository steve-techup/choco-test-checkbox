using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RFID.Simulator
{
    public partial class SimulatorMainForm : Form
    {
        private readonly SimulatorServer _server;

        public SimulatorMainForm()
        {
            InitializeComponent();
            _server = new SimulatorServer(new IPAddress(new byte[]{127, 0, 0, 1}), 23513, this);
            _server.Start();
        }

        public void SetConnection(bool connected)
        {
            connectionStatusLabel.Text = connected ? "Connected!" : "Not connected.";
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            _server.Multicast(tagBox.Text);
            tagBox.Text = "";
        }
    }
}
