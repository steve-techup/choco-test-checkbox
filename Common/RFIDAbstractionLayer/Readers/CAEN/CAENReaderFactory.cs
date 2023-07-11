using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using com.caen.RFIDLibrary;
using Serilog;

namespace RFIDAbstractionLayer.Readers
{
    public class CAENReaderFactory
    {
        private readonly ILogger _logger;
        private readonly IPortCache _portCache;
        private readonly RFIDReaderCommon _readerCommon;

        public CAENReaderFactory(ILogger logger, IPortCache portCache)
        {
            _logger = logger;
            _portCache = portCache;
            _readerCommon = new RFIDReaderCommon();
        }

        private List<Tuple<CAENReader, string>> getReaders(List<string> portsToSearch)
        {
            var readers = new List<Tuple<CAENReader, string>>();
            // Run through all the COM ports in the USBPorts array
            foreach (string testPort in portsToSearch)
            {
                var reader = new CAENReader(testPort, _logger);

                try
                {
                    // Initialise the reader on the testPort
                    reader.Connect();
                    // Attempt to ReadTags
                    reader.ReadTags();

                    readers.Add(new Tuple<CAENReader, string>(reader, testPort));
                }
                catch (CAENRFIDException)
                {
                    // triggered when trying to open a COM port where there isn't a reader.
                    reader.Disconnect();
                }
                catch (Exception e)
                {
                    _logger.Error(e, "Unexpected exception");
                }

            }

            return readers;
        }

        private List<string> getAvailableCOMPorts()
        {
            var portsToSearch = new List<string>();
            #region Windows Management Instrumentation search for available serial ports. Filters out bluetooth devices since they seem to hang up the auto discovery. 
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_PnPEntity WHERE Name like '%COM%'");

            foreach (ManagementObject obj in searcher.Get())
            {
                if (obj["Name"] != null && !obj["Name"].ToString().ToLowerInvariant().Contains("bluetooth") &&
                    obj["DeviceID"] != null)
                {
                    var portNumber = obj["Name"].ToString().Split(new string[] { "COM" }, StringSplitOptions.None);
                    if (portNumber.Length < 2)
                        continue;

                    var name = portNumber[1];
                    var portname = "COM" + new string(name.Where(c => char.IsDigit(c)).ToArray());

                    portsToSearch.Add(portname);
                }

            }
            return portsToSearch;
            #endregion
        }

        public List<CAENReader> GetReaders()
        {
            var portsToSearch = new HashSet<string>();
            if (_portCache == null)
            {
                portsToSearch = new HashSet<string>(getAvailableCOMPorts());
            }
            _portCache.LoadPorts().ForEach(port => portsToSearch.Add(port));
        
            var readers = getReaders(portsToSearch.ToList());
            if (!readers.Any())
            {
                portsToSearch = new HashSet<string>(getAvailableCOMPorts());
                readers = getReaders(portsToSearch.ToList());
            }

            _portCache.SavePorts(readers.Select(r => r.Item2).ToList());
            return readers.Select(r => r.Item1).ToList();
        }
    }
}
