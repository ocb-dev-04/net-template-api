using AutoMapper;
using MediatR;

using Core.DTOs;
using Core.Helpers;
using Core.Interfaces;
using Core.Builders;
using Core.Entities;

namespace Core.MediatorHandlers.Commands
{
    public static class PauseUser
    {
        // Command
        public record PauseCommand(Guid id) : IRequest<bool>;

        // Handler
        public class Handler : UnitOfWorkBase, IRequestHandler<PauseCommand, bool>
        {
            public Handler(IUnitOfWork unit, IMapper mapper) : base(unit, mapper)
            {

            }

            public async Task<bool> Handle(PauseCommand request, CancellationToken cancellationToken)
            {
                FullUserDTO find = await _unitOfWork.UserQueriesRepository.GetById(request.id);
                User savedData = _mapper.Map<User>(find);
                User update = new UserStatusBuilder(savedData).Pause();

                await _unitOfWork.UserCommandRepository.Update(update);
                return await _unitOfWork.Commit();
            }
        }
    }
}
