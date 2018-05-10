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
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="leftQuote">Specifies the Unicode character as the left quote.</param>
        /// <param name="rightQuote">Specifies the Unicode character as the right quote.</param>
        /// <returns>
        /// A new string instance with characters replaced.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static string ReplaceWithQuotes(this string str, Func<char, bool> predicate, char newChar, int startIndex, int length, char leftQuote = '{', char rightQuote = '}')
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerReplaceWithQuotes(str, predicate, newChar, startIndex, endIndex, leftQuote, rightQuote);
        }

        /// <summary>
        /// Returns a new string instance, with all Unicode characters, which are outside quotes and satisfy the specified predicate, replaced by a new character.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character outside quotes of the current string.</param>
        /// <param name="newChar">The new character to replace those satisfying the predicate.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for characters satisfying <paramref name="predicate" /> starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="leftQuotes">Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.</param>
        /// <param name="rightQuotes">Specifies an array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.</param>
        /// <returns>
        /// A new string instance with characters replaced.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static string ReplaceWithQuotes(this string str, Func<char, bool> predicate, char newChar, int startIndex, int length, char[] leftQuotes, char[] rightQuotes)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerReplaceWithQuotes(str, predicate, newChar, startIndex, endIndex, leftQuotes, rightQuotes);
        }

        /// <summary>
        /// Returns a new string instance, with all Unicode characters, which are outside quotes and satisfy the specified predicate, replaced by a new character.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character outside quotes of the current string.</param>
        /// <param name="newChar">The new character to replace those satisfying the predicate.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for characters satisfying <paramref name="predicate" /> starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// A new string instance with characters replaced.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static string ReplaceWithQuotes(this string str, Func<char, bool> predicate, char newChar, int startIndex, int length, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerReplaceWithQuotes(str, predicate, newChar, startIndex, endIndex, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote);
        }

        /// <summary>
        /// Returns a new string instance, with all Unicode characters, which are outside quotes and satisfy the specified predicate, replaced by a new character.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character outside quotes of the current string.</param>
        /// <param name="newChar">The new character to replace those satisfying the predicate.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for characters satisfying <paramref name="predicate" /> starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// A new string instance with characters replaced.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static string ReplaceWithQuotes(this string str, Func<char, bool> predicate, char newChar, int startIndex, int length, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerReplaceWithQuotes(str, predicate, newChar, startIndex, endIndex, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes);
        }

        /// <summary>
        /// Returns a new string instance, with all Unicode characters, which are outside quotes and satisfy the specified predicate, replaced by a new character.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character outside quotes of the current string.</param>
        /// <param name="newChar">The new character to replace those satisfying the predicate.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for characters satisfying <paramref name="predicate" /> starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuote" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuote" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// A new string instance with characters replaced.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static string ReplaceWithQuotes(this string str, Func<char, bool> predicate, char newChar, int startIndex, int length, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerReplaceWithQuotes(str, predicate, newChar, startIndex, endIndex, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote);
        }

        /// <summary>
        /// Returns a new string instance, with all Unicode characters, which are outside quotes and satisfy the specified predicate, replaced by a new character.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character outside quotes of the current string.</param>
        /// <param name="newChar">The new character to replace those satisfying the predicate.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for characters satisfying <paramref name="predicate" /> starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuote" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuote" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// A new string instance with characters replaced.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static string ReplaceWithQuotes(this string str, Func<char, bool> predicate, char newChar, int startIndex, int length, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerReplaceWithQuotes(str, predicate, newChar, startIndex, endIndex, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes);
        }

        /// <summary>
        /// Returns a new string instance, with all occurrences of the specified substring outside quotes replaced by a new value.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="oldValue">All occurrences of this substring are to be replaced.</param>
        /// <param name="newValue">The new value to replace occurrences of <paramref name="oldValue" />.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for <paramref name="oldValue" /> starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="leftQuote">Specifies the Unicode character as the left quote.</param>
        /// <param name="rightQuote">Specifies the Unicode character as the right quote.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search of <paramref name="oldValue"/>.</param>
        /// <returns>
        /// A new string instance with substrings replaced.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static string ReplaceWithQuotes(this string str, string oldValue, string newValue, int startIndex, int length, char leftQuote = '{', char rightQuote = '}', StringComparison comparisonType = StringComparison.Ordinal)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerReplaceWithQuotes(str, oldValue, newValue, startIndex, endIndex, leftQuote, rightQuote, comparisonType);
        }

        /// <summary>
        /// Returns a new string instance, with all occurrences of the specified substring outside quotes replaced by a new value.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="oldValue">All occurrences of this substring are to be replaced.</param>
        /// <param name="newValue">The new value to replace occurrences of <paramref name="oldValue" />.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for <paramref name="oldValue" /> starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="leftQuotes">Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.</param>
        /// <param name="rightQuotes">Specifies an array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search of <paramref name="oldValue"/>.</param>
        /// <returns>
        /// A new string instance with substrings replaced.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static string ReplaceWithQuotes(this string str, string oldValue, string newValue, int startIndex, int length, char[] leftQuotes, char[] rightQuotes, StringComparison comparisonType = StringComparison.Ordinal)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerReplaceWithQuotes(str, oldValue, newValue, startIndex, endIndex, leftQuotes, rightQuotes, comparisonType);
        }

        /// <summary>
        /// Returns a new string instance, with all occurrences of the specified substrings outside quotes replaced by a new value.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="oldValues">All occurrences of these substrings are to be replaced.</param>
        /// <param name="newValue">The new value to replace occurrences of <paramref name="oldValues" />.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for <paramref name="oldValues" /> starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="leftQuote">Specifies the Unicode character as the left quote.</param>
        /// <param name="rightQuote">Specifies the Unicode character as the right quote.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search of <paramref name="oldValue"/>.</param>
        /// <returns>
        /// A new string instance with substrings replaced.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static string ReplaceWithQuotes(this string str, string[] oldValues, string newValue, int startIndex, int length, char leftQuote = '{', char rightQuote = '}', StringComparison comparisonType = StringComparison.Ordinal)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerReplaceWithQuotes(str, oldValues, newValue, startIndex, endIndex, leftQuote, rightQuote, comparisonType);
        }

        /// <summary>
        /// Returns a new string instance, with all occurrences of the specified substrings outside quotes replaced by a new value.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="oldValues">All occurrences of these substrings are to be replaced.</param>
        /// <param name="newValue">The new value to replace occurrences of <paramref name="oldValues" />.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for <paramref name="oldValues" /> starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="leftQuotes">Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.</param>
        /// <param name="rightQuotes">Specifies an array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search of <paramref name="oldValue"/>.</param>
        /// <returns>
        /// A new string instance with substrings replaced.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static string ReplaceWithQuotes(this string str, string[] oldValues, string newValue, int startIndex, int length, char[] leftQuotes, char[] rightQuotes, StringComparison comparisonType = StringComparison.Ordinal)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerReplaceWithQuotes(str, oldValues, newValue, startIndex, endIndex, leftQuotes, rightQuotes, comparisonType);
        }
    }
}
