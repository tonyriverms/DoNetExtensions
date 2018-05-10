using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public partial class StringReader
    {
        #region Predicate

        /// <summary>
        /// Gets an object that can iterate through substrings of the current reading scope
        /// that are delimited by Unicode characters outside quotes and satisfying the specified <paramref name="predicate" />.
        /// </summary>
        /// <param name="predicate">A function to test each Unicode character of the current string. Any character that passes this test will be used as a separator.</param>
        /// <param name="leftQuote">The left quote paired by <paramref name="rightQuote" /> to escape separators.</param>
        /// <param name="rightQuote">The right quote paired by <paramref name="leftQuote" /> to escape separators.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned; for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para>
        /// </param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance (or a part of the current string instance)
        /// that are delimited by Unicode characters outside quotes and satisfying the specified predicate.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public IEnumerator<string> GetSplitEnumeratorWithQuotes(Func<char, bool> predicate, char leftQuote, char rightQuote, bool removeEmptyEntries = true, bool trim = false)
        {
            while (!EOF)
            {
                var split = trim ? ReadAfterWithTrim(predicate, leftQuote, rightQuote, true, false) : ReadAfter(predicate, leftQuote, rightQuote, true, false);
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
        /// Gets an object that can iterate through substrings of the current reading scope
        /// that are delimited by Unicode characters outside quotes and satisfying the specified <paramref name="predicate" />.
        /// </summary>
        /// <param name="predicate">A function to test each Unicode character of the current string. Any character that passes this test will be used as a separator.</param>
        /// <param name="leftQuotes">An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when a character satisfying the <paramref name="predicate" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when a character satisfying the <paramref name="predicate" /> is encountered inside a pair of quotes.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned; for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para>
        /// </param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance (or a part of the current string instance)
        /// that are delimited by Unicode characters outside quotes and satisfying the specified predicate.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public IEnumerator<string> GetSplitEnumeratorWithQuotes(Func<char, bool> predicate, char[] leftQuotes, char[] rightQuotes, bool removeEmptyEntries = true, bool trim = false)
        {
            while (!EOF)
            {
                var split = trim ? ReadAfterWithTrim(predicate, leftQuotes, rightQuotes, true, false) : ReadAfter(predicate, leftQuotes, rightQuotes, true, false);
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
        /// Gets an object that can iterate through substrings (represented by <see cref="StringReader"/> objects) of the current reading scope
        /// that are delimited by Unicode characters outside quotes and satisfying the specified <paramref name="predicate" />.
        /// </summary>
        /// <param name="predicate">A function to test each Unicode character of the current string. Any character that passes this test will be used as a separator.</param>
        /// <param name="leftQuote">The left quote paired by <paramref name="rightQuote" /> to escape separators.</param>
        /// <param name="rightQuote">The right quote paired by <paramref name="leftQuote" /> to escape separators.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned; for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para>
        /// </param>
        /// <returns>
        /// An object that can iterate through substrings (represented by <see cref="StringReader"/> objects) in the current string instance (or a part of the current string instance)
        /// that are delimited by Unicode characters outside quotes and satisfying the specified predicate.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public IEnumerator<StringReader> GetSplitReaderEnumeratorWithQuotes(Func<char, bool> predicate, char leftQuote, char rightQuote, bool removeEmptyEntries = true, bool trim = false)
        {
            while (!EOF)
            {
                var split = trim ? ReadAfterWithTrimAsReader(predicate, leftQuote, rightQuote, true, false) : ReadAfterAsReader(predicate, leftQuote, rightQuote, true, false);
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
                        if (!removeEmptyEntries) yield return EmptyReader;
                        yield break;
                    }
                }
            }
        }

        /// <summary>
        /// Gets an object that can iterate through substrings (represented by <see cref="StringReader"/> objects) of the current reading scope
        /// that are delimited by Unicode characters outside quotes and satisfying the specified <paramref name="predicate" />.
        /// </summary>
        /// <param name="predicate">A function to test each Unicode character of the current string. Any character that passes this test will be used as a separator.</param>
        /// <param name="leftQuotes">An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when a character satisfying the <paramref name="predicate" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when a character satisfying the <paramref name="predicate" /> is encountered inside a pair of quotes.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned; for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para>
        /// </param>
        /// <returns>
        /// An object that can iterate through substrings (represented by <see cref="StringReader"/> objects) in the current string instance (or a part of the current string instance)
        /// that are delimited by Unicode characters outside quotes and satisfying the specified predicate.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public IEnumerator<StringReader> GetSplitReaderEnumeratorWithQuotes(Func<char, bool> predicate, char[] leftQuotes, char[] rightQuotes, bool removeEmptyEntries = true, bool trim = false)
        {
            while (!EOF)
            {
                var split = trim ? ReadAfterWithTrimAsReader(predicate, leftQuotes, rightQuotes, true, false) : ReadAfterAsReader(predicate, leftQuotes, rightQuotes, true, false);
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
                        if (!removeEmptyEntries) yield return EmptyReader;
                        yield break;
                    }
                }
            }
        }

        #endregion

        #region Single Char

        /// <summary>
        /// Gets an object that can iterate through substrings of the current reading scope that are delimited by Unicode characters outside quotes.
        /// </summary>
        /// <param name="separator">A Unicode character as the separator.</param>
        /// <param name="leftQuote">The left quote paired by <paramref name="rightQuote" /> to escape separators.</param>
        /// <param name="rightQuote">The right quote paired by <paramref name="leftQuote" /> to escape separators.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned; for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para>
        /// </param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance (or a part of the current string instance) that are delimited by Unicode characters outside quotes.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public IEnumerator<string> GetSplitEnumeratorWithQuotes(char separator, char leftQuote, char rightQuote, bool removeEmptyEntries = true, bool trim = false)
        {
            while (!EOF)
            {
                var split = trim ? ReadAfterWithTrim(separator, leftQuote, rightQuote, true, false) : ReadAfter(separator, leftQuote, rightQuote, true, false);
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
        /// Gets an object that can iterate through substrings of the current reading scope
        /// that are delimited by Unicode characters outside quotes and satisfying the specified <paramref name="predicate" />.
        /// </summary>
        /// <param name="separator">A Unicode character as the separator.</param>
        /// <param name="leftQuotes">An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when a character satisfying the <paramref name="predicate" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when a character satisfying the <paramref name="predicate" /> is encountered inside a pair of quotes.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned; for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para>
        /// </param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance (or a part of the current string instance) that are delimited by Unicode characters outside quotes.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public IEnumerator<string> GetSplitEnumeratorWithQuotes(char separator, char[] leftQuotes, char[] rightQuotes, bool removeEmptyEntries = true, bool trim = false)
        {
            while (!EOF)
            {
                var split = trim ? ReadAfterWithTrim(separator, leftQuotes, rightQuotes, true, false) : ReadAfter(separator, leftQuotes, rightQuotes, true, false);
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
        /// Gets an object that can iterate through substrings (represented by <see cref="StringReader"/> objects) of the current reading scope that are delimited by Unicode characters outside quotes.
        /// </summary>
        /// <param name="separator">A Unicode character as the separator.</param>
        /// <param name="leftQuote">The left quote paired by <paramref name="rightQuote" /> to escape separators.</param>
        /// <param name="rightQuote">The right quote paired by <paramref name="leftQuote" /> to escape separators.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned; for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para>
        /// </param>
        /// <returns>
        /// An object that can iterate through substrings (represented by <see cref="StringReader"/> objects) in the current string instance (or a part of the current string instance) that are delimited by Unicode characters outside quotes.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public IEnumerator<StringReader> GetSplitReaderEnumeratorWithQuotes(char separator, char leftQuote, char rightQuote, bool removeEmptyEntries = true, bool trim = false)
        {
            while (!EOF)
            {
                var split = trim ? ReadAfterWithTrimAsReader(separator, leftQuote, rightQuote, true, false) : ReadAfterAsReader(separator, leftQuote, rightQuote, true, false);
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
                        if (!removeEmptyEntries) yield return EmptyReader;
                        yield break;
                    }
                }
            }
        }

        /// <summary>
        /// Gets an object that can iterate through substrings (represented by <see cref="StringReader"/> objects) of the current reading scope
        /// that are delimited by Unicode characters outside quotes and satisfying the specified <paramref name="predicate" />.
        /// </summary>
        /// <param name="separator">A Unicode character as the separator.</param>
        /// <param name="leftQuotes">An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when a character satisfying the <paramref name="predicate" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when a character satisfying the <paramref name="predicate" /> is encountered inside a pair of quotes.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned; for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para>
        /// </param>
        /// <returns>
        /// An object that can iterate through substrings (represented by <see cref="StringReader"/> objects) in the current string instance (or a part of the current string instance) that are delimited by Unicode characters outside quotes.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public IEnumerator<StringReader> GetSplitReaderEnumeratorWithQuotes(char separator, char[] leftQuotes, char[] rightQuotes, bool removeEmptyEntries = true, bool trim = false)
        {
            while (!EOF)
            {
                var split = trim ? ReadAfterWithTrimAsReader(separator, leftQuotes, rightQuotes, true, false) : ReadAfterAsReader(separator, leftQuotes, rightQuotes, true, false);
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
                        if (!removeEmptyEntries) yield return EmptyReader;
                        yield break;
                    }
                }
            }
        }

        #endregion

        #region Multiple Chars

        /// <summary>
        /// Gets an object that can iterate through substrings of the current reading scope that are delimited by Unicode characters outside quotes.
        /// </summary>
        /// <param name="separators">Unicode characters as the separators.</param>
        /// <param name="leftQuote">The left quote paired by <paramref name="rightQuote" /> to escape separators.</param>
        /// <param name="rightQuote">The right quote paired by <paramref name="leftQuote" /> to escape separators.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned; for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para>
        /// </param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance (or a part of the current string instance) that are delimited by Unicode characters outside quotes.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public IEnumerator<string> GetSplitEnumeratorWithQuotes(char[] separators, char leftQuote, char rightQuote, bool removeEmptyEntries = true, bool trim = false)
        {
            while (!EOF)
            {
                var split = trim ? ReadAfterWithTrim(separators, leftQuote, rightQuote, true, false) : ReadAfter(separators, leftQuote, rightQuote, true, false);
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
        /// Gets an object that can iterate through substrings of the current reading scope
        /// that are delimited by Unicode characters outside quotes and satisfying the specified <paramref name="predicate" />.
        /// </summary>
        /// <param name="separators">Unicode characters as the separators.</param>
        /// <param name="leftQuotes">An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when a character satisfying the <paramref name="predicate" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when a character satisfying the <paramref name="predicate" /> is encountered inside a pair of quotes.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned; for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para>
        /// </param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance (or a part of the current string instance) that are delimited by Unicode characters outside quotes.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public IEnumerator<string> GetSplitEnumeratorWithQuotes(char[] separators, char[] leftQuotes, char[] rightQuotes, bool removeEmptyEntries = true, bool trim = false)
        {
            while (!EOF)
            {
                var split = trim ? ReadAfterWithTrim(separators, leftQuotes, rightQuotes, true, false) : ReadAfter(separators, leftQuotes, rightQuotes, true, false);
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
        /// Gets an object that can iterate through substrings (represented by <see cref="StringReader"/> objects) of the current reading scope that are delimited by Unicode characters outside quotes.
        /// </summary>
        /// <param name="separators">Unicode characters as the separators.</param>
        /// <param name="leftQuote">The left quote paired by <paramref name="rightQuote" /> to escape separators.</param>
        /// <param name="rightQuote">The right quote paired by <paramref name="leftQuote" /> to escape separators.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned; for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para>
        /// </param>
        /// <returns>
        /// An object that can iterate through substrings (represented by <see cref="StringReader"/> objects) in the current string instance (or a part of the current string instance) that are delimited by Unicode characters outside quotes.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public IEnumerator<StringReader> GetSplitReaderEnumeratorWithQuotes(char[] separators, char leftQuote, char rightQuote, bool removeEmptyEntries = true, bool trim = false)
        {
            while (!EOF)
            {
                var split = trim ? ReadAfterWithTrimAsReader(separators, leftQuote, rightQuote, true, false) : ReadAfterAsReader(separators, leftQuote, rightQuote, true, false);
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
                        if (!removeEmptyEntries) yield return EmptyReader;
                        yield break;
                    }
                }
            }
        }

        /// <summary>
        /// Gets an object that can iterate through substrings (represented by <see cref="StringReader"/> objects) of the current reading scope
        /// that are delimited by Unicode characters outside quotes and satisfying the specified <paramref name="predicate" />.
        /// </summary>
        /// <param name="separators">Unicode characters as the separators.</param>
        /// <param name="leftQuotes">An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when a character satisfying the <paramref name="predicate" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when a character satisfying the <paramref name="predicate" /> is encountered inside a pair of quotes.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned; for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para>
        /// </param>
        /// <returns>
        /// An object that can iterate through substrings (represented by <see cref="StringReader"/> objects) in the current string instance (or a part of the current string instance) that are delimited by Unicode characters outside quotes.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public IEnumerator<StringReader> GetSplitReaderEnumeratorWithQuotes(char[] separators, char[] leftQuotes, char[] rightQuotes, bool removeEmptyEntries = true, bool trim = false)
        {
            while (!EOF)
            {
                var split = trim ? ReadAfterWithTrimAsReader(separators, leftQuotes, rightQuotes, true, false) : ReadAfterAsReader(separators, leftQuotes, rightQuotes, true, false);
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
                        if (!removeEmptyEntries) yield return EmptyReader;
                        yield break;
                    }
                }
            }
        }
        #endregion
    }
}
