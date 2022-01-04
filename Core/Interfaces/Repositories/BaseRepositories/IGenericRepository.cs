using Core.Entities;

namespace Core.Interfaces.Repositories.BaseRepositories
{
    public interface IGenericRepository<Entity> where Entity : BaseEntity
    {
        /// <summary>
        /// Get entity list
        /// </summary>
        /// <returns></returns>
        Task<HashSet<Entity>> GetAll();

        /// <summary>
        /// Get deleted entities list
        /// </summary>
        /// <returns></returns>
        Task<HashSet<Entity>> GetAllDeletes();

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id">Entity guid</param>
        /// <returns></returns>
        Task<Entity?> GetById(Guid id);

        /// <summary>
        /// Add an entity
        /// </summary>
        /// <param name="entity">Entity model</param>
        /// <returns></returns>
        Task<Entity> Create(Entity entity);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="id">Current entity guid</param>
        /// <param name="entity">Enitty with changes</param>
        /// <returns></returns>
        Task<Entity> Update(Guid id, Entity entity);

        /// <summary>
        /// Delete entity by guid
        /// </summary>
        /// <param name="id">Entity guid</param>
        /// <returns></returns>
        Task<bool> Delete(Guid id);
    }
}
