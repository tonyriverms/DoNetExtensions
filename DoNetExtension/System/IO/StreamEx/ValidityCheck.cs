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
        /// <summary>
        /// Writes a 64-bit positive integer check code into this stream. 
        /// Check code is used to check the validity of the data before reading.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="value">A 64-bit positive integer as a countersign.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteCheckCode(this Stream stream, Int64 value)
        {
            if (value <= 0) throw new ArgumentOutOfRangeException(IOResources.ERR_StreamExtension_InvalidCheckCode);
            stream.WriteInt64(Int64.MinValue + value);
        }

        /// <summary>
        /// Writes a 32-bit positive integer as the check code into this stream. 
        /// Countersign is used to check the validity of the data before reading.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="value">A 32-bit positive integer as a check code.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteCheckCode(this Stream stream, Int32 value)
        {
            if (value <= 0) throw new ArgumentOutOfRangeException(IOResources.ERR_StreamExtension_InvalidCheckCode);
            stream.WriteInt32(Int32.MinValue + value);
        }

        /// <summary>
        /// Writes a check code into this stream.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="value">The countersign.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteCheckCode(this Stream stream, IOChecks value)
        {
            stream.WriteCheckCode((Int64)value);
        }

        /// <summary>
        /// Checks the validity of data at the current position of the stream by a countersign.
        /// </summary>
        /// <param name="stream">The stream to check.</param>
        /// <param name="countersign">The countersign to check.</param>
        /// <returns>true if the data at the current position of the stream is valid; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Check(this Stream stream, Int64 countersign)
        {
            return stream.ReadInt64() == Int64.MinValue + countersign;
        }

        /// <summary>
        /// Checks the validity of data at the current position of the stream by a countersign.
        /// </summary>
        /// <param name="stream">The stream to check.</param>
        /// <param name="countersign">The countersign to check.</param>
        /// <returns>true if the data at the current position of the stream is valid; otherwise, false.</returns>
        public static bool Check(this Stream stream, Int32 countersign)
        {
            return stream.ReadInt32() == Int32.MinValue + countersign;
        }

        /// <summary>
        /// Checks the validity of data at the current position of the stream by a countersign.
        /// </summary>
        /// <param name="stream">The stream to check.</param>
        /// <param name="countersign">The countersign to check.</param>
        /// <returns>true if the data at the current position of the stream is valid; otherwise, false.</returns>
        public static bool Check(this Stream stream, IOChecks countersign)
        {
            return Check(stream, (Int64)countersign);
        }
    }
}
