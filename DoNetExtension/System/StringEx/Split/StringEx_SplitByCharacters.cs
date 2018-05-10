using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System_Extension_Library.System;
using System_Extension_Library.System.StringEx;

namespace System
{
    public static partial class StringEx
    {
        #region Common

        /// <summary>
        /// Returns a string array that contains the substrings in this string (or a part of this string according to <paramref name="startIndex"/> and <paramref name="length"/>) that are delimited by characters satisfying the specified predicate.
        /// Additional options, such as string trimming, or separator keep, are available.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character of the current string. Any character satisfying this preidcate will be used as a separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An array containing substrings of this string (or a part of this string) that are delimited by characters satisfying <paramref name="predicate" />.
        /// </returns>
        public static string[] Split(this string str, Func<char, bool> predicate, int startIndex, int length, bool removeEmptyEntries = false, bool trim = false, bool keepSeparator = false)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return new _innerSplitEnumerator01(str, predicate, startIndex, endIndex, removeEmptyEntries, trim, keepSeparator).ToArray();
        }

        /// <summary>
        /// Returns a string array that contains the substrings in this string (or a part of this string according to <paramref name="startIndex"/>) that are delimited by characters satisfying the specified predicate.
        /// Additional options, such as string trimming, or separator keep, are available.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character of the current string. Any character satisfying this preidcate will be used as a separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An array containing substrings of this string (or part of this string) that are delimited by characters satisfying <paramref name="predicate" />.
        /// </returns>
        public static string[] Split(this string str, Func<char, bool> predicate, int startIndex, bool removeEmptyEntries = false, bool trim = false, bool keepSeparator = false)
        {
            ExceptionHelper.NonNegativeArgumentRequired("startIndex", startIndex);
            return new _innerSplitEnumerator01(str, predicate, startIndex, str.Length, removeEmptyEntries, trim, keepSeparator).ToArray();
        }

        /// <summary>
        /// Returns a string array that contains the substrings in this string that are delimited by characters satisfying the specified predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character of the current string. Any character satisfying this preidcate will be used as a separator.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An array containing substrings of this string that are delimited by characters satisfying <paramref name="predicate" />.
        /// </returns>
        public static string[] Split(this string str, Func<char, bool> predicate, bool removeEmptyEntries = false, bool trim = false, bool keepSeparator = false)
        {
            return new _innerSplitEnumerator01(str, predicate, 0, str.Length, removeEmptyEntries, trim, keepSeparator).ToArray();
        }

        /// <summary>
        /// Returns substrings of this string (or a part of this string according to <paramref name="startIndex"/> and <paramref name="length"/>) delimited by specified Unicode character.
        /// Additional options, such as string trimming, or separator keep, are available.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separator">A Unicode characters that delimits the substrings in the current string instance.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings should be trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An array containing substrings of this string (or part of this string) that are delimited by the specified separator.
        /// </returns>
        public static string[] Split(this string str, char separator, int startIndex, int length, bool removeEmptyEntries = false, bool trim = false, bool keepSeparator = false)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return new _innerSplitEnumerator02(str, separator, startIndex, endIndex, removeEmptyEntries, trim, keepSeparator).ToArray();
        }

        /// <summary>
        /// Returns substrings of this string (or a part of this string according to <paramref name="startIndex"/>) delimited by specified Unicode character.
        /// Additional options, such as string trimming, or separator keep, are available.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separator">A Unicode characters that delimits the substrings in the current string instance.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings should be trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An array containing substrings of this string (or part of this string) that are delimited by the specified separator.
        /// </returns>
        public static string[] Split(this string str, char separator, int startIndex, bool removeEmptyEntries = false, bool trim = false, bool keepSeparator = false)
        {
            ExceptionHelper.NonNegativeArgumentRequired("startIndex", startIndex);
            return new _innerSplitEnumerator02(str, separator, startIndex, str.Length, removeEmptyEntries, trim, keepSeparator).ToArray();
        }

        /// <summary>
        /// Returns substrings of this string delimited by specified Unicode character.
        /// Additional options, such as string trimming, or separator keep, are available.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separator">A Unicode characters that delimits the substrings in the current string instance.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings should be trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An array containing substrings of this string that are delimited by the specified separator.
        /// </returns>
        public static string[] Split(this string str, char separator, bool removeEmptyEntries = false, bool trim = false, bool keepSeparator = false)
        {
            return new _innerSplitEnumerator02(str, separator, 0, str.Length, removeEmptyEntries, trim, keepSeparator).ToArray();
        }

        /// <summary>
        /// Returns substrings of this string (or a part of this string according to <paramref name="startIndex"/> and <paramref name="length"/>) delimited by specified Unicode characters.
        /// Additional options, such as string trimming, or separator keep, are available.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separators">A non-empty array of Unicode characters that delimit the substrings in the current string instance.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings should be trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An array containing substrings of this string (or part of this string) that are delimited by the specified separators.
        /// </returns>
        public static string[] Split(this string str, char[] separators, int startIndex, int length, bool removeEmptyEntries = false, bool trim = false, bool keepSeparator = false)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return new _innerSplitEnumerator03(str, separators, startIndex, length, removeEmptyEntries, trim, keepSeparator).ToArray();
        }

        /// <summary>
        /// Returns substrings of this string (or a part of this string according to <paramref name="startIndex"/>) delimited by specified Unicode characters.
        /// Additional options, such as string trimming, or separator keep, are available.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separators">A non-empty array of Unicode characters that delimit the substrings in the current string instance.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings should be trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An array containing substrings of this string (or part of this string) that are delimited by the specified separators.
        /// </returns>
        public static string[] Split(this string str, char[] separators, int startIndex, bool removeEmptyEntries = false, bool trim = false, bool keepSeparator = false)
        {
            ExceptionHelper.NonNegativeArgumentRequired("startIndex", startIndex);
            return new _innerSplitEnumerator03(str, separators, startIndex, str.Length, removeEmptyEntries, trim, keepSeparator).ToArray();
        }

        /// <summary>
        /// Returns substrings of this string delimited by specified Unicode characters. Additional options, such as string trimming, or separator keep, are available.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separators">A non-empty array of Unicode characters that delimit the substrings in the current string instance.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings should be trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An array containing substrings of this string that are delimited by the specified separators.
        /// </returns>
        public static string[] Split(this string str, char[] separators, bool removeEmptyEntries = false, bool trim = false, bool keepSeparator = false)
        {
            return new _innerSplitEnumerator03(str, separators, 0, str.Length, removeEmptyEntries, trim, keepSeparator).ToArray();
        }

        #endregion

        #region Common Ex

        /// <summary>
        /// Returns a <see cref="System.StringSplitResult" /> array that contains information about substrings in this string instance (or a part of this string according to <paramref name="startIndex" /> and <paramref name="length" />) that are delimited by Unicode characters satisfying the specified predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function used to test each Unicode character of the current string. If a character passes this predicate, it returns a non-negative integer as the separator's index; otherwise, this function must return -1. Any character satisfying this predicate will be used as the separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for characters satisfying <paramref name="predicate" /> starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <returns>A <see cref="System.StringSplitResult" /> array that contains information about the substrings in the current string instance (or a part of the current string instance) that are delimited by Unicode characters satisfying the specified predicate.</returns>
        public static StringSplitResult[] SplitEx(this string str, Func<char, int> predicate, int startIndex, int length, bool removeEmptyEntries = false, bool trim = false)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return new _innerSplitEnumeratorEx01(str, predicate, startIndex, endIndex, removeEmptyEntries, trim).ToArray();
        }

        /// <summary>
        /// Returns a <see cref="System.StringSplitResult" /> array that contains information about substrings in this string instance (or a part of this string according to <paramref name="startIndex"/>) that are delimited by Unicode characters satisfying the specified predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function used to test each Unicode character of the current string. If a character passes this predicate, it returns a non-negative integer as the separator's index; otherwise, this function must return -1. Any character satisfying this predicate will be used as the separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for characters satisfying <paramref name="predicate" /> starts.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <returns>
        /// A <see cref="System.StringSplitResult" /> array that contains information about the substrings in the current string instance (or a part of the current string instance)
        /// that are delimited by Unicode characters satisfying the specified predicate.
        /// </returns>
        public static StringSplitResult[] SplitEx(this string str, Func<char, int> predicate, int startIndex, bool removeEmptyEntries = false, bool trim = false)
        {
            ExceptionHelper.NonNegativeArgumentRequired("startIndex", startIndex);
            return new _innerSplitEnumeratorEx01(str, predicate, startIndex, str.Length, removeEmptyEntries, trim).ToArray();
        }

        /// <summary>
        /// Returns a <see cref="System.StringSplitResult" /> array that contains information about substrings in this string instance that are delimited by Unicode characters satisfying the specified predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character of the current string. Any character that passes this test will be used as a separator.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <returns>
        /// A <see cref="System.StringSplitResult" /> array that contains information about the substrings in the current string instance that are delimited by Unicode characters satisfying the specified predicate.
        /// </returns>
        public static StringSplitResult[] SplitEx(this string str, Func<char, int> predicate, bool removeEmptyEntries = false, bool trim = false)
        {
            return new _innerSplitEnumeratorEx01(str, predicate, 0, str.Length, removeEmptyEntries, trim).ToArray();
        }

        /// <summary>
        /// Returns a <see cref="System.StringSplitResult" /> array that contains information about the substrings in this string (or a part of this string according to <paramref name="startIndex"/> and <paramref name="length"/>) that are delimited by specified Unicode characters.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separators">A non-empty array of Unicode characters that delimit the substrings in the current string instance.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <returns>
        /// A <see cref="System.StringSplitResult" /> array that contains information about the substrings in the current string instance (or a part of the current string instance) that are delimited by outside-quote separators.
        /// </returns>
        public static StringSplitResult[] SplitEx(this string str, char[] separators, int startIndex, int length, bool removeEmptyEntries = false, bool trim = false)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return new _innerSplitEnumeratorEx02(str, separators, startIndex, endIndex, removeEmptyEntries, trim).ToArray();
        }

        /// <summary>
        /// Returns a <see cref="System.StringSplitResult" /> array that contains information about the substrings in this string (or a part of this string according to <paramref name="startIndex"/>) that are delimited by specified Unicode characters.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separators">A non-empty array of Unicode characters that delimit the substrings in the current string instance.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>        /// <returns>
        /// A <see cref="System.StringSplitResult" /> array that contains information about the substrings in the current string instance (or a part of the current string instance) that are delimited by outside-quote separators.
        /// </returns>
        public static StringSplitResult[] SplitEx(this string str, char[] separators, int startIndex, bool removeEmptyEntries = false, bool trim = true)
        {
            ExceptionHelper.NonNegativeArgumentRequired("startIndex", startIndex);
            return new _innerSplitEnumeratorEx02(str, separators, startIndex, str.Length, removeEmptyEntries, trim).ToArray();
        }

        /// <summary>
        /// Returns a <see cref="System.StringSplitResult" /> array that contains information about the substrings in this string that are delimited by specified Unicode characters.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separators">A non-empty array of Unicode characters that delimit the substrings in the current string instance.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>        
        /// <returns>
        /// A <see cref="System.StringSplitResult" /> array that contains information about the substrings in the current string instance that are delimited by outside-quote separators.
        /// </returns>
        public static StringSplitResult[] SplitEx(this string str, char[] separators, bool removeEmptyEntries = false, bool trim = true)
        {
            return new _innerSplitEnumeratorEx02(str, separators, 0, str.Length, removeEmptyEntries, trim).ToArray();
        }

        #endregion

        #region WithQuotes

        /// <summary>
        /// Returns a string array that contains substrings in this string instance (or a part of this string)
        /// that are delimited by Unicode characters outside quotes satisfying the specified predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character outside the quotes of the current string.
        /// Any character that passes this test will be used as a separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for characters satisfying <paramref name="predicate" /> starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="leftQuote">Specifies the Unicode character as the left quote.</param>
        /// <param name="rightQuote">Specifies the Unicode character as the right quote.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="keepQuotes"><c>true</c> if the quotes are not removed in the returned strings.
        /// For example, splitting string "{a,b},c" by comma ',' with '{' and '}' as the quotes produces array "{a,b}", "c" with this argument set <c>true</c>,
        /// and "a,b", "c" with this argument set <c>false</c>.</param>
        /// <param name="keepSeparator"><c>true</c> if separators are not removed from the returned strings.
        /// For example, splitting string "a,b,c" by comma ',' produces "a,", "b,", "c" with this argument set <c>true</c>
        /// and "a", "b", "c" without this argument set <c>false</c>.</param>
        /// <returns>
        /// A string array whose elements are the substrings in the current string instance (or a part of the current string instance) that are delimited by outside-quote characters satisfying the specified <paramref name="predicate" />.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when a quote mismatch is found.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when the value of <paramref name="startIndex"/> or <paramref name="length"/> is not valid.</exception>
        public static string[] SplitWithQuotes(this string str, Func<char, bool> predicate, int startIndex, int length,
            char leftQuote = '{', char rightQuote = '}', bool removeEmptyEntries = true, bool keepQuotes = true, bool keepSeparator = false)
        {
            return GetSplitEnumeratorWithQuotes(str, predicate, startIndex, length, leftQuote, rightQuote, removeEmptyEntries, keepQuotes, keepSeparator).ToArray();
        }

        /// <summary>
        /// Returns a string array that contains substrings in this string instance (or a part of this string)
        /// that are delimited by Unicode characters outside quotes satisfying the specified predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character outside the quotes of the current string.
        /// Any character that passes this test will be used as a separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for characters satisfying <paramref name="predicate" /> starts.</param>
        /// <param name="leftQuote">Specifies the Unicode character as the left quote.</param>
        /// <param name="rightQuote">Specifies the Unicode character as the right quote.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="keepQuotes"><c>true</c> if the quotes are not removed in the returned strings.
        /// For example, splitting string "{a,b},c" by comma ',' with '{' and '}' as the quotes produces array "{a,b}", "c" with this argument set <c>true</c>,
        /// and "a,b", "c" with this argument set <c>false</c>.</param>
        /// <param name="keepSeparator"><c>true</c> if separators are not removed from the returned strings.
        /// For example, splitting string "a,b,c" by comma ',' produces "a,", "b,", "c" with this argument set <c>true</c>
        /// and "a", "b", "c" without this argument set <c>false</c>.</param>
        /// <returns>
        /// A string array whose elements are the substrings in the current string instance (or a part of the current string instance) that are delimited by outside-quote characters satisfying the specified <paramref name="predicate" />.
        /// </returns>
        public static string[] SplitWithQuotes(this string str, Func<char, bool> predicate, int startIndex = 0,
            char leftQuote = '{', char rightQuote = '}', bool removeEmptyEntries = true, bool keepQuotes = true, bool keepSeparator = false)
        {
            return SplitWithQuotes(str, predicate, startIndex, str.Length - startIndex, leftQuote, rightQuote, removeEmptyEntries, keepQuotes, keepSeparator);
        }

        /// <summary>
        /// Returns a string array that contains the substrings in this string (or a part of this string)
        /// that are delimited by specified Unicode characters outside quotes.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separators">A non-empty array of Unicode characters that delimit the substrings in the current string instance.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="leftQuote">Specifies the Unicode character as the left quote.</param>
        /// <param name="rightQuote">Specifies the Unicode character as the right quote.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="keepQuotes"><c>true</c> if the quotes are not removed in the returned strings.
        /// For example, splitting string "{a,b},c" by comma ',' with '{' and '}' as the quotes produces array "{a,b}", "c" with this argument set <c>true</c>,
        /// and "a,b", "c" with this argument set <c>false</c>.</param>
        /// <param name="keepSeparator"><c>true</c> if separators are not removed from the returned strings.
        /// For example, splitting string "a,b,c" by comma ',' produces "a,", "b,", "c" with this argument set <c>true</c>
        /// and "a", "b", "c" without this argument set <c>false</c>.</param>
        /// <returns>
        /// A string array whose elements are the substrings in the current string instance (or a part of the current string instance) that are delimited by outside-quote separators.
        /// </returns>
        public static string[] SplitWithQuotes(this string str, char[] separators, int startIndex, int length, char leftQuote = '{', char rightQuote = '}',
            bool removeEmptyEntries = true, bool keepQuotes = true, bool keepSeparator = false)
        {
            return SplitWithQuotes(str, c => c.In(separators), startIndex, length, leftQuote, rightQuote, removeEmptyEntries, keepQuotes, keepSeparator);
        }

        /// <summary>
        /// Returns a string array that contains the substrings in this string (or a part of this string)
        /// that are delimited by specified Unicode characters outside quotes.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separators">A non-empty array of Unicode characters that delimit the substrings in the current string instance.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="leftQuote">Specifies the Unicode character as the left quote.</param>
        /// <param name="rightQuote">Specifies the Unicode character as the right quote.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="keepQuotes"><c>true</c> if the quotes are not removed in the returned strings.
        /// For example, splitting string "{a,b},c" by comma ',' with '{' and '}' as the quotes produces array "{a,b}", "c" with this argument set <c>true</c>,
        /// and "a,b", "c" with this argument set <c>false</c>.</param>
        /// <param name="keepSeparator"><c>true</c> if separators are not removed from the returned strings.
        /// For example, splitting string "a,b,c" by comma ',' produces "a,", "b,", "c" with this argument set <c>true</c>
        /// and "a", "b", "c" without this argument set <c>false</c>.</param>
        /// <returns>
        /// A string array whose elements are the substrings in the current string instance (or a part of the current string instance) that are delimited by outside-quote separators.
        /// </returns>
        public static string[] SplitWithQuotes(this string str, char[] separators, int startIndex = 0, char leftQuote = '{', char rightQuote = '}',
            bool removeEmptyEntries = true, bool keepQuotes = true, bool keepSeparator = false)
        {
            return SplitWithQuotes(str, c => c.In(separators), startIndex, str.Length - startIndex, leftQuote, rightQuote, removeEmptyEntries, keepQuotes, keepSeparator);
        }

        /// <summary>
        /// Returns a string array that contains the substrings in this string (or a part of this string)
        /// that are delimited by specified Unicode characters outside quotes.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separator">A Unicode characters that delimits the substrings in the current string instance.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for the separator starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="leftQuote">Specifies the Unicode character as the left quote.</param>
        /// <param name="rightQuote">Specifies the Unicode character as the right quote.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="keepQuotes"><c>true</c> if the quotes are not removed in the returned strings.
        /// For example, splitting string "{a,b},c" by comma ',' with '{' and '}' as the quotes produces array "{a,b}", "c" with this argument set <c>true</c>,
        /// and "a,b", "c" with this argument set <c>false</c>.</param>
        /// <param name="keepSeparator"><c>true</c> if the separator is not removed from the returned strings.
        /// For example, splitting string "a,b,c" by comma ',' produces "a,", "b,", "c" with this argument set <c>true</c>
        /// and "a", "b", "c" without this argument set <c>false</c>.</param>
        /// <returns>
        /// A string array whose elements are the substrings in the current string instance (or a part of the current string instance) that are delimited by the outside-quote separator.
        /// </returns>
        public static string[] SplitWithQuotes(this string str, char separator, int startIndex, int length, char leftQuote = '{', char rightQuote = '}',
            bool removeEmptyEntries = true, bool keepQuotes = true, bool keepSeparator = false)
        {
            return SplitWithQuotes(str, c => c.Equals(separator), startIndex, length, leftQuote, rightQuote, removeEmptyEntries, keepQuotes, keepSeparator);
        }

        /// <summary>
        /// Returns a string array that contains the substrings in this string (or a part of this string)
        /// that are delimited by specified Unicode characters outside quotes.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separator">A Unicode characters that delimits the substrings in the current string instance.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for the separator starts.</param>
        /// <param name="leftQuote">Specifies the Unicode character as the left quote.</param>
        /// <param name="rightQuote">Specifies the Unicode character as the right quote.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="keepQuotes"><c>true</c> if the quotes are not removed in the returned strings.
        /// For example, splitting string "{a,b},c" by comma ',' with '{' and '}' as the quotes produces array "{a,b}", "c" with this argument set <c>true</c>,
        /// and "a,b", "c" with this argument set <c>false</c>.</param>
        /// <param name="keepSeparator"><c>true</c> if the separator is not removed from the returned strings.
        /// For example, splitting string "a,b,c" by comma ',' produces "a,", "b,", "c" with this argument set <c>true</c>
        /// and "a", "b", "c" without this argument set <c>false</c>.</param>
        /// <returns>
        /// A string array whose elements are the substrings in the current string instance (or a part of the current string instance) that are delimited by the outside-quote separator.
        /// </returns>
        public static string[] SplitWithQuotes(this string str, char separator, int startIndex = 0, char leftQuote = '{', char rightQuote = '}',
            bool removeEmptyEntries = true, bool keepQuotes = true, bool keepSeparator = false)
        {
            return SplitWithQuotes(str, c => c.Equals(separator), startIndex, str.Length - startIndex, leftQuote, rightQuote, removeEmptyEntries, keepQuotes, keepSeparator);
        }

        #endregion

        #region WithQuotes Ex

        /// <summary>
        /// Returns a <see cref="System.StringSplitResult"/> array that contains information about substrings in this string instance (or a part of this string)
        /// that are delimited by Unicode characters outside quotes satisfying the specified predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character outside the quotes of the current string.
        /// Any character that passes this test will be used as a separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for characters satisfying <paramref name="predicate" /> starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="leftQuote">Specifies the Unicode character as the left quote.</param>
        /// <param name="rightQuote">Specifies the Unicode character as the right quote.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="keepQuotes"><c>true</c> if the quotes are not removed in the returned strings.
        /// For example, splitting string "{a,b},c" by comma ',' with '{' and '}' as the quotes produces array "{a,b}", "c" with this argument set <c>true</c>,
        /// and "a,b", "c" with this argument set <c>false</c>.</param>
        /// <param name="keepSeparator"><c>true</c> if separators are not removed from the returned strings.
        /// For example, splitting string "a,b,c" by comma ',' produces "a,", "b,", "c" with this argument set <c>true</c>
        /// and "a", "b", "c" without this argument set <c>false</c>.</param>
        /// <returns>
        /// A <see cref="System.StringSplitResult"/> array that contains information about substrings in the current string instance (or a part of the current string instance) that are delimited by outside-quote characters satisfying the specified <paramref name="predicate" />.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when a quote mismatch is found.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when the value of <paramref name="startIndex"/> or <paramref name="length"/> is not valid.</exception>
        public static StringSplitResult[] SplitWithQuotesEx(this string str, Func<char, int> predicate, int startIndex, int length,
            char leftQuote = '{', char rightQuote = '}', bool removeEmptyEntries = true, bool keepQuotes = true, bool keepSeparator = false)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            var splitList = new List<StringSplitResult>();
            var sb = new StringBuilder(str.Length);
            var multiQuote = leftQuote != rightQuote;

            for (int i = startIndex; i < endIndex; ++i)
            {
                var c = str[i];
                var currCharIsSeparator = predicate(c);

                if (c == leftQuote)
                {
                    if (keepQuotes) sb.Append(leftQuote);
                    var stackNum = 1;

                    while (true)
                    {
                        ++i;
                        if (i == endIndex) throw new FormatException(StringExResources.ERR_Quotes_QuoteMismatch);
                        c = str[i];

                        if (c == leftQuote && multiQuote)
                        {
                            sb.Append(leftQuote);
                            ++stackNum;
                        }
                        else if (c == rightQuote)
                        {
                            --stackNum;
                            if (stackNum == 0 || !multiQuote)
                            {
                                if (keepQuotes) sb.Append(rightQuote);
                                break;
                            }
                            sb.Append(rightQuote);
                        }
                        else sb.Append(c);
                    }
                }
                else if (currCharIsSeparator != -1)
                {
                    if (!removeEmptyEntries || sb.Length != 0)
                    {
                        if (keepSeparator) sb.Append(c);
                        splitList.Add(new StringSplitResult(sb.ToString(), c, currCharIsSeparator));
                        sb.Clear();
                    }
                    //blank entry discarded
                }
                else sb.Append(c);
            }

            if (splitList.Count == 0) return (new StringSplitResult(str, '\0', -1)).CreateSingleton();
            else
            {
                if (!removeEmptyEntries || sb.Length != 0) splitList.Add(new StringSplitResult(sb.ToString(), '\0', -1));
                return splitList.ToArray();
            }
        }

        /// <summary>
        /// Returns a <see cref="System.StringSplitResult"/> array that contains information about substrings in this string instance (or a part of this string)
        /// that are delimited by Unicode characters outside quotes satisfying the specified predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character outside the quotes of the current string.
        /// Any character that passes this test will be used as a separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for characters satisfying <paramref name="predicate" /> starts.</param>
        /// <param name="leftQuote">Specifies the Unicode character as the left quote.</param>
        /// <param name="rightQuote">Specifies the Unicode character as the right quote.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="keepQuotes"><c>true</c> if the quotes are not removed in the returned strings.
        /// For example, splitting string "{a,b},c" by comma ',' with '{' and '}' as the quotes produces array "{a,b}", "c" with this argument set <c>true</c>,
        /// and "a,b", "c" with this argument set <c>false</c>.</param>
        /// <param name="keepSeparator"><c>true</c> if separators are not removed from the returned strings.
        /// For example, splitting string "a,b,c" by comma ',' produces "a,", "b,", "c" with this argument set <c>true</c>
        /// and "a", "b", "c" without this argument set <c>false</c>.</param>
        /// <returns>
        /// A <see cref="System.StringSplitResult"/> array that contains information about substrings in the current string instance (or a part of the current string instance) that are delimited by outside-quote characters satisfying the specified <paramref name="predicate" />.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when a quote mismatch is found.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when the value of <paramref name="startIndex"/> or <paramref name="length"/> is not valid.</exception>
        public static StringSplitResult[] SplitWithQuotesEx(this string str, Func<char, int> predicate, int startIndex = 0,
            char leftQuote = '{', char rightQuote = '}', bool removeEmptyEntries = true, bool keepQuotes = true, bool keepSeparator = false)
        {
            return SplitWithQuotesEx(str, predicate, startIndex, str.Length - startIndex, leftQuote, rightQuote, removeEmptyEntries, keepQuotes, keepSeparator);
        }

        /// <summary>
        /// Returns a <see cref="System.StringSplitResult"/> array that contains information about the substrings in this string (or a part of this string)
        /// that are delimited by specified Unicode characters outside quotes.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separators">A non-empty array of Unicode characters that delimit the substrings in the current string instance.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="leftQuote">Specifies the Unicode character as the left quote.</param>
        /// <param name="rightQuote">Specifies the Unicode character as the right quote.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="keepQuotes"><c>true</c> if the quotes are not removed in the returned strings.
        /// For example, splitting string "{a,b},c" by comma ',' with '{' and '}' as the quotes produces array "{a,b}", "c" with this argument set <c>true</c>,
        /// and "a,b", "c" with this argument set <c>false</c>.</param>
        /// <param name="keepSeparator"><c>true</c> if separators are not removed from the returned strings.
        /// For example, splitting string "a,b,c" by comma ',' produces "a,", "b,", "c" with this argument set <c>true</c>
        /// and "a", "b", "c" without this argument set <c>false</c>.</param>
        /// <returns>
        /// A <see cref="System.StringSplitResult"/> array that contains information about the substrings in the current string instance (or a part of the current string instance) that are delimited by outside-quote separators.
        /// </returns>
        public static StringSplitResult[] SplitWithQuotesEx(this string str, char[] separators, int startIndex, int length, char leftQuote = '{', char rightQuote = '}',
            bool removeEmptyEntries = true, bool keepQuotes = true, bool keepSeparator = false)
        {
            return SplitWithQuotesEx(str, c => separators.IndexOf(c), startIndex, length, leftQuote, rightQuote, removeEmptyEntries, keepQuotes, keepSeparator);
        }

        /// <summary>
        /// Returns a <see cref="System.StringSplitResult"/> array that contains information about the substrings in this string (or a part of this string)
        /// that are delimited by specified Unicode characters outside quotes.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separators">A non-empty array of Unicode characters that delimit the substrings in the current string instance.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="leftQuote">Specifies the Unicode character as the left quote.</param>
        /// <param name="rightQuote">Specifies the Unicode character as the right quote.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="keepQuotes"><c>true</c> if the quotes are not removed in the returned strings.
        /// For example, splitting string "{a,b},c" by comma ',' with '{' and '}' as the quotes produces array "{a,b}", "c" with this argument set <c>true</c>,
        /// and "a,b", "c" with this argument set <c>false</c>.</param>
        /// <param name="keepSeparator"><c>true</c> if separators are not removed from the returned strings.
        /// For example, splitting string "a,b,c" by comma ',' produces "a,", "b,", "c" with this argument set <c>true</c>
        /// and "a", "b", "c" without this argument set <c>false</c>.</param>
        /// <returns>
        /// A <see cref="System.StringSplitResult"/> array that contains information about the substrings in the current string instance (or a part of the current string instance) that are delimited by outside-quote separators.
        /// </returns>
        public static StringSplitResult[] SplitWithQuotesEx(this string str, char[] separators, int startIndex = 0, char leftQuote = '{', char rightQuote = '}',
            bool removeEmptyEntries = true, bool keepQuotes = true, bool keepSeparator = false)
        {
            return SplitWithQuotesEx(str, c => separators.IndexOf(c), startIndex, str.Length - startIndex, leftQuote, rightQuote, removeEmptyEntries, keepQuotes, keepSeparator);
        }

        #endregion
    }
}
