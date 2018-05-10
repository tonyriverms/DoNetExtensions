using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class StringEx
    {
        static IEnumerator<string[]> _innerGetDoubleSplitEnumerator(string str, int startIndex, int endIndex, Func<char, bool> primaryPredicate, Func<char, bool> secondaryPredicate, bool removeEmptyEntries = false, bool trim = false)
        {
            var i = startIndex;
            var posList = new List<int>(13);
            while (i <= endIndex)
            {
                var split = i == endIndex || primaryPredicate(str[i]);
                if (split)
                {
                    var posCount = posList.Count;
                    if(posCount == 0)
                    {
                        if (trim)
                        {
                            var trimmedStr = str.SubstringWithTrim(startIndex, i - startIndex);
                            if (!removeEmptyEntries || !trimmedStr.Equals(string.Empty)) yield return trimmedStr.CreateSingleton(); 
                        }
                        else if(!removeEmptyEntries || i != startIndex) yield return str.Substring(startIndex, i - startIndex).CreateSingleton();
                        startIndex = i + 1;
                    }
                    else
                    {
                        var output = new List<string>(posCount);
                        string outputStr;
                        bool ignore;
                        for (int j = 0; j < posCount; ++j)
                        {
                            var pos = posList[j];
                            if (trim)
                            {
                                outputStr = str.SubstringWithTrim(startIndex, pos - startIndex);
                                ignore = removeEmptyEntries && outputStr.Equals(string.Empty);
                            }
                            else
                            {
                                outputStr = str.Substring(startIndex, pos - startIndex);
                                ignore = removeEmptyEntries && pos == startIndex;
                            }
                            if (!ignore) output.Add(outputStr);
                            startIndex = pos + 1;
                        }

                        if (trim)
                        {
                            outputStr = str.SubstringWithTrim(startIndex, i - startIndex);
                            ignore = removeEmptyEntries && outputStr.Equals(string.Empty);
                        }
                        else
                        {
                            outputStr = str.Substring(startIndex, i - startIndex);
                            ignore = removeEmptyEntries && i == startIndex;
                        }

                        if (!ignore) output.Add(outputStr);
                        startIndex = i + 1;

                        yield return output.ToArray();
                        posList.Clear();
                    }
                }
                else if(secondaryPredicate(str[i]))
                    posList.Add(i);

                ++i;
            }
        }

        /// <summary>
        /// Gets an object that can iterate through groups of substrings in this string instance (or a part of the current string instance according to <paramref name="startIndex"/> and <paramref name="length"/>) that are delimited by Unicode characters satisfying the specified primary predicate and secondary predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="primaryPredicate">A function used to test each Unicode character of the current string. If a character passes this predicate, it returns a non-negative integer as the separator's index; otherwise, this function must return -1. Any character satisfying this predicate will be used as the primary separator. A primary spearator delimits substring arrays, for example, in "123,456;abc,def" which represent substring arrays { {"123", "456"}, {"abc", "def"} }, the semi-comma ';' is the primary separator.</param>
        /// <param name="secondaryPredicate">A function used to test each Unicode character of the current string. If a character passes this predicate, it returns a non-negative integer as the separator's index; otherwise, this function must return -1. Any character satisfying this predicate will be used as the secondary separator. A secondary separator delimits substrings in an array, for example, in "123,456;abc,def" which represent substring arrays { {"123", "456"}, {"abc", "def"} }, the comma ',' is the secondary separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if the returned enumerator should ignore empty substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "123,   ,456;abc,def" split by comma ';' (primary separator) and ',' (secondary separator) is { {"123", "456"}, {"abc", "def"} }.</para></param>
        /// <returns>An object that can iterate through groups of substrings in this string instance (or a part of the current string instance) that are delimited by Unicode characters satisfying the specified two predicates.</returns>
        public static IEnumerator<string[]> GetDoubleSplitEnumerator(this string str, Func<char, bool> primaryPredicate, Func<char, bool> secondaryPredicate, int startIndex, int length, bool removeEmptyEntries = false, bool trim = false)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerGetDoubleSplitEnumerator(str, startIndex, endIndex, primaryPredicate, secondaryPredicate, removeEmptyEntries, trim);
        }

        /// <summary>
        /// Gets an object that can iterate through groups of substrings in this string instance (or a part of the current string instance according to <paramref name="startIndex" />) that are delimited by Unicode characters satisfying the specified primary predicate and secondary predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="primaryPredicate">A function used to test each Unicode character of the current string. If a character passes this predicate, it returns a non-negative integer as the separator's index; otherwise, this function must return -1. Any character satisfying this predicate will be used as the primary separator. A primary spearator delimits substring arrays, for example, in "123,456;abc,def" which represent substring arrays { {"123", "456"}, {"abc", "def"} }, the semi-comma ';' is the primary separator.</param>
        /// <param name="secondaryPredicate">A function used to test each Unicode character of the current string. If a character passes this predicate, it returns a non-negative integer as the separator's index; otherwise, this function must return -1. Any character satisfying this predicate will be used as the secondary separator. A secondary separator delimits substrings in an array, for example, in "123,456;abc,def" which represent substring arrays { {"123", "456"}, {"abc", "def"} }, the comma ',' is the secondary separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if the returned enumerator should ignore empty substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "123,   ,456;abc,def" split by comma ';' (primary separator) and ',' (secondary separator) is { {"123", "456"}, {"abc", "def"} }.</para></param>
        /// <returns>An object that can iterate through groups of substrings in this string instance (or a part of the current string instance) that are delimited by Unicode characters satisfying the specified two predicates.</returns>
        public static IEnumerator<string[]> GetDoubleSplitEnumerator(this string str, Func<char, bool> primaryPredicate, Func<char, bool> secondaryPredicate, int startIndex = 0, bool removeEmptyEntries = false, bool trim = false)
        {
            ExceptionHelper.NonNegativeArgumentRequired("startIndex", startIndex);
            return _innerGetDoubleSplitEnumerator(str, startIndex, str.Length, primaryPredicate, secondaryPredicate, removeEmptyEntries, trim);
        }
    }
}
