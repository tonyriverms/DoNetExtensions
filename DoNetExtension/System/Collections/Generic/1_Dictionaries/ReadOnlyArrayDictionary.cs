using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoNetExtension.System.Collections.Generic;

namespace System.Collections.Generic
{
    /// <summary>
    /// Implements <see cref="IDictionary{TKey, TValue}"/>, <see cref="IReadOnlyDictionary{TKey, TValue}"/> and <see cref="IList{TValue}"/> using a <typeparamref name="TKey"/> array and a <typeparamref name="TValue"/> array. 
    /// </summary>
    /// <typeparam name="TKey">The type of keys in this dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in this dictionary.</typeparam>
    public class ReadOnlyArrayDictionary<TKey, TValue> : IDictionary<TKey, TValue>, IReadOnlyDictionary<TKey, TValue>, IList<TValue>
    {
        TKey[] _keys;
        TValue[] _values;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlyArrayDictionary{TKey, TValue}"/> class using a <typeparamref name="TKey"/> array and a <typeparamref name="TValue"/> array.
        /// </summary>
        /// <param name="keys">An <typeparamref name="TKey"/> array whose element at an index <c>i</c> is the key associated with the <c>i</c>th element in <paramref name="values"/>.</param>
        /// <param name="values">The <typeparamref name="TValue"/> array whose element at an index <c>i</c> is using the <c>i</c>th element in <paramref name="values"/> as the key.</param>
        public ReadOnlyArrayDictionary(TKey[] keys, TValue[] values)
        {
            _keys = keys;
            _values = values;
        }

        /// <summary>
        /// Gets the index of specific key.
        /// </summary>
        /// <param name="key">The key to locate in this <see cref="ReadOnlyArrayDictionary{TKey, TValue}"/>.</param>
        /// <returns>The index of the specific key if the key exists in this <see cref="ReadOnlyArrayDictionary{TKey, TValue}"/>; otherwise -1.</returns>
        public int IndexOf(TKey key)
        {
            for (int i = 0, j = _keys.Length; i < j; ++i)
            {
                if (_keys[i].Equals(key))
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Determines whether this <see cref="ReadOnlyArrayDictionary{TKey, TValue}"/> contains a specific key.
        /// </summary>
        /// <param name="key">The key to locate in this <see cref="ReadOnlyArrayDictionary{TKey, TValue}"/>.</param>
        /// <returns><c>true</c> if this <see cref="ReadOnlyArrayDictionary{TKey, TValue}"/> contains a value with the specified key; otherwise, <c>false</c>.</returns>
        public bool ContainsKey(TKey key)
        {
            return ((IDictionary<TKey, TValue>)this).ContainsKey(key);
        }

        /// <summary>
        /// Gets a collection containing the keys in this <see cref="ReadOnlyArrayDictionary{TKey, TValue}"/>.
        /// </summary>
        public IEnumerable<TKey> Keys
        {
            get
            {
                return ((IDictionary<TKey, TValue>)this).Keys;
            }
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="value">When this method returns, contains the value associated with the specified key, if the key is found; otherwise, the default value for the type of the value parameter. This parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if this <see cref="ReadOnlyArrayDictionary{TKey, TValue}"/> contains a value with the specified key; otherwise, <c>false</c>.</returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            return ((IDictionary<TKey, TValue>)this).TryGetValue(key, out value);
        }

        /// <summary>
        /// Gets a collection containing the values in this <see cref="ReadOnlyArrayDictionary{TKey, TValue}"/>.
        /// </summary>
        public IEnumerable<TValue> Values
        {
            get { return ((IDictionary<TKey, TValue>)this).Values; }
        }

        /// <summary>
        /// Gets the value associated with the specified index.
        /// </summary>
        /// <param name="key">The key of the value to get or set.</param>
        /// <returns>The value associated with the specified key. If the specified key is not found, a get operation throws a <see cref="KeyNotFoundException"/>, and a set operation creates a new value with the specified key.</returns>
        public TValue this[TKey key]
        {
            get { return ((IDictionary<TKey, TValue>)this)[key]; }
        }

        /// <summary>
        /// Gets the number of key/value pairs contained in this <see cref="ReadOnlyArrayDictionary{TKey, TValue}"/>.
        /// </summary>
        public int Count
        {
            get { return ((IDictionary<TKey, TValue>)this).Count; }
        }

        #region Hidden Interface Members

        void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
        {
            throw new NotSupportedException(GenericResources.ERR_ReadOnlyArrayDictionary_ReadOnly);
        }

        bool IDictionary<TKey, TValue>.ContainsKey(TKey key)
        {
            return IndexOf(key) != -1;
        }

        ICollection<TKey> IDictionary<TKey, TValue>.Keys
        {
            get { return _keys.AsReadOnly(); }
        }

        bool IDictionary<TKey, TValue>.Remove(TKey key)
        {
            throw new NotSupportedException(GenericResources.ERR_ReadOnlyArrayDictionary_ReadOnly);
        }

        bool IDictionary<TKey, TValue>.TryGetValue(TKey key, out TValue value)
        {
            var i = IndexOf(key);
            if (i == -1)
            {
                value = default(TValue);
                return false;
            }
            else
            {
                value = _values[i];
                return true;
            }
        }

        ICollection<TValue> IDictionary<TKey, TValue>.Values
        {
            get { return Array.AsReadOnly(_values); }
        }

        TValue IDictionary<TKey, TValue>.this[TKey key]
        {
            get
            {
                var i = _keys.IndexOf(key);
                if (i == -1) throw new KeyNotFoundException(GenericResources.ERR_Common_KeyNotFound.Scan(key));
                return _values[i];
            }
            set
            {
                throw new NotSupportedException(GenericResources.ERR_ReadOnlyArrayDictionary_ReadOnly);
            }
        }

        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotSupportedException(GenericResources.ERR_ReadOnlyArrayDictionary_ReadOnly);
        }

        void ICollection<KeyValuePair<TKey, TValue>>.Clear()
        {
            throw new NotSupportedException(GenericResources.ERR_ReadOnlyArrayDictionary_ReadOnly);
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
        {
            TValue value;
            if (((IDictionary<TKey, TValue>)this).TryGetValue(item.Key, out value))
                return value.Equals(item.Value);
            return false;
        }

        void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            for (int i = 0, j = arrayIndex, len = _keys.Length; i < len; ++i, ++j)
                array[j] = new KeyValuePair<TKey, TValue>(_keys[i], _values[i]);
        }

        int ICollection<KeyValuePair<TKey, TValue>>.Count
        {
            get { return _keys.Length; }
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly
        {
            get { return true; }
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotSupportedException(GenericResources.ERR_ReadOnlyArrayDictionary_ReadOnly);
        }

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            for (int i = 0, j = _keys.Length; i < j; ++i)
                yield return new KeyValuePair<TKey, TValue>(_keys[i], _values[i]);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0, j = _keys.Length; i < j; ++i)
                yield return new KeyValuePair<TKey, TValue>(_keys[i], _values[i]);
        }

        void IList<TValue>.Insert(int index, TValue item)
        {
            throw new NotSupportedException(GenericResources.ERR_ReadOnlyArrayDictionary_ReadOnly);
        }

        void IList<TValue>.RemoveAt(int index)
        {
            throw new NotSupportedException(GenericResources.ERR_ReadOnlyArrayDictionary_ReadOnly);
        }

        TValue IList<TValue>.this[int index]
        {
            get
            {
                ExceptionHelper.ArgumentRangeRequired("index", index, 0, true, _keys.Length, false);
                return _values[index];
            }
            set
            {
                throw new NotSupportedException(GenericResources.ERR_ReadOnlyArrayDictionary_ReadOnly);
            }
        }

        void ICollection<TValue>.Add(TValue item)
        {
            throw new NotSupportedException(GenericResources.ERR_ReadOnlyArrayDictionary_ReadOnly);
        }

        void ICollection<TValue>.Clear()
        {
            throw new NotSupportedException(GenericResources.ERR_ReadOnlyArrayDictionary_ReadOnly);
        }

        bool ICollection<TValue>.Contains(TValue item)
        {
            return _values.IndexOf(item) != -1;
        }

        void ICollection<TValue>.CopyTo(TValue[] array, int arrayIndex)
        {
            _values.CopyTo(array, arrayIndex);
        }

        int ICollection<TValue>.Count
        {
            get { return _values.Length; }
        }

        bool ICollection<TValue>.IsReadOnly
        {
            get { return true; }
        }

        int IList<TValue>.IndexOf(TValue item)
        {
            return _values.IndexOf(item);
        }

        bool ICollection<TValue>.Remove(TValue item)
        {
            throw new NotSupportedException(GenericResources.ERR_ReadOnlyArrayDictionary_ReadOnly);
        }

        IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
        {
            return ((IDictionary<TKey, TValue>)this).Values.GetEnumerator();
        }

        #endregion
    }
}
