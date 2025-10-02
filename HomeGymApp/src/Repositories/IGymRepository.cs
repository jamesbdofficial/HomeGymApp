using HomeGymApp.src.Entities;
using HomeGymApp.src.Repositories.Base;

namespace HomeGymApp.src.Repositories
{
    public interface IGymRepository : IReadWriteRepository<Gym>
    {
        /// <summary>
        /// Method to search the Gym Repo to find all gyms a particular owner owns.
        /// </summary>
        /// <param name="ownerId">The Id of the owner to search by</param>
        /// <returns>A collection of gyms owned by a particular owner</returns>
        Task<IEnumerable<Gym>> GetByOwnerIdAsync(Guid ownerId);

        /// <summary>
        /// Method to search the Gym Repo for all gyms in a particular city.
        /// </summary>
        /// <param name="city">The city to search by</param>
        /// <returns>A collection of gyms in a particular city.</returns>
        Task<IEnumerable<Gym>> GetByCityAsync(string city);
    }
}