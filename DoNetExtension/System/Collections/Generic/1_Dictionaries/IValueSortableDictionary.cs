using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    public interface IValueSortableDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        IEnumerator<KeyValuePair<TKey, TValue>> GetValueSortedEnumerator(int top, bool desc);
        IEnumerator<TKey> GetValueSortedKeyEnumerator(int top, bool desc);
        IEnumerator<TValue> GetValueSortedValueEnumerator(int top, bool desc);
    }
}
