using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DoNetExtension.System.IO;

namespace System.IO
{
    public static partial class StreamEx
    {
        /// <summary>
        /// Writes a specified number of bytes to the stream.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="bytes">The bytes to write.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteBytes(this Stream stream, byte[] bytes)
        {
            stream.Write(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Writes a specified number of bytes at the beginning of the <paramref name="buffer" /> to the stream.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="buffer">An array of bytes.</param>
        /// <param name="count">The number of bytes at the beginning of the <paramref name="buffer" /> to write to the stream.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(this Stream stream, byte[] buffer, int count)
        {
            stream.Write(buffer, 0, count);
        }

        /// <summary>
        /// Reads all the remaining bytes after the current position of this stream.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <returns>A byte array storing the read bytes.</returns>
        public static byte[] ReadAllBytes(this Stream stream)
        {
            return stream.ReadBytes((Int32)(stream.Length - stream.Position));
        }

        /// <summary>
        /// Reads all bytes of another stream starting from its current position and writes all the read bytes into the current stream.
        /// </summary>
        /// <param name="stream">The current stream into which the bytes read from <paramref name="streamToRead" /> will be written.</param>
        /// <param name="streamToRead">Another stream to read.</param>
        /// <returns>The total number of bytes read from <paramref name="streamToRead"/>.</returns>
        public static long ReadFromStream(this Stream stream, Stream streamToRead)
        {
            int tmp;
            long byteCount = 0;
            while ((tmp = streamToRead.ReadByte()) != -1)
            {
                ++byteCount;
                stream.WriteByte((byte)tmp);
            }
            return byteCount;
        }

        /// <summary>
        /// Reads all bytes of another stream starting from its current position and writes all the read bytes into the current stream.
        /// </summary>
        /// <param name="stream">The current stream into which the bytes read from <paramref name="streamToRead" /> will be written.</param>
        /// <param name="streamToRead">Another stream to read.</param>
        /// <param name="buffer">A byte array serves as the reading buffer.</param>
        /// <returns>The total number of bytes read from <paramref name="streamToRead"/>.</returns>
        public static long ReadFromStream(this Stream stream, Stream streamToRead, byte[] buffer)
        {
            var bufferSize = buffer.Length;
            int tmp;
            long byteCount = 0;
            while((tmp = streamToRead.Read(buffer)) != 0)
            {
                byteCount += tmp;
                stream.Write(buffer, tmp);
            }

            return byteCount;
        }

        /// <summary>
        /// Reads all bytes of another stream starting from its current position and writes all the read bytes into the current stream.
        /// </summary>
        /// <param name="stream">The current stream into which the bytes read from <paramref name="streamToRead" /> will be written.</param>
        /// <param name="streamToRead">Another stream to read.</param>
        /// <param name="bufferSize">The size of the buffer that will be used for the reading process.</param>
        /// <returns>
        /// The total number of bytes read from <paramref name="streamToRead" />.
        /// </returns>
        public static long ReadFromStream(this Stream stream, Stream streamToRead, int bufferSize)
        {
            int tmp;
            long byteCount = 0;
            var buffer = new byte[bufferSize];
            while ((tmp = streamToRead.Read(buffer)) != 0)
            {
                byteCount += tmp;
                stream.Write(buffer, tmp);
            }

            return byteCount;
        }

        /// <summary>
        /// Copys all bytes since the current position of this stream into a new memeory stream.
        /// </summary>
        /// <param name="stream">The current stream of which the bytes after its current position will be copied to a newly created <see cref="System.IO.MemoryStream"/>.</param>
        /// <returns>A new <see cref="System.IO.MemoryStream"/> with bytes copied from the current stream.</returns>
        public static MemoryStream ToMemoryStream(this Stream stream)
        {
            var ms = new MemoryStream();
            ms.ReadFromStream(stream);
            ms.SeekToBegin();
            return ms;
        }

        /// <summary>
        /// Reads as many bytes as possible to fill the specified buffer.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <param name="buffer">A byte array storing the read bytes.</param>
        /// <returns>The number of byte actually read from the stream.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Read(this Stream stream, byte[] buffer)
        {
            var length = buffer.Length;
            return Read(stream, buffer, length);
        }

        /// <summary>
        /// Reads a specified number of bytes from the stream.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <param name="length">The length.</param>
        /// <returns>
        /// A byte array storing the read bytes.
        /// </returns>
        /// <exception cref="System.IO.InvalidDataException">Raises when the number of bytes actually read from stream is not exactly the same as <paramref name="length"/>.</exception>
        public static byte[] ReadBytes(this Stream stream, int length)
        {
            var buffer = new byte[length];
            var i = Read(stream, buffer, length);
            if (i != length) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
            return buffer;
        }

        /// <summary>
        /// Reads a specified number of bytes from the stream into the specified buffer.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <param name="buffer">The buffer to store byte read from the stream.</param>
        /// <param name="count">The count.</param>
        /// <returns>The number of byte actually read from the stream.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Read(this Stream stream, byte[] buffer, int count)
        {
            return stream.Read(buffer, 0, count);
        }

        /// <summary>
        /// Writes a byte array to this stream. You may write an empty array or a <c>null</c> reference.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="array">The byte array to write.</param>
        /// <param name="validityCheck">Indicates whether to write a check code before the byte array. This check code will help detect corrupted data.</param>
        /// <returns>The number of bytes actually written to the stream.</returns>
        public static int WriteByteArray(this Stream stream, byte[] array, bool validityCheck)
        {
            var metaLen = 4;
            if (validityCheck)
            {
                stream.WriteCheckCode((Int64)37);
                metaLen += 8;
            }

            if (array == null)
            {
                stream.WriteInt32(0);
                return metaLen;
            }

            var arrLen = array.Length;
            stream.WriteInt32(array.Length);
            stream.WriteBytes(array);
            return metaLen + arrLen;
        }

        /// <summary>
        /// Writes a byte array to this stream. You may write an empty array or a <c>null</c> reference.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="array">The byte array to write.</param>
        /// <returns>The number of bytes actually written to the stream.</returns>
        public static int WriteByteArray(this Stream stream, byte[] array)
        {
            var metaLen = 4;
            if (array == null)
            {
                stream.WriteInt32(0);
                return metaLen;
            }

            var arrLen = array.Length;
            stream.WriteInt32(array.Length);
            stream.WriteBytes(array);
            return metaLen + arrLen;
        }

        /// <summary>
        /// Reads a byte array from this stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck">Set this parameter <c>true</c> if there is a check code before the array to detect data corruption; otherwise, set this <c>false</c>.</param>
        /// <returns>
        /// The byte array read from the stream.
        /// </returns>
        /// <exception cref="System.IO.InvalidDataException">Raises if data in the stream is corrupted.</exception>
        public static byte[] ReadByteArray(this Stream stream, bool validityCheck)
        {
            if (!validityCheck || stream.Check((Int64)37))
            {
                var len = stream.ReadInt32();
                if (len == 0) return null;
                else if (len < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
                return stream.ReadBytes(len);
            }
            else throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
        }

        /// <summary>
        /// Reads a byte array from this stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>
        /// The byte array read from the stream.
        /// </returns>
        /// <exception cref="System.IO.InvalidDataException">Raises if data in the stream is corrupted.</exception>
        public static byte[] ReadByteArray(this Stream stream)
        {
            var len = stream.ReadInt32();
            if (len == 0) return null;
            else if (len < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
            return stream.ReadBytes(len);
        }

        /// <summary>
        /// Skips a byte array in this stream.
        /// </summary>
        /// <param name="stream">A stream.</param>
        /// <param name="validityCheck">Set this parameter <c>true</c> if there is a check code before the array to skip; otherwise, set this <c>false</c>.</param>
        /// <exception cref="System.IO.InvalidDataException">Raises if data in the stream is corrupted.</exception>
        public static void SkipByteArray(this Stream stream, bool validityCheck)
        {
            if (!validityCheck || stream.Check((Int64)37))
            {
                var len = stream.ReadInt32();
                if (len < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
                else if (len > 0) stream.SeekForward(len);
            }
            else throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
        }

        /// <summary>
        /// Skips a byte array in this stream.
        /// </summary>
        /// <param name="stream">A stream.</param>
        /// <exception cref="System.IO.InvalidDataException">Raises if data in the stream is corrupted.</exception>
        public static void SkipByteArray(this Stream stream)
        {
            var len = stream.ReadInt32();
            if (len < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
            else if (len > 0) stream.SeekForward(len);
        }
    }
}
