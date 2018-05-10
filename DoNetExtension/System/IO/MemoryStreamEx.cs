using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.IO
{
    /// <summary>
    /// Provides IO methods for System.IO.MemoryStream class.
    /// </summary>
    public static class MemoryStreamEx
    {
        /// <summary>
        /// Writes all bytes in this memory stream to a file regardless its current position. 
        /// If this memeory stream is empty, an empty file will be created. 
        /// If the file already exists, it will be overwritten.
        /// </summary>
        /// <param name="ms">A <see cref="System.IO.MemoryStream"/>.</param>
        /// <param name="path">The path of the file to write.</param>
        public static void WriteAllBytesToFile(this MemoryStream ms, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                if (ms.Length != 0)
                    fs.WriteBytes(ms.ToArray());
            }
        }

        /// <summary>
        /// Appends all bytes in this memory stream to the end of a file regardless its current position.
        /// If this memeory stream is empty and the file does not exist, an empty file will be created.
        /// </summary>
        /// <param name="ms">A <see cref="System.IO.MemoryStream"/>.</param>
        /// <param name="path">The path of the file to append.</param>
        public static void AppendAllBytesToFile(this MemoryStream ms, string path)
        {
            if (ms.Length != 0)
            {
                using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
                {
                    fs.WriteBytes(ms.ToArray());
                }
            }
        }
    }
}
