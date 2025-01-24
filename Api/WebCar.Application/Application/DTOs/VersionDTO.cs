using WebCar.Application.Application.DTOs;

namespace WebCar.Api.Application.DTOs
{
    public class VersionDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ModelDTO Model { get; set; }
    }
}
