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
        /// Gets an object that can iterate through information about substrings of the current reading scope that are delimited by Unicode characters satisfying the specified <paramref name="predicate" />.
        /// </summary>
        /// <param name="predicate">A method to test each Unicode character of the current reading scope.
        /// Any character that passes this test will be used as a separator.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should not be returned; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned; for example, "ab,   ,cd" split by comma ',' is "ab" and "cd".</para>
        /// </param>
        /// <returns>
        /// An object that can iterate through information about substrings of the current reading scope that are delimited by Unicode characters satisfying the specified <paramref name="predicate" />.
        /// </returns>
        public IEnumerator<StringSplitResult> GetSplitEnumeratorEx(Func<char, int> predicate, bool removeEmptyEntries = false, bool trim = false)
        {
            int predicateOutput = -1;
            char separator = '\0';
            var predicateWrap = new Func<char, bool>(c =>
            {
                separator = c;
                predicateOutput = predicate(c);
                return predicateOutput != -1;
            });

            while (!EOF)
            {
                var split = trim ? ReadAfterWithTrim(predicateWrap, true, false) : ReadAfter(predicateWrap, true, false);
                if (split == null)
                {
                    split = trim ? ReadToEndWithTrim() : ReadToEnd();
                    if (!removeEmptyEntries || !split.Equals(string.Empty, StringComparison.Ordinal)) yield return new StringSplitResult(split, '\0', -1);
                    yield break;
                }
                else
                {
                    if (!removeEmptyEntries || !split.Equals(string.Empty, StringComparison.Ordinal)) yield return new StringSplitResult(split, separator, predicateOutput);
                    if (EOF)
                    {
                        if (!removeEmptyEntries) yield return new StringSplitResult(string.Empty, '\0', -1);
                        yield break;
                    }
                }
            }
        }

        /// <summary>
        /// Gets an object that can iterate through information about substrings of the current reading scope that are delimited by Unicode characters satisfying the specified <paramref name="predicate" />.
        /// </summary>
        /// <param name="predicate">A method to test each Unicode character of the current reading scope. Any character that passes this test will be used as a separator.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should not be returned; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned; for example, "ab,   ,cd" split by comma ',' is "ab" and "cd".</para>
        /// </param>
        /// <returns>
        /// An object that can iterate through information about substrings of the current reading scope that are delimited by Unicode characters satisfying the specified <paramref name="predicate" />.
        /// </returns>
        public IEnumerator<StringReaderSplitResult> GetSplitReaderEnumeratorEx(Func<char, int> predicate, bool removeEmptyEntries = true, bool trim = false)
        {
            int predicateOutput = -1;
            char separator = '\0';
            var predicateWrap = new Func<char, bool>(c =>
            {
                separator = c;
                predicateOutput = predicate(c);
                return predicateOutput != -1;
            });

            while (!EOF)
            {
                var split = trim ? ReadAfterWithTrimAsReader(predicateWrap, true, false) : ReadAfterAsReader(predicateWrap, true, false);
                if (split == null)
                {
                    split = trim ? ReadToEndWithTrimAsReader() : ReadToEndAsReader();
                    if (!removeEmptyEntries || !split.EOF) yield return new StringReaderSplitResult(split, '\0', -1);
                    yield break;
                }
                else
                {
                    if (!removeEmptyEntries || !split.EOF) yield return new StringReaderSplitResult(split, separator, predicateOutput);
                    if (EOF)
                    {
                        if (!removeEmptyEntries) yield return new StringReaderSplitResult(EmptyReader, '\0', -1);
                        yield break;
                    }
                }
            }
        }

        #endregion

        #region Multiple Chars

        /// <summary>
        /// Gets an object that can iterate through informaiton about substrings of the current reading scope that are delimited by the specified Unicode characters as the separators.
        /// </summary>
        /// <param name="separators">Unicode characters as the separators.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should not be returned; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned; for example, "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <returns>
        /// An object that can iterate through informaiton about substrings of the current reading scope that are delimited by the specified <paramref name="separators"/>.
        /// </returns>
        public IEnumerator<StringSplitResult> GetSplitEnumeratorEx(char[] separators, bool removeEmptyEntries = true, bool trim = false)
        {
            int hitIndex;
            while (!EOF)
            {
                var split = trim ? ReadAfterWithTrim(separators, out hitIndex, true, false) : ReadAfter(separators, out hitIndex, true, false);
                if (split == null)
                {
                    split = trim ? ReadToEndWithTrim() : ReadToEnd();
                    if (!removeEmptyEntries || !split.Equals(string.Empty, StringComparison.Ordinal)) yield return new StringSplitResult(split, '\0', -1);
                    yield break;
                }
                else
                {
                    if (!removeEmptyEntries || !split.Equals(string.Empty, StringComparison.Ordinal)) yield return new StringSplitResult(split, separators[hitIndex], hitIndex); ;
                    if (EOF)
                    {
                        if (!removeEmptyEntries) yield return new StringSplitResult(string.Empty, '\0', -1);
                        yield break;
                    }
                }
            }
        }

        /// <summary>
        /// Gets an object that can iterate through information about substrings of the current reading scope that are delimited by the specified Unicode character as the separator.
        /// </summary>
        /// <param name="separators">Unicode characters as the separators.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should not be returned; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>
        /// NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned; for example, "ab,   ,cd" split by comma ',' is "ab" and "cd".</para>
        /// </param>
        /// <returns>
        /// An object that can iterate through information about substrings of the current reading scope that are delimited by the specified <paramref name="separator"/>.
        /// </returns>
        public IEnumerator<StringReaderSplitResult> GetSplitReaderEnumeratorEx(char[] separators, bool removeEmptyEntries = true, bool trim = false)
        {
            int hitIndex;
            while (!EOF)
            {
                var split = trim ? ReadAfterWithTrimAsReader(separators, out hitIndex, true, false) : ReadAfterAsReader(separators, out hitIndex, true, false);
                if (split == null)
                {
                    split = trim ? ReadToEndWithTrimAsReader() : ReadToEndAsReader();
                    if (!removeEmptyEntries || !split.EOF) yield return new StringReaderSplitResult(split, '\0', -1);
                    yield break;
                }
                else
                {
                    if (!removeEmptyEntries || !split.EOF) yield return new StringReaderSplitResult(split, separators[hitIndex], hitIndex);
                    if (EOF)
                    {
                        if (!removeEmptyEntries) yield return new StringReaderSplitResult(EmptyReader, '\0', -1);
                        yield break;
                    }
                }
            }
        }

        #endregion
    }
}
