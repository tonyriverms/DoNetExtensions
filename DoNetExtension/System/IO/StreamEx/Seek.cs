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
        /// Skips a byte value (seeks forward 1 byte) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipByte(this Stream stream)
        {
            stream.Seek(sizeof(byte), SeekOrigin.Current);
        }

        /// <summary>
        /// Skips a Boolean value (seeks forward 1 byte) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipBoolean(this Stream stream)
        {
            stream.Seek(sizeof(byte), SeekOrigin.Current);
        }

        /// <summary>
        /// Skips a System.Int16 value (seeks forward 2 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipInt16(this Stream stream)
        {
            stream.Seek(sizeof(Int16), SeekOrigin.Current);
        }

        /// <summary>
        /// Skips a System.UInt16 value (seeks forward 2 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipUInt16(this Stream stream)
        {
            stream.Seek(sizeof(UInt16), SeekOrigin.Current);
        }

        /// <summary>
        /// Skips a System.Int32 value (seeks forward 4 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipInt32(this Stream stream)
        {
            stream.Seek(sizeof(Int32), SeekOrigin.Current);
        }

        /// <summary>
        /// Skips a System.UInt32 value (seeks forward 4 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipUInt32(this Stream stream)
        {
            stream.Seek(sizeof(UInt32), SeekOrigin.Current);
        }

        /// <summary>
        /// Skips a System.Int64 value (seeks forward 8 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipInt64(this Stream stream)
        {
            stream.Seek(sizeof(Int64), SeekOrigin.Current);
        }

        /// <summary>
        /// Skips a System.UInt64 value (seeks forward 8 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipUInt64(this Stream stream)
        {
            stream.Seek(sizeof(UInt64), SeekOrigin.Current);
        }

        /// <summary>
        /// Skips a System.Single value (seeks forward 4 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipSingle(this Stream stream)
        {
            stream.Seek(sizeof(Single), SeekOrigin.Current);
        }

        /// <summary>
        /// Skips a System.Char value (seeks forward 2 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipChar(this Stream stream)
        {
            stream.Seek(sizeof(Char), SeekOrigin.Current);
        }

        /// <summary>
        /// Skips a System.Double value (seeks forward 8 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SkipDouble(this Stream stream)
        {
            stream.Seek(sizeof(Double), SeekOrigin.Current);
        }

        /// <summary>
        /// Jumps back a byte value (seeks backward 1 byte) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackByte(this Stream stream)
        {
            stream.Seek(-sizeof(byte), SeekOrigin.Current);
        }

        /// <summary>
        /// Jumps back a Boolean value (seeks backward 1 byte) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackBoolean(this Stream stream)
        {
            stream.Seek(-sizeof(byte), SeekOrigin.Current);
        }

        /// <summary>
        /// Jumps back a System.Int16 value (seeks backward 2 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackInt16(this Stream stream)
        {
            stream.Seek(-sizeof(Int16), SeekOrigin.Current);
        }

        /// <summary>
        /// Jumps back a System.UInt16 value (seeks backward 2 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackUInt16(this Stream stream)
        {
            stream.Seek(-sizeof(UInt16), SeekOrigin.Current);
        }

        /// <summary>
        /// Jumps back a System.Int32 value (seeks backward 4 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackInt32(this Stream stream)
        {
            stream.Seek(-sizeof(Int32), SeekOrigin.Current);
        }

        /// <summary>
        /// Jumps back a System.UInt32 value (seeks backward 4 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackUInt32(this Stream stream)
        {
            stream.Seek(-sizeof(UInt32), SeekOrigin.Current);
        }

        /// <summary>
        /// Jumps back a System.Int64 value (seeks backward 8 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackInt64(this Stream stream)
        {
            stream.Seek(-sizeof(Int64), SeekOrigin.Current);
        }

        /// <summary>
        /// Jumps back a System.UInt64 value (seeks backward 8 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackUInt64(this Stream stream)
        {
            stream.Seek(-sizeof(UInt64), SeekOrigin.Current);
        }

        /// <summary>
        /// Jumps back a System.Single value (seeks backward 4 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackSingle(this Stream stream)
        {
            stream.Seek(-sizeof(Single), SeekOrigin.Current);
        }

        /// <summary>
        /// Jumps back a System.Double value (seeks backward 8 bytes) in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BackDouble(this Stream stream)
        {
            stream.Seek(-sizeof(Double), SeekOrigin.Current);
        }

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
