namespace WebCar.Application.Application.Services
{
    public sealed class FileSystemObject
    {
        public string Filename => Path.GetFileName(FullPath);
        public string Folder => Path.GetDirectoryName(FullPath);
        public string FullPath { get; set; }
        public string Extension { get; set; }
        public string MimeType { get; set; }
        public string HashId { get; set; }
        public int Length { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
