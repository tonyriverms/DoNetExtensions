﻿using System.Collections.Generic;
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
        /// Writes an array of System.Char integers to the current stream.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="array">An array of System.Char integers.</param>
        /// <param name="startIndex">A position in the array/list where the writing starts.</param>
        /// <param name="count">The number of integers to write to the stream.
        /// <para>!!! Note this number should be no larger than the number of integers from <paramref name="startIndex" /> to the end of the array.</para>
        /// </param>
        public unsafe static void WriteChars(this Stream stream, Char[] array, int startIndex, int count)
        {
            WriteChars(stream, array, startIndex, count, new byte[count * sizeof(Char)]);
        }

        /// <summary>
        /// Writes an array of System.Char integers to the current stream using the specified buffer.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="array">An array of System.Char integers.</param>
        /// <param name="startIndex">A position in the array/list where the writing starts.</param>
        /// <param name="count">The number of integers to write to the stream.
        /// <para>!!! Note this number should be no larger than the number of integers from <paramref name="startIndex" /> to the end of the array.</para></param>
        /// <param name="buffer">A byte array used to temporarily store data to write.</param>
        public static void WriteChars(this Stream stream, Char[] array, int startIndex, int count, byte[] buffer)
        {
            Buffer.BlockCopy(array, 0, buffer, 0, sizeof(Char) * count);
            stream.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// Writes a list of System.Char integers to the current stream using the specified buffer.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="array">A list of System.Char integers.</param>
        /// <param name="startIndex">A position in the list where the writing starts.</param>
        /// <param name="count">The number of integers to be written into the current stream.
        /// <para>!!! Note this number should be no larger than the number of integers from <paramref name="startIndex" /> to the end of the array.</para></param>
        /// <param name="buffer">A byte array used to temporarily store data to write.</param>
        public unsafe static void WriteChars(this Stream stream, IList<Char> array, int startIndex, int count)
        {
            WriteChars(stream, array, startIndex, count, new byte[sizeof(Char) * count]);
        }

        /// <summary>
        /// Writes a list of System.Char integers to the current stream using the specified buffer.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="array">A list of System.Char integers.</param>
        /// <param name="startIndex">A position in the list where the writing starts.</param>
        /// <param name="count">The number of integers to be written into the current stream.
        /// <para>!!! Note this number should be no larger than the number of integers from <paramref name="startIndex" /> to the end of the array.</para></param>
        /// <param name="buffer">A byte array used to temporarily store data to write.</param>
        public unsafe static void WriteChars(this Stream stream, IList<Char> list, int startIndex, int count, byte[] buffer)
        {
            fixed (byte* ptr = buffer) 
            {
                Char* iptr2 = (Char*)ptr;
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
        /// Writes an array of System.Char integers to the current stream.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="list">An array of System.Char integers.</param>
        /// <param name="startIndex">A position in the array where the writing starts.</param>
        public unsafe static void WriteChars(this Stream stream, Char[] array, int startIndex = 0)
        {
            var count = array.Length - startIndex;
            WriteChars(stream, array, startIndex, count);
        }

        /// <summary>
        /// Writes a list of System.Char integers to the current stream using the specified buffer.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="list">An array of System.Char integers.</param>
        /// <param name="startIndex">A position in the array where the writing starts.</param>
        /// <param name="buffer">A byte array used to temporarily store data to write.</param>
        public unsafe static void WriteChars(this Stream stream, Char[] array, byte[] buffer, int startIndex = 0)
        {
            var count = array.Length - startIndex;
            WriteChars(stream, array, startIndex, count, buffer);
        }

        /// <summary>
        /// Writes a list of System.Char integers to the current stream.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="list">A list of System.Char integers.</param>
        /// <param name="startIndex">A position in the list where the writing starts.</param>
        public unsafe static void WriteChars(this Stream stream, IList<Char> list, int startIndex = 0)
        {
            var count = list.Count - startIndex;
            WriteChars(stream, list, startIndex, count);
        }

        /// <summary>
        /// Writes a list of System.Char integers to the current stream using the specified buffer.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="list">A list of System.Char integers.</param>
        /// <param name="startIndex">A position in the list where the writing starts.</param>
        /// <param name="buffer">A byte array used to temporarily store data to write.</param>
        public unsafe static void WriteChars(this Stream stream, IList<Char> list, byte[] buffer, int startIndex = 0)
        {
            var count = list.Count - startIndex;
            WriteChars(stream, list, startIndex, count, buffer);
        }

        #endregion

        #region Uncounted Read

        /// <summary>
        /// Reads a System.Char integer array from this stream.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <param name="length">The length of the array.</param>
        /// <returns>A System.Char integer array read from the stream.</returns>
        public unsafe static Char[] ReadChars(this Stream stream, int length)
        {
            var data = new Char[length];
            var dataLen = length * sizeof(Char);
            byte[] buffer = stream.ReadBytes(dataLen);

            fixed (Char* lptr = data)
            {
                var bptr = (byte*)lptr;
                Marshal.Copy(buffer, 0, (IntPtr)bptr, dataLen);
            }

            return data;
        }

        /// <summary>
        /// Reads a System.Char integer array from this stream using the specified buffer.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <param name="length">The length of the array.</param>
        /// <param name="buffer">A byte array used to temporarily store data read from the stream.</param>
        /// <returns>A System.Char integer array read from the stream.</returns>
        public unsafe static Char[] ReadChars(this Stream stream, int length, byte[] buffer)
        {
            var data = new Char[length];
            var dataLen = length * sizeof(Char);
            stream.Read(buffer, dataLen);

            fixed (Char* lptr = data)
            {
                var bptr = (byte*)lptr;
                Marshal.Copy(buffer, 0, (IntPtr)bptr, dataLen);
            }

            return data;
        }

        #endregion

        #region Counted Write

        /// <summary>
        /// Writes an array of System.Char integers to the current stream. You may write an empty array or a <c>null</c> reference.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="array">The byte array to write.</param>
        /// <param name="validityCheck">Indicates whether to write a check code before the byte array. This check code will help detect corrupted data.</param>
        /// <returns>The number of bytes actually written to the stream.</returns>
        public static int WriteCharArray(this Stream stream, Char[] array, bool validityCheck = true)
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
            stream.WriteChars(array);
            return metaLen + arrLen * sizeof(Char);
        }

        /// <summary>
        /// Writes an array of System.Char integers to the current stream using the specified buffer. You may write an empty array or a <c>null</c> reference.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="array">The byte array to write.</param>
        /// <param name="validityCheck">Indicates whether to write a check code before the byte array. This check code will help detect corrupted data.</param>
        /// <param name="buffer">A byte array used to temporarily store data to write.</param>
        /// <returns>The number of bytes actually written to the stream.</returns>
        public static int WriteCharArray(this Stream stream, Char[] array, byte[] buffer, bool validityCheck = true)
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
            stream.WriteChars(array, buffer);
            return metaLen + arrLen * sizeof(Char);
        }

        #endregion

        #region Counted Read

        /// <summary>
        /// Reads a System.Char integer array from this stream. The method does not require an argument specifying the length of the array; <seealso cref="ReadChars"/>.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <param name="validityCheck">Set this parameter <c>true</c> if there is a check code before the array to prevent data corruption; otherwise, set this <c>false</c>.</param>
        /// <returns>
        /// The System.Char array read from the stream.
        /// </returns>
        /// <exception cref="System.IO.InvalidDataException">Raises if data in the stream is corrupted.</exception>
        public static Char[] ReadCharArray(this Stream stream, bool validityCheck = true)
        {
            if (!validityCheck || stream.Check((long)37))
            {
                var len = stream.ReadInt32();
                if (len == 0) return null;
                else if (len < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
                return stream.ReadChars(len);
            }
            else throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
        }

        /// <summary>
        /// Reads a System.Char integer array from this stream. The method does not require an argument specifying the length of the array; <seealso cref="ReadChars"/>.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <param name="validityCheck">Set this parameter <c>true</c> if there is a check code before the array to prevent data corruption; otherwise, set this <c>false</c>.</param>
        /// <param name="buffer">A byte array used to temporarily store data read from the stream.</param>
        /// <returns>
        /// The System.Char array read from the stream.
        /// </returns>
        /// <exception cref="System.IO.InvalidDataException">Raises if data in the stream is corrupted.</exception>
        public static Char[] ReadCharArray(this Stream stream, byte[] buffer, bool validityCheck = true)
        {
            if (!validityCheck || stream.Check((long)37))
            {
                var len = stream.ReadInt32(buffer);
                if (len == 0) return null;
                else if (len < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
                return stream.ReadChars(len, buffer);
            }
            else throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
        }

        /// <summary>
        /// Reads a System.Char integer array from this stream into the specified buffer. This method avoids an additional data copy to enchance performance.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <param name="validityCheck">Set this parameter <c>true</c> if there is a check code before the array to prevent data corruption; otherwise, set this <c>false</c>.</param>
        /// <param name="buffer">A byte array used to store data read from the stream. You may later get a Char pointer of this array for fast iteration.</param>
        /// <returns>
        /// true if the array read from the stream is not empty; otherwise, false.
        /// </returns>
        /// <exception cref="System.IO.InvalidDataException">Raises if data in the stream is corrupted.</exception>
        public static bool ReadCharArrayToBuffer(this Stream stream, byte[] buffer, bool validityCheck = true)
        {
            if (!validityCheck || stream.Check((long)37))
            {
                var len = stream.ReadInt32(buffer);
                if (len == 0) return false;
                else if (len < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
                stream.Read(buffer, 0, len * sizeof(Char));
                return true;
            }
            else throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
        }

        #endregion
    }
}
