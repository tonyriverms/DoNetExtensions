using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using DoNetExtension.System.IO;

namespace System.IO
{
    /// <summary>
    /// A method converting a specified object to byte array.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="obj">The object to convert.</param>
    /// <returns>A byte array representing the object.</returns>
    public delegate byte[] ObjectToBytesConverter<in T>(T obj);

    /// <summary>
    /// A method converting a given byte array to an object.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="bytes">The byte array to convert.</param>
    /// <returns>An object of the specified type converted from the given byte array.</returns>
    public delegate T BytesToObjectConverter<out T>(byte[] bytes);

    public static partial class StreamEx
    {
        #region Basic

        /// <summary>
        /// Dumps the objects as their string representations in a text file at <paramref name="path" />, each object as a line..
        /// </summary>
        /// <typeparam name="T">The type of current objects.</typeparam>
        /// <param name="objs">The current objs.</param>
        /// <param name="path">The path to the text file.</param>
        /// <param name="encoding">Provides the text encoding.</param>
        public static void DumpText<T>(this IEnumerable<T> objs, string path, Encoding encoding)
        {
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (var sw = new StreamWriter(fs, encoding))
                {
                    foreach (var obj in objs)
                        sw.WriteLine(obj);
                }
            }
        }

        /// <summary>
        /// Dumps the objects as their string representations in a text file at <paramref name="path" />, each object as a line..
        /// </summary>
        /// <typeparam name="T">The type of current objects.</typeparam>
        /// <param name="objs">The current objs.</param>
        /// <param name="path">The path to the text file.</param>
        public static void DumpText<T>(this IEnumerable<T> objs, string path)
        {
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (var sw = new StreamWriter(fs))
                {
                    foreach (var obj in objs)
                        sw.WriteLine(obj);
                }
            }
        }

        /// <summary>
        /// Dumps the objects as their string representations in a text file at <paramref name="path" />, delimited by tabs <c>'\t'</c>.
        /// </summary>
        /// <typeparam name="T">The type of current objects.</typeparam>
        /// <param name="objs">The current objs.</param>
        /// <param name="path">The path to the text file.</param>
        /// <param name="encoding">Provides the text encoding.</param>
        public static void DumpText<T>(this IEnumerable<IEnumerable<T>> objs, string path, Encoding encoding)
        {
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (var sw = new StreamWriter(fs, encoding))
                {
                    foreach (var row in objs)
                        sw.WriteLineWithDelimiter('\t', row);
                }
            }
        }

        /// <summary>
        /// Dumps the objects as their string representations in a text file at <paramref name="path" />, delimited by tabs <c>'\t'</c>.
        /// </summary>
        /// <typeparam name="T">The type of current objects.</typeparam>
        /// <param name="objs">The current objs.</param>
        /// <param name="path">The path to the text file.</param>
        public static void DumpText<T>(this IEnumerable<IEnumerable<T>> objs, string path)
        {
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (var sw = new StreamWriter(fs))
                {
                    foreach (var row in objs)
                        sw.WriteLineWithDelimiter('\t', row);
                }
            }
        }

        /// <summary>
        /// Dumps the objects as their string representations in a text file at <paramref name="path" />, each object as a line.
        /// </summary>
        /// <typeparam name="T">The type of current objects.</typeparam>
        /// <param name="objs">The current objs.</param>
        /// <param name="path">The path to the text file.</param>
        /// <param name="encoding">Provides the text encoding.</param>
        public static void DumpText<T>(this T[][] objs, string path, Encoding encoding)
        {
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (var sw = new StreamWriter(fs, encoding))
                {
                    foreach (var row in objs)
                        sw.WriteLineWithDelimiter('\t', row);
                }
            }
        }

        /// <summary>
        /// Dumps the objects as their string representations in a text file at <paramref name="path" />, each object as a line.
        /// </summary>
        /// <typeparam name="T">The type of current objects.</typeparam>
        /// <param name="objs">The current objs.</param>
        /// <param name="path">The path to the text file.</param>
        public static void DumpText<T>(this T[] objs, string path)
        {
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (var sw = new StreamWriter(fs))
                {
                    foreach (var obj in objs)
                        sw.WriteLine(obj);
                }
            }
        }

        /// <summary>
        /// Dumps the objects as their string representations in a text file at <paramref name="path" />, delimited by tabs <c>'\t'</c>.
        /// </summary>
        /// <typeparam name="T">The type of current objects.</typeparam>
        /// <param name="objs">The current objs.</param>
        /// <param name="path">The path to the text file.</param>
        /// <param name="encoding">Provides the text encoding.</param>
        public static void DumpText<T>(this T[] objs, string path, Encoding encoding)
        {
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (var sw = new StreamWriter(fs, encoding))
                {
                    foreach (var obj in objs)
                        sw.WriteLine(obj);
                }
            }
        }

        /// <summary>
        /// Dumps the object arrays as their string representations in a text file at <paramref name="path" />, each line for one array and string representations of objects in one array delimited by tabs <c>'\t'</c>.
        /// </summary>
        /// <typeparam name="T">The type of current objects.</typeparam>
        /// <param name="objs">The current objs.</param>
        /// <param name="path">The path to the text file.</param>
        public static void DumpText<T>(this T[][] objs, string path)
        {
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (var sw = new StreamWriter(fs))
                {
                    foreach (var row in objs)
                        sw.WriteLineWithDelimiter('\t', row);
                }
            }
        }

        public static void Serialize<T>(this T obj, Stream stream) where T : new()
        {
            if (obj != null)
            {
                var bf = new BinaryFormatter();
                bf.Serialize(stream, obj);
            }
        }

        public static void Serialize<T>(this T obj, string path, FileMode mode = FileMode.OpenOrCreate) where T : new()
        {
            if (obj != null)
            {
                var bf = new BinaryFormatter();
                using (var fs = new FileStream(path, mode))
                    bf.Serialize(fs, obj);
            }
        }

        public static byte[] Serialize<T>(this T obj) where T : new()
        {
            if (obj == null) return null;
            var bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Deserialize<T>(this Stream stream) where T : new()
        {
            var binForm = new BinaryFormatter();
            return (T)binForm.Deserialize(stream);
        }


        public static T Deserialize<T>(this string path) where T : new()
        {
            var binForm = new BinaryFormatter();
            using (var fs = File.OpenRead(path))
                return (T)binForm.Deserialize(fs);
        }

        public static T Deserialize<T>(this byte[] bytes) where T : new()
        {
            var memStream = new MemoryStream(bytes);
            var binForm = new BinaryFormatter();
            return (T)binForm.Deserialize(memStream);
        }

        public static void Dump(this IEnumerable collection, Type objType, Stream stream)
        {
            var pos = stream.Position;
            stream.WriteInt32(0);

            var fields = objType.GetFields(Reflection.BindingFlags.Instance | Reflection.BindingFlags.Public | Reflection.BindingFlags.NonPublic);
            var fieldCount = (UInt16)fields.Length;
            stream.WriteUInt16(fieldCount);
            var objCount = 0;
            foreach (var obj in collection)
            {
                for (int i = 0; i < fieldCount; ++i)
                {
                    var field = fields[i];
                    stream.WriteObject(field.GetValue(obj));
                }
                ++objCount;
            }

            var endPos = stream.Position;
            stream.SeekTo(pos);
            stream.WriteInt32(objCount);
            stream.SeekTo(endPos);
        }

        public static void Dump<T>(this IEnumerable<T> collection, Stream stream) where T : new()
        {
            collection.Dump(typeof(T), stream);
        }

        public static T[] LoadDump<T>(this Stream stream) where T : new()
        {
            var objCount = stream.ReadInt32();
            var fieldCount = stream.ReadUInt16();
            var fields = typeof(T).GetFields(Reflection.BindingFlags.Instance | Reflection.BindingFlags.Public | Reflection.BindingFlags.NonPublic);
            var arr = new T[objCount];

            for (int j = 0; j < objCount; ++j)
            {
                var obj = new T();
                for (int i = 0; i < fieldCount; ++i)
                {
                    var field = fields[i];
                    field.SetValue(obj, stream.ReadObject());
                }
                arr[j] = obj;
            }
            return arr;
        }

        public static void Dump<T>(this IEnumerable<T> collection, string path, FileMode mode = FileMode.OpenOrCreate) where T : new()
        {
            if (collection != null)
            {
                using (var fs = new FileStream(path, mode))
                    collection.Dump(fs);
            }
        }

        public static T[] LoadDump<T>(this string path) where T : new()
        {
            using (var fs = File.OpenRead(path))
                return fs.LoadDump<T>();
        }

        /// <summary>
        /// Writes an object to this stream.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="obj">A System.Object.</param>
        /// <param name="converter">A method that converts the object to bytes.</param>
        /// <param name="validityCheck">Indicates whether to write a check code before the actual data. This check code will help detect corrupted data.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int WriteObject<T>(this Stream stream, T obj, ObjectToBytesConverter<T> converter, bool validityCheck = true)
        {
            return stream.WriteByteArray(converter(obj), validityCheck);
        }

        enum _commonObjectTypeMapping : byte
        {
            _string = 0,
            _int32 = 1,
            _int64 = 2,
            _uint32 = 3,
            _uint64 = 4,
            _byte = 5,
            _int16 = 6,
            _uint16 = 7,
            _datetime = 8,
            _sbyte = 9,
            _single = 10,
            _double = 11,
            _byteArray = 12,
            _intlist = 13,
            _intarr = 14,
            _glist = 15,
            _nglist = 16
        }


        public static void WriteObject(this Stream stream, object obj)
        {
            switch (obj)
            {
                case string str:
                    stream.WriteByte((byte)_commonObjectTypeMapping._string);
                    stream.WriteString(str);
                    break;
                case Int32 i32:
                    stream.WriteByte((byte)_commonObjectTypeMapping._int32);
                    stream.WriteInt32(i32);
                    break;
                case Int64 i64:
                    stream.WriteByte((byte)_commonObjectTypeMapping._int64);
                    stream.WriteInt64(i64);
                    break;
                case Double d:
                    stream.WriteByte((Byte)_commonObjectTypeMapping._double);
                    stream.WriteDouble(d);
                    break;
                case Single s:
                    stream.WriteByte((Byte)_commonObjectTypeMapping._single);
                    stream.WriteSingle(s);
                    break;
                case DateTime t:
                    stream.WriteByte((Byte)_commonObjectTypeMapping._datetime);
                    stream.WriteDateTime(t);
                    break;
                case UInt32 ui32:
                    stream.WriteByte((byte)_commonObjectTypeMapping._uint32);
                    stream.WriteUInt32(ui32);
                    break;
                case UInt64 ui64:
                    stream.WriteByte((byte)_commonObjectTypeMapping._uint64);
                    stream.WriteUInt64(ui64);
                    break;
                case Byte b:
                    stream.WriteByte((byte)_commonObjectTypeMapping._byte);
                    stream.WriteByte(b);
                    break;
                case Int16 i16:
                    stream.WriteByte((Byte)_commonObjectTypeMapping._int16);
                    stream.WriteInt16(i16);
                    break;
                case UInt16 ui16:
                    stream.WriteByte((Byte)_commonObjectTypeMapping._uint16);
                    stream.WriteUInt16(ui16);
                    break;
                case SByte sb:
                    stream.WriteByte((Byte)_commonObjectTypeMapping._sbyte);
                    stream.WriteSByte(sb);
                    break;
                case Int32[] i32arr:
                    stream.WriteByte((Byte)_commonObjectTypeMapping._intarr);
                    stream.WriteInt32Array(i32arr, false);
                    break;
                case List<int> i32list:
                    stream.WriteByte((Byte)_commonObjectTypeMapping._intlist);
                    stream.WriteInt32Array(((List<int>)obj).ToArray(), false);
                    break;
                case Byte[] bytearr:
                    stream.WriteByte((Byte)_commonObjectTypeMapping._byteArray);
                    stream.WriteByteArray(bytearr, false);
                    break;
                case IList glist:
                    {
                        var type = glist.GetType();
                        if (type.IsGenericType)
                        {
                            //? if the type is consistent through the list

                            stream.WriteByte((Byte)_commonObjectTypeMapping._glist);
                            stream.WriteString(type.FullName, false); // writes list full name
                            var gtype = type.GetGenericArguments()[0];
                            stream.WriteString(gtype.FullName, false); // writes object type full name
                            var objCount = glist.Count;
                            stream.WriteInt32(objCount); // writes object count

                            var fields = gtype.GetFields(Reflection.BindingFlags.Instance | Reflection.BindingFlags.Public | Reflection.BindingFlags.NonPublic);
                            var fieldCount = (UInt16)fields.Length;
                            stream.WriteUInt16(fieldCount); // writes field count

                            // writes list to stream
                            for (int j = 0; j < objCount; ++j)
                            {
                                for (int i = 0; i < fieldCount; ++i)
                                {
                                    var field = fields[i];
                                    stream.WriteObject(field.GetValue(glist[j]));
                                }
                            }
                        }
                        else
                        {
                            stream.WriteByte((Byte)_commonObjectTypeMapping._nglist);
                            stream.WriteString(type.FullName, false);

                            var count = glist.Count;
                            stream.WriteInt32(count);
                            for (int i = 0; i < count; ++i)
                                stream.WriteObject(glist[i]);
                        }
                        break;
                    }
                default:
                    {
                        var type = obj.GetType();
                        stream.WriteString(type.FullName, false);
                        var fields = obj.GetType().GetFields(Reflection.BindingFlags.Instance | Reflection.BindingFlags.Public | Reflection.BindingFlags.NonPublic);
                        var fieldCount = (UInt16)fields.Length;
                        stream.WriteUInt16(fieldCount);
                        for (int i = 0; i < fieldCount; ++i)
                        {
                            var field = fields[i];
                            stream.WriteObject(field.GetValue(obj));
                        }
                        break;
                    }
            }
        }

        public static object ReadObject(this Stream stream)
        {
            var type = (_commonObjectTypeMapping)stream.ReadByte();
            switch (type)
            {
                case _commonObjectTypeMapping._string:
                    return stream.ReadString();
                case _commonObjectTypeMapping._int32:
                    return stream.ReadInt32();
                case _commonObjectTypeMapping._int64:
                    return stream.ReadInt64();
                case _commonObjectTypeMapping._uint32:
                    return stream.ReadUInt32();
                case _commonObjectTypeMapping._uint64:
                    return stream.ReadUInt64();
                case _commonObjectTypeMapping._byte:
                    {
                        var read = stream.ReadByte();
                        if (read < Byte.MinValue || read > byte.MaxValue) throw new IOException();
                        else return (Byte)read;
                    }
                case _commonObjectTypeMapping._datetime:
                    return stream.ReadDateTime();
                case _commonObjectTypeMapping._int16:
                    return stream.ReadInt16();
                case _commonObjectTypeMapping._uint16:
                    return stream.ReadUInt16();
                case _commonObjectTypeMapping._single:
                    return stream.ReadSingle();
                case _commonObjectTypeMapping._double:
                    return stream.ReadDouble();
                case _commonObjectTypeMapping._sbyte:
                    return stream.ReadSByte();
                case _commonObjectTypeMapping._byteArray:
                    return stream.ReadByteArray();
                case _commonObjectTypeMapping._intarr:
                    return stream.ReadInt32Array(false);
                case _commonObjectTypeMapping._intlist:
                    return new List<int>(stream.ReadInt32Array(false));
                case _commonObjectTypeMapping._glist:
                    {
                        var glistname = stream.ReadString(false);
                        var glist = (IList)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(glistname);
                        var count = stream.ReadInt32();
                        for (int i = 0; i < count; ++i)
                            glist.Add(stream.ReadObject());
                        return null;
                        break;
                    }
                default:
                    {
                        return null;
                        break;
                    }
            }
        }

        /// <summary>
        /// Reads an object from this stream.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream">The stream to read.</param>
        /// <param name="converter">A method that converts the read bytes to output object.</param>
        /// <param name="validityCheck">Set this parameter <c>true</c> if there is a check code before the actual data to prevent data corruption; otherwise, set this <c>false</c>.</param>
        /// <returns>An object converted from the bytes read.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object ReadObject<T>(this Stream stream, BytesToObjectConverter<T> converter, bool validityCheck = true)
        {
            return converter(stream.ReadByteArray(validityCheck));
        }

        /// <summary>
        /// Skips an object in this stream.
        /// </summary>
        /// <param name="stream">A System.IO.Stream.</param>
        /// <param name="validityCheck">Set this parameter <c>true</c> if there is a check code before the actual data to prevent data corruption; otherwise, set this <c>false</c>.</param>
        public static void SkipObject(this Stream stream, bool validityCheck = true)
        {
            stream.SkipByteArray(validityCheck);
        }

        #endregion



        #region Key

        /// <summary>
        /// Writes a <see cref="System.Key"/> into this stream.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="key">The <see cref="System.Key"/> to write to the stream.</param>
        public static void WriteKey(this Stream stream, Key key)
        {
            stream.WriteByteArray(key._bytes, false);
        }

        /// <summary>
        /// Reads a <see cref="System.Key"/> from this stream.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <returns>A <see cref="System.Key"/> read from the stream.</returns>
        public static Key ReadKey(this Stream stream)
        {
            return new Key(stream.ReadByteArray(), false);
        }

        #endregion

        #region Not Ready

        /// <summary>
        /// Writes a System.Segment object into this stream.
        /// </summary>
        /// <param name="stream">This stream.</param>
        /// <param name="mapping">A System.Segment object.</param>
        internal static void WriteSegmentMapping(this Stream stream, SegmentMapping mapping, bool validityCheck = false)
        {
            if (validityCheck)
                stream.WriteCheckCode(IOChecks.Common);
            stream.WriteInt32(mapping.OriginalStartPosition);
            stream.WriteInt32(mapping.OriginalEndPosition);
            stream.WriteInt32(mapping.MappingStartPosition);
            stream.WriteInt32(mapping.MappingEndPosition);
        }

        /// <summary>
        /// Reads a System.Segment object from this stream.
        /// </summary>
        /// <param name="stream">This stream.</param>
        /// <returns>A System.Segment object.</returns>
        internal static SegmentMapping ReadSegmentMapping(this Stream stream, bool validityCheck = false)
        {
            if (!validityCheck || stream.Check(IOChecks.Common))
            {
                var b = new SegmentMapping();
                b.OriginalStartPosition = stream.ReadInt32();
                b.OriginalEndPosition = stream.ReadInt32();
                b.MappingStartPosition = stream.ReadInt32();
                b.MappingEndPosition = stream.ReadInt32();
                return b;
            }
            else
                throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
        }

        internal static bool TryWriteObject(this Stream stream, object obj, Type type = null)
        {
            var success = true;
            if (type == null)
                type = obj.GetType();
            if (type == typeof(string))
                stream.WriteString(obj as string, null, ByteCompressionMethods.None, true, false);
            else if (type == typeof(Int32))
                stream.WriteInt32((Int32)obj);
            else if (type == typeof(Int64))
                stream.WriteInt64((Int64)obj);
            else if (type == typeof(Byte))
                stream.WriteByte((Byte)obj);
            else if (type == typeof(UInt32))
                stream.WriteUInt32((UInt32)obj);
            else if (type == typeof(UInt64))
                stream.WriteUInt64((UInt64)obj);
            else if (type == typeof(UInt16))
                stream.WriteUInt16((UInt16)obj);
            else if (type == typeof(Int16))
                stream.WriteInt16((Int16)obj);
            else if (type == typeof(Double))
                stream.WriteDouble((Double)obj);
            else if (type == typeof(Single))
                stream.WriteSingle((Single)obj);
            else if (type == typeof(DateTime))
                stream.WriteDateTime((DateTime)obj);
            else if (type == typeof(SByte))
                stream.WriteSByte((SByte)obj);
            else if (type == typeof(Char))
                stream.WriteChar((Char)obj);
            else if (type.IsEnum)
                stream.WriteInt32((Int32)obj);
            else if (type == typeof(Decimal))
                throw new InvalidOperationException();
            else
            {
                try
                {
                    var mi = type.GetMethod("SaveToStream", new Type[] { typeof(Stream) });
                    if (mi == null) success = false;
                    else mi.Invoke(obj, new object[] { stream });
                }
                catch { success = false; }
            }
            return success;
        }

        internal static dynamic TryReadObject(this Stream stream, Type type)
        {
            if (type == typeof(string))
                return stream.ReadString(false);
            else if (type == typeof(Int32))
                return stream.ReadInt32();
            else if (type == typeof(Int64))
                return stream.ReadInt64();
            else if (type == typeof(Byte))
                return stream.ReadByte();
            else if (type == typeof(UInt32))
                return stream.ReadUInt32();
            else if (type == typeof(UInt64))
                return stream.ReadUInt64();
            else if (type == typeof(UInt16))
                return stream.ReadUInt16();
            else if (type == typeof(Int16))
                return stream.ReadInt16();
            else if (type == typeof(Double))
                return stream.ReadDouble();
            else if (type == typeof(Single))
                return stream.ReadSingle();
            else if (type == typeof(DateTime))
                return stream.ReadDateTime();
            else if (type == typeof(SByte))
                return stream.ReadSByte();
            else if (type == typeof(Char))
                return stream.ReadChar();
            else if (type.IsEnum)
                throw new InvalidOperationException();
            else if (type == typeof(Decimal))
                throw new InvalidOperationException();
            else
                return Activator.CreateInstance(type, new object[] { stream });
        }

        #endregion
    }
}
