namespace WebCar.Domain.Models
{
    public class Brand
    {
        public string Name { get; set; }
        public ICollection<Model> Models { get; set; } = new List<Model>();
    }
}
