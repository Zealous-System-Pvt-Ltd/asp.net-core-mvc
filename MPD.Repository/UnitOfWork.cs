using System;
using Microsoft.Extensions.Configuration;
using MPD.Repository.Contract;
using MPD.Repository.Repository;

namespace MPD.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        //private readonly MPDContext _dbContext = new MPDContext();
        private readonly MPDContext _dbContext;
        private IAddressRepository _addressReporsitory;

        public UnitOfWork(MPDContext dbContext)
        {
            _dbContext = dbContext;
        }

        /*
         * We can pass connection to the DbContext as below as well
         * In this we can irectly pass the connection reading from appsettings.js as IConfiguration is defualt
         * injected to asp.net core.
         * By, using this method we don't need to give DbContext reference to the UI project and prevent this to expose
         * But at the same time if we are creating context from here won't allow us to exe. unit test with mock data
         * for testability, better to get DbContex objec injected from UI
        public IConfiguration Configuration { get; }

        public UnitOfWork(IConfiguration configuration)
        {
            Configuration = configuration;
            _dbContext = new MPDContext(Configuration.GetConnectionString("DefaultConnection"));
        }
        */

        public IAddressRepository AddressReporsitory => _addressReporsitory = _addressReporsitory ?? new AddressRepository(_dbContext);

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _dbContext.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
