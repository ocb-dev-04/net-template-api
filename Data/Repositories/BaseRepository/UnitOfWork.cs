using Data.AppDbContext;

using Core.Interfaces;
using Core.Entities;

namespace Data.Repositories
{
    public class UnitOfWork : BaseRepository, IUnitOfWork
    {
        #region Properties

        private readonly IGenericRepository<User> _userGenRepository;
        private readonly IGenericRepository<DeviceToken> _deviceTokenGenRepository;
        private readonly IGenericRepository<UserPhone> _userPhoneGenRepository;
        private readonly IGenericRepository<UserScore> _userScoreGenRepository;
        
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

        #region Repositories methods

        /// <inheritdoc/>
        public IGenericRepository<User> UserGenRepository 
            => _userGenRepository ?? new GenericRepository<User>(_context);

        /// <inheritdoc/>
        public IGenericRepository<DeviceToken> DeviceTokenGenRepository 
            => _deviceTokenGenRepository ?? new GenericRepository<DeviceToken>(_context);

        /// <inheritdoc/>
        public IGenericRepository<UserPhone> UserPhoneGenRepository 
            => _userPhoneGenRepository ?? new GenericRepository<UserPhone>(_context);

        /// <inheritdoc/>
        public IGenericRepository<UserScore> UserScoreGenRepository 
            => _userScoreGenRepository ?? new GenericRepository<UserScore>(_context);

        #endregion

        #region Interfaces methods inselft

        /// <inheritdoc/>
        public async Task<bool> Commit()
        {
            int changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        #endregion
    }
}
