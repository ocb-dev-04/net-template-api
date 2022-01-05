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
        public class Handler : UnitOfWorkBaseRepository, IRequestHandler<UpdateCommand, FullUserDTO>
        {
            public Handler(IUnitOfWork unit, IMapper mapper) : base(unit, mapper)
            {

            }

            public async Task<FullUserDTO> Handle(UpdateCommand request, CancellationToken cancellationToken)
            {
                FullUserDTO find = await _unitOfWork.UserQueriesRepository.GetById(request.model.Id);
                User savedData = _mapper.Map<User>(find);
                User update = new UpdateBuilder(savedData)
                    .SetName(request.model.Name)
                    .SetLastName(request.model.LastName)
                    .SetEmail(request.model.Email)
                    .Build();

                await _unitOfWork.UserCommandRepository.Update(update);
                await _unitOfWork.Commit();
                return await _unitOfWork.UserQueriesRepository.GetById(update.Id);
            }
        }
    }
}
