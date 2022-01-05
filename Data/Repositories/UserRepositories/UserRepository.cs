using Microsoft.EntityFrameworkCore;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using Data.AppDbContext;
using Core.Interfaces;
using Core.DTOs;
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
        public async Task<FullUserDTO> GetByEmail(string email)
        {
            User user = await _context.User.FirstOrDefaultAsync(f => f.Email.Equals(email));
            return _mapper.Map<FullUserDTO>(user);
        }


        /// <inheritdoc/>
        public async Task<FullUserDTO> GetById(Guid id)
        {
            User user = await _context.User.FirstOrDefaultAsync(f => f.Id.Equals(id));
            return _mapper.Map<FullUserDTO>(user);
        }

        #endregion

        #region Collections

        /// <inheritdoc/>
        public async Task<IEnumerable<FlatUserDTO>> GetAll(BasePagination pagination)
            => await _context.User.ProjectTo<FlatUserDTO>(_mapper.ConfigurationProvider)
                                    .Take(10)
                                    .Skip(pagination.PageNumber * 10)
                                    .ToListAsync();

        /// <inheritdoc/>
        public async Task<IEnumerable<FlatUserDTO>> GetAllByName(GetByName byName)
            => await _context.User.Where(w => w.Name.StartsWith(byName.Name))
                                    .ProjectTo<FlatUserDTO>(_mapper.ConfigurationProvider)
                                    .Take(10)
                                    .Skip(byName.PageNumber * 10)
                                    .ToListAsync();

        #endregion
    }
}
