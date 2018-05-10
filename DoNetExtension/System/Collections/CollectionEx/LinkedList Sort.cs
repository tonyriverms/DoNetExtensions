using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    public static partial class GenericCollectionEx
    {
        //VERSION: 1.1
        //UPDATE: 01/21/2013

        /// <summary>
        /// Adds a new node containing the specified value to this <see cref="System.Collections.Generic.LinkedList{T}"/> in an ordered fasion.
        /// </summary>
        /// <typeparam name="TValue">The element type of the linked list.</typeparam>
        /// <typeparam name="TComparable">The comparable type the element of the linked list should be converted to before comparison.</typeparam>
        /// <param name="linkedList">A <see cref="System.Collections.Generic.LinkedList{T}"/>.</param>
        /// <param name="value">The value to add.</param>
        /// <param name="toComparable">A method converting elements in the current linked list to comparable values.</param>
        /// <param name="descending"><c>true</c> if the elements of this linked list should be arranged in descending order; <c>false</c> if ascending order applies.</param>
        public static void SortedAdd<TValue, TComparable>
            (this LinkedList<TValue> linkedList, TValue value, Func<TValue, TComparable> toComparable, bool descending = false)
            where TComparable : IComparable
        {
            var node = linkedList.First;
            var valueKey = toComparable(value);
            while (node != null)
            {
                var nodeValue = node.Value;
                var nodeKey = toComparable(nodeValue);
                if (descending == ((nodeKey.CompareTo(valueKey) < 0)))
                {
                    linkedList.AddBefore(node, value);
                    return;
                }
                node = node.Next;
            }
            linkedList.AddLast(value);
        }

        /// <summary>
        /// Adds a new node containing the specified value to this <see cref="System.Collections.Generic.LinkedList{T}"/> in an ordered fasion.
        /// </summary>
        /// <typeparam name="TValue">The element type of the linked list.</typeparam>
        /// <param name="linkedList">A <see cref="System.Collections.Generic.LinkedList{T}"/>.</param>
        /// <param name="value">The value to add.</param>
        /// <param name="comparison">A <see cref="System.Comparison{T}"/> to use when comparing values.</param>
        /// <param name="descending"><c>true</c> if the elements of this linked list should be arranged in descending order; <c>false</c> if ascending order applies.</param>
        public static void SortedAdd<TValue>
            (this LinkedList<TValue> linkedList, TValue value, Comparison<TValue> comparison, bool descending = false)
        {
            var node = linkedList.First;
            while (node != null)
            {
                var nodeValue = node.Value;
                if (descending == (comparison(nodeValue, value) < 0))
                {
                    linkedList.AddBefore(node, value);
                    return;
                }
                node = node.Next;
            }
            linkedList.AddLast(value);
        }

        /// <summary>
        /// Adds a new node containing the specified value to this <see cref="System.Collections.Generic.LinkedList{T}"/> in an ordered fashion.
        /// </summary>
        /// <typeparam name="T">The element type of the linked list. This type must implement <see cref="System.IComparable"/> interface.</typeparam>
        /// <param name="linkedList">A <c>System.Collections.Generic.LinkedList{T}</c>.</param>
        /// <param name="value">The value to add.</param>
        /// <param name="descending">true if the elements of this linked list should be arrange in descending order; false if ascending order applies.</param>
        public static void SortedAdd<T>
            (this LinkedList<T> linkedList, T value, bool descending = false)
        {
            var node = linkedList.First;

            while (node != null)
            {
                var nodeValue = node.Value;
                if (descending == ((((IComparable)nodeValue).CompareTo(value) < 0)))
                {
                    linkedList.AddBefore(node, value);
                    return;
                }
                node = node.Next;
            }
            linkedList.AddLast(value);
        }
    }
}
