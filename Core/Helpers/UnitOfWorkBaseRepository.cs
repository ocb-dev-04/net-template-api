using AutoMapper;
using Core.Interfaces;

namespace Core.Helpers
{
    public class UnitOfWorkBaseRepository
    {
        #region Properties

        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        #endregion

        #region Ctor

        public UnitOfWorkBaseRepository(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;   
            _mapper = mapper;
        }

        #endregion
    }
}
