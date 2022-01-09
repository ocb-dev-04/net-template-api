using MediatR;
using AutoMapper;

using Core.DTOs;
using Core.Entities;
using Core.Helpers;
using Core.Interfaces;

namespace Core.MediatorHandlers.Queries
{
    public class GetUserById
    {
        // Command
        public record GetByIdCommand(Guid id) : IRequest<FullUserDTO>;

        // Handler
        public class Handler : UnitOfWorkBase, IRequestHandler<GetByIdCommand, FullUserDTO>
        {
            public Handler(IUnitOfWork unit, IMapper mapper) : base(unit, mapper)
            {

            }

            public async Task<FullUserDTO> Handle(GetByIdCommand request, CancellationToken cancellationToken)
            {
                User finded = await _unitOfWork.UserQueriesRepository.GetById(request.id);
                return _mapper.Map<FullUserDTO>(finded);
            }
        }
    }
}
