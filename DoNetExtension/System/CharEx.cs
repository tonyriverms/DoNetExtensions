using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace System
{
    /// <summary>
    /// Provides rich methods to operate on a character instance.
    /// </summary>
    public static class CharExtension
    {

        #region In-Series Methods

        /// <summary>
        /// Determines whether this Unicode character exists in the specified string instance.
        /// </summary>
        /// <param name="c">This Unicode character.</param>
        /// <param name="target">The string instance to search the current Unicode character.</param>
        /// <returns>true if the specified string instance contains the current Unicode character; otherwise, <c>false</c>.</returns>
        public static bool In(this char c, string target)
        {
            return target.IndexOf(c) != -1;
        }

        /// <summary>
        /// Determines whether this Unicode character exists in any element of the specified string sequence.
        /// </summary>
        /// <param name="c">This Unicode character.</param>
        /// <param name="target">The string sequence whose elements will be searched for the current Unicode character.</param>
        /// <returns>true if any element of the specified string sequence contains the current Unicode character; otherwise, <c>false</c>.</returns>
        public static bool InAny(this char c, IEnumerable<string> target)
        {
            foreach (var str in target)
                if (str.IndexOf(c) != -1) return true;
            return false;
        }

        /// <summary>
        /// Determines whether this Unicode character exists in every element of the specified string sequence.
        /// </summary>
        /// <param name="c">This Unicode character.</param>
        /// <param name="target">The string sequence whose elements will be searched for the current Unicode character.</param>
        /// <returns>true if every element of the specified string sequence contains the current Unicode character; otherwise, <c>false</c>.</returns>
        public static bool InAll(this char c, IEnumerable<string> target)
        {
            foreach (var str in target)
                if (str.IndexOf(c) == -1) return false;
            return true;
        }

        /// <summary>
        /// Determines whether this Unicode character exists in any element of the specified string array.
        /// </summary>
        /// <param name="c">This Unicode character.</param>
        /// <param name="target">The string array whose elements will be searched for the current Unicode character.</param>
        /// <returns>true if any element of the specified string array contains the current Unicode character; otherwise, <c>false</c>.</returns>
        public static bool InAny(this char c, params string[] target)
        {
            foreach (var str in target)
                if (str.IndexOf(c) != -1) return true;
            return false;
        }

        /// <summary>
        /// Determines whether this Unicode character exists in any element of the specified string array.
        /// </summary>
        /// <param name="c">This Unicode character.</param>
        /// <param name="target">The string array whose elements will be searched for the current Unicode character.</param>
        /// <returns>true if every element of the specified string array contains the current Unicode character; otherwise, <c>false</c>.</returns>
        public static bool InAll(this char c, params string[] target)
        {
            foreach (var str in target)
                if (str.IndexOf(c) == -1) return false;
            return true;
        }

        #endregion

        /// <summary>
        /// Returns a new instance of the <see cref="System.String"/> class to the value indicated by the current Unicode character repeated a specified number of times.
        /// </summary>
        /// <param name="c">A Unicode character.</param>
        /// <param name="repeat">The number of times the current character repeats.</param>
        /// <returns>A <see cref="string" /> that contains the current character repeated by the specified number of times.</returns>
        public static string ToString(this char c, int repeat)
        {
            if (repeat <= 0) return string.Empty;
            return new string(c, repeat);
        }

        /// <summary>Converts the specified numeric Unicode character to a double-precision floating point number. This is a dummy method of <see cref="char.GetNumericValue(char)"/> for convenience.</summary>
        /// <param name="c">The Unicode character to convert. </param>
        /// <returns>The numeric value of the current character if that character represents a number; otherwise, -1.0.</returns>
        public static double GetNumericValue(this char c)
        {
            return char.GetNumericValue(c);
        }

        /// <summary>
        /// Converts the value of a Unicode character to its uppercase equivalent using the casing rules of the invariant culture. This is a dummy method of <see cref="char.ToUpper(char,CultureInfo)" /> for convenience.
        /// </summary>
        /// <param name="c">The Unicode character to convert.</param>
        /// <param name="culture">An object that supplies culture-specific casing rules.</param>
        /// <returns>The uppercase equivalent of the current character, or the unchanged value of the current character, if the current character is already uppercase or not alphabetic.</returns>
        public static char ToUpper(this char c, CultureInfo culture)
        {
            return char.ToUpper(c, culture);
        }

        /// <summary>
        /// Converts the value of a Unicode character to its lowercase equivalent using the casing rules of the invariant culture. This is a dummy method of <see cref="char.ToLower(char, CultureInfo)" /> for convenience.
        /// </summary>
        /// <param name="c">The Unicode character to convert.</param>
        /// <param name="culture">An object that supplies culture-specific casing rules.</param>
        /// <returns>The lowercase equivalent of the current character, or the unchanged value of the current character, if  the current character is already lowercase or not alphabetic.</returns>
        public static char ToLower(this char c, CultureInfo culture)
        {
            return char.ToLower(c, culture);
        }

        /// <summary>
        /// Gets the uppercase equivalent of the current Unicode character. This is a dummy method of <see cref="char.ToUpperInvariant(char)"/> for convenience.
        /// </summary>
        /// <param name="c">This Unicode character</param>
        /// <returns>The uppercase equivalent of the current Unicode character, or the original value if it is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
        public static char ToUpper(this char c)
        {
            return char.ToUpperInvariant(c);
        }

        /// <summary>
        /// Gets the lowercase equivalent of the current Unicode character. This is a dummy method of <see cref="char.ToLowerInvariant(char)"/> for convenience.
        /// </summary>
        /// <param name="c">This Unicode character</param>
        /// <returns>The lowercase equivalent of the current Unicode character, 
        /// or the original value if it is already lowercase, has no lowercase equivalent, or is not alphabetic.</returns>
        public static char ToLower(this char c)
        {
            return char.ToLowerInvariant(c);
        }

        /// <summary>
        /// Indicates whether this instance of Unicode character is categorized as white space. This is a dummy method of <see cref="char.IsWhiteSpace(char)"/> for convenience.
        /// </summary>
        /// <param name="c">An instance of <see cref="System.Char"/></param>
        /// <returns><c>true</c> if this instance of Unicode character is white space; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWhiteSpace(this char c)
        {
            return char.IsWhiteSpace(c);
        }

        /// <summary>
        /// Indicates whether this instance of Unicode character is categorized as a decimal digit. This is a dummy method of <see cref="char.IsDigit(char)"/> for convenience.
        /// </summary>
        /// <param name="c">An instance of <see cref="System.Char"/></param>
        /// <returns><c>true</c> if this instance of Unicode character is a decimal digit; otherwise, <c>false</c>.</returns>
        public static bool IsDigit(this char c)
        {
            return char.IsDigit(c);
        }

        /// <summary>
        /// Indicates whether this instance of Unicode character is categorized as a letter. This is a dummy method of <see cref="char.IsLetter(char)"/> for convenience.
        /// </summary>
        /// <param name="c">An instance of <see cref="System.Char"/></param>
        /// <returns><c>true</c> if this instance of Unicode character is a letter; otherwise, <c>false</c>.</returns>
        public static bool IsLetter(this char c)
        {
            return char.IsLetter(c);
        }

        /// <summary>
        /// Inidcates whether this instance of Unicode character is categoriazed as an ASCII letter.
        /// </summary>
        /// <param name="c">An instance of <see cref="System.Char"/></param>
        /// <returns><c>true</c> if this instance of Unicode character is an ASCII letter; otherwise, <c>false</c>.</returns>
        public static bool IsASCIILetter(this char c)
        {
            return (c <= 'z' && c >= 'a') || (c >= 'A' && c <= 'Z');
        }

        /// <summary>
        /// Inidcates whether this instance of Unicode character is categoriazed as an ASCII upper letter (i.e. A-Z).
        /// </summary>
        /// <param name="c">An instance of <see cref="<see cref="System.Char"/>.</param>
        /// <returns><c>true</c> if this instance of Unicode character is an ASCII upper letter; otherwise, <c>false</c>.</returns>
        public static bool IsASCIIUpper(this char c)
        {
            return c >= 'A' && c <= 'Z';
        }

        /// <summary>
        /// Inidcates whether this instance of Unicode character is categoriazed as an ASCII lower letter (i.e. a-z).
        /// </summary>
        /// <param name="c">An instance of <see cref="<see cref="System.Char"/>.</param>
        /// <returns><c>true</c> if this instance of Unicode character is an ASCII lower letter; otherwise, <c>false</c>.</returns>
        public static bool IsASCIILower(this char c)
        {
            return c >= 'a' && c <= 'z';
        }

        /// <summary>
        /// Inidcates whether this instance of Unicode character is categoriazed as an ASCII letter or ASCII digit.
        /// </summary>
        /// <param name="c">An instance of <see cref="System.Char"/></param>
        /// <returns><c>true</c> if this instance of Unicode character is an ASCII letter or an ASCII digit; otherwise, <c>false</c>.</returns>
        public static bool IsASCIILetterOrDigit(this char c)
        {
            return (c <= 'z' && c >= 'a') || (c >= 'A' && c <= 'Z' || (c >= '0' && c <= '9'));
        }

        /// <summary>
        /// Inidcates whether this instance of Unicode character is categoriazed as an ASCII digit (i.e. 0-9).
        /// </summary>
        /// <param name="c">An instance of <see cref="System.Char"/></param>
        /// <returns><c>true</c> if this instance of Unicode character is an ASCII digit; otherwise, <c>false</c>.</returns>
        public static bool IsASCIIDigit(this char c)
        {
            return c >= '0' && c <= '9';
        }

        /// <summary>
        /// Inidcates whether this instance of Unicode character is categoriazed as an ASCII character (i.e. the character's code is smaller than or equal to 127).
        /// </summary>
        /// <param name="c">An instance of <see cref="System.Char"/></param>
        /// <returns><c>true</c> if this instance of Unicode character is an ASCII character; otherwise, <c>false</c>.</returns>
        public static bool IsASCII(this char c)
        {
            return (c <= 127);
        }

        /// <summary>
        /// Indicates whether this instance of Unicode character is categorized as a letter or a decimal digit. This is a dummy method of <see cref="char.IsLetterOrDigit(char)"/> for convenience.
        /// </summary>
        /// <param name="c">An instance of <see cref="System.Char"/></param>
        /// <returns><c>true</c> if this instance of Unicode character is a letter or a decimal digit; otherwise, <c>false</c>.</returns>
        public static bool IsLetterOrDigit(this char c)
        {
            return char.IsLetterOrDigit(c);
        }

        /// <summary>
        /// Indicates whether this instance of Unicode character is categorized as an upper case letter. This is a dummy method of <see cref="char.IsUpper(char)"/> for convenience.
        /// </summary>
        /// <param name="c">An instance of <see cref="System.Char"/></param>
        /// <returns><c>true</c> if this instance of Unicode character is an upper case letter; otherwise, <c>false</c>.</returns>
        public static bool IsUpper(this char c)
        {
            return char.IsUpper(c);
        }

        /// <summary>
        /// Indicates whether this instance of Unicode character is categorized as a lower case letter. This is a dummy method of <see cref="char.IsLower(char)"/> for convenience.
        /// </summary>
        /// <param name="c">An instance of <see cref="System.Char"/></param>
        /// <returns><c>true</c> if this instance of Unicode character is a lower case letter; otherwise, <c>false</c>.</returns>
        public static bool IsLower(this char c)
        {
            return char.IsLower(c);
        }

        /// <summary>
        /// Indicates whether this instance of Unicode character is categorized as a punctuation. This is a dummy method of <see cref="char.IsPunctuation(char)"/> for convenience.
        /// </summary>
        /// <param name="c">An instance of <see cref="System.Char"/></param>
        /// <returns><c>true</c> if this instance of Unicode character is a punctuation; otherwise, <c>false</c>.</returns>
        public static bool IsPunctuation(this char c)
        {
            return char.IsPunctuation(c);
        }

        /// <summary>
        /// Indicates whether this instance of Unicode character is categorized as a number. This is a dummy method of <see cref="char.IsNumber(char)"/> for convenience.
        /// </summary>
        /// <param name="c">An instance of <see cref="System.Char"/></param>
        /// <returns><c>true</c> if this instance of Unicode character is a number; otherwise, <c>false</c>.</returns>
        public static bool IsNumber(this char c)
        {
            return char.IsNumber(c);
        }

        /// <summary>
        /// Determines whether the current character is the currency symbol under the current culture.
        /// </summary>
        /// <param name="c">The current character.</param>
        /// <returns><c>true</c> the current character is a currency symbol under the current culture; otherwise, <c>false</c>.</returns>
        public static bool IsCurrencySymbol(this char c)
        {
            return IsCurrencySymbol(c, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Determines whether the current character is the currency symbol under the specified culture.
        /// </summary>
        /// <param name="c">The current character.</param>
        /// <param name="culture">An object that supplies culture-specific casing rules.</param>
        /// <returns><c>true</c> the current character is a currency symbol under the specified culture; otherwise, <c>false</c>.</returns>
        public static bool IsCurrencySymbol(this char c, CultureInfo culture)
        {
            var currencySymbol = culture.NumberFormat.CurrencySymbol;
            if (currencySymbol.Length == 1) return c == currencySymbol[0];
            else return false;
        }


        /// <summary>
        /// Determines whether the current character represents the numerical negative sign under the current culture.
        /// </summary>
        /// <param name="c">The current character.</param>
        /// <returns><c>true</c> the current character represents the numerical negative sign under the current culture; otherwise, <c>false</c>.</returns>
        public static bool IsNegativeSign(this char c)
        {
            return IsNegativeSign(c, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Determines whether the current character represents the numerical negative sign under the specified culture.
        /// </summary>
        /// <param name="c">The current character.</param>
        /// <param name="culture">An object that supplies culture-specific casing rules.</param>
        /// <returns><c>true</c> the current character represents the numerical negative sign under the specified culture; otherwise, <c>false</c>.</returns>
        public static bool IsNegativeSign(this char c, CultureInfo culture)
        {
            var negativeSign = culture.NumberFormat.NegativeSign;
            if (negativeSign.Length == 1) return c == negativeSign[0];
            else return false;
        }

    }
}
