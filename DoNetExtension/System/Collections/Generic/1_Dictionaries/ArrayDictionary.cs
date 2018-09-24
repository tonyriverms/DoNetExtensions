using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DoNetExtension.System.Collections.Generic;

namespace System.Collections.Generic
{

    /// <summary>
    /// Implements <see cref="IDictionary{TKey, TValue}" /> and <see cref="IList{TValue}" /> using a <typeparamref name="TKey" /> array and a <typeparamref name="TValue" /> array. Recommended for collections that contain 10 items or less.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in this dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in this dictionary.</typeparam>
    /// <remarks>The capacity of an <see cref="ArrayDictionary{TKey, TValue}" /> must be specified when it is initialized. After the initialization, the capacity cannot be changed. Another implementation similar to <see cref="ArrayDictionary{TKey, TValue}" /> but with growing capacity is <see cref="ListDictionary{Key, TValue}" />, which implements <see cref="IDictionary{TKey, TValue}" /> and <see cref="IList{TValue}" /> using a linked list.</remarks>
    public class ArrayDictionary<TKey, TValue> : IDictionary<TKey, TValue>, IList<TValue>
    {
        TKey[] _keys;
        TValue[] _values;
        int _endPos;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArrayDictionary{TKey, TValue}"/> class with capacity 10.
        /// </summary>
        public ArrayDictionary() : this(10) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArrayDictionary{TKey, TValue}"/> class with a specified capacity.
        /// </summary>
        /// <param name="capacity">The capacity of the <see cref="ArrayDictionary{TKey, TValue}"/>.</param>
        public ArrayDictionary(int capacity)
        {
            _keys = new TKey[capacity];
            _values = new TValue[capacity];
        }

        /// <summary>
        /// Gets a number indicating the capacity of this <see cref="ArrayDictionary{TKey, TValue}"/>.
        /// </summary>
        public int Capacity { get { return _keys.Length; } }

        /// <summary>
        /// Adds a value associated with the specified key into this <see cref="ArrayDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <param name="key">The key associated with the value to add.</param>
        /// <param name="value">The value to add.</param>
        public void Add(TKey key, TValue value)
        {
            if (_endPos == Capacity)
                throw new InvalidOperationException(
                    string.Format(GenericResources.ERR_ArrayDictionary_ExceedsCapacity, Capacity));

            if (ContainsKey(key))
                throw new ArgumentException(
                    string.Format(GenericResources.ERR_Common_KeyConflict, key), "key");

            _keys[_endPos] = key;
            _values[_endPos] = value;
            ++_endPos;
        }

        /// <summary>
        /// Determines whether this <see cref="ArrayDictionary{TKey, TValue}"/> contains a specific key.
        /// </summary>
        /// <param name="key">The key to locate in this <see cref="ArrayDictionary{TKey, TValue}"/>.</param>
        /// <returns><c>true</c> if this <see cref="ArrayDictionary{TKey, TValue}"/> contains a value with the specified key; otherwise, <c>false</c>.</returns>
        public bool ContainsKey(TKey key)
        {
            return (IndexOf(key) != -1);
        }

        /// <summary>
        /// Gets a collection containing the keys in this <see cref="ArrayDictionary{TKey, TValue}"/>.
        /// </summary>
        public ICollection<TKey> Keys
        {
            get
            {
                if (_endPos == 0) return null;
                return _keys.SubArray(0, _endPos);
            }
        }

        /// <summary>
        /// Gets the index of specific key.
        /// </summary>
        /// <param name="key">The key to locate in this <see cref="ArrayDictionary{TKey, TValue}"/>.</param>
        /// <returns>The index of the specific key if the key exists in this <see cref="ArrayDictionary{TKey, TValue}"/>; otherwise -1.</returns>
        public int IndexOf(TKey key)
        {
            for (int i = 0; i < _endPos; ++i)
            {
                if (_keys[i].Equals(key))
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Removes the value with the specified key from this <see cref="ArrayDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <param name="key">The key of the value to remove.</param>
        /// <returns><c>true</c> if the specific value is successfully found and removed; otherwise, <c>false</c>. This method returns false if the specified key is not found.</returns>
        public bool Remove(TKey key)
        {
            for (int i = 0; i < _endPos; ++i)
            {
                if (_keys[i].Equals(key))
                {
                    _keys.InternalShiftRemove(i, _endPos);
                    _values.InternalShiftRemove(i, _endPos);
                    --_endPos;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="value">When this method returns, contains the value associated with the specified key, if the key is found; 
        /// otherwise, the default value for the type of the value parameter. This parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if this <see cref="ArrayDictionary{TKey, TValue}"/> contains a value with the specified key; otherwise, <c>false</c>.</returns>
        public bool TryGetValue(TKey key, out TValue value)
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

        /// <summary>
        /// Gets a collection containing the values in this <see cref="ArrayDictionary{TKey, TValue}"/>.
        /// </summary>
        public ICollection<TValue> Values
        {
            get
            {
                if (_endPos == 0) return null;
                return _values.SubArray(0, _endPos);
            }
        }

        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the value to get or set.</param>
        /// <returns>The value associated with the specified key. If the specified key is not found, a get operation throws a <see cref="KeyNotFoundException"/>, and a set operation creates a new value with the specified key.</returns>
        public TValue this[TKey key]
        {
            get
            {
                var i = _keys.IndexOf(key);
                if (i == -1) throw new KeyNotFoundException(GenericResources.ERR_Common_KeyNotFound.Scan(key));
                return _values[i];
            }
            set
            {
                var i = _keys.IndexOf(key);
                if (i == -1) throw new KeyNotFoundException(GenericResources.ERR_Common_KeyNotFound.Scan(key));
                _values[i] = value;
            }
        }

        /// <summary>
        /// Adds a key/value pair to this <see cref="ArrayDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <param name="pair">The key/value pair.</param>
        public void Add(KeyValuePair<TKey, TValue> pair)
        {
            Add(pair.Key, pair.Value);
        }

        /// <summary>
        /// Removes all keys and values from this <see cref="ArrayDictionary{TKey, TValue}"/>.
        /// </summary>
        public void Clear()
        {
            _endPos = 0;
        }

        /// <summary>
        /// Copies all key/value pairs of this Array Dictionary to an array, starting at a particular array index. 
        /// </summary>
        /// <param name="array">The one-dimensional array that is the destination of the key/value pairs copied from this <see cref="ArrayDictionary{TKey, TValue}"/>.</param>
        /// <param name="arrayIndex">The zero-based index in the array at which copying begins.</param>
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (_endPos == 0) return;
            for (int i = 0, j = arrayIndex; i < _endPos; ++i, ++j)
                array[j] = new KeyValuePair<TKey, TValue>(_keys[i], _values[i]);
        }

        /// <summary>
        /// Gets the number of key/value pairs contained in this <see cref="ArrayDictionary{TKey, TValue}"/>.
        /// </summary>
        public int Count
        {
            get { return _endPos; }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection. NOTE that the returned enumerator is not resettable.
        /// </summary>
        /// <returns>A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.</returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return (IEnumerator<KeyValuePair<TKey, TValue>>)((IEnumerable)this).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < _endPos; ++i)
                yield return new KeyValuePair<TKey, TValue>(_keys[i], _values[i]);
        }

        /// <summary>
        /// Gets the index of the first occurrence of a specific value.
        /// </summary>
        /// <param name="value">The value to locate in this dictionary.</param>
        /// <returns>The index of the specific value if it is found in this dictionary, otherwise -1.</returns>
        public int IndexOf(TValue value)
        {
            for (int i = 0; i < _endPos; ++i)
            {
                if (_values[i].Equals(value))
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Inserts a value with default key into this <see cref="ArrayDictionary{TKey, TValue}"/> at the specified index.
        /// <para>This method is for implementation of IList{T} interface and may be useless.</para>
        /// </summary>
        /// <param name="index">The zero-based index at which the value should be inserted.</param>
        /// <param name="value">The value to insert.</param>
        public void Insert(int index, TValue value)
        {
            //MARK: possible performance improvement
            ExceptionHelper.ArgumentRangeRequired("index", index, 0, true, _endPos, false);
            _keys.InternalShiftInsert(default(TKey), index, _endPos);
            _values.InternalShiftInsert(value, index, _endPos);
        }

        /// <summary>
        /// Removes the key and value at the specified index of this <see cref="ArrayDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <param name="index">The zero-based index of the value to remove.</param>
        public void RemoveAt(int index)
        {
            ExceptionHelper.ArgumentRangeRequired("index", index, 0, true, _endPos, false);
            _keys.InternalShiftRemove(index, _endPos);
            _values.InternalShiftRemove(index, _endPos);
            --_endPos;
        }

        /// <summary>
        /// Gets or sets the value at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the value to get or set.</param>
        /// <returns>The value at the specified index.</returns>
        public TValue this[int index]
        {
            get
            {
                ExceptionHelper.ArgumentRangeRequired("index", index, 0, true, _endPos, false);
                return _values[index];
            }
            set
            {
                ExceptionHelper.ArgumentRangeRequired("index", index, 0, true, _endPos, false);
                _values[index] = value;
            }
        }

        /// <summary>
        /// Adds a value with default key into this <see cref="ArrayDictionary{TKey, TValue}"/>.
        /// <para>This method is for implementation of IList{T} interface and may be useless.</para>
        /// </summary>
        /// <param name="value">The value to add.</param>
        public void Add(TValue value)
        {
            Add(default(TKey), value);
        }

        /// <summary>
        /// Determines whether a value is in this <see cref="ArrayDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <param name="value">The value to locate in this <see cref="ArrayDictionary{TKey, TValue}"/>.</param>
        /// <returns><c>true</c> if the value is found in this <see cref="ArrayDictionary{TKey, TValue}"/>; otherwise, <c>false</c>.</returns>
        public bool Contains(TValue value)
        {
            var idx = _values.IndexOf(value);
            return idx != -1 && idx < _endPos;
        }

        /// <summary>
        /// Copies all values to a compatible one-dimensional array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional array that is the destination of the values copied from Array Disctionary.</param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(TValue[] array, int arrayIndex)
        {
            _values.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes the first occurrence of a specific value from this <see cref="ArrayDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <param name="value">The object to remove from this <see cref="ArrayDictionary{TKey, TValue}"/>.</param>
        /// <returns><c>true</c> if the specific value is successfully removed; otherwise, <c>false</c>.</returns>
        public bool Remove(TValue value)
        {
            var idx = _values.IndexOf(value);
            if (idx == -1 || idx >= _endPos) return false;
            else
            {
                RemoveAt(idx);
                return true;
            }
        }


        /// <summary>
        /// Determines whether this <see cref="ArrayDictionary{TKey, TValue}"/> contains a specific key/value pair
        /// </summary>
        /// <param name="pair">The key/value pair to locate in this <see cref="ArrayDictionary{TKey, TValue}"/>.</param>
        /// <returns><c>true</c> if the key/value pair is found in this <see cref="ArrayDictionary{TKey, TValue}"/>; otherwise, <c>false</c>.</returns>
        public bool Contains(KeyValuePair<TKey, TValue> pair)
        {
            TValue value;
            if (TryGetValue(pair.Key, out value))
                return value.Equals(pair.Value);
            return false;
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> pair)
        {
            for (int i = 0; i < _endPos; ++i)
            {
                if (_keys[i].Equals(pair.Key) && _values[i].Equals(pair.Value))
                {
                    _keys.InternalShiftRemove(i, _endPos);
                    _values.ShiftRemove(i);
                    --_endPos;
                    return true;
                }
            }
            return false;
        }

        IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
        {
            return Values.GetEnumerator();
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly
        {
            get { return false; }
        }

        bool ICollection<TValue>.IsReadOnly
        {
            get { return false; }
        }
    }
}
