using Ambev.DeveloperEvaluation.Application.Auth.AuthenticateUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Authenticates the user and generates a JWT token.
        /// </summary>
        /// <param name="request">Login request containing email and password.</param>
        /// <returns>JWT token if authentication is successful.</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthenticateUserCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
