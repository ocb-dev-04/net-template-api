using AutoMapper;
using Core.Builders;
using Core.DTOs;
using Core.Entities;
using Core.Helpers;
using Core.Interfaces;
using MediatR;

namespace Core.MediatorHandlers.Commands
{
    public static class ActivateUser
    {
        // Command
        public record ActivateCommand(Guid id) : IRequest<bool>;

        // Handler
        public class Handler : UnitOfWorkBaseRepository, IRequestHandler<ActivateCommand, bool>
        {
            public Handler(IUnitOfWork unit, IMapper mapper) : base(unit, mapper)
            {

            }

            public async Task<bool> Handle(ActivateCommand request, CancellationToken cancellationToken)
            {
                FullUserDTO find = await _unitOfWork.UserQueriesRepository.GetById(request.id);
                User savedData = _mapper.Map<User>(find);
                User update = new UserStatusBuilder(savedData).Reactivate();

                await _unitOfWork.UserCommandRepository.Update(update);
                return await _unitOfWork.Commit();
            }
        }
    }
}
