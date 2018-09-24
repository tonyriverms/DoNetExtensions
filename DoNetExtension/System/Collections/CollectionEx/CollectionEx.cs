using System;
using System.Collections.Generic;
using System.Linq;

namespace System.Collections.Generic
{
    public static partial class GenericCollectionEx
    {
        #region Misc

        /// <summary>
        /// Converts the current collection to a hash-set.
        /// </summary>
        /// <param name="collection">The current collection.</param>
        /// <returns>A hash-set that contains all distinct elements from the current collection.</returns>
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> collection)
        {
            return new HashSet<T>(collection);
        }

        /// <summary>
        /// Concats all sequences in the current sequence as a single array.
        /// </summary>
        /// <typeparam name="T">They type of elements in the sequences contained in the current sequence.</typeparam>
        /// <param name="source">The current sequence of collections.</param>
        /// <returns>An array that contains all elements in the sequences of the current sequence.</returns>
        public static T[] Concat<T>(this IEnumerable<IEnumerable<T>> source)
        {
            List<T> output = new List<T>();
            foreach (var list in source)
                output.AddRange(list);
            return output.ToArray();
        }

        /// <summary>
        /// Gets the number of elements in the current sequence that equal the specified target value. 
        /// </summary>
        /// <typeparam name="T">The type of elements in the current sequence.</typeparam>
        /// <param name="source">The current sequence.</param>
        /// <param name="targetValue">The value that each element in the current sequence is to compare with.</param>
        /// <param name="equals">A delegate that defines the equality between two objects of type <typeparamref name="T"/>.</param>
        /// <returns>The number of elements in the current sequence that equal the specified target value. </returns>
        public static int Count<T>(this IEnumerable<T> source, T targetValue, Func<T, T, bool> equals)
        {
            var count = 0;
            foreach (var item in source)
            {
                if (equals(item, targetValue))
                    ++count;
            }
            return count;
        }

        /// <summary>
        /// Gets the number of elements in the current sequence that equal the specified target value. Equality is defined by method Equals of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current sequence.</typeparam>
        /// <param name="source">The current sequence.</param>
        /// <param name="targetValue">The value that each element in the current sequence is to compare with.</param>
        /// <returns>The number of elements in the current sequence that equal the specified target value. </returns>
        public static int Count<T>(this IEnumerable<T> source, T targetValue)
        {
            var count = 0;
            foreach (var item in source)
            {
                if (item.Equals(targetValue))
                    ++count;
            }
            return count;
        }

        public static int Count<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            var count = 0;
            foreach (var item in source)
            {
                if (predicate(item))
                    ++count;
            }
            return count;
        }

        /// <summary>
        /// Counts the number of occurrences of the specified <paramref name="targetValue"/> in each array of the <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current arrays.</typeparam>
        /// <param name="source">The current arrays.</param>
        /// <param name="targetValue">The target value to count.</param>
        /// <returns>A <see cref="int"/> array that stores the counts of <paramref name="targetValue"/> in each of the current array.</returns>
        public static int[] Count<T>(this T[][] source, T targetValue)
        {
            var rowCount = source.Length;
            var column = new int[rowCount];
            for (int i = 0; i < rowCount; ++i)
                column[i] = source[i].Count(targetValue);
            return column;
        }

        /// <summary>
        /// Counts the number of occurrences each <paramref name="targetValues"/> in the current array.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current array.</typeparam>
        /// <param name="source">The current array.</param>
        /// <param name="targetValues">The target values to count.</param>
        /// <returns>A <see cref="int"/> array that stores the counts of each of <paramref name="targetValues"/> in the current array.</returns>
        public static int[] Count<T>(this T[] source, T[] targetValues)
        {
            var columnCount = targetValues.Length;
            var row = new int[columnCount];
            for (int i = 0; i < columnCount; ++i)
                row[i] = source.Count(targetValues[i]);
            return row;
        }

        /// <summary>
        /// Returns a jagged array representing a count matrix of <paramref name="targetValues"/> in the <paramref name="source"/> arrays. 
        /// <para>The inside arrays of the returned jagged array all have the same size of <paramref name="targetValues"/>.The <c>i</c>th inside array counts the number of occurrences of each of <paramref name="targetValues"/> in the <c>i</c>th <paramref name="source"/> array.</para>
        /// </summary>
        /// <typeparam name="T">The type of elements in the current arrays.</typeparam>
        /// <param name="source">The current arrays.</param>
        /// <param name="targetValues">The target value to count.</param>
        /// <returns>A <see cref="int"/> array that stores the counts of <paramref name="targetValues"/> in each array of <paramref name="source"/>.</returns>
        public static int[][] Count<T>(this T[][] source, T[] targetValues)
        {
            var rowCount = source.Length;
            var columnCount = targetValues.Length;

            var countMatrix = new int[rowCount][];
            for (int i = 0; i < rowCount; i++)
                countMatrix[i] = source[i].Count(targetValues);
            return countMatrix;

            //! even though the number of rows and columns are pre-determined, we return nested arrays for better flexibility
        }

        /// <summary>
        /// Determines whether the current sequence contains a specified element that satisfies conditions defined by a specified delegate.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current sequence.</typeparam>
        /// <param name="source">The current sequence.</param>
        /// <param name="predicate"> A delegate to test each element for a condition.</param>
        /// <returns>true if at least one element in the current sequence satisfies the condition defined by the delegate; otherwise, false.</returns>
        public static bool Contains<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
                if (predicate(item))
                    return true;
            return false;
        }

        /// <summary>
        /// Gets the the position of the first occurrence of an element that satisfies a condition defined by a specified delegate.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current <c>List</c>.</typeparam>
        /// <param name="list">The current <c>List</c>.</param>
        /// <param name="predicate"> A delegate to test each element for a condition.</param>
        /// <returns>The position of the first occurrence of an element that satisfies a condition defined by a specified delegate, if found; otherwise -1.</returns>
        public static int IndexOf<T>(this IList<T> list, Func<T, bool> predicate, int startIndex = 0)
        {
            var listCount = list.Count;
            if (listCount == 0) return -1;
            if (startIndex < 0 || startIndex >= listCount) throw new ArgumentOutOfRangeException("startIndex");

            for (int i = startIndex; i < listCount; ++i)
                if (predicate(list[i]))
                    return i;

            return -1;
        }

        public static int IndexOfSubList<T>(this IList<T> src, IList<T> target)
        {
            var len1 = src.Count;
            var len2 = target.Count;
            if (len2 <= len1)
            {
                var end = len2 - len1;
                --len2;
                for (int i = 0; i <= end; ++i)
                {
                    int j = 0;
                    int k = i;

                    while (true)
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

        public static int IndexOfSubList<T>(this IList<T> src, IList<T> target, Func<T, T, bool> comparer)
        {
            var len1 = src.Count;
            var len2 = target.Count;
            if (len2 <= len1)
            {
                var end = len2 - len1;
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

        public static bool SequenceEqual<T>(this IList<T> src, IList<T> target)
        {
            var len1 = src.Count;
            if (len1 != target.Count) return false;

            for (int i = 0; i < len1; ++i)
            {
                if (!src[i].Equals(target[i]))
                    return false;
            }

            return true;
        }

        public static bool SequenceEqual<T>(this IList<T> src, IList<T> target, Func<T, T, bool> comparer)
        {
            var len1 = src.Count;
            if (len1 != target.Count) return false;

            for (int i = 0; i < len1; ++i)
            {
                if (!comparer?.Invoke(src[i], target[i]) ?? !src[i].Equals(target[i]))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Copies the objects in the current sequence to a new linked list.
        /// </summary>
        /// <typeparam name="T">The type of objects in the sequence.</typeparam>
        /// <param name="enumerable">The current sequence.</param>
        /// <returns>A new <see cref="LinkedList{T}"/> of objects copied from the current sequence.</returns>
        public static LinkedList<T> ToLinkedList<T>(this IEnumerable<T> enumerable)
        {
            var lkList = new LinkedList<T>();
            foreach (var item in enumerable) lkList.AddLast(item);
            return lkList;
        }

        public static void NewAll<T>(this IList<T> list) where T : new()
        {
            var count = list.Count;
            for (int i = 0; i < count; ++i)
                list[i] = new T();
        }

        public static void Clear<T>(this T[] arr)
        {
            var len = arr.Length;
            for (int i = 0; i < len; ++i)
                arr[i] = default(T);
        }

        #endregion

        #region List

        /// <summary>
        /// Inserts an item to the beginning of current <see cref="System.Collections.Generic.IList{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current <see cref="System.Collections.Generic.IList{T}"/>.</typeparam>
        /// <param name="list">The current <see cref="System.Collections.Generic.IList{T}"/>.</param>
        /// <param name="value">The value to insert at the beginning of the current <c>System.Collections.Generic.List{T}</c>.</param>
        public static void InsertFirst<T>(this IList<T> list, T value)
        {
            list.Insert(0, value);
        }

        /// <summary>
        /// Creates an array from the current <see cref="System.Collections.Generic.IList{T}"/>.
        /// The elements of the output array is in reversed order. For example, the first element in the output array is the last element of the list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current <see cref="System.Collections.Generic.IList{T}"/>.</typeparam>
        /// <param name="list">The current <see cref="System.Collections.Generic.IList{T}"/>.</param>
        /// <returns>An array that contains the elements from the current list but in reversed order. </returns>
        public static T[] ToReversedArray<T>(this IList<T> list)
        {
            var listCount = list.Count;
            var output = new T[listCount];

            for (int i = listCount - 1, j = 0; i >= 0; --i, ++j)
                output[j] = list[i];

            return output;
        }


        #endregion

        #region Dictionary

        #region M-series dictionary

        public static bool TryGetValue<TKey, TValue>(this IDictionary<TKey, LinkedList<TValue>> dict, TKey key, TValue valueToCompare, out TValue value)
        {
            LinkedList<TValue> list;
            if (dict.TryGetValue(key, out list))
            {
                foreach (var item in list)
                {
                    if (item.Equals(valueToCompare))
                    {
                        value = item;
                        return true;
                    }
                }
            }

            value = default(TValue);
            return false;
        }

        public static bool TryGetValue<TKey, TValue>(this IDictionary<TKey, LinkedList<TValue>> dict, TKey key, TValue valueToCompare, out LinkedList<TValue> list, out TValue value)
        {
            if (dict.TryGetValue(key, out list))
            {
                foreach (var item in list)
                {
                    if (item.Equals(valueToCompare))
                    {
                        value = item;
                        return true;
                    }
                }
            }

            value = default(TValue);
            return false;
        }

        public static bool TryGetValue<TKey, TValue>(this IDictionary<TKey, SinglyLinkedList<TValue>> dict, TKey key, TValue valueToCompare, out TValue value)
        {
            SinglyLinkedList<TValue> list;
            if (dict.TryGetValue(key, out list))
            {
                foreach (var item in list)
                {
                    if (item.Equals(valueToCompare))
                    {
                        value = item;
                        return true;
                    }
                }
            }

            value = default(TValue);
            return false;
        }

        public static bool TryGetValue<TKey, TValue>(this IDictionary<TKey, SinglyLinkedList<TValue>> dict, TKey key, TValue valueToCompare, out SinglyLinkedList<TValue> list, out TValue value)
        {
            if (dict.TryGetValue(key, out list))
            {
                foreach (var item in list)
                {
                    if (item.Equals(valueToCompare))
                    {
                        value = item;
                        return true;
                    }
                }
            }

            value = default(TValue);
            return false;
        }

        public static bool TryGetValue<TKey, TValue>(this IDictionary<TKey, IList<TValue>> dict, TKey key, TValue valueToCompare, out TValue value)
        {
            IList<TValue> list;
            if (dict.TryGetValue(key, out list))
            {
                foreach (var item in list)
                {
                    if (item.Equals(valueToCompare))
                    {
                        value = item;
                        return true;
                    }
                }
            }

            value = default(TValue);
            return false;
        }

        public static bool TryGetValue<TKey, TValue>(this IDictionary<TKey, IList<TValue>> dict, TKey key, TValue valueToCompare, out IList<TValue> list, out TValue value)
        {
            if (dict.TryGetValue(key, out list))
            {
                foreach (var item in list)
                {
                    if (item.Equals(valueToCompare))
                    {
                        value = item;
                        return true;
                    }
                }
            }

            value = default(TValue);
            return false;
        }

        #endregion

        /// <summary>
        /// Gets the value associated with the specified key. If there is no such value associated with the key, a new instance will be initialized and associated with the key.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="dictionary">The current dictionary.</param>
        /// <param name="key">The key whose value to get.</param>
        /// <returns>The value associated with the specified key. If there is no such value associated with the key, a new instance will be initialized, associated and then returned.</returns>
        public static TValue TryGetValueOrNew<TKey, TValue>
            (this IDictionary<TKey, TValue> dictionary, TKey key) where TValue : new()
        {
            TValue value;
            if (dictionary.TryGetValue(key, out value))
                return value;
            else
            {
                value = new TValue();
                dictionary.Add(key, value);
                return value;
            }
        }

        /// <summary>
        /// Gets the value associated with the specified key. If there is no such value associated with the key, a new instance will be initialized and associated with the key.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="dictionary">The current dictionary.</param>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="isNew">Gets a value indicating whether the returned value is newly initialized.</param>
        /// <returns>The value associated with the specified key. If there is no such value associated with the key, a new instance will be initialized, associated and then returned.</returns>
        public static TValue TryGetValueOrNew<TKey, TValue>
            (this IDictionary<TKey, TValue> dictionary, TKey key, out bool isNew) where TValue : new()
        {
            if (!(isNew = !dictionary.TryGetValue(key, out var value)))
                return value;
            else
            {
                value = new TValue();
                dictionary.Add(key, value);
                return value;
            }
        }

        /// <summary>
        /// Removes key-value pairs with the specified keys from the <see cref="IDictionary{TKey, TValue}" />.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="dictionary">The current dictionary.</param>
        /// <param name="keys">The keys of the key-value pairs to remove.</param>
        /// <returns>The number of key-value pairs removed from the dictionary.</returns>
        public static int Remove<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, ICollection<TKey> keys)
        {
            var removeCount = 0;
            foreach (var key in keys)
            {
                if (dictionary.Remove(key))
                    ++removeCount;
            }
            return removeCount;
        }

        /// <summary>
        /// Removes key-value pairs with the specified value form the <see cref="IDictionary{TKey, TValue}" />.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="dictionary">The current dictionary.</param>
        /// <param name="value">Key-value pairs with this specified value will be removed from this dictionary.</param>
        /// <returns>The number of key-value pairs removed from this dictionary.</returns>
        public static int RemoveByValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TValue value)
        {
            var removeList = new List<TKey>();
            foreach (var pair in dictionary)
            {
                if (pair.Value.Equals(value))
                    removeList.Add(pair.Key);
            }

            return dictionary.Remove(removeList);
        }

        /// <summary>
        /// Removes key-value pairs form the <see cref="IDictionary{TKey, TValue}" /> whose value satisfies the specified <paramref name="predicate"/>.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="dictionary">The current dictionary.</param>
        /// <param name="predicate">A method that returns a <see cref="bool"/>. If the value of a key-value pair satisfies this condition, then it will be removed from the dictionary.</param>
        /// <returns>The number of key-value pairs removed from this dictionary.</returns>
        public static int RemoveByValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, Func<TValue, bool> predicate)
        {
            var removeList = new List<TKey>();
            foreach (var pair in dictionary)
            {
                if (predicate(pair.Value))
                    removeList.Add(pair.Key);
            }

            return dictionary.Remove(removeList);
        }

        #endregion

        #region LinkedList

        #endregion

        #region Enumerator Related Extensions

        /// <summary>
        /// Gets an enumerator that enumerates all elements since a specified position in this array/list.
        /// </summary>
        /// <typeparam name="T">The type of elements in this array/list.</typeparam>
        /// <param name="list">Specifies the position in the array/list where the enumerator starts to enumerate. 
        /// The enumerator will enumerate all elements since this position.</param>
        /// <param name="startIndex">The index of the first element to enumerate.</param>
        /// <returns>An enumerator that enumerates all elements since position 
        /// specified by <paramref name="startIndex"/> in this array/list.</returns>
        public static IEnumerator<T> GetSegmentEnumerator<T>(this IList<T> list, int startIndex)
        {
            return new SegmentEnumerator<T>(list, startIndex);
        }

        /// <summary>
        /// Gets an enumerator that enumerates all elements since a specified position in this array/list.
        /// </summary>
        /// <typeparam name="T">The type of elements in this array/list.</typeparam>
        /// <param name="list">Specifies the position in the array/list where the enumerator starts to enumerate. 
        /// The enumerator will enumerate all elements since this position.</param>
        /// <param name="startIndex">The index of the first element to enumerate.</param>
        /// <param name="count">The total number of elements to enumerate.</param>
        /// <returns>An enumerator that enumerates all elements since position 
        /// specified by <paramref name="startIndex"/> in this array/list.</returns>
        public static IEnumerator<T> GetSegmentEnumerator<T>(this IList<T> list, int startIndex, int count)
        {
            return new SegmentEnumerator<T>(list, startIndex, count);
        }

        /// <summary>
        /// Gets a merged enumerator of all enumerators in this array.
        /// </summary>
        /// <typeparam name="T">The type of element which enumerators in this array enumerate.</typeparam>
        /// <param name="enumerators">This array of enumerators.</param>
        /// <returns>A merged enumerator that sequentially enumerates all elements 
        /// of the collections enumerated by this array of enumerators.</returns>
        public static IEnumerator<T> GetMergedEnumerator<T>(this IEnumerator<T>[] enumerators)
        {
            return new MEnumerator<T>(enumerators);
        }

        /// <summary>
        /// Gets an array of elements from this enumerator by giving their relative indexes 
        /// (0-based, the next element the enumerator will read is with index 0) away from the current element of the enumerator.
        /// Those indexes are specified in parameter <paramref name="relativeIndexes"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements the enumerator enumerates.</typeparam>
        /// <param name="enumerator">This enumerator.</param>
        /// <param name="relativeIndexes">The relative indexes 
        /// (0-based, the next element the enumerator will read is with index 0) 
        /// of the elements to retrive.</param>
        /// <returns>An array of elements retrieved from the enumerator.</returns>
        public static T[] GetElements<T>(this IEnumerator<T> enumerator, int[] relativeIndexes)
        {
            var fixedIndexes = relativeIndexes.Sort().Distinct().ToArray();
            var len = fixedIndexes.Length;
            var output = new T[len];
            for (int i = 0; i < len; i++)
            {
                var forward = fixedIndexes[i] + 1;
                var actForward = enumerator.MoveForward(forward);
                if (actForward == forward)
                    output[i] = enumerator.Current;
                else break;
            }
            return output;
        }

        /// <summary>
        /// Advances this enumerator to the next i-th element where i is indicated by the parameter <paramref name="forward"/>.
        /// <para>NOTE that the number of element the enumerator actually advances may be different from the parameter <paramref name="forward"/>
        /// since the enumerator could move past the last element.</para>
        /// </summary>
        /// <typeparam name="T">The type of the element the enumerator enumerates.</typeparam>
        /// <param name="enumerator">This enumerator.</param>
        /// <param name="forward">A value indicating how many elements the enumerator should advance.</param>
        /// <returns>The number of elements the enumerator actually advances. A returned valued smaller than the parameter <paramref name="forward"/>
        /// indicates the enumerator has moved past the last element.</returns>
        public static int MoveForward<T>(this IEnumerator<T> enumerator, int forward)
        {
            int i = 0;
            while (i < forward)
            {
                if (enumerator.MoveNext())
                    ++i;
                else break;
            }

            return i;
        }

        /// <summary>
        /// Adds the REST elements not yet enumerated by a enumerator to the current System.Collections.Generic.IList{T}.
        /// <para>!!!Note that this method only adds those elements that are not yet enumerated by the enumerator.</para>
        /// </summary>
        /// <typeparam name="T">The type of the elements to add.</typeparam>
        /// <param name="list">The current System.Collections.Generic.IList{T}.</param>
        /// <param name="enumerator">The enumerator that enumerates the elements.</param>
        /// <param name="relativeIndexes">Only the elements with relative indexes 
        /// (0-based, the element the enumerator will read is with index 0) 
        /// specified in this array will be added to the current list.</param>
        public static void AddRange<T>(this IList<T> list, IEnumerator<T> enumerator, int[] relativeIndexes = null)
        {
            if (relativeIndexes == null)
                while (enumerator.MoveNext())
                    list.Add(enumerator.Current);
            else
            {
                int i = 0;
                {
                    while (enumerator.MoveNext())
                        if (i++.In(relativeIndexes))
                            list.Add(enumerator.Current);
                }
            }
        }

        public static T[] ToArray<T>(this IEnumerator<T> enumerator, Func<T, bool> checker)
        {
            var list = new List<T>();
            while (enumerator.MoveNext())
            {
                if (checker == null || checker(enumerator.Current))
                    list.Add(enumerator.Current);
            }
            return list.ToArray();
        }

        /// <summary>
        /// Creates an array from the current System.Collections.Generic.IList{T}.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current list.</typeparam>
        /// <param name="list">The current list.</param>
        /// <param name="indexes">Sets this parameter to an integer array and then 
        /// an element will be copied only if it is of an index in this array.</param>
        /// <returns>A new array holding the elements from the current list.</returns>
        public static T[] ToArray<T>(this IList<T> list, int[] indexes)
        {
            if (indexes == null)
                return list.ToArray();
            else
            {
                var count = indexes.Length;
                var array = new T[count];
                for (int i = 0; i < count; i++)
                    array[i] = list[indexes[i]];
                return array;
            }
        }

        #endregion

        public static void AddDistinct<T>(this IList<T> srcList, T item)
        {
            if (!srcList.Contains(item)) srcList.Add(item);
        }

        public static void AddRangeDistinct<T>(this IList<T> srcList, IEnumerable<T> items)
        {
            foreach (var item in items)
                AddDistinct(srcList, item);
        }

        public static void AddLastDistinct<T>(this LinkedList<T> srcList, T item)
        {
            if (!srcList.Contains(item)) srcList.AddLast(item);
        }

        public static void AddFirstDistinct<T>(this LinkedList<T> srcList, T item)
        {
            if (!srcList.Contains(item)) srcList.AddFirst(item);
        }

        public static void AddRangeLastDistinct<T>(this LinkedList<T> srcList, IEnumerable<T> items)
        {
            foreach (var item in items)
                AddLastDistinct(srcList, item);
        }

        public static void AddRangeFirstDistinct<T>(this LinkedList<T> srcList, IEnumerable<T> items)
        {
            foreach (var item in items)
                srcList.AddFirstDistinct(item);
        }

        /// <summary>
        /// Adds elements starting from a given position in another System.Collections.Generic.IList{T} to the current
        /// System.Collections.Generic.IList{T}.
        /// </summary>
        /// <typeparam name="T">The type of elements both lists hold.</typeparam>
        /// <param name="srcList">The current System.Collections.Generic.IList{T}.</param>
        /// <param name="list">Elements starting from a position (specified by parameter <paramref name="startIndex"/>) 
        /// in this System.Collections.Generic.IList{T} will be added to the current list.</param>
        /// <param name="startIndex">Specifies a position in <paramref name="list"/> 
        /// starting from which all elements will be added to the current list.</param>
        public static void AddRange<T>(this IList<T> srcList, IList<T> list, int startIndex)
        {
            for (int i = startIndex; i < list.Count; i++)
                srcList.Add(list[i]);
        }

        public static void AddRange<T>(this IList<T> srcList, IList<T> list, int startIndex, int count)
        {
            for (int i = startIndex, j = startIndex + count; i < j; i++)
                srcList.Add(list[i]);
        }

        /// <summary>
        /// Removes the last element from the <see cref="System.Collections.Generic.IList{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list.</param>
        public static void RemoveLast<T>(this IList<T> list)
        {
            list.RemoveAt(list.Count - 1);
        }


        public static T PopLast<T>(this IList<T> list)
        {
            var idx = list.Count - 1;
            var item = list[idx];
            list.RemoveAt(idx);
            return item;
        }

        /// <summary>
        /// Removes elements satisfying the specified condition from the <see cref="System.Collections.Generic.IList{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list.</param>
        /// <param name="predicate">The predicate.</param>
        public static IList<T> Remove<T>(this IList<T> list, Func<T, bool> predicate)
        {
            var listLen = list.Count;
            for (int i = 0; i < listLen;)
            {
                if (predicate(list[i]))
                {
                    list.RemoveAt(i);
                    --listLen;
                }
                else ++i;
            }

            return list;
        }

        public static T[] Remove<T>(this T[] array, Func<T, bool> predicate)
        {
            var arrLen = array.Length;
            var list = new List<T>(arrLen);
            for (int i = 0; i < arrLen; ++i)
            {
                var item = array[i];
                if (!predicate(item))
                    list.Add(item);
            }
            return list.ToArray();
        }

        public static void ChangeKey<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey oldKey, TKey newKey)
        {
            dict.Add(newKey, dict[oldKey]);
            dict.Remove(oldKey);
        }

        public static bool ContainsAny<T>(this HashSet<T> hashSet, IList<T> items)
        {
            foreach (var item in items)
            {
                if (hashSet.Contains(item))
                    return true;
            }
            return false;
        }

        public static bool ContainsAll<T>(this HashSet<T> hashSet, IList<T> items)
        {
            foreach (var item in items)
            {
                if (!hashSet.Contains(item))
                    return false;
            }
            return true;
        }

        public static bool ContainsAnyKey<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IList<TKey> keys)
        {
            foreach (var item in keys)
            {
                if (dictionary.ContainsKey(item))
                    return true;
            }
            return false;
        }

        public static bool ContainsAllKeys<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IList<TKey> keys)
        {
            foreach (var item in keys)
            {
                if (!dictionary.ContainsKey(item))
                    return false;
            }
            return true;
        }




    }
}
