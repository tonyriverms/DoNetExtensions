using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class ArrayEx
    {

        /// <summary>
        /// Copies the elements in the sequence to an array.
        /// </summary>
        /// <typeparam name="T">The type of elements in the output array.</typeparam>
        /// <param name="enumerable">An enumerable sequence.</param>
        /// <returns>A new array containing the elements copied from the enumerable sequence.</returns>
        public static T[] ToArray<T>(this IEnumerable enumerable)
        {
            var list = new List<T>();
            foreach (object obj in enumerable)
                list.Add((T)(obj));
            return list.ToArray();
        }

        /// <summary>
        /// Converts and copies the elements in the sequence (treated as <typeparamref name="T"/>) to an array of type <typeparamref name="TOut"/>.
        /// </summary>
        /// <typeparam name="T">The elements in the current sequence are treated as this type.</typeparam>
        /// <typeparam name="TOut">The type of elements in the output array.</typeparam>
        /// <param name="enumerable">An enumerable sequence of type <typeparamref name="TOut"/>.</param>
        /// <param name="func">The method to convert each element in the sequence to type <typeparamref name="TOut"/>.</param>
        /// <param name="excludesNull"><c>true</c> if <c>null</c> refrences in the sequence are ignored; otherwise the <c>null</c> reference will be preserved in the ouptut array.</param>
        /// <returns>A new array containing the elements copied and converted from the enumerable sequence.</returns>
        public static TOut[] ToArray<T, TOut>(this IEnumerable enumerable, Func<T, TOut> func, bool excludesNull = true)
        {
            var list = new List<TOut>();
            foreach (var obj in enumerable)
            {
                var output = func((T)obj);
                if (output != null)
                    list.Add(output);
            }

            return list.ToArray();
        }

        /// <summary>
        /// Copies the REMAINING elements to a new array.
        /// <para>NOTE that this method only copies the elements not yet enumerated by this <see cref="System.Collections.Generic.IEnumerator{T}"/> to the new array. To copy all elements, you may call the <c>Reset</c> method of the enumerator first. After copying elements to the array, the enumerator can no longer <c>MoveNext</c> unless you call <c>Reset</c>.</para>
        /// </summary>
        /// <typeparam name="T">The type of elements enumerated by the enumerator.</typeparam>
        /// <param name="enumerator">The current enumerator.</param>
        /// <returns>A new array containing the elements not yet enumerated by the enumerator before the execution of this method.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] ToArray<T>(this IEnumerator<T> enumerator)
        {
            var list = new List<T>();
            while (enumerator.MoveNext())
                list.Add(enumerator.Current);
            return list.ToArray();
        }

        /// <summary>
        /// Copies the REMAINING elements to a new array up to a maximum number specified by <paramref name="maxCopy" />.
        /// <para>NOTE that this method only copies the elements not yet enumerated by this <see cref="System.Collections.Generic.IEnumerator{T}" /> to the new array. If the number of remainig elements are more than <paramref name="maxCopy" />, which limits the maximum number of elements to be copied, then the method terminates and returns the array when that limit is reached; if the number of remainig elements are less than <paramref name="maxCopy" />, the method terminates when all remaining elements are copied to the new array.</para>
        /// </summary>
        /// <typeparam name="T">The type of elements enumerated by the enumerator.</typeparam>
        /// <param name="enumerator">The current enumerator.</param>
        /// <param name="maxCopy">The maximum number of elements to return. If the number of remaining elements are less than this argument, then the number of actually returned elements will be less than this argument.</param>
        /// <returns>A new array containing the elements not yet enumerated by the enumerator before the execution of this method. The length of this returned array is up to <paramref name="maxCopy" />.</returns>
        public static T[] ToArray<T>(this IEnumerator<T> enumerator, int maxCopy)
        {
            var list = new List<T>(maxCopy);
            int i = 0;
            while (i < maxCopy && enumerator.MoveNext())
            {
                list.Add(enumerator.Current);
                ++i;
            }
            return list.ToArray();
        }

        /// <summary>
        /// Converts the REMAINING elements of type <typeparamref name="T1"/> to objects of another type <typeparamref name="T2"/> and output the conversion results to a new array.
        /// <para>NOTE that this method only processes the elements not yet enumerated by this <see cref="System.Collections.Generic.IEnumerator&lt;T1&gt;"/> to the new array. To process all elements, you may call the <c>Reset</c> method of the enumerator first. After the execution of this method, the enumerator can no longer <c>MoveNext</c> unless you call <c>Reset</c>.</para>
        /// </summary>
        /// <typeparam name="T1">The type of elements enumerated by the enumerator.</typeparam>
        /// <typeparam name="T2">The type of elements in the returned array.</typeparam>
        /// <param name="enumerator">The current enumerator.</param>
        /// <param name="converter">Provides a method to convert elements enumerated by the enumerator.</param>
        /// <returns>A new array of type <typeparamref name="T2"/> containing objects converted from the elements not yet enumerated by the enumerator before the execution of this method.</returns>
        public static T2[] ToArray<T1, T2>(this IEnumerator<T1> enumerator, Func<T1, T2> converter)
        {
            if (converter == null) throw new ArgumentNullException("converter");
            var list = new List<T2>();
            while (enumerator.MoveNext())
                list.Add(converter(enumerator.Current));
            return list.ToArray();
        }

        /// <summary>
        /// Copies the REMAINING elements of the specified <paramref name="offsets"/> to a new array.
        /// <para>NOTE that this method only copies the elements not yet enumerated by this <see cref="System.Collections.Generic.IEnumerator{T}"/> to the new array. To copy all elements, you may call the <c>Reset</c> method of the enumerator first. After copying elements to the array, the enumerator can no longer <c>MoveNext</c> unless you call <c>Reset</c>.</para>
        /// </summary>
        /// <typeparam name="T">The type of elements enumerated by the enumerator.</typeparam>
        /// <param name="enumerator">The current enumerator.</param>
        /// <param name="offsets">An element of any of these specified offsets will be copied to the array. For example, an element of offset 0 is the element at the enumerator's current position; an element of offset 1 is the element next to the enumerator's current position; an element of offset 2 is the element next to the element of offset 1; and so forth.</param>
        /// <returns>A new array containing the elements not yet enumerated by the enumerator before the execution of this method.</returns>
        public static T[] ToArray<T>(this IEnumerator<T> enumerator, int[] offsets)
        {
            if (offsets == null)
                return enumerator.ToArray();
            else
            {
                int j = 0;
                var list = new List<T>();
                while (enumerator.MoveNext())
                {
                    if (j.In(offsets))
                        list.Add(enumerator.Current);
                    ++j;
                }
                return list.ToArray();
            }
        }

        /// <summary>
        /// Copies the REMAINING elements to a new array.
        /// <para>NOTE that this method only copies the elements not yet enumerated by this <see cref="System.Collections.IEnumerator"/> to the new array. To copy all elements, you may call the <c>Reset</c> method of the enumerator first. After copying elements to the array, the enumerator can no longer <c>MoveNext</c> unless you call <c>Reset</c>.</para>
        /// </summary>
        /// <typeparam name="T">The type of elements enumerated by the enumerator.</typeparam>
        /// <param name="enumerator">The current enumerator.</param>
        /// <returns>A new array containing the elements not yet enumerated by the enumerator before the execution of this method.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object[] ToArray(this IEnumerator enumerator)
        {
            var list = new List<object>();
            while (enumerator.MoveNext())
                list.Add(enumerator.Current);
            return list.ToArray();
        }

        /// <summary>
        /// Converts the REMAINING element of the current <see cref="System.Collections.IEnumerator"/> to objects of another type <typeparamref name="T"/> and output the conversion results to a new array.
        /// <para>NOTE that this method only processes the elements not yet enumerated by this <see cref="System.Collections.IEnumerator"/> to the new array. To process all elements, you may call the <c>Reset</c> method of the enumerator first. After the execution of this method, the enumerator can no longer <c>MoveNext</c> unless you call <c>Reset</c>.</para>
        /// </summary>
        /// <typeparam name="T">The type of elements in the returned array.</typeparam>
        /// <param name="enumerator">The current <see cref="System.Collections.IEnumerator"/>.</param>
        /// <param name="converter">Provides a method to convert elements enumerated by the enumerator.</param>
        /// <returns>A new array of type <typeparamref name="T"/> containing objects converted from the elements not yet enumerated by the enumerator before the execution of this method.</returns>
        public static T[] ToArray<T>(this IEnumerator enumerator, Func<object, T> converter)
        {
            if (converter == null) throw new ArgumentNullException("converter");
            var list = new List<T>();
            while (enumerator.MoveNext())
                list.Add(converter(enumerator.Current));
            return list.ToArray();
        }

        /// <summary>
        /// Copies the REMAINING elements of the specified <paramref name="offsets"/> to a new array.
        /// <para>NOTE that this method only copies the elements not yet enumerated by this <see cref="System.Collections.IEnumerator"/> to the new array. To copy all elements, you may call the <c>Reset</c> method of the enumerator first. After copying elements to the array, the enumerator can no longer <c>MoveNext</c> unless you call <c>Reset</c>.</para>
        /// </summary>
        /// <typeparam name="T">The type of elements enumerated by the enumerator.</typeparam>
        /// <param name="enumerator">The current enumerator.</param>
        /// <param name="offsets">An element of any of these specified offsets will be copied to the array. For example, an element of offset 0 is the element at the enumerator's current position; an element of offset 1 is the element next to the enumerator's current position; an element of offset 2 is the element next to the element of offset 1; and so forth.</param>
        /// <returns>A new array containing the elements not yet enumerated by the enumerator before the execution of this method.</returns>
        public static object[] ToArray(this IEnumerator enumerator, int[] offsets)
        {
            if (offsets == null)
                return enumerator.ToArray();
            else
            {
                int j = 0;
                var list = new List<object>();
                while (enumerator.MoveNext())
                {
                    if (j.In(offsets))
                        list.Add(enumerator.Current);
                    ++j;
                }
                return list.ToArray();
            }
        }
    }
}
