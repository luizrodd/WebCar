namespace WebCar.Domain.Models
{
    public class Image
    {
        public byte[] Data { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; } 

        public Image(byte[] data, string fileName, string description)
        {
            Data = data;
            FileName = fileName;
            Description = description;
        }
    }
}
