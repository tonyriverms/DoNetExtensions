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
        /// Reports the index of the last character satisfying the specified predicate. 
        /// The search starts at a specified character position toward the beginning of this string instance.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="startIndex">The search starting position. The search proceeds from <paramref name="startIndex"/> toward the end of this instance.</param>
        /// <param name="predicate">A function to test each character of the current string.</param>
        /// <returns>The zero-based index position of the last character in this instance satisfying the specified predicate.</returns>
        public static int LastIndexOf(this string str, Func<char, bool> predicate, int startIndex)
        {
            for (var i = startIndex; i >= 0; --i)
            {
                if (predicate(str[i]))
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Reports the index of the last character satisfying the specified predicate.
        /// The search starts at a specified character position and examines a specified number of character positions toward the beginning of this string instance.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each character of the current string.</param>
        /// <param name="startIndex">The search starting position. The search proceeds from <paramref name="startIndex" /> toward the beginning of this instance.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <returns>
        /// The zero-based index position of the last character in this instance satisfying the specified predicate.
        /// </returns>
        public static int LastIndexOf(this string str, Func<char, bool> predicate, int startIndex, int count)
        {
            if (count < 0) throw new ArgumentOutOfRangeException(ExceptionHelper.GetNonNegativeArgumentRequiredMessage("count"));
            if (startIndex < 0) throw new ArgumentOutOfRangeException(ExceptionHelper.GetArgumentOutOfRangeMessage("startIndex", 0, true, str.Length - 1, true));
            var endIndex = startIndex - count;
            if (endIndex < 0) throw new ArgumentOutOfRangeException(ExceptionHelper.GetArgumentOutOfRangeMessage("count", 0, true, startIndex, true));

            for (var i = startIndex; i >= endIndex; --i)
            {
                if (predicate(str[i]))
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Reports the index of the last occurrence of any of the specified strings in this string instance.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="anyOf">A string array containing one or more strings to seek.</param>
        /// <param name="startIndex">Indicating the position where the search starts.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search.</param>
        /// <returns>
        /// A <see cref="StringSearchResult"/> object that stores the search result; null if none of the <paramref name="anyOf"/> is found in the current string.
        /// </returns>
        public static StringSearchResult LastIndexOfAny(this string str, IList<string> anyOf, int startIndex, int count, StringComparison comparisonType = StringComparison.Ordinal)
        {
            var hitPosition = -1;
            var idx = 0;
            string hitValue = null;

            for (int i = 0, j = anyOf.Count; i < j; ++i)
            {
                var val = anyOf[i];
                int pos;
                if ((pos = str.LastIndexOf(val, startIndex, count, comparisonType)) != -1)
                {
                    if (hitPosition < pos)
                    {
                        hitPosition = pos;
                        hitValue = val;
                        idx = i;
                    }
                }
            }
            if (hitValue == null) return null;
            else return new StringSearchResult() { Value = hitValue, Position = hitPosition, HitIndex = idx };
        }

        /// <summary>
        /// Reports the index of the last occurrence of any of the specified strings in this string instance.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="anyOf">A string array containing one or more strings to seek.</param>
        /// <param name="startIndex">Indicating the position where the search starts. The search proceeds from startIndex toward the beginning of this instance.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search.</param>
        /// <returns>
        /// A <see cref="StringSearchResult"/> object that stores the search result; null if none of the <paramref name="anyOf"/> is found in the current string.
        /// </returns>
        public static StringSearchResult LastIndexOfAny(this string str, IList<string> anyOf, int startIndex, StringComparison comparisonType = StringComparison.Ordinal)
        {
            return LastIndexOfAny(str, anyOf, startIndex, str.Length - startIndex, comparisonType);
        }

    }
}
