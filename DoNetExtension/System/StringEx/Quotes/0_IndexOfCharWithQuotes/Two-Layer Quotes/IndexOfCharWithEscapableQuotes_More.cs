﻿namespace System
{
    public static partial class StringEx
    {
        #region Predicate

        /// <summary>
        /// Reports the zero-based index of the first occurrence of a Unicode character outside quotes and satisfying the specified predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character outside quotes of the current string.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for characters satisfying <paramref name="predicate" /> starts.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the first Unicode character outside quotes and satisfying the specified predicate, or -1 if no such character is not.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static int IndexOfWithQuotes(this string str, Func<char, bool> predicate, int startIndex, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote)
        {
            var strLen = str.Length;
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, strLen - 1, true);
            return _innerIndexOfWithQuotes(str, predicate, startIndex, strLen, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of a Unicode character outside quotes and satisfying the specified predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character outside quotes of the current string.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the first Unicode character outside quotes and satisfying the specified predicate, or -1 if no such character is not.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static int IndexOfWithQuotes(this string str, Func<char, bool> predicate, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote)
        {
            return _innerIndexOfWithQuotes(str, predicate, 0, str.Length, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of a Unicode character outside quotes and satisfying the specified predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character outside quotes of the current string.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for characters satisfying <paramref name="predicate" /> starts.</param>
        /// <param name="primaryLeftQuote">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuote" />.</param>
        /// <param name="primaryRightQuote">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuote" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the first Unicode character outside quotes and satisfying the specified predicate, or -1 if no such character is not.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static int IndexOfWithQuotes(this string str, Func<char, bool> predicate, int startIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote)
        {
            var strLen = str.Length;
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, strLen - 1, true);
            return _innerIndexOfWithQuotes(str, predicate, startIndex, strLen, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of a Unicode character outside quotes and satisfying the specified predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character outside quotes of the current string.</param>
        /// <param name="primaryLeftQuote">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuote" />.</param>
        /// <param name="primaryRightQuote">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuote" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the first Unicode character outside quotes and satisfying the specified predicate, or -1 if no such character is not.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static int IndexOfWithQuotes(this string str, Func<char, bool> predicate, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote)
        {
            return _innerIndexOfWithQuotes(str, predicate, 0, str.Length, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified Unicode character outside quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character outside quotes of the current string.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the first Unicode character outside quotes and satisfying the specified predicate, or -1 if no such character is not.
        /// </returns>
        public static int IndexOfWithQuotes(this string str, Func<char, bool> predicate, int startIndex, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            var strLen = str.Length;
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, strLen - 1, true);
            return _innerIndexOfWithQuotes(str, predicate, startIndex, strLen, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified Unicode character outside quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character outside quotes of the current string.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the first Unicode character outside quotes and satisfying the specified predicate, or -1 if no such character is not.
        /// </returns>
        public static int IndexOfWithQuotes(this string str, Func<char, bool> predicate, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            return _innerIndexOfWithQuotes(str, predicate, 0, str.Length, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified Unicode character outside quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character outside quotes of the current string.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="primaryLeftQuote">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuote" />.</param>
        /// <param name="primaryRightQuote">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuote" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the first Unicode character outside quotes and satisfying the specified predicate, or -1 if no such character is not.
        /// </returns>
        public static int IndexOfWithQuotes(this string str, Func<char, bool> predicate, int startIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            var strLen = str.Length;
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, strLen - 1, true);
            return _innerIndexOfWithQuotes(str, predicate, startIndex, strLen, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified Unicode character outside quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character outside quotes of the current string.</param>
        /// <param name="primaryLeftQuote">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuote" />.</param>
        /// <param name="primaryRightQuote">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuote" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the first Unicode character outside quotes and satisfying the specified predicate, or -1 if no such character is not.
        /// </returns>
        public static int IndexOfWithQuotes(this string str, Func<char, bool> predicate, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            return _innerIndexOfWithQuotes(str, predicate, 0, str.Length, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes);
        }

        #endregion

        #region Single Char

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified Unicode character outside escapable quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="value">The Unicode character to seek.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for characters satisfying <paramref name="predicate" /> starts.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the first occurrence of <paramref name="value" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static int IndexOfWithQuotes(this string str, char value, int startIndex, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote)
        {
            var strLen = str.Length;
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, strLen - 1, true);
            return _innerIndexOfWithQuotes(str, value, startIndex, strLen, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified Unicode character outside escapable quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="value">The Unicode character to seek.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the first occurrence of <paramref name="value" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static int IndexOfWithQuotes(this string str, char value, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote)
        {
            return _innerIndexOfWithQuotes(str, value, 0, str.Length, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified Unicode character outside escapable quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="value">The Unicode character to seek.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for characters satisfying <paramref name="predicate" /> starts.</param>
        /// <param name="primaryLeftQuote">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuote" />.</param>
        /// <param name="primaryRightQuote">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuote" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the first occurrence of <paramref name="value" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static int IndexOfWithQuotes(this string str, char value, int startIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote)
        {
            var strLen = str.Length;
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, strLen - 1, true);
            return _innerIndexOfWithQuotes(str, value, startIndex, strLen, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified Unicode character outside escapable quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="value">The Unicode character to seek.</param>
        /// <param name="primaryLeftQuote">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuote" />.</param>
        /// <param name="primaryRightQuote">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuote" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the first occurrence of <paramref name="value" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static int IndexOfWithQuotes(this string str, char value, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote)
        {
            return _innerIndexOfWithQuotes(str, value, 0, str.Length, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified Unicode character outside escapable quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="value">The Unicode character to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the first occurrence of <paramref name="value" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        public static int IndexOfWithQuotes(this string str, char value, int startIndex, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            var strLen = str.Length;
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, strLen - 1, true);
            return _innerIndexOfWithQuotes(str, value, startIndex, strLen, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified Unicode character outside escapable quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="value">The Unicode character to seek.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the first occurrence of <paramref name="value" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        public static int IndexOfWithQuotes(this string str, char value, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            return _innerIndexOfWithQuotes(str, value, 0, str.Length, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified Unicode character outside escapable quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="value">The Unicode character to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuote" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuote" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the first occurrence of <paramref name="value" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        public static int IndexOfWithQuotes(this string str, char value, int startIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            var strLen = str.Length;
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, strLen - 1, true);
            return _innerIndexOfWithQuotes(str, value, startIndex, strLen, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes);
        }


        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified Unicode character outside escapable quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="value">The Unicode character to seek.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuote" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuote" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the first occurrence of <paramref name="value" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        public static int IndexOfWithQuotes(this string str, char value, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            return _innerIndexOfWithQuotes(str, value, 0, str.Length, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes);
        }

        #endregion

        #region Multiple Chars

        /// <summary>
        /// Reports the zero-based index of the first occurrence of any of the specified Unicode characters outside escapable quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The Unicode characters to seek.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for characters satisfying <paramref name="predicate" /> starts.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the first occurrence of any value specified in <paramref name="values" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static int IndexOfAnyWithQuotes(this string str, char[] values, int startIndex, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote)
        {
            var strLen = str.Length;
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, strLen - 1, true);
            return _innerIndexOfWithQuotes(str, values, startIndex, strLen, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of any of the specified Unicode characters outside escapable quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The Unicode characters to seek.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the first occurrence of any value specified in <paramref name="values" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static int IndexOfAnyWithQuotes(this string str, char[] values, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote)
        {
            return _innerIndexOfWithQuotes(str, values, 0, str.Length, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of any of the specified Unicode characters outside escapable quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The Unicode characters to seek.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for characters satisfying <paramref name="predicate" /> starts.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuote" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuote" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the first occurrence of any value specified in <paramref name="values" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static int IndexOfAnyWithQuotes(this string str, char[] values, int startIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote)
        {
            var strLen = str.Length;
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, strLen - 1, true);
            return _innerIndexOfWithQuotes(str, values, startIndex, strLen, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of any of the specified Unicode characters outside escapable quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The Unicode characters to seek.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuote" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuote" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the first occurrence of any value specified in <paramref name="values" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static int IndexOfAnyWithQuotes(this string str, char[] values, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote)
        {
            return _innerIndexOfWithQuotes(str, values, 0, str.Length, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of any of the specified Unicode characters outside escapable quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The Unicode characters to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the first occurrence of any value specified in <paramref name="values" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        public static int IndexOfAnyWithQuotes(this string str, char[] values, int startIndex, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            var strLen = str.Length;
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, strLen - 1, true);
            return _innerIndexOfWithQuotes(str, values, startIndex, strLen, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of any of the specified Unicode characters outside escapable quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The Unicode characters to seek.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the first occurrence of any value specified in <paramref name="values" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        public static int IndexOfAnyWithQuotes(this string str, char[] values, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            return _innerIndexOfWithQuotes(str, values, 0, str.Length, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of any of the specified Unicode characters outside escapable quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The Unicode characters to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuote" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuote" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the first occurrence of any value specified in <paramref name="values" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        public static int IndexOfAnyWithQuotes(this string str, char[] values, int startIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            var strLen = str.Length;
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, strLen - 1, true);
            return _innerIndexOfWithQuotes(str, values, startIndex, strLen, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of any of the specified Unicode characters outside escapable quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The Unicode characters to seek.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuote" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuote" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the first occurrence of any value specified in <paramref name="values" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        public static int IndexOfAnyWithQuotes(this string str, char[] values, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            return _innerIndexOfWithQuotes(str, values, 0, str.Length, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes);
        }

        #endregion
    }
}
