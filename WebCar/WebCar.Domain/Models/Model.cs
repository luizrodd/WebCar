using WebCar.Domain.Core;

namespace WebCar.Domain.Models
{
    public class Model : Entity<Guid>
    {
        private readonly List<Version> _versions;
        private Model()
        {
            _versions = [];
        }
        public Model(string name) : this()
        {
            Id = Guid.NewGuid();
            Name = name;
        }
        public string Name { get; private set; }
        public IReadOnlyCollection<Version> Versions => _versions;
        public void AddVersion(Version version)
        {
            _versions.Add(version);
        }
    }
}
