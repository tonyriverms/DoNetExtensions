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
        /// Writes a Boolean array to this stream.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="array">A boolean array.</param>
        /// <param name="validityCheck">Indicates whether to write a check code before the Boolean array. This check code will help detect corrupted data.</param>
        public static void WriteBooleans(this Stream stream, bool[] array, bool validityCheck = true)
        {
            if (validityCheck) stream.WriteCheckCode(IOChecks.Booleans);

            if (array == null)
            {
                stream.WriteInt32(0);
                return;
            }

            var count = (int)Math.Ceiling(array.Length / 8f);
            var bytes = new byte[count];
            for (int i = 0; i < array.Length;)
            {
                bytes.SetBit(i, array[i]);
                ++i;
            }
            stream.WriteInt32(array.Length);
            stream.WriteBytes(bytes);
        }


        /// <summary>
        /// Reads a Boolean array from this stream.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <param name="validityCheck">Set this parameter <c>true</c> if there is a check code before the Boolean array to prevent data corruption; otherwise, set this <c>false</c>.</param>
        /// <returns>
        /// A Boolean array read from the stream.
        /// </returns>
        /// <exception cref="System.IO.InvalidDataException">Raises if data in the stream is corrupted.</exception>
        public static bool[] ReadBooleans(this Stream stream, bool validityCheck = true)
        {
            if (!validityCheck || stream.Check(IOChecks.Booleans))
            {
                var len = stream.ReadInt32();
                if (len == 0) return null;
                else if (len < 0)
                    throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);

                var count = (int)Math.Ceiling(len / 8f);
                var bytes = stream.ReadBytes(count);
                var bools = new bool[len];
                for (int i = 0; i < len; i++)
                    bools[i] = bytes.GetBit(i);
                return bools;
            }
            else throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
        }
    }
}
