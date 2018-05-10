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
        #region Int16 Write

        /// <summary>
        /// Writes a System.Int16 value to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.Int16 value.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInt16(this Stream stream, Int16 value)
        {
            stream.WriteBytes(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Writes a System.Int16 value to the stream using the specified buffer. Use this method if performance is critical.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.Int16 value.</param>
        /// <param name="buffer">A byte array used to temporarily store the <paramref name="value"/>.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void WriteInt16(this Stream stream, Int16 value, byte[] buffer)
        {
            fixed (byte* numRef = buffer)
            {
                *((Int16*)numRef) = value;
            }
            stream.Write(buffer, 0, sizeof(Int16));
        }

        #endregion

        #region Int16 Read

        /// <summary>
        /// Reads a System.Int16 value from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>The System.Int16 value read from the stream.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int16 ReadInt16(this Stream stream)
        {
            return BitConverter.ToInt16(stream.ReadBytes(sizeof(Int16)), 0);
        }

        /// <summary>
        /// Reads a System.Int16 value from the stream using the specified buffer.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="buffer">A byte array used to temporarily store the bytes read.</param>
        /// <returns>
        /// The System.Int16 value read from the stream.
        /// </returns>
        /// <exception cref="System.IO.InvalidDataException">Raises when the number of bytes actually read from stream is not 2.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int16 ReadInt16(this Stream stream, byte[] buffer)
        {
            var i = stream.Read(buffer, 0, sizeof(Int16));
            if (i != sizeof(Int16)) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
            return BitConverter.ToInt16(buffer, 0);
        }

        #endregion

        #region UInt16 Write

        /// <summary>
        /// Writes a System.UInt16 value to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.UInt16 value.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteUInt16(this Stream stream, UInt16 value)
        {
            stream.WriteBytes(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Writes a System.UInt16 value to the stream using the specified buffer. Use this method if performance is critical.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The System.UInt16 value.</param>
        /// <param name="buffer">A byte array used to temporarily store the <paramref name="value"/>.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void WriteUInt16(this Stream stream, UInt16 value, byte[] buffer)
        {
            fixed (byte* numRef = buffer)
            {
                *((UInt16*)numRef) = value;
            }
            stream.Write(buffer, 0, sizeof(UInt16));
        }

        #endregion

        #region UInt16 Read

        /// <summary>
        /// Reads a System.UInt16 value from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>The System.UInt16 value read from the stream.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt16 ReadUInt16(this Stream stream)
        {
            return BitConverter.ToUInt16(stream.ReadBytes(sizeof(UInt16)), 0);
        }

        /// <summary>
        /// Reads a System.UInt16 value from the stream using the specified buffer.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="buffer">A byte array used to temporarily store the bytes read.</param>
        /// <returns>
        /// The System.UInt16 value read from the stream.
        /// </returns>
        /// <exception cref="System.IO.InvalidDataException">Raises when the number of bytes actually read from stream is not 2.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt16 ReadUInt16(this Stream stream, byte[] buffer)
        {
            var i = stream.Read(buffer, 0, sizeof(UInt16));
            if (i != sizeof(UInt16)) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
            return BitConverter.ToUInt16(buffer, 0);
        }

        #endregion
    }
}
