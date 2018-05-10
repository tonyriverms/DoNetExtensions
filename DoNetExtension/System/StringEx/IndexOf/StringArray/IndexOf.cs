using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public partial class StringEx
    {
        static int _innerIndexOf(string[] array, string value, int startIndex, int endIndex, StringComparison comparisonType)
        {
            for (int i = startIndex; i < endIndex; ++i)
            {
                var valueToCompare = array[i];
                if (valueToCompare.Equals(value, comparisonType)) return i;
            }
            return -1;
        }

        /// <summary>
        /// Searches for the specified <paramref name="value"/> and returns the index of the first occurrence within the entire one-dimensional string array.
        /// </summary>
        /// <param name="array">The current one-dimensional string array to search.</param>
        /// <param name="value">The string to locate in array.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search.</param>
        /// <returns>The index of the first occurrence of <paramref name="value"/> within the entire array, if found; otherwise, -1.</returns>
        public static int IndexOf(this string[] array, string value, StringComparison comparisonType = StringComparison.Ordinal)
        {
            return _innerIndexOf(array, value, 0, array.Length, comparisonType);
        }

        /// <summary>
        /// Searches for the specified string and returns the index of the first occurrence within the range of string elements in this one-dimensional string array that starts at the specified index.
        /// </summary>
        /// <param name="array">The one-dimensional string array to search.</param>
        /// <param name="value">The string to locate in this array.</param>
        /// <param name="startIndex">The starting index of the search. 0 (zero) is valid in an empty array.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search.</param>
        /// <returns>The index of the first occurrence of <paramref name="value"/> within the range of elements in array that starts at <paramref name="startIndex"/>, if found; otherwise, -1.</returns>
        public static int IndexOf(this string[] array, string value, int startIndex, StringComparison comparisonType = StringComparison.Ordinal)
        {
            ExceptionHelper.NonNegativeArgumentRequired("startIndex", startIndex);
            return _innerIndexOf(array, value, startIndex, array.Length, comparisonType);
        }

        /// <summary>
        /// Searches for the specified string and returns the index of the first occurrence within the range of string elements in this one-dimensional string array that starts at the specified index and contains the specified number of elements.
        /// </summary>
        /// <param name="array">The one-dimensional string array to search.</param>
        /// <param name="value">The string to locate in this array.</param>
        /// <param name="startIndex">The starting index of the search. 0 (zero) is valid in an empty array.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search.</param>
        /// <returns>The index of the first occurrence of <paramref name="value"/> within the range of elements in array that starts at <paramref name="startIndex"/> and contains the number of elements specified in <paramref name="count"/>, if found; otherwise, -1.</returns>
        public static int IndexOf(this string[] array, string value, int startIndex, int count, StringComparison comparisonType = StringComparison.Ordinal)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, count, array.Length);
            return _innerIndexOf(array, value, startIndex, endIndex, comparisonType);
        }
    }
}
