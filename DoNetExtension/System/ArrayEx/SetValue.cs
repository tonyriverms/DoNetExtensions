using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class ArrayEx
    {
        //UPDATE: 01/19/2013
        //VERSION: 2.01

        #region Array

        /// <summary>
        /// Sets all elements of a segment of this one-dimensional <see cref="System.Array"/> to the same specified value.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">This array.</param>
        /// <param name="value">All elements of the segment defined by <paramref name="startIndex"/> and <paramref name="length"/> will be assigned to this value.</param>
        /// <param name="startIndex">A 64-bit integer that represents the position of the first element to set.</param>
        /// <param name="length">The number of elements to set from the position indicated by <paramref name="startIndex" />.</param>
        public static void SetValue<T>(this T[] array, T value, long startIndex, long length)
        {
            var end = startIndex + length;
            for (long i = startIndex; i < end; ++i)
                array[i] = value;
        }

        /// <summary>
        /// Sets all elements of a segment of this one-dimensional <see cref="System.Array"/> to the same specified value.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">This array.</param>
        /// <param name="value">All elements of the segment defined by <paramref name="startIndex"/> and <paramref name="length"/> will be assigned to this value.</param>
        /// <param name="startIndex">An integer that represents the position of the first element to set.</param>
        /// <param name="length">The number of elements to set from the position indicated by <paramref name="startIndex" />.</param>
        public static void SetValue<T>(this T[] array, T value, int startIndex, int length)
        {
            var end = startIndex + length;
            for (int i = startIndex; i < end; ++i)
                array[i] = value;
        }

        /// <summary>
        /// Sets all elements from a specified position to the end of this one-dimensional <see cref="System.Array"/> to the same value.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">This array.</param>
        /// <param name="value">All elements since position specified by <paramref name="startIndex"/> to the end of this array will be assigned to this value.</param>
        /// <param name="startIndex">A 64-bit integer that represents the position of the first element to set.</param>
        public static void SetValue<T>(this T[] array, T value, long startIndex)
        {
            var end = array.Length;
            for (long i = startIndex; i < end; ++i)
                array[i] = value;
        }

        /// <summary>
        /// Sets all elements since a specified position to the end of this one-dimensional <see cref="System.Array"/> to the same specified value.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">This array.</param>
        /// <param name="value">All elements since position specified by <paramref name="startIndex"/> to the end of this array will be assigned to this value.</param>
        /// <param name="startIndex">An integer that represents the position of the first element to set.</param>
        public static void SetValue<T>(this T[] array, T value, int startIndex)
        {
            var end = array.Length;
            for (int i = startIndex; i < end; ++i)
                array[i] = value;
        }

        /// <summary>
        /// Sets all elements of this one-dimensional <see cref="System.Array"/> to the same specified value.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">This array.</param>
        /// <param name="value">All elements in the array will be assigned this value.</param>
        public static void SetAll<T>(this T[] array, T value)
        {
            var end = array.Length;
            for (long i = 0; i < end; ++i)
                array[i] = value;
        }

        #endregion

        #region List

        /// <summary>
        /// Sets all elements of a segment of this list to the same specified value.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">This list.</param>
        /// <param name="value">All elements of the segment defined by <paramref name="startIndex"/> and <paramref name="length"/> will be assigned to this value.</param>
        /// <param name="startIndex">An integer that represents the position of the first element to set.</param>
        /// <param name="length">The number of elements to set from the position indicated by <paramref name="startIndex" />.</param>
        public static void SetValue<T>(this IList<T> list, T value, int startIndex, int length)
        {
            var end = startIndex + length;
            for (int i = startIndex; i < end; ++i)
                list[i] = value;
        }

        /// <summary>
        /// Sets all elements since a specified position to the end of this list to the same specified value.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">This list.</param>
        /// <param name="value">All elements since position specified by <paramref name="startIndex"/> to the end of this list will be assigned to this value.</param>
        /// <param name="startIndex">An integer that represents the position of the first element to set.</param>
        public static void SetValue<T>(this IList<T> list, T value, int startIndex)
        {
            var end = list.Count;
            for (int i = startIndex; i < end; ++i)
                list[i] = value;
        }

        /// <summary>
        /// Sets all elements of this list to the same specified value.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">This list.</param>
        /// <param name="value">All elements in the list will be assigned this value.</param>
        public static void SetValue<T>(this IList<T> list, T value)
        {
            var end = list.Count;
            for (int i = 0; i < end; ++i)
                list[i] = value;
        }

        #endregion

        #region LinkedList

        /// <summary>
        /// Sets all elements of this linked list to the same specified value.
        /// </summary>
        /// <typeparam name="T">The type of elements in the linked list.</typeparam>
        /// <param name="list">This linked list.</param>
        /// <param name="value">All elements in the linked list will be assigned this value.</param>
        public static void SetValue<T>(this LinkedList<T> list, T value)
        {
            var node = list.First;
            while (node != null)
            {
                node.Value = value;
                node = node.Next;
            }
        }

        #endregion
    }
}
