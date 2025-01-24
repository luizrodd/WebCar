using WebCar.Domain.Core;

namespace WebCar.Domain.Models
{
    public class Brand : Entity<Guid>, IExternalSource
    {
        private readonly List<Model> _models;
        private Brand()
        {
            _models = [];
        }
        public Brand(string name) : this()
        {
            Id = Guid.NewGuid();
            Name = name;
        }
        public string Name { get; private set; }
        public IReadOnlyCollection<Model> Models => _models;
        public void AddModel(Model model)
        {
            _models.Add(model);
        }
    }
}
