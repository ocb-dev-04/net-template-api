using AutoMapper;

using Core.Helpers;
using Core.Interfaces;

namespace Core.Queries
{
    public sealed class UserQueries : UnitOfWorkBaseRepository, IUserQueries
    {
        #region Ctor

        public UserQueries(IUnitOfWork unitOfWork, IMapper mapper)
            :base(unitOfWork, mapper)
        {

        }

        #endregion
    }
}
