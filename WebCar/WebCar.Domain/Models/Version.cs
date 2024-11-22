using WebCar.Domain.Core;

namespace WebCar.Domain.Models
{
    public class Version : Entity<Guid>
    {
        public Version(string name) 
        {
            Id = Guid.NewGuid();
            Name = name;
        }
        public string Name { get; private set; }
    }
}
