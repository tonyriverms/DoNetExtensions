using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public partial class ArrayEx
    {
        public static int IndexOfSubArray<T>(this T[] src, T[] target)
        {
            var len1 = src.Length;
            var len2 = target.Length;
            if (len2 <= len1)
            {
                var end = len1 - len2;
                --len2;
                for (int i = 0; i <= end; ++i)
                {
                    int j = 0;
                    int k = i;

                    while(true)
                    {
                        if (!target[j].Equals(src[k])) break;
                        else if (j == len2) return i;

                        ++j;
                        ++k;
                    }
                }
            }

            return -1;
        }

        public static int IndexOfSubArray<T>(this T[] src, T[] target, Func<T, T, bool> comparer)
        {
            var len1 = src.Length;
            var len2 = target.Length;
            if (len2 <= len1)
            {
                var end = len1 - len2;
                --len2;
                for (int i = 0; i <= end; ++i)
                {
                    int j = 0;
                    int k = i;

                    while (true)
                    {
                        if (!comparer(target[j], src[k])) break;
                        else if (j == len2) return i;

                        ++j;
                        ++k;
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// Searches for the specified object and returns the index of the first occurrence within the entire one-dimensional array. NOTE that this method performs an equality comparison by calling each element's <c>Equals</c> method.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The current one-dimensional array to search.</param>
        /// <param name="value">The object to locate in array.</param>
        /// <returns>The index of the first occurrence of <paramref name="value"/> within the entire array, if found; otherwise, -1.</returns>
        /// <remarks>This is a dummy method of the <c>Array.IndexOf</c> method for convenience purpose.</remarks>
        /// <exception cref="System.ArgumentNullException"><paramref name="array"/> is null.</exception>
        public static int IndexOf<T>(this T[] array, T value)
        {
            return Array.IndexOf(array, value);
        }

        /// <summary>
        /// Searches for the specified object and returns the index of the first occurrence within the range of elements in this one-dimensional Array that starts at the specified index. NOTE that this method performs an equality comparison by calling each element's <c>Equals</c> method.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The one-dimensional array to search.</param>
        /// <param name="value">The object to locate in this array.</param>
        /// <param name="startIndex">The starting index of the search. 0 (zero) is valid in an empty array.</param>
        /// <returns>The index of the first occurrence of value within the range of elements in array that starts at <paramref name="startIndex"/>, if found; otherwise, -1.</returns>
        /// <remarks>This is a dummy method of the <c>Array.IndexOf</c> method for convenience purpose.</remarks>
        /// <exception cref="System.ArgumentNullException"><paramref name="array"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="startIndex"/> is outside the range of valid indexes for array.</exception>
        public static int IndexOf<T>(this T[] array, T value, int startIndex)
        {
            return Array.IndexOf(array, value, startIndex);
        }

        /// <summary>
        /// Searches for the specified object and returns the index of the first occurrence within the range of elements in this one-dimensional Array that starts at the specified index and contains the specified number of elements. NOTE that this method performs an equality comparison by calling each element's <c>Equals</c> method.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The one-dimensional array to search.</param>
        /// <param name="value">The object to locate in this array.</param>
        /// <param name="startIndex">The starting index of the search. 0 (zero) is valid in an empty array.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The index of the first occurrence of value within the range of elements in array that starts at <paramref name="startIndex"/> and contains the number of elements specified in <paramref name="count"/>, if found; otherwise, -1.</returns>
        /// <remarks>This is a dummy method of the <c>Array.IndexOf</c> method for convenience purpose.</remarks>
        /// <exception cref="System.ArgumentNullException"><paramref name="array"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="startIndex"/> is outside the range of valid indexes for array; or <paramref name="count"/> is less than zero; or <paramref name="startIndex"/> and <paramref name="count"/> do not specify a valid section in array.</exception>
        public static int IndexOf<T>(this T[] array, T value, int startIndex, int count)
        {
            return Array.IndexOf(array, value, startIndex, count);
        }

        /// <summary>
        /// Searches for the specified object and returns the index of the first occurrence within the entire one-dimensional <see cref="System.Array"/>. NOTE that this method performs an equality comparison by calling each element's <c>Equals</c> method.
        /// </summary>
        /// <param name="array">The current one-dimensional <see cref="System.Array"/> to search.</param>
        /// <param name="obj">The object to locate in array.</param>
        /// <returns>The index of the first occurrence of value within the entire array, if found; otherwise, the lower bound of the array minus 1, typically -1.</returns>
        /// <remarks>This is a dummy method of the <c>Array.IndexOf</c> method for convenience purpose.</remarks>
        /// <exception cref="System.ArgumentNullException"><paramref name="array"/> is null.</exception>
        /// <exception cref="System.RankException"><paramref name="array"/> is multidimensional.</exception>
        public static int IndexOf<T>(this Array array, object obj)
        {
            return Array.IndexOf(array, obj);
        }

        /// <summary>
        /// Searches for the specified object and returns the index of the first occurrence within the range of elements in this one-dimensional Array that starts at the specified index. NOTE that this method performs an equality comparison by calling each element's <c>Equals</c> method.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="Array" /> to search.</param>
        /// <param name="value">The object to locate in this array.</param>
        /// <param name="startIndex">The starting index of the search. 0 (zero) is valid in an empty array.</param>
        /// <returns>The index of the first occurrence of value within the range of elements in array that starts at <paramref name="startIndex"/>, if found; otherwise, the lower bound of the array minus 1 (typically -1).</returns>
        /// <remarks>This is a dummy method of the <c>Array.IndexOf</c> method for convenience purpose.</remarks>
        /// <exception cref="System.ArgumentNullException"><paramref name="array"/> is null.</exception>
        /// <exception cref="System.RankException"><paramref name="array"/> is multidimensional.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="startIndex"/> is outside the range of valid indexes for array.</exception>
        public static int IndexOf(this Array array, object value, int startIndex)
        {
            return Array.IndexOf(array, value, startIndex);
        }

        /// <summary>
        /// Searches for the specified object and returns the index of the first occurrence within the range of elements in this one-dimensional Array that starts at the specified index and contains the specified number of elements. NOTE that this method performs an equality comparison by calling each element's <c>Equals</c> method.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="Array" /> to search.</param>
        /// <param name="value">The object to locate in this array.</param>
        /// <param name="startIndex">The starting index of the search. 0 (zero) is valid in an empty array.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The index of the first occurrence of value within the range of elements in array that starts at <paramref name="startIndex"/> and contains the number of elements specified in <paramref name="count"/>, if found; otherwise, the lower bound of the array minus 1 (typically -1).</returns>
        /// <remarks>This is a dummy method of the <c>Array.IndexOf</c> method for convenience purpose.</remarks>
        /// <exception cref="System.ArgumentNullException"><paramref name="array"/> is null.</exception>
        /// <exception cref="System.RankException"><paramref name="array"/> is multidimensional.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="startIndex"/> is outside the range of valid indexes for array; or <paramref name="count"/> is less than zero; or <paramref name="startIndex"/> and <paramref name="count"/> do not specify a valid section in array.</exception>
        public static int IndexOf(this Array array, object value, int startIndex, int count)
        {
            return Array.IndexOf(array, value, startIndex, count);
        }
    }
}
