namespace WebCar.Application.Application.DTOs
{
    public class BrandDetailsDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<ModelDetailsDTO> Models { get; set; }
    }

    public class ModelDetailsDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<VersionDetailsDTO> Versions { get; set; }
    }

    public class VersionDetailsDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
