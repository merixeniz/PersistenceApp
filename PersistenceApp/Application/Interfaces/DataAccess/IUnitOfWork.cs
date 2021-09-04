using Entities.Base;
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
