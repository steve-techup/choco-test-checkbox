using Caretag_Class.Model;
using RFIDAbstractionLayer.TagEncoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using System.Threading;
using Caretag.Contracts.Api.v1;
using DevExpress.CodeParser;
using TechnicalStation.Infrastructure;
using System.Diagnostics.Metrics;
using LanguageExt;
using Microsoft.Extensions.Logging;
using Caretag.Contracts.Enums;
using Caretag_Class.Configuration;
using RFIDAbstractionLayer;
using TechnicalStation.Configuration;
using DevExpress.LookAndFeel.Design;

namespace TechnicalStation.Services
{
    public class ClassicWrapper : IDataRepository
    {
        private readonly CaretagModel _model;
        private readonly ILogger<ClassicWrapper> _logger;
        private readonly AppSettingsBase _appSettingsBase;
        private readonly TechnicalStationAppSettings _technicalStationAppSettings;

        public ClassicWrapper(
            CaretagModel model, 
            ILogger<ClassicWrapper> logger, 
            AppSettingsBase appSettings,
            TechnicalStationAppSettings technicalStationAppSettings)
        {
            _model = model;
            _logger = logger;
            _appSettingsBase = appSettings;
            _technicalStationAppSettings = technicalStationAppSettings;
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
        public async Task CommitEpc(RfidEPC epc)
        {
            var transaction = _model.Database.BeginTransaction();
            var uncommittedAssetId = await _model.AssetId.FirstOrDefaultAsync(u => u.Id == (long)epc.AssetId);

            if (uncommittedAssetId == null)
            {
                //Nothing to commit
                transaction.Rollback();
                return;
            }

            uncommittedAssetId.WrittenToTag = true;

            await _model.SaveChangesAsync();
            transaction.Commit();
        }

        public async Task CreateNewContainer(string epc, int? assetTagId = null, string lot = null, DateTime? productionDate = null, Instrument_Description instrumentDescription = null)
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
            await _model.SaveChangesAsync();
        }

        public async Task CreateNewInstrument(string epc, string lot, DateTime productionDate, Instrument_Description instrumentDescription, int? assetTagId = null)
        {
            var instrument = new Instrument_RFID
            {
                EPC_Nr = epc,
                Description_ID = instrumentDescription.Description_ID,
                InstrumentDescription = instrumentDescription,
                Description_Text = instrumentDescription.GetFullDescription(),
                Instrument_InUse = true,
                InstrumentProductionDate = productionDate,
                LotNumber = lot,
            };

            _model.Instrument_RFID_Life.Add(CreateInstrumentLife(epc, instrumentDescription));
            _model.Instrument_RFID.Add(instrument);
            await _model.SaveChangesAsync();
        }

        public async Task CreateNewTray(string epc, int? assetTagId = null, string lot = null, DateTime? productionDate = null, Instrument_Description instrumentDescription = null)
        {
            var trayRfid = new Tray_RFID
            {
                EPC_Nr = epc,
                Date_Changed = DateTime.Now,
                Description_ID = 1,
                Description_Text = "Created with new Technical Station"
            };
            _model.Tray_RFID.Add(trayRfid);
            await _model.SaveChangesAsync();
        }

        public async Task<RfidEPC> CreateNewUncommittedEpc(uint gs1CompanyPrefix, uint tenantId)
        {
            var transaction = _model.Database.BeginTransaction(IsolationLevel.Serializable);
            try
            {
                //begin transaction
                //Take an exclusive mutex ensuring that only one thread can access the database at a time
                _model.Database.ExecuteSqlCommand($"exec sp_getapplock 'CreateNewUncommittedEpc', 'exclusive'");

                //get highest UncommittedAssetId from database
                var uncommittedAssetId = await GetHighestUncommittedAssetId();
                int id = uncommittedAssetId == null ? 1 : (int)uncommittedAssetId.Id + 1;
                var codedEPC = new RfidEPC((ulong)id, gs1CompanyPrefix, tenantId);

                //generate EPC codes until there are no collosions with instrument_rfid, tray_rfid tables
                while ((await GetInstrumentRfidByEpc(codedEPC.ToString())).Item1 != null ||
                       (await GetTrayRfidByEpc(codedEPC.ToString())).Item1 != null ||
                       (await GetContainerRfidByEpc(codedEPC.ToString())).Item1 != null)
                {
                    _logger.LogDebug($"Collision detected with EPC={codedEPC}, generating new EPC");
                    id++;
                    codedEPC = new RfidEPC((ulong)id, gs1CompanyPrefix, tenantId);
                }

                var assetId = new AssetId
                {
                    Id = id,
                    Timestamp = DateTime.Now,
                    EPC = codedEPC.ToString(),
                    WrittenToTag = false
                };

                _model.AssetId.Add(assetId);
                _logger.LogDebug($"Saving new uncommitted assetId={assetId.Id} with EPC={codedEPC} on thread {Thread.CurrentThread.ManagedThreadId}");
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

        public async Task<Tuple<Container_RFID, AssetDetailsItem>> GetContainerRfidByEpc(string epc)
        {
            var container = await _model.Container_RFID.FirstOrDefaultAsync(containerRfid => containerRfid.EPC_Nr == epc);
            if (container != null)
            {
                var description = await _model.Container_Description.FirstOrDefaultAsync(cd => cd.Description_ID == container.Description_ID);
                var details = new AssetDetailsItem
                {
                    Id = container.Container_ID,
                    Epc = epc,
                    Type = "Container",
                    Name = description != null ? description.Container_Name : container.Special_Text,
                    Description = description != null ? description.Container_Description1 : string.Empty,
                    Status = "Active"
                };

                return new Tuple<Container_RFID, AssetDetailsItem>(container, details);
            }
            return new Tuple<Container_RFID, AssetDetailsItem>(null, null);
        }

        public async Task<AssetId> GetHighestUncommittedAssetId()
        => await _model.AssetId.OrderByDescending(u => u.Id).FirstOrDefaultAsync();

        public async Task<Tuple<Instrument_RFID, AssetDetailsItem>> GetInstrumentRfidByEpc(string epc)
        {
            var instrument = await _model.Instrument_RFID.Include(i => i.InstrumentDescription).FirstOrDefaultAsync(i => i.EPC_Nr == epc);

            if (instrument != null)
            {
                var details = new AssetDetailsItem
                {
                    Id = instrument.Instrument_ID,
                    Epc = epc,
                    Type = "Instrument",
                    Name = instrument.Description_Text,
                    Description = string.Empty,
                    Sku = instrument.Description_ID,
                    Manufacturer = instrument.InstrumentDescription?.Instrument_Company,
                    LotNumber = instrument.LotNumber,
                    ManufacturingDate = instrument.InstrumentProductionDate,
                    Status = "Active"
                };

                return new Tuple<Instrument_RFID, AssetDetailsItem>(instrument, details);
            }
            return new Tuple<Instrument_RFID, AssetDetailsItem>(null, null);
        }

        public async Task<Tuple<Tray_RFID, AssetDetailsItem>> GetTrayRfidByEpc(string epc)
        {
            var tray = await _model.Tray_RFID.Include(t => t.TrayDescription).FirstOrDefaultAsync(trayRfid => trayRfid.EPC_Nr == epc);


            if (tray != null)
            {
                var details = new AssetDetailsItem
                {
                    Id = tray.Tray_ID,
                    Epc = epc,
                    Type = "Tray",
                    Name = tray.TrayDescription?.Tray_Name,
                    Description = tray.Description_Text,
                    Status = "Active"
                };

                return new Tuple<Tray_RFID, AssetDetailsItem>(tray, details);
            }
            return new Tuple<Tray_RFID, AssetDetailsItem>(null, null);
        }


        public async Task<IReadOnlyCollection<Instrument_Description>> SearchInstrumentType(string query, AssetClassType[] classTypes = null)
        {
            var types = _model.Instrument_Description.Where(i =>
                 i.D.StartsWith(query) || i.E.StartsWith(query) || i.Description_Name.StartsWith(query) ||
                 i.Description_ID.StartsWith(query)).ToList();

            foreach (var type in types)
            {
                type.E = type.Description_ID;
            }
            return types;
        }

        public async Task UpdateInstrument(Instrument_RFID instrumentRfid, Instrument_Description instrumentDescription, string lot = null, DateTime? productionDate = null)
        {
            instrumentRfid.Description_ID = instrumentDescription.Description_ID;
            instrumentRfid.Description_Text = instrumentDescription.GetFullDescription();
            instrumentRfid.InstrumentDescription = instrumentDescription;
            instrumentRfid.Instrument_InUse = true;

            if (!_model.Instrument_RFID_Life.Any(life => life.EPC_Nr == instrumentRfid.EPC_Nr))
                _model.Instrument_RFID_Life.Add(CreateInstrumentLife(instrumentRfid.EPC_Nr, instrumentDescription));

            await _model.SaveChangesAsync();
        }

        public async Task<EPC_Number_Serie> GetEpcNumberSerie()
        => await _model.EPC_Number_Serie.FirstAsync();

        public async Task<RfidEPC> GenereateNewEpc(long assetId, string lot, DateTime? productionDate)
        => new RfidEPC("DEADBEEF");

        public async Task<bool> IsEpcValid(string epc, uint gs1CompanyPrefix)
        {
            var rfidEpc = new RfidEPC(epc);

            return new RfidEPC(epc).Gs1CompanyPrefix == gs1CompanyPrefix && rfidEpc.ValidCaretagEPC;
        }

        public async Task<Tuple<bool, int?>> GetAssetTag(string tagId)
        {
            return new Tuple<bool, int?>(true, null);
        }
        public async Task<Tuple<Instrument_RFID, AssetDetailsItem>> GetTrolleyRfidByEpc(string epc) => null;
        public async Task CreateNewTrolley(string epc, int? assetTagId = null, string lot = null, DateTime? productionDate = null, Instrument_Description instrumentDescription = null) { }

        public async Task<Tuple<Tray_RFID, AssetDetailsItem>> GetSterilizationCartRfidByEpc(string epc) => null;
        public async Task CreateNewSterilizationCart(string epc, int? assetTagId = null, string lot = null, DateTime? productionDate = null, Instrument_Description instrumentDescription = null) { }
        public async Task<TechnicalStationConfig> GetStationConfig()
        {
            return new TechnicalStationConfig
            {
                StationName = _appSettingsBase.StationUniqueID,
                RFID = _appSettingsBase.RFID,
                AppSettings = _technicalStationAppSettings
            };
        }
    }
}