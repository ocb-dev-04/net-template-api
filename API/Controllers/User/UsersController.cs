using Core.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        #region Ctor

        public UsersController(IMediator mediator) : base(mediator)
        {

        }

        #endregion

        #region Read

        #endregion

        #region Commands

        [HttpPost]
        public async Task<IActionResult> Create(CreateUser.Command command) 
            => Ok(await _mediator.Send(command));

        #endregion
    }
}
