using Flume.Application.Dtos;
using Flume.Application.Feature.Users.Handlers;
using Flume.Application.Feature.Users.Queries;
using Flume.Application.Features.Users.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlumeMiniWallet.API.Controllers
{
    [ApiController]
    [Route("api/v1/Users")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var query = new GetAllUsersQueries(); // Instancias la QUERY, no el Handler
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var command = new CreateUserCommand(
                createUserDto.Name,
                createUserDto.Email
                );
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
