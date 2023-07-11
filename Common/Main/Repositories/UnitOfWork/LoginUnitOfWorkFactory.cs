using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caretag_Class;

namespace Main.Repositories.UnitOfWork
{
    public class LoginUnitOfWorkFactory
    {
        private readonly CaretagModelFactory _dbContextFactory;

        public LoginUnitOfWorkFactory(CaretagModelFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public LoginUnitOfWork Create()
        {
            return new LoginUnitOfWork(_dbContextFactory);
        }
    }
}
