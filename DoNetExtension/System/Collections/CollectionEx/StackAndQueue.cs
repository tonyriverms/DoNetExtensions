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
        /// Adds a pair of values to the end of this pair queue.
        /// </summary>
        /// <typeparam name="T1">The type of the first value in a pair.</typeparam>
        /// <typeparam name="T2">The type of the second value in a pair.</typeparam>
        /// <param name="queue">This pair queue.</param>
        /// <param name="value1">The first value of the pair to add.</param>
        /// <param name="value2">The second value of the pair to add.</param>
        public static void Enqueue<T1, T2>(this Queue<Pair<T1, T2>> queue, T1 value1, T2 value2)
        {
            queue.Enqueue(new Pair<T1, T2>(value1, value2));
        }

        /// <summary>
        /// Inserts a pair of values at the top of this pair stack.
        /// </summary>
        /// <typeparam name="T1">The type of the first value in a pair.</typeparam>
        /// <typeparam name="T2">The type of the second value in a pair.</typeparam>
        /// <param name="queue">This pair stack.</param>
        /// <param name="value1">The first value of the pair to push.</param>
        /// <param name="value2">The second value of the pair to push.</param>
        public static void Push<T1, T2>(this Stack<Pair<T1, T2>> stack, T1 value1, T2 value2) => stack.Push(new Pair<T1, T2>(value1, value2));

        /// <summary>
        /// Adds a key/value pair to the end of this key/value pair queue.
        /// </summary>
        /// <typeparam name="TKey">The type of the key in a key/value pair.</typeparam>
        /// <typeparam name="TValue">The type of the value in a key/value pair.</typeparam>
        /// <param name="queue">This key/value pair queue.</param>
        /// <param name="key">The key to add.</param>
        /// <param name="value">The value to add.</param>
        public static void Enqueue<TKey, TValue>(this Queue<KeyValuePair<TKey, TValue>> queue, TKey key, TValue value)
        {
            queue.Enqueue(new KeyValuePair<TKey, TValue>(key, value));
        }

        /// <summary>
        /// Inserts a key/value pair at the top of this key/value pair stack.
        /// </summary>
        /// <typeparam name="TKey">The type of the key in a key/value pair.</typeparam>
        /// <typeparam name="TValue">The type of the value in a key/value pair.</typeparam>
        /// <param name="stack">This key/value pair stack.</param>
        /// <param name="key">The key to insert.</param>
        /// <param name="value">The value to insert.</param>
        public static void Push<TKey, TValue>(this Stack<KeyValuePair<TKey, TValue>> stack, TKey key, TValue value)
        {
            stack.Push(new KeyValuePair<TKey, TValue>(key, value));
        }

        /// <summary>
        /// Adds an array of objects to the end of the <see cref="Collections.Generic.Queue{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the queue.</typeparam>
        /// <param name="queue">This queue.</param>
        /// <param name="items">The array of objects to add to the <see cref="Collections.Generic.Queue{T}"/>.</param>
        public static void Enqueue<T>(this Queue<T> queue, params T[] items)
        {
            if (items == null) return;
            for (int i = 0; i < items.Length; i++)
                queue.Enqueue(items[i]);
        }

        /// <summary>
        /// Adds a sequence of objects to the end of the <see cref="Collections.Generic.Queue{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the queue.</typeparam>
        /// <param name="queue">This queue.</param>
        /// <param name="items">The sequence of objects to add to the <see cref="Collections.Generic.Queue{T}"/>.</param>
        public static void Enqueue<T>(this Queue<T> queue, IEnumerable<T> items)
        {
            if (items != null)
            {
                foreach (var item in items)
                    queue.Enqueue(item);
            }
        }

        /// <summary>
        /// Removes and returns the object at the beginning of the <see cref="System.Collections.Generic.Queue{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the queue.</typeparam>
        /// <param name="queue">This queue.</param>
        /// <param name="count">The number of objects to be removed from the beginning of the queue.</param>
        /// <returns>The objects that are removed from the beginning of the <see cref="System.Collections.Generic.Queue{T}"/>.</returns>
        public static T[] Dequeue<T>(this Queue<T> queue, int count)
        {
            var output = new T[count];
            for (int i = 0; i < count; i++)
                output[i] = queue.Dequeue();
            return output;
        }

        /// <summary>
        /// Inserts objects at the top of the <see cref="System.Collections.Generic.Stack{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the stack.</typeparam>
        /// <param name="stack">This stack.</param>
        /// <param name="items">The objects to push onto the <see cref="System.Collections.Generic.Stack{T}"/>.</param>
        public static void Push<T>(this Stack<T> stack, params T[] items)
        {
            if (items == null) return;
            for (var i = 0; i < items.Length; ++i)
                stack.Push(items[i]);
        }

        /// <summary>
        /// Removes and returns the objects at the top of the <see cref="System.Collections.Generic.Stack{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the stack.</typeparam>
        /// <param name="stack">This stack.</param>
        /// <param name="count">The number of objects to be removed from the top of the stack.</param>
        /// <returns>The objects removed from the top of the <see cref="System.Collections.Generic.Stack{T}"/>.</returns>
        public static T[] Pop<T>(this Stack<T> stack, int count)
        {
            var output = new T[count];
            for (var i = 0; i < count; ++i)
                output[i] = stack.Pop();
            return output;
        }
    }
}
