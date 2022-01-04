using AutoMapper;

using Data.AppDbContext;
using Core.Interfaces;

namespace Data.Repositories
{
    public sealed class UserRepository :BaseRepository, IUserRepository
    {
        #region Ctor

        public UserRepository(ApplicationDbContext context, IMapper mapper):base(context, mapper)
        {

        }

        #endregion

        #region Methods

        #endregion
    }
}
