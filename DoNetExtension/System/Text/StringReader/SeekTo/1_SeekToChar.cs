using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Text
{
    //TODO this file is not complete

    public partial class StringReader
    {
        #region SeekTo Predicate

        /// <summary>
        /// Advances the reader until a character satisfying <paramref name="predicate"/> is encountered.
        /// </summary>
        /// <param name="predicate">A method to test each character.</param>
        /// <param name="skipKeychar">
        /// <c>true</c> if the reader stops at the position next to the first encountered character satisfying the <paramref name="predicate"/>;
        /// <c>false</c> if the reader stops at the position of such a character.
        /// </param>
        /// <param name="seekToEndIfKeycharNotFound">
        /// <c>true</c> if the reader should advance to the end of the reading scope if no character satisfying the <paramref name="predicate"/> is found;
        /// <c>false</c> if the reader should stand still if such a character cannot be found.
        /// </param>
        /// <returns><c>true</c> if the reader has advanced to a character satisfying the specified <paramref name="predicate"/>; <c>false</c> if no such character is found.</returns>
        public void SeekTo(Func<char, bool> predicate, bool skipKeychar = true, bool seekToEndIfKeycharNotFound = true)
        {
            var idx = UnderlyingString.IndexOf(predicate, CurrentPosition);
            _innerSeekTo(idx, 1, skipKeychar, seekToEndIfKeycharNotFound);
        }

        /// <summary>
        /// Advances the reader until a character satisfying <paramref name="predicate" /> is encountered outside quotes.
        /// </summary>
        /// <param name="predicate">A method to test each character.</param>
        /// <param name="leftQuote">
        /// The left quote that works together with <paramref name="rightQuote"/> to escape the <paramref name="predicate"/>. 
        /// The reader will not stop when a character satisfying the <paramref name="predicate"/> is encountered inside a pair of quotes.
        /// </param>
        /// <param name="rightQuote">
        /// The left quote that works together with <paramref name="leftQuote"/> to escape the <paramref name="predicate"/>. 
        /// The reader will not stop when a character satisfying the <paramref name="predicate"/> is encountered inside a pair of quotes.
        /// </param>
        /// <param name="skipKeychar"><c>true</c> if the reader stops at the position next to the first encountered character satisfying the <paramref name="predicate" />;
        /// <c>false</c> if the reader stops at the position of such a character.</param>
        /// <param name="seekToEndIfKeycharNotFound"><c>true</c> if the reader should advance to the end of the reading scope if no character satisfying the <paramref name="predicate" /> is found;
        /// <c>false</c> if the reader should stand still if such a character cannot be found.</param>
        /// <returns>
        /// <c>true</c> if the reader is advanced to a character outside quotes satisfying the specified <paramref name="predicate" />; <c>false</c> if no such character is found.
        /// </returns>
        public bool SeekTo(Func<char, bool> predicate, char leftQuote, char rightQuote, bool skipKeychar = true, bool seekToEndIfKeycharNotFound = true)
        {
            var keycharPos = UnderlyingString.IndexOfWithQuotes(predicate, CurrentPosition, EndPosition - CurrentPosition, leftQuote, rightQuote);
            return _innerSeekTo(keycharPos, 1, skipKeychar, seekToEndIfKeycharNotFound);
        }

        /// <summary>
        /// Advances the reader until a character satisfying <paramref name="predicate" /> is encountered outside quotes.
        /// </summary>
        /// <param name="predicate">A method to test each character.</param>
        /// <param name="leftQuotes">
        /// The left quotes that work together with <paramref name="rightQuotes"/> to escape the <paramref name="predicate"/>. 
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when a character satisfying the <paramref name="predicate"/> is encountered inside a pair of quotes.
        /// </param>
        /// <param name="rightQuotes">
        /// The left quotes that work together with <paramref name="leftQuotes"/> to escape the <paramref name="predicate"/>. 
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when a character satisfying the <paramref name="predicate"/> is encountered inside a pair of quotes.
        /// </param>
        /// <param name="skipKeychar"><c>true</c> if the reader stops at the position next to the first encountered character satisfying the <paramref name="predicate" />;
        /// <c>false</c> if the reader stops at the position of such a character.</param>
        /// <param name="seekToEndIfKeycharNotFound"><c>true</c> if the reader should advance to the end of the reading scope if no character satisfying the <paramref name="predicate" /> is found;
        /// <c>false</c> if the reader should stand still if such a character cannot be found.</param>
        /// <returns>
        /// <c>true</c> if the reader is advanced to a character outside quotes satisfying the specified <paramref name="predicate" />; <c>false</c> if no such character is found.
        /// </returns>
        public bool SeekTo(Func<char, bool> predicate, char[] leftQuotes, char[] rightQuotes, bool skipKeychar = true, bool seekToEndIfKeycharNotFound = true)
        {
            var keycharPos = UnderlyingString.IndexOfWithQuotes(predicate, CurrentPosition, EndPosition - CurrentPosition, leftQuotes, rightQuotes);
            return _innerSeekTo(keycharPos, 1, skipKeychar, seekToEndIfKeycharNotFound);
        }

        #endregion

        #region SeekTo A Keychar

        /// <summary>
        /// Advances the reader until an occurrence of the specified character is encountered.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered.</param>
        /// <param name="skipKeychar">
        /// <c>true</c> if the reader stops at the position next to the encountered <paramref name="keychar"/>;
        /// <c>false</c> if the reader stops at the position of the encountered <paramref name="keychar"/>.
        /// </param>
        /// <param name="seekToEndIfKeycharNotFound">
        /// <c>true</c> if the reader should advance to the end of the reading scope if <paramref name="keychar"/> is not found.
        /// <c>false</c> if the reader should stand still if such a character cannot be found.
        /// </param>
        /// <returns>
        /// <c>true</c> if an occurrence <paramref name="keychar" /> is found and the reader has advanced to that character; <c>false</c> if no such character is found.
        /// </returns>
        public bool SeekTo(char keychar, bool skipKeychar = true, bool seekToEndIfKeycharNotFound = true)
        {
            var keycharPos = UnderlyingString.IndexOf(keychar, CurrentPosition, EndPosition - CurrentPosition);
            return _innerSeekTo(keycharPos, 1, skipKeychar, seekToEndIfKeycharNotFound);
        }

        /// <summary>
        /// Advances the reader until an occurrence of the specified character is encountered outside quotes.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered.</param>
        /// <param name="leftQuote">
        /// The left quote that works together with <paramref name="rightQuote"/> to escape the <paramref name="keychar"/>. 
        /// The reader will not stop when a keychar is encountered inside a pair of quotes.
        /// </param>
        /// <param name="rightQuote">
        /// The left quote that works together with <paramref name="leftQuote"/> to escape the <paramref name="keychar"/>. 
        /// The reader will not stop when a keychar is encountered inside a pair of quotes.
        /// </param>
        /// <param name="skipKeychar">
        /// <c>true</c> if the reader stops at the position next to the encountered <paramref name="keychar"/>;
        /// <c>false</c> if the reader stops at the position of the encountered <paramref name="keychar"/>.
        /// </param>
        /// <param name="seekToEndIfKeycharNotFound">
        /// <c>true</c> if the reader should advance to the end of the reading scope if <paramref name="keychar"/> is not found.
        /// <c>false</c> if the reader should stand still if such a character cannot be found.
        /// </param>
        /// <returns>
        /// <c>true</c> if an occurrence <paramref name="keychar" /> is found outside quotes and the reader is advanced to that character; <c>false</c> if no such character is found.
        /// </returns>
        public bool SeekTo(char keychar, char leftQuote, char rightQuote, bool skipKeychar = true, bool seekToEndIfKeycharNotFound = true)
        {
            var keycharPos = UnderlyingString.IndexOfWithQuotes(keychar, CurrentPosition, EndPosition - CurrentPosition, leftQuote, rightQuote);
            return _innerSeekTo(keycharPos, 1, skipKeychar, seekToEndIfKeycharNotFound);
        }


        /// <summary>
        /// Advances the reader until an occurrence of the specified character is encountered outside quotes.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered.</param>
        /// <param name="leftQuotes">
        /// The left quotes that work together with <paramref name="rightQuotes"/> to escape the <paramref name="predicate"/>. 
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when a character satisfying the <paramref name="predicate"/> is encountered inside a pair of quotes.
        /// </param>
        /// <param name="rightQuotes">
        /// The left quotes that work together with <paramref name="leftQuotes"/> to escape the <paramref name="predicate"/>. 
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when a character satisfying the <paramref name="predicate"/> is encountered inside a pair of quotes.
        /// </param>
        /// <param name="skipKeychar">
        /// <c>true</c> if the reader stops at the position next to the encountered <paramref name="keychar"/>;
        /// <c>false</c> if the reader stops at the position of the encountered <paramref name="keychar"/>.
        /// </param>
        /// <param name="seekToEndIfKeycharNotFound">
        /// <c>true</c> if the reader should advance to the end of the reading scope if <paramref name="keychar"/> is not found.
        /// <c>false</c> if the reader should stand still if such a character cannot be found.
        /// </param>
        /// <returns>
        /// <c>true</c> if an occurrence <paramref name="keychar" /> is found outside quotes and the reader is advanced to that character; <c>false</c> if no such character is found.
        /// </returns>
        public bool SeekTo(char keychar, char[] leftQuotes, char[] rightQuotes, bool skipKeychar = true, bool seekToEndIfKeycharNotFound = true)
        {
            var keycharPos = UnderlyingString.IndexOfWithQuotes(keychar, CurrentPosition, EndPosition - CurrentPosition, leftQuotes, rightQuotes);
            return _innerSeekTo(keycharPos, 1, skipKeychar, seekToEndIfKeycharNotFound);
        }

        #endregion

        #region SeekTo Keychars

        /// <summary>
        /// Advances the reader until an occurrence of any of the specified characters is encountered.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="skipKeychar">
        /// <c>true</c> if the reader stops at the position next to the encountered keychar.
        /// <c>false</c> if the reader stops at the position of the encountered keychar.
        /// </param>
        /// <param name="seekToEndIfKeycharNotFound">
        /// <c>true</c> if the reader should advance to the end of the reading scope if none of <paramref name="keychars"/> is found.
        /// <c>false</c> if the reader should stand still if such a character cannot be found.
        /// </param>
        /// <returns>
        /// <c>true</c> if an occurrence of any of the <paramref name="keywords" /> is found and the reader is advanced to that character; 
        /// <c>false</c> if no such character is found.
        /// </returns>
        public int SeekTo(char[] keychars, bool skipKeychar = true, bool seekToEndIfKeycharNotFound = true)
        {
            var keycharPos = UnderlyingString.IndexOfAny(keychars, CurrentPosition, EndPosition - CurrentPosition, out var keycharIndex);
            _innerSeekTo(keycharPos, 1, skipKeychar, seekToEndIfKeycharNotFound);
            return keycharIndex;
        }

        /// <summary>
        /// Advances the reader until an occurrence of any of the specified characters is encountered outside quotes.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="leftQuote">
        /// The left quote that works together with <paramref name="rightQuote"/> to escape the <paramref name="keychars"/>. 
        /// The reader will not stop when a keychar is encountered inside a pair of quotes.
        /// </param>
        /// <param name="rightQuote">
        /// The left quote that works together with <paramref name="leftQuote"/> to escape the <paramref name="keychars"/>. 
        /// The reader will not stop when a keychar is encountered inside a pair of quotes.
        /// </param>
        /// <param name="skipKeychar">
        /// <c>true</c> if the reader stops at the position next to the encountered keychar.
        /// <c>false</c> if the reader stops at the position of the encountered keychar.
        /// </param>
        /// <param name="seekToEndIfKeycharNotFound">
        /// <c>true</c> if the reader should advance to the end of the reading scope if none of <paramref name="keychars"/> is found.
        /// <c>false</c> if the reader should stand still if such a character cannot be found.
        /// </param>
        /// <returns>
        /// '\0' if none of <paramref name="keychars"/> is found; ohterwise, the encountered keychar.
        /// </returns>
        public char SeekTo(char[] keychars, char leftQuoe, char rightQuote, bool skipKeychar = true, bool seekToEndIfKeycharNotFound = true)
        {
            var keycharPos = UnderlyingString.IndexOfAnyWithQuotes(keychars, CurrentPosition, EndPosition - CurrentPosition, leftQuoe, rightQuote);
            if (keycharPos == -1)
            {
                _innerSeekTo(-1, 0, skipKeychar, seekToEndIfKeycharNotFound);
                return '\0';
            }
            else
            {
                _innerSeekTo(keycharPos, 1, skipKeychar, seekToEndIfKeycharNotFound);
                return UnderlyingString[keycharPos];
            }
        }

        /// <summary>
        /// Advances the reader until an occurrence of any of the specified characters is encountered outside quotes.
        /// </summary>
        /// <param name="keychars">The reader stops when any of these characters is encountered.</param>
        /// <param name="leftQuotes">
        /// The left quotes that work together with <paramref name="rightQuotes"/> to escape the <paramref name="predicate"/>. 
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when a character satisfying the <paramref name="predicate"/> is encountered inside a pair of quotes.
        /// </param>
        /// <param name="rightQuotes">
        /// The left quotes that work together with <paramref name="leftQuotes"/> to escape the <paramref name="predicate"/>. 
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when a character satisfying the <paramref name="predicate"/> is encountered inside a pair of quotes.
        /// </param>
        /// <param name="skipKeychar">
        /// <c>true</c> if the reader stops at the position next to the encountered keychar.
        /// <c>false</c> if the reader stops at the position of the encountered keychar.
        /// </param>
        /// <param name="seekToEndIfKeycharNotFound">
        /// <c>true</c> if the reader should advance to the end of the reading scope if none of <paramref name="keychars"/> is found.
        /// <c>false</c> if the reader should stand still if such a character cannot be found.
        /// </param>
        /// <returns>
        /// '\0' if none of <paramref name="keychars"/> is found; ohterwise, the encountered keychar.
        /// </returns>
        public char SeekTo(char[] keychars, char[] leftQuotes, char[] rightQuotes, bool skipKeychar = true, bool seekToEndIfKeycharNotFound = true)
        {
            var keycharPos = UnderlyingString.IndexOfAnyWithQuotes(keychars, CurrentPosition, EndPosition - CurrentPosition, leftQuotes, rightQuotes);
            if (keycharPos == -1)
            {
                _innerSeekTo(-1, 0, skipKeychar, seekToEndIfKeycharNotFound);
                return '\0';
            }
            else
            {
                _innerSeekTo(keycharPos, 1, skipKeychar, seekToEndIfKeycharNotFound);
                return UnderlyingString[keycharPos];
            }
        }

        #endregion
    }
}
