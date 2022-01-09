using Core.MediatorHandlers.Commands;
using Core.MediatorHandlers.Queries;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetCollectionsUser.GetCollectionsCommand command)
            => Ok(await _mediator.Send(command));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] GetUserById.GetByIdCommand command)
            => Ok(await _mediator.Send(command));   

        #endregion

        #region Commands

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUser.CreateCommand command) 
            => Ok(await _mediator.Send(command));
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> Update([FromBody] UpdateUser.UpdateCommand command) 
            => Ok(await _mediator.Send(command));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("activate/{id:guid}")]
        public async Task<IActionResult> Activate([FromRoute] ActivateUser.ActivateCommand command)
            => Ok(await _mediator.Send(command));
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("desactivate/{id:guid}")]
        public async Task<IActionResult> Desactivate([FromRoute] DesactivateUser.DesactivateCommand command)
            => Ok(await _mediator.Send(command));
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("pause/{id:guid}")]
        public async Task<IActionResult> Pause([FromRoute] PauseUser.PauseCommand command)
            => Ok(await _mediator.Send(command));
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> Activate([FromRoute] DeleteUser.DeleteCommand command)
            => Ok(await _mediator.Send(command));

        #endregion
    }
}
