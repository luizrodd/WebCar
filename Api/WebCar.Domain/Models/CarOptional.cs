using WebCar.Domain.Core;

namespace WebCar.Domain.Models
{
    public class CarOptional : Entity<Guid>
    {
        private CarOptional() { }
        public CarOptionalTypeEnum CarOptionalType { get; private set; }

        public CarOptional(CarOptionalTypeEnum optionalId)
        {
            Id = Guid.NewGuid();
            CarOptionalType = optionalId;
        }
    }
}
