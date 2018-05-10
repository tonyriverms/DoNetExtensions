using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class StringEx
    {
        static int _innerLastIndexOfWithEscape(string str, Func<char, bool> predicate, int startIndex, int endIndex, Func<char, bool> escapePredicate)
        {
            var i = startIndex;
            while (i > endIndex)
            {
                char c = str[i];
                if (predicate(c))
                {
                    if (i == endIndex + 1) return i;
                    else if (i == endIndex + 2)
                    {
                        if (!escapePredicate(str[i - 1])) return i;
                        else return -1;
                    }
                    else if (escapePredicate(str[i - 1]))
                    {
                        if (str[i - 2] == str[i - 1]) return i;
                        else i -= 2;
                    }
                    else return i;
                }
                else --i;
            }
            return -1;
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of any escapable Unicode character satisfying the specified predicate. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character of the current string.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex"/> towards the beginning of the current string.</param>
        /// <param name="escape">Specifies the Unicode character as the escape indicator. 
        /// Use two consecutive escape characters to indicate the literal value of an escape character.</para>
        /// </param>
        /// <returns>The zero-based index position of the last occurrence of <paramref name="value"/> if it is found, or -1 if it is not.</returns>
        public static int LastIndexOfWithEscape(this string str, Func<char, bool> predicate, int startIndex, int length, Func<char, bool> escapePredicate)
        {
            var endIndex = ExceptionHelper.BackwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerLastIndexOfWithEscape(str, predicate, startIndex, endIndex, escapePredicate);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified escapable Unicode character in this string. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">A unicode character to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex"/>.</param>
        /// <param name="escape">Specifies the Unicode character as the escape indicator. 
        /// Use two consecutive escape characters to indicate the literal value of an escape character.</para>
        /// </param>
        /// <returns>The zero-based index position of the last occurrence of <paramref name="value"/> if it is found, or -1 if it is not.</returns>
        public static int LastIndexOfWithEscape(this string str, char value, int startIndex, int length, Func<char, bool> escapePredicate)
        {
            var endIndex = ExceptionHelper.BackwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerLastIndexOfWithEscape(str, c => c == value, startIndex, endIndex, escapePredicate);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified escapable Unicode character in this string. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">A unicode character to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="escape">Specifies the Unicode character as the escape indicator. 
        /// Use two consecutive escape characters to indicate the literal value of an escape character.
        /// </param>
        /// <returns>The zero-based index position of the last occurrence of <paramref name="value"/> if it is found, or -1 if it is not.</returns>
        public static int LastIndexOfWithEscape(this string str, char value, int startIndex, Func<char, bool> escapePredicate)
        {
            return _innerLastIndexOfWithEscape(str, c => c == value, startIndex, -1, escapePredicate);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified escapable Unicode character in this string. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">A unicode character to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="escape">Specifies the Unicode character as the escape indicator. 
        /// Use two consecutive escape characters to indicate the literal value of an escape character.
        /// </param>
        /// <returns>The zero-based index position of the last occurrence of <paramref name="value"/> if it is found, or -1 if it is not.</returns>
        public static int LastIndexOfWithEscape(this string str, char value, Func<char, bool> escapePredicate)
        {
            return _innerLastIndexOfWithEscape(str, c => c == value, str.Length - 1, -1, escapePredicate);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of any of the specified escapable Unicode characters in this string. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">Unicode characters to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" /> towards the beginning of the current string.</param>
        /// <param name="escape">Specifies the Unicode character as the escape indicator.
        /// Use two consecutive escape characters to indicate the literal value of an escape character.</param>
        /// <returns>
        /// The zero-based index position of the last occurrence of any value specified in <paramref name="values" /> if it is found, or -1 if it is not.
        /// </returns>
        public static int LastIndexOfAnyWithEscape(this string str, char[] values, int startIndex, int length, Func<char, bool> escapePredicate)
        {
            var endIndex = ExceptionHelper.BackwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerLastIndexOfWithEscape(str, c => c.In(values), startIndex, endIndex, escapePredicate);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of any of the specified escapable Unicode characters in this string. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">Unicode characters to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="escape">Specifies the Unicode character as the escape indicator.
        /// Use two consecutive escape characters to indicate the literal value of an escape character.</param>
        /// <returns>
        /// The zero-based index position of the last occurrence of any value specified in <paramref name="values" /> if it is found, or -1 if it is not.
        /// </returns>
        public static int LastIndexOfAnyWithEscape(this string str, char[] values, int startIndex, Func<char, bool> escapePredicate)
        {
            return _innerLastIndexOfWithEscape(str, c => c.In(values), startIndex, -1, escapePredicate);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of any of the specified escapable Unicode characters in this string. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">Unicode characters to seek.</param>
        /// <param name="escape">Specifies the Unicode character as the escape indicator.
        /// Use two consecutive escape characters to indicate the literal value of an escape character.</param>
        /// <returns>
        /// The zero-based index position of the last occurrence of any value specified in <paramref name="values" /> if it is found, or -1 if it is not.
        /// </returns>
        public static int LastIndexOfAnyWithEscape(this string str, char[] values, Func<char, bool> escapePredicate)
        {
            return _innerLastIndexOfWithEscape(str, c => c.In(values), str.Length - 1, -1, escapePredicate);
        }
    }
}
