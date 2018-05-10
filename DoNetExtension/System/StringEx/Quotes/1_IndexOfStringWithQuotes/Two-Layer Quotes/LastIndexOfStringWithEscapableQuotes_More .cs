using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class StringEx
    {
        #region With StartIndex

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified <paramref name="value" /> outside quotes in this string. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="value">The substring to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search of <paramref name="value" />.</param>
        /// <returns>
        /// The zero-based index position of the last occurrence of <paramref name="value" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is quote mismatch in the string instance.</exception>
        public static int LastIndexOfWithQuotes(this string str, string value, int startIndex, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, StringComparison comparisonType = StringComparison.Ordinal)
        {
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, str.Length - 1, true);
            return _innerLastIndexOfWithQuotes(str, value, startIndex, -1, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, comparisonType);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified <paramref name="value" /> outside quotes in this string. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="value">The substring to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search of <paramref name="value" />.</param>
        /// <returns>
        /// The zero-based index position of the last occurrence of <paramref name="value" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is quote mismatch in the string instance.</exception>
        public static int LastIndexOfWithQuotes(this string str, string value, int startIndex, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, StringComparison comparisonType = StringComparison.Ordinal)
        {
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, str.Length - 1, true);
            return _innerLastIndexOfWithQuotes(str, value, startIndex, -1, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, comparisonType);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified <paramref name="value" /> outside quotes in this string. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="value">The substring to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuote" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuote" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search of <paramref name="value" />.</param>
        /// <returns>
        /// The zero-based index position of the last occurrence of <paramref name="value" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is quote mismatch in the string instance.</exception>
        public static int LastIndexOfWithQuotes(this string str, string value, int startIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, StringComparison comparisonType = StringComparison.Ordinal)
        {
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, str.Length - 1, true);
            return _innerLastIndexOfWithQuotes(str, value, startIndex, -1, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, comparisonType);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified <paramref name="value" /> outside quotes in this string. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="value">The substring to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuote" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuote" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search of <paramref name="value" />.</param>
        /// <returns>
        /// The zero-based index position of the last occurrence of <paramref name="value" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is quote mismatch in the string instance.</exception>
        public static int LastIndexOfWithQuotes(this string str, string value, int startIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes,
            StringComparison comparisonType = StringComparison.Ordinal)
        {
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, str.Length - 1, true);
            return _innerLastIndexOfWithQuotes(str, value, startIndex, -1, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, comparisonType);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of any of the specified <paramref name="values"/> outside quotes in this string. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The substrings to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search of <paramref name="values" />.</param>
        /// <returns>
        /// A <see cref="System.StringSearchResult"/> object that stores the zero-based index position of the last occurrence of any of the specified <paramref name="values"/> if one is found outside quotes, or <c>null</c> if none is found.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is quote mismatch in the string instance.</exception>
        public static StringSearchResult LastIndexOfAnyWithQuotes(this string str, string[] values, int startIndex, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, StringComparison comparisonType = StringComparison.Ordinal)
        {
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, str.Length - 1, true);
            return _innerLastIndexOfWithQuotes(str, values, startIndex, -1, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, comparisonType);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of any of the specified <paramref name="values"/> outside quotes in this string. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The substrings to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuote" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuote" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search of <paramref name="values" />.</param>
        /// <returns>
        /// A <see cref="System.StringSearchResult"/> object that stores the zero-based index position of the last occurrence of any of the specified <paramref name="values"/> if one is found outside quotes, or <c>null</c> if none is found.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is quote mismatch in the string instance.</exception>
        public static StringSearchResult LastIndexOfAnyWithQuotes(this string str, string[] values, int startIndex, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, StringComparison comparisonType = StringComparison.Ordinal)
        {
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, str.Length - 1, true);
            return _innerLastIndexOfWithQuotes(str, values, startIndex, -1, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, comparisonType);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of any of the specified <paramref name="values"/> outside quotes in this string. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The substrings to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="primaryLeftQuotes">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuotes">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search of <paramref name="values" />.</param>
        /// <returns>
        /// A <see cref="System.StringSearchResult"/> object that stores the zero-based index position of the last occurrence of any of the specified <paramref name="values"/> if one is found outside quotes, or <c>null</c> if none is found.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is quote mismatch in the string instance.</exception>
        public static StringSearchResult LastIndexOfAnyWithQuotes(this string str, string[] values, int startIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, StringComparison comparisonType = StringComparison.Ordinal)
        {
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, str.Length - 1, true);
            return _innerLastIndexOfWithQuotes(str, values, startIndex, -1, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, comparisonType);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of any of the specified <paramref name="values"/> outside quotes in this string. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The substrings to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuote" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuote" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search of <paramref name="values" />.</param>
        /// <returns>
        /// A <see cref="System.StringSearchResult"/> object that stores the zero-based index position of the last occurrence of any of the specified <paramref name="values"/> if one is found outside quotes, or <c>null</c> if none is found.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is quote mismatch in the string instance.</exception>
        public static StringSearchResult LastIndexOfAnyWithQuotes(this string str, string[] values, int startIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, StringComparison comparisonType = StringComparison.Ordinal)
        {
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, str.Length - 1, true);
            return _innerLastIndexOfWithQuotes(str, values, startIndex, -1, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, comparisonType);
        }

        #endregion

        #region Without StartIndex

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified <paramref name="value" /> outside quotes in this string. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="value">The substring to seek.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search of <paramref name="value" />.</param>
        /// <returns>
        /// The zero-based index position of the last occurrence of <paramref name="value" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is quote mismatch in the string instance.</exception>
        public static int LastIndexOfWithQuotes(this string str, string value, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, StringComparison comparisonType = StringComparison.Ordinal)
        {
            return _innerLastIndexOfWithQuotes(str, value, str.Length - 1, -1, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, comparisonType);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified <paramref name="value" /> outside quotes in this string. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="value">The substring to seek.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search of <paramref name="value" />.</param>
        /// <returns>
        /// The zero-based index position of the last occurrence of <paramref name="value" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is quote mismatch in the string instance.</exception>
        public static int LastIndexOfWithQuotes(this string str, string value, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, StringComparison comparisonType = StringComparison.Ordinal)
        {
            return _innerLastIndexOfWithQuotes(str, value, str.Length - 1, -1, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, comparisonType);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified <paramref name="value" /> outside quotes in this string. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="value">The substring to seek.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuote" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuote" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search of <paramref name="value" />.</param>
        /// <returns>
        /// The zero-based index position of the last occurrence of <paramref name="value" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is quote mismatch in the string instance.</exception>
        public static int LastIndexOfWithQuotes(this string str, string value, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, StringComparison comparisonType = StringComparison.Ordinal)
        {
            return _innerLastIndexOfWithQuotes(str, value, str.Length - 1, -1, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, comparisonType);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified <paramref name="value" /> outside quotes in this string. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="value">The substring to seek.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuote" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuote" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search of <paramref name="value" />.</param>
        /// <returns>
        /// The zero-based index position of the last occurrence of <paramref name="value" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is quote mismatch in the string instance.</exception>
        public static int LastIndexOfWithQuotes(this string str, string value, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes,
            StringComparison comparisonType = StringComparison.Ordinal)
        {
            return _innerLastIndexOfWithQuotes(str, value, str.Length - 1, -1, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, comparisonType);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of any of the specified <paramref name="values"/> outside quotes in this string. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The substrings to seek.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search of <paramref name="values" />.</param>
        /// <returns>
        /// A <see cref="System.StringSearchResult"/> object that stores the zero-based index position of the last occurrence of any of the specified <paramref name="values"/> if one is found outside quotes, or <c>null</c> if none is found.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is quote mismatch in the string instance.</exception>
        public static StringSearchResult LastIndexOfAnyWithQuotes(this string str, string[] values, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, StringComparison comparisonType = StringComparison.Ordinal)
        {
            return _innerLastIndexOfWithQuotes(str, values, str.Length - 1, -1, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, comparisonType);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of any of the specified <paramref name="values"/> outside quotes in this string. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The substrings to seek.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuote" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuote" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search of <paramref name="values" />.</param>
        /// <returns>
        /// A <see cref="System.StringSearchResult"/> object that stores the zero-based index position of the last occurrence of any of the specified <paramref name="values"/> if one is found outside quotes, or <c>null</c> if none is found.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is quote mismatch in the string instance.</exception>
        public static StringSearchResult LastIndexOfAnyWithQuotes(this string str, string[] values, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, StringComparison comparisonType = StringComparison.Ordinal)
        {
            return _innerLastIndexOfWithQuotes(str, values, str.Length - 1, -1, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, comparisonType);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of any of the specified <paramref name="values"/> outside quotes in this string. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The substrings to seek.</param>
        /// <param name="primaryLeftQuotes">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuotes">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search of <paramref name="values" />.</param>
        /// <returns>
        /// A <see cref="System.StringSearchResult"/> object that stores the zero-based index position of the last occurrence of any of the specified <paramref name="values"/> if one is found outside quotes, or <c>null</c> if none is found.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is quote mismatch in the string instance.</exception>
        public static StringSearchResult LastIndexOfAnyWithQuotes(this string str, string[] values, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, StringComparison comparisonType = StringComparison.Ordinal)
        {
            return _innerLastIndexOfWithQuotes(str, values, str.Length - 1, -1, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, comparisonType);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of any of the specified <paramref name="values"/> outside quotes in this string. The search starts from <pararef name="startIndex" /> and advances towards the beginning of the current string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The substrings to seek.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuote" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuote" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search of <paramref name="values" />.</param>
        /// <returns>
        /// A <see cref="System.StringSearchResult"/> object that stores the zero-based index position of the last occurrence of any of the specified <paramref name="values"/> if one is found outside quotes, or <c>null</c> if none is found.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is quote mismatch in the string instance.</exception>
        public static StringSearchResult LastIndexOfAnyWithQuotes(this string str, string[] values, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, StringComparison comparisonType = StringComparison.Ordinal)
        {
            return _innerLastIndexOfWithQuotes(str, values, str.Length - 1, -1, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, comparisonType);
        }

        #endregion
    }
}
