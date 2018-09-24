using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Text
{
    public partial class StringReader
    {
        //TODO this file is not complete

        #region SeekTo A Keyword

        /// <summary>
        /// Advances the reader until an occurrence of the specified string is encountered.
        /// </summary>
        /// <param name="keyword">The reader stops when this string is encountered.</param>
        /// <param name="skipKeyword">
        /// <c>true</c> if the reader stops at the position next to the last character of the encountered keyword.
        /// <c>false</c> if the reader stops at the position of the first character of the encountered keyword.
        /// </param>
        /// <param name="seekToEndIfKeywordNotFound">
        /// <c>true</c> if the reader should advance to the end of the reading scope if <paramref name="keyword"/> is not found.
        /// <c>false</c> if the reader should stand still if such a keyword cannot be found.
        /// </param>
        /// <returns>
        /// <c>true</c> if an occurrence of <paramref name="keyword" /> is encountered and the reader is advanced to that keyword; <c>false</c> if no such keyword is found.
        /// </returns>
        public bool SeekTo(string keyword, bool skipKeyword = true, bool seekToEndIfKeywordNotFound = true)
        {
            var keywordPos = UnderlyingString.IndexOf(keyword, CurrentPosition, EndPosition - CurrentPosition);
            return _innerSeekTo(keywordPos, keyword.Length, skipKeyword, seekToEndIfKeywordNotFound);
        }

        /// <summary>
        /// Advances the reader until an occurrence of the specified string is encountered outside quotes.
        /// </summary>
        /// <param name="keyword">The reader stops when this string is encountered.</param>
        /// <param name="leftQuote">
        /// The left quote that works together with <paramref name="rightQuote"/> to escape the <paramref name="keyword"/>. 
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.
        /// </param>
        /// <param name="rightQuote">
        /// The left quote that works together with <paramref name="leftQuote"/> to escape the <paramref name="keyword"/>. 
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.
        /// </param>
        /// <param name="skipKeyword">
        /// <c>true</c> if the reader stops at the position next to the last character of the encountered keyword.
        /// <c>false</c> if the reader stops at the position of the first character of the encountered keyword.
        /// </param>
        /// <param name="seekToEndIfKeywordNotFound">
        /// <c>true</c> if the reader should advance to the end of the reading scope if <paramref name="keyword"/> is not found.
        /// <c>false</c> if the reader should stand still if such a keyword cannot be found.
        /// </param>
        /// <returns>
        /// <c>true</c> if an occurrence of <paramref name="keyword" /> is encountered outside quotes and the reader is advanced to that keyword; <c>false</c> if no such keyword is found.
        /// </returns>
        public bool SeekTo(string keyword, char leftQuote, char rightQuote, bool skipKeyword = true, bool seekToEndIfKeywordNotFound = true)
        {
            var keywordPos = UnderlyingString.IndexOfWithQuotes(keyword, CurrentPosition, EndPosition - CurrentPosition, leftQuote, rightQuote, ComparisonType);
            return _innerSeekTo(keywordPos, keyword.Length, skipKeyword, seekToEndIfKeywordNotFound);
        }

        /// <summary>
        /// Advances the reader until an occurrence of the specified string is encountered outside quotes.
        /// </summary>
        /// <param name="keyword">The reader stops when this string is encountered.</param>
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
        /// <param name="skipKeyword">
        /// <c>true</c> if the reader stops at the position next to the last character of the encountered keyword.
        /// <c>false</c> if the reader stops at the position of the first character of the encountered keyword.
        /// </param>
        /// <param name="seekToEndIfKeywordNotFound">
        /// <c>true</c> if the reader should advance to the end of the reading scope if <paramref name="keyword"/> is not found.
        /// <c>false</c> if the reader should stand still if such a keyword cannot be found.
        /// </param>
        /// <returns>
        /// <c>true</c> if an occurrence of <paramref name="keyword" /> is encountered outside quotes and the reader is advanced to that keyword; <c>false</c> if no such keyword is found.
        /// </returns>
        public bool SeekTo(string keyword, char[] leftQuotes, char[] rightQuotes, bool skipKeyword = true, bool seekToEndIfKeywordNotFound = true)
        {
            var keywordPos = UnderlyingString.IndexOfWithQuotes(keyword, CurrentPosition, EndPosition - CurrentPosition, leftQuotes, rightQuotes, ComparisonType);
            return _innerSeekTo(keywordPos, keyword.Length, skipKeyword, seekToEndIfKeywordNotFound);
        }

        #endregion

        #region SeekTo Keywords

        /// <summary>
        /// Advances the reader until an occurrence of any of the specified strings is encountered.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these strings is encountered.</param>
        /// <param name="skipKeyword">
        /// <c>true</c> if the reader stops at the position next to the last character of the encountered keyword.
        /// <c>false</c> if the reader stops at the position of the first character of the encountered keyword.
        /// </param>
        /// <param name="seekToEndIfKeywordNotFound">
        /// <c>true</c> if the reader should advance to the end of the reading scope if none of <paramref name="keywords"/> is found.
        /// <c>false</c> if the reader should stand still if such a keyword cannot be found.
        /// </param>
        /// <returns>
        /// <c>true</c> if an occurrence of any of the <paramref name="keywords" /> is found and the reader is advanced to that keyword; 
        /// <c>false</c> if no such keyword is found.
        /// </returns>
        public int SeekTo(string[] keywords, bool skipKeyword = true, bool seekToEndIfKeywordNotFound = true)
        {
            var keywordSearchResult = UnderlyingString.IndexOfAny(keywords, CurrentPosition, EndPosition - CurrentPosition);
            if (keywordSearchResult == null)
            {
                _innerSeekTo(-1, 0, skipKeyword, seekToEndIfKeywordNotFound);
                return -1;
            }
            else
            {
                _innerSeekTo(keywordSearchResult.Position, keywordSearchResult.Value.Length, skipKeyword, seekToEndIfKeywordNotFound);
                return keywordSearchResult.HitIndex;
            }
        }

        /// <summary>
        /// Advances the reader until an occurrence of any of the specified strings is encountered outside quotes.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these strings is encountered.</param>
        /// <param name="leftQuote">
        /// The left quote that works together with <paramref name="rightQuote"/> to escape the <paramref name="keywords"/>. 
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.
        /// </param>
        /// <param name="rightQuote">
        /// The left quote that works together with <paramref name="leftQuote"/> to escape the <paramref name="keywords"/>. 
        /// The reader will not stop when a keyword is encountered inside a pair of quotes.
        /// </param>
        /// <param name="skipKeyword">
        /// <c>true</c> if the reader stops at the position next to the last character of the encountered keyword.
        /// <c>false</c> if the reader stops at the position of the first character of the encountered keyword.
        /// </param>
        /// <param name="seekToEndIfKeywordNotFound">
        /// <c>true</c> if the reader should advance to the end of the reading scope if none of <paramref name="keywords"/> is found.
        /// <c>false</c> if the reader should stand still if such a keyword cannot be found.
        /// </param>
        /// <returns>
        /// <c>true</c> if an occurrence of any of the <paramref name="keywords" /> is encountered outside quotes and the reader is advanced to that keyword; 
        /// <c>false</c> if no such keyword is found.
        /// </returns>
        public int SeekTo(string[] keywords, char leftQuote, char rightQuote, bool skipKeyword = true, bool seekToEndIfKeywordNotFound = true)
        {
            var keywordSearchResult = UnderlyingString.IndexOfAnyWithQuotes(keywords, CurrentPosition, EndPosition - CurrentPosition, leftQuote, rightQuote, ComparisonType);
            if (keywordSearchResult == null)
            {
                _innerSeekTo(-1, 0, skipKeyword, seekToEndIfKeywordNotFound);
                return -1;
            }
            else
            {
                _innerSeekTo(keywordSearchResult.Position, keywordSearchResult.Value.Length, skipKeyword, seekToEndIfKeywordNotFound);
                return keywordSearchResult.HitIndex;
            }
        }

        /// <summary>
        /// Advances the reader until an occurrence of any of the specified <paramref name="keywords"/> is encountered outside quotes.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these strings is encountered.</param>
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
        /// <param name="skipKeyword">
        /// <c>true</c> if the reader stops at the position next to the last character of the encountered keyword.
        /// <c>false</c> if the reader stops at the position of the first character of the encountered keyword.
        /// </param>
        /// <param name="seekToEndIfKeywordNotFound">
        /// <c>true</c> if the reader should advance to the end of the reading scope if none of <paramref name="keywords"/> is found.
        /// <c>false</c> if the reader should stand still if such a keyword cannot be found.
        /// </param>
        /// <returns>
        /// THe index of the encountered keyword in the <paramref name="keywords" />, if any ouccrrance of the <paramref name="keywords"/> is encountered outside quotes and the reader has advanced to that keyword; 
        /// -1 if no keyword is encountered.
        /// </returns>
        public int SeekTo(string[] keywords, char[] leftQuotes, char[] rightQuotes, bool skipKeyword = true, bool seekToEndIfKeywordNotFound = true)
        {
            var keywordSearchResult = UnderlyingString.IndexOfAnyWithQuotes(keywords, CurrentPosition, EndPosition - CurrentPosition, leftQuotes, rightQuotes, ComparisonType);
            if (keywordSearchResult == null)
            {
                _innerSeekTo(-1, 0, skipKeyword, seekToEndIfKeywordNotFound);
                return -1;
            }
            else
            {
                _innerSeekTo(keywordSearchResult.Position, keywordSearchResult.Value.Length, skipKeyword, seekToEndIfKeywordNotFound);
                return keywordSearchResult.HitIndex;
            }
        }

        /// <summary>
        /// Advances the reader until an occurrence of any of the specified <paramref name="keywords"/> is encountered outside quotes.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these strings is encountered.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="skipKeyword">
        /// <c>true</c> if the reader stops at the position next to the last character of the encountered keyword.
        /// <c>false</c> if the reader stops at the position of the first character of the encountered keyword.
        /// </param>
        /// <param name="seekToEndIfKeywordNotFound">
        /// <c>true</c> if the reader should advance to the end of the reading scope if none of <paramref name="keywords"/> is found.
        /// <c>false</c> if the reader should stand still if such a keyword cannot be found.
        /// </param>
        /// <returns>
        /// THe index of the encountered keyword in the <paramref name="keywords" />, if any ouccrrance of the <paramref name="keywords"/> is encountered outside quotes and the reader has advanced to that keyword; 
        /// -1 if no keyword is encountered.
        /// </returns>
        public int SeekTo(string[] keywords, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, bool skipKeyword = true, bool seekToEndIfKeywordNotFound = true)
        {
            var keywordSearchResult = UnderlyingString.IndexOfAnyWithQuotes(keywords, CurrentPosition, EndPosition - CurrentPosition, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, ComparisonType);
            if (keywordSearchResult == null)
            {
                _innerSeekTo(-1, 0, skipKeyword, seekToEndIfKeywordNotFound);
                return -1;
            }
            else
            {
                _innerSeekTo(keywordSearchResult.Position, keywordSearchResult.Value.Length, skipKeyword, seekToEndIfKeywordNotFound);
                return keywordSearchResult.HitIndex;
            }
        }

        /// <summary>
        /// Advances the reader until an occurrence of any of the specified <paramref name="keywords"/> is encountered outside quotes.
        /// </summary>
        /// <param name="keywords">The reader stops when any of these strings is encountered.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="skipKeyword">
        /// <c>true</c> if the reader stops at the position next to the last character of the encountered keyword.
        /// <c>false</c> if the reader stops at the position of the first character of the encountered keyword.
        /// </param>
        /// <param name="seekToEndIfKeywordNotFound">
        /// <c>true</c> if the reader should advance to the end of the reading scope if none of <paramref name="keywords"/> is found.
        /// <c>false</c> if the reader should stand still if such a keyword cannot be found.
        /// </param>
        /// <returns>
        /// THe index of the encountered keyword in the <paramref name="keywords" />, if any ouccrrance of the <paramref name="keywords"/> is encountered outside quotes and the reader has advanced to that keyword; 
        /// -1 if no keyword is encountered.
        /// </returns>
        public int SeekTo(string[] keywords, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool skipKeyword = true, bool seekToEndIfKeywordNotFound = true)
        {
            var keywordSearchResult = UnderlyingString.IndexOfAnyWithQuotes(keywords, CurrentPosition, EndPosition - CurrentPosition, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, ComparisonType);
            if (keywordSearchResult == null)
            {
                _innerSeekTo(-1, 0, skipKeyword, seekToEndIfKeywordNotFound);
                return -1;
            }
            else
            {
                _innerSeekTo(keywordSearchResult.Position, keywordSearchResult.Value.Length, skipKeyword, seekToEndIfKeywordNotFound);
                return keywordSearchResult.HitIndex;
            }
        }

        #endregion
    }
}
