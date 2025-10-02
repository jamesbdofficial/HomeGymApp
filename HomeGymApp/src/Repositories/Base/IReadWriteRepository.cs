namespace HomeGymApp.src.Repositories.Base
{
    public interface IReadWriteRepository<T> : IReadRepository<T> where T : class
    {
        /// <summary>
        /// Method to add an entity to the repo.
        /// </summary>
        /// <param name="entity">The entity to add to the repository</param>
        /// <returns>The async operation task.</returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Method to update an entity in the repo.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>The async operation task.</returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Method to delete an entity in the repo.
        /// </summary>
        /// <param name="id">The Id of the entity to delete.</param>
        /// <returns>The async operation task.</returns>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Method to save changes.
        /// </summary>
        /// <returns>The async operation task.</returns>
        Task<int> SaveChangesAsync();
    }
}