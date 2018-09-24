using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DoNetExtension.System.IO;

namespace System.IO
{
    public partial class StreamEx
    {
        #region Int32 Write

        /// <summary>
        /// Writes a System.Int32 value to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.Int32 value.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInt32(this Stream stream, Int32 value)
        {
            WriteInt32(stream, value, new byte[sizeof(Int32)]);
        }

        /// <summary>
        /// Writes a System.Int32 value to the stream using the specified buffer. Use this method if performance is critical.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.Int32 value.</param>
        /// <param name="buffer">A byte array used to temporarily store the <paramref name="value"/>.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void WriteInt32(this Stream stream, Int32 value, byte[] buffer)
        {
            fixed (byte* numRef = buffer)
            {
                *((Int32*)numRef) = value;
            }
            stream.Write(buffer, 0, sizeof(Int32));
        }

        /// <summary>
        /// Writes a specified number of rightmost bytes of the System.Int32 value to the stream.
        /// <para>** For example, the rightmost 3 bytes of integer 111 is 111, 0, 0.</para>
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.Int32 value.</param>
        /// <param name="size">The number of bytes to write to the stream.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Raises when the value of <paramref name="size"/> is larger than 4 or smaller than 1.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInt32(this Stream stream, Int32 value, int size)
        {
            WriteInt32(stream, value, new byte[sizeof(Int32)], size);
        }

        /// <summary>
        /// Writes a specified number of rightmost bytes of the System.Int32 value to the stream using the specified buffer. Use this method if performance is critical.
        /// <para>** For example, the rightmost 3 bytes of integer 111 is 111, 0, 0.</para>
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.Int32 value.</param>
        /// <param name="buffer">A byte array used to temporarily store the <paramref name="value"/>.</param>
        /// <param name="size">The number of bytes to write to the stream.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Raises when the value of <paramref name="size" /> is larger than 4 or smaller than 1.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void WriteInt32(this Stream stream, Int32 value, byte[] buffer, int size)
        {
            if (size > sizeof(Int32) || size < 1) throw new ArgumentOutOfRangeException("size");
            fixed (byte* numRef = buffer)
            {
                *((Int32*)numRef) = value;
            }
            stream.Write(buffer, 0, size);
        }
        
        #endregion

        #region Int32 Read

        /// <summary>
        /// Reads a System.Int32 value from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>The System.Int32 value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int32 ReadInt32(this Stream stream)
        {
            return ReadInt32(stream, new byte[sizeof(Int32)]);
        }

        /// <summary>
        /// Reads a System.Int32 value from the stream using the specified buffer.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="buffer">A byte array used to temporarily store the bytes read.</param>
        /// <returns>
        /// The System.Int32 value.
        /// </returns>
        /// <exception cref="System.IO.InvalidDataException">Raises when the number of bytes actually read from stream is not 4.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int32 ReadInt32(this Stream stream, byte[] buffer)
        {
            var i = stream.Read(buffer, 0, sizeof(Int32));
            if (i != sizeof(Int32)) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
            return BitConverter.ToInt32(buffer, 0);
        }

        /// <summary>
        /// Reads a specified number of bytes from the stream and converts it to a System.Int32 value.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="size">The number of byte to read.</param>
        /// <returns>The System.Int32 value converted from the bytes read.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int32 ReadInt32(this Stream stream, int size)
        {
            return ReadInt32(stream, new byte[sizeof(Int32)], size);
        }

        /// <summary>
        /// Reads a specified number of bytes from the stream, using the specified buffer, and converts it to a System.Int32 value.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="buffer">A byte array used to temporarily store the bytes read.</param>
        /// <param name="size">The number of byte to read.</param>
        /// <returns>
        /// The System.Int32 value converted from the bytes read.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Raises when the value of <paramref name="size" /> is larger than 4 or smaller than 1.</exception>
        /// <exception cref="System.IO.InvalidDataException">Raises when the number of bytes actually read from stream does not equal <paramref name="size"/>.</exception>
        public static Int32 ReadInt32(this Stream stream, byte[] buffer, int size)
        {
            if (size > sizeof(Int32) || size < 1) throw new ArgumentOutOfRangeException("size");
            switch (size)
            {
                case 4: return ReadInt32(stream, buffer);
                case 3: return ReadInt24(stream, buffer);
                case 2: return (Int32)ReadInt16(stream, buffer);
                case 1: return (Int32)ReadSByte(stream);
                default: throw new ArgumentOutOfRangeException("size");
            }
        }

        #endregion

        #region UInt32 Write

        /// <summary>
        /// Writes a System.UInt32 value to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.UInt32 value.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteUInt32(this Stream stream, UInt32 value)
        {
            WriteUInt32(stream, value, new byte[sizeof(UInt32)]);
        }

        /// <summary>
        /// Writes a System.UInt32 value to the stream using the specified buffer. Use this method if performance is critical.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.UInt32 value.</param>
        /// <param name="buffer">A byte array used to temporarily store the <paramref name="value"/>.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void WriteUInt32(this Stream stream, UInt32 value, byte[] buffer)
        {
            fixed (byte* numRef = buffer)
            {
                *((UInt32*)numRef) = value;
            }
            stream.Write(buffer, 0, sizeof(UInt32));
        }

        /// <summary>
        /// Writes a specified number of rightmost bytes of the System.UInt32 value to the stream.
        /// <para>** For example, the rightmost 3 bytes of integer 111 is 111, 0, 0.</para>
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.UInt32 value.</param>
        /// <param name="size">The number of bytes to write to the stream.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Raises when the value of <paramref name="size"/> is larger than 4 or smaller than 1.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteUInt32(this Stream stream, UInt32 value, int size)
        {
            WriteUInt32(stream, value, new byte[sizeof(UInt32)], size);
        }

        /// <summary>
        /// Writes a specified number of rightmost bytes of the System.UInt32 value to the stream using the specified buffer. Use this method if performance is critical.
        /// <para>** For example, the rightmost 3 bytes of integer 111 is 111, 0, 0.</para>
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.UInt32 value.</param>
        /// <param name="buffer">A byte array used to temporarily store the <paramref name="value"/>.</param>
        /// <param name="size">The number of bytes to write to the stream.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Raises when the value of <paramref name="size" /> is larger than 4 or smaller than 1.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void WriteUInt32(this Stream stream, UInt32 value, byte[] buffer, int size)
        {
            if (size > sizeof(UInt32) || size < 1) throw new ArgumentOutOfRangeException("size");
            fixed (byte* numRef = buffer)
            {
                *((UInt32*)numRef) = value;
            }
            stream.Write(buffer, 0, size);
        }

        #endregion

        #region UInt32 Read

        /// <summary>
        /// Reads a System.UInt32 value from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>The System.UInt32 value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt32 ReadUInt32(this Stream stream)
        {
            return ReadUInt32(stream, new byte[sizeof(UInt32)]);
        }

        /// <summary>
        /// Reads a System.UInt32 value from the stream using the specified buffer.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="buffer">A byte array used to temporarily store the bytes read.</param>
        /// <returns>
        /// The System.UInt32 value.
        /// </returns>
        /// <exception cref="System.IO.InvalidDataException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt32 ReadUInt32(this Stream stream, byte[] buffer)
        {
            var i = stream.Read(buffer, 0, sizeof(UInt32));
            if (i != sizeof(UInt32)) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
            return BitConverter.ToUInt32(buffer, 0);
        }

        /// <summary>
        /// Reads a specified number of bytes from the stream and converts it to a System.UInt32 value.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="size">The number of byte to read.</param>
        /// <returns>The System.UInt32 value converted from the bytes read.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt32 ReadUInt32(this Stream stream, int size)
        {
            return ReadUInt32(stream, new byte[sizeof(UInt32)], size);
        }

        /// <summary>
        /// Reads a specified number of bytes from the stream, using the specified buffer, and converts it to a System.UInt32 value.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="buffer">A byte array used to temporarily store the bytes read.</param>
        /// <param name="size">The number of byte to read.</param>
        /// <returns>
        /// The System.UInt32 value converted from the bytes read.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Raises when the value of <paramref name="size"/> is larger than 4 or smaller than 1.</exception>
        /// <exception cref="System.IO.InvalidDataException">Raises when the number of bytes actually read from stream does not equal <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt32 ReadUInt32(this Stream stream, byte[] buffer, int size)
        {
            if (size > sizeof(UInt32) || size < 1) throw new ArgumentOutOfRangeException("size");
            var c = stream.Read(buffer, 0, size);
            if (c == size) return BitConverter.ToUInt32(buffer, 0);
            else throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
        }

        #endregion

        #region Int24/UInt24 Write

        /// <summary>
        /// Writes the rightmost 3 bytes of the System.UInt32 value to the stream.
        /// <para>** For example, the rightmost 3 bytes of integer 111 is 111, 0, 0.</para>
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.UInt32 value.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void WriteInt24(this Stream stream, Int32 value)
        {
            WriteInt24(stream, value, new byte[sizeof(Int32)]);
        }

        /// <summary>
        /// Writes the rightmost 3 bytes of the System.UInt32 value to the stream using the specified buffer. Use this method if performance is critical.
        /// <para>** For example, the rightmost 3 bytes of integer 111 is 111, 0, 0.</para>
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.UInt32 value.</param>
        /// <param name="buffer">A byte array used to temporarily store the <paramref name="value"/>.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void WriteInt24(this Stream stream, Int32 value, byte[] buffer)
        {
            fixed (byte* numRef = buffer)
            {
                *((Int32*)numRef) = value;
            }
            stream.Write(buffer, 0, 3);
        }

        /// <summary>
        /// Writes the rightmost 3 bytes of the System.UUInt32 value to the stream.
        /// <para>** For example, the rightmost 3 bytes of integer 111 is 111, 0, 0.</para>
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.UUInt32 value.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void WriteUInt24(this Stream stream, UInt32 value)
        {
            WriteUInt24(stream, value, new byte[sizeof(UInt32)]);
        }

        /// <summary>
        /// Writes the rightmost 3 bytes of the System.UUInt32 value to the stream using the specified buffer. Use this method if performance is critical.
        /// <para>** For example, the rightmost 3 bytes of UInteger 111 is 111, 0, 0.</para>
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.UUInt32 value.</param>
        /// <param name="buffer">A byte array used to temporarily store the <paramref name="value"/>.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void WriteUInt24(this Stream stream, UInt32 value, byte[] buffer)
        {
            fixed (byte* numRef = buffer)
            {
                *((UInt32*)numRef) = value;
            }
            stream.Write(buffer, 0, 3);
        }

        #endregion

        #region Int24/UInt24 Read

        /// <summary>
        /// Reads 6 bytes from the stream and converts it to a System.Int64 value.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns> The System.Int64 value converted from the bytes read.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static Int32 ReadInt24(this Stream stream)
        {
            var buffer = new byte[sizeof(Int32)];
            stream.Read(buffer, 0, 3);
            fixed (byte* bptr = buffer)
            {
                var negative = bptr[2].GetBit(7);
                var ptr = (UInt32*)bptr;
                if (negative) return -(Int32)~((*ptr | 0xFF000000) - 1);
                else return (Int32)(*ptr);
            }
        }


        /// <summary>
        /// Reads 6 bytes from the stream, using the specified buffer, and converts it to a System.UInt32 value.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="buffer">A byte array, of size no smaller than 8, used to temporarily store the bytes read.</param>
        /// <returns>
        /// The System.Int64 value converted from the bytes read.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static Int32 ReadInt24(this Stream stream, byte[] buffer)
        {
            stream.Read(buffer, 0, 3);
            fixed (byte* bptr = buffer)
            {
                var negative = bptr[2].GetBit(7);
                var ptr = (UInt32*)bptr;
                if (negative) return -(Int32)~((*ptr | 0xFF000000) - 1);
                else return (Int32)(*ptr & 0x00FFFFFF);
            }
        }

        /// <summary>
        /// Reads 6 bytes from the stream and converts it to a System.UInt64 value.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns> The System.UInt64 value converted from the bytes read.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static UInt32 ReadUInt24(this Stream stream)
        {
            var buffer = new byte[sizeof(UInt32)];
            stream.Read(buffer, 0, 3);
            fixed (byte* bptr = buffer)
            {
                return *(UInt32*)bptr;
            }
        }

        /// <summary>
        /// Reads 3 bytes from the stream, using the specified buffer, and converts it to a System.UInt32 value.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="buffer">A byte array, of size no smaller than 8, used to temporarily store the bytes read.</param>
        /// <returns>
        /// The System.UInt64 value converted from the bytes read.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static UInt32 ReadUInt24(this Stream stream, byte[] buffer)
        {
            stream.Read(buffer, 0, 3);
            fixed (byte* bptr = buffer)
            {
                return *(UInt32*)bptr & 0x00FFFFFF;
            }
        }

        #endregion
    }

}
