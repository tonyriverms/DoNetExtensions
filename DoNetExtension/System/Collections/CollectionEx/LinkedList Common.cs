using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    public static partial class GenericCollectionEx
    {
        /// <summary>
        /// Creates an array of <see cref="LinkedListNode{T}"/> objects from the <see cref="LinkedList{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the linked list.</typeparam>
        /// <param name="linkedList">The linked list.</param>
        /// <returns>A <see cref="LinkedListNode{T}"/> array created from the <see cref="LinkedList{T}"/>.</returns>
        public static LinkedListNode<T>[] ToNodeArray<T>(this LinkedList<T> linkedList)
        {
            var count = linkedList.Count;
            var nodes = new LinkedListNode<T>[count];

            var node = linkedList.First;
            for (int i = 0; i < count; ++i)
            {
                nodes[i] = node;
                node = node.Next;
            }

            return nodes;
        }

        /// <summary>
        /// Removes all nodes that satisfy conditions defined by <paramref name="predicate"/> from the current <see cref="Generic.LinkedList{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of element in the current <see cref="Generic.LinkedList{T}"/>.</typeparam>
        /// <param name="linkedList">The current <see cref="Generic.LinkedList{T}"/>.</param>
        /// <param name="predicate">A delegate defining what elements should be removed from the current <see cref="Generic.LinkedList{T}"/>.</param>
        /// <returns>The current <see cref="Generic.LinkedList{T}"/> with specified nodes removed.</returns>
        public static LinkedList<T> RemoveAll<T>(this LinkedList<T> linkedList, Func<T, bool> predicate)
        {
            var node = linkedList.First;
            while (node != null)
            {
                var nextNode = node.Next;
                if (predicate(node.Value))
                    linkedList.Remove(node);
                node = nextNode;
            }
            return linkedList;
        }

        /// <summary>
        /// Removes all nodes of the specified <paramref name="value"/> from the current <see cref="Generic.LinkedList{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of element in the current <see cref="Generic.LinkedList{T}"/>.</typeparam>
        /// <param name="linkedList">The current <see cref="Generic.LinkedList{T}"/>.</param>
        /// <param name="value">The value to remove from the current <see cref="Generic.LinkedList{T}"/>.</param>
        /// <returns>The current <see cref="Generic.LinkedList{T}"/> with specified nodes removed.</returns>
        public static LinkedList<T> RemoveAll<T>(this LinkedList<T> linkedList, T value)
        {
            var node = linkedList.First;
            while (node != null)
            {
                var nextNode = node.Next;
                if (value.Equals(node.Value))
                    linkedList.Remove(node);
                node = nextNode;
            }
            return linkedList;
        }

        /// <summary>
        /// Adds a pair of values to the end of the current <see cref="Generic.LinkedList{T}"/>.
        /// </summary>
        /// <typeparam name="TValue1">The type of the first value.</typeparam>
        /// <typeparam name="TValue2">The type of the second value.</typeparam>
        /// <param name="linkedList">The current <see cref="Generic.LinkedList{T}"/>.</param>
        /// <param name="value1">The first value to add at the end of the current <see cref="Generic.LinkedList{T}"/>.</param>
        /// <param name="value2">The second value to add at the end of the current <see cref="Generic.LinkedList{T}"/>.</param>
        /// <returns>The current <see cref="Generic.LinkedList{T}"/> with the pair of values added.</returns>
        public static LinkedList<Pair<TValue1, TValue2>>
            AddLast<TValue1, TValue2>(this LinkedList<Pair<TValue1, TValue2>> linkedList, TValue1 value1, TValue2 value2)
        {
            linkedList.AddLast(new Pair<TValue1, TValue2>(value1, value2));
            return linkedList;
        }

        /// <summary>
        /// Adds a pair of values to the beginning of the current <see cref="Generic.LinkedList{T}"/>.
        /// </summary>
        /// <typeparam name="TValue1">The type of the first value.</typeparam>
        /// <typeparam name="TValue2">The type of the second value.</typeparam>
        /// <param name="linkedList">The current <see cref="Generic.LinkedList{T}"/>.</param>
        /// <param name="value1">The first value to add at the beginning of the current <see cref="Generic.LinkedList{T}"/>.</param>
        /// <param name="value2">The second value to add at the beginning of the current <see cref="Generic.LinkedList{T}"/>.</param>
        /// <returns>The current <see cref="Generic.LinkedList{T}"/> with the pair of values added.</returns>
        public static LinkedList<Pair<TValue1, TValue2>>
            AddFirst<TValue1, TValue2>(this LinkedList<Pair<TValue1, TValue2>> linkedList, TValue1 value1, TValue2 value2)
        {
            linkedList.AddFirst(new Pair<TValue1, TValue2>(value1, value2));
            return linkedList;
        }

        /// <summary>
        /// Adds each element in an array/list of values to the end of current <see cref="Generic.LinkedList{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current <see cref="Generic.LinkedList{T}"/>.</typeparam>
        /// <param name="linkedList">The current <see cref="Generic.LinkedList{T}"/>.</param>
        /// <param name="values">An array/list of values to add at the end of current <see cref="Generic.LinkedList{T}"/>.</param>
        /// <returns>The current <see cref="Generic.LinkedList{T}"/> with values added.</returns>
        public static LinkedList<T> AddLast<T>(this LinkedList<T> linkedList, IList<T> values)
        {
            if (values != null)
            {
                var valueCount = values.Count;
                if (valueCount != 0)
                {
                    for (int i = 0; i < valueCount; ++i)
                        linkedList.AddLast(values[i]);
                }
            }
            return linkedList;
        }

        /// <summary>
        /// Adds each element in an sequence of values to the end of current <see cref="Generic.LinkedList{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current <see cref="Generic.LinkedList{T}"/>.</typeparam>
        /// <param name="linkedList">The current <see cref="Generic.LinkedList{T}"/>.</param>
        /// <param name="values">An sequence of values to add at the end of current <see cref="Generic.LinkedList{T}"/>.</param>
        /// <returns>The current <see cref="Generic.LinkedList{T}"/> with values added.</returns>
        public static LinkedList<T> AddLast<T>(this LinkedList<T> linkedList, IEnumerable<T> values)
        {
            foreach (var value in values)
                linkedList.AddLast(value);
            return linkedList;
        }

        /// <summary>
        /// Adds each element in an array/list of values to the beginning of current <see cref="Generic.LinkedList{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current <see cref="Generic.LinkedList{T}"/>.</typeparam>
        /// <param name="linkedList">The current <see cref="Generic.LinkedList{T}"/>.</param>
        /// <param name="values">An array/list of values to add at the beginning of current <see cref="Generic.LinkedList{T}"/>.</param>
        /// <returns>The current <see cref="Generic.LinkedList{T}"/> with values added.</returns>
        public static LinkedList<T> AddFirst<T>(this LinkedList<T> linkedList, IList<T> values)
        {
            for (int i = values.Count - 1; i != -1; i--)
                linkedList.AddFirst(values[i]);
            return linkedList;
        }

        /// <summary>
        /// Adds each element in an sequence of values to the beginning of current <see cref="Generic.LinkedList{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the current <see cref="Generic.LinkedList{T}"/>.</typeparam>
        /// <param name="linkedList">The current <see cref="Generic.LinkedList{T}"/>.</param>
        /// <param name="values">An sequence of values to add at the beginning of current <see cref="Generic.LinkedList{T}"/>.</param>
        /// <returns>The current <see cref="Generic.LinkedList{T}"/> with values added.</returns>
        public static LinkedList<T> AddFirst<T>(this LinkedList<T> linkedList, IEnumerable<T> values)
        {
            var tmpArr = values.ToArray();
            var j = tmpArr.Length;
            for (int i = j - 1; i >= 0; i--)
                linkedList.AddFirst(tmpArr[i]);
            return linkedList;
        }

    }
}
