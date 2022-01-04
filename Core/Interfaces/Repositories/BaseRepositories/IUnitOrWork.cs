using Core.DTOs;
using Core.Entities;

namespace Core.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        #region Read actions repositories

        /// <summary>
        /// User Queries Repository. Read actions.
        /// </summary>
        public IUserRepository UserQueriesRepository { get; }

        #endregion

        #region Write actions repositories

        /// <summary>
        /// User Command Repository. Write actions.
        /// </summary>
        public IGenericRepository<User, UserDTO> UserCommandRepository { get; }


        /// <summary>
        /// DeviceToken Command Repository. Write actions.
        /// </summary>
        public IGenericRepository<DeviceToken, DeviceTokenDTO> DeviceTokenCommandRepository { get; }

        /// <summary>
        ///  UserPhone Command Repository. Write actions.
        /// </summary>
        public IGenericRepository<UserPhone, UserPhoneDTO> UserPhoneCommandRepository { get; }

        /// <summary>
        /// UserPhone Command Repository. Write actions.
        /// </summary>
        public IGenericRepository<UserScore, UserScoreDTO> UserScoreCommandRepository { get; }

        #endregion
    }
}
