namespace WebCar.Application.Application.DTOs.Json
{
    public class BrandJsonDTO
    {
        public string Name { get; set; }
        public IEnumerable<ModelJsonDTO> Models { get; set; }
    }
    public class ModelJsonDTO
    {
        public string Name { get; set; }
        public IEnumerable<VersionJsonDTO> Versions { get; set; }
    }
    public class VersionJsonDTO
    {
        public string Name { get; set; }
    }
}
