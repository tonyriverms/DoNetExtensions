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
        /// Begins an asynchronous write operation.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="buffer">The buffer to write data from.</param>
        /// <param name="callback">The callback to which a System.IO.AsyncStreamOperationState object is passed.</param>
        public static void BeginWrite(this Stream stream, byte[] buffer, AsyncCallback callback)
        {
            stream.BeginWrite(buffer, 0, buffer.Length, callback, new StreamAsyncState(stream, buffer));
        }

        /// <summary>
        /// Begins an asynchronous read operation.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="buffer">The buffer to read the data into.</param>
        /// <param name="callback">The callback to which a System.IO.AsyncStreamOperationState object is passed.</param>
        public static void BeginRead(this Stream stream, byte[] buffer, AsyncCallback callback)
        {
            stream.BeginRead(buffer, 0, buffer.Length, callback, new StreamAsyncState(stream, buffer));
        }
    }

    /// <summary>
    /// Provides the System.IO.Stream instance and the bytes for an asynchronous read-write process.
    /// ** This class cannot be initialized. It can only be obtained through property <c>AsyncState</c> of a <see cref="System.IAsyncState"/> instance.
    /// </summary>
    public class StreamAsyncState
    {
        Stream m_fs;
        byte[] m_buf;

        internal StreamAsyncState(Stream stream, byte[] buffer)
        {
            m_fs = stream;
            m_buf = buffer;
        }

        /// <summary>
        /// Gets the <see cref="Stream"/> the asynchronous read-write process. 
        /// </summary>
        public Stream Stream { get { return m_fs; } }

        /// <summary>
        /// Gets the bytes of the asynchronous read-write process.
        /// </summary>
        public byte[] Buffer { get { return m_buf; } }
    }
}
