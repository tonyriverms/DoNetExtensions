using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class ArrayEx
    {
        /// <summary>
        /// Returns an generic enumerator for the array.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array</typeparam>
        /// <param name="array">The array.</param>
        /// <returns>Returns an generic enumerator that iterates through all elements in the array.</returns>
        public static IEnumerator<T> GetEnumerator<T>(this T[] array)
        {
            return ((IEnumerable<T>)array).GetEnumerator();
        }

        /// <summary>
        /// Gets an enumerator that first goes through all elements in the current <see cref="System.Array"/> and then goes through elements of other provided arrays.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current array and all other provided arrays.</typeparam>
        /// <param name="array">This array.</param>
        /// <param name="otherArrays">Provide other arrays. The enumerator will also go through elements in these arrays.</param>
        /// <returns>An enumerator that first goes through all elements in the current and then go through elements of <paramref name="otherArrays"/>.</returns>
        public static IEnumerator<T> GetEnumerator<T>(this T[] array, T[][] otherArrays)
        {
            int arrayLen;
            if (array != null)
            {
                arrayLen = array.Length;
                for (int i = 0; i < array.Length; ++i)
                    yield return array[i];
            }

            if (otherArrays != null)
            {
                for (int j = 0, k = otherArrays.Length; j < k; ++j)
                {
                    array = otherArrays[j];
                    if (array != null)
                    {
                        arrayLen = array.Length;
                        for (int i = 0; i < array.Length; ++i)
                            yield return array[i];
                    }
                }
            }
        }

        /// <summary>
        /// Gets an enumerator that first goes through all elements in the current <see cref="System.Array"/> and then goes through elements of other provided enumerables.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current array and all other provided enumerable sequences.</typeparam>
        /// <param name="array">This array.</param>
        /// <param name="otherEnumerables">Provide other enumerable sequences. The enumerator will also go through elements in these enumerables.</param>
        /// <returns>An enumerator that first goes through all elements in the current and then go through each of the <paramref name="enumerables"/>.</returns>
        public static IEnumerator<T> GetEnumerator<T>(this T[] array, IEnumerable<T>[] otherEnumerables)
        {
            int arrayLen;
            if (array != null)
            {
                arrayLen = array.Length;
                for (int i = 0; i < array.Length; ++i)
                    yield return array[i];
            }

            if (otherEnumerables != null)
            {
                for (int j = 0, k = otherEnumerables.Length; j < k; ++j)
                {
                    var enumerable = otherEnumerables[j];
                    foreach (T item in enumerable)
                        yield return item;
                    
                }
            }
        }

        /// <summary>
        /// Gets a trivial enumerator that can only yield the current object once. NOTE that this method returns an unresettable enumerator. To return a resettable enumerator, use the other overload.
        /// </summary>
        /// <typeparam name="T">The type of the current object.</typeparam>
        /// <param name="obj">The current object.</param>
        /// <returns>An un-resettable enumerator that can only yield the current object once.</returns>
        /// <remarks>This returned enumerator is intended for architecture purpose, not for general use. When a method or an interface requires an enumerator as its argument, a single object can be sent into that method or interface by wrapping it in a trivial enumerator.</remarks>
        public static IEnumerator<T> GetTrivialEnumerator<T>(this T obj)
        {
            yield return obj;
        }

        /// <summary>
        /// Gets a trivial enumerator that can only iterate the current object. NOTE that this method returns a resettable enumerator if <paramref name="resettable" /> is assigned <c>true</c>.
        /// </summary>
        /// <typeparam name="T">The type of the current object.</typeparam>
        /// <param name="obj">The current object.</param>
        /// <param name="resettable"><c>true</c> if the returned enumerator is resettable, otherwise, <c>false</c>.</param>
        /// <returns>An enumerator that can only iterate the current object.</returns>
        public static IEnumerator<T> GetTrivialEnumerator<T>(this T obj, bool resettable)
        {
            if (resettable) return new TrivialEnumerator<T>(obj);
            else return GetTrivialEnumerator(obj);
        }

        public static IEnumerator<T2> GetWrappedEnumerator<T1, T2>(this IEnumerable<T1> enumerable, Func<T1, T2> converter)
        {
            if (converter == null) throw new ArgumentNullException("converter");
            foreach (var item in enumerable) yield return converter(item);
        }

        public static IEnumerator<T2> GetWrappedEnumerator<T1, T2>(this IEnumerable<T1> enumerable)
        {
            foreach (var item in enumerable)
                yield return (T2)(object)item;
        }

        public static IEnumerator<T2> GetWrappedEnumerator<T1, T2>(this IEnumerator<T1> enumerator, Func<T1, T2> converter)
        {
            if (converter == null) throw new ArgumentNullException("converter");
            while (enumerator.MoveNext()) yield return converter(enumerator.Current);
        }

        public static IEnumerator<T2> GetWrappedEnumerator<T1, T2>(this IEnumerator<T1> enumerator)
        {
            while(enumerator.MoveNext())
                yield return (T2)(object)enumerator.Current;
        }

        class TrivialEnumerator<T> : IEnumerator<T>
        {
            T _obj;
            bool _reset;

            public TrivialEnumerator(T obj)
            {
                _obj = obj;
            }

            public T Current
            {
                get { if (!_reset) throw new InvalidOperationException(); return _obj; }
            }

            public void Dispose() { }

            object IEnumerator.Current
            {
                get { if (!_reset) throw new InvalidOperationException(); return _obj; }
            }

            public bool MoveNext()
            {
                if (_reset) return false;
                else
                {
                    _reset = true;
                    return true;
                }
            }

            public void Reset()
            {
                _reset = false;
            }
        }
    }
}
