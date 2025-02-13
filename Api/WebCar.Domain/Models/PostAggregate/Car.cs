using WebCar.Domain.Core;

namespace WebCar.Domain.Models.PostAggregate
{
    public class Car : Entity<Guid>
    {
        private readonly List<CarOptional> _optionalPosts;
        private Car()
        {
            _optionalPosts = [];
        }
        public Car(long kilometer, int yearOfManufacture, int yearOfModel, bool armored, bool licensed,
            TransmissionTypeEnum clutch,
            FuelTypeEnum fuel,
            BodyTypeEnum body,
            CarConditionTypeEnum condition,
            Guid versionId,
            List<CarOptional> postOptionals) : this()
        {
            Id = Guid.NewGuid();
            Kilometer = kilometer;
            YearOfManufacture = yearOfManufacture;
            YearOfModel = yearOfModel;
            IsArmored = armored;
            IsLicensed = licensed;

            ConditionType = condition;
            TransmissionType = clutch;
            FuelType = fuel;
            BodyType = body;
            VersionId = versionId;

            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;

            _optionalPosts = postOptionals;
        }

        public long Kilometer { get; private set; }
        public int YearOfManufacture { get; private set; }
        public int YearOfModel { get; private set; }
        public bool IsEnabled { get; private set; }
        public bool IsArmored { get; private set; }
        public bool IsLicensed { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public CarConditionTypeEnum ConditionType { get; private set; }
        public TransmissionTypeEnum TransmissionType { get; private set; }
        public FuelTypeEnum FuelType { get; private set; }
        public BodyTypeEnum BodyType { get; private set; }
        public Guid VersionId { get; private set; }
        public IReadOnlyCollection<CarOptional> Optionals => _optionalPosts;
    }
}
