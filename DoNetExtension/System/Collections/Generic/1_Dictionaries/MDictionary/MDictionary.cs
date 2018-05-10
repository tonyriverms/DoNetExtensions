using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Collections.Generic
{
    //TODO switching LinkedList to SinglyLinkedList

    /// <summary>
    /// Represents a collection of key/value pairs. Different values can be mapped to the same key.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in this dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in this dictionary.</typeparam>
    /// <remarks>
    /// <para>This class inherits from the <see cref="Dictionary&lt;TKey,LinkedList&lt;TValue&gt;&gt;"/> class and you may directly operate on the underlying linked list. However, NOTE that the <c>this</c> indexer is modified to return a <typeparamref name="TValue"/> array instead of a linked list.</para>
    /// <para>This class also implements the <see cref="IMDictionary&lt;TKey,TValue&gt;"/> interface, but it is highly not recommended to operate on the underlying linked list through this interface.</para>
    /// </remarks>
    public class MDictionary<TKey, TValue> : Dictionary<TKey, LinkedList<TValue>>, IMDictionary<TKey, TValue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MDictionary&lt;TKey,TValue&gt;" /> class.
        /// </summary>
        /// <param name="capacity">The initial number of lists that the <see cref="MDictionary&lt;TKey,TValue&gt;" /> can contain.</param>
        public MDictionary(int capacity) : base(capacity) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MDictionary&lt;TValue&gt;" /> class.
        /// </summary>
        public MDictionary() : base() { }

        /// <summary>
        /// Removes a value associated with the specified key from this dictionary.
        /// </summary>
        /// <param name="key">The key of the value to remove.</param>
        /// <param name="value">The value to remove. Multiple values associated with one key are allowed in this dictionary, so this argument is needed to remove the value.
        /// </param>
        public void Remove(TKey key, TValue value)
        {
            if (base.TryGetValue(key, out LinkedList<TValue> list))
            {
                list.Remove(value);
                if (list.Count == 0) base.Remove(key);
            }
        }

        /// <summary>
        /// Removes values associated with the specified key from this dictionary.
        /// </summary>
        /// <param name="key">The key of the values to remove.</param>
        /// <param name="values">A list of the values to remove.</param>
        public void Remove(TKey key, IList<TValue> values)
        {
            if (base.TryGetValue(key, out LinkedList<TValue> list))
            {
                foreach (var value in values) list.Remove(value);
                if (list.Count == 0) base.Remove(key);
            }
        }

        /// <summary>
        /// Removes entries with the specified value form this <see cref="MDictionary{TKey, TValue}" />.
        /// </summary>
        /// <param name="value">Entries with this specified value will be removed from this dictionary.</param>
        /// <returns>The number of entries removed from this dictionary.</returns>
        public int RemoveByValue(TValue value)
        {
            var removeList = new List<TKey>();
            var removeCount = 0;
            foreach (var pair in this)
            {
                var list = pair.Value;
                var len = list.Count;
                list.RemoveAll(value);
                var len2 = list.Count;

                if (len2 == 0)
                {
                    removeList.Add(pair.Key);
                    removeCount = len;
                }
                else
                    removeCount = len2 - len;
            }

            foreach (var key in removeList)
                base.Remove(key);

            return removeCount;
        }

        /// <summary>
        /// Removes entries satisfying the specified <paramref name="predicate"/> from this <see cref="MDictionary{TKey, TValue}" />.
        /// </summary>
        /// <param name="predicate">Entries satisfying this predicate will be removed from this dictionary.</param>
        /// <returns>The number of entries removed from this dictionary.</returns>
        public int RemoveByValue(Func<TValue, bool> predicate)
        {
            var removeList = new List<TKey>();
            var removeCount = 0;
            foreach (var pair in this)
            {
                var list = pair.Value;
                var len = list.Count;
                list.RemoveAll(predicate);
                var len2 = list.Count;

                if (len2 == 0)
                {
                    removeList.Add(pair.Key);
                    removeCount = len;
                }
                else
                    removeCount = len2 - len;
            }

            foreach (var key in removeList)
                base.Remove(key);

            return removeCount;
        }

        /// <summary>
        /// Gets the total number of key/value pairs contained in this dictionary.
        /// <para>NOTE that this value may be different from property <c>Keys.Count</c> and <c>Values.Count</c>. To get the number of keys, use <c>Keys.Count</c> instead.</para>
        /// </summary>
        public int TotalCount
        {
            get { return base.Values.Sum(list => list.Count); }
        }

        /// <summary>
        /// Counts the number of values associated with the specified <paramref name="key"/> in this dictionary.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The number of values associated with the specified <paramref name="key"/>.</returns>
        public int Count(TKey key)
        {
            if (base.TryGetValue(key, out LinkedList<TValue> list)) return list.Count;
            else return 0;
        }

        /// <summary>
        /// Adds a value associated with the specified <paramref name="key"/> to this dictionary.
        /// </summary>
        /// <param name="key">The key of the value to add.</param>
        /// <param name="value">The value to add.</param>
        public void Add(TKey key, TValue value)
        {
            LinkedList<TValue> list;
            if (!base.TryGetValue(key, out list))
            {
                list = new LinkedList<TValue>();
                base.Add(key, list);
            }

            list.AddLast(value);
        }

        /// <summary>
        /// Adds a value associated with the specified <paramref name="key"/> to this dictionary.
        /// </summary>
        /// <param name="key">The key of the value to add.</param>
        /// <param name="value">The value to add.</param>
        /// <param name="node">Returns a <see cref="LinkedListNode&lt;TValue;&gt;"/> object that contains the added value.</param>
        public void Add(TKey key, TValue value, out LinkedListNode<TValue> node)
        {
            LinkedList<TValue> list;
            if (!base.TryGetValue(key, out list))
            {
                list = new LinkedList<TValue>();
                base.Add(key, list);
            }

            list.AddLast(value);
            node = list.Last;
        }

        /// <summary>
        /// Adds a value associated with the specified <paramref name="key"/> to this dictionary in a sorted manner. 
        /// If this method has been used to ensure all elements associated with the same key are arranged in a sorted manner, 
        /// the other method <see cref="Add"/> should not be called, or the sort could be disrupted.
        /// </summary>
        /// <param name="key">The key of the value to add.</param>
        /// <param name="value">The value to add.</param>
        /// <param name="descending"><c>true</c> if the elements associated with the same key should be arrange in descending order; <c>false</c> if ascending order applies.</param>
        public void SortedAdd(TKey key, TValue value, bool descending = false)
        {
            LinkedList<TValue> list;
            if (!base.TryGetValue(key, out list))
            {
                list = new LinkedList<TValue>();
                base.Add(key, list);
            }

            list.SortedAdd(value, descending);
        }

        /// <summary>
        /// Adds a value associated with the specified <paramref name="key"/> to this dictionary in a sorted manner. 
        /// If this method has been used to ensure all elements associated with the same key are arranged in a sorted manner, 
        /// the other method <see cref="Add"/> should not be called, or the sort could be disrupted.
        /// </summary>
        /// <param name="key">The key of the value to add.</param>
        /// <param name="value">The value to add.</param>
        /// <param name="descending"><c>true</c> if the elements associated with the same key should be arrange in descending order; <c>false</c> if ascending order applies.</param>
        /// <param name="node">Returns a <see cref="LinkedListNode&lt;TValue;&gt;"/> object that contains the added value.</param>
        public void SortedAdd(TKey key, TValue value, out LinkedListNode<TValue> node, bool descending = false)
        {
            LinkedList<TValue> list;
            if (!base.TryGetValue(key, out list))
            {
                list = new LinkedList<TValue>();
                base.Add(key, list);
            }

            list.SortedAdd(value, descending);
            node = list.Last;
        }

        /// <summary>
        /// Adds a value associated with the specified <paramref name="key"/> to this dictionary in a sorted manner.
        /// If this method has been used to ensure all elements associated with the same key are arranged in a sorted manner,
        /// the other method <see cref="Add"/> should not be called, or the sort could be disrupted.
        /// </summary>
        /// <param name="key">The key of the value to add.</param>
        /// <param name="value">The value to add.</param>
        /// <param name="toComparable">A method converting the value to add to a comparable type.</param>
        /// <param name="descending"><c>true</c> if the elements associated with the same key should be arrange in descending order; <c>false</c> if ascending order applies.</param>
        public void SortedAdd(TKey key, TValue value, Func<TValue, IComparable> toComparable, bool descending = false)
        {
            LinkedList<TValue> list;
            if (!base.TryGetValue(key, out list))
            {
                list = new LinkedList<TValue>();
                base.Add(key, list);
            }
            list.SortedAdd(value, toComparable, descending);
        }

        /// <summary>
        /// Adds values associated with the specified <paramref name="key"/> to this dictionary.
        /// </summary>
        /// <param name="key">The key of the values to add.</param>
        /// <param name="values">The list of the values to add.</param>
        public void Add(TKey key, IList<TValue> values)
        {
            LinkedList<TValue> list;
            if (!base.TryGetValue(key, out list))
            {
                list = new LinkedList<TValue>(values);
                base.Add(key, list);
            }
            else list.AddLast(values);
        }

        /// <summary>
        /// Gets the values associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the values to get.</param>
        /// <returns>The values associated with the specified key it the key is found; otherwise, <c>null</c>.</returns>
        public new TValue[] this[TKey key]
        {
            get
            {
                LinkedList<TValue> list;
                base.TryGetValue(key, out list);
                if (list != null && list.Count > 0)
                    return list.ToArray();
                else return null;
            }
        }

        public TValue[][] ValuesToArrays()
        {
            var count = Values.Count;
            var output = new TValue[count][];

            int i = 0;
            foreach (var list in Values)
            {
                output[i] = list.ToArray();
                ++i;
            }
            return output;
        }

        #region For IMDcitionary<TKey,TValue> interface

        void IDictionary<TKey, IEnumerable<TValue>>.Add(TKey key, IEnumerable<TValue> value)
        {
            if (ContainsKey(key)) throw new ArgumentException();
            base.Add(key, value.ToLinkedList());
        }

        ICollection<TKey> IDictionary<TKey, IEnumerable<TValue>>.Keys
        {
            get { return base.Keys; }
        }

        bool IDictionary<TKey, IEnumerable<TValue>>.Remove(TKey key)
        {
            return base.Remove(key);
        }

        bool IDictionary<TKey, IEnumerable<TValue>>.TryGetValue(TKey key, out IEnumerable<TValue> value)
        {
            LinkedList<TValue> list;
            if (TryGetValue(key, out list))
            {
                value = list;
                return true;
            }
            else
            {
                value = null;
                return false;
            }
        }

        ICollection<IEnumerable<TValue>> IDictionary<TKey, IEnumerable<TValue>>.Values
        {
            get { return base.Values.ToArray(); }
        }

        IEnumerable<TValue> IDictionary<TKey, IEnumerable<TValue>>.this[TKey key]
        {
            get
            {
                return base[key];
            }
            set
            {
                base[key] = value.ToLinkedList();
            }
        }

        void ICollection<KeyValuePair<TKey, IEnumerable<TValue>>>.Add(KeyValuePair<TKey, IEnumerable<TValue>> item)
        {
            if (ContainsKey(item.Key)) throw new ArgumentException();
            base.Add(item.Key, item.Value.ToLinkedList());
        }

        bool ICollection<KeyValuePair<TKey, IEnumerable<TValue>>>.Contains(KeyValuePair<TKey, IEnumerable<TValue>> item)
        {
            LinkedList<TValue> list;
            return TryGetValue(item.Key, out list) && item.Value == list;
        }

        void ICollection<KeyValuePair<TKey, IEnumerable<TValue>>>.CopyTo(KeyValuePair<TKey, IEnumerable<TValue>>[] array, int arrayIndex)
        {
            var e = base.GetEnumerator();
            var arrLen = array.Length;
            while (arrayIndex < arrLen && e.MoveNext())
            {
                var curr = e.Current;
                array[arrayIndex] = new KeyValuePair<TKey, IEnumerable<TValue>>(curr.Key, curr.Value);
                ++arrayIndex;
            }
        }

        int ICollection<KeyValuePair<TKey, IEnumerable<TValue>>>.Count
        {
            get { return base.Count; }
        }

        bool ICollection<KeyValuePair<TKey, IEnumerable<TValue>>>.IsReadOnly
        {
            get { return false; }
        }

        bool ICollection<KeyValuePair<TKey, IEnumerable<TValue>>>.Remove(KeyValuePair<TKey, IEnumerable<TValue>> item)
        {
            LinkedList<TValue> list;
            if (TryGetValue(item.Key, out list))
            {
                if (item.Value == list)
                    return base.Remove(item.Key);

            }
            return false;
        }

        IEnumerator<KeyValuePair<TKey, IEnumerable<TValue>>> IEnumerable<KeyValuePair<TKey, IEnumerable<TValue>>>.GetEnumerator()
        {
            var e = base.GetEnumerator();
            while (e.MoveNext())
            {
                var curr = e.Current;
                yield return new KeyValuePair<TKey, IEnumerable<TValue>>(curr.Key, curr.Value);
            }
        }
        #endregion
    }
}
