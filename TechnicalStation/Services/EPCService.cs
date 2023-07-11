using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Caretag_Class.EventReporting;
using Caretag_Class.Model;
using RFIDAbstractionLayer;
using RFIDAbstractionLayer.Exceptions;
using RFIDAbstractionLayer.Readers;
using RFIDAbstractionLayer.TagEncoding;
using Z.EntityFramework.Plus;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using Caretag_Class.Configuration;
using Microsoft.Extensions.Logging;

namespace TechnicalStation.Services
{
    public class EPCService
    {
        private readonly RFIDReaderCollection _rfidReader;
        private readonly ILogger<EPCService> _logger;
        private readonly uint _gs1CompanyPrefix;
        private readonly uint _tenantId;
        private readonly AppSettingsBase _appSettingsBase;
        private readonly IDataRepository _dataRepository;
        public uint Gs1CompanyPrefix
        {
            get { return _gs1CompanyPrefix; }
        }
        public uint TenantId
        {
            get { return _tenantId; }
        }

        public EPCService(AppSettingsBase appSettings, IDataRepository dataRepository, RFIDReaderCollection readerCollection, ILogger<EPCService> logger)
        {
            _appSettingsBase = appSettings;
            _rfidReader = readerCollection;
            _logger = logger;
            _dataRepository = dataRepository;
            var globalEPCInfo = Task.Run(() => _dataRepository.GetEpcNumberSerie()).Result;
            _gs1CompanyPrefix = uint.Parse(globalEPCInfo.Owner_Serie);
            _tenantId = uint.Parse(globalEPCInfo.Customer_Number);
        }

        public EPCService(IDataRepository dataRepository, ILogger<EPCService> logger)
        {
            _logger = logger;
            _dataRepository = dataRepository;
            var globalEPCInfo = Task.Run(() => _dataRepository.GetEpcNumberSerie()).Result;
            _gs1CompanyPrefix = uint.Parse(globalEPCInfo.Owner_Serie);
            _tenantId = uint.Parse(globalEPCInfo.Customer_Number);
        }


        public async Task<Tuple<bool, string>> ResetTag(string accessPassword, Action<string> report, long assetId, string lot, DateTime? productionDate)
        {
            var epc = await _dataRepository.GenereateNewEpc(assetId, lot, productionDate);

            if (_appSettingsBase.RFID.ReaderType != ReaderType.Simulator)
                return ProgramTag(accessPassword, epc, report);
            else
                return new Tuple<bool, string>(true, epc.ToString());
        }

        public Tuple<bool, string> ProgramTag(string accessPassword, RfidEPC epc, Action<string> report)
        {
            // Method requires an RFIDWriter, verify one is connected
            var writers = _rfidReader.GetRFIDWriters();

            if (writers.Count == 0)
            {
                report("No RFID writer found. Please connect a reader, please restart application and try again.");
                return new Tuple<bool, string>(false, null);
            }

            if (writers.Count > 2)
            {
                string Str = "More than one RFID Writer is currently attached to the system!" +
                             Environment.NewLine + "Found:" + Environment.NewLine;
                foreach (IRFIDWriter rfidWriter in writers)
                {
                    IRFIDReader rfidReader = rfidWriter as IRFIDReader;
                    var devInfo = rfidReader.GetDeviceInformation();
                    Str = Str + String.Format("Brand: {0} (Model: {1})", devInfo.Brand, devInfo.Model);
                }

                MessageBox.Show(Str, "More than one writer connected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Tuple<bool, string>(false, null);
            }

            IRFIDWriter writer = writers.First();
            IRFIDReader reader = writer as IRFIDReader;
            ReadingResult[] tags = reader.ReadTags();

            if (tags.Length == 0)
            {
                report("No tag found. Please put asset back and try again.");
                return new Tuple<bool, string>(false, null);
            }
            if (tags.Length > 1)
            {
                report("More than one tag found. Please remove other assets and try again.");
                return new Tuple<bool, string>(false, null);
            }

            ReadingResult tag = tags.First();
            try
            {
                if (!writer.WriteEPC(Convert.ToUInt32(accessPassword, 16), tag.Value, epc.GetBinaryRepresentation()))
                {
                    throw new RFIDWriterWriteException("RFID Writer returned false when calling Writer.WriteEPC",
                        null);
                }

            }
            catch (Exception e)
            {
                return new Tuple<bool, string>(false, null);

            }


            return new Tuple<bool, string>(true, epc.ToString());
        }

        public async Task<bool> MatchesGS1Prefix(string epc)
        {
            return await _dataRepository.IsEpcValid(epc, _gs1CompanyPrefix);
        }
    }
}