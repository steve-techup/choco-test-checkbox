using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetCoreServer;

namespace RFID.Simulator
{
    public class SimulatorServer : TcpServer
    {
        private readonly SimulatorMainForm _form;
        public SimulatorServer(IPAddress address, int port, SimulatorMainForm form) : base(address, port)
        {
            _form = form;
        }

        protected override TcpSession CreateSession()
        {
            return new SimulatorSession(this, _form);
        }

        protected override void OnError(SocketError error)
        {
            MessageBox.Show("Error in simulator. ");
        }
    }
}
