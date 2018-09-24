using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Text
{
    /// <summary>
    /// Provides two cached <see cref="StringBuilder"/> instances for frequent use of <see cref="StringBuilder"/> class to build short strings (The maximum number of characters is defined by <see cref="MaxCacheSize"/>.).
    /// </summary>
    public static class StringBuilderCache
    {
        [ThreadStatic]
        private static StringBuilder _cachedInstanceA;
        [ThreadStatic]
        private static StringBuilder _cachedInstanceB;

        /// <summary>
        /// The maximum cache size.
        /// </summary>
        public const int MaxCacheSize = 360;

        /// <summary>
        /// Returns a cached <see cref="StringBuilder"/> instance if <paramref name="capacity"/> is equal to or smaller than the current cache size, or a new <see cref="StringBuilder"/> instance otherwise. The returned instance must be released by either calling <see cref="Release"/> or <see cref="GetStringAndRelease"/>.
        /// </summary>
        /// <param name="capacity">The intended capacity for the returned <see cref="StringBuilder"/> instance. If this capacity exceeds the current capacity of the cached <see cref="StringBuilder"/> instance, a new instance will be returned.</param>
        /// <returns>A cached <see cref="StringBuilder"/> instance or a new <see cref="StringBuilder"/> instance.</returns>
        public static StringBuilder Acquire(int capacity = 0x10)
        {
            if (capacity <= MaxCacheSize)
            {
                var cachedInstance = _cachedInstanceA;
                if (cachedInstance != null && capacity <= cachedInstance.Capacity)
                {
                    _cachedInstanceA = null;
                    cachedInstance.Clear();
                    return cachedInstance;
                }
            }
            return new StringBuilder(capacity);
        }

        /// <summary>
        /// Returns a cached <see cref="StringBuilder"/> instance if <paramref name="capacity"/> is equal to or smaller than the current cache size, or a new <see cref="StringBuilder"/> instance otherwise. The returned instance must be released by either calling <see cref="Release2"/> or <see cref="GetStringAndRelease2"/>.
        /// </summary>
        /// <param name="capacity">The intended capacity for the returned <see cref="StringBuilder"/> instance. If this capacity exceeds the current capacity of the cached <see cref="StringBuilder"/> instance, a new instance will be returned.</param>
        /// <returns>A cached <see cref="StringBuilder"/> instance or a new <see cref="StringBuilder"/> instance.</returns>
        public static StringBuilder Acquire2(int capacity = 0x10)
        {
            if (capacity <= MaxCacheSize)
            {
                StringBuilder cachedInstance = _cachedInstanceB;
                if ((cachedInstance != null) && (capacity <= cachedInstance.Capacity))
                {
                    _cachedInstanceA = null;
                    cachedInstance.Clear();
                    return cachedInstance;
                }
            }
            return new StringBuilder(capacity);
        }

        /// <summary>
        /// Releases a <see cref="StringBuilder"/> instance acquired by the <see cref="Acquire"/> method and returns the string instance it builds.
        /// </summary>
        /// <param name="toRelease">The <see cref="StringBuilder"/> instance to release.</param>
        /// <returns>The string built by the <see cref="StringBuilder"/>.</returns>
        public static string GetStringAndRelease(StringBuilder toRelease)
        {
            var str = toRelease.ToString();
            Release(toRelease);
            return str;
        }

        /// <summary>
        /// Releases a <see cref="StringBuilder"/> instance acquired by the <see cref="Acquire"/> method.
        /// </summary>
        /// <param name="toRelease">The <see cref="StringBuilder"/> instance to release.</param>
        public static void Release(StringBuilder toRelease)
        {
            if (toRelease.Capacity <= MaxCacheSize)
            {
                _cachedInstanceA = toRelease;
            }
        }

        /// <summary>
        /// Releases a <see cref="StringBuilder"/> instance acquired by the <see cref="Acquire2"/> method and returns the string instance it builds.
        /// </summary>
        /// <param name="toRelease">The <see cref="StringBuilder"/> instance to release.</param>
        /// <returns>The string built by the <see cref="StringBuilder"/>.</returns>
        public static string GetStringAndRelease2(StringBuilder toRelease)
        {
            string str = toRelease.ToString();
            Release2(toRelease);
            return str;
        }

        /// <summary>
        /// Releases a <see cref="StringBuilder"/> instance acquired by the <see cref="Acquire2"/> method.
        /// </summary>
        /// <param name="toRelease">The <see cref="StringBuilder"/> instance to release.</param>
        public static void Release2(StringBuilder toRelease)
        {
            if (toRelease.Capacity <= MaxCacheSize)
            {
                _cachedInstanceB = toRelease;
            }
        }
    }

}
