using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DoNetExtension.System.IO;
using System.Collections;
using System.Diagnostics;

//Note: All stuff in this file is tested, but not guaranteed bug-free for now. (5/6/2010)

namespace System.IO
{
    /// <summary>
    /// Represents two modes of writing.
    /// </summary>
    public enum WritingMode
    {
        /// <summary>
        /// Creates a new record.
        /// </summary>
        New,
        /// <summary>
        /// Overrides the existing record.
        /// </summary>
        Override
    }

    /// <summary>
    /// Provides methods of IO operation for lists and collections.
    /// </summary>
    public static partial class StreamEx
    {
        static int _byteArrayOccupancy(this Stream stream, byte[] array, bool validityCheck = true)
        {
            return validityCheck ?
                sizeof(Int64) + array.Length + sizeof(Int32) :
                array.Length + sizeof(Int32);
        }

        static void _writeEnumeratorToEnd<T>(Stream stream,
            IEnumerator enumerator, ObjectToBytesConverter<T> converter,
            bool validityCheck)
        {
            var lengthPos = stream.Position;

            stream.WriteInt32(0);
            stream.WriteInt32(0);
            stream.WriteInt64(0);

            int len = 0;

            do
            {
                if (enumerator.Current != null)
                    len += stream.WriteObject((T)enumerator.Current, converter, validityCheck);
            }
            while (enumerator.MoveNext());

            var endPos = stream.Position;

            stream.SeekTo(lengthPos);
            stream.WriteInt32(len);
            stream.WriteInt32(len);
            stream.SeekTo(endPos);
        }

        /// <summary>
        /// Writes a set of objects, each of them fetched from an enumerator, to this stream.
        /// </summary>
        /// <param name="stream">A <see cref="System.IO.Stream"/>.</param>
        /// <param name="enumerator">An enumerator used to get each object.</param>
        /// <param name="mode">Indicates whether to override existing list or create a new list in the stream.</param>
        /// <param name="converter">A delegate used to convert each item in the list to a byte array.</param>
        /// <param name="validityCheck">Indicates whether to write a validity-check countersign before the list in the stream.</param>
        public static void WriteObjects<T>(this Stream stream, IEnumerator enumerator, WritingMode mode,
            ObjectToBytesConverter<T> converter, bool validityCheck = true)
        {
            if (mode == WritingMode.New)
            {
                if (validityCheck)
                    stream.WriteCheckCode((Int64)29);

                if (enumerator.MoveNext())
                    _writeEnumeratorToEnd(stream, enumerator, converter, validityCheck);
                else
                {
                    stream.WriteInt32(0);
                    stream.WriteInt32(0);
                    stream.WriteInt64(0);
                }
            }
            else
            {
                if (!validityCheck || stream.Check((Int64)29))
                {
                    int i = 0;
                    bool moreObjs = enumerator.MoveNext();
                    if (!moreObjs)
                    {
                        stream.SkipInt32();
                        stream.WriteInt32(0);
                        var next = stream.ReadInt64();
                        stream.WriteInt64(-Math.Abs(next));
                        return;
                    }

                    while (moreObjs)
                    {
                        var len = stream.ReadInt32();
                        var olen = len;

                        var usedLenPos = stream.Position;
                        var usedLen = stream.ReadInt32();

                        var nextPtrPos = stream.Position;
                        var next = stream.ReadInt64();

                        int objLen;
                        for (; len > 0 && moreObjs; len -= objLen, i++)
                        {
                            var b = converter((T)enumerator.Current);
                            objLen = stream._byteArrayOccupancy(b, validityCheck);

                            if (objLen > len) break;
                            else
                            {
                                stream.WriteByteArray(b, validityCheck);
                                moreObjs = enumerator.MoveNext();
                            }
                        }

                        var nUsedLen = olen - len;

                        var currPos = stream.Position;
                        stream.SeekTo(usedLenPos);
                        stream.WriteInt32(nUsedLen);
                        stream.SeekTo(currPos);

                        if (moreObjs)
                        {
                            if (next == 0)
                            {
                                stream.SeekTo(nextPtrPos);
                                stream.WriteInt64(stream.Length);
                                stream.SeekToEnd();

                                _writeEnumeratorToEnd(stream, enumerator, converter, validityCheck);
                                break;
                            }
                            else
                            {
                                if (next < 0)
                                {
                                    stream.SeekTo(nextPtrPos);
                                    next = -next;
                                    stream.WriteInt64(next);
                                }
                                stream.SeekTo(next);
                            }
                        }
                        else
                        {
                            if (next != 0)
                            {
                                currPos = stream.Position;
                                stream.SeekTo(nextPtrPos);
                                stream.WriteInt64(-Math.Abs(next));
                                stream.SeekTo(currPos);
                                break;
                            }
                        }
                    }
                }
                else
                    throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
            }
        }

        /// <summary>
        /// Reads objects from this stream and stores them in a list.
        /// </summary>
        /// <param name="stream">A <see cref="System.IO.Stream"/>.</param>
        /// <param name="list">A list used to store the objects.</param>
        /// <param name="converter">A delegate used to convert the read bytes to the desired object.</param>
        /// <param name="validityCheck">Indicates whether to read a countersign from the stream and perform the validity check.</param>
        public static void ReadObjects<T>(this Stream stream,
            IList<T> list, BytesToObjectConverter<T> converter, bool validityCheck = true)
        {
            var pos = stream.Position;

            if (!validityCheck || stream.Check((Int64)29))
            {
                while (true)
                {
                    var len = stream.ReadInt32();
                    if (len < 0)
                    {
                        stream.SeekTo(pos);
                        throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
                    }

                    var occupancy = stream.ReadInt32();

                    if (occupancy < 0)
                    {
                        stream.SeekTo(pos);
                        throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
                    }

                    var next = stream.ReadInt64();
                    while (occupancy > 0)
                    {
                        var p1 = stream.Position;
                        var b = stream.ReadByteArray(validityCheck);
                        var advance = stream.Position - p1;
                        occupancy -= (int)advance;
                        list.Add(converter(b));
                    }
                    if (next <= 0) break;
                    else stream.SeekTo(next);
                }
            }
            else throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
        }


        #region Read/Write List

        delegate void _writeItem<T>(Stream stream, T value);
        delegate T _readItem<T>(Stream stream);

        static void _innerWriteList<T>(_writeItem<T> write, Stream stream, IList<T> list, WritingMode mode = WritingMode.New, bool validityCheck = true)
        {
            //TODO need to deal with objects of variable binary length

            if (mode == WritingMode.New)
            {
                if (validityCheck)
                    stream.WriteCheckCode((long)29);

                if (list == null || list.Count == 0)
                {
                    stream.WriteInt32(0); // current block length (total number of available slots for the objects to write)
                    stream.WriteInt32(0); // current block occupancy (actual number of objects in the current block)
                    stream.WriteInt64(0); // next block position
                    return;
                }

                stream.WriteInt32(list.Count);
                stream.WriteInt32(list.Count);
                stream.WriteInt64(0);
                for (var i = 0; i < list.Count; i++)
                    write(stream, list[i]);
            }
            else if (mode == WritingMode.Override)
            {
                if (!validityCheck || stream.Check((Int64)29))
                {
                    var i = 0;
                    var totalItemCountToWrite = list.Count;
                    while (true)
                    {
                        var count = stream.ReadInt32();
                        if (list.Count == 0)
                        {
                            stream.SkipInt32();
                            stream.WriteInt32(0); // writes occupancy as zero
                            return;
                        }

                        var occupancyCountPtrPos = stream.Position;
                        stream.SkipInt32();

                        var nextPtrPos = stream.Position;
                        var nextBlockPosition = stream.ReadInt64();

                        var oi = i;
                        for (; count > 0 && i < totalItemCountToWrite; count--, i++)
                            write(stream, list[i]);

                        var currPos = stream.Position;
                        stream.SeekTo(occupancyCountPtrPos);
                        stream.WriteInt32(i - oi);
                        stream.SeekTo(currPos);

                        if (i < totalItemCountToWrite)
                        {
                            if (nextBlockPosition == 0)
                            {
                                stream.SeekTo(nextPtrPos); // writes the position of the new block
                                stream.WriteInt64(stream.Length);
                                stream.SeekToEnd();

                                stream.WriteInt32(totalItemCountToWrite - i);
                                stream.WriteInt32(totalItemCountToWrite - i);

                                stream.WriteInt64(0);
                                for (; i < totalItemCountToWrite; i++)
                                    write(stream, list[i]);
                                break;
                            }
                            else
                                stream.SeekTo(nextBlockPosition);
                        }
                        else
                            break;
                    }
                }
                else
                    throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
            }
        }

        static void _writeInt32(Stream s, Int32 v)
        {
            s.WriteInt32((Int32)v);
        }

        static Int32 _readInt32(Stream s)
        {
            return s.ReadInt32();
        }

        static void _writeInt64(Stream s, Int64 v)
        {
            s.WriteInt64((Int64)v);
        }

        static Int64 _readInt64(Stream s)
        {
            return s.ReadInt64();
        }

        static void _writeUInt64(Stream s, UInt64 v)
        {
            s.WriteUInt64((UInt64)v);
        }

        static UInt64 _readUInt64(Stream s)
        {
            return s.ReadUInt64();
        }

        static void _writeUInt32(Stream s, UInt32 v)
        {
            s.WriteUInt32((UInt32)v);
        }

        static UInt32 _readUInt32(Stream s)
        {
            return s.ReadUInt32();
        }

        static void _writeUInt16(Stream s, UInt16 v)
        {
            s.WriteUInt16((UInt16)v);
        }

        static UInt16 _readUInt16(Stream s)
        {
            return s.ReadUInt16();
        }

        static void _writeInt16(Stream s, Int16 v)
        {
            s.WriteInt16((Int16)v);
        }

        static Int16 _readInt16(Stream s)
        {
            return s.ReadInt16();
        }

        static void _writeSingle(Stream s, Single v)
        {
            s.WriteSingle((Single)v);
        }

        static Single _readSingle(Stream s)
        {
            return s.ReadSingle();
        }

        static void _writeDouble(Stream s, Double v)
        {
            s.WriteDouble((Double)v);
        }

        static Double _readDouble(Stream s)
        {
            return s.ReadDouble();
        }

        static void _writeISavable(Stream s, IBinarySavable obj)
        {
            obj.WriteToStream(s, null);
        }

        static void _writeISavable<T>(Stream s, T obj) where T: IBinarySavable
        {
            obj.WriteToStream(s, null);
        }

        static T _readISavable<T>(Stream s) where T : IBinarySavable, new()
        {
            var output = new T();
            output.LoadFromStream(s, null);
            return output;
        }

        static void _innerReadList<T>(_readItem<T> read, Stream stream, IList<T> list, bool validityCheck = true)
        {
            //var pos = stream.Position;

            if (!validityCheck || stream.Check((Int64)29))
            {
                while (true)
                {
                    //reads and checks length
                    var len = stream.ReadInt32();
                    if (len < 0)
                    {
                        //stream.SeekTo(pos);
                        throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
                    }

                    //reads and checks occupancy
                    var occupancy = stream.ReadInt32();
                    if (occupancy < 0)
                    {
                        //stream.SeekTo(pos);
                        throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
                    }

                    //reads and check next point
                    var next = stream.ReadInt64();
                    if (next < 0)
                    {
                        //stream.SeekTo(pos);
                        throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
                    }

                    for (int i = 0; i < occupancy; i++)
                        list.Add((T)read(stream));

                    if (next == 0 || occupancy < len) break;
                    else stream.SeekTo(next);
                }
            }
            else throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
        }

        /// <summary>
        /// Writes a list of 32-bit integers to this stream.
        /// </summary>
        /// <param name="stream">A <see cref="System.IO.Stream"/>.</param>
        /// <param name="list">A list of 32-bit integers.</param>
        /// <param name="mode">Indicates whether to override existing list or create a new list in the stream.</param>
        /// <param name="validityCheck">Indicates whether to write a validity-check countersign before the list in the stream.</param>
        public static void WriteList(this Stream stream, IList<Int32> list, WritingMode mode = WritingMode.New, bool validityCheck = true)
        {
            _innerWriteList<Int32>(_writeInt32, stream, list, mode, validityCheck);
        }

        /// <summary>
        /// Reads a list of 32-bit integers from this stream.
        /// </summary>
        /// <param name="stream">A <see cref="System.IO.Stream"/>.</param>
        /// <param name="list">A list used to store the integers.</param>
        /// <param name="validityCheck">Indicates whether to read a countersign from the stream and perform the validity check.</param>
        public static void ReadList(this Stream stream, IList<Int32> list, bool validityCheck = true)
        {
            _innerReadList<Int32>(_readInt32, stream, list, validityCheck);
        }

        /// <summary>
        /// Writes a list of 64-bit integers to this stream.
        /// </summary>
        /// <param name="stream">A <see cref="System.IO.Stream"/>.</param>
        /// <param name="list">A list of 64-bit integers.</param>
        /// <param name="mode">Indicates whether to override existing list or create a new list in the stream.</param>
        /// <param name="validityCheck">Indicates whether to write a validity-check countersign before the list in the stream.</param>
        public static void WriteList(this Stream stream,
            IList<Int64> list, WritingMode mode = WritingMode.New, bool validityCheck = true)
        {
            _innerWriteList<Int64>(_writeInt64, stream, list, mode, validityCheck);
        }

        /// <summary>
        /// Reads a list of 64-bit integers from this stream.
        /// </summary>
        /// <param name="stream">A <see cref="System.IO.Stream"/>.</param>
        /// <param name="list">A list used to store the integers.</param>
        /// <param name="validityCheck">Indicates whether to read a countersign from the stream and perform the validity check.</param>
        public static void ReadList(this Stream stream,
            IList<Int64> list, bool validityCheck = true)
        {
            _innerReadList<Int64>(_readInt64, stream, list, validityCheck);
        }

        /// <summary>
        /// Writes a list of 16-bit integers to this stream.
        /// </summary>
        /// <param name="stream">A <see cref="System.IO.Stream"/>.</param>
        /// <param name="list">A list of 16-bit integers.</param>
        /// <param name="mode">Indicates whether to override existing list or create a new list in the stream.</param>
        /// <param name="validityCheck">Indicates whether to write a validity-check countersign before the list in the stream.</param>
        public static void WriteList(this Stream stream,
            IList<Int16> list, WritingMode mode = WritingMode.New, bool validityCheck = true)
        {
            _innerWriteList<Int16>(_writeInt16, stream, list, mode, validityCheck);
        }

        /// <summary>
        /// Reads a list of 16-bit integers from this stream.
        /// </summary>
        /// <param name="stream">A <see cref="System.IO.Stream"/>.</param>
        /// <param name="list">A list used to store the integers.</param>
        /// <param name="validityCheck">Indicates whether to read a countersign from the stream and perform the validity check.</param>
        public static void ReadList(this Stream stream,
            IList<Int16> list, bool validityCheck = true)
        {
            _innerReadList<Int16>(_readInt16, stream, list, validityCheck);
        }

        /// <summary>
        /// Writes a list of 64-bit unsigned integers to this stream.
        /// </summary>
        /// <param name="stream">A <see cref="System.IO.Stream"/>.</param>
        /// <param name="list">A list of 64-bit unsigned integers.</param>
        /// <param name="mode">Indicates whether to override existing list or create a new list in the stream.</param>
        /// <param name="validityCheck">Indicates whether to write a validity-check countersign before the list in the stream.</param>
        public static void WriteList(this Stream stream,
            IList<UInt64> list, WritingMode mode = WritingMode.New, bool validityCheck = true)
        {
            _innerWriteList<UInt64>(_writeUInt64, stream, list, mode, validityCheck);
        }

        /// <summary>
        /// Reads a list of 64-bit unsigned integers from this stream.
        /// </summary>
        /// <param name="stream">A <see cref="System.IO.Stream"/>.</param>
        /// <param name="list">A list used to store the integers.</param>
        /// <param name="validityCheck">Indicates whether to read a countersign from the stream and perform the validity check.</param>
        public static void ReadList(this Stream stream,
            IList<UInt64> list, bool validityCheck = true)
        {
            _innerReadList<UInt64>(_readUInt64, stream, list, validityCheck);
        }

        /// <summary>
        /// Writes a list of 32-bit unsigned integers to this stream.
        /// </summary>
        /// <param name="stream">A <see cref="System.IO.Stream"/>.</param>
        /// <param name="list">A list of 32-bit unsigned integers.</param>
        /// <param name="mode">Indicates whether to override existing list or create a new list in the stream.</param>
        /// <param name="validityCheck">Indicates whether to write a validity-check countersign before the list in the stream.</param>
        public static void WriteList(this Stream stream,
            IList<UInt32> list, WritingMode mode = WritingMode.New, bool validityCheck = true)
        {
            _innerWriteList<UInt32>(_writeUInt32, stream, list, mode, validityCheck);
        }

        /// <summary>
        /// Reads a list of 32-bit unsigned integers from this stream.
        /// </summary>
        /// <param name="stream">A <see cref="System.IO.Stream"/>.</param>
        /// <param name="list">A list used to store the integers.</param>
        /// <param name="validityCheck">Indicates whether to read a countersign from the stream and perform the validity check.</param>
        public static void ReadList(this Stream stream,
            IList<UInt32> list, bool validityCheck = true)
        {
            _innerReadList<UInt32>(_readUInt32, stream, list, validityCheck);
        }

        /// <summary>
        /// Writes a list of 16-bit unsigned integers to this stream.
        /// </summary>
        /// <param name="stream">A <see cref="System.IO.Stream"/>.</param>
        /// <param name="list">A list of 16-bit unsigned integers.</param>
        /// <param name="mode">Indicates whether to override existing list or create a new list in the stream.</param>
        /// <param name="validityCheck">Indicates whether to write a validity-check countersign before the list in the stream.</param>
        public static void WriteList(this Stream stream,
            IList<UInt16> list, WritingMode mode = WritingMode.New, bool validityCheck = true)
        {
            _innerWriteList<UInt16>(_writeUInt16, stream, list, mode, validityCheck);
        }

        /// <summary>
        /// Reads a list of 16-bit unsigned integers from this stream.
        /// </summary>
        /// <param name="stream">A <see cref="System.IO.Stream"/>.</param>
        /// <param name="list">A list used to store the integers.</param>
        /// <param name="validityCheck">Indicates whether to read a countersign from the stream and perform the validity check.</param>
        public static void ReadList(this Stream stream,
            IList<UInt16> list, bool validityCheck = true)
        {
            _innerReadList<UInt16>(_readUInt16, stream, list, validityCheck);
        }

        /// <summary>
        /// Writes a list of single-precision numbers to this stream.
        /// </summary>
        /// <param name="stream">A <see cref="System.IO.Stream"/>.</param>
        /// <param name="list">A list of single-precision numbers.</param>
        /// <param name="mode">Indicates whether to override existing list or create a new list in the stream.</param>
        /// <param name="validityCheck">Indicates whether to write a validity-check countersign before the list in the stream.</param>
        public static void WriteList(this Stream stream,
            IList<Single> list, WritingMode mode = WritingMode.New, bool validityCheck = true)
        {
            _innerWriteList<Single>(_writeSingle, stream, list, mode, validityCheck);
        }

        /// <summary>
        /// Reads a list of single-precision numbers from this stream.
        /// </summary>
        /// <param name="stream">A <see cref="System.IO.Stream"/>.</param>
        /// <param name="list">A list used to store the integers.</param>
        /// <param name="validityCheck">Indicates whether to read a countersign from the stream and perform the validity check.</param>
        public static void ReadList(this Stream stream,
            IList<Single> list, bool validityCheck = true)
        {
            _innerReadList<Single>(_readSingle, stream, list, validityCheck);
        }

        /// <summary>
        /// Writes a list of double-precision number to this stream.
        /// </summary>
        /// <param name="stream">A <see cref="System.IO.Stream"/>.</param>
        /// <param name="list">A list of double-precision numbers.</param>
        /// <param name="mode">Indicates whether to override existing list or create a new list in the stream.</param>
        /// <param name="validityCheck">Indicates whether to write a validity-check countersign before the list in the stream.</param>
        public static void WriteList(this Stream stream,
            IList<Double> list, WritingMode mode = WritingMode.New, bool validityCheck = true)
        {
            _innerWriteList<Double>(_writeDouble, stream, list, mode, validityCheck);
        }

        /// <summary>
        /// Reads a list of double-precision numbers from this stream.
        /// </summary>
        /// <param name="stream">A <see cref="System.IO.Stream"/>.</param>
        /// <param name="list">A list used to store the integers.</param>
        /// <param name="validityCheck">Indicates whether to read a countersign from the stream and perform the validity check.</param>
        public static void ReadList(this Stream stream,
            IList<Double> list, bool validityCheck = true)
        {
            _innerReadList<Double>(_readDouble, stream, list, validityCheck);
        }


        /// <summary>
        /// Writes a list of double-precision number to this stream.
        /// </summary>
        /// <param name="stream">A <see cref="System.IO.Stream"/>.</param>
        /// <param name="list">A list of double-precision numbers.</param>
        /// <param name="mode">Indicates whether to override existing list or create a new list in the stream. DO NOT use <see cref="WritingMode.Override"/> if the binary length <see cref="IBinarySavable"/> object is variable.</param>
        /// <param name="validityCheck">Indicates whether to write a validity-check countersign before the list in the stream.</param>
        public static void WriteList<T>(this Stream stream,
            IList<T> list, WritingMode mode = WritingMode.New, bool validityCheck = true) where T : IBinarySavable
        {
            _innerWriteList(_writeISavable, stream, list, WritingMode.New, validityCheck);
        }

        /// <summary>
        /// Reads a list of <see cref="IBinarySavable"/> objects from this stream.
        /// </summary>
        /// <param name="stream">A <see cref="System.IO.Stream"/>.</param>
        /// <param name="list">A list used to store the integers.</param>
        /// <param name="validityCheck">Indicates whether to read a countersign from the stream and perform the validity check.</param>
        public static void ReadList<T>(this Stream stream, IList<T> list, bool validityCheck = true) where T : IBinarySavable, new()
        {
            _innerReadList(_readISavable<T>, stream, list, validityCheck);
        }

        /// <summary>
        /// Reads a list of double-precision numbers from this stream.
        /// </summary>
        /// <param name="stream">A <see cref="System.IO.Stream"/>.</param>
        /// <param name="validityCheck">Indicates whether to read a countersign from the stream and perform the validity check.</param>
        public static T[] ReadList<T>(this Stream stream, bool validityCheck = true) where T : IBinarySavable, new()
        {
            var list = new List<T>();
            _innerReadList(_readISavable<T>, stream, list, validityCheck);
            return list.ToArray();
        }

        #endregion

    }
}
