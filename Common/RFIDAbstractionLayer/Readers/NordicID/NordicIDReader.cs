using System;
using System.Collections.Generic;
using System.Linq;
using Impinj.OctaneSdk;
using NurApiDotNet;
using RFIDAbstractionLayer.Exceptions;
using Serilog;

namespace RFIDAbstractionLayer.Readers
{
    public class NordicIDReader : IRFIDReader, IRFIDWriter
    {
        #region Fields
        private readonly ILogger _logger;
        private readonly uint _killPassword = 0x0U;
        private readonly uint _accessPassword = 0x12345678U;
        private readonly List<EventHandler<NurApi.NurEventArgs>> _connectEventHandlers = new List<EventHandler<NurApi.NurEventArgs>>();
        private readonly List<EventHandler<NurApi.NurEventArgs>> _disconnectEventHandlers = new List<EventHandler<NurApi.NurEventArgs>>();
        private readonly List<EventHandler<NurApi.InventoryStreamEventArgs>> _inventoryEventHandlers = new List<EventHandler<NurApi.InventoryStreamEventArgs>>();
        private PowerLevel _powerLevel;
        private NurApi _physicalReader;
        private NurApi.DeviceCapabilites _devCaps;
        private NurApi.ReaderInfo _physicalReaderInfo;
        private bool _isConnected;
        private RFIDReaderCommon _RFIDCommon = new RFIDReaderCommon();
        private Action<ReadingResult[]> _callBack;
        private string readerOrigin = "No NordicID Reader initialized!";
        #endregion

        #region Constructors/Destructor
        public NordicIDReader(ILogger logger)
        {
            _logger = logger;
        }

        ~NordicIDReader()
        {
            if (_physicalReader != null)
            {
                if (_physicalReader.IsConnected())
                    _physicalReader.Disconnect();
                if (!_physicalReader.Disposed)
                    _physicalReader.Dispose();
            }
        }
        #endregion

        #region IRFIDReader.cs Interface required methods (Sub and Unsub excluded)
        /// <summary>
        /// Returns device information
        /// </summary>
        /// <returns></returns>
        public DeviceInformation GetDeviceInformation()
        {
            try
            {
                var deviceInformation = new DeviceInformation
                {
                    Brand = "NordicID",
                    Model = _physicalReaderInfo.name,
                    Version = _physicalReaderInfo.swVerMajor + "." + _physicalReaderInfo.swVerMinor + " (Hardware: " + _physicalReaderInfo.hwVersion + ")",
                    Serial = _physicalReaderInfo.serial
                };
                readerOrigin = _RFIDCommon.GetReaderOriginName(deviceInformation);
                return deviceInformation;
            }
            catch (Exception e)
            {
                LogError(e, "Error while getting device information");
                return null;
            }
        }
        /// <summary>
        /// Set the power for the reader
        /// </summary>
        /// <param name="powerValue"></param>
        public void SetPower(PowerLevel powerValue)
        {
            _powerLevel = powerValue;
            switch (_powerLevel)
            {
                case PowerLevel.Lowest:
                    _physicalReader.TxLevel = 19;
                    break;
                case PowerLevel.Low:
                    _physicalReader.TxLevel = 14;
                    break;
                case PowerLevel.Medium:
                    _physicalReader.TxLevel = 9;
                    break;
                case PowerLevel.High:
                    _physicalReader.TxLevel = 4;
                    break;
                case PowerLevel.Highest:
                    _physicalReader.TxLevel = 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Get the current power setting for the reader
        /// </summary>
        /// <returns></returns>
        public PowerLevel GetPower()
        {
            return _powerLevel;
        }
        
        public bool Connect()
        {
            if (_isConnected)
                return true;

            try
            {
                _physicalReader = new NurApi(null);
                _physicalReader.SetUsbAutoConnect(true);
                                
                _physicalReaderInfo = new NurApi.ReaderInfo();
                _physicalReaderInfo = _physicalReader.GetReaderInfo();
                GetDeviceCapabilities();
                SetPower(PowerLevel.Medium);
                _isConnected = true;
                _logger?.Debug("Connected NordicID reader");
            }
            catch (Exception e)
            {
                LogError(e, "Error while initializing");
            }
            return _isConnected;
        }
        
        /// <summary>
        /// Used to detect if this reader type is connected to the system
        /// </summary>
        /// <returns></returns>
        public bool IsConnected()
        {
            return _physicalReader.IsConnected();
        }

        /// <summary>
        /// Read the tags currently on the RFID reader
        /// </summary>
        /// <returns></returns>
        public ReadingResult[] ReadTags()
        {
            List<ReadingResult> result = new List<ReadingResult>();
            string readerOrigin = _RFIDCommon.GetReaderOriginName(this);
            
            try
            {
                _physicalReader.ClearTagsEx();

                NurApi.InventoryResponse response = _physicalReader.SimpleInventory();
                NurApi.TagStorage inventory = _physicalReader.FetchTags(true);

                foreach (NurApi.Tag readTag in inventory)
                {
                    // Only include tag is signal is above minimum threshold
                    if (readTag.rssi > -70)
                    {
                        RFIDTag tag = new RFIDTag();
                        
                        tag.EPC = readTag.GetEpcString();

                        result.Add(new ReadingResult(ReadingType.RFID, readTag.GetEpcString(), readTag.rssi, readerOrigin));
                    }
                }
            }
            catch (Exception e)
            {
                LogError( e, "ReadTags()");
            }

            return result.ToArray();
        }
        
        public void Disconnect()
        {
            _physicalReader?.Disconnect();
        }
        #endregion

        #region Subscription based reading
        public void Subscribe(Action<ReadingResult[]> callback)
        {
            if (IsConnected())
                _physicalReader.Disconnect();

            var connectEvent = new EventHandler<NurApi.NurEventArgs>(OnConnectedEvent);
            var disconnectEvent = new EventHandler<NurApi.NurEventArgs>(OnDisconnectedEvent);
            var inventoryEvent = new EventHandler<NurApi.InventoryStreamEventArgs>(OnInventoryStream);

            _physicalReader.ConnectedEvent += connectEvent;
            _physicalReader.DisconnectedEvent += disconnectEvent;
            _physicalReader.InventoryStreamEvent += inventoryEvent;

            _connectEventHandlers.Add(connectEvent);
            _disconnectEventHandlers.Add(disconnectEvent);
            _inventoryEventHandlers.Add(inventoryEvent);

            _callBack = callback;

            _physicalReader.Connect();
        }

        public void UnsubscribeAll()
        {
            _connectEventHandlers.ForEach(connectHandler => _physicalReader.ConnectedEvent -= connectHandler);
            _disconnectEventHandlers.ForEach(disconnectHandler => _physicalReader.DisconnectedEvent -= disconnectHandler);
            _inventoryEventHandlers.ForEach(inventoryHandler => _physicalReader.InventoryStreamEvent -= inventoryHandler);

            _connectEventHandlers.Clear();
            _disconnectEventHandlers.Clear();
            _inventoryEventHandlers.Clear();
        }

        private void OnInventoryStream(object sender, NurApi.InventoryStreamEventArgs e)
        {
            if (_callBack == null)
                return;

            // Get NurApi object that generated the event
            NurApi api = sender as NurApi;

            try
            {

                // Copy tags from NurApi internal tag storage to application tag storage
                NurApi.TagStorage intTagStorage = api.GetTagStorage();
                List<ReadingResult> results = new List<ReadingResult>();
                lock (intTagStorage)
                {
                    for (int i = 0; i < intTagStorage.Count; i++)
                    {
                        var tag = intTagStorage[i];
                        ReadingResult result = new ReadingResult(ReadingType.RFID, _RFIDCommon.RawTagToEPC(tag.epc),
                            tag.rssi, readerOrigin);
                        results.Add(result);
                    }

                    // Clear NurApi internal tag storage
                    api.ClearTags();
                }

                _callBack(results.ToArray());


                if (e.data.stopped)
                {
                    // Start streaming again if stopped
                    api.StartInventoryStream();
                }
            }
            catch (Exception ex)
            {
                // Handle error
                _logger?.Error(ex, "");
            }

        }

        private void OnDisconnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            _physicalReader.Connect();
        }

        private void OnConnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            NurApi nur = sender as NurApi;
            
            _logger?.Information(string.Format("{0} connected", _RFIDCommon.GetReaderOriginName(this)));

            nur.StartInventoryStream();
        }
        #endregion

        #region Support functions
        /// <summary>
        /// Loads DeviceCapabilities from the physical NordicID reader
        /// </summary>
        private void GetDeviceCapabilities()
        {
            try
            {
                _devCaps = _physicalReader.GetDeviceCaps();
                if (_devCaps.txAttnStep == 3)
                {
                    _devCaps.maxTxmW = 500;
                    _devCaps.maxTxdBm = 27;
                    _devCaps.txAttnStep = 1;
                    _devCaps.txSteps = 20;
                    _devCaps.maxAnt = 4;
                    _logger.Warning("NordicID Reader - Firmware may be too old so use the defaults");
                }
            }
            catch (Exception e)
            {
                LogError(e, "GetDeviceCapabilities()");
            }
        }

        private bool IsTagLocked(byte[] EPC)
        {
            byte bank = NurApi.BANK_TID; // EPC
            uint sAddress = 2;
            uint sRange = 6;

            ushort[] result;
            try
            {
                result = _physicalReader.ReadPermalockByEPC(_accessPassword, false, EPC, bank, sAddress, sRange);
            }
            catch (Exception NurApiException)
            {
                return true;
            }
            //
            // Nodes about ReadPermaLockByEPC
            //
            // if locked and not using secured, then it will trigger an unspecified writing error
            //


            if (result.Length == 0)
                // No tag
                return false;

            return (result[0] == (uint)1);
        }

        private void LockTag(byte[] EPC)
        {
            _physicalReader.SetAccessPasswordByEPC(0U, false, EPC, _accessPassword);
            _physicalReader.SetLockByEPC(_accessPassword, EPC, NurApi.LOCK_ACCESSPWD | NurApi.LOCK_EPCMEM, NurApi.LOCK_SECURED);
            _physicalReader.SetKillPasswordByEPC(0U, false, EPC, _killPassword);
        }

        private void LogError(Exception e, string message)
        {
            if (_logger != null)
                _logger.Error(e, message);
        }

        private void UnlockTag(byte[] EPC)
        {
            const bool lockUser = true;
            const bool lockTid = true;
            const bool lockEpc = true;
            const bool lockAccess = true;
            const bool lockKill = false;

            uint memoryMask = 0;
            if (lockUser) memoryMask |= NurApi.LOCK_USERMEM;
            if (lockTid) memoryMask |= NurApi.LOCK_TIDMEM;
            if (lockEpc) memoryMask |= NurApi.LOCK_EPCMEM;
            if (lockAccess) memoryMask |= NurApi.LOCK_ACCESSPWD;
            if (lockKill) memoryMask |= NurApi.LOCK_KILLPWD;

            uint action = 0; // 0 - open, 1 - permanently writeable, 2 - secured, 3 - permanently locked

            //
            // Tries to unlock first with default password, then _accessPassword and then _killPassword
            //
            try
            {
                _physicalReader.SetLockByEPC(0U, EPC, memoryMask, NurApi.LOCK_OPEN);
            }
            catch (Exception e1)
            {
                try
                {
                    _physicalReader.SetLockByEPC(_accessPassword, EPC, memoryMask, NurApi.LOCK_OPEN);
                }
                catch (Exception e2)
                {
                    _physicalReader.SetLockByEPC(_killPassword, EPC, memoryMask, NurApi.LOCK_OPEN);
                }
            }
        }

        public bool WriteEPC(string currentEPC, string newEPC)
        {
            return WriteEPC(0, currentEPC, newEPC);
        }
        
        public bool WriteEPC(uint accessPassword, string currentEPC, string newEPC)
        {
            try
            {
                byte sBank = NurApi.BANK_EPC;
                uint sAddress = 32;
                byte[] rawEpcBuffer = NurApi.HexStringToBin(newEPC);

                var epcBuffer = new byte[12]; //Ensure left padding with 0x0
                var startAt = epcBuffer.Length - rawEpcBuffer.Length;
                Array.Copy(rawEpcBuffer, 0, epcBuffer, startAt, rawEpcBuffer.Length);
                
                byte[] sMask = NurApi.HexStringToBin(currentEPC);
                int sMaskBitLength = (int)sMask.Length * 8;
                
                _physicalReader.WriteEPC(accessPassword, false, NurApi.BANK_EPC, sAddress, sMaskBitLength, sMask, epcBuffer);
            }
            catch (Exception e)
            {
                LogError(e, "WriteEPC Exception!");
                throw new RFIDWriterWriteException("Failed to write RFID tag", e);
            }

            return true;
        }

        public bool WriteEPC(uint accessPassword, byte[] currentEpc, byte[] newEpc)
        {
            try
            {
                byte sBank = NurApi.BANK_EPC;
                uint sAddress = 32;
                byte[] rawEpcBuffer = newEpc.ToArray(); 

                var epcBuffer = new byte[12]; //Ensure left padding with 0x0
                var startAt = epcBuffer.Length - rawEpcBuffer.Length;
                Array.Copy(rawEpcBuffer, 0, epcBuffer, startAt, rawEpcBuffer.Length);

                byte[] sMask = currentEpc.ToArray();
                int sMaskBitLength = sMask.Length * 8;

                _physicalReader.WriteEPC(accessPassword, false, NurApi.BANK_EPC, sAddress, sMaskBitLength, sMask, epcBuffer);
            }
            catch (Exception e)
            {
                LogError(e, "WriteEPC Exception!");
                throw new RFIDWriterWriteException("Failed to write RFID tag", e);
            }

            return true;
        }

        public bool WriteEPC(uint accessPassword, string currentEpc, byte[] newEpc)
        {
            return WriteEPC(accessPassword, NurApi.HexStringToBin(currentEpc), newEpc);
        }

        #endregion
    }
}
