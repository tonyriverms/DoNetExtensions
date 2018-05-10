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
        /// Gets an enumerator that traverse through combinations of elements in the current <see cref="System.Array"/>. A combination is a subset of the current array. For example, {1,2,3}, {2,3,4}, etc., are the 3-combinations of integer array {1,2,3,4,5}, while {1,2}, {3,4} are its 2-combinations.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current array.</typeparam>
        /// <param name="array">This array.</param>
        /// <param name="startIndex">The elements in the returned combinations will be limited to elements starting from this index and ending at <paramref name="startIndex" /> + <paramref name="length" /> - 1.</param>
        /// <param name="length">The elements in the returned combinations will be limited to elements starting from <paramref name="startIndex" /> and ending at <paramref name="startIndex" /> + <paramref name="length" /> - 1.</param>
        /// <param name="startK">The minimum number of elements of each combination returned by the enumerator if <paramref name="startK"/> is no larger than <paramref name="endK"/>; otherwise, the maximum number of elements of each combination returned by the enumerator.</param>
        /// <param name="endK">The maximum number of elements of each combination returned by the enumerator if <paramref name="startK"/> is no larger than <paramref name="endK"/>; otherwise, the minimum number of elements of each combination returned by the enumerator.</param>
        /// <returns>
        /// An enumerator that traverse through combinations of elements in the current array.
        /// </returns>
        public static IEnumerator<T[]> GetMultiCombinationEnumerator<T>(this T[] array, int startIndex, int length, int startK, int endK)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, array.Length);
            ExceptionHelper.ArgumentRangeRequired<int>("startK", startK, 0, true, length, true);
            ExceptionHelper.ArgumentRangeRequired<int>("endK", endK, 0, true, length, true);

            var innerIE = _combNonRecursive<T>(array, startIndex, endIndex, length, 0, startK, endK);
            while (innerIE.MoveNext()) yield return innerIE.Current;
        }

        /// <summary>
        /// Gets an enumerator that traverse through combinations of elements in the current <see cref="System.Array"/>. A combination is a subset of the current array. For example, {1,2,3}, {2,3,4}, etc., are the 3-combinations of integer array {1,2,3,4,5}, while {1,2}, {3,4} are its 2-combinations.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current array.</typeparam>
        /// <param name="array">This array.</param>
        /// <param name="startIndex">The elements in the returned combinations will be limited to elements starting from this index and ending at <paramref name="startIndex" /> + <paramref name="length" /> - 1.</param>
        /// <param name="length">The elements in the returned combinations will be limited to elements starting from <paramref name="startIndex" /> and ending at <paramref name="startIndex" /> + <paramref name="length" /> - 1.</param>
        /// <param name="startK">The minimum number of elements of each combination returned by the enumerator if <paramref name="startK" /> is no larger than <paramref name="endK" />; otherwise, the maximum number of elements of each combination returned by the enumerator.</param>
        /// <param name="endK">The maximum number of elements of each combination returned by the enumerator if <paramref name="startK" /> is no larger than <paramref name="endK" />; otherwise, the minimum number of elements of each combination returned by the enumerator.</param>
        /// <param name="returnLimits">Limits the number of combinations the returned enumerator can go through. The first element of this array limits the number of returned <paramref name="startK"/>-combinations, the second element limits the number of returned (<paramref name="startK"/>+1)-combinations (or (<paramref name="startK"/>-1)-combinations if <paramref name="startK"/> is larger than <paramref name="endK"/>), and so forth. NOTE that if k-combination has no corresponding return limit, in which case the length of <paramref name="returnLimits"/> is smaller than k - <paramref name="startK"/> + 1, then the number of returned k-combinations will not be limited.
        /// <para>For example, if the current array is {1,2,3,4,5}, and <paramref name="startIndex"/> is 0, <paramref name="length"/> 5, <paramref name="startK"/> 2, <paramref name="endK"/> 3, <paramref name="returnLimits"/> {2,3}, then returned enumerator will go through {1,2}, {1,3}, {1,2,3}, {1,2,4}, {1,2,5}. If <paramref name="endK"/> is changed to 4, then all 4-combinations {1,2,3,4},{1,2,3,5},{1,2,4,5},{1,3,4,5},{2,3,4,5} will be returned by the enumerator since there is no limit on 4-combinations.</para>
        /// </param>
        /// <returns>
        /// An enumerator that traverse through combinations of elements in the current array.
        /// </returns>
        public static IEnumerator<T[]> GetMultiCombinationEnumerator<T>(this T[] array, int startIndex, int length, int startK, int endK, int[] returnLimits)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, array.Length);
            ExceptionHelper.ArgumentRangeRequired<int>("startK", startK, 0, true, length, true);
            ExceptionHelper.ArgumentRangeRequired<int>("endK", endK, 0, true, length, true);

            var innerIE = _combNonRecursive<T>(array, startIndex, endIndex, length, 0, startK, endK, returnLimits);
            while (innerIE.MoveNext()) yield return innerIE.Current;
        }

        /// <summary>
        /// Gets an enumerator that traverse through combinations of elements in the current <see cref="System.Array"/>. A combination is a subset of the current array. For example, {1,2,3}, {2,3,4}, etc., are the 3-combinations of integer array {1,2,3,4,5}, while {1,2}, {3,4} are its 2-combinations.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current array.</typeparam>
        /// <param name="array">This array.</param>
        /// <param name="startIndex">The elements in the returned combinations will be limited to elements starting from this index.</param>
        /// <param name="startK">The minimum number of elements of each combination returned by the enumerator if <paramref name="startK" /> is no larger than <paramref name="endK" />; otherwise, the maximum number of elements of each combination returned by the enumerator.</param>
        /// <param name="endK">The maximum number of elements of each combination returned by the enumerator if <paramref name="startK" /> is no larger than <paramref name="endK" />; otherwise, the minimum number of elements of each combination returned by the enumerator.</param>
        /// <returns>
        /// An enumerator that traverse through combinations of elements in the current array.
        /// </returns>
        public static IEnumerator<T[]> GetMultiCombinationEnumerator<T>(this T[] array, int startIndex, int startK, int endK)
        {
            var endIndex = array.Length;
            ExceptionHelper.ArgumentRangeRequired<int>("startIndex", startIndex, 0, true, endIndex, false);

            var length = endIndex - startIndex;
            ExceptionHelper.ArgumentRangeRequired<int>("startK", startK, 0, true, length, true);
            ExceptionHelper.ArgumentRangeRequired<int>("endK", endK, 0, true, length, true);

            var innerIE = _combNonRecursive<T>(array, startIndex, endIndex, length, 0, startK, endK);
            while (innerIE.MoveNext()) yield return innerIE.Current;
        }

        /// <summary>
        /// Gets an enumerator that traverse through combinations of elements in the current <see cref="System.Array"/>. A combination is a subset of the current array. For example, {1,2,3}, {2,3,4}, etc., are the 3-combinations of integer array {1,2,3,4,5}, while {1,2}, {3,4} are its 2-combinations.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current array.</typeparam>
        /// <param name="array">This array.</param>
        /// <param name="startIndex">The elements in the returned combinations will be limited to elements starting from this index.</param>
        /// <param name="startK">The minimum number of elements of each combination returned by the enumerator if <paramref name="startK" /> is no larger than <paramref name="endK" />; otherwise, the maximum number of elements of each combination returned by the enumerator.</param>
        /// <param name="endK">The maximum number of elements of each combination returned by the enumerator if <paramref name="startK" /> is no larger than <paramref name="endK" />; otherwise, the minimum number of elements of each combination returned by the enumerator.</param>
        /// <param name="returnLimits">Limits the number of combinations the returned enumerator can go through. The first element of this array limits the number of returned  <paramref name="startK" />-combinations, the second element limits the number of returned (<paramref name="startK" />+1)-combinations (or (<paramref name="startK" />-1)-combinations if <paramref name="startK" /> is larger than <paramref name="endK" />), and so forth. NOTE that if k-combination has no corresponding return limit, in which case the length of <paramref name="returnLimits" /> is smaller than k - <paramref name="startK" /> + 1, then the number of returned k-combinations will not be limited.
        /// <para>For example, if the current array is {1,2,3,4,5}, and <paramref name="startIndex" /> is 0, <paramref name="length" /> 5, <paramref name="startK" /> 2, <paramref name="endK" /> 3, <paramref name="returnLimits" /> {2,3}, then returned enumerator will go through {1,2}, {1,3}, {1,2,3}, {1,2,4}, {1,2,5}. If <paramref name="endK" /> is changed to 4, then all 4-combinations {1,2,3,4},{1,2,3,5},{1,2,4,5},{1,3,4,5},{2,3,4,5} will be returned by the enumerator since there is no limit on 4-combinations.</para>
        /// </param>
        /// <returns>
        /// An enumerator that traverse through combinations of elements in the current array.
        /// </returns>
        public static IEnumerator<T[]> GetMultiCombinationEnumerator<T>(this T[] array, int startIndex, int startK, int endK, int[] returnLimits)
        {
            var endIndex = array.Length;
            ExceptionHelper.ArgumentRangeRequired<int>("startIndex", startIndex, 0, true, endIndex, false);

            var length = endIndex - startIndex;
            ExceptionHelper.ArgumentRangeRequired<int>("startK", startK, 0, true, length, true);
            ExceptionHelper.ArgumentRangeRequired<int>("endK", endK, 0, true, length, true);

            var innerIE = _combNonRecursive<T>(array, startIndex, endIndex, length, 0, startK, endK, returnLimits);
            while (innerIE.MoveNext()) yield return innerIE.Current;
        }

        /// <summary>
        /// Gets an enumerator that traverse through combinations of elements in the current <see cref="System.Array"/>. A combination is a subset of the current array. For example, {1,2,3}, {2,3,4}, etc., are the 3-combinations of integer array {1,2,3,4,5}, while {1,2}, {3,4} are its 2-combinations.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current array.</typeparam>
        /// <param name="array">This array.</param>
        /// <param name="startK">The minimum number of elements of each combination returned by the enumerator if <paramref name="startK" /> is no larger than <paramref name="endK" />; otherwise, the maximum number of elements of each combination returned by the enumerator.</param>
        /// <param name="endK">The maximum number of elements of each combination returned by the enumerator if <paramref name="startK" /> is no larger than <paramref name="endK" />; otherwise, the minimum number of elements of each combination returned by the enumerator.</param>
        /// <returns>
        /// An enumerator that traverse through combinations of elements in the current array.
        /// </returns>
        public static IEnumerator<T[]> GetMultiCombinationEnumerator<T>(this T[] array, int startK, int endK)
        {
            var endIndex = array.Length;
            ExceptionHelper.ArgumentRangeRequired<int>("startK", startK, 0, true, endIndex, true);
            ExceptionHelper.ArgumentRangeRequired<int>("endK", endK, 0, true, endIndex, true);

            var innerIE = _combNonRecursive<T>(array, 0, endIndex, endIndex, 0, startK, endK);
            while (innerIE.MoveNext()) yield return innerIE.Current;
        }

        /// <summary>
        /// Gets an enumerator that traverse through combinations of elements in the current <see cref="System.Array"/>. A combination is a subset of the current array. For example, {1,2,3}, {2,3,4}, etc., are the 3-combinations of integer array {1,2,3,4,5}, while {1,2}, {3,4} are its 2-combinations.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current array.</typeparam>
        /// <param name="array">This array.</param>
        /// <param name="startK">The minimum number of elements of each combination returned by the enumerator if <paramref name="startK" /> is no larger than <paramref name="endK" />; otherwise, the maximum number of elements of each combination returned by the enumerator.</param>
        /// <param name="endK">The maximum number of elements of each combination returned by the enumerator if <paramref name="startK" /> is no larger than <paramref name="endK" />; otherwise, the minimum number of elements of each combination returned by the enumerator.</param>
        /// <param name="returnLimits">Limits the number of combinations the returned enumerator can go through. The first element of this array limits the number of returned <paramref name="startK" />-combinations, the second element limits the number of returned (<paramref name="startK" />+1)-combinations (or (<paramref name="startK" />-1)-combinations if <paramref name="startK" /> is larger than <paramref name="endK" />), and so forth. NOTE that if k-combination has no corresponding return limit, in which case the length of <paramref name="returnLimits" /> is smaller than k - <paramref name="startK" /> + 1, then the number of returned k-combinations will not be limited.
        /// <para>For example, if the current array is {1,2,3,4,5}, and <paramref name="startIndex" /> is 0, <paramref name="length" /> 5, <paramref name="startK" /> 2, <paramref name="endK" /> 3, <paramref name="returnLimits" /> {2,3}, then returned enumerator will go through {1,2}, {1,3}, {1,2,3}, {1,2,4}, {1,2,5}. If <paramref name="endK" /> is changed to 4, then all 4-combinations {1,2,3,4},{1,2,3,5},{1,2,4,5},{1,3,4,5},{2,3,4,5} will be returned by the enumerator since there is no limit on 4-combinations.</para>
        /// </param>
        /// <returns>
        /// An enumerator that traverse through combinations of elements in the current array.
        /// </returns>
        public static IEnumerator<T[]> GetMultiCombinationEnumerator<T>(this T[] array, int startK, int endK, int[] returnLimits)
        {
            var endIndex = array.Length;
            ExceptionHelper.ArgumentRangeRequired<int>("startK", startK, 0, true, endIndex, true);
            ExceptionHelper.ArgumentRangeRequired<int>("endK", endK, 0, true, endIndex, true);

            var innerIE = _combNonRecursive<T>(array, 0, endIndex, endIndex, 0, startK, endK, returnLimits);
            while (innerIE.MoveNext()) yield return innerIE.Current;
        }
    }
}
