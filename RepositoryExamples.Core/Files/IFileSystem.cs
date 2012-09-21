using System.IO;

namespace Examples.Core.Files
{
    /// <summary>
    /// Interface around the file system
    /// </summary>
    public interface IFileSystem
    {
        /// <summary>
        /// Creates a directory for the given path
        /// </summary>
        /// <param name="filePath"></param>
        void CreateDirectoryForFile(string filePath);

        /// <summary>
        /// Gets a stream to a file at the given path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        StreamWriter GetWriteFileStream(string path);
    }

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