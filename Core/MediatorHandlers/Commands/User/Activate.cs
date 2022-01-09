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
        public class Handler : UnitOfWorkBase, IRequestHandler<ActivateCommand, bool>
        {
            public Handler(IUnitOfWork unit, IMapper mapper) : base(unit, mapper)
            {

            }

            public async Task<bool> Handle(ActivateCommand request, CancellationToken cancellationToken)
            {
                User find = await _unitOfWork.UserQueriesRepository.GetById(request.id);
                User update = new UserStatusBuilder(find).Reactivate();

                await _unitOfWork.UserCommandRepository.Update(update);
                return await _unitOfWork.Commit();
            }
        }
    }
}
