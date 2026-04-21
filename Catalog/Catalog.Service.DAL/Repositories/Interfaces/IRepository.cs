using System.Linq.Expressions;

namespace Catalog.Service.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
        Task UpdateAsync(T entity, CancellationToken cancellationToken);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
