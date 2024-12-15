using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WebCar.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController(IMediator mediator) : ControllerBase
    {
        private IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpPost]
        public async Task<IActionResult> CreateFromJson(IFormFile file)
        {
            if (file == null) return BadRequest();

            using var stream = file.OpenReadStream();
            using var reader = new StreamReader(stream);
            var jsonData = await reader.ReadToEndAsync();

            var jsonObject = JsonSerializer.Deserialize<dynamic>(jsonData);

            return Ok(jsonObject);
        }
    }
}
