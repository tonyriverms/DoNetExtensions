using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class ArrayEx
    {
        static IEnumerator<T[]> _perm<T>(T[] array, int startIndex, int length)
        {
            if (length == 0) yield break;
            var subArr = array.SubArray(startIndex, length);
            yield return subArr.Copy();
            if (length == 1) yield break;

            int k;
            T tmp;
            var count = new int[length];
            var i = 1;

            do
            {
                if (count[i] < i)
                {
                    if (i % 2 == 0) k = 0;
                    else k = count[i];

                    tmp = subArr[k];
                    subArr[k] = subArr[i];
                    subArr[i] = tmp;

                    ++count[i];
                    i = 1;
                    yield return subArr.Copy();
                }
                else
                {
                    count[i] = 0;
                    ++i;
                }
            } while (i < length);
        }

        /// <summary>
        /// Gets an enumerator that traverse through all permutations of the current <see cref="System.Array"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current array.</typeparam>
        /// <param name="array">This <see cref="System.Array"/>.</param>
        /// <returns>An enumerator that traverse through all permutations of the current array.</returns>
        public static IEnumerator<T[]> GetPermutationEnumerator<T>(this T[] array)
        {
            var innerIE = _perm<T>(array, 0, array.Length);
            while (innerIE.MoveNext()) yield return innerIE.Current;
        }

        /// <summary>
        /// Gets an enumerator that traverse through all permutations of a sub-array (starting from the specified <paramref name="startIndex"/> to the end) of the current <see cref="System.Array" />.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current array.</typeparam>
        /// <param name="array">This <see cref="System.Array" />.</param>
        /// <param name="startIndex">The returned enumerator will go through all permutations of a sub-array starting from this index.</param>
        /// <returns>
        /// An enumerator that traverse through all permutations of a sub-array (starting from the element at the specified <paramref name="startIndex"/> to the end) of the current array.
        /// </returns>
        public static IEnumerator<T[]> GetPermutationEnumerator<T>(this T[] array, int startIndex)
        {
            ExceptionHelper.NonNegativeArgumentRequired("startIndex", startIndex);
            var innerIE = _perm<T>(array, startIndex, array.Length - startIndex);
            while(innerIE.MoveNext()) yield return innerIE.Current;
        }

        /// <summary>
        /// Gets an enumerator that traverse through all permutations of a sub-array (starting from the element at the specified <paramref name="startIndex" /> to the element at index <paramref name="startIndex" /> + <paramref name="length"/> - 1) of the current <see cref="System.Array" />.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current array.</typeparam>
        /// <param name="array">This <see cref="System.Array" />.</param>
        /// <param name="startIndex">The returned enumerator will go through all permutations of a sub-array starting from the element at this index to the element at index <paramref name="startIndex" /> + <paramref name="length"/> - 1.</param>
        /// <param name="length">The returned enumerator will go through all permutations of a sub-array starting from the element at <paramref name="startIndex" /> to the element at index <paramref name="startIndex" /> + <paramref name="length"/> - 1.</param>
        /// <returns>
        /// An enumerator that traverse through all permutations of a sub-array (starting from the specified <paramref name="startIndex" /> to the element at index <paramref name="startIndex" /> + <paramref name="length"/> - 1 of the current array.
        /// </returns>
        public static IEnumerator<T[]> GetPermutationEnumerator<T>(this T[] array, int startIndex, int length)
        {
            ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, array.Length);
            var innerIE = _perm<T>(array, startIndex, length);
            while (innerIE.MoveNext()) yield return innerIE.Current;
        }
    }
}
