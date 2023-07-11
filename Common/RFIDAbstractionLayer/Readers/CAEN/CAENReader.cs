using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using com.caen.RFIDLibrary;
using NurApiDotNet;
using Serilog;

namespace RFIDAbstractionLayer.Readers
{
    public class CAENReader : IRFIDReader, IRFIDWriter
    {

        #region Fields
        protected CAENRFIDReader PhysicalReader;
        protected CAENRFIDLogicalSource PhysicalReaderSource;
        protected RFIDReaderCommon RFIDCommon = new();
        private readonly List<CAENRFIDEventHandler> _eventHandlers = new List<CAENRFIDEventHandler>();
        private readonly ILogger _logger;
        private readonly string _comPort;
        private bool _connected;
        private PowerLevel _powerLevel;

        #endregion

        #region Constructors
        public CAENReader(string comPort, ILogger logger)
        {
            _comPort = comPort;
            _logger = logger;
        }
        #endregion

        #region IRFIDReader.cs interface required functions
        /// <summary>
        /// Returns device information
        /// </summary>
        /// <returns></returns>
        public DeviceInformation GetDeviceInformation()
        {
            try
            {
                var result = new DeviceInformation
                {
                    Brand = "CAEN"
                };

                // Attempt to load all values from the Reader
                var info = PhysicalReader.GetReaderInfo();
                result.Model = info.GetModel();
                result.Serial = info.GetSerialNumber();
                result.Version = PhysicalReader.GetFirmwareRelease();
                return result;
            }
            catch (Exception e)
            {
                LogError(e, "Error getting device information");
            }

            return null;
        }

        /// <summary>
        /// Get the current power setting for the reader
        /// </summary>
        /// <returns></returns>
        public PowerLevel GetPower()
        {
            return _powerLevel;
        }

        /// <summary>
        /// Use this method to run any initialisation code the reader might need
        /// </summary>
        public bool Connect()
        {
            if (_connected)
                return true;

            string address = _comPort + ":115200:n:8:1";
            PhysicalReader = new CAENRFIDReader();
            PhysicalReader.Connect(CAENRFIDPort.CAENRFID_RS232, address);
            PhysicalReader.SetProtocol(CAENRFIDProtocol.CAENRFID_EPC_C1G2);

            PhysicalReaderSource = PhysicalReader.GetSource("Source_0");
            SetPower(PowerLevel.Medium);
            _connected = true;
            _logger?.Debug("Connected CAEN reader on port: {port}", _comPort);
            return _connected;
        }

        public bool IsConnected()
        {
            // return the result of FindReader, which will return true if a CAEN reader is connected to the system
            return _connected;
        }

        /// <summary>
        /// Read the tags currently on the RFID reader
        /// </summary>
        /// <returns></returns>
        public ReadingResult[] ReadTags()
        {
            List<ReadingResult> result = new List<ReadingResult>();
            string readerOrigin = RFIDCommon.GetReaderOriginName(this);
            try
            {
                // Read the tags from the reader
                var list = PhysicalReaderSource.InventoryTag();
                if (list == null)
                    return Array.Empty<ReadingResult>();

                foreach (var item in list)
                {
                    result.Add(new ReadingResult(ReadingType.RFID, RFIDCommon.RawTagToEPC(item.GetId().ToArray()), item.GetRSSI(), readerOrigin));
                }

            }
            catch (CAENRFIDException)
            {
                // Every now and again the CAEN reader will throw a
                // CAENRFIDException("RFID Error: RFID Error: RFID Error: Invalid parameter")
                // catching here to avoid bubbling up
            }
            catch (Exception e)
            {
                LogError(e, "Error reading tag");
            }

            // return result list
            return result.ToArray();
        }

        /// <summary>
        /// Set the power for the reader
        /// </summary>
        /// <param name="powerValue"></param>
        public void SetPower(PowerLevel powerValue)
        {
            try
            {
                var evtHandlers = _eventHandlers.ToArray();
                UnsubscribeAll();

                // Set the power level
                PhysicalReader.SetPower(powerValue switch
                {
                    PowerLevel.Lowest => 11,
                    PowerLevel.Low => 22,
                    PowerLevel.Medium => 33,
                    PowerLevel.High => 44,
                    PowerLevel.Highest => 55,
                    _ => throw new ArgumentOutOfRangeException()
                });
                _powerLevel = powerValue;
                foreach (var caenrfidEventHandler in evtHandlers)
                {
                    PhysicalReaderSource.SetSelected_EPC_C1G2(CAENRFIDLogicalSourceConstants.EPC_C1G2_ALL_SELECTED);
                    PhysicalReaderSource.EventInventoryTag(Array.Empty<byte>(), 0, 0, 0x06);
                    PhysicalReader.CAENRFIDEvent += caenrfidEventHandler;
                    _eventHandlers.Add(caenrfidEventHandler);
                }
            }
            catch (Exception e)
            {
                LogError(e, "Error setting power");
            }
        }

        /// <summary>
        /// Run when to disconnect reader
        /// </summary>
        public void Disconnect()
        {
            PhysicalReader?.Disconnect();
        }

        public void Subscribe(Action<ReadingResult[]> callback)
        {
            string readerOrigin = RFIDCommon.GetReaderOriginName(this);
            PhysicalReaderSource.SetReadCycle(0);
            
            var eventHandler = new CAENRFIDEventHandler((sender, evt) =>
            {
                callback(evt.Data.Select(data =>

                    new ReadingResult()
                    {
                        Value = RFIDCommon.RawTagToEPC(data.getTagID()),
                        ReadingType = ReadingType.RFID,
                        SignalStrength = data.RSSI,
                        OriginatingReader = readerOrigin
                    }).ToArray());
            });
            _eventHandlers.Add(eventHandler);

            PhysicalReaderSource.SetSelected_EPC_C1G2(CAENRFIDLogicalSourceConstants.EPC_C1G2_ALL_SELECTED);
            PhysicalReaderSource.EventInventoryTag(Array.Empty<byte>(), 0, 0, 0x06);
            PhysicalReader.CAENRFIDEvent += eventHandler;
        }

        public void UnsubscribeAll()
        {
            if (_eventHandlers.Any())
                PhysicalReader.InventoryAbort();
            _eventHandlers.ForEach(eventhandler => PhysicalReader.CAENRFIDEvent -= eventhandler);
            _eventHandlers.Clear();
            
        }

        #endregion

        private void LogError(Exception e, string message)
        {
            if (_logger != null)
                _logger.Error(e, message);
        }
        
        public bool WriteEPC(uint accessPassword, string currentEPC, string newEPC)
        {
            return WriteEPC(0, NurApi.HexStringToBin(currentEPC), NurApi.HexStringToBin(newEPC));
        }

        public bool WriteEPC(string currentEPC, string newEPC)
        {
            return WriteEPC(0, currentEPC, newEPC);
        }

        public bool WriteEPC(uint accessPassword, byte[] currentEpc, byte[] newEpc)
        {
            try
            {
                // Here CAEN uses bitwise indexing and read the existing tag
                var tag = PhysicalReaderSource.InventoryTag(NurApi.BANK_EPC, currentEpc, (short)(currentEpc.Length * 8), 0x20);

                if (tag == null || tag.Length != 1)
                    return false;

                // Here CAEN uses byte indexing
                if (accessPassword == 0)
                    PhysicalReaderSource.WriteTagData_EPC_C1G2(tag.First(), NurApi.BANK_EPC, 4, (short)newEpc.Length, newEpc);
                else
                    PhysicalReaderSource.WriteTagData_EPC_C1G2(tag.First(), NurApi.BANK_EPC, 4, (short)newEpc.Length, newEpc, (int)accessPassword);

                return true;
            }
            catch (Exception ex)
            {
                _logger.Debug(ex, "Error writing tag with CAEN reader. ");
                return false;
            }
        
        }

        public bool WriteEPC(uint accessPassword, string currentEpc, byte[] newEpc)
        {
            return WriteEPC(0, NurApi.HexStringToBin(currentEpc), newEpc);
        }
    }
}
