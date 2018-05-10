using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class StringEx
    {
        static int _innerIndexOfWithEscape(string str, Func<char, bool> predicate, int startIndex, int endIndex, Func<char, bool> escapePredicate)
        {
            var i = startIndex;
            while (i < endIndex)
            {
                var c = str[i];

                if (escapePredicate(c)) i += 2;
                else if (predicate(c)) return i;
                else ++i;
            }

            return -1;
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of any escapable Unicode character satisfying the specified predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character of the current string.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex"/>.</param>
        /// <param name="escape">Specifies the Unicode character as the escape indicator. 
        /// Use two consecutive escape characters to indicate the literal value of an escape character.</para>
        /// </param>
        /// <returns>The zero-based index position of the first occurrence of <paramref name="value"/> if it is found, or -1 if it is not.</returns>
        public static int IndexOfWithEscape(this string str, Func<char, bool> predicate, int startIndex, int length, Func<char, bool> escapePredicate)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerIndexOfWithEscape(str, predicate, startIndex, endIndex, escapePredicate);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified escapable Unicode character in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">A unicode character to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex"/>.</param>
        /// <param name="escape">Specifies the Unicode character as the escape indicator. 
        /// Use two consecutive escape characters to indicate the literal value of an escape character.</para>
        /// </param>
        /// <returns>The zero-based index position of the first occurrence of <paramref name="value"/> if it is found, or -1 if it is not.</returns>
        public static int IndexOfWithEscape(this string str, char value, int startIndex, int length, Func<char, bool> escapePredicate)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerIndexOfWithEscape(str, c => c == value, startIndex, endIndex, escapePredicate);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified escapable Unicode character in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">A unicode character to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="escape">Specifies the Unicode character as the escape indicator. 
        /// Use two consecutive escape characters to indicate the literal value of an escape character.</para>
        /// </param>
        /// <returns>The zero-based index position of the first occurrence of <paramref name="value"/> if it is found, or -1 if it is not.</returns>
        public static int IndexOfWithEscape(this string str, char value, int startIndex, Func<char, bool> escapePredicate)
        {
            return _innerIndexOfWithEscape(str, c => c == value, startIndex, str.Length, escapePredicate);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of any of the specified escapable Unicode characters in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">Unicode characters to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex"/>.</param>
        /// <param name="escape">Specifies the Unicode character as the escape indicator. 
        /// Use two consecutive escape characters to indicate the literal value of an escape character.</para>
        /// </param>
        /// <returns>The zero-based index position of the first occurrence of any value specified in <paramref name="values"/> if it is found, or -1 if it is not.</returns>
        public static int IndexOfAnyWithEscape(this string str, char[] values, int startIndex, int length, Func<char, bool> escapePredicate)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerIndexOfWithEscape(str, c => c.In(values), startIndex, endIndex, escapePredicate);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of any of the specified escapable Unicode characters in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">Unicode characters to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="escape">Specifies the Unicode character as the escape indicator. 
        /// Use two consecutive escape characters to indicate the literal value of an escape character.</para>
        /// </param>
        /// <returns>The zero-based index position of the first occurrence of any value specified in <paramref name="values"/> if it is found, or -1 if it is not.</returns>
        public static int IndexOfAnyWithEscape(this string str, char[] values, int startIndex, Func<char, bool> escapePredicate)
        {
            return _innerIndexOfWithEscape(str, c => c.In(values), startIndex, str.Length, escapePredicate);
        }
    }
}
