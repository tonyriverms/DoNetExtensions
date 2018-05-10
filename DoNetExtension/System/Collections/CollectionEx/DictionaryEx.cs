using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections
{
    public static partial class CollectionEx
    {
        public static void Add<TKey, TValue>(this IDictionary<TKey, TValue> dict, IEnumerable<TValue> valueCollection, Func<TValue, TKey> keyGenerator)
        {
            if (keyGenerator == null) throw new ArgumentNullException("keyGenerator");

            if (valueCollection != null)
            {
                foreach (TValue value in valueCollection)
                    dict.Add(keyGenerator(value), value);
            }
        }

        public static bool TryGetValue<TKey, TValue>(this IDictionary<TKey, object> dict, TKey key, out TValue value)
        {
            object tmp;
            if (dict.TryGetValue(key, out tmp))
            {
                value = (TValue)tmp;
                return true;
            }
            else
            {
                value = default(TValue);
                return false;
            }
        }

        public static void Add<TKey, TValue>(this IDictionary<TKey, TValue> dict, IEnumerable<Pair<TKey, TValue>> pairCollection)
        {
            if (pairCollection != null)
            {
                foreach (var pair in pairCollection)
                {
                    var key = pair.First;
                    var value = pair.Second;
                    if (!dict.ContainsKey(key))
                        dict.Add(key, value);
                }
            }
        }

        public static void Add<TKey, TValue>(this IDictionary<TKey, TValue> dict, IEnumerable<KeyValuePair<TKey, TValue>> pairCollection)
        {
            if (pairCollection != null)
            {
                foreach (var pair in pairCollection)
                {
                    var key = pair.Key;
                    var value = pair.Value;
                    if (!dict.ContainsKey(key))
                        dict.Add(key, value);
                }
            }
        }
    }
}
