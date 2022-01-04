using Core.Interfaces;
using Data.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public sealed class UserRepository :BaseRepository, IUserRepository
    {
        #region Ctor

        public UserRepository(ApplicationDbContext context):base(context)
        {

        }

        #endregion

        #region Methods

        #endregion
    }
}
