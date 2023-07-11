using Caretag_Class.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caretag_Class.Repositories
{
    public class UnitOfWork : IDisposable
    {
        public CaretagModel DbContext { get; }

        public UnitOfWork(CaretagModelFactory dbContextFactory)
        {
            DbContext = dbContextFactory.Create();
        }


        public void Save()
        {
            DbContext.SaveChanges();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
