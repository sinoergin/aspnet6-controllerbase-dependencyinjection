using System.Linq.Expressions;

namespace AspNet6.DependencyInjection.Database.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        public Repository(DbContext context)
        {
            this.Context = context;
        }

        public DbContext Context { get; set; }
        public DbSet<TEntity> Set => Context.Set<TEntity>();

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where = null, CancellationToken cancellationToken = default)
        {
            if (where is null)
                return await Set.ToListAsync(cancellationToken);
            return await Set.Where(where).ToListAsync(cancellationToken);
        }

        public async Task<TEntity> GetAsync(TKey key, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(nameof(key));
            return await Set.FindAsync(new object[] { key }, cancellationToken);
        }

        public async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            Set.Add(entity);
            await Context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            if (entity is null)
                return false;
            Set.Update(entity);
            await Context.SaveChangesAsync(cancellationToken);
            return true;
        }
        public async Task<bool> DeleteAsync(TKey key, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(key);
            var entity = await GetAsync(key, cancellationToken);
            if (entity is null)
                return false;
            Set.Remove(entity);
            await Context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
