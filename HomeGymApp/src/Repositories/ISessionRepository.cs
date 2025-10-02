using HomeGymApp.src.Entities;
using HomeGymApp.src.Repositories.Base;

namespace HomeGymApp.src.Repositories
{
    public interface ISessionRepository : IReadWriteRepository<Session>
    {
        /// <summary>
        /// Method to search the Session Repo for all sessions for a particular person.
        /// </summary>
        /// <param name="personId">The Id of the person to search by</param>
        /// <returns>A list of sessions for a particular person</returns>
        Task<IEnumerable<Session>> GetByPersonIdAsync(Guid personId);

        /// <summary>
        /// Method to get the active session for a particular person.
        /// </summary>
        /// <param name="personId">The Id of the person to search by</param>
        /// <returns>The active session for a particular person</returns>
        Task<Session?> GetActiveSessionForPersonAsync(Guid personId);
        
        /// <summary>
        /// Method to get all active sessions.
        /// </summary>
        /// <returns>All currently active sessions.</returns>
        Task<IEnumerable<Session>> GetActiveSessionsAsync();

        /// <summary>
        /// Method to get all sessions in a particular date range.
        /// </summary>
        /// <param name="minDateTime">The earliest date time the session could have started.</param>
        /// <param name="maxDateTime">The latest date time the session could have ended.</param>
        /// <returns></returns>
        Task<IEnumerable<Session>> GetSessionByDateRange(DateTime minDateTime,  DateTime maxDateTime);
    }
}