using AutoMapper;

using Core.Helpers;
using Core.Interfaces;

namespace Core.Queries
{
    public sealed class UserQueries : UnitOfWorkBaseRepository, IUserQueries
    {
        private readonly IUnitOfWork _unitOfWork1;   

        #region Ctor

        public UserQueries(IUnitOfWork unitOfWork, IMapper mapper):base(mapper)
        {

        }

        #endregion
    }
}
