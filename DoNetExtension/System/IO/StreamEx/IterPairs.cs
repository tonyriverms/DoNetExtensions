using DoNetExtension.System.IO;
using System.Collections.Generic;

namespace System.IO
{
    public static partial class StreamEx
    {




        /// <summary>
        /// Iterates <see cref="bool"/>-<see cref="bool"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterBooleanBooleanTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(bool, bool)> IterBooleanBooleanDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadBoolean();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="bool"/>-<see cref="bool"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(bool, bool)> IterBooleanBooleanTuples(this Stream stream)
        {
            var key = stream.ReadBoolean();
            var value = stream.ReadBoolean();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="byte"/>-<see cref="bool"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterByteBooleanTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(byte, bool)> IterByteBooleanDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadBoolean();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="byte"/>-<see cref="bool"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(byte, bool)> IterByteBooleanTuples(this Stream stream)
        {
            var key = (byte)stream.ReadByte();
            var value = stream.ReadBoolean();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="sbyte"/>-<see cref="bool"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterSByteBooleanTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(sbyte, bool)> IterSByteBooleanDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadBoolean();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="sbyte"/>-<see cref="bool"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(sbyte, bool)> IterSByteBooleanTuples(this Stream stream)
        {
            var key = stream.ReadSByte();
            var value = stream.ReadBoolean();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="short"/>-<see cref="bool"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt16BooleanTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(short, bool)> IterInt16BooleanDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadBoolean();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="short"/>-<see cref="bool"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(short, bool)> IterInt16BooleanTuples(this Stream stream)
        {
            var key = stream.ReadInt16();
            var value = stream.ReadBoolean();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="int"/>-<see cref="bool"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt32BooleanTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(int, bool)> IterInt32BooleanDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadBoolean();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="int"/>-<see cref="bool"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(int, bool)> IterInt32BooleanTuples(this Stream stream)
        {
            var key = stream.ReadInt32();
            var value = stream.ReadBoolean();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="long"/>-<see cref="bool"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt64BooleanTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(long, bool)> IterInt64BooleanDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadBoolean();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="long"/>-<see cref="bool"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(long, bool)> IterInt64BooleanTuples(this Stream stream)
        {
            var key = stream.ReadInt64();
            var value = stream.ReadBoolean();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="ushort"/>-<see cref="bool"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt16BooleanTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(ushort, bool)> IterUInt16BooleanDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadBoolean();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="ushort"/>-<see cref="bool"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(ushort, bool)> IterUInt16BooleanTuples(this Stream stream)
        {
            var key = stream.ReadUInt16();
            var value = stream.ReadBoolean();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="uint"/>-<see cref="bool"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt32BooleanTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(uint, bool)> IterUInt32BooleanDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadBoolean();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="uint"/>-<see cref="bool"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(uint, bool)> IterUInt32BooleanTuples(this Stream stream)
        {
            var key = stream.ReadUInt32();
            var value = stream.ReadBoolean();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="ulong"/>-<see cref="bool"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt64BooleanTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(ulong, bool)> IterUInt64BooleanDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadBoolean();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="ulong"/>-<see cref="bool"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(ulong, bool)> IterUInt64BooleanTuples(this Stream stream)
        {
            var key = stream.ReadUInt64();
            var value = stream.ReadBoolean();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="string"/>-<see cref="bool"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterStringBooleanTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(string, bool)> IterStringBooleanDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadBoolean();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="string"/>-<see cref="bool"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(string, bool)> IterStringBooleanTuples(this Stream stream)
        {
            var key = stream.ReadString();
            var value = stream.ReadBoolean();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="DateTime"/>-<see cref="bool"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterDateTimeBooleanTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(DateTime, bool)> IterDateTimeBooleanDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadBoolean();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="DateTime"/>-<see cref="bool"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(DateTime, bool)> IterDateTimeBooleanTuples(this Stream stream)
        {
            var key = stream.ReadDateTime();
            var value = stream.ReadBoolean();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="bool"/>-<see cref="byte"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterBooleanByteTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(bool, byte)> IterBooleanByteDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = (byte)stream.ReadByte();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="bool"/>-<see cref="byte"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(bool, byte)> IterBooleanByteTuples(this Stream stream)
        {
            var key = stream.ReadBoolean();
            var value = (byte)stream.ReadByte();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="byte"/>-<see cref="byte"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterByteByteTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(byte, byte)> IterByteByteDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = (byte)stream.ReadByte();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="byte"/>-<see cref="byte"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(byte, byte)> IterByteByteTuples(this Stream stream)
        {
            var key = (byte)stream.ReadByte();
            var value = (byte)stream.ReadByte();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="sbyte"/>-<see cref="byte"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterSByteByteTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(sbyte, byte)> IterSByteByteDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = (byte)stream.ReadByte();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="sbyte"/>-<see cref="byte"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(sbyte, byte)> IterSByteByteTuples(this Stream stream)
        {
            var key = stream.ReadSByte();
            var value = (byte)stream.ReadByte();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="short"/>-<see cref="byte"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt16ByteTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(short, byte)> IterInt16ByteDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = (byte)stream.ReadByte();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="short"/>-<see cref="byte"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(short, byte)> IterInt16ByteTuples(this Stream stream)
        {
            var key = stream.ReadInt16();
            var value = (byte)stream.ReadByte();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="int"/>-<see cref="byte"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt32ByteTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(int, byte)> IterInt32ByteDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = (byte)stream.ReadByte();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="int"/>-<see cref="byte"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(int, byte)> IterInt32ByteTuples(this Stream stream)
        {
            var key = stream.ReadInt32();
            var value = (byte)stream.ReadByte();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="long"/>-<see cref="byte"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt64ByteTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(long, byte)> IterInt64ByteDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = (byte)stream.ReadByte();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="long"/>-<see cref="byte"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(long, byte)> IterInt64ByteTuples(this Stream stream)
        {
            var key = stream.ReadInt64();
            var value = (byte)stream.ReadByte();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="ushort"/>-<see cref="byte"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt16ByteTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(ushort, byte)> IterUInt16ByteDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = (byte)stream.ReadByte();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="ushort"/>-<see cref="byte"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(ushort, byte)> IterUInt16ByteTuples(this Stream stream)
        {
            var key = stream.ReadUInt16();
            var value = (byte)stream.ReadByte();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="uint"/>-<see cref="byte"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt32ByteTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(uint, byte)> IterUInt32ByteDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = (byte)stream.ReadByte();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="uint"/>-<see cref="byte"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(uint, byte)> IterUInt32ByteTuples(this Stream stream)
        {
            var key = stream.ReadUInt32();
            var value = (byte)stream.ReadByte();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="ulong"/>-<see cref="byte"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt64ByteTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(ulong, byte)> IterUInt64ByteDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = (byte)stream.ReadByte();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="ulong"/>-<see cref="byte"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(ulong, byte)> IterUInt64ByteTuples(this Stream stream)
        {
            var key = stream.ReadUInt64();
            var value = (byte)stream.ReadByte();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="string"/>-<see cref="byte"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterStringByteTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(string, byte)> IterStringByteDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = (byte)stream.ReadByte();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="string"/>-<see cref="byte"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(string, byte)> IterStringByteTuples(this Stream stream)
        {
            var key = stream.ReadString();
            var value = (byte)stream.ReadByte();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="DateTime"/>-<see cref="byte"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterDateTimeByteTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(DateTime, byte)> IterDateTimeByteDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = (byte)stream.ReadByte();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="DateTime"/>-<see cref="byte"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(DateTime, byte)> IterDateTimeByteTuples(this Stream stream)
        {
            var key = stream.ReadDateTime();
            var value = (byte)stream.ReadByte();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="bool"/>-<see cref="sbyte"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterBooleanSByteTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(bool, sbyte)> IterBooleanSByteDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadSByte();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="bool"/>-<see cref="sbyte"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(bool, sbyte)> IterBooleanSByteTuples(this Stream stream)
        {
            var key = stream.ReadBoolean();
            var value = stream.ReadSByte();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="byte"/>-<see cref="sbyte"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterByteSByteTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(byte, sbyte)> IterByteSByteDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadSByte();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="byte"/>-<see cref="sbyte"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(byte, sbyte)> IterByteSByteTuples(this Stream stream)
        {
            var key = (byte)stream.ReadByte();
            var value = stream.ReadSByte();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="sbyte"/>-<see cref="sbyte"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterSByteSByteTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(sbyte, sbyte)> IterSByteSByteDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadSByte();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="sbyte"/>-<see cref="sbyte"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(sbyte, sbyte)> IterSByteSByteTuples(this Stream stream)
        {
            var key = stream.ReadSByte();
            var value = stream.ReadSByte();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="short"/>-<see cref="sbyte"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt16SByteTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(short, sbyte)> IterInt16SByteDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadSByte();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="short"/>-<see cref="sbyte"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(short, sbyte)> IterInt16SByteTuples(this Stream stream)
        {
            var key = stream.ReadInt16();
            var value = stream.ReadSByte();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="int"/>-<see cref="sbyte"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt32SByteTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(int, sbyte)> IterInt32SByteDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadSByte();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="int"/>-<see cref="sbyte"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(int, sbyte)> IterInt32SByteTuples(this Stream stream)
        {
            var key = stream.ReadInt32();
            var value = stream.ReadSByte();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="long"/>-<see cref="sbyte"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt64SByteTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(long, sbyte)> IterInt64SByteDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadSByte();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="long"/>-<see cref="sbyte"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(long, sbyte)> IterInt64SByteTuples(this Stream stream)
        {
            var key = stream.ReadInt64();
            var value = stream.ReadSByte();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="ushort"/>-<see cref="sbyte"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt16SByteTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(ushort, sbyte)> IterUInt16SByteDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadSByte();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="ushort"/>-<see cref="sbyte"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(ushort, sbyte)> IterUInt16SByteTuples(this Stream stream)
        {
            var key = stream.ReadUInt16();
            var value = stream.ReadSByte();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="uint"/>-<see cref="sbyte"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt32SByteTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(uint, sbyte)> IterUInt32SByteDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadSByte();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="uint"/>-<see cref="sbyte"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(uint, sbyte)> IterUInt32SByteTuples(this Stream stream)
        {
            var key = stream.ReadUInt32();
            var value = stream.ReadSByte();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="ulong"/>-<see cref="sbyte"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt64SByteTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(ulong, sbyte)> IterUInt64SByteDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadSByte();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="ulong"/>-<see cref="sbyte"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(ulong, sbyte)> IterUInt64SByteTuples(this Stream stream)
        {
            var key = stream.ReadUInt64();
            var value = stream.ReadSByte();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="string"/>-<see cref="sbyte"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterStringSByteTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(string, sbyte)> IterStringSByteDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadSByte();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="string"/>-<see cref="sbyte"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(string, sbyte)> IterStringSByteTuples(this Stream stream)
        {
            var key = stream.ReadString();
            var value = stream.ReadSByte();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="DateTime"/>-<see cref="sbyte"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterDateTimeSByteTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(DateTime, sbyte)> IterDateTimeSByteDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadSByte();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="DateTime"/>-<see cref="sbyte"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(DateTime, sbyte)> IterDateTimeSByteTuples(this Stream stream)
        {
            var key = stream.ReadDateTime();
            var value = stream.ReadSByte();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="bool"/>-<see cref="short"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterBooleanInt16Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(bool, short)> IterBooleanInt16DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadInt16();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="bool"/>-<see cref="short"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(bool, short)> IterBooleanInt16Tuples(this Stream stream)
        {
            var key = stream.ReadBoolean();
            var value = stream.ReadInt16();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="byte"/>-<see cref="short"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterByteInt16Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(byte, short)> IterByteInt16DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadInt16();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="byte"/>-<see cref="short"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(byte, short)> IterByteInt16Tuples(this Stream stream)
        {
            var key = (byte)stream.ReadByte();
            var value = stream.ReadInt16();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="sbyte"/>-<see cref="short"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterSByteInt16Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(sbyte, short)> IterSByteInt16DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadInt16();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="sbyte"/>-<see cref="short"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(sbyte, short)> IterSByteInt16Tuples(this Stream stream)
        {
            var key = stream.ReadSByte();
            var value = stream.ReadInt16();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="short"/>-<see cref="short"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt16Int16Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(short, short)> IterInt16Int16DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadInt16();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="short"/>-<see cref="short"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(short, short)> IterInt16Int16Tuples(this Stream stream)
        {
            var key = stream.ReadInt16();
            var value = stream.ReadInt16();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="int"/>-<see cref="short"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt32Int16Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(int, short)> IterInt32Int16DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadInt16();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="int"/>-<see cref="short"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(int, short)> IterInt32Int16Tuples(this Stream stream)
        {
            var key = stream.ReadInt32();
            var value = stream.ReadInt16();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="long"/>-<see cref="short"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt64Int16Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(long, short)> IterInt64Int16DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadInt16();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="long"/>-<see cref="short"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(long, short)> IterInt64Int16Tuples(this Stream stream)
        {
            var key = stream.ReadInt64();
            var value = stream.ReadInt16();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="ushort"/>-<see cref="short"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt16Int16Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(ushort, short)> IterUInt16Int16DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadInt16();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="ushort"/>-<see cref="short"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(ushort, short)> IterUInt16Int16Tuples(this Stream stream)
        {
            var key = stream.ReadUInt16();
            var value = stream.ReadInt16();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="uint"/>-<see cref="short"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt32Int16Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(uint, short)> IterUInt32Int16DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadInt16();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="uint"/>-<see cref="short"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(uint, short)> IterUInt32Int16Tuples(this Stream stream)
        {
            var key = stream.ReadUInt32();
            var value = stream.ReadInt16();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="ulong"/>-<see cref="short"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt64Int16Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(ulong, short)> IterUInt64Int16DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadInt16();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="ulong"/>-<see cref="short"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(ulong, short)> IterUInt64Int16Tuples(this Stream stream)
        {
            var key = stream.ReadUInt64();
            var value = stream.ReadInt16();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="string"/>-<see cref="short"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterStringInt16Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(string, short)> IterStringInt16DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadInt16();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="string"/>-<see cref="short"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(string, short)> IterStringInt16Tuples(this Stream stream)
        {
            var key = stream.ReadString();
            var value = stream.ReadInt16();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="DateTime"/>-<see cref="short"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterDateTimeInt16Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(DateTime, short)> IterDateTimeInt16DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadInt16();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="DateTime"/>-<see cref="short"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(DateTime, short)> IterDateTimeInt16Tuples(this Stream stream)
        {
            var key = stream.ReadDateTime();
            var value = stream.ReadInt16();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="bool"/>-<see cref="int"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterBooleanInt32Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(bool, int)> IterBooleanInt32DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadInt32();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="bool"/>-<see cref="int"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(bool, int)> IterBooleanInt32Tuples(this Stream stream)
        {
            var key = stream.ReadBoolean();
            var value = stream.ReadInt32();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="byte"/>-<see cref="int"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterByteInt32Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(byte, int)> IterByteInt32DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadInt32();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="byte"/>-<see cref="int"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(byte, int)> IterByteInt32Tuples(this Stream stream)
        {
            var key = (byte)stream.ReadByte();
            var value = stream.ReadInt32();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="sbyte"/>-<see cref="int"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterSByteInt32Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(sbyte, int)> IterSByteInt32DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadInt32();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="sbyte"/>-<see cref="int"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(sbyte, int)> IterSByteInt32Tuples(this Stream stream)
        {
            var key = stream.ReadSByte();
            var value = stream.ReadInt32();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="short"/>-<see cref="int"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt16Int32Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(short, int)> IterInt16Int32DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadInt32();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="short"/>-<see cref="int"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(short, int)> IterInt16Int32Tuples(this Stream stream)
        {
            var key = stream.ReadInt16();
            var value = stream.ReadInt32();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="int"/>-<see cref="int"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt32Int32Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(int, int)> IterInt32Int32DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadInt32();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="int"/>-<see cref="int"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(int, int)> IterInt32Int32Tuples(this Stream stream)
        {
            var key = stream.ReadInt32();
            var value = stream.ReadInt32();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="long"/>-<see cref="int"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt64Int32Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(long, int)> IterInt64Int32DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadInt32();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="long"/>-<see cref="int"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(long, int)> IterInt64Int32Tuples(this Stream stream)
        {
            var key = stream.ReadInt64();
            var value = stream.ReadInt32();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="ushort"/>-<see cref="int"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt16Int32Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(ushort, int)> IterUInt16Int32DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadInt32();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="ushort"/>-<see cref="int"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(ushort, int)> IterUInt16Int32Tuples(this Stream stream)
        {
            var key = stream.ReadUInt16();
            var value = stream.ReadInt32();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="uint"/>-<see cref="int"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt32Int32Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(uint, int)> IterUInt32Int32DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadInt32();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="uint"/>-<see cref="int"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(uint, int)> IterUInt32Int32Tuples(this Stream stream)
        {
            var key = stream.ReadUInt32();
            var value = stream.ReadInt32();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="ulong"/>-<see cref="int"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt64Int32Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(ulong, int)> IterUInt64Int32DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadInt32();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="ulong"/>-<see cref="int"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(ulong, int)> IterUInt64Int32Tuples(this Stream stream)
        {
            var key = stream.ReadUInt64();
            var value = stream.ReadInt32();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="string"/>-<see cref="int"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterStringInt32Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(string, int)> IterStringInt32DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadInt32();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="string"/>-<see cref="int"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(string, int)> IterStringInt32Tuples(this Stream stream)
        {
            var key = stream.ReadString();
            var value = stream.ReadInt32();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="DateTime"/>-<see cref="int"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterDateTimeInt32Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(DateTime, int)> IterDateTimeInt32DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadInt32();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="DateTime"/>-<see cref="int"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(DateTime, int)> IterDateTimeInt32Tuples(this Stream stream)
        {
            var key = stream.ReadDateTime();
            var value = stream.ReadInt32();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="bool"/>-<see cref="long"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterBooleanInt64Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(bool, long)> IterBooleanInt64DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadInt64();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="bool"/>-<see cref="long"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(bool, long)> IterBooleanInt64Tuples(this Stream stream)
        {
            var key = stream.ReadBoolean();
            var value = stream.ReadInt64();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="byte"/>-<see cref="long"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterByteInt64Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(byte, long)> IterByteInt64DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadInt64();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="byte"/>-<see cref="long"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(byte, long)> IterByteInt64Tuples(this Stream stream)
        {
            var key = (byte)stream.ReadByte();
            var value = stream.ReadInt64();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="sbyte"/>-<see cref="long"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterSByteInt64Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(sbyte, long)> IterSByteInt64DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadInt64();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="sbyte"/>-<see cref="long"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(sbyte, long)> IterSByteInt64Tuples(this Stream stream)
        {
            var key = stream.ReadSByte();
            var value = stream.ReadInt64();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="short"/>-<see cref="long"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt16Int64Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(short, long)> IterInt16Int64DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadInt64();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="short"/>-<see cref="long"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(short, long)> IterInt16Int64Tuples(this Stream stream)
        {
            var key = stream.ReadInt16();
            var value = stream.ReadInt64();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="int"/>-<see cref="long"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt32Int64Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(int, long)> IterInt32Int64DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadInt64();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="int"/>-<see cref="long"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(int, long)> IterInt32Int64Tuples(this Stream stream)
        {
            var key = stream.ReadInt32();
            var value = stream.ReadInt64();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="long"/>-<see cref="long"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt64Int64Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(long, long)> IterInt64Int64DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadInt64();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="long"/>-<see cref="long"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(long, long)> IterInt64Int64Tuples(this Stream stream)
        {
            var key = stream.ReadInt64();
            var value = stream.ReadInt64();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="ushort"/>-<see cref="long"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt16Int64Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(ushort, long)> IterUInt16Int64DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadInt64();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="ushort"/>-<see cref="long"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(ushort, long)> IterUInt16Int64Tuples(this Stream stream)
        {
            var key = stream.ReadUInt16();
            var value = stream.ReadInt64();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="uint"/>-<see cref="long"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt32Int64Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(uint, long)> IterUInt32Int64DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadInt64();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="uint"/>-<see cref="long"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(uint, long)> IterUInt32Int64Tuples(this Stream stream)
        {
            var key = stream.ReadUInt32();
            var value = stream.ReadInt64();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="ulong"/>-<see cref="long"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt64Int64Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(ulong, long)> IterUInt64Int64DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadInt64();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="ulong"/>-<see cref="long"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(ulong, long)> IterUInt64Int64Tuples(this Stream stream)
        {
            var key = stream.ReadUInt64();
            var value = stream.ReadInt64();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="string"/>-<see cref="long"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterStringInt64Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(string, long)> IterStringInt64DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadInt64();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="string"/>-<see cref="long"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(string, long)> IterStringInt64Tuples(this Stream stream)
        {
            var key = stream.ReadString();
            var value = stream.ReadInt64();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="DateTime"/>-<see cref="long"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterDateTimeInt64Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(DateTime, long)> IterDateTimeInt64DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadInt64();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="DateTime"/>-<see cref="long"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(DateTime, long)> IterDateTimeInt64Tuples(this Stream stream)
        {
            var key = stream.ReadDateTime();
            var value = stream.ReadInt64();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="bool"/>-<see cref="ushort"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterBooleanUInt16Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(bool, ushort)> IterBooleanUInt16DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadUInt16();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="bool"/>-<see cref="ushort"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(bool, ushort)> IterBooleanUInt16Tuples(this Stream stream)
        {
            var key = stream.ReadBoolean();
            var value = stream.ReadUInt16();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="byte"/>-<see cref="ushort"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterByteUInt16Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(byte, ushort)> IterByteUInt16DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadUInt16();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="byte"/>-<see cref="ushort"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(byte, ushort)> IterByteUInt16Tuples(this Stream stream)
        {
            var key = (byte)stream.ReadByte();
            var value = stream.ReadUInt16();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="sbyte"/>-<see cref="ushort"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterSByteUInt16Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(sbyte, ushort)> IterSByteUInt16DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadUInt16();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="sbyte"/>-<see cref="ushort"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(sbyte, ushort)> IterSByteUInt16Tuples(this Stream stream)
        {
            var key = stream.ReadSByte();
            var value = stream.ReadUInt16();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="short"/>-<see cref="ushort"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt16UInt16Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(short, ushort)> IterInt16UInt16DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadUInt16();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="short"/>-<see cref="ushort"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(short, ushort)> IterInt16UInt16Tuples(this Stream stream)
        {
            var key = stream.ReadInt16();
            var value = stream.ReadUInt16();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="int"/>-<see cref="ushort"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt32UInt16Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(int, ushort)> IterInt32UInt16DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadUInt16();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="int"/>-<see cref="ushort"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(int, ushort)> IterInt32UInt16Tuples(this Stream stream)
        {
            var key = stream.ReadInt32();
            var value = stream.ReadUInt16();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="long"/>-<see cref="ushort"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt64UInt16Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(long, ushort)> IterInt64UInt16DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadUInt16();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="long"/>-<see cref="ushort"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(long, ushort)> IterInt64UInt16Tuples(this Stream stream)
        {
            var key = stream.ReadInt64();
            var value = stream.ReadUInt16();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="ushort"/>-<see cref="ushort"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt16UInt16Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(ushort, ushort)> IterUInt16UInt16DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadUInt16();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="ushort"/>-<see cref="ushort"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(ushort, ushort)> IterUInt16UInt16Tuples(this Stream stream)
        {
            var key = stream.ReadUInt16();
            var value = stream.ReadUInt16();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="uint"/>-<see cref="ushort"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt32UInt16Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(uint, ushort)> IterUInt32UInt16DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadUInt16();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="uint"/>-<see cref="ushort"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(uint, ushort)> IterUInt32UInt16Tuples(this Stream stream)
        {
            var key = stream.ReadUInt32();
            var value = stream.ReadUInt16();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="ulong"/>-<see cref="ushort"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt64UInt16Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(ulong, ushort)> IterUInt64UInt16DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadUInt16();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="ulong"/>-<see cref="ushort"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(ulong, ushort)> IterUInt64UInt16Tuples(this Stream stream)
        {
            var key = stream.ReadUInt64();
            var value = stream.ReadUInt16();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="string"/>-<see cref="ushort"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterStringUInt16Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(string, ushort)> IterStringUInt16DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadUInt16();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="string"/>-<see cref="ushort"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(string, ushort)> IterStringUInt16Tuples(this Stream stream)
        {
            var key = stream.ReadString();
            var value = stream.ReadUInt16();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="DateTime"/>-<see cref="ushort"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterDateTimeUInt16Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(DateTime, ushort)> IterDateTimeUInt16DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadUInt16();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="DateTime"/>-<see cref="ushort"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(DateTime, ushort)> IterDateTimeUInt16Tuples(this Stream stream)
        {
            var key = stream.ReadDateTime();
            var value = stream.ReadUInt16();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="bool"/>-<see cref="uint"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterBooleanUInt32Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(bool, uint)> IterBooleanUInt32DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadUInt32();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="bool"/>-<see cref="uint"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(bool, uint)> IterBooleanUInt32Tuples(this Stream stream)
        {
            var key = stream.ReadBoolean();
            var value = stream.ReadUInt32();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="byte"/>-<see cref="uint"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterByteUInt32Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(byte, uint)> IterByteUInt32DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadUInt32();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="byte"/>-<see cref="uint"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(byte, uint)> IterByteUInt32Tuples(this Stream stream)
        {
            var key = (byte)stream.ReadByte();
            var value = stream.ReadUInt32();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="sbyte"/>-<see cref="uint"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterSByteUInt32Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(sbyte, uint)> IterSByteUInt32DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadUInt32();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="sbyte"/>-<see cref="uint"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(sbyte, uint)> IterSByteUInt32Tuples(this Stream stream)
        {
            var key = stream.ReadSByte();
            var value = stream.ReadUInt32();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="short"/>-<see cref="uint"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt16UInt32Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(short, uint)> IterInt16UInt32DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadUInt32();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="short"/>-<see cref="uint"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(short, uint)> IterInt16UInt32Tuples(this Stream stream)
        {
            var key = stream.ReadInt16();
            var value = stream.ReadUInt32();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="int"/>-<see cref="uint"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt32UInt32Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(int, uint)> IterInt32UInt32DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadUInt32();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="int"/>-<see cref="uint"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(int, uint)> IterInt32UInt32Tuples(this Stream stream)
        {
            var key = stream.ReadInt32();
            var value = stream.ReadUInt32();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="long"/>-<see cref="uint"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt64UInt32Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(long, uint)> IterInt64UInt32DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadUInt32();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="long"/>-<see cref="uint"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(long, uint)> IterInt64UInt32Tuples(this Stream stream)
        {
            var key = stream.ReadInt64();
            var value = stream.ReadUInt32();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="ushort"/>-<see cref="uint"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt16UInt32Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(ushort, uint)> IterUInt16UInt32DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadUInt32();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="ushort"/>-<see cref="uint"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(ushort, uint)> IterUInt16UInt32Tuples(this Stream stream)
        {
            var key = stream.ReadUInt16();
            var value = stream.ReadUInt32();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="uint"/>-<see cref="uint"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt32UInt32Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(uint, uint)> IterUInt32UInt32DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadUInt32();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="uint"/>-<see cref="uint"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(uint, uint)> IterUInt32UInt32Tuples(this Stream stream)
        {
            var key = stream.ReadUInt32();
            var value = stream.ReadUInt32();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="ulong"/>-<see cref="uint"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt64UInt32Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(ulong, uint)> IterUInt64UInt32DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadUInt32();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="ulong"/>-<see cref="uint"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(ulong, uint)> IterUInt64UInt32Tuples(this Stream stream)
        {
            var key = stream.ReadUInt64();
            var value = stream.ReadUInt32();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="string"/>-<see cref="uint"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterStringUInt32Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(string, uint)> IterStringUInt32DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadUInt32();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="string"/>-<see cref="uint"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(string, uint)> IterStringUInt32Tuples(this Stream stream)
        {
            var key = stream.ReadString();
            var value = stream.ReadUInt32();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="DateTime"/>-<see cref="uint"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterDateTimeUInt32Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(DateTime, uint)> IterDateTimeUInt32DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadUInt32();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="DateTime"/>-<see cref="uint"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(DateTime, uint)> IterDateTimeUInt32Tuples(this Stream stream)
        {
            var key = stream.ReadDateTime();
            var value = stream.ReadUInt32();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="bool"/>-<see cref="ulong"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterBooleanUInt64Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(bool, ulong)> IterBooleanUInt64DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadUInt64();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="bool"/>-<see cref="ulong"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(bool, ulong)> IterBooleanUInt64Tuples(this Stream stream)
        {
            var key = stream.ReadBoolean();
            var value = stream.ReadUInt64();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="byte"/>-<see cref="ulong"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterByteUInt64Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(byte, ulong)> IterByteUInt64DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadUInt64();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="byte"/>-<see cref="ulong"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(byte, ulong)> IterByteUInt64Tuples(this Stream stream)
        {
            var key = (byte)stream.ReadByte();
            var value = stream.ReadUInt64();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="sbyte"/>-<see cref="ulong"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterSByteUInt64Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(sbyte, ulong)> IterSByteUInt64DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadUInt64();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="sbyte"/>-<see cref="ulong"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(sbyte, ulong)> IterSByteUInt64Tuples(this Stream stream)
        {
            var key = stream.ReadSByte();
            var value = stream.ReadUInt64();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="short"/>-<see cref="ulong"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt16UInt64Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(short, ulong)> IterInt16UInt64DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadUInt64();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="short"/>-<see cref="ulong"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(short, ulong)> IterInt16UInt64Tuples(this Stream stream)
        {
            var key = stream.ReadInt16();
            var value = stream.ReadUInt64();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="int"/>-<see cref="ulong"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt32UInt64Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(int, ulong)> IterInt32UInt64DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadUInt64();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="int"/>-<see cref="ulong"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(int, ulong)> IterInt32UInt64Tuples(this Stream stream)
        {
            var key = stream.ReadInt32();
            var value = stream.ReadUInt64();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="long"/>-<see cref="ulong"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt64UInt64Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(long, ulong)> IterInt64UInt64DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadUInt64();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="long"/>-<see cref="ulong"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(long, ulong)> IterInt64UInt64Tuples(this Stream stream)
        {
            var key = stream.ReadInt64();
            var value = stream.ReadUInt64();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="ushort"/>-<see cref="ulong"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt16UInt64Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(ushort, ulong)> IterUInt16UInt64DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadUInt64();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="ushort"/>-<see cref="ulong"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(ushort, ulong)> IterUInt16UInt64Tuples(this Stream stream)
        {
            var key = stream.ReadUInt16();
            var value = stream.ReadUInt64();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="uint"/>-<see cref="ulong"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt32UInt64Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(uint, ulong)> IterUInt32UInt64DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadUInt64();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="uint"/>-<see cref="ulong"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(uint, ulong)> IterUInt32UInt64Tuples(this Stream stream)
        {
            var key = stream.ReadUInt32();
            var value = stream.ReadUInt64();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="ulong"/>-<see cref="ulong"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt64UInt64Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(ulong, ulong)> IterUInt64UInt64DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadUInt64();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="ulong"/>-<see cref="ulong"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(ulong, ulong)> IterUInt64UInt64Tuples(this Stream stream)
        {
            var key = stream.ReadUInt64();
            var value = stream.ReadUInt64();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="string"/>-<see cref="ulong"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterStringUInt64Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(string, ulong)> IterStringUInt64DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadUInt64();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="string"/>-<see cref="ulong"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(string, ulong)> IterStringUInt64Tuples(this Stream stream)
        {
            var key = stream.ReadString();
            var value = stream.ReadUInt64();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="DateTime"/>-<see cref="ulong"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterDateTimeUInt64Tuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(DateTime, ulong)> IterDateTimeUInt64DictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadUInt64();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="DateTime"/>-<see cref="ulong"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(DateTime, ulong)> IterDateTimeUInt64Tuples(this Stream stream)
        {
            var key = stream.ReadDateTime();
            var value = stream.ReadUInt64();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="bool"/>-<see cref="float"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterBooleanSingleTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(bool, float)> IterBooleanSingleDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadSingle();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="bool"/>-<see cref="float"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(bool, float)> IterBooleanSingleTuples(this Stream stream)
        {
            var key = stream.ReadBoolean();
            var value = stream.ReadSingle();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="byte"/>-<see cref="float"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterByteSingleTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(byte, float)> IterByteSingleDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadSingle();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="byte"/>-<see cref="float"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(byte, float)> IterByteSingleTuples(this Stream stream)
        {
            var key = (byte)stream.ReadByte();
            var value = stream.ReadSingle();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="sbyte"/>-<see cref="float"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterSByteSingleTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(sbyte, float)> IterSByteSingleDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadSingle();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="sbyte"/>-<see cref="float"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(sbyte, float)> IterSByteSingleTuples(this Stream stream)
        {
            var key = stream.ReadSByte();
            var value = stream.ReadSingle();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="short"/>-<see cref="float"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt16SingleTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(short, float)> IterInt16SingleDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadSingle();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="short"/>-<see cref="float"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(short, float)> IterInt16SingleTuples(this Stream stream)
        {
            var key = stream.ReadInt16();
            var value = stream.ReadSingle();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="int"/>-<see cref="float"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt32SingleTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(int, float)> IterInt32SingleDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadSingle();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="int"/>-<see cref="float"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(int, float)> IterInt32SingleTuples(this Stream stream)
        {
            var key = stream.ReadInt32();
            var value = stream.ReadSingle();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="long"/>-<see cref="float"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt64SingleTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(long, float)> IterInt64SingleDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadSingle();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="long"/>-<see cref="float"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(long, float)> IterInt64SingleTuples(this Stream stream)
        {
            var key = stream.ReadInt64();
            var value = stream.ReadSingle();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="ushort"/>-<see cref="float"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt16SingleTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(ushort, float)> IterUInt16SingleDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadSingle();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="ushort"/>-<see cref="float"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(ushort, float)> IterUInt16SingleTuples(this Stream stream)
        {
            var key = stream.ReadUInt16();
            var value = stream.ReadSingle();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="uint"/>-<see cref="float"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt32SingleTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(uint, float)> IterUInt32SingleDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadSingle();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="uint"/>-<see cref="float"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(uint, float)> IterUInt32SingleTuples(this Stream stream)
        {
            var key = stream.ReadUInt32();
            var value = stream.ReadSingle();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="ulong"/>-<see cref="float"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt64SingleTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(ulong, float)> IterUInt64SingleDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadSingle();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="ulong"/>-<see cref="float"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(ulong, float)> IterUInt64SingleTuples(this Stream stream)
        {
            var key = stream.ReadUInt64();
            var value = stream.ReadSingle();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="string"/>-<see cref="float"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterStringSingleTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(string, float)> IterStringSingleDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadSingle();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="string"/>-<see cref="float"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(string, float)> IterStringSingleTuples(this Stream stream)
        {
            var key = stream.ReadString();
            var value = stream.ReadSingle();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="DateTime"/>-<see cref="float"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterDateTimeSingleTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(DateTime, float)> IterDateTimeSingleDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadSingle();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="DateTime"/>-<see cref="float"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(DateTime, float)> IterDateTimeSingleTuples(this Stream stream)
        {
            var key = stream.ReadDateTime();
            var value = stream.ReadSingle();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="bool"/>-<see cref="double"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterBooleanDoubleTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(bool, double)> IterBooleanDoubleDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadDouble();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="bool"/>-<see cref="double"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(bool, double)> IterBooleanDoubleTuples(this Stream stream)
        {
            var key = stream.ReadBoolean();
            var value = stream.ReadDouble();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="byte"/>-<see cref="double"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterByteDoubleTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(byte, double)> IterByteDoubleDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadDouble();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="byte"/>-<see cref="double"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(byte, double)> IterByteDoubleTuples(this Stream stream)
        {
            var key = (byte)stream.ReadByte();
            var value = stream.ReadDouble();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="sbyte"/>-<see cref="double"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterSByteDoubleTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(sbyte, double)> IterSByteDoubleDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadDouble();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="sbyte"/>-<see cref="double"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(sbyte, double)> IterSByteDoubleTuples(this Stream stream)
        {
            var key = stream.ReadSByte();
            var value = stream.ReadDouble();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="short"/>-<see cref="double"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt16DoubleTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(short, double)> IterInt16DoubleDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadDouble();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="short"/>-<see cref="double"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(short, double)> IterInt16DoubleTuples(this Stream stream)
        {
            var key = stream.ReadInt16();
            var value = stream.ReadDouble();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="int"/>-<see cref="double"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt32DoubleTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(int, double)> IterInt32DoubleDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadDouble();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="int"/>-<see cref="double"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(int, double)> IterInt32DoubleTuples(this Stream stream)
        {
            var key = stream.ReadInt32();
            var value = stream.ReadDouble();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="long"/>-<see cref="double"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt64DoubleTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(long, double)> IterInt64DoubleDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadDouble();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="long"/>-<see cref="double"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(long, double)> IterInt64DoubleTuples(this Stream stream)
        {
            var key = stream.ReadInt64();
            var value = stream.ReadDouble();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="ushort"/>-<see cref="double"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt16DoubleTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(ushort, double)> IterUInt16DoubleDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadDouble();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="ushort"/>-<see cref="double"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(ushort, double)> IterUInt16DoubleTuples(this Stream stream)
        {
            var key = stream.ReadUInt16();
            var value = stream.ReadDouble();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="uint"/>-<see cref="double"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt32DoubleTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(uint, double)> IterUInt32DoubleDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadDouble();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="uint"/>-<see cref="double"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(uint, double)> IterUInt32DoubleTuples(this Stream stream)
        {
            var key = stream.ReadUInt32();
            var value = stream.ReadDouble();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="ulong"/>-<see cref="double"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt64DoubleTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(ulong, double)> IterUInt64DoubleDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadDouble();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="ulong"/>-<see cref="double"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(ulong, double)> IterUInt64DoubleTuples(this Stream stream)
        {
            var key = stream.ReadUInt64();
            var value = stream.ReadDouble();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="string"/>-<see cref="double"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterStringDoubleTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(string, double)> IterStringDoubleDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadDouble();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="string"/>-<see cref="double"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(string, double)> IterStringDoubleTuples(this Stream stream)
        {
            var key = stream.ReadString();
            var value = stream.ReadDouble();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="DateTime"/>-<see cref="double"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterDateTimeDoubleTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(DateTime, double)> IterDateTimeDoubleDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadDouble();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="DateTime"/>-<see cref="double"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(DateTime, double)> IterDateTimeDoubleTuples(this Stream stream)
        {
            var key = stream.ReadDateTime();
            var value = stream.ReadDouble();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="bool"/>-<see cref="string"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterBooleanStringTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(bool, string)> IterBooleanStringDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadString();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="bool"/>-<see cref="string"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(bool, string)> IterBooleanStringTuples(this Stream stream)
        {
            var key = stream.ReadBoolean();
            var value = stream.ReadString();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="byte"/>-<see cref="string"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterByteStringTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(byte, string)> IterByteStringDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadString();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="byte"/>-<see cref="string"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(byte, string)> IterByteStringTuples(this Stream stream)
        {
            var key = (byte)stream.ReadByte();
            var value = stream.ReadString();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="sbyte"/>-<see cref="string"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterSByteStringTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(sbyte, string)> IterSByteStringDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadString();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="sbyte"/>-<see cref="string"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(sbyte, string)> IterSByteStringTuples(this Stream stream)
        {
            var key = stream.ReadSByte();
            var value = stream.ReadString();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="short"/>-<see cref="string"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt16StringTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(short, string)> IterInt16StringDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadString();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="short"/>-<see cref="string"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(short, string)> IterInt16StringTuples(this Stream stream)
        {
            var key = stream.ReadInt16();
            var value = stream.ReadString();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="int"/>-<see cref="string"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt32StringTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(int, string)> IterInt32StringDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadString();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="int"/>-<see cref="string"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(int, string)> IterInt32StringTuples(this Stream stream)
        {
            var key = stream.ReadInt32();
            var value = stream.ReadString();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="long"/>-<see cref="string"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt64StringTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(long, string)> IterInt64StringDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadString();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="long"/>-<see cref="string"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(long, string)> IterInt64StringTuples(this Stream stream)
        {
            var key = stream.ReadInt64();
            var value = stream.ReadString();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="ushort"/>-<see cref="string"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt16StringTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(ushort, string)> IterUInt16StringDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadString();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="ushort"/>-<see cref="string"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(ushort, string)> IterUInt16StringTuples(this Stream stream)
        {
            var key = stream.ReadUInt16();
            var value = stream.ReadString();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="uint"/>-<see cref="string"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt32StringTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(uint, string)> IterUInt32StringDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadString();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="uint"/>-<see cref="string"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(uint, string)> IterUInt32StringTuples(this Stream stream)
        {
            var key = stream.ReadUInt32();
            var value = stream.ReadString();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="ulong"/>-<see cref="string"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt64StringTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(ulong, string)> IterUInt64StringDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadString();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="ulong"/>-<see cref="string"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(ulong, string)> IterUInt64StringTuples(this Stream stream)
        {
            var key = stream.ReadUInt64();
            var value = stream.ReadString();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="string"/>-<see cref="string"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterStringStringTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(string, string)> IterStringStringDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadString();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="string"/>-<see cref="string"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(string, string)> IterStringStringTuples(this Stream stream)
        {
            var key = stream.ReadString();
            var value = stream.ReadString();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="DateTime"/>-<see cref="string"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterDateTimeStringTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(DateTime, string)> IterDateTimeStringDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadString();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="DateTime"/>-<see cref="string"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(DateTime, string)> IterDateTimeStringTuples(this Stream stream)
        {
            var key = stream.ReadDateTime();
            var value = stream.ReadString();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="bool"/>-<see cref="DateTime"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterBooleanDateTimeTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(bool, DateTime)> IterBooleanDateTimeDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadDateTime();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="bool"/>-<see cref="DateTime"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(bool, DateTime)> IterBooleanDateTimeTuples(this Stream stream)
        {
            var key = stream.ReadBoolean();
            var value = stream.ReadDateTime();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="byte"/>-<see cref="DateTime"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterByteDateTimeTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(byte, DateTime)> IterByteDateTimeDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadDateTime();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="byte"/>-<see cref="DateTime"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(byte, DateTime)> IterByteDateTimeTuples(this Stream stream)
        {
            var key = (byte)stream.ReadByte();
            var value = stream.ReadDateTime();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="sbyte"/>-<see cref="DateTime"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterSByteDateTimeTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(sbyte, DateTime)> IterSByteDateTimeDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadDateTime();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="sbyte"/>-<see cref="DateTime"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(sbyte, DateTime)> IterSByteDateTimeTuples(this Stream stream)
        {
            var key = stream.ReadSByte();
            var value = stream.ReadDateTime();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="short"/>-<see cref="DateTime"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt16DateTimeTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(short, DateTime)> IterInt16DateTimeDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadDateTime();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="short"/>-<see cref="DateTime"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(short, DateTime)> IterInt16DateTimeTuples(this Stream stream)
        {
            var key = stream.ReadInt16();
            var value = stream.ReadDateTime();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="int"/>-<see cref="DateTime"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt32DateTimeTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(int, DateTime)> IterInt32DateTimeDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadDateTime();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="int"/>-<see cref="DateTime"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(int, DateTime)> IterInt32DateTimeTuples(this Stream stream)
        {
            var key = stream.ReadInt32();
            var value = stream.ReadDateTime();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="long"/>-<see cref="DateTime"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt64DateTimeTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(long, DateTime)> IterInt64DateTimeDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadDateTime();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="long"/>-<see cref="DateTime"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(long, DateTime)> IterInt64DateTimeTuples(this Stream stream)
        {
            var key = stream.ReadInt64();
            var value = stream.ReadDateTime();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="ushort"/>-<see cref="DateTime"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt16DateTimeTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(ushort, DateTime)> IterUInt16DateTimeDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadDateTime();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="ushort"/>-<see cref="DateTime"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(ushort, DateTime)> IterUInt16DateTimeTuples(this Stream stream)
        {
            var key = stream.ReadUInt16();
            var value = stream.ReadDateTime();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="uint"/>-<see cref="DateTime"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt32DateTimeTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(uint, DateTime)> IterUInt32DateTimeDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadDateTime();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="uint"/>-<see cref="DateTime"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(uint, DateTime)> IterUInt32DateTimeTuples(this Stream stream)
        {
            var key = stream.ReadUInt32();
            var value = stream.ReadDateTime();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="ulong"/>-<see cref="DateTime"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt64DateTimeTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(ulong, DateTime)> IterUInt64DateTimeDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadDateTime();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="ulong"/>-<see cref="DateTime"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(ulong, DateTime)> IterUInt64DateTimeTuples(this Stream stream)
        {
            var key = stream.ReadUInt64();
            var value = stream.ReadDateTime();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="string"/>-<see cref="DateTime"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterStringDateTimeTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(string, DateTime)> IterStringDateTimeDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadDateTime();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="string"/>-<see cref="DateTime"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(string, DateTime)> IterStringDateTimeTuples(this Stream stream)
        {
            var key = stream.ReadString();
            var value = stream.ReadDateTime();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="DateTime"/>-<see cref="DateTime"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterDateTimeDateTimeTuples" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(DateTime, DateTime)> IterDateTimeDateTimeDictPairs(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadDateTime();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="DateTime"/>-<see cref="DateTime"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(DateTime, DateTime)> IterDateTimeDateTimeTuples(this Stream stream)
        {
            var key = stream.ReadDateTime();
            var value = stream.ReadDateTime();
            yield return (key, value);
        }



        /// <summary>
        /// Iterates <see cref="bool"/>-<see cref="IBinarySavable"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterBooleanBinarySavableTuples{T}" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(bool, T)> IterBooleanBinarySavableDictPairs<T>(this Stream stream, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadBoolean();
                    var value = stream.ReadBinarySavable<T>();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="bool"/>-<see cref="IBinarySavable"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(bool, T)> IterBooleanBinarySavableTuples<T>(this Stream stream) where T : IBinarySavable, new()
        {
            var key = stream.ReadBoolean();
            var value = stream.ReadBinarySavable<T>();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="byte"/>-<see cref="IBinarySavable"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterByteBinarySavableTuples{T}" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(byte, T)> IterByteBinarySavableDictPairs<T>(this Stream stream, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = (byte)stream.ReadByte();
                    var value = stream.ReadBinarySavable<T>();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="byte"/>-<see cref="IBinarySavable"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(byte, T)> IterByteBinarySavableTuples<T>(this Stream stream) where T : IBinarySavable, new()
        {
            var key = (byte)stream.ReadByte();
            var value = stream.ReadBinarySavable<T>();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="sbyte"/>-<see cref="IBinarySavable"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterSByteBinarySavableTuples{T}" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(sbyte, T)> IterSByteBinarySavableDictPairs<T>(this Stream stream, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadSByte();
                    var value = stream.ReadBinarySavable<T>();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="sbyte"/>-<see cref="IBinarySavable"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(sbyte, T)> IterSByteBinarySavableTuples<T>(this Stream stream) where T : IBinarySavable, new()
        {
            var key = stream.ReadSByte();
            var value = stream.ReadBinarySavable<T>();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="short"/>-<see cref="IBinarySavable"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt16BinarySavableTuples{T}" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(short, T)> IterInt16BinarySavableDictPairs<T>(this Stream stream, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt16();
                    var value = stream.ReadBinarySavable<T>();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="short"/>-<see cref="IBinarySavable"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(short, T)> IterInt16BinarySavableTuples<T>(this Stream stream) where T : IBinarySavable, new()
        {
            var key = stream.ReadInt16();
            var value = stream.ReadBinarySavable<T>();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="int"/>-<see cref="IBinarySavable"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt32BinarySavableTuples{T}" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(int, T)> IterInt32BinarySavableDictPairs<T>(this Stream stream, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt32();
                    var value = stream.ReadBinarySavable<T>();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="int"/>-<see cref="IBinarySavable"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(int, T)> IterInt32BinarySavableTuples<T>(this Stream stream) where T : IBinarySavable, new()
        {
            while (stream.Position != stream.Length)
            {
                var key = stream.ReadInt32();
                var value = stream.ReadBinarySavable<T>();
                yield return (key, value);
            }
        }

        /// <summary>
        /// Iterates <see cref="long"/>-<see cref="IBinarySavable"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterInt64BinarySavableTuples{T}" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(long, T)> IterInt64BinarySavableDictPairs<T>(this Stream stream, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadInt64();
                    var value = stream.ReadBinarySavable<T>();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="long"/>-<see cref="IBinarySavable"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(long, T)> IterInt64BinarySavableTuples<T>(this Stream stream) where T : IBinarySavable, new()
        {
            var key = stream.ReadInt64();
            var value = stream.ReadBinarySavable<T>();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="ushort"/>-<see cref="IBinarySavable"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt16BinarySavableTuples{T}" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(ushort, T)> IterUInt16BinarySavableDictPairs<T>(this Stream stream, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt16();
                    var value = stream.ReadBinarySavable<T>();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="ushort"/>-<see cref="IBinarySavable"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(ushort, T)> IterUInt16BinarySavableTuples<T>(this Stream stream) where T : IBinarySavable, new()
        {
            var key = stream.ReadUInt16();
            var value = stream.ReadBinarySavable<T>();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="uint"/>-<see cref="IBinarySavable"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt32BinarySavableTuples{T}" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(uint, T)> IterUInt32BinarySavableDictPairs<T>(this Stream stream, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt32();
                    var value = stream.ReadBinarySavable<T>();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="uint"/>-<see cref="IBinarySavable"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(uint, T)> IterUInt32BinarySavableTuples<T>(this Stream stream) where T : IBinarySavable, new()
        {
            var key = stream.ReadUInt32();
            var value = stream.ReadBinarySavable<T>();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="ulong"/>-<see cref="IBinarySavable"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterUInt64BinarySavableTuples{T}" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(ulong, T)> IterUInt64BinarySavableDictPairs<T>(this Stream stream, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadUInt64();
                    var value = stream.ReadBinarySavable<T>();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="ulong"/>-<see cref="IBinarySavable"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(ulong, T)> IterUInt64BinarySavableTuples<T>(this Stream stream) where T : IBinarySavable, new()
        {
            var key = stream.ReadUInt64();
            var value = stream.ReadBinarySavable<T>();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="string"/>-<see cref="IBinarySavable"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterStringBinarySavableTuples{T}" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(string, T)> IterStringBinarySavableDictPairs<T>(this Stream stream, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadString();
                    var value = stream.ReadBinarySavable<T>();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="string"/>-<see cref="IBinarySavable"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(string, T)> IterStringBinarySavableTuples<T>(this Stream stream) where T : IBinarySavable, new()
        {
            var key = stream.ReadString();
            var value = stream.ReadBinarySavable<T>();
            yield return (key, value);
        }

        /// <summary>
        /// Iterates <see cref="DateTime"/>-<see cref="IBinarySavable"/> tuples from the stream. There can be a data checking code and a count in the stream prior to all data pairs. To only read pairs, use <see cref="IterDateTimeBinarySavableTuples{T}" /> instead.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck"><c>true</c> if a 8-byte code is read from the stream before all actual data. If this code is not the expected value, then the data in the stream is corrupted.</param>
        public static IEnumerator<(DateTime, T)> IterDateTimeBinarySavableDictPairs<T>(this Stream stream, bool validityCheck = false) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check((Int64)0x212DF455DFABE3C))
            {
                var count = stream.ReadInt32();
                if (count < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataNotEnough);
                for (var i = 0; i < count; ++i)
                {
                    var key = stream.ReadDateTime();
                    var value = stream.ReadBinarySavable<T>();
                    yield return (key, value);
                }
            }
        }

        /// <summary>
        /// Iterates <see cref="DateTime"/>-<see cref="IBinarySavable"/> key-value tuples from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        public static IEnumerator<(DateTime, T)> IterDateTimeBinarySavableTuples<T>(this Stream stream) where T : IBinarySavable, new()
        {
            var key = stream.ReadDateTime();
            var value = stream.ReadBinarySavable<T>();
            yield return (key, value);
        }
    }
}
