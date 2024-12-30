using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Nodes;
using WebCar.Application.Application.Commands;
using WebCar.Application.Application.Commands.CreateBrand;
using WebCar.Application.Application.Commands.CreateModel;
using WebCar.Application.Application.Commands.CreateVersion;
using WebCar.Application.Application.DTOs;
using WebCar.Application.Application.DTOs.Json;
using WebCar.Application.Application.Queries;
using WebCar.Domain.Models;

namespace WebCar.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController(IMediator mediator) : ControllerBase
    {
        private IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BrandDetailsDTO>), 200)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> GetBrands()
        {
            var query = new GetAllBrandQuery();
            var result = await _mediator.Send(query);
            if(result == null)
                return NoContent();

            return Ok(result);
        }

        [HttpGet("posts")]
        [ProducesResponseType(typeof(IEnumerable<BrandDetailsDTO>), 200)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> GetBrandsFromPosts()
        {
            var query = new GetBrandsFromPostQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

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

                var cmd = new CreateBrandFromJsonCommand(brands);
                var result = await _mediator.Send(cmd);

                return Ok(result);
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
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
                return BadRequest("Nome da marca não fornecido.");

            var command = new CreateBrandCommand(name);

            var result = await _mediator.Send(command);
            if (result == false) return BadRequest();

            return Ok(result);
        }

        [HttpPost("{brandId}/model")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddModel(Guid brandId, string name)
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
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddVersion(Guid modelId, string name)
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
