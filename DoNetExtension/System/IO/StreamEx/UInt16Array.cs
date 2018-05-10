using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DoNetExtension.System.IO;

namespace System.IO
{
    public static partial class StreamEx
    {
        #region Uncounted Write

        /// <summary>
        /// Writes an array of System.UInt16 integers to the current stream.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="array">An array of System.UInt16 integers.</param>
        /// <param name="startIndex">A position in the array/list where the writing starts.</param>
        /// <param name="count">The number of integers to write to the stream.
        /// <para>!!! Note this number should be no larger than the number of integers from <paramref name="startIndex" /> to the end of the array.</para>
        /// </param>
        public unsafe static void WriteUInt16s(this Stream stream, UInt16[] array, int startIndex, int count)
        {
            WriteUInt16s(stream, array, startIndex, count, new byte[count * sizeof(UInt16)]);
        }

        /// <summary>
        /// Writes an array of System.UInt16 integers to the current stream using the specified buffer.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="array">An array of System.UInt16 integers.</param>
        /// <param name="startIndex">A position in the array/list where the writing starts.</param>
        /// <param name="count">The number of integers to write to the stream.
        /// <para>!!! Note this number should be no larger than the number of integers from <paramref name="startIndex" /> to the end of the array.</para></param>
        /// <param name="buffer">A byte array used to temporarily store data to write.</param>
        public static void WriteUInt16s(this Stream stream, UInt16[] array, int startIndex, int count, byte[] buffer)
        {
            Buffer.BlockCopy(array, 0, buffer, 0, sizeof(UInt16) * count);
            stream.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// Writes a list of System.UInt16 integers to the current stream using the specified buffer.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="array">A list of System.UInt16 integers.</param>
        /// <param name="startIndex">A position in the list where the writing starts.</param>
        /// <param name="count">The number of integers to be written into the current stream.
        /// <para>!!! Note this number should be no larger than the number of integers from <paramref name="startIndex" /> to the end of the array.</para></param>
        /// <param name="buffer">A byte array used to temporarily store data to write.</param>
        public unsafe static void WriteUInt16s(this Stream stream, IList<UInt16> array, int startIndex, int count)
        {
            WriteUInt16s(stream, array, startIndex, count, new byte[sizeof(UInt16) * count]);
        }

        /// <summary>
        /// Writes a list of System.UInt16 integers to the current stream using the specified buffer.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="array">A list of System.UInt16 integers.</param>
        /// <param name="startIndex">A position in the list where the writing starts.</param>
        /// <param name="count">The number of integers to be written into the current stream.
        /// <para>!!! Note this number should be no larger than the number of integers from <paramref name="startIndex" /> to the end of the array.</para></param>
        /// <param name="buffer">A byte array used to temporarily store data to write.</param>
        public unsafe static void WriteUInt16s(this Stream stream, IList<UInt16> list, int startIndex, int count, byte[] buffer)
        {
            fixed (byte* ptr = buffer) 
            {
                UInt16* iptr2 = (UInt16*)ptr;
                for (int i = 0, j = startIndex; i < count; )
                {
                    iptr2[i] = list[j];
                    ++i;
                    ++j;
                }
            }

            stream.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// Writes an array of System.UInt16 integers to the current stream.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="list">An array of System.UInt16 integers.</param>
        /// <param name="startIndex">A position in the array where the writing starts.</param>
        public unsafe static void WriteUInt16s(this Stream stream, UInt16[] array, int startIndex = 0)
        {
            var count = array.Length - startIndex;
            WriteUInt16s(stream, array, startIndex, count);
        }

        /// <summary>
        /// Writes a list of System.UInt16 integers to the current stream using the specified buffer.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="list">An array of System.UInt16 integers.</param>
        /// <param name="startIndex">A position in the array where the writing starts.</param>
        /// <param name="buffer">A byte array used to temporarily store data to write.</param>
        public unsafe static void WriteUInt16s(this Stream stream, UInt16[] array, byte[] buffer, int startIndex = 0)
        {
            var count = array.Length - startIndex;
            WriteUInt16s(stream, array, startIndex, count, buffer);
        }

        /// <summary>
        /// Writes a list of System.UInt16 integers to the current stream.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="list">A list of System.UInt16 integers.</param>
        /// <param name="startIndex">A position in the list where the writing starts.</param>
        public unsafe static void WriteUInt16s(this Stream stream, IList<UInt16> list, int startIndex = 0)
        {
            var count = list.Count - startIndex;
            WriteUInt16s(stream, list, startIndex, count);
        }

        /// <summary>
        /// Writes a list of System.UInt16 integers to the current stream using the specified buffer.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="list">A list of System.UInt16 integers.</param>
        /// <param name="startIndex">A position in the list where the writing starts.</param>
        /// <param name="buffer">A byte array used to temporarily store data to write.</param>
        public unsafe static void WriteUInt16s(this Stream stream, IList<UInt16> list, byte[] buffer, int startIndex = 0)
        {
            var count = list.Count - startIndex;
            WriteUInt16s(stream, list, startIndex, count, buffer);
        }

        #endregion

        #region Uncounted Read

        /// <summary>
        /// Reads a System.UInt16 integer array from this stream.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <param name="length">The length of the array.</param>
        /// <returns>A System.UInt16 integer array read from the stream.</returns>
        public unsafe static UInt16[] ReadUInt16s(this Stream stream, int length)
        {
            var data = new UInt16[length];
            var dataLen = length * sizeof(UInt16);
            byte[] buffer = stream.ReadBytes(dataLen);

            fixed (UInt16* lptr = data)
            {
                var bptr = (byte*)lptr;
                Marshal.Copy(buffer, 0, (IntPtr)bptr, dataLen);
            }

            return data;
        }

        /// <summary>
        /// Reads a System.UInt16 integer array from this stream using the specified buffer.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <param name="length">The length of the array.</param>
        /// <param name="buffer">A byte array used to temporarily store data read from the stream.</param>
        /// <returns>A System.UInt16 integer array read from the stream.</returns>
        public unsafe static UInt16[] ReadUInt16s(this Stream stream, int length, byte[] buffer)
        {
            var data = new UInt16[length];
            var dataLen = length * sizeof(UInt16);
            stream.Read(buffer, dataLen);

            fixed (UInt16* lptr = data)
            {
                var bptr = (byte*)lptr;
                Marshal.Copy(buffer, 0, (IntPtr)bptr, dataLen);
            }

            return data;
        }

        #endregion

        #region Counted Write

        /// <summary>
        /// Writes an array of System.UInt16 integers to the current stream. You may write an empty array or a <c>null</c> reference.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="array">The byte array to write.</param>
        /// <param name="validityCheck">Indicates whether to write a check code before the byte array. This check code will help detect corrupted data.</param>
        /// <returns>The number of bytes actually written to the stream.</returns>
        public static int WriteUInt16Array(this Stream stream, UInt16[] array, bool validityCheck = true)
        {
            var metaLen = 4;
            if (validityCheck)
            {
                stream.WriteCheckCode((long)37);
                metaLen += 8;
            }
            if (array == null)
            {
                stream.WriteInt32(0);
                return metaLen;
            }

            var arrLen = array.Length;
            stream.WriteInt32(arrLen);
            stream.WriteUInt16s(array);
            return metaLen + arrLen * sizeof(UInt16);
        }

        /// <summary>
        /// Writes an array of System.UInt16 integers to the current stream using the specified buffer. You may write an empty array or a <c>null</c> reference.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="array">The byte array to write.</param>
        /// <param name="validityCheck">Indicates whether to write a check code before the byte array. This check code will help detect corrupted data.</param>
        /// <param name="buffer">A byte array used to temporarily store data to write.</param>
        /// <returns>The number of bytes actually written to the stream.</returns>
        public static int WriteUInt16Array(this Stream stream, UInt16[] array, byte[] buffer, bool validityCheck = true)
        {
            var metaLen = 4;
            if (validityCheck)
            {
                stream.WriteCheckCode((long)37);
                metaLen += 8;
            }
            if (array == null)
            {
                stream.WriteInt32(0, buffer);
                return metaLen;
            }

            var arrLen = array.Length;
            stream.WriteInt32(arrLen, buffer);
            stream.WriteUInt16s(array, buffer);
            return metaLen + arrLen * sizeof(UInt16);
        }

        #endregion

        #region Counted Read

        /// <summary>
        /// Reads a System.UInt16 integer array from this stream. The method does not require an argument specifying the length of the array; <seealso cref="ReadUInt16s"/>.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <param name="validityCheck">Set this parameter <c>true</c> if there is a check code before the array to prevent data corruption; otherwise, set this <c>false</c>.</param>
        /// <returns>
        /// The System.UInt16 array read from the stream.
        /// </returns>
        /// <exception cref="System.IO.InvalidDataException">Raises if data in the stream is corrupted.</exception>
        public static UInt16[] ReadUInt16Array(this Stream stream, bool validityCheck = true)
        {
            if (!validityCheck || stream.Check((long)37))
            {
                var len = stream.ReadInt32();
                if (len == 0) return null;
                else if (len < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
                return stream.ReadUInt16s(len);
            }
            else throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
        }

        /// <summary>
        /// Reads a System.UInt16 integer array from this stream. The method does not require an argument specifying the length of the array; <seealso cref="ReadUInt16s"/>.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <param name="validityCheck">Set this parameter <c>true</c> if there is a check code before the array to prevent data corruption; otherwise, set this <c>false</c>.</param>
        /// <param name="buffer">A byte array used to temporarily store data read from the stream.</param>
        /// <returns>
        /// The System.UInt16 array read from the stream.
        /// </returns>
        /// <exception cref="System.IO.InvalidDataException">Raises if data in the stream is corrupted.</exception>
        public static UInt16[] ReadUInt16Array(this Stream stream, byte[] buffer, bool validityCheck = true)
        {
            if (!validityCheck || stream.Check((long)37))
            {
                var len = stream.ReadInt32(buffer);
                if (len == 0) return null;
                else if (len < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
                return stream.ReadUInt16s(len, buffer);
            }
            else throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
        }

        /// <summary>
        /// Reads a System.UInt16 integer array from this stream into the specified buffer. This method avoids an additional data copy to enchance performance.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <param name="validityCheck">Set this parameter <c>true</c> if there is a check code before the array to prevent data corruption; otherwise, set this <c>false</c>.</param>
        /// <param name="buffer">A byte array used to store data read from the stream. You may later get a UInt16 pointer of this array for fast iteration.</param>
        /// <returns>
        /// true if the array read from the stream is not empty; otherwise, false.
        /// </returns>
        /// <exception cref="System.IO.InvalidDataException">Raises if data in the stream is corrupted.</exception>
        public static bool ReadUInt16ArrayToBuffer(this Stream stream, byte[] buffer, bool validityCheck = true)
        {
            if (!validityCheck || stream.Check((long)37))
            {
                var len = stream.ReadInt32(buffer);
                if (len == 0) return false;
                else if (len < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
                stream.Read(buffer, 0, len * sizeof(UInt16));
                return true;
            }
            else throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
        }

        #endregion
    }
}
