using System;
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
        /// Run the <paramref name="action"/> for a number of iterations specified by the current integer.
        /// </summary>
        /// <param name="iterations">The current integer specifying the number of iterations.</param>
        /// <param name="action">The <see cref="Action"/> to execute for a number of iterations specified by the current integer. It accepts a single parameter indicating the index of the current iteration.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach(this int iterations, Action<int> action)
        {
            for (var i = 0; i < iterations; ++i)
                action(i);
        }

        /// <summary>
        /// Run the <paramref name="action"/> for a number of iterations with iteration indexes specified by the current <see cref="ValueTuple"/>. For example, <c>(2,6).Foreach(i=>Console.WriteLine(i))</c> prints out numbers from 2 to 5.
        /// </summary>
        /// <param name="iterationIndexRange">The current <see cref="ValueTuple"/> specifying the iteration index range.</param>
        /// <param name="action">The <see cref="Action"/> to execute for a number of iterations specified by the current integer. It accepts a single parameter indicating the index of the current iteration.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach(this (int, int) iterationIndexRange, Action<int> action)
        {
            for (var i = iterationIndexRange.Item1; i < iterationIndexRange.Item2; ++i)
                action(i);
        }

        /// <summary>
        /// Run the <paramref name="action"/> for a number of iterations with iteration indexes specified by the current <see cref="ValueTuple"/>. For example, <c>(2,8,2).Foreach(i=>Console.WriteLine(i))</c> prints out numbers 2, 4, 6.
        /// </summary>
        /// <param name="iterationIndexRange">The current <see cref="ValueTuple"/> specifying the iteration index range.</param>
        /// <param name="action">The <see cref="Action"/> to execute for a number of iterations specified by the current integer. It accepts a single parameter indicating the index of the current iteration.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach(this (int, int, int) iterationIndexRange, Action<int> action)
        {
            for (var i = iterationIndexRange.Item1; i < iterationIndexRange.Item2; i += iterationIndexRange.Item3)
                action(i);
        }



        /// <summary>
        /// Do some action for each element in the current sequence.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current collection.</typeparam>
        /// <param name="collection">The current collection.</param>
        /// <param name="action">A delegate that will be invoked on each element of the current collection. 
        /// The only argument is the element of the current collection.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            if (collection == null) return;
            var ie = collection.GetEnumerator();
            while (ie.MoveNext())
                action(ie.Current);
        }

        /// <summary>
        /// Do some action for each element in the current sequence.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current collection.</typeparam>
        /// <param name="collection">The current collection.</param>
        /// <param name="action">A delegate that will be invoked on each element of the current collection. 
        /// The first argument indicates the position of the element in the current collection, and the second is the element.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<T>(this IEnumerable<T> collection, Action<int, T> action)
        {
            if (collection != null)
            {
                var i = 0;
                var ie = collection.GetEnumerator();
                while (ie.MoveNext())
                {
                    action(i, ie.Current);
                    ++i;
                }
            }
        }

        /// <summary>
        /// Do some action for each element in the current sequence.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current collection.</typeparam>
        /// <param name="collection">The current collection.</param>
        /// <param name="action">A delegate that will be invoked on each element of the current collection. 
        /// The only argument is the element of the current collection. A Boolean value must be returned indicating whether the iteration should continue.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<T>(this IEnumerable<T> collection, Func<T, bool> action)
        {
            if (collection != null)
            {
                var ie = collection.GetEnumerator();
                while (ie.MoveNext())
                    if (!action(ie.Current)) break;
            }
        }

        /// <summary>
        /// Do some action for each element in the current sequence.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current collection.</typeparam>
        /// <param name="collection">The current collection.</param>
        /// <param name="action">A delegate that will be invoked on each element of the current collection. 
        /// The first argument indicates the position of the element in the current collection, and the second is the element. A Boolean value must be returned indicating whether the iteration should continue.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<T>(this IEnumerable<T> collection, Func<int, T, bool> action)
        {
            if (collection != null)
            {
                var ie = collection.GetEnumerator();
                int i = 0;
                while (ie.MoveNext())
                    if (!action(i++, ie.Current)) break;
            }
        }

        /// <summary>
        /// Do some action for each element in the current list/array.
        /// </summary>
        /// <typeparam name="T">The type of element in the current list/array.</typeparam>
        /// <param name="list">The current list/array.</param>
        /// <param name="action">A delegate that will be invoked on each element of the current list/array. 
        /// The only argument is the element of the current list/array.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<T>(this IList<T> list, Action<T> action)
        {
            for (var i = 0; i < list.Count; ++i)
                action(list[i]);
        }

        /// <summary>
        /// Do some action for each element in the current list/array.
        /// </summary>
        /// <typeparam name="T">The type of element in the current list/array.</typeparam>
        /// <param name="list">The current list/array.</param>
        /// <param name="action">A delegate that will be invoked on each element of the current list/array. 
        /// The first argument indicates the position of the element in the current list/array, and the second is the element.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<T>(this IList<T> list, Action<int, T> action)
        {
            for (int i = 0; i < list.Count; ++i)
                action(i, list[i]);
        }

        /// <summary>
        /// Do some action for each element in the current list/array.
        /// </summary>
        /// <typeparam name="T">The type of element in the current list/array.</typeparam>
        /// <param name="list">The current list/array.</param>
        /// <param name="action">A delegate that will be invoked on each element of the current list/array. 
        /// The first argument indicates the position of the element in the current list/array, and the second is the element. A Boolean value must be returned indicating whether the iteration should continue.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<T>(this IList<T> list, Func<int, T, bool> action)
        {
            for (int i = 0; i < list.Count; ++i)
                if (!action(i, list[i])) break;
        }

        /// <summary>
        /// Do some action for each element in the current list/array.
        /// </summary>
        /// <typeparam name="T">The type of element in the current list/array.</typeparam>
        /// <param name="list">The current list/array.</param>
        /// <param name="action">A delegate that will be invoked on each element of the current list/array. 
        /// The only argument is the element of the current list/array. A Boolean value must be returned indicating whether the iteration should continue.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<T>(this IList<T> list, Func<T, bool> action)
        {
            for (var i = 0; i < list.Count; ++i)
                if (!action(list[i])) break;
        }

        /// <summary>
        /// Do some action for each element in the current array.
        /// </summary>
        /// <typeparam name="T">The type of element in the current array.</typeparam>
        /// <param name="list">The current array.</param>
        /// <param name="action">A delegate that will be invoked on each element of the current array. 
        /// The only argument is the element of the current array. A Boolean value must be returned indicating whether the iteration should continue.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<T>(this T[] array, Func<T, bool> action)
        {
            for (var i = 0; i < array.Length; ++i)
                if (!action(array[i])) break;
        }
    }
}
