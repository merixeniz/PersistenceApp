using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.DataAccess
{
    public interface ISavingChangesContext
    {
        int SaveChanges();

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        EntityEntry Remove([NotNull] object entity);

        EntityEntry<TEntity> Remove<TEntity>([NotNull] TEntity entity) where TEntity : class;

        void RemoveRange([NotNull] IEnumerable<object> entities);

        void RemoveRange([NotNull] params object[] entities);

        EntityEntry Update([NotNull] object entity);

        EntityEntry<TEntity> Update<TEntity>([NotNull] TEntity entity) where TEntity : class;
    }
}
