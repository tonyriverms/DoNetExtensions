using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class StringEx
    {

        /// <summary>
        /// Splits this string in some special way.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="specialSplit">Specifies how to split the current string.</param>
        /// <returns>A string array storing the split result.</returns>
        public static string[] Split(this string str, SpecialStringSplit specialSplit)
        {
            var list = new List<string>();
            switch (specialSplit)
            {
                case SpecialStringSplit.GetASCIIParts:
                    {
                        int pi = -1;
                        for (int i = 0; i < str.Length; i++)
                        {
                            var c = str[i];
                            if (c.IsASCII())
                            {
                                if (pi == -1)
                                    pi = i;
                            }
                            else
                            {
                                if (pi != -1)
                                {
                                    list.Add(str.Substring(pi, i - pi));
                                    pi = -1;
                                }
                            }
                        }
                        if (pi != -1)
                            list.Add(str.Substring(pi));
                        break;
                    }
                case SpecialStringSplit.GetNonASCIIParts:
                    {
                        int pi = -1;
                        for (int i = 0; i < str.Length; i++)
                        {
                            var c = str[i];
                            if (!c.IsASCII())
                            {
                                if (pi == -1)
                                    pi = i;
                            }
                            else
                            {
                                if (pi != -1)
                                {
                                    list.Add(str.Substring(pi, i - pi));
                                    pi = -1;
                                }
                            }
                        }
                        if (pi != -1)
                            list.Add(str.Substring(pi));
                        break;
                    }
                case SpecialStringSplit.SplitASCIIPartsAndNonASCIIChars:
                    {
                        int pi = -1;
                        for (int i = 0; i < str.Length; i++)
                        {
                            var c = str[i];
                            if (c.IsASCII())
                                if (pi == -1) pi = i;
                                else
                                {
                                    if (pi != -1)
                                    {
                                        list.Add(str.Substring(pi, i - pi));
                                        pi = -1;
                                    }
                                    list.Add(c.ToString());
                                }
                        }
                        if (pi != -1)
                            list.Add(str.Substring(pi));
                        break;
                    }
                case SpecialStringSplit.SplitASCIIPartsAndNonASCIIParts:
                    {
                        int pi = -1;
                        int pj = -1;
                        for (int i = 0; i < str.Length; i++)
                        {
                            var c = str[i];
                            if (c.IsASCII())
                            {
                                if (pj != -1)
                                {
                                    list.Add(str.Substring(pj, i - pj));
                                    pj = -1;
                                }
                                if (pi == -1) pi = i;
                            }
                            else
                            {
                                if (pi != -1)
                                {
                                    list.Add(str.Substring(pi, i - pi));
                                    pi = -1;
                                }
                                if (pj == -1) pj = i;
                            }
                        }

                        if (pi != -1)
                            list.Add(str.Substring(pi));
                        else if (pj != -1)
                            list.Add(str.Substring(pj));
                        break;
                    }
            }
            return list.ToArray();
        }

        /// <summary>
        /// Splits this string instance into a two-dimensional jagged array string[][].
        /// For example, you may split "ab,c,defg;h,ijk;l,mn,op,q" with ',' as the <paramref name="separator1"/> 
        /// and ';' the <paramref name="separator2"/>.
        /// The result is three arrays of strings, the first one bing string array {"ab", "c", "defg"}.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separator1">The separator to split each string of the results from spliting the current string by <paramref name="separator2"/>.</param>
        /// <param name="separator2">The separator to split the current string into a string array each of which will be then split by <paramref name="separator1"/>.</param>
        /// <param name="options">Specifies whether the empty entries should be returned.</param>
        /// <returns>A two-dimensional jagged array storing the split result.</returns>
        public static string[][] Split(this string str, char separator1, char separator2, StringSplitOptions options)
        {
            var strs = str.Split(new char[] { separator2 }, options);
            var count = strs.Length;
            var output = new string[count][];
            for (int i = 0; i < count; i++)
                output[i] = strs[i].Split(new char[] { separator1 }, options);
            return output;
        }

        /// <summary>
        /// Splits this string instance into a two-dimensional jagged array string[][].
        /// For example, you may split "ab,c:defg;h,ijk;l,mn,op|q" with {',', '|'} as <paramref name="separators1"/> 
        /// and {';', ':'} as <paramref name="separators2"/>.
        /// The result is four arrays of strings, the first one be string array {"ab", "c"}.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separators1">The separators to split each string of the results from spliting the current string by <paramref name="separators2"/>.</param>
        /// <param name="separators2">The separators to split the current string into a string array each of which will be then split by <paramref name="separators1"/>.</param>
        /// <param name="options">Specifies whether the empty entries should be returned.</param>
        /// <returns>A two-dimensional jagged array storing the split result.</returns>
        public static string[][] Split(this string str, char[] separators1, char[] separators2, StringSplitOptions options)
        {
            var strs = str.Split(separators2, options);
            var count = strs.Length;
            var output = new string[count][];
            for (int i = 0; i < count; i++)
                output[i] = strs[i].Split(separators1, options);
            return output;
        }

        /// <summary>
        /// Splits the current string instance to lines represented by a string array.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="options">Specifies whether the empty entries should be returned.</param>
        /// <returns>Lines of the given string instances.</returns>
        public static string[] SplitToLines(this string str, StringSplitOptions options = StringSplitOptions.None)
        {
            return str.Split(new string[] { Environment.NewLine }, options);
        }

        /// <summary>
        /// Splits this string by upper letters. 
        /// </summary>
        /// <param name="str">The string instance to operate on.</param>
        /// <param name="ignoreConsecutiveUpperLetters">Indicates whether to split consecutive upper letters. 
        /// <para>For example, if this parameter is set true, string "aBigAPPLETree" will be split as "a Big APPLETree"; 
        /// otherwise, "a Big A P P L E Tree".</para></param>
        /// <returns>A string array.</returns>
        public unsafe static string[] SplitByInitials(this string str, bool ignoreConsecutiveUpperLetters)
        {
            var output = new List<string>(5);

            GCHandle gch = GCHandle.Alloc(str, GCHandleType.Pinned);
            char* ptr = (char*)gch.AddrOfPinnedObject();
            int start = 0;
            bool lastUpper = ptr[0].IsUpper();

            int i;
            for (i = 1; i < str.Length; i++)
            {
                if (ptr[i].IsUpper())
                {
                    if (!lastUpper || !ignoreConsecutiveUpperLetters)
                    {
                        output.Add(new string(ptr, start, i - start));
                        start = i;
                        lastUpper = true;
                    }
                }
                else
                    lastUpper = false;
            }

            if (i != start)
                output.Add(new string(ptr, start, i - start));

            gch.Free();
            return output.ToArray();
        }

        /// <summary>
        /// Splits a string into substrings by spaces defined by <see cref="Char.IsWhiteSpace(char)"/>.
        /// </summary>
        /// <param name="str">The string to split.</param>
        /// <param name="options"><see cref="System.StringSplitOptions.RemoveEmptyEntries"/> to omit empty array elements from the array returned; or System.StringSplitOptions.None to include empty array elements in the array returned.</param>
        /// <returns>An array whose elements contain the substrings from this instance that are delimited by white spaces defined by <see cref="Char.IsWhiteSpace(char)"/>.</returns>
        public static string[] SplitBySpaces(this string str, StringSplitOptions options)
        {
            return str.Split(new char[] { }, options);
        }

        /// <summary>
        /// Splits a string into substrings using TAB space as the delimiter.
        /// </summary>
        /// <param name="str">The string to split.</param>
        /// <param name="options"><see cref="System.StringSplitOptions.RemoveEmptyEntries"/> to omit empty array elements from the array returned; or System.StringSplitOptions.None to include empty array elements in the array returned.</param>
        /// <returns>An array whose elements contain the substrings from this instance that are delimited by TABs.</returns>
        public static string[] SplitByTab(this string str, StringSplitOptions options = StringSplitOptions.None)
        {
            return str.Split(new char[] { '\t' }, options);
        }

        /// <summary>
        /// Splits a string into substrings by spaces defined by <see cref="Char.IsWhiteSpace(char)"/>. Empty entries will be removed.
        /// </summary>
        /// <param name="str">The string to split.</param>
        /// <returns>An array whose elements contain the substrings from this instance that are delimited by white spaces defined by <see cref="Char.IsWhiteSpace(char)"/>.</returns>
        public static string[] SplitBySpaces(this string str)
        {
            return str.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Returns a string array that contains the substrings in this instance that are delimited by the specified <paramref name="separator"/>.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separator">A <see cref="string"/> that delimits the substrings in this string, or null. If the separator parameter is null, white-space characters are assumed to be the delimiter. </param>
        /// <param name="options"><see cref="StringSplitOptions.RemoveEmptyEntries"/> to omit empty array elements from the array returned; or <see cref="StringSplitOptions.None"/> to include empty array elements in the array returned.</param>
        /// <returns>An array whose elements contain the substrings in this string that are delimited by the specified <paramref name="separator"/>.</returns>
        public static string[] Split(this string str, string separator, StringSplitOptions options)
        {
            return str.Split(new string[] { separator }, options);
        }

        public static string[] ToArrayWithSplit(this IEnumerable<string> strs, char[] separators, StringSplitOptions options)
        {
            var output = new List<string>();
            foreach (var str in strs)
                output.AddRange(str.Split(separators, options));
            return output.ToArray();
        }

        public static string[] ToArrayWithSplit(this IEnumerable<string> strs, char separator, StringSplitOptions options)
        {
            return ToArrayWithSplit(strs, new char[] { separator }, options);
        }

        public static string[] ToArrayWithSplit(this IEnumerable<string> strs, char[] separators)
        {
            var output = new List<string>();
            foreach (var str in strs)
                output.AddRange(str.Split(separators));
            return output.ToArray();
        }

        public static string[] ToArrayWithSplit(this IEnumerable<string> strs, char separator)
        {
            var output = new List<string>();
            foreach (var str in strs)
                output.AddRange(str.Split(separator));
            return output.ToArray();
        }

        public static string[] ToArrayWithDistinctSplit(this IEnumerable<string> strs, char[] separators, StringSplitOptions options)
        {
            var output = new HashSet<string>();
            foreach (var str in strs)
            {
                var splits = str.Split(separators, options);
                foreach (var split in splits)
                    if (!output.Contains(split))
                        output.Add(split);
            }
            return output.ToArray();
        }

        public static string[] ToArrayWithDistinctSplit(this IEnumerable<string> strs, char separator, StringSplitOptions options)
        {
            return ToArrayWithDistinctSplit(strs, new char[] { separator }, options);
        }

        public static string[] ToArrayWithDistinctSplit(this IEnumerable<string> strs, char[] separators)
        {
            var output = new HashSet<string>();
            foreach (var str in strs)
            {
                var splits = str.Split(separators);
                foreach (var split in splits)
                    if (!output.Contains(split))
                        output.Add(split);
            }
            return output.ToArray();
        }

        public static string[] ToArrayWithDistinctSplit(this IEnumerable<string> strs, char separator)
        {
            var output = new HashSet<string>();
            foreach (var str in strs)
            {
                var splits = str.Split(separator);
                foreach (var split in splits)
                    if (!output.Contains(split))
                        output.Add(split);
            }
            return output.ToArray();
        }
    }
}
