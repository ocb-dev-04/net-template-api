using AutoMapper;
using Core.Interfaces;

namespace Core.Helpers
{
    public class UnitOfWorkBase
    {
        #region Properties

        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        #endregion

        #region Ctor

        public UnitOfWorkBase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;   
            _mapper = mapper;
        }

        #endregion
    }
}
