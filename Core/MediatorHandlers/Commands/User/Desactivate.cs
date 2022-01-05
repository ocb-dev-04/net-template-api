﻿using AutoMapper;
using MediatR;

using Core.Builders;
using Core.DTOs;
using Core.Helpers;
using Core.Interfaces;
using Core.Entities;

namespace Core.MediatorHandlers.Commands
{
    public static class DesactivateUser
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
                User savedData = _mapper.Map<User>(find);
                User update = new UserStatusBuilder(savedData).Desactivate();

                await _unitOfWork.UserCommandRepository.Update(update);
                return await _unitOfWork.Commit();
            }
        }
    }
}