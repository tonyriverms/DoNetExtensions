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
        /// Determines if a substring of the current string instance 
        /// ends with the target string specified by <paramref name="value"/>.
        /// The method performs an ordinal comparison between strings.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="endIndex">The end position of the substring.</param>
        /// <param name="value">The string instance to compare.</param>
        /// <param name="ignoreCase">Indicates whether the comparison is case-sensitive.</param>
        /// <returns><c>true</c> if the specified substring ends with the target string; otherwise, <c>false</c>.</returns>
        public static bool EndsWith(this string source, int endIndex, string value, bool ignoreCase = false)
        {
            return EndsWith(source, endIndex, value, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
        }

        /// <summary>
        /// Determines if a substring of the current string instance
        /// ends with the target string (or a substring of this target string) specified by <paramref name="target" />.
        /// The method performs an ordinal comparison between strings.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="endIndex">The end position of the substring of the current string instance.</param>
        /// <param name="target">The target string instance to compare.</param>
        /// <param name="targetStartIndex">The start position of the substring of the target string instance.</param>
        /// <param name="targetLength">The length of the substring of the target string specified by <paramref name="target"/>.</param>
        /// <param name="ignoreCase">Indicates whether the comparison is case-sensitive.</param>
        /// <returns>
        ///   <c>true</c> if the specified substring ends with the target substring (or a substring of this target string); otherwise, <c>false</c>.
        /// </returns>
        public static bool EndsWith(this string source, int endIndex, string target, int targetStartIndex, int targetLength, bool ignoreCase = false)
        {
            return EndsWith(source, endIndex, target, targetStartIndex, targetLength, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
        }

        /// <summary>
        /// Determines if a substring of the current string instance
        /// ends with the target string (or a substring of this target string) specified by <paramref name="target" />.
        /// The method performs an ordinal comparison between strings.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="endIndex">The end position of the substring of the current string instance.</param>
        /// <param name="target">The target string instance to compare.</param>
        /// <param name="targetStartIndex">The start position of the substring of the target string instance.</param>
        /// <param name="ignoreCase">Indicates whether the comparison is case-sensitive.</param>
        /// <returns>
        ///   <c>true</c> if the specified substring ends with the target substring (or a substring of this target string); otherwise, <c>false</c>.
        /// </returns>
        public static bool EndsWith(this string source, int endIndex, string target, int targetStartIndex, bool ignoreCase = false)
        {
            return EndsWith(source, endIndex, target, targetStartIndex, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
        }

        /// <summary>
        /// Determines if a substring of the current string instance
        /// ends with the target string (or a substring of this target string) specified by <paramref name="target" />.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="endIndex">The end position of the substring of the current string instance.</param>
        /// <param name="target">The target string instance to compare.</param>
        /// <param name="targetStartIndex">The start position of the substring of the target string instance.</param>
        /// <param name="targetLength">The length of the substring of the target string specified by <paramref name="target" />.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the comparison.</param>
        /// <returns>
        ///   <c>true</c> if the specified substring ends with the target substring (or a substring of this target string); otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Occurs when at least one of <paramref name="endIndex"/>, <paramref name="targetStartIndex"/> and <paramref name="targetLength"/> is assigned an invalid value.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">Occurs when the argument <paramref name="target"/> is <c>null</c>.</exception>
        public static bool EndsWith(this string source, int endIndex, string target, int targetStartIndex, int targetLength, StringComparison comparisonType)
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
            if (endIndex < 0 && endIndex >= sourceLen) throw new ArgumentOutOfRangeException(ExceptionHelper.GetArgumentOutOfRangeMessage("startIndex", 0, true, sourceLen, false));

            if (targetLength != 0 && targetLength != 1) endIndex -= (targetLength - 1);
            if (endIndex < 0) return false;
            return string.Compare(source, endIndex, target, targetStartIndex, targetLength, comparisonType) == 0;
        }

        /// <summary>
        /// Determines if a substring of the current string instance
        /// ends with the target string (or a substring of this target string) specified by <paramref name="target" />.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="endIndex">The end position of the substring of the current string instance.</param>
        /// <param name="target">The target string instance to compare.</param>
        /// <param name="targetStartIndex">The start position of the substring of the target string instance.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the comparison.</param>
        /// <returns>
        ///   <c>true</c> if the specified substring ends with the target substring (or a substring of this target string); otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Occurs when either <paramref name="endIndex"/> or <paramref name="targetStartIndex"/> is assigned an invalid value.
        /// </exception>
        public static bool EndsWith(this string source, int endIndex, string target, int targetStartIndex, StringComparison comparisonType)
        {
            var sourceLen = source.Length;
            if (endIndex < 0 && endIndex >= sourceLen)
                throw new ArgumentOutOfRangeException(ExceptionHelper.GetArgumentOutOfRangeMessage("startIndex", 0, true, sourceLen, false));

            var targetLen = target == null ? 0 : target.Length;
            if (targetStartIndex < 0 && targetStartIndex >= targetLen)
                throw new ArgumentOutOfRangeException(ExceptionHelper.GetArgumentOutOfRangeMessage("targetStartIndex", 0, true, targetLen, false));

            targetLen -= targetStartIndex;
            if (targetLen != 0 && targetLen != 1) endIndex -= (targetLen - 1);
            if (endIndex < 0) return false;
            return string.Compare(source, endIndex, target, targetStartIndex, targetLen, comparisonType) == 0;
        }

        /// <summary>
        /// Determines if a substring of the current string instance ends with the target string specified by <paramref name="value" />.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="endIndex">The end position of the substring.</param>
        /// <param name="value">The string instance to compare.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the comparison.</param>
        /// <returns>
        ///   <c>true</c> if the specified substring ends with the target string; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when <paramref name="endIndex"/> is assigned an invalid value.</exception>
        public static bool EndsWith(this string source, int endIndex, string value, StringComparison comparisonType)
        {
            var sourceLen = source.Length;
            if (endIndex < 0 && endIndex >= sourceLen)
                throw new ArgumentOutOfRangeException(ExceptionHelper.GetArgumentOutOfRangeMessage("startIndex", 0, true, sourceLen, false));

            var targetLen = value == null ? 0 : value.Length;
            if(targetLen != 0 && targetLen != 1) endIndex -= (targetLen - 1);
            if (endIndex < 0) return false;

            return string.Compare(source, endIndex, value, 0, targetLen, comparisonType) == 0;
        }

        /// <summary>
        /// Determines if the end of this string instance matches any element of the specified string sequence.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="values">The sequence of strings to compare.</param>
        /// <param name="comparisonType">Specifies how the end of this string is compared with strings in the specified sequence.</param>
        /// <returns><c>true</c> if any of the strings in the sequence matches the end of the current string instance; otherwise, <c>false</c>.</returns>
        public static string EndsWithAny(this string source, IEnumerable<string> values,
            StringComparison comparisonType = StringComparison.Ordinal)
        {
            foreach (var t in values)
            {
                if (t.IsNullOrEmpty()) continue;
                if (source.EndsWith(t, comparisonType))
                    return t;
            }
            return null;
        }
    }
}
