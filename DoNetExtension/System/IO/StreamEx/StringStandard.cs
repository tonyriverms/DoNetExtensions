using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoNetExtension.System.IO;

namespace System.IO
{
    public static partial class StreamEx
    {
        #region Base Methods

        /// <summary>
        /// Reads a string instance encoded by the specified <paramref name="encoding" /> from this stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="encoding">The encoding of the string.</param>
        /// <param name="validityCheck">Set this parameter <c>true</c> if there is a check code before the string to detect data corruption; otherwise, set this <c>false</c>.</param>
        /// <returns>A string read from the stream.</returns>
        public static string ReadText(this Stream stream, Encoding encoding, bool validityCheck)
        {
            var bytes = ReadByteArray(stream, validityCheck);
            if (bytes == null) return null;
            else if (bytes.Length == 1 && bytes[0] == 0) return string.Empty;
            else return encoding.GetString(bytes);
        }

        /// <summary>
        /// Reads a string instance encoded by the specified <paramref name="encoding" /> from this stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="encoding">The encoding of the string.</param>
        /// <returns>A string read from the stream.</returns>
        public static string ReadText(this Stream stream, Encoding encoding)
        {
            var bytes = ReadByteArray(stream);
            if (bytes == null) return null;
            else if (bytes.Length == 1 && bytes[0] == 0) return string.Empty;
            else return encoding.GetString(bytes);
        }

        /// <summary>
        /// Reads a string instance encoded by <see cref="Encoding.UTF8"/> from this stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>A string read from the stream.</returns>
        public static string ReadText(this Stream stream)
        {
            var bytes = ReadByteArray(stream);
            if (bytes == null) return null;
            else if (bytes.Length == 1 && bytes[0] == 0) return string.Empty;
            else return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        /// Writes a string instance (can be <c>null</c>) encoded by the specified <paramref name="encoding" /> to the stream.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="str">The string instance to write to the <paramref name="stream"/>.</param>
        /// <param name="encoding">The encoding of the string.</param>
        /// <param name="validityCheck">Set this parameter <c>true</c> if there is a check code before the string to detect data corruption; otherwise, set this <c>false</c>.</param>
        public static void WriteText(this Stream stream, string str, Encoding encoding, bool validityCheck)
        {
            if (str == null) stream.WriteByteArray(null, validityCheck);
            else if (str.Equals(string.Empty)) stream.WriteByteArray(new byte[] { 0 }, validityCheck);
            else stream.WriteByteArray(encoding.GetBytes(str), validityCheck);
        }

        /// <summary>
        /// Writes a string instance (can be <c>null</c>) encoded by the specified <paramref name="encoding" /> to the stream.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="str">The string instance to write to the <paramref name="stream"/>.</param>
        /// <param name="encoding">The encoding of the string.</param>
        public static void WriteText(this Stream stream, string str, Encoding encoding)
        {
            if (str == null) stream.WriteByteArray(null);
            else if (str.Equals(string.Empty)) stream.WriteByteArray(new byte[] { 0 });
            else stream.WriteByteArray(encoding.GetBytes(str));
        }

        /// <summary>
        /// Writes a string instance (can be <c>null</c>) encoded by <see cref="Encoding.UTF8"/> to the stream.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="str">The string instance to write to the <paramref name="stream"/>.</param>
        public static void WriteText(this Stream stream, string str)
        {
            if (str == null) stream.WriteByteArray(null);
            else if (str.Equals(string.Empty)) stream.WriteByteArray(new byte[] { 0 });
            else stream.WriteByteArray(Encoding.UTF8.GetBytes(str));
        }

        #endregion

        #region ASCII

        /// <summary>
        /// Reads an ASCII encoded string instance from this stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck">Set this parameter <c>true</c> if there is a check code before the string to detect data corruption; otherwise, set this <c>false</c>.</param>
        /// <returns>A string read from the stream.</returns>
        public static string ReadASCIIText(this Stream stream, bool validityCheck)
        {
            return ReadText(stream, Encoding.ASCII, validityCheck);
        }

        /// <summary>
        /// Reads an ASCII encoded string instance from this stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>A string read from the stream.</returns>
        public static string ReadASCIIText(this Stream stream)
        {
            return ReadText(stream, Encoding.ASCII);
        }

        /// <summary>
        /// Writes a string instance to the stream using ASCII encoding.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="str">The string instance to write to the <paramref name="stream"/>.</param>
        /// <param name="validityCheck">Set this parameter <c>true</c> if there is a check code before the string to detect data corruption; otherwise, set this <c>false</c>.</param>
        public static void WriteASCIIText(this Stream stream, string str, bool validityCheck)
        {
            WriteText(stream, str, Encoding.ASCII, validityCheck);
        }

        /// <summary>
        /// Writes a string instance to the stream using ASCII encoding.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="str">The string instance to write to the <paramref name="stream"/>.</param>
        public static void WriteASCIIText(this Stream stream, string str)
        {
            WriteText(stream, str, Encoding.ASCII);
        }

        #endregion

        #region UTF8

        /// <summary>
        /// Reads an UTF8 encoded string instance from this stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck">Set this parameter <c>true</c> if there is a check code before the string to detect data corruption; otherwise, set this <c>false</c>.</param>
        /// <returns>A string read from the stream.</returns>
        public static string ReadUTF8Text(this Stream stream, bool validityCheck)
        {
            return ReadText(stream, Encoding.UTF8, validityCheck);
        }

        /// <summary>
        /// Reads an UTF8 encoded string instance from this stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>A string read from the stream.</returns>
        public static string ReadUTF8Text(this Stream stream)
        {
            return ReadText(stream, Encoding.UTF8);
        }

        /// <summary>
        /// Writes a string instance to the stream using UTF8 encoding.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="str">The string instance to write to the <paramref name="stream"/>.</param>
        /// <param name="validityCheck">Set this parameter <c>true</c> if there is a check code before the string to detect data corruption; otherwise, set this <c>false</c>.</param>
        public static void WriteUTF8Text(this Stream stream, string str, bool validityCheck)
        {
            WriteText(stream, str, Encoding.UTF8, validityCheck);
        }

        /// <summary>
        /// Writes a string instance to the stream using UTF8 encoding.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="str">The string instance to write to the <paramref name="stream"/>.</param>
        public static void WriteUTF8Text(this Stream stream, string str)
        {
            WriteText(stream, str, Encoding.UTF8);
        }

        #endregion

        #region Unicode

        /// <summary>
        /// Reads an Unicode encoded string instance from this stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="validityCheck">Set this parameter <c>true</c> if there is a check code before the string to detect data corruption; otherwise, set this <c>false</c>.</param>
        /// <returns>A string read from the stream.</returns>
        public static string ReadUnicodeText(this Stream stream, bool validityCheck)
        {
            return ReadText(stream, Encoding.Unicode, validityCheck);
        }

        /// <summary>
        /// Reads an Unicode encoded string instance from this stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>A string read from the stream.</returns>
        public static string ReadUnicodeText(this Stream stream)
        {
            return ReadText(stream, Encoding.Unicode);
        }

        /// <summary>
        /// Writes a string instance to the stream using Unicode encoding.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="str">The string instance to write to the <paramref name="stream"/>.</param>
        /// <param name="validityCheck">Set this parameter <c>true</c> if there is a check code before the string to detect data corruption; otherwise, set this <c>false</c>.</param>
        public static void WriteUnicodeText(this Stream stream, string str, bool validityCheck)
        {
            WriteText(stream, str, Encoding.Unicode, validityCheck);
        }

        /// <summary>
        /// Writes a string instance to the stream using Unicode encoding.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="str">The string instance to write to the <paramref name="stream"/>.</param>
        public static void WriteUnicodeText(this Stream stream, string str)
        {
            WriteText(stream, str, Encoding.Unicode);
        }

        #endregion

        #region TextList

        public static void WriteTextList(this Stream stream, IList<string> stringList, Encoding encoding, bool validityCheck)
        {
            if (validityCheck) stream.WriteCheckCode(IOChecks.StringList);
            WriteTextList(stream, stringList, encoding);
        }

        public static void WriteTextList(this Stream stream, IList<string> stringList, Encoding encoding = null)
        {
            var c = stringList?.Count ?? 0;
            stream.WriteInt32(c);
            if (encoding == null) encoding = Encoding.UTF8;
            for (var i = 0; i < c; ++i)
                stream.WriteText(stringList[i], encoding, false);
        }

        public static string[] ReadTextList(this Stream stream, Encoding encoding, bool validityCheck)
        {
            if (!validityCheck || stream.Check(IOChecks.StringList))
            {
                var stringCount = stream.ReadInt32();
                if (stringCount < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
                if (stringCount != 0)
                {
                    var output = new string[stringCount];
                    if (encoding == null) encoding = Encoding.UTF8;
                    for (int i = 0; i < stringCount; ++i)
                        output[i] = stream.ReadText(encoding, false);
                    return output;
                }
                return null;
            }

            throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
        }

        public static string[] ReadTextList(this Stream stream, Encoding encoding = null)
        {
            var stringCount = stream.ReadInt32();
            if (stringCount < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
            else if (stringCount != 0)
            {
                var output = new string[stringCount];
                if (encoding == null) encoding = Encoding.UTF8;
                for (int i = 0; i < stringCount; ++i)
                    output[i] = stream.ReadText(encoding, false);
                return output;
            }
            else return null;
        }

        #endregion

        #region Text Pairs and Text-Keyed Dictionary

        public static void WriteTextPairs(this Stream stream, (string, string)[] textPairs, Encoding encoding, bool validityCheck)
        {
            if (validityCheck) stream.WriteCheckCode(IOChecks.StringList);
            WriteTextPairs(stream, textPairs, encoding);
        }

        public static void WriteTextPairs(this Stream stream, (string, string)[] textPairs, Encoding encoding = null)
        {
            var c = textPairs?.Length ?? 0;
            stream.WriteInt32(c);
            if (c == 0) return;

            if (encoding == null) encoding = Encoding.UTF8;

            foreach (var pair in textPairs)
            {
                stream.WriteText(pair.Item1, encoding, false);
                stream.WriteText(pair.Item2, encoding, false);
            }
        }

        public static (string, string)[] ReadTextPairs(this Stream stream, Encoding encoding, bool validityCheck)
        {
            if (!validityCheck || stream.Check(IOChecks.StringList))
            {
                var stringCount = stream.ReadInt32();
                if (stringCount < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
                if (stringCount != 0)
                {
                    if (encoding == null) encoding = Encoding.UTF8;
                    var output = new(string, string)[stringCount];
                    for (int i = 0; i < stringCount; ++i)
                        output[i] = (stream.ReadText(encoding, false), stream.ReadText(encoding, false));
                    return output;
                }
                return null;
            }

            throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
        }

        public static (string, string)[] ReadTextPairs(this Stream stream, Encoding encoding = null)
        {
            var stringCount = stream.ReadInt32();
            if (stringCount < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
            if (stringCount != 0)
            {
                if (encoding == null) encoding = Encoding.UTF8;
                var output = new(string, string)[stringCount];
                for (int i = 0; i < stringCount; ++i)
                    output[i] = (stream.ReadText(encoding, false), stream.ReadText(encoding, false));
                return output;
            }
            return null;
        }

        public static void WriteTextDict(this Stream stream, IDictionary<string, string> textDict, Encoding encoding, bool validityCheck)
        {
            if (validityCheck) stream.WriteCheckCode(IOChecks.StringList);
            WriteTextDict(stream, textDict, encoding);
        }

        public static void WriteTextDict(this Stream stream, IDictionary<string, string> textDict, Encoding encoding = null)
        {
            var c = textDict?.Count ?? 0;
            stream.WriteInt32(c);
            if (c == 0) return;

            if (encoding == null) encoding = Encoding.UTF8;

            foreach (var pair in textDict)
            {
                stream.WriteText(pair.Key, encoding, false);
                stream.WriteText(pair.Value, encoding, false);
            }
        }

        public static void ReadTextDict(this Stream stream, IDictionary<string, string> dict, Encoding encoding, bool validityCheck)
        {
            if (!validityCheck || stream.Check(IOChecks.StringList))
            {
                var stringCount = stream.ReadInt32();
                if (stringCount < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
                if (stringCount != 0)
                {
                    if (encoding == null) encoding = Encoding.UTF8;
                    for (int i = 0; i < stringCount; ++i)
                        dict.Add(stream.ReadText(encoding, false), stream.ReadText(encoding, false));
                    return;
                }
                return;
            }

            throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
        }

        public static void ReadTextDict(this Stream stream, IDictionary<string, string> dict, Encoding encoding = null)
        {
            var stringCount = stream.ReadInt32();
            if (stringCount < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
            if (stringCount != 0)
            {
                if (encoding == null) encoding = Encoding.UTF8;
                for (int i = 0; i < stringCount; ++i)
                    dict.Add(stream.ReadText(encoding, false), stream.ReadText(encoding, false));
            }
        }

        public static void WriteTextDict<T>(this Stream stream, IDictionary<string, T> dict, Encoding encoding, bool validityCheck) where T : IBinarySavable, new()
        {
            if (validityCheck) stream.WriteCheckCode(IOChecks.StringList);
            WriteTextDict(stream, dict, encoding);
        }

        public static void WriteTextDict<T>(this Stream stream, IDictionary<string, T> dict, Encoding encoding = null) where T : IBinarySavable, new()
        {
            var c = dict?.Count ?? 0;
            stream.WriteInt32(c);
            if (c == 0) return;

            if (encoding == null) encoding = Encoding.UTF8;

            foreach (var pair in dict)
            {
                stream.WriteText(pair.Key, encoding, false);
                stream.WriteBinarySavable(pair.Value);
            }
        }

        public static void ReadTextDict<T>(this Stream stream, IDictionary<string, T> dict, Encoding encoding, bool validityCheck) where T : IBinarySavable, new()
        {
            if (!validityCheck || stream.Check(IOChecks.StringList))
            {
                var stringCount = stream.ReadInt32();
                if (stringCount < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
                if (stringCount != 0)
                {
                    if (encoding == null) encoding = Encoding.UTF8;
                    for (int i = 0; i < stringCount; ++i)
                        dict.Add(stream.ReadText(encoding, false), stream.ReadBinarySavable<T>());
                    return;
                }
                return;
            }

            throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
        }

        public static void ReadTextDict<T>(this Stream stream, IDictionary<string, T> dict, Encoding encoding = null) where T : IBinarySavable, new()
        {
            var stringCount = stream.ReadInt32();
            if (stringCount < 0) throw new InvalidDataException(IOResources.ERR_StreamExtension_DataIrrecognizable);
            if (stringCount != 0)
            {
                if (encoding == null) encoding = Encoding.UTF8;
                for (int i = 0; i < stringCount; ++i)
                    dict.Add(stream.ReadText(encoding, false), stream.ReadBinarySavable<T>());
                return;
            }
        }

        #endregion
    }
}
