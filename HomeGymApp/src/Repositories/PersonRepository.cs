using HomeGymApp.src.Constants;
using HomeGymApp.src.Data;
using HomeGymApp.src.Entities;
using HomeGymApp.src.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace HomeGymApp.src.Repositories
{
    public class PersonRepository : ReadWriteRepository<Person>, IPersonRepository
    {
        public PersonRepository(HomeGymDbContext dbContext) : base(dbContext)
        {
        }

        /// <inheritdoc/>
        public async Task<Person?> GetByEmailAsync(string emailAddress)
        {
            return await dbSet
                .FirstOrDefaultAsync(x => x.EmailAddress == emailAddress);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Person?>> GetByUserTypeAsync(UserType userType)
        {
            return await dbSet
                .Where(x => x.UserType == userType)
                .ToListAsync();
        }
    }
}