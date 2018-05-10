using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class StringEx
    {
        /// <summary>
        /// Returns a new string instance, with all Unicode characters, which are outside quotes and satisfy the specified predicate, replaced by a new character.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character outside quotes of the current string.</param>
        /// <param name="newChar">The new character to replace those satisfying the predicate.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for characters satisfying <paramref name="predicate" /> starts.</param>
        /// <param name="leftQuote">Specifies the Unicode character as the left quote.</param>
        /// <param name="rightQuote">Specifies the Unicode character as the right quote.</param>
        /// <returns>
        /// A new string instance with characters replaced.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static string ReplaceWithQuotes(this string str, Func<char, bool> predicate, char newChar, int startIndex = 0, char leftQuote = '{', char rightQuote = '}')
        {
            var strLen = str.Length;
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, strLen - 1, true);
            return _innerReplaceWithQuotes(str, predicate, newChar, startIndex, strLen, leftQuote, rightQuote);
        }

        /// <summary>
        /// Returns a new string instance, with all Unicode characters, which are outside quotes and satisfy the specified predicate, replaced by a new character.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character outside quotes of the current string.</param>
        /// <param name="newChar">The new character to replace those satisfying the predicate.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for characters satisfying <paramref name="predicate" /> starts.</param>
        /// <param name="leftQuotes">Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.</param>
        /// <param name="rightQuotes">Specifies an array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.</param>
        /// <returns>
        /// A new string instance with characters replaced.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static string ReplaceWithQuotes(this string str, Func<char, bool> predicate, char newChar, int startIndex, char[] leftQuotes, char[] rightQuotes)
        {
            var strLen = str.Length;
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, strLen - 1, true);
            return _innerReplaceWithQuotes(str, predicate, newChar, startIndex, strLen, leftQuotes, rightQuotes);
        }

        /// <summary>
        /// Returns a new string instance, with all occurrences of the specified character outside quotes replaced by a new value.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="oldChar">All occurrences of this character are to be replaced.</param>
        /// <param name="newChar">The new character to replace occurrences of the <paramref name="oldChar"/>.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for <paramref name="oldChar" /> starts.</param>
        /// <param name="leftQuote">Specifies the Unicode character as the left quote.</param>
        /// <param name="rightQuote">Specifies the Unicode character as the right quote.</param>
        /// <returns>
        /// A new string instance with characters replaced.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static string ReplaceWithQuotes(this string str, char oldChar, char newChar, int startIndex = 0, char leftQuote = '{', char rightQuote = '}')
        {
            var strLen = str.Length;
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, strLen - 1, true);
            return _innerReplaceWithQuotes(str, c => c == oldChar, newChar, startIndex, strLen, leftQuote, rightQuote);
        }

        /// <summary>
        /// Returns a new string instance, with all occurrences of the specified substring outside quotes replaced by a new value.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="oldChar">All occurrences of this character are to be replaced.</param>
        /// <param name="newChar">The new character to replace occurrences of the <paramref name="oldChar"/>.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for <paramref name="oldChar" /> starts.</param>
        /// <param name="leftQuotes">Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.</param>
        /// <param name="rightQuotes">The right quotes.</param>
        /// <returns>
        /// A new string instance with characters replaced.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static string ReplaceWithQuotes(this string str, char oldChar, char newChar, int startIndex, char[] leftQuotes, char[] rightQuotes)
        {
            var strLen = str.Length;
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, strLen - 1, true);
            return _innerReplaceWithQuotes(str, c => c == oldChar, newChar, startIndex, strLen, leftQuotes, rightQuotes);
        }

        /// <summary>
        /// Returns a new string instance, with all occurrences of the specified characters outside quotes replaced by a new value.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="oldChars">All occurrences of these characters are to be replaced.</param>
        /// <param name="newChar">The new character to replace occurrences of <paramref name="oldChars" />.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for <paramref name="oldChars" /> starts.</param>
        /// <param name="leftQuote">Specifies the Unicode character as the left quote.</param>
        /// <param name="rightQuote">Specifies the Unicode character as the right quote.</param>
        /// <returns>
        /// A new string instance with characters replaced.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static string ReplaceWithQuotes(this string str, char[] oldChars, char newChar, int startIndex = 0, char leftQuote = '{', char rightQuote = '}')
        {
            var strLen = str.Length;
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, strLen - 1, true);
            return _innerReplaceWithQuotes(str, c => c.In(oldChars), newChar, startIndex, strLen, leftQuote, rightQuote);
        }

        /// <summary>
        /// Returns a new string instance, with all occurrences of the specified characters outside quotes replaced by a new value.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="oldChars">All occurrences of these characters are to be replaced.</param>
        /// <param name="newChar">The new value to replace occurrences of <paramref name="oldChars" />.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for <paramref name="oldChars" /> starts.</param>
        /// <param name="leftQuotes">Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.</param>
        /// <param name="rightQuotes">Specifies an array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.</param>
        /// <returns>
        /// A new string instance with characters replaced.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static string ReplaceWithQuotes(this string str, char[] oldChars, char newChar, int startIndex, char[] leftQuotes, char[] rightQuotes)
        {
            var strLen = str.Length;
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, strLen - 1, true);
            return _innerReplaceWithQuotes(str, c => c.In(oldChars), newChar, startIndex, strLen, leftQuotes, rightQuotes);
        }

        /// <summary>
        /// Returns a new string instance, with all occurrences of the specified substring outside quotes replaced by a new value.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="oldValue">All occurrences of this substring are to be replaced.</param>
        /// <param name="newValue">The new value to replace occurrences of <paramref name="oldValue" />.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for <paramref name="oldValue" /> starts.</param>
        /// <param name="leftQuote">Specifies the Unicode character as the left quote.</param>
        /// <param name="rightQuote">Specifies the Unicode character as the right quote.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search of <paramref name="oldValue" />.</param>
        /// <returns>
        /// A new string instance with substrings replaced.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static string ReplaceWithQuotes(this string str, string oldValue, string newValue, int startIndex = 0,
            char leftQuote = '{', char rightQuote = '}', StringComparison comparisonType = StringComparison.Ordinal)
        {
            var strLen = str.Length;
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, strLen - 1, true);
            return _innerReplaceWithQuotes(str, oldValue, newValue, startIndex, strLen, leftQuote, rightQuote, comparisonType);
        }

        /// <summary>
        /// Returns a new string instance, with all occurrences of the specified substring outside quotes replaced by a new value.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="oldValue">All occurrences of this substring are to be replaced.</param>
        /// <param name="newValue">The new value to replace occurrences of <paramref name="oldValue" />.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for <paramref name="oldValue" /> starts.</param>
        /// <param name="leftQuotes">Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.</param>
        /// <param name="rightQuotes">The right quote.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search of <paramref name="oldValue" />.</param>
        /// <returns>
        /// A new string instance with substrings replaced.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static string ReplaceWithQuotes(this string str, string oldValue, string newValue, int startIndex,
            char[] leftQuotes, char[] rightQuotes, StringComparison comparisonType = StringComparison.Ordinal)
        {
            var strLen = str.Length;
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, strLen - 1, true);
            return _innerReplaceWithQuotes(str, oldValue, newValue, startIndex, strLen, leftQuotes, rightQuotes, comparisonType);
        }

        /// <summary>
        /// Returns a new string instance, with all occurrences of the specified substrings outside quotes replaced by a new value.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="oldValues">All occurrences of these substrings are to be replaced.</param>
        /// <param name="newValue">The new value to replace occurrences of <paramref name="oldValues" />.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for <paramref name="oldValues" /> starts.</param>
        /// <param name="leftQuote">Specifies the Unicode character as the left quote.</param>
        /// <param name="rightQuote">Specifies the Unicode character as the right quote.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search of <paramref name="oldValues" />.</param>
        /// <returns>
        /// A new string instance with substrings replaced.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static string ReplaceWithQuotes(this string str, string[] oldValues, string newValue, int startIndex = 0,
            char leftQuote = '{', char rightQuote = '}', StringComparison comparisonType = StringComparison.Ordinal)
        {
            var strLen = str.Length;
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, strLen - 1, true);
            return _innerReplaceWithQuotes(str, oldValues, newValue, startIndex, strLen, leftQuote, rightQuote, comparisonType);
        }

        /// <summary>
        /// Returns a new string instance, with all occurrences of the specified substrings outside quotes replaced by a new value.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="oldValues">All occurrences of these substrings are to be replaced.</param>
        /// <param name="newValue">The new value to replace occurrences of <paramref name="oldValues" />.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for <paramref name="oldValues" /> starts.</param>
        /// <param name="leftQuotes">Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.</param>
        /// <param name="rightQuotes">Specifies an array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search of <paramref name="oldValues" />.</param>
        /// <returns>
        /// A new string instance with substrings replaced.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static string ReplaceWithQuotes(this string str, string[] oldValues, string newValue, int startIndex,
            char[] leftQuotes, char[] rightQuotes, StringComparison comparisonType = StringComparison.Ordinal)
        {
            var strLen = str.Length;
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, strLen - 1, true);
            return _innerReplaceWithQuotes(str, oldValues, newValue, startIndex, strLen, leftQuotes, rightQuotes, comparisonType);
        }
    }
}
