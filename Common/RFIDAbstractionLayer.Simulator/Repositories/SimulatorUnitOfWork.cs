using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caretag_Class;
using Caretag_Class.Model;
using Caretag_Class.Repositories;
using Polly;

namespace RFIDAbstractionLayer.Simulator.Repositories
{
    public class SimulatorUnitOfWork : UnitOfWork
    {
        private GenericRepository<Container_RFID> _containerRepository;
        private GenericRepository<Tray_RFID> _trayRepository;
        private GenericRepository<Instrument_RFID>_instrumentRepository;

        public GenericRepository<Container_RFID> ContainerRepository
        {
            get
            {
                _containerRepository ??= new GenericRepository<Container_RFID>(DbContext);
                return _containerRepository;
            }
        }

        public GenericRepository<Tray_RFID> TrayRepository
        {
            get
            {
                _trayRepository ??= new GenericRepository<Tray_RFID>(DbContext);
                return _trayRepository;
            }
        }
        public GenericRepository<Instrument_RFID> InstrumentRepository
        {
            get
            {
                _instrumentRepository ??= new GenericRepository<Instrument_RFID>(DbContext);
                return _instrumentRepository;
            }
        }

        public SimulatorUnitOfWork(CaretagModelFactory dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}
