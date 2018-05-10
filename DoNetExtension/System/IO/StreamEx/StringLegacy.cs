using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoNetExtension.System.IO;

namespace System.IO
{
    public static partial class StreamEx
    {
        #region IO Methods for String Objects

        #region private members

        private static Encoding _getCoder(byte id)
        {
            switch (id)
            {
                case 0x10: return Encoding.GetEncoding(437);
                case 0x20: return Encoding.UTF8;
                case 0x30: return Encoding.Unicode;
                default: return null;
            }
        }

        private static byte _getCP(Encoding coder)
        {
            switch (coder.CodePage)
            {
                case 20127: return 0x10;
                case 65001: return 0x20;
                case 1200: return 0x30;
                default: return 0x00;
            }
        }

        private static Encoding _bestEncoder(string str)
        {
            if (str == null) return null;

            bool b1 = false, b2 = false;
            foreach (char c in str)
            {
                if (c > 255) b2 = true;
                else b1 = true;
                if (b1 && b2) return Encoding.UTF8;
            }
            if (b1) return Encoding.GetEncoding(437);
            else return Encoding.Unicode;
        }

        private static Encoding _bestEncoder(string str, int startIndex, int length)
        {
            if (startIndex + length > str.Length)
                throw new ArgumentException();

            if (str == null) return null;

            bool b1 = false, b2 = false;
            for (int i = startIndex, j = startIndex + length; i < j; i++)
            {
                var c = str[i];
                if (c > 255) b2 = true;
                else b1 = true;
                if (b1 && b2) return Encoding.UTF8;
            }
            if (b1) return Encoding.ASCII;
            else return Encoding.Unicode;
        }

        private static string _srstring(this Stream stream, byte para)
        {
            var alg = (ByteCompressionMethods)para;
            UInt32 len = stream.ReadUInt32();
            Encoding coder = Encoding.GetEncoding(stream.ReadUInt16());
            return coder.GetString(IO.Compression.CompressionEx.DeCompress(stream.ReadBytes(Convert.ToInt32(len)), alg));
        }

        private static void _sfstring(this Stream stream)
        {
            UInt32 len = stream.ReadUInt32();
            stream.Seek(len + 2, SeekOrigin.Current);
        }

        #endregion

        /// <summary>
        /// Writes a string hash set to this stream. 
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="stringSet">The string hash set.</param>
        /// <param name="validityCheck">
        /// <c>true</c> if a code is written into the stream 
        /// and any reading method can check this code to determine whether the data is not corrupted.
        /// </param>
        public static void WriteStringHashSet(this Stream stream, HashSet<string> stringSet, bool validityCheck = true)
        {
            if (validityCheck)
                stream.WriteCheckCode(18);

            stream.WriteInt32((stringSet == null) ? 0 : stringSet.Count);
            foreach (var item in stringSet)
                stream.WriteString(item, false);
        }

        /// <summary>
        /// Writes a string dictionary to this stream. 
        /// </summary>
        /// <param name="stream">This stream.</param>
        /// <param name="dictionary">The string dictionary.</param>
        /// <param name="validityCheck">
        /// <c>true</c> if a code is written into the stream 
        /// and any reading method can check this code to determine whether the data is not corrupted.
        /// </param>
        public static void WriteStringDictionary(this Stream stream, IDictionary<string, string> dictionary, bool validityCheck = true)
        {
            if (validityCheck)
                stream.WriteCheckCode(IOChecks.StringList);

            stream.WriteInt32((dictionary == null) ? 0 : dictionary.Count);
            foreach (var item in dictionary)
            {
                stream.WriteString(item.Key, false);
                stream.WriteString(item.Value, false);
            }
        }

        /// <summary>
        /// Reads a string hash set from this stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck">
        /// <c>true</c> if a code is written into the stream 
        /// and any reading method can check this code to determine whether the data is not corrupted.
        /// </param>
        /// <returns>A string hash set read from the stream.</returns>
        public static HashSet<string> ReadStringHashSet(this Stream stream, bool validityCheck = true)
        {
            if (validityCheck)
                stream.Check((Int64)18);
            var count = stream.ReadInt32();
            if (count == 0) return null;
            var set = new HashSet<string>();
            while (count-- > 0)
                set.Add(stream.ReadString(false));
            return set;
        }

        /// <summary>
        /// Reads a string dictionary from this stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck">
        /// <c>true</c> if a code is written into the stream 
        /// and any reading method can check this code to determine whether the data is not corrupted.
        /// </param>
        /// <returns>A string dictionary read from the stream.</returns>
        public static Dictionary<string, string> ReadStringDictionary<T>(this Stream stream, bool validityCheck = true)
        {
            if (validityCheck)
                stream.Check(IOChecks.StringList);
            var count = stream.ReadInt32();
            if (count == 0) return null;
            var set = new Dictionary<string, string>();
            while (count-- > 0)
                set.Add(stream.ReadString(false), stream.ReadString(false));
            return set;
        }

        /// <summary>
        /// Reads string dictionary items from this stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="dictionary">A dictionary that stores dictionary items read from the stream.</param>
        /// <param name="validityCheck">
        /// <c>true</c> if a code is written into the stream 
        /// and any reading method can check this code to determine whether the data is not corrupted.
        /// </param>
        /// <returns>A string dictionary read from the stream.</returns>
        public static void ReadStringDictionary(this Stream stream, IDictionary<string, string> dictionary, bool validityCheck = true)
        {
            if (validityCheck)
                stream.Check(IOChecks.StringList);
            var count = stream.ReadInt32();
            if (count == 0) return;
            while (count-- > 0)
                dictionary.Add(stream.ReadString(false), stream.ReadString(false));
        }


        /// <summary>
        /// Writes a list of strings to this stream. 
        /// This method automatically chooses best character encoding and applies no compression.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="stringList">The string list.</param>
        /// <param name="validityCheck">
        /// <c>true</c> if a code is written into the stream 
        /// and any reading method can check this code to determine whether the data is not corrupted.
        /// </param>
        public static void WriteStringList(this Stream stream, IList<string> stringList, bool validityCheck = true)
        {
            if (validityCheck)
                stream.WriteCheckCode(IOChecks.StringList);

            var c = (stringList == null) ? 0 : stringList.Count;
            stream.WriteInt32(c);

            for (int i = 0; i < c; ++i)
                stream.WriteString(stringList[i], false);
        }

        /// <summary>
        /// Writes a list of strings to this stream. 
        /// This method automatically chooses best character encoding and applies no compression.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="stringList">The string list.</param>
        /// <param name="validityCheck">
        /// <c>true</c> if a code is written into the stream 
        /// and any reading method can check this code to determine whether the data is not corrupted.
        /// </param>
        public static void WriteStringList(this Stream stream, LinkedList<string> stringList, bool validityCheck = true)
        {
            if (validityCheck)
                stream.WriteCheckCode(IOChecks.StringList);

            var c = (stringList == null) ? 0 : stringList.Count;
            stream.WriteInt32(c);

            var firstNode = stringList.First;
            while (firstNode != null)
            {
                stream.WriteString(firstNode.Value, false);
                firstNode = firstNode.Next;
            }
        }

        /// <summary>
        /// Writes a consecutive section of a string list into this stream.
        /// </summary>
        /// <param name="stream">This stream.</param>
        /// <param name="stringList">The string list.</param>
        /// <param name="startIndex">Indicates the index of the first string in the list to be written into this stream.</param>
        /// <param name="length">Indicates how many strings should be written into the stream.</param>
        /// <param name="validityCheck">Indicates whether to write 
        /// a validity-check code before the string list.</param>
        public static void WriteStringList(this Stream stream, IList<string> stringList,
            int startIndex, int length, bool validityCheck = true)
        {
            if (validityCheck)
                stream.WriteCheckCode(IOChecks.StringList);

            if (length < 0) throw new ArgumentException();
            if (startIndex < 0) throw new ArgumentException();
            if (startIndex + length > stringList.Count) throw new ArgumentException();

            var c = (stringList == null) ? 0 : length;

            stream.WriteInt32(c);
            c += startIndex;
            for (int i = startIndex; i < c; i++)
                stream.WriteString(stringList[i], false);
        }

        /// <summary>
        /// Writes strings in a string list with indexes no smaller than the start index into this stream.
        /// </summary>
        /// <param name="stream">This stream.</param>
        /// <param name="stringList">The string list.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="validityCheck">Indicates whether to write 
        /// a validity-check code before the string list.</param>
        public static void WriteStringList(this Stream stream, IList<string> stringList,
            int startIndex, bool validityCheck = true)
        {
            WriteStringList(stream, stringList, startIndex, stringList.Count - startIndex, validityCheck);
        }

        /// <summary>
        /// Reads a list of strings from this stream.
        /// </summary>
        /// <param name="stream">This stream.</param>
        /// <param name="validityCheck">
        /// <c>true</c> if a code is written into the stream 
        /// and any reading method can check this code to determine whether the data is not corrupted.
        /// </param>
        /// <returns>A list of strings.</returns>
        public static string[] ReadStringList(this Stream stream, bool validityCheck = true)
        {
            return ReadStringListEnumerator(stream, validityCheck).ToArray();
        }

        public static IEnumerator<string> ReadStringListEnumerator(this Stream stream, bool validityCheck = true)
        {
            if (!validityCheck || stream.Check(IOChecks.StringList))
            {
                var stringCount = stream.ReadInt32();
                if (stringCount < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
                else if (stringCount != 0)
                {
                    for (int i = 0; i < stringCount; ++i)
                        yield return stream.ReadString(false);
                }
            }
            else
                throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
        }


        public unsafe static void WriteString(this Stream stream, string str, int startIndex, int length,
            Encoding encoder = null,
            ByteCompressionMethods compressionMethod = ByteCompressionMethods.None,
            bool metaCompression = false,
            bool validityCheck = true)
        {
            if (startIndex + length > str.Length)
                throw new ArgumentException();

            if (validityCheck)
                stream.WriteCheckCode((Int64)17);

            if (str.IsNullOrEmpty())
            {
                stream.WriteByte(byte.MaxValue);
                return;
            }

            if (encoder == null)
                encoder = _bestEncoder(str, startIndex, length);

            fixed (char* sptr = str)
            {
                char* sptr2 = startIndex + sptr;
                var bcount = encoder.GetByteCount(sptr2, length);
                var b = new byte[bcount];
                fixed (byte* bptr = b)
                    encoder.GetBytes(sptr2, length, bptr, bcount);

                b = b.Compress(ref compressionMethod);
                byte para = (byte)compressionMethod;

                if (metaCompression)
                {
                    byte cp = _getCP(encoder);

                    if (b.Length <= byte.MaxValue)
                    {
                        stream.WriteByte((byte)(para.SetBitOneAt6() | cp));
                        stream.WriteByte((byte)b.Length);
                    }
                    else if (b.Length <= UInt16.MaxValue)
                    {
                        stream.WriteByte((byte)(para.SetBitOneAt7() | cp));
                        stream.WriteUInt16((UInt16)b.Length);
                    }
                    else if (b.Length <= Int32.MaxValue)
                    {
                        stream.WriteByte((byte)(para | cp));
                        stream.WriteUInt32((UInt32)b.Length);
                    }
                    else
                        throw (new ArgumentException(IOResources.ERR_Text4GLimit));

                    if (cp == 0x00)
                        stream.WriteUInt16((UInt16)encoder.CodePage);
                }
                else if (b.Length <= Int32.MaxValue)
                {
                    stream.WriteByte(para);
                    stream.WriteUInt32((UInt32)b.Length);
                    stream.WriteUInt16((UInt16)encoder.CodePage);
                }
                else
                    throw (new ArgumentException(IOResources.ERR_Text4GLimit));

                stream.WriteBytes(b);
            }
        }

        /// <summary>
        /// Writes a string instance to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="str">The System.String object.</param>
        /// <param name="encoder">The character encoding for the string.</param>
        /// <param name="compressionMethod">The compression algorithm used to compress the string.</param>
        /// <param name="headCompression">Indicates whether to compress the head section.</param>
        /// <param name="validityCheck">Indicates whether to write 
        /// a validity-check code before the string.</param>
        public static void WriteString(this Stream stream, string str,
            Encoding encoder = null,
            ByteCompressionMethods compressionMethod = ByteCompressionMethods.None,
            bool headCompression = false,
            bool validityCheck = true)
        {
            if (validityCheck)
                stream.WriteCheckCode((Int64)17);

            if (str.IsNullOrEmpty())
            {
                stream.WriteByte(byte.MaxValue);
                return;
            }

            if (encoder == null)
                encoder = _bestEncoder(str);

            byte[] b = encoder.GetBytes(str);
            b = b.Compress(ref compressionMethod);
            byte para = (byte)compressionMethod;

            if (headCompression)
            {
                byte cp = _getCP(encoder);

                if (b.Length <= byte.MaxValue)
                {
                    stream.WriteByte((byte)(para.SetBitOne(6) | cp));
                    stream.WriteByte((byte)b.Length);
                }
                else if (b.Length <= UInt16.MaxValue)
                {
                    stream.WriteByte((byte)(para.SetBitOne(7) | cp));
                    stream.WriteUInt16((UInt16)b.Length);
                }
                else if (b.Length <= Int32.MaxValue)
                {
                    stream.WriteByte((byte)(para | cp));
                    stream.WriteUInt32((UInt32)b.Length);
                }
                else
                    throw (new ArgumentException(IOResources.ERR_Text4GLimit));

                if (cp == 0x00)
                    stream.WriteUInt16((UInt16)encoder.CodePage);
            }
            else if (b.Length <= Int32.MaxValue)
            {
                stream.WriteByte(para);
                stream.WriteUInt32((UInt32)b.Length);
                stream.WriteUInt16((UInt16)encoder.CodePage);
            }
            else
                throw (new ArgumentException(IOResources.ERR_Text4GLimit));

            stream.WriteBytes(b);
        }

        /// <summary>
        /// Writes a string instance to this stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="str">The System.String object.</param>
        /// <param name="validityCheck">Indicates whether to write 
        /// a validity-check code before the string.</param>
        public static void WriteString(this Stream stream, string str, bool validityCheck)
        {
            WriteString(stream, str, null, ByteCompressionMethods.None, false, validityCheck);
        }

        /// <summary>
        /// Reads a string instance from this stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck">Indicates whether to read 
        /// a countersign before the string and perform data-validity check.</param>
        /// <returns>A string read from the stream.</returns>
        public static string ReadString(this Stream stream, bool validityCheck = true)
        {
            if (!validityCheck || stream.Check((Int64)17))
            {
                byte para = (byte)stream.ReadByte();
                if (para == byte.MaxValue) return string.Empty;

                if (para <= 0x0F) return _srstring(stream, para);

                int len;
                if (para.GetBitAt6())
                {
                    para = para.SetBitZeroAt6();
                    len = stream.ReadByte();
                }
                else if (para.GetBitAt7())
                {
                    para = para.SetBitZeroAt7();
                    len = (int)stream.ReadUInt16();
                }
                else
                    len = (int)stream.ReadUInt32();

                byte cp = (byte)(para & 0x30);
                Encoding coder = _getCoder(cp);
                if (coder == null) coder = Encoding.GetEncoding(stream.ReadUInt16());
                var alg = (ByteCompressionMethods)((byte)(para & 0xCF));
                return coder.GetString(stream.ReadBytes(len).DeCompress(alg));
            }
            else throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
        }



        /// <summary>
        /// Skips a string instance in this stream.
        /// </summary>
        /// <param name="stream">The stream to operate on.</param>
        /// <param name="validityCheck">Indicates whether to read 
        /// a countersign before the string and perform data-validity check.</param>
        public static void SkipString(this Stream stream, bool validityCheck = true)
        {
            if (!validityCheck || stream.Check((Int64)17))
            {
                byte para = (byte)stream.ReadByte();
                if (para == byte.MaxValue) return;

                if (para <= 0x0F) { _sfstring(stream); return; }

                int len = 0;
                if (para.GetBitAt6())
                    len += stream.ReadByte();
                else if (para.GetBitAt7())
                    len += stream.ReadUInt16();
                else
                    len += Convert.ToInt32(stream.ReadUInt32());

                byte cp = (byte)(para & 0x30);
                if (cp == 0x00) len += 2;

                stream.Seek(len, SeekOrigin.Current);
            }
            else
                throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
        }

        public static void WriteHuffmanTree<TStream, TObject>(this TStream stream, BinaryTree<TObject> huffmanTree)
            where TStream : Stream, IBitStream
        {
            var ie = huffmanTree.GetBreadthFirstEnumerator();
            while (ie.MoveNext())
            {
                var node = (BinaryTree<TObject>)ie.Current;

                var left = (node.LeftChild == null);
                var right = (node.RightChild == null);
                var isNull = !left || !right;
                stream.WriteBit(right);
                stream.WriteBit(left);
                stream.WriteBit(isNull);

                if (!isNull)
                    stream.TryWriteObject(node.Value, typeof(TObject));
            }
        }

        public static BinaryTree<TObject> ReadHuffmanTree<TStream, TObject>(this TStream stream)
            where TStream : Stream, IBitStream
        {
            var q = new Queue<BinaryTree<TObject>>();
            var root = new BinaryTree<TObject>();
            q.Enqueue(root);
            var objType = typeof(TObject);
            while (q.Count > 0)
            {
                var t = q.Dequeue();
                bool rightNull = stream.ReadBit();
                bool leftNull = stream.ReadBit();
                bool isNull = stream.ReadBit();

                if (isNull != (!rightNull || !leftNull))
                    throw new InvalidDataException();

                if (leftNull)
                    t.LeftChild = null;
                else
                {
                    t.LeftChild = new BinaryTree<TObject>();
                    q.Enqueue((BinaryTree<TObject>)t.LeftChild);
                }

                if (rightNull)
                    t.RightChild = null;
                else
                {
                    t.RightChild = new BinaryTree<TObject>();
                    q.Enqueue((BinaryTree<TObject>)t.RightChild);
                }

                if (!isNull)
                    t.Value = stream.TryReadObject(objType);
            }
            return root;
        }



        public static void WriteBitCode64(this Stream stream, BitCode64 code)
        {
            stream.WriteUInt64(code.Code);
            byte len = ((byte)code.Length).SetBit(7, code.High);
            stream.WriteByte(len);
        }

        public static BitCode64 ReadBitCode64(this Stream stream)
        {
            var v = stream.ReadUInt64();
            var len = (byte)stream.ReadByte();
            bool high = len.GetBitAt7();
            if (high)
                len = len.SetBitZeroAt7();

            return new BitCode64(v, len, high);
        }

        static void _innerWriteCompressedData<TStream, TObject>(this TStream stream, IEnumerator<TObject> enumerator, TObject encodingSwitch,
             TextCompressionMethods tMethod,
            Dictionary<TObject, BitCode64> dictionary = null, int predictCount = 0) where TStream : Stream, IBitStream
        {
            var saveDictionary = (dictionary == null);
            var objType = typeof(TObject);
            BinaryTree<TObject> dTree = null;
            int count = 0;
            switch (tMethod)
            {
                case TextCompressionMethods.Gamma:
                    {
                        dictionary = enumerator.GenerateGammaCoding<TObject>(encodingSwitch, out count, predictCount);
                        break;
                    }
                case TextCompressionMethods.Delta:
                    {
                        dictionary = enumerator.GenerateDeltaCoding<TObject>(encodingSwitch, out count, predictCount);
                        break;
                    }
                case TextCompressionMethods.Huffman:
                    {
                        dictionary = enumerator.GenerateHuffmanCoding<TObject>(encodingSwitch, out dTree, out count, predictCount);
                        break;
                    }
            }

            if (saveDictionary)
            {
                if (dTree != null)
                    stream.WriteHuffmanTree(dTree);
                else
                {
                    stream.WriteInt32(dictionary.Count);
                    foreach (var pair in dictionary)
                    {
                        stream.TryWriteObject(pair.Key, objType);
                        stream.WriteBits(pair.Value);
                    }
                }
            }

            stream.WriteInt32(count);
            enumerator.Reset();
            TObject cur;
            while (enumerator.MoveNext())
            {
                BitCode64 code;
                cur = enumerator.Current;
                if (dictionary.ContainsKey(cur))
                {
                    code = dictionary[cur];
                    stream.WriteBits(code);
                }
                else
                {
                    code = dictionary[encodingSwitch];
                    stream.WriteBits(code);
                    stream.TryWriteObject(cur);
                }
            }
        }

        public static void WriteCompressedData<TStream, TObject>(this TStream stream,
            TObject encodingSwitch,
            IEnumerator<TObject> enumerator,
            TextCompressionMethods tMethod,
            ByteCompressionMethods bMethod = ByteCompressionMethods.None,
            Dictionary<TObject, BitCode64> dictionary = null,
            int predictCount = 0)
            where TStream : Stream, IBitStream
        {
            if (bMethod != ByteCompressionMethods.None)
            {
                var ms = new MemoryStream();
                var bs = new ForwardBitStream(ms, false);
                bs._innerWriteCompressedData<ForwardBitStream, TObject>
                    (enumerator, encodingSwitch, tMethod, dictionary, predictCount);
                bs.Flush();
                var buffer = ms.ToArray().Compress(ref bMethod);

                byte algTag = 0;
                algTag = algTag.SetBitsAtLeft(4, (byte)tMethod);
                algTag = algTag.SetBitsAtRight(4, (byte)bMethod);
                stream.WriteByte(algTag);

                if (bMethod == ByteCompressionMethods.None)
                    stream.WriteBytes(buffer);
                else
                    stream.WriteByteArray(buffer);
            }
            else
            {
                byte algTag = 0;
                algTag = algTag.SetBitsAtLeft(4, (byte)tMethod);
                algTag = algTag.SetBitsAtRight(4, (byte)bMethod);
                stream.WriteByte(algTag);

                stream._innerWriteCompressedData<TStream, TObject>
                    (enumerator, encodingSwitch, tMethod, dictionary, predictCount);
            }
        }

        static TObject[] _innerReadCompressedText<TStream, TObject>(this TStream stream,
            TObject encodingSwitch,
            TextCompressionMethods tMethod,
            Dictionary<int, TObject> dictionary = null) where TStream : Stream, IBitStream
        {
            var readDictionary = (dictionary == null);
            var objType = typeof(TObject);
            BinaryTree<TObject> dTree = null;

            if (tMethod == TextCompressionMethods.Huffman)
                dTree = stream.ReadHuffmanTree<TStream, TObject>();
            else if (readDictionary)
            {
                var len = stream.ReadInt32();
                if (len > 0)
                {
                    dictionary = new Dictionary<int, TObject>(len);
                    TObject cur;
                    while (len-- > 0)
                    {
                        cur = stream.TryReadObject(objType);
                        dictionary.Add(stream.ReadGammaCode(), cur);
                    }

                }
                else throw new InvalidDataException();
            }

            var count = stream.ReadInt32();
            var output = new TObject[count];
            int i = 0;
            if (dTree != null)
            {
                while (count-- > 0)
                {
                    var value = stream.ReadHuffmanCode(dTree);
                    if (encodingSwitch.Equals(value))
                        output[i++] = stream.TryReadObject(objType);
                    else
                        output[i++] = value;
                }
            }
            else if (tMethod == TextCompressionMethods.Gamma)
            {
                while (count-- > 0)
                {
                    var value = dictionary[stream.ReadGammaCode()];
                    if (encodingSwitch.Equals(value))
                        output[i++] = stream.TryReadObject(objType);
                    else
                        output[i++] = value;
                }
            }
            else if (tMethod == TextCompressionMethods.Delta)
            {
                while (count-- > 0)
                {
                    var value = dictionary[stream.ReadDeltaCode()];
                    if (encodingSwitch.Equals(value))
                        output[i++] = stream.TryReadObject(objType);
                    else
                        output[i++] = value;
                }
            }
            return output;
        }

        public static TObject[] ReadCompressedText<TStream, TObject>(this TStream stream,
            TObject encodingSwitch,
            Dictionary<int, TObject> dictionary = null) where TStream : Stream, IBitStream
        {
            var algTag = (byte)stream.ReadByte();
            var tMethod = (TextCompressionMethods)algTag.GetBitsAtLeft(4);
            var bMethod = (ByteCompressionMethods)algTag.GetBitsAtRight(4);

            if (bMethod != ByteCompressionMethods.None)
            {
                var buffer = stream.ReadByteArray().DeCompress(bMethod);
                var bs = new ForwardBitStream(new MemoryStream(buffer), true);
                return bs._innerReadCompressedText(encodingSwitch, tMethod, dictionary);
            }
            else
                return stream._innerReadCompressedText(encodingSwitch, tMethod, dictionary);

        }


        #endregion
    }
}
