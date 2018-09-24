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
        /// Reports the zero-based index of the next character which matches another specified character. Those matched characters are usually brackets, such as '(' and ')', '[' and ']', '{' and '}'.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="leftChar">The character that matches the character to search, typically a left bracket, such as '(', '[' or '{', or quotes, such as '"', '''.</param>
        /// <param name="rightChar">The character to search, typically a right bracket, such as ')', ']' or '}', or quotes, such as '"', '''.</param>
        /// <param name="startIndex">The search starting position. NOTE that this position should be right at the <paramref name="leftChar"/> you want to find a match for. For example, if it is intended to find a match of the first left square bracket at position 0 in string "[abc[de]fgh]", the <paramref name="startIndex" /> should be 0.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <returns>
        /// The zero-based index position of <paramref name="rightChar" /> if that character is found and it matches <paramref name="leftChar" />, or -1 if it is not.
        /// </returns>
        public static int IndexOfNextMatch(this string str, char leftChar, char rightChar, int startIndex, int length)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            _searchRightQuote(str, ref startIndex, endIndex, leftChar, rightChar);
            return startIndex;
        }

        /// <summary>
        /// Reports the zero-based index of the next character which matches another specified character outside quotes. 
        /// Those matched characters are usually brackets, such as '(' and ')', '[' and ']', '{' and '}'.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="leftChar">The character that matches the character to search, typically a left bracket, such as '(', '[' or '{'.</param>
        /// <param name="rightChar">The next character to search, typically a right bracket, such as ')', ']' or '}'.</param>
        /// <param name="leftQuote">
        /// Specifies the left quote.
        /// Any character inside quotes (<paramref name="leftQuote"/> and <paramref name="rightQuote"/>) will not be considered as a match.</param>
        /// <param name="rightQuote">
        /// Specifies the right quote.
        /// Any character inside quotes (<paramref name="leftQuote"/> and <paramref name="rightQuote"/>) will not be considered as a match.
        /// </param>
        /// <param name="startIndex">The search starting position. NOTE that this position should be right at the <paramref name="leftChar"/> you want to find a match for. For example, if it is intended to find a match of the first left square bracket at position 0 in string "[abc[de]fgh]", the <paramref name="startIndex" /> should be 0.</param>
        /// <returns>
        /// The zero-based index position of <paramref name="rightChar" /> if that character is found and it matches <paramref name="leftChar" />, or -1 if it is not.
        /// </returns>
        public static int IndexOfNextMatch(this string str, char leftChar, char rightChar, char leftQuote, char rightQuote, int startIndex, int length)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            _searchRightQuote(str, ref startIndex, endIndex, leftChar, rightChar, leftQuote.Singleton(), rightQuote.Singleton());
            return startIndex;
        }

        /// <summary>
        /// Reports the zero-based index of the next character which matches another specified character outside quotes. 
        /// Those matched characters are usually brackets, such as '(' and ')', '[' and ']', '{' and '}'.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="leftChar">The character that matches the character to search, typically a left bracket, such as '(', '[' or '{'.</param>
        /// <param name="rightChar">The next character to search, typically a right bracket, such as ')', ']' or '}'.</param>
        /// <param name="leftQuotes">
        /// Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// Any character that appears between a left quote and its corresponding right quote will not be considered a match.
        /// </param>
        /// <param name="rightQuotes">
        /// Specifies an array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// Any character that appears between a left quote and its corresponding right quote will not be considered a match.
        /// </param>
        /// <param name="startIndex">The search starting position. NOTE that this position should be right at the <paramref name="leftChar"/> you want to find a match for. For example, if it is intended to find a match of the first left square bracket at position 0 in string "[abc[de]fgh]", the <paramref name="startIndex" /> should be 0.</param>
        /// <param name="length">The number of characters to search. The parameter determines the search ending position along with <paramref name="startIndex" />.</param>
        /// <returns>
        /// The zero-based index position of <paramref name="rightChar" /> if that character is found and it matches <paramref name="leftChar" />, or -1 if it is not.
        /// </returns>
        public static int IndexOfNextMatch(this string str, char leftChar, char rightChar, char[] leftQuotes, char[] rightQuotes, int startIndex, int length)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            _searchRightQuote(str, ref startIndex, endIndex, leftChar, rightChar, leftQuotes, rightQuotes);
            return startIndex;
        }

        /// <summary>
        /// Reports the zero-based index of the next character which matches another specified character. The method supports classic escaping.
        /// Those matched characters are usually brackets, such as '(' and ')', '[' and ']', '{' and '}'.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="leftChar">The character that matches the character to search, typically a left bracket, such as '(', '[' or '{'.</param>
        /// <param name="rightChar">The next character to search, typically a right bracket, such as ')', ']' or '}'.</param>
        /// <param name="escape">The character that escapes the <paramref name="rightChar"/>, typically '\'. For example, suppose '\' is used for escaping, then the match for the first left square bracket in string "[abc\]abc]" is the last right square bracket, not the one in the middle because the '\' that precedes it escapes it.</param>
        /// <param name="startIndex">The search starting position. NOTE that this position should be right at the <paramref name="leftChar"/> you want to find a match for. For example, if it is intended to find a match of the first left square bracket at position 0 in string "[abc[de]fgh]", the <paramref name="startIndex" /> should be 0.</param>
        /// <param name="length">The number of characters to search. The parameter determines the search ending position along with <paramref name="startIndex" />.</param>
        /// <returns>
        /// The zero-based index position of <paramref name="rightChar" /> if that character is found and it matches <paramref name="leftChar" />, or -1 if it is not.
        /// </returns>
        public static int IndexOfNextMatch(this string str, char leftChar, char rightChar, char escape, int startIndex, int length)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            _searchRightQuote(str, ref startIndex, endIndex, leftChar, rightChar, escape.Singleton());
            return startIndex;
        }

        /// <summary>
        /// Reports the zero-based index of the next character which matches another specified character. The method supports classic escaping.
        /// Those matched characters are usually brackets, such as '(' and ')', '[' and ']', '{' and '}'.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="leftChar">The character that matches the character to search, typically a left bracket, such as '(', '[' or '{'.</param>
        /// <param name="rightChar">The next character to search, typically a right bracket, such as ')', ']' or '}'.</param>
        /// <param name="escapes">The characters that escape the <paramref name="rightChar" />, typically '\'. For example, suppose '\', '#' are used for escaping, then the match for the first left square bracket in string "[abc\]#]abc]" is the last right square bracket, not the two in the middle because the '\' and '#' that precede them escapes them respectively.</param>
        /// <param name="startIndex">The search starting position. NOTE that this position should be right at the <paramref name="leftChar"/> you want to find a match for. For example, if it is intended to find a match of the first left square bracket at position 0 in string "[abc[de]fgh]", the <paramref name="startIndex" /> should be 0.</param>
        /// <param name="length">The number of characters to search. The parameter determines the search ending position along with <paramref name="startIndex" />.</param>
        /// <returns>
        /// The zero-based index position of <paramref name="rightChar" /> if that character is found and it matches <paramref name="leftChar" />, or -1 if it is not.
        /// </returns>
        public static int IndexOfNextMatch(this string str, char leftChar, char rightChar, char[] escapes, int startIndex, int length)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            _searchRightQuote(str, ref startIndex, endIndex, leftChar, rightChar, escapes);
            return startIndex;
        }
    }
}
