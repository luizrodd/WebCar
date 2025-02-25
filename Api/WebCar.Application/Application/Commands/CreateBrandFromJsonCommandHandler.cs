using MediatR;
using WebCar.Application.Application.DTOs.Json;
using WebCar.Domain.Models.BrandAggregate;
using WebCar.Domain.Repositories;

namespace WebCar.Application.Application.Commands;

public class CreateBrandFromJsonCommandHandler(IBrandRepository brandRepository) : IRequestHandler<CreateBrandFromJsonCommand, bool>
{
    private readonly IBrandRepository _brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository));
    public Task<bool> Handle(CreateBrandFromJsonCommand request, CancellationToken cancellationToken)
    {
        foreach (var brand in request.Brands)
        {
            var brandEntity = new Brand(brand.Name);
            foreach (var model in brand.Models)
            {
                var modelEntity = new Model(model.Name);
                foreach (var version in model.Versions)
                {
                    modelEntity.AddVersion(new Domain.Models.BrandAggregate.Version(version.Name));
                }
                brandEntity.AddModel(modelEntity);
            }
            _brandRepository.Add(brandEntity);
        }

        _brandRepository.SaveChanges();

        return Task.FromResult(true);
    }
}
public class CreateBrandFromJsonCommand(List<BrandJsonDTO> brandJsonDTOs) : IRequest<bool>
{
    public List<BrandJsonDTO> Brands { get; set; } = brandJsonDTOs;
}
