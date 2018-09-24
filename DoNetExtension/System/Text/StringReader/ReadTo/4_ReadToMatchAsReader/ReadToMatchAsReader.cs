using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Text
{
    public partial class StringReader
    {
        StringReader _innerReadToMatchAsReader(char leftChar, char rightChar, ReadOptions mode)
        {
            var idx = UnderlyingString.IndexOfNextMatch(leftChar, rightChar, CurrentPosition);
            if (idx == -1) return null;
            else
            {
                if (UnderlyingString[CurrentPosition] == leftChar && mode.HasFlag(ReadOptions.DiscardKey)) ++CurrentPosition;
                return _innerReadToAsReader(idx, 1, mode);
            }
        }

        StringReader _innerReadToMatchAsReader(char leftChar, char rightChar, char leftQuote, char rightQuote, ReadOptions mode)
        {
            var idx = UnderlyingString.IndexOfNextMatch(leftChar, rightChar, leftQuote, rightQuote, CurrentPosition);
            if (idx == -1) return null;
            else
            {
                if (UnderlyingString[CurrentPosition] == leftChar && mode.HasFlag(ReadOptions.DiscardKey)) ++CurrentPosition;
                return _innerReadToAsReader(idx, 1, mode);
            }
        }

        StringReader _innerReadToMatchAsReader(char leftChar, char rightChar, char[] leftQuotes, char[] rightQuotes, ReadOptions mode)
        {
            var idx = UnderlyingString.IndexOfNextMatch(leftChar, rightChar, leftQuotes, rightQuotes, CurrentPosition);
            if (idx == -1) return null;
            else
            {
                if (UnderlyingString[CurrentPosition] == leftChar && mode.HasFlag(ReadOptions.DiscardKey)) ++CurrentPosition;
                return _innerReadToAsReader(idx, 1, mode);
            }
        }

        /// <summary>
        /// Advances the reader and reads until a match of the reader's current character is found.
        /// The reader's current character is the character of the underlying string at the reader's current position.
        /// </summary>
        /// <param name="discardMatch">If set to <c>true</c>, the matched pair of characters will not be included in the returned substring.</param>
        /// <returns>A new string reader that encapsulates a substring read from the underlying string instance of the current reader.</returns>
        public StringReader ReadToMatchAsReader(bool discardMatch = true)
        {
            var currChar = UnderlyingString[CurrentPosition];
            var matchedChar = _getMatchedCharacter(currChar);
            if (discardMatch) return _innerReadToMatchAsReader(currChar, matchedChar, ReadOptions.StopAfterKey | ReadOptions.DiscardKey);
            else return _innerReadToMatchAsReader(currChar, matchedChar, ReadOptions.StopAfterKey);
        }

        /// <summary>
        /// Advances the reader and reads until a match of the reader's current character is found.
        /// The reader's current character is the character of the underlying string at the reader's current position.
        /// </summary>
        /// <param name="matchedCharacter">Defines the character that matches the reader's current character.</param>
        /// <param name="discardMatch">If set to <c>true</c>, the matched pair of characters will not be included in the returned substring.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToMatchAsReader(char matchedCharacter, bool discardMatch = true)
        {
            var currChar = UnderlyingString[CurrentPosition];
            if (discardMatch) return _innerReadToMatchAsReader(currChar, matchedCharacter, ReadOptions.StopAfterKey | ReadOptions.DiscardKey);
            else return _innerReadToMatchAsReader(currChar, matchedCharacter, ReadOptions.StopAfterKey);
        }

        /// <summary>
        /// Advances the reader and reads until a match of the reader's current character outside quotes is found.
        /// The reader's current character is the character of the underlying string at the reader's current position.
        /// </summary>
        /// <param name="leftQuote">The left quote. Any match that occurs between a pair of quotes will be ignored.</param>
        /// <param name="rightQuote">The right quote. Any match that occurs between a pair of quotes will be ignored.</param>
        /// <param name="discardMatch">If set to <c>true</c>, the matched pair of characters will not be included in the returned substring.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToMatchAsReader(char leftQuote, char rightQuote, bool discardMatch = true)
        {
            var currChar = UnderlyingString[CurrentPosition];
            var matchedChar = _getMatchedCharacter(currChar);
            if (discardMatch) return _innerReadToMatchAsReader(currChar, matchedChar, leftQuote, rightQuote, ReadOptions.StopAfterKey | ReadOptions.DiscardKey);
            else return _innerReadToMatchAsReader(currChar, matchedChar, leftQuote, rightQuote, ReadOptions.StopAfterKey);
        }

        /// <summary>
        /// Advances the reader and reads until a match of the reader's current character outside quotes is found.
        /// The reader's current character is the character of the underlying string at the reader's current position.
        /// </summary>
        /// <param name="matchedCharacter">Defines the character that matches the reader's current character.</param>
        /// <param name="leftQuote">The left quote. Any match that occurs between a pair of quotes will be ignored.</param>
        /// <param name="rightQuote">The right quote. Any match that occurs between a pair of quotes will be ignored.</param>
        /// <param name="discardMatch">If set to <c>true</c>, the matched pair of characters will not be included in the returned substring.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToMatchAsReader(char matchedCharacter, char leftQuote, char rightQuote, bool discardMatch = true)
        {
            var currChar = UnderlyingString[CurrentPosition];
            if (discardMatch) return _innerReadToMatchAsReader(currChar, matchedCharacter, leftQuote, rightQuote, ReadOptions.StopAfterKey | ReadOptions.DiscardKey);
            else return _innerReadToMatchAsReader(currChar, matchedCharacter, leftQuote, rightQuote, ReadOptions.StopAfterKey);
        }

        /// <summary>
        /// Advances the reader and reads until a match of the reader's current character outside quotes is found.
        /// The reader's current character is the character of the underlying string at the reader's current position.
        /// </summary>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when a match is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when a match is encountered inside a pair of quotes.</param>
        /// <param name="discardMatch">If set to <c>true</c>, the matched pair of characters will not be included in the returned substring.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToMatchAsReader(char[] leftQuotes, char[] rightQuotes, bool discardMatch = true)
        {
            var currChar = UnderlyingString[CurrentPosition];
            var matchedChar = _getMatchedCharacter(currChar);
            if (discardMatch) return _innerReadToMatchAsReader(currChar, matchedChar, leftQuotes, rightQuotes, ReadOptions.StopAfterKey | ReadOptions.DiscardKey);
            else return _innerReadToMatchAsReader(currChar, matchedChar, leftQuotes, rightQuotes, ReadOptions.StopAfterKey);
        }

        /// <summary>
        /// Advances the reader and reads until a match of the reader's current character outside quotes is found.
        /// The reader's current character is the character of the underlying string at the reader's current position.
        /// </summary>
        /// <param name="matchedCharacter">Defines the character that matches the reader's current character.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when a match is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when a match is encountered inside a pair of quotes.</param>
        /// <param name="discardMatch">If set to <c>true</c>, the matched pair of characters will not be included in the returned substring.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToMatchAsReader(char matchedCharacter, char[] leftQuotes, char[] rightQuotes, bool discardMatch = true)
        {
            var currChar = UnderlyingString[CurrentPosition];
            if (discardMatch) return _innerReadToMatchAsReader(currChar, matchedCharacter, leftQuotes, rightQuotes, ReadOptions.StopAfterKey | ReadOptions.DiscardKey);
            else return _innerReadToMatchAsReader(currChar, matchedCharacter, leftQuotes, rightQuotes, ReadOptions.StopAfterKey);
        }
    }
}
