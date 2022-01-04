using Core.DTOs;
using Core.Entities;

namespace Core.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="Entity"></typeparam>
    /// <typeparam name="DTO"></typeparam>
    public interface IGenericRepository<Entity, DTO>
        where Entity : BaseEntity
        where DTO : BaseDTO
    {
        /// <summary>
        /// Add an entity
        /// </summary>
        /// <param name="create">DTO ready to map to entity</param>
        /// <returns></returns>
        Task Create(DTO create);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="id">Current entity guid</param>
        /// <param name="update">DTO with changes ready to map to entity</param>
        /// <returns></returns>
        Task Update(Guid id, DTO update);

        /// <summary>
        /// Delete entity by guid
        /// </summary>
        /// <param name="id">Entity guid to delete</param>
        /// <returns></returns>
        Task Delete(Guid id);
    }
}
