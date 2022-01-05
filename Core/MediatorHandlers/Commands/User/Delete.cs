﻿using AutoMapper;
using MediatR;

using Core.DTOs;
using Core.Helpers;
using Core.Interfaces;

namespace Core.MediatorHandlers.Commands
{
    public static class DeleteUser
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
                if (find == null) throw new ArgumentNullException(nameof(find));

                await _unitOfWork.UserCommandRepository.Delete(find.Id);
                return await _unitOfWork.Commit();
            }
        }
    }
}