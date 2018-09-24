using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Text
{
    public partial class StringReader
    {
        #region Single Keyword

        #region Single Keyword, Without Quotes

        /// <summary>
        /// Advances the reader and reads until the specified <paramref name="keyword"/> is encountered.
        /// The reader's position after executing this method depends on the <paramref name="options"/>.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>A new string reader that encapsulates a substring read from the underlying string instance of the current reader.</returns>
        public StringReader ReadToAsReader(string keyword, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = UnderlyingString.IndexOf(keyword, CurrentPosition, EndPosition - CurrentPosition, ComparisonType);
            return _innerReadToAsReader(idx, keyword.Length, options);
        }

        /// <summary>
        /// Advances the reader and reads until the specified <paramref name="keyword"/> is encountered.
        /// The reader stops at the position of the first character of this Keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keyword"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>A new string reader that encapsulates a substring read from the underlying string instance of the current reader.</returns>
        public StringReader ReadBeforeWithTrimAsReader(string keyword, bool readToEndIfKeywordNotFound = true)
        {
            var options = readToEndIfKeywordNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keyword, options);
        }

        /// <summary>
        /// Advances the reader and reads until the specified <paramref name="keyword" /> is encountered.
        /// The reader stops at the position next to the last character of the encountered keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keyword"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(string keyword, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keyword, options);
        }

        /// <summary>
        /// Advances the reader and reads until the specified <paramref name="keyword"/> is encountered.
        /// The reader stops at the position of the first character of this Keyword.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keyword"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>A new string reader that encapsulates a substring read from the underlying string instance of the current reader.</returns>
        public StringReader ReadBeforeAsReader(string keyword, bool readToEndIfKeywordNotFound = true)
        {
            return ReadToAsReader(keyword, readToEndIfKeywordNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until the specified <paramref name="keyword" /> is encountered.
        /// The reader stops at the position next to the last character of this Keyword.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keyword"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(string keyword, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keyword, options);
        }

        #endregion

        #region Single Keyword, Single Pair of Quotes

        /// <summary>
        /// Advances the reader and reads until the <paramref name="keyword" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when a keyword is encountered inside quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when a keyword is encountered inside quotes.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(string keyword, char leftQuote, char rightQuote, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = UnderlyingString.IndexOfWithQuotes(keyword, CurrentPosition, EndPosition - CurrentPosition, leftQuote, rightQuote, ComparisonType);
            return _innerReadToAsReader(idx, keyword.Length, options);
        }

        /// <summary>
        /// Advances the reader and reads until the <paramref name="keyword" /> is encountered outside quotes.
        /// The reader stops at the position of the first character of this Keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when a keyword is encountered inside quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when a keyword is encountered inside quotes.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keyword"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(string keyword, char leftQuote, char rightQuote, bool readToEndIfKeywordNotFound = true)
        {
            var options = readToEndIfKeywordNotFound ?
                ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keyword, leftQuote, rightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until the <paramref name="keyword" /> is encountered outside quotes.
        /// The reader stops at the position next to the last character of the encountered keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when a keyword is encountered inside quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when a keyword is encountered inside quotes.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keyword"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(string keyword, char leftQuote, char rightQuote, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keyword, leftQuote, rightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until the <paramref name="keyword" /> is encountered outside quotes.
        /// The reader stops at the position of the first character of this Keyword.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when a keyword is encountered inside quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when a keyword is encountered inside quotes.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keyword"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(string keyword, char leftQuote, char rightQuote, bool readToEndIfKeywordNotFound = true)
        {
            return ReadToAsReader(keyword, leftQuote, rightQuote, readToEndIfKeywordNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until the <paramref name="keyword" /> is encountered outside quotes.
        /// The reader stops at the position next to the last character of this Keyword.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when a keyword is encountered inside quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when a keyword is encountered inside quotes.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keyword"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(string keyword, char leftQuote, char rightQuote, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keyword, leftQuote, rightQuote, options);
        }

        #endregion

        #region Single Keyword, Multiple Pairs of Quotes

        /// <summary>
        /// Advances the reader and reads until the <paramref name="keyword" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(string keyword, char[] leftQuotes, char[] rightQuotes, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = UnderlyingString.IndexOfWithQuotes(keyword, CurrentPosition, EndPosition - CurrentPosition, leftQuotes, rightQuotes, ComparisonType);
            return _innerReadToAsReader(idx, keyword.Length, options);
        }

        /// <summary>
        /// Advances the reader and reads until the <paramref name="keyword" /> is encountered outside quotes.
        /// The reader stops at the position of the first character of this Keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keyword"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(string keyword, char[] leftQuotes, char[] rightQuotes, bool readToEndIfKeywordNotFound = true)
        {
            var options = readToEndIfKeywordNotFound ?
                ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keyword, leftQuotes, rightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until the <paramref name="keyword" /> is encountered outside quotes.
        /// The reader stops at the position next to the last character of the encountered keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="leftQuotes">An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keyword"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(string keyword, char[] leftQuotes, char[] rightQuotes, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keyword, leftQuotes, rightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until the <paramref name="keyword" /> is encountered outside quotes.
        /// The reader stops at the position of the first character of the encountered keyword.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="leftQuotes">An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keyword"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(string keyword, char[] leftQuotes, char[] rightQuotes, bool readToEndIfKeywordNotFound = true)
        {
            return ReadToAsReader(keyword, leftQuotes, rightQuotes, readToEndIfKeywordNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until the <paramref name="keyword" /> is encountered outside quotes.
        /// The reader stops at the position next to the last character of the encountered keyword.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="leftQuotes">An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keyword"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(string keyword, char[] leftQuotes, char[] rightQuotes, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keyword, leftQuotes, rightQuotes, options);
        }

        #endregion

        #region Single Keyword, Two-Layer Quotes

        #region Single Keyword, Two-Layer Quotes #1

        /// <summary>
        /// Advances the reader and reads until the specified keyword is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="options">>Specifies the reading options.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(string keyword, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote,
            ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keyword, CurrentPosition, EndPosition, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, ComparisonType);
            return _innerReadToAsReader(idx, keyword.Length, options);
        }

        /// <summary>
        /// Advances the reader and reads until the specified keyword is encountered outside quotes.
        /// The current reader stops at the position of the keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keyword"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(string keyword, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, bool readToEndIfKeywordNotFound = true)
        {
            var options = readToEndIfKeywordNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keyword, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until the specified keyword is encountered outside quotes.
        /// The current reader stops at the position immediately after the last character of the encountered keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keyword"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(string keyword, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keyword, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until the specified keyword is encountered outside quotes. The current reader stops at the position of the keyword.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keyword"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(string keyword, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, bool readToEndIfKeywordNotFound = true)
        {
            return ReadToAsReader(keyword, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, readToEndIfKeywordNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until the specified keyword is encountered outside quotes. The current reader stops at the position immediately after the last character of the encountered keyword.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keyword"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(string keyword, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keyword, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, options);
        }

        #endregion

        #region Single Keyword, Two-Layer Quotes #2

        /// <summary>
        /// Advances the reader and reads until the specified keyword is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="options">>Specifies the reading options.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(string keyword, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes,
            ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keyword, CurrentPosition, EndPosition, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, ComparisonType);
            return _innerReadToAsReader(idx, keyword.Length, options);
        }

        /// <summary>
        /// Advances the reader and reads until the specified keyword is encountered outside quotes.
        /// The current reader stops at the position of the keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keyword"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(string keyword, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool readToEndIfKeywordNotFound = true)
        {
            var options = readToEndIfKeywordNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keyword, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until the specified keyword is encountered outside quotes.
        /// The current reader stops at the position immediately after the last character of the encountered keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keyword"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(string keyword, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keyword, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until the specified keyword is encountered outside quotes. The current reader stops at the position of the keyword.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keyword"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(string keyword, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool readToEndIfKeywordNotFound = true)
        {
            return ReadToAsReader(keyword, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, readToEndIfKeywordNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until the specified keyword is encountered outside quotes. The current reader stops at the position immediately after the last character of the encountered keyword.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keyword"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(string keyword, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keyword, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        #endregion

        #region Single Keyword, Two-Layer Quotes #3

        /// <summary>
        /// Advances the reader and reads until the specified keyword is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="options">>Specifies the reading options.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(string keyword, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote,
            ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keyword, CurrentPosition, EndPosition, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, ComparisonType);
            return _innerReadToAsReader(idx, keyword.Length, options);
        }

        /// <summary>
        /// Advances the reader and reads until the specified keyword is encountered outside quotes.
        /// The current reader stops at the position of the keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keyword"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(string keyword, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, bool readToEndIfKeywordNotFound = true)
        {
            var options = readToEndIfKeywordNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keyword, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until the specified keyword is encountered outside quotes.
        /// The current reader stops at the position immediately after the last character of the encountered keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keyword"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(string keyword, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keyword, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until the specified keyword is encountered outside quotes. The current reader stops at the position of the keyword.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keyword"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(string keyword, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, bool readToEndIfKeywordNotFound = true)
        {
            return ReadToAsReader(keyword, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, readToEndIfKeywordNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until the specified keyword is encountered outside quotes. The current reader stops at the position immediately after the last character of the encountered keyword.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keyword"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(string keyword, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keyword, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, options);
        }

        #endregion

        #region Single Keyword, Two-Layer Quotes #4

        /// <summary>
        /// Advances the reader and reads until the specified keyword is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="options">>Specifies the reading options.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(string keyword, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes,
            ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keyword, CurrentPosition, EndPosition, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, ComparisonType);
            return _innerReadToAsReader(idx, keyword.Length, options);
        }

        /// <summary>
        /// Advances the reader and reads until the specified keyword is encountered outside quotes.
        /// The current reader stops at the position of the keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keyword"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(string keyword, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool readToEndIfKeywordNotFound = true)
        {
            var options = readToEndIfKeywordNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keyword, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until the specified keyword is encountered outside quotes.
        /// The current reader stops at the position immediately after the last character of the encountered keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keyword"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(string keyword, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keyword, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until the specified keyword is encountered outside quotes. The current reader stops at the position of the keyword.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keyword"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(string keyword, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool readToEndIfKeywordNotFound = true)
        {
            return ReadToAsReader(keyword, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, readToEndIfKeywordNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until the specified keyword is encountered outside quotes. The current reader stops at the position immediately after the last character of the encountered keyword.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keyword"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(string keyword, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keyword, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        #endregion

        #endregion

        #endregion

        #region Multiple Keywords, Without HitIndex

        #region Multiple Keywords, Without Quotes

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(string[] keywords, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var searchResult = UnderlyingString.IndexOfAny(keywords, CurrentPosition, EndPosition - CurrentPosition, ComparisonType);
            return _innerReadToAsReader(searchResult.Position, searchResult.Value.Length, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered.
        /// The reader stops at the position of the first character of this Keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(string[] keywords, bool readToEndIfKeywordNotFound = true)
        {
            var options = readToEndIfKeywordNotFound ?
                ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keywords, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords"/> is encountered.
        /// The reader stops at the position next to the last character of the encountered keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(string[] keywords, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keywords, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords"/> is encountered.
        /// The reader stops at the position of the first character of this Keyword.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>A new string reader that encapsulates a substring read from the underlying string instance of the current reader.</returns>
        public StringReader ReadBeforeAsReader(string[] keywords, bool readToEndIfKeywordNotFound = true)
        {
            return ReadToAsReader(keywords, readToEndIfKeywordNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords"/> is encountered.
        /// The reader stops at the position next to the last character of this Keyword.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(string[] keywords, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keywords, options);
        }

        #endregion

        #region Multiple Keywords, Single Pair of Quotes

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" />  is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(string[] keywords, char leftQuote, char rightQuote, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var searchResult = UnderlyingString.IndexOfAnyWithQuotes(keywords, CurrentPosition, EndPosition - CurrentPosition, leftQuote, rightQuote, ComparisonType);
            return _innerReadToAsReader(searchResult.Position, searchResult.Value.Length, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" />  is encountered outside quotes.
        /// The reader stops at the position of the first character of this Keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(string[] keywords, char leftQuote, char rightQuote, bool readToEndIfKeywordNotFound = true)
        {
            var options = readToEndIfKeywordNotFound ?
                ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keywords, leftQuote, rightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" />  is encountered outside quotes.
        /// The reader stops at the position next to the last character of the encountered keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(string[] keywords, char leftQuote, char rightQuote, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keywords, leftQuote, rightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" />  is encountered outside quotes.
        /// The reader stops at the position of the first character of this Keyword.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(string[] keywords, char leftQuote, char rightQuote, bool readToEndIfKeywordNotFound = true)
        {
            return ReadToAsReader(keywords, leftQuote, rightQuote, readToEndIfKeywordNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" />  is encountered outside quotes.
        /// The reader stops at the position next to the last character of this Keyword.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(string[] keywords, char leftQuote, char rightQuote, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keywords, leftQuote, rightQuote, options);
        }

        #endregion

        #region Multiple Keywords, Multiple Pairs of Quotes

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" />  is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="Keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="keywords">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="keywords" />.
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(string[] Keywords, char[] keywords, char[] rightQuotes, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = UnderlyingString.IndexOfAnyWithQuotes(Keywords, CurrentPosition, EndPosition - CurrentPosition, keywords, rightQuotes, ComparisonType);
            return _innerReadToAsReader(idx.Position, idx.Value.Length, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" />  is encountered outside quotes.
        /// The reader stops at the position of the first character of this Keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(string[] keywords, char[] leftQuotes, char[] rightQuotes, bool readToEndIfKeywordNotFound = true)
        {
            var options = readToEndIfKeywordNotFound ?
                ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keywords, leftQuotes, rightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" />  is encountered outside quotes.
        /// The reader stops at the position next to the last character of the encountered keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(string[] keywords, char[] leftQuotes, char[] rightQuotes, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keywords, leftQuotes, rightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" />  is encountered outside quotes.
        /// The reader stops at the position of the first character of the encountered keyword.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="leftQuotes">An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(string[] keywords, char[] leftQuotes, char[] rightQuotes, bool readToEndIfKeywordNotFound = true)
        {
            return ReadToAsReader(keywords, leftQuotes, rightQuotes, readToEndIfKeywordNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" />  is encountered outside quotes.
        /// The reader stops at the position next to the last character of the encountered keyword.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(string[] keywords, char[] leftQuotes, char[] rightQuotes, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (discardKeyword) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keywords, leftQuotes, rightQuotes, options);
        }

        #endregion

        #region Multiple Keywords, Two-Layer Quotes

        #region Multiple Keywords, Two-Layer Quotes #1

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="options">>Specifies the reading options.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(string[] keywords, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote,
            ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keywords, CurrentPosition, EndPosition, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, ComparisonType);
            return idx == null ? _innerReadToAsReader(-1, 0, options) : _innerReadToAsReader(idx.Position, idx.Value.Length, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes.
        /// The current reader stops at the position of the keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(string[] keywords, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, bool readToEndIfKeywordNotFound = true)
        {
            var options = readToEndIfKeywordNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keywords, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the last character of the encountered keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(string[] keywords, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keywords, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes. The current reader stops at the position of the keyword.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(string[] keywords, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, bool readToEndIfKeywordNotFound = true)
        {
            return ReadToAsReader(keywords, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, readToEndIfKeywordNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes. The current reader stops at the position immediately after the last character of the encountered keyword.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(string[] keywords, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keywords, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, options);
        }

        #endregion

        #region Multiple Keywords, Two-Layer Quotes #2

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes. The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="options">>Specifies the reading options.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(string[] keywords, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes,
            ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keywords, CurrentPosition, EndPosition, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, ComparisonType);
            return idx == null ? _innerReadToAsReader(-1, 0, options) : _innerReadToAsReader(idx.Position, idx.Value.Length, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes. The current reader stops at the position of the keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(string[] keywords, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool readToEndIfKeywordNotFound = true)
        {
            var options = readToEndIfKeywordNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keywords, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes. The current reader stops at the position immediately after the last character of the encountered keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(string[] keywords, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keywords, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes. The current reader stops at the position of the keyword.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(string[] keywords, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool readToEndIfKeywordNotFound = true)
        {
            return ReadToAsReader(keywords, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, readToEndIfKeywordNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes. The current reader stops at the position immediately after the last character of the encountered keyword.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(string[] keywords, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keywords, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        #endregion

        #region Multiple Keywords, Two-Layer Quotes #3

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="options">>Specifies the reading options.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(string[] keywords, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote,
            ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keywords, CurrentPosition, EndPosition, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, ComparisonType);
            return idx == null ? _innerReadToAsReader(-1, 0, options) : _innerReadToAsReader(idx.Position, idx.Value.Length, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes.
        /// The current reader stops at the position of the keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(string[] keywords, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, bool readToEndIfKeywordNotFound = true)
        {
            var options = readToEndIfKeywordNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keywords, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the last character of the encountered keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(string[] keywords, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keywords, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes. The current reader stops at the position of the keyword.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(string[] keywords, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, bool readToEndIfKeywordNotFound = true)
        {
            return ReadToAsReader(keywords, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, readToEndIfKeywordNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes. The current reader stops at the position immediately after the last character of the encountered keyword.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(string[] keywords, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keywords, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, options);
        }

        #endregion

        #region Multiple Keywords, Two-Layer Quotes #4

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="options">>Specifies the reading options.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(string[] keywords, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes,
            ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keywords, CurrentPosition, EndPosition, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, ComparisonType);
            return idx == null ? _innerReadToAsReader(-1, 0, options) : _innerReadToAsReader(idx.Position, idx.Value.Length, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes.
        /// The current reader stops at the position of the keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(string[] keywords, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool readToEndIfKeywordNotFound = true)
        {
            var options = readToEndIfKeywordNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keywords, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the last character of the encountered keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(string[] keywords, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keywords, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes. The current reader stops at the position of the keyword.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(string[] keywords, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool readToEndIfKeywordNotFound = true)
        {
            return ReadToAsReader(keywords, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, readToEndIfKeywordNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes. The current reader stops at the position immediately after the last character of the encountered keyword.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(string[] keywords, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keywords, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        #endregion

        #endregion

        #endregion

        #region Multiple Keywords, With HitIndex

        #region Multiple Keywords, Without Quotes

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(string[] keywords, out int hitIndex, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var searchResult = UnderlyingString.IndexOfAny(keywords, CurrentPosition, EndPosition - CurrentPosition, ComparisonType);
            hitIndex = searchResult.HitIndex;
            return _innerReadToAsReader(searchResult.Position, searchResult.Value.Length, options);
        }


        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered.
        /// The reader stops at the position of the first character of this Keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(string[] keywords, out int hitIndex, bool readToEndIfKeywordNotFound = true)
        {
            var options = readToEndIfKeywordNotFound ?
                ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keywords, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered.
        /// The reader stops at the position next to the last character of the encountered keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(string[] keywords, out int hitIndex, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keywords, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered.
        /// The reader stops at the position of the first character of this Keyword.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(string[] keywords, out int hitIndex, bool readToEndIfKeywordNotFound = true)
        {
            return ReadToAsReader(keywords, out hitIndex, readToEndIfKeywordNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered.
        /// The reader stops at the position next to the last character of this Keyword.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(string[] keywords, out int hitIndex, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keywords, out hitIndex, options);
        }

        #endregion

        #region Multiple Keywords, Single Pair of Quotes

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" />  is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(string[] keywords, char leftQuote, char rightQuote, out int hitIndex, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var searchResult = UnderlyingString.IndexOfAnyWithQuotes(keywords, CurrentPosition, EndPosition - CurrentPosition, leftQuote, rightQuote, ComparisonType);
            hitIndex = searchResult.HitIndex;
            return _innerReadToAsReader(searchResult.Position, searchResult.Value.Length, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" />  is encountered outside quotes.
        /// The reader stops at the position of the first character of this Keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(string[] keywords, char leftQuote, char rightQuote, out int hitIndex, bool readToEndIfKeywordNotFound = true)
        {
            var options = readToEndIfKeywordNotFound ?
                ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keywords, leftQuote, rightQuote, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" />  is encountered outside quotes.
        /// The reader stops at the position next to the last character of the encountered keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(string[] keywords, char leftQuote, char rightQuote, out int hitIndex, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keywords, leftQuote, rightQuote, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" />  is encountered outside quotes.
        /// The reader stops at the position of the first character of this Keyword.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(string[] keywords, char leftQuote, char rightQuote, out int hitIndex, bool readToEndIfKeywordNotFound = true)
        {
            return ReadToAsReader(keywords, leftQuote, rightQuote, out hitIndex, readToEndIfKeywordNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" />  is encountered outside quotes.
        /// The reader stops at the position next to the last character of this Keyword.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(string[] keywords, char leftQuote, char rightQuote, out int hitIndex, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keywords, leftQuote, rightQuote, out hitIndex, options);
        }

        #endregion

        #region Multiple Keywords, Multiple Pairs of Quotes

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" />  is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="leftQuotes">An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(string[] keywords, char[] leftQuotes, char[] rightQuotes, out int hitIndex, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var searchResult = UnderlyingString.IndexOfAnyWithQuotes(keywords, CurrentPosition, EndPosition - CurrentPosition, leftQuotes, rightQuotes, ComparisonType);
            if (searchResult == null)
            {
                hitIndex = -1;
                return _innerReadToAsReader(-1, 0, options);
            }
            else
            {
                hitIndex = searchResult.HitIndex;
                return _innerReadToAsReader(searchResult.Position, searchResult.Value.Length, options);
            }
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" />  is encountered outside quotes.
        /// The reader stops at the position of the first character of this Keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="leftQuotes">An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(string[] keywords, char[] leftQuotes, char[] rightQuotes, out int hitIndex, bool readToEndIfKeywordNotFound = true)
        {
            var options = readToEndIfKeywordNotFound ?
                ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keywords, leftQuotes, rightQuotes, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" />  is encountered outside quotes.
        /// The reader stops at the position next to the last character of the encountered keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="leftQuotes">An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(string[] keywords, char[] leftQuotes, char[] rightQuotes, out int hitIndex, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keywords, leftQuotes, rightQuotes, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" />  is encountered outside quotes.
        /// The reader stops at the position of the first character of the encountered keyword.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="leftQuotes">An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(string[] keywords, char[] leftQuotes, char[] rightQuotes, out int hitIndex, bool readToEndIfKeywordNotFound = true)
        {
            return ReadToAsReader(keywords, leftQuotes, rightQuotes, out hitIndex, readToEndIfKeywordNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" />  is encountered outside quotes.
        /// The reader stops at the position next to the last character of the encountered keyword.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="leftQuotes">An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(string[] keywords, char[] leftQuotes, char[] rightQuotes, out int hitIndex, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keywords, leftQuotes, rightQuotes, out hitIndex, options);
        }

        #endregion

        #region Multiple Keywords, Two-Layer Quotes

        #region Multiple Keywords, Two-Layer Quotes #1

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="options">>Specifies the reading options.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(string[] keywords, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex,
            ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keywords, CurrentPosition, EndPosition, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, ComparisonType);
            if (idx == null)
            {
                hitIndex = -1;
                return _innerReadToAsReader(-1, 0, options);
            }
            else
            {
                hitIndex = idx.HitIndex;
                return _innerReadToAsReader(idx.Position, idx.Value.Length, options);
            }
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes.
        /// The current reader stops at the position of the keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(string[] keywords, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex, bool readToEndIfKeywordNotFound = true)
        {
            var options = readToEndIfKeywordNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keywords, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the last character of the encountered keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(string[] keywords, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keywords, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes. The current reader stops at the position of the keyword.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(string[] keywords, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex, bool readToEndIfKeywordNotFound = true)
        {
            return ReadToAsReader(keywords, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, out hitIndex, readToEndIfKeywordNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes. The current reader stops at the position immediately after the last character of the encountered keyword.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(string[] keywords, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keywords, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, out hitIndex, options);
        }

        #endregion

        #region Multiple Keywords, Two-Layer Quotes #2

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="options">>Specifies the reading options.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(string[] keywords, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex,
            ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keywords, CurrentPosition, EndPosition, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, ComparisonType);
            if (idx == null)
            {
                hitIndex = -1;
                return _innerReadToAsReader(-1, 0, options);
            }
            else
            {
                hitIndex = idx.HitIndex;
                return _innerReadToAsReader(idx.Position, idx.Value.Length, options);
            }
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes.
        /// The current reader stops at the position of the keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(string[] keywords, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex, bool readToEndIfKeywordNotFound = true)
        {
            var options = readToEndIfKeywordNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keywords, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the last character of the encountered keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(string[] keywords, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keywords, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes. The current reader stops at the position of the keyword.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(string[] keywords, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex, bool readToEndIfKeywordNotFound = true)
        {
            return ReadToAsReader(keywords, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, out hitIndex, readToEndIfKeywordNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes. The current reader stops at the position immediately after the last character of the encountered keyword.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(string[] keywords, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keywords, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, out hitIndex, options);
        }

        #endregion

        #region Multiple Keywords, Two-Layer Quotes #3

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="options">>Specifies the reading options.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(string[] keywords, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex,
            ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keywords, CurrentPosition, EndPosition, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, ComparisonType);
            if (idx == null)
            {
                hitIndex = -1;
                return _innerReadToAsReader(-1, 0, options);
            }
            else
            {
                hitIndex = idx.HitIndex;
                return _innerReadToAsReader(idx.Position, idx.Value.Length, options);
            }
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes.
        /// The current reader stops at the position of the keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(string[] keywords, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex, bool readToEndIfKeywordNotFound = true)
        {
            var options = readToEndIfKeywordNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keywords, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the last character of the encountered keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(string[] keywords, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keywords, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes. The current reader stops at the position of the keyword.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(string[] keywords, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex, bool readToEndIfKeywordNotFound = true)
        {
            return ReadToAsReader(keywords, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, out hitIndex, readToEndIfKeywordNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes. The current reader stops at the position immediately after the last character of the encountered keyword.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(string[] keywords, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keywords, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, out hitIndex, options);
        }

        #endregion

        #region Multiple Keywords, Two-Layer Quotes #4

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="options">>Specifies the reading options.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(string[] keywords, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex,
            ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keywords, CurrentPosition, EndPosition, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, ComparisonType);
            if (idx == null)
            {
                hitIndex = -1;
                return _innerReadToAsReader(-1, 0, options);
            }
            else
            {
                hitIndex = idx.HitIndex;
                return _innerReadToAsReader(idx.Position, idx.Value.Length, options);
            }
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes.
        /// The current reader stops at the position of the keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(string[] keywords, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex, bool readToEndIfKeywordNotFound = true)
        {
            var options = readToEndIfKeywordNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keywords, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the last character of the encountered keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(string[] keywords, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keywords, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes. The current reader stops at the position of the keyword.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(string[] keywords, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex, bool readToEndIfKeywordNotFound = true)
        {
            return ReadToAsReader(keywords, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, out hitIndex, readToEndIfKeywordNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="keywords" /> is encountered outside quotes. The current reader stops at the position immediately after the last character of the encountered keyword.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these keywords is encountered.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keyword in the <paramref name="keywords"/>.</param>
        /// <param name="discardKeyword"><c>true</c> if the keyword will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeywordNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keywords"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(string[] keywords, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex, bool discardKeyword = true, bool readToEndIfKeywordNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeyword) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeywordNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keywords, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, out hitIndex, options);
        }

        #endregion

        #endregion

        #endregion
    }
}
