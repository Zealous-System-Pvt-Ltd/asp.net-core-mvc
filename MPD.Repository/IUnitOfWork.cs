using MPD.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPD.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IAddressRepository AddressReporsitory { get; }
        void Save();

    }
}
