using WebCar.Domain.Core;

namespace WebCar.Domain.Models
{
    public class Image : Entity<Guid>
    {
        public string FileName { get; private set; }
        public string FilePath { get; private set; }
        public string ContentType { get; private set; }
        public long FileSize { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Image() { }

        public Image(string fileName, string filePath, string contentType, long fileSize)
        {
            Id = Guid.NewGuid();
            FileName = fileName;
            FilePath = filePath;
            ContentType = contentType;
            FileSize = fileSize;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
