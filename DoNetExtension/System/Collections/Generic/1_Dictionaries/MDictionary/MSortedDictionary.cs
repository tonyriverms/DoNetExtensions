using System;
using System.Linq;
using System.Text;

namespace System.Collections.Generic
{
    /// <summary>
    /// Represents a collection of key/value pairs that are sorted on the key. Different values can be mapped to the same key. NOTE that the values associated with the same key are not sorted.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in this dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in this dictionary.</typeparam>
    /// <remarks>
    /// <para>This class inherits from the <see cref="SortedDictionary&lt;TKey,LinkedList&lt;TValue&gt;&gt;"/> class and you may directly operate on the underlying linked list. However, NOTE that the <c>this</c> indexer is modified to return a <typeparamref name="TValue"/> array instead of a linked list.</para>
    /// <para>This class also implements the <see cref="IMDictionary&lt;TKey,TValue&gt;"/> interface, but it is highly not recommended to operate on the underlying linked list through this interface.</para>
    /// </remarks>
    public class MSortedDictionary<TKey, TValue> : SortedDictionary<TKey, LinkedList<TValue>>, IMDictionary<TKey, TValue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MSortedDictionary{TKey, TValue}"/> class.
        /// </summary>
        public MSortedDictionary() : base() { }

        /// <summary>
        /// Removes a value associated with the specified key from this dictionary.
        /// </summary>
        /// <param name="key">The key of the value to remove.</param>
        /// <param name="value">The value to remove.
        /// <para>** Multiple values associated with one key are allowed in this dictionary, so this argument is needed to remove the value.</para>
        /// </param>
        public void Remove(TKey key, TValue value)
        {
            var list = base[key];
            list.Remove(value);
            if (list.Count == 0)
                base.Remove(key);
        }

        /// <summary>
        /// Removes values with the specified key from this dictionary.
        /// </summary>
        /// <param name="key">The key of the values to remove.</param>
        /// <param name="values">A list of the values to remove.</param>
        public void Remove(TKey key, IList<TValue> values)
        {
            var list = base[key];
            foreach (var value in values)
                list.Remove(value);

            if (list.Count == 0)
                base.Remove(key);
        }

        /// <summary>
        /// Gets the number of key/value pairs that are actually contained in this dictionary.
        /// <para>!!! Not like System.Collection.Generic&lt;TKey,TValue&gt; class, 
        /// this value may be different from property "Keys.Count" and "Values.Count".</para>
        /// <para>** To get the number of keys, which may be different from this value, use "Keys.Count" property.</para>
        /// </summary>
        public int TotalCount
        {
            get { return base.Values.Sum(n => n.Count); }
        }

        /// <summary>
        /// Adds a value associated with the specified key to this dictionary.
        /// </summary>
        /// <param name="key">The key of the value to add.</param>
        /// <param name="value">The value to add.</param>
        public void Add(TKey key, TValue value)
        {
            LinkedList<TValue> list;
            if (!base.ContainsKey(key))
            {
                list = new LinkedList<TValue>();
                base.Add(key, list);
            }
            else
                list = base[key];

            list.AddLast(value);
        }

        /// <summary>
        /// Adds a value associated with the specified key to this dictionary. 
        /// If this method has been used to ensure all elements associated with the same key are arranged in an ordered fashion, 
        /// the other method <c>Add</c> should not be called, or the sort could be disrupted.
        /// </summary>
        /// <param name="key">The key of the value to add.</param>
        /// <param name="value">The value to add.</param>
        /// <param name="descending"><c>true</c> if the elements associated with the same key should be arrange in descending order; <c>false</c> if ascending order applies.</param>
        /// <remarks>
        /// Note that this method help keep the order of element associated with the same key, not the order of keys.
        /// </remarks>
        public void SortedAdd(TKey key, TValue value, bool descending = false)
        {
            LinkedList<TValue> list;
            if (!base.ContainsKey(key))
            {
                list = new LinkedList<TValue>();
                base.Add(key, list);
            }
            else
                list = base[key];

            list.SortedAdd(value, descending);
        }

        /// <summary>
        /// Adds a value associated with the specified key to this dictionary.
        /// If this method has been used to ensure all elements associated with the same key are arranged in an ordered fashion,
        /// the other method <c>Add</c> should not be called, or the sort could be disrupted.
        /// </summary>
        /// <param name="key">The key of the value to add.</param>
        /// <param name="value">The value to add.</param>
        /// <param name="toComparable">A method converting the value to add to a comparable type.</param>
        /// <param name="descending"><c>true</c> if the elements associated with the same key should be arrange in descending order; <c>false</c> if ascending order applies.</param>
        /// <remarks>
        /// Note that this method help keep the order of element associated with the same key, not the order of keys.
        /// </remarks>
        public void SortedAdd(TKey key, TValue value, Func<TValue, IComparable> toComparable, bool descending = false)
        {
            LinkedList<TValue> list;
            if (!base.ContainsKey(key))
            {
                list = new LinkedList<TValue>();
                base.Add(key, list);
            }
            else
                list = base[key];

            list.SortedAdd(value, toComparable, descending);
        }

        /// <summary>
        /// Adds values associated with the specified key to this dictionary.
        /// </summary>
        /// <param name="key">The key of the values to add.</param>
        /// <param name="values">The list of the values to add.</param>
        public void Add(TKey key, IList<TValue> values)
        {
            LinkedList<TValue> list;
            if (!base.ContainsKey(key))
            {
                list = new LinkedList<TValue>(values);
                base.Add(key, list);
            }
            else
            {
                list = base[key];
                foreach (var value in values)
                    list.AddLast(value);
            }
        }

        /// <summary>
        /// Picks a value associated with the minimum key from this dictionary.
        /// <para>!!! When picked out, this value will be removed from this dictionary.</para>
        /// <para>!!! The returned value is usually the lastest value added to this dictionary.</para>
        /// </summary>
        /// <returns>The value picked out.</returns>
        public TValue PickMinimum()
        {
            var list = base.Values.First();
            var value = list.Last.Value;
            list.RemoveLast();
            if (list.Count == 0)
                base.Remove(base.Keys.First());

            return value;
        }

        /// <summary>
        /// Picks a value associated with the maximum key from this dictionary.
        /// <para>!!! When picked out, this value will be removed from this dictionary.</para>
        /// <para>!!! The returned value is usually the lastest value added to this dictionary.</para>
        /// </summary>
        /// <returns>The value picked out.</returns>
        public TValue PickMaximum()
        {
            var list = base.Values.Last();
            var value = list.Last.Value;
            list.RemoveLast();
            if (list.Count == 0)
                base.Remove(base.Keys.Last());

            return value;
        }

        /// <summary>
        /// Picks a value associated with the minimum key from this dictionary.
        /// <para>!!! When picked out, this value will be removed from this dictionary.</para>
        /// <para>!!! The returned value is usually the lastest value added to this dictionary.</para>
        /// </summary>
        /// <param name="key">Returns the key associated with the value picked out.</param>
        /// <returns>The value picked out.</returns>
        public TValue PickMinimum(out TKey key)
        {
            var list = base.Values.First();
            var value = list.Last.Value;
            key = base.Keys.First();
            list.RemoveLast();
            if (list.Count == 0)
                base.Remove(key);

            return value;
        }

        /// <summary>
        /// Picks a value associated with the maximum key from this dictionary.
        /// <para>!!! When picked out, this value will be removed from this dictionary.</para>
        /// <para>!!! The returned value is usually the lastest value added to this dictionary.</para>
        /// </summary>
        /// <param name="key">Returns the key associated with the value picked out.</param>
        /// <returns>The value picked out.</returns>
        public TValue PickMaximum(out TKey key)
        {
            var list = base.Values.Last();
            var value = list.Last.Value;
            key = base.Keys.Last();
            list.RemoveLast();
            if (list.Count == 0)
                base.Remove(key);

            return value;
        }

        /// <summary>
        /// Returns a value associated with the minimum key from this dictionary.
        /// <para>!!! The returned value is usually the lastest value added to this dictionary.</para>
        /// </summary>
        /// <param name="key">Returns the key associated with the value picked out.</param>
        /// <returns>A value associated with the minimum key.</returns>
        public TValue PeekMinimum(out TKey key)
        {
            key = base.Keys.First();
            return base.Values.First().Last.Value;
        }

        /// <summary>
        /// Returns a value associated with the maximum key from this dictionary.
        /// <para>!!! The returned value is usually the lastest value added to this dictionary.</para>
        /// </summary>
        /// <param name="key">Returns the key associated with the value picked out.</param>
        /// <returns>A value associated with the maximum key.</returns>
        public TValue PeekMaximum(out TKey key)
        {
            key = base.Keys.Last();
            return base.Values.Last().Last.Value; ;
        }

        /// <summary>
        /// Returns a value associated with the minimum key from this dictionary.
        /// <para>!!! The returned value is usually the lastest value added to this dictionary.</para>
        /// </summary>
        /// <returns>A value associated with the minimum key.</returns>
        public TValue PeekMinimum()
        {
            return base.Values.First().Last.Value;
        }

        /// <summary>
        /// Returns a value associated with the maximum key from this dictionary.
        /// <para>!!! The returned value is usually the lastest value added to this dictionary.</para>
        /// </summary>
        /// <returns>A value associated with the maximum key.</returns>
        public TValue PeekMaximum()
        {
            return base.Values.Last().Last.Value; ;
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
