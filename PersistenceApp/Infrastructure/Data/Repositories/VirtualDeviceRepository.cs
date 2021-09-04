using Application.Interfaces.DataAccess;
using Entities;

namespace Infrastructure.Data.Repositories
{
    public class VirtualDeviceRepository : EfRepository<VirtualDevice>, IVirtualDeviceRepository
    {
        public VirtualDeviceRepository(PersistenceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
