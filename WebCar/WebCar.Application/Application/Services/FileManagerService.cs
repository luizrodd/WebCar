using WebCar.Domain.Interfaces;

namespace WebCar.Application.Application.Services;


public class FileManagerService(IFileSystemManager fileSystemManager) : IFileManagerService
{
    private const string ROOT_FOLDER_NAME = "Images";
    private readonly IFileSystemManager _fileSystem = fileSystemManager ?? throw new ArgumentNullException(nameof(fileSystemManager));

    private static string GetPostFolder(Guid userId, Guid postId, Guid fileId)
    {
        return $"{ROOT_FOLDER_NAME}/{userId}/{postId}/{fileId}";
    }

    public Guid Save(Guid userId, Guid postId, string fileName, byte[] data)
    {
        var fileId = Guid.NewGuid();
        var filePath = GetPostFolder(userId, postId, fileId);

        _fileSystem.Save(filePath, fileName, data);

        return fileId;
    }

    public void Delete(Guid userId, Guid postId, Guid fileId)
    {
        var filePath = GetPostFolder(userId, postId, fileId);

        _fileSystem.Delete(filePath);
    }

    public FileSystemObject GetInfo(Guid userId, Guid postId, Guid fileId)
    {
        var filePath = GetPostFolder(userId, postId, fileId);

        return _fileSystem.GetInfo(filePath);
    }

    public byte[] GetContent(Guid userId, Guid postId, Guid fileId)
    {
        var filePath = GetPostFolder(userId, postId, fileId);

        var fileData = _fileSystem.Get(filePath, loadContent: true);
        return fileData.Data;
    }
}
