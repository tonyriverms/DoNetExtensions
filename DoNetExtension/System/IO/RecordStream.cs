using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System_Extension_Library.System;
using DoNetExtension.System;
using DoNetExtension.System.IO;

//Note: All the stuff in this file has been tested, but not guaranteed bug-free for now.

namespace System.IO
{
    class _rinfo
    {
        internal long _totalLength;
        internal int _blockLength;
        internal List<long> _list;
        internal bool _infoModified1;
        internal bool _infoModified2;
        internal int _metaNum;
    }

    /// <summary>
    /// A stream that allows storing records of indefinite size on the same base stream.
    /// </summary>
    public class RecordStream : Stream, IRecord
    {
        long _infoPos;
        long _currPos;
        ISpaceManager _manager;
        Stream _dataStream;
        Stream _infoStream;
        _rinfo _rinfo;

        /// <summary>
        /// DO NOT use this constructor. It is meant to be used in the codes of higher-level record class.
        /// </summary>
        public RecordStream() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecordStream"/> class.
        /// Call this constructor if you intend to create a new recod; otherwise call a constructor that allows you to set the position parameter.
        /// </summary>
        /// <param name="infoStream">A <see cref="System.IO.Stream"/> where meta information is stored.
        /// The meta information will be stored at the end of the <paramref name="infoStream" /> when you call <c>SaveInfo</c> method.
        /// This stream is allowed to be the same as <paramref name="dataStream"/>.</param>
        /// <param name="dataStream">A <see cref="System.IO.Stream"/> where data are actually stored. 
        /// This stream is allowed to be the same as <paramref name="infoStream"/>.</param>
        /// <param name="manager">A System.IO.IRecordManager that manages this record stream,
        /// providing functionality of space release and optimization.</param>
        public RecordStream(Stream infoStream, Stream dataStream, ISpaceManager manager = null)
            : this(infoStream, -1, dataStream, manager)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecordStream" /> class.
        /// Call this constructor if you intend to create a new recod; otherwise call a constructor that allows you to set the position parameter.
        /// </summary>
        /// <param name="infoStream">A <see cref="System.IO.Stream" /> where meta information is stored.
        /// The meta information will be stored at the end of the <paramref name="infoStream" /> when you call <c>SaveInfo</c> method.
        /// This stream is allowed to be the same as <paramref name="dataStream" />.</param>
        /// <param name="dataStream">A <see cref="System.IO.Stream" /> where data are actually stored.
        /// This stream is allowed to be the same as <paramref name="infoStream" />.</param>
        public RecordStream(Stream infoStream, Stream dataStream)
            : this(infoStream, -1, dataStream, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecordStream" /> class.
        /// Usually you call this constructor when you intend to load an existing record from the specified position.
        /// </summary>
        /// <param name="infoStream">A <see cref="System.IO.Stream" /> where meta information is stored.
        /// The meta information will be saved at the current position of this stream.
        /// This stream is allowed to be the same as <paramref name="dataStream" />.</param>
        /// <param name="infoPosition">The position of meta information in the <paramref name="infoStream" />.
        /// Set this parameter to -1 to mark this record as a new record.</param>
        /// <param name="dataStream">A <see cref="System.IO.Stream" /> where data are actually stored.
        /// This stream is allowed to be the same as <paramref name="infoStream" />.</param>
        /// <param name="manager">A <see cref="IRecordManager" /> that manages this record stream,
        /// providing functionality of space release and optimization.</param>
        public RecordStream(Stream infoStream, long infoPosition, Stream dataStream,
            ISpaceManager manager = null)
        {
            if (infoStream == null) throw new ArgumentNullException("infoStream");
            if (dataStream == null) throw new ArgumentNullException("dataStream");
            if (infoPosition < -1) throw new ArgumentOutOfRangeException("infoPosition");

            _infoStream = infoStream;
            _dataStream = dataStream;
            _infoPos = infoPosition;
            _manager = manager;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecordStream"/> class.
        /// Usually you call this constructor when you intend to load an existing record from the specified position.
        /// </summary>
        /// <param name="baseStream">A <see cref="System.IO.Stream"/> where data are actually stored.</param>
        /// <param name="startPosition">
        /// Specifies a non-negative integer to indicate the location of an existing record in <paramref name="baseStream"/>, 
        /// or -1 to create a new record.
        /// </param>
        public RecordStream(Stream baseStream, long startPosition)
            : this(baseStream, startPosition, baseStream)
        {
            if (baseStream == null) throw new ArgumentNullException("baseStream");
            if (startPosition < -1) throw new ArgumentOutOfRangeException("startPosition");
            _infoStream = _dataStream = baseStream;
            _infoPos = startPosition;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecordStream" /> class.
        /// Call this constructor if you intend to create a new recod; otherwise call a constructor that allows you to set the position parameter.
        /// </summary>
        /// <param name="baseStream">A <see cref="System.IO.Stream" /> where data are actually stored.
        /// Data will be stored at the end of the base stream when you call <c>SaveInfo</c> method.</param>
        /// <exception cref="System.ArgumentNullException">baseStream</exception>
        public RecordStream(Stream baseStream)
        {
            if (baseStream == null) throw new ArgumentNullException("baseStream");

            _infoStream = _dataStream = baseStream;
            _infoPos = -1;
        }

        /// <summary>
        /// Makes this <see cref="RecordStream"/> represent a new record without eliminating the data 
        /// of the previous record in the underlying stream.
        /// If you have already loaded an existing record into this instance and made changes to the data blocks, 
        /// and you call this method again before you call <c>SaveInfo</c>, and then these new changes will be lost.
        /// </summary>
        /// <param name="blockLength">The length of each data block in this record stream.</param>
        public void CreateNew(int blockLength)
        {
            if (blockLength <= 0)
                throw new ArgumentOutOfRangeException("blockLength", GeneralResources.ERR_PositiveValueRequired.Scan("blockLength"));

            if (_infoPos == -1 && _rinfo == null)
            {
                _rinfo = new _rinfo();
                _rinfo._list = new List<long>();
                _rinfo._totalLength = 0;
                _rinfo._blockLength = blockLength;
                _currPos = -1;
                _rinfo._infoModified1 = true;
                _rinfo._infoModified2 = true;
            }
            else throw new InvalidOperationException(IOResources.ERR_RecordStream_InvalidCreation);
        }

        /// <summary>
        /// Gets a value indicating whether this record stream is initialized. 
        /// If not, you should call method CreatNew before writing any data to this stream.
        /// </summary>
        public bool Initialized
        {
            get
            {
                return _infoPos != -1 || _rinfo._list != null;
            }
        }

        bool _metaNumRetrieved;

        /// <summary>
        /// Gets or sets a 32-bit integer in this record stream. 
        /// This number is stored in this stream but can be retrieved without first calling the LoadInfo method.
        /// Note that after assigning a value to this property, you still need to call SaveInfo to save the change.
        /// </summary>
        protected int MetaNumber
        {
            get
            {
                if (_metaNumRetrieved)
                    return _rinfo._metaNum;
                _rinfo._metaNum = ReadMetaNumber();
                _metaNumRetrieved = true;
                return _rinfo._metaNum;
            }
            set
            {
                _rinfo._metaNum = value;
                _metaNumRetrieved = true;
            }
        }

        /// <summary>
        /// Reads the meta number from this record stream. 
        /// This method only reads from the stream but does not change the current value of MetaNumber property.
        /// </summary>
        /// <returns>The meta number stored in this stream.</returns>
        protected int ReadMetaNumber()
        {
            if (_infoPos == -1)
                throw new InvalidOperationException();

            _infoStream.SeekTo(_infoPos);
            if (!_infoStream.Check(IOChecks.RecordStream))
                throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
            return _infoStream.ReadInt32();
        }

        /// <summary>
        /// Loads meta information into this instance of <see cref="RecordStream"/>. 
        /// If you have called <c>UnloadInfo</c>,
        /// the status of this <see cref="RecordStream"/> instance will be restored where it was right before the last time UnloadInfo was called.
        /// </summary>
        public virtual void LoadInfo()
        {
            //reads info from <paramref name="infoStream" />
            if (_rinfo != null) return;
            if (_infoPos >= 0)
            {
                _infoStream.SeekTo(_infoPos);

                if (_infoStream.Check(IOChecks.RecordStream))
                {
                    _rinfo = new _rinfo();
                    _rinfo._metaNum = _infoStream.ReadInt32();
                    _metaNumRetrieved = true;
                    _rinfo._blockLength = _infoStream.ReadInt32();
                    _rinfo._totalLength = _infoStream.ReadInt64();

                    if (ReadMoreInfo != null)
                        ReadMoreInfo(_infoStream);

                    _rinfo._list = new List<long>();
                    _infoStream.ReadList(_rinfo._list);
                }
                else
                    throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
            }
        }

        /// <summary>
        /// Gets the position of meta information in the info stream or base stream.
        /// </summary>
        public long StartPosition { get { return _infoPos; } }

        /// <summary>
        /// Saves meta information of this <see cref="RecrodStream"/> instance. 
        /// This method only saves the information of new data blocks whereby the new data will be meanwhile preserved. 
        /// However, it has nothing to do with the changes you made on the old data blocks, 
        /// on which any modification will be immediately effective no matter whether you call this method or not.
        /// </summary>
        public virtual void SaveInfo()
        {
            if (_rinfo == null)
                throw new InvalidOperationException(IOResources.ERR_IRecord_NotLoaded);

            if (!_rinfo._infoModified1 || !_rinfo._infoModified2)
                return;

            WritingMode mode;
            if (_infoPos == -1)
            {
                mode = WritingMode.New;
                _infoPos = _infoStream.Length;
                _infoStream.SeekToEnd();
                _infoStream.WriteCheckCode(IOChecks.RecordStream);
            }
            else
            {
                mode = WritingMode.Override;
                _infoStream.SeekTo(_infoPos);

                if (!_infoStream.Check(IOChecks.RecordStream))
                    throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
            }

            if (_metaNumRetrieved || mode == WritingMode.New)
                _infoStream.WriteInt32(_rinfo._metaNum);
            else
                _infoStream.SkipInt32();

            if (_rinfo != null)
            {
                _infoStream.WriteInt32(_rinfo._blockLength);
                _infoStream.WriteInt64(_rinfo._totalLength);
                if (WriteMoreInfo != null)
                    WriteMoreInfo(_infoStream);
                _infoStream.WriteList(_rinfo._list, mode);
            }
            _rinfo._infoModified1 = false;
            _rinfo._infoModified2 = false;
        }

        /// <summary>
        /// Unloads the meta information of this <see cref="RecordStream"/> instance and release some memory.
        /// Before calling this method, you must make a decision to save or discard the changes to the data blocks.
        /// Later you are able to reload the meta information by calling LoadInfo again.
        /// </summary>
        public virtual void UnloadInfo()
        {
            if (_rinfo == null)
                throw new InvalidOperationException(IOResources.ERR_IRecord_NotLoaded);
            if (_rinfo._infoModified1)
                throw new InvalidOperationException(IOResources.ERR_RecordStream_UpdateNotSaved);
            if (_rinfo._list != null)
            {
                _rinfo._list.Clear();
                _rinfo._list = null;
            }
            _rinfo = null;
        }

        /// <summary>
        /// Marks all new data blocks since the last time SaveInfo was called as discarded. 
        /// Note that this method only discards new blocks whereby the data on the new blocks will also be discarded. 
        /// However, changes on the old data blocks will not be affected.
        /// This method only marks the new data blocks as discarded but not really deletes them. You can call ResumeUpdate to 
        /// reverse this operation. Also, this operation will be reversed automatically if any new writing occurs.
        /// </summary>
        public void DiscardUpdate()
        {
            _rinfo._infoModified1 = false;
        }

        /// <summary>
        /// Resumes the data blocks previously marked as discarded.
        /// </summary>
        public void ResumeUpdate()
        {
            _rinfo._infoModified1 = _rinfo._infoModified2;
        }

        /// <summary>
        /// Clears all the data in this record stream and frees all the space taken if this record has a manager. 
        /// If this record has a manager, the clearance will be immediately effective and the data is no longer recoverable. 
        /// If not, you are allowed to sequentially call <c>DiscardUpdate</c>, <c>UnloadInfo</c> and <c>LoadInfo</c> to resume all cleared data.
        /// </summary>
        public virtual void Clear()
        {
            if (_rinfo != null)
            {
                bool forcedWriteback = (_manager != null);
                if (forcedWriteback)
                    _manager.FreeSections(_rinfo._list, _rinfo._blockLength);

                _rinfo._list.Clear();
                _rinfo._totalLength = 0;
                _currPos = -1;

                _rinfo._infoModified1 = true;
                _rinfo._infoModified2 = true;

                if (forcedWriteback)
                    SaveInfo();
            }
            else
                throw new InvalidOperationException(IOResources.ERR_IRecord_NotLoaded);
        }

        /// <summary>
        /// Gets a value indicating whether the underlying System.IO.Stream supports reading.
        /// </summary>
        public override bool CanRead
        {
            get { return _dataStream.CanRead; }
        }

        /// <summary>
        /// Gets a value indicating whether the underlying System.IO.Stream supports seeking.
        /// </summary>
        public override bool CanSeek
        {
            get { return _dataStream.CanSeek; }
        }

        /// <summary>
        /// Gets a value indicating whether the underlying System.IO.Stream supports writing.
        /// </summary>
        public override bool CanWrite
        {
            get { return _dataStream.CanWrite; }
        }

        /// <summary>
        /// Clears all buffers for this stream and causes any buffered data to be written to the underlying device.
        /// </summary>
        public override void Flush()
        {
            lock (_dataStream)
            {
                _dataStream.Flush();
            }

            if (_infoStream != _dataStream)
            {
                lock (_infoStream)
                {
                    _infoStream.Flush();
                }
            }
        }

        /// <summary>
        /// Gets the length in bytes of this record stream.
        /// </summary>
        public override long Length
        {
            get
            {
                if (_rinfo != null)
                    return _rinfo._totalLength;
                else throw new InvalidOperationException(IOResources.ERR_IRecord_NotLoaded);
            }
        }

        /// <summary>
        /// Sets a delegation method to write additional LENGTH-FIXED information. 
        /// DO NOT write any data of indefinite or changeable length, such as a linked list. 
        /// If this property is set to an bugged method the data in the info-stream can be corrupted.
        /// </summary>
        public Action<Stream> WriteMoreInfo { get; set; }

        /// <summary>
        /// Sets a delegation method to read additional LENGTH-FIXED information. 
        /// If this property is set to an bugged method for the most part a validity-check failure will occure.
        /// </summary>
        public Action<Stream> ReadMoreInfo { get; set; }

        /// <summary>
        /// Gets or sets the current position within this record stream. 
        /// </summary>
        public override long Position
        {
            get
            {
                if (_rinfo != null)
                    return _currPos;
                else throw new InvalidOperationException(IOResources.ERR_IRecord_NotLoaded);
            }
            set
            {
                if (_rinfo != null)
                {
                    //stream empty, position always set to -1
                    if (Capacity == 0) _currPos = -1;
                    //stream not empty, position is not the end of stream, data stream seeks to the right position
                    else if (value >= 0 || value <= _rinfo._totalLength)
                    {
                        var idx = (int)(value / _rinfo._blockLength);
                        var offset = value % _rinfo._blockLength;
                        if (idx < _rinfo._list.Count)
                            _dataStream.SeekTo(_rinfo._list[idx] + offset);
                        else if (idx == _rinfo._list.Count && offset == 0)
                            _dataStream.SeekToEnd();
                        else
                            throw new InvalidOperationException(IOResources.ERR_RecordStream_InvalidPosition);
                        _currPos = value;
                    }
                    else
                        throw new InvalidOperationException(IOResources.ERR_RecordStream_InvalidPosition);
                }
                else
                    throw new InvalidOperationException(IOResources.ERR_IRecord_NotLoaded);
            }
        }

        /// <summary>
        /// Gets the index of the current data block used by this record stream. 
        /// </summary>
        public int BlockIndex
        {
            get
            {
                if (_rinfo != null)
                    return (int)(Position / _rinfo._blockLength);
                else throw new InvalidOperationException(IOResources.ERR_IRecord_NotLoaded);
            }
        }

        /// <summary>
        /// Gets the offset in the current data block used by this record stream.
        /// </summary>
        public int BlockOffset
        {
            get
            {
                if (_rinfo != null)
                    return (int)(Position % _rinfo._blockLength);
                else throw new InvalidOperationException(IOResources.ERR_IRecord_NotLoaded);
            }
        }

        /// <summary>
        /// Gets the length in bytes of each data block.
        /// </summary>
        public int BlockLength
        {
            get
            {
                if (_rinfo != null)
                    return _rinfo._blockLength;
                else throw new InvalidOperationException(IOResources.ERR_IRecord_NotLoaded);
            }
        }

        /// <summary>
        /// Gets the number of all data blocks used by this record stream.
        /// </summary>
        public int BlockCount
        {
            get
            {
                if (_rinfo != null)
                    return _rinfo._list.Count;
                else
                    throw new InvalidOperationException(IOResources.ERR_IRecord_NotLoaded);
            }
        }

        /// <summary>
        /// Gets the maximum length in bytes of this System.IO.RecordStream can reach 
        /// without applying for new space.
        /// </summary>
        public long Capacity
        {
            get
            {
                if (_rinfo != null)
                    return _rinfo._list.Count * _rinfo._blockLength;
                else
                    throw new InvalidOperationException(IOResources.ERR_IRecord_NotLoaded);
            }
        }

        /// <summary>
        /// Reads a sequence of bytes from the current stream 
        /// and advances the position within the stream by the number of bytes read. 
        /// </summary>
        /// <param name="buffer">An array of bytes. When this method returns, 
        /// the buffer contains the specified byte array with the values between offset 
        /// and (offset + count - 1) replaced by the bytes read from the current source.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin storing the data read from the current stream.</param>
        /// <param name="count">The maximum number of bytes to be read from the current stream.</param>
        /// <returns>The total number of bytes read into the buffer. 
        /// This can be less than the number of bytes requested if that many bytes are not currently available, 
        /// or zero (0) if the end of the stream has been reached. </returns>
        public override int Read(byte[] buffer, int offset, int count)
        {
            //checks the validity of arguments
            //even though the underlying stream has its own checking logic, 
            //perform this checking to prevent possible invalid change of some private values of this record stream
            if (offset < 0)
                throw new ArgumentOutOfRangeException(IOResources.ERR_RecordStream_InvalidOffset);
            if (count <= 0)
                throw new ArgumentOutOfRangeException(IOResources.ERR_RecordStream_InvalidCount);
            if (offset + count > buffer.Length)
                throw new ArgumentException(IOResources.ERR_RecordStream_InvalidOffsetAndCount);
            if (!CanRead)
                throw new NotSupportedException(IOResources.ERR_RecordStream_CannotRead);

            //this line makes sure the bytes to read does  the length of this stream
            count =
                Math.Min((int)Math.Min((long)int.MaxValue, _rinfo._totalLength - _currPos), count);

            if (count == 0) return 0;

            //count is taking part in the reading process 
            //and has itself altered after a certain amount of bytes are read
            //so we make a copy of "count" to record the initial value.
            var copyOfCount = count;

            //reads from the current block
            var poi = Position;
            //the position of the underlying stream may have been changed, and this line make it back to the right place
            Position = poi;

            var sectionIndex = (int)(poi / _rinfo._blockLength) + 1;
            int sectionRemain = _rinfo._blockLength - (int)(poi % _rinfo._blockLength);
            if (sectionRemain != 0)
            {
                //the bytes to read are all from the current section
                //just read them and return
                if (count <= sectionRemain)
                {
                    _dataStream.Read(buffer, offset, count);
                    _currPos += copyOfCount;
                    return count;
                }
                //the bytes to read are from the current section and following sections
                //read all the bytes after the section offset
                else
                {
                    _dataStream.Read(buffer, offset, sectionRemain);
                    count -= sectionRemain;
                    offset += sectionRemain;
                }
            }

            //reads the rest sections

            while (count > 0)
            {
                _dataStream.SeekTo(_rinfo._list[sectionIndex++]);
                var byteCount = Math.Min(_rinfo._blockLength, count);
                _dataStream.Read(buffer, offset, byteCount);
                count -= byteCount;
                offset += byteCount;
            }

            _currPos += copyOfCount;
            return copyOfCount;
        }

        /// <summary>
        /// Sets the position within the current stream.
        /// </summary>
        /// <param name="offset">A byte offset relative to the origin parameter. </param>
        /// <param name="origin">A value of type SeekOrigin 
        /// indicating the reference point used to obtain the new position.</param>
        /// <returns>The new position within the current stream.</returns>
        public override long Seek(long offset, SeekOrigin origin)
        {
            if (origin == SeekOrigin.Begin)
                Position = offset;
            else if (origin == SeekOrigin.Current)
                offset += _currPos;
            else
                offset = _rinfo._totalLength - offset;

            Position = offset;
            return offset;
        }

        /// <summary>
        /// Sets the length of the current stream.
        /// </summary>
        /// <param name="value">The desired length of the current record stream in bytes.</param>
        public override void SetLength(long value)
        {
            var spaceToAlloc = value - Capacity;
            if (spaceToAlloc > 0)
            {
                var sectionsToCreate = spaceToAlloc / _rinfo._blockLength;
                var tmp = spaceToAlloc % _rinfo._blockLength;
                if (tmp != 0) sectionsToCreate++;

                lock (_dataStream)
                {
                    var pos = _dataStream.Length;
                    _dataStream.SetLength(_dataStream.Length + _rinfo._blockLength * sectionsToCreate);
                    while (sectionsToCreate-- > 0)
                    {
                        _rinfo._list.Add(pos);
                        pos += _rinfo._blockLength;
                    }
                }
            }
            _rinfo._totalLength = value;
        }

        /// <summary>
        /// Gets a value indicating whether this record stream holds a brand new record without any data in it. 
        /// This property returns true when Clear or CreateNew method has just been executed.
        /// </summary>
        public bool IsNew
        {
            get { return Capacity == 0; }
        }

        /// <summary>
        /// Gets a value indicating whether this record stream is empty. 
        /// This property returns true when Length is zero.
        /// </summary>
        public bool IsEmpty
        {
            get { return Length == 0; }
        }

        /// <summary>
        /// Gets a value indicating whether the necessary meta information has been loaded. 
        /// If false is returned, you cannot write or read any data before you call <c>LoadInfo</c> or <c>CreateNew</c> method.
        /// </summary>
        public bool Loaded { get { return _rinfo != null; } }

        /// <summary>
        /// Writes a sequence of bytes to the current stream and advances the current position within this stream by the number of bytes written. 
        /// </summary>
        /// <param name="buffer">An array of bytes. This method copies count bytes from buffer to the current stream.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin copying bytes to the current stream.</param>
        /// <param name="count">The number of bytes to be written to the current stream.</param>
        public override void Write(byte[] buffer, int offset, int count)
        {
            //checks the validity of arguments
            //even though the underlying stream has its own checking logic, 
            //perform this checking to prevent possible invalid change of some private values of this record stream
            if (offset < 0)
                throw new ArgumentOutOfRangeException(IOResources.ERR_RecordStream_InvalidOffset);
            if (count <= 0)
                throw new ArgumentOutOfRangeException(IOResources.ERR_RecordStream_InvalidCount);
            if (offset + count > buffer.Length)
                throw new ArgumentException(IOResources.ERR_RecordStream_InvalidOffsetAndCount);
            if (!CanRead)
                throw new NotSupportedException(IOResources.ERR_RecordStream_CannotRead);

            _rinfo._infoModified1 = true;
            _rinfo._infoModified2 = true;
            //count is taking part in the reading process 
            //and has itself altered after writing a certain amount of bytes
            //so we make a copy of "count" to record the initial value.
            var oricount = count;
            var poi = Position;
            Position = poi; //the position of the underlying stream may have been changed, and this line make it back to the right place

            int sectionIndex = 0;
            sectionIndex = (int)(poi / _rinfo._blockLength);

            if (sectionIndex < _rinfo._list.Count)
            {
                sectionIndex++;
                if (!IsNew)
                {
                    var sectionRemain = (int)(_rinfo._blockLength - (_currPos % _rinfo._blockLength));
                    if (sectionRemain != 0)
                    {
                        if (count <= sectionRemain)
                        {
                            _dataStream.Write(buffer, offset, count);
                            _currPos += count;
                            _rinfo._totalLength = Math.Max(_currPos, _rinfo._totalLength);
                            return;
                        }
                        else
                        {
                            _dataStream.Write(buffer, offset, sectionRemain);
                            count -= sectionRemain;
                            offset += sectionRemain;
                            _currPos += sectionRemain;
                            _rinfo._totalLength = Math.Max(_currPos, _rinfo._totalLength);
                        }
                    }
                }
            }

            var temp0 = ((double)count / _rinfo._blockLength);
            var temp1 = (int)Math.Ceiling(temp0); //number of sections to write
            var temp3 = _rinfo._list.Count - sectionIndex; //number of available sections

            bool newSectionNeeded = (temp1 > temp3);
            var limit = newSectionNeeded ? temp3 + sectionIndex : temp1 + sectionIndex;
            while (sectionIndex < limit)
            {
                _dataStream.SeekTo(_rinfo._list[sectionIndex++]);
                var byteCount = Math.Min(_rinfo._blockLength, count);
                _dataStream.Write(buffer, offset, byteCount);
                count -= byteCount;
                offset += byteCount;
                _currPos += byteCount;
                _rinfo._totalLength = Math.Max(_currPos, _rinfo._totalLength);
            }

            if (newSectionNeeded)
            {
                _currPos = _rinfo._totalLength;
                if (_manager != null)
                {
                    long pos;
                    while ((pos = _manager.ApplySection(_rinfo._blockLength)) != -1 && count > 0)
                    {
                        _dataStream.SeekTo(pos);
                        var byteCount = Math.Min(_rinfo._blockLength, count);
                        _dataStream.Write(buffer, offset, byteCount);
                        count -= byteCount;
                        offset += byteCount;
                        _currPos += byteCount;
                        _rinfo._totalLength += byteCount;
                        _rinfo._list.Add(pos);
                    }
                }

                if (count > 0)
                {
                    var endPos = _dataStream.Length;
                    _dataStream.SeekToEnd();
                    _dataStream.Write(buffer, offset, count);
                    var newSectionCount = (int)Math.Ceiling((double)count / _rinfo._blockLength);

                    //fill the blanks
                    var occupancy = count % _rinfo._blockLength;
                    if (occupancy != 0)
                    {
                        var blanks = _rinfo._blockLength - occupancy;
                        var fillBytes = new byte[blanks];
                        _dataStream.Write(fillBytes, 0, blanks);
                        _dataStream.SeekBackward(blanks);
                    }

                    _currPos += count;
                    _rinfo._totalLength += count;
                    for (int i = 0; i < newSectionCount; i++)
                        _rinfo._list.Add(endPos + i * _rinfo._blockLength);
                }
            }
        }

        Stream IBasicRecord.InfoStream
        {
            get { return _infoStream; }
            set { _infoStream = value; }
        }

        Stream IBasicRecord.DataStream
        {
            get { return _dataStream; }
            set { _dataStream = value; }
        }

        long IBasicRecord.InfoPosition
        {
            get { return _infoPos; }
            set { _infoPos = value; }
        }
    }
}
