using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class StringEx
    {
        static IEnumerator<string> _innerGetSplitEnumerator(string value, string separator, int startIndex, int endIndex, bool removeEmptyEntries, bool trim)
        {
            var length = endIndex - startIndex;

            if(trim)
            {
                var idx = value.IndexOf(separator, startIndex, length);
                if (idx == -1)
                {
                    var output = value.SubstringWithTrim(startIndex, length);
                    if (!removeEmptyEntries || !output.Equals(string.Empty))
                        yield return output;
                }
                else
                {
                    var output = value.SubstringWithTrim(startIndex, idx - startIndex);
                    if (!removeEmptyEntries || !output.Equals(string.Empty)) yield return output;

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
                                yield return output;
                            yield break;
                        }
                        else
                        {
                            output = value.SubstringWithTrim(idx, startIndex - idx);
                            if (!removeEmptyEntries || !output.Equals(string.Empty))
                                yield return output;
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
                        yield return value.Substring(startIndex, length);
                }
                else
                {
                    if (idx != startIndex || !removeEmptyEntries)
                        yield return value.Substring(startIndex, idx - startIndex);

                    var separatorLen = separator.Length;
                    idx += separatorLen;
                    while (true)
                    {
                        length = endIndex - idx;
                        startIndex = value.IndexOf(separator, idx, length);
                        if (startIndex == -1)
                        {
                            if (!removeEmptyEntries || idx != endIndex)
                                yield return value.Substring(idx, length);
                           yield break;
                        }
                        else
                        {
                            if (startIndex != idx || !removeEmptyEntries)
                                yield return value.Substring(idx, startIndex - idx);
                            idx = startIndex + separatorLen;
                        }
                    }
                }
            }
        }

        static IEnumerator<string> _innerGetSplitEnumerator(string value, string[] separators, int startIndex, int endIndex, bool removeEmptyEntries, bool trim)
        {
            var length = endIndex - startIndex;

            if (trim)
            {
                var idxResult = value.IndexOfAny(separators, startIndex, length);
                if (idxResult == null)
                {
                    var output = value.SubstringWithTrim(startIndex, length);
                    if (!removeEmptyEntries || !output.Equals(string.Empty))
                        yield return output;
                }
                else
                {
                    var output = value.SubstringWithTrim(startIndex, idxResult.Position - startIndex);
                    if (!removeEmptyEntries || !output.Equals(string.Empty)) yield return output;
                    startIndex = idxResult.Position + idxResult.Value.Length;
                    while (true)
                    {
                        length = endIndex - startIndex;
                        idxResult = value.IndexOfAny(separators, startIndex, length);
                        if (idxResult == null)
                        {
                            output = value.SubstringWithTrim(startIndex, length);
                            if (!removeEmptyEntries || !output.Equals(string.Empty))
                                yield return output;
                            yield break;
                        }
                        else
                        {
                            output = value.SubstringWithTrim(startIndex, idxResult.Position - startIndex);
                            if (!removeEmptyEntries || !output.Equals(string.Empty))
                                yield return output;
                            startIndex = idxResult.Position + idxResult.Value.Length;
                        }
                    }
                }
            }
            else
            {
                var idxResult = value.IndexOfAny(separators, startIndex, length);
                if (idxResult == null)
                {
                    if (!removeEmptyEntries || startIndex != endIndex)
                        yield return value.Substring(startIndex, length);
                }
                else
                {
                    if (idxResult.Position != startIndex || !removeEmptyEntries)
                        yield return value.Substring(startIndex, idxResult.Position - startIndex);

                    startIndex = idxResult.Position + idxResult.Value.Length;
                    while (true)
                    {
                        length = endIndex - startIndex;
                        idxResult = value.IndexOfAny(separators, startIndex, length);
                        if (idxResult == null)
                        {
                            if (!removeEmptyEntries || length != 0)
                                yield return value.Substring(startIndex, length);
                            yield break;
                        }
                        else
                        {
                            if (!removeEmptyEntries || startIndex != idxResult.Position)
                                yield return value.Substring(startIndex, idxResult.Position - startIndex);
                            startIndex = idxResult.Position + idxResult.Value.Length;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets an object that can iterate through substrings in this string (or a part of this string)
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
        /// An object that can iterate through substrings in the current string instance (or a part of the current string instance)
        /// that are delimited by the specified separator.
        /// </returns>
        public static IEnumerator<string> GetSplitEnumerator(this string str, string separator, int startIndex, int length, bool removeEmptyEntries = false, bool trim = false)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerGetSplitEnumerator(str, separator, startIndex, endIndex, removeEmptyEntries, trim);
        }

        /// <summary>
        /// Gets an object that can iterate through substrings in this string (or a part of this string)
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
        /// An object that can iterate through substrings in the current string instance (or a part of the current string instance)
        /// that are delimited by the specified separator.
        /// </returns>
        public static IEnumerator<string> GetSplitEnumerator(this string str, string separator, int startIndex = 0, bool removeEmptyEntries = false, bool trim = false)
        {
            ExceptionHelper.NonNegativeArgumentRequired("startIndex", startIndex);
            return _innerGetSplitEnumerator(str, separator, startIndex, str.Length, removeEmptyEntries, trim);
        }

        /// <summary>
        /// Gets an object that can iterate through substrings in this string (or a part of this string)
        /// that are delimited by the specified separators.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separators">String instances that delimits the substrings in the current string instance.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if the returned enumerator should ignore empty substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned;
        /// for example, in this case "ab||   **  cd" split by "||" and "**" is "ab" and "cd".</para></param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance (or a part of the current string instance)
        /// that are delimited by the specified separators.
        /// </returns>
        public static IEnumerator<string> GetSplitEnumerator(this string str, string[] separators, int startIndex, int length, bool removeEmptyEntries = false, bool trim = false)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerGetSplitEnumerator(str, separators, startIndex, endIndex, removeEmptyEntries, trim);
        }

        /// <summary>
        /// Gets an object that can iterate through substrings in this string (or a part of this string)
        /// that are delimited by the specified separators.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separators">String instances that delimit the substrings in the current string instance.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if the returned enumerator should ignore empty substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned;
        /// for example, in this case "ab||   **  cd" split by "||" and "**" is "ab" and "cd".</para></param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance (or a part of the current string instance)
        /// that are delimited by the specified separators.
        /// </returns>
        public static IEnumerator<string> GetSplitEnumerator(this string str, string[] separators, int startIndex = 0, bool removeEmptyEntries = false, bool trim = false)
        {
            ExceptionHelper.NonNegativeArgumentRequired("startIndex", startIndex);
            return _innerGetSplitEnumerator(str, separators, startIndex, str.Length, removeEmptyEntries, trim);
        }
    }
}
