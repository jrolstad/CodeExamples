using System.IO;
using Examples.Core.Files;

namespace FileSystem.Windows
{
    /// <summary>
    /// File System service around the windows file system
    /// </summary>
    public class WindowsFileSystemService : IFileSystem
    {
        /// <summary>
        /// Creates a directory for the given path
        /// </summary>
        /// <param name="filePath"></param>
        public virtual void CreateDirectoryForFile(string filePath)
        {
            var directoryName = Path.GetDirectoryName(filePath);
            if (directoryName != null && !Directory.Exists(directoryName))
                Directory.CreateDirectory(directoryName);
        }

        /// <summary>
        /// Gets a stream to a file at the given path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public virtual StreamWriter GetWriteFileStream(string path)
        {
            return File.CreateText(path);
        }
    }
}
