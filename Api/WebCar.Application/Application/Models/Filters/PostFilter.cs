using WebCar.Domain.Models;

namespace WebCar.Application.Application.Models.Filters
{
    public record PostFilter(
            long? StartKilometer,
            long? EndKilometer,
            int? StartYear,
            int? EndYear,
            decimal? StartPrice,
            decimal? EndPrice,
            bool? Armored,
            bool? Licensed,
            string? Localization,
            TransmissionTypeEnum? Clutch,
            FuelTypeEnum? Fuel,
            BodyTypeEnum? Body,
            CarConditionTypeEnum? Condition,
            Guid? BrandId,
            Guid? ModelId,
            Guid? VersionId)
    {
    }
}
