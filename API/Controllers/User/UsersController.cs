using Core.MediatorHandlers.Commands;
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

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return Ok();
        }

        #endregion

        #region Commands

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUser.CreateCommand command) 
            => Ok(await _mediator.Send(command));
        
        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> Update([FromBody] UpdateUser.UpdateCommand command) 
            => Ok(await _mediator.Send(command));

        [HttpDelete("activate/{id:guid}")]
        public async Task<IActionResult> Activate([FromRoute] ActivateUser.ActivateCommand command)
            => Ok(await _mediator.Send(command));
        
        [HttpDelete("desactivate/{id:guid}")]
        public async Task<IActionResult> Desactivate([FromRoute] DesactivateUser.DesactivateCommand command)
            => Ok(await _mediator.Send(command));
        
        [HttpDelete("pause/{id:guid}")]
        public async Task<IActionResult> Pause([FromRoute] PauseUser.PauseCommand command)
            => Ok(await _mediator.Send(command));
        
        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> Activate([FromRoute] DeleteUser.DeleteCommand command)
            => Ok(await _mediator.Send(command));

        #endregion
    }
}
