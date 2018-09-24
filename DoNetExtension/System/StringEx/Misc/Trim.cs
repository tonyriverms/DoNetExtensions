using System.Collections.Generic;

namespace System
{
    public static partial class StringEx
    {
        #region TrimAll

        /// <summary>
        /// Trims all leading and trailing white spaces from every string in this string array/list.
        /// </summary>
        /// <param name="stringArray">This string array/list.</param>
        public static void TrimAll(this IList<string> stringArray)
        {
            for (var i = 0; i < stringArray.Count; ++i)
                stringArray[i] = stringArray[i].Trim();
        }

        /// <summary>
        /// Trims all leading white spaces from every string in this string array/list.
        /// </summary>
        /// <param name="stringArray">This string array/list.</param>
        public static void TrimStartAll(this IList<string> stringArray)
        {
            for (var i = 0; i < stringArray.Count; ++i)
                stringArray[i] = stringArray[i].TrimStart();
        }

        /// <summary>
        /// Trims all trailing white spaces from every string in this string array/list.
        /// </summary>
        /// <param name="stringArray">This string array/list.</param>
        public static void TrimEndAll(this IList<string> stringArray)
        {
            for (var i = 0; i < stringArray.Count; ++i)
                stringArray[i] = stringArray[i].TrimStart();
        }

        /// <summary>
        /// Removes all leading and trailing occurrences of a set of characters specified in an array from every string in this string array/list.
        /// </summary>
        /// <param name="stringArray">This string array/list.</param>
        /// <param name="trimChars">An array of Unicode characters to remove, or null.</param>
        public static void TrimAll(this IList<string> stringArray, params char[] trimChars)
        {
            for (var i = 0; i < stringArray.Count; ++i)
                stringArray[i] = stringArray[i].Trim(trimChars);
        }

        /// <summary>
        /// Removes all leading occurrences of a set of characters specified in an array from every string in this string array/list.
        /// </summary>
        /// <param name="stringArray">This string array/list.</param>
        /// <param name="trimChars">An array of Unicode characters to remove, or null.</param>
        public static void TrimStartAll(this IList<string> stringArray, params char[] trimChars)
        {
            for (var i = 0; i < stringArray.Count; ++i)
                stringArray[i] = stringArray[i].TrimStart(trimChars);
        }

        /// <summary>
        /// Removes all trailing occurrences of a set of characters specified in an array from every string in this string array/list.
        /// </summary>
        /// <param name="stringArray">This string array/list.</param>
        /// <param name="trimChars">An array of Unicode characters to remove, or null.</param>
        public static void TrimEndAll(this IList<string> stringArray, params char[] trimChars)
        {
            for (var i = 0; i < stringArray.Count; ++i)
                stringArray[i] = stringArray[i].TrimStart(trimChars);
        }

        #endregion

        #region Trim Strings

        /// <summary>
        /// Removes the first leading and tailing occurrences of any strings in <paramref name="trims"/> from the current string instance.
        /// NOTE only the first matched leading and tailing occurrences will be removed. For example, <c>"123123abc456".Trim("123","456")</c> gives "123abc".
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="trims">The sequence of strings to match the beginning and the end of this string instance.</param>
        /// <param name="trimmedStart">Gets a value indicating whether any leading substring is trimmed. If this returns <c>true</c>, at least one string in <paramref name="trims"/>  is at the beginning of this string and trimmed.</param>
        /// <param name="trimmedEnd">Gets a value indicating whether any tailing substring is trimmed. If this returns <c>true</c>, at least one string in <paramref name="trims"/>  is at the end of this string and trimmed.</param>
        /// <returns>A copy of the original string with the beginning trimmed, if any of the strings in <paramref name="trims"/> matches the beginning or the end of the original string; otherwise, the original string instance.</returns>
        public static string Trim(this string source, IEnumerable<string> trims, out bool trimmedStart, out bool trimmedEnd)
        {
            return source.TrimStart(trims, out trimmedStart).TrimEnd(trims, out trimmedEnd);
        }

        /// <summary>
        /// Removes the first leading occurrence of any strings in <paramref name="trims"/> from the current string instance.
        /// NOTE only the first matched leading occurrences will be removed. For example, <c>"123123abc456".TrimStart("123","456")</c> gives "123abc456".
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="trims">The sequence of strings to match the beginning of this string instance.</param>
        /// <param name="trimmed">Gets a value indicating whether any leading substring is trimmed. If this returns <c>true</c>, at least one string in <paramref name="trims"/>  is at the beginning of this string and trimmed.</param>
        /// <returns>A copy of the original string with the beginning trimmed, if any of the strings in <paramref name="trims"/> matches the beginning of the original string; otherwise, the original string instance.</returns>
        public static string TrimStart(this string source, IEnumerable<string> trims, out bool trimmed)
        {
            var s = source.StartsWithAny(trims);
            trimmed = s != null;
            return trimmed ? source.Substring(s.Length) : source;
        }

        /// <summary>
        /// Removes the first tailing occurrence of any strings in <paramref name="trims"/> from the current string instance.
        /// NOTE only the first matched tailing occurrence will be removed. For example, <c>"123abc456456".TrimEnd("123","456")</c> gives "123abc456".
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="trims">The sequence of strings to match the end of this string instance.</param>
        /// <param name="trimmed">Gets a value indicating whether any tailing substring is trimmed. If this returns <c>true</c>, at least one string in <paramref name="trims"/>  is at the end of this string and trimmed.</param>
        /// <returns>A copy of the original string with the beginning trimmed, if any of the strings in <paramref name="trims"/> matches the end of the original string; otherwise, the original string instance.</returns>
        public static string TrimEnd(this string source, IEnumerable<string> trims, out bool trimmed)
        {
            var s = source.EndsWithAny(trims);
            if (s == null)
            {
                trimmed = false;
                return source;
            }
            else
            {
                trimmed = true;
                return source.Substring(0, source.Length - s.Length);
            }
        }

        /// <summary>
        /// Removes the first leading and tailing occurrences of any strings in <paramref name="trims"/> from the current string instance.
        /// NOTE only the first matched leading and tailing occurrences will be removed. For example, <c>"123123abc456".Trim("123","456")</c> gives "123abc".
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="trims">The sequence of strings to match the beginning and the end of this string instance.</param>
        /// <returns>A copy of the original string with the beginning trimmed, if any of the strings in <paramref name="trims"/> matches the beginning or the end of the original string; otherwise, the original string instance.</returns>
        public static string Trim(this string source, IEnumerable<string> trims)
        {
            return source.TrimStart(trims).TrimEnd(trims);
        }

        /// <summary>
        /// Removes the first leading occurrence of any strings in <paramref name="trims"/> from the current string instance.
        /// NOTE only the first matched leading occurrences will be removed. For example, <c>"123123abc456".TrimStart("123","456")</c> gives "123abc456".
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="trims">The sequence of strings to match the beginning of this string instance.</param>
        /// <returns>A copy of the original string with the beginning trimmed, if any of the strings in <paramref name="trims"/> matches the beginning of the original string; otherwise, the original string instance.</returns>
        public static string TrimStart(this string source, IEnumerable<string> trims)
        {
            var s = source.StartsWithAny(trims);
            return s == null ? source : source.Substring(s.Length);
        }

        /// <summary>
        /// Removes the first tailing occurrence of any strings in <paramref name="trims"/> from the current string instance.
        /// NOTE only the first matched tailing occurrence will be removed. For example, <c>"123abc456456".TrimEnd("123","456")</c> gives "123abc456".
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="trims">The sequence of strings to match the end of this string instance.</param>
        /// <returns>A copy of the original string with the beginning trimmed, if any of the strings in <paramref name="trims"/> matches the end of the original string; otherwise, the original string instance.</returns>
        public static string TrimEnd(this string source, IEnumerable<string> trims)
        {
            var s = source.EndsWithAny(trims);
            return s == null ? source : source.Substring(0, source.Length - s.Length);
        }

        /// <summary>
        /// Removes the first leading and tailing occurrences of any strings in <paramref name="trims"/> from the current string instance.
        /// NOTE only the first matched leading and tailing occurrences will be removed. For example, <c>"123123abc456".Trim("123","456")</c> gives "123abc".
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="trims">The sequence of strings to match the beginning and the end of this string instance.</param>
        /// <returns>A copy of the original string with the beginning trimmed, if any of the strings in <paramref name="trims"/> matches the beginning or the end of the original string; otherwise, the original string instance.</returns>
        public static string Trim(this string source, params string[] trims)
        {
            return source.TrimStart(trims).TrimEnd(trims);
        }

        /// <summary>
        /// Removes the first leading occurrence of any strings in <paramref name="trims"/> from the current string instance.
        /// NOTE only the first matched leading occurrences will be removed. For example, <c>"123123abc456".TrimStart("123","456")</c> gives "123abc456".
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="trims">The sequence of strings to match the beginning of this string instance.</param>
        /// <returns>A copy of the original string with the beginning trimmed, if any of the strings in <paramref name="trims"/> matches the beginning of the original string; otherwise, the original string instance.</returns>
        public static string TrimStart(this string source, params string[] trims)
        {
            var s = source.StartsWithAny(trims);
            return s == null ? source : source.Substring(s.Length);
        }

        /// <summary>
        /// Removes the first tailing occurrence of any strings in <paramref name="trims"/> from the current string instance.
        /// NOTE only the first matched tailing occurrence will be removed. For example, <c>"123abc456456".TrimEnd("123","456")</c> gives "123abc456".
        /// </summary>
        /// <param name="source">This string instance.</param>
        /// <param name="trims">The sequence of strings to match the end of this string instance.</param>
        /// <returns>A copy of the original string with the beginning trimmed, if any of the strings in <paramref name="trims"/> matches the end of the original string; otherwise, the original string instance.</returns>
        public static string TrimEnd(this string source, params string[] trims)
        {
            var s = source.EndsWithAny(trims);
            return s == null ? source : source.Substring(0, source.Length - s.Length);
        }

        #endregion

        #region Trim Chars

        /// <summary>
        /// Removes all leading occurrences of characters that satisfy the specified <paramref name="predicate"/>. NOTE this method may return the original instance if no characters are removed.
        /// </summary>
        /// <param name="str">The string instance.</param>
        /// <param name="predicate">The predicate to test characters.</param>
        /// <returns>The string that remains after all leading occurrences of characters that satisfy the specified <paramref name="predicate"/> are removed from the start of the current string. If any character is trimmed, a new instance will be returned; otherwise, if no character is removed, the original instance will be returned.</returns>
        public static string TrimStart(this string str, Func<char, bool> predicate)
        {
            if (str.IsNullOrEmpty()) return str;

            for (int i = 0, j = str.Length; i < j; ++i)
            {
                if (!predicate(str[i]))
                {
                    return i != 0 ? str.Substring(i) : str;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Removes all tailing occurrences of characters that satisfy the specified <paramref name="predicate"/>. NOTE this method may return the original instance if no characters are removed.
        /// </summary>
        /// <param name="str">The string instance.</param>
        /// <param name="predicate">The predicate to test characters.</param>
        /// <returns>The string that remains after all tailing occurrences of characters that satisfy the specified <paramref name="predicate"/> are removed from the start of the current string. If any character is trimmed, a new instance will be returned; otherwise, if no character is removed, the original instance will be returned.</returns>
        public static string TrimEnd(this string str, Func<char, bool> predicate)
        {
            if (str.IsNullOrEmpty()) return str;

            var endIndex = str.Length - 1;
            for (var i = endIndex; i >= 0; --i)
            {
                if (!predicate(str[i]))
                {
                    return i != endIndex ? str.Substring(0, i + 1) : str;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Removes all leading and tailing occurrences of characters that satisfy the specified <paramref name="predicate"/>. NOTE this method may return the original instance if no characters are removed.
        /// </summary>
        /// <param name="str">The string instance.</param>
        /// <param name="predicate">The predicate to test characters.</param>
        /// <returns>The string that remains after all leading and tailing occurrences of characters that satisfy the specified <paramref name="predicate"/> are removed from the start of the current string. If any character is trimmed, a new instance will be returned; otherwise, if no character is removed, the original instance will be returned.</returns>
        public static string Trim(this string str, Func<char, bool> predicate)
        {
            return TrimEnd(TrimStart(str, predicate), predicate);
        }

        #endregion
    }
}
