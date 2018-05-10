namespace System
{
    public static partial class StringEx
    {
        #region Predicate

        /// <summary>
        /// Reports the zero-based index of the last occurrence of a Unicode character outside quotes and satisfying the specified predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character outside quotes of the current string.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for characters satisfying <paramref name="predicate" /> starts. The search starts at this specified position and advances towards the beginning of the string.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the last Unicode character outside quotes and satisfying the specified predicate, or -1 if no such character is not.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static int LastIndexOfWithQuotes(this string str, Func<char, bool> predicate, int startIndex, int length, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote)
        {
            var endIndex = ExceptionHelper.BackwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerLastIndexOfWithQuotes(str, predicate, startIndex, endIndex, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of a Unicode character outside quotes and satisfying the specified predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character outside quotes of the current string.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for characters satisfying <paramref name="predicate" /> starts. The search starts at this specified position and advances towards the beginning of the string.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="primaryLeftQuote">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuote" />.</param>
        /// <param name="primaryRightQuote">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuote" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the last Unicode character outside quotes and satisfying the specified predicate, or -1 if no such character is not.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static int LastIndexOfWithQuotes(this string str, Func<char, bool> predicate, int startIndex, int length, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote)
        {
            var endIndex = ExceptionHelper.BackwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerLastIndexOfWithQuotes(str, predicate, startIndex, endIndex, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified Unicode character outside quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character outside quotes of the current string.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for characters satisfying <paramref name="predicate" /> starts. The search starts at this specified position and advances towards the beginning of the string.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the last Unicode character outside quotes and satisfying the specified predicate, or -1 if no such character is not.
        /// </returns>
        public static int LastIndexOfWithQuotes(this string str, Func<char, bool> predicate, int startIndex, int length, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            var endIndex = ExceptionHelper.BackwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerLastIndexOfWithQuotes(str, predicate, startIndex, endIndex, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified Unicode character outside quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character outside quotes of the current string.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for characters satisfying <paramref name="predicate" /> starts. The search starts at this specified position and advances towards the beginning of the string.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="primaryLeftQuote">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuote" />.</param>
        /// <param name="primaryRightQuote">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuote" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the last Unicode character outside quotes and satisfying the specified predicate, or -1 if no such character is not.
        /// </returns>
        public static int LastIndexOfWithQuotes(this string str, Func<char, bool> predicate, int startIndex, int length, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            var endIndex = ExceptionHelper.BackwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerLastIndexOfWithQuotes(str, predicate, startIndex, endIndex, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes);
        }

        #endregion

        #region Single Char

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified Unicode character outside escapable quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="value">The Unicode character to seek.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for <paramref name="value" /> starts. The search starts at this specified position and advances towards the beginning of the string.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the last occurrence of <paramref name="value" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static int LastIndexOfWithQuotes(this string str, char value, int startIndex, int length, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote)
        {
            var endIndex = ExceptionHelper.BackwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerLastIndexOfWithQuotes(str, value, startIndex, endIndex, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified Unicode character outside escapable quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="value">The Unicode character to seek.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for <paramref name="value" /> starts. The search starts at this specified position and advances towards the beginning of the string.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="primaryLeftQuote">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuote" />.</param>
        /// <param name="primaryRightQuote">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuote" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the last occurrence of <paramref name="value" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static int LastIndexOfWithQuotes(this string str, char value, int startIndex, int length, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote)
        {
            var endIndex = ExceptionHelper.BackwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerLastIndexOfWithQuotes(str, value, startIndex, endIndex, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified Unicode character outside escapable quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="value">The Unicode character to seek.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for <paramref name="value" /> starts. The search starts at this specified position and advances towards the beginning of the string.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the last occurrence of <paramref name="value" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        public static int LastIndexOfWithQuotes(this string str, char value, int startIndex, int length, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            var endIndex = ExceptionHelper.BackwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerLastIndexOfWithQuotes(str, value, startIndex, endIndex, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified Unicode character outside escapable quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="value">The Unicode character to seek.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for <paramref name="value" /> starts. The search starts at this specified position and advances towards the beginning of the string.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuote" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuote" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the last occurrence of <paramref name="value" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        public static int LastIndexOfWithQuotes(this string str, char value, int startIndex, int length, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            var endIndex = ExceptionHelper.BackwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerLastIndexOfWithQuotes(str, value, startIndex, endIndex, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes);
        }

        #endregion

        #region Multiple Chars

        /// <summary>
        /// Reports the zero-based index of the last occurrence of any of the specified Unicode characters outside escapable quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The Unicode characters to seek.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for <paramref name="values" /> starts. The search starts at this specified position and advances towards the beginning of the string.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the last occurrence of any value specified in <paramref name="values" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static int LastIndexOfAnyWithQuotes(this string str, char[] values, int startIndex, int length, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote)
        {
            var endIndex = ExceptionHelper.BackwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerLastIndexOfWithQuotes(str, values, startIndex, endIndex, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of any of the specified Unicode characters outside escapable quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The Unicode characters to seek.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for <paramref name="values" /> starts. The search starts at this specified position and advances towards the beginning of the string.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuote" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuote" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the last occurrence of any value specified in <paramref name="values" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static int LastIndexOfAnyWithQuotes(this string str, char[] values, int startIndex, int length, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote)
        {
            var endIndex = ExceptionHelper.BackwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerLastIndexOfWithQuotes(str, values, startIndex, endIndex, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of any of the specified Unicode characters outside escapable quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The Unicode characters to seek.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for <paramref name="values" /> starts. The search starts at this specified position and advances towards the beginning of the string.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the last occurrence of any value specified in <paramref name="values" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        public static int LastIndexOfAnyWithQuotes(this string str, char[] values, int startIndex, int length, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            var endIndex = ExceptionHelper.BackwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerLastIndexOfWithQuotes(str, values, startIndex, endIndex, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of any of the specified Unicode characters outside escapable quotes in this string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="values">The Unicode characters to seek.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for <paramref name="values" /> starts. The search starts at this specified position and advances towards the beginning of the string.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuote" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuote" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <returns>
        /// The zero-based index position of the last occurrence of any value specified in <paramref name="values" /> if it is found outside quotes, or -1 if it is not.
        /// </returns>
        public static int LastIndexOfAnyWithQuotes(this string str, char[] values, int startIndex, int length, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            var endIndex = ExceptionHelper.BackwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerLastIndexOfWithQuotes(str, values, startIndex, endIndex, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes);
        }

        #endregion
    }
}
