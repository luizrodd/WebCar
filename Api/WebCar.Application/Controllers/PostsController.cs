using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebCar.Api.Application.Commands;
using WebCar.Application.Application.Models.Filters;
using WebCar.Application.Application.Models.Requests;
using WebCar.Application.Application.Queries;
using WebCar.Application.Application.Services;
using WebCar.Domain.Interfaces;

namespace WebCar.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPostQueries _postQueries;

        public PostsController(IMediator mediator, IPostQueries postQueries)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _postQueries = postQueries;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] AddPostRequest request)
        {
            if (request == null) return BadRequest();

            var command = new AddPostCommand(request);

            var result = await _mediator.Send(command);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PostFilter filter)
        {
            var result = await _postQueries.Get(filter);
            if (result == null) return NoContent();

            foreach (var post in result)
            {
                foreach (var image in post.Images)
                {
                    image.Path = $"https://localhost:7193/Images/{post.User.Id}/{post.Id}/{image.ScannedFileId}/{image.Filename}";
                }
            }

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(Guid id)
        {
            var result = await _postQueries.GetById(id);
            if (result == null) return BadRequest();

            return Ok(result);
        }
    }
}
