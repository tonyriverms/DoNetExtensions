using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_Extension_Library.System;

namespace System
{
    public static partial class StringEx
    {
        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified <paramref name="value" /> outside quotes in this string. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="value">The substring to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from position specified by <paramref name="startIndex" /> towards the beginning of the current string.</param>
        /// <param name="leftQuote">Specifies the Unicode character as the left quote.</param>
        /// <param name="rightQuote">Specifies the Unicode character as the right quote.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search of <paramref name="value"/>.</param>
        /// <returns>
        /// The zero-based index position of the last occurrence of <paramref name="value" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is quote mismatch in the string instance.</exception>
        public static int LastIndexOfWithQuotes(this string str, string value, int startIndex, int length, char leftQuote = '{', char rightQuote = '}', StringComparison comparisonType = StringComparison.Ordinal)
        {
            var endIndex = ExceptionHelper.BackwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerLastIndexOfWithQuotes(str, value, startIndex, endIndex, leftQuote, rightQuote, comparisonType);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified <paramref name="value" /> outside quotes in this string. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="value">The substring to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from position specified by <paramref name="startIndex" /> towards the beginning of the current string.</param>
        /// <param name="leftQuotes">Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.</param>
        /// <param name="rightQuotes">Specifies an array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search of <paramref name="value"/>.</param>
        /// <returns>
        /// The zero-based index position of the last occurrence of <paramref name="value" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is quote mismatch in the string instance.</exception>
        public static int LastIndexOfWithQuotes(this string str, string value, int startIndex, int length, char[] leftQuotes, char[] rightQuotes,
            StringComparison comparisonType = StringComparison.Ordinal)
        {
            var endIndex = ExceptionHelper.BackwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerLastIndexOfWithQuotes(str, value, startIndex, endIndex, leftQuotes, rightQuotes, comparisonType);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of any of the specified <paramref name="values" /> outside quotes in this string. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The substrings to seek.</param>
        /// <param name="startIndex">The search starting position. </param>
        /// <param name="length">A positive value indicating the number of characters to search starting from position specified by <paramref name="startIndex" /> towards the beginning of the current string.</param>
        /// <param name="leftQuote">Specifies the Unicode character as the left quote.</param>
        /// <param name="rightQuote">Specifies the Unicode character as the right quote.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search of <paramref name="value"/>.</param>
        /// <returns>
        /// A <see cref="System.StringSearchResult"/> object that stores the zero-based index position of the last occurrence of any of the specified <paramref name="values"/> if one is found outside quotes, or <c>null</c> if none is found.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is quote mismatch in the string instance.</exception>
        public static StringSearchResult LastIndexOfAnyWithQuotes(this string str, string[] values, int startIndex, int length, char leftQuote = '{', char rightQuote = '}', StringComparison comparisonType = StringComparison.Ordinal)
        {
            var endIndex = ExceptionHelper.BackwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerLastIndexOfWithQuotes(str, values, startIndex, endIndex, leftQuote, rightQuote, comparisonType);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of any of the specified <paramref name="values" /> outside quotes in this string. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The substrings to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from position specified by <paramref name="startIndex" /> towards the beginning of the current string.</param>
        /// <param name="leftQuotes">Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.</param>
        /// <param name="rightQuotes">Specifies an array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search of <paramref name="value"/>.</param>
        /// <returns>
        /// A <see cref="System.StringSearchResult"/> object that stores the zero-based index position of the last occurrence of any of the specified <paramref name="values"/> if one is found outside quotes, or <c>null</c> if none is found.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is quote mismatch in the string instance.</exception>
        public static StringSearchResult LastIndexOfAnyWithQuotes(this string str, string[] values, int startIndex, int length, char[] leftQuotes, char[] rightQuotes, StringComparison comparisonType = StringComparison.Ordinal)
        {
            var endIndex = ExceptionHelper.BackwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerLastIndexOfWithQuotes(str, values, startIndex, endIndex, leftQuotes, rightQuotes, comparisonType);
        }
    }
}
