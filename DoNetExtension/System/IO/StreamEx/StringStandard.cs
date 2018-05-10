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
            if(str == null) stream.WriteByteArray(null);
            else if (str.Equals(string.Empty)) stream.WriteByteArray(new byte[] { 0 });
            else stream.WriteByteArray(encoding.GetBytes(str));
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
            if (validityCheck)
                stream.WriteCheckCode(IOChecks.StringList);
            WriteTextList(stream, stringList, encoding);
        }

        public static void WriteTextList(this Stream stream, IList<string> stringList, Encoding encoding = null)
        {
            var c = (stringList == null) ? 0 : stringList.Count;
            stream.WriteInt32(c);
            if (encoding == null) encoding = Encoding.UTF8;
            for (int i = 0; i < c; ++i)
                stream.WriteText(stringList[i], encoding, false);
        }

        public static string[] ReadTextList(this Stream stream, Encoding encoding, bool validityCheck)
        {
            if (!validityCheck || stream.Check(IOChecks.StringList))
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
            else
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
    }
}
