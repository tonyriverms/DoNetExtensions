using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    public class TrivialDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        public TrivialDictionary(TKey key, TValue value)
        {
            _key = key;
            _value = value;
        }

        public static TrivialDictionary<TKey, TValue> Create(TKey key, TValue value)
        {
            return new TrivialDictionary<TKey, TValue>(key, value);
        }

        TKey _key;
        TValue _value;

        public bool ContainsKey(TKey key)
        {
            return _key.Equals(key);
        }

        public IEnumerable<TKey> Keys
        {
            get { return _key.Singleton(); }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (_key.Equals(key))
            {
                value = _value;
                return true;
            }
            else
            {
                value = default(TValue);
                return false;
            }
        }

        public IEnumerable<TValue> Values
        {
            get { return _value.Singleton(); }
        }

        public int Count
        {
            get { return 1; }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return (new KeyValuePair<TKey, TValue>(_key, _value).GetTrivialEnumerator(true));
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator(bool resettable)
        {
            return (new KeyValuePair<TKey, TValue>(_key, _value).GetTrivialEnumerator(resettable));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (new KeyValuePair<TKey, TValue>(_key, _value).GetTrivialEnumerator(true));
        }

        public void Add(TKey key, TValue value)
        {
            throw new NotSupportedException();
        }

        ICollection<TKey> IDictionary<TKey, TValue>.Keys
        {
            get { return _key.Singleton(); }
        }

        public bool Remove(TKey key)
        {
            throw new NotSupportedException();
        }

        ICollection<TValue> IDictionary<TKey, TValue>.Values
        {
            get { return _value.Singleton(); }
        }

        public TValue this[TKey key]
        {
            get
            {
                if (_key.Equals(key)) return _value;
                else throw new KeyNotFoundException();
            }
            set
            {
                if (_key.Equals(key)) _value = value;
                else throw new KeyNotFoundException();
            }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotSupportedException();
        }

        public void Clear()
        {
            throw new NotSupportedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return _key.Equals(item.Key) && _value.Equals(item.Value);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            array[arrayIndex] = new KeyValuePair<TKey, TValue>(_key, _value);
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotSupportedException();
        }
    }
}
