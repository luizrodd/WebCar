namespace WebCar.Application.Application.Services
{
    public interface IFileSystemManager
    {
        void Delete(string file);
        byte[] GetContent(string file);
        /// <summary>
        /// Get specified file from the file system.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <remarks>
        /// This method can only be called if the file was saved using the <see cref="Write(string, string, byte[])"/> method.
        /// </remarks>
        FileSystemInfo Get(string file);
        /// <summary>
        /// Get specified file from the file system.
        /// </summary>
        /// <remarks>
        /// This method can only be called if the file was saved using the <see cref="Write(string, string, byte[])"/> method.
        /// </remarks>
        FileSystemInfo Get(string file, bool onlyInfo);
        /// <summary>
        /// Saves the specified data to the file system.
        /// </summary>
        /// <param name="fullPath">The full path where the file will be saved. This must include the filename.</param>
        /// <param name="fileName">The name of the file to be saved. This parameter is necessary to generate the correct file name when downloading it.</param>
        /// <param name="data">The content of the file.</param>
        /// <example>
        /// To hide the filename in storage:
        /// Write("path/to/folder/231232-13213", "file.txt", data);
        ///
        /// To display the filename in storage:
        /// Write("path/to/folder/file.txt", "file.txt", data);
        /// </example>
        void Write(string fullPath, string fileName, byte[] data);
        string GetSASKey(string clientIP, int minutes, string filePath);
        bool IsSASKeySupported { get; }
    }

    public class FileSystemInfo(FileSystemObject info, byte[] data)
    {
        public FileSystemObject Info { get; } = info;
        public byte[] Data { get; } = data;
    }
}
