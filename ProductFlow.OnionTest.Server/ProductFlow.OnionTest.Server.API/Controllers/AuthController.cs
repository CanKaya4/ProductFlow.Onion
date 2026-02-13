using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductFlow.OnionTest.Server.Application.Features.Commands.UserCommands;
using ProductFlow.OnionTest.Server.Application.Features.Queries.UserQueries;

namespace ProductFlow.OnionTest.Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserCommands command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserQuery query)
        {
            var token = await _mediator.Send(query);
            return Ok(new { Token = token });
        }
    }
}
