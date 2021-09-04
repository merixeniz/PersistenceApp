using Application.Interfaces.DataAccess;
using Entities.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PersistenceDbContext _db;
        private readonly IServiceProvider _serviceProvider;

        public UnitOfWork(PersistenceDbContext db, IServiceProvider serviceProvider)
        {
            _db = db;
            _serviceProvider = serviceProvider;
        }

        public IAsyncRepository<T> Repository<T>() where T : BaseEntity, IAggregateRoot
        {
            return _serviceProvider.GetRequiredService<IAsyncRepository<T>>();
        }

        public T CustomRepository<T>() where T : ICustomRepository
        {
            return _serviceProvider.GetRequiredService<T>();
        }

        public async Task<int> SaveAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
