using WebCar.Domain.Models;

namespace WebCar.Api.Application.DTOs
{
    public class PostDTO
    {
        public long Kilometer { get; set; }
        public int YearOfManufacture { get; set; }
        public int YearOfModel { get; set; }
        public decimal Price { get; set; }
        public string Localization { get; set; }
        public string? Description { get; set; }
        public bool IsSold { get; set; }
        public bool IsArmored { get; set; }
        public bool IPVA { get; set; }
        public bool AcceptTrade { get; set; }
        public bool IsLicensed { get; set; }
        public bool IsUsed { get; set; }
        public DateTime UpdatedAt { get; set; }
        public TransmissionTypeEnum TransmissionType { get; set; }
        public FuelTypeEnum FuelType { get; set; }
        public BodyTypeEnum BodyType { get; set; }
        public VersionDTO Version { get; set; }
        public List<ImageDTO> Images { get; set; }
        public List<PostOptionalDTO> PostOptionals { get; set; }
    }
}
