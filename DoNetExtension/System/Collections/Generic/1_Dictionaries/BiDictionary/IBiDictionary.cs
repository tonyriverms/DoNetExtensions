using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    /// <summary>
    /// Represents a collection of keys and values that are indexed by both keys and values. The association between keys and values are one-to-one.
    /// </summary>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    /// <typeparam name="TValue">The type of the t value.</typeparam>
    public interface IBiDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        /// <summary>
        /// Removes the specified value and its associated key.
        /// </summary>
        /// <param name="value">The value to remove.</param>
        /// <returns><c>true</c> if the value and its associated key are successfully removed, <c>false</c> otherwise.</returns>
        bool RemoveByValue(TValue value);

        /// <summary>
        /// Gets the key associated with the specified <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value associated with the key to get.</param>
        /// <param name="key">When this method returns, contains the key associated with the specified value, if the value is found; otherwise, the default value for the type of <typeparamref name="TKey"/>. This parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if the value is found and its associated key is assigned to parameter <paramref name="key"/>, <c>false</c> otherwise.</returns>
        bool TryGetKey(TValue value, out TKey key);

        /// <summary>
        /// Associates the value with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="value">The value to be associated with the <paramref name="key"/>.</param>
        /// <param name="key">The key to be associated with the <paramref name="value"/>.</param>
        /// <returns><c>true</c> if the association is successful, <c>false</c> otherwise.</returns>
        bool TrySetKey(TValue value, TKey key);

        /// <summary>
        /// Determines whether the the specified <paramref name="value"/> can be found.
        /// </summary>
        /// <param name="value">The value to be located.</param>
        /// <returns><c>true</c> if the specified value exists; otherwise, <c>false</c>.</returns>
        bool ContainsValue(TValue value);

        /// <summary>
        /// Returns an enumerator that iterates through the value/key pairs. The iteration order may be different from the key/value pair enumerator.
        /// </summary>
        /// <returns>A <see cref="System.Collections.Generic.IEnumerator&lt;TValue,TKey&gt;" /> that can be used to iterate through value/key pairs.</returns>
        IEnumerator<KeyValuePair<TValue, TKey>> GetReversedPairEnumerator();
    }
}
