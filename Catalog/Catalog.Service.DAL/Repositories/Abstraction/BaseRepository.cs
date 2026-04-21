using Catalog.Service.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Catalog.Service.DAL.Repositories.Abstraction
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly CatalogContext CatalogContext;

        protected BaseRepository(CatalogContext catalogContext)
        {
            CatalogContext = catalogContext;
        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await CatalogContext.GetDbSet<T>().FirstAsync(predicate, cancellationToken).ConfigureAwait(false);
        }

        public virtual async Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await CatalogContext.GetDbSet<T>().AsNoTracking().Where(predicate).ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public virtual async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            await CatalogContext.GetDbSet<T>().AddAsync(entity, cancellationToken).ConfigureAwait(false);
        }

        public virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            var ent = await CatalogContext.GetDbSet<T>().FindAsync(entity, cancellationToken).ConfigureAwait(false);
            if (ent == null) return;

            CatalogContext.GetDbSet<T>().Entry(ent).CurrentValues.SetValues(entity);
        }

        public virtual async Task DeleteAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            var enteties = await CatalogContext.GetDbSet<T>().Where(expression).ToListAsync(cancellationToken).ConfigureAwait(false);
            if (enteties.Count == 0) return;

            CatalogContext.GetDbSet<T>().RemoveRange(enteties);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            if (!CatalogContext.ChangeTracker.HasChanges()) return 0;

            return await CatalogContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
