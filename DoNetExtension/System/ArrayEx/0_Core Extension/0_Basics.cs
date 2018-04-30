using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace System
{
    public static partial class ArrayEx
    {

        #region ToArray


        /// <summary>
        /// Returns <c>null</c> if the current list is empty or <c>null</c>; otherwise returns a new array containing the elements of the current list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The current list.</param>
        /// <returns><c>null</c> if the current list is empty or <c>null</c>; otherwise, a new array containing the elements of the current list.</returns>
        public static T[] ToArrayOrNull<T>(this List<T> list)
        {
            if (list.IsNullOrEmpty()) return null;
            else return list.ToArray();
        }

        /// <summary>
        /// Returns <c>null</c> if the current list is empty or <c>null</c>; otherwise returns a new array containing the elements of the current list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The current list.</param>
        /// <returns><c>null</c> if the current list is empty or <c>null</c>; otherwise, a new array containing the elements of the current list.</returns>
        public static T[] ToArrayOrNull<T>(this IList<T> list)
        {
            if (list.IsNullOrEmpty()) return null;
            else return list.ToArray();
        }

        /// <summary>
        /// Returns <c>null</c> if the current collection is empty or <c>null</c>; otherwise returns a new array containing the elements of the current list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The current collection.</param>
        /// <returns><c>null</c> if the current collection is empty or <c>null</c>; otherwise, a new array containing the elements of the current collection.</returns>
        public static T[] ToArrayOrNull<T>(this IEnumerable<T> collection)
        {
            var list = new List<T>();
            foreach (var item in collection)
                list.Add(item);
            return list.ToArrayOrNull();
        }

        /// <summary>
        /// Returns a new array containing the elements of the current list starting at the specified <paramref name="startIndex" />.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The current list.</param>
        /// <param name="startIndex">The element at and after this position in the <paramref name="list"/> are copied to the new array.</param>
        /// <returns><c>null</c> if the current list is empty or <c>null</c>, or there is no element at or after the specified <paramref name="startIndex"/>; otherwise, a new array containing the elements at and after the specified <paramref name="startIndex"/> of the current list.</returns>
        public static T[] ToArrayOrNull<T>(this List<T> list, int startIndex)
        {
            var count = list.Count;
            if (startIndex == count) return null;

            var arr = new T[count - startIndex];
            for (int i = startIndex, j = 0; i < count; ++i, ++j)
                arr[j] = list[i];
            return arr;
        }

        /// <summary>
        /// Returns a new array containing the elements of the current list starting at the specified <paramref name="startIndex" />.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The current list.</param>
        /// <param name="startIndex">The element at and after this position in the <paramref name="list"/> are copied to the new array.</param>
        /// <returns><c>null</c> if the current list is empty or <c>null</c>, or there is no element at or after the specified <paramref name="startIndex"/>; otherwise, a new array containing the elements at and after the specified <paramref name="startIndex"/> of the current list.</returns>
        public static T[] ToArrayOrNull<T>(this IList<T> list, int startIndex)
        {
            var count = list.Count;
            if (startIndex == count) return null;

            var arr = new T[count - startIndex];
            for (int i = startIndex, j = 0; i < count; ++i, ++j)
                arr[j] = list[i];
            return arr;
        }

        /// <summary>
        /// Returns a new array containing the elements of the current collection starting at the specified <paramref name="startIndex" />.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The current collection.</param>
        /// <param name="startIndex">The element at and after this position in the <paramref name="collection"/> are copied to the new array.</param>
        /// <returns><c>null</c> if the current collection is empty or <c>null</c>, or there is no element at or after the specified <paramref name="startIndex"/>; otherwise, a new array containing the elements at and after the specified <paramref name="startIndex"/> of the current collection.</returns>
        public static T[] ToArrayOrNull<T>(this IEnumerable<T> collection, int startIndex)
        {
            var list = new List<T>();
            var idx = 0;
            foreach (var item in collection)
            {
                if (idx >= startIndex)
                    list.Add(item);
                ++idx;
            }
            return list.ToArrayOrNull();
        }


        /// <summary>
        /// Copies the elements of this <see cref="List{T}"/> to an array of <typeparamref name="T"/> and then clear this <see cref="List{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in this <see cref="List{T}"/>.</typeparam>
        /// <param name="list">This list.</param>
        /// <returns>An array containing copies of the elements of the <see cref="List{T}"/>.</returns>
        public static T[] ToArrayThenClear<T>(this List<T> list)
        {
            var arr = list.ToArray();
            list.Clear();
            return arr;
        }

        /// <summary>
        /// Copies the elements of this <see cref="IList{T}"/> to an array of <typeparamref name="T"/> and then clear this <see cref="IList{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in this <see cref="IList{T}"/>.</typeparam>
        /// <param name="list">This list.</param>
        /// <returns>An array containing copies of the elements of the <see cref="IList{T}"/>.</returns>
        public static T[] ToArrayThenClear<T>(this IList<T> list)
        {
            var arr = list.ToArray();
            list.Clear();
            return arr;
        }

        /// <summary>
        /// Copies the elements of this <see cref="List{T}"/> to an array of <typeparamref name="T"/> if this <see cref="List{T}"/> is not <c>null</c> or empty, and then clear this <see cref="List{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in this <see cref="List{T}"/>.</typeparam>
        /// <param name="list">This list.</param>
        /// <returns>An array containing copies of the elements of the <see cref="List{T}"/> if it is neither <c>null</c> or empty; otherwise <c>null</c>.</returns>
        public static T[] ToArrayOrNullThenClear<T>(this List<T> list)
        {
            if (list.IsNullOrEmpty()) return null;
            else return list.ToArrayThenClear();
        }

        /// <summary>
        /// Copies the elements of this <see cref="IList{T}"/> to an array of <typeparamref name="T"/> if this <see cref="IList{T}"/> is not <c>null</c> or empty, and then clear this <see cref="IList{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in this <see cref="IList{T}"/>.</typeparam>
        /// <param name="list">This list.</param>
        /// <returns>An array containing copies of the elements of the <see cref="IList{T}"/> if it is neither <c>null</c> or empty; otherwise <c>null</c>.</returns>
        public static T[] ToArrayOrNullThenClear<T>(this IList<T> list)
        {
            if (list.IsNullOrEmpty()) return null;
            else return list.ToArrayThenClear();
        }

        #endregion

        #region NullOrEmpty

        /// <summary>
        /// Determines whether the current collection is empty.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The current collection.</param>
        /// <returns><c>true</c> if the current collection is an empty collection.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEmpty<T>(this ICollection<T> collection) => collection.Count == 0;

        /// <summary>
        /// Determines whether the current collection is not empty.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The current collection.</param>
        /// <returns><c>true</c> if the current collection is not empty; otherwise <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNotEmpty<T>(this ICollection<T> collection)
        {
            return collection.Count != 0;
        }

        /// <summary>
        /// Determines whether the current list is empty.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The current list.</param>
        /// <returns><c>true</c> if the current list is empty.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEmpty<T>(this List<T> list)
        {
            return list.Count == 0;
        }

        /// <summary>
        /// Determines whether the current list is not empty.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The current list.</param>
        /// <returns><c>true</c> if the current list is not empty; otherwise <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNotEmpty<T>(this List<T> list)
        {
            return list.Count != 0;
        }

        /// <summary>
        /// Determines whether the current collection is <c>null</c> or empty.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The current collection.</param>
        /// <returns><c>true</c> if the current collection is a <c>null</c> reference or an empty collection.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNullOrEmpty<T>(this ICollection<T> collection)
        {
            return collection == null || collection.Count == 0;
        }

        /// <summary>
        /// Determines whether the current collection is not <c>null</c> or empty.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The current collection.</param>
        /// <returns><c>true</c> if the current collection is not a <c>null</c> reference or an empty collection; otherwise <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNotNullOrEmpty<T>(this ICollection<T> collection)
        {
            return collection != null && collection.Count != 0;
        }

        /// <summary>
        /// Determines whether the current <see cref="System.Array"/> is <c>null</c> or empty.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current array.</typeparam>
        /// <param name="array">The current array.</param>
        /// <returns><c>true</c> if the current array is a <c>null</c> reference or an empty array.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNullOrEmpty<T>(this T[] array)
        {
            return array == null || array.Length == 0;
        }

        /// <summary>
        /// Determines whether the current <see cref="System.Collections.Generic.Stack{T}"/> is <c>null</c> or empty.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current stack.</typeparam>
        /// <param name="stack">The current stack.</param>
        /// <returns><c>true</c> if the current stack is a <c>null</c> reference or an empty stack.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNullOrEmpty<T>(this Stack<T> stack)
        {
            return stack == null || stack.Count == 0;
        }

        #endregion

        #region Insert & ShiftInsert

        /// <summary>
        /// Creates a new <see cref="System.Array"/> instance that duplicates the current array with items from another array inserted at the specified index.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="sourceArray">The current array.</param>
        /// <param name="array">All elements of this array will be inserted at the specified <paramref name="index"/>.</param>
        /// <param name="index">The zero-based index at which items from argument <paramref name="array"/> should be inserted.</param>
        /// <returns>A new <see cref="System.Array"/> instance with all elements of the current array and items from another specified array inserted at the specified index.</returns>
        public static T[] Insert<T>(this T[] sourceArray, T[] array, int index)
        {
            if (sourceArray == null) return array;
            var scount = sourceArray.Length;
            var acount = array.Length;
            if (index > scount) index = scount;
            var output = new T[scount + acount];
            int i = 0;
            for (; i < index; ++i)
                output[i] = sourceArray[i];
            for (int j = 0; j < acount; ++i, ++j)
                output[i] = array[j];
            for (int j = index; j < scount; ++j)
                output[i] = sourceArray[j];
            return output;
        }

        /// <summary>
        /// Creates a new <see cref="System.Array"/> instance that duplicates the current array with a given item inserted at the specified index.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="sourceArray">The current array.</param>
        /// <param name="item">The item to be inserted at the specified <paramref name="index"/>.</param>
        /// <param name="index">The zero-based index at which the <paramref name="item"/> should be inserted.</param>
        /// <returns>A new <see cref="System.Array"/> instance with all elements of the current array and the given item inserted at the specified index. </returns>
        public static T[] Insert<T>(this T[] sourceArray, T item, int index)
        {
            if (sourceArray == null) return new T[] { item };
            var scount = sourceArray.Length;
            if (index > scount)
                index = scount;
            var output = new T[scount + 1];
            int i = 0;
            for (; i < index; ++i)
                output[i] = sourceArray[i];

            output[i] = item;

            for (int j = index; j < scount; ++j)
                output[i] = sourceArray[j];
            return output;
        }

        /// <summary>
        /// For internal use only. Inserts an element into the current array at a specified position by shifting rightward a number of elements at and after the insert position. The number is specified by <c><paramref name="shiftLimit"/> - <paramref name="index"/> - 1</c>. The element at position <c><paramref name="shiftLimit"/> - 1</c> will be removed. NOTE that this method bypasses the argument check for better performance.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">The current array.</param>
        /// <param name="item">The new element to be inserted into the array.</param>
        /// <param name="index">The shift begins at this position. <paramref name="item"/> will be placed at this position after the shift.</param>
        /// <param name="shiftLimit">Defining the segment of the array where shift occurs starting at the position specified by <paramref name="index"/>. The number of elements shifted backward is determined by <c><paramref name="shiftLimit"/> - <paramref name="index"/> - 1</c>.</param>
        internal static void InternalShiftInsert<T>(this T[] array, T item, int index, int shiftLimit)
        {
            for (var i = shiftLimit - 1; i > index; --i) array[i] = array[i - 1];
            array[index] = item;
        }

        /// <summary>
        /// Inserts an element into the current array at a specified position by shifting rightward all the elements at and after the position. The last element of the array will be removed.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">The current array.</param>
        /// <param name="item">The new element to be inserted into the array.</param>
        /// <param name="index">The shift begins at this position. <paramref name="item"/> will be placed at this position after the shift.</param>
        public static void ShiftInsert<T>(this T[] array, T item, int index)
        {
            var shiftLimit = array.Length;
            ExceptionHelper.ArgumentRangeRequired("index", index, 0, true, shiftLimit, false);
            InternalShiftInsert(array, item, index, shiftLimit);
        }


        /// <summary>
        /// Inserts an element into the current array at a specified position by shifting rightward a number of elements at and after the insert position. The number is specified by <c><paramref name="shiftLength"/> - 1</c>. The element at position <c><paramref name="index"/> + <paramref name="shiftLength"/> - 1</c> will be removed.
        /// </summary>
        /// <typeparam name="T">The type of elements in the arrray.</typeparam>
        /// <param name="array">The current array.</param>
        /// <param name="item">The new element to be inserted into the array.</param>
        /// <param name="index">The shift begins at this position. <paramref name="item"/> will be placed at this position after the shift.</param>
        /// <param name="shiftLength">Defining the segment of the array where shift occurs starting at position specified by <paramref name="index"/>. The number of elements shifted backward is determined by <c><paramref name="shiftLength"/> - 1</c>.</param>
        public static void ShiftInsert<T>(this T[] array, T item, int index, int shiftLength)
        {
            var shiftLimit = ExceptionHelper.ForwardCheckStartIndexAndLength(index, shiftLength, array.Length, "index", "shiftLength");
            InternalShiftInsert(array, item, index, shiftLimit);
        }

        #endregion

        #region  Remove

        /// <summary>
        /// Creates a new <see cref="System.Array"/> instance that duplicates the current array with the item at the specified index removed.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="sourceArray">The current array.</param>
        /// <param name="index">The index of the item to be removed.</param>
        /// <returns>A new <see cref="System.Array"/> instance that duplicates the current array with the item at the specified index removed. </returns>
        public static T[] RemoveAt<T>(this T[] sourceArray, int index)
        {
            int len = sourceArray.Length;
            var nlen = len - 1;
            var newArray = new T[nlen];
            for (int i = 0; i < index; ++i)
                newArray[i] = sourceArray[i];
            for (int i = index + 1; i < len; ++i)
                newArray[i - 1] = sourceArray[i];

            return newArray;
        }

        /// <summary>
        /// Creates a new <see cref="System.Array"/> instance that duplicates the current array with the specified <paramref name="item"/> removed if it is found; or returns the current array if <paramref name="item"/> is not found.
        /// <para>You may check if the item is found be checking if the reference to the returned array equals the current array.</para>
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="sourceArray">The current array.</param>
        /// <param name="item">The item to remove.</param>
        /// <returns>A new <see cref="System.Array"/> instance that duplicates the current array with the specified <paramref name="item"/> removed if it is found; otherwise, the current array.</returns>
        public static T[] Remove<T>(this T[] sourceArray, T item)
        {
            var idx = sourceArray.IndexOf(item);
            return idx == -1 ? sourceArray : RemoveAt(sourceArray, idx);
        }

        /// <summary>
        /// Creates a new <see cref="System.Array"/> instance that duplicates the current array with the specified <paramref name="items"/> removed if they are found. This method always returns a new array.
        /// <para>You may check if the item is found be checking if the reference to the returned array equals the current array.</para>
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="sourceArray">The current array.</param>
        /// <param name="items">The items to remove.</param>
        /// <returns>A new <see cref="System.Array"/> instance that duplicates the current array with the specified <paramref name="items"/> removed if they are found.</returns>
        public static T[] Remove<T>(this T[] sourceArray, T[] items)
        {
            var sourceArrLen = sourceArray.Length;
            var list = new List<T>(sourceArrLen);
            for (int i = 0; i < sourceArrLen; ++i)
            {
                var curr = sourceArray[i];
                if (!curr.In(items))
                    list.Add(curr);
            }

            return list.ToArray();
        }

        /// <summary>
        /// Returns an array that duplicates elements in the current collectino with the specified <paramref name="item"/> removed.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current collection.</typeparam>
        /// <param name="collection">The current collection.</param>
        /// <param name="item">The item to remove.</param>
        /// <returns>An array that duplicates elements in the current collectino with the specified <paramref name="item"/> removed.</returns>
        public static T[] Remove<T>(this IEnumerable<T> collection, T item)
        {
            var list = new List<T>();
            foreach (var curr in collection)
            {

                if (!curr.Equals(item))
                    list.Add(curr);
            }

            return list.ToArray();
        }

        /// <summary>
        /// Returns an array that duplicates elements in the current collectino with the specified <paramref name="items"/> removed.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current collection.</typeparam>
        /// <param name="collection">The current collection.</param>
        /// <param name="items">The items to remove.</param>
        /// <returns>An array that duplicates elements in the current collectino with the specified <paramref name="items"/> removed.</returns>
        public static T[] Remove<T>(this IEnumerable<T> collection, IEnumerable<T> items)
        {
            var list = new List<T>();
            foreach (var curr in collection)
            {
                if (!curr.In(items))
                    list.Add(curr);
            }

            return list.ToArray();
        }

        /// <summary>
        /// For internal use only. Removes an element in the current array at a specified position by shifting a number of elements after the position foward. The number is specified by <c><paramref name="shiftLimit"/> - <paramref name="index"/> - 1</c>. The element at position <c><paramref name="shiftLimit"/> - 1</c> will be replaced the default value of type <typeparamref name="T"/>. NOTE that this method bypasses the argument check for better performance.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">The current array.</param>
        /// <param name="index">The element at this position will be removed.</param>
        /// <param name="shiftLimit">Defining the segment of the array where shift occurs starting at the position specified by <paramref name="index"/>. The number of elements shifted leftward is determined by <c><paramref name="shiftLimit"/> - <paramref name="index"/> - 1</c>.</param>
        internal static void InternalShiftRemove<T>(this T[] array, int index, int shiftLimit)
        {
            --shiftLimit;
            for (int i = index; i < shiftLimit; ++i) array[i] = array[i + 1];
            array[shiftLimit] = default(T);
        }

        /// <summary>
        /// Removes an element in the current array at a specified position by shifting a number of elements after the position foward. The number is specified by <c><paramref name="shiftLength"/> - 1</c>. The element at position <c><paramref name="index"/> + <paramref name="shiftLength"/> - 1</c> will be replaced the default value of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the arrray.</typeparam>
        /// <param name="array">The current array.</param>
        /// <param name="index">The element at this position will be removed.</param>
        /// <param name="shiftLength">Defining the segment of the array where shift occurs starting at position specified by <paramref name="index"/>. The number of elements shifted leftward is determined by c><paramref name="shiftLength"/> - 1</c>.</param>
        public static void ShiftRemove<T>(this T[] array, int index, int shiftLength)
        {
            var shiftLimit = ExceptionHelper.ForwardCheckStartIndexAndLength(index, shiftLength, array.Length, "index", "shiftLength");
            InternalShiftRemove(array, index, shiftLimit);
        }

        /// <summary>
        /// Removes an element in the current array at a specified position by shifting all the elements after the position foward. The last element of the array will be replaced the default value of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">The current array.</param>
        /// <param name="index">The element at this position will be removed.</param>
        public static void ShiftRemove<T>(this T[] array, int index)
        {
            var shiftLimit = array.Length;
            ExceptionHelper.ArgumentRangeRequired("index", index, 0, true, shiftLimit, false);
            InternalShiftRemove(array, index, shiftLimit);
        }

        /// <summary>
        /// Creates a new <see cref="System.Array" /> instance that duplicates the current array with the first item removed.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="sourceArray">The current array.</param>
        /// <returns>
        /// A new <see cref="System.Array" /> instance that duplicates the current array with the first item removed.
        /// </returns>
        public static T[] RemoveFirst<T>(this T[] sourceArray)
        {
            int len = sourceArray.Length;
            var nlen = len - 1;
            var newArray = new T[nlen];
            for (int i = 1; i < len; ++i)
                newArray[i - 1] = sourceArray[i];

            return newArray;
        }

        /// <summary>
        /// Creates a new <see cref="System.Array" /> instance that duplicates the current array with the last item removed.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="sourceArray">The current array.</param>
        /// <returns>
        /// A new <see cref="System.Array" /> instance that duplicates the current array with the last item removed.
        /// </returns>
        public static T[] RemoveLast<T>(this T[] sourceArray)
        {
            var nlen = sourceArray.Length - 1;
            var newArray = new T[nlen];
            for (int i = 0; i < nlen; ++i)
                newArray[i] = sourceArray[i];

            return newArray;
        }

        #endregion

        #region AddFirstLast

        /// <summary>
        /// Creates a new <see cref="System.Array"/> instance that duplicates the current array with specified collection of items appended at the end. However, if <paramref name="items"/> is <c>null</c> or empty, the instance of the current array will be returned. ALSO NOTE that the current array can be a <c>null</c> reference, in which case a new array containing objects in <paramref name="items"/> will be returned.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="sourceArray">The current array.</param>
        /// <param name="items">The collection of items to be appended at the end.</param>
        /// <returns>A new <see cref="System.Array"/> instance that duplicates the current array with the specified itmes appended at the end.</returns>
        public static T[] AddLast<T>(this T[] sourceArray, ICollection<T> items)
        {
            if (items == null) return sourceArray;
            var itemCount = items.Count;
            if (itemCount == 0) return sourceArray;
            if (sourceArray == null) return items.ToArray();
            var sourceLen = sourceArray.Length;
            if (sourceLen == 0) return items.ToArray();

            var output = new T[sourceLen + itemCount];
            int i = 0;
            for (; i < sourceLen; ++i)
                output[i] = sourceArray[i];

            foreach (var item in items)
            {
                output[i] = item;
                ++i;
            }

            return output;
        }

        /// <summary>
        /// Creates a new <see cref="System.Array"/> instance that duplicates the current array with specified list of items appended at the end. However, if <paramref name="items"/> is <c>null</c> or empty, the instance of the current array will be returned. ALSO NOTE that the current array can be a <c>null</c> reference, in which case a new array containing objects in <paramref name="items"/> will be returned.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="sourceArray">The current array.</param>
        /// <param name="items">The list of items to be appended at the end.</param>
        /// <returns>A new <see cref="System.Array"/> instance that duplicates the current array with the specified itmes appended at the end.</returns>
        public static T[] AddLast<T>(this T[] sourceArray, IList<T> items)
        {
            if (items == null) return sourceArray;
            var itemCount = items.Count;
            if (itemCount == 0) return sourceArray;
            if (sourceArray == null) return items.ToArray();
            var sourceLen = sourceArray.Length;
            if (sourceLen == 0) return items.ToArray();

            var output = new T[sourceLen + itemCount];
            int i = 0;
            for (; i < sourceLen; ++i)
                output[i] = sourceArray[i];
            for (int j = 0; j < itemCount; ++i, ++j)
                output[i] = items[j];

            return output;
        }

        /// <summary>
        /// Creates a new <see cref="System.Array"/> instance that duplicates the current array with specified items appended at the end. However, if <paramref name="items"/> is <c>null</c> or empty, the instance of the current array will be returned. ALSO NOTE that the current array can be a <c>null</c> reference, in which case a copy of <paramref name="items"/> will be returned.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="sourceArray">The current array.</param>
        /// <param name="items">The items to be appended at the end.</param>
        /// <returns>A new <see cref="System.Array"/> instance that duplicates the current array with the specified itmes appended at the end.</returns>
        public static T[] AddLast<T>(this T[] sourceArray, params T[] items)
        {
            if (items == null) return sourceArray;
            var itemCount = items.Length;
            if (itemCount == 0) return sourceArray;
            if (sourceArray == null) return items.Copy();
            var sourceLen = sourceArray.Length;
            if (sourceLen == 0) return items.Copy();

            var output = new T[sourceLen + itemCount];
            int i = 0;
            for (; i < sourceLen; ++i)
                output[i] = sourceArray[i];
            for (int j = 0; j < itemCount; ++i, ++j)
                output[i] = items[j];

            return output;
        }

        /// <summary>
        /// Creates a new <see cref="System.Array"/> instance that duplicates the current array with spcified items inserted at the beginning. However, if <paramref name="items"/> is <c>null</c> or empty, the instance of the current array will be returned. ALSO NOTE that the current array can be a <c>null</c> reference.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="sourceArray">The current array.</param>
        /// <param name="items">The items to be inserted at the beginning.</param>
        /// <returns>A new <see cref="System.Array"/> instance that duplicates the current array with the specified items inserted at the beginning.</returns>
        public static T[] AddFirst<T>(this T[] sourceArray, params T[] items)
        {
            //! DO NOTE SIMPLY USE items.AddLast, which is inconsistent with the description of this method.
            //! When items is null, this method should return the original instance of sourceArray (the current array), however, items.AddLast will return a new instance.

            if (items == null) return sourceArray;
            var itemCount = items.Length;
            if (itemCount == 0) return sourceArray;
            if (sourceArray == null) return items.ToArray();
            var sourceLen = sourceArray.Length;
            if (sourceLen == 0) return items.ToArray();

            var output = new T[sourceLen + itemCount];
            int i = 0;
            for (; i < itemCount; ++i)
                output[i] = items[i];
            for (int j = 0; j < sourceLen; ++i, ++j)
                output[i] = sourceArray[j];

            return output;
        }

        /// <summary>
        /// Creates a new <see cref="System.Array"/> instance that duplicates the current array with specified list of items inserted at the beginning. However, if <paramref name="items"/> is <c>null</c> or empty, the instance of the current array will be returned. ALSO NOTE that the current array can be a <c>null</c> reference.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="sourceArray">The current array.</param>
        /// <param name="items">The list of items to be inserted at the beginning.</param>
        /// <returns>A new <see cref="System.Array"/> instance that duplicates the current array with the specified items inserted at the beginning.</returns>
        public static T[] AddFirst<T>(this T[] sourceArray, IList<T> items)
        {
            if (items == null) return sourceArray;
            var itemCount = items.Count;
            if (itemCount == 0) return sourceArray;
            if (sourceArray == null) return items.ToArray();
            var sourceLen = sourceArray.Length;
            if (sourceLen == 0) return items.ToArray();

            var output = new T[sourceLen + itemCount];
            int i = 0;
            for (; i < itemCount; ++i)
                output[i] = items[i];
            for (int j = 0; j < sourceLen; ++i, ++j)
                output[i] = sourceArray[j];

            return output;
        }

        /// <summary>
        /// Creates a new <see cref="System.Array"/> instance that duplicates the current array with specified items appended at the end.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="sourceArray">The current array.</param>
        /// <param name="arrayOfItems">Elements from all provided arrays will be appended at the end.</param>
        /// <returns>A new <see cref="System.Array"/> instance that duplicates the current array with the specified itmes appended at the end.</returns>
        public static T[] AddLast<T>(this T[] sourceArray, params T[][] arrayOfItems)
        {
            if (sourceArray == null) return arrayOfItems.Merge();

            int k = sourceArray.Length;
            var count = arrayOfItems.Sum(array => array == null ? 0 : array.Length) + k;
            var narr = new T[count];
            sourceArray.CopyTo(narr, 0);
            --k;
            for (int i = 0, count2 = arrayOfItems.Length; i < count2; ++i)
            {
                var currArray = arrayOfItems[i];
                if (currArray != null)
                {
                    for (int j = 0, count3 = currArray.Length; j < count3; ++j)
                        narr[++k] = currArray[j];
                }
            }
            return narr;
        }

        /// <summary>
        /// Creates a new <see cref="System.Array"/> instance that duplicates the current array with spcified items inserted at the beginning.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="sourceArray">The current array.</param>
        /// <param name="arrayOfItems">Elements from all provided arrays will be appended at the beginning.</param>
        /// <returns>A new <see cref="System.Array"/> instance that duplicates the current array with the specified items inserted at the beginning.</returns>
        public static T[] AddFirst<T>(this T[] sourceArray, params T[][] arrayOfItems)
        {
            if (sourceArray == null) return arrayOfItems.Merge();

            var count = arrayOfItems.Sum(array => array == null ? 0 : array.Length) + sourceArray.Length;
            var narr = new T[count];
            int k = -1;
            for (int i = 0, count2 = arrayOfItems.Length; i < count2; ++i)
            {
                var currArray = arrayOfItems[i];
                if (currArray != null)
                {
                    for (int j = 0, count3 = currArray.Length; j < count3; ++j)
                        narr[++k] = currArray[j];
                }
            }
            sourceArray.CopyTo(narr, k + 1);

            return narr;
        }

        /// <summary>
        /// Creates a new <see cref="System.Array"/> instance that duplicates the current array with a specified item appended at the end.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="sourceArray">The current array.</param>
        /// <param name="item">The item to be appended at the end.</param>
        /// <returns>A new <see cref="System.Array"/> instance that duplicates the current array with the specified item appended at the end.</returns>
        public static T[] AddLast<T>(this T[] sourceArray, T item)
        {
            if (sourceArray == null) return new T[] { item };
            var scount = sourceArray.Length;
            var output = new T[scount + 1];
            int i = 0;
            for (; i < scount; ++i)
                output[i] = sourceArray[i];
            output[scount] = item;

            return output;
        }

        /// <summary>
        /// Creates a new <see cref="System.Array"/> instance that duplicates the current array with a specified item inserted at the beginning.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="sourceArray">The current array.</param>
        /// <param name="item">The item to be inserted at the beginning.</param>
        /// <returns>A new <see cref="System.Array"/> instance that duplicates the current array with the specified item inserted at the beginning.</returns>
        public static T[] AddFirst<T>(this T[] sourceArray, T item)
        {
            if (sourceArray == null) return new T[] { item };
            var scount = sourceArray.Length;
            var output = new T[scount + 1];
            int i = 1, j = 0;
            for (; j < scount; ++i, ++j)
                output[i] = sourceArray[j];
            output[0] = item;

            return output;
        }

        #endregion


        public static void Sort<T, TComparable>(this List<T> list, Func<T, TComparable> comparable) where TComparable : IComparable
        {
            list.Sort((item1, item2) => comparable(item1).CompareTo(comparable(item2)));
        }

        /// <summary>
        /// Gets the value at the specified position from this array; of the position is invalid (e.g. this array is <c>null</c> or empty, or the position exceeds this array's length), then a <c>default<typeparamref name="T"/>)</c> is returned.
        /// </summary>
        /// <typeparam name="T">They type of elements in the array.</typeparam>
        /// <param name="array">The current array.</param>
        /// <param name="index">The position of the element to retrieve.</param>
        /// <returns>The value at the specified position from this array, if the position is valid; otherwise, <c>default<typeparamref name="T"/>)</c>.</returns>
        public static T GetValueOrDefault<T>(this object[] array, int index)
        {
            if (array != null && index < array.Length) return (T)array[index];
            else return default(T);
        }

        /// <summary>
        /// Gets the value at the specified position from this array; of the position is invalid (e.g. this array is <c>null</c> or empty, or the position exceeds this array's length), then the specified <paramref name="default" /> is returned.
        /// </summary>
        /// <typeparam name="T">They type of elements in the array.</typeparam>
        /// <param name="array">The current array.</param>
        /// <param name="index">The position of the element to retrieve.</param>
        /// <param name="default">The default object to return when the <paramref name="index"/> is invalid.</param>
        /// <returns>The value at the specified position from this array, if the position is valid; otherwise, the specified <paramref name="default" />.</returns>
        public static T GetValueOrDefault<T>(this object[] array, int index, T @default)
        {
            if (array != null && index < array.Length) return (T)array[index];
            else return @default;
        }


        /// <summary>
        /// Swaps two elements at the specified indexes.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="arr">The current array.</param>
        /// <param name="indexA">The element at this index will be replaced by the element at <paramref name="indexB"/>.</param>
        /// <param name="indexB">The element at this index will be replaced by the element at <paramref name="indexA"/>.</param>
        public static void Swap<T>(this T[] arr, int indexA, int indexB)
        {
            var tmp = arr[indexA];
            arr[indexA] = arr[indexB];
            arr[indexB] = tmp;
        }

        /// <summary>
        /// Returns a read-only wrapper for the current array.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The current array.</param>
        /// <returns>A read-only <see cref="ReadOnlyCollection{T}"/> wrapper for the current array.</returns>
        public static ReadOnlyCollection<T> AsReadOnly<T>(this T[] array)
        {
            return Array.AsReadOnly(array);
        }

        /// <summary>
        /// Returns a read-only wrapper for a segment of the current array.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="offset">The zero-based index of the first element of the segment.</param>
        /// <param name="count">The number of elements in the segment.</param>
        /// <param name="array">The current array.</param>
        /// <returns>A read-only <see cref="ReadOnlyCollection{T}"/> wrapper for the specified segment of the current array.</returns>
        public static ReadOnlyCollection<T> AsReadOnly<T>(this T[] array, int offset, int count)
        {
            return new ReadOnlyCollection<T>(new ArraySegment<T>(array, offset, count));
        }

        /// <summary>
        /// Creates a shallow copy of the current <see cref="System.Array"/>. This method is a simple wrap of the <see cref="Clone"/> method but returns a strong-typed array.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current array.</typeparam>
        /// <param name="array">The current array.</param>
        /// <returns>A shallow copy of the current <see cref="System.Array"/>.</returns>
        public static T[] Copy<T>(this T[] array)
        {
            return (T[])array.Clone();
        }

        /// <summary>
        /// Creates a shallow copy of the current <see cref="System.Array" />, starting from <paramref name="startIndex" />, of length <paramref name="length" />.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current array.</typeparam>
        /// <param name="array">The current array.</param>
        /// <param name="startIndex">The start position of the copy.</param>
        /// <param name="length">The number of elements to copy.</param>
        /// <returns>A shallow copy of the current <see cref="System.Array" />, starting from <paramref name="startIndex" />, of length <paramref name="length" />.</returns>
        public static T[] Copy<T>(this T[] array, int startIndex, int length)
        {
            var output = new T[length];
            for (int i = 0; i < length; ++i, ++startIndex)
                output[i] = array[startIndex];
            return output;
        }

        /// <summary>
        /// Creates a new <see cref="System.Array"/> instance that merges all elements of the current <see cref="System.Array"/> objects.
        /// </summary>
        /// <typeparam name="T">The type of elements in every <see cref="System.Array"/>.</typeparam>
        /// <param name="arrays">The current <see cref="System.Array"/> objects.</param>
        /// <returns>A new <see cref="System.Array"/> instance that merges all elements of the current <see cref="System.Array"/> objects.</returns>
        public static T[] Merge<T>(this T[][] arrays)
        {
            var count = arrays.Sum(array => array?.Length ?? 0);
            var mergedArr = new T[count];
            int k = -1;
            for (int i = 0, count2 = arrays.Length; i < count2; ++i)
            {
                var currArray = arrays[i];
                if (currArray != null)
                {
                    for (int j = 0, count3 = currArray.Length; j < count3; ++j)
                        mergedArr[++k] = currArray[j];
                }
            }
            return mergedArr;
        }


        /// <summary>
        /// Creates a new <see cref="System.Array"/> instance that merges all elements of the current collection of <see cref="System.Array"/> objects.
        /// </summary>
        /// <typeparam name="T">The type of elements in every <see cref="System.Array"/>.</typeparam>
        /// <param name="arraySeq">The current collection of <see cref="System.Array"/> objects.</param>
        /// <returns>A new <see cref="System.Array"/> instance that merges all elements of the current <see cref="System.Array"/> collection.</returns>
        public static T[] Merge<T>(this IEnumerable<T[]> arraySeq)
        {
            var list = new List<T>();
            foreach (var arr in arraySeq)
                list.AddRange(arr);

            return list.ToArray();
        }

        /// <summary>
        /// Returns a string that concatenates all string representations of the elements in the current <see cref="IEnumerable"/> sequence by the specified <paramref name="connector"/>.
        /// </summary>
        /// <param name="sequence">The sequence of which the elements' string representations are to be concatenated.</param>
        /// <param name="connector">The connector that connects the string representations.</param>
        /// <returns>A string that concatenates all string representations of the elements in the current enumerable sequence.</returns>
        public static string ToConcatString(this IEnumerable sequence, string connector)
        {
            var ie = sequence.GetEnumerator();
            var sb = new StringBuilder();
            if (!ie.MoveNext()) return sb.ToString();
            sb.Append(ie.Current);
            while (ie.MoveNext())
            {
                sb.Append(connector);
                sb.Append(ie.Current);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Returns a string that concatenates all string representations of the elements in the current <see cref="IEnumerable"/> sequence by the specified <paramref name="connector"/>.
        /// </summary>
        /// <param name="sequence">The sequence of which the elements' string representations are to be concatenated.</param>
        /// <param name="connector">The connector that connects the string representations.</param>
        /// <returns>A string that concatenates all string representations of the elements in the current enumerable sequence.</returns>
        public static string ToConcatString(this IEnumerable sequence, char connector)
        {
            var ie = sequence.GetEnumerator();
            var sb = new StringBuilder();
            if (!ie.MoveNext()) return sb.ToString();
            sb.Append(ie.Current);
            while (ie.MoveNext())
            {
                sb.Append(connector);
                sb.Append(ie.Current);
            }
            return sb.ToString();
        }
    }
}
