using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Application.Interfaces.DataAccess
{
    public interface IPersistenceDbContext : ISavingChangesContext
    {
        DatabaseFacade Database { get; }
    }
}
