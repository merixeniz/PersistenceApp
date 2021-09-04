using Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.DataAccess
{
    public interface IUnitOfWork
    {
        IAsyncRepository<T> Repository<T>() where T : BaseEntity, IAggregateRoot;
        T CustomRepository<T>() where T : ICustomRepository;
        Task<int> SaveAsync();
    }
}
