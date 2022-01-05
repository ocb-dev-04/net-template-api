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

        #endregion

        Task<bool> Commit();
    }
}
