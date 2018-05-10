using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public partial class StringReader
    {
        #region Single Keychar

        #region Single Keychar, Without Quotes

        /// <summary>
        /// Advances the reader and reads until a specified character <paramref name="keychar"/> is encountered.
        /// The reader's position after executing this method depends on the <paramref name="options"/>.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>A new string reader that encapsulates a substring read from the underlying string instance of the current reader.</returns>
        public StringReader ReadToAsReader(char keychar, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = UnderlyingString.IndexOf(keychar, CurrentPosition, EndPosition - CurrentPosition);
            return _innerReadToAsReader(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until a specified character <paramref name="keychar" /> is encountered.
        /// The current reader stops at the position of the <paramref name="keychar" /> and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(char keychar, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;

            return ReadToAsReader(keychar, options);
        }

        /// <summary>
        /// Advances the reader and reads until a specified character <paramref name="keychar" /> is encountered.
        /// The current reader stops at the position immediately after the <paramref name="keychar" /> and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(char keychar, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychar, options);
        }

        /// <summary>
        /// Advances the reader and reads until a specified character <paramref name="keychar" /> is encountered.
        /// The current reader stops at the position of the <paramref name="keychar"/>.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(char keychar, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?  ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadToAsReader(keychar, options);
        }

        /// <summary>
        /// Advances the reader and reads until a specified character <paramref name="keychar" /> is encountered.
        /// The current reader stops at the position immediately after the <paramref name="keychar" />.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(char keychar, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychar, options);
        }

        #endregion

        #region Single Keychar, Single Pair of Quotes

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="indicator" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="indicator">The reader stops when this character is encountered outside quotes.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when the <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when the <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(char indicator, char leftQuote, char rightQuote, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, indicator, CurrentPosition, EndPosition, leftQuote, rightQuote);
            return _innerReadToAsReader(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The current reader stops at the position of the <paramref name="keyChar" /> and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered outside quotes.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(char keychar, char leftQuote, char rightQuote, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keychar, leftQuote, rightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the last character of the encountered keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered outside quotes.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(char keychar, char leftQuote, char rightQuote, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychar, leftQuote, rightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The current reader stops at the position of the <paramref name="keychar"/>
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered outside quotes.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(char keychar, char leftQuote, char rightQuote, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?  ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadToAsReader(keychar, leftQuote, rightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the position of the <paramref name="keychar" />.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered outside quotes.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(char keychar, char leftQuote, char rightQuote, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychar, leftQuote, rightQuote, options);
        }

        #endregion

        #region Single Keychar, Multiple Pairs of Quotes

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="indicator" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="indicator">The reader stops when this character is encountered outside quotes.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when the <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when the <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(char indicator, char[] leftQuotes, char[] rightQuotes, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, indicator, CurrentPosition, EndPosition, leftQuotes, rightQuotes);
            return _innerReadToAsReader(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="indicator" /> is encountered outside quotes.
        /// The current reader stops at the position of the <paramref name="keyChar" /> and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="indicator">The reader stops when this character is encountered outside quotes.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when the <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when the <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(char indicator, char[] leftQuotes, char[] rightQuotes, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(indicator, leftQuotes, rightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="indicator" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the last character of the encountered keyword and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="indicator">The reader stops when this character is encountered outside quotes.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when the <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when the <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="discardKeychar">If set to <c>true</c>, the <paramref name="indicator" /> will be discarded and not be included in the returned substring.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(char indicator, char[] leftQuotes, char[] rightQuotes, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(indicator, leftQuotes, rightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="indicator" /> is encountered outside quotes.
        /// The current reader stops at the position of the <paramref name="keychar"/>
        /// </summary>
        /// <param name="indicator">The reader stops when this character is encountered outside quotes.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when the <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when the <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(char indicator, char[] leftQuotes, char[] rightQuotes, bool readToEndIfKeycharNotFound = true)
        {
            return ReadToAsReader(indicator, leftQuotes, rightQuotes, readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="indicator" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the position of the <paramref name="keychar" />.
        /// </summary>
        /// <param name="indicator">The reader stops when this character is encountered outside quotes.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when the <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when the <paramref name="keychar" /> is encountered inside a pair of quotes.</param>
        /// <param name="discardKeychar">If set to <c>true</c>, the <paramref name="indicator" /> will be discarded and not be included in the returned substring.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(char indicator, char[] leftQuotes, char[] rightQuotes, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(indicator, leftQuotes, rightQuotes, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(char keychar, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychar, CurrentPosition, EndPosition, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote);
            return _innerReadToAsReader(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The current reader stops at the position of the <paramref name="keychar" /> and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered outside quotes. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(char keychar, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keychar, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(char keychar, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychar, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(char keychar, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?  ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadToAsReader(keychar, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(char keychar, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychar, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(char keychar, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychar, CurrentPosition, EndPosition, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes);
            return _innerReadToAsReader(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The current reader stops at the position of the <paramref name="keychar" /> and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered outside quotes. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(char keychar, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keychar, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(char keychar, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychar, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(char keychar, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?  ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadToAsReader(keychar, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(char keychar, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychar, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(char keychar, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychar, CurrentPosition, EndPosition, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote);
            return _innerReadToAsReader(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The current reader stops at the position of the <paramref name="keychar" /> and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered outside quotes. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(char keychar, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keychar, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(char keychar, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychar, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(char keychar, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?  ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadToAsReader(keychar, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(char keychar, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychar, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(char keychar, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychar, CurrentPosition, EndPosition, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes);
            return _innerReadToAsReader(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered outside quotes.
        /// The current reader stops at the position of the <paramref name="keychar" /> and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered outside quotes. The reader will not stop when an <paramref name="keychar" /> is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychar"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(char keychar, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keychar, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(char keychar, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychar, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(char keychar, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?  ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadToAsReader(keychar, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(char keychar, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychar, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        #endregion

        #endregion

        #endregion

        #region Multiple Keychars, Without HitIndex

        #region Multiple Keychars, Without Quotes

        /// <summary>
        /// Advances the reader until any character specified in <paramref name="keychars"/> is encountered.
        /// The reader's position after executing this method depends on the <paramref name="options"/>.
        /// </summary>
        /// <param name="keychars">An array of characters indicating where the current reader stops advancing.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>A new string reader that encapsulates a substring read from the underlying string instance of the current reader.</returns>
        public StringReader ReadToAsReader(char[] keychars, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = UnderlyingString.IndexOfAny(keychars, CurrentPosition, EndPosition - CurrentPosition);
            return _innerReadToAsReader(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars"/> is encountered.
        /// The current reader stops at the position of the encountered character of <paramref name="keychars" /> and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychars">An array of characters indicating where the current reader stops advancing.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>A new string reader that encapsulates a substring read from the underlying string instance of the current reader.</returns>
        public StringReader ReadBeforeWithTrimAsReader(char[] keychars, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keychars, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars"/> is encountered.
        /// The current reader stops at the position immediately after the encountered character of <paramref name="keychars" /> and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychars">An array of characters indicating where the current reader stops advancing.</param>
        /// <param name="discardKeychar">If set to <c>true</c>, the encountered character of <paramref name="keychars"/> will be discarded and not be included in the returned substring.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(char[] keychars, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychars, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars"/> is encountered.
        /// The current reader stops at the position of the encountered keychar.
        /// </summary>
        /// <param name="keychars">An array of characters indicating where the current reader stops advancing.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>A new string reader that encapsulates a substring read from the underlying string instance of the current reader.</returns>
        public StringReader ReadBeforeAsReader(char[] keychars, bool readToEndIfKeycharNotFound = true)
        {
            return ReadToAsReader(keychars, readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars"/> is encountered.
        /// The current reader stops at the position immediately after the encountered keychar .
        /// </summary>
        /// <param name="keychars">An array of characters indicating where the current reader stops advancing.</param>
        /// <param name="discardKeychar">If set to <c>true</c>, the encountered character of <paramref name="keychars"/> will be discarded and not be included in the returned substring.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(char[] keychars, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychars, options);
        }

        #endregion

        #region Multiple Keychars, Single Pair of Quotes

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keychars">An array of characters indicating where the current reader stops advancing.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(char[] keychars, char leftQuote, char rightQuote, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychars, CurrentPosition, EndPosition, leftQuote, rightQuote);
            return _innerReadToAsReader(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position of the encountered character of <paramref name="keychars" /> and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychars">An array of characters indicating where the current reader stops advancing.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(char[] keychars, char leftQuote, char rightQuote, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keychars, leftQuote, rightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the encountered character of <paramref name="keychars" /> and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychars">An array of characters indicating where the current reader stops advancing.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="discardKeychar">If set to <c>true</c>, the encountered character of <paramref name="keychars"/> will be discarded and not be included in the returned substring.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(char[] keychars, char leftQuote, char rightQuote, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychars, leftQuote, rightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position of the encountered character of <paramref name="keychars" />.
        /// </summary>
        /// <param name="keychars">An array of characters indicating where the current reader stops advancing.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(char[] keychars, char leftQuote, char rightQuote, bool readToEndIfKeycharNotFound = true)
        {
            return ReadToAsReader(keychars, leftQuote, rightQuote, readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the encountered character of <paramref name="keychars" />.
        /// </summary>
        /// <param name="keychars">An array of characters indicating where the current reader stops advancing.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="discardKeychar">If set to <c>true</c>, the <paramref name="indicator" /> will be discarded and not be included in the returned substring.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(char[] keychars, char leftQuote, char rightQuote, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychars, leftQuote, rightQuote, options);
        }

        #endregion

        #region Multiple Keychars, Multiple Pairs of Quotes

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keychars">An array of characters indicating where the current reader stops advancing.</param>
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(char[] keychars, char[] leftQuotes, char[] rightQuotes, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychars, CurrentPosition, EndPosition, leftQuotes, rightQuotes);
            return _innerReadToAsReader(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position of the encountered character of <paramref name="keychars" /> and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychars">An array of characters indicating where the current reader stops advancing.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(char[] keychars, char[] leftQuotes, char[] rightQuotes, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keychars, leftQuotes, rightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the encountered character of <paramref name="keychars" /> and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychars">An array of characters indicating where the current reader stops advancing.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="discardKeychar">If set to <c>true</c>, the encountered character of <paramref name="keychars"/> will be discarded and not be included in the returned substring.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(char[] keychars, char[] leftQuotes, char[] rightQuotes, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychars, leftQuotes, rightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position of the encountered character of <paramref name="keychars" />.
        /// </summary>
        /// <param name="keychars">An array of characters indicating where the current reader stops advancing.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(char[] keychars, char[] leftQuotes, char[] rightQuotes, bool readToEndIfKeycharNotFound = true)
        {
            return ReadToAsReader(keychars, leftQuotes, rightQuotes, readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the encountered character of <paramref name="keychars" />.
        /// </summary>
        /// <param name="keychars">An array of characters indicating where the current reader stops advancing.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="discardKeychar">If set to <c>true</c>, the encountered element of <paramref name="keychars" /> will be discarded and not be included in the returned substring.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(char[] keychars, char[] leftQuotes, char[] rightQuotes, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychars, leftQuotes, rightQuotes, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote,
            ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychars, CurrentPosition, EndPosition, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote);
            return _innerReadToAsReader(idx, 1, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?  ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadToAsReader(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychars, CurrentPosition, EndPosition, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes);
            return _innerReadToAsReader(idx, 1, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?  ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadToAsReader(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychars, CurrentPosition, EndPosition, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote);
            return _innerReadToAsReader(idx, 1, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?  ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadToAsReader(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychars, CurrentPosition, EndPosition, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes);
            return _innerReadToAsReader(idx, 1, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?  ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadToAsReader(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        #endregion

        #endregion

        #endregion

        #region Multiple Keychars, With HitIndex

        #region Multiple Keychars, Without Quotes

        /// <summary>
        /// Advances the reader until any character specified in <paramref name="keychars"/> is encountered.
        /// The reader's position after executing this method depends on the <paramref name="options"/>.
        /// </summary>
        /// <param name="keychars">An array of characters indicating where the current reader stops advancing.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>A new string reader that encapsulates a substring read from the underlying string instance of the current reader.</returns>
        public StringReader ReadToAsReader(char[] keychars, out int hitIndex, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = UnderlyingString.IndexOfAny(keychars, CurrentPosition, EndPosition - CurrentPosition, out hitIndex);
            return _innerReadToAsReader(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars"/> is encountered.
        /// The current reader stops at the position of the encountered character of <paramref name="keychars" /> and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychars">An array of characters indicating where the current reader stops advancing.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>A new string reader that encapsulates a substring read from the underlying string instance of the current reader.</returns>
        public StringReader ReadBeforeWithTrimAsReader(char[] keychars, out int hitIndex, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keychars, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars"/> is encountered.
        /// The current reader stops at the position immediately after the encountered character of <paramref name="keychars" /> and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychars">An array of characters indicating where the current reader stops advancing.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="discardKeychar">If set to <c>true</c>, the encountered character of <paramref name="keychars"/> will be discarded and not be included in the returned substring.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(char[] keychars, out int hitIndex, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychars, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars"/> is encountered.
        /// The current reader stops at the position of the encountered keychar.
        /// </summary>
        /// <param name="keychars">An array of characters indicating where the current reader stops advancing.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>A new string reader that encapsulates a substring read from the underlying string instance of the current reader.</returns>
        public StringReader ReadBeforeAsReader(char[] keychars, out int hitIndex, bool readToEndIfKeycharNotFound = true)
        {
            return ReadToAsReader(keychars, out hitIndex, readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars"/> is encountered.
        /// The current reader stops at the position immediately after the encountered keychar .
        /// </summary>
        /// <param name="keychars">An array of characters indicating where the current reader stops advancing.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="discardKeychar">If set to <c>true</c>, the encountered character of <paramref name="keychars"/> will be discarded and not be included in the returned substring.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(char[] keychars, out int hitIndex, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychars, out hitIndex, options);
        }

        #endregion

        #region Multiple Keychars, Single Pair of Quotes

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keychars">An array of characters indicating where the current reader stops advancing.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(char[] keychars, char leftQuote, char rightQuote, out int hitIndex, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychars, CurrentPosition, EndPosition, leftQuote, rightQuote, out hitIndex);
            return _innerReadToAsReader(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position of the encountered character of <paramref name="keychars" /> and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychars">An array of characters indicating where the current reader stops advancing.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(char[] keychars, char leftQuote, char rightQuote, out int hitIndex, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keychars, leftQuote, rightQuote, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the encountered character of <paramref name="keychars" /> and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychars">An array of characters indicating where the current reader stops advancing.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="discardKeychar">If set to <c>true</c>, the encountered character of <paramref name="keychars"/> will be discarded and not be included in the returned substring.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(char[] keychars, char leftQuote, char rightQuote, out int hitIndex, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychars, leftQuote, rightQuote, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position of the encountered character of <paramref name="keychars" />.
        /// </summary>
        /// <param name="keychars">An array of characters indicating where the current reader stops advancing.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(char[] keychars, char leftQuote, char rightQuote, out int hitIndex, bool readToEndIfKeycharNotFound = true)
        {
            return ReadToAsReader(keychars, leftQuote, rightQuote, out hitIndex, readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the encountered character of <paramref name="keychars" />.
        /// </summary>
        /// <param name="keychars">An array of characters indicating where the current reader stops advancing.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="discardKeychar">If set to <c>true</c>, the <paramref name="indicator" /> will be discarded and not be included in the returned substring.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(char[] keychars, char leftQuote, char rightQuote, out int hitIndex, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychars, leftQuote, rightQuote, out hitIndex, options);
        }

        #endregion

        #region Multiple Keychars, Multiple Pairs of Quotes

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keychars">An array of characters indicating where the current reader stops advancing.</param>
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(char[] keychars, char[] leftQuotes, char[] rightQuotes, out int hitIndex, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychars, CurrentPosition, EndPosition, leftQuotes, rightQuotes, out hitIndex);
            return _innerReadToAsReader(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position of the encountered character of <paramref name="keychars" /> and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychars">An array of characters indicating where the current reader stops advancing.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(char[] keychars, char[] leftQuotes, char[] rightQuotes, out int hitIndex, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keychars, leftQuotes, rightQuotes, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the encountered character of <paramref name="keychars" /> and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="keychars">An array of characters indicating where the current reader stops advancing.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="discardKeychar">If set to <c>true</c>, the encountered character of <paramref name="keychars"/> will be discarded and not be included in the returned substring.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(char[] keychars, char[] leftQuotes, char[] rightQuotes, out int hitIndex, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychars, leftQuotes, rightQuotes, out hitIndex, options);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position of the encountered character of <paramref name="keychars" />.
        /// </summary>
        /// <param name="keychars">An array of characters indicating where the current reader stops advancing.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(char[] keychars, char[] leftQuotes, char[] rightQuotes, out int hitIndex, bool readToEndIfKeycharNotFound = true)
        {
            return ReadToAsReader(keychars, leftQuotes, rightQuotes, out hitIndex, readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until any character specified in <paramref name="keychars" /> is encountered outside quotes.
        /// The current reader stops at the position immediately after the encountered character of <paramref name="keychars" />.
        /// </summary>
        /// <param name="keychars">An array of characters indicating where the current reader stops advancing.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when any of the <paramref name="keychars" /> is encountered inside a pair of quotes.</param>
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="discardKeychar">If set to <c>true</c>, the encountered element of <paramref name="keychars" /> will be discarded and not be included in the returned substring.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if none of the <paramref name="keychars"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(char[] keychars, char[] leftQuotes, char[] rightQuotes, out int hitIndex, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychars, leftQuotes, rightQuotes, out hitIndex, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex,
            ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychars, CurrentPosition, EndPosition, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, out hitIndex);
            return _innerReadToAsReader(idx, 1, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, out hitIndex, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, out hitIndex, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadToAsReader(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, out hitIndex, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, out hitIndex, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychars, CurrentPosition, EndPosition, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, out hitIndex);
            return _innerReadToAsReader(idx, 1, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, out hitIndex, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, out hitIndex, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadToAsReader(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, out hitIndex, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(char[] keychars, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychars, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, out hitIndex, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychars, CurrentPosition, EndPosition, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, out hitIndex);
            return _innerReadToAsReader(idx, 1, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, out hitIndex, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, out hitIndex, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadToAsReader(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, out hitIndex, options);
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
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, out hitIndex, options);
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
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, keychars, CurrentPosition, EndPosition, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, out hitIndex);
            return _innerReadToAsReader(idx, 1, options);
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
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                 ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                 ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, out hitIndex, options);
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
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, out hitIndex, options);
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
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ? ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadToAsReader(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, out hitIndex, options);
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
        /// <param name="hitIndex">Returns the index of the encountered keychar in the <paramref name="keychars"/>.</param>
        /// <param name="discardKeychar"><c>true</c> if the encountered keychar will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the <paramref name="keychars"/> is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(char[] keychars, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(keychars, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, out hitIndex, options);
        }

        #endregion

        #endregion

        #endregion
    }
}
