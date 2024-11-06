namespace WebCar.Domain.Models
{
    public class Model
    {
        public string Name { get; set; }
        public ICollection<Version> Versions { get; set; } = new List<Version>();
    }
}
