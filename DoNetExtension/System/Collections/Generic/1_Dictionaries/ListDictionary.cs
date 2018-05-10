using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System_Extension_Library.System.Collections.Generic;

namespace System.Collections.Generic
{
    /// <summary>
    /// Implements <see cref="IDictionary{TKey, TValue}"/> using a linked list. Recommended for collections that typically contain 10 items or less.
    /// </summary>
    /// <remarks>
    /// Another implementation similar to <see cref="ListDictionary{TKey, TValue}"/> but with fixed capacity is <see cref="ArrayDictionary{TKey, TValue}"/>, which implements <see cref="IDictionary{TKey, TValue}"/> and <see cref="IList{TValue}"/> using an array of <see cref="KeyValuePair{TKey, TValue}"/> objects.
    /// </remarks>
    /// <typeparam name="TKey">The type of keys in this dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in this dictionary.</typeparam>
    public class ListDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        SinglyLinkedList<KeyValuePair<TKey, TValue>> _list;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListDictionary{TKey, TValue}"/> class.
        /// </summary>
        public ListDictionary()
        {
            _list = new SinglyLinkedList<KeyValuePair<TKey, TValue>>();
        }

        /// <summary>
        /// Adds a value associated with the specified key into this <see cref="ListDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <param name="key">The key associated with the value to add. The key can be <c>null</c>.</param>
        /// <param name="value">The value to add.</param>
        public void Add(TKey key, TValue value)
        {
            if (ContainsKey(key))
                throw new ArgumentException(string.Format(GenericResources.ERR_Common_KeyConflict, key), "key");
            else
                _list.AddLast(new KeyValuePair<TKey, TValue>(key, value));
        }

        /// <summary>
        /// Determines whether this <see cref="ListDictionary{TKey, TValue}"/> contains a specific key.
        /// </summary>
        /// <param name="key">The key to locate in this <see cref="ListDictionary{TKey, TValue}"/>. The key can be <c>null</c>.</param>
        /// <returns><c>true</c> if this <see cref="ListDictionary{TKey, TValue}"/> contains a value with the specified key; otherwise, <c>false</c>.</returns>
        public bool ContainsKey(TKey key)
        {
            var node = _list.First;
            while (true)
            {
                if (node == null) return false;
                var nodeKey = node.Value.Key;
                if (nodeKey == null)
                {
                    if (key == null) return true;
                    else node = node.Next;
                }
                else if (!nodeKey.Equals(key))
                    node = node.Next;
                else
                    return true;
            }
        }

        /// <summary>
        /// Gets a collection containing the keys in this <see cref="ListDictionary{TKey, TValue}"/>.
        /// </summary>
        public ICollection<TKey> Keys
        {
            get
            {
                return _list.Select(n => n.Key).ToArray();
            }
        }

        /// <summary>
        /// Removes the value associated with a specified key from this <see cref="ListDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <param name="key">The key associated with the value to remove. The key can be <c>null</c>.</param>
        /// <returns><c>true</c> if the specific key is successfully found and both this key and its associated value are removed; otherwise, <c>false</c>.</returns>
        public bool Remove(TKey key)
        {
            var node = _list.First;
            while (true)
            {
                if (node == null) return false;
                if (node.Value.Key == null)
                {
                    if (key == null)
                    {
                        _list.Remove(node);
                        return true;
                    }
                    else node = node.Next;
                }
                else if (!node.Value.Key.Equals(key))
                    node = node.Next;
                else
                {
                    _list.Remove(node);
                    return true;
                }
            }
        }

        /// <summary>
        /// Gets the value by its associated key.
        /// </summary>
        /// <param name="key">The key associated with the value to retrieve. The key can be <c>null</c>.</param>
        /// <param name="value">When this method returns, this argument contains the value associated with the specified key, if the key is found; otherwise, this argument is assigned the default value for the type of the value parameter. This parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if this <see cref="ListDictionary{TKey, TValue}"/> contains a value with the specified key; otherwise, <c>false</c>.</returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            var node = _list.First;

            while (true)
            {
                if (node == null)
                {
                    value = default(TValue);
                    return false;
                }
                else if (node.Value.Key == null)
                {
                    if (key == null)
                    {
                        value = node.Value.Value;
                        return true;
                    }
                    else node = node.Next;
                }
                else if (!node.Value.Key.Equals(key))
                    node = node.Next;
                else
                {
                    value = node.Value.Value;
                    return true;
                }
            }
        }

        /// <summary>
        /// Associates the specified <paramref name="key"/> with the specified <paramref name="value"/> if the key already exists in this dictionary; or adds a new key/value pair into this dictionary if the key is not found.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if the specified key already exists in this dictionary; otherwise, <c>false</c>.</returns>
        public bool TrySetOrAddValue(TKey key, TValue value)
        {
            var node = _list.First;

            while (true)
            {
                if (node == null)
                {
                    _list.AddLast(new KeyValuePair<TKey, TValue>(key, value));
                    return false;
                }
                else if (node.Value.Key == null)
                {
                    if (key == null)
                    {
                        node.Value = new KeyValuePair<TKey,TValue>(key, value);
                        return true;
                    }
                    else node = node.Next;
                }
                else if (!node.Value.Key.Equals(key))
                    node = node.Next;
                else
                {
                    node.Value = new KeyValuePair<TKey, TValue>(key, value);
                    return true;
                }
            }
        }


        /// <summary>
        /// Associates the specified <paramref name="key"/> with the specified <paramref name="value"/> if the key already exists in this dictionary.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if the specified key already exists in this dictionary; otherwise, <c>false</c>.</returns>
        public bool TrySetValue(TKey key, TValue value)
        {
            var node = _list.First;

            while (true)
            {
                if (node == null) return false;
                else if (node.Value.Key == null)
                {
                    if (key == null)
                    {
                        node.Value = new KeyValuePair<TKey, TValue>(key, value);
                        return true;
                    }
                    else node = node.Next;
                }
                else if (!node.Value.Key.Equals(key))
                    node = node.Next;
                else
                {
                    node.Value = new KeyValuePair<TKey, TValue>(key, value);
                    return true;
                }
            }
        }

        /// <summary>
        /// Gets a collection containing the values in this <see cref="ListDictionary{TKey, TValue}"/>.
        /// </summary>
        public ICollection<TValue> Values
        {
            get { return _list.Select(n => n.Value).ToArray(); }
        }

        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The value associated with the specified key.</returns>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">
        /// Occurs when the specified key is not found.
        /// </exception>
        public TValue this[TKey key]
        {
            get
            {
                var node = _list.First;
                while (true)
                {
                    if (node == null) throw new KeyNotFoundException();

                    if (node.Value.Key == null)
                    {
                        if (key == null) return node.Value.Value;
                        else node = node.Next;
                    }
                    else if (!node.Value.Key.Equals(key))
                        node = node.Next;
                    else
                        return node.Value.Value;
                }
            }
            set
            {
                var node = _list.First;
                while (true)
                {
                    if (node == null) throw new KeyNotFoundException();

                    if (node.Value.Key == null)
                    {
                        if (key == null)
                        {
                            node.Value = new KeyValuePair<TKey, TValue>(node.Value.Key, value);
                            break;
                        }
                        else node = node.Next;
                    }
                    else if (!node.Value.Key.Equals(key))
                        node = node.Next;
                    else
                    {
                        node.Value = new KeyValuePair<TKey, TValue>(node.Value.Key, value);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Adds a key/value pair to this <see cref="ListDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <param name="pair">The key/value pair to add.</param>
        public void Add(KeyValuePair<TKey, TValue> pair)
        {
            Add(pair.Key, pair.Value);
        }

        /// <summary>
        /// Removes all keys and values from this <see cref="ListDictionary{TKey, TValue}"/>.
        /// </summary>
        public void Clear()
        {
            _list.Clear();
        }

        /// <summary>
        /// Determines whether this <see cref="ListDictionary{TKey, TValue}"/> contains a specific key/value pair
        /// </summary>
        /// <param name="pair">The key/value pair to locate in this <see cref="ListDictionary{TKey, TValue}"/>.</param>
        /// <returns><c>true</c> if the key/value pair is found in this <see cref="ListDictionary{TKey, TValue}"/>; otherwise, <c>false</c>.</returns>
        public bool Contains(KeyValuePair<TKey, TValue> pair)
        {
            return ContainsKey(pair.Key);
        }

        /// <summary>
        /// Copies all key/value pairs of this <see cref="ListDictionary{TKey, TValue}"/> to an array, starting at a particular array index. 
        /// </summary>
        /// <param name="array">The one-dimensional array that is the destination of the key/value pairs copied from this <see cref="ListDictionary{TKey, TValue}"/>.</param>
        /// <param name="arrayIndex">The zero-based index in the array at which copying begins.</param>
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Gets the number of key/value pairs contained in this <see cref="ListDictionary{TKey, TValue}"/>.
        /// </summary>
        public int Count
        {
            get { return _list.Count; }
        }

        /// <summary>
        /// Gets an enumerator that iterates through this <see cref="ListDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <returns>An enumerator that iterates through the key/value pairs in this <see cref="ListDictionary{TKey, TValue}"/>.</returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _list.GetEnumerator();
        }


        #region Hidden Interface Members

        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly
        {
            get { return false; }
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> pair)
        {
            return Remove(pair.Key);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        #endregion
    }
}
