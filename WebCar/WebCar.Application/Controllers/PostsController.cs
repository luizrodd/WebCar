using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebCar.Api.Application.Commands;
using WebCar.Application.Application.Models.Filters;
using WebCar.Application.Application.Models.Requests;
using WebCar.Application.Application.Queries;
using static WebCar.Application.Application.Queries.GetPostsQueryHandler;

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

        [HttpGet]
        public async Task<IActionResult> GetPosts([FromQuery] PostFilter filter)
        {
            var query = new GetPostsQuery(
                filter.StartKilometer,
                filter.EndKilometer,
                filter.StartYear,
                filter.EndYear,
                filter.StartPrice,
                filter.EndPrice,
                filter.Armored,
                filter.Licensed,
                filter.Localization,
                filter.Clutch,
                filter.Fuel,
                filter.Body,
                filter.Condition,
                filter.VersionId,
                filter.ModelId,
                filter.BrandId
                );

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostDetails(Guid id)
        {
            var query = new GetPostDetailsQuery(id);

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
