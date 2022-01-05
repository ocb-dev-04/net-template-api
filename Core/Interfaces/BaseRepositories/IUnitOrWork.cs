using Core.DTOs;
using Core.Entities;

namespace Core.Interfaces
{
    /// <summary>
    /// <see cref="IUnitOfWork"/> interface
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
        public IGenericRepository<User> UserCommandRepository { get; }


        /// <summary>
        /// DeviceToken Command Repository. Write actions.
        /// </summary>
        public IGenericRepository<DeviceToken> DeviceTokenCommandRepository { get; }

        /// <summary>
        ///  UserPhone Command Repository. Write actions.
        /// </summary>
        public IGenericRepository<UserPhone> UserPhoneCommandRepository { get; }

        /// <summary>
        /// UserPhone Command Repository. Write actions.
        /// </summary>
        public IGenericRepository<UserScore> UserScoreCommandRepository { get; }

        #endregion

        Task<bool> Commit();
    }
}
