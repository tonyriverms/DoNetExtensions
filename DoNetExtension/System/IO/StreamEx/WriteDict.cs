using System;
using System.Collections.Generic;
using System.Text;

namespace System.IO
{
    public static partial class StreamEx
    {


        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<byte, byte> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteByte(pair.Key);
                    stream.WriteByte(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<bool, byte> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteBoolean(pair.Key);
                    stream.WriteByte(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<sbyte, byte> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteSByte(pair.Key);
                    stream.WriteByte(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<short, byte> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt16(pair.Key);
                    stream.WriteByte(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<ushort, byte> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt16(pair.Key);
                    stream.WriteByte(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<int, byte> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt32(pair.Key);
                    stream.WriteByte(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<uint, byte> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt32(pair.Key);
                    stream.WriteByte(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<long, byte> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt64(pair.Key);
                    stream.WriteByte(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<ulong, byte> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt64(pair.Key);
                    stream.WriteByte(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<double, byte> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteDouble(pair.Key);
                    stream.WriteByte(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<float, byte> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteSingle(pair.Key);
                    stream.WriteByte(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<DateTime, byte> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteDateTime(pair.Key);
                    stream.WriteByte(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<string, byte> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteString(pair.Key);
                    stream.WriteByte(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<IBinarySavable, byte> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteBinarySavable(pair.Key);
                    stream.WriteByte(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<byte, bool> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteByte(pair.Key);
                    stream.WriteBoolean(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<bool, bool> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteBoolean(pair.Key);
                    stream.WriteBoolean(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<sbyte, bool> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteSByte(pair.Key);
                    stream.WriteBoolean(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<short, bool> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt16(pair.Key);
                    stream.WriteBoolean(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<ushort, bool> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt16(pair.Key);
                    stream.WriteBoolean(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<int, bool> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt32(pair.Key);
                    stream.WriteBoolean(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<uint, bool> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt32(pair.Key);
                    stream.WriteBoolean(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<long, bool> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt64(pair.Key);
                    stream.WriteBoolean(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<ulong, bool> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt64(pair.Key);
                    stream.WriteBoolean(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<double, bool> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteDouble(pair.Key);
                    stream.WriteBoolean(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<float, bool> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteSingle(pair.Key);
                    stream.WriteBoolean(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<DateTime, bool> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteDateTime(pair.Key);
                    stream.WriteBoolean(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<string, bool> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteString(pair.Key);
                    stream.WriteBoolean(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<IBinarySavable, bool> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteBinarySavable(pair.Key);
                    stream.WriteBoolean(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<byte, sbyte> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteByte(pair.Key);
                    stream.WriteSByte(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<bool, sbyte> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteBoolean(pair.Key);
                    stream.WriteSByte(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<sbyte, sbyte> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteSByte(pair.Key);
                    stream.WriteSByte(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<short, sbyte> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt16(pair.Key);
                    stream.WriteSByte(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<ushort, sbyte> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt16(pair.Key);
                    stream.WriteSByte(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<int, sbyte> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt32(pair.Key);
                    stream.WriteSByte(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<uint, sbyte> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt32(pair.Key);
                    stream.WriteSByte(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<long, sbyte> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt64(pair.Key);
                    stream.WriteSByte(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<ulong, sbyte> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt64(pair.Key);
                    stream.WriteSByte(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<double, sbyte> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteDouble(pair.Key);
                    stream.WriteSByte(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<float, sbyte> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteSingle(pair.Key);
                    stream.WriteSByte(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<DateTime, sbyte> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteDateTime(pair.Key);
                    stream.WriteSByte(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<string, sbyte> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteString(pair.Key);
                    stream.WriteSByte(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<IBinarySavable, sbyte> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteBinarySavable(pair.Key);
                    stream.WriteSByte(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<byte, short> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteByte(pair.Key);
                    stream.WriteInt16(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<bool, short> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteBoolean(pair.Key);
                    stream.WriteInt16(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<sbyte, short> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteSByte(pair.Key);
                    stream.WriteInt16(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<short, short> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt16(pair.Key);
                    stream.WriteInt16(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<ushort, short> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt16(pair.Key);
                    stream.WriteInt16(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<int, short> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt32(pair.Key);
                    stream.WriteInt16(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<uint, short> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt32(pair.Key);
                    stream.WriteInt16(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<long, short> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt64(pair.Key);
                    stream.WriteInt16(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<ulong, short> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt64(pair.Key);
                    stream.WriteInt16(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<double, short> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteDouble(pair.Key);
                    stream.WriteInt16(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<float, short> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteSingle(pair.Key);
                    stream.WriteInt16(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<DateTime, short> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteDateTime(pair.Key);
                    stream.WriteInt16(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<string, short> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteString(pair.Key);
                    stream.WriteInt16(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<IBinarySavable, short> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteBinarySavable(pair.Key);
                    stream.WriteInt16(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<byte, ushort> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteByte(pair.Key);
                    stream.WriteUInt16(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<bool, ushort> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteBoolean(pair.Key);
                    stream.WriteUInt16(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<sbyte, ushort> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteSByte(pair.Key);
                    stream.WriteUInt16(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<short, ushort> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt16(pair.Key);
                    stream.WriteUInt16(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<ushort, ushort> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt16(pair.Key);
                    stream.WriteUInt16(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<int, ushort> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt32(pair.Key);
                    stream.WriteUInt16(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<uint, ushort> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt32(pair.Key);
                    stream.WriteUInt16(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<long, ushort> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt64(pair.Key);
                    stream.WriteUInt16(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<ulong, ushort> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt64(pair.Key);
                    stream.WriteUInt16(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<double, ushort> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteDouble(pair.Key);
                    stream.WriteUInt16(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<float, ushort> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteSingle(pair.Key);
                    stream.WriteUInt16(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<DateTime, ushort> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteDateTime(pair.Key);
                    stream.WriteUInt16(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<string, ushort> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteString(pair.Key);
                    stream.WriteUInt16(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<IBinarySavable, ushort> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteBinarySavable(pair.Key);
                    stream.WriteUInt16(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<byte, int> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteByte(pair.Key);
                    stream.WriteInt32(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<bool, int> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteBoolean(pair.Key);
                    stream.WriteInt32(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<sbyte, int> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteSByte(pair.Key);
                    stream.WriteInt32(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<short, int> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt16(pair.Key);
                    stream.WriteInt32(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<ushort, int> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt16(pair.Key);
                    stream.WriteInt32(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<int, int> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt32(pair.Key);
                    stream.WriteInt32(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<uint, int> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt32(pair.Key);
                    stream.WriteInt32(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<long, int> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt64(pair.Key);
                    stream.WriteInt32(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<ulong, int> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt64(pair.Key);
                    stream.WriteInt32(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<double, int> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteDouble(pair.Key);
                    stream.WriteInt32(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<float, int> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteSingle(pair.Key);
                    stream.WriteInt32(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<DateTime, int> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteDateTime(pair.Key);
                    stream.WriteInt32(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<string, int> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteString(pair.Key);
                    stream.WriteInt32(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<IBinarySavable, int> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteBinarySavable(pair.Key);
                    stream.WriteInt32(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<byte, uint> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteByte(pair.Key);
                    stream.WriteUInt32(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<bool, uint> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteBoolean(pair.Key);
                    stream.WriteUInt32(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<sbyte, uint> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteSByte(pair.Key);
                    stream.WriteUInt32(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<short, uint> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt16(pair.Key);
                    stream.WriteUInt32(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<ushort, uint> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt16(pair.Key);
                    stream.WriteUInt32(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<int, uint> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt32(pair.Key);
                    stream.WriteUInt32(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<uint, uint> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt32(pair.Key);
                    stream.WriteUInt32(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<long, uint> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt64(pair.Key);
                    stream.WriteUInt32(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<ulong, uint> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt64(pair.Key);
                    stream.WriteUInt32(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<double, uint> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteDouble(pair.Key);
                    stream.WriteUInt32(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<float, uint> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteSingle(pair.Key);
                    stream.WriteUInt32(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<DateTime, uint> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteDateTime(pair.Key);
                    stream.WriteUInt32(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<string, uint> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteString(pair.Key);
                    stream.WriteUInt32(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<IBinarySavable, uint> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteBinarySavable(pair.Key);
                    stream.WriteUInt32(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<byte, long> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteByte(pair.Key);
                    stream.WriteInt64(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<bool, long> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteBoolean(pair.Key);
                    stream.WriteInt64(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<sbyte, long> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteSByte(pair.Key);
                    stream.WriteInt64(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<short, long> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt16(pair.Key);
                    stream.WriteInt64(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<ushort, long> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt16(pair.Key);
                    stream.WriteInt64(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<int, long> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt32(pair.Key);
                    stream.WriteInt64(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<uint, long> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt32(pair.Key);
                    stream.WriteInt64(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<long, long> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt64(pair.Key);
                    stream.WriteInt64(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<ulong, long> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt64(pair.Key);
                    stream.WriteInt64(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<double, long> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteDouble(pair.Key);
                    stream.WriteInt64(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<float, long> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteSingle(pair.Key);
                    stream.WriteInt64(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<DateTime, long> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteDateTime(pair.Key);
                    stream.WriteInt64(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<string, long> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteString(pair.Key);
                    stream.WriteInt64(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<IBinarySavable, long> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteBinarySavable(pair.Key);
                    stream.WriteInt64(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<byte, ulong> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteByte(pair.Key);
                    stream.WriteUInt64(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<bool, ulong> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteBoolean(pair.Key);
                    stream.WriteUInt64(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<sbyte, ulong> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteSByte(pair.Key);
                    stream.WriteUInt64(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<short, ulong> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt16(pair.Key);
                    stream.WriteUInt64(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<ushort, ulong> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt16(pair.Key);
                    stream.WriteUInt64(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<int, ulong> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt32(pair.Key);
                    stream.WriteUInt64(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<uint, ulong> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt32(pair.Key);
                    stream.WriteUInt64(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<long, ulong> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt64(pair.Key);
                    stream.WriteUInt64(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<ulong, ulong> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt64(pair.Key);
                    stream.WriteUInt64(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<double, ulong> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteDouble(pair.Key);
                    stream.WriteUInt64(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<float, ulong> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteSingle(pair.Key);
                    stream.WriteUInt64(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<DateTime, ulong> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteDateTime(pair.Key);
                    stream.WriteUInt64(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<string, ulong> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteString(pair.Key);
                    stream.WriteUInt64(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<IBinarySavable, ulong> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteBinarySavable(pair.Key);
                    stream.WriteUInt64(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<byte, double> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteByte(pair.Key);
                    stream.WriteDouble(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<bool, double> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteBoolean(pair.Key);
                    stream.WriteDouble(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<sbyte, double> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteSByte(pair.Key);
                    stream.WriteDouble(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<short, double> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt16(pair.Key);
                    stream.WriteDouble(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<ushort, double> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt16(pair.Key);
                    stream.WriteDouble(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<int, double> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt32(pair.Key);
                    stream.WriteDouble(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<uint, double> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt32(pair.Key);
                    stream.WriteDouble(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<long, double> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt64(pair.Key);
                    stream.WriteDouble(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<ulong, double> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt64(pair.Key);
                    stream.WriteDouble(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<double, double> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteDouble(pair.Key);
                    stream.WriteDouble(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<float, double> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteSingle(pair.Key);
                    stream.WriteDouble(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<DateTime, double> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteDateTime(pair.Key);
                    stream.WriteDouble(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<string, double> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteString(pair.Key);
                    stream.WriteDouble(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<IBinarySavable, double> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteBinarySavable(pair.Key);
                    stream.WriteDouble(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<byte, float> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteByte(pair.Key);
                    stream.WriteSingle(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<bool, float> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteBoolean(pair.Key);
                    stream.WriteSingle(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<sbyte, float> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteSByte(pair.Key);
                    stream.WriteSingle(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<short, float> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt16(pair.Key);
                    stream.WriteSingle(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<ushort, float> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt16(pair.Key);
                    stream.WriteSingle(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<int, float> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt32(pair.Key);
                    stream.WriteSingle(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<uint, float> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt32(pair.Key);
                    stream.WriteSingle(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<long, float> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt64(pair.Key);
                    stream.WriteSingle(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<ulong, float> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt64(pair.Key);
                    stream.WriteSingle(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<double, float> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteDouble(pair.Key);
                    stream.WriteSingle(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<float, float> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteSingle(pair.Key);
                    stream.WriteSingle(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<DateTime, float> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteDateTime(pair.Key);
                    stream.WriteSingle(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<string, float> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteString(pair.Key);
                    stream.WriteSingle(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<IBinarySavable, float> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteBinarySavable(pair.Key);
                    stream.WriteSingle(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<byte, DateTime> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteByte(pair.Key);
                    stream.WriteDateTime(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<bool, DateTime> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteBoolean(pair.Key);
                    stream.WriteDateTime(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<sbyte, DateTime> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteSByte(pair.Key);
                    stream.WriteDateTime(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<short, DateTime> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt16(pair.Key);
                    stream.WriteDateTime(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<ushort, DateTime> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt16(pair.Key);
                    stream.WriteDateTime(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<int, DateTime> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt32(pair.Key);
                    stream.WriteDateTime(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<uint, DateTime> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt32(pair.Key);
                    stream.WriteDateTime(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<long, DateTime> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt64(pair.Key);
                    stream.WriteDateTime(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<ulong, DateTime> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt64(pair.Key);
                    stream.WriteDateTime(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<double, DateTime> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteDouble(pair.Key);
                    stream.WriteDateTime(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<float, DateTime> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteSingle(pair.Key);
                    stream.WriteDateTime(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<DateTime, DateTime> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteDateTime(pair.Key);
                    stream.WriteDateTime(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<string, DateTime> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteString(pair.Key);
                    stream.WriteDateTime(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<IBinarySavable, DateTime> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteBinarySavable(pair.Key);
                    stream.WriteDateTime(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<byte, string> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteByte(pair.Key);
                    stream.WriteString(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<bool, string> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteBoolean(pair.Key);
                    stream.WriteString(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<sbyte, string> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteSByte(pair.Key);
                    stream.WriteString(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<short, string> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt16(pair.Key);
                    stream.WriteString(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<ushort, string> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt16(pair.Key);
                    stream.WriteString(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<int, string> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt32(pair.Key);
                    stream.WriteString(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<uint, string> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt32(pair.Key);
                    stream.WriteString(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<long, string> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt64(pair.Key);
                    stream.WriteString(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<ulong, string> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt64(pair.Key);
                    stream.WriteString(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<double, string> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteDouble(pair.Key);
                    stream.WriteString(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<float, string> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteSingle(pair.Key);
                    stream.WriteString(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<DateTime, string> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteDateTime(pair.Key);
                    stream.WriteString(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<string, string> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteString(pair.Key);
                    stream.WriteString(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<IBinarySavable, string> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteBinarySavable(pair.Key);
                    stream.WriteString(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<byte, IBinarySavable> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteByte(pair.Key);
                    stream.WriteBinarySavable(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<bool, IBinarySavable> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteBoolean(pair.Key);
                    stream.WriteBinarySavable(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<sbyte, IBinarySavable> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteSByte(pair.Key);
                    stream.WriteBinarySavable(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<short, IBinarySavable> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt16(pair.Key);
                    stream.WriteBinarySavable(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<ushort, IBinarySavable> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt16(pair.Key);
                    stream.WriteBinarySavable(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict<T>(this Stream stream, IDictionary<int, T> dict, bool validityCheck = false) where T : IBinarySavable
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt32(pair.Key);
                    stream.WriteBinarySavable(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<uint, IBinarySavable> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt32(pair.Key);
                    stream.WriteBinarySavable(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<long, IBinarySavable> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteInt64(pair.Key);
                    stream.WriteBinarySavable(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<ulong, IBinarySavable> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteUInt64(pair.Key);
                    stream.WriteBinarySavable(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<double, IBinarySavable> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteDouble(pair.Key);
                    stream.WriteBinarySavable(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<float, IBinarySavable> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteSingle(pair.Key);
                    stream.WriteBinarySavable(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<DateTime, IBinarySavable> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteDateTime(pair.Key);
                    stream.WriteBinarySavable(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict<T>(this Stream stream, IDictionary<string, T> dict, bool validityCheck = false) where T : IBinarySavable
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteString(pair.Key);
                    stream.WriteBinarySavable(pair.Value);
                }
            }

        }

        /// <summary>
        /// Writes the dictionary to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="dict">The dictionary object to write to the stream.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is written to the stream before all actual data. When the dictionary is later read from the stream, this code should be at the reading start position, or otherwise the data in the stream is corrupted.</param>
        public static void WriteDict(this Stream stream, IDictionary<IBinarySavable, IBinarySavable> dict, bool validityCheck = false)
        {
            if (validityCheck) stream.WriteCheckCode((Int64)0x212DF455DFABE3C);

            if (dict == null) stream.WriteInt32(0);
            else
            {
                stream.WriteInt32(dict.Count);
                foreach (var pair in dict)
                {
                    stream.WriteBinarySavable(pair.Key);
                    stream.WriteBinarySavable(pair.Value);
                }
            }

        }

    }
}
