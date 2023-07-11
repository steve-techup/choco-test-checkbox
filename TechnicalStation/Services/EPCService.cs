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
using Serilog;

namespace TechnicalStation.Services
{
    public class EPCService
    {
        private readonly CaretagModel _model;
        private readonly RFIDReaderCollection _rfidReader;
        private readonly ILogger _logger;
        private readonly uint _gs1CompanyPrefix;
        private readonly uint _tenantId;

        public EPCService(CaretagModel model, RFIDReaderCollection readerCollection, ILogger logger)
        {
            _model = model;
            _rfidReader = readerCollection;
            _logger = logger;
            var globalEPCInfo = _model.EPC_Number_Serie.First();
            _gs1CompanyPrefix = uint.Parse(globalEPCInfo.Owner_Serie);
            _tenantId = uint.Parse(globalEPCInfo.Customer_Number);
        }

        public EPCService(CaretagModel model, ILogger logger)
        {
            _model = model;
            _logger = logger;
            var globalEPCInfo = _model.EPC_Number_Serie.First();
            _gs1CompanyPrefix = uint.Parse(globalEPCInfo.Owner_Serie);
            _tenantId = uint.Parse(globalEPCInfo.Customer_Number);
        }

        public Tuple<bool, string> ResetTag(string accessPassword, Action<string> report)
        {
            var epc = new RfidEPC("DEADBEEF");
            return ProgramTag(accessPassword, epc, report);
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


        public virtual Instrument_RFID GetInstrumentRfidByEpc(string epc)
        {
            return _model.Instrument_RFID
                .Include(i => i.InstrumentDescription)
                .FirstOrDefault(i => i.EPC_Nr == epc);
        }

        public virtual Tray_RFID GetTrayRfidByEpc(string epc)
        {
            return _model.Tray_RFID
                .FirstOrDefault(trayRfid => trayRfid.EPC_Nr == epc);
        }

        public virtual Container_RFID GetContainerRfidByEpc(string epc)
        {
            return _model.Container_RFID.FirstOrDefault(containerRfid => containerRfid.EPC_Nr == epc);
        }

        public bool MatchesGS1Prefix(string epc)
        {
            var rfidEpc = new RfidEPC(epc);

            return rfidEpc.Gs1CompanyPrefix == _gs1CompanyPrefix && rfidEpc.ValidCaretagEPC;
        }

        public void CommitEpc(RfidEPC epc)
        {
            var transaction = _model.Database.BeginTransaction();
            var uncommittedAssetId = _model.AssetId.FirstOrDefault(u =>
                u.Id == (long)epc.AssetId);

            if (uncommittedAssetId == null)
            {
                //Nothing to commit
                transaction.Rollback();
                return;
            }
            
            uncommittedAssetId.WrittenToTag = true;

            _model.SaveChanges();
            transaction.Commit();
        }

        public virtual AssetId GetHighestUncommittedAssetId()
        {
            return _model.AssetId
                .OrderByDescending(u => u.Id)
                .FirstOrDefault();
        }

        public RfidEPC CreateNewUncommittedEpc()
        {
            var transaction = _model.Database.BeginTransaction(IsolationLevel.Serializable);
            try
            {
                //begin transaction
                //Take an exclusive mutex ensuring that only one thread can access the database at a time
                _model.Database.ExecuteSqlCommand($"exec sp_getapplock 'CreateNewUncommittedEpc', 'exclusive'");
                
                //get highest UncommittedAssetId from database
                var uncommittedAssetId = GetHighestUncommittedAssetId();
                int id = uncommittedAssetId == null ? 1 : (int)uncommittedAssetId.Id + 1;
                var codedEPC = new RfidEPC((ulong)id, _gs1CompanyPrefix, _tenantId);

                //generate EPC codes until there are no collosions with instrument_rfid, tray_rfid tables
                while (GetInstrumentRfidByEpc(codedEPC.ToString()) != null ||
                       GetTrayRfidByEpc(codedEPC.ToString()) != null ||
                       GetContainerRfidByEpc(codedEPC.ToString()) != null)
                {
                    _logger.Debug($"Collision detected with EPC={codedEPC}, generating new EPC");
                    id++;
                    codedEPC = new RfidEPC((ulong)id, _gs1CompanyPrefix, _tenantId); 
                }
                
                var assetId = new AssetId
                {
                    Id = id,
                    Timestamp = DateTime.Now,
                    EPC = codedEPC.ToString(),
                    WrittenToTag = false
                };

                _model.AssetId.Add(assetId);
                _logger.Debug($"Saving new uncommitted assetId={assetId.Id} with EPC={codedEPC} on thread {Thread.CurrentThread.ManagedThreadId}");
                _model.SaveChanges();
                transaction.Commit();
                return codedEPC;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw;
            }
            
        }

        public void CreateNewTray(string epc)
        {
            var trayRfid = new Tray_RFID
            {
                EPC_Nr = epc,
                Date_Changed = DateTime.Now,
                Description_ID = 1,
                Description_Text = "Created with new Technical Station"
            };
            _model.Tray_RFID.Add(trayRfid);
            _model.SaveChanges();
        }

        public void CreateNewContainer(string epc)
        {
            var containerRfid = new Container_RFID
            {
                EPC_Nr = epc,
                Container_Changed = DateTime.Now,
                Description_ID = 1,
                Special_Text = "Created with new Technical Station",
                Container_LastSeen_Date = DateTime.Now,
                Container_InUse = true,
                Container_Contents = 0,
                SEQ_Nr = "",
                Container_LastSeen_Place = "Technical Station"

            };
            _model.Container_RFID.Add(containerRfid);
            _model.SaveChanges();
        }

        public IQueryable<Instrument_Description> SearchInstrumentType(string query)
        {
            return _model.Instrument_Description.Where(i =>
                i.D.StartsWith(query) || i.E.StartsWith(query) || i.Description_Name.StartsWith(query) ||
                i.Description_ID.StartsWith(query));

        }
        private Instrument_RFID_Life CreateInstrumentLife(string epc, Instrument_Description instrumentDescription)
        {
            var now = DateTime.Now;
            return new Instrument_RFID_Life()
            {
                Date_Birth = now,
                DaysInService = 0,
                Description_ID = instrumentDescription.Description_ID,
                EPC_Nr = epc,
                Last_Change = now,
                Passed_Steri = 0,
                Sent_To_Service = false,
                Wash_Counter = 0,
                Used_In_OR = 0,
                Demand_Log = 0,
                Demand_Service_Number = 0,
                Number_Service = 0
            };
        }

        public void UpdateInstrument(Instrument_RFID instrumentRfid, Instrument_Description instrumentDescription)
        {
            instrumentRfid.Description_ID = instrumentDescription.Description_ID;
            instrumentRfid.Description_Text = instrumentDescription.GetFullDescription();
            instrumentRfid.InstrumentDescription = instrumentDescription;
            instrumentRfid.Instrument_InUse = true;

            if (!_model.Instrument_RFID_Life.Any(life => life.EPC_Nr == instrumentRfid.EPC_Nr))
                _model.Instrument_RFID_Life.Add(CreateInstrumentLife(instrumentRfid.EPC_Nr, instrumentDescription));
            
            _model.SaveChanges();
        }


        public void CreateNewInstrument(string epc, string lot, DateTime productionDate, Instrument_Description instrumentDescription)
        {

            var instrument = new Instrument_RFID
            {
                EPC_Nr = epc,
                Description_ID = instrumentDescription.Description_ID,
                InstrumentDescription = instrumentDescription,
                Description_Text = instrumentDescription.GetFullDescription(),
                Instrument_InUse = true,
                InstrumentProductionDate = productionDate,
                LotNumber= lot,
            };

            _model.Instrument_RFID_Life.Add(CreateInstrumentLife(epc, instrumentDescription));
            _model.Instrument_RFID.Add(instrument);
            _model.SaveChanges();
        }
    }
}
