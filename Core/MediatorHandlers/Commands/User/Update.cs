using AutoMapper;
using Core.Builders;
using Core.DTOs;
using Core.Helpers;
using Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MediatorHandlers.Commands
{
    public class UpdateUser
    {
        // Command
        public record Command(UpdateUserDTO model) : IRequest<bool>;

        // Handler
        public class Handler : UnitOfWorkBaseRepository, IRequestHandler<Command, bool>
        {
            public Handler(IUnitOfWork unit, IMapper mapper) : base(unit, mapper)
            {

            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                FullUserDTO find = await _unitOfWork.UserQueriesRepository.GetById(request.model.Id);
                Entities.User savedData = _mapper.Map<Entities.User>(find);
                Entities.User update = new UpdateBuilder(savedData)
                    .SetName(request.model.Name)
                    .SetLastName(request.model.LastName)
                    .SetEmail(request.model.Email)
                    .Build();

                await _unitOfWork.UserCommandRepository.Update(update);
                return await _unitOfWork.Commit();
            }
        }
    }
}
