using HomeGymApp.src.Entities;

namespace HomeGymApp.src.Services
{
    public interface IGymService
    {
        /// <summary>
        /// Creates a new Gym in the system.
        /// </summary>
        /// <returns>The newly created gym.</returns>
        Task<Gym> Create();

        /// <summary>
        /// Deletes a pre-existing Gym.
        /// </summary>
        /// <param name="gymId">The Id of the gym to delete.</param>
        void Delete(Guid gymId);

        void Update(Guid gymId, Equipment equipment);
    }
}