using Core.DTOs;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IGenericRepository<Entity, DTO>
        where Entity : BaseEntity
        where DTO : BaseDTO
    {
        /// <summary>
        /// Add an entity
        /// </summary>
        /// <param name="entity">Entity model</param>
        /// <returns></returns>
        Task Create(Entity entity);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="id">Current entity guid</param>
        /// <param name="entity">Enitty with changes</param>
        /// <returns></returns>
        Task Update(Guid id, Entity entity);

        /// <summary>
        /// Delete entity by guid
        /// </summary>
        /// <param name="id">Entity guid</param>
        /// <returns></returns>
        Task Delete(Guid id);
    }
}
