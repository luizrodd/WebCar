using WebCar.Api.Application.DTOs;
using WebCar.Domain.Models;

namespace WebCar.Application.Application.DTOs
{
    public class CarDTO
    {
        public long Kilometer { get; set; }
        public int YearOfManufacture { get; set; }
        public int YearOfModel { get; set; }
        public TransmissionTypeEnum TransmissionType { get; set; }
        public FuelTypeEnum FuelType { get; set; }
        public VersionDTO Version { get; set; }
    }
}
