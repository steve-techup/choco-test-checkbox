using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caretag_Class;
using Caretag_Class.Model;
using Caretag_Class.Repositories;

namespace Main.Repositories
{
    public class LoginUnitOfWork : Caretag_Class.Repositories.UnitOfWork
    {
        private CaretagModel _dbContext;
        public GenericRepository<TblPassword> UserRepository { get; set; }
        public LoginUnitOfWork(CaretagModelFactory dbContextFactory) : base(dbContextFactory)
        {
            _dbContext = dbContextFactory.Create();
            UserRepository = new GenericRepository<TblPassword>(_dbContext);
        }
    }
}
