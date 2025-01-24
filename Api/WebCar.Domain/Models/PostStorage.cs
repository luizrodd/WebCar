using WebCar.Domain.Core;

namespace WebCar.Domain.Models
{
    public class PostStorage : ValueObject
    {
        public PostStorage(string filename, Guid scannedFileId)
        {
            Filename = filename;
            ScannedFileId = scannedFileId;
        }

        public string Filename { get; private set; }
        public Guid ScannedFileId { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Filename;
            yield return ScannedFileId;
        }
    }
}
