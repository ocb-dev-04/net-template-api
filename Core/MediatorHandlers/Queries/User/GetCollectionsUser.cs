using MediatR;
using AutoMapper;

using Core.DTOs;
using Core.Entities;
using Core.Helpers;
using Core.Interfaces;
using Core.Validations.QueryParams;

namespace Core.MediatorHandlers.Queries
{
    public class GetCollectionsUser
    {
        // Command
        public record GetCollectionsCommand(BasePagination model) : IRequest<IEnumerable<FullUserDTO>>;

        // Handler
        public class Handler : UnitOfWorkBase, IRequestHandler<GetCollectionsCommand, IEnumerable<FullUserDTO>>
        {
            public Handler(IUnitOfWork unit, IMapper mapper) : base(unit, mapper)
            {

            }

            public async Task<IEnumerable<FullUserDTO>> Handle(GetCollectionsCommand request, CancellationToken cancellationToken)
            {
                IEnumerable<User> finded = await _unitOfWork.UserQueriesRepository.GetAll(request.model);
                return _mapper.Map<IEnumerable<User>, IEnumerable<FullUserDTO>>(finded);
            }
        }
    }
}
