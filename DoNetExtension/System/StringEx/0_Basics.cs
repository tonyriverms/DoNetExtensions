using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class StringEx
    {
        /// <summary>
        /// Returns <c>true</c> if current string instance is null or empty. This is a dummy of <see cref="string.IsNullOrEmpty"/> method for convenience.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <returns><c>true</c> if this string instance is null or empty; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// Returns <c>true</c> if the current string instance is empty.
        /// </summary>
        /// <param name="str">The string instance.</param>
        /// <returns><c>true</c> if the current string is empty; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEmpty(this string str)
        {
            return str.Length == 0;
        }


        /// <summary>
        /// Indicates whether the current string instance is empty or contains only whitespace characters defined by <see cref="char.IsWhiteSpace(char)"/>.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <returns><c>true</c> if this string instance is empty or contains only whitespace characters; otherwise, <c>false</c>.</returns>
        /// <exception cref="NullReferenceException">Occurs when <paramref name="str"/> is a <c>null</c> reference.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEmptyOrBlank(this string str)
        {
            var len = str.Length;
            for (var i = 0; i < len; ++i)
                if (!char.IsWhiteSpace(str[i]))
                    return false;
            return true;
        }


        /// <summary>
        /// Indicates whether the current string instance is null, empty or contains only white space characters defined by <see cref="char.IsWhiteSpace(char)"/>.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <returns><c>true</c> if this string instance is null or empty or contains only white space characters; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNullOrEmptyOrBlank(this string str)
        {
            return str == null || str.IsEmptyOrBlank();
        }


        /// <summary>
        /// Returns <c>true</c> if current string instance is not null and not empty.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <returns><c>true</c> if this string instance is not null and not empty; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNotNullOrEmpty(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// Returns <c>true</c> if the current string instance is not empty.
        /// </summary>
        /// <param name="str">The string instance.</param>
        /// <returns><c>true</c> if the current string is not empty; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNotEmpty(this string str)
        {
            return str.Length != 0;
        }

        /// <summary>
        /// Indicates whether the current string instance is not empty and contains characters other than white spaces defined by <see cref="char.IsWhiteSpace(char)"/>.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <returns><c>true</c> if this string instance is not empty and contains at least one non-whitespace character; otherwise, <c>false</c>.</returns>
        /// <exception cref="NullReferenceException">Occurs when <paramref name="str"/> is a <c>null</c> reference.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNotEmptyOrBlank(this string str)
        {
            var len = str.Length;
            for (var i = 0; i < len; ++i)
                if (!char.IsWhiteSpace(str[i]))
                    return true;
            return false;
        }


        /// <summary>
        /// Indicates whether the current string instance is not null null, not empty, and contains characters other than white spaces defined by <see cref="char.IsWhiteSpace(char)"/>.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <returns><c>true</c> if this string instance is not null, not empty, and contains at least one non-whitespace character; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNotNullOrEmptyOrBlank(this string str)
        {
            return str != null && str.IsNotEmptyOrBlank();
        }

    }
}
