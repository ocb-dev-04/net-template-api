using Microsoft.EntityFrameworkCore;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using Data.AppDbContext;
using Core.Interfaces;
using Core.DTOs;
using Core.Validations.QueryParams;

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
        public async Task<FlatUserDTO> GetByEmail(string email)
            =>  await _context.User.Select(s => 
                                new FlatUserDTO()
                                {
                                    Id = s.Id,
                                    FullName = string.Format("{0} {1}", s.Name, s.LastName),
                                    Email = s.Email,
                                    Status = s.UserStatus,
                                    VerificationStatus = s.VerificationStatus
                                }).FirstOrDefaultAsync(f => f.Email.Equals(email));


        /// <inheritdoc/>
        public async Task<FullUserDTO> GetById(Guid id)
            => await _context.User.Select(s =>
                                new FullUserDTO()
                                {
                                    Id = s.Id,
                                    FullName = string.Format("{0} {1}", s.Name, s.LastName),
                                    Email = s.Email,
                                    Status = s.UserStatus,
                                    VerificationStatus = s.VerificationStatus
                                }).FirstOrDefaultAsync(f => f.Id.Equals(id));

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
