using Microsoft.AspNetCore.StaticFiles;

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
            Console.WriteLine($"Saving file to: {fullPath}"); // Add logging here

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
    public FileSystemObject GetInfo(string relativePath)
    {
        string folderPath = Path.Combine(AppContext.BaseDirectory, relativePath);

        if (Directory.Exists(folderPath))
        {
            string[] files = Directory.GetFiles(folderPath);

            if (files.Length > 0)
            {
                string filePath = files[0]; 
                Console.WriteLine($"Arquivo encontrado: {filePath}");

                var fileInfo = new FileInfo(filePath);
                var provider = new FileExtensionContentTypeProvider();

                string mimeType;
                if (!provider.TryGetContentType(fileInfo.FullName, out mimeType))
                {
                    mimeType = "application/octet-stream";
                }

                var fileObject = new FileSystemObject
                {
                    Path = fileInfo.FullName,
                    FileName = fileInfo.Name,
                    CreatedAt = fileInfo.CreationTime,
                    ModifiedAt = fileInfo.LastWriteTime,
                    MimeType = mimeType
                };

                return fileObject;
            }
            else
            {
                throw new FileNotFoundException("Nenhum arquivo foi encontrado no diretório.");
            }
        }
        else
        {
            throw new DirectoryNotFoundException($"O diretório {folderPath} não foi encontrado.");
        }
    }

    public FileSystemObject Get(string path, bool loadContent)
    {
        path = Path.Combine(AppContext.BaseDirectory, path);
        try
        {
            var fileSystemObject = new FileSystemObject();

            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);
                if (files.Length > 0)
                {
                    string filePath = files[0]; 
                    var fileInfo = new FileInfo(filePath);

                    fileSystemObject.Path = fileInfo.FullName;
                    fileSystemObject.FileName = fileInfo.Name;
                    fileSystemObject.CreatedAt = fileInfo.CreationTime;
                    fileSystemObject.ModifiedAt = fileInfo.LastWriteTime;

                    if (loadContent)
                    {
                        fileSystemObject.Data = File.ReadAllBytes(filePath);
                    }
                }
                else
                {
                    throw new FileNotFoundException("Nenhum arquivo encontrado no diretório.");
                }
            }
            else if (File.Exists(path))
            {
                var fileInfo = new FileInfo(path);

                fileSystemObject.Path = fileInfo.FullName;
                fileSystemObject.FileName = fileInfo.Name;
                fileSystemObject.CreatedAt = fileInfo.CreationTime;
                fileSystemObject.ModifiedAt = fileInfo.LastWriteTime;

                if (loadContent)
                {
                    fileSystemObject.Data = File.ReadAllBytes(path);
                }
            }
            else
            {
                throw new FileNotFoundException($"O caminho '{path}' não existe.");
            }

            return fileSystemObject;
        }
        catch (Exception ex)
        {
            throw new IOException($"Erro ao carregar o arquivo: {ex.Message}", ex);
        }
    }

}
