using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class StringEx
    {
        internal static int _innerIndexOf(string str, Func<char, bool> predicate, int startIndex, int endIndex)
        {
            while (startIndex < endIndex)
            {
                if (predicate(str[startIndex]))
                    return startIndex;
                ++startIndex;
            }
            return -1;
        }

        internal static int _innerIndexOfAny(string str, char[] anyOf, int startIndex, int endIndex, out int hitIndex)
        {
            while (startIndex < endIndex)
            {
                hitIndex = anyOf.IndexOf(str[startIndex]);
                if (hitIndex != -1) return startIndex;
                ++startIndex;
            }

            hitIndex = -1;
            return -1;
        }

        /// <summary>
        /// Reports the index of the first character satisfying the specified predicate. 
        /// The search starts at a specified character position toward the end of this string instance.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="startIndex">The search starting position. The search proceeds from <paramref name="startIndex"/> toward the end of this instance.</param>
        /// <param name="predicate">A function to test each character of the current string.</param>
        /// <returns>The zero-based index position of the first character in this instance satisfying the specified predicate.</returns>
        public static int IndexOf(this string str, Func<char, bool> predicate, int startIndex = 0)
        {
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, str.Length - 1, true);
            return _innerIndexOf(str, predicate, startIndex, str.Length);
        }

        /// <summary>
        /// Reports the index of the first character satisfying the specified predicate.
        /// The search starts at a specified character position and examines a specified number of character positions toward the end of this string instance.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each character of the current string.</param>
        /// <param name="startIndex">The search starting position. The search proceeds from <paramref name="startIndex" /> toward the end of this instance.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <returns>
        /// The zero-based index position of the first character in this instance satisfying the specified predicate.
        /// </returns>
        public static int IndexOf(this string str, Func<char, bool> predicate, int startIndex, int count)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, count, str.Length, "startIndex", "count");
            return _innerIndexOf(str, predicate, startIndex, endIndex);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence in this instance of any character in a specified array of Unicode characters <paramref name="anyOf"/>. 
        /// The search starts at a specified character position and examines a specified number of character positions.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <param name="hitIndex">Returns the index of the encountered character in the specified array of Unicode characters.</param>
        /// <returns>The zero-based index position of the first character in this instance satisfying the specified predicate.</returns>
        public static int IndexOfAny(this string str, char[] anyOf, int startIndex, int count, out int hitIndex)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, count, str.Length, "startIndex", "count");
            return _innerIndexOfAny(str, anyOf, startIndex, endIndex, out hitIndex);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence in this instance of any character in a specified array of Unicode characters <paramref name="anyOf"/>. 
        /// The search starts at a specified character position and examines a specified number of character positions.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="hitIndex">Returns the index of the encountered character in the specified array of Unicode characters.</param>
        /// <returns>The zero-based index position of the first character in this instance satisfying the specified predicate.</returns>
        public static int IndexOfAny(this string str, char[] anyOf, int startIndex, out int hitIndex)
        {
            ExceptionHelper.ArgumentRangeRequired("startIndex", startIndex, 0, true, str.Length - 1, true);
            return _innerIndexOfAny(str, anyOf, startIndex, str.Length, out hitIndex);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence in this instance of any character in a specified array of Unicode characters <paramref name="anyOf"/>. 
        /// The search starts at a specified character position and examines a specified number of character positions.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
        /// <param name="hitIndex">Returns the index of the encountered character in the specified array of Unicode characters.</param>
        /// <returns>The zero-based index position of the first character in this instance satisfying the specified predicate.</returns>
        public static int IndexOfAny(this string str, char[] anyOf, out int hitIndex)
        {
            return _innerIndexOfAny(str, anyOf, 0, str.Length, out hitIndex);
        }

        /// <summary>
        /// Reports the index of the first occurrence of any of the specified strings in this string instance.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="anyOf">A string array containing one or more strings to seek.</param>
        /// <param name="startIndex">Indicating the position where the search starts.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search.</param>
        /// <returns>
        /// A <see cref="StringSearchResult"/> object that stores the search result; null if the search fails.
        /// </returns>
        public static StringSearchResult IndexOfAny(this string str, IList<string> anyOf, int startIndex, int count, StringComparison comparisonType = StringComparison.Ordinal)
        {
            int pos;
            int minPos = int.MaxValue;
            string hitValue = null;
            var idx = 0;
            for (int i = 0, j = anyOf.Count; i < j; ++i)
            {
                var val = anyOf[i];
                if ((pos = str.IndexOf(val, startIndex, count, comparisonType)) != -1)
                {
                    if (minPos > pos)
                    {
                        minPos = pos;
                        hitValue = val;
                        idx = i;
                    }
                }
            }
            if (hitValue == null) return null;
            else return new StringSearchResult() { Value = hitValue, Position = minPos, HitIndex = idx };
        }

        /// <summary>
        /// Reports the index of the first occurrence of any of the specified strings in this string instance.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="anyOf">A string array containing one or more strings to seek.</param>
        /// <param name="startIndex">Indicating the position where the search starts.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search.</param>
        /// <returns>
        /// A <see cref="StringSearchResult"/> object that stores the search result; <c>null</c> if no element in the <paramref name="anyOf"/> is found in the current string.
        /// </returns>
        public static StringSearchResult IndexOfAny(this string str, IList<string> anyOf, int startIndex = 0, StringComparison comparisonType = StringComparison.Ordinal)
        {
            return IndexOfAny(str, anyOf, startIndex, str.Length - startIndex, comparisonType);
        }


        //public static int IndexOfAny(this string[] arr, string[] values, StringComparison comparisonType)
        //{
        //    var arrLen = arr.Length;
        //    for (int i = 0; i < arrLen; ++i)
        //    {
        //        var valueToCompare = arr[i];
        //        if (valueToCompare.In(values, comparisonType)) return i;
        //    }
        //    return -1;
        //}

        //public static int IndexOfAny(this string[] arr, string[] values, int startIndex, int length, StringComparison comparisonType)
        //{
        //    var arrLen = arr.Length;
        //    var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, arrLen);
        //    for (int i = startIndex; i < endIndex; ++i)
        //    {
        //        var valueToCompare = arr[i];
        //        if (valueToCompare.In(values, comparisonType)) return i;
        //    }
        //    return -1;
        //}
    }
}
