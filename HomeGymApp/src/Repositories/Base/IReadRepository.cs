using System.Linq.Expressions;

namespace HomeGymApp.src.Repositories.Base
{
    public interface IReadRepository<T> where T : class
    {
        /// <summary>
        /// Method to retrieve an entity from the repo by it's Id.
        /// </summary>
        /// <param name="id">The id of the entity to retrieve.</param>
        /// <returns>The entity found, or null if doesn't exist.</returns>
        Task<T?> GetByIdAsync(Guid id);

        /// <summary>
        /// Method to get all entities of a type from the repo.
        /// </summary>
        /// <returns>All entities of the specified type.</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Method to find a particular entity.
        /// </summary>
        /// <param name="predicate">The values to search the entity by.</param>
        /// <returns>A list of entities that match the criteria.</returns>
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Method to see if an entity exists in the repo.
        /// </summary>
        /// <param name="id">The Id of the entity to search for.</param>
        /// <returns>True or False, if the entity exists or not.</returns>
        Task<bool> ExistsAsync(Guid id);
    }
}