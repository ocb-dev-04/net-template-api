using AutoMapper;

using Data.AppDbContext;
using Core.Interfaces;
using Core.Entities;
using Core.DTOs;

namespace Data.Repositories
{
    public class UnitOfWork : BaseRepository, IUnitOfWork
    {
        #region Properties

        #region Read actions props

        private readonly IUserRepository _userQueriesRepository;

        #endregion

        #region Write actions props

        private readonly IGenericRepository<User> _userCommandRepository;
        private readonly IGenericRepository<DeviceToken> _deviceTokenCommandRepository;
        private readonly IGenericRepository<UserPhone> _userPhoneCommandRepository;
        private readonly IGenericRepository<UserScore> _userScoreCommandRepository;

        #endregion
        
        #endregion

        #region Ctor

        /// <summary>
        /// <see cref="UnitOfWork"/> contructor
        /// </summary>
        /// <param name="context"><see cref="ApplicationDbContext"/> injection</param>
        public UnitOfWork(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {

        }

        #endregion

        #region Read actions respositories

        /// <inheritdoc/>
        public IUserRepository UserQueriesRepository
            => _userQueriesRepository ?? new UserRepository(_context, _mapper);

        #endregion

        #region Write actions repositories

        /// <inheritdoc/>
        public IGenericRepository<User> UserCommandRepository
            => _userCommandRepository ?? new GenericRepository<User>(_context, _mapper);

        /// <inheritdoc/>
        public IGenericRepository<DeviceToken> DeviceTokenCommandRepository
            => _deviceTokenCommandRepository ?? new GenericRepository<DeviceToken>(_context, _mapper);

        /// <inheritdoc/>
        public IGenericRepository<UserPhone> UserPhoneCommandRepository
            => _userPhoneCommandRepository ?? new GenericRepository<UserPhone>(_context, _mapper);

        /// <inheritdoc/>
        public IGenericRepository<UserScore> UserScoreCommandRepository
            => _userScoreCommandRepository ?? new GenericRepository<UserScore>(_context, _mapper);

        #endregion

        /// <inheritdoc/>
        public async Task<bool> Commit()
        {
            int changes = await _context.SaveChangesAsync();
            return changes > 0;
        }
    }
}
