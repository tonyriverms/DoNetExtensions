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
        /// Gets an enumerator that traverse through k-combinations of elements in the current <see cref="System.Array"/>. A k-combination is a subset of the current array which contains k elements. For example, {1,2,3}, {2,3,4}, etc., are the 3-combinations of integer array {1,2,3,4,5}. 
        /// </summary>
        /// <typeparam name="T">The type of elements in the current array.</typeparam>
        /// <param name="array">This array.</param>
        /// <param name="startIndex">The elements in the returned combinations will be limited to elements starting from this index and ending at <paramref name="startIndex"/> + <paramref name="length"/> - 1.</param>
        /// <param name="length">The elements in the returned combinations will be limited to elements starting from <paramref name="startIndex"/> and ending at <paramref name="startIndex"/> + <paramref name="length"/> - 1.</param>
        /// <param name="k">The number of elements of each combination returned by the enumerator.</param>
        /// <returns>An enumerator that traverse through k-combinations of elements in the current array.</returns>
        public static IEnumerator<T[]> GetCombinationEnumerator<T>(this T[] array, int startIndex, int length, int k)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, array.Length);
            ExceptionHelper.ArgumentRangeRequired<int>("k", k, 0, true, length, true);
            var innerIE = _combNonRecursive<T>(array, startIndex, endIndex, length, k);
            while (innerIE.MoveNext()) yield return innerIE.Current;
        }

        /// <summary>
        /// Gets an enumerator that traverse through k-combinations of elements in the current <see cref="System.Array"/>. A k-combination is a subset of the current array which contains k elements. For example, {1,2,3}, {2,3,4}, etc., are the 3-combinations of integer array {1,2,3,4,5}.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current array.</typeparam>
        /// <param name="array">This array.</param>
        /// <param name="startIndex">The elements in the returned combinations will be limited to elements starting from this index.</param>
        /// <param name="k">The number of elements of each combination returned by the enumerator.</param>
        /// <returns>
        /// An enumerator that traverse through k-combinations of elements in the current array.
        /// </returns>
        public static IEnumerator<T[]> GetCombinationEnumerator<T>(this T[] array, int startIndex, int k)
        {
            var endIndex = array.Length;
            ExceptionHelper.ArgumentRangeRequired<int>("startIndex", startIndex, 0, true, endIndex, false);

            var length = endIndex - startIndex;
            ExceptionHelper.ArgumentRangeRequired<int>("k", k, 0, true, length, true);
            var innerIE = _combNonRecursive<T>(array, startIndex, endIndex, length, k);
            while (innerIE.MoveNext()) yield return innerIE.Current;
        }

        /// <summary>
        /// Gets an enumerator that traverse through k-combinations of elements in the current <see cref="System.Array"/>. A k-combination is a subset of the current array which contains k elements. For example, {1,2,3}, {2,3,4}, etc., are the 3-combinations of integer array {1,2,3,4,5}.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current array.</typeparam>
        /// <param name="array">This array.</param>
        /// <param name="k">The number of elements of each combination returned by the enumerator.</param>
        /// <returns>
        /// An enumerator that traverse through k-combinations of elements in the current array.
        /// </returns>
        public static IEnumerator<T[]> GetCombinationEnumerator<T>(this T[] array, int k)
        {
            var endIndex = array.Length;
            ExceptionHelper.ArgumentRangeRequired<int>("k", k, 0, true, endIndex, true);
            var innerIE = _combNonRecursive<T>(array, 0, endIndex, endIndex, k);
            while (innerIE.MoveNext()) yield return innerIE.Current;
        }
    }
}
