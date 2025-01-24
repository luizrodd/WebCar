using WebCar.Api.Application.DTOs;

namespace WebCar.Application.Application.DTOs
{
    public class CarDetailsDTO
    {
        public int Kilometer { get; set; }
        public int ConditionType { get; set; }
        public int TransmissionType { get; set; }
        public int FuelType { get; set; }
        public int BodyType { get; set; }
        public bool IsArmored { get; set; }
        public bool IsLicensed { get; set; }
        public int YearOfManufacture { get; set; }
        public int YearOfModel { get; set; }
        public VersionDTO Version { get; set; }
    }
}
