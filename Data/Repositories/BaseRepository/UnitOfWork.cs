using Core.Interfaces;
using Core.Entities;
using Core.DTOs;

using Data.AppDbContext;

namespace Data.Repositories
{
    public class UnitOfWork : BaseRepository, IUnitOfWork
    {
        #region Properties

        #region Read actions props

        private readonly IUserRepository _userQueriesRepository;

        #endregion

        #region Write actions props

        private readonly IGenericRepository<User, UserDTO> _userCommandRepository;
        private readonly IGenericRepository<DeviceToken, DeviceTokenDTO> _deviceTokenCommandRepository;
        private readonly IGenericRepository<UserPhone, UserPhoneDTO> _userPhoneCommandRepository;
        private readonly IGenericRepository<UserScore, UserScoreDTO> _userScoreCommandRepository;

        #endregion
        
        #endregion

        #region Ctor

        /// <summary>
        /// <see cref="UnitOfWork"/> contructor
        /// </summary>
        /// <param name="context"><see cref="ApplicationDbContext"/> injection</param>
        public UnitOfWork(ApplicationDbContext context) : base(context)
        {

        }

        #endregion

        #region Read actions respositories

        /// <inheritdoc/>
        public IUserRepository UserQueriesRepository
            => _userQueriesRepository ?? new UserRepository(_context);

        #endregion

        #region Write actions repositories

        /// <inheritdoc/>
        public IGenericRepository<User, UserDTO> UserCommandRepository
            => _userCommandRepository ?? new GenericRepository<User, UserDTO>(_context);

        /// <inheritdoc/>
        public IGenericRepository<DeviceToken, DeviceTokenDTO> DeviceTokenCommandRepository
            => _deviceTokenCommandRepository ?? new GenericRepository<DeviceToken, DeviceTokenDTO>(_context);

        /// <inheritdoc/>
        public IGenericRepository<UserPhone, UserPhoneDTO> UserPhoneCommandRepository
            => _userPhoneCommandRepository ?? new GenericRepository<UserPhone, UserPhoneDTO>(_context);

        /// <inheritdoc/>
        public IGenericRepository<UserScore, UserScoreDTO> UserScoreCommandRepository
            => _userScoreCommandRepository ?? new GenericRepository<UserScore, UserScoreDTO>(_context);

        #endregion

        #region Interfaces methods inselft

        /// <inheritdoc/>
        public async Task<bool> Commit()
        {
            int changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        #endregion
    }
}
