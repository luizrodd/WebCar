using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebCar.Api.Application.Commands;
using WebCar.Application.Application.Models.Requests;

namespace WebCar.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromForm] AddPostRequest request)
        {
            if (request == null) return BadRequest();

            var command = new AddPostCommand(request);

            var result = await _mediator.Send(command);

            return Ok();
        }
    }
}
