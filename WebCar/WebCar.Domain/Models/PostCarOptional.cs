using WebCar.Domain.Core;

namespace WebCar.Domain.Models
{
    public class PostCarOptional : Entity<Guid>
    {
        private PostCarOptional() { }
        public CarOptionalTypeEnum CarOptionalType { get; private set; }

        public PostCarOptional(CarOptionalTypeEnum optionalId)
        {
            Id = Guid.NewGuid();
            CarOptionalType = optionalId;
        }
    }
}
