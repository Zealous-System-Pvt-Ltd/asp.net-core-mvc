using MPD.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPD.Repository.Repository
{
    public class AddressRepository : RepositoryBase<Entities.Domain.Address>, IAddressRepository
    {
        public AddressRepository(MPDContext dbContext) : base(dbContext)
        {
        }
    }
}
