using System.Collections.Generic;
using System.Linq;
using RFIDAbstractionLayer.Exceptions;
using Serilog;

namespace RFIDAbstractionLayer.Readers
{
    public class RFIDReaderFactory
    {
        private CAENReaderFactory _caenReaderFactory;
        private readonly ILogger _logger;

        public RFIDReaderFactory(CAENReaderFactory caenReaderFactory, ILogger logger)
        {
            _caenReaderFactory = caenReaderFactory;
            _logger = logger;
        }

        public List<IRFIDReader> ConnectAll(RfIdConfig config)
        {
            var readers = new List<IRFIDReader>();

            switch (config.ReaderType)
            {
                case ReaderType.Simulator:
                    var reader = new SimulationReader();
                    if (reader.Connect())
                        readers.Add(reader);
                    return readers;
                case ReaderType.NordicIdOrCAEN:
                    readers.AddRange(_caenReaderFactory.GetReaders());
                    var nordicIdReader = new NordicIDReader(_logger);
                    if (nordicIdReader.Connect())
                        readers.Add(nordicIdReader);
                    return readers;
                case ReaderType.Impinj:
                    var impinjReader = new ImpinjReader(config.ReaderIpAddress, _logger);
                    if (impinjReader.Connect() || impinjReader.IsConnected())
                    {
                        readers.Add(impinjReader);
                    }
                    return readers;
            }

            return readers;
        }

        public ImpinjReader Create(string ipAddress)
        {
            var reader = new ImpinjReader(ipAddress, _logger);
            return reader.Connect() ? reader : null;
        }

        public IRFIDReader Create<T>() where T : IRFIDReader
        {
            IRFIDReader reader = null;
            if (typeof(T) == typeof(SimulationReader))
                reader = new SimulationReader();
            else if (typeof(T) == typeof(NordicIDReader))
                reader = new NordicIDReader(_logger);
            else if (typeof(T) == typeof(ImpinjReader))
                throw new UnsupportedRfidOperationException(
                    "Cannot create Impinj reader with this overload, since it requires an IP address. ");
            else if (typeof(T) == typeof(CAENReader))
                return _caenReaderFactory.GetReaders().FirstOrDefault();
            
            if (reader == null)
                return null;
            return reader.Connect() ? reader : null;
        }
    }
}
