using HomeGymApp.src.Data;
using HomeGymApp.src.Entities;
using HomeGymApp.src.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace HomeGymApp.src.Repositories
{
    public class GymRepository : ReadWriteRepository<Gym>, IGymRepository
    {
        public GymRepository(HomeGymDbContext context) : base(context) 
        {

        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Gym>> GetByOwnerIdAsync(Guid ownerId)
        {
            return await dbSet
                .Where(x => x.OwnerId == ownerId)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Gym>> GetByCityAsync(string city)
        {
            return await dbSet
                .Where(x => x.City == city)
                .ToListAsync();
        }
    }
}