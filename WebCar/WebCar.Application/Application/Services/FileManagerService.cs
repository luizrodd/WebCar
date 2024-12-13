using WebCar.Domain.Interfaces;

namespace WebCar.Application.Application.Services;

public class FileManagerService : IFileManagerService
{
    private readonly IFileSystemManager _fileSystem;

    public FileManagerService(IFileSystemManager fileSystem)
    {
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
    }

    private const string ROOT_FOLDER_NAME = "images";

    private static string GetPostFolder(Guid userId, Guid postId, Guid fileId)
    {
        return $"{ROOT_FOLDER_NAME}/{userId}/{postId}/{fileId}";
    }

    public Guid Save(Guid userId, Guid postId, string fileName, byte[] data)
    {
        var id = Guid.NewGuid();
        var fileToSave = GetPostFolder(userId, postId, id);
        _fileSystem.Write(fileToSave, fileName, data);
        return id;
    }

    public void Delete(Guid userId, Guid postId, Guid fileId)
    {
        var file = GetPostFolder(userId, postId, fileId);
        _fileSystem.Delete(file);
    }

    public FileSystemObject GetInfo(Guid userId, Guid postId, Guid fileId)
    {
        var file = GetPostFolder(userId, postId, fileId);
        var data = _fileSystem.Get(file, true);
        return data.Info;
    }

    public byte[] GetContent(Guid userId, Guid postId, Guid fileId)
    {
        var file = GetPostFolder(userId, postId, fileId);
        var data = _fileSystem.Get(file, false);
        return data.Data;
    }

}
