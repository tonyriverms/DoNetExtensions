using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.IO
{
    /// <summary>
    /// Provides a collection class that simplifies management of a variety of file streams.
    /// </summary>
    /// <typeparam name="TDictionary">The type of dictionary used to store and retrieve file streams. 
    /// This dictionary must use strings as keys and accept System.IO.FileStream objects as values.
    /// <para>You will retrieve each file stream by its ID (as a key in the dictionary).</para></typeparam>
    public class FileStreamCollection<TDictionary> : 
        IDisposable where TDictionary : IDictionary<string, FileStream>, new()
    {
        TDictionary _dict;
        FileMode _mode;
        FileAccess _access;
        FileShare _share;
        string _folder;

        /// <summary>
        /// Gets a value indicating how the operating system should open a file for every file stream in this collection.
        /// </summary>
        public FileMode Mode { get { return _mode; } }
        /// <summary>
        /// Gets a value indicating how the operating system should access a file for every file stream in this collection.
        /// </summary>
        public FileAccess Access { get { return _access; } }
        /// <summary>
        /// Gets a value indicating what kind of access all file streams can have to a file at the same time.
        /// </summary>
        public FileShare Share { get { return _share; } }

        /// <summary>
        /// Initializes a new instance of System.IO.FileStreamCollection class.
        /// </summary>
        /// <param name="rootFolder">The default root folder for all file streams.</param>
        /// <param name="mode">Specifies how the operating system should open a file for every file stream in this collection.</param>
        /// <param name="access">Specifies how the operating system should access a file for every file stream in this collection.</param>
        /// <param name="share">Specifies what kind of access all file streams can have to a file at the same time.</param>
        public FileStreamCollection(string rootFolder, 
            FileMode mode = FileMode.OpenOrCreate, 
            FileAccess access = FileAccess.ReadWrite, 
            FileShare share = FileShare.None)
        {
            _folder = rootFolder;
            _mode = mode;
            _access = access;
            _share = share;
            _dict = new TDictionary();
        }

        /// <summary>
        /// Opens a file stream of a file (specified by a string path) and adds the stream to this collection. The file ID is the file name.
        /// <para>For example, the ID of file "directory1\directory2\123.txt" is "123.txt".</para>
        /// </summary>
        /// <param name="filePath">The path of the file to be added into this collection.</param>
        /// <returns>The created System.FileStream object of the specified file.</returns>
        public FileStream AddFile(string filePath)
        {
            var fullPath = _folder + "\\" + filePath;
            var fileID = Path.GetFileName(fullPath);
            var fs = new FileStream(_folder + "\\" + filePath, _mode, _access, _share);
            _dict.Add(fileID, fs);
            return fs;
        }

        /// <summary>
        /// Opens a file stream of a file (specified by a string path) and adds the stream to this collection using specified file ID.
        /// <para>You may later retrieve the created file stream of the specified file by the file ID.</para>
        /// </summary>
        /// <param name="fileID">Specifies the ID of the file stream.
        /// <para>You may later retrieve the created file stream by this ID.</para></param>
        /// <param name="filePath">The path of the file to be added into this collection.</param>
        /// <returns>The created System.FileStream object of the specified file.</returns>
        public FileStream AddFile(string fileID, string filePath)
        {
            var fs = new FileStream(_folder + "\\" + filePath, _mode, _access, _share);
            _dict.Add(fileID, fs);
            return fs;
        }

        /// <summary>
        /// Opens a file stream of a file (specified by a file path represented by a series of strings) 
        /// and adds the stream to this collection using specified file ID.
        /// <para>You may later retrieve the created file stream of the specified file by the file ID.</para>
        /// </summary>
        /// <param name="fileID">Specifies the ID of the file stream.
        /// <para>You may later retrieve the created file stream by this ID.</para></param>
        /// <param name="filePath">The path of the file to be added into this collection.</param>
        /// <returns>The created System.FileStream object of the specified file.</returns>
        public FileStream AddFile(string fileID, string[] filePath)
        {
            var fullPath = _folder + "\\" + filePath.Concat('\\', false, true);
            var fs = new FileStream(fullPath, _mode, _access, _share);
            _dict.Add(fileID, fs);
            return fs;
        }

        /// <summary>
        /// Opens a file stream of a file (specified by a file path represented by a series of strings) 
        /// and adds the stream to this collection. The file ID is the file name.
        /// <para>For example, the ID of file "directory1\directory2\123.txt" is "123.txt".</para>
        /// </summary>
        /// <param name="filePath">The path of the file to be added into this collection.</param>
        /// <returns>The created System.FileStream object of the specified file.</returns>
        public FileStream AddFile(string[] filePath)
        {
            var fullPath = _folder + "\\" + filePath.Concat('\\', false, true);
            var fileID = Path.GetFileName(fullPath);
            var fs = new FileStream(fullPath, _mode, _access, _share);
            _dict.Add(fileID, fs);
            return fs;
        }

        /// <summary>
        /// Retrieves a file stream by its ID. 
        /// <para>**If there exists no file stream in this collection associated with the specified ID, a null reference will be returned.</para>
        /// </summary>
        /// <param name="fileID">The ID of the file stream to retrieve.</param>
        /// <returns>The file stream associated with the specified ID. If there exists no file stream in this collection associated with the specified ID, a null reference will be returned.</returns>
        public FileStream this[string fileID]
        {
            get
            {
                FileStream fs;
                _dict.TryGetValue(fileID, out fs);
                return fs;
            }
        }

        /// <summary>
        /// Replaces an existing file stream in this collection by another file stream.
        /// <para>!!!Note that the replaced file stream will not be closed by this method.</para>
        /// </summary>
        /// <param name="fileID">The ID of the file stream to be replaced.</param>
        /// <param name="newStream">The file stream to replace the existing one.</param>
        public void Replace(string fileID, FileStream newStream)
        {
            _dict[fileID] = newStream;
        }

        /// <summary>
        /// Closes an existing file stream in this collection and then replaces it by another file stream.
        /// </summary>
        /// <param name="fileID">The ID of the file stream to be closed and replaced.</param>
        /// <param name="newStream">The file stream to replace the existing one.</param>
        public void CloseAndReplace(string fileID, FileStream newStream)
        {
            Close(fileID);
            Replace(fileID, newStream);
        }

        /// <summary>
        /// Closes an existing file stream in this collection. 
        /// Optionally, you may remove the file stream after it is closed by setting the second parameter "remove" of this method to "true".
        /// </summary>
        /// <param name="fileID">The ID of the file stream to be closed.</param>
        /// <param name="remove">Specifies whether the file stream should be removed after it is closed.</param>
        public void Close(string fileID, bool remove = false)
        {
            var fs = this[fileID];
            if (fs != null)
            {
                if (remove)
                    _dict.Remove(fileID);
                try
                {
                    fs.Close();
                    fs.Dispose();
                }
                catch { }
            }
        }

        /// <summary>
        /// Disposes all file streams in this collection.
        /// </summary>
        public void Dispose()
        {
            foreach (var fs in _dict.Values)
            {
                try
                {
                    fs.Close();
                    fs.Dispose();
                }
                catch { }
            }
            _dict.Clear();
        }
    }
}
