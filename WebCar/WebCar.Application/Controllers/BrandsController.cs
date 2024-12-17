using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Nodes;
using WebCar.Application.Application.Commands.CreateBrand;
using WebCar.Application.Application.Commands.CreateModel;
using WebCar.Application.Application.Commands.CreateVersion;
using WebCar.Application.Application.DTOs.Json;

namespace WebCar.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController(IMediator mediator) : ControllerBase
    {
        private IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpPost("json")]
        public async Task<IActionResult> CreateFromJson(IFormFile file)
        {
            if (file == null)
                return BadRequest("Arquivo não fornecido.");

            try
            {
                using var stream = file.OpenReadStream();
                using var reader = new StreamReader(stream);
                var jsonData = await reader.ReadToEndAsync();
                var jsonArray = JsonNode.Parse(jsonData).AsArray();

                var brands = jsonArray
                    .GroupBy(item => item["marca"].ToString())
                    .Select(group => new BrandJsonDTO
                    {
                        Name = group.Key,
                        Models = group
                            .GroupBy(item => item["modelo"].ToString())
                            .Select(modelGroup => new ModelJsonDTO
                            {
                                Name = modelGroup.Key,
                                Versions = modelGroup.Select(item => new VersionJsonDTO
                                {
                                    Name = $"{item["versao"]}"
                                }).ToList()
                            }).ToList()
                    }).ToList();

                return Ok(brands);
            }
            catch (JsonException ex)
            {
                return BadRequest($"Erro ao processar o JSON: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
                return BadRequest("Nome da marca não fornecido.");

            var command = new CreateBrandCommand(name);

            var result = await _mediator.Send(command);
            if (result == false) return BadRequest();

            return Ok(result);
        }

        [HttpPost("{brandId}/model")]
        public async Task<IActionResult> CreateModel(Guid brandId, string name)
        {
            if (brandId == Guid.Empty)
                return BadRequest("Id da marca não fornecido.");
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Nome do modelo não fornecido.");

            var command = new CreateModelCommand(brandId, name);

            var result = await _mediator.Send(command);
            if (result == false) return BadRequest();

            return Ok(result);
        }

        [HttpPost("model/{modelId}/version")]
        public async Task<IActionResult> CreateVersion(Guid modelId, string name)
        {
            if (modelId == Guid.Empty)
                return BadRequest("Id do modelo não fornecido.");
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Nome da versão não fornecido.");

            var command = new CreateVersionCommand(modelId, name);

            var result = await _mediator.Send(command);
            if (result == false) return BadRequest();

            return Ok(result);
        }
    }
}
