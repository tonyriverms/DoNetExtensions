using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DoNetExtension.System.IO;
using DoNetExtension.System.IO;

namespace System.IO
{
    /// <summary>
    /// A forward-only stream that allows storing records of indefinite size on the same base stream. Overhead is remarkably lower than a similar class <see cref="RecordStream"/>.
    /// </summary>
    /// <remarks>
    /// This class allocate blocks of variable length to store data and works much like a forward-only linked list. In this sense backward-seeking is not supported by this class.
    /// A similar class <see cref="RecordStream"/> always allocates blocks of the same length and is able to seek back and forth. 
    /// However, two methods <c>SaveStatus</c> and <c>RestoreStatus</c> are provided to alleviate this drawback.
    /// Also note that the memory usage of each instance of this class is fixed, with contrast to <see cref="RecordStream"/> which uses more memory when new blocks are created.
    /// </remarks>
    public class FRecordStream : Stream, IBasicRecord
    {
        /// <summary>
        /// The base stream.
        /// </summary>
        Stream _base;

        /// <summary>
        /// The position in the base stream where this record stream begins.
        /// </summary>
        long _startPosition;

        /// <summary>
        /// Represents the current data block.
        /// </summary>
        _frinfo _info;

        /// <summary>
        /// Initializes a new instance of <see cref="FRecordStream"/> that represents a new record.
        /// </summary>
        /// <param name="baseStream">A <see cref="System.IO.Stream"/> where data are actually stored.</param>
        /// <param name="bytesForLength">Specifies how many bytes are enough to describe the size of a data block. For example, if the maximum size of a data block is 64KB, then 2 bytes are sufficient.</param>
        /// <param name="bytesForPosition">Specifies how many bytes are enough to describe the total size of data. For example, if the maximum size of all data is 4GB, then 4 bytes are sufficient.</param>
        public FRecordStream(Stream baseStream, byte bytesForLength = 4, byte bytesForPosition = 4)
            : this(baseStream, -1, 32, bytesForLength, bytesForPosition)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="FRecordStream"/> that represents either a new record (when <paramref name="startPosition"/> is assigned -1) or an existing record.
        /// <para>!!! If this instance represents an existing record (<paramref name="startPosition"/> not set -1), invoking <c>LoadInfo</c> method is necessary before many operations. </para>
        /// <para>!!! Also note its initial position is the previously saved position rather than 0, and call <c>Reset</c> method if reading from the beginning is intended.</para>
        /// </summary>
        /// <param name="baseStream">A <see cref="System.IO.Stream"/> where data are actually stored.</param>
        /// <param name="startPosition">Specifies a non-negative integer to indicate the location of an existing record in <paramref name="baseStream"/>, or -1 to create a new record.</param>
        /// <param name="minimumBlockSize">Specifies the minimum size in bytes of a data block.</param>
        /// <param name="bytesForLength">Specifies how many bytes are enough to describe the size of a data block. For example, if the maximum size of a data block is 64KB, then 2 bytes are sufficient.</param>
        /// <param name="bytesForPosition">Specifies how many bytes are enough to describe the total size of data. For example, if the maximum size of all data is 4GB, then 4 bytes are sufficient.</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="baseStream"/> is <c>null</c>.</exception>
        /// <exception cref="System.ArgumentException"><paramref name="baseStream"/> must be seekable, readable and writable.</exception>
        public FRecordStream(Stream baseStream, Int64 startPosition, ushort minimumBlockSize, byte bytesForLength, byte bytesForPosition)
        {
            if (baseStream == null) throw new ArgumentNullException("baseStream");
            if (!baseStream.CanSeek && !baseStream.CanRead && !baseStream.CanWrite) throw new ArgumentException(IOResources.ERR_FRecordStream_InvalidBaseStream);
            _base = baseStream;

            _startPosition = startPosition;
            if (_startPosition == -1)
            {
                _info = new _frinfo()
                {
                    _bytesFor = (byte)((byte)bytesForLength | (byte)(bytesForPosition << 4)),
                    _blockStart = -1,
                    _autoalloc = minimumBlockSize
                };
            }
        }

        /// <summary>
        /// Gets the base stream where this instance actually stores data.
        /// </summary>
        public Stream BaseStream
        {
            get { return _base; }
        }

        /// <summary>
        /// Gets a value indicating whether the end of this <see cref="FRecordStream"/> has been reached.
        /// <para>!!! This property is invalid if necessary meta information has not been loaded. In this case, call <c>LoadInfo</c> method first.</para>
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Necessary meta information has not been loaded. Call <c>LoadInfo</c> method first.</exception>
        public bool EndOfStream
        {
            get
            {
                if (!Loaded) throw new InvalidOperationException(IOResources.ERR_FRecordStream_NotLoaded);
                lock (_base) return _base.Position == _info._endPosition;
            }
        }

        /// <summary>
        /// Gets the positon in the base stream where this <see cref="FRecordStream"/> begins.
        /// </summary>
        public Int64 StartPosition
        {
            get { return _startPosition; }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="FRecordStream"/> is loaded.
        /// </summary>
        public bool Loaded
        {
            get { return _info != null; }
        }

        /// <summary>
        /// Gets a number indicating how many bytes are used to describe the size of a data block.
        /// For example, if the maximum size of a data block is 64KB, then the returned value of this property will be 2.
        /// </summary>
        public byte BytesForLength
        {
            get { return (byte)(_info._bytesFor & 0x0F); }
            private set { _info._bytesFor = (byte)(((byte)(_info._bytesFor & 0xF0)) | value); }
        }

        /// <summary>
        /// Gets a number indicating how many bytes are used to describe the position of a data block.
        /// For example, if the maximum size of all data is 4GB, then the returned value of this property will be 4.
        /// </summary>
        public byte BytesForPosition
        {
            get { return (byte)((_info._bytesFor & 0xF0) >> 4); }
            private set { _info._bytesFor = (byte)(((byte)(_info._bytesFor & 0x0F)) | (byte)(value << 4)); }
        }

        /// <summary>
        /// Gets the minimum size in bytes of a data block.
        /// </summary>
        public UInt16 MinimumBlockSize { get { return _info._autoalloc; } }

        /// <summary>
        /// Preserves the current status (especially data position) of this <see cref="FRecordStream"/>. The current status is temporarily stored and will be discarded by <c>UnloadInfo</c> method.
        /// <para>!!! This method is invalid if necessary meta information has not been loaded. In this case, call <c>LoadInfo</c> method first.</para>
        /// <para>!!! This method is invalid if there currently exists no data block in this instance. Call <c>Reset</c> method instead of saving the initial position by this method.</para>
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        /// <para>Necessary meta information has not been loaded and you need to call <c>LoadInfo</c> method first;</para>
        /// <para>or you call this method when the current <see cref="FRecordStream"/> is empty.</para>
        /// </exception>
        /// <example>
        /// The following codes shows how <c>SaveStatus</c> and <c>RestoreStatus</c> are used to remember and go back to history position.
        /// <code>
        ///     var ms = new MemoryStream();
        ///     var fr = new FRecordStream(ms);
        ///     fr.LoadInfo();
        ///     //fr.SaveStatus(); //Invalid operation! This record stream is new and right after LoadInfo it is still empty.
        ///     fr.WriteString("abcdefg");
        ///     fr.SaveStatus();
        ///     fr.WriteString("hijklmn");
        ///     fr.SaveStatus();
        ///     fr.WriteString("opqrst");
        ///     fr.Reset();
        ///     Console.WriteLine(fr.ReadString()); //"abcdefg"
        ///     Console.WriteLine(fr.ReadString()); //"hijklmn"
        ///     Console.WriteLine(fr.ReadString()); //"opqrst"
        ///     fr.RestoreStatus();
        ///     Console.WriteLine(fr.ReadString()); //"opqrst"
        ///     fr.RestoreStatus();
        ///     Console.WriteLine(fr.ReadString()); //"hijklmn"
        ///</code>
        /// </example>
        public void SaveStatus(bool cascade = false)
        {
            if (!Loaded) throw new InvalidOperationException(IOResources.ERR_FRecordStream_NotLoaded);
            _info._prevStatus = cascade ? new _frinfo21(_info) : new _frinfo2(_info);
        }

        /// <summary>
        /// Restores this <see cref="FRecordStream"/> to its previous status.
        /// <para>!!! This method is invalid if necessary meta information has not been loaded. In this case, call <c>LoadInfo</c> method first.</para>
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        /// Necessary meta information has not been loaded and you need to call <c>LoadInfo</c> method first;
        /// </exception>
        /// <example>
        /// The following codes shows how <c>SaveStatus</c> and <c>RestoreStatus</c> are used to remember and go back to history position.
        /// <code>
        ///     var ms = new MemoryStream();
        ///     var fr = new FRecordStream(ms);
        ///     fr.LoadInfo();
        ///     //fr.SaveStatus(); //Invalid operation! This record stream is new and right after LoadInfo it is still empty.
        ///     fr.WriteString("abcdefg");
        ///     fr.SaveStatus();
        ///     fr.WriteString("hijklmn");
        ///     fr.SaveStatus();
        ///     fr.WriteString("opqrst");
        ///     fr.Reset();
        ///     Console.WriteLine(fr.ReadString()); //"abcdefg"
        ///     Console.WriteLine(fr.ReadString()); //"hijklmn"
        ///     Console.WriteLine(fr.ReadString()); //"opqrst"
        ///     fr.RestoreStatus();
        ///     Console.WriteLine(fr.ReadString()); //"opqrst"
        ///     fr.RestoreStatus();
        ///     Console.WriteLine(fr.ReadString()); //"hijklmn"
        ///</code>
        /// </example>
        public void RestoreStatus(bool cascade = false)
        {
            if (!Loaded) throw new InvalidOperationException();
            var prev = _info._prevStatus;
            _info._blockStart = prev._blockStart;
            _info._blockLen = prev._blockLen;
            _info._currPosition = prev._currPosition;

            if (cascade)
                _info._prevStatus = ((_frinfo21)prev)._prevStatus;
        }

        /// <summary>
        /// Gets a value indicating whether this stream supports reading. <c>true</c> always.
        /// </summary>
        public override bool CanRead
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether this stream supports seeking. <c>true</c> always.
        /// <para>!!! The seeking support is limited to forward-only.</para>
        /// </summary>
        public override bool CanSeek
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether this stream supports writing. <c>true</c> always.
        /// </summary>
        public override bool CanWrite
        {
            get { return true; }
        }

        /// <summary>
        /// Clears all buffers for this stream and causes any buffered data to be written to the underlying device.
        /// </summary>
        public override void Flush()
        {
            _base.Flush();
        }

        /// <summary>
        /// Not supported. Use <c>BaseStream.Length</c> to get the length of the underlying stream.
        /// </summary>
        /// <exception cref="System.NotSupportedException">Always raises.</exception>
        public override long Length
        {
            get { throw new NotSupportedException(); }
        }

        /// <summary>
        /// Not supported. Use <c>BaseStream.Position</c> to get the position of the underlying stream.
        /// </summary>
        /// <exception cref="System.NotSupportedException">Always raises.</exception>
        public override long Position
        {
            get
            {
                throw new NotSupportedException();
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Allocates new space in the underlying stream to store more data. 
        /// <para>** It is not necessary to call this method when avaialbe space is not sufficient since new space will be automatically assigned. This method provies a way to manually request space.</para>
        /// <para>!!! This method is invalid if necessary meta information has not been loaded. In this case, call <c>LoadInfo</c> method first.</para>
        /// </summary>
        /// <param name="size"></param>
        /// <exception cref="System.InvalidOperationException">
        /// Necessary meta information has not been loaded and you need to call <c>LoadInfo</c> method first;
        /// </exception>
        public void Alloc(int size)
        {
            if (!Loaded) throw new InvalidOperationException(IOResources.ERR_FRecordStream_NotLoaded);

            var bfc = BytesForLength;
            var bfp = BytesForPosition;
            var streamMetaLength = _info._size(bfp, bfc);
            var blockMetaLength = bfc;

            lock (_base)
            {
                if (_startPosition == -1)
                {
                    if (_base.Length == 0)
                        _base.WriteByte(0);

                    _startPosition = _base.Length;
                    var blkstart = _startPosition + streamMetaLength + blockMetaLength;
                    var end = blkstart + size;
                    _base.SeekToEnd();

                    _info._blockLen = size;
                    _info._blockStart = blkstart;
                    _info._endPosition = end;
                    _info._currPosition = blkstart;

                    this.SetLength(end);
                    _base.SeekForward(streamMetaLength); //no need to preserve stream meta right now
                    _base.WriteInt32(size, bfc);
                    _base.SeekToEnd();

                    _base.WriteInt64(0, bfp); //no next
                }
                else
                {
                    _base.SeekTo(_info._endPosition);
                    _base.WriteInt64(_base.Length, bfp);
                    _base.SeekToEnd();
                    _base.WriteInt32(size, bfc);
                    this.SetLength(_base.Length + size);
                    _base.SeekToEnd();
                    _base.WriteInt64(0, bfp);
                }
            }
        }

        /// <summary>
        /// Goes to the beginning of this <see cref="FRecordStream"/>.
        /// </summary>
        public void Reset()
        {
            if (_startPosition == -1) return;

            var bfc = BytesForLength;
            var bfp = BytesForPosition;
            var streamMetaLength = _info._size(bfp, bfc);
            var blockMetaLength = bfc;

            var blkstart = _startPosition + streamMetaLength;
            var blkstart2 = blkstart + blockMetaLength;

            if (blkstart2 != _info._blockStart)
            {
                lock (_base)
                {
                    _base.SeekTo(blkstart);
                    _info._blockLen = _base.ReadInt32(bfc);
                }
            }
            _info._currPosition = _info._blockStart = blkstart2;
        }

        /// <summary>
        /// Reads a sequence of bytes from the current stream and advances the position within the stream by the number of bytes read.
        /// <para>!!! This method is invalid if necessary meta information has not been loaded. In this case, call <c>LoadInfo</c> method first.</para>
        /// <para>!!! This method is invalid if there currently exists no data block in this instance. Writes some data first.</para>
        /// </summary>
        /// <param name="buffer">An array of bytes. When this method returns, 
        /// the buffer contains the specified byte array with the values between <paramref name="offset"/> and (<paramref name="offset"/> + <paramref name="count"/> - 1) 
        /// replaced by the bytes read from the current source.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin storing the data read from the current stream.</param>
        /// <param name="count">The maximum number of bytes to be read from the current stream.</param>
        /// <returns>The total number of bytes read into the buffer. 
        /// This can be less than the number of bytes requested if that many bytes are not currently available, or zero (0) if the end of the stream has been reached.</returns>
        /// <exception cref="System.InvalidOperationException">
        /// <para>Necessary meta information has not been loaded and you need to call <c>LoadInfo</c> method first;</para>
        /// <para>or you call this method when the current <see cref="FRecordStream"/> is empty.</para>
        /// </exception>
        public override int Read(byte[] buffer, int offset, int count)
        {
            if (!Loaded || Empty) throw new InvalidOperationException(IOResources.ERR_FRecordStream_EmptyOrNotLoaded);

            int total = 0;
            var bfc = BytesForLength;
            var bfp = BytesForPosition;
            var streamMetaLength = _info._size(bfp, bfc);
            var blockMetaLength = bfc;

            var currPos = _info._currPosition;
            var blkstart = _info._blockStart;
            var blkend = blkstart + _info._blockLen;
            var end = _info._endPosition;

            lock (_base)
            {
                _base.SeekTo(currPos);

                if (currPos == blkend) // end of block
                {
                    if (currPos == end) //end of stream
                        return 0;
                    else
                    {
                        var next = _base.ReadInt64(bfp);
                        _base.SeekTo(next);

                        _info._blockLen = _base.ReadInt32(bfc);
                        blkstart = _info._blockStart = next + blockMetaLength;
                        blkend = blkstart + _info._blockLen;
                        currPos = _info._currPosition = blkstart;
                    }
                }

                var remain = (int)(blkend - currPos);
                while (remain < count)
                {
                    _base.Read(buffer, offset, remain);

                    offset += remain;
                    count -= remain;
                    total += remain;

                    if (_base.Position == end)
                        return total;

                    var next = _base.ReadInt64(bfp);
                    _base.SeekTo(next);

                    var blklen = _info._blockLen = _base.ReadInt32(bfc);
                    blkstart = _info._blockStart = next + blockMetaLength;
                    blkend = blkstart + blklen;
                    currPos = _info._currPosition = blkstart;
                    remain = blklen;
                }

                _base.Read(buffer, offset, count);
                _info._currPosition = _base.Position;
            }

            return total + count;
        }

        /// <summary>
        /// Writes a sequence of bytes to the current stream and advances the current position within this stream by the number of bytes written.
        /// <para>!!! This method is invalid if necessary meta information has not been loaded. In this case, call <c>LoadInfo</c> method first.</para>
        /// </summary>
        /// <param name="buffer">An array of bytes. This method copies <paramref name="count"/> bytes from buffer to the current stream.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin copying bytes to the current stream.</param>
        /// <param name="count">The number of bytes to be written to the current stream.</param>
        public override void Write(byte[] buffer, int offset, int count)
        {
            if (_info == null) throw new InvalidOperationException(IOResources.ERR_FRecordStream_NotLoaded);

            var bfc = BytesForLength;
            var bfp = BytesForPosition;
            var streamMetaLength = _info._size(bfp, bfc);
            var blockMetaLength = bfc;

            lock (_base)
            {
                if (_startPosition == -1)
                {
                    var blken = Math.Max(_info._autoalloc, count);

                    if (_base.Length == 0)
                        _base.WriteByte(0);

                    _startPosition = _base.Length;
                    var blkstart = _startPosition + streamMetaLength + blockMetaLength;
                    var end = blkstart + blken;

                    _base.SeekToEnd();

                    _info._blockLen = blken;
                    _info._blockStart = blkstart;
                    _info._endPosition = end;
                    _info._currPosition = blkstart + count;

                    this.SetLength(end);
                    _base.SeekForward(streamMetaLength); //no need to preserve meta right now
                    _base.WriteInt32(blken, bfc);
                    _base.Write(buffer, offset, count);
                    _base.SeekToEnd();

                    //no next
                    _base.WriteInt64(0, bfp);

                    return;
                }
                else
                {
                    var currPos = _info._currPosition;
                    var blkstart = _info._blockStart;
                    var blkend = blkstart + _info._blockLen;
                    var end = _info._endPosition;
                    _base.SeekTo(currPos);

                    if (currPos == blkend) // end of block
                    {
                        if (currPos == end) //end of stream
                        {
                            var baselen = _base.Length;
                            var blken = Math.Max(_info._autoalloc, count);
                            blkstart = baselen + blockMetaLength;

                            //alloc
                            //_base.SeekBackward(bfp);
                            _base.WriteInt64(baselen, bfp);
                            _base.SeekToEnd();

                            _base.WriteInt32(blken, bfc);
                            this.SetLength(_base.Length + blken);
                            _base.SeekToEnd();
                            _base.WriteInt64(0, bfp);

                            _info._blockLen = blken;
                            _info._currPosition = _info._blockStart = blkstart;
                            _info._endPosition = blken + blkstart;
                            _base.SeekTo(blkstart);

                            //data
                            _base.Write(buffer, offset, count);
                            _info._currPosition = _base.Position;

                            return;
                        }
                        else
                        {
                            var next = _base.ReadInt64(bfp);
                            _base.SeekTo(next);

                            _info._blockLen = _base.ReadInt32(bfc);
                            blkstart = _info._blockStart = next + blockMetaLength;
                            blkend = blkstart + _info._blockLen;
                            currPos = _info._currPosition = blkstart;
                        }
                    }

                    //not end of block

                    var remain = (int)(blkend - currPos);
                    while (remain < count)
                    {
                        _base.Write(buffer, offset, remain);

                        offset += remain;
                        count -= remain;

                        var next = _base.ReadInt64(bfp);
                        if (next == 0) //end of stream
                        {
                            var baselen = _base.Length;
                            var blken = Math.Max(_info._autoalloc, count);
                            blkstart = baselen + blockMetaLength;

                            //alloc
                            _base.SeekBackward(bfp);
                            _base.WriteInt64(baselen, bfp);
                            _base.SeekToEnd();

                            _base.WriteInt32(blken, bfc);
                            this.SetLength(_base.Length + blken);
                            _base.SeekToEnd();
                            _base.WriteInt64(0, bfp);

                            _info._blockLen = blken;
                            _info._currPosition = _info._blockStart = blkstart;
                            _info._endPosition = blken + blkstart;
                            _base.SeekTo(blkstart);

                            //data
                            _base.Write(buffer, offset, count);
                            _info._currPosition = _base.Position;

                            return;
                        }

                        _base.SeekTo(next);

                        var blklen = _info._blockLen = _base.ReadInt32(bfc);
                        blkstart = _info._blockStart = next + blockMetaLength;
                        blkend = blkstart + _info._blockLen;
                        currPos = _info._currPosition = blkstart;
                        remain = blklen;

                    }

                    _base.Write(buffer, offset, count);
                    _info._currPosition = _base.Position;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether the current <see cref="FRecordStream"/> is empty and no data block has been created.
        /// </summary>
        public bool Empty
        {
            get { return _startPosition == -1; }
        }

        /// <summary>
        /// Sets the position within the current stream. This method is limited in the following ways,
        /// 1. only <c>Current</c> is valid for <paramref name="origin"/>;
        /// 2. backward seeking (negative <paramref name="offset"/>) is only allowed within the current data block.
        /// <para>!!! This method is invalid if necessary meta information has not been loaded. In this case, call <c>LoadInfo</c> method first.</para>
        /// <para>!!! This method is invalid if there currently exists no data block in this instance. Writes some data first.</para>
        /// </summary>
        /// <param name="offset">A byte offset relative to the <paramref name="origin"/> parameter.</param>
        /// <param name="origin">A value of type <see cref="SeekOrigin"/> indicating the reference point used to obtain the new position.
        /// <para>!!! For <see cref="FRecordStream"/>, only <c>Current</c> is valid.</para></param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">
        /// <para>Necessary meta information has not been loaded and you need to call <c>LoadInfo</c> method first;</para>
        /// <para>or you call this method when the current <see cref="FRecordStream"/> is empty.</para>
        /// </exception>
        public override long Seek(long offset, SeekOrigin origin)
        {
            if (!Loaded || Empty) throw new InvalidOperationException(IOResources.ERR_FRecordStream_EmptyOrNotLoaded);

            var currPos = _info._currPosition;
            var blkstart = _info._blockStart;
            if (origin == SeekOrigin.Current)
            {
                if (offset > 0)
                {
                    var blkend = blkstart + _info._blockLen;
                    var remain = (int)(blkend - currPos);
                    lock (_base)
                    {
                        while (remain < offset)
                        {
                            _base.SeekTo(blkend);
                            offset -= remain;

                            blkstart = _base.ReadInt64(BytesForPosition);
                            if (blkstart == 0) throw new InvalidDataException();
                            else
                            {
                                _base.SeekTo(blkstart);
                                var bfc = BytesForLength;
                                var blklen = _info._blockLen = _base.ReadInt32(bfc);
                                blkstart += bfc;
                                currPos = _info._blockStart = blkstart;
                                blkend = blkstart + blklen;
                                remain = blklen;
                            }
                        }

                        _base.SeekTo(currPos + offset);
                    }
                }
                else if (offset < 0)
                {
                    currPos += offset;
                    if (currPos >= blkstart) lock (_base) _base.SeekTo(currPos);
                    else throw new NotSupportedException();
                }
            }
            else if (origin == SeekOrigin.Begin && offset == 0) Reset();
            else throw new NotSupportedException();

            _info._currPosition = _base.Position;
            return _info._currPosition;
        }

        public override void SetLength(long value)
        {
            lock (_base)
            {
                _base.SeekToEnd();
                var blanks = (int)(value - _base.Length);
                var fillBytes = new byte[blanks];
                _base.Write(fillBytes, 0, blanks);
                _base.SeekBackward(blanks);
            }
        }

        /// <summary>
        /// Goes to the end of this <see cref="FRecordStream"/>.
        /// </summary>
        public void MoveToEnd()
        {
            lock (_base)
                _base.SeekTo(_info._endPosition);
        }

        /// <summary>
        /// Loads necessary information before further operations.
        /// <para>!!! Note that <see cref="FRecordStream"/> remembers its previous position when the last time <c>UnloadInfo</c> is called. 
        /// Always call <c>Reset</c> before reading from the beginning. </para>
        /// </summary>
        public void LoadInfo()
        {
            if (_info == null)
            {
                lock (_base)
                {
                    _base.SeekTo(_startPosition);
                    _info = new _frinfo(_base);
                }
            }
        }

        /// <summary>
        /// Permanently saves the current status of this <see cref="FRecordStream"/>. 
        /// Note that this method remembers the current position which will be restored the next time <c>LoadInfo</c> is called.
        /// </summary>
        public void SaveInfo()
        {
            if (_info != null)
            {
                if (_info._blockStart == -1)
                {
                    var bfp = BytesForPosition;
                    var bfc = BytesForLength;

                    var streamMetaLength = _info._size(bfp, bfc);
                    var blockMetaLength = bfc;

                    int size = _info._autoalloc;
                    if (size == 0) size = 20;

                    lock (_base)
                    {
                        if (_base.Length == 0)
                            _base.WriteByte(0);

                        _startPosition = _base.Length;
                        var blkstart = _startPosition + streamMetaLength + blockMetaLength;
                        var end = blkstart + size;

                        _base.SeekToEnd();

                        _info._blockLen = size;
                        _info._blockStart = blkstart;
                        _info._endPosition = end;
                        _info._currPosition = blkstart;


                        this.SetLength(end);
                        _info._write(_base, bfp, bfc); //no need to preserve meta right now
                        _base.WriteInt32(size, bfc);
                        _base.SeekToEnd();

                        //no next
                        _base.WriteInt64(0, bfp);
                    }
                }
                else
                {
                    lock (_base)
                    {
                        _base.SeekTo(_startPosition);
                        _info._write(_base, BytesForPosition, BytesForLength);
                    }
                }
            }
        }

        /// <summary>
        /// Permanently preserves the current status of this <see cref="FRecordStream"/> and unloads some information to save memory.
        /// This method put this <see cref="FRecordStream"/> into a status where most operations are invalid. You need to call <c>LoadInfo</c> again.
        /// <para>!!! All temporary status stored by <c>SaveStatus</c> method will be discarded.</para>
        /// </summary>
        public void UnloadInfo()
        {
            SaveInfo();
            _info = null;
        }

        /// <summary>
        /// Clears all data stored in this <see cref="FRecordStream"/>.
        /// </summary>
        public void Clear()
        {
            _info = null;
            _startPosition = -1;
        }

        long IBasicRecord.InfoPosition
        {
            get
            {
                return _startPosition;
            }
            set
            {
                _startPosition = value;
            }
        }

        Stream IBasicRecord.InfoStream
        {
            get
            {
                return _base;
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        Stream IBasicRecord.DataStream
        {
            get
            {
                return _base;
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Gets or sets a 64-bit integer that carries user-defined information.
        /// <para>!!! This property is invalid if necessary meta information has not been loaded. In this case, call <c>LoadInfo</c> method first, or use method <c>GetStoredTag</c> instead.</para>
        /// </summary>
        public UInt64 Tag
        {
            get
            {
                if (!Loaded) throw new InvalidOperationException(IOResources.ERR_FRecordStream_NotLoaded);
                return _info._tag;
            }
            set
            {
                if (!Loaded) throw new InvalidOperationException(IOResources.ERR_FRecordStream_NotLoaded);
                _info._tag = value;
            }
        }

        /// <summary>
        /// Gets the stored 64-bit integer tag for this <see cref="FRecordStream"/> even when property <c>Loaded</c> is false. This tag carries some user-defined addtional information.
        /// <para>!!! This method is invalid if there currently exists no data block in this instance. Writes some data first.</para>
        /// </summary>
        /// <returns>A 64-bit unsigned integer as the tag for this instance.</returns>
        /// <exception cref="System.InvalidOperationException">This <see cref="FRecordStream"/> is currently empty.</exception>
        public UInt64 GetStoredTag()
        {
            if (_startPosition == -1) throw new InvalidOperationException(IOResources.ERR_FRecordStream_Empty);
            else
            {
                lock (_base)
                {
                    _base.SeekTo(_startPosition);
                    return _frinfo._getTag(_base);
                }
            }
        }
    }

    class _frinfo
    {
        internal _frinfo2 _prevStatus;
        internal long _endPosition;
        internal long _currPosition;
        internal int _blockLen;
        internal long _blockStart;
        internal ushort _autoalloc;
        internal UInt64 _tag;
        internal byte _bytesFor;

        internal byte _size(byte bfp, byte bfc)
        {
            return (byte)(bfp + bfp + bfp + bfc + 11);
        }

        internal _frinfo(Stream stream)
        {
            _bytesFor = (byte)stream.ReadByte();
            byte bfp = (byte)((_bytesFor & 0xF0) >> 4);
            byte bfc = (byte)(_bytesFor & 0x0F);
            _endPosition = stream.ReadInt64(bfp);
            _currPosition = stream.ReadInt64(bfp);
            _blockStart = stream.ReadInt64(bfp);
            _blockLen = stream.ReadInt32(bfc);
            _autoalloc = stream.ReadUInt16();
            _tag = stream.ReadUInt64();
        }

        internal static UInt64 _getTag(Stream stream)
        {
            var _bytesFor = (byte)stream.ReadByte();
            byte bfp = (byte)((_bytesFor & 0xF0) >> 4);
            byte bfc = (byte)(_bytesFor & 0x0F);
            stream.SeekForward(bfp + bfp + bfp + bfp + 2);
            return stream.ReadUInt64();
        }

        internal void _write(Stream stream, byte bfp, byte bfc)
        {
            stream.WriteByte(_bytesFor);
            stream.WriteInt64(_endPosition, bfp);
            stream.WriteInt64(_currPosition, bfp);
            stream.WriteInt64(_blockStart, bfp);
            stream.WriteInt32(_blockLen, bfc);
            stream.WriteUInt16(_autoalloc);
            stream.WriteUInt64(_tag);
        }

        public _frinfo() { }
    }

    class _frinfo2
    {
        internal long _currPosition;
        internal int _blockLen;
        internal long _blockStart;

        public _frinfo2(_frinfo info)
        {
            _blockStart = info._blockStart;
            if (_blockStart == -1) throw new InvalidOperationException(IOResources.ERR_FRecordStream_Empty);
            _currPosition = info._currPosition;
            _blockLen = info._blockLen;
        }
    }

    class _frinfo21 : _frinfo2
    {
        internal _frinfo2 _prevStatus;

        public _frinfo21(_frinfo info) : base(info)
        {
            _prevStatus = info._prevStatus;
        }
    }
}
