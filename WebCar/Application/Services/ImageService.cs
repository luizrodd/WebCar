using WebCar.Domain.Models;
using WebCar.Domain.Services;

namespace WebCar.Api.Application.Services
{
    public class ImageService
    {
        private readonly IImageStorageService _imageStorageService;
        //private readonly IRepository<Image> _imageRepository;

        public ImageService(IImageStorageService imageStorageService /*IRepository<Image> imageRepository*/)
        {
            _imageStorageService = imageStorageService;
            //_imageRepository = imageRepository;
        }

        public async Task<Guid> UploadImageAsync(Stream fileStream, string fileName, string contentType)
        {
            var filePath = await _imageStorageService.SaveAsync(fileStream, fileName, contentType);
            var image = new Image(fileName, filePath, contentType, fileStream.Length);

            //await _imageRepository.AddAsync(image);
            return image.Id;
        }

        public async Task DeleteImageAsync(Guid imageId)
        {
            //var image = await _imageRepository.GetByIdAsync(imageId);

            //await _imageStorageService.DeleteAsync(image.FilePath);
            //await _imageRepository.DeleteAsync(image);
        }
    }

}
