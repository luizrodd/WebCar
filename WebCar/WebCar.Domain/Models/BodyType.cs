namespace WebCar.Domain.Models
{
    public class BodyType
    {
        public BodyTypeEnum Id { get; private set; }
        public string Name { get; private set; }

        public BodyType(BodyTypeEnum id)
        {
            Id = id;
            Name = id.ToString();
        }
    }
    public enum BodyTypeEnum
    {
        Hatchback = 0,
        Sedan = 1,
        SUV = 2,
        Pickup = 3,
        Coupe = 4,
        Convertible = 5,
        Minivan = 6,
        Van = 7
    }
}
