using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caretag_Class;
using Caretag_Class.Model;
using Caretag_Class.Repositories;
using Main.Model.PackingList;

namespace PackingStation.Repositories
{
    public class PackingStationUnitOfWork : UnitOfWork
    {
        public GenericRepository<Tray_RFID> TrayRfidRepository { get; set; }
        public GenericRepository<Instrument_RFID> InstrumentRfidRepository { get; set; }
        public GenericRepository<Container_RFID> ContainerRfidRepository { get; set; }
        public GenericRepository<Tray_Description> TrayDescriptionRepository { get; set; }
        public GenericRepository<Instrument_Description> InstrumentDescriptionRepository { get; set; }
        public TrayImageRepository TrayImageRepository { get; set; }
        public InstrumentImageRepository InstrumentImageRepository { get; set; }
        public PackingListRepository PackingListRepository { get; set; }
        public GenericRepository<Cost_Center> CostCenterRepository { get; set; }
        public GenericRepository<Cost_Log> CostLogRepository { get; set; }
        public GenericRepository<PackingLog> PackingLogRepository { get; set; }

        public PackingStationUnitOfWork(CaretagModelFactory dbContextFactory) : base(dbContextFactory)
        {
            TrayDescriptionRepository = new GenericRepository<Tray_Description>(DbContext);
            InstrumentDescriptionRepository = new GenericRepository<Instrument_Description>(DbContext);
            TrayRfidRepository = new GenericRepository<Tray_RFID>(DbContext);
            InstrumentRfidRepository = new GenericRepository<Instrument_RFID>(DbContext);
            ContainerRfidRepository = new GenericRepository<Container_RFID>(DbContext);
            PackingListRepository = new PackingListRepository(DbContext);
            TrayImageRepository = new TrayImageRepository(DbContext);
            InstrumentImageRepository = new InstrumentImageRepository(DbContext);
            CostCenterRepository = new GenericRepository<Cost_Center>(DbContext);
            PackingLogRepository = new GenericRepository<PackingLog>(DbContext);
            CostLogRepository = new GenericRepository<Cost_Log>(DbContext);
        }
    }
}
