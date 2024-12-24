using WebCar.Api.Application.DTOs;

namespace WebCar.Application.Application.DTOs
{
    public class PostDetailsDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool AcceptTrade { get; set; }
        public decimal Price { get; set; }
        public UserDTO User { get; set; }
        public string Localization { get; set; }
        public CarDetailsDTO Car { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Images> Images { get; set; }
    }
}
