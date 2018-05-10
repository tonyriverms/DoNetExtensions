using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.IO
{
    public static partial class StreamEx
    {
        /// <summary>
        /// Reads the bytes from the current stream and writes them to a file. 
        /// Copying begins at the current position in the current stream, 
        /// and does not reset the position of the current stream after the writing is complete. 
        /// If the file already exists, it will be overwritten.
        /// </summary>
        /// <param name="stream">A <see cref="System.IO.Stream"/>.</param>
        /// <param name="path">The path of the file to write.</param>
        public static void WriteToFile(this Stream stream, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(fs);
            }
        }

        /// <summary>
        /// Reads the bytes from the current stream and writes them to the end of a file. 
        /// Copying begins at the current position in the current stream, 
        /// and does not reset the position of the current stream after the writing is complete. 
        /// </summary>
        /// <param name="stream">A <see cref="System.IO.Stream"/>.</param>
        /// <param name="path">The path of the file to append.</param>
        public static void AppendToFile(this Stream stream, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
            {
                stream.CopyTo(fs);
            }
        }

        /// <summary>
        /// Reads the bytes from a file and writes them into this stream at its current position.
        /// After reading, the position of the current stream is not reset and remains where it is.
        /// </summary>
        /// <param name="stream">A <see cref="System.IO.Stream"/>.</param>
        /// <param name="path">The path of the file to read.</param>
        public static void ReadFromFile(this Stream stream, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                fs.CopyTo(stream);
            }
        }
    }
}
