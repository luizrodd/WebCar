namespace WebCar.Application.Application.DTOs
{
    public class BrandDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<ModelDTO> Models { get; set; }
    }
}
