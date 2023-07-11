using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caretag_Class;

namespace PackingStation.Repositories
{
    public class PackingStationUnitOfWorkFactory
    {
        private readonly CaretagModelFactory _dbContextFactory;

        public PackingStationUnitOfWorkFactory(CaretagModelFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public PackingStationUnitOfWork Create()
        {
            return new PackingStationUnitOfWork(_dbContextFactory);
        }
    }
}
