using WebCar.Application.Application.Services;

namespace WebCar.Domain.Interfaces
{
    public interface IFileManagerService
    {
        Guid Save(Guid userId, Guid postId, string fileName, byte[] data);
        void Delete(Guid userId, Guid postId, Guid fileId);
        FileSystemObject GetInfo(Guid userId, Guid postId, Guid fileId);
        public byte[] GetContent(Guid userId, Guid postId, Guid fileId);
    }
}
