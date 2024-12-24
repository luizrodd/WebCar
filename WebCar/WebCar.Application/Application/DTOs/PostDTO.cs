using WebCar.Application.Application.DTOs;
using WebCar.Domain.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WebCar.Api.Application.DTOs
{
    public class PostDTO
    {
        public decimal Price { get; set; }
        public string Localization { get; set; }
        public CarDTO Car { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Guid> Images { get; set; }
    }
}
