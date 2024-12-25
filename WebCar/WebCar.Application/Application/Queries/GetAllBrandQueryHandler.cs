using MediatR;
using WebCar.Application.Application.DTOs;
using WebCar.Domain.Core;
using WebCar.Domain.Models;
using WebCar.Domain.Repositories;

namespace WebCar.Application.Application.Queries
{
    public class GetAllBrandQueryHandler(IBrandRepository brandRepository) : IRequestHandler<GetAllBrandQuery, List<BrandDetailsDTO>>
    {
        private readonly IBrandRepository _brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository));
        public async Task<List<BrandDetailsDTO>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
        {
            var brands = _brandRepository.GetAll().OrderBy(x => x.Name);

            return brands.Select(brand => new BrandDetailsDTO
            {
                Id = brand.Id,
                Name = brand.Name,
                Models = brand.Models.Select(model => new ModelDetailsDTO
                {
                    Id = model.Id,
                    Name = model.Name,
                    Versions = model.Versions.Select(version => new VersionDetailsDTO
                    {
                        Id = version.Id,
                        Name = version.Name
                    }).ToList()
                }).ToList()
            }).ToList();
        }
    }
    public class GetAllBrandQuery() : IRequest<List<BrandDetailsDTO>>
    {
    }
}
