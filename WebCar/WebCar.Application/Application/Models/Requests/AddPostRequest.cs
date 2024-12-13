using WebCar.Domain.Models;

namespace WebCar.Application.Application.Models.Requests;

public record AddPostRequest(
    Guid UserId,
    decimal Price,
    string Localization,
    string Description,
    bool AcceptTrade,
    List<IFormFile> Images,
    long Kilometer,
    int YearOfManufacture,
    int YearOfModel,
    bool Armored,
    bool Licensed,
    TransmissionTypeEnum Clutch,
    FuelTypeEnum Fuel,
    BodyTypeEnum Body,
    CarConditionTypeEnum Condition,
    Guid VersionId,
    List<CarOptionalTypeEnum> Optionals)
{}
