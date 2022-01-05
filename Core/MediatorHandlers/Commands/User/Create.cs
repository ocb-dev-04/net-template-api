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
        public record CreateCommand(CreateUserDTO model) : IRequest<FullUserDTO>;

        // Handler
        public class Handler : UnitOfWorkBase, IRequestHandler<CreateCommand, FullUserDTO>
        {
            public Handler(IUnitOfWork unit, IMapper mapper) : base(unit, mapper)
            {

            }

            public async Task<FullUserDTO> Handle(CreateCommand request, CancellationToken cancellationToken)
            {
                User create = new CreateBuilder()
                    .SetName(request.model.Name)
                    .SetLastName(request.model.LastName)
                    .SetEmail(request.model.Email)
                    .Build();
                
                await _unitOfWork.UserCommandRepository.Create(create);
                await _unitOfWork.Commit();
                return await _unitOfWork.UserQueriesRepository.GetById(create.Id);
            }
        }
    }
}
