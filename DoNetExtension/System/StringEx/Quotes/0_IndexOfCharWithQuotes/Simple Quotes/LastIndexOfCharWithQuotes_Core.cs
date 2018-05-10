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
        /// Reports the zero-based index of the last occurrence of a Unicode character outside quotes and satisfying the specified predicate. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character outside quotes of the current string.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for characters satisfying <paramref name="predicate" /> starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from position specified by <paramref name="startIndex" /> towards the beginning of the current string.</param>
        /// <param name="leftQuote">Specifies the Unicode character as the left quote.</param>
        /// <param name="rightQuote">Specifies the Unicode character as the right quote.</param>
        /// <returns>
        /// The zero-based index position of the last occurrence of <paramref name="value" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        /// <exception cref="System.FormatException">
        /// Occurs when there is a quote mismatch in the string instance.
        /// </exception>
        public static int LastIndexOfWithQuotes(this string str, Func<char, bool> predicate, int startIndex, int length, char leftQuote = '{', char rightQuote = '}')
        {
            var endIndex = ExceptionHelper.BackwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerLastIndexOfWithQuotes(str, predicate, startIndex, endIndex, leftQuote, rightQuote);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of a Unicode character outside quotes and satisfying the specified predicate. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character outside quotes of the current string.</param>
        /// <param name="startIndex">The zero-based position indicating where the backward search for characters satisfying <paramref name="predicate" /> starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from position specified by <paramref name="startIndex" /> towards the beginning of the current string.</param>
        /// <param name="leftQuotes">Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.</param>
        /// <param name="rightQuotes">Specifies an array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.</param>
        /// <returns>
        /// The zero-based index position of the last occurrence of <paramref name="value" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static int LastIndexOfWithQuotes(this string str, Func<char, bool> predicate, int startIndex, int length, char[] leftQuotes, char[] rightQuotes)
        {
            var endIndex = ExceptionHelper.BackwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerLastIndexOfWithQuotes(str, predicate, startIndex, endIndex, leftQuotes, rightQuotes);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified Unicode character outside quotes in this string. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="value">The Unicode character to seek.</param>
        /// <param name="startIndex">The zero-based position indicating where the backward search for the specified character starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from position specified by <paramref name="startIndex" /> towards the beginning of the current string.</param>
        /// <param name="leftQuote">Specifies the Unicode character as the left quote.</param>
        /// <param name="rightQuote">Specifies the Unicode character as the right quote.</param>
        /// <returns>
        /// The zero-based index position of the last occurrence of <paramref name="value" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        public static int LastIndexOfWithQuotes(this string str, char value, int startIndex, int length, char leftQuote = '{', char rightQuote = '}')
        {
            var endIndex = ExceptionHelper.BackwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerLastIndexOfWithQuotes(str, c => c.Equals(value), startIndex, endIndex, leftQuote, rightQuote);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified Unicode character outside quotes in this string. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="value">The Unicode character to seek.</param>
        /// <param name="startIndex">The zero-based position indicating where the backward search for the specified character starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from position specified by <paramref name="startIndex" /> towards the beginning of the current string.</param>
        /// <param name="leftQuotes">Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.</param>
        /// <param name="rightQuotes">Specifies an array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.</param>
        /// <returns>
        /// The zero-based index position of the last occurrence of <paramref name="value" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        public static int LastIndexOfWithQuotes(this string str, char value, int startIndex, int length, char[] leftQuotes, char[] rightQuotes)
        {
            var endIndex = ExceptionHelper.BackwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerLastIndexOfWithQuotes(str, c => c.Equals(value), startIndex, endIndex, leftQuotes, rightQuotes);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of any of the specified Unicode characters outside quotes in this string. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">Unicode characters to seek.</param>
        /// <param name="startIndex">The zero-based position indicating where the backward search for the specified characters starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from position specified by <paramref name="startIndex" /> towards the beginning of the current string.</param>
        /// <param name="leftQuotes">Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.</param>
        /// <param name="rightQuotes">Specifies an array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.</param>
        /// <returns>
        /// The zero-based index position of the last occurrence of any value specified in <paramref name="values" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        public static int LastIndexOfAnyWithQuotes(this string str, char[] values, int startIndex, int length, char[] leftQuotes, char[] rightQuotes)
        {
            var endIndex = ExceptionHelper.BackwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerLastIndexOfWithQuotes(str, c => c.In(values), startIndex, endIndex, leftQuotes, rightQuotes);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of any of the specified Unicode characters outside quotes in this string. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">Unicode characters to seek.</param>
        /// <param name="startIndex">The zero-based position indicating where the backward search for the specified characters starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from position specified by <paramref name="startIndex" /> towards the beginning of the current string.</param>
        /// <param name="leftQuote">Specifies the Unicode character as the left quote.</param>
        /// <param name="rightQuote">Specifies the Unicode character as the right quote.</param>
        /// <returns>
        /// The zero-based index position of the last occurrence of any value specified in <paramref name="values" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        public static int LastIndexOfAnyWithQuotes(this string str, char[] values, int startIndex, int length, char leftQuote = '{', char rightQuote = '}')
        {
            var endIndex = ExceptionHelper.BackwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerLastIndexOfWithQuotes(str, c => c.In(values), startIndex, endIndex, leftQuote, rightQuote);
        }
    }
}
