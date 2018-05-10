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
        #region Int64 Write

        /// <summary>
        /// Writes a <see cref="System.Int64"/> value to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The <see cref="System.Int64"/> value.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInt64(this Stream stream, Int64 value)
        {
            WriteInt64(stream, value, new byte[sizeof(Int64)]);
        }

        /// <summary>
        /// Writes the nullable int64.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The nullable <see cref="System.Int64"/> value.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Throws when <paramref name="value"/> is equal to <see cref="Int64.MinValue"/>.</exception>
        public static void WriteNullableInt64(this Stream stream, Int64? value)
        {
            if (value == null) stream.WriteInt64(Int64.MinValue);
            else if (value == Int64.MinValue) throw new ArgumentOutOfRangeException(nameof(value));
            else stream.WriteInt64(value.Value);
        }

        /// <summary>
        /// Writes a <see cref="System.Int64"/> value to the stream using the specified buffer. Use this method if performance is critical.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The <see cref="System.Int64"/> value.</param>
        /// <param name="buffer">A byte array used to temporarily store the <paramref name="value"/>.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void WriteInt64(this Stream stream, Int64 value, byte[] buffer)
        {
            fixed (byte* numRef = buffer)
            {
                *((Int64*)numRef) = value;
            }
            stream.Write(buffer, 0, sizeof(Int64));
        }

        /// <summary>
        /// Writes a specified number of rightmost bytes of the <see cref="System.Int64"/> value to the stream.
        /// <para>** For example, the rightmost 3 bytes of integer 111 is 111, 0, 0.</para>
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The <see cref="System.Int64"/> value.</param>
        /// <param name="size">The number of bytes to write to the stream.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Raises when the value of <paramref name="size"/> is larger than 8 or smaller than 1.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInt64(this Stream stream, Int64 value, int size)
        {
            WriteInt64(stream, value, new byte[sizeof(Int64)], size);
        }

        /// <summary>
        /// Writes a specified number of rightmost bytes of the <see cref="System.Int64"/> value to the stream using the specified buffer. Use this method if performance is critical.
        /// <para>** For example, the rightmost 3 bytes of integer 111 is 111, 0, 0.</para>
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The <see cref="System.Int64"/> value.</param>
        /// <param name="buffer">A byte array used to temporarily store the <paramref name="value"/>.</param>
        /// <param name="size">The number of bytes to write to the stream.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Raises when the value of <paramref name="size" /> is larger than 8 or smaller than 1.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void WriteInt64(this Stream stream, Int64 value, byte[] buffer, int size)
        {
            if (size > sizeof(Int64) || size < 1) throw new ArgumentOutOfRangeException("size");
            fixed (byte* numRef = buffer)
            {
                *((Int64*)numRef) = value;
            }
            stream.Write(buffer, 0, size);
        }

        #endregion

        #region Int64 Read

        /// <summary>
        /// Reads a <see cref="System.Int64"/> value from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>The <see cref="System.Int64"/> value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int64 ReadInt64(this Stream stream)
        {
            return ReadInt64(stream, new byte[sizeof(Int64)]);
        }

        /// <summary>
        /// Reads a nullable <see cref="System.Int64"/> value from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>The nullable <see cref="System.Int64"/> value.</returns>
        public static Int64? ReadNullableInt64(this Stream stream)
        {
            var value = ReadInt64(stream);
            if (value == Int64.MinValue) return null;
            else return value;
        }

        /// <summary>
        /// Reads a <see cref="System.Int64"/> value from the stream using the specified buffer.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="buffer">A byte array used to temporarily store the bytes read.</param>
        /// <returns>
        /// The <see cref="System.Int64"/> value.
        /// </returns>
        /// <exception cref="System.IO.InvalidDataException">Raises when the number of bytes actually read from stream is not 8.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int64 ReadInt64(this Stream stream, byte[] buffer)
        {
            var i = stream.Read(buffer, 0, sizeof(Int64));
            if (i != sizeof(Int64)) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
            return BitConverter.ToInt64(buffer, 0);
        }

        /// <summary>
        /// Reads a specified number of bytes from the stream and converts it to a <see cref="System.Int64"/> value.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="size">The number of byte to read.</param>
        /// <returns>The <see cref="System.Int64"/> value converted from the bytes read.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int64 ReadInt64(this Stream stream, int size)
        {
            return ReadInt64(stream, new byte[sizeof(Int64)], size);
        }

        /// <summary>
        /// Reads a specified number of bytes from the stream, using the specified buffer, and converts it to a <see cref="System.Int64"/> value.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="buffer">A byte array used to temporarily store the bytes read.</param>
        /// <param name="size">The number of byte to read.</param>
        /// <returns>
        /// The <see cref="System.Int64"/> value converted from the bytes read.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Raises when the number of bytes actually read from stream is not 8.</exception>
        /// <exception cref="System.IO.InvalidDataException">Raises when the number of bytes actually read from stream does not equal <paramref name="size"/>.</exception>
        public static Int64 ReadInt64(this Stream stream, byte[] buffer, int size)
        {
            if (size > sizeof(Int64) || size < 1) throw new ArgumentOutOfRangeException("size");
            switch (size)
            {
                case 8: return ReadInt64(stream, buffer);
                case 7: return ReadInt56(stream, buffer);
                case 6: return ReadInt48(stream, buffer);
                case 5: return ReadInt40(stream, buffer);
                case 4: return ReadInt32(stream, buffer);
                case 3: return ReadInt24(stream, buffer);
                case 2: return (Int32)ReadInt16(stream, buffer);
                case 1: return (Int32)ReadSByte(stream);
                default: throw new ArgumentOutOfRangeException("size");
            }
        }

        #endregion

        #region UInt64 Write

        /// <summary>
        /// Writes a System.UInt64 value to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.UInt64 value.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteUInt64(this Stream stream, UInt64 value)
        {
            WriteUInt64(stream, value, new byte[sizeof(UInt64)]);
        }

        /// <summary>
        /// Writes a System.UInt64 value to the stream using the specified buffer. Use this method if performance is critical.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.UInt64 value.</param>
        /// <param name="buffer">A byte array used to temporarily store the <paramref name="value"/>.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void WriteUInt64(this Stream stream, UInt64 value, byte[] buffer)
        {
            fixed (byte* numRef = buffer)
            {
                *((UInt64*)numRef) = value;
            }
            stream.Write(buffer, 0, sizeof(UInt64));
        }

        /// <summary>
        /// Writes a specified number of rightmost bytes of the System.UInt64 value to the stream.
        /// <para>** For example, the rightmost 3 bytes of integer 111 is 111, 0, 0.</para>
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.UInt64 value.</param>
        /// <param name="size">The number of bytes to write to the stream.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Raises when the value of <paramref name="size"/> is larger than 8 or smaller than 1.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteUInt64(this Stream stream, UInt64 value, int size)
        {
            WriteUInt64(stream, value, new byte[sizeof(UInt64)], size);
        }

        /// <summary>
        /// Writes a specified number of rightmost bytes of the System.UInt64 value to the stream using the specified buffer. Use this method if performance is critical.
        /// <para>** For example, the rightmost 3 bytes of integer 111 is 111, 0, 0.</para>
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.UInt64 value.</param>
        /// <param name="buffer">A byte array used to temporarily store the <paramref name="value"/>.</param>
        /// <param name="size">The number of bytes to write to the stream.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Raises when the value of <paramref name="size" /> is larger than 8 or smaller than 1.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void WriteUInt64(this Stream stream, UInt64 value, byte[] buffer, int size)
        {
            if (size > sizeof(UInt64) || size < 1) throw new ArgumentOutOfRangeException("size");
            fixed (byte* numRef = buffer)
            {
                *((UInt64*)numRef) = value;
            }
            stream.Write(buffer, 0, size);
        }

        #endregion

        #region UInt64 Read

        /// <summary>
        /// Reads a System.UInt64 value from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>The System.UInt64 value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt64 ReadUInt64(this Stream stream)
        {
            return BitConverter.ToUInt64(stream.ReadBytes(sizeof(UInt64)), 0);
        }

        /// <summary>
        /// Reads a System.UInt64 value from the stream using the specified buffer.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="buffer">A byte array used to temporarily store the bytes read.</param>
        /// <returns>
        /// The System.UInt64 value.
        /// </returns>
        /// <exception cref="System.IO.InvalidDataException">Raises when the number of bytes actually read from stream is not 8.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt64 ReadUInt64(this Stream stream, byte[] buffer)
        {
            var i = stream.Read(buffer, 0, sizeof(UInt64));
            if (i != sizeof(UInt64)) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
            return BitConverter.ToUInt64(buffer, 0);
        }

        /// <summary>
        /// Reads a specified number of bytes from the stream and converts it to a System.UInt64 value.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="size">The number of byte to read.</param>
        /// <returns>The System.UInt64 value converted from the bytes read.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt64 ReadUInt64(this Stream stream, int size)
        {
            return ReadUInt64(stream, new byte[sizeof(UInt64)], size);
        }

        /// <summary>
        /// Reads a specified number of bytes from the stream, using the specified buffer, and converts it to a System.UInt64 value.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="buffer">A byte array used to temporarily store the bytes read.</param>
        /// <param name="size">The number of byte to read.</param>
        /// <returns>
        /// The System.UInt64 value converted from the bytes read.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Raises when the number of bytes actually read from stream is not 8.</exception>
        /// <exception cref="System.IO.InvalidDataException">Raises when the number of bytes actually read from stream does not equal <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt64 ReadUInt64(this Stream stream, byte[] buffer, int size)
        {
            if (size > sizeof(UInt64) || size < 1) throw new ArgumentOutOfRangeException("size");
            var c = stream.Read(buffer, 0, size);
            if (c == size) return BitConverter.ToUInt64(buffer, 0);
            else throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
        }

        #endregion

        #region Int56/UInt56 Write

        /// <summary>
        /// Writes the rightmost 7 bytes of the System.UInt64 value to the stream.
        /// <para>** For example, the rightmost 3 bytes of integer 111 is 111, 0, 0.</para>
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.UInt64 value.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void WriteInt56(this Stream stream, Int64 value)
        {
            WriteInt56(stream, value, new byte[sizeof(Int64)]);
        }

        /// <summary>
        /// Writes the rightmost 7 bytes of the System.UInt64 value to the stream using the specified buffer. Use this method if performance is critical.
        /// <para>** For example, the rightmost 3 bytes of integer 111 is 111, 0, 0.</para>
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.UInt64 value.</param>
        /// <param name="buffer">A byte array used to temporarily store the <paramref name="value"/>.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void WriteInt56(this Stream stream, Int64 value, byte[] buffer)
        {
            fixed (byte* numRef = buffer)
            {
                *((Int64*)numRef) = value;
            }
            stream.Write(buffer, 0, 7);
        }

        /// <summary>
        /// Writes the rightmost 7 bytes of the System.UInt64 value to the stream.
        /// <para>** For example, the rightmost 3 bytes of integer 111 is 111, 0, 0.</para>
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.UInt64 value.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void WriteUInt56(this Stream stream, UInt64 value)
        {
            WriteUInt56(stream, value, new byte[sizeof(UInt64)]);
        }

        /// <summary>
        /// Writes the rightmost 7 bytes of the System.UInt64 value to the stream using the specified buffer. Use this method if performance is critical.
        /// <para>** For example, the rightmost 3 bytes of UInteger 111 is 111, 0, 0.</para>
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.UInt64 value.</param>
        /// <param name="buffer">A byte array used to temporarily store the <paramref name="value"/>.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void WriteUInt56(this Stream stream, UInt64 value, byte[] buffer)
        {
            fixed (byte* numRef = buffer)
            {
                *((UInt64*)numRef) = value;
            }
            stream.Write(buffer, 0, 7);
        }

        #endregion

        #region Int56/UInt56 Read

        /// <summary>
        /// Reads 6 bytes from the stream and converts it to a <see cref="System.Int64"/> value.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns> The <see cref="System.Int64"/> value converted from the bytes read.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static Int64 ReadInt56(this Stream stream)
        {
            var buffer = new byte[sizeof(Int64)];
            stream.Read(buffer, 0, 7);
            fixed (byte* bptr = buffer)
            {
                var negative = bptr[6].GetBit(7);
                var ptr = (UInt64*)bptr;
                if (negative) return -(Int64)~((*ptr | 0xFF00000000000000) - 1);
                else return (Int64)(*ptr);
            }
        }


        /// <summary>
        /// Reads 6 bytes from the stream, using the specified buffer, and converts it to a System.UInt32 value.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="buffer">A byte array, of size no smaller than 8, used to temporarily store the bytes read.</param>
        /// <returns>
        /// The <see cref="System.Int64"/> value converted from the bytes read.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static Int64 ReadInt56(this Stream stream, byte[] buffer)
        {
            stream.Read(buffer, 0, 7);
            fixed (byte* bptr = buffer)
            {
                var negative = bptr[6].GetBit(7);
                var ptr = (UInt64*)bptr;
                if (negative) return -(Int64)~((*ptr | 0xFF00000000000000) - 1);
                else return (Int64)(*ptr & 0x00FFFFFFFFFFFFFF);
            }
        }

        /// <summary>
        /// Reads 6 bytes from the stream and converts it to a System.UInt64 value.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns> The System.UInt64 value converted from the bytes read.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static UInt64 ReadUInt56(this Stream stream)
        {
            var buffer = new byte[sizeof(UInt64)];
            stream.Read(buffer, 0, 7);
            fixed (byte* bptr = buffer)
            {
                return *(UInt64*)bptr;
            }
        }

        /// <summary>
        /// Reads 6 bytes from the stream, using the specified buffer, and converts it to a System.UUInt32 value.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="buffer">A byte array, of size no smaller than 8, used to temporarily store the bytes read.</param>
        /// <returns>
        /// The System.UInt64 value converted from the bytes read.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static UInt64 ReadUInt56(this Stream stream, byte[] buffer)
        {
            stream.Read(buffer, 0, 7);
            fixed (byte* bptr = buffer)
            {
                return *(UInt64*)bptr & 0x00FFFFFFFFFFFFFF;
            }
        }

        #endregion

        #region Int48/UInt48 Write

        /// <summary>
        /// Writes the rightmost 6 bytes of the System.UInt64 value to the stream.
        /// <para>** For example, the rightmost 3 bytes of integer 111 is 111, 0, 0.</para>
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.UInt64 value.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void WriteInt48(this Stream stream, Int64 value)
        {
            WriteInt48(stream, value, new byte[sizeof(Int64)]);
        }

        /// <summary>
        /// Writes the rightmost 6 bytes of the System.UInt64 value to the stream using the specified buffer. Use this method if performance is critical.
        /// <para>** For example, the rightmost 3 bytes of integer 111 is 111, 0, 0.</para>
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.UInt64 value.</param>
        /// <param name="buffer">A byte array used to temporarily store the <paramref name="value"/>.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void WriteInt48(this Stream stream, Int64 value, byte[] buffer)
        {
            fixed (byte* numRef = buffer)
            {
                *((Int64*)numRef) = value;
            }
            stream.Write(buffer, 0, 6);
        }

        /// <summary>
        /// Writes the rightmost 6 bytes of the System.UInt64 value to the stream.
        /// <para>** For example, the rightmost 3 bytes of integer 111 is 111, 0, 0.</para>
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.UInt64 value.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void WriteUInt48(this Stream stream, UInt64 value)
        {
            WriteUInt48(stream, value, new byte[sizeof(Int64)]);
        }

        /// <summary>
        /// Writes the rightmost 6 bytes of the System.UInt64 value to the stream using the specified buffer. Use this method if performance is critical.
        /// <para>** For example, the rightmost 3 bytes of UInteger 111 is 111, 0, 0.</para>
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.UInt64 value.</param>
        /// <param name="buffer">A byte array used to temporarily store the <paramref name="value"/>.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void WriteUInt48(this Stream stream, UInt64 value, byte[] buffer)
        {
            fixed (byte* numRef = buffer)
            {
                *((UInt64*)numRef) = value;
            }
            stream.Write(buffer, 0, 6);
        }

        #endregion

        #region Int48/UInt48 Read

        /// <summary>
        /// Reads 6 bytes from the stream and converts it to a <see cref="System.Int64"/> value.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns> The <see cref="System.Int64"/> value converted from the bytes read.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static Int64 ReadInt48(this Stream stream)
        {
            var buffer = new byte[sizeof(Int64)];
            stream.Read(buffer, 0, 6);
            fixed (byte* bptr = buffer)
            {
                var negative = bptr[5].GetBit(7);
                var ptr = (UInt64*)bptr;
                if (negative) return -(Int64)~((*ptr | 0xFFFF000000000000) - 1);
                else return (Int64)(*ptr);
            }
        }


        /// <summary>
        /// Reads 6 bytes from the stream, using the specified buffer, and converts it to a System.UInt32 value.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="buffer">A byte array, of size no smaller than 8, used to temporarily store the bytes read.</param>
        /// <returns>
        /// The <see cref="System.Int64"/> value converted from the bytes read.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static Int64 ReadInt48(this Stream stream, byte[] buffer)
        {
            stream.Read(buffer, 0, 6);
            fixed (byte* bptr = buffer)
            {
                var negative = bptr[5].GetBit(7);
                var ptr = (UInt64*)bptr;
                if (negative) return -(Int64)~((*ptr | 0xFFFF000000000000) - 1);
                else return (Int64)(*ptr & 0x0000FFFFFFFFFFFF);
            }
        }

        /// <summary>
        /// Reads 6 bytes from the stream and converts it to a System.UInt64 value.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns> The System.UInt64 value converted from the bytes read.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static UInt64 ReadUInt48(this Stream stream)
        {
            var buffer = new byte[sizeof(UInt64)];
            stream.Read(buffer, 0, 6);
            fixed (byte* bptr = buffer)
            {
                return *(UInt64*)bptr;
            }
        }

        /// <summary>
        /// Reads 6 bytes from the stream, using the specified buffer, and converts it to a System.UInt64 value.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="buffer">A byte array, of size no smaller than 8, used to temporarily store the bytes read.</param>
        /// <returns>
        /// The System.UInt64 value converted from the bytes read.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static UInt64 ReadUInt48(this Stream stream, byte[] buffer)
        {
            stream.Read(buffer, 0, 6);
            fixed (byte* bptr = buffer)
            {
                return *(UInt64*)bptr & 0x0000FFFFFFFFFFFF;
            }
        }

        #endregion

        #region Int40/UInt40 Write

        /// <summary>
        /// Writes the rightmost 5 bytes of the System.UInt64 value to the stream.
        /// <para>** For example, the rightmost 3 bytes of integer 111 is 111, 0, 0.</para>
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.UInt64 value.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void WriteInt40(this Stream stream, Int64 value)
        {
            WriteInt40(stream, value, new byte[sizeof(Int64)]);
        }

        /// <summary>
        /// Writes the rightmost 5 bytes of the System.UInt64 value to the stream using the specified buffer. Use this method if performance is critical.
        /// <para>** For example, the rightmost 3 bytes of integer 111 is 111, 0, 0.</para>
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.UInt64 value.</param>
        /// <param name="buffer">A byte array used to temporarily store the <paramref name="value"/>.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void WriteInt40(this Stream stream, Int64 value, byte[] buffer)
        {
            fixed (byte* numRef = buffer)
            {
                *((Int64*)numRef) = value;
            }
            stream.Write(buffer, 0, 5);
        }

        /// <summary>
        /// Writes the rightmost 5 bytes of the System.UInt64 value to the stream.
        /// <para>** For example, the rightmost 3 bytes of integer 111 is 111, 0, 0.</para>
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.UInt64 value.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void WriteUInt40(this Stream stream, UInt64 value)
        {
            WriteUInt40(stream, value, new byte[sizeof(UInt64)]);
        }

        /// <summary>
        /// Writes the rightmost 5 bytes of the System.UInt64 value to the stream using the specified buffer. Use this method if performance is critical.
        /// <para>** For example, the rightmost 3 bytes of UInteger 111 is 111, 0, 0.</para>
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.UInt64 value.</param>
        /// <param name="buffer">A byte array used to temporarily store the <paramref name="value"/>.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void WriteUInt40(this Stream stream, UInt64 value, byte[] buffer)
        {
            fixed (byte* numRef = buffer)
            {
                *((UInt64*)numRef) = value;
            }
            stream.Write(buffer, 0, 5);
        }

        #endregion

        #region Int40/UInt40 Read

        /// <summary>
        /// Reads 5 bytes from the stream and converts it to a <see cref="System.Int64"/> value.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns> The <see cref="System.Int64"/> value converted from the bytes read.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static Int64 ReadInt40(this Stream stream)
        {
            var buffer = new byte[sizeof(Int64)];
            stream.Read(buffer, 0, 5);
            fixed (byte* bptr = buffer)
            {
                var negative = bptr[4].GetBit(7);
                var ptr = (UInt64*)bptr;
                if (negative) return -(Int64)~((*ptr | 0xFFFFFF0000000000) - 1);
                else return (Int64)(*ptr);
            }
        }


        /// <summary>
        /// Reads 5 bytes from the stream, using the specified buffer, and converts it to a System.UInt32 value.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="buffer">A byte array, of size no smaller than 8, used to temporarily store the bytes read.</param>
        /// <returns>
        /// The <see cref="System.Int64"/> value converted from the bytes read.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static Int64 ReadInt40(this Stream stream, byte[] buffer)
        {
            stream.Read(buffer, 0, 5);
            fixed (byte* bptr = buffer)
            {
                var negative = bptr[4].GetBit(7);
                var ptr = (UInt64*)bptr;
                if (negative) return -(Int64)~((*ptr | 0xFFFFFF0000000000) - 1);
                else return (Int64)(*ptr & 0x000000FFFFFFFFFF);
            }
        }

        /// <summary>
        /// Reads 5 bytes from the stream and converts it to a System.UInt64 value.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns> The System.UInt64 value converted from the bytes read.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static UInt64 ReadUInt40(this Stream stream)
        {
            var buffer = new byte[sizeof(UInt64)];
            stream.Read(buffer, 0, 5);
            fixed (byte* bptr = buffer)
            {
                return *(UInt64*)bptr;
            }
        }

        /// <summary>
        /// Reads 5 bytes from the stream, using the specified buffer, and converts it to a System.UInt64 value.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="buffer">A byte array, of size no smaller than 8, used to temporarily store the bytes read.</param>
        /// <returns>
        /// The System.UInt64 value converted from the bytes read.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static UInt64 ReadUInt40(this Stream stream, byte[] buffer)
        {
            stream.Read(buffer, 0, 5);
            fixed (byte* bptr = buffer)
            {
                return *(UInt64*)bptr & 0x000000FFFFFFFFFF;
            }
        }

        #endregion
    }
}
