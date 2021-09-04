using Application.Interfaces.DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class VirtualDeviceRepository : EfRepository<VirtualDevice>, IVirtualDeviceRepository
    {
        public VirtualDeviceRepository(PersistenceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
