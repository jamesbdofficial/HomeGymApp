using HomeGymApp.src.Data;
using HomeGymApp.src.Entities;
using HomeGymApp.src.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HomeGymApp.src.Repositories
{
    public class SessionRepository : ReadWriteRepository<Session>, ISessionRepository
    {
        public SessionRepository(HomeGymDbContext context) : base(context) 
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Session>> GetByPersonIdAsync(Guid personId)
        {
            return await dbSet
                .Include(x => x.Person)
                .Include(x => x.ExercisePerformances)
                .Where(x => x.Person.Id == personId)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Session?> GetActiveSessionForPersonAsync(Guid personId)
        {
            return await dbSet
                .Include(x => x.Person)
                .Include(x => x.ExercisePerformances)
                .FirstOrDefaultAsync(x => x.Person.Id == personId && x.TimeLeft == null);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Session>> GetActiveSessionsAsync()
        {
            return await dbSet
                .Include(x => x.Person)
                .Where(x => x.TimeLeft == null)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Session>> GetSessionByDateRange(DateTime minDateTime, DateTime maxDateTime)
        {
            return await dbSet
                .Include(x => x.Person)
                .Where(x => x.TimeEntered >= minDateTime && x.TimeLeft <= maxDateTime)
                .OrderBy(x => x.TimeEntered)
                .ToListAsync();
        }
    }
}
