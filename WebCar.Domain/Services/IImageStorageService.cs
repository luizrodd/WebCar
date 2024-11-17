namespace WebCar.Domain.Services
{
    public interface IImageStorageService
    {
        Task<string> SaveAsync(Stream fileStream, string fileName, string contentType);
        Task DeleteAsync(string filePath);
    }

    public class ImageStorageService : IImageStorageService
    {
        private readonly string _baseDirectory;

        public ImageStorageService(string baseDirectory)
        {
            _baseDirectory = baseDirectory;
        }

        public async Task<string> SaveAsync(Stream fileStream, string fileName, string contentType)
        {
            var filePath = Path.Combine(_baseDirectory, fileName);
            using var fileStreamOutput = new FileStream(filePath, FileMode.Create);
            await fileStream.CopyToAsync(fileStreamOutput);
            return filePath;
        }

        public Task DeleteAsync(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Task.CompletedTask;
        }
    }

}
