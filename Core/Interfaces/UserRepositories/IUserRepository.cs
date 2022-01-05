using Core.DTOs;
using Core.Validations.QueryParams;

namespace Core.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserRepository
    {
        #region Single

        /// <summary>
        /// Get user by email
        /// </summary>
        /// <param name="email">The user email to search</param>
        /// <returns></returns>
        Task<FlatUserDTO> GetByEmail(string email);

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">Id of user</param>
        /// <returns></returns>
        Task<FullUserDTO> GetById(Guid id);

        #endregion

        #region Collections

        /// <summary>
        /// Get an user paginated list
        /// </summary>
        /// <param name="pageNumber">Number of page</param>
        /// <returns></returns>
        Task<IEnumerable<FlatUserDTO>> GetAll(BasePagination pagination);

        /// <summary>
        /// Get users by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<IEnumerable<FlatUserDTO>> GetAllByName(GetByName byName);

        #endregion
    }
}
