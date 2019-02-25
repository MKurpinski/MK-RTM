using System.Threading.Tasks;
using AsyncSample.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AsyncSample.Controllers
{
    [Route("api/github")]
    [ApiController]
    public class GithubController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GithubController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{username:minlength(1)}")]
        public async Task<IActionResult> GetUserDetails(string username)
        {
            var result = await _mediator.Send(new GetUserDetailsRequest(username)).ConfigureAwait(false);
            if (result == null)
            {
                return NotFound($"User with username: {username} cannot be found");
            }
            return Ok(result);
        }
    }
}