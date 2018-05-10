using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_Extension_Library.System;

namespace System
{
    public static partial class StringEx
    {
        /// <summary>
        /// Determines if a substring of the current string instance 
        /// starts with the target string specified by <paramref name="value"/>.
        /// The method performs an ordinal comparison between strings.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="startIndex">The start position of the substring.</param>
        /// <param name="value">The string instance to compare.</param>
        /// <param name="ignoreCase">Indicates whether the comparison is case-sensitive.</param>
        /// <returns><c>true</c> if the specified substring starts with the target string; otherwise, <c>false</c>.</returns>
        public static bool StartsWith(this string source, int startIndex, string value, bool ignoreCase = false)
        {
            return StartsWith(source, startIndex, value, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
        }

        /// <summary>
        /// Determines if a substring of the current string instance
        /// starts with the target string (or a substring of this target string) specified by <paramref name="target" />.
        /// The method performs an ordinal comparison between strings.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="startIndex">The start position of the substring of the current string instance.</param>
        /// <param name="target">The target string instance to compare.</param>
        /// <param name="targetStartIndex">The start position of the substring of the target string instance.</param>
        /// <param name="targetLength">The length of the substring of the target string specified by <paramref name="target"/>.</param>
        /// <param name="ignoreCase">Indicates whether the comparison is case-sensitive.</param>
        /// <returns>
        ///   <c>true</c> if the specified substring starts with the target substring (or a substring of this target string); otherwise, <c>false</c>.
        /// </returns>
        public static bool StartsWith(this string source, int startIndex, string target, int targetStartIndex, int targetLength, bool ignoreCase = false)
        {
            return StartsWith(source, startIndex, target, targetStartIndex, targetLength, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
        }

        /// <summary>
        /// Determines if a substring of the current string instance
        /// starts with the target string (or a substring of this target string) specified by <paramref name="target" />.
        /// The method performs an ordinal comparison between strings.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="startIndex">The start position of the substring of the current string instance.</param>
        /// <param name="target">The target string instance to compare.</param>
        /// <param name="targetStartIndex">The start position of the substring of the target string instance.</param>
        /// <param name="ignoreCase">Indicates whether the comparison is case-sensitive.</param>
        /// <returns>
        ///   <c>true</c> if the specified substring starts with the target substring (or a substring of this target string); otherwise, <c>false</c>.
        /// </returns>
        public static bool StartsWith(this string source, int startIndex, string target, int targetStartIndex, bool ignoreCase = false)
        {
            return StartsWith(source, startIndex, target, targetStartIndex, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
        }

        /// <summary>
        /// Determines if a substring of the current string instance
        /// starts with the target string (or a substring of this target string) specified by <paramref name="target" />.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="startIndex">The start position of the substring of the current string instance.</param>
        /// <param name="target">The target string instance to compare.</param>
        /// <param name="targetStartIndex">The start position of the substring of the target string instance.</param>
        /// <param name="targetLength">The length of the substring of the target string specified by <paramref name="target" />.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the comparison.</param>
        /// <returns>
        ///   <c>true</c> if the specified substring starts with the target substring (or a substring of this target string); otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Occurs when at least one of <paramref name="startIndex"/>, <paramref name="targetStartIndex"/> and <paramref name="targetLength"/> is assigned an invalid value.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">Occurs when the argument <paramref name="target"/> is <c>null</c>.</exception>
        public static bool StartsWith(this string source, int startIndex, string target, int targetStartIndex, int targetLength, StringComparison comparisonType)
        {
            if (targetLength < 0)
                throw new ArgumentOutOfRangeException(ExceptionHelper.GetNonNegativeArgumentRequiredMessage("targetLength"));

            if (targetStartIndex < 0)
                throw new ArgumentOutOfRangeException(ExceptionHelper.GetNonNegativeArgumentRequiredMessage("targetStartIndex"));

            var realTargetLen = target == null ? 0 : target.Length;

            var targetEndIndex = targetStartIndex + targetLength;
            if (targetEndIndex > realTargetLen)
                throw new ArgumentOutOfRangeException(ExceptionHelper.GetArgumentOutOfRangeMessage("targetLength", 0, true, target.Length - targetStartIndex, true));

            var sourceLen = source.Length;
            if (startIndex < 0 && startIndex >= sourceLen) throw new ArgumentOutOfRangeException(ExceptionHelper.GetArgumentOutOfRangeMessage("startIndex", 0, true, sourceLen, false));
            sourceLen -= startIndex;
            return sourceLen >= targetLength && string.Compare(source, startIndex, target, targetStartIndex, targetLength, comparisonType) == 0;
        }

        /// <summary>
        /// Determines if a substring of the current string instance
        /// starts with the target string (or a substring of this target string) specified by <paramref name="target" />.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="startIndex">The start position of the substring of the current string instance.</param>
        /// <param name="target">The target string instance to compare.</param>
        /// <param name="targetStartIndex">The start position of the substring of the target string instance.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the comparison.</param>
        /// <returns>
        ///   <c>true</c> if the specified substring starts with the target substring (or a substring of this target string); otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Occurs when either <paramref name="startIndex"/> or <paramref name="targetStartIndex"/> is assigned an invalid value.
        /// </exception>
        public static bool StartsWith(this string source, int startIndex, string target, int targetStartIndex, StringComparison comparisonType)
        {
            var sourceLen = source.Length;
            if (startIndex < 0 && startIndex >= sourceLen)
                throw new ArgumentOutOfRangeException(ExceptionHelper.GetArgumentOutOfRangeMessage("startIndex", 0, true, sourceLen, false));

            var targetLen = target == null ? 0 : target.Length;
            if (targetStartIndex < 0 && targetStartIndex >= targetLen)
                throw new ArgumentOutOfRangeException(ExceptionHelper.GetArgumentOutOfRangeMessage("targetStartIndex", 0, true, targetLen, false));

            targetLen -= targetStartIndex;
            sourceLen -= startIndex;
            return sourceLen >= targetLen && string.Compare(source, startIndex, target, targetStartIndex, targetLen, comparisonType) == 0;
        }

        /// <summary>
        /// Determines if a substring of the current string instance starts with the target string specified by <paramref name="value" />.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="startIndex">The start position of the substring.</param>
        /// <param name="value">The string instance to compare.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the comparison.</param>
        /// <returns>
        ///   <c>true</c> if the specified substring starts with the target string; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when <paramref name="startIndex"/> is assigned an invalid value.</exception>
        public static bool StartsWith(this string source, int startIndex, string value, StringComparison comparisonType)
        {
            var sourceLen = source.Length;
            if (startIndex < 0 && startIndex >= sourceLen)
                throw new ArgumentOutOfRangeException(ExceptionHelper.GetArgumentOutOfRangeMessage("startIndex", 0, true, sourceLen, false));

            sourceLen -= startIndex;
            var targetLen = value == null ? 0 : value.Length;
            return sourceLen >= targetLen && string.Compare(source, startIndex, value, 0, targetLen, comparisonType) == 0;
        }

        /// <summary>
        /// Determines if the beginning of this string instance matches any element of the specified string sequence.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="values">The sequence of strings to compare.</param>
        /// <param name="comparisonType">Specifies how the beginning of this string is compared with strings in the specified sequence.</param>
        /// <returns><c>true</c> if any of the strings in the sequence matches the beginning of the current string instance; otherwise, <c>false</c>.</returns>
        public static string StartsWithAny(this string source, IEnumerable<string> values, StringComparison comparisonType = StringComparison.Ordinal)
        {
            foreach (var t in values)
            {
                if (t.IsNullOrEmpty()) continue;
                if (source.StartsWith(t, comparisonType))
                    return t;
            }
            return null;
        }
    }
}
