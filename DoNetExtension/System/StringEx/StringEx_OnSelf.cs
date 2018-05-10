using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class StringEx
    {
        //TITLE: OnSelf-Series String Methods
        //VERSION: 0.0.2
        //DATE: 08/21/2012
        //TEST: Yes

        //TEST: Yes
        /// <summary>
        /// Replaces all occurrences of specified Unicode characters in this instance by another specified Unicode character.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="oldChars">The Unicode characters to be replaced.</param>
        /// <param name="newChar">The Unicode character to replace all occurrences of characters in <paramref name="oldChars"/>.</param>
        /// <returns>The original string instance with all specified Unicode characters replaced.</returns>
        public unsafe static string ReplaceOnSelf(this string str, char[] oldChars, char newChar)
        {
            var strlen = str.Length;
            fixed (char* ptr = str)
            {
                for (int i = 0; i < strlen; i++)
                {
                    if (ptr[i].In(oldChars))
                        ptr[i] = newChar;
                }
            }
            return str;
        }

        //TEST: Yes
        /// <summary>
        /// Replaces all occurrences of the specified Unicode character in this instance by another specified Unicode character.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="oldChars">The Unicode character to be replaced.</param>
        /// <param name="newChar">The Unicode character to replace all occurrences of <paramref name="oldChar"/>.</param>
        /// <returns>The original string instance with all specified Unicode characters replaced.</returns>
        public unsafe static string ReplaceOnSelf(this string str, char oldChar, char newChar)
        {
            var strlen = str.Length;
            fixed (char* ptr = str)
            {
                for (int i = 0; i < strlen; i++)
                {
                    if (ptr[i] == oldChar)
                        ptr[i] = newChar;
                }
            }
            return str;
        }

        //TEST: Yes
        /// <summary>
        /// Converts the initial Unicode character of this string instance to its uppercase equivalent.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <returns>The original string instance with the initial character converted to its uppercase equivalent.</returns>
        public unsafe static string InitUpperOnSelf(this string str)
        {
            if (str[0].IsUpper()) return str;

            fixed (char* ptr = str)
            {
                ptr[0] = ptr[0].ToUpper();
            }
            return str;
        }

        /// <summary>
        /// Converts the initial Unicode characters of the substrings of this string instance separated by white spaces to their uppercase equivalents.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <returns>The original string instance with the initial characters of white-space-separated substrings converted to their uppercase equivalents.</returns>
        public unsafe static string InitUpperOnSelfForWords(this string str)
        {
            var nonWhiteSpaceToUpper = true;
            fixed (char* ptr = str)
            {
                for (int i = 0, j = str.Length; i < j; ++i)
                {
                    if(nonWhiteSpaceToUpper)
                    {
                        if (!ptr[i].IsWhiteSpace())
                        {
                            ptr[i] = ptr[i].ToUpper();
                            nonWhiteSpaceToUpper = false;
                        }
                    }
                    else if (ptr[i].IsWhiteSpace())
                        nonWhiteSpaceToUpper = true;
                }
            }
            return str;
        }

        /// <summary>
        /// Converts the initial Unicode characters of the substrings of this string instance separated by white spaces to their uppercase equivalents, and all other non-whitespace Unicode characters to their lowercase equivalents.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <returns>The original string instance with the initial characters of white-space-separated substrings converted to their uppercase equivalents, and all other non-whitespace Unicode characters to their lowercase equivalents.</returns>
        public unsafe static string NormalizeCasesOnSelfForWords(this string str)
        {
            var nonWhiteSpaceToUpper = true;
            fixed (char* ptr = str)
            {
                for (int i = 0, j = str.Length; i < j; ++i)
                {
                    if (nonWhiteSpaceToUpper)
                    {
                        if (!ptr[i].IsWhiteSpace())
                        {
                            ptr[i] = ptr[i].ToUpper();
                            nonWhiteSpaceToUpper = false;
                        }
                    }
                    else if (ptr[i].IsWhiteSpace())
                        nonWhiteSpaceToUpper = true;
                    else
                        ptr[i] = ptr[i].ToLower();
                }
            }
            return str;
        }

        //TEST: Yes
        /// <summary>
        /// Converts the initial Unicode character of this string instance to its lowercase equivalent.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <returns>The original string instance with the initial character converted to its lowercase equivalent.</returns>
        public unsafe static string InitLowerOnSelf(this string str)
        {
            if (str[0].IsLower()) return str;

            fixed (char* ptr = str)
            {
                ptr[0] = ptr[0].ToLower();
            }
            return str;
        }

        //TEST: Yes
        /// <summary>
        /// Converts all Unicode characters in this string instance to their uppercase equivalents. The characters without uppercase equivalent will not be converted.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <returns>The original string instance with every character converted to their lowercase equivalent.</returns>
        public unsafe static string ToUpperOnSelf(this string str)
        {
            fixed (char* ptr = str)
            {
                for (int i = 0, j = str.Length; i < j; i++)
                    ptr[i] = ptr[i].ToUpper();
            }
            return str;
        }

        //TEST: Yes
        /// <summary>
        /// Converts all Unicode characters in this string instance to their lowercase equivalents. The characters without lowercase equivalent will not be converted.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <returns>The original string instance with every character converted to their lowercase equivalent.</returns>
        public unsafe static string ToLowerOnSelf(this string str)
        {
            fixed (char* ptr = str)
            {
                for (int i = 0, j = str.Length; i < j; i++)
                    ptr[i] = ptr[i].ToLower();
            }
            return str;
        }

        //TEST: Yes
        /// <summary>
        /// Reverses this string instance.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <returns>The reversed original string instance.</returns>
        public unsafe static string ReverseOnSelf(this string str)
        {
            fixed(char* ptr = str)
            {
                var strlen = str.Length;
                var halflen = (int)(strlen-- / 2);

                for (int i = 0; i < halflen; i++)
                {
                    int i2 = strlen - i;
                    ptr[i] ^= ptr[i2];
                    ptr[i2] ^= ptr[i];
                    ptr[i] ^= ptr[i2];
                }
            }

            return str;
        }

        public static string Replace(this string str, Func<char, bool> predicate, char replacement)
        {
            var strLen = str.Length;
            var output = new char[strLen];
            
            for (int i = 0; i < strLen; ++i)
                output[i] = predicate(str[i]) ? replacement : str[i];

            return new string(output);
        }

        public static string ReplaceOrOriginal(this string str, Func<char, bool> predicate, char replacement)
        {
            var strLen = str.Length;
            var output = new char[strLen];
            bool replaced = false;
            for (int i = 0; i < strLen; ++i)
            {
                var c = str[i];
                if (predicate(c))
                {
                    output[i] = replacement;
                    replaced = true;
                }
                else output[i] = c;
            }

            if (replaced) return new string(output);
            else return str;
        }

    }
}
