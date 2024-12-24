using WebCar.Api.Application.DTOs;

namespace WebCar.Application.Application.DTOs
{
    public class ModelDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public BrandDTO Brand { get; set; }
    }
}