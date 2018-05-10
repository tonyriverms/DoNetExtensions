using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public partial class StringEx
    {
        static ElementSearchResult<string> _innerIndexOfAny(string[] array, string[] values, int startIndex, int endIndex, StringComparison comparisonType)
        {
            for (int i = startIndex; i < endIndex; ++i)
            {
                var valueToCompare = array[i];
                var hitIndex = values.IndexOf(valueToCompare, comparisonType);
                if (hitIndex != -1) return new ElementSearchResult<string>() { HitIndex = hitIndex, Position = i, Value = valueToCompare };
            }
            return null;
        }

        /// <summary>
        /// Searches for any of the specified <paramref name="values"/> and returns the index of the first occurrence within the entire one-dimensional string array.
        /// </summary>
        /// <param name="array">The current one-dimensional string array to search.</param>
        /// <param name="values">The strings to locate in array.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search.</param>
        /// <returns>An <see cref="ElementSearchResult&lt;TElement&gt;"/> object that stores the index of the first occurrence of any of the <paramref name="values"/> within the entire array, if found; otherwise, <c>null</c>.</returns>
        public static ElementSearchResult<string> IndexOfAny(this string[] array, string[] values, StringComparison comparisonType = StringComparison.Ordinal)
        {
            return _innerIndexOfAny(array, values, 0, array.Length, comparisonType);
        }

        /// <summary>
        /// Searches for any of the specified strings and returns the index of the first occurrence within the range of string elements in this one-dimensional string array that starts at the specified index.
        /// </summary>
        /// <param name="array">The one-dimensional string array to search.</param>
        /// <param name="values">The strings to locate in this array.</param>
        /// <param name="startIndex">The starting index of the search. 0 (zero) is valid in an empty array.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search.</param>
        /// <returns>An <see cref="ElementSearchResult&lt;TElement&gt;"/> object that stores the index of the first occurrence of any of the <paramref name="values"/> within the range of elements in array that starts at <paramref name="startIndex"/>, if found; otherwise, <c>null</c>.</returns>
        public static ElementSearchResult<string> IndexOfAny(this string[] array, string[] values, int startIndex, StringComparison comparisonType = StringComparison.Ordinal)
        {
            ExceptionHelper.NonNegativeArgumentRequired("startIndex", startIndex);
            return _innerIndexOfAny(array, values, startIndex, array.Length, comparisonType);
        }

        /// <summary>
        /// Searches for any of the specified strings and returns the index of the first occurrence within the range of string elements in this one-dimensional string array that starts at the specified index and contains the specified number of elements.
        /// </summary>
        /// <param name="array">The one-dimensional string array to search.</param>
        /// <param name="values">The strings to locate in this array.</param>
        /// <param name="startIndex">The starting index of the search. 0 (zero) is valid in an empty array.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search.</param>
        /// <returns>An <see cref="ElementSearchResult&lt;TElement&gt;"/> object that stores the index of the first occurrence of any of the <paramref name="values"/> within the range of elements in array that starts at <paramref name="startIndex"/> and contains the number of elements specified in <paramref name="count"/>, if found; otherwise, <c>null</c>.</returns>
        public static ElementSearchResult<string> IndexOfAny(this string[] array, string[] values, int startIndex, int length, StringComparison comparisonType = StringComparison.Ordinal)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, array.Length);
            return _innerIndexOfAny(array, values, startIndex, endIndex, comparisonType);
        }
    }
}
