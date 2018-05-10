using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class StringEx
    {
        #region Common

        /// <summary>
        /// Splits this string into two parts at the position where the first occurrence of <paramref name="separator"/> is found.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="separator">A string as the separator. NOTE that this separator will be removed. For example, split "abcdef" by "cd" and we will get "ab" and "ef".
        /// </param>
        /// <returns>A pair of strings if the separator is found; otherwise, <c>null</c>.</returns>
        public static Pair<string> BiSplit(this string source, string separator)
        {
            var idx = source.IndexOf(separator);
            if (idx == -1) return null;
            var str1 = source.Substring(0, idx);
            var str2 = source.Substring(idx + separator.Length);

            return new Pair<string>(str1, str2);
        }

        /// <summary>
        /// Splits this string into two parts at the position where the first occurrence of <paramref name="separator" /> is found.
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="separator">A string as the separator. NOTE that this separator will be removed. For example, split "abcdef" by "cd" and we will get "ab" and "ef".</param>
        /// <param name="value1">Returns the substring before the first occurrence of the separator.</param>
        /// <param name="value2">Returns the substring after the first occurrence of the separator.</param>
        /// <returns>
        ///   <c>true</c> if the separator is found and the separation is successful; otherwise, <c>false</c>.
        /// </returns>
        public static bool BiSplit(this string source, string separator, out string value1, out string value2)
        {
            var idx = source.IndexOf(separator);
            if (idx == -1)
            {
                value1 = null;
                value2 = null;
                return false;
            }
            else
            {
                value1 = source.Substring(0, idx);
                value2 = source.Substring(idx + separator.Length);
                return true;
            }
        }


        #endregion

        #region CommonEx




        #endregion

        #region WithQuotes
        #endregion
    }
}
