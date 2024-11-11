using WebCar.Domain.Core;

namespace WebCar.Domain.Models
{
    public class Model : Entity<Guid>
    {
        private readonly List<Version> _versions = new List<Version>();
        public Model(string name) 
        {
            Id = Guid.NewGuid();
            Name = name;
        }
        public string Name { get; set; }
        public IReadOnlyCollection<Version> Versions => _versions.AsReadOnly();
    }
}
