using AutoMapper;
using Core.Builders;
using Core.DTOs;
using Core.Helpers;
using Core.Interfaces;
using MediatR;

namespace Core.MediatorHandlers.Commands
{
    public static class ReactivateUser
    {
        // Command
        public record Command(Guid id) : IRequest<bool>;

        // Handler
        public class Handler : UnitOfWorkBaseRepository, IRequestHandler<Command, bool>
        {
            public Handler(IUnitOfWork unit, IMapper mapper) : base(unit, mapper)
            {

            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                FullUserDTO find = await _unitOfWork.UserQueriesRepository.GetById(request.id);
                Entities.User savedData = _mapper.Map<Entities.User>(find);
                Entities.User update = new UserStatusBuilder(savedData).Reactivate();

                await _unitOfWork.UserCommandRepository.Update(update);
                return await _unitOfWork.Commit();
            }
        }
    }
}
