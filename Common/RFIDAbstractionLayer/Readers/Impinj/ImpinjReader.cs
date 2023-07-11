using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Impinj.OctaneSdk;
using RFIDAbstractionLayer.Exceptions;
using Serilog;

namespace RFIDAbstractionLayer.Readers
{
    public class ImpinjReader : IRFIDReader
    {
        private readonly string _ipAddress;
        private readonly ILogger _logger;
        private PowerLevel _powerLevel;

        #region Fields
        protected RFIDReaderCommon RfidCommon = new();
        private Impinj.OctaneSdk.ImpinjReader _physicalReader;
        private Impinj.OctaneSdk.Settings _readerSettings;
        #endregion

        public ImpinjReader(string ipAddress, ILogger logger)
        {
            _ipAddress = ipAddress;
            _logger = logger;

            _physicalReader = new Impinj.OctaneSdk.ImpinjReader();
            Connect();

            var defaultSettings = _physicalReader.QueryDefaultSettings();
            _readerSettings = defaultSettings;
        }

        public DeviceInformation GetDeviceInformation()
        {
            var featureSet = _physicalReader.QueryFeatureSet();
            var result =  new DeviceInformation
            {
                Brand = "Impinj",
                Model = featureSet.ModelName,
                Serial = featureSet.SerialNumber,
                Version = featureSet.FirmwareVersion
            };

            return result;
        }

        public PowerLevel GetPower()
        {
            return _powerLevel;
        }
        
        public ReadingResult[] ReadTags()
        {
            throw new UnsupportedRfidOperationException("Synchronous reading is not supported for Impinj readers. ");
        }

        public bool Connect()
        {
            try
            {
                _physicalReader.Connect(_ipAddress);
                var settings = _physicalReader.QueryDefaultSettings();
                // Tell the reader to include the antenna number in all tag reports. Other fields can be added to the reports in the same way by setting the appropriate Report.IncludeXXXXXXX property.
                
                settings.Report.IncludeAntennaPortNumber = true;
                settings.Report.IncludeFirstSeenTime = true;
                settings.Report.IncludeLastSeenTime = true;
                settings.Report.IncludeSeenCount = true;

                // The reader can be set into various modes in which reader dynamics are optimized for specific regions and environments.
                // The following mode, AutoSetDenseReader, monitors RF noise and interference and then automatically and continuously optimizes the reader’s configuration
                settings.RfMode = 1002;

                
                // ************************     *************************************
                settings.SearchMode = SearchMode.ReaderSelected;
                settings.Session = 2;
                // *****************************************************************
                
                settings.TagPopulationEstimate = 60;
                settings.Antennas.DisableAll();
                for (ushort i = 1; i < 5; i++)
                {
                    settings.Antennas.GetAntenna(i).IsEnabled = true;
                    settings.Antennas.GetAntenna(i).MaxTxPower = true;
                    settings.Antennas.GetAntenna(i).MaxRxSensitivity = true;
                }
                
                settings.TxFrequenciesInMhz.Clear();
                settings.TxFrequenciesInMhz.Add(865.7);
                settings.TxFrequenciesInMhz.Add(866.3);
                settings.TxFrequenciesInMhz.Add(866.9);
                settings.TxFrequenciesInMhz.Add(867.5);
                
                _physicalReader.ApplySettings(settings);
                _logger.Verbose("Impinj reader settings {@settings}", settings);
            }
            catch(Exception ex)
            {
                _logger.Error(ex, "Connection to Impinj reader failed. ");
                return false;
            }
            return _physicalReader.IsConnected;
        }

        public bool IsConnected()
        {
            return _physicalReader.IsConnected;
        }

        public void Disconnect()
        {
            _physicalReader.Disconnect();
        }

        private readonly List<Impinj.OctaneSdk.ImpinjReader.TagsReportedHandler> _eventHandlers = new();
        public void Subscribe(Action<ReadingResult[]> callback)
        {
            int index = 0;
            ConcurrentDictionary<string, string> _elements = new ConcurrentDictionary<string, string>();
            if (_physicalReader.QueryStatus().IsSingulating)
                _physicalReader.Stop();
            _physicalReader.Start();
            string originReader = RfidCommon.GetReaderOriginName(this);
            Impinj.OctaneSdk.ImpinjReader.TagsReportedHandler eventHandler =
                (reader, report) =>
                {
                    _elements.TryAdd(report.Tags.FirstOrDefault().Epc.ToString(), string.Empty);
                    index++;
                    if (index > 100)
                    {
                        index = 0;
                        callback(
                    _elements.Select(tag =>
                    new ReadingResult() { Value = tag.Key.Replace(" ", ""), ReadingType = ReadingType.RFID, SignalStrength = 1, OriginatingReader = originReader }).ToArray()
                );
                        _elements.Clear();
                    }
                };
            _physicalReader.TagsReported += eventHandler;
            _eventHandlers.Add(eventHandler);
        }

        public void UnsubscribeAll()
        {
            _physicalReader.Stop();
            _eventHandlers.ForEach(eventHandler => _physicalReader.TagsReported -= eventHandler);
        }

        public void SetPower(PowerLevel powerValue)
        {
            if (powerValue == null)
                throw new ArgumentOutOfRangeException();

            // *** TODO ***
        }
        
        
    }
}
