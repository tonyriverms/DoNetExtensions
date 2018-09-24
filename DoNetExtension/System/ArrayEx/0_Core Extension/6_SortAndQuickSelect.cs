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
        /// Sorts the elements in the one-dimensional <see cref="System.Array"/> using the <see cref="System.IComparable{T}"/> interface implementation of each element of the <see cref="System.Array"/>.
        /// <para>
        /// Note this method does not create a new array but stores the sorted elements in the original array.
        /// The returned array is the same instance as the passed-in argument <paramref name="array"/>.
        /// </para>
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The one-dimensional, zero-base <see cref="System.Array"/> to sort.</param>
        /// <returns>The same instance as the passed-in argument <paramref name="array"/> with elements sorted.</returns>
        public static T[] Sort<T>(this T[] array)
        {
            Array.Sort<T>(array);
            return array;
        }

        /// <summary>
        /// Sorts the elements in the one-dimensional <see cref="System.Array"/> in the descending order using the <see cref="System.IComparable{T}"/> interface implementation of each element of the <see cref="System.Array"/>.
        /// <para>
        /// Note this method does not create a new array but stores the sorted elements in the original array.
        /// The returned array is the same instance as the passed-in argument <paramref name="array"/>.
        /// </para>
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The one-dimensional, zero-base <see cref="System.Array"/> to sort.</param>
        /// <returns>The same instance as the passed-in argument <paramref name="array"/> with elements sorted in the descending order.</returns>
        public static T[] SortDesc<T>(this T[] array)
        {
            Array.Sort<T>(array);
            Array.Reverse(array);
            return array;
        }

        /// <summary>
        /// Sorts a pair of <see cref="System.Array"/> objects (one contains the keys and the other contains the corresponding items) based on the keys in the first <see cref="System.Array"/> using the <see cref="IComparable{T}"/> generic interface implementation of each key.
        /// </summary>
        /// <typeparam name="TKey">TThe type of the elements of the <paramref name="keys"/> array.</typeparam>
        /// <typeparam name="TValue">The type of the elements of the <paramref name="values "/> array.</typeparam>
        /// <param name="keys">The one-dimensional, zero-based <see cref="System.Array"/> that contains the keys to sort.</param>
        /// <param name="values">The one-dimensional, zero-based <see cref="System.Array"/> that contains the items that correspond to the keys in keys, or <c>null</c> to sort only keys.</param>
        public static void SortWithValues<TKey, TValue>(this TKey[] keys, TValue[] values)
        {
            Array.Sort<TKey, TValue>(keys, values);
        }

        /// <summary>
        /// Sorts a pair of <see cref="System.Array"/> objects (one contains the keys and the other contains the corresponding items) in the descending order based on the keys in the first <see cref="System.Array"/> using the <see cref="IComparable{T}"/> generic interface implementation of each key.
        /// </summary>
        /// <typeparam name="TKey">TThe type of the elements of the <paramref name="keys"/> array.</typeparam>
        /// <typeparam name="TValue">The type of the elements of the <paramref name="values "/> array.</typeparam>
        /// <param name="keys">The one-dimensional, zero-based <see cref="System.Array"/> that contains the keys to sort.</param>
        /// <param name="values">The one-dimensional, zero-based <see cref="System.Array"/> that contains the items that correspond to the keys in keys, or <c>null</c> to sort only keys.</param>
        public static void SortDescWithValues<TKey, TValue>(this TKey[] keys, TValue[] values)
        {
            Array.Sort<TKey, TValue>(keys, values);
            Array.Reverse(keys);
            Array.Reverse(values);
        }


        /// <summary>
        /// Sorts a range the specified array.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The one-dimensional, zero-based <see cref="System.Array"/> to sort</param>
        /// <param name="start">The starting index of the range to sort.</param>
        /// <param name="length">The number of elements in the range to sort.</param>
        /// <returns>The same instance as the passed-in argument <paramref name="array"/> with elements in the specified range sorted.</returns>
        public static T[] Sort<T>(this T[] array, int start, int length)
        {
            Array.Sort(array, start, length);
            return array;
        }

        /// <summary>
        /// Sorts a range the specified array in the descending order.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The one-dimensional, zero-based <see cref="System.Array"/> to sort</param>
        /// <param name="start">The starting index of the range to sort.</param>
        /// <param name="length">The number of elements in the range to sort.</param>
        /// <returns>The same instance as the passed-in argument <paramref name="array"/> with elements in the specified range sorted.</returns>
        public static T[] SortDesc<T>(this T[] array, int start, int length)
        {
            Array.Sort<T>(array, start, length);
            Array.Reverse(array, start, length);
            return array;
        }

        /// <summary>
        /// Sorts a range of a pair of <see cref="System.Array" /> objects (one contains the keys and the other contains the corresponding items) based on the keys in the first <see cref="System.Array"/> using the <see cref="IComparable{T}" /> generic interface implementation of each key.
        /// </summary>
        /// <typeparam name="TKey">TThe type of the elements of the <paramref name="keys" /> array.</typeparam>
        /// <typeparam name="TValue">The type of the elements of the <paramref name="values " /> array.</typeparam>
        /// <param name="keys">The one-dimensional, zero-based <see cref="System.Array" /> that contains the keys to sort.</param>
        /// <param name="values">The one-dimensional, zero-based <see cref="System.Array" /> that contains the items that correspond to the keys in keys, or <c>null</c> to sort only keys.</param>
        /// <param name="start">The starting index of the range to sort.</param>
        /// <param name="length">The number of elements in the range to sort.</param>
        public static void SortWithValues<TKey, TValue>(this TKey[] keys, TValue[] values, int start, int length)
        {
            Array.Sort<TKey, TValue>(keys, values, start, length);
        }

        /// <summary>
        /// Sorts a range of a pair of <see cref="System.Array" /> objects (one contains the keys and the other contains the corresponding items) in the descending order based on the keys in the first <see cref="System.Array"/> using the <see cref="IComparable{T}" /> generic interface implementation of each key.
        /// </summary>
        /// <typeparam name="TKey">TThe type of the elements of the <paramref name="array" /> array.</typeparam>
        /// <typeparam name="TValue">The type of the elements of the <paramref name="values " /> array.</typeparam>
        /// <param name="array">The one-dimensional, zero-based <see cref="System.Array" /> that contains the keys to sort.</param>
        /// <param name="values">The one-dimensional, zero-based <see cref="System.Array" /> that contains the items that correspond to the keys in keys, or <c>null</c> to sort only keys.</param>
        /// <param name="start">The starting index of the range to sort.</param>
        /// <param name="length">The number of elements in the range to sort.</param>
        public static void SortDescWithValues<TKey, TValue>(this TKey[] array, TValue[] values, int start, int length)
        {
            Array.Sort<TKey, TValue>(array, values, start, length);
            Array.Reverse(array, start, length);
            Array.Reverse(values, start, length);
        }

        /// <summary>
        /// Sorts the elements in the one-dimensional <see cref="System.Array" /> using the specified <see cref="System.Comparison{T}"/>.
        /// <para>
        /// Note this method does not create a new array but stores the sorted elements in the original array.
        /// The returned array is the same instance as the passed-in argument <paramref name="array" />.
        /// </para>
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The one-dimensional, zero-base <see cref="System.Array"/> to sort.</param>
        /// <param name="comparison">The <see cref="System.Comparison{T}"/> to use when comparing elements.</param>
        /// <returns>
        /// The same instance as the passed-in argument <paramref name="array" /> with elements sorted.
        /// </returns>
        public static T[] Sort<T>(this T[] array, Comparison<T> comparison)
        {
            Array.Sort<T>(array, comparison);
            return array;
        }

        /// <summary>
        /// Sorts the elements in the one-dimensional <see cref="System.Array" />. A method can be specified to convert each element to a comparable object before comparison.
        /// <para>
        /// NOTE this method does not create a new array but stores the sorted elements in the original array.
        /// The returned array is the same instance as the passed-in argument <paramref name="array" />.
        /// </para>
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The one-dimensional, zero-base <see cref="System.Array"/> to sort.</param>
        /// <param name="toComparable">A method converting elements of the <see cref="System.Array" /> to comparable values.</param>
        /// <returns>
        /// The same instance as the passed-in argument <paramref name="array" /> with elements sorted.
        /// </returns>
        public static T[] Sort<T>(this T[] array, Func<T, IComparable> toComparable)
        {
            Array.Sort<T>(array, (t1, t2) =>
            {
                var v1 = toComparable(t1);
                var v2 = toComparable(t2);
                return v1.CompareTo(v2);
            });
            return array;
        }

        /// <summary>
        /// Sorts the elements in the one-dimensional <see cref="System.Array" /> descendingly. A method can be specified to convert each element to a comparable object before comparison.
        /// <para>
        /// NOTE this method does not create a new array but stores the sorted elements in the original array.
        /// The returned array is the same instance as the passed-in argument <paramref name="array" />.
        /// </para>
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The one-dimensional, zero-base <see cref="System.Array"/> to sort.</param>
        /// <param name="toComparable">A method converting elements of the <see cref="System.Array" /> to comparable values.</param>
        /// <returns>
        /// The same instance as the passed-in argument <paramref name="array" /> with elements sorted.
        /// </returns>
        public static T[] SortDesc<T>(this T[] array, Func<T, IComparable> toComparable)
        {
            Array.Sort<T>(array, (t1, t2) =>
            {
                var v1 = toComparable(t1);
                var v2 = toComparable(t2);
                return -v1.CompareTo(v2);
            });
            return array;
        }

        /// <summary>
        /// Selects the <paramref name="k"/>th element in the current array, based on ascending order. After execution of this method, the current array will be reordered, and its first <paramref name="k"/> elements are smaller or equal to the selected <paramref name="k"/>th element.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the current array.</typeparam>
        /// <param name="array">The one-dimensional, zero-base <see cref="System.Array"/> to sort.</param>
        /// <param name="k">The <paramref name="k"/>th element in the current array based on ascending order will be returned.</param>
        /// <returns>The <paramref name="k"/>th element in the current array based on ascending order.</returns>
        public static T TopK<T>(this T[] array, int k) where T : IComparable
        {
            return TopK(array, 0, array.Length, k);
        }

        /// <summary>
        /// Selects the <paramref name="k"/>th element in the selection range (specified by <paramref name="start"/> and <paramref name="length"/>) of the current array, based on ascending order. After execution of this method, the current array will be reordered, and its first <paramref name="k"/> elements are smaller or equal to the selected <paramref name="k"/>th element.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the current array.</typeparam>
        /// <param name="array">The one-dimensional, zero-base <see cref="System.Array"/> to sort.</param>
        /// <param name="start">The starting index of the selection range.</param>
        /// <param name="length">The number of elements in the selection range.</param>
        /// <param name="k">The <paramref name="k"/>th element in the selection range (specified by <paramref name="start"/> and <paramref name="length"/>) of the current array base on ascending order will be returned.</param>
        /// <returns>The <paramref name="k"/>th element in the selection range specified by <paramref name="start"/> and <paramref name="length"/> based on ascending order.</returns>
        public static T TopK<T>(this T[] array, int start, int length, int k) where T : IComparable
        {
            while (true)
            {
                if (array.IsNullOrEmpty()) return default;

                if (length == 1 && k == 1) return array[start];

                var m = (length + 4) / 5;
                var mid = new T[m];

                for (var i = 0; i < m; i++)
                {
                    var t = start + i * 5;
                    var r = length + start - t;
                    if (r > 4)
                    {
                        array.Sort(t, 5);
                        mid[i] = array[t + 2];
                    }
                    else
                    {
                        array.Sort(t, r);
                        mid[i] = array[t + (r - 1) / 2];
                    }
                }

                var pivot = TopK(mid, 0, m, (m + 1) / 2);

                for (var i = 0; i < length; i++)
                {
                    if (array[start + i].CompareTo(pivot) != 0) continue;
                    array.Swap(start + i, start + length - 1);
                    break;
                }

                var pos = 0;
                for (var i = 0; i < length - 1; i++)
                {
                    if (array[start + i].CompareTo(pivot) >= 0) continue;
                    if (i != pos) array.Swap(start + i, start + pos);
                    pos++;
                }

                array.Swap(start + pos, start + length - 1);

                if (pos == k - 1)
                    return pivot;
                if (pos > k - 1)
                {
                    length = pos;
                }
                else
                {
                    start = start + pos + 1;
                    length = length - pos - 1;
                    k = k - pos - 1;
                }
            }
        }

        /// <summary>
        /// Selects the <paramref name="k"/>th element in the current array, based on descending order. After execution of this method, the current array will be reordered, and its first <paramref name="k"/> elements are smaller or equal to the selected <paramref name="k"/>th element.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the current array.</typeparam>
        /// <param name="array">The one-dimensional, zero-base <see cref="System.Array"/> to sort.</param>
        /// <param name="k">The <paramref name="k"/>th element in the current array based on descending order will be returned.</param>
        /// <returns>The <paramref name="k"/>th element in the current array based on descending order.</returns>
        public static T TopKDesc<T>(this T[] array, int k) where T : IComparable
        {
            return TopKDesc(array, 0, array.Length, k);
        }

        /// <summary>
        /// Selects the <paramref name="k"/>th element in the selection range (specified by <paramref name="start"/> and <paramref name="length"/>) of the current array, based on descending order. After execution of this method, the current array will be reordered, and its first <paramref name="k"/> elements are smaller or equal to the selected <paramref name="k"/>th element.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the current array.</typeparam>
        /// <param name="array">The one-dimensional, zero-base <see cref="System.Array"/> to sort.</param>
        /// <param name="start">The starting index of the selection range.</param>
        /// <param name="length">The number of elements in the selection range.</param>
        /// <param name="k">The <paramref name="k"/>th element in the selection range (specified by <paramref name="start"/> and <paramref name="length"/>) of the current array based on descending order will be returned.</param>
        /// <returns>The <paramref name="k"/>th element in the selection range specified by <paramref name="start"/> and <paramref name="length"/> based on descending order.</returns>
        public static T TopKDesc<T>(this T[] array, int start, int length, int k) where T : IComparable
        {
            while (true)
            {
                if (array.IsNullOrEmpty()) return default(T);

                if (length == 1 && k == 1) return array[start];

                var m = (length + 4) / 5;
                var mid = new T[m];

                for (var i = 0; i < m; i++)
                {
                    var t = start + i * 5;
                    var r = length + start - t;
                    if (r > 4)
                    {
                        array.SortDesc(t, 5);
                        mid[i] = array[t + 2];
                    }
                    else
                    {
                        array.SortDesc(t, r);
                        mid[i] = array[t + (r - 1) / 2];
                    }
                }

                var pivot = TopKDesc(mid, 0, m, (m + 1) / 2);

                for (int i = 0; i < length; i++)
                {
                    if (array[start + i].CompareTo(pivot) != 0) continue;
                    array.Swap(start + i, start + length - 1);
                    break;
                }

                var pos = 0;
                for (var i = 0; i < length - 1; i++)
                {
                    if (array[start + i].CompareTo(pivot) <= 0) continue;
                    if (i != pos) array.Swap(start + i, start + pos);
                    pos++;
                }

                array.Swap(start + pos, start + length - 1);

                if (pos == k - 1)
                    return pivot;
                if (pos > k - 1)
                {
                    length = pos;
                }
                else
                {
                    start = start + pos + 1;
                    length = length - pos - 1;
                    k = k - pos - 1;
                }
            }
        }

        /// <summary>
        /// Selects the <paramref name="k" />th element in the selection range (specified by <paramref name="start" /> and <paramref name="length" />) from the current array, based on ascending order. After execution of this method, the current array will be reordered along with <paramref name="values" />, and its first <paramref name="k" /> elements are smaller or equal to the selected <paramref name="k" />th element.
        /// </summary>
        /// <typeparam name="TKey">The type of the elements of the current array.</typeparam>
        /// <typeparam name="TValue">The type of the elements of the <paramref name="values"/>.</typeparam>
        /// <param name="array">The one-dimensional, zero-base <see cref="System.Array" /> to sort.</param>
        /// <param name="values">The values whose element order will be changed along with the current array.</param>
        /// <param name="start">The starting index of the selection range.</param>
        /// <param name="length">The number of elements in the selection range.</param>
        /// <param name="k">The <paramref name="k" />th element in the selection range (specified by <paramref name="start" /> and <paramref name="length" />) of the current array will be returned.</param>
        /// <returns>The <paramref name="k" />th element in the selection range specified by <paramref name="start" /> and <paramref name="length" />.</returns>
        public static TKey TopKWithValues<TKey, TValue>(this TKey[] array, TValue[] values, int start, int length, int k) where TKey : IComparable
        {
            while (true)
            {
                if (array.IsNullOrEmpty()) return default(TKey);

                if (length == 1 && k == 1) return array[start];

                var m = (length + 4) / 5;
                var mid = new TKey[m];

                for (var i = 0; i < m; i++)
                {
                    var t = start + i * 5;
                    var r = length + start - t;
                    if (r > 4)
                    {
                        array.SortWithValues(values, t, 5);
                        mid[i] = array[t + 2];
                    }
                    else
                    {
                        array.SortWithValues(values, t, r);
                        mid[i] = array[t + (r - 1) / 2];
                    }
                }

                var pivot = TopK(mid, 0, m, (m + 1) / 2);

                for (var i = 0; i < length; i++)
                {
                    if (array[start + i].CompareTo(pivot) == 0)
                    {
                        array.Swap(start + i, start + length - 1);
                        values.Swap(start + i, start + length - 1);
                        break;
                    }
                }

                var pos = 0;
                for (var i = 0; i < length - 1; i++)
                {
                    if (array[start + i].CompareTo(pivot) >= 0) continue;
                    if (i != pos)
                    {
                        array.Swap(start + i, start + pos);
                        values.Swap(start + i, start + pos);
                    }

                    pos++;
                }

                array.Swap(start + pos, start + length - 1);
                values.Swap(start + pos, start + length - 1);

                if (pos == k - 1)
                    return pivot;
                else if (pos > k - 1)
                {
                    length = pos;
                }
                else
                {
                    start = start + pos + 1;
                    length = length - pos - 1;
                    k = k - pos - 1;
                }
            }
        }

        /// <summary>
        /// Selects the <paramref name="k" />th element in the selection range (specified by <paramref name="start" /> and <paramref name="length" />) from the current array, based on descending order. After execution of this method, the current array will be reordered along with <paramref name="values" />, and its first <paramref name="k" /> elements are smaller or equal to the selected <paramref name="k" />th element.
        /// </summary>
        /// <typeparam name="TKey">The type of the elements of the current array.</typeparam>
        /// <typeparam name="TValue">The type of the elements of the <paramref name="values"/>.</typeparam>
        /// <param name="array">The one-dimensional, zero-base <see cref="System.Array" /> to sort.</param>
        /// <param name="values">The values whose element order will be changed along with the current array.</param>
        /// <param name="start">The starting index of the selection range.</param>
        /// <param name="length">The number of elements in the selection range.</param>
        /// <param name="k">The <paramref name="k" />th element in the selection range (specified by <paramref name="start" /> and <paramref name="length" />) of the current array will be returned.</param>
        /// <returns>The <paramref name="k" />th element in the selection range specified by <paramref name="start" /> and <paramref name="length" />.</returns>
        public static TKey TopKDescWithValues<TKey, TValue>(this TKey[] array, TValue[] values, int start, int length, int k) where TKey : IComparable
        {
            while (true)
            {
                if (array.IsNullOrEmpty()) return default(TKey);
                if (length == 1 && k == 1) return array[start];

                var m = (length + 4) / 5;
                var mid = new TKey[m];

                for (var i = 0; i < m; i++)
                {
                    var t = start + i * 5;
                    var r = length + start - t;
                    if (r > 4)
                    {
                        array.SortDescWithValues(values, t, 5);
                        mid[i] = array[t + 2];
                    }
                    else
                    {
                        array.SortDescWithValues(values, t, r);
                        mid[i] = array[t + (r - 1) / 2];
                    }
                }

                var pivot = TopKDesc(mid, 0, m, (m + 1) / 2);

                for (var i = 0; i < length; i++)
                {
                    if (array[start + i].CompareTo(pivot) != 0) continue;
                    array.Swap(start + i, start + length - 1);
                    values.Swap(start + i, start + length - 1);
                    break;
                }

                var pos = 0;
                for (var i = 0; i < length - 1; i++)
                {
                    if (array[start + i].CompareTo(pivot) <= 0) continue;
                    if (i != pos)
                    {
                        array.Swap(start + i, start + pos);
                        values.Swap(start + i, start + pos);
                    }

                    pos++;
                }

                array.Swap(start + pos, start + length - 1);
                values.Swap(start + pos, start + length - 1);

                if (pos == k - 1)
                    return pivot;
                if (pos > k - 1)
                {
                    length = pos;
                }
                else
                {
                    start = start + pos + 1;
                    length = length - pos - 1;
                    k = k - pos - 1;
                }
            }
        }

        /// <summary>
        /// Returns the minimum value in a generic sequence. Items in the sequence are compared using the specified <paramref name="comparison"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The generic sequence.</param>
        /// <param name="comparison">The comparison method.</param>
        /// <returns>The minimum value.</returns>
        public static T Min<T>(this IEnumerable<T> source, Comparison<T> comparison)
        {
            using (var ie = source.GetEnumerator())
            {
                var minItem = default(T);

                if (!ie.MoveNext()) return minItem;
                minItem = ie.Current;
                while (ie.MoveNext())
                {
                    var item = ie.Current;
                    if (comparison(item, minItem) < 0)
                        minItem = item;
                }

                return minItem;
            }
        }

        /// <summary>
        /// Returns the maximum value in a generic sequence. Items in the sequence are compared using the specified <paramref name="comparison"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The generic sequence.</param>
        /// <param name="comparison">The comparison method.</param>
        /// <returns>The maximum value.</returns>
        public static T Max<T>(this IEnumerable<T> source, Comparison<T> comparison)
        {
            using (var ie = source.GetEnumerator())
            {
                var maxItem = default(T);

                if (!ie.MoveNext()) return maxItem;
                maxItem = ie.Current;
                while (ie.MoveNext())
                {
                    var item = ie.Current;
                    if (comparison(item, maxItem) > 0)
                        maxItem = item;
                }

                return maxItem;
            }
        }

        /// <summary>
        /// Returns the minimum value in an array. Items in the array are compared using the specified <paramref name="comparison" />.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="array" />.</typeparam>
        /// <param name="array">The array.</param>
        /// <param name="comparison">The comparison method.</param>
        /// <returns>The minimum value.</returns>
        public static T Min<T>(this T[] array, Comparison<T> comparison)
        {
            var len = ExceptionHelper.NonEmptyArrayRequired(array, "array");
            var minItem = array[0];
            for (var i = 1; i < len; ++i)
            {
                var item = array[i];
                if (comparison(item, minItem) < 0) minItem = item;
            }
            return minItem;
        }

        /// <summary>
        /// Returns the maximum value in an array. Items in the array are compared using the specified <paramref name="comparison"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="array"/>.</typeparam>
        /// <param name="array">The array.</param>
        /// <param name="comparison">The comparison method.</param>
        /// <returns>The maximum value.</returns>
        public static T Max<T>(this T[] array, Comparison<T> comparison)
        {
            var len = ExceptionHelper.NonEmptyArrayRequired(array, "array");
            var minItem = array[0];
            for (var i = 1; i < len; ++i)
            {
                var item = array[i];
                if (comparison(item, minItem) > 0) minItem = item;
            }
            return minItem;
        }

        /// <summary>
        /// Selects an element in the sequence with the minimum comparable value.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The generic sequence.</param>
        /// <param name="toComparable">Coverts each element in the sequence to comparable values.</param>
        /// <returns>An element in the sequence with the minimum comparable value.</returns>
        public static T SelectMin<T>(this IEnumerable<T> source, Func<T, IComparable> toComparable)
        {
            var minItem = default(T);
            using (var ie = source.GetEnumerator())
            {
                if (!ie.MoveNext()) return minItem;
                minItem = ie.Current;
                var maxVal = toComparable(minItem);

                while (ie.MoveNext())
                {
                    var item = ie.Current;
                    var val = toComparable(item);
                    if (val.CompareTo(maxVal) >= 0) continue;
                    minItem = item;
                    maxVal = val;
                }

                return minItem;
            }
        }

        /// <summary>
        /// Selects an element in the sequence with the maximum comparable value.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The generic sequence.</param>
        /// <param name="toComparable">Coverts each element in the sequence to comparable values.</param>
        /// <returns>An element in the sequence with the maximum comparable value.</returns>
        public static T SelectMax<T>(this IEnumerable<T> source, Func<T, IComparable> toComparable)
        {
            var maxItem = default(T);
            using (var ie = source.GetEnumerator())

            {
                if (!ie.MoveNext()) return maxItem;
                maxItem = ie.Current;
                var maxVal = toComparable(maxItem);

                while (ie.MoveNext())
                {
                    var item = ie.Current;
                    var val = toComparable(item);
                    if (val.CompareTo(maxVal) <= 0) continue;
                    maxItem = item;
                    maxVal = val;
                }

                return maxItem;
            }
        }
    }
}
