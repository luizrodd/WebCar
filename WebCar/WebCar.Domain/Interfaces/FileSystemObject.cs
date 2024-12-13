namespace WebCar.Application.Application.Services;

public class FileSystemObject
{
    public string Path { get; set; }
    public string FileName { get; set; }
    public byte[] Data { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
}
