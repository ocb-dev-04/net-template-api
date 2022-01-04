using AutoMapper;

namespace Core.Helpers
{
    public class UnitOfWorkBaseRepository
    {
        #region Properties

        protected readonly IMapper _mapper;

        #endregion

        #region Ctor

        public UnitOfWorkBaseRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        #endregion
    }
}
