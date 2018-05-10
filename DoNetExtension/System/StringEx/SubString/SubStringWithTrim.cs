using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class StringEx
    {
        /// <summary>
        /// Retrieves a substring from this instance and removes white spaces at both ends of the substring.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="startIndex">The zero-based starting character position of a substring in this instance.</param>
        /// <param name="length">The number of characters in the substring.</param>
        /// <returns>A substring starting from position <paramref name="startIndex" /> to position <pamref name="startIndex" /> + <paramref name="length" /> - 1 with white spaces removed from both ends of the substring.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining), SecuritySafeCritical]
        public static string SubstringWithTrim(this string str, int startIndex, int length)
        {
            #region Preserved Code
            ////! After heavy test, I found the build-in way is the most efficient way. I don't know why, but this is the case.
            //return str.Substring(startIndex, length).Trim();
            #endregion
            
            var endIndex = startIndex + length - 1;

            while (startIndex <= endIndex)
            {
                if (!char.IsWhiteSpace(str[startIndex])) break;
                ++startIndex;
            }

            while (endIndex >= startIndex)
            {
                if (!char.IsWhiteSpace(str[endIndex])) break;
                --endIndex;
            }

            return str.Substring(startIndex, endIndex - startIndex + 1);
        }

        /// <summary>
        /// Retrieves a substring from this instance and removes white spaces at both ends of the substring.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="startIndex">The zero-based starting character position of a substring in this instance.</param>
        /// <returns>A substring starting from position <paramref name="startIndex" /> to the end of the current string instance with white spaces removed from both ends of the substring.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining), SecuritySafeCritical]
        public static string SubstringWithTrim(this string str, int startIndex)
        {
            var endIndex = str.Length - 1;

            while (startIndex <= endIndex)
            {
                if (!char.IsWhiteSpace(str[startIndex])) break;
                ++startIndex;
            }

            while (endIndex >= startIndex)
            {
                if (!char.IsWhiteSpace(str[endIndex])) break;
                --endIndex;
            }

            return str.Substring(startIndex, endIndex - startIndex + 1);
        }
    }
}
