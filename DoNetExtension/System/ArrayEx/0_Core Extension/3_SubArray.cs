using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class ArrayEx
    {
        /// <summary>
        /// Retrieves a subarray from the current <see cref="System.Array"/> starting at a specified position.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">The current array.</param>
        /// <param name="offset">The position of the first element of the subarray.</param>
        /// <param name="length">The length of the subarray.</param>
        /// <returns>
        /// A subarray from the current array.
        /// </returns>
        public static T[] SubArray<T>(this T[] array, int offset, int length)
        {
            var output = new T[length];
            for (int i = 0, j = offset; i != length; ++i, ++j)
                output[i] = array[j];
            return output;
        }

        /// <summary>
        /// Retrieves a subarray from the current list starting at a specified position.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The current list.</param>
        /// <param name="offset">The position of the first element of the subarray.</param>
        /// <param name="length">The length of the subarray.</param>
        /// <returns>
        /// A subarray from the current list starting at the specified position.
        /// </returns>
        public static T[] SubArray<T>(this IList<T> list, int offset, int length)
        {
            var output = new T[length];
            for (int i = 0, j = offset; i != length; ++i, ++j)
                output[i] = list[j];

            return output;
        }

        /// <summary>
        /// Retrieves the first few elements of the current array.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">The current array.</param>
        /// <param name="length">The number of elements to retrieve.</param>
        /// <returns>
        /// A subarray containing the first few elements of the current array..
        /// </returns>
        public static T[] SubFirst<T>(this T[] array, int length)
        {
            var output = new T[length];

            for (int i = 0; i != length; ++i)
                output[i] = array[i];

            return output;
        }

        /// <summary>
        /// Retrieves the first few elements of the current list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The current list.</param>
        /// <param name="length">The number of elements to retrieve.</param>
        /// <returns>
        /// A subarray containing the first few elements of the current list..
        /// </returns>
        public static T[] SubFirst<T>(this IList<T> list, int length)
        {
            var output = new T[length];

            for (int i = 0; i != length; ++i)
                output[i] = list[i];

            return output;
        }

        /// <summary>
        /// Retrieves the last few elements of the current array.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">The current array.</param>
        /// <param name="length">The number of elements to retrieve.</param>
        /// <returns>
        /// A subarray containing the last few elements of the current array.
        /// </returns>
        public static T[] SubLast<T>(this T[] array, int length)
        {
            var output = new T[length];
            var arrLen = array.Length;
            for (int i = arrLen - length, j = 0; i != arrLen; ++i, ++j)
                output[j] = array[i];

            return output;
        }

        /// <summary>
        /// Retrieves the last few elements of the current list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The current list.</param>
        /// <param name="length">The number of elements to retrieve.</param>
        /// <returns>
        /// A subarray containing the last few elements of the current list.
        /// </returns>
        public static T[] SubLast<T>(this IList<T> list, int length)
        {
            var output = new T[length];
            var arrLen = list.Count;
            for (int i = arrLen - length, j = 0; i != arrLen; ++i, ++j)
                output[j] = list[i];

            return output;
        }
    }
}
