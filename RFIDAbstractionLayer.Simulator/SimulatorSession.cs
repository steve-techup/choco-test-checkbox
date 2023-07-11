using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetCoreServer;

namespace RFID.Simulator
{
    public class SimulatorSession : TcpSession
    {
        private readonly SimulatorMainForm _form;

        public SimulatorSession(TcpServer server, SimulatorMainForm form) : base(server)
        {
            _form = form;
        }

        protected override void OnConnected()
        {
            _form.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                _form.SetConnection(true);
                });
            
            SendAsync("OK!");
        }

        protected override void OnDisconnected()
        {
            _form.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                _form.SetConnection(false);
            });

        }

        protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            string message = Encoding.UTF8.GetString(buffer, (int)offset, (int)size);
            
            // If the buffer starts with '!' then disconnect the current session
            if (message.ToLowerInvariant() == "disconnect!")
                Disconnect();
        }

        protected override void OnError(SocketError error)
        {
            MessageBox.Show("Error in simulator session. ");
        }
    }

}
