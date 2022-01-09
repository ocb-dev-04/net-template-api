using AutoMapper;
using MediatR;

using Core.Builders;
using Core.DTOs;
using Core.Helpers;
using Core.Interfaces;
using Core.Entities;

namespace Core.MediatorHandlers.Commands
{
    public class UpdateUser
    {
        // Command
        public record UpdateCommand(UpdateUserDTO model) : IRequest<FullUserDTO>;

        // Handler
        public class Handler : UnitOfWorkBase, IRequestHandler<UpdateCommand, FullUserDTO>
        {
            public Handler(IUnitOfWork unit, IMapper mapper) : base(unit, mapper)
            {

            }

            public async Task<FullUserDTO> Handle(UpdateCommand request, CancellationToken cancellationToken)
            {
                User find = await _unitOfWork.UserQueriesRepository.GetById(request.model.Id);
                User update = new UpdateBuilder(find)
                    .SetName(request.model.Name)
                    .SetLastName(request.model.LastName)
                    .SetEmail(request.model.Email)
                    .Build();

                await _unitOfWork.UserCommandRepository.Update(update);
                await _unitOfWork.Commit();

                User updated =  await _unitOfWork.UserQueriesRepository.GetById(update.Id);
                return _mapper.Map<FullUserDTO>(updated);
            }
        }
    }
}
