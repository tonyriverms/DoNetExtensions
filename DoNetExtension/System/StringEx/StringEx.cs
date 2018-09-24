using DoNetExtension.System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace System
{
    public static class IOExtensionOnStringExtension
    {
        public static void WriteStringRetrieveOption(this Stream stream, StringRetrievalOption value, bool validityCheck = true)
        {
            if (validityCheck)
                stream.WriteCheckCode(IOChecks.Common);
            if (value == null)
            {
                stream.WriteInt32(-1);
                return;
            }
            stream.WriteInt32(value.StartIndex);
            stream.WriteInt32(value.MaximumReturn);
            stream.WriteBoolean(value.IncludeStartIndicator);
            stream.WriteBoolean(value.IncludeEndIndicator);
            stream.WriteString(value.Locator, false);
            stream.WriteString(value.Boundary, false);
            stream.WriteStringList(value.StartIndicator, false);
            stream.WriteStringList(value.EndIndicator, false);
        }

        public static StringRetrievalOption ReadStringRetrieveOption(this Stream stream, bool validityCheck = true)
        {
            if (validityCheck)
                stream.Check(IOChecks.Common);
            var sidx = stream.ReadInt32();
            if (sidx == -1) return null;

            var option = new StringRetrievalOption();
            option.StartIndex = sidx;
            option.MaximumReturn = stream.ReadInt32();
            option.IncludeStartIndicator = stream.ReadBoolean();
            option.IncludeEndIndicator = stream.ReadBoolean();
            option.Locator = stream.ReadString(false);
            option.Boundary = stream.ReadString(false);
            option.StartIndicator = stream.ReadStringList(false);
            option.EndIndicator = stream.ReadStringList(false);
            return option;
        }

        public static void WriteStringSeekOption(this Stream stream, StringSeekOption value, bool validityCheck = true)
        {
            if (validityCheck)
                stream.WriteCheckCode(IOChecks.Common);
            if (value == null)
            {
                stream.WriteInt32(-1);
                return;
            }
            stream.WriteInt32(value.StartPosition);
            stream.WriteString(value.StartIndicator, false);
            stream.WriteString(value.EndIndicator, false);
            stream.WriteStringList(value.Values, false);
            stream.WriteByte((byte)value.Mode);
        }

        public static StringSeekOption ReadStringSeekOption(this Stream stream, bool validityCheck = true)
        {
            if (validityCheck)
                stream.Check(IOChecks.Common);
            var sidx = stream.ReadInt32();
            if (sidx == -1) return null;
            var option = new StringSeekOption();
            option.StartPosition = sidx;
            option.StartIndicator = stream.ReadString(false);
            option.EndIndicator = stream.ReadString(false);
            option.Values = stream.ReadStringList(false);
            option.Mode = (StringSeekMode)stream.ReadByte();
            return option;
        }
    }

    /// <summary>Specifies how an object is horizontally aligned.</summary>
    [ComVisible(true)]
    public enum HorizontalAlignment
    {
        Left,
        Right,
        Center,
    }

    /// <summary>
    /// Provides rich methods to operate string instances.
    /// </summary>
    public static partial class StringEx
    {
        //VERSION: 0.0.22
        //DATE: 02/17/2008
        //UPDATE: 04/09/2013

        #region Dummies

        //TEST: Not Needed
        /// <summary>
        /// Converts the current string sequence to a hash-set.
        /// </summary>
        /// <param name="sequence">This string sequence.</param>
        /// <returns>A hash-set that contains all distinct elements from the current string sequence.</returns>
        public static HashSet<string> ToHashSet(this IEnumerable<string> sequence)
        {
            return new HashSet<string>(sequence);
        }

        /// <summary>
        /// Creates a new string instance with the same value as the current one.
        /// <para>This a dummy of <c>string.Copy</c> method for convenience.</para>
        /// </summary>
        /// <param name="str">The string instance to copy.</param>
        /// <returns>The new string instance.</returns>
        public static string Copy(this string str)
        {
            return string.Copy(str);
        }

        /// <summary>
        /// Determines whether this string instance and another specified string instance have the same value with case and trim options.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="value">The string to compare to this instance.</param>
        /// <param name="ignoreCase">Indicates whether case of strings is ignored during comparision.</param>
        /// <param name="trimSource">Indicates whether the white spaces at the beginning and the end of the current string instance are 
        /// removed before comparision.</param>
        /// <param name="trimValue">Indicates whether the white spaces at the beginning and the end of the string instance to compare are 
        /// removed before the comparision.</param>
        /// <returns><c>true</c> if the two compared string instances have the same value under the specified options; otherwise, <c>false</c>.</returns>
        public static bool Equals(this string str, string value, bool ignoreCase, bool trimSource = false, bool trimValue = false)
        {
            if (trimSource) str = str?.Trim();
            if (trimValue) value = value?.Trim();

            return ignoreCase ? str.Equals(value, StringComparison.InvariantCultureIgnoreCase) : str.Equals(value);
        }

        #endregion

        #region In-Series

        //TEST: Not Needed
        /// <summary>
        /// Determines whether this string instance is in an array of strings.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="array">An array of strings.</param>
        /// <param name="comparisonType">Specifies how the strings are compared.</param>
        /// <param name="trimTarget">Indicates whether to trim all strings in the <paramref name="array"/> to compare.</param>
        /// <returns><c>true</c> if this string is in the specified array of strings; otherwise, <c>false</c>.</returns>
        public static bool In(this string str, StringComparison comparisonType, bool trimTarget, params string[] array)
        {
            foreach (var str2 in array)
                if ((trimTarget ? str2.Trim() : str2).Equals(str, comparisonType))
                    return true;
            return false;
        }

        //TEST: Not Needed
        /// <summary>
        /// Determines whether this string instance is in an array of strings.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="array">An array of strings.</param>
        /// <param name="comparisonType">Specifies how the strings are compared.</param>
        /// <returns><c>true</c> if this string is in the specified array of strings; otherwise, <c>false</c>.</returns>
        public static bool In(this string str, StringComparison comparisonType, params string[] array)
        {
            foreach (var str2 in array)
                if (str2.Equals(str, comparisonType))
                    return true;
            return false;
        }

        //TEST: Not Needed
        /// <summary>
        /// Determines whether this string instance is in a sequence of strings.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="sequence">A sequence of strings.</param>
        /// <param name="comparisonType">Specifies how the strings are compared.</param>
        /// <returns><c>true</c> if this string is in the specified sequence of strings; otherwise, <c>false</c>.</returns>
        public static bool In(this string str, StringComparison comparisonType, IEnumerable<string> sequence)
        {
            foreach (var str2 in sequence)
                if (str2.Equals(str, comparisonType))
                    return true;
            return false;
        }

        //TEST: Not Needed
        /// <summary>
        /// Determines whether this string instance is in a sequence of strings.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="sequence">A sequence of strings.</param>
        /// <param name="comparisonType">Specifies how the string will be compared.</param>
        /// <param name="trimTarget">Indicates whether to trim all strings in the <paramref name="sequence"/> to compare.</param>
        /// <returns><c>true</c> if this string is in the specified sequence of strings; otherwise, <c>false</c>.</returns>
        public static bool In(this string str, IEnumerable<string> sequence, StringComparison comparisonType, bool trimTarget = false)
        {
            if (trimTarget && str != null) str = str.Trim();

            foreach (var str2 in sequence)
                if ((trimTarget ? str2.Trim() : str2).Equals(str, comparisonType))
                    return true;
            return false;
        }

        //TEST: Not Needed
        /// <summary>
        /// Determines whether this string instance is in a sequence of strings.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="sequence">A sequence of strings.</param>
        /// <param name="ignoreCase">Specifies whether case of strings is ignored during the comparison.</param>
        /// <param name="trimTarget">Indicates whether to trim all strings in the <paramref name="sequence"/> to compare.</param>
        /// <returns><c>true</c> if this string is in the specified sequence of strings; otherwise, <c>false</c>.</returns>
        public static bool In(this string str, IEnumerable<string> sequence, bool ignoreCase, bool trimTarget = false)
        {
            if (trimTarget && str != null) str = str.Trim();

            foreach (var str2 in sequence)
                if (str.Equals(str2, ignoreCase, false, trimTarget))
                    return true;
            return false;
        }

        #endregion

        #region Remove

        /// <summary>
        /// Removes extra white spaces from the current string; for example, if there is a substring of three white spaces, only the first white space is preserved in the returned string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="mergeLines">if set to <c>true</c>, '\r' and '\n' and other new-line symbols defined in <see cref="Environment.NewLine"/> are removed.</param>
        /// <returns>A string with extra white spaces removed.</returns>
        public static string RemoveExtraWhiteSpaces(this string str, bool mergeLines = true)
        {
            var sb = StringBuilderCache.Acquire(str.Length);
            var prevWhitespace = false;
            for (int i = 0, j = str.Length; i < j; ++i)
            {
                var c = str[i];
                if (c == '\r' || c == '\n' || c.In(Environment.NewLine))
                {
                    if (!mergeLines)
                    {
                        sb.Append(c);
                        prevWhitespace = true;
                    }
                }
                else if (c.IsWhiteSpace())
                {
                    if (!prevWhitespace)
                    {
                        sb.Append(' ');
                        prevWhitespace = true;
                    }
                }
                else
                {
                    prevWhitespace = false;
                    sb.Append(c);
                }
            }

            return StringBuilderCache.GetStringAndRelease(sb);
        }

        public static string Remove(this string str, Func<char, bool> predicate)
        {
            var sb = new StringBuilder();
            for (int i = 0, j = str.Length; i < j; ++i)
            {
                var c = str[i];
                if (predicate(c)) continue;
                else sb.Append(c);
            }
            return sb.ToString();
        }


        /// <summary>
        /// Returns a copy of this string instance with the last character removed.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <returns>A copy of this string instance with the last character removed.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string RemoveLast(this string str)
        {
            return str.Substring(0, str.Length - 1);
        }


        /// <summary>
        /// Returns a copy of this string instance with the first character removed.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <returns>A copy of this string instance with the first character removed.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string RemoveFirst(this string str)
        {
            return str.Substring(1);
        }

        /// <summary>
        /// If the current string starts with the specified <paramref name="leftChr" /> and ends with the specified <paramref name="rightChr" />, returns a new string instance with the <paramref name="leftChr" /> and <paramref name="rightChr" /> removed.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="leftChr">Checks if this <see cref="System.Char" /> appears at the beginning of the current string.</param>
        /// <param name="rightChr">Checks if this <see cref="System.Char" /> appears at the end of the current string.</param>
        /// <param name="ignoreWhitespace">If set to <c>true</c>, the white spaces defined by <see cref="char.IsWhiteSpace(char)"/> at the beginning and the end of the current string will be ignored. These white spaces will also be removed if a match of <paramref name="leftChr" /> and <paramref name="rightChr" /> are found.</param>
        /// <returns>A new string instance with the <paramref name="leftChr" /> at the beginning and the <paramref name="rightChr" /> at the end removed; the original string instance if either <paramref name="leftChr" /> is not found at the beginning of the current instance, or <paramref name="rightChr" /> is not found at the end of the current instance. White spaces at the beginning and the end will also be removed if <paramref name="ignoreWhitespace"/> is specified <c>true</c>.</returns>
        public static string RemoveMatchedCharPair(this string str, char leftChr, char rightChr, bool ignoreWhitespace = true)
        {
            int start, end;
            int length = str.Length;

            for (start = 0; start < length; ++start)
            {
                if (ignoreWhitespace && str[start].IsWhiteSpace()) continue;
                if (str[start] == leftChr) break;
                return str;
            }

            if (start == length) return str;
            ++start;

            for (end = length - 1; end >= start; --end)
            {
                if (ignoreWhitespace && str[end].IsWhiteSpace()) continue;
                if (str[end] == rightChr) break;
                return str;
            }

            if (start == end) return string.Empty;
            return str.Substring(start, end - start);
        }

        /// <summary>
        /// Returns a new string instance with the "quote"s at both ends of the current string removed.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="quoteChr">Checks if this <see cref="System.Char" /> appears both ends of the current string.</param>
        /// <param name="ignoreWhitespace">If set to <c>true</c>, the white spaces defined by <see cref="char.IsWhiteSpace(char)"/> at the beginning and the end of the current string will be ignored. These white spaces will also be removed if <paramref name="quoteChr"/> is found at both ends of the current string.</param>
        /// <returns>A new string instance with the <paramref name="quoteChr" /> at both ends of the string removed; the original string instance if either <paramref name="quoteChr" /> is not found at the beginning of the current instance, or it is not found at the end of the current instance. White spaces at the beginning and the end will also be removed if <paramref name="ignoreWhitespace"/> is specified <c>true</c>.</returns>
        public static string RemoveQuotes(this string str, char quoteChr, bool ignoreWhitespace = true)
        {
            return RemoveMatchedCharPair(str, quoteChr, quoteChr, ignoreWhitespace);
        }

        //TEST: Yes
        /// <summary>
        /// Removes a new string in which all occurrences of the specified substrings are removed from the current string.
        /// NOTE that this method only removes occurrences in the current string before the removal operation. 
        /// Any new occurrence caused by the removal operation will not be removed again. For example, removing "ab", "bc" from "aabbcb" returns "ab".
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="substrings">Substrings to remove.</param>
        /// <param name="blankspace">Indicates whether a blank space will take place of each occurrence of the removed substring.</param>
        /// <returns>A copy of the current string in which all occurrences of the specified substrings are removed.</returns>
        public static string Remove(this string str, string[] substrings, bool blankspace = false)
        {
            foreach (string del in substrings)
                str = str.Remove(del, blankspace);
            return str;
        }

        //TEST: Yes
        //TODO: Better Performance
        /// <summary>
        /// Returns a new string in which all occurrences of the specified substring are removed from the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="subString">The substring to remove.</param>
        /// <param name="replaceByWhitespace">Indicates whether a blank space will take place of each occurrence of the removed substring.</param>
        /// <returns>A copy of the current string in which all occurrences of the specified substring are removed.</returns>
        public static string Remove(this string str, string subString, bool replaceByWhitespace = false)
        {
            if (replaceByWhitespace)
                return str.Replace(subString, " ");
            else
                return str.Replace(subString, string.Empty);
        }

        //TODO: substring removal with comparison options

        //TEST: Yes
        /// <summary>
        /// Returns a new string in which all occurrences of the specified characters are removed from the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="charsToRemove">The characters to remove.</param>
        /// <param name="saveMemory">Set <c>true</c> if the current string will not be used elsewhere and the memory is really a big concern. 
        /// <para>If this parameter is true, the current string instance might become meaningless and no longer usable after the execution of this method.</para></param>
        /// <returns>A copy of the current string in which all occurrences of <paramref name="charsToRemove"/> are removed.</returns>
        public unsafe static string Remove(this string str, char[] charsToRemove, bool saveMemory = false)
        {
            var strlen = str.Length;
            if (!saveMemory) str = String.Copy(str);
            int j = 0;
            var write = false;
            fixed (char* ptr = str)
            {
                for (int i = 0; i < strlen;)
                {
                    var c = ptr[i];
                    if (c.In(charsToRemove)) write = true;
                    else
                    {
                        if (write) ptr[j] = c;
                        ++j;
                    }
                    ++i;
                }

                if (write) return str.Substring(0, j);
                else return str;
            }
        }

        public unsafe static string Remove(this string str, Func<char, bool> predicate, bool saveMemory = false)
        {
            var strlen = str.Length;
            if (!saveMemory) str = string.Copy(str);
            int j = 0;
            var write = false;
            fixed (char* ptr = str)
            {
                for (int i = 0; i < strlen;)
                {
                    var c = ptr[i];
                    if (predicate(c)) write = true;
                    else
                    {
                        if (write) ptr[j] = c;
                        ++j;
                    }
                    ++i;
                }

                if (write) return str.Substring(0, j);
                else return str;
            }
        }

        /// <summary>
        /// Returns a new string in which all occurrences of the specified character are removed from the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="charToRemove">The character to remove.</param>
        /// <param name="saveMemory">Set <c>true</c> if the current string will not be used elsewhere and the memory is really a big concern. 
        /// <para>If this parameter is true, the current string instance might become meaningless and no longer usable after the execution of this method.</para></param>
        /// <returns>A copy of the current string in which all occurrences of <paramref name="charToRemove"/> are removed.</returns>
        public unsafe static string Remove(this string str, char charToRemove, bool saveMemory = false)
        {
            var strlen = str.Length;
            if (!saveMemory) str = String.Copy(str);
            int j = 0;
            var write = false;
            fixed (char* ptr = str)
            {
                for (int i = 0; i < strlen; i++)
                {
                    var c = ptr[i];
                    if (c == charToRemove) write = true;
                    else
                    {
                        if (write) ptr[j] = c;
                        j++;
                    }

                }
                if (write) return str.Substring(0, j);
                else return str;
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters after the first occurrence of a specified delimiter removed. The delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiter">All characters after the first occurrence of this delimiter will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <param name="succeeded">Gets a value indicating whether the delimiter was found.</param>
        /// <returns>The string with all characters after the first occurrence of the delimiter removed. The delimiter may be removed as well.</returns>
        public static string RemoveAfter(this string source, char delimiter, bool removeDelimiter, out bool succeeded)
        {
            var idx = source.IndexOf(delimiter);
            if (idx == -1)
            {
                succeeded = false;
                return source;
            }
            else
            {
                succeeded = true;
                if (!removeDelimiter) idx++;
                return source.Substring(0, idx);
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters after the last occurrence of a specified delimiter removed. The delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiter">All characters after the last occurrence of this delimiter will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <param name="succeeded">Gets a value indicating whether the delimiter was found.</param>
        /// <returns>The string with all characters after the last occurrence of the delimiter removed. The delimiter may be removed as well.</returns>
        public static string RemoveAfterLast(this string source, char delimiter, bool removeDelimiter, out bool succeeded)
        {
            var idx = source.LastIndexOf(delimiter);
            if (idx == -1)
            {
                succeeded = false;
                return source;
            }
            else
            {
                succeeded = true;
                if (!removeDelimiter) idx++;
                return source.Substring(0, idx);
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters after the first occurrence of a specified delimiter removed. The delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiter">All characters after the first occurrence of this delimiter will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <returns>The string with all characters after the first occurrence of the delimiter removed. The delimiter may be removed as well.</returns>
        public static string RemoveAfter(this string source, char delimiter, bool removeDelimiter)
        {
            var idx = source.IndexOf(delimiter);
            if (idx == -1)
            {
                return source;
            }
            else
            {
                if (!removeDelimiter)
                    idx++;
                return source.Substring(0, idx);
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters after the last occurrence of a specified delimiter removed. The delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiter">All characters after the last occurrence of this delimiter will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <returns>The string with all characters after the last occurrence of the delimiter removed. The delimiter may be removed as well.</returns>
        public static string RemoveAfterLast(this string source, char delimiter, bool removeDelimiter)
        {
            var idx = source.LastIndexOf(delimiter);
            if (idx == -1)
            {
                return source;
            }
            else
            {
                if (!removeDelimiter)
                    idx++;
                return source.Substring(0, idx);
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters after the first occurrence of a specified delimiter removed. The delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiter">All characters after the first occurrence of this delimiter will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <param name="succeeded">Gets a value indicating whether the delimiter was found.</param>
        /// <returns>The string with all characters after the first occurrence of the delimiter removed. The delimiter may be removed as well.</returns>
        public static string RemoveAfter(this string source, string delimiter, bool removeDelimiter, out bool succeeded)
        {
            var idx = source.IndexOf(delimiter);
            if (idx == -1)
            {
                succeeded = false;
                return source;
            }
            else
            {
                succeeded = true;
                if (!removeDelimiter)
                    idx += delimiter.Length;
                return source.Substring(0, idx);
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters after the last occurrence of a specified delimiter removed. The delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiter">All characters after the last occurrence of this delimiter will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <param name="succeeded">Gets a value indicating whether the delimiter was found.</param>
        /// <returns>The string with all characters after the last occurrence of the delimiter removed. The delimiter may be removed as well.</returns>
        public static string RemoveAfterLast(this string source, string delimiter, bool removeDelimiter, out bool succeeded)
        {
            var idx = source.LastIndexOf(delimiter);
            if (idx == -1)
            {
                succeeded = false;
                return source;
            }
            else
            {
                succeeded = true;
                if (!removeDelimiter)
                    idx += delimiter.Length;
                return source.Substring(0, idx);
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters after the first occurrence of a specified delimiter removed. The delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiter">All characters after the first occurrence of this delimiter will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <returns>The string with all characters after the first occurrence of the delimiter removed. The delimiter may be removed as well.</returns>
        public static string RemoveAfter(this string source, string delimiter, bool removeDelimiter)
        {
            var idx = source.IndexOf(delimiter);
            if (idx == -1) return source;
            else
            {
                if (!removeDelimiter)
                    idx += delimiter.Length;
                return source.Substring(0, idx);
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters after the last occurrence of a specified delimiter removed. The delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiter">All characters after the last occurrence of this delimiter will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <returns>The string with all characters after the last occurrence of the delimiter removed. The delimiter may be removed as well.</returns>
        public static string RemoveAfterLast(this string source, string delimiter, bool removeDelimiter)
        {
            var idx = source.LastIndexOf(delimiter);
            if (idx == -1) return source;
            else
            {
                if (!removeDelimiter)
                    idx += delimiter.Length;
                return source.Substring(0, idx);
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters after the first occurrence of any of the specified delimiters removed. 
        /// The matched delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiters">All characters after the first occurrence of any of these delimiters will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <param name="succeeded">Gets a value indicating whether at least one of the specified delimiters was found.</param>
        /// <returns>The string with all characters after the first occurrence of any of the delimiters removed. The matched delimiter may be removed as well.</returns>
        public static string RemoveAfter(this string source, IList<string> delimiters, bool removeDelimiter, out bool succeeded)
        {
            var rlt = source.IndexOfAny(delimiters, 0);
            if (rlt == null || rlt.Position == -1)
            {
                succeeded = false;
                return source;
            }
            else
            {
                succeeded = true;
                var len = rlt.Position;
                if (!removeDelimiter)
                    len += rlt.Value.Length;
                return source.Substring(0, len);
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters after the last occurrence of any of the specified delimiters removed. 
        /// The matched delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiters">All characters after the last occurrence of any of these delimiters will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <param name="succeeded">Gets a value indicating whether at least one of the specified delimiters was found.</param>
        /// <returns>The string with all characters after the last occurrence of any of the delimiters removed. The matched delimiter may be removed as well.</returns>
        public static string RemoveAfterLast(this string source, IList<string> delimiters, bool removeDelimiter, out bool succeeded)
        {
            var rlt = source.LastIndexOfAny(delimiters, 0);
            if (rlt == null || rlt.Position == -1)
            {
                succeeded = false;
                return source;
            }
            else
            {
                succeeded = true;
                var len = rlt.Position;
                if (!removeDelimiter)
                    len += rlt.Value.Length;
                return source.Substring(0, len);
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters after the first occurrence of any of the specified delimiters removed. 
        /// The delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiters">All characters after the first occurrence of any of these delimiters will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <returns>The string with all characters after the first occurrence of any of the delimiters removed. The matched delimiter may be removed as well.</returns>
        public static string RemoveAfter(this string source, IList<string> delimiters, bool removeDelimiter)
        {
            var rlt = source.IndexOfAny(delimiters, 0);
            if (rlt == null || rlt.Position == -1)
            {
                return source;
            }
            else
            {
                var len = rlt.Position;
                if (!removeDelimiter)
                    len += rlt.Value.Length;
                return source.Substring(0, len);
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters after the last occurrence of any of the specified delimiters removed. 
        /// The delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiters">All characters after the last occurrence of any of these delimiters will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <returns>The string with all characters after the last occurrence of any of the delimiters removed. The matched delimiter may be removed as well.</returns>
        public static string RemoveAfterLast(this string source, IList<string> delimiters, bool removeDelimiter)
        {
            var rlt = source.LastIndexOfAny(delimiters, 0);
            if (rlt == null || rlt.Position == -1)
            {
                return source;
            }
            else
            {
                var len = rlt.Position;
                if (!removeDelimiter)
                    len += rlt.Value.Length;
                return source.Substring(0, len);
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters after the first occurrence of any of the specified delimiters removed. 
        /// The delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiters">All characters after the first occurrence of any of these delimiters will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <param name="succeeded">Gets a value indicating whether at least one of the specified delimiters was found.</param>
        /// <returns>The string with all characters after the first occurrence of any of the delimiters removed. The matched delimiter may be removed as well.</returns>
        public static string RemoveAfter(this string source, char[] delimiters, bool removeDelimiter, out bool succeeded)
        {
            var idx = source.IndexOfAny(delimiters);
            if (idx == -1)
            {
                succeeded = false;
                return source;
            }
            else
            {
                succeeded = true;
                if (!removeDelimiter)
                    idx++;
                return source.Substring(0, idx);
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters after the last occurrence of any of the specified delimiters removed. 
        /// The delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiters">All characters after the last occurrence of any of these delimiters will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <param name="succeeded">Gets a value indicating whether at least one of the specified delimiters was found.</param>
        /// <returns>The string with all characters after the last occurrence of any of the delimiters removed. The matched delimiter may be removed as well.</returns>
        public static string RemoveAfterLast(this string source, char[] delimiters, bool removeDelimiter, out bool succeeded)
        {
            var idx = source.LastIndexOfAny(delimiters);
            if (idx == -1)
            {
                succeeded = false;
                return source;
            }
            else
            {
                succeeded = true;
                if (!removeDelimiter)
                    idx++;
                return source.Substring(0, idx);
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters after the first occurrence of any of the specified delimiters removed. 
        /// The delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiters">All characters after the first occurrence of any of these delimiters will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <returns>The string with all characters after the first occurrence of any of the delimiters removed. The matched delimiter may be removed as well.</returns>
        public static string RemoveAfter(this string source, char[] delimiters, bool removeDelimiter)
        {
            var idx = source.IndexOfAny(delimiters);
            if (idx == -1)
            {
                return source;
            }
            else
            {
                if (!removeDelimiter)
                    idx++;
                return source.Substring(0, idx);
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters after the last occurrence of any of the specified delimiters removed. 
        /// The delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiters">All characters after the last occurrence of any of these delimiters will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <returns>The string with all characters after the last occurrence of any of the delimiters removed. The matched delimiter may be removed as well.</returns>
        public static string RemoveAfterLast(this string source, char[] delimiters, bool removeDelimiter)
        {
            var idx = source.LastIndexOfAny(delimiters);
            if (idx == -1)
            {
                return source;
            }
            else
            {
                if (!removeDelimiter)
                    idx++;
                return source.Substring(0, idx);
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters before the first occurrence of a specified delimiter removed. The delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiter">All characters before the first occurrence of this delimiter will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <param name="succeeded">Gets a value indicating whether the delimiter was found.</param>
        /// <returns>The string with all characters before the first occurrence of the delimiter removed. The delimiter may be removed as well.</returns>
        public static string RemoveBefore(this string source, char delimiter, bool removeDelimiter, out bool succeeded)
        {
            var idx = source.IndexOf(delimiter);
            if (idx == -1)
            {
                succeeded = false;
                return source;
            }
            else
            {
                succeeded = true;
                if (removeDelimiter)
                    idx++;
                return source.Substring(idx);
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters before the last occurrence of a specified delimiter removed. The delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiter">All characters before the last occurrence of this delimiter will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <param name="succeeded">Gets a value indicating whether the delimiter was found.</param>
        /// <returns>The string with all characters before the last occurrence of the delimiter removed. The delimiter may be removed as well.</returns>
        public static string RemoveBeforeLast(this string source, char delimiter, bool removeDelimiter, out bool succeeded)
        {
            var idx = source.LastIndexOf(delimiter);
            if (idx == -1)
            {
                succeeded = false;
                return source;
            }
            else
            {
                succeeded = true;
                if (removeDelimiter)
                    idx++;
                return source.Substring(idx);
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters before the first occurrence of a specified delimiter removed. The delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiter">All characters before the first occurrence of this delimiter will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <returns>The string with all characters before the first occurrence of the delimiter removed. The delimiter may be removed as well.</returns>
        public static string RemoveBefore(this string source, char delimiter, bool removeDelimiter)
        {
            var idx = source.IndexOf(delimiter);
            if (idx == -1)
            {
                return source;
            }
            else
            {
                if (removeDelimiter)
                    idx++;
                return source.Substring(idx);
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters before the last occurrence of a specified delimiter removed. The delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiter">All characters before the last occurrence of this delimiter will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <returns>The string with all characters before the last occurrence of the delimiter removed. The delimiter may be removed as well.</returns>
        public static string RemoveBeforeLast(this string source, char delimiter, bool removeDelimiter)
        {
            var idx = source.LastIndexOf(delimiter);
            if (idx == -1)
            {
                return source;
            }
            else
            {
                if (removeDelimiter)
                    idx++;
                return source.Substring(idx);
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters before the first occurrence of a specified delimiter removed. The delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiter">All characters before the first occurrence of this delimiter will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <param name="succeeded">Gets a value indicating whether the delimiter was found.</param>
        /// <returns>The string with all characters before the first occurrence of the delimiter removed. The delimiter may be removed as well.</returns>
        public static string RemoveBefore(this string source, string delimiter, bool removeDelimiter, out bool succeeded)
        {
            var idx = source.IndexOf(delimiter);

            if (idx == -1)
            {
                succeeded = false;
                return source;
            }
            else
            {
                succeeded = true;
                if (removeDelimiter) idx += delimiter.Length;
                return source.Substring(idx);
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters before the last occurrence of a specified delimiter removed. The delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiter">All characters before the last occurrence of this delimiter will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <param name="succeeded">Gets a value indicating whether the delimiter was found.</param>
        /// <returns>The string with all characters before the last occurrence of the delimiter removed. The delimiter may be removed as well.</returns>
        public static string RemoveBeforeLast(this string source, string delimiter, bool removeDelimiter, out bool succeeded)
        {
            var idx = source.LastIndexOf(delimiter);

            if (idx == -1)
            {
                succeeded = false;
                return source;
            }
            else
            {
                succeeded = true;
                if (removeDelimiter) idx += delimiter.Length;
                return source.Substring(idx);
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters before the first occurrence of a specified delimiter removed. The delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiter">All characters before the first occurrence of this delimiter will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <returns>The string with all characters before the first occurrence of the delimiter removed. The delimiter may be removed as well.</returns>
        public static string RemoveBefore(this string source, string delimiter, bool removeDelimiter)
        {
            var idx = source.IndexOf(delimiter);

            if (idx == -1) return source;
            else
            {
                if (removeDelimiter) idx += delimiter.Length;
                return source.Substring(idx);
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters before the last occurrence of a specified delimiter removed. The delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiter">All characters before the last occurrence of this delimiter will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <returns>The string with all characters before the last occurrence of the delimiter removed. The delimiter may be removed as well.</returns>
        public static string RemoveBeforeLast(this string source, string delimiter, bool removeDelimiter = true)
        {
            var idx = source.LastIndexOf(delimiter, StringComparison.Ordinal);
            if (idx == -1) return source;
            else
            {
                if (removeDelimiter) idx += delimiter.Length;
                return source.Substring(idx);
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters before the first occurrence of any of the specified delimiters. 
        /// The matched delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiters">All characters before the first occurrence of any of these delimiters will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <param name="succeeded">Gets a value indicating whether at least one of the specified delimiters was found.</param>
        /// <returns>The string with all characters before the first occurrence of any of the delimiters removed. The matched delimiter may be removed as well.</returns>
        public static string RemoveBefore(this string source, IList<string> delimiters, bool removeDelimiter, out bool succeeded)
        {
            var rlt = source.IndexOfAny(delimiters, 0);
            if (rlt == null || rlt.Position == -1)
            {
                succeeded = false;
                return source;
            }
            else
            {
                succeeded = true;
                var pos = rlt.Position;
                if (removeDelimiter)
                    pos += rlt.Value.Length;
                return source.Substring(pos);
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters before the last occurrence of any of the specified delimiters. 
        /// The matched delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiters">All characters before the last occurrence of any of these delimiters will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <param name="succeeded">Gets a value indicating whether at least one of the specified delimiters was found.</param>
        /// <returns>The string with all characters before the last occurrence of any of the delimiters removed. The matched delimiter may be removed as well.</returns>
        public static string RemoveBeforeLast(this string source, IList<string> delimiters, bool removeDelimiter, out bool succeeded)
        {
            var rlt = source.LastIndexOfAny(delimiters, 0);
            if (rlt == null || rlt.Position == -1)
            {
                succeeded = false;
                return source;
            }
            else
            {
                succeeded = true;
                var pos = rlt.Position;
                if (removeDelimiter)
                    pos += rlt.Value.Length;
                return source.Substring(pos);
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters before the first occurrence of any of the specified delimiters. 
        /// The matched delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiters">All characters before the first occurrence of any of these delimiters will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <returns>The string with all characters before the first occurrence of any of the delimiters removed. The matched delimiter may be removed as well.</returns>
        public static string RemoveBefore(this string source, IList<string> delimiters, bool removeDelimiter)
        {
            var rlt = source.IndexOfAny(delimiters, 0);
            if (rlt == null || rlt.Position == -1) return source;
            else
            {
                var pos = rlt.Position;
                if (removeDelimiter)
                    pos += rlt.Value.Length;
                return source.Substring(pos);
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters before the last occurrence of any of the specified delimiters. 
        /// The matched delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiters">All characters before the last occurrence of any of these delimiters will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <returns>The string with all characters before the last occurrence of any of the delimiters removed. The matched delimiter may be removed as well.</returns>
        public static string RemoveBeforeLast(this string source, IList<string> delimiters, bool removeDelimiter)
        {
            var rlt = source.LastIndexOfAny(delimiters, 0);
            if (rlt == null || rlt.Position == -1) return source;
            else
            {
                var pos = rlt.Position;
                if (removeDelimiter)
                    pos += rlt.Value.Length;
                return source.Substring(pos);
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters before the first occurrence of any of the specified delimiters. 
        /// The delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiters">All characters before the first occurrence of any of these delimiters will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <param name="succeeded">Gets a value indicating whether at least one of the specified delimiters was found.</param>
        /// <returns>The string with all characters before the first occurrence of any of the delimiters removed. The matched delimiter may be removed as well.</returns>
        public static string RemoveBefore(this string source, char[] delimiters, bool removeDelimiter, out bool succeeded)
        {
            var idx = source.IndexOfAny(delimiters, 0);
            if (idx == -1)
            {
                succeeded = false;
                return source;
            }
            else
            {
                succeeded = true;
                if (removeDelimiter)
                    idx++;
                return source.Substring(idx);
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters before the last occurrence of any of the specified delimiters. 
        /// The delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiters">All characters before the last occurrence of any of these delimiters will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <param name="succeeded">Gets a value indicating whether at least one of the specified delimiters was found.</param>
        /// <returns>The string with all characters before the last occurrence of any of the delimiters removed. The matched delimiter may be removed as well.</returns>
        public static string RemoveBeforeLast(this string source, char[] delimiters, bool removeDelimiter, out bool succeeded)
        {
            var idx = source.LastIndexOfAny(delimiters, 0);
            if (idx == -1)
            {
                succeeded = false;
                return source;
            }
            else
            {
                succeeded = true;
                if (removeDelimiter)
                    idx++;
                return source.Substring(idx);
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters before the first occurrence of any of the specified delimiters. 
        /// The matched delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiters">All characters before the first occurrence of any of these delimiters will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <returns>The string with all characters before the first occurrence of any of the delimiters removed. The matched delimiter may be removed as well.</returns>
        public static string RemoveBefore(this string source, char[] delimiters, bool removeDelimiter)
        {
            var idx = source.IndexOfAny(delimiters, 0);
            if (idx == -1) return source;
            else
            {
                if (removeDelimiter) idx++;
                return source.Substring(idx);
            }
        }

        /// <summary>
        /// Returns a copy of the current string with all characters before the last occurrence of any of the specified delimiters. 
        /// The matched delimiter may be removed as well.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="delimiters">All characters before the last occurrence of any of these delimiters will be removed.</param>
        /// <param name="removeDelimiter">Indicating whether the delimiter is also removed.</param>
        /// <returns>The string with all characters before the last occurrence of any of the delimiters removed. The matched delimiter may be removed as well.</returns>
        public static string RemoveBeforeLast(this string source, char[] delimiters, bool removeDelimiter)
        {
            var idx = source.LastIndexOfAny(delimiters, 0);
            if (idx == -1) return source;
            else
            {
                if (removeDelimiter) idx++;
                return source.Substring(idx);
            }
        }

        #endregion

        #region Only

        /// <summary>
        /// Gets a value indicating whether this string instance contains only ASCII digits (namely 0-9).
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <returns><c>true</c> if this string instance contains only ASCII digits; otherwise, <c>false</c>.</returns>
        public static bool OnlyDigits(this string str)
        {
            for (int i = 0, j = str.Length; i < j; ++i)
            {
                char c = str[i];
                if (!(c <= '9' && c >= '0'))
                    return false;
            }
            return true;
        }

        //TEST: Not Needed
        /// <summary>
        /// Gets a value indicating whether this string instance contains only ASCII letters and digits (namely a-z, A-Z, 0-9).
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <returns><c>true</c> if this string instance contains only ASCII letters and digits; otherwise, <c>false</c>.</returns>
        public static bool OnlyASCIILettersAndDigits(this string str)
        {
            for (int i = 0, j = str.Length; i < j; ++i)
            {
                char c = str[i];
                if (!((c <= 'z' && c >= 'a') || (c <= 'Z' && c >= 'A') || (c <= '9' && c >= '0')))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Gets a value indicating whether this string instance contains only big ASCII letters (namely A-Z).
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns><c>true</c> if this string instance contains only big ASCII letters; otherwise, <c>false</c>.</returns>
        public static bool OnlyBigASCIILetters(this string str)
        {
            for (int i = 0, j = str.Length; i < j; ++i)
            {
                char c = str[i];
                if (c > 'Z' || c < 'A')
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Gets a value indicating whether this string instance contains no big ASCII letters (namely no A-Z).
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns><c>true</c> if this string instance contains no big ASCII letters; otherwise, <c>false</c>.</returns>
        public static bool NoBigASCIILetters(this string str)
        {
            for (int i = 0, j = str.Length; i < j; ++i)
            {
                char c = str[i];
                if (c <= 'Z' && c >= 'A')
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Gets a value indicating whether this string instance contains only small ASCII letters (namely a-z).
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns><c>true</c> if this string instance contains only small ASCII letters; otherwise, <c>false</c>.</returns>
        public static bool OnlySmallASCIILetters(this string str)
        {
            for (int i = 0, j = str.Length; i < j; ++i)
            {
                char c = str[i];
                if (c > 'z' || c < 'a')
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Gets a value indicating whether this string instance contains no small ASCII letters (namely no a-z).
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns><c>true</c> if this string instance contains no small ASCII letters; otherwise, <c>false</c>.</returns>
        public static bool NoSmallASCIILetters(this string str)
        {
            for (int i = 0, j = str.Length; i < j; ++i)
            {
                char c = str[i];
                if (c <= 'z' && c >= 'a')
                    return false;
            }
            return true;
        }

        //TEST: Not Needed
        /// <summary>
        /// Gets a value indicating whether this string instance contains only ASCII characters. Any character represented by integer larger than 255 is a non-ASCII character.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <returns><c>true</c> if this string instance contains only ASCII chars; otherwise, <c>false</c>.</returns>
        public static bool OnlyASCIIs(this string str)
        {
            for (int i = 0, j = str.Length; i < j; i++)
            {
                char c = str[i];
                if (c > 255) return false;
            }
            return true;
        }

        //TEST: Not Needed
        /// <summary>
        /// Gets a value indicating whether this string instance contains only letters and digits. 
        /// Whether a character is a letter or a number is determined by char.IsLetter and char.IsDigit methods.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <returns><c>true</c> if this string instance contains only letters and digits; otherwise, <c>false</c>.</returns>
        public static bool OnlyLettersAndDigits(this string str)
        {
            for (int i = 0, j = str.Length; i < j; i++)
            {
                if (!str[i].IsLetter() && !str[i].IsDigit())
                    return false;
            }
            return true;
        }

        #endregion

        #region Contains

        /// <summary>
        /// Returns a value indicating whether the specified string <paramref name="value"/> occurs within this string. 
        /// A parameter specifies options for string comparison.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="value">The string to seek.</param>
        /// <param name="comparisonType">Specifies how strings are compared.</param>
        /// <returns><c>true</c> if the <paramref name="value"/> parameter occurs within this string, or if value is the empty string (""); otherwise, <c>false</c>.</returns>
        public static bool Contains(this string str, string value, StringComparison comparisonType)
        {
            return str.IndexOf(value, comparisonType) != -1;
        }

        /// <summary>
        /// Gets a value indicating whether the specified value occurs in this string instance after 
        /// (or before, determined by <paramref name="fromBeginningToEnd"/>) the specified zero-based position. 
        /// This method allows you to set search direction and comparison options.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="value">The string to seek.</param>
        /// <param name="startIndex">Indicating the zero-based position where the search starts. 
        /// <para>Use -1 to indicate the default position. 
        /// If <paramref name="fromBeginningToEnd"/> is set true, the default position is 0; 
        /// otherwise, the default position is the end of this string instance.</para></param>
        /// <param name="comparisonType">Specifies the rules of search.</param>
        /// <param name="fromBeginningToEnd">Specifies the search direction. 
        /// If this parameter is set true, the search starts at <paramref name="startIndex"/> and ends at the end of this string instance; 
        /// otherwise, the search starts at <paramref name="startIndex"/> and proceeds toward the beginning of this string instance.</param>
        /// <returns><c>true</c> if the target value occurs in this string instance after 
        /// (or before, determined by <paramref name="fromBeginningToEnd"/>) the specified position; otherwise, false</returns>
        public static bool Contains(this string str, string value, int startIndex, bool fromBeginningToEnd = true,
            StringComparison comparisonType = StringComparison.CurrentCulture)
        {
            if (fromBeginningToEnd)
            {
                if (startIndex == -1) startIndex = 0;
                return str.IndexOf(value, startIndex, comparisonType) != -1;
            }
            else
            {
                if (startIndex == -1) startIndex = str.Length - 1;
                return str.LastIndexOf(value, startIndex, comparisonType) != -1;
            }
        }

        /// <summary>
        /// Determines whether this string instance contains all the specified strings.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The strings to seek.</param>
        /// <returns><c>true</c> if this string contains all the specified strings; otherwise, <c>false</c>.</returns>
        public static bool ContainsAll(this string str, IEnumerable<string> values)
        {
            foreach (var target in values)
                if (!str.Contains(target)) return false;
            return true;
        }

        /// <summary>
        /// Determines whether this string instance contains all the specified strings.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The strings to seek.</param>
        /// <returns><c>true</c> if this string contains all the specified strings; otherwise, <c>false</c>.</returns>
        public static bool ContainsAll(this string str, params string[] values)
        {
            for (int i = 0, j = values.Length; i < j; i++)
                if (!str.Contains(values[i])) return false;
            return true;
        }

        /// <summary>
        /// Determines whether this string instance contains all the specified strings. The search starts at the specified zero-based position.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The strings to seek.</param>
        /// <param name="startIndex">Indicating the zero-based position where the search starts.</param>
        /// <returns><c>true</c> if this string contains all the specified strings; otherwise, <c>false</c>.</returns>
        public static bool ContainsAll(this string str, IEnumerable<string> values, int startIndex)
        {
            int sidx;
            foreach (var target in values)
            {
                sidx = str.IndexOf(target, startIndex);
                if (sidx == -1) return false;
            }
            return true;
        }

        /// <summary>
        /// Determines whether this string instance contains all the specified strings sequentially.
        /// <para>** The difference between this method and ContainsAll is how the target values should occur. 
        /// For example, string "ab, ef, cd" contains "ab", "cd" and "ef" but does not contain "ab", "cd" and "ef" sequentially.</para>
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The strings to seek.</param>
        /// <param name="startIndex">Indicating the zero-based position where the search starts.</param>
        /// <returns><c>true</c> if this string contains all the specified strings sequentially; otherwise, <c>false</c>.</returns>
        public static bool ContainsAllSequentially(this string str, IList<string> values, int startIndex = 0)
        {
            foreach (var target in values)
            {
                startIndex = str.IndexOf(target, startIndex);
                if (startIndex == -1) return false;
                else startIndex += target.Length;
            }

            return true;
        }

        /// <summary>
        /// Determines whether this string instance contains all the specified strings sequentially.
        /// <para>** The difference between this method and ContainsAll is how the target values should occur. 
        /// For example, string "ab, ef, cd" contains "ab", "cd" and "ef" but does not contain "ab", "cd" and "ef" sequentially.</para>
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The strings to seek.</param>
        /// <param name="startIndex">Indicating the zero-based position where the search starts.</param>
        /// <returns><c>true</c> if this string contains all the specified strings sequentially; otherwise, <c>false</c>.</returns>
        public static bool ContainsAllSequentially(this string str, params string[] values)
        {
            var startIndex = 0;
            for (int i = 0, j = values.Length; i < j; i++)
            {
                var target = values[i];
                startIndex = str.IndexOf(target, startIndex);
                if (startIndex == -1) return false;
                else startIndex += target.Length;
            }

            return true;
        }

        /// <summary>
        /// Determines whether this string instance contains any of the specified strings.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The strings to seek.</param>
        /// <param name="comparisonType">Specifies how strings are compared.</param>
        /// <returns><c>true</c> if this string contains any of the specified strings; otherwise, <c>false</c>.</returns>
        public static bool ContainsAny(this string str, IEnumerable<string> values, StringComparison comparisonType = StringComparison.Ordinal)
        {
            foreach (var target in values)
            {
                if (str.Contains(target))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Determines whether this string instance contains any of the specified strings. 
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The strings to seek.</param>
        /// <returns><c>true</c> if this string contains any of the specified strings; otherwise, <c>false</c>.</returns>
        public static bool ContainsAny(this string str, params string[] values)
        {
            for (int i = 0, j = values.Length; i < j; i++)
            {
                if (str.Contains(values[i]))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Determines whether this string instance contains any of the specified strings.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The strings to seek.</param>
        /// <param name="comparisonType">Specifies how strings are compared.</param>
        /// <returns><c>true</c> if this string contains any of the specified strings; otherwise, <c>false</c>.</returns>
        public static bool ContainsAny(this string str, string[] values, StringComparison comparisonType)
        {
            for (int i = 0, j = values.Length; i < j; i++)
            {
                if (str.Contains(values[i], comparisonType))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Determines whether this string instance contains any of the specified strings. The search starts at the specified zero-based position.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The strings to seek.</param>
        /// <param name="startIndex">Indicating the zero-based position where the search starts.</param>
        /// <returns><c>true</c> if this string contains any of the specified strings after the specified position; otherwise, <c>false</c>.</returns>
        public static bool ContainsAny(this string str, IEnumerable<string> values, int startIndex)
        {
            int sidx;
            foreach (var target in values)
            {
                sidx = str.IndexOf(target, startIndex);
                if (sidx != -1)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Determines whether this string instance 
        /// contains any/all/the first one/the last one of the strings specified in a System.StringSeekOption object. 
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="option">Indicating the substring to search, the strings to seek and search mode.</param>
        /// <returns><c>true</c> if the search succeeds; otherwise, <c>false</c>.</returns>
        public static bool ContainsByOption(this string str, StringSeekOption option)
        {
            var sidx = option.StartIndicator.IsNullOrEmpty() ? option.StartPosition :
                str.IndexOf(option.StartIndicator, option.StartPosition);
            if (sidx < 0) return false;
            sidx += option.StartIndicator.Length;

            var eidx = option.EndIndicator.IsNullOrEmpty() ? str.Length : str.IndexOf(option.EndIndicator, sidx);
            if (eidx < 0) return false;

            switch (option.Mode)
            {
                case StringSeekMode.Any:
                    {
                        foreach (var target in option.Values)
                        {
                            var idx = str.IndexOf(target, sidx);
                            if (idx != -1 && idx < eidx)
                                return true;
                        }
                        return false;
                    }
                case StringSeekMode.All:
                    {
                        foreach (var target in option.Values)
                        {
                            var idx = str.IndexOf(target, sidx);
                            if (idx == -1 || idx >= eidx)
                                return false;
                        }
                        return true;
                    }
                case StringSeekMode.First:
                    {
                        var idx = str.IndexOf(option.Values[0], sidx);
                        return idx != -1 && idx < eidx;
                    }
                case StringSeekMode.Last:
                    {
                        var idx = str.IndexOf(option.Values.Last(), sidx);
                        return idx != -1 && idx < eidx;
                    }
                case StringSeekMode.SequentialAll:
                    {
                        foreach (var target in option.Values)
                        {
                            sidx = str.IndexOf(target, sidx);
                            if (sidx == -1 || sidx >= eidx)
                                return false;
                            else sidx += target.Length;
                        }

                        return true;
                    }
                default:
                    return false;
            }
        }

        #endregion

        #region Concatenation

        /// <summary>
        /// Concates the current sequence of strings into a single string.
        /// </summary>
        /// <param name="collection">This sequence of strings.</param>
        /// <returns>The concatenation result of the current string sequence.</returns>
        public static string Concat(this IEnumerable<string> collection)
        {
            var sb = new StringBuilder();
            foreach (var str in collection)
                sb.Append(str);
            return sb.ToString();
        }

        /// <summary>
        /// Concates the current sequence of strings into a single string.
        /// </summary>
        /// <param name="collection">This sequence of strings.</param>
        /// <param name="connector">A Unicode character that links all strings in the current sequence together. 
        /// For example, concating string array {"ab", "cd", "ef"} with connector ',' returns "ab,cd,ef".</param>
        /// <returns>The concatenation result of the current string sequence.</returns>
        public static string Concat(this IEnumerable<string> collection, char connector)
        {
            var sb = new StringBuilder();
            var count = collection.Count();
            int i = 0;
            foreach (var str in collection)
            {
                i++;
                sb.Append(str);
                if (i != count) sb.Append(connector);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Concatenates this string array/list to a single System.String instance.
        /// </summary>
        /// <param name="array">The string array to concatenate.</param>
        /// <param name="multiline"><c>true</c> if a new line should be created for each instance in the string array to concatenate; otherwise, <c>false</c>.</param>
        /// <param name="trim"><c>true</c> if all leading and ending white-spaces should be removed from each instance of the provided string array when concatenating them; otherwise, <c>false</c>.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be excluded from the concatenation; otherwise, <c>false</c>.</param>
        /// <returns>The concatenated string.</returns>
        public static string Concat(this IList<string> array, bool multiline = true, bool trim = false, bool removeEmptyEntries = true)
        {
            int len = array.Count - 1;
            StringBuilder sb = new StringBuilder();
            string str;
            for (int i = 0; i < len; ++i)
            {
                str = array[i];
                if (trim) str = str.Trim();
                if (removeEmptyEntries && str.IsNullOrEmpty()) continue;
                sb.Append(str);
                if (multiline)
                    sb.Append(Environment.NewLine);
            }

            str = array[len];
            if (trim) str = str.Trim();
            if (!removeEmptyEntries || !str.IsNullOrEmpty())
                sb.Append(str);

            return sb.ToString();
        }

        /// <summary>
        /// Concatenates this string array/list to a single System.String instance.
        /// </summary>
        /// <param name="array">The string array to concatenate.</param>
        /// <param name="connector">The character that is appended to the end of each string instance in the string array.</param>
        /// <param name="multiline"><c>true</c> if a new line should be created for each instance in the string array to concatenate; otherwise, <c>false</c>.</param>
        /// <param name="trim"><c>true</c> if all leading and ending white-spaces should be removed from each instance of the provided string array when concatenating them; otherwise, <c>false</c>.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be excluded from the concatenation; otherwise, <c>false</c>.</param>
        /// <returns>
        /// The concatenated string.
        /// </returns>
        public static string Concat(this IList<string> array, char connector, bool multiline = false, bool trim = false, bool removeEmptyEntries = true)
        {
            int len = array.Count;
            if (len == 0)
                return string.Empty;
            StringBuilder sb = new StringBuilder();
            --len;
            string str;

            for (int i = 0; i < len; ++i)
            {
                str = array[i];
                if (trim) str = str.Trim();
                if (!removeEmptyEntries || str.Length != 0)
                {
                    sb.Append(str);
                    sb.Append(connector);
                    if (multiline) sb.Append(Environment.NewLine);
                }
            }

            if (trim) str = array[len].Trim();
            else str = array[len];
            sb.Append(str);

            return sb.ToString();
        }

        /// <summary>
        /// Concatenates this string array/list to a single System.String instance.
        /// </summary>
        /// <param name="array">The string array to concatenate.</param>
        /// <param name="connector">The additional string that is appended to the end of each string instance in the string array.</param>
        /// <param name="multiline"><c>true</c> if a new line should be created for each instance in the string array to concatenate; otherwise, <c>false</c>.</param>
        /// <param name="trim"><c>true</c> if all leading and ending white-spaces should be removed from each instance of the provided string array when concatenating them; otherwise, <c>false</c>.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be excluded from the concatenation; otherwise, <c>false</c>.</param>
        /// <returns>
        /// The concatenated string.
        /// </returns>
        public static string Concat(this IList<string> array, string connector, bool multiline = true, bool trim = false, bool removeEmptyEntries = true)
        {
            int len = array.Count;
            StringBuilder sb = new StringBuilder();
            len--;
            string str;

            for (int i = 0; i < len; i++)
            {
                str = array[i];
                if (trim) str = str.Trim();
                if (!removeEmptyEntries || str.Length != 0)
                {
                    sb.Append(str);
                    sb.Append(connector);
                    if (multiline) sb.Append(Environment.NewLine);
                }
            }
            if (trim) str = array[len].Trim();
            else str = array[len];
            sb.Append(array[len]);

            return sb.ToString();
        }

        /// <summary>
        /// Concatenates the string representations of each of this object array/list to a single System.String instance.
        /// </summary>
        /// <param name="array">This object array/list.</param>
        /// <param name="connector">The character that is appended to the end of each string instance representing an object.</param>
        /// <param name="multiline">Sets this <c>true</c> if each sting representation should be followed by a new line; otherwise, <c>false</c>.</param>
        /// <param name="removeBlankEntry">Indicates whether to remove blank string representations.</param>
        /// <returns>The concatenated string representations of elements in the object array/list.</returns>
        public static string ConcatAsString(this IList<object> array, char connector, bool multiline = true, bool removeBlankEntry = true)
        {
            var strArr = new string[10];
            var sb = new StringBuilder();
            for (int i = 0, j = array.Count; i < j; i++)
            {
                var str = array[i].ToString();
                if (removeBlankEntry && str.IsNullOrEmpty())
                    continue;
                sb.Append(str);
                if (i != j - 1)
                {
                    sb.Append(connector);
                    if (multiline)
                        sb.Append(Environment.NewLine);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Concatenates the string representations of each of this object array/list to a single System.String instance.
        /// </summary>
        /// <param name="array">This object array/list.</param>
        /// <param name="multiline">Sets this <c>true</c> if each sting representation should be followed by a new line; otherwise, <c>false</c>.</param>
        /// <param name="removeBlankEntry">Indicates whether to remove blank string representations.</param>
        /// <returns>The concatenated string representations of elements in the object array/list.</returns>
        public static string ConcatAsString(this IList<object> array, bool multiline = true, bool removeBlankEntry = true)
        {
            var strArr = new string[10];
            var sb = new StringBuilder();
            for (int i = 0, j = array.Count; i < j; i++)
            {
                var str = array[i].ToString();
                if (removeBlankEntry && str.IsNullOrEmpty())
                    continue;
                sb.Append(str);
                if (i != j - 1)
                {
                    if (multiline)
                        sb.Append(Environment.NewLine);
                }
            }
            return sb.ToString();
        }

        #endregion


        #region Retrieval

        /// <summary>
        /// Retrieves a substring represented by a System.Substring object from this string instance.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="option">Indicating a variety of options for the retrieval operation.</param>
        /// <returns>The retrieved substring represented by a System.Substring object.</returns>
        public static SubString RetrieveFirst(this string source, StringRetrievalOption option)
        {
            int idx;
            if (option.Locator.IsNullOrEmpty())
                idx = 0;
            else
            {
                idx = source.IndexOf(option.Locator, option.StartIndex);
                if (idx == -1) return null;
                else idx += option.Locator.Length;
            }

            var bidx = option.Boundary.IsNullOrEmpty() ? source.Length - 1 : source.IndexOf(option.Boundary, idx);
            if (bidx == -1) bidx = source.Length - 1;

            var srlt = source.IndexOfAny(option.StartIndicator, idx);
            var sidx = srlt.Position;
            if (sidx == -1 || sidx >= bidx) return null;

            var erlt = source.IndexOfAny(option.EndIndicator, sidx + srlt.Value.Length);
            var eidx = erlt.Position;
            if (eidx == -1 || eidx >= bidx) return null;


            if (!option.IncludeStartIndicator)
                sidx += srlt.Value.Length;

            if (option.IncludeEndIndicator)
                eidx += erlt.Value.Length;

            return new SubString(source, sidx, eidx, true);
        }

        /// <summary>
        /// Retrieves a substring represented by a System.Substring object from this string instance.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="startIndex">Indicating the position where the search starts.</param>
        /// <param name="locator">The search starts after the first occurrence of this string instance after the start position.</param>
        /// <param name="boundary">The search ends at the first occurrence of this string instance.</param>
        /// <param name="startIndicator">The start indicator of the target substring.</param>
        /// <param name="endIndicator">The end indicator of the target substring.</param>
        /// <param name="includeStartIndicator">Indicating whether the start indicator is included in the substring.</param>
        /// <param name="includeEndIndicator">Indicating whether the end indicator is included in the substring.</param>
        /// <returns>The retrieved substring represented by a System.Substring object.</returns>
        public static SubString RetrieveFirst(this string source, int startIndex,
            string locator, string boundary,
            string startIndicator, string endIndicator,
            bool includeStartIndicator = false, bool includeEndIndicator = false)
        {
            int idx;
            if (locator.IsNullOrEmpty())
                idx = 0;
            else
            {
                idx = source.IndexOf(locator, startIndex);
                if (idx == -1) return null;
                else idx += locator.Length;
            }

            var bidx = boundary.IsNullOrEmpty() ? source.Length - 1 : source.IndexOf(boundary, idx);
            if (bidx == -1) bidx = source.Length - 1;

            int sidx;
            if (startIndicator.Length == 1)
                sidx = source.IndexOf(startIndicator[0], idx);
            else
                sidx = source.IndexOf(startIndicator, idx);
            if (sidx == -1 || sidx >= bidx) return null;

            int eidx;
            if (endIndicator.Length == 1)
                eidx = source.IndexOf(endIndicator[0], sidx + startIndicator.Length);
            else
                eidx = source.IndexOf(endIndicator, sidx + startIndicator.Length);
            if (eidx == -1 || eidx >= bidx) return null;

            if (!includeStartIndicator)
                sidx += startIndicator.Length;

            if (includeEndIndicator)
                eidx += endIndicator.Length;

            return new SubString(source, sidx, eidx, true);
        }

        /// <summary>
        /// Retrieves substrings represented by System.Substring objects from this string instance.
        /// The search proceeds accroding to the indicators in the System.RetrieveOption objects.
        /// <para>This method first retrieves the an array of substrings according to the indicators in the first System.RetrieveOption object.
        /// If the previous search ends at position p1, 
        /// then this method continutes to retrieve the second array of substrings 
        /// according to the indicators in the second System.RetrieveOption object, starting from the postion p1.</para>
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="startIndex">Indicating the position where the search starts.</param>
        /// <param name="locator">The search starts after the first occurrence of this string instance after the start position.</param>
        /// <param name="boundary">The search ends at the first occurrence of this string instance.</param>
        /// <param name="options">An array of System.RetrieveOption objects that store search indicators.</param>
        /// <returns>The retrieved substrings represented by System.Substring objects.</returns>
        public static SubString[][] Retrieve(this string source, int startIndex,
            string locator, string boundary,
            StringRetrievalOption[] options)
        {
            int idx;
            if (locator.IsNullOrEmpty())
                idx = 0;
            else
            {
                idx = source.IndexOf(locator, startIndex);
                if (idx == -1) return null;
                else idx += locator.Length;
            }

            var bidx = boundary.IsNullOrEmpty() ? source.Length - 1 : source.IndexOf(boundary, idx);
            if (bidx == -1) bidx = source.Length - 1;

            var sublist = new List<SubString>();
            var rlt = new SubString[options.Length][];

            for (int i = 0; i < options.Length; i++)
            {
                int count = 0;
                while (true)
                {
                    var thisinfo = options[i];
                    var startIndicator = thisinfo.StartIndicator;
                    var endIndicator = thisinfo.EndIndicator;

                    var sidx = source.IndexOfAny(startIndicator, idx);
                    if (sidx == null || (bidx != -1 && sidx.Position >= bidx)) break;

                    var eidx = source.IndexOfAny(endIndicator, sidx.Position + sidx.Value.Length);
                    if (eidx == null || (bidx != -1 && eidx.Position >= bidx)) break;

                    var sub = new SubString(source,
                        thisinfo.IncludeStartIndicator ? sidx.Position : sidx.Position + sidx.Value.Length,
                        thisinfo.IncludeEndIndicator ? eidx.Position + eidx.Value.Length : eidx.Position, true);
                    sublist.Add(sub);
                    idx = sub.EndIndex;
                    count++;
                    if (count == thisinfo.MaximumReturn)
                        break;
                }
                if (sublist.Count == 0) rlt[i] = null;
                else rlt[i] = sublist.ToArray();
                sublist.Clear();
            }

            return rlt;
        }

        /// <summary>
        /// Retrieves substrings represented by System.Substring objects from this string instance.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="startIndex">Indicating the position where the search starts.</param>
        /// <param name="locator">The search starts after the first occurrence of this string instance after the start position.</param>
        /// <param name="boundary">The search ends at the first occurrence of this string instance.</param>
        /// <param name="startIndicator">The start indicator of the target substring.</param>
        /// <param name="endIndicators">The end indicators of the target substring.</param>
        /// <param name="includeStartIndicator">Indicating whether the start indicator is included in the substring.</param>
        /// <param name="includeEndIndicators">Indicating whether the end indicators are included in the substrings.</param>
        /// <returns>The retrieved substrings represented by System.Substring objects.</returns>
        public static SubString[] Retrieve(this string source, int startIndex,
            string locator, string boundary,
            string startIndicator, string[] endIndicator,
            bool includeStartIndicator = false, bool includeEndIndicators = false)
        {
            int idx;
            if (locator.IsNullOrEmpty())
                idx = 0;
            else
            {
                idx = source.IndexOf(locator, startIndex);
                if (idx == -1) return null;
                else idx += locator.Length;
            }

            var bidx = boundary.IsNullOrEmpty() ? source.Length - 1 : source.IndexOf(boundary, idx);
            if (bidx == -1) bidx = source.Length - 1;

            var sublist = new List<SubString>();

            while (true)
            {
                var sidx = source.IndexOf(startIndicator, idx);
                if (sidx == -1 || (bidx != -1 && sidx >= bidx)) break;

                var eidx = source.IndexOfAny(endIndicator, sidx + startIndicator.Length);
                if (eidx == null || eidx.Position == -1 || (bidx != -1 && eidx.Position >= bidx)) break;

                var sub = new SubString(source, includeStartIndicator ? sidx : sidx + startIndicator.Length,
                    includeEndIndicators ? eidx.Position + eidx.Value.Length : eidx.Position, true);
                sublist.Add(sub);
                idx = sub.EndIndex;
            }

            if (sublist.Count == 0) return null;
            else return sublist.ToArray();
        }

        /// <summary>
        /// Retrieves substrings represented by System.Substring objects from this string instance.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="startIndex">Indicating the position where the search starts.</param>
        /// <param name="locator">The search starts after the first occurrence of this string instance after the start position.</param>
        /// <param name="boundary">The search ends at the first occurrence of this string instance.</param>
        /// <param name="startIndicators">The start indicators of the target substring.</param>
        /// <param name="endIndicators">The end indicators of the target substring.</param>
        /// <param name="includeStartIndicators">Indicating whether the start indicators are included in the substrings.</param>
        /// <param name="includeEndIndicators">Indicating whether the end indicators are included in the substrings.</param>
        /// <returns>The retrieved substrings represented by System.Substring objects.</returns>
        public static SubString[] Retrieve(this string source, int startIndex,
            string locator, string boundary,
            string[] startIndicators, string[] endIndicators,
            bool includeStartIndicators = false, bool includeEndIndicators = false)
        {
            int idx;
            if (locator.IsNullOrEmpty())
                idx = 0;
            else
            {
                idx = source.IndexOf(locator, startIndex);
                if (idx == -1) return null;
                else idx += locator.Length;
            }

            var bidx = boundary.IsNullOrEmpty() ? source.Length - 1 : source.IndexOf(boundary, idx);
            if (bidx == -1) bidx = source.Length - 1;

            var sublist = new List<SubString>();

            while (true)
            {

                var sidx = source.IndexOfAny(startIndicators, idx);
                if (sidx == null || sidx.Position == -1 || (bidx != -1 && sidx.Position >= bidx)) break;

                var eidx = source.IndexOfAny(endIndicators, sidx.Position + sidx.Value.Length);
                if (eidx == null || eidx.Position == -1 || (bidx != -1 && eidx.Position >= bidx)) break;

                var sub = new SubString(source, includeStartIndicators ? sidx.Position : sidx.Position + sidx.Value.Length,
                    includeEndIndicators ? eidx.Position + eidx.Value.Length : eidx.Position);
                sublist.Add(sub);
                idx = sub.EndIndex;
            }

            if (sublist.Count == 0) return null;
            else return sublist.ToArray();
        }

        /// <summary>
        /// Retrieves substrings represented by System.Substring objects from this string instance.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="startIndex">Indicating the position where the search starts.</param>
        /// <param name="locator">The search starts after the first occurrence of this string instance after the start position.</param>
        /// <param name="boundary">The search ends at the first occurrence of this string instance.</param>
        /// <param name="startIndicators">The start indicators of the target substring.</param>
        /// <param name="endIndicator">The end indicator of the target substring.</param>
        /// <param name="includeStartIndicator">Indicating whether the start indicator is included in the substring.</param>
        /// <param name="includeEndIndicator">Indicating whether the end indicator is included in the substring.</param>
        /// <returns>The retrieved substrings represented by System.Substring objects.</returns>
        public static SubString[] Retrieve(this string source, int startIndex,
            string locator, string boundary,
            string[] startIndicators, string endIndicator,
            bool includeStartIndicator = false, bool includeEndIndicator = false)
        {
            int idx;
            if (locator.IsNullOrEmpty())
                idx = 0;
            else
            {
                idx = source.IndexOf(locator, startIndex);
                if (idx == -1) return null;
                else idx += locator.Length;
            }

            var bidx = boundary.IsNullOrEmpty() ? source.Length - 1 : source.IndexOf(boundary, idx);
            if (bidx == -1) bidx = source.Length - 1;

            var sublist = new List<SubString>();

            while (true)
            {
                var sidx = source.IndexOfAny(startIndicators, idx);
                if (sidx == null || sidx.Position == -1 || (bidx != -1 && sidx.Position >= bidx)) break;

                var eidx = source.IndexOf(endIndicator, sidx.Position + sidx.Value.Length);
                if (eidx == -1 || (bidx != -1 && eidx >= bidx)) break;

                var sub = new SubString(source, includeStartIndicator ? sidx.Position : sidx.Position + sidx.Value.Length,
                    includeEndIndicator ? eidx + endIndicator.Length : eidx, true);
                sublist.Add(sub);
                idx = sub.EndIndex;
            }

            if (sublist.Count == 0) return null;
            else return sublist.ToArray();
        }

        /// <summary>
        /// Retrieves substrings represented by System.Substring objects from this string instance.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="startIndex">Indicating the position where the search starts.</param>
        /// <param name="locator">The search starts after the first occurrence of this string instance after the start position.</param>
        /// <param name="boundary">The search ends at the first occurrence of this string instance.</param>
        /// <param name="startIndicator">The start indicator of the target substring.</param>
        /// <param name="endIndicator">The end indicator of the target substring.</param>
        /// <param name="includeStartIndicator">Indicating whether the start indicator is included in the substring.</param>
        /// <param name="includeEndIndicator">Indicating whether the end indicator is included in the substring.</param>
        /// <returns>The retrieved substrings represented by System.Substring objects.</returns>
        public static SubString[] Retrieve(this string source, int startIndex,
            string locator, string boundary,
            string startIndicator, string endIndicator,
            bool includeStartIndicator = false, bool includeEndIndicator = false)
        {
            int idx;
            if (locator.IsNullOrEmpty())
                idx = 0;
            else
            {
                idx = source.IndexOf(locator, startIndex);
                if (idx == -1) return null;
                else idx += locator.Length;
            }

            var bidx = boundary.IsNullOrEmpty() ? source.Length - 1 : source.IndexOf(boundary, idx);
            if (bidx == -1) bidx = source.Length - 1;

            var sublist = new List<SubString>();

            while (true)
            {

                var sidx = source.IndexOf(startIndicator, idx);
                if (sidx == -1 || sidx >= bidx) break;

                var eidx = source.IndexOf(endIndicator, sidx + startIndicator.Length);
                if (eidx == -1 || eidx >= bidx) break;

                var sub = new SubString(source, includeStartIndicator ? sidx : sidx + startIndicator.Length,
                    includeEndIndicator ? eidx + endIndicator.Length : eidx, true);
                sublist.Add(sub);
                idx = sub.EndIndex;
            }

            if (sublist.Count == 0) return null;
            else return sublist.ToArray();
        }

        #endregion

        #region IndexOf

        /// <summary>
        /// Reports the first occurrence's index of any/all/the first one/the last one of the target strings specified 
        /// in the System.StringSeekOption object within a specified segment of this string instance.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="option">Indicating the segment to search, the target string and the search mode.</param>
        /// <returns>A System.StringSearchResult object that stores the search result; 
        /// null if the search fails.</returns>
        public static StringSearchResult IndexOfByOption(this string str, StringSeekOption option)
        {
            var sidx = option.StartIndicator.IsNullOrEmpty() ? option.StartPosition :
                str.IndexOf(option.StartIndicator, option.StartPosition);
            if (sidx < 0) return null;
            sidx += option.StartIndicator.Length;

            var eidx = option.EndIndicator.IsNullOrEmpty() ? str.Length : str.IndexOf(option.EndIndicator, sidx);
            if (eidx < 0) return null;

            switch (option.Mode)
            {
                case StringSeekMode.Any:
                    {
                        int hitPos = 0;
                        string hit = null;
                        var idx = 0;
                        var values = option.Values;
                        for (int i = 0, j = values.Length; i < j;)
                        {
                            var value = values[i];
                            var pos = str.IndexOf(value, sidx);
                            if (pos != -1 && pos < eidx)
                            {
                                hitPos = Math.Min(hitPos, pos);
                                hit = value;

                            }
                            ++i;
                        }
                        if (hit == null) return null;
                        else return new StringSearchResult() { Value = hit, Position = hitPos, HitIndex = idx };
                    }
                case StringSeekMode.First:
                    {
                        var idx = str.IndexOf(option.Values[0], sidx);
                        if (idx != -1 && idx < eidx)
                            return new StringSearchResult() { Value = option.Values[0], Position = idx, HitIndex = 0 };
                        else return null;
                    }
                case StringSeekMode.Last:
                    {
                        var lastValueIdx = option.Values.Length - 1;
                        var target = option.Values[lastValueIdx];
                        var idx = str.IndexOf(target, sidx);
                        if (idx != -1 && idx < eidx)
                            return new StringSearchResult() { Value = target, Position = idx, HitIndex = lastValueIdx };
                        else return null;
                    }
                default:
                    {
                        throw new NotSupportedException();
                    }
            }
        }

        /// <summary>
        /// Reports the indexes of the first occurrences of several specified strings in this string instance.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The strings to seek.</param>
        /// <param name="mode">Indicating search mode. 
        /// In the default sequential mode, the next search starts at the position where the previous search ends.</param>
        /// <para>For example, if we search string "Visual Microsoft Visual Studio" for "Microsoft" and "Visual", 
        /// in normal mode the result is 7 and 0 while in sequential mode the result is 7 and 17.</para>
        /// <param name="startIndex">Indicating the position where the search starts.</param>
        /// <returns>An array of integers indicating the indexes of occurrences of all specified strings.</returns>
        public static int[] IndexOfAll(this string str, IList<string> values,
            IndexOfAllMode mode = IndexOfAllMode.Sequential, int startIndex = 0)
        {
            var len = values.Count;
            var rlt = new int[len];

            if (mode == IndexOfAllMode.Normal)
            {
                for (int i = 0; i < len; i++)
                    rlt[i] = str.IndexOf(values[i], startIndex);
            }
            else if (mode == IndexOfAllMode.Sequential)
            {
                var idx = startIndex;
                int pidx;
                for (int i = 0; i < len; i++)
                {
                    pidx = idx;
                    idx = str.IndexOf(values[i], idx);
                    rlt[i] = idx;
                    if (idx == -1) idx = pidx;
                }
            }
            else
                return null;

            return rlt;
        }

        #endregion

        #region Data Types

        /// <summary>
        /// Converts the string representation of a sequence of System.DateTime values delimited by <paramref name="separator"/> to equivalent System.DateTime objects.
        /// For example, input "11/3/2012, 07/08/1997, 01/15/2013" with comma ',' as the separator will return a System.DateTime array {11/3/2012, 07/08/1997, 01/15/2013}.
        /// </summary>
        /// <param name="str">The string representing time.</param>
        /// <param name="separator">The character used to separate time representations.</param>
        /// <returns>An array System.DateTime objects.</returns>
        public static DateTime[] ToDateTimeArray(this string str, char separator)
        {
            var eles = str.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            var arr = new DateTime[eles.Length];
            for (int i = 0; i < eles.Length; i++)
                arr[i] = Convert.ToDateTime(eles[i]);
            return arr;
        }

        /// <summary>
        /// Converts the string representation of byte numbers delimited by <paramref name="separator"/> to equivalent 8-bit unsigned integer array.
        /// For example, input "1, 2, 3" with comma ',' as the separator will return a 8-bit integer array 1, 2, 3.
        /// </summary>
        /// <param name="str">The string representing byte numbers.</param>
        /// <param name="separator">The character used to separate numbers.</param>
        /// <returns>An array of 8-bit unsigned integers.</returns>
        public static Byte[] ToByteArray(this string str, char separator)
        {
            var eles = str.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            var arr = new Byte[eles.Length];
            for (int i = 0; i < eles.Length; i++)
                arr[i] = Convert.ToByte(eles[i]);
            return arr;
        }

        /// <summary>
        /// Converts the string representation of byte numbers delimited by <paramref name="separator"/> to equivalent 8-bit integer array.
        /// For example, input "1, 2, -3" with comma ',' as the separator will return a 8-bit integer array 1, 2, -3.
        /// </summary>
        /// <param name="str">The string representing byte numbers.</param>
        /// <param name="separator">The character used to separate numbers.</param>
        /// <returns>An array of 8-bit signed integers.</returns>
        public static SByte[] ToSByteArray(this string str, char separator)
        {
            var eles = str.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            var arr = new SByte[eles.Length];
            for (int i = 0; i < eles.Length; i++)
                arr[i] = Convert.ToSByte(eles[i]);
            return arr;
        }

        /// <summary>
        /// Converts the string representation of numbers delimited by <pararef name="separator" /> to equivalent 64-bit integer array.
        /// For example, input "100, 200, -300" with comma ',' as the separator will return a 64-bit integer array { 100, 200, -300 }.
        /// </summary>
        /// <param name="str">The string representing 64-bit numbers.</param>
        /// <param name="separator">The character used to separate numbers.</param>
        /// <returns>An array of 64-bit integers.</returns>
        public static Int64[] ToInt64Array(this string str, char separator)
        {
            var eles = str.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            var arr = new Int64[eles.Length];
            for (int i = 0; i < eles.Length; i++)
                arr[i] = Convert.ToInt64(eles[i]);
            return arr;
        }

        /// <summary>
        /// Converts an array of strings to an array of equivalent 64-bit integers.
        /// </summary>
        /// <param name="strs">The strings to convert.</param>
        /// <returns>An array of 64-bit integers.</returns>
        public static Int64[] ToInt64Array(this string[] strs)
        {
            var arr = new Int64[strs.Length];
            for (int i = 0; i < strs.Length; ++i)
                arr[i] = Convert.ToInt64(strs[i]);
            return arr;
        }

        /// <summary>
        /// Tries to convert the string representation of numbers delimited by <pararef name="separator" /> to equivalent 64-bit integer array.
        /// For example, input "100, 200, -300" with comma ',' as the separator will return a 32-bit integer array { 100, 200, -300 }.
        /// </summary>
        /// <param name="str">The string representing 64-bit numbers.</param>
        /// <param name="separator">The character used to separate numbers.</param>
        /// <returns>An array of 64-bit integers if the conversion is successful; or <c>null</c> if the conversion failed.</returns>
        public static Int64[] TryInt64Array(this string str, char separator)
        {
            var eles = str.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            var arr = new Int64[eles.Length];
            for (int i = 0; i < eles.Length; ++i)
            {
                long val;
                if (Int64.TryParse(eles[i], out val)) arr[i] = val;
                else return null;
            }
            return arr;
        }

        /// <summary>
        /// Converts the string representation of numbers delimited by white spaces to equivalent 32-bit integer array.
        /// For example, input "100 200 -300" will return a 32-bit integer array { 100, 200, -300 }.
        /// </summary>
        /// <param name="str">The string representing 32-bit numbers.</param>
        /// <returns>An array of 32-bit integers.</returns>
        public static Int32[] ToInt32Array(this string str)
        {
            var eles = str.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
            var arr = new Int32[eles.Length];
            for (int i = 0; i < eles.Length; ++i)
                arr[i] = Convert.ToInt32(eles[i]);
            return arr;
        }

        /// <summary>
        /// Converts an array of strings to an array of equivalent 32-bit integers.
        /// </summary>
        /// <param name="strs">The strings to convert.</param>
        /// <returns>An array of 32-bit integers.</returns>
        public static Int32[] ToInt32Array(this string[] strs)
        {
            var arr = new Int32[strs.Length];
            for (int i = 0; i < strs.Length; ++i)
                arr[i] = Convert.ToInt32(strs[i]);
            return arr;
        }

        /// <summary>
        /// Tries to convert the string representation of numbers delimited by white spaces to equivalent 32-bit integer array.
        /// For example, input "100 200 -300" will return a 32-bit integer array { 100, 200, -300 }.
        /// </summary>
        /// <param name="str">The string representing 32-bit numbers.</param>
        /// <returns>An array of 32-bit integers if the conversion is successful; or <c>null</c> if the conversion failed.</returns>
        public static Int32[] TryInt32Array(this string str)
        {
            var eles = str.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
            var arr = new Int32[eles.Length];
            for (int i = 0; i < eles.Length; ++i)
            {
                if (Int32.TryParse(eles[i], out int val)) arr[i] = val;
                else return null;
            }
            return arr;
        }

        /// <summary>
        /// Converts the string representation of numbers delimited by <paramref name="separator" /> to equivalent 32-bit integer array.
        /// For example, input "100, 200, -300" with comma ',' as the separator will return a 32-bit integer array { 100, 200, -300 }.
        /// </summary>
        /// <param name="str">The string representing 32-bit numbers.</param>
        /// <param name="separator">The character used to separate numbers.</param>
        /// <returns>An array of 32-bit integers.</returns>
        public static Int32[] ToInt32Array(this string str, char separator)
        {
            var eles = str.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            var arr = new Int32[eles.Length];
            for (int i = 0; i < eles.Length; ++i)
                arr[i] = Convert.ToInt32(eles[i]);
            return arr;
        }

        /// <summary>
        /// Tries to convert the string representation of numbers delimited by <paramref name="separator" /> to equivalent 32-bit integer array.
        /// For example, input "100, 200, -300" with comma ',' as the separator will return a 32-bit integer array { 100, 200, -300 }.
        /// </summary>
        /// <param name="str">The string representing 32-bit numbers.</param>
        /// <param name="separator">The character used to separate numbers.</param>
        /// <returns>An array of 32-bit integers if the conversion is successful; or <c>null</c> if the conversion failed.</returns>
        public static Int32[] TryInt32Array(this string str, char separator)
        {
            var eles = str.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            var arr = new Int32[eles.Length];
            for (int i = 0; i < eles.Length; ++i)
            {
                if (Int32.TryParse(eles[i], out int val)) arr[i] = val;
                else return null;
            }
            return arr;
        }

        /// <summary>
        /// Converts the string representation of numbers delimited by <pararef name="separator" /> to equivalent System.Double array.
        /// For example, input "1.035, 2.046, 30.322" with comma ',' as the separator will return a double-precision floating-point number 1.035, 2.046, 30.322.
        /// </summary>
        /// <param name="str">The string representation of double-precision floating-point numbers.</param>
        /// <param name="separator">The character used to separate numbers.</param>
        /// <returns>A System.Double array.</returns>
        public static Double[] ToDoubleArray(this string str, char separator)
        {
            var eles = str.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            var arr = new Double[eles.Length];
            for (int i = 0; i < eles.Length; i++)
                arr[i] = Convert.ToDouble(eles[i]);
            return arr;
        }

        /// <summary>
        /// Converts the string representation of numbers delimited by <pararef name="separator" /> to equivalent System.Single array.
        /// For example, input "1.03, 2.04, 30.3" with comma ',' as the separator will return a single-precision floating-point number 1.03, 2.04, 30.3.
        /// </summary>
        /// <param name="str">The string representation of single-precision floating-point numbers.</param>
        /// <param name="separator">The character used to separate numbers.</param>
        /// <returns>A System.Single array.</returns>
        public static Single[] ToSingleArray(this string str, char separator)
        {
            var eles = str.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            var arr = new Single[eles.Length];
            for (int i = 0; i < eles.Length; i++)
                arr[i] = Convert.ToSingle(eles[i]);
            return arr;
        }

        /// <summary>
        /// Converts the string representation of numbers delimited by <pararef name="separator" /> to equivalent 16-bit integer array.
        /// For example, input "100, 200, -300" with comma ',' as the separator will return a 16-bit integer array { 100, 200, -300 }.
        /// </summary>
        /// <param name="str">The string representing 16-bit numbers.</param>
        /// <param name="separator">The character used to separate numbers.</param>
        /// <returns>An array of 16-bit integers.</returns>
        public static Int16[] ToInt16Array(this string str, char separator)
        {
            var eles = str.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            var arr = new Int16[eles.Length];
            for (int i = 0; i < eles.Length; ++i)
                arr[i] = Convert.ToInt16(eles[i]);
            return arr;
        }

        /// <summary>
        /// Tries to convert the string representation of numbers delimited by <pararef name="separator" /> to equivalent 16-bit integer array.
        /// For example, input "100, 200, -300" with comma ',' as the separator will return a 16-bit integer array { 100, 200, -300 }.
        /// </summary>
        /// <param name="str">The string representing 16-bit numbers.</param>
        /// <param name="separator">The character used to separate numbers.</param>
        /// <returns>An array of 16-bit integers if the conversion is successful; or <c>null</c> if the conversion failed.</returns>
        public static Int16[] TryInt16Array(this string str, char separator)
        {
            var eles = str.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            var arr = new Int16[eles.Length];
            for (int i = 0; i < eles.Length; ++i)
            {
                Int16 val;
                if (Int16.TryParse(eles[i], out val)) arr[i] = val;
                else return null;
            }
            return arr;
        }

        /// <summary>
        /// Converts the string representation of numbers delimited by <pararef name="separator" /> to equivalent 64-bit unsigned integer array.
        /// For example, input "100, 200, 300" with comma ',' as the separator will return a 64-bit unsigned integer array { 100, 200, 300 }.
        /// </summary>
        /// <param name="str">The string representing 64-bit unsigned numbers.</param>
        /// <param name="separator">The character used to separate numbers.</param>
        /// <returns>An array of 64-bit unsigned integers.</returns>
        public static UInt64[] ToUInt64Array(this string str, char separator)
        {
            var eles = str.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            var arr = new UInt64[eles.Length];
            for (int i = 0; i < eles.Length; i++)
                arr[i] = Convert.ToUInt64(eles[i]);
            return arr;
        }

        /// <summary>
        /// Converts the string representation of numbers delimited by <pararef name="separator" /> to equivalent 32-bit unsigned integer array.
        /// For example, input "100, 200, 300" with comma ',' as the separator will return a 32-bit unsigned integer array { 100, 200, 300 }.
        /// </summary>
        /// <param name="str">The string representing 32-bit unsigned numbers.</param>
        /// <param name="separator">The character used to separate numbers.</param>
        /// <returns>An array of 32-bit unsigned integers.</returns>
        public static UInt32[] ToUInt32Array(this string str, char separator)
        {
            var eles = str.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            var arr = new UInt32[eles.Length];
            for (int i = 0; i < eles.Length; i++)
                arr[i] = Convert.ToUInt32(eles[i]);
            return arr;
        }

        /// <summary>
        /// Converts the string representation of numbers delimited by <pararef name="separator" /> to equivalent 16-bit unsigned integer array.
        /// For example, input "100, 200, 300" with comma ',' as the separator will return a 16-bit unsigned integer array { 100, 200, 300 }.
        /// </summary>
        /// <param name="str">The string representing 16-bit unsigned numbers.</param>
        /// <param name="separator">The character used to separate numbers.</param>
        /// <returns>An array of 16-bit unsigned integers.</returns>
        public static UInt16[] ToUInt16Array(this string str, char separator)
        {
            var eles = str.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            var arr = new UInt16[eles.Length];
            for (int i = 0; i < eles.Length; i++)
                arr[i] = Convert.ToUInt16(eles[i]);
            return arr;
        }

        /// <summary>
        /// Converts the string representation of boolean values delimited by <pararef name="separator" /> to equivalent bool array.
        /// For example, input "true, false, true" with comma ',' as the separator will return a Boolean array.
        /// </summary>
        /// <param name="str">The string representing bool values.</param>
        /// <param name="separator">The character used to separate bool values.</param>
        /// <returns>An array of bool values.</returns>
        public static bool[] ToBooleanArray(this string str, char separator)
        {
            var eles = str.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            var arr = new bool[eles.Length];
            for (int i = 0; i < eles.Length; i++)
                arr[i] = Convert.ToBoolean(eles[i]);
            return arr;
        }

        #endregion

        #region Substring

        /// <summary>
        /// Retrieves a substring from this string instance. 
        /// The substring starts at the position before/after the first occurrence of a substring specified by <paramref name="startIndicator"/> 
        /// and ends at the position before/after the first occurrence of <paramref name="endIndicator"/> following the the first occurrence of <paramref name="startIndicator"/>.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="startIndicator">The start indicator used to locate the start position of the substring after the position specified by <paramref name="startIndex"/>. 
        /// A null reference is allowed to indicate the start position is equal to <paramref name="startIndex"/>.</param>
        /// <param name="endIndicator">The end indicator used to locate the end position of the substring after the first accurrance of <paramref name="startIndicator"/>. 
        /// A null reference is allowed to indicate the end position is the end of the current string instance.</param>
        /// <param name="includeStartIndicator">Indicating whether the start indicator is included in the returned substring.</param>
        /// <param name="includeEndIndicator">Indicating whether the end indicator is included in the returned substring.</param>
        /// <param name="startIndex">Indicating the position where the search for both <paramref name="startIndicator"/> and <paramref name="endIndicator"/> starts.</param>
        /// <returns>A substring of this string instance.</returns>
        public static string Substring(this string str, string startIndicator, string endIndicator,
            bool includeStartIndicator = true, bool includeEndIndicator = false, int startIndex = 0)
        {
            var startIndicatorEmpty = startIndicator.IsNullOrEmpty();
            if (!startIndicatorEmpty)
            {
                startIndex = str.IndexOf(startIndicator, startIndex);
                if (startIndex == -1) return null;
                startIndex += startIndicator.Length;
            }

            int endIndex;
            if (endIndicator.IsNullOrEmpty())
                endIndex = str.Length;
            else
            {
                endIndex = str.IndexOf(endIndicator, startIndex);
                if (endIndex == -1) return null;

                if (includeEndIndicator)
                    endIndex += endIndicator.Length;
            }

            if (!startIndicatorEmpty && includeStartIndicator)
                startIndex -= startIndicator.Length;

            var len = endIndex - startIndex;
            if (len == 0) return null;
            else return str.Substring(startIndex, len);
        }

        /// <summary>
        /// Retrieves a substring from this string instance. 
        /// The substring starts at the position before/after the first occurrence of a character specified by <paramref name="startIndicator"/> 
        /// and ends at the position before/after the first occurrence of a character specified by <paramref name="endIndicator"/>.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="startIndicator">The start indicator used to locate the start position of the desired substring after the position specified by <paramref name="startIndex"/>.
        /// Zero char '\0' is allowed to indicate the start position is equal to <paramref name="startIndex"/>.</param>
        /// </param>
        /// <param name="endIndicator">The end indicator used to locate the end position of the desired substring after the first occurrence of <paramref name="startIndicator"/>.
        /// Zero char '\0' is allowed to indicate the end position is the end of the current string instance.</param>
        /// <param name="includeStartIndicator">Indicating whether the start indicator is included in the returned substring.</param>
        /// <param name="includeEndIndicator">Indicating whether the end indicator is included in the returned substring.</param>
        /// <param name="startIndex">Indicating the position where the search for both <paramref name="startIndicator"/> and <paramref name="endIndicator"/> starts.</param>
        /// <returns>A substring of this string instance.</returns>
        public static string Substring(this string str, char startIndicator, char endIndicator,
            bool includeStartIndicator = true, bool includeEndIndicator = false, int startIndex = 0)
        {
            var startIndicatorEmpty = startIndicator == '\0';
            if (!startIndicatorEmpty)
            {
                startIndex = str.IndexOf(startIndicator, startIndex);
                if (startIndex == -1) return null;
                startIndex++;
            }

            int endIndex;
            if (endIndicator == '\0')
                endIndex = str.Length;
            else
            {
                endIndex = str.IndexOf(endIndicator, startIndex);
                if (endIndex == -1) return null;
                if (includeEndIndicator) endIndex++;
            }

            if (!startIndicatorEmpty && includeStartIndicator) startIndex--;

            var len = endIndex - startIndex;
            if (len == 0) return string.Empty;
            else return str.Substring(startIndex, len);
        }

        /// <summary>
        /// Retrieves a substring from this string instance. 
        /// The substring starts at the specified position, and ends at the position before/after the first occurrence of a substring specified by <paramref name="endIndicator"/>.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="startIndex">Indicating the position where the returned substring and the search for <paramref name="endIndicator"/> starts.</param>
        /// <param name="endIndicator">The end indicator used to locate the end position of the desired substring.</param>
        /// <param name="includeEndIndicator">Indicating whether the end indicator is included in the returned substring.</param>
        /// <returns>A substring of this string instance.</returns>
        public static string Substring(this string str, int startIndex, string endIndicator, bool includeEndIndicator = false)
        {
            var idx = str.IndexOf(endIndicator, startIndex);
            if (idx == -1) return null;
            if (includeEndIndicator) idx += endIndicator.Length;

            if (idx == 0) return string.Empty;
            return str.Substring(startIndex, idx - startIndex);
        }

        /// <summary>
        /// Retrieves a substring from this string instance. 
        /// The substring starts at the specified position, and ends at the position before/after the first occurrence of a character specified by <paramref name="endIndicator"/>.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="startIndex">Indicating the position where the returned substring and the search for <paramref name="endIndicator"/> starts.</param>
        /// <param name="endIndicator">The end indicator used to locate the end position of the desired substring.</param>
        /// <param name="includeEndIndicator">Indicating whether the end indicator is included in the returned substring.</param>
        /// <returns>A substring of this string instance.</returns>
        public static string Substring(this string str, int startIndex, char endIndicator, bool includeEndIndicator = false)
        {
            var idx = str.IndexOf(endIndicator, startIndex);
            if (idx == -1) return null;
            if (includeEndIndicator) idx++;

            if (idx == 0) return "";
            return str.Substring(startIndex, idx - startIndex);
        }

        /// <summary>
        /// Gets the number of occurrences of a specified substring in the current string instance.
        /// </summary>
        /// <param name="str">This string isntance.</param>
        /// <param name="value">The string to seek.</param>
        /// <returns>The number of occurrences of a specified substring in the current string instance</returns>
        public static int CountOfSubstring(this string str, string value)
        {
            if (str.IsNullOrEmpty()) return 0;
            if (value.IsNullOrEmpty()) throw new ArgumentNullException("value");

            int idx = 0;
            int count = 0;
            while ((idx = str.IndexOf(value, idx)) != -1) { count++; idx += value.Length; }
            return count;
        }

        #endregion

        #region Modification

        /// <summary>
        /// Decorates this string with the repetition of specified characters. 
        /// <para>For example, decorating "abc" as "--abc---" when using "-" as the decoration character, 
        /// or as "    abc  " when using a space as the decoration character.</para>
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <param name="decorationChar">The decoration character.</param>
        /// <param name="totalLength">The total length of the string plus the decoration.</param>
        /// <param name="alignment">The alignment of this string.</param>
        /// <param name="indent">A positive integer indicates this string moves rightward; a negative integer indicates moving leftward.</param>
        /// <param name="rightLonger">Indicates whether the decoration at the right side can be longer 
        /// than the other side when it is not possible to make them even.</param>
        /// <returns>A string with decoration.</returns>
        /// <remarks><para>Usage: this method could be useful in console applications or other scenarios to output aligned texts.</para>
        /// <para>Test: this method has been tested, but is not guaranteed bug-free.</para>
        /// <para>Future: future versions could use unsafe coding to improve performance.</para></remarks>
        public static string Decorate(this string str, char decorationChar,
            int totalLength, HorizontalAlignment alignment = HorizontalAlignment.Center,
            int indent = 0, bool rightLonger = false)
        {
            return Decorate(str, decorationChar, decorationChar, totalLength, alignment, indent, rightLonger);
        }

        /// <summary>
        /// Decorates this string with the repetition of specified characters. 
        /// <para>For example, decorating "abc" as "--abc***" when using "-" as the decoration character at the left side and "*" at the right side, 
        /// or as "    abc  " when using a space as the decoration character at both sides.</para>
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <param name="leftDecorationChar">The decoration character at the left side.</param>
        /// <param name="rightDecorationChar">The decoration character at the right side.</param>
        /// <param name="totalLength">The total length of the string plus the decoration.</param>
        /// <param name="alignment">The alignment of this string.</param>
        /// <param name="indent">A positive integer indicates this string moves rightward; a negative integer indicates moving leftward.</param>
        /// <param name="rightLonger">Indicates whether the decoration at the right side can be longer 
        /// than the other side when it is not possible to make them even.</param>
        /// <returns>A string with decoration.</returns>
        /// <remarks><para>Usage: this method could be useful in console applications or other scenarios to output aligned texts.</para>
        /// <para>Test: this method has been tested, but is not guaranteed bug-free.</para>
        /// <para>Future: future versions could use unsafe coding to improve performance.</para></remarks>
        public static string Decorate(this string str, char leftDecorationChar, char rightDecorationChar,
            int totalLength, HorizontalAlignment alignment = HorizontalAlignment.Center,
            int indent = 0, bool rightLonger = false)
        {
            var margin = totalLength - str.Length;
            if (margin <= 0) return str;
            else
            {
                switch (alignment)
                {
                    case HorizontalAlignment.Center:
                        {
                            double temp = margin / 2f;
                            int left, right;
                            if (rightLonger)
                            {
                                left = (int)Math.Floor(temp);
                                right = (int)Math.Ceiling(temp);
                            }
                            else
                            {
                                left = (int)Math.Ceiling(temp);
                                right = (int)Math.Floor(temp);
                            }

                            left += indent;
                            right -= indent;

                            if (left <= 0)
                                return str + new string(rightDecorationChar, margin);
                            else if (right <= 0)
                                return new string(leftDecorationChar, margin) + str;
                            else
                                return new string(leftDecorationChar, left) + str + new string(rightDecorationChar, right);
                        }
                    case HorizontalAlignment.Left:
                        {
                            if (indent < 0) indent = 0;

                            var left = indent;
                            var right = margin - indent;

                            if (left == 0)
                                return str + new string(rightDecorationChar, margin);
                            else
                                return new string(leftDecorationChar, left) + str + new string(rightDecorationChar, right);
                        }
                    case HorizontalAlignment.Right:
                        {
                            if (indent > 0) indent = 0;
                            var left = margin + indent;
                            var right = -indent;

                            if (right == 0)
                                return new string(leftDecorationChar, margin) + str;
                            else
                                return new string(leftDecorationChar, left) + str + new string(rightDecorationChar, right);
                        }
                    default:
                        {
                            return str;
                        }
                }
            }
        }

        /// <summary>
        /// Inserts a single space before all initials (upper letters) in this string.
        /// </summary>
        /// <param name="str">The string instance to operate on.</param>
        /// <param name="ignoreConsecutiveUpperLetters">Indicates whether to insert only before the first upper letter when consecutive upper letters are found.</param>
        /// <returns>A string where a space is inserted before all upper letters.</returns>
        public static string InsertSpaceBeforeInitials(this string str, bool ignoreConsecutiveUpperLetters)
        {
            return InsertBeforeInitials(str, ' ', ignoreConsecutiveUpperLetters);
        }

        /// <summary>
        /// Inserts a specified character before all initials (upper letters) in this string.
        /// </summary>
        /// <param name="str">The string instance to operate on.</param>
        /// <param name="insertionChar">The character to insert.</param>
        /// <param name="ignoreConsecutiveUpperLetters">Indicates whether to insert only before the first upper letter when consecutive upper letters are found.</param>
        /// <returns>A string where the specified character is inserted before all upper letters.</returns>
        public static string InsertBeforeInitials(this string str, char insertionChar, bool ignoreConsecutiveUpperLetters)
        {
            if (str.IsNullOrEmpty()) return str;

            var output = new char[str.Length + str.Length];
            output[0] = str[0];
            bool lastUpper = str[0].IsUpper();
            int totallen = str.Length;

            for (int i = 1, j = 1; i < str.Length; i++)
            {
                if (str[i].IsUpper())
                {
                    if (lastUpper && ignoreConsecutiveUpperLetters)
                        output[j++] = str[i];
                    else
                    {
                        output[j++] = insertionChar;
                        output[j++] = str[i];
                        totallen++;
                        lastUpper = true;
                    }
                }
                else
                {
                    output[j++] = str[i];
                    lastUpper = false;
                }
            }

            return new string(output, 0, totallen);
        }

        /// <summary>
        /// Cuts short this string instance if it execeeds a given length and then attach it with a tail.
        /// <para>For a typical example, "Microsoft Visual Studio" is shortened to "Microsoft Visua..." 
        /// when <paramref name="length"/> is set 15 and <paramref name="tail"/> is set "...".</para>
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="length">The maximum length of the shortened string.</param>
        /// <param name="tail">The tail to attach.</param>
        /// <returns>The shortened string instance.</returns>
        /// <remarks><para>Test: this method has been tested, but is not guaranteed bug-free.</para></remarks>
        public static string Shorten(this string str, int length, string tail = "...")
        {
            if (length <= tail.Length)
                return tail;
            else if (str.Length > length)
                return str.Substring(0, length - tail.Length) + tail;
            else return str;
        }

        //TEST: Yes
        /// <summary>
        /// Returns a copy of this string instance with the first Unicode character converted to its uppercase equivalent.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <returns>A copy of the current string instance with the first Unicode character converted to its uppercase equivalent.</returns>
        public unsafe static string InitUpper(this string str)
        {
            return str.Copy().InitUpperOnSelf();
        }

        //TEST: Yes
        /// <summary>
        /// Returns a copy of this string instance with the first Unicode character converted to its lowercase equivalent.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <returns>A copy of the current string instance with the first Unicode character converted to its lowercase equivalent.</returns>
        public unsafe static string InitLower(this string str)
        {
            return str.Copy().InitLowerOnSelf();
        }

        //TEST: Yes
        /// <summary>
        /// Returns a copy of the reversed version of this string instance.
        /// </summary>
        /// <param name="str">This string instance.</param>
        public static string Reverse(this string str)
        {
            return str.Copy().ReverseOnSelf();
        }

        #endregion

        #region Enumerators

        /// <summary>
        /// Gets an enumerator that supports simple iteration of substrings in this string instance. 
        /// <para>For example, suppose "&lt;" and "&gt;" are used as the indicators, iterating "&lt;div&gt;abc&lt;/div&gt;" yields 
        /// "&lt;div&gt;" "&lt;/div&gt;" if indicators are included, and "div" "/div" if indicators are excluded.</para>
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="startIndicator">The indicator makring the beginning of each substring to iterate.</param>
        /// <param name="endIndicator">The indicator makring the end of each substring to iterate.</param>
        /// <param name="includeStartIndicator">Indicates whether the start indicator is included in the retrieved string.</param>
        /// <param name="includeEndIndicator">Indicates whether the end indicator is included in the retrieved string.</param>
        /// <returns>An enumerator that supports simple iteration of substrings in this string instance.</returns>
        public static IEnumerator<string> GetEnumerator(this string str, string startIndicator, string endIndicator, bool includeStartIndicator = false, bool includeEndIndicator = false)
        {
            return new StringEnumerator1(str, startIndicator, endIndicator, includeStartIndicator, includeEndIndicator);
        }

        /// <summary>
        /// Gets an enumerator that supports simple iteration of substrings in this string instance. 
        /// <para>For example, suppose '&lt;' and '&gt;' are used as the indicators, iterating "&lt;div&gt;abc&lt;/div&gt;" yields 
        /// "&lt;div&gt;" "&lt;/div&gt;" if indicators are included, and "div" "/div" if indicators are excluded.</para>
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="startIndicator">The indicator makring the beginning of each substring to iterate.</param>
        /// <param name="endIndicator">The indicator makring the end of each substring to iterate.</param>
        /// <param name="includeStartIndicator">Indicates whether the start indicator is included in the retrieved string.</param>
        /// <param name="includeEndIndicator">Indicates whether the end indicator is included in the retrieved string.</param>
        /// <returns>An enumerator that supports simple iteration of substrings in this string instance.</returns>
        public static IEnumerator<string> GetEnumerator(this string str, char startIndicator, char endIndicator, bool includeStartIndicator = false, bool includeEndIndicator = false)
        {
            return new StringEnumerator2(str, startIndicator, endIndicator, includeStartIndicator, includeEndIndicator);
        }

        /// <summary>
        /// Gets an enumerator that supports simple iteration of substrings in this string instance. 
        /// <para>For example, suppose ",," is used as the separator, iterating "ab,,cd,,ef" yields 
        /// "ab,," "cd,," "ef" if the separator is included, and "ab" "cd" "ef" if the separator is excluded.</para>
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separator">The separator that separates each substring.</param>
        /// <param name="includeSeparator">Indicates whether the separator is included in the retrieved string.</param>
        /// <returns>An enumerator that supports simple iteration of substrings in this string instance.</returns>
        public static IEnumerator<string> GetEnumerator(this string str, string separator, bool includeSeparator = false)
        {
            return new StringEnumerator3(str, separator, includeSeparator);
        }

        /// <summary>
        /// Gets an enumerator that supports simple iteration of substrings in this string instance. 
        /// <para>For example, suppose ',' is used as the separator, iterating "ab,cd,ef" yields 
        /// "ab," "cd," "ef" if the separator is included, and "ab" "cd" "ef" if the separator is excluded.</para>
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separator">The separator that separates each substring.</param>
        /// <param name="includeSeparator">Indicates whether the separator is included in the retrieved string.</param>
        /// <returns>An enumerator that supports simple iteration of substrings in this string instance.</returns>
        public static IEnumerator<string> GetEnumerator(this string str, char separator, bool includeSeparator = false)
        {
            return new StringEnumerator4(str, separator, includeSeparator);
        }

        #endregion

        #region Others

        /// <summary>
        /// Returns a new string that only contains a specified number of continuous occurrences of this string instance.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="repeat">Specifies the number of continuous occurrences.</param>
        /// <returns>
        /// A new string that only contains continuous occurrences of this string instance.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs if <paramref name="repeat"/> is assigned a non-positive value.</exception>
        public unsafe static string Repeat(this string str, int repeat)
        {
            if (repeat > 0)
            {
                var strlen = str.Length;
                var chars = new char[repeat * strlen + 1];
                fixed (char* ptr = chars)
                {
                    int i = 0;
                    for (int j = 0; j < repeat; ++j)
                        for (int k = 0; k < strlen; ++i, ++k)
                            ptr[i] = str[k];

                    return new string(ptr);
                }
            }

            throw new ArgumentOutOfRangeException("repeat", GeneralResources.ERR_PositiveValueRequired.Scan("repeat"));
        }

        /// <summary>
        /// Encodes non-ASCII chars in this string by their equivalent hex representations.
        /// <para>** Particularly used in translating url containing non-ASCII chars to an ASCII url.
        /// For example, "http://www.hudong.com/wiki/电子垃圾" will be translated to "http://www.hudong.com/wiki/%E7%94%B5%E5%AD%90%E5%9E%83%E5%9C%BE".</para>
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="encoding">Specifies the encoding for encoding the non-ASCII chars.</param>
        /// <param name="byteIndicator">Specifies the char before each hex representation of a byte value.</param>
        /// <returns>A copy of the original string with all non-ASCII chars and the chars in the exception list converted to hex representations.</returns>
        public static string HexEncode(this string source, Encoding encoding, char byteIndicator = '%')
        {
            return HexEncode(source, encoding, new char[] { '.', '/', ':' }, byteIndicator);
        }

        /// <summary>
        /// Encodes non-ASCII chars in this string by their equivalent hex representations.
        /// For example, "http://www.hudong.com/wiki/电子垃圾" will be translated to "http://www.hudong.com/wiki/%E7%94%B5%E5%AD%90%E5%9E%83%E5%9C%BE".
        /// <para>** Particularly used in translating url containing non-ASCII chars to an ASCII url.</para>
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="encoding">Specifies the encoding for encoding the non-ASCII chars.</param>
        /// <param name="exceptionList">Specifies the ASCII chars that are also converted to hex representations.</param>
        /// <param name="byteIndicator">Specifies the char before each hex representation of a byte value.</param>
        /// <returns>A copy of the original string with all non-ASCII chars and the chars in the exception list converted to hex representations.</returns>
        public static string HexEncode(this string source, Encoding encoding, char[] exceptionList, char byteIndicator = '%')
        {
            StringBuilder sb = new StringBuilder(source.Length);
            List<char> cache = new List<char>();
            for (int i = 0; i < source.Length; i++)
            {
                var c = source[i];
                if (c.IsASCIILetterOrDigit() || exceptionList.Contains(c))
                {
                    if (cache.Count > 0)
                    {
                        sb.Append(encoding.GetBytes(cache.ToArray()).ToHex(byteIndicator));
                        cache.Clear();
                    }
                    sb.Append(c);
                }
                else
                    cache.Add(c);
            }

            if (cache.Count > 0)
                sb.Append(encoding.GetBytes(cache.ToArray()).ToHex(byteIndicator));

            return sb.ToString();
        }

        /// <summary>
        /// Decodes hex representations in this string to their equivalent chars.
        /// For example, "http://www.hudong.com/wiki/%E7%94%B5%E5%AD%90%E5%9E%83%E5%9C%BE" will be translated to "http://www.hudong.com/wiki/电子垃圾".
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="encoding">Specifies the encoding of the non-ASCII chars.</param>
        /// <param name="byteIndicator">Specifies the char before each hex representation of a byte value.</param>
        /// <returns>A copy of the original string with hex representations decoded to their equivalent chars.</returns>
        public static string HexDecode(this string source, Encoding encoding, char byteIndicator = '%')
        {
            List<byte> cache = new List<byte>();
            StringBuilder sb = new StringBuilder(source.Length);
            for (int i = 0; i < source.Length; i++)
            {
                var c = source[i];
                if (c == byteIndicator)
                {
                    cache.Add(byte.Parse(source.Substring(i + 1, 2), Globalization.NumberStyles.HexNumber));
                    i += 2;
                }
                else
                {
                    if (cache.Count > 0)
                    {
                        sb.Append(encoding.GetChars(cache.ToArray()));
                        cache.Clear();
                    }
                    sb.Append(c);
                }
            }

            if (cache.Count > 0)
                sb.Append(encoding.GetChars(cache.ToArray()));
            return sb.ToString();
        }

        #endregion

        #region Obselete

        //!!! Methods in this region will be removed. DO NOT USE THEM !!!

        /// <summary>
        /// Gets all integers consisting of ASCII digits in this string instance.
        /// <para>For example, the integers in string "There are 100 students and 5 classes in this school." are 100 and 5.</para>
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="startIndex">Indicating where the search starts.</param>
        /// <returns>All integers consisting of ASCII digits in this string instance, if found; otherwise, an empty array.</returns>
        public static int[] GetIntegers(this string str, int startIndex = 0)
        {
            int? output = null;
            var list = new List<int>(7);
            var bgPos = -1;
            for (int i = startIndex; i < str.Length; ++i)
            {
                var c = str[i];
                if (c.IsDigit())
                {
                    if (bgPos == -1) bgPos = i;
                    if (output == null) output = 0;
                    var nv = c.GetNumericValue();
                    var fnv = Math.Floor(nv);
                    if (fnv == nv)
                        output = output * 10 + ((int)fnv);
                }
                else if (output != null)
                {
                    if (bgPos != 0 && str[bgPos - 1] == '-')
                        list.Add(-output.Value);
                    else list.Add(output.Value);
                    bgPos = -1;
                }
            }
            return list.ToArray();
        }

        public static int? GetInteger(this string str, int intIdx, int startIndex)
        {
            int? output = null;
            var bgPos = -1;
            var currIntegerIdx = 0;
            for (int i = startIndex; i < str.Length; ++i)
            {
                var c = str[i];
                if (c.IsDigit())
                {
                    if (bgPos == -1) bgPos = i;
                    if (output == null) output = 0;
                    var nv = c.GetNumericValue();
                    var fnv = Math.Floor(nv);
                    if (fnv == nv)
                        output = output * 10 + ((int)fnv);
                }
                else if (output != null)
                {
                    if (currIntegerIdx == intIdx)
                    {
                        if (bgPos != 0 && str[bgPos - 1] == '-')
                            return -output.Value;
                        else return output.Value;
                    }
                    ++currIntegerIdx;
                    bgPos = -1;
                }
            }
            return output;
        }

        /// <summary>
        /// Gets the first integer consisting of ASCII digits in this string instance.
        /// <para>For example, the first integer in string "There are 100 students and 5 classes in this school." is 100.</para>
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="startIndex">Indicating the position where the search starts.</param>
        /// <returns>The first integer in this string instance. If no integer is found, a null reference will be returned.</returns>
        public static int? GetInteger(this string str, int startIndex = 0)
        {
            int? output = null;
            var bgPos = -1;
            var strLen = str.Length;
            for (int i = startIndex; i < strLen; ++i)
            {
                var c = str[i];
                if (c.IsDigit())
                {
                    if (bgPos == -1) bgPos = i;
                    if (output == null) output = 0;
                    var nv = c.GetNumericValue();
                    var fnv = Math.Floor(nv);
                    if (fnv == nv)
                        output = output * 10 + ((int)fnv);
                }
                else if (output != null)
                {
                    if (bgPos != 0 && str[bgPos - 1] == '-')
                        return -output;
                    else return output;
                }
            }

            return output;
        }

        public static bool TryGetInteger(this string str, out int integer, int startIndex = 0)
        {
            integer = int.MinValue;
            var bgPos = -1;
            var strLen = str.Length;
            for (int i = startIndex; i < strLen; ++i)
            {
                var c = str[i];
                if (c.IsDigit())
                {
                    if (bgPos == -1) bgPos = i;
                    if (integer == int.MinValue) integer = 0;
                    var nv = c.GetNumericValue();
                    var fnv = Math.Floor(nv);
                    if (fnv == nv)
                        integer = integer * 10 + ((int)fnv);
                }
                else if (integer != int.MinValue)
                {
                    if (bgPos != 0 && str[bgPos - 1] == '-') integer = -integer;
                    return true;
                }
            }

            integer = 0;
            return false;
        }

        #endregion
    }
}
