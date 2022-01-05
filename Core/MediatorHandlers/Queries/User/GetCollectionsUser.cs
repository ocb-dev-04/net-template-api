using MediatR;
using AutoMapper;

using Core.DTOs;
using Core.Helpers;
using Core.Interfaces;
using Core.Validations.QueryParams;

namespace Core.MediatorHandlers.Queries.User
{
    public class GetCollectionsUser
    {
        // Command
        public record GetCollectionsCommand(BasePagination model) : IRequest<IEnumerable<FlatUserDTO>>;

        // Handler
        public class Handler : UnitOfWorkBase, IRequestHandler<GetCollectionsCommand, IEnumerable<FlatUserDTO>>
        {
            public Handler(IUnitOfWork unit, IMapper mapper) : base(unit, mapper)
            {

            }

            public async Task<IEnumerable<FlatUserDTO>> Handle(GetCollectionsCommand request, CancellationToken cancellationToken)
                => await _unitOfWork.UserQueriesRepository.GetAll(request.model);
        }
    }
}
