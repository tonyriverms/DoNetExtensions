using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace System.IO
{
    [Flags]
    enum CloseOptions
    {
        None = 0,
        Flush = 1,
        CloseWrapper = 2,
        CloseBase = 4
    }

    internal class BlockStream : Stream
    {
        long _pointerPosition;
        long _blockEndPosition;
        Stream _wrapper;
        Stream _baseStream;
        Action _wrapperFlush;
        CloseOptions _closeOption;
        bool _readMode;

        public static BlockStream Create(Stream baseStream, Stream wrapper, Action wrapperFlush, CloseOptions closeOption)
        {
            var block = new BlockStream()
            {
                _baseStream = baseStream,
                _pointerPosition = baseStream.Length,
                _wrapperFlush = wrapperFlush,
                _closeOption = closeOption,
                _wrapper = wrapper
            };
            baseStream.WriteInt64(0);
            return block;
        }

        public static BlockStream Read(Stream baseStream, Stream wrapper, Action wrapperFlush, CloseOptions closeOption)
        {
            var block = new BlockStream()
            {
                _readMode = true,
                _baseStream = baseStream,
                _pointerPosition = baseStream.Position,
                _wrapperFlush = wrapperFlush,
                _closeOption = closeOption,
                _wrapper = wrapper,
                _blockEndPosition = baseStream.ReadInt64(),
            };

            block._length = block._blockEndPosition - sizeof(Int64) - block._pointerPosition;
            return block;
        }

        public override bool CanRead
        {
            get { return _wrapper.CanRead; }
        }

        public override bool CanSeek
        {
            get { return _wrapper.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return _wrapper.CanWrite; }
        }

        public override void Flush()
        {
            _wrapper.Flush();
        }

        long _length;
        public override long Length
        {
            get 
            {
                if (_readMode) return _length;
                else return _baseStream.Position - _pointerPosition - sizeof(Int64);
            }
        }

        public override long Position
        {
            get
            {
                return _baseStream.Position - _pointerPosition - sizeof(Int64);
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (_readMode)
                return _wrapper.Read(buffer, offset, count);
            else throw new InvalidOperationException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _wrapper.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _wrapper.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            if (_readMode) throw new InvalidOperationException();
            _wrapper.Write(buffer, offset, count);
        }

        protected override void Dispose(bool disposing)
        {
            if (_readMode)
                _baseStream.SeekTo(_blockEndPosition);
            else
            {
                if (_closeOption.HasFlag(CloseOptions.Flush))
                {
                    if (_wrapperFlush == null)
                        _wrapper.Flush();
                    else _wrapperFlush();
                }

                var currPos = _baseStream.Position;
                _baseStream.SeekTo(_pointerPosition);
                _baseStream.WriteInt64(currPos);
                _baseStream.SeekTo(currPos);
            }

            if (_closeOption.HasFlag(CloseOptions.CloseWrapper))
                _wrapper.Close();

            if (_closeOption.HasFlag(CloseOptions.CloseBase))
                _baseStream.Close();

            base.Dispose(disposing);
        }
    }

    [Flags]
    public enum BlockOptions
    {
        None = 0,
        Compression = 1,
        Encryption = 2
    }

    public static partial class StreamEx
    {
        public static Stream CreateBlock(this Stream baseStream, BlockOptions options, byte[] key, byte[] iv)
        {
            var compression = options.HasFlag(BlockOptions.Compression);
            var encryption = options.HasFlag(BlockOptions.Encryption);
            if (compression)
            {
                if (encryption) //compression & encryption
                {
                    var gzipStream = new GZipStream(baseStream, CompressionLevel.Optimal, true);
                    var rijAlg = Rijndael.Create();
                    rijAlg.Key = key;
                    rijAlg.IV = iv;
                    var encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);
                    var encryptionStream = new CryptoStream(gzipStream, encryptor, CryptoStreamMode.Write);
                    return BlockStream.Create(baseStream, encryptionStream, () =>
                        {
                            encryptionStream.FlushFinalBlock();
                            gzipStream.Close();
                        }, CloseOptions.Flush);
                }
                else //compression
                {
                    var gzipStream = new GZipStream(baseStream, CompressionLevel.Optimal, true);
                    return BlockStream.Create(baseStream, gzipStream, null, CloseOptions.Flush | CloseOptions.CloseWrapper);
                }
            }
            else
            {
                if (encryption) //encryption
                {
                    var rijAlg = Rijndael.Create();
                    rijAlg.Key = key;
                    rijAlg.IV = iv;
                    var encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);
                    var encryptionStream = new CryptoStream(baseStream, encryptor, CryptoStreamMode.Write);
                    return BlockStream.Create(baseStream, encryptionStream, () =>
                    {
                        encryptionStream.FlushFinalBlock();
                    }, CloseOptions.Flush);
                }
                else throw new ArgumentOutOfRangeException();
            }
        }

        public static Stream ReadBlock(this Stream baseStream, BlockOptions options, byte[] key, byte[] iv)
        {
            var compression = options.HasFlag(BlockOptions.Compression);
            var encryption = options.HasFlag(BlockOptions.Encryption);
            if (compression)
            {
                if (encryption) //compression & encryption
                {
                    var gzipStream = new GZipStream(baseStream, CompressionMode.Decompress, true);
                    var rijAlg = Rijndael.Create();
                    rijAlg.Key = key;
                    rijAlg.IV = iv;
                    var encryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
                    var encryptionStream = new CryptoStream(gzipStream, encryptor, CryptoStreamMode.Read);
                    return BlockStream.Read(baseStream, encryptionStream, () =>
                    {
                        gzipStream.Close();
                    }, CloseOptions.Flush);
                }
                else //compression
                {
                    var gzipStream = new GZipStream(baseStream, CompressionMode.Decompress, true);
                    return BlockStream.Read(baseStream, gzipStream, null, CloseOptions.CloseWrapper);
                }
            }
            else
            {
                if (encryption) //encryption
                {
                    var rijAlg = Rijndael.Create();
                    rijAlg.Key = key;
                    rijAlg.IV = iv;
                    var encryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
                    var encryptionStream = new CryptoStream(baseStream, encryptor, CryptoStreamMode.Read);
                    return BlockStream.Read(baseStream, encryptionStream, null, CloseOptions.None);
                }
                else throw new ArgumentOutOfRangeException();
            }
        }

        public static void SkipBlock(this Stream baseStream)
        {
            var pos = baseStream.ReadInt64();
            baseStream.SeekTo(pos);
        }
    }
}
