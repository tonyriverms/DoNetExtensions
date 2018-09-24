using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Text
{
    public partial class StringReader
    {
        #region Single Keychar

        #region Single Keychar, Without Quotes

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar"/> is encountered.
        /// The current position after executing this method depends on the <paramref name="options"/>.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// If <c>ReadeOptions.ReadToEnd</c> is specified in <paramref name="options"/>, then a substring starting from the current position of the reading scope to the position of the first occurrence of <paramref name="keychar"/> within the search scope when the keychar is found, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found.
        /// <para>If <c>ReadeOptions.ReadToEnd</c> is not specified, then a substring starting from the current position of the reading scope to the position of the first occurrence of <paramref name="keychar"/> within the search scope when the keychar is found, or <c>null</c> if such character is not found.</para>
        /// <para>The position of this reader after executing this method depends on if <c>ReadOptions.StopAfterKey</c> is specified. If <c>ReadOptions.StopAfterKey</c> is specified, then the <paramref name="keychar"/> is included in the returned substring if <c>ReadOptions.DiscardKey</c> is also selected.</para>
        /// <para>NOTE that the white spaces at the beginning of the substring will be trimmed if <c>ReadeOptions.TrimStart</c> is specified, and the white spaces at the end of the substring will be trimmed if <c>ReadeOptions.TrimEnd</c> is specified. Also NOTE that <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadTo(char keychar, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = options.HasFlag(ReadOptions.InLine) ? UnderlyingString.InlineIndexOf(keychar, CurrentPosition, EndPosition - CurrentPosition) : UnderlyingString.IndexOf(keychar, CurrentPosition, EndPosition - CurrentPosition);
            return _innerReadTo(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered.
        /// The reader stops at the position of the encountered keychar and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found, or <c>null</c> if such character is not found.</para>
        /// <para>NOTE that the white spaces at both ends of the substring will be trimmed. Also <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadBeforeWithTrim(char keychar, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;

            return ReadTo(keychar, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered.
        /// The reader stops at the position next to the <paramref name="keychar" /> and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered.</param>
        /// <param name="discardKeychar"><c>true</c> if the <paramref name="keychar" /> should be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found, or <c>null</c> if such character is not found.</para>
        /// <para>NOTE that whether the <paramref name="keychar" /> is included in the returned substring depends on <paramref name="discardKeychar"/>, and the white spaces at both ends of the substring will be trimmed. Also NOTE <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadAfterWithTrim(char keychar, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychar, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered.
        /// The reader stops at the position of the encountered keychar.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found, or <c>null</c> if such character is not found.</para>
        /// <para>NOTE that <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadBefore(char keychar, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadTo(keychar, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered.
        /// The reader stops at the position next to the encountered keychar.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found, or <c>null</c> if such character is not found.</para>
        /// <para>NOTE that whether the <paramref name="keychar" /> is included in the returned substring depends on <paramref name="discardKeychar"/>, and <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadAfter(char keychar, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychar, options);
        }

        #endregion

        #region Single Keychar, Single Pair of Quotes

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// If <c>ReadeOptions.ReadToEnd</c> is specified in <paramref name="options"/>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <c>ReadeOptions.ReadToEnd</c> is not specified, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>The position of this reader after executing this method depends on if <see cref="ReadOptions.StopAfterKey"/> is specified. If <see cref="ReadOptions.StopAfterKey"/> is specified, then the <paramref name="keychar"/> is included in the returned substring if <see cref="ReadOptions.DiscardKey"/> is also selected.</para>
        /// <para>NOTE the white spaces at the beginning of the substring will be trimmed if <c>ReadeOptions.TrimStart</c> is specified, and the white spaces at the end of the substring will be trimmed if <c>ReadeOptions.TrimEnd</c> is specified. Also NOTE <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadTo(char keychar, char leftQuote, char rightQuote,
            ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = UnderlyingString.IndexOfWithQuotes(keychar, CurrentPosition, EndPosition - CurrentPosition, leftQuote, rightQuote);
            return _innerReadTo(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="quoteEscape">A character for escaping the quotes in the string. Note the escaped quotes will not be solved in the returned string of this method.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// If <c>ReadeOptions.ReadToEnd</c> is specified in <paramref name="options" />, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <c>ReadeOptions.ReadToEnd</c> is not specified, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para><para>The position of this reader after executing this method depends on if <see cref="ReadOptions.StopAfterKey" /> is specified. If <see cref="ReadOptions.StopAfterKey" /> is specified, then the <paramref name="keychar" /> is included in the returned substring if <see cref="ReadOptions.DiscardKey" /> is also selected.</para><para>NOTE the white spaces at the beginning of the substring will be trimmed if <c>ReadeOptions.TrimStart</c> is specified, and the white spaces at the end of the substring will be trimmed if <c>ReadeOptions.TrimEnd</c> is specified. Also NOTE <see cref="String.Empty" /> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadTo(char keychar, char leftQuote, char rightQuote, char quoteEscape,
            ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = UnderlyingString.IndexOfWithQuotes(keychar, CurrentPosition, EndPosition - CurrentPosition, leftQuote, rightQuote, quoteEscape);
            return _innerReadTo(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The reader stops at the position of the first character of this Keychar and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that the white spaces at both ends of the substring will be trimmed. Also <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadBeforeWithTrim(char keychar, char leftQuote, char rightQuote, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadTo(keychar, leftQuote, rightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The reader stops at the position next to the last character of the encountered keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="discardKeychar">If set to <c>true</c>, the <paramref name="keychar" />
        /// will be discarded and not be included in the returned substring.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the <pararef name="keychar" /> is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and the white spaces at both ends of the substring will be trimmed. Also NOTE <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadAfterWithTrim(char keychar, char leftQuote, char rightQuote, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychar, leftQuote, rightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The reader stops at the position of the encountered keychar.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadBefore(char keychar, char leftQuote, char rightQuote, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadTo(keychar, leftQuote, rightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The reader stops at the position next to the encountered keychar.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="discardKeychar">If set to <c>true</c>, the <paramref name="keychar" />
        /// will be discarded and not be included in the returned substring.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the <pararef name="keychar" /> is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadAfter(char keychar, char leftQuote, char rightQuote, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychar, leftQuote, rightQuote, options);
        }

        #endregion

        #region Single Keychar, Multiple Pairs of Quotes

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// If <c>ReadeOptions.ReadToEnd</c> is specified in <paramref name="options"/>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <c>ReadeOptions.ReadToEnd</c> is not specified, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>The position of this reader after executing this method depends on if <c>ReadOptions.StopAfterKey</c> is specified. If <c>ReadOptions.StopAfterKey</c> is specified, then the character satisfying the <paramref name="predicate" /> is included in the returned substring if <c>ReadOptions.DiscardKey</c> is also selected.</para>
        /// <para>NOTE that the white spaces at the beginning of the substring will be trimmed if <c>ReadeOptions.TrimStart</c> is specified, and the white spaces at the end of the substring will be trimmed if <c>ReadeOptions.TrimEnd</c> is specified. Also NOTE that <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadTo(char keychar, char[] leftQuotes, char[] rightQuotes,
            ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = UnderlyingString.IndexOfWithQuotes(keychar, CurrentPosition, EndPosition - CurrentPosition, leftQuotes, rightQuotes);
            return _innerReadTo(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The reader stops at the position of the first character of this Keychar and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered.</param>
        /// <param name="leftQuotes">An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that the white spaces at both ends of the substring will be trimmed. Also <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadBeforeWithTrim(char keychar, char[] leftQuotes, char[] rightQuotes, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadTo(keychar, leftQuotes, rightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The reader stops at the position next to the last character of the encountered keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered.</param>
        /// <param name="leftQuotes">An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the <pararef name="keychar" /> is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and the white spaces at both ends of the substring will be trimmed. Also NOTE <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadAfterWithTrim(char keychar, char[] leftQuotes, char[] rightQuotes, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychar, leftQuotes, rightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The reader stops at the position of the encountered keychar.
        /// </summary>
        /// <param name="Keychar">The reader stops when this character is encountered.</param>
        /// <param name="leftQuotes">An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadBefore(char Keychar, char[] leftQuotes, char[] rightQuotes, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadTo(Keychar, leftQuotes, rightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The reader stops at the position next to the encountered keychar.
        /// </summary>
        /// <param name="Keychar">The reader stops when this character is encountered.</param>
        /// <param name="leftQuotes">An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="discardKeychar">If set to <c>true</c>, the <paramref name="keychar" />
        /// will be discarded and not be included in the returned substring.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the <pararef name="keychar" /> is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadAfter(char Keychar, char[] leftQuotes, char[] rightQuotes, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(Keychar, leftQuotes, rightQuotes, options);
        }

        #endregion

        #region Single Keychar, Two-Layer Quotes

        #region Single Keychar, Two-Layer Quotes #1

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered outside quotes. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// If <c>ReadeOptions.ReadToEnd</c> is specified in <paramref name="options"/>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <c>ReadeOptions.ReadToEnd</c> is not specified, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>The position of this reader after executing this method depends on if <c>ReadOptions.StopAfterKey</c> is specified. If <c>ReadOptions.StopAfterKey</c> is specified, then the character satisfying the <paramref name="predicate" /> is included in the returned substring if <c>ReadOptions.DiscardKey</c> is also selected.</para>
        /// <para>NOTE that the white spaces at the beginning of the substring will be trimmed if <c>ReadeOptions.TrimStart</c> is specified, and the white spaces at the end of the substring will be trimmed if <c>ReadeOptions.TrimEnd</c> is specified. Also NOTE that <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadTo(char keychar, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychar, CurrentPosition, EndPosition, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote);
            return _innerReadTo(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The current reader stops at the position of the encountered keychar and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered outside quotes. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that the white spaces at both ends of the substring will be trimmed. Also <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadBeforeWithTrim(char keychar, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadTo(keychar, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the last character of the encountered keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered outside quotes. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the <pararef name="keychar" /> is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and the white spaces at both ends of the substring will be trimmed. Also NOTE <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadAfterWithTrim(char keychar, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychar, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The current reader stops at the position of the <paramref name="keychar"/>
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered outside quotes. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadBefore(char keychar, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadTo(keychar, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the position of the <paramref name="keychar" />.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered outside quotes. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the <pararef name="keychar" /> is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadAfter(char keychar, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychar, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, options);
        }

        #endregion

        #region Single Keychar, Two-Layer Quotes #2

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered outside quotes. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// If <c>ReadeOptions.ReadToEnd</c> is specified in <paramref name="options"/>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <c>ReadeOptions.ReadToEnd</c> is not specified, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>The position of this reader after executing this method depends on if <c>ReadOptions.StopAfterKey</c> is specified. If <c>ReadOptions.StopAfterKey</c> is specified, then the character satisfying the <paramref name="predicate" /> is included in the returned substring if <c>ReadOptions.DiscardKey</c> is also selected.</para>
        /// <para>NOTE that the white spaces at the beginning of the substring will be trimmed if <c>ReadeOptions.TrimStart</c> is specified, and the white spaces at the end of the substring will be trimmed if <c>ReadeOptions.TrimEnd</c> is specified. Also NOTE that <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadTo(char keychar, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychar, CurrentPosition, EndPosition, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes);
            return _innerReadTo(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The current reader stops at the position of the encountered keychar and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered outside quotes. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that the white spaces at both ends of the substring will be trimmed. Also <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadBeforeWithTrim(char keychar, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadTo(keychar, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the last character of the encountered keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered outside quotes. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the <pararef name="keychar" /> is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and the white spaces at both ends of the substring will be trimmed. Also NOTE <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadAfterWithTrim(char keychar, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychar, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The current reader stops at the position of the <paramref name="keychar"/>
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered outside quotes. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadBefore(char keychar, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadTo(keychar, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the position of the <paramref name="keychar" />.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered outside quotes. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the <pararef name="keychar" /> is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadAfter(char keychar, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychar, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        #endregion

        #region Single Keychar, Two-Layer Quotes #3

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered outside quotes. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// If <c>ReadeOptions.ReadToEnd</c> is specified in <paramref name="options"/>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <c>ReadeOptions.ReadToEnd</c> is not specified, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>The position of this reader after executing this method depends on if <c>ReadOptions.StopAfterKey</c> is specified. If <c>ReadOptions.StopAfterKey</c> is specified, then the character satisfying the <paramref name="predicate" /> is included in the returned substring if <c>ReadOptions.DiscardKey</c> is also selected.</para>
        /// <para>NOTE that the white spaces at the beginning of the substring will be trimmed if <c>ReadeOptions.TrimStart</c> is specified, and the white spaces at the end of the substring will be trimmed if <c>ReadeOptions.TrimEnd</c> is specified. Also NOTE that <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadTo(char keychar, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychar, CurrentPosition, EndPosition, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote);
            return _innerReadTo(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The current reader stops at the position of the encountered keychar and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered outside quotes. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that the white spaces at both ends of the substring will be trimmed. Also <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadBeforeWithTrim(char keychar, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadTo(keychar, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the last character of the encountered keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered outside quotes. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the <pararef name="keychar" /> is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and the white spaces at both ends of the substring will be trimmed. Also NOTE <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadAfterWithTrim(char keychar, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychar, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The current reader stops at the position of the <paramref name="keychar"/>
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered outside quotes. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadBefore(char keychar, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadTo(keychar, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the position of the <paramref name="keychar" />.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered outside quotes. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the <pararef name="keychar" /> is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadAfter(char keychar, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychar, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, options);
        }

        #endregion

        #region Single Keychar, Two-Layer Quotes #4

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered outside quotes. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// If <c>ReadeOptions.ReadToEnd</c> is specified in <paramref name="options"/>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <c>ReadeOptions.ReadToEnd</c> is not specified, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>The position of this reader after executing this method depends on if <c>ReadOptions.StopAfterKey</c> is specified. If <c>ReadOptions.StopAfterKey</c> is specified, then the character satisfying the <paramref name="predicate" /> is included in the returned substring if <c>ReadOptions.DiscardKey</c> is also selected.</para>
        /// <para>NOTE that the white spaces at the beginning of the substring will be trimmed if <c>ReadeOptions.TrimStart</c> is specified, and the white spaces at the end of the substring will be trimmed if <c>ReadeOptions.TrimEnd</c> is specified. Also NOTE that <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadTo(char keychar, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychar, CurrentPosition, EndPosition, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes);
            return _innerReadTo(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The current reader stops at the position of the encountered keychar and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered outside quotes. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that the white spaces at both ends of the substring will be trimmed. Also <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadBeforeWithTrim(char keychar, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadTo(keychar, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the last character of the encountered keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered outside quotes. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the <pararef name="keychar" /> is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and the white spaces at both ends of the substring will be trimmed. Also NOTE <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadAfterWithTrim(char keychar, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychar, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The current reader stops at the position of the <paramref name="keychar"/>
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered outside quotes. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadBefore(char keychar, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadTo(keychar, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the position of the <paramref name="keychar" />.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered outside quotes. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of the <paramref name="keychar" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the <pararef name="keychar" /> is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadAfter(char keychar, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychar, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        #endregion

        #endregion

        #endregion

        #region Multiple Keychars, Without HitIndex

        #region Multiple Keychars, Without Quotes

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars"/> is encountered.
        /// The reader's position after executing this method depends on the <paramref name="options"/>.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// If <c>ReadeOptions.ReadToEnd</c> is specified in <paramref name="options"/>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found.
        /// <para>If <c>ReadeOptions.ReadToEnd</c> is not specified, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found, or <c>null</c> if such character is not found.</para>
        /// <para>The position of this reader after executing this method depends on if <c>ReadOptions.StopAfterKey</c> is specified. If <c>ReadOptions.StopAfterKey</c> is specified, then the character satisfying the <paramref name="predicate" /> is included in the returned substring if <c>ReadOptions.DiscardKey</c> is also selected.</para>
        /// <para>NOTE that the white spaces at the beginning of the substring will be trimmed if <c>ReadeOptions.TrimStart</c> is specified, and the white spaces at the end of the substring will be trimmed if <c>ReadeOptions.TrimEnd</c> is specified. Also NOTE that <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadTo(char[] keychars, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = UnderlyingString.IndexOfAny(keychars, CurrentPosition);
            return _innerReadTo(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered.
        /// The reader stops at the position of the first character of this Keychar and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found, or <c>null</c> if such character is not found.</para>
        /// <para>NOTE that the white spaces at both ends of the substring will be trimmed. Also <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadBeforeWithTrim(char[] keychars, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadTo(keychars, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered.
        /// The reader stops at the position next to the last character of the encountered keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the encountered keychar is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and the white spaces at both ends of the substring will be trimmed. Also NOTE <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadAfterWithTrim(char[] keychars, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychars, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars"/> is encountered.
        /// The reader stops at the position of the encountered keychar.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found, or <c>null</c> if such character is not found.</para>
        /// <para>NOTE that <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadBefore(char[] keychars, bool readToEndIfKeycharNotFound = true)
        {
            return ReadTo(keychars, readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars"/> is encountered.
        /// The reader stops at the position next to the encountered keychar.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found, or <c>null</c> if such character is not found.</para>
        /// <para>NOTE that whether the encountered keychar is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadAfter(char[] keychars, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychars, options);
        }

        #endregion

        #region Multiple Keychars, Single Pair of Quotes

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// If <c>ReadeOptions.ReadToEnd</c> is specified in <paramref name="options"/>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <c>ReadeOptions.ReadToEnd</c> is not specified, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>The position of this reader after executing this method depends on if <c>ReadOptions.StopAfterKey</c> is specified. If <c>ReadOptions.StopAfterKey</c> is specified, then the character satisfying the <paramref name="predicate" /> is included in the returned substring if <c>ReadOptions.DiscardKey</c> is also selected.</para>
        /// <para>NOTE that the white spaces at the beginning of the substring will be trimmed if <c>ReadeOptions.TrimStart</c> is specified, and the white spaces at the end of the substring will be trimmed if <c>ReadeOptions.TrimEnd</c> is specified. Also NOTE that <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadTo(char[] keychars, char leftQuote, char rightQuote, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychars, CurrentPosition, EndPosition - CurrentPosition, leftQuote, rightQuote);
            return _innerReadTo(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The reader stops at the position of the first character of this Keychar and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that the white spaces at both ends of the substring will be trimmed. Also <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadBeforeWithTrim(char[] keychars, char leftQuote, char rightQuote, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadTo(keychars, leftQuote, rightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The reader stops at the position next to the last character of the encountered keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the encountered keychar is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and the white spaces at both ends of the substring will be trimmed. Also NOTE <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadAfterWithTrim(char[] keychars, char leftQuote, char rightQuote, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychars, leftQuote, rightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The reader stops at the position of the encountered keychar.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <para>NOTE that <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadBefore(char[] keychars, char leftQuote, char rightQuote, bool readToEndIfKeycharNotFound = true)
        {
            return ReadTo(keychars, leftQuote, rightQuote, readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The reader stops at the position next to the encountered keychar.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when any of the <paramref name="keychars"/> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when any of the <paramref name="keychars"/> is encountered inside a pair of quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the encountered keychar is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadAfter(char[] keychars, char leftQuote, char rightQuote, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options = ReadOptions.ReadToEnd;
            return ReadTo(keychars, leftQuote, rightQuote, options);
        }

        #endregion

        #region Multiple Keychars, Multiple Pairs of Quotes

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// If <c>ReadeOptions.ReadToEnd</c> is specified in <paramref name="options"/>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <c>ReadeOptions.ReadToEnd</c> is not specified, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>The position of this reader after executing this method depends on if <c>ReadOptions.StopAfterKey</c> is specified. If <c>ReadOptions.StopAfterKey</c> is specified, then the character satisfying the <paramref name="predicate" /> is included in the returned substring if <c>ReadOptions.DiscardKey</c> is also selected.</para>
        /// <para>NOTE that the white spaces at the beginning of the substring will be trimmed if <c>ReadeOptions.TrimStart</c> is specified, and the white spaces at the end of the substring will be trimmed if <c>ReadeOptions.TrimEnd</c> is specified. Also NOTE that <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadTo(char[] keychars, char[] leftQuotes, char[] rightQuotes, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychars, CurrentPosition, EndPosition - CurrentPosition, leftQuotes, rightQuotes);
            return _innerReadTo(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The reader stops at the position of the first character of this Keychar and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that the white spaces at both ends of the substring will be trimmed. Also <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadBeforeWithTrim(char[] keychars, char[] leftQuotes, char[] rightQuotes, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadTo(keychars, leftQuotes, rightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The reader stops at the position next to the last character of the encountered keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the encountered keychar is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and the white spaces at both ends of the substring will be trimmed. Also NOTE <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadAfterWithTrim(char[] keychars, char[] leftQuotes, char[] rightQuotes, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychars, leftQuotes, rightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The reader stops at the position of the encountered keychar.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <para>NOTE that <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadBefore(char[] keychars, char[] leftQuotes, char[] rightQuotes, bool readToEndIfKeycharNotFound = true)
        {
            return ReadTo(keychars, leftQuotes, rightQuotes, readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The reader stops at the position next to the encountered keychar.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the encountered keychar is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadAfter(char[] keychars, char[] leftQuotes, char[] rightQuotes, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychars, leftQuotes, rightQuotes, options);
        }

        #endregion

        #region Multiple Keychars, Two-Layer Quotes

        #region Multiple Keychars, Two-Layer Quotes #1

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// If <c>ReadeOptions.ReadToEnd</c> is specified in <paramref name="options"/>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <c>ReadeOptions.ReadToEnd</c> is not specified, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>The position of this reader after executing this method depends on if <c>ReadOptions.StopAfterKey</c> is specified. If <c>ReadOptions.StopAfterKey</c> is specified, then the character satisfying the <paramref name="predicate" /> is included in the returned substring if <c>ReadOptions.DiscardKey</c> is also selected.</para>
        /// <para>NOTE that the white spaces at the beginning of the substring will be trimmed if <c>ReadeOptions.TrimStart</c> is specified, and the white spaces at the end of the substring will be trimmed if <c>ReadeOptions.TrimEnd</c> is specified. Also NOTE that <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadTo(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote,
            ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychars, CurrentPosition, EndPosition, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote);
            return _innerReadTo(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position of the <paramref name="keychars" /> and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that the white spaces at both ends of the substring will be trimmed. Also <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadBeforeWithTrim(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadTo(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the last character of the encountered keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the encountered keychar is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and the white spaces at both ends of the substring will be trimmed. Also NOTE <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadAfterWithTrim(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position of the encountered character of the <paramref name="keychars"/>
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <para>NOTE that <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadBefore(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadTo(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the position of the <paramref name="keychar" />.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the encountered keychar is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadAfter(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, options);
        }

        #endregion

        #region Multiple Keychars, Two-Layer Quotes #2

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// If <c>ReadeOptions.ReadToEnd</c> is specified in <paramref name="options"/>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <c>ReadeOptions.ReadToEnd</c> is not specified, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>The position of this reader after executing this method depends on if <c>ReadOptions.StopAfterKey</c> is specified. If <c>ReadOptions.StopAfterKey</c> is specified, then the character satisfying the <paramref name="predicate" /> is included in the returned substring if <c>ReadOptions.DiscardKey</c> is also selected.</para>
        /// <para>NOTE that the white spaces at the beginning of the substring will be trimmed if <c>ReadeOptions.TrimStart</c> is specified, and the white spaces at the end of the substring will be trimmed if <c>ReadeOptions.TrimEnd</c> is specified. Also NOTE that <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadTo(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychars, CurrentPosition, EndPosition, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes);
            return _innerReadTo(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position of the <paramref name="keychars" /> and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that the white spaces at both ends of the substring will be trimmed. Also <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadBeforeWithTrim(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadTo(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the last character of the encountered keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the encountered keychar is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and the white spaces at both ends of the substring will be trimmed. Also NOTE <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadAfterWithTrim(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position of the encountered character of the <paramref name="keychars"/>
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <para>NOTE that <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadBefore(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadTo(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the position of the <paramref name="keychar" />.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the encountered keychar is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadAfter(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        #endregion

        #region Multiple Keychars, Two-Layer Quotes #3

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// If <c>ReadeOptions.ReadToEnd</c> is specified in <paramref name="options"/>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <c>ReadeOptions.ReadToEnd</c> is not specified, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>The position of this reader after executing this method depends on if <c>ReadOptions.StopAfterKey</c> is specified. If <c>ReadOptions.StopAfterKey</c> is specified, then the character satisfying the <paramref name="predicate" /> is included in the returned substring if <c>ReadOptions.DiscardKey</c> is also selected.</para>
        /// <para>NOTE that the white spaces at the beginning of the substring will be trimmed if <c>ReadeOptions.TrimStart</c> is specified, and the white spaces at the end of the substring will be trimmed if <c>ReadeOptions.TrimEnd</c> is specified. Also NOTE that <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadTo(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychars, CurrentPosition, EndPosition, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote);
            return _innerReadTo(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position of the <paramref name="keychars" /> and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that the white spaces at both ends of the substring will be trimmed. Also <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadBeforeWithTrim(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadTo(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the last character of the encountered keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the encountered keychar is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and the white spaces at both ends of the substring will be trimmed. Also NOTE <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadAfterWithTrim(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position of the encountered character of the <paramref name="keychars"/>
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <para>NOTE that <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadBefore(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadTo(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the position of the encountered character of the <paramref name="keychars" />.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the encountered keychar is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadAfter(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, options);
        }

        #endregion

        #region Multiple Keychars, Two-Layer Quotes #4

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// If <c>ReadeOptions.ReadToEnd</c> is specified in <paramref name="options"/>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <c>ReadeOptions.ReadToEnd</c> is not specified, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>The position of this reader after executing this method depends on if <c>ReadOptions.StopAfterKey</c> is specified. If <c>ReadOptions.StopAfterKey</c> is specified, then the character satisfying the <paramref name="predicate" /> is included in the returned substring if <c>ReadOptions.DiscardKey</c> is also selected.</para>
        /// <para>NOTE that the white spaces at the beginning of the substring will be trimmed if <c>ReadeOptions.TrimStart</c> is specified, and the white spaces at the end of the substring will be trimmed if <c>ReadeOptions.TrimEnd</c> is specified. Also NOTE that <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadTo(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychars, CurrentPosition, EndPosition, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes);
            return _innerReadTo(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position of the <paramref name="keychars" /> and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that the white spaces at both ends of the substring will be trimmed. Also <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadBeforeWithTrim(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadTo(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the last character of the encountered keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the encountered keychar is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and the white spaces at both ends of the substring will be trimmed. Also NOTE <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadAfterWithTrim(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position of the encountered character of the <paramref name="keychars"/>
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <para>NOTE that <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadBefore(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadTo(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the position of the encountered character of the <paramref name="keychars" />.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the encountered keychar is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadAfter(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        #endregion

        #endregion

        #endregion

        #region Multiple Keychars, With HitIndex

        #region Multiple Keychars, Without Quotes

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars"/> is encountered.
        /// The reader's position after executing this method depends on the <paramref name="options"/>.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// If <c>ReadeOptions.ReadToEnd</c> is specified in <paramref name="options"/>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found.
        /// <para>If <c>ReadeOptions.ReadToEnd</c> is not specified, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found, or <c>null</c> if such character is not found.</para>
        /// <para>The position of this reader after executing this method depends on if <c>ReadOptions.StopAfterKey</c> is specified. If <c>ReadOptions.StopAfterKey</c> is specified, then the character satisfying the <paramref name="predicate" /> is included in the returned substring if <c>ReadOptions.DiscardKey</c> is also selected.</para>
        /// <para>NOTE that the white spaces at the beginning of the substring will be trimmed if <c>ReadeOptions.TrimStart</c> is specified, and the white spaces at the end of the substring will be trimmed if <c>ReadeOptions.TrimEnd</c> is specified. Also NOTE that <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadTo(char[] keychars, out int hitIndex, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = UnderlyingString.IndexOfAny(keychars, CurrentPosition, out hitIndex);
            return _innerReadTo(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered.
        /// The reader stops at the position of the first character of this Keychar and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found, or <c>null</c> if such character is not found.</para>
        /// <para>NOTE that the white spaces at both ends of the substring will be trimmed. Also <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadBeforeWithTrim(char[] keychars, out int hitIndex, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadTo(keychars, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered.
        /// The reader stops at the position next to the last character of the encountered keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the encountered keychar is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and the white spaces at both ends of the substring will be trimmed. Also NOTE <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadAfterWithTrim(char[] keychars, out int hitIndex, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychars, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars"/> is encountered.
        /// The reader stops at the position of the encountered keychar.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found, or <c>null</c> if such character is not found.</para>
        /// <para>NOTE that <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadBefore(char[] keychars, out int hitIndex, bool readToEndIfKeycharNotFound = true)
        {
            return ReadTo(keychars, out hitIndex, readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars"/> is encountered.
        /// The reader stops at the position next to the encountered keychar.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found, or <c>null</c> if such character is not found.</para>
        /// <para>NOTE that whether the encountered keychar is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadAfter(char[] keychars, out int hitIndex, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychars, out hitIndex, options);
        }

        #endregion

        #region Multiple Keychars, Single Pair of Quotes

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// If <c>ReadeOptions.ReadToEnd</c> is specified in <paramref name="options"/>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <c>ReadeOptions.ReadToEnd</c> is not specified, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>The position of this reader after executing this method depends on if <c>ReadOptions.StopAfterKey</c> is specified. If <c>ReadOptions.StopAfterKey</c> is specified, then the character satisfying the <paramref name="predicate" /> is included in the returned substring if <c>ReadOptions.DiscardKey</c> is also selected.</para>
        /// <para>NOTE that the white spaces at the beginning of the substring will be trimmed if <c>ReadeOptions.TrimStart</c> is specified, and the white spaces at the end of the substring will be trimmed if <c>ReadeOptions.TrimEnd</c> is specified. Also NOTE that <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadTo(char[] keychars, char leftQuote, char rightQuote, out int hitIndex, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychars, CurrentPosition, EndPosition - CurrentPosition, leftQuote, rightQuote, out hitIndex);
            return _innerReadTo(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The reader stops at the position of the first character of this Keychar and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that the white spaces at both ends of the substring will be trimmed. Also <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadBeforeWithTrim(char[] keychars, char leftQuote, char rightQuote, out int hitIndex, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadTo(keychars, leftQuote, rightQuote, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The reader stops at the position next to the last character of the encountered keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the encountered keychar is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and the white spaces at both ends of the substring will be trimmed. Also NOTE <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadAfterWithTrim(char[] keychars, char leftQuote, char rightQuote, out int hitIndex, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychars, leftQuote, rightQuote, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The reader stops at the position of the encountered keychar.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <para>NOTE that <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadBefore(char[] keychars, char leftQuote, char rightQuote, out int hitIndex, bool readToEndIfKeycharNotFound = true)
        {
            return ReadTo(keychars, leftQuote, rightQuote, out hitIndex, readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The reader stops at the position next to the encountered keychar.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when any of the <paramref name="keychars"/> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when any of the <paramref name="keychars"/> is encountered inside a pair of quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the encountered keychar is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadAfter(char[] keychars, char leftQuote, char rightQuote, out int hitIndex, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options = ReadOptions.ReadToEnd;
            return ReadTo(keychars, leftQuote, rightQuote, out hitIndex, options);
        }

        #endregion

        #region Multiple Keychars, Multiple Pairs of Quotes

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// If <c>ReadeOptions.ReadToEnd</c> is specified in <paramref name="options"/>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <c>ReadeOptions.ReadToEnd</c> is not specified, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>The position of this reader after executing this method depends on if <c>ReadOptions.StopAfterKey</c> is specified. If <c>ReadOptions.StopAfterKey</c> is specified, then the character satisfying the <paramref name="predicate" /> is included in the returned substring if <c>ReadOptions.DiscardKey</c> is also selected.</para>
        /// <para>NOTE that the white spaces at the beginning of the substring will be trimmed if <c>ReadeOptions.TrimStart</c> is specified, and the white spaces at the end of the substring will be trimmed if <c>ReadeOptions.TrimEnd</c> is specified. Also NOTE that <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadTo(char[] keychars, char[] leftQuotes, char[] rightQuotes, out int hitIndex, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychars, CurrentPosition, EndPosition - CurrentPosition, leftQuotes, rightQuotes, out hitIndex);
            return _innerReadTo(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The reader stops at the position of the first character of this Keychar and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that the white spaces at both ends of the substring will be trimmed. Also <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadBeforeWithTrim(char[] keychars, char[] leftQuotes, char[] rightQuotes, out int hitIndex, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadTo(keychars, leftQuotes, rightQuotes, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The reader stops at the position next to the last character of the encountered keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the encountered keychar is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and the white spaces at both ends of the substring will be trimmed. Also NOTE <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadAfterWithTrim(char[] keychars, char[] leftQuotes, char[] rightQuotes, out int hitIndex, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychars, leftQuotes, rightQuotes, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The reader stops at the position of the encountered keychar.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <para>NOTE that <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadBefore(char[] keychars, char[] leftQuotes, char[] rightQuotes, out int hitIndex, bool readToEndIfKeycharNotFound = true)
        {
            return ReadTo(keychars, leftQuotes, rightQuotes, out hitIndex, readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The reader stops at the position next to the encountered keychar.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the encountered keychar is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadAfter(char[] keychars, char[] leftQuotes, char[] rightQuotes, out int hitIndex, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychars, leftQuotes, rightQuotes, out hitIndex, options);
        }

        #endregion

        #region Multiple Keychars, Two-Layer Quotes

        #region Multiple Keychars, Two-Layer Quotes #1

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// If <c>ReadeOptions.ReadToEnd</c> is specified in <paramref name="options"/>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <c>ReadeOptions.ReadToEnd</c> is not specified, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>The position of this reader after executing this method depends on if <c>ReadOptions.StopAfterKey</c> is specified. If <c>ReadOptions.StopAfterKey</c> is specified, then the character satisfying the <paramref name="predicate" /> is included in the returned substring if <c>ReadOptions.DiscardKey</c> is also selected.</para>
        /// <para>NOTE that the white spaces at the beginning of the substring will be trimmed if <c>ReadeOptions.TrimStart</c> is specified, and the white spaces at the end of the substring will be trimmed if <c>ReadeOptions.TrimEnd</c> is specified. Also NOTE that <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadTo(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex,
            ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychars, CurrentPosition, EndPosition, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, out hitIndex);
            return _innerReadTo(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position of the <paramref name="keychars" /> and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that the white spaces at both ends of the substring will be trimmed. Also <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadBeforeWithTrim(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadTo(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the last character of the encountered keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the encountered keychar is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and the white spaces at both ends of the substring will be trimmed. Also NOTE <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadAfterWithTrim(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position of the encountered character of the <paramref name="keychars"/>
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <para>NOTE that <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadBefore(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadTo(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the position of the <paramref name="keychar" />.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the encountered keychar is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadAfter(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, out hitIndex, options);
        }

        #endregion

        #region Multiple Keychars, Two-Layer Quotes #2

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// If <c>ReadeOptions.ReadToEnd</c> is specified in <paramref name="options"/>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <c>ReadeOptions.ReadToEnd</c> is not specified, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>The position of this reader after executing this method depends on if <c>ReadOptions.StopAfterKey</c> is specified. If <c>ReadOptions.StopAfterKey</c> is specified, then the character satisfying the <paramref name="predicate" /> is included in the returned substring if <c>ReadOptions.DiscardKey</c> is also selected.</para>
        /// <para>NOTE that the white spaces at the beginning of the substring will be trimmed if <c>ReadeOptions.TrimStart</c> is specified, and the white spaces at the end of the substring will be trimmed if <c>ReadeOptions.TrimEnd</c> is specified. Also NOTE that <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadTo(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychars, CurrentPosition, EndPosition, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, out hitIndex);
            return _innerReadTo(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position of the <paramref name="keychars" /> and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that the white spaces at both ends of the substring will be trimmed. Also <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadBeforeWithTrim(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadTo(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the last character of the encountered keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the encountered keychar is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and the white spaces at both ends of the substring will be trimmed. Also NOTE <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadAfterWithTrim(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position of the encountered character of the <paramref name="keychars"/>
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <para>NOTE that <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadBefore(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadTo(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the position of the <paramref name="keychar" />.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the encountered keychar is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadAfter(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, out hitIndex, options);
        }

        #endregion

        #region Multiple Keychars, Two-Layer Quotes #3

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// If <c>ReadeOptions.ReadToEnd</c> is specified in <paramref name="options"/>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <c>ReadeOptions.ReadToEnd</c> is not specified, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>The position of this reader after executing this method depends on if <c>ReadOptions.StopAfterKey</c> is specified. If <c>ReadOptions.StopAfterKey</c> is specified, then the character satisfying the <paramref name="predicate" /> is included in the returned substring if <c>ReadOptions.DiscardKey</c> is also selected.</para>
        /// <para>NOTE that the white spaces at the beginning of the substring will be trimmed if <c>ReadeOptions.TrimStart</c> is specified, and the white spaces at the end of the substring will be trimmed if <c>ReadeOptions.TrimEnd</c> is specified. Also NOTE that <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadTo(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychars, CurrentPosition, EndPosition, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, out hitIndex);
            return _innerReadTo(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position of the <paramref name="keychars" /> and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that the white spaces at both ends of the substring will be trimmed. Also <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadBeforeWithTrim(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadTo(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the last character of the encountered keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the encountered keychar is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and the white spaces at both ends of the substring will be trimmed. Also NOTE <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadAfterWithTrim(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position of the encountered character of the <paramref name="keychars"/>
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <para>NOTE that <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadBefore(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadTo(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the position of the encountered character of the <paramref name="keychars" />.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the encountered keychar is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadAfter(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, out hitIndex, options);
        }

        #endregion

        #region Multiple Keychars, Two-Layer Quotes #4

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// If <c>ReadeOptions.ReadToEnd</c> is specified in <paramref name="options"/>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <c>ReadeOptions.ReadToEnd</c> is not specified, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>The position of this reader after executing this method depends on if <c>ReadOptions.StopAfterKey</c> is specified. If <c>ReadOptions.StopAfterKey</c> is specified, then the character satisfying the <paramref name="predicate" /> is included in the returned substring if <c>ReadOptions.DiscardKey</c> is also selected.</para>
        /// <para>NOTE that the white spaces at the beginning of the substring will be trimmed if <c>ReadeOptions.TrimStart</c> is specified, and the white spaces at the end of the substring will be trimmed if <c>ReadeOptions.TrimEnd</c> is specified. Also NOTE that <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadTo(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychars, CurrentPosition, EndPosition, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, out hitIndex);
            return _innerReadTo(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position of the <paramref name="keychars" /> and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that the white spaces at both ends of the substring will be trimmed. Also <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadBeforeWithTrim(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadTo(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the last character of the encountered keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the encountered keychar is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and the white spaces at both ends of the substring will be trimmed. Also NOTE <see cref="String.Empty"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public string ReadAfterWithTrim(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position of the encountered character of the <paramref name="keychars"/>
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <para>NOTE that <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadBefore(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadTo(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the position of the encountered character of the <paramref name="keychars" />.
        /// </summary>
        /// <param name="keychars">The reader stops when any character in this array is encountered outside quotes. The reader will not stop when an element of the <paramref name="keychars" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found outside quotes.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a substring starting from the current position of the reading scope to the position of the first occurrence of any of the <paramref name="keychars" /> within the search scope when such character is found outside quotes, or <c>null</c> if such character is not found outside quotes.</para>
        /// <para>NOTE that whether the encountered keychar is inclueded in the returned substring depends on <paramref name="discardKeychar"/>, and <see cref="String.Empty"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public string ReadAfter(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadTo(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, out hitIndex, options);
        }

        #endregion

        #endregion

        #endregion
    }
}
