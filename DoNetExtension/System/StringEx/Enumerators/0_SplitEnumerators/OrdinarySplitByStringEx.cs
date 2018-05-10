using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class StringEx
    {
        static IEnumerator<StringSplitResult> _innerGetSplitEnumeratorEx(string value, string separator, int startIndex, int endIndex, bool removeEmptyEntries, bool trim)
        {
            var length = endIndex - startIndex;

            if (trim)
            {
                var idx = value.IndexOf(separator, startIndex, length);
                if (idx == -1)
                {
                    var output = value.SubstringWithTrim(startIndex, length);
                    if (!removeEmptyEntries || !output.Equals(string.Empty))
                        yield return new StringSplitResult(output, null, -1);
                }
                else
                {
                    var output = value.SubstringWithTrim(startIndex, idx - startIndex);
                    if (!removeEmptyEntries || !output.Equals(string.Empty)) yield return new StringSplitResult(output, separator, idx);

                    var separatorLen = separator.Length;
                    idx += separatorLen;
                    while (true)
                    {
                        length = endIndex - idx;
                        startIndex = value.IndexOf(separator, idx, length);
                        if (startIndex == -1)
                        {
                            output = value.SubstringWithTrim(idx, length);
                            if (!removeEmptyEntries || !output.Equals(string.Empty))
                                yield return new StringSplitResult(output, null, -1);
                            yield break;
                        }
                        else
                        {
                            output = value.SubstringWithTrim(idx, startIndex - idx);
                            if (!removeEmptyEntries || !output.Equals(string.Empty))
                                yield return new StringSplitResult(output, separator, startIndex);
                            idx = startIndex + separatorLen;
                        }
                    }
                }
            }
            else
            {
                var idx = value.IndexOf(separator, startIndex, length);
                if (idx == -1)
                {
                    if (!removeEmptyEntries || startIndex != endIndex)
                        yield return new StringSplitResult(value.Substring(startIndex, length), null, -1);
                }
                else
                {
                    if (idx != startIndex || !removeEmptyEntries)
                        yield return new StringSplitResult(value.Substring(startIndex, idx - startIndex), separator, idx);

                    var separatorLen = separator.Length;
                    idx += separatorLen;
                    while (true)
                    {
                        length = endIndex - idx;
                        startIndex = value.IndexOf(separator, idx, length);
                        if (startIndex == -1)
                        {
                            if (!removeEmptyEntries || idx != endIndex)
                                yield return new StringSplitResult(value.Substring(idx, length), null, -1);
                            break;
                        }
                        else
                        {
                            if (startIndex != idx || !removeEmptyEntries)
                                yield return new StringSplitResult(value.Substring(idx, startIndex - idx), separator, startIndex);
                            idx = startIndex + separatorLen;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets an object that can iterate through information of substrings in this string (or a part of this string)
        /// that are delimited by the specified separator.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separator">A string instance that delimits the substrings in the current string instance.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if the returned enumerator should ignore empty substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned;
        /// for example, in this case "ab,,   ,,cd" split by dual-comma ",," is "ab" and "cd".</para></param>
        /// <returns>
        /// An object that can iterate through information of substrings in the current string instance (or a part of the current string instance)
        /// that are delimited by the specified separator.
        /// </returns>
        public static IEnumerator<StringSplitResult> GetSplitEnumeratorEx(this string str, string separator, int startIndex, int length, bool removeEmptyEntries = false, bool trim = false)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerGetSplitEnumeratorEx(str, separator, startIndex, endIndex, removeEmptyEntries, trim);
        }

        /// <summary>
        /// Gets an object that can iterate through information of substrings in this string (or a part of this string)
        /// that are delimited by the specified separator.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separator">A string instance that delimits the substrings in the current string instance.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if the returned enumerator should ignore empty substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned;
        /// for example, in this case "ab,,   ,,cd" split by dual-comma ",," is "ab" and "cd".</para></param>
        /// <returns>
        /// An object that can iterate through information of substrings in the current string instance (or a part of the current string instance)
        /// that are delimited by the specified separator.
        /// </returns>
        public static IEnumerator<StringSplitResult> GetSplitEnumeratorEx(this string str, string separator, int startIndex = 0, bool removeEmptyEntries = false, bool trim = false)
        {
            ExceptionHelper.NonNegativeArgumentRequired("startIndex", startIndex);
            return _innerGetSplitEnumeratorEx(str, separator, startIndex, str.Length, removeEmptyEntries, trim);
        }
    }
}
