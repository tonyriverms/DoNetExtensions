using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class StringEx
    {
        /// <summary>
        /// Splits this string into two substrings at the position where the first occurrence of <paramref name="separator"/> is found.
        /// <para>This is a useful method when splitting an attribute-value string like "company: Microsoft".</para>
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="separator">A character as the separator. 
        /// NOTE that this separator will be removed. For example, split "abcde" by "c" and we will get "ab" and "de".
        /// </param>
        /// <returns>A pair of split substrings if the separator is found; otherwise, <c>null</c>.</returns>
        public static Pair<string> BiSplit(this string source, char separator)
        {
            return BiSplit(source, source.IndexOf(separator));
        }

        /// <summary>
        /// Splits this string into two substrings at the position where the first occurrence of <paramref name="separator" /> is found.
        /// <para>This is a useful method when splitting an attribute-value string like "company: Microsoft".</para>
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="separator">A character as the separator.
        /// NOTE that this separator will be removed. For example, split "abcde" by "c" and we will get "ab" and "de".</param>
        /// <param name="first">If <paramref name="separator" /> is found, returns the substring from beginning to the position before <paramref name="separator" />, where <see cref="string.Empty" /> is returned if the leading character of the current string equals the <paramref name="separator" />; otherwise, <c>null</c>.</param>
        /// <param name="second">If <paramref name="separator" /> is found, returns the substring from the position after <paramref name="separator" /> to the end; otherwise, <c>null</c>.</param>
        /// <returns><c>true</c> if <paramref name="separator"/> is found in the current string; otherwise, <c>false</c>.</returns>
        public static bool BiSplit(this string source, char separator, out string first, out string second)
        {
            var idx = source.IndexOf(separator);
            if (idx == -1)
            {
                first = null;
                second = null;
                return false;
            }
            else
            {
                first = source.Substring(0, idx);
                second = source.Substring(idx + 1);
                return true;
            }
        }

        /// <summary>
        /// Splits this string into two substrings at the specified position. <c>null</c> is returned if <paramref name="index"/> is negative.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="index">The position where the current string is split.</param>
        /// <returns>A<see cref="Pair{stirng}"/> of split substrings derived from spliting the current string at the position before <paramref name="index"/> if <paramref name="index"/> is positive; a <see cref="Pair{stirng}"/> with <see cref="string.Empty"/> as the first item and the substring starting from position <c>1</c> as the second item if <paramref name="index"/> is zero; otherwise, <c>null</c>.</returns>
        public static Pair<string> BiSplit(this string source, int index)
        {
            if (index < 0) return null;
            else
            {
                var str1 = source.Substring(0, index);
                var str2 = source.Substring(index + 1);
                return new Pair<string>(str1, str2);
            }
        }

        /// <summary>
        /// Splits this string into two substrings at the specified position.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="index">The position where the current string is split.</param>
        /// <param name="first">Returns the substring from beginning to the position before <paramref name="index" /> if <paramref name="index" /> is positive; <see cref="string.Empty" /> if <paramref name="index" /> is zero; otherwise, <c>null</c>.</param>
        /// <param name="second">Returns the substring starting from position after <paramref name="index" /> to the end if <paramref name="index" /> is non-negative; otherwise, <c>null</c>.</param>
        public static void BiSplit(this string source, int index, out string first, out string second)
        {
            if (index < 0)
            {
                first = null;
                second = null;
            }
            else
            {
                first = source.Substring(0, index);
                second = source.Substring(index + 1);
            }
        }

        /// <summary>
        /// Splits this string into two substrings at the position where the first occurrence of <paramref name="separator"/> is found.
        /// The whitespaces at both ends of the two substrings will be trimmed as well. 
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="separator">A character as the separator. 
        /// NOTE that this separator will be removed. For example, split "abcde" by "c" and we will get "ab" and "de".
        /// </param>
        /// <returns>A pair of split substrings (with white spaces trimmed at both ends) if the separator is found; otherwise, <c>null</c>.</returns>
        public static Pair<string> BiSplitWithTrim(this string source, char separator)
        {
            if (BiSplitWithTrim(source, separator, out string value1, out string value2)) return new Pair<string>(value1, value2);
            else return null;
        }

        ///// <summary>
        ///// Splits this string into two substrings at the position where the first occurrence of <paramref name="separator" /> is found.
        ///// This is a useful method when splitting an attribute-value string like "company: Microsoft".
        ///// </summary>
        ///// <param name="source">This string instance.</param>
        ///// <param name="separator">A character as the separator.
        ///// NOTE that this separator will be removed. For example, split "abcde" by "c" and we will get "ab" and "de".</param>
        ///// <param name="value1">Returns the substring before the first occurrence of the separator.</param>
        ///// <param name="value2">Returns the substring after the first occurrence of the separator.</param>
        ///// <returns>
        ///// <c>true</c> if the separator is found and the separation is successful; otherwise, <c>false</c>.
        ///// </returns>
        //public static bool BiSplit(this string source, char separator, out string value1, out string value2)
        //{
        //    var idx = source.IndexOf(separator);
        //    if (idx == -1)
        //    {
        //        value1 = null;
        //        value2 = null;
        //        return false;
        //    }
        //    else
        //    {
        //        value1 = source.Substring(0, idx);
        //        value2 = source.Substring(idx + 1);
        //        return true;
        //    }
        //}

        /// <summary>
        /// Splits this string into two substrings at the position where the first occurrence of <paramref name="separator" /> is found.
        /// The whitespaces at both ends of the two substrings will be trimmed as well. 
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="separator">A character as the separator.
        /// NOTE that this separator will be removed. For example, split "abcde" by "c" and we will get "ab" and "de".</param>
        /// <param name="value1">Returns the substring (with white spaces trimmed at both ends) before the first occurrence of the separator.</param>
        /// <param name="value2">Returns the substring (with white spaces trimmed at both ends) after the first occurrence of the separator.</param>
        /// <returns>
        /// <c>true</c> if the separator is found and the separation is successful; otherwise, <c>false</c>.
        /// </returns>
        public static bool BiSplitWithTrim(this string source, char separator, out string value1, out string value2)
        {
            var reader = new StringReader(source);
            reader.Trim();
            value1 = reader.ReadAfterWithTrim(separator, readToEndIfKeycharNotFound: false);
            if (value1 == null)
            {
                value2 = null;
                return false;
            }

            value2 = reader.ReadToEndWithTrim();
            return true;
        }
    }
}
