using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HomeGymApp.src.Repositories.Base
{
    public abstract class ReadRepository<T> : IReadRepository<T> where T : class
    {
        protected readonly DbContext dbContext;
        protected readonly DbSet<T> dbSet;

        protected ReadRepository(DbContext Context)
        {
            dbContext = Context;
            dbSet = Context.Set<T>();
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }


        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<bool> ExistsAsync(Guid id)
        {
            return await dbSet.FindAsync(id) != null;
        }
    }
}