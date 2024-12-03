//using MediatR;
//using WebCar.Application.Application.DTOs;
//using WebCar.Domain.Core;
//using WebCar.Domain.Models;
//using WebCar.Domain.Repositories;

//namespace WebCar.Application.Application.Queries
//{
//    public class GetAllBrandQueryHandler(IExternalSourceRepository<Brand, Guid> brandRepository) : IRequestHandler<GetAllBrandQuery, List<BrandDTO>>
//    {
//        private readonly IExternalSourceRepository<Brand, Guid> _brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository));
//        public Task<List<BrandDTO>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
//        {
//        }
//    }
//    public class GetAllBrandQuery : IRequest<List<BrandDTO>>
//    {

//    }
//}
