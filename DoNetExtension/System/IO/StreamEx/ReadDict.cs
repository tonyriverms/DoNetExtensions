using System;
using System.Collections.Generic;
using System.Text;

namespace System.IO
{
    public static partial class StreamEx
    {


        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<byte, byte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = (byte)stream.ReadByte();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<byte, byte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = (byte)stream.ReadByte();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<bool, byte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = (byte)stream.ReadByte();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<bool, byte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = (byte)stream.ReadByte();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<sbyte, byte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = (byte)stream.ReadByte();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<sbyte, byte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = (byte)stream.ReadByte();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<short, byte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = (byte)stream.ReadByte();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<short, byte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = (byte)stream.ReadByte();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<ushort, byte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = (byte)stream.ReadByte();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<ushort, byte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = (byte)stream.ReadByte();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<int, byte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = (byte)stream.ReadByte();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<int, byte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = (byte)stream.ReadByte();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<uint, byte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = (byte)stream.ReadByte();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<uint, byte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = (byte)stream.ReadByte();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<long, byte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = (byte)stream.ReadByte();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<long, byte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = (byte)stream.ReadByte();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<ulong, byte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = (byte)stream.ReadByte();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<ulong, byte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = (byte)stream.ReadByte();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<double, byte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDouble();
                    var value = (byte)stream.ReadByte();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<double, byte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDouble();
                    var value = (byte)stream.ReadByte();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<float, byte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSingle();
                    var value = (byte)stream.ReadByte();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<float, byte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSingle();
                    var value = (byte)stream.ReadByte();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<DateTime, byte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = (byte)stream.ReadByte();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<DateTime, byte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = (byte)stream.ReadByte();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<string, byte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = (byte)stream.ReadByte();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<string, byte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = (byte)stream.ReadByte();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<byte, bool> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadBoolean();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<byte, bool> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadBoolean();
                    outputDict.TryAdd(key, value);
                    
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<bool, bool> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadBoolean();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<bool, bool> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadBoolean();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<sbyte, bool> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadBoolean();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<sbyte, bool> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadBoolean();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<short, bool> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadBoolean();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<short, bool> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadBoolean();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<ushort, bool> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadBoolean();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<ushort, bool> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadBoolean();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<int, bool> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadBoolean();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<int, bool> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadBoolean();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<uint, bool> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadBoolean();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<uint, bool> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadBoolean();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<long, bool> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadBoolean();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<long, bool> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadBoolean();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<ulong, bool> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadBoolean();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<ulong, bool> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadBoolean();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<double, bool> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDouble();
                    var value = stream.ReadBoolean();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<double, bool> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDouble();
                    var value = stream.ReadBoolean();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<float, bool> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSingle();
                    var value = stream.ReadBoolean();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<float, bool> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSingle();
                    var value = stream.ReadBoolean();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<DateTime, bool> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadBoolean();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<DateTime, bool> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadBoolean();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<string, bool> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadBoolean();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<string, bool> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadBoolean();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<byte, sbyte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadSByte();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<byte, sbyte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadSByte();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<bool, sbyte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadSByte();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<bool, sbyte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadSByte();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<sbyte, sbyte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadSByte();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<sbyte, sbyte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadSByte();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<short, sbyte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadSByte();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<short, sbyte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadSByte();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<ushort, sbyte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadSByte();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<ushort, sbyte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadSByte();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<int, sbyte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadSByte();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<int, sbyte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadSByte();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<uint, sbyte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadSByte();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<uint, sbyte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadSByte();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<long, sbyte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadSByte();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<long, sbyte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadSByte();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<ulong, sbyte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadSByte();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<ulong, sbyte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadSByte();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<double, sbyte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDouble();
                    var value = stream.ReadSByte();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<double, sbyte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDouble();
                    var value = stream.ReadSByte();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<float, sbyte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSingle();
                    var value = stream.ReadSByte();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<float, sbyte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSingle();
                    var value = stream.ReadSByte();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<DateTime, sbyte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadSByte();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<DateTime, sbyte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadSByte();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<string, sbyte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadSByte();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<string, sbyte> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadSByte();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<byte, short> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadInt16();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<byte, short> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadInt16();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<bool, short> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadInt16();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<bool, short> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadInt16();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<sbyte, short> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadInt16();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<sbyte, short> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadInt16();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<short, short> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadInt16();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<short, short> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadInt16();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<ushort, short> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadInt16();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<ushort, short> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadInt16();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<int, short> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadInt16();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<int, short> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadInt16();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<uint, short> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadInt16();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<uint, short> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadInt16();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<long, short> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadInt16();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<long, short> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadInt16();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<ulong, short> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadInt16();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<ulong, short> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadInt16();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<double, short> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDouble();
                    var value = stream.ReadInt16();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<double, short> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDouble();
                    var value = stream.ReadInt16();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<float, short> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSingle();
                    var value = stream.ReadInt16();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<float, short> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSingle();
                    var value = stream.ReadInt16();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<DateTime, short> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadInt16();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<DateTime, short> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadInt16();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<string, short> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadInt16();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<string, short> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadInt16();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<byte, ushort> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadUInt16();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<byte, ushort> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadUInt16();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<bool, ushort> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadUInt16();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<bool, ushort> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadUInt16();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<sbyte, ushort> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadUInt16();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<sbyte, ushort> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadUInt16();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<short, ushort> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadUInt16();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<short, ushort> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadUInt16();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<ushort, ushort> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadUInt16();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<ushort, ushort> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadUInt16();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<int, ushort> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadUInt16();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<int, ushort> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadUInt16();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<uint, ushort> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadUInt16();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<uint, ushort> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadUInt16();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<long, ushort> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadUInt16();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<long, ushort> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadUInt16();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<ulong, ushort> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadUInt16();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<ulong, ushort> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadUInt16();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<double, ushort> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDouble();
                    var value = stream.ReadUInt16();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<double, ushort> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDouble();
                    var value = stream.ReadUInt16();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<float, ushort> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSingle();
                    var value = stream.ReadUInt16();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<float, ushort> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSingle();
                    var value = stream.ReadUInt16();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<DateTime, ushort> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadUInt16();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<DateTime, ushort> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadUInt16();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<string, ushort> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadUInt16();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<string, ushort> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadUInt16();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<byte, int> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadInt32();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<byte, int> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadInt32();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<bool, int> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadInt32();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<bool, int> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadInt32();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<sbyte, int> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadInt32();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<sbyte, int> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadInt32();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<short, int> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadInt32();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<short, int> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadInt32();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<ushort, int> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadInt32();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<ushort, int> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadInt32();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<int, int> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadInt32();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<int, int> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadInt32();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<uint, int> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadInt32();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<uint, int> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadInt32();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<long, int> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadInt32();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<long, int> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadInt32();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<ulong, int> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadInt32();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<ulong, int> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadInt32();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<double, int> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDouble();
                    var value = stream.ReadInt32();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<double, int> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDouble();
                    var value = stream.ReadInt32();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<float, int> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSingle();
                    var value = stream.ReadInt32();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<float, int> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSingle();
                    var value = stream.ReadInt32();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<DateTime, int> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadInt32();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<DateTime, int> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadInt32();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<string, int> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadInt32();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<string, int> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadInt32();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<byte, uint> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadUInt32();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<byte, uint> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadUInt32();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<bool, uint> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadUInt32();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<bool, uint> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadUInt32();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<sbyte, uint> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadUInt32();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<sbyte, uint> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadUInt32();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<short, uint> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadUInt32();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<short, uint> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadUInt32();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<ushort, uint> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadUInt32();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<ushort, uint> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadUInt32();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<int, uint> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadUInt32();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<int, uint> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadUInt32();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<uint, uint> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadUInt32();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<uint, uint> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadUInt32();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<long, uint> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadUInt32();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<long, uint> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadUInt32();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<ulong, uint> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadUInt32();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<ulong, uint> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadUInt32();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<double, uint> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDouble();
                    var value = stream.ReadUInt32();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<double, uint> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDouble();
                    var value = stream.ReadUInt32();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<float, uint> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSingle();
                    var value = stream.ReadUInt32();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<float, uint> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSingle();
                    var value = stream.ReadUInt32();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<DateTime, uint> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadUInt32();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<DateTime, uint> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadUInt32();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<string, uint> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadUInt32();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<string, uint> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadUInt32();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<byte, long> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadInt64();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<byte, long> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadInt64();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<bool, long> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadInt64();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<bool, long> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadInt64();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<sbyte, long> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadInt64();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<sbyte, long> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadInt64();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<short, long> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadInt64();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<short, long> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadInt64();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<ushort, long> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadInt64();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<ushort, long> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadInt64();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<int, long> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadInt64();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<int, long> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadInt64();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<uint, long> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadInt64();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<uint, long> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadInt64();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<long, long> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadInt64();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<long, long> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadInt64();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<ulong, long> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadInt64();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<ulong, long> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadInt64();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<double, long> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDouble();
                    var value = stream.ReadInt64();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<double, long> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDouble();
                    var value = stream.ReadInt64();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<float, long> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSingle();
                    var value = stream.ReadInt64();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<float, long> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSingle();
                    var value = stream.ReadInt64();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<DateTime, long> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadInt64();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<DateTime, long> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadInt64();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<string, long> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadInt64();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<string, long> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadInt64();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<byte, ulong> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadUInt64();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<byte, ulong> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadUInt64();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<bool, ulong> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadUInt64();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<bool, ulong> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadUInt64();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<sbyte, ulong> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadUInt64();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<sbyte, ulong> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadUInt64();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<short, ulong> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadUInt64();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<short, ulong> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadUInt64();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<ushort, ulong> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadUInt64();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<ushort, ulong> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadUInt64();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<int, ulong> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadUInt64();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<int, ulong> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadUInt64();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<uint, ulong> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadUInt64();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<uint, ulong> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadUInt64();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<long, ulong> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadUInt64();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<long, ulong> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadUInt64();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<ulong, ulong> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadUInt64();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<ulong, ulong> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadUInt64();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<double, ulong> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDouble();
                    var value = stream.ReadUInt64();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<double, ulong> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDouble();
                    var value = stream.ReadUInt64();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<float, ulong> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSingle();
                    var value = stream.ReadUInt64();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<float, ulong> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSingle();
                    var value = stream.ReadUInt64();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<DateTime, ulong> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadUInt64();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<DateTime, ulong> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadUInt64();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<string, ulong> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadUInt64();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<string, ulong> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadUInt64();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<byte, double> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadDouble();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<byte, double> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadDouble();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<bool, double> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadDouble();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<bool, double> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadDouble();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<sbyte, double> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadDouble();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<sbyte, double> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadDouble();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<short, double> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadDouble();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<short, double> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadDouble();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<ushort, double> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadDouble();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<ushort, double> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadDouble();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<int, double> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadDouble();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<int, double> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadDouble();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<uint, double> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadDouble();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<uint, double> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadDouble();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<long, double> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadDouble();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<long, double> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadDouble();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<ulong, double> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadDouble();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<ulong, double> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadDouble();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<double, double> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDouble();
                    var value = stream.ReadDouble();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<double, double> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDouble();
                    var value = stream.ReadDouble();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<float, double> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSingle();
                    var value = stream.ReadDouble();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<float, double> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSingle();
                    var value = stream.ReadDouble();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<DateTime, double> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadDouble();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<DateTime, double> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadDouble();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<string, double> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadDouble();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<string, double> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadDouble();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<byte, float> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadSingle();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<byte, float> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadSingle();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<bool, float> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadSingle();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<bool, float> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadSingle();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<sbyte, float> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadSingle();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<sbyte, float> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadSingle();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<short, float> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadSingle();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<short, float> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadSingle();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<ushort, float> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadSingle();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<ushort, float> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadSingle();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<int, float> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadSingle();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<int, float> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadSingle();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<uint, float> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadSingle();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<uint, float> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadSingle();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<long, float> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadSingle();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<long, float> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadSingle();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<ulong, float> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadSingle();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<ulong, float> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadSingle();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<double, float> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDouble();
                    var value = stream.ReadSingle();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<double, float> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDouble();
                    var value = stream.ReadSingle();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<float, float> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSingle();
                    var value = stream.ReadSingle();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<float, float> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSingle();
                    var value = stream.ReadSingle();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<DateTime, float> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadSingle();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<DateTime, float> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadSingle();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<string, float> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadSingle();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<string, float> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadSingle();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<byte, DateTime> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadDateTime();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<byte, DateTime> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadDateTime();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<bool, DateTime> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadDateTime();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<bool, DateTime> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadDateTime();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<sbyte, DateTime> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadDateTime();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<sbyte, DateTime> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadDateTime();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<short, DateTime> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadDateTime();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<short, DateTime> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadDateTime();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<ushort, DateTime> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadDateTime();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<ushort, DateTime> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadDateTime();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<int, DateTime> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadDateTime();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<int, DateTime> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadDateTime();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<uint, DateTime> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadDateTime();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<uint, DateTime> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadDateTime();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<long, DateTime> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadDateTime();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<long, DateTime> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadDateTime();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<ulong, DateTime> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadDateTime();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<ulong, DateTime> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadDateTime();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<double, DateTime> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDouble();
                    var value = stream.ReadDateTime();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<double, DateTime> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDouble();
                    var value = stream.ReadDateTime();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<float, DateTime> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSingle();
                    var value = stream.ReadDateTime();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<float, DateTime> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSingle();
                    var value = stream.ReadDateTime();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<DateTime, DateTime> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadDateTime();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<DateTime, DateTime> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadDateTime();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<string, DateTime> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadDateTime();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<string, DateTime> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadDateTime();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<byte, string> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadString();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<byte, string> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadString();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<bool, string> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadString();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<bool, string> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadString();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<sbyte, string> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadString();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<sbyte, string> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadString();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<short, string> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadString();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<short, string> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadString();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<ushort, string> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadString();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<ushort, string> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadString();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<int, string> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadString();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<int, string> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadString();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<uint, string> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadString();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<uint, string> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadString();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<long, string> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadString();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<long, string> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadString();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<ulong, string> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadString();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<ulong, string> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadString();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<double, string> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDouble();
                    var value = stream.ReadString();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<double, string> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDouble();
                    var value = stream.ReadString();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<float, string> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSingle();
                    var value = stream.ReadString();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<float, string> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSingle();
                    var value = stream.ReadString();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<DateTime, string> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadString();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<DateTime, string> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadString();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict(this Stream stream, IDictionary<string, string> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadString();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd(this Stream stream, IDictionary<string, string> outputDict, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadString();
                    outputDict.TryAdd(key, value);
                }

            }
        }



        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict<T>(this Stream stream, IDictionary<byte, T> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadBinarySavable<T>();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd<T>(this Stream stream, IDictionary<byte, T> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadBinarySavable<T>();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict<T>(this Stream stream, IDictionary<T, byte> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBinarySavable<T>();
                    var value = (byte)stream.ReadByte();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd<T>(this Stream stream, IDictionary<T, byte> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBinarySavable<T>();
                    var value = (byte)stream.ReadByte();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict<T>(this Stream stream, IDictionary<bool, T> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadBinarySavable<T>();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd<T>(this Stream stream, IDictionary<bool, T> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadBinarySavable<T>();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict<T>(this Stream stream, IDictionary<T, bool> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBinarySavable<T>();
                    var value = stream.ReadBoolean();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd<T>(this Stream stream, IDictionary<T, bool> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBinarySavable<T>();
                    var value = stream.ReadBoolean();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict<T>(this Stream stream, IDictionary<sbyte, T> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadBinarySavable<T>();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd<T>(this Stream stream, IDictionary<sbyte, T> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadBinarySavable<T>();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict<T>(this Stream stream, IDictionary<T, sbyte> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBinarySavable<T>();
                    var value = stream.ReadSByte();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd<T>(this Stream stream, IDictionary<T, sbyte> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBinarySavable<T>();
                    var value = stream.ReadSByte();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict<T>(this Stream stream, IDictionary<short, T> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadBinarySavable<T>();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd<T>(this Stream stream, IDictionary<short, T> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadBinarySavable<T>();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict<T>(this Stream stream, IDictionary<T, short> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBinarySavable<T>();
                    var value = stream.ReadInt16();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd<T>(this Stream stream, IDictionary<T, short> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBinarySavable<T>();
                    var value = stream.ReadInt16();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict<T>(this Stream stream, IDictionary<ushort, T> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadBinarySavable<T>();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd<T>(this Stream stream, IDictionary<ushort, T> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadBinarySavable<T>();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict<T>(this Stream stream, IDictionary<T, ushort> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBinarySavable<T>();
                    var value = stream.ReadUInt16();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd<T>(this Stream stream, IDictionary<T, ushort> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBinarySavable<T>();
                    var value = stream.ReadUInt16();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict<T>(this Stream stream, IDictionary<int, T> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadBinarySavable<T>();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd<T>(this Stream stream, IDictionary<int, T> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadBinarySavable<T>();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict<T>(this Stream stream, IDictionary<T, int> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBinarySavable<T>();
                    var value = stream.ReadInt32();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd<T>(this Stream stream, IDictionary<T, int> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBinarySavable<T>();
                    var value = stream.ReadInt32();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict<T>(this Stream stream, IDictionary<uint, T> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadBinarySavable<T>();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd<T>(this Stream stream, IDictionary<uint, T> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadBinarySavable<T>();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict<T>(this Stream stream, IDictionary<T, uint> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBinarySavable<T>();
                    var value = stream.ReadUInt32();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd<T>(this Stream stream, IDictionary<T, uint> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBinarySavable<T>();
                    var value = stream.ReadUInt32();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict<T>(this Stream stream, IDictionary<long, T> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadBinarySavable<T>();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd<T>(this Stream stream, IDictionary<long, T> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadBinarySavable<T>();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict<T>(this Stream stream, IDictionary<T, long> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBinarySavable<T>();
                    var value = stream.ReadInt64();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd<T>(this Stream stream, IDictionary<T, long> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBinarySavable<T>();
                    var value = stream.ReadInt64();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict<T>(this Stream stream, IDictionary<ulong, T> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadBinarySavable<T>();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd<T>(this Stream stream, IDictionary<ulong, T> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadBinarySavable<T>();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict<T>(this Stream stream, IDictionary<T, ulong> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBinarySavable<T>();
                    var value = stream.ReadUInt64();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd<T>(this Stream stream, IDictionary<T, ulong> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBinarySavable<T>();
                    var value = stream.ReadUInt64();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict<T>(this Stream stream, IDictionary<double, T> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDouble();
                    var value = stream.ReadBinarySavable<T>();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd<T>(this Stream stream, IDictionary<double, T> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDouble();
                    var value = stream.ReadBinarySavable<T>();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict<T>(this Stream stream, IDictionary<T, double> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBinarySavable<T>();
                    var value = stream.ReadDouble();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd<T>(this Stream stream, IDictionary<T, double> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBinarySavable<T>();
                    var value = stream.ReadDouble();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict<T>(this Stream stream, IDictionary<float, T> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSingle();
                    var value = stream.ReadBinarySavable<T>();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd<T>(this Stream stream, IDictionary<float, T> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSingle();
                    var value = stream.ReadBinarySavable<T>();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict<T>(this Stream stream, IDictionary<T, float> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBinarySavable<T>();
                    var value = stream.ReadSingle();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd<T>(this Stream stream, IDictionary<T, float> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBinarySavable<T>();
                    var value = stream.ReadSingle();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict<T>(this Stream stream, IDictionary<DateTime, T> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadBinarySavable<T>();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd<T>(this Stream stream, IDictionary<DateTime, T> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadBinarySavable<T>();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict<T>(this Stream stream, IDictionary<T, DateTime> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBinarySavable<T>();
                    var value = stream.ReadDateTime();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd<T>(this Stream stream, IDictionary<T, DateTime> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBinarySavable<T>();
                    var value = stream.ReadDateTime();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict<T>(this Stream stream, IDictionary<string, T> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadBinarySavable<T>();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd<T>(this Stream stream, IDictionary<string, T> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadBinarySavable<T>();
                    outputDict.TryAdd(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys raise exception.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDict<T>(this Stream stream, IDictionary<T, string> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBinarySavable<T>();
                    var value = stream.ReadString();
                    outputDict.Add(key, value);
                }

            }
        }

        /// <summary>
        /// Reads key-value pairs from the stream and adds them to the specified dictionary. Duplicate keys and their values are ignored.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="outputDict">The key-value pairs read from the stream are added to this dictionary.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static void ReadDictTryAdd<T>(this Stream stream, IDictionary<T, string> outputDict, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBinarySavable<T>();
                    var value = stream.ReadString();
                    outputDict.TryAdd(key, value);
                }

            }
        }
    }
}
