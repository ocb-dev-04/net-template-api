using AutoMapper;
using Core.Helpers;
using Core.Interfaces;

namespace Core.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class UserCommands : UnitOfWorkBaseRepository, IUserCommands
    {
        #region Ctor

        public UserCommands(IUnitOfWork unitOfWork, IMapper mapper) 
            : base(unitOfWork, mapper)
        {

        }

        #endregion
    }
}
