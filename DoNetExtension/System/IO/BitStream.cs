using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using DoNetExtension.System.IO;

namespace System.IO
{
    /// <summary>
    /// Represents
    /// </summary>
    public interface IBitStream
    {
        byte[] ReadBits(int length);
        int Read(byte[] buffer, int offset, int count);
        int ReadByte();
        bool ReadBit();
        void WriteBits(byte value, int length, bool high = false);            
        void Write(byte[] buffer, int offset, int count);
        void WriteByte(byte value);
        void WriteBit(bool value);
        void Reset();
    }

    public class BitCode64
    {
        public UInt64 Code { get; set; }
        public int Length { get; set; }
        public bool High { get; set; }

        public BitCode64(UInt64 code, int length, bool high = false)
        {
            Code = code;
            Length = length;
            High = high;
        }
    }

    public static class BitStreamEx
    {
        public static Dictionary<T, int> GenerateFrequencyDictionary<T>(this IEnumerator<T> enumerator, out int count, int predictCount = 0)
        {
            count = 0;
            Dictionary<T, int> _dict;
            if (predictCount == 0)
                _dict = new Dictionary<T, int>();
            else _dict = new Dictionary<T, int>(predictCount);

            while (enumerator.MoveNext())
            {
                count++;
                if (_dict.ContainsKey(enumerator.Current))
                    _dict[enumerator.Current]++;
                else
                    _dict.Add(enumerator.Current, 1);
            }
            
            return _dict;
        }

        static int _switchProcess<T>(Dictionary<T, int> _dict)
        {
            int sfre = 0;
            List<T> _rlist = new List<T>();
            foreach (var pair in _dict)
            {
                var f = pair.Value;
                var str = pair.Key as string;
                var len = _estimateSize(pair.Key);
                var clen = len + sizeof(ulong) * (f + 1);
                if (clen >= (len + sizeof(ulong)) * f)
                {
                    sfre++;
                    _rlist.Add(pair.Key);
                }
            }

            foreach (var key in _rlist)
                _dict.Remove(key);

            return sfre;
        }

        /// <summary>
        /// Codes this integer using Elias Gamma coding.
        /// <para>!!!The integer must be non-negative.</para>
        /// </summary>
        /// <param name="num">The integer to be coded.</param>
        /// <returns>A Elias Gamma code representing the original integer.</returns>
        public static BitCode64 ToGammaCode(this int num)
        {
            if (num < 0)
                throw new ArgumentException(IOResources.ERR_EliasCode_OnlyNonNegativeIntegerAllowed);
            num++;
            int l = (int)Math.Floor(Math.Log(num, 2));
            var l2 = l + l;
            UInt64 code = (UInt64)num;
            code <<= 63 - l2;
            return new BitCode64(code, l2 + 1, true);
        }

        public static int ReadGammaCode(this BitCode64 code)
        {
            int l2 = code.Length - 1;
            if (code.High)
                return (int)(code.Code >> (63 - l2)) - 1;
            else
                return (int)code.Code - 1;
        }

        /// <summary>
        /// Reads a non-negative integer coded by Elias Gamma coding from this bit stream.
        /// </summary>
        /// <param name="stream">This bit stream.</param>
        /// <returns>A non-negative integer.</returns>
        public static int ReadGammaCode(this IBitStream stream)
        {
            int numberBits = 0;
            while (!stream.ReadBit())
                numberBits++;

            if (numberBits == 0) return 0;

            int current = 1 << numberBits;
            for (int a = numberBits - 1; a >= 0; a--)
            {
                if (stream.ReadBit())
                    current |= 1 << a;
            }
            return current - 1;
        }

        public static void WriteGammaCode(this BitStream stream, int num)
        {
            stream.WriteCode(num.ToGammaCode());
        }

        /// <summary>
        /// Codes this integer using Elias Delta coding.
        /// <para>!!!The integer must be non-negative.</para>
        /// </summary>
        /// <param name="num">The integer to be coded.</param>
        /// <returns>A Elias Delta code representing the original integer.</returns>
        public static BitCode64 ToDeltaCode(this int num)
        {
            if (num < 0)
                throw new ArgumentException(IOResources.ERR_EliasCode_OnlyNonNegativeIntegerAllowed);

            if (num == 0) return new BitCode64(0x8000000000000000, 1);
            else num++;
            int l = (int)Math.Floor(Math.Log(num, 2)) + 1;
            int ll = (int)Math.Floor(Math.Log(l, 2));
            var codeh = (UInt64)(((UInt64)l) << (63 - ll - ll));
            var codel = (UInt64)((((UInt64)num) << (64 - l + 1)) >> (ll + ll + 1));
            return new BitCode64(codeh | codel, ll + ll + l, true);
        }

        public static int ReadDeltaCode(this BitCode64 code)
        {
            int ll = 0;
            int i = 63;
            UInt64 ucode;
            if (code.High)
                ucode = code.Code;
            else
                ucode = code.Code << 64 - code.Length;

            if (ucode == 0x8000000000000000) return 0;

            while (!ucode.GetBit(i--))
                ll++;
            int l = code.Length - 1 - ll - ll;
            ll += ll;
            int high = ((int)(ucode >> (63 - ll))) - 1;
            int v = 2;
            while (--high > 0)
                v += v;
            int low = (int)((ucode << (ll + 1)) >> (64 - l));
            return v + low - 1;
        }

        public static int ReadDeltaCode(this IBitStream stream)
        {
            int num = 1;
            int len = 1;
            int lengthOfLen = 0;
            while (!stream.ReadBit())     // potentially dangerous with malformed files.
                lengthOfLen++;

            if (lengthOfLen == 0) return 0;
            
            for (int i = 0; i < lengthOfLen; i++)
            {
                len <<= 1;
                if (stream.ReadBit())
                    len |= 1;
            }
            for (int i = 0; i < len - 1; i++)
            {
                num <<= 1;
                if (stream.ReadBit())
                    num |= 1;
            }
            return num - 1;            // write out the value
        }

        public static void WriteDeltaCode(this BitStream stream, int num)
        {
            stream.WriteCode(num.ToDeltaCode());
        }

        public static Dictionary<T, BitCode64> GenerateGammaCoding<T>(this IEnumerator<T> enumerator, 
           T encodingSwitch, out int count, int predictCount = 0)
        {
            var _dict = GenerateFrequencyDictionary(enumerator, out count, predictCount);
            int sfre = _switchProcess<T>(_dict);

            var sortedFrequency = _dict.OrderBy(n => n.Value);
            var dict2 = new Dictionary<T, BitCode64>(sortedFrequency.Count());

            int num = 0;
            int sfreProcessed = 0;
            T key;
            foreach (var pair in sortedFrequency)
            {
                if (sfreProcessed == 0 && sfre > pair.Value)
                {
                    key = encodingSwitch;
                    sfreProcessed = 1;
                }
                else key = pair.Key;
            begin:
                int l = (int)Math.Floor(Math.Log(num));
                UInt64 code = 0;
                for (int a = 0; a <= l; a++)
                    code.SetBit(63 - a, false); //put 0s to indicate how many bits will follow
                code.SetBit(62 - l, true);      //mark the end of the 0s
                for (int a = l - 1, i = 61 - l; a >= 0; a--, i--) //Write the bits as plain binary
                {
                    if ((code & (ulong)1 << a) > 0)
                        code.SetBit(i, true);
                    else
                        code.SetBit(i, false);
                }
                dict2.Add(key, new BitCode64(code, 2 * l + 1, true));
                num++;

                if (sfreProcessed == 1)
                {
                    key = pair.Key;
                    sfreProcessed = 2;
                    goto begin;
                }
            }

            return dict2;
        }

        public static Dictionary<T, BitCode64> GenerateDeltaCoding<T>(this IEnumerator<T> enumerator,  T encodingSwitch, 
            out int count, int predictCount = 0)
        {
            var _dict = GenerateFrequencyDictionary(enumerator, out count, predictCount);
            int sfre = _switchProcess<T>(_dict);

            var sortedFrequency = _dict.OrderBy(n => n.Value);
            var dict2 = new Dictionary<T, BitCode64>(sortedFrequency.Count());

            int num = 0;
            int sfreProcessed = 0;
            T key;
            foreach (var pair in sortedFrequency)
            {
                if (sfreProcessed == 0 && sfre > pair.Value)
                {
                    key = encodingSwitch;
                    sfreProcessed = 1;
                }
                else key = pair.Key;

            begin:
                int len = 0;
                int lengthOfLen = 0;
                UInt64 code = 0;
                for (int temp = num; temp > 0; temp >>= 1)  // calculate 1+floor(log2(num))
                    len++;
                for (int temp = len; temp > 1; temp >>= 1)  // calculate floor(log2(len))
                    lengthOfLen++;

                int j = sizeof(int);
                for (int i = lengthOfLen; i > 0; --i)
                    code.SetBit(--j, false);
                for (int i = lengthOfLen; i >= 0; --i)
                    code.SetBit(--j, Convert.ToBoolean(((len >> i) & 1)));
                for (int i = len - 2; i >= 0; i--)
                    code.SetBit(--j, Convert.ToBoolean((num >> i) & 1));

                dict2.Add(key, new BitCode64(code, sizeof(int) - j, true));

                num++;

                if (sfreProcessed == 1)
                {
                    key = pair.Key;
                    sfreProcessed = 2;
                    goto begin;
                }
            }

            return dict2;
        }

        static int _estimateSize(object obj)
        {
            var type = obj.GetType();
            if (type == typeof(SubString))
                return (obj as SubString).Length;
            else if (type == typeof(string))
            {
                var str = obj as string;
                var len = str.OnlyASCIIs() ? str.Length : str.Length * 2;
                return len;
            }
            else
                return System.Runtime.InteropServices.Marshal.SizeOf(obj.GetType());
        }

        public static Dictionary<T, BitCode64> GenerateHuffmanCoding<T>(this IEnumerator<T> enumerator, 
            T encodingSwitch, 
            out BinaryTree<T> decodeTree, 
            out int count, 
            int predictCount = 0)
        {
            Dictionary<T, BitCode64> frequency;
            if (predictCount == 0)
                frequency = new Dictionary<T, BitCode64>();
            else frequency = new Dictionary<T, BitCode64>(predictCount);

            count = 0;
            while (enumerator.MoveNext())
            {
                count++;
                if (frequency.ContainsKey(enumerator.Current))
                    frequency[enumerator.Current].Code++;
                else
                    frequency.Add(enumerator.Current, new BitCode64(1, 0));
            }


            var mslist = new MSortedDictionary<ulong, BinaryTree<T>>();
            var templist = new BinaryTree<T>[frequency.Count];
            int tempListLen = 0;
            ulong sfre = 0;
            List<T> rlist = new List<T>();
            foreach (var pair in frequency)
            {
                var f = (int)pair.Value.Code;
                var key = pair.Key;
                int len = _estimateSize(key);
                var str = key as string;

                int clen = len + sizeof(uint) * (f + 1);
                if (clen >= (len + sizeof(uint)) * f)
                {
                    sfre++;
                    rlist.Add(pair.Key);
                }
                else
                {
                    var t = new BinaryTree<T>() { Value = pair.Key };
                    templist[tempListLen++] = t;
                    mslist.Add(pair.Value.Code, t);
                }
            }

            foreach (var key in rlist)
                frequency.Remove(key);

            var st = new BinaryTree<T>() { Value = encodingSwitch };
            templist[tempListLen++] = st;
            mslist.Add(sfre, st);
            frequency.Add(encodingSwitch, new BitCode64(sfre, 0));

            ulong lkey, rkey;
            BinaryTree<T> root = null;
            while (mslist.Count > 1)
            {
                var left = mslist.PickMinimum(out lkey);
                var right = mslist.PickMinimum(out rkey);
                root = new BinaryTree<T>();
               
                root.LeftChild = left;
                root.RightChild = right;

                mslist.Add(rkey + lkey, root);
            }

            for(int i = 0; i < tempListLen ;i++)
            {
                var pair = templist[i];
                ulong code = 0;
                int len = 0;
                var curr = pair;
                
                while (curr.Parent != null)
                {
                    if ((BinaryTree<T>)((BinaryTree<T>)curr.Parent).RightChild == curr)
                        code = code.SetBit(len, true);
                    len++;
                    curr = (BinaryTree<T>)curr.Parent;
                }
                var c64 = frequency[pair.Value];
                c64.Code = code;
                c64.Length = len;
            }

            decodeTree = root;
            return frequency;
        }

        public static T ReadHuffmanCode<T>(this IBitStream stream, BinaryTree<T> decodingTree)
        {
            while (true)
            {
                var b = stream.ReadBit();
                if (b)
                    decodingTree = (BinaryTree<T>)decodingTree.RightChild;
                else
                    decodingTree = (BinaryTree<T>)decodingTree.LeftChild;

                if (decodingTree.LeftChild == null && decodingTree.RightChild == null)
                    return decodingTree.Value;
            }
        }

        //public static IEnumerator<T> DecodeHuffmanCoding<T>(this IBitStream stream)
        //{
        //}

        public static void WriteBits(this IBitStream stream, byte[] value, int length, bool high = true)
        {
            if (length < 1 || length > value.Length * 8)
                throw new ArgumentException();

            int remain = length % 8;
            int count = (int)((length - remain) / 8);

            if (high)
            {
                if (count > 0)
                    stream.Write(value, 0, count);

                if (remain > 0)
                    stream.WriteBits(value[count], remain, true);
            }
            else
            {
                if (remain > 0)
                    stream.WriteBits(value[value.Length - 1 - count], remain, false);

                if (count > 0)
                    stream.Write(value, value.Length - count, count);
            }
        }

        public static unsafe void WriteBits(this IBitStream stream, params bool[] value)
        {
            var remain = value.Length % 8;
            var count = (value.Length - remain) / 8;
            var bytes = new byte[count + 1];

            int idx;
            byte b;
            byte* bp = &b;

            for (int i = 0; i < count; i++)
            {
                b = 0;
                idx = i * 8;

                BitOperations.SetBit(bp, 7, value[idx + 0]);
                BitOperations.SetBit(bp, 6, value[idx + 1]);
                BitOperations.SetBit(bp, 5, value[idx + 2]);
                BitOperations.SetBit(bp, 4, value[idx + 3]);
                BitOperations.SetBit(bp, 3, value[idx + 4]);
                BitOperations.SetBit(bp, 2, value[idx + 5]);
                BitOperations.SetBit(bp, 1, value[idx + 6]);
                BitOperations.SetBit(bp, 0, value[idx + 7]);
                bytes[i] = b;
            }

            idx = count * 8;
            b = 0;
            for (int i = 0; i < remain; i++)
                BitOperations.SetBit(bp, 7 - i, value[idx + i]);
            bytes[count] = b;

            if (count > 0)
                stream.Write(bytes, 0, count);

            if (remain > 0)
                stream.WriteBits(bytes[count], remain, true);
        }

        public static unsafe void Write(this IBitStream stream, byte* buffer, int offset, int count)
        {
            var array = new byte[count];
            for (int i = 0, j = offset; i < count; i++, j++)
                array[i] = buffer[offset];
            stream.Write(array, 0, count);
        }

        public static unsafe void WriteBits(this IBitStream stream, byte* value, int byteCount, int bitLength, bool high = true)
        {
            if (bitLength < 1)
                throw new ArgumentException();

            int remain = bitLength % 8;
            int count = (int)((bitLength - remain) / 8);

            if (high)
            {
                if (count > 0)
                    stream.Write(value, 0, count);

                if (remain > 0)
                    stream.WriteBits(value[count], remain, true);
            }
            else
            {
                if (remain > 0)
                    stream.WriteBits(value[byteCount - 1 - count], remain, false);

                if (count > 0)
                    stream.Write(value, byteCount - count, count);
            }
        }

        public static unsafe void WriteBits(this IBitStream stream, uint value, int length, bool high = false)
        {
            var tlen = sizeof(uint) * 8;
            if (length < 1 || length > tlen)
                throw new ArgumentException();

            if (high)
                value = value >> (tlen - length);

            stream.WriteBits((byte*)(&value), sizeof(uint), length, false);
        }

        public static unsafe void WriteBits(this IBitStream stream, ulong value, int length, bool high = false)
        {
            var tlen = sizeof(ulong) * 8;
            if (length < 1 || length > tlen)
                throw new ArgumentException();

            var remain = length % 8;
            var count = (length - remain) / 8;

            if (!high)
                value = value << (tlen - length);

            var ptr = (byte*)(&value);

            if(count == 0)
                stream.WriteBits(ptr[sizeof(ulong) - 1], length, true);
            else
            {
                var bytes = new byte[count + 1];
                for(int i = 0;i <= count;i++)
                    bytes[i] = ptr[sizeof(ulong) -1 - i];
                stream.WriteBits(bytes, length, true);
            }

        }

        public static void WriteBits(this IBitStream stream, BitCode64 code)
        {
            stream.WriteBits(code.Code, code.Length, code.High);
        }

        public static unsafe void WriteBits(this IBitStream stream, ushort value, int length, bool high = false)
        {
            var tlen = sizeof(ushort) * 8;
            if (length < 1 || length > tlen)
                throw new ArgumentException();

            if (high)
                value = (ushort)(value >> (tlen - length));

            stream.WriteBits((byte*)(&value), sizeof(ushort), length, false);
        }

        public static void WriteCode(this IBitStream stream, BitCode64 code)
        {
            stream.WriteBits(code.Code, code.Length, code.High);
        }
    }

    public class ForwardBitStream : Stream, IBitStream
    {
        Stream _baseStream;
        int _bitPosition;
        long _origin;
        byte _temp;
        bool _read;

        public ForwardBitStream(Stream baseStream, bool forRead)
        {
            _baseStream = baseStream;
            _read = forRead;
            _origin = baseStream.Position;   
        }

        public void Reset(bool forRead)
        {
            if (_baseStream.CanSeek)
            {
                if (!_read) Flush();
                _read = forRead;
                _bitPosition = 0;
                _baseStream.SeekTo(_origin);
            }
            else
                throw new InvalidOperationException();
        }

        public void Reset()
        {
            if (_baseStream.CanSeek)
            {
                if (!_read) Flush();
                _bitPosition = 0;
                _baseStream.SeekTo(_origin);
            }
            else
                throw new InvalidOperationException();
        }

        public override bool CanRead
        {
            get { return _baseStream.CanRead; }
        }

        public override bool CanSeek
        {
            get { return false; }
        }

        public override bool CanWrite
        {
            get { return _baseStream.CanWrite; }
        }

        public override void Flush()
        {
            if (_read)
                throw new InvalidOperationException();

            if (_bitPosition > 0)
            {
                if (_baseStream.Position != _baseStream.Length)
                {
                    _temp = _temp.SetBitsAtRight(8 - _bitPosition, (byte)_baseStream.ReadByte());
                    _baseStream.BackByte();
                }
                _baseStream.WriteByte(_temp);
            }
        }

        public override long Length
        {
            get { throw new InvalidOperationException(); }
        }

        public override long Position
        {
            get
            {
                if (_read)
                    if (_bitPosition > 0)
                        return (_baseStream.Position - _origin - 1) * 8 + _bitPosition;
                    else
                        return (_baseStream.Position - _origin) * 8;
                else
                    return (_baseStream.Position - _origin) * 8 + _bitPosition;
            }
            set
            {
                throw new InvalidOperationException();
            }
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new InvalidOperationException();
        }

        public override void SetLength(long value)
        {
            _baseStream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            if (_read)
                throw new InvalidOperationException();

            if (_bitPosition == 0)
                _baseStream.Write(buffer, offset, count);
            else
            {
                byte value;
                var tBuffer = new byte[count];
                var capacity = 8 - _bitPosition;
                for (int i = offset, j = offset + count; i < j; i++)
                {
                    value = buffer[i];
                    _temp = _temp.SetBitsAtRight(capacity, value, true);
                    tBuffer[i - offset] = _temp;
                    _temp = (byte)(value << capacity);
                }
                _baseStream.Write(tBuffer, 0, count);
            }
        }

        public override void WriteByte(byte value)
        {
            if (_read)
                throw new InvalidOperationException();

            if (_bitPosition == 0)
                _baseStream.WriteByte(value);
            else
            {
                var capacity = 8 - _bitPosition;
                _baseStream.WriteByte(_temp.SetBitsAtRight(capacity, value, true));
                _temp = ((byte)(value << capacity));
            }
        }

        public void WriteBits(byte value, int length, bool high = false)
        {
            if (_read)
                throw new InvalidOperationException();

            if (length < 1 || length > 8)
                throw new ArgumentException();

            if (length == 8)
                WriteByte(value);
            else
            {
                var capacity = 8 - _bitPosition;
                var margin = capacity - length;
                if (margin > 0)
                {
                    _temp = _temp.SetBits(_bitPosition, length, value, high);
                    _bitPosition += length;
                }
                else if (length == capacity)
                {
                    _baseStream.WriteByte(_temp.SetBitsAtRight(capacity, value, high));
                    _temp = 0;
                    _bitPosition = 0;
                }
                else
                {
                    _baseStream.WriteByte(_temp.SetBitsAtRight(capacity, value, high));
                    _bitPosition = -margin;

                    if (high) value = (byte)(value << capacity);
                    else value = (byte)(value >> capacity);
                    _temp = (byte)(((byte)0).SetBitsAtLeft(8 - capacity, value, high));
                }
            }

        }

        public void WriteBit(bool value)
        {
            _temp = _temp.SetBit(7 - _bitPosition, value);
            _bitPosition++;

            if (_bitPosition == 8)
            {
                _baseStream.WriteByte(_temp);
                _temp = 0;
                _bitPosition = 0;
            }
        }

        public bool ReadBit()
        {
            if (!_read)
                throw new InvalidOperationException();

            if (_baseStream.Position == _baseStream.Length && _bitPosition == 0)
                throw new InvalidOperationException();
            else
            {
                if (_bitPosition == 0)
                    _temp = (byte)_baseStream.ReadByte();

                var value = _temp.GetBit(7 - _bitPosition);
                _bitPosition++;

                if (_bitPosition == 8)
                    _bitPosition = 0;
                return value;
            }
        }

        public byte[] ReadBits(int length)
        {
            if (!_read)
                throw new InvalidOperationException();

            if (length > (_baseStream.Length - _baseStream.Position) * 8 + 8 - _bitPosition) 
                throw new ArgumentException();

            var remain = length % 8;
            var c = (length - remain) / 8;
            byte[] rlt;
            if (remain == 0)
            {
                rlt = new byte[c];
                Read(rlt, 0, c);
            }
            else
            {
                rlt = new byte[c + 1];
                if (c > 0)
                    Read(rlt, 0, c);

                var capacity = 8 - _bitPosition;
                var margin = capacity - remain;
                if (margin > 0)
                {
                    if (_bitPosition == 0)
                        _temp = (byte)_baseStream.ReadByte();

                    rlt[c] = (byte)((byte)(_temp >> margin) << (margin + _bitPosition));
                    _bitPosition = 8 - margin;
                }
                else if (margin == 0)
                {
                    rlt[c] = (byte)(_temp << _bitPosition);
                    _bitPosition = 0;
                }
                else
                {
                    var v = (byte)(_temp << _bitPosition);
                    _temp = (byte)_baseStream.ReadByte();
                    _bitPosition = -margin;
                    rlt[c] = (byte)(v | (byte)(_temp >> (8 + margin)) << (8 + margin - capacity));
                }
            }
            return rlt;
        }

        public override int ReadByte()
        {
            if (!_read)
                throw new InvalidOperationException();
            byte v;
            if (_bitPosition == 0)
                v  = (byte)_baseStream.ReadByte();
            else
            {
                v = (byte)_baseStream.ReadByte();
                var v2 = ((byte)(_temp << _bitPosition)).SetBitsAtRight(_bitPosition, v, true);
                _temp = v;
                return v2;
            }
            return v;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (buffer.Length  - offset < count || 
                (_baseStream.Length - _baseStream.Position) * 8 + 8 - _bitPosition < count * 8) 
                throw new ArgumentException();

            if (_bitPosition == 0)
                _baseStream.Read(buffer, offset, count);
            else
            {
                for (int i = offset, j = offset + count; i < j; i++)
                {
                    var v = _baseStream.ReadByte();
                    buffer[i] = (byte)((_temp << _bitPosition) | (v >> (8 - _bitPosition)));
                    _temp = (byte)v;
                }
            }
            return count;
        }
    }

    public class BitStream : Stream, IBitStream
    {
        Stream _baseStream;
        int _bitPosition;
        int _bitLength;
        long _origin;
        long _end;
        bool _changed;

        public BitStream(Stream baseStream, bool createNew)
        {
            _baseStream = baseStream;

            if (_baseStream.Position == _baseStream.Length || createNew)
            {
                _temp = 0;
                _bitLength = 0;
                _baseStream.WriteByte(0);
                _baseStream.WriteInt64(_baseStream.Position + 8);
                _end = _origin = _baseStream.Position;
            }
            else
            {
                _bitLength = (byte)_baseStream.ReadByte();
                _end = _baseStream.ReadInt64();

                if (_end == _baseStream.Position)
                    _temp = 0;
                else if (_end > _baseStream.Position)
                {
                    _temp = (byte)_baseStream.ReadByte();
                    _baseStream.BackByte();
                }
                else
                    throw new InvalidDataException();

                _origin = _baseStream.Position;
            }
            _bitPosition = 0;
            _changed = false;
        }

        public override bool CanRead
        {
            get { return _baseStream.CanRead; }
        }

        public override bool CanSeek
        {
            get { return _baseStream.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return _baseStream.CanWrite; }
        }

        public override void Flush()
        {
            var npos = _baseStream.Position;
            _baseStream.SeekTo(_origin - 9);
            _baseStream.WriteByte((byte)_bitLength);
            _baseStream.WriteInt64(_end);
            _baseStream.SeekTo(npos);

            if ((_baseStream.Length == _baseStream.Position && _bitLength > 0) || _bitPosition > 0)
            {
                _baseStream.WriteByte(_temp);
                _baseStream.BackByte();
            }

            _baseStream.Flush();
        }

        public override void Close()
        {
            Flush();
        }

        public override long Length
        {
            get { return (_end - _origin) * 8 + _bitLength; }
        }

        public override long Position
        {
            get
            {
                return (_baseStream.Position - _origin) * 8 + _bitPosition;
            }
            set
            {
                Seek(value, SeekOrigin.Begin);
            }
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            long seek;
            int t;
            if (origin == SeekOrigin.End)
            {
                t = 8 - (int)(offset % 8);
                seek = _end - ((offset + t) / 8);
            }
            else if (origin == SeekOrigin.Begin)
            {
                t = (int)(offset % 8);
                seek = _origin + (offset - t) / 8;
            }
            else
            {
                if (offset >= 0)
                {
                    t = (int)(offset % 8);
                    seek = _baseStream.Position + (offset - t) / 8;
                }
                else
                {
                    offset = -offset;
                    t = 8 - (int)(offset % 8);
                    seek = _baseStream.Position - ((offset + t) / 8);
                }
            }

            if (seek < _origin || seek > _end || (seek == _end && t > _bitLength))
                throw new InvalidOperationException();

            if (_changed)
            {
                _baseStream.WriteByte(_temp);
                _changed = false;
            }

            _baseStream.SeekTo(seek);

            if (seek != _end || _bitLength > 0)
            {
                _temp = (byte)_baseStream.ReadByte();
                _baseStream.BackByte();
            }
            else _temp = 0;

            _bitPosition = t;
            return Position;
        }

        public override void SetLength(long value)
        {
            _baseStream.SetLength(value);
        }

        byte _temp;

        public override int ReadByte()
        {
            var remain = (_end - _baseStream.Position) * 8 - _bitPosition + _bitLength;
            if (remain < 8) throw new InvalidOperationException();

            byte v;
            if (_bitPosition == 0)
            {
                v = _temp;
                if (_changed)
                {
                    _baseStream.WriteByte(_temp);
                    _changed = false;
                }
                else
                    _baseStream.SkipByte();
                if (_bitLength > 0 || _baseStream.Position < _end)
                {
                    _temp = (byte)_baseStream.ReadByte();
                    _baseStream.BackByte();
                }
                else _temp = 0;
            }
            else
            {
                v = _temp;
                if (_changed)
                {
                    _baseStream.WriteByte(v);
                    _changed = false;
                }
                else
                    _baseStream.SkipByte();
                _temp = (byte)_baseStream.ReadByte();
                _baseStream.BackByte();
                v = (byte)((v << _bitPosition) | (_temp >> (8 - _bitPosition)));
            }
            _changed = false;
            return v;
        } //direct reading method

        public override int Read(byte[] buffer, int offset, int count)
        {
            var remain = (_end - _baseStream.Position) * 8 - _bitPosition + _bitLength;
            if (remain < count * 8) throw new InvalidOperationException();

            if (_bitPosition == 0)
            {
                if (_changed)
                {
                    _baseStream.WriteByte(_temp);
                    _baseStream.BackByte();
                    _changed = false;
                }
                _baseStream.Read(buffer, offset, count);
                if (_bitLength > 0 || _baseStream.Position < _end)
                {
                    _temp = (byte)_baseStream.ReadByte();
                    _baseStream.BackByte();
                }
                else _temp = 0;
            }
            else
            {
                if (_changed)
                {
                    _baseStream.WriteByte(_temp);
                    _changed = false;
                }
                else
                    _baseStream.SkipByte();
                for (int i = offset, j = offset + count; i < j; i++)
                {
                    var v = _baseStream.ReadByte();
                    buffer[i] = (byte)((_temp << _bitPosition) | (v >> (8 - _bitPosition)));
                    _temp = (byte)v;
                }
                _baseStream.BackByte();
            }

            return count;
        } //direct reading method

        public bool ReadBit()
        {
            if (_baseStream.Position == _end && _bitLength == _bitPosition)
                throw new InvalidOperationException();
            else
            {
                var value = _temp.GetBit(7 - _bitPosition);
                _bitPosition++;

                if (_bitPosition == 8)
                {
                    _bitPosition = 0;
                    if (_changed)
                    {
                        _baseStream.WriteByte(_temp);
                        _changed = false;
                    }
                    else
                        _baseStream.SkipByte();

                    if (_baseStream.Position - 1 == _end)
                    {
                        _temp = 0;
                        _bitLength = 0;
                        _end++;
                    }
                    else
                    {
                        _temp = (byte)_baseStream.ReadByte();
                        _baseStream.BackByte();
                    }
                }

                return value;
            }
        } //direct reading method

        public byte[] ReadBits(int count)
        {
            if (count > (_bitLength - _bitPosition + (_end - _baseStream.Position) * 8))
                throw new InvalidOperationException();
            var remain = count % 8;
            var c = (count - remain) / 8;
            byte[] rlt;
            if (remain == 0)
            {
                rlt = new byte[c];
                Read(rlt, 0, c);
            }
            else
            {
                rlt = new byte[c + 1];
                if (c > 0)
                    Read(rlt, 0, c);

                var capacity = 8 - _bitPosition;
                var margin = capacity - remain;
                if (margin > 0)
                {
                    rlt[c] = (byte)((byte)(_temp >> margin) << (margin + _bitPosition));
                    _bitPosition = 8 - margin;
                }
                else if (margin == 0)
                {
                    rlt[c] = (byte)(_temp << _bitPosition);
                    _bitPosition = 0;
                    if (_changed)
                    {
                        _baseStream.WriteByte(_temp);
                        _changed = false;
                    }
                    else
                        _baseStream.SkipByte();
                    _temp = (byte)_baseStream.ReadByte();
                    _baseStream.BackByte();
                }
                else
                {
                    var v = (byte)(_temp << _bitPosition);
                    if (_changed)
                    {
                        _baseStream.WriteByte(_temp);
                        _changed = false;
                    }
                    else
                        _baseStream.SkipByte();
                    _temp = (byte)_baseStream.ReadByte();
                    _baseStream.BackByte();

                    _bitPosition = -margin;
                    rlt[c] = (byte)(v | (byte)(_temp >> (8 + margin)) << (8 + margin - capacity));
                }
            }
            return rlt;
        } //direct reading method

        public override void WriteByte(byte value)
        {
            //executes writing first, so even if the writing fails, no critical information will change
            if (_bitPosition == 0)
            {
                _baseStream.WriteByte(value);
                if (_baseStream.Position <= _end)
                {
                    _temp = (byte)_baseStream.ReadByte();
                    _baseStream.BackByte();
                }
                else
                {
                    _end++;
                    _bitLength = 0;
                    _temp = 0;
                }
                _changed = false;
            }
            else
            {
                var capacity = 8 - _bitPosition;
                var t = _temp.SetBitsAtRight(capacity, value, true);
                _baseStream.WriteByte(t);

                if (_baseStream.Position - 1 == _end)
                {
                    _end++;
                    _temp = (byte)(value << capacity);
                    _bitLength = _bitPosition;
                }
                else
                {
                    _temp = ((byte)_baseStream.ReadByte()).SetBitsAtLeft(_bitPosition, value);
                    _baseStream.BackByte();
                }
                _changed = true;
            }
        } //direct writing method

        public override void Write(byte[] buffer, int offset, int count)
        {
            var capacity = 8 - _bitPosition;

            var tBuffer = new byte[count];

            if (_bitPosition > 0)
            {
                byte value1;
                for (int i = offset, j = offset + count; i < j; i++)
                {
                    value1 = buffer[i];
                    _temp = _temp.SetBitsAtRight(capacity, value1, true);
                    tBuffer[i - offset] = _temp;
                    _temp = (byte)(value1 << capacity);
                }
                _baseStream.Write(tBuffer, 0, count);

                if (_baseStream.Position <= _end)
                {
                    _temp = ((byte)_baseStream.ReadByte()).SetBitsAtLeft(_bitPosition, _temp, true);
                    _baseStream.BackByte();
                    if (_baseStream.Position == _end && _bitLength < _bitPosition)
                        _bitLength = _bitPosition;
                }
                else
                {
                    _end = _baseStream.Position;
                    _bitLength = _bitPosition;
                }
                _changed = true;
            }
            else
            {
                _baseStream.Write(buffer, offset, count);
                if (_baseStream.Position <= _end)
                {
                    _temp = (byte)_baseStream.ReadByte();
                    _baseStream.BackByte();
                }
                else
                {
                    _temp = 0;
                    _bitLength = 0;
                    _end = _baseStream.Position;
                }
                _changed = false;
            }
        } //direct writing method

        public unsafe void WriteBit(bool value)
        {
            _temp = _temp.SetBit(7 - _bitPosition, value);
            _bitPosition++;

            if (_bitPosition == 8)
            {
                _baseStream.WriteByte(_temp);
                if (_baseStream.Position > _end)
                {
                    _end++;
                    _bitLength = 0;
                }
                _temp = 0;
                _bitPosition = 0;
                _changed = false;
            }
            else
            {
                _changed = true;
                if (_baseStream.Position == _end && _bitPosition > _bitLength)
                    _bitLength = _bitPosition;
            }
        } //direct writing method

        public void WriteBits(byte value, int length, bool high = false)
        {
            if (length < 1 || length > 8)
                throw new ArgumentException();

            if (length == 8)
                WriteByte(value);
            else
            {
                var capacity = 8 - _bitPosition;
                var margin = capacity - length;
                if (margin > 0)
                {
                    _temp = _temp.SetBits(_bitPosition, length, value, high);
                    _bitPosition += length;
                    if (_baseStream.Position == _end && _bitPosition > _bitLength)
                        _bitLength = _bitPosition;
                    _changed = true;
                }
                else if (length == capacity)
                {
                    _baseStream.WriteByte(_temp.SetBitsAtRight(capacity, value, high));
                    if (_baseStream.Position > _end)
                    {
                        _end++;
                        _bitLength = 0;
                    }
                    _temp = 0;
                    _bitPosition = 0;
                    _changed = false;
                }
                else
                {
                    _baseStream.WriteByte(_temp.SetBitsAtRight(capacity, value, high));
                    _bitPosition = -margin;

                    if (high) value = (byte)(value << capacity);
                    else value = (byte)(value >> capacity);

                    if (_baseStream.Position > _end)
                    {
                        _end = _baseStream.Position;
                        _bitLength = _bitPosition;
                        _temp = (byte)(((byte)0).SetBitsAtLeft(8 - capacity, value, high));
                    }
                    else
                    {
                        _temp = ((byte)_baseStream.ReadByte()).SetBitsAtLeft(8 - capacity, value, high);
                        _baseStream.BackByte();
                        if (_baseStream.Position == _end && _bitPosition > _bitLength)
                            _bitLength = _bitPosition;
                    }
                    _changed = true;
                }
            }
        } //direct writing method



        public void Reset()
        {
            this.SeekToBegin();
        }
    }

    
}
