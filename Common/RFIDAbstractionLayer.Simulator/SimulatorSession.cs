using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NetCoreServer;
using RFIDAbstractionLayer.Simulator.Resources;

namespace RFIDAbstractionLayer.Simulator
{
    public class SimulatorSession : TcpSession
    {
        private readonly MainWindow _window;

        public SimulatorSession(TcpServer server, MainWindow window) : base(server)
        {
            _window = window;
        }

        protected override void OnConnected()
        {
            _window.Dispatcher.Invoke(new Action(delegate
            {
                _window.SetConnection(true);
            }));
            
            SendAsync("OK!");
        }

        protected override void OnDisconnected()
        {
            _window.Dispatcher.Invoke(new Action(delegate
            {
                _window.SetConnection(false);
            }));
        }

        protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            string message = Encoding.UTF8.GetString(buffer, (int)offset, (int)size);
            if (message.Length == 0)
                return;

            if (message.ToLowerInvariant() == "disconnect!")
            {
                Disconnect();
                return;
            }

            var ma = message.Split("=");

            if ((ma.Length > 1) && (ma[0].ToUpperInvariant() == "!POWER"))
            {
                // Power setting incoming
                int powerLevel = Int32.Parse(ma[1]);
                _window.Dispatcher.Invoke(new Action(delegate
                {
                    _window.SetPower(powerLevel);
                }));
            }
        }

        protected override void OnError(SocketError error)
        {
            MessageBox.Show(App.Translate("ErrorInSimulation"));
        }
    }

}
