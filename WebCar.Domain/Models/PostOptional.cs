using WebCar.Domain.Core;

namespace WebCar.Domain.Models
{
    public class PostOptional : Entity<Guid>
    {
        public OptionalType Optional { get; private set; }
        private OptionalTypeEnum _optionalTypeId;

        public PostOptional(OptionalTypeEnum optionalId)
        {
            Id = Guid.NewGuid();
            _optionalTypeId = optionalId;
        }
    }
}
