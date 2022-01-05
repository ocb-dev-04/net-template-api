using AutoMapper;
using MediatR;

using Core.DTOs;
using Core.Helpers;
using Core.Interfaces;

namespace Core.Commands
{
    public static class CreateUser
    {
        // Command
        public record Command(CreateUserDTO model) : IRequest<bool>;

        // Handler
        public class Handler : UnitOfWorkBaseRepository, IRequestHandler<Command, bool>
        {
            public Handler(IUnitOfWork unit, IMapper mapper) : base(unit, mapper)
            {

            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                Entities.User create = _mapper.Map<Entities.User>(request.model);
                await _unitOfWork.UserCommandRepository.Create(create);
                return await _unitOfWork.Commit();
            }
        }
    }
}
