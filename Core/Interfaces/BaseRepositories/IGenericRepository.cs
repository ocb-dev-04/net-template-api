using Core.Entities;

namespace Core.Interfaces
{
    /// <summary>
    /// <see cref="IGenericRepository"/> interface
    /// </summary>
    /// <typeparam name="Entity"></typeparam>
    /// <typeparam name="DTO"></typeparam>
    public interface IGenericRepository<Entity>
        where Entity : BaseEntity
    {
        /// <summary>
        /// Get total count
        /// </summary>
        /// <returns></returns>
        Task<int> Count();

        /// <summary>
        /// Add an entity
        /// </summary>
        /// <param name="create">Entity inselft</param>
        /// <returns></returns>
        Task Create(Entity create);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="id">Current entity guid</param>
        /// <param name="update">Entity updated</param>
        /// <returns></returns>
        Task Update(Entity update);

        /// <summary>
        /// Delete entity by guid
        /// </summary>
        /// <param name="id">Entity guid to delete</param>
        /// <returns></returns>
        Task Delete(Guid id);
    }
}
