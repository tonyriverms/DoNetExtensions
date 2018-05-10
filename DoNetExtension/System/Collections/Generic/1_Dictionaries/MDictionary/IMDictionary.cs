using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    /// <summary>
    /// Represents a collection of key/value pairs in which different values can be mapped to the same key.
    /// </summary>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    /// <typeparam name="TValue">The type of the t value.</typeparam>
    public interface IMDictionary<TKey, TValue> : IDictionary<TKey, IEnumerable<TValue>>
    {
        /// <summary>
        /// Adds a value associated with the specified <paramref name="key"/> to this dictionary.
        /// </summary>
        /// <param name="key">The key of the value to add.</param>
        /// <param name="value">The value to add.</param>
        void Add(TKey key, TValue value);

        /// <summary>
        /// Removes a value associated with the specified key from this dictionary.
        /// </summary>
        /// <param name="key">The key of the value to remove.</param>
        /// <param name="value">The value to remove. Multiple values associated with one key are allowed in an <see cref="IMDictionary&lt;TKey,TValue&gt;"/> dictionary, so this argument is needed to remove the value.
        /// </param>
        void Remove(TKey key, TValue value);
    }
}
