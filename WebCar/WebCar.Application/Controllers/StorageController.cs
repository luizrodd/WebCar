using Microsoft.AspNetCore.Mvc;
using WebCar.Domain.Interfaces;

namespace WebCar.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly IFileManagerService _fileManagerService;

        public StorageController(IFileManagerService fileManagerService)
        {
            _fileManagerService = fileManagerService ?? throw new System.ArgumentNullException(nameof(fileManagerService));
        }

        [HttpGet]
        public IActionResult Get(Guid userId, Guid postId, Guid fileId)
        {
            var fileInfo = _fileManagerService.GetInfo(userId, postId, fileId);

            if (fileInfo == null)
            {
                return NotFound("File not found.");
            }

            var fileContent = _fileManagerService.GetContent(userId, postId, fileId);

            if (fileContent == null || fileContent.Length == 0)
            {
                return NotFound("File content is empty.");
            }

            return File(fileContent, fileInfo.MimeType, fileInfo.FileName);
        }

    }
}
