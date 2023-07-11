using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace RFIDAbstractionLayer.Readers
{

    public class SimulationReader : IRFIDReader, IRFIDWriter
    {
        #region Fields
        protected string _brand = "Caretag";
        protected string _model = "RFID Simulation Window";
        protected string _version = "1.01";
        protected string _serial = "0000000000";
        protected PowerLevel _power = PowerLevel.Medium;
        private List<Action<ReadingResult[]>> _callbacks = new();
        private TcpClient _client;
        private RFIDReaderCommon _RFIDReaderCommon = new();
        private Timer _timer;

        #endregion

        #region IRFIDReader.cs Interface required methods
        /// <summary>
        /// Returns device information
        /// </summary>
        /// <returns></returns>
        public DeviceInformation GetDeviceInformation()
        {
            var result = new DeviceInformation
            {
                Brand = _brand,
                Model = _model,
                Version = _version,
                Serial = _serial
            };

            return result;
        }

        public SimulationReader()
        {
            _timer = new Timer();
            _timer.Interval = 500;

            _timer.Tick += TimerOnTick;
        }

        PowerLevel IRFIDReader.GetPower()
        {
            return _power;
        }

        public void SetPower(PowerLevel powerValue)
        {
            _power = powerValue;

            string s = "!power=" + (int)powerValue;
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            _client.Client.Send(bytes);
        }

        public bool IsConnected()
        {
            if (_client == null)
                return false;

            return _client.Connected;
        }

        public void Disconnect()
        {
            _client.Close();
        }

        public void Subscribe(Action<ReadingResult[]> callback)
        {
            lock (this)
            {
                if (!_timer.Enabled)
                    _timer.Start();

                _callbacks.Add(callback);
            }
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            lock (this)
            {
                var tags = ReadTags();
                if (tags.Length == 0)
                    return;
                _callbacks.ForEach(callback => callback(tags));
            }            
        }

        public void UnsubscribeAll()
        {
            lock (this)
            {
                _timer.Stop();
                _callbacks.Clear();
            }
        }

        /// <summary>
        /// Use this method to run any initialisation code the reader might need
        /// </summary>
        public bool Connect()
        {
            try
            {
                _client = new TcpClient("127.0.0.1", 23513);

                var ns = _client.GetStream();
                byte[] bytes = new byte[1024];

                int bytesRead = ns.Read(bytes, 0, bytes.Length);

                var message = Encoding.ASCII.GetString(bytes, 0, bytesRead);

                if (message != "OK!")
                    return false;
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Read the tags currently on the RFID reader
        /// </summary>
        /// <returns></returns>
        public ReadingResult[] ReadTags()
        {
            var ns = _client.GetStream();
            if (!ns.DataAvailable)
                return Array.Empty<ReadingResult>();

            // Will these lines empty the full buffer if larger than 1024 bytes?
            byte[] bytes = new byte[1024];
            int bytesRead = ns.Read(bytes, 0, bytes.Length);

            var message = Encoding.ASCII.GetString(bytes, 0, bytesRead);

            return StreamStringToTags(message);
        }

        private ReadingResult[] StreamStringToTags(string message)
        {
            List<ReadingResult> result = new List<ReadingResult>();
            string originReader = _RFIDReaderCommon.GetReaderOriginName(this);

            string[] tags = message.Split('|');

            foreach (string tag in tags)
            {
                result.Add(ReadingResult.MakeRFIDSimReading(tag, originReader));
            }

            return result.ToArray();
        }

        private RFIDTag EPCStringToTag(string epcString)
        {
            RFIDTag result = new RFIDTag();

            result.EPC = epcString;

            return result;
        }
        
        #endregion
        
        public bool WriteEPC(uint accessPassword, string currentEPC, string newEPC)
        {
            return true;
        }

        public bool WriteEPC(string currentEPC, string newEPC)
        {
            return true;
        }

        public bool WriteEPC(uint accessPassword, byte[] currentEpc, byte[] newEpc)
        {
            return true;

        }

        public bool WriteEPC(uint accessPassword, string currentEpc, byte[] newEpc)
        {
            return true;
        }
    }
}
