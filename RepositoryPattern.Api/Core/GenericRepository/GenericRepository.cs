using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Api.Data;

namespace RepositoryPattern.Api.Core.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApiDbContext context;
        internal DbSet<T> _dbSet;
        protected readonly ILogger _logger;
        public GenericRepository(ApiDbContext context, ILogger logger)
        {
            this.context = context;
            this._dbSet = context.Set<T>();
            _logger = logger;
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<T> InsertAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return await Task.FromResult(entity);
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return await Task.FromResult(entity);
        }

        public virtual async Task<T> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return await Task.FromResult(entity);
        }
    }
}
