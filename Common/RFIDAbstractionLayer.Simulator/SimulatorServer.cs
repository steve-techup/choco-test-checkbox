using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using NetCoreServer;
using System.Windows;
using RFIDAbstractionLayer.Simulator.Resources;

namespace RFIDAbstractionLayer.Simulator
{
    public class SimulatorServer : TcpServer
    {
        private readonly MainWindow _window;
        public SimulatorServer(IPAddress address, int port, MainWindow window) : base(address, port)
        {
            _window = window;
        }

        protected override TcpSession CreateSession()
        {
            return new SimulatorSession(this, _window);
        }

        protected override void OnError(SocketError error)
        {
            MessageBox.Show(App.Translate("ErrorInSimulation"));
        }
    }
}
