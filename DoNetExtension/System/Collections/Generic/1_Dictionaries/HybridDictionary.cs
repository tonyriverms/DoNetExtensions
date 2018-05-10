using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Collections.Generic
{
    /// <summary>
    /// Implements <see cref="IDictionary{TKey,TValue}"/> using a <see cref="ListDictionary{TKey,TValue}"/> when the size of the collection is no more than 10,
    /// and then switching to the <see cref="Dictionary{TKey,TValue}"/> when the collection gets larger.</summary>
    /// <typeparam name="TKey">The type of keys in this dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in this dictionary.</typeparam>
    public class HybridDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        /// <summary>
        /// Gets a value indicating the maximum size of when a <see cref="HybridDictionary{TKey,TValue}"/> uses a <see cref="ListDictionary{TKey,TValue}"/> implementation.
        /// </summary>
        public const int TransformThreshold = 10;

        ListDictionary<TKey, TValue> _listDict;
        Dictionary<TKey, TValue> _dict;
        IDictionary<TKey, TValue> _curr;

        /// <summary>
        /// Initializes a new instance of the <see cref="HybridDictionary{TKey, TValue}"/> class.
        /// </summary>
        public HybridDictionary()
        {
            _listDict = new ListDictionary<TKey, TValue>();
            _curr = _listDict;
        }

        /// <summary>
        /// Adds a value associated with the specified key into this dictionary.
        /// </summary>
        /// <param name="key">The key associated with the <paramref name="value"/> to add.</param>
        /// <param name="value">The value to add.</param>
        public void Add(TKey key, TValue value)
        {
            if (Count == TransformThreshold)
            {
                _dict = new Dictionary<TKey, TValue>(_listDict);
                _dict.Add(key, value);
                _listDict = null;
                _curr = _dict;
            }
            else _curr.Add(key, value);
        }

        /// <summary>
        /// Determines whether this dictionary contains a specific key.
        /// </summary>
        /// <param name="key">The key to locate in this dictionary.</param>
        /// <returns><c>true</c> if this dictionary contains a value with the specified key; otherwise, <c>false</c>.</returns>
        public bool ContainsKey(TKey key)
        {
            return _curr.ContainsKey(key);
        }

        /// <summary>
        /// Gets a collection containing the keys in this dictionary.
        /// </summary>
        public ICollection<TKey> Keys
        {
            get { return _curr.Keys; }
        }

        /// <summary>
        /// Removes the value with the specified key from this dictionary.
        /// </summary>
        /// <param name="key">The key of the value to remove.</param>
        /// <returns><c>true</c> if the specific value is successfully found and removed; 
        /// otherwise, <c>false</c>. This method returns false if the specified key is not found.</returns>
        public bool Remove(TKey key)
        {
            var rlt = _curr.Remove(key);
            if (Count == TransformThreshold)
            {
                _listDict = new ListDictionary<TKey, TValue>();
                foreach (var pair in _dict)
                    _listDict.Add(pair);
                _dict = null;
                _curr = _listDict;
            }
            return rlt;
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="value">When this method returns, contains the value associated with the specified key, if the key is found; 
        /// otherwise, the default value for the type of the value parameter. This parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if this dictionary contains a value with the specified key; otherwise, <c>false</c>.</returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            return _curr.TryGetValue(key, out value);
        }

        /// <summary>
        /// Associates the specified <paramref name="key"/> with the specified <paramref name="value"/> if the key already exists in this dictionary; or adds a new key/value pair into this dictionary if the key is not found.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if the specified key already exists in this dictionary; otherwise, <c>false</c>.</returns>
        public bool TrySetOrAddValue(TKey key, TValue value)
        {
            if (_curr == _listDict)
                return _listDict.TrySetOrAddValue(key, value);
            else
            {
                if (_dict.ContainsKey(key))
                {
                    _dict[key] = value;
                    return true;
                }
                else
                {
                    _dict.Add(key, value);
                    return false;
                }
            }
        }

        /// <summary>
        /// Gets a collection containing the values in this dictionary.
        /// </summary>
        public ICollection<TValue> Values
        {
            get { return _curr.Values; }
        }

        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the value to get or set.</param>
        /// <returns>The value associated with the specified key. If the specified key is not found, a get operation throws a KeyNotFoundException, 
        /// and a set operation creates a new value with the specified key.</returns>
        public TValue this[TKey key]
        {
            get
            {
                return _curr[key];
            }
            set
            {
                _curr[key] = value;
            }
        }

        /// <summary>
        /// Adds a key/value pair to this dictionary.
        /// </summary>
        /// <param name="pair">The key/value pair.</param>
        public void Add(KeyValuePair<TKey, TValue> pair)
        {
            Add(pair.Key, pair.Value);
        }

        /// <summary>
        /// Removes all keys and values from this dictionary.
        /// </summary>
        public void Clear()
        {
            if (_dict == null)
                _listDict.Clear();
            else
            {
                _listDict = new ListDictionary<TKey, TValue>();
                _dict = null;
                _curr = _listDict;
            }
        }

        /// <summary>
        /// Determines whether this dictionary contains a specific key/value pair
        /// </summary>
        /// <param name="pair">The key/value pair to locate in this dictionary.</param>
        /// <returns><c>true</c> if the key/value pair is found in this dictionary; otherwise, <c>false</c>.</returns>
        public bool Contains(KeyValuePair<TKey, TValue> pair)
        {
            return ContainsKey(pair.Key);
        }

        /// <summary>
        /// Copies all key/value pairs of this dictionary to a one-dimensional array at the specified index. 
        /// </summary>
        /// <param name="array">The one-dimensional array that is the destination of the key/value pairs copied from this dictionary.</param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            _curr.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Gets the number of key/value pairs contained in this dictionary.
        /// </summary>
        public int Count
        {
            get { return _curr.Count; }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="HybridDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <returns>An enumerator that iterates through the key/value pairs in this <see cref="HybridDictionary{TKey, TValue}"/>.</returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _curr.GetEnumerator();
        }

        #region Hidden Interface Members

        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly
        {
            get { return false; }
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> pair)
        {
            return _curr.Remove(pair);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _curr.GetEnumerator();
        }

        #endregion
    }
}
