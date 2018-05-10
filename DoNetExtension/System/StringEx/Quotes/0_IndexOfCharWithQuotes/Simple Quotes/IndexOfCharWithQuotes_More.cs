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
        /// Reports the zero-based index of the first occurrence of a Unicode character outside quotes and satisfying the specified predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character outside quotes of the current string.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for characters satisfying <paramref name="predicate" /> starts.</param>
        /// <param name="leftQuotes">Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.</param>
        /// <param name="rightQuotes">Specifies an array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.</param>
        /// <returns>
        /// The zero-based index position of the first occurrence of <paramref name="value" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        public static int IndexOfWithQuotes(this string str, Func<char, bool> predicate, int startIndex, char[] leftQuotes, char[] rightQuotes)
        {
            return _innerIndexOfWithQuotes(str, predicate, startIndex, str.Length, leftQuotes, rightQuotes);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified escapable Unicode character outside quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="value">The Unicode character to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="leftQuotes">Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.</param>
        /// <param name="rightQuotes">Specifies an array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.</param>
        /// <returns>
        /// The zero-based index position of the first occurrence of <paramref name="value" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        public static int IndexOfWithQuotes(this string str, char value, int startIndex, char[] leftQuotes, char[] rightQuotes)
        {
            return _innerIndexOfWithQuotes(str, c => c.Equals(value), startIndex, str.Length, leftQuotes, rightQuotes);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of any of the specified escapable Unicode characters outside quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">Unicode characters to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="leftQuotes">Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.</param>
        /// <param name="rightQuotes">Specifies an array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.</param>
        /// <returns>
        /// The zero-based index position of the first occurrence of any value specified in <paramref name="values" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        public static int IndexOfAnyWithQuotes(this string str, char[] values, int startIndex, char[] leftQuotes, char[] rightQuotes)
        {
            return _innerIndexOfWithQuotes(str, c => c.In(values), startIndex, str.Length, leftQuotes, rightQuotes);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of a Unicode character outside quotes and satisfying the specified predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character outside quotes of the current string.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for characters satisfying <paramref name="predicate"/> starts.</param>
        /// <param name="leftQuote">Specifies the Unicode character as the left quote.</param>
        /// <param name="rightQuote">Specifies the Unicode character as the right quote.</param>
        /// <returns>The zero-based index position of the first occurrence of <paramref name="value"/> if it is found outside quotes, or -1 if it is not.</returns>
        public static int IndexOfWithQuotes(this string str, Func<char, bool> predicate, int startIndex = 0, char leftQuote = '{', char rightQuote = '}')
        {
            return _innerIndexOfWithQuotes(str, predicate, startIndex, str.Length, leftQuote, rightQuote);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified escapable Unicode character outside quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="value">The Unicode character to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="leftQuote">Specifies the Unicode character as the left quote.</param>
        /// <param name="rightQuote">Specifies the Unicode character as the right quote.</param>
        /// <returns>
        /// The zero-based index position of the first occurrence of <paramref name="value" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        public static int IndexOfWithQuotes(this string str, char value, int startIndex = 0, char leftQuote = '{', char rightQuote = '}')
        {
            return _innerIndexOfWithQuotes(str, c => c.Equals(value), startIndex, str.Length, leftQuote, rightQuote);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of any of the specified escapable Unicode characters outside quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">Unicode characters to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="leftQuote">Specifies the Unicode character as the left quote.</param>
        /// <param name="rightQuote">Specifies the Unicode character as the right quote.</param>
        /// <returns>
        /// The zero-based index position of the first occurrence of any value specified in <paramref name="values" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        public static int IndexOfAnyWithQuotes(this string str, char[] values, int startIndex = 0, char leftQuote = '{', char rightQuote = '}')
        {
            return _innerIndexOfWithQuotes(str, c => c.In(values), startIndex, str.Length, leftQuote, rightQuote);
        }
    }
}
