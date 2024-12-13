namespace WebCar.Application.Application.Services;
public interface IFileSystemManager
{
    void Save(string path, string fileName, byte[] data);
    void Delete(string path);
    FileSystemObject GetInfo(string path);
    FileSystemObject Get(string path, bool loadContent);
}

public class FileSystemManager : IFileSystemManager
{
    public void Save(string path, string fileName, byte[] data)
    {
        try
        {
            var directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var fullPath = Path.Combine(path, fileName);

            File.WriteAllBytes(fullPath, data);
        }
        catch (Exception ex)
        {
            throw new IOException($"Erro ao salvar o arquivo: {ex.Message}", ex);
        }
    }

    public void Delete(string path)
    {
        try
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            else
            {
                throw new FileNotFoundException($"O arquivo em {path} não foi encontrado.");
            }
        }
        catch (Exception ex)
        {
            throw new IOException($"Erro ao excluir o arquivo: {ex.Message}", ex);
        }
    }

    public FileSystemObject GetInfo(string path)
    {
        try
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"O arquivo em {path} não foi encontrado.");
            }

            var fileInfo = new FileInfo(path);

            return new FileSystemObject
            {
                Path = fileInfo.FullName,
                FileName = fileInfo.Name,
                CreatedAt = fileInfo.CreationTime,
                ModifiedAt = fileInfo.LastWriteTime
            };
        }
        catch (Exception ex)
        {
            throw new IOException($"Erro ao obter informações do arquivo: {ex.Message}", ex);
        }
    }

    public FileSystemObject Get(string path, bool loadContent)
    {
        try
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"O arquivo em {path} não foi encontrado.");
            }

            var fileInfo = new FileInfo(path);

            var fileSystemObject = new FileSystemObject
            {
                Path = fileInfo.FullName,
                FileName = fileInfo.Name,
                CreatedAt = fileInfo.CreationTime,
                ModifiedAt = fileInfo.LastWriteTime
            };

            if (loadContent)
            {
                fileSystemObject.Data = File.ReadAllBytes(path);
            }

            return fileSystemObject;
        }
        catch (Exception ex)
        {
            throw new IOException($"Erro ao carregar o arquivo: {ex.Message}", ex);
        }
    }
}
