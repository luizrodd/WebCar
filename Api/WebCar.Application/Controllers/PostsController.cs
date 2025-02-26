using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebCar.Api.Application.Commands;
using WebCar.Api.Application.DTOs;
using WebCar.Application.Application.Commands.ApprovePost;
using WebCar.Application.Application.Commands.CancelPost;
using WebCar.Application.Application.Commands.SoldPost;
using WebCar.Application.Application.DTOs;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromForm] AddPostRequest request)
        {
            if (request == null) return BadRequest();

            var command = new AddPostCommand(request);

            var result = await _mediator.Send(command);

            return Ok();
        }

        [HttpPost("{id}/sold")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Sold(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            var command = new SoldPostCommand(id);
            var result = await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("{id}/cancel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Canceled(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var command = new CanceledPostCommand(id);
            var result = await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("{id}/approve")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Approve(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var command = new ApprovePostCommand(id);
            var result = await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PostDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PostDetailsDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetDetails(Guid id)
        {
            var result = await _postQueries.GetById(id);
            if (result == null) return BadRequest();

            return Ok(result);
        }
    }
}
