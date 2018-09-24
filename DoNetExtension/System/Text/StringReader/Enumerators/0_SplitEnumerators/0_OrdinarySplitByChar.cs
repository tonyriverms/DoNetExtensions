using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Text
{
    public partial class StringReader
    {
        #region Predicate

        /// <summary>
        /// Gets an object that can iterate through substrings of the current reading scope that are delimited by Unicode characters satisfying the specified <paramref name="predicate" />.
        /// </summary>
        /// <param name="predicate">A method to test each Unicode character of the current reading scope.
        /// Any character that passes this test will be used as a separator.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should not be returned; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned; for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para>
        /// </param>
        /// <returns>
        /// An object that can iterate through substrings of the current reading scope that are delimited by Unicode characters satisfying the specified <paramref name="predicate" />.
        /// </returns>
        public IEnumerator<string> GetSplitEnumerator(Func<char, bool> predicate, bool removeEmptyEntries = false, bool trim = false)
        {
            while (!EOF)
            {
                var split = trim ? ReadAfterWithTrim(predicate, true, false) : ReadAfter(predicate, true, false);
                if (split == null)
                {
                    split = trim ? ReadToEndWithTrim() : ReadToEnd();
                    if (!removeEmptyEntries || !split.Equals(string.Empty, StringComparison.Ordinal)) yield return split;
                    yield break;
                }
                else
                {
                    if (!removeEmptyEntries || !split.Equals(string.Empty, StringComparison.Ordinal)) yield return split;
                    if (EOF)
                    {
                        if (!removeEmptyEntries) yield return string.Empty;
                        yield break;
                    }
                }
            }
        }

        /// <summary>
        /// Gets an object that can iterate through substrings (represented by <see cref="StringReader"/> objects) of the current reading scope that are delimited by Unicode characters satisfying the specified <paramref name="predicate" />.
        /// </summary>
        /// <param name="predicate">A method to test each Unicode character of the current reading scope. Any character that passes this test will be used as a separator.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should not be returned; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned; for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para>
        /// </param>
        /// <returns>
        /// An object that can iterate through substrings (represented by <see cref="StringReader"/> objects) of the current reading scope that are delimited by Unicode characters satisfying the specified <paramref name="predicate" />.
        /// </returns>
        public IEnumerator<StringReader> GetSplitReaderEnumerator(Func<char, bool> predicate, bool removeEmptyEntries = true, bool trim = false)
        {
            while (!EOF)
            {
                var split = trim ? ReadAfterWithTrimAsReader(predicate, true, false) : ReadAfterAsReader(predicate, true, false);
                if (split == null)
                {
                    split = trim ? ReadToEndWithTrimAsReader() : ReadToEndAsReader();
                    if (!removeEmptyEntries || !split.EOF) yield return split;
                    yield break;
                }
                else
                {
                    if (!removeEmptyEntries || !split.EOF) yield return split;
                    if (EOF)
                    {
                        if (!removeEmptyEntries) yield return StringReader.EmptyReader;
                        yield break;
                    }
                }
            }
        }

        #endregion

        #region Single Char

        /// <summary>
        /// Gets an object that can iterate through substrings of the current reading scope that are delimited by the specified Unicode character as the separator.
        /// </summary>
        /// <param name="separator">A Unicode character as the separator.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should not be returned; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>
        /// NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned; for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para>
        /// </param>
        /// <returns>
        /// An object that can iterate through substrings of the current reading scope that are delimited by the specified <paramref name="separator"/>.
        /// </returns>
        public IEnumerator<string> GetSplitEnumerator(char separator, bool removeEmptyEntries = true, bool trim = false)
        {
            while (!EOF)
            {
                var split = trim ? ReadAfterWithTrim(separator, true, false) : ReadAfter(separator, true, false);
                if (split == null)
                {
                    split = trim ? ReadToEndWithTrim() : ReadToEnd();
                    if (!removeEmptyEntries || !split.Equals(string.Empty, StringComparison.Ordinal)) yield return split;
                    yield break;
                }
                else
                {
                    if (!removeEmptyEntries || !split.Equals(string.Empty, StringComparison.Ordinal)) yield return split;
                    if (EOF)
                    {
                        if (!removeEmptyEntries) yield return string.Empty;
                        yield break;
                    }
                }
            }
        }

        /// <summary>
        /// Gets an object that can iterate through substrings (represented by <see cref="StringReader"/> objects) of the current reading scope that are delimited by the specified Unicode character as the separator.
        /// </summary>
        /// <param name="separator">A Unicode character as the separator.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should not be returned; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>
        /// NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned; for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para>
        /// </param>
        /// <returns>
        /// An object that can iterate through substrings (represented by <see cref="StringReader"/> objects) of the current reading scope that are delimited by the specified <paramref name="separator"/>.
        /// </returns>
        public IEnumerator<StringReader> GetSplitReaderEnumerator(char separator, bool removeEmptyEntries = true, bool trim = false)
        {
            while (!EOF)
            {
                var split = trim ? ReadAfterWithTrimAsReader(separator, true, false) : ReadAfterAsReader(separator, true, false);
                if (split == null)
                {
                    split = trim ? ReadToEndWithTrimAsReader() : ReadToEndAsReader();
                    if (!removeEmptyEntries || !split.EOF) yield return split;
                    yield break;
                }
                else
                {
                    if (!removeEmptyEntries || !split.EOF) yield return split;
                    if (EOF)
                    {
                        if (!removeEmptyEntries) yield return StringReader.EmptyReader;
                        yield break;
                    }
                }
            }
        }

        #endregion

        #region Multiple Chars

        /// <summary>
        /// Gets an object that can iterate through substrings of the current reading scope that are delimited by the specified Unicode characters as the separators.
        /// </summary>
        /// <param name="separators">Unicode characters as the separators.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should not be returned; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned; for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <returns>
        /// An object that can iterate through substrings of the current reading scope that are delimited by the specified <paramref name="separators"/>.
        /// </returns>
        public IEnumerator<string> GetSplitEnumerator(char[] separators, bool removeEmptyEntries = true, bool trim = false)
        {
            while (!EOF)
            {
                var split = trim ? ReadAfterWithTrim(separators, true, false) : ReadAfter(separators, true, false);
                if (split == null)
                {
                    split = trim ? ReadToEndWithTrim() : ReadToEnd();
                    if (!removeEmptyEntries || !split.Equals(string.Empty, StringComparison.Ordinal)) yield return split;
                    yield break;
                }
                else
                {
                    if (!removeEmptyEntries || !split.Equals(string.Empty, StringComparison.Ordinal)) yield return split;
                    if (EOF)
                    {
                        if (!removeEmptyEntries) yield return string.Empty;
                        yield break;
                    }
                }
            }
        }

        /// <summary>
        /// Gets an object that can iterate through substrings (represented by <see cref="StringReader"/> objects) of the current reading scope that are delimited by the specified Unicode character as the separator.
        /// </summary>
        /// <param name="separators">Unicode characters as the separators.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should not be returned; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>
        /// NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned; for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para>
        /// </param>
        /// <returns>
        /// An object that can iterate through substrings (represented by <see cref="StringReader"/> objects) of the current reading scope that are delimited by the specified <paramref name="separator"/>.
        /// </returns>
        public IEnumerator<StringReader> GetSplitReaderEnumerator(char[] separators, bool removeEmptyEntries = true, bool trim = false)
        {
            while (!EOF)
            {
                var split = trim ? ReadAfterWithTrimAsReader(separators, true, false) : ReadAfterAsReader(separators, true, false);
                if (split == null)
                {
                    split = trim ? ReadToEndWithTrimAsReader() : ReadToEndAsReader();
                    if (!removeEmptyEntries || !split.EOF) yield return split;
                    yield break;
                }
                else
                {
                    if (!removeEmptyEntries || !split.EOF) yield return split;
                    if (EOF)
                    {
                        if (!removeEmptyEntries) yield return StringReader.EmptyReader;
                        yield break;
                    }
                }
            }
        }

        #endregion
    }
}
