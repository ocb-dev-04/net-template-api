using AutoMapper;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public class UnitOfWorkBaseRepository
    {
        #region Properties

        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        #endregion

        #region Ctor

        public UnitOfWorkBaseRepository(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion
    }
}
