using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class ArrayEx
    {
        /// <summary>
        /// Creates a new one-dimensional <see cref="System.Array"/> instance containing this object as its only element.
        /// </summary>
        /// <typeparam name="T">The type of this object.</typeparam>
        /// <param name="obj">This object.</param>
        /// <returns>A new  one-dimensional <see cref="System.Array"/> instance containing this object as its only element.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] Singleton<T>(this T obj)
        {
            return new T[] { obj };
        }

        /// <summary>
        /// Creates a new one-dimensional <see cref="System.Array"/> instance with each element equal to this object.
        /// </summary>
        /// <typeparam name="T">The type of this object.</typeparam>
        /// <param name="obj">This object.</param>
        /// <param name="length">The length of the created array.</param>
        /// <returns>A new  one-dimensional <see cref="System.Array"/> instance with each element equal to this object.</returns>
        public static T[] CreateArray<T>(this T obj, int length)
        {
            var array = new T[length];
            for (int i = 0; i < length; ++i)
                array[i] = obj;
            return array;
        }
    }
}
