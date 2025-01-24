using WebCar.Application.Application.DTOs;

namespace WebCar.Api.Application.DTOs
{
    public class PostDTO
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public string Localization { get; set; }
        public UserDTO User { get; set; }
        public CarDTO Car { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Images> Images { get; set; }
    }
    public class Images 
    {
        public Guid ScannedFileId { get; set; }
    }
}
