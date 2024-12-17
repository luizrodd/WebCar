//using MediatR;
//using WebCar.Application.Application.DTOs;
//using WebCar.Domain.Core;
//using WebCar.Domain.Models;
//using WebCar.Domain.Repositories;

//namespace WebCar.Application.Application.Queries
//{
//    public class GetAllBrandQueryHandler(IBrandRepository brandRepository) : IRequestHandler<GetAllBrandQuery, List<BrandDTO>>
//    {
//        private readonly IBrandRepository _brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository));
//        public Task<List<BrandDTO>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
//        {
//            var brands = _brandRepository.GetAll()
//        }
//    }
//    public class GetAllBrandQuery(string Name, string Model, string Version) : IRequest<List<BrandDTO>>
//    {

//    }
//}
