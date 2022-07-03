using System.Linq.Expressions;

namespace AspNet6.DependencyInjection.Database.Repositories
{
    public interface IRepository<TEntity, TKey>
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where = null, CancellationToken cancellationToken = default);
        Task<TEntity> GetAsync(TKey key, CancellationToken cancellationToken = default);
        Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(TKey key, CancellationToken cancellationToken = default);
    }
}
