using AutoMapper;
using MediatR;

using Core.DTOs;
using Core.Helpers;
using Core.Interfaces;
using Core.Builders;
using Core.Entities;

namespace Core.MediatorHandlers.Commands
{
    public class CreateUser
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
                User create = new CreateBuilder()
                    .SetName(request.model.Name)
                    .SetLastName(request.model.LastName)
                    .SetEmail(request.model.Email)
                    .Build();
                
                await _unitOfWork.UserCommandRepository.Create(create);
                return await _unitOfWork.Commit();
            }
        }
    }
}
