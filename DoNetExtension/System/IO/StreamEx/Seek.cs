using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace System.IO
{
    public partial class StreamEx
    {
        #region Type Related

        /// <summary>
        /// Skips a <see cref="Boolean"/> value (seeks forward 1 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipBoolean(this Stream stream)
        {
            stream.Seek(sizeof(Boolean), SeekOrigin.Current);
        }

        /// <summary>
        /// Seeks backward a <see cref="Boolean"/> value (seeks backward 1 byte) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackBoolean(this Stream stream)
        {
            stream.Seek(-sizeof(Boolean), SeekOrigin.Current);
        }

        /// <summary>
        /// Skips <see cref="Boolean"/> values (seeks forward 1 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        /// <param name="count">The number of values to skip.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipBoolean(this Stream stream, int count)
        {
            stream.Seek(sizeof(Boolean) * count, SeekOrigin.Current);
        }

        /// <summary>
        /// Seeks backward <see cref="Boolean"/> values (seeks backward 1 byte) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        /// <param name="count">The number of values to skip.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackBoolean(this Stream stream, int count)
        {
            stream.Seek(-sizeof(Boolean) * count, SeekOrigin.Current);
        }

        /// <summary>
        /// Skips a <see cref="Byte"/> value (seeks forward 1 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipByte(this Stream stream)
        {
            stream.Seek(sizeof(Byte), SeekOrigin.Current);
        }

        /// <summary>
        /// Seeks backward a <see cref="Byte"/> value (seeks backward 1 byte) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackByte(this Stream stream)
        {
            stream.Seek(-sizeof(Byte), SeekOrigin.Current);
        }

        /// <summary>
        /// Skips <see cref="Byte"/> values (seeks forward 1 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        /// <param name="count">The number of values to skip.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipByte(this Stream stream, int count)
        {
            stream.Seek(sizeof(Byte) * count, SeekOrigin.Current);
        }

        /// <summary>
        /// Seeks backward <see cref="Byte"/> values (seeks backward 1 byte) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        /// <param name="count">The number of values to skip.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackByte(this Stream stream, int count)
        {
            stream.Seek(-sizeof(Byte) * count, SeekOrigin.Current);
        }

        /// <summary>
        /// Skips a <see cref="SByte"/> value (seeks forward 1 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipSByte(this Stream stream)
        {
            stream.Seek(sizeof(SByte), SeekOrigin.Current);
        }

        /// <summary>
        /// Seeks backward a <see cref="SByte"/> value (seeks backward 1 byte) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackSByte(this Stream stream)
        {
            stream.Seek(-sizeof(SByte), SeekOrigin.Current);
        }

        /// <summary>
        /// Skips <see cref="SByte"/> values (seeks forward 1 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        /// <param name="count">The number of values to skip.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipSByte(this Stream stream, int count)
        {
            stream.Seek(sizeof(SByte) * count, SeekOrigin.Current);
        }

        /// <summary>
        /// Seeks backward <see cref="SByte"/> values (seeks backward 1 byte) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        /// <param name="count">The number of values to skip.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackSByte(this Stream stream, int count)
        {
            stream.Seek(-sizeof(SByte) * count, SeekOrigin.Current);
        }

        /// <summary>
        /// Skips a <see cref="Int16"/> value (seeks forward 2 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipInt16(this Stream stream)
        {
            stream.Seek(sizeof(Int16), SeekOrigin.Current);
        }

        /// <summary>
        /// Seeks backward a <see cref="Int16"/> value (seeks backward 2 byte) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackInt16(this Stream stream)
        {
            stream.Seek(-sizeof(Int16), SeekOrigin.Current);
        }

        /// <summary>
        /// Skips <see cref="Int16"/> values (seeks forward 2 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        /// <param name="count">The number of values to skip.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipInt16(this Stream stream, int count)
        {
            stream.Seek(sizeof(Int16) * count, SeekOrigin.Current);
        }

        /// <summary>
        /// Seeks backward <see cref="Int16"/> values (seeks backward 2 byte) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        /// <param name="count">The number of values to skip.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackInt16(this Stream stream, int count)
        {
            stream.Seek(-sizeof(Int16) * count, SeekOrigin.Current);
        }

        /// <summary>
        /// Skips a <see cref="Int32"/> value (seeks forward 4 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipInt32(this Stream stream)
        {
            stream.Seek(sizeof(Int32), SeekOrigin.Current);
        }

        /// <summary>
        /// Seeks backward a <see cref="Int32"/> value (seeks backward 4 byte) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackInt32(this Stream stream)
        {
            stream.Seek(-sizeof(Int32), SeekOrigin.Current);
        }

        /// <summary>
        /// Skips <see cref="Int32"/> values (seeks forward 4 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        /// <param name="count">The number of values to skip.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipInt32(this Stream stream, int count)
        {
            stream.Seek(sizeof(Int32) * count, SeekOrigin.Current);
        }

        /// <summary>
        /// Seeks backward <see cref="Int32"/> values (seeks backward 4 byte) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        /// <param name="count">The number of values to skip.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackInt32(this Stream stream, int count)
        {
            stream.Seek(-sizeof(Int32) * count, SeekOrigin.Current);
        }

        /// <summary>
        /// Skips a <see cref="Int64"/> value (seeks forward 8 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipInt64(this Stream stream)
        {
            stream.Seek(sizeof(Int64), SeekOrigin.Current);
        }

        /// <summary>
        /// Seeks backward a <see cref="Int64"/> value (seeks backward 8 byte) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackInt64(this Stream stream)
        {
            stream.Seek(-sizeof(Int64), SeekOrigin.Current);
        }

        /// <summary>
        /// Skips <see cref="Int64"/> values (seeks forward 8 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        /// <param name="count">The number of values to skip.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipInt64(this Stream stream, int count)
        {
            stream.Seek(sizeof(Int64) * count, SeekOrigin.Current);
        }

        /// <summary>
        /// Seeks backward <see cref="Int64"/> values (seeks backward 8 byte) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        /// <param name="count">The number of values to skip.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackInt64(this Stream stream, int count)
        {
            stream.Seek(-sizeof(Int64) * count, SeekOrigin.Current);
        }

        /// <summary>
        /// Skips a <see cref="UInt16"/> value (seeks forward 2 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipUInt16(this Stream stream)
        {
            stream.Seek(sizeof(UInt16), SeekOrigin.Current);
        }

        /// <summary>
        /// Seeks backward a <see cref="UInt16"/> value (seeks backward 2 byte) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackUInt16(this Stream stream)
        {
            stream.Seek(-sizeof(UInt16), SeekOrigin.Current);
        }

        /// <summary>
        /// Skips <see cref="UInt16"/> values (seeks forward 2 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        /// <param name="count">The number of values to skip.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipUInt16(this Stream stream, int count)
        {
            stream.Seek(sizeof(UInt16) * count, SeekOrigin.Current);
        }

        /// <summary>
        /// Seeks backward <see cref="UInt16"/> values (seeks backward 2 byte) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        /// <param name="count">The number of values to skip.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackUInt16(this Stream stream, int count)
        {
            stream.Seek(-sizeof(UInt16) * count, SeekOrigin.Current);
        }

        /// <summary>
        /// Skips a <see cref="UInt32"/> value (seeks forward 4 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipUInt32(this Stream stream)
        {
            stream.Seek(sizeof(UInt32), SeekOrigin.Current);
        }

        /// <summary>
        /// Seeks backward a <see cref="UInt32"/> value (seeks backward 4 byte) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackUInt32(this Stream stream)
        {
            stream.Seek(-sizeof(UInt32), SeekOrigin.Current);
        }

        /// <summary>
        /// Skips <see cref="UInt32"/> values (seeks forward 4 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        /// <param name="count">The number of values to skip.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipUInt32(this Stream stream, int count)
        {
            stream.Seek(sizeof(UInt32) * count, SeekOrigin.Current);
        }

        /// <summary>
        /// Seeks backward <see cref="UInt32"/> values (seeks backward 4 byte) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        /// <param name="count">The number of values to skip.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackUInt32(this Stream stream, int count)
        {
            stream.Seek(-sizeof(UInt32) * count, SeekOrigin.Current);
        }

        /// <summary>
        /// Skips a <see cref="UInt64"/> value (seeks forward 8 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipUInt64(this Stream stream)
        {
            stream.Seek(sizeof(UInt64), SeekOrigin.Current);
        }

        /// <summary>
        /// Seeks backward a <see cref="UInt64"/> value (seeks backward 8 byte) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackUInt64(this Stream stream)
        {
            stream.Seek(-sizeof(UInt64), SeekOrigin.Current);
        }

        /// <summary>
        /// Skips <see cref="UInt64"/> values (seeks forward 8 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        /// <param name="count">The number of values to skip.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipUInt64(this Stream stream, int count)
        {
            stream.Seek(sizeof(UInt64) * count, SeekOrigin.Current);
        }

        /// <summary>
        /// Seeks backward <see cref="UInt64"/> values (seeks backward 8 byte) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        /// <param name="count">The number of values to skip.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackUInt64(this Stream stream, int count)
        {
            stream.Seek(-sizeof(UInt64) * count, SeekOrigin.Current);
        }

        /// <summary>
        /// Skips a <see cref="Single"/> value (seeks forward 4 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipSingle(this Stream stream)
        {
            stream.Seek(sizeof(Single), SeekOrigin.Current);
        }

        /// <summary>
        /// Seeks backward a <see cref="Single"/> value (seeks backward 4 byte) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackSingle(this Stream stream)
        {
            stream.Seek(-sizeof(Single), SeekOrigin.Current);
        }

        /// <summary>
        /// Skips <see cref="Single"/> values (seeks forward 4 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        /// <param name="count">The number of values to skip.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipSingle(this Stream stream, int count)
        {
            stream.Seek(sizeof(Single) * count, SeekOrigin.Current);
        }

        /// <summary>
        /// Seeks backward <see cref="Single"/> values (seeks backward 4 byte) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        /// <param name="count">The number of values to skip.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackSingle(this Stream stream, int count)
        {
            stream.Seek(-sizeof(Single) * count, SeekOrigin.Current);
        }

        /// <summary>
        /// Skips a <see cref="Double"/> value (seeks forward 8 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipDouble(this Stream stream)
        {
            stream.Seek(sizeof(Double), SeekOrigin.Current);
        }

        /// <summary>
        /// Seeks backward a <see cref="Double"/> value (seeks backward 8 byte) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackDouble(this Stream stream)
        {
            stream.Seek(-sizeof(Double), SeekOrigin.Current);
        }

        /// <summary>
        /// Skips <see cref="Double"/> values (seeks forward 8 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        /// <param name="count">The number of values to skip.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipDouble(this Stream stream, int count)
        {
            stream.Seek(sizeof(Double) * count, SeekOrigin.Current);
        }

        /// <summary>
        /// Seeks backward <see cref="Double"/> values (seeks backward 8 byte) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        /// <param name="count">The number of values to skip.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackDouble(this Stream stream, int count)
        {
            stream.Seek(-sizeof(Double) * count, SeekOrigin.Current);
        }

        //! Datetime does not have predefined size.

        #endregion

        #region Common

        /// <summary>
        /// Advances within the current stream with reference to the current position.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        /// <param name="length">The number of bytes to advance.</param>
        public static void SeekForward(this Stream stream, long length)
        {
            stream.Seek(length, SeekOrigin.Current);
        }

        /// <summary>
        /// Goes back within the current stream with reference to the current position.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        /// <param name="length">The number of bytes to go back.</param>
        public static void SeekBackward(this Stream stream, long length)
        {
            stream.Seek(-length, SeekOrigin.Current);
        }

        /// <summary>
        /// Sets the position within the current stream to the beginning.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        public static void SeekToBegin(this Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
        }

        /// <summary>
        /// Sets the position within the current stream to the end.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        public static void SeekToEnd(this Stream stream)
        {
            stream.Seek(0, SeekOrigin.End);
        }

        /// <summary>
        /// Sets the position within the current stream with reference to the beginning.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        public static void SeekTo(this Stream stream, long position)
        {
            stream.Seek(position, SeekOrigin.Begin);
        }

        #endregion
    }
}
