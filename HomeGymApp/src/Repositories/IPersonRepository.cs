using HomeGymApp.src.Constants;
using HomeGymApp.src.Entities;
using HomeGymApp.src.Repositories.Base;

namespace HomeGymApp.src.Repositories
{
    public interface IPersonRepository : IReadWriteRepository<Person>
    {
        /// <summary>
        /// Method to search the Person Repo by a particular email address.
        /// </summary>
        /// <param name="emailAddress">The email address to search by</param>
        /// <returns>The person with that email address, or null if one doesn't exist.</returns>
        Task<Person?> GetByEmailAsync(string emailAddress);

        /// <summary>
        /// Method to search the Person Repo for all users with a particular UserType.
        /// </summary>
        /// <param name="userType">The UserType to search by.</param>
        /// <returns>All persons with a particular UserType.</returns>
        Task<IEnumerable<Person?>> GetByUserTypeAsync(UserType userType);
    }
}