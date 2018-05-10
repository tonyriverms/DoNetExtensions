using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_Extension_Library.System.Collections.Generic;

namespace System.Collections.Generic
{
    /// <summary>
    /// Represents a collection of keys and values that are indexed by both keys and values. The two-way indexing is done by synchronizing a key-value dictionary and a value-key dictionary and ensures one-to-one associations between keys and values.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    public class BiDictionary<TKey, TValue> : IBiDictionary<TKey, TValue>
    {
        IDictionary<TKey, TValue> _dict1;
        IDictionary<TValue, TKey> _dict2;
        bool _selfSync;

        /// <summary>
        /// Initializes a new instance of the <see cref="BiDictionary{TKey, TValue}"/> class with a new <see cref="Dictionary{TKey, TValue}" /> as the key-value dictionary, and a new <see cref="Dictionary{TValue, TKey}" /> as the value-key dictionary.
        /// </summary>
        public BiDictionary()
        {
            _dict1 = new Dictionary<TKey, TValue>();
            _dict2 = new Dictionary<TValue, TKey>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BiDictionary{TKey, TValue}"/> class with a new <see cref="Dictionary{TKey, TValue}" /> as the key-value dictionary, and a new <see cref="Dictionary{TValue, TKey}" /> as the value-key dictionary.
        /// </summary>
        /// <param name="capacity">The initial number of elements the key-value dictionary and the value-key dictionary can contain.</param>
        public BiDictionary(int capacity)
        {
            _dict1 = new Dictionary<TKey, TValue>(capacity);
            _dict2 = new Dictionary<TValue, TKey>(capacity);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BiDictionary{TKey, TValue}" /> class.
        /// </summary>
        /// <param name="keyValueDictionary">Provides a key-value dictionary. If this dictionary is non-empty, please make sure it is synchronized with <paramref name="valueKeyDictionary"/>.</param>
        /// <param name="valueKeyDictionary">Provides a value-key dictionary. If this dictionary is non-empty, please make sure it is synchronized with <paramref name="keyValueDictionary"/>.</param>
        /// <param name="selfSynchronization"><c>true</c> if the key-value dictionary and the value-key dictionary are automatically synchronized and the synchronization defined by this class should be ineffective; <c>false</c> if synchronization defined by this class is needed.</param>
        public BiDictionary(IDictionary<TKey, TValue> keyValueDictionary, IDictionary<TValue, TKey> valueKeyDictionary, bool selfSynchronization)
        {
            _dict1 = keyValueDictionary;
            _dict2 = valueKeyDictionary;
            _selfSync = selfSynchronization;
        }

        /// <summary>
        /// Removes the specified <paramref name="value"/> and its associated key from both the key-value dictionary and the value-key dictionary.
        /// </summary>
        /// <param name="value">The value to remove.</param>
        /// <returns><c>true</c> if the value and its associated key are successfully removed, <c>false</c> otherwise.</returns>
        /// <exception cref="System.InvalidOperationException">Occurs when synchronization between the key-value dictionary and the value-key dictionary failed.</exception>
        public bool RemoveByValue(TValue value)
        {
            if (_selfSync) return _dict2.Remove(value);
            else
            {
                TKey key;
                if (TryGetKey(value, out key))
                {
                    if (_dict1.Remove(key))
                    {
                        if (_dict2.Remove(value)) return true;
                        else throw new InvalidOperationException(GenericResources.ERR_BiDictionary_SynchronizationFailed);
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// Removes the specified <paramref name="key"/> with its associated value from both the key-value dictionary and the value-key dictionary.
        /// </summary>
        /// <param name="key">The key to remove.</param>
        /// <returns><c>true</c> if the key and its associated value are successfully removed; otherwise, <c>false</c>.</returns>
        /// <exception cref="System.InvalidOperationException">Occurs when synchronization between the key-value dictionary and the value-key dictionary failed.</exception>
        public bool Remove(TKey key)
        {
            if (_selfSync) return _dict1.Remove(key);
            else
            {
                TValue value;
                if (_dict1.TryGetValue(key, out value))
                {
                    if (_dict1.Remove(key))
                    {
                        if (_dict2.Remove(value))
                            return true;
                        else throw new InvalidOperationException(GenericResources.ERR_BiDictionary_SynchronizationFailed);
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// Gets the key associated with the specified <paramref name="value"/> from the value-key dictionary.
        /// </summary>
        /// <param name="value">The value associated with the key to get.</param>
        /// <param name="key">When this method returns, contains the key associated with the specified value, if the value is found in the value-key dictionary; otherwise, the default value for the type of the key parameter. This parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if the value-key dictionary contains the specified value, <c>false</c> otherwise.</returns>
        public bool TryGetKey(TValue value, out TKey key)
        {
            return _dict2.TryGetValue(value, out key);
        }

        /// <summary>
        /// Associates the value with the specified <paramref name="key"/> in both the key-value dictionary and the value-key dictionary.
        /// </summary>
        /// <param name="value">The value to be associated with the <paramref name="key"/>.</param>
        /// <param name="key">The key to be associated with the <paramref name="value"/>.</param>
        /// <returns><c>true</c> if the association is successful, <c>false</c> otherwise.</returns>
        public bool TrySetKey(TValue value, TKey key)
        {
            if (_selfSync)
            {
                _dict2[value] = key;
                return true;
            }
            else
            {
                if (_dict1.ContainsKey(key) && _dict2.ContainsKey(value))
                {
                    _dict1[key] = value;
                    _dict2[value] = key;
                    return true;
                }
                else return false;
            }
        }

        /// <summary>
        /// Determines whether the value-key dictionary contains the specified <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value to located in the value-key dictionary.</param>
        /// <returns><c>true</c> if the specified value contains value; otherwise, <c>false</c>.</returns>
        public bool ContainsValue(TValue value)
        {
            return _dict2.ContainsKey(value);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the value/key pairs in the value-key dictionary.
        /// </summary>
        /// <returns>A <see cref="System.Collections.Generic.IEnumerator`2" /> that can be used to iterate through value/key pairs in the value-key dictionary.</returns>
        public IEnumerator<KeyValuePair<TValue, TKey>> GetReversedPairEnumerator()
        {
            return _dict2.GetEnumerator();
        }

        /// <summary>
        /// Adds a key and its associated value to both the key-value dictionary and the value-key dictionary.
        /// </summary>
        /// <param name="key">The key associated with the <paramref name="value"/>.</param>
        /// <param name="value">The value associated with the <paramref name="key"/>.</param>
        public void Add(TKey key, TValue value)
        {
            _dict1.Add(key, value);
            if(!_selfSync) _dict2.Add(value, key);
        }

        /// <summary>
        /// Gets or sets the element with the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The value associated with the specified <paramref name="key"/>.</returns>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">Occurs when <paramref name="key"/> is not found in the key-value dictionary.</exception>
        public TValue this[TKey key]
        {
            get
            {
                return _dict1[key];
            }
            set
            {
                if (_selfSync) _dict1[key] = value;
                else
                {
                    TValue previousValue;
                    if (TryGetValue(key, out previousValue))
                    {
                        _dict1[key] = value;
                        _dict2[previousValue] = key;
                    }
                    else throw new KeyNotFoundException();
                }
            }
        }

        /// <summary>
        /// Determines whether the key-value dictionary contains the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to locate in the key-value dictionary.</param>
        /// <returns>true if the key-value dictionary contains the <paramref name="key"/>; otherwise, false.</returns>
        public bool ContainsKey(TKey key)
        {
            return _dict1.ContainsKey(key);
        }

        /// <summary>
        /// Gets the value associated with the specified <paramref name="key"/> from the key-value dictionary.
        /// </summary>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="value">When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the type of the <paramref name="value" /> parameter. This parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if the key-value dictionary contains the specified key; otherwise, <c>false</c>.</returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            return _dict1.TryGetValue(key, out value);
        }

        /// <summary>
        /// Gets an <see cref="T:System.Collections.Generic.ICollection`1" /> containing the keys.
        /// </summary>
        /// <value>The keys.</value>
        public ICollection<TKey> Keys
        {
            get { return _dict1.Keys; }
        }

        /// <summary>
        /// Gets an <see cref="T:System.Collections.Generic.ICollection`1" /> containing the values.
        /// </summary>
        /// <value>The values.</value>
        public ICollection<TValue> Values
        {
            get { return _dict1.Values; }
        }

        /// <summary>
        /// Adds an item to both the key-value dictionary and the value-key dictionary.
        /// </summary>
        /// <param name="item">The object to add to both dictionaries.</param>
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        /// <summary>
        /// Removes all items from both the key-value dictionary and the value-key dictionary.
        /// </summary>
        public void Clear()
        {
            _dict1.Clear();
            if (!_selfSync) _dict2.Clear();
        }

        /// <summary>
        /// Gets the number of elements contained in both dictionaries. In correct synchronization, the number of elements in the key-value dictionary and the value-key dictionary should equal.
        /// </summary>
        /// <value>The number of elements contained in both dictionaries.</value>
        public int Count
        {
            get { return _dict1.Count; }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the key/value pairs in the key-value dictionary.
        /// </summary>
        /// <returns>A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through key/value pairs in the key-value dictionary.</returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _dict1.GetEnumerator();
        }

        #region Hidden Interfaces

        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly
        {
            get { return false; }
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
        {
            if (_selfSync) return _dict1.Remove(item);
            else
            {
                var reversedItem = new KeyValuePair<TValue, TKey>(item.Value, item.Key);
                if (_dict2.Contains(reversedItem) && _dict1.Remove(item))
                {
                    if (_dict2.Remove(reversedItem)) return true;
                    else throw new InvalidOperationException(GenericResources.ERR_BiDictionary_SynchronizationFailed);
                }
                return false;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _dict1.GetEnumerator();
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
        {
            return _dict1.Contains(item);
        }

        void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            _dict1.CopyTo(array, arrayIndex);
        }

        #endregion
    }
}
