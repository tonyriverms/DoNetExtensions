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
        #region SByte

        /// <summary>
        /// Writes a System.SByte value to this stream.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="value">The System.SByte value.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void WriteSByte(this Stream stream, SByte value)
        {
            byte* ptr = (byte*)&value;
            stream.WriteByte(ptr[0]);
        }

        /// <summary>
        /// Reads a System.SByte value from this stream.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <returns>A System.SByte value read from this stream.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static SByte ReadSByte(this Stream stream)
        {
            var value = (byte)stream.ReadByte();
            SByte* ptr = (SByte*)&value;
            return ptr[0];
        }

        #endregion

        #region Boolean

        /// <summary>
        /// Writes a Boolean value to this stream.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="value">A System.Boolean value.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteBoolean(this Stream stream, bool value)
        {
            stream.WriteByte(Convert.ToByte(value));
        }

        /// <summary>
        /// Reads a Boolean value from this stream.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <returns>The System.UInt32 value read from the stream.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ReadBoolean(this Stream stream)
        {
            return Convert.ToBoolean(stream.ReadByte());
        }

        #endregion

        #region Char

        /// <summary>
        /// Writes a System.Char value to this stream.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="value">The System.Char value.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteChar(this Stream stream, Char value)
        {
            WriteInt16(stream, (short)value, new byte[2]);
        }

        /// <summary>
        /// Writes a System.Char value to this stream using the specified buffer. Use this method if performance is critical.
        /// </summary>
        /// <param name="stream">This stream to write.</param>
        /// <param name="value">The System.Char value.</param>
        /// <param name="buffer">A byte array used to temporarily store the <paramref name="value"/>.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void WriteChar(this Stream stream, Char value, byte[] buffer)
        {
            WriteInt16(stream, (short)value, buffer);
        }

        /// <summary>
        /// Reads a System.Char value from this stream.
        /// </summary>
        /// <param name="stream">This stream to read.</param>
        /// <returns>A System.Char value read from this stream.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Char ReadChar(this Stream stream)
        {
            return (Char)ReadInt16(stream, new byte[2]);
        }

        /// <summary>
        /// Reads a System.Char value from this stream using the specified buffer.
        /// </summary>
        /// <param name="stream">This stream to read.</param>
        /// <param name="buffer">A byte array used to temporarily store the value read.</param>
        /// <returns>A System.Char value read from this stream.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Char ReadChar(this Stream stream, byte[] buffer)
        {
            return (Char)ReadInt16(stream, buffer);
        }

        #endregion

        #region DateTime

        /// <summary>
        /// Writes a <see cref="System.DateTime"/> value to the stream.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="datetime">The <see cref="System.DateTime"/> value.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteDateTime(this Stream stream, DateTime datetime)
        {
            stream.WriteInt64(datetime.Ticks);
        }

        /// <summary>
        /// Writes a nullable <see cref="System.DateTime"/> value to the stream.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="datetime">The nullable <see cref="System.DateTime"/> value.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">datetime</exception>
        public static void WriteNullableDateTime(this Stream stream, DateTime? datetime)
        {
            if (datetime == null)
                stream.WriteDateTime(DateTime.MinValue);
            else if (datetime.Value == DateTime.MinValue) throw new ArgumentOutOfRangeException("datetime");
            else stream.WriteDateTime(datetime.Value);
        }

        /// <summary>
        /// Writes a <see cref="System.DateTime"/> value to the stream.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="dateTime">The <see cref="System.DateTime"/> value.</param>
        /// <param name="buffer">A byte array used to temporarily store the <paramref name="value"/>.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteDateTime(this Stream stream, DateTime dateTime, byte[] buffer)
        {
            stream.WriteInt64(dateTime.Ticks, buffer);
        }

        /// <summary>
        /// Reads a <see cref="System.DateTime"/> value from the stream.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <returns>The <see cref="System.DateTime"/> value read from the stream.</returns>
        public static DateTime ReadDateTime(this Stream stream)
        {
            return new DateTime(stream.ReadInt64());
        }

        /// <summary>
        /// Reads a nullable <see cref="System.DateTime"/> value from the stream.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <returns>The nullable <see cref="System.DateTime"/> value read from the stream.</returns>
        public static DateTime? ReadNullableDateTime(this Stream stream)
        {
            var value = stream.ReadDateTime();
            if (value == DateTime.MinValue) return null;
            else return value;
        }

        /// <summary>
        /// Reads a <see cref="System.DateTime"/> value from the stream.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <param name="buffer">A byte array used to temporarily store the value read.</param>
        /// <returns>
        /// The <see cref="System.DateTime"/> value read from the stream.
        /// </returns>
        public static DateTime ReadDateTime(this Stream stream, byte[] buffer)
        {
            return new DateTime(stream.ReadInt64(buffer));
        }

        #endregion

        #region Single

        /// <summary>
        /// Writes a System.Single value to the stream.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="value">The System.Single value.</param>
        public static void WriteSingle(this Stream stream, Single value)
        {
            stream.WriteBytes(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Writes a System.Single value to the stream using the specified buffer. Use this method if performance is critical.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="value">The System.Single value.</param>
        /// <param name="buffer">A byte array used to temporarily store the <paramref name="value"/>.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void WriteSingle(this Stream stream, Single value, byte[] buffer)
        {
            fixed (byte* numRef = buffer)
            {
                *((Single*)numRef) = value;
            }
            stream.Write(buffer, 0, sizeof(Single));
        }

        /// <summary>
        /// Reads a System.Single value from the stream.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <returns>The System.Single value read from the stream.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Single ReadSingle(this Stream stream)
        {
            return BitConverter.ToSingle(stream.ReadBytes(sizeof(Single)), 0);
        }

        /// <summary>
        /// Reads a System.Single value from the stream using the specified buffer.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <param name="buffer">A byte array used to temporarily store the bytes read.</param>
        /// <returns>
        /// The System.Single value read from the stream.
        /// </returns>
        /// <exception cref="System.IO.InvalidDataException">Raises when the number of bytes actually read from stream is not 4.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Single ReadSingle(this Stream stream, byte[] buffer)
        {
            var i = stream.Read(buffer, 0, sizeof(Single));
            if (i != sizeof(Single)) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
            return BitConverter.ToSingle(buffer, 0);
        }

        #endregion

        #region Double

        /// <summary>
        /// Writes a System.Double value to the stream.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="value">The System.Double value.</param>
        public static void WriteDouble(this Stream stream, Double value)
        {
            stream.WriteBytes(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Writes a System.Double value to the stream using the specified buffer. Use this method if performance is critical.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="value">The System.Double value.</param>
        /// <param name="buffer">A byte array used to temporarily store the <paramref name="value"/>.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void WriteDouble(this Stream stream, Double value, byte[] buffer)
        {
            fixed (byte* numRef = buffer)
            {
                *((Double*)numRef) = value;
            }
            stream.Write(buffer, 0, sizeof(Double));
        }

        /// <summary>
        /// Reads a System.Double value from the stream.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <returns>The System.Double value read from the stream.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Double ReadDouble(this Stream stream)
        {
            return BitConverter.ToDouble(stream.ReadBytes(sizeof(Double)), 0);
        }

        /// <summary>
        /// Reads a System.Double value from the stream using the specified buffer.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <param name="buffer">A byte array used to temporarily store the bytes read.</param>
        /// <returns>
        /// The System.Double value read from the stream.
        /// </returns>
        /// <exception cref="System.IO.InvalidDataException">Raises when the number of bytes actually read from stream is not 8.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Double ReadDouble(this Stream stream, byte[] buffer)
        {
            var i = stream.Read(buffer, 0, sizeof(Double));
            if (i != sizeof(Double)) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
            return BitConverter.ToDouble(buffer, 0);
        }

        #endregion

    }
}
