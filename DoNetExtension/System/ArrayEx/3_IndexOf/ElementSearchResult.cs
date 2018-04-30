using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// Stores the result of an element search (usually by the <c>IndexOfAny</c> method of an array).
    /// </summary>
    /// <typeparam name="TElement">The type of the found element stored in this object.</typeparam>
    public class ElementSearchResult<TElement>
    {
        /// <summary>
        /// The position of the found element (property <see cref="Value"/>) in the original array.
        /// </summary>
        public int Position;
        /// <summary>
        /// The found element.
        /// </summary>
        public TElement Value;
        /// <summary>
        /// The index of the found element in the element array to search.
        /// </summary>
        public int HitIndex;
    }
}
