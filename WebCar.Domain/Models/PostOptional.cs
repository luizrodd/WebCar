namespace WebCar.Domain.Models
{
    public class PostOptional
    {
        public OptionalType Optional { get; private set; }
        public OptionalTypeEnum _optionalTypeId;

        public PostOptional(OptionalTypeEnum optionalId)
        {
            _optionalTypeId = optionalId;
        }
    }
}
