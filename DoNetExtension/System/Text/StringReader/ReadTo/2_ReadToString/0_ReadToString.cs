using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Text
{
    public partial class StringReader
    {
        #region Single Indicator, Without Quotes

        /// <summary>
        /// Advances the reader and reads until a substring specified by <paramref name="indicator" /> is encountered.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="indicator">The reader stops when an occurrence of this string instance is encountered.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// A substring read from the underlying string instance.
        /// </returns>
        public string ReadTo(string indicator, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey)
        {
            var idx = options.HasFlag(ReadOptions.InLine) ? UnderlyingString.InlineIndexOf(indicator, CurrentPosition, EndPosition - CurrentPosition, ComparisonType) :
            UnderlyingString.IndexOf(indicator, CurrentPosition, EndPosition - CurrentPosition, ComparisonType);
            return _innerReadTo(idx, indicator.Length, options);
        }

        /// <summary>
        /// Advances the reader and reads until a substring specified by <paramref name="indicator"/> is encountered.
        /// The reader stops at the position of the first character of this indicator and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="indicator">The reader stops when an occurrence of this string instance is encountered.</param>
        /// <returns>A substring read from the underlying string instance.</returns>
        public string ReadBeforeWithTrim(string indicator)
        {
            return ReadTo(indicator, ReadOptions.Default | ReadOptions.TrimStart | ReadOptions.TrimEnd);
        }

        /// <summary>
        /// Advances the reader and reads until a substring specified by <paramref name="indicator" /> is encountered.
        /// The reader stops at the position next to the last character of the encountered keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="indicator">The reader stops when an occurrence of this string instance is encountered.</param>
        /// <param name="discardIndicator">If set to <c>true</c>, the <paramref name="indicator"/> 
        /// will be discarded and not be included in the returned substring.</param>
        /// <returns>
        /// A substring read from the underlying string instance.
        /// </returns>
        public string ReadAfterWithTrim(string indicator, bool discardIndicator = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardIndicator) options |= ReadOptions.DiscardKey;
            return ReadTo(indicator, options);
        }

        /// <summary>
        /// Advances the reader and reads until a substring specified by <paramref name="indicator"/> is encountered.
        /// The reader stops at the position of the first character of this indicator.
        /// </summary>
        /// <param name="indicator">The reader stops when an occurrence of this string instance is encountered.</param>
        /// <returns>A substring read from the underlying string instance.</returns>
        public string ReadBefore(string indicator)
        {
            return ReadTo(indicator, ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until a substring specified by <paramref name="indicator" /> is encountered.
        /// The reader stops at the position next to the last character of this indicator.
        /// </summary>
        /// <param name="indicator">The reader stops when an occurrence of this string instance is encountered.</param>
        /// <param name="discardIndicator">If set to <c>true</c>, the <paramref name="indicator"/> 
        /// will be discarded and not be included in the returned substring.</param>
        /// <returns>
        /// A substring read from the underlying string instance.
        /// </returns>
        public string ReadAfter(string indicator, bool discardIndicator = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardIndicator) options |= ReadOptions.DiscardKey;
            return ReadTo(indicator, options);
        }

        #endregion

        #region Multiple Indicators, Without Quotes

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="indicators"/> is encountered.
        /// The reader's position after executing this method depends on the <paramref name="options"/>.
        /// </summary>
        /// <param name="indicators">The reader stops an occurrence of this string instances is encountered.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>A substring read from the underlying string instance.</returns>
        public string ReadTo(string[] indicators, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey)
        {
            var idx = UnderlyingString.IndexOfAny(indicators, CurrentPosition, EndPosition - CurrentPosition, ComparisonType);
            return _innerReadTo(idx.Position, idx.Value.Length, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="indicators"/> is encountered.
        /// The reader stops at the position of the first character of this indicator and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="indicators">The reader stops an occurrence of this string instances is encountered.</param>
        /// <returns>A substring read from the underlying string instance.</returns>
        public string ReadBeforeWithTrim(string[] indicators)
        {
            return ReadTo(indicators, ReadOptions.Default | ReadOptions.TrimStart | ReadOptions.TrimEnd);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="indicators"/> is encountered.
        /// The reader stops at the position next to the last character of the encountered keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="indicators">The reader stops an occurrence of this string instances is encountered.</param>
        /// <param name="discardIndicator">If set to <c>true</c>, the <paramref name="indicator"/> 
        /// will be discarded and not be included in the returned substring.</param>
        /// <returns>
        /// A substring read from the underlying string instance.
        /// </returns>
        public string ReadAfterWithTrim(string[] indicators, bool discardIndicator = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardIndicator) options |= ReadOptions.DiscardKey;
            return ReadTo(indicators, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="indicators"/> is encountered.
        /// The reader stops at the position of the first character of this indicator.
        /// </summary>
        /// <param name="indicators">The reader stops an occurrence of this string instances is encountered.</param>
        /// <returns>A substring read from the underlying string instance.</returns>
        public string ReadBefore(string[] indicators)
        {
            return ReadTo(indicators, ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="indicators"/> is encountered.
        /// The reader stops at the position next to the last character of this indicator.
        /// </summary>
        /// <param name="indicators">The reader stops an occurrence of this string instances is encountered.</param>
        /// <param name="discardIndicator">If set to <c>true</c>, the <paramref name="indicator"/> 
        /// will be discarded and not be included in the returned substring.</param>
        /// <returns>
        /// A substring read from the underlying string instance.
        /// </returns>
        public string ReadAfter(string[] indicators, bool discardIndicator = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardIndicator) options |= ReadOptions.DiscardKey;
            return ReadTo(indicators, options);
        }

        #endregion

        #region Single Indicator, Single Pair of Quotes

        /// <summary>
        /// Advances the reader and reads until a substring specified by <paramref name="indicator" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="indicator">The reader stops when an occurrence of this string instance is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// A substring read from the underlying string instance.
        /// </returns>
        public string ReadTo(string indicator, char leftQuote, char rightQuote,
            ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey)
        {
            var idx = UnderlyingString.IndexOfWithQuotes(indicator, CurrentPosition, EndPosition - CurrentPosition, leftQuote, rightQuote, ComparisonType); ;
            return _innerReadTo(idx, indicator.Length, options);
        }

        /// <summary>
        /// Advances the reader and reads until a substring specified by <paramref name="indicator" /> is encountered outside quotes.
        /// The reader stops at the position of the first character of this indicator and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="indicator">The reader stops when an occurrence of this string instance is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <returns>
        /// A substring read from the underlying string instance.
        /// </returns>
        public string ReadBeforeWithTrim(string indicator, char leftQuote, char rightQuote)
        {
            return ReadTo(indicator, leftQuote, rightQuote, ReadOptions.Default | ReadOptions.TrimStart | ReadOptions.TrimEnd);
        }

        /// <summary>
        /// Advances the reader and reads until a substring specified by <paramref name="indicator" /> is encountered outside quotes.
        /// The reader stops at the position next to the last character of the encountered keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="indicator">The reader stops when an occurrence of this string instance is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="discardIndicator">If set to <c>true</c>, the <paramref name="indicator" />
        /// will be discarded and not be included in the returned substring.</param>
        /// <returns>
        /// A substring read from the underlying string instance.
        /// </returns>
        public string ReadAfterWithTrim(string indicator, char leftQuote, char rightQuote, bool discardIndicator = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardIndicator) options |= ReadOptions.DiscardKey;
            return ReadTo(indicator, leftQuote, rightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until a substring specified by <paramref name="indicator" /> is encountered outside quotes.
        /// The reader stops at the position of the first character of this indicator.
        /// </summary>
        /// <param name="indicator">The reader stops when an occurrence of this string instance is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <returns>
        /// A substring read from the underlying string instance.
        /// </returns>
        public string ReadBefore(string indicator, char leftQuote, char rightQuote)
        {
            return ReadTo(indicator, leftQuote, rightQuote, ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until a substring specified by <paramref name="indicator" /> is encountered outside quotes.
        /// The reader stops at the position next to the last character of this indicator.
        /// </summary>
        /// <param name="indicator">The reader stops when an occurrence of this string instance is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="discardIndicator">If set to <c>true</c>, the <paramref name="indicator" />
        /// will be discarded and not be included in the returned substring.</param>
        /// <returns>
        /// A substring read from the underlying string instance.
        /// </returns>
        public string ReadAfter(string indicator, char leftQuote, char rightQuote, bool discardIndicator = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardIndicator) options |= ReadOptions.DiscardKey;
            return ReadTo(indicator, leftQuote, rightQuote, options);
        }

        #endregion

        #region Single Indicator, Multiple Pairs of Quotes

        /// <summary>
        /// Advances the reader and reads until a substring specified by <paramref name="indicator" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="indicator">The reader stops when an occurrence of this string instance is encountered.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// A substring read from the underlying string instance.
        /// </returns>
        public string ReadTo(string indicator, char[] leftQuotes, char[] rightQuotes,
            ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey)
        {
            var idx = UnderlyingString.IndexOfWithQuotes(indicator, CurrentPosition, EndPosition - CurrentPosition, leftQuotes, rightQuotes, ComparisonType); ;
            return _innerReadTo(idx, indicator.Length, options);
        }

        /// <summary>
        /// Advances the reader and reads until a substring specified by <paramref name="indicator" /> is encountered outside quotes.
        /// The reader stops at the position of the first character of this indicator and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="indicator">The reader stops when an occurrence of this string instance is encountered.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <returns>
        /// A substring read from the underlying string instance.
        /// </returns>
        public string ReadBeforeWithTrim(string indicator, char[] leftQuotes, char[] rightQuotes)
        {
            return ReadTo(indicator, leftQuotes, rightQuotes, ReadOptions.Default | ReadOptions.TrimStart | ReadOptions.TrimEnd);
        }

        /// <summary>
        /// Advances the reader and reads until a substring specified by <paramref name="indicator" /> is encountered outside quotes.
        /// The reader stops at the position next to the last character of the encountered keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="indicator">The reader stops when an occurrence of this string instance is encountered.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="discardIndicator">If set to <c>true</c>, the <paramref name="indicator" />
        /// will be discarded and not be included in the returned substring.</param>
        /// <returns>
        /// A substring read from the underlying string instance.
        /// </returns>
        public string ReadAfterWithTrim(string indicator, char[] leftQuotes, char[] rightQuotes, bool discardIndicator = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardIndicator) options |= ReadOptions.DiscardKey;
            return ReadTo(indicator, leftQuotes, rightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until a substring specified by <paramref name="indicator" /> is encountered outside quotes.
        /// The reader stops at the position of the first character of this indicator.
        /// </summary>
        /// <param name="indicator">The reader stops when an occurrence of this string instance is encountered.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <returns>
        /// A substring read from the underlying string instance.
        /// </returns>
        public string ReadBefore(string indicator, char[] leftQuotes, char[] rightQuotes)
        {
            return ReadTo(indicator, leftQuotes, rightQuotes, ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until a substring specified by <paramref name="indicator" /> is encountered outside quotes.
        /// The reader stops at the position next to the last character of this indicator.
        /// </summary>
        /// <param name="indicator">The reader stops when an occurrence of this string instance is encountered.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="discardIndicator">If set to <c>true</c>, the <paramref name="indicator" />
        /// will be discarded and not be included in the returned substring.</param>
        /// <returns>
        /// A substring read from the underlying string instance.
        /// </returns>
        public string ReadAfter(string indicator, char[] leftQuotes, char[] rightQuotes, bool discardIndicator = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardIndicator) options |= ReadOptions.DiscardKey;
            return ReadTo(indicator, leftQuotes, rightQuotes, options);
        }

        #endregion

        #region Multiple Indicators, Single Pair of Quotes

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="indicators" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="indicators">The reader stops an occurrence of this string instances is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// A substring read from the underlying string instance.
        /// </returns>
        public string ReadTo(string[] indicators, char leftQuote, char rightQuote, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey)
        {
            var idx = UnderlyingString.IndexOfAnyWithQuotes(indicators, CurrentPosition, EndPosition - CurrentPosition, leftQuote, rightQuote, ComparisonType); ;
            return _innerReadTo(idx.Position, idx.Value.Length, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="indicators" /> is encountered outside quotes.
        /// The reader stops at the position of the first character of this indicator and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="indicators">The reader stops an occurrence of this string instances is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <returns>
        /// A substring read from the underlying string instance.
        /// </returns>
        public string ReadBeforeWithTrim(string[] indicators, char leftQuote, char rightQuote)
        {
            return ReadTo(indicators, leftQuote, rightQuote, ReadOptions.Default | ReadOptions.TrimStart | ReadOptions.TrimEnd);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="indicators" /> is encountered outside quotes.
        /// The reader stops at the position next to the last character of the encountered keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="indicators">The reader stops an occurrence of this string instances is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="discardIndicator">If set to <c>true</c>, the <paramref name="indicator" />
        /// will be discarded and not be included in the returned substring.</param>
        /// <returns>
        /// A substring read from the underlying string instance.
        /// </returns>
        public string ReadAfterWithTrim(string[] indicators, char leftQuote, char rightQuote, bool discardIndicator = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardIndicator) options |= ReadOptions.DiscardKey;
            return ReadTo(indicators, leftQuote, rightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="indicators" /> is encountered outside quotes.
        /// The reader stops at the position of the first character of this indicator.
        /// </summary>
        /// <param name="indicators">The reader stops an occurrence of this string instances is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <returns>
        /// A substring read from the underlying string instance.
        /// </returns>
        public string ReadBefore(string[] indicators, char leftQuote, char rightQuote)
        {
            return ReadTo(indicators, leftQuote, rightQuote, ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="indicators" /> is encountered outside quotes.
        /// The reader stops at the position next to the last character of this indicator.
        /// </summary>
        /// <param name="indicators">The reader stops an occurrence of this string instances is encountered.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="discardIndicator">If set to <c>true</c>, the <paramref name="indicator" />
        /// will be discarded and not be included in the returned substring.</param>
        /// <returns>
        /// A substring read from the underlying string instance.
        /// </returns>
        public string ReadAfter(string[] indicators, char leftQuote, char rightQuote, bool discardIndicator = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardIndicator) options |= ReadOptions.DiscardKey;
            return ReadTo(indicators, leftQuote, rightQuote, options);
        }

        #endregion

        #region Multiple Indicators, Multiple Pairs of Quotes

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="indicators" /> is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="indicators">The reader stops an occurrence of this string instances is encountered.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// A substring read from the underlying string instance.
        /// </returns>
        public string ReadTo(string[] indicators, char[] leftQuotes, char[] rightQuotes, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey)
        {
            var idx = UnderlyingString.IndexOfAnyWithQuotes(indicators, CurrentPosition, EndPosition - CurrentPosition, leftQuotes, rightQuotes, ComparisonType); ;
            return _innerReadTo(idx.Position, idx.Value.Length, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="indicators" /> is encountered outside quotes.
        /// The reader stops at the position of the first character of this indicator and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="indicators">The reader stops an occurrence of this string instances is encountered.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <returns>
        /// A substring read from the underlying string instance.
        /// </returns>
        public string ReadBeforeWithTrim(string[] indicators, char[] leftQuotes, char[] rightQuotes)
        {
            return ReadTo(indicators, leftQuotes, rightQuotes, ReadOptions.Default | ReadOptions.TrimStart | ReadOptions.TrimEnd);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="indicators" /> is encountered outside quotes.
        /// The reader stops at the position next to the last character of the encountered keyword and the white-spaces at both ends of the returned substring will be trimmed.
        /// </summary>
        /// <param name="indicators">The reader stops an occurrence of this string instances is encountered.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="discardIndicator">If set to <c>true</c>, the <paramref name="indicator" />
        /// will be discarded and not be included in the returned substring.</param>
        /// <returns>
        /// A substring read from the underlying string instance.
        /// </returns>
        public string ReadAfterWithTrim(string[] indicators, char[] leftQuotes, char[] rightQuotes, bool discardIndicator = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardIndicator) options |= ReadOptions.DiscardKey;
            return ReadTo(indicators, leftQuotes, rightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="indicators" /> is encountered outside quotes.
        /// The reader stops at the position of the first character of this indicator.
        /// </summary>
        /// <param name="indicators">The reader stops an occurrence of this string instances is encountered.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <returns>
        /// A substring read from the underlying string instance.
        /// </returns>
        public string ReadBefore(string[] indicators, char[] leftQuotes, char[] rightQuotes)
        {
            return ReadTo(indicators, leftQuotes, rightQuotes, ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until any substring specified in <paramref name="indicators" /> is encountered outside quotes.
        /// The reader stops at the position next to the last character of this indicator.
        /// </summary>
        /// <param name="indicators">The reader stops an occurrence of this string instances is encountered.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when an <paramref name="indicator" /> is encountered inside a pair of quotes.</param>
        /// <param name="discardIndicator">If set to <c>true</c>, the <paramref name="indicator" />
        /// will be discarded and not be included in the returned substring.</param>
        /// <returns>
        /// A substring read from the underlying string instance.
        /// </returns>
        public string ReadAfter(string[] indicators, char[] leftQuotes, char[] rightQuotes, bool discardIndicator = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardIndicator) options |= ReadOptions.DiscardKey;
            return ReadTo(indicators, leftQuotes, rightQuotes, options);
        }

        #endregion
    }
}