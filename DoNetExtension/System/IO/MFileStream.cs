using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace System.IO
{
    public class MFileStream : Stream
    {
        List<FileStream> _fileStreams;
        FileStream _currStream;
        int _currIndex;
        FileMode _mode;
        FileAccess _access;
        FileShare _share;
        string _path;
        int _fileSize;

        public MFileStream(string path, FileMode mode, FileAccess access, FileShare share, int fileSize)
        {
            _path = path;
            _mode = mode;
            _access = access;
            _share = share;
            _fileSize = fileSize;

            int i = 0;
            var tpath = _getPath(i++);
            _add(tpath);
            tpath = _getPath(i++);
            while (File.Exists(tpath))
            {
                _add(path);
                tpath = _getPath(i++);
            }
        }

        string _getPath(int i)
        {
            return "{0}.{1}".Scan(_path, i);
        }

        void _add(string path)
        {
            _fileStreams.Add(new FileStream(path, _mode, _access, _share));
        }

        public override bool CanRead
        {
            get { return (_access == FileAccess.Read || _access == FileAccess.ReadWrite); }
        }

        public override bool CanSeek
        {
            get { return true; }
        }

        public override bool CanWrite
        {
            get { return (_access == FileAccess.Write || _access == FileAccess.ReadWrite); }
        }

        public override void Flush()
        {
            _fileStreams.ForEach((fs) => fs.Flush());
        }

        public override long Length
        {
            get { return (_fileStreams.Count - 1) * _fileSize + _fileStreams.Last().Length; }
        }

        public override long Position
        {
            get
            {
                return _currIndex * _fileSize + _currStream.Length;
            }
            set
            {
                var r = value % _fileSize;
                var idx = (int)((value - r) / _fileSize);
                _currStream = _fileStreams[idx];
                _currStream.SeekTo(r);
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var remain = _currStream.Length - _currStream.Position;
            if (remain > count)
            {
                var actualRead = _currStream.Read(buffer, offset, count);
                if (actualRead < count)
                    throw new InvalidDataException();
            }
            else
            {
                var remain2 = (int)remain;
                var actualRead = _currStream.Read(buffer, offset, remain2);
                if (actualRead < remain2)
                    throw new InvalidDataException();

                offset += remain2;
                count -= remain2;

                while (true)
                {
                    _currIndex++;
                    if (_currIndex == _fileStreams.Count)
                    {
                        var tpath = _getPath(_currIndex);
                        _add(tpath);
                    }
                    _currStream = _fileStreams[_currIndex];

                    if (_fileSize > count)
                    {
                        actualRead = _currStream.Read(buffer, offset, count);
                        if (actualRead < count)
                            throw new InvalidDataException();
                        break;
                    }
                    else
                    {
                        actualRead = _currStream.Read(buffer, offset, _fileSize);
                        if (actualRead < _fileSize)
                            throw new InvalidDataException();
                        offset += _fileSize;
                        count -= _fileSize;
                    }
                }
            }

            return count;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            var r = value % _fileSize;
            var c = (value - r) / _fileSize; //1
            var j = _fileStreams.Count; //1

            while (j < c)
            {
                var tpath = _getPath(j++);
                _add(tpath);
            }

            if (r > 0 && j == c)
            {
                var tpath = _getPath(j++);
                _add(tpath);
            }

            for (int i = 0; i < j - 1; i++)
                _fileStreams[i].SetLength(_fileSize);

            _fileStreams[j - 1].SetLength(r);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            var remain = _currStream.Length - _currStream.Position;
            if (remain > count)
                _currStream.Write(buffer, offset, count);
            else
            {
                var remain2 = (int)remain;
                _currStream.Write(buffer, offset, remain2);

                offset += remain2;
                count -= remain2;

                while (true)
                {
                    _currIndex++;
                    if (_currIndex == _fileStreams.Count)
                    {
                        var tpath = _getPath(_currIndex);
                        _add(tpath);
                    }
                    _currStream = _fileStreams[_currIndex];

                    if (_fileSize > count)
                    {
                        _currStream.Write(buffer, offset, count);
                        break;
                    }
                    else
                    {
                        _currStream.Write(buffer, offset, _fileSize);
                        offset += _fileSize;
                        count -= _fileSize;
                    }
                }
            }
        }
    }
}
