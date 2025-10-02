using Microsoft.EntityFrameworkCore;

namespace HomeGymApp.src.Repositories.Base
{
    public abstract class ReadWriteRepository<T> : ReadRepository<T>, IReadWriteRepository<T> where T : class
    {
        protected ReadWriteRepository(DbContext context) : base(context)
        {
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return entity;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            dbSet.Update(entity);
            await Task.CompletedTask;
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
            }
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}