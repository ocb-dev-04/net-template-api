using Microsoft.EntityFrameworkCore;

using AutoMapper;

using Data.AppDbContext;
using Core.Interfaces;
using Core.Validations.QueryParams;
using Core.Entities;

namespace Data.Repositories
{
    public sealed class UserRepository :BaseRepository, IUserRepository
    {
        #region Ctor

        public UserRepository(ApplicationDbContext context, IMapper mapper):base(context, mapper)
        {

        }

        #endregion

        #region Single

        /// <inheritdoc/>
        public async Task<User> GetByEmail(string email)
            => await _context.User.FirstOrDefaultAsync(f => f.Email.Equals(email));

        /// <inheritdoc/>
        public async Task<User> GetById(Guid id)
            => await _context.User.FindAsync(id);
           
        #endregion

        #region Collections

        /// <inheritdoc/>
        public async Task<IEnumerable<User>> GetAll(BasePagination pagination)
            => await _context.User
            //.Take(10)
                                    //.Skip(pagination.PageNumber * 10)
                                    .ToListAsync();

        /// <inheritdoc/>
        public async Task<IEnumerable<User>> GetAllByName(GetByName byName)
            => await _context.User.Where(w => w.Name.StartsWith(byName.Name))
                                    .Take(10)
                                    .Skip(byName.PageNumber * 10)
                                    .ToListAsync();

        #endregion
    }
}
