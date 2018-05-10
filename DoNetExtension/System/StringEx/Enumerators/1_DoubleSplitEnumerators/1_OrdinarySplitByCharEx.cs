using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public class StringDoubleSplitResult
    {
        public StringSplitResult[] SecondarySplits;
        public char Separator;
        public int SeparatorIndex;
    }

    public static partial class StringEx
    {
        static IEnumerator<StringDoubleSplitResult> _innerGetDoubleSplitEnumeratorEx(string str, int startIndex, int endIndex, Func<char, int> primaryPredicate, Func<char, int> secondaryPredicate, bool removeEmptyEntires = false, bool trim = false)
        {
            var i = startIndex;
            var posList = new List<Pair<int>>(13);
            var separatorIndex = -1;
            while (i <= endIndex)
            {
                var primarySplit = i == endIndex || (separatorIndex = primaryPredicate(str[i])) != -1;
                if (primarySplit)
                {
                    var posCount = posList.Count;
                    if (posCount == 0)
                    {
                        string outputStr;
                        bool ignore;
                        if (trim)
                        {
                            outputStr = str.SubstringWithTrim(startIndex, i - startIndex);
                            ignore = removeEmptyEntires && outputStr.Equals(string.Empty);
                        }
                        else
                        {
                            outputStr = str.Substring(startIndex, i - startIndex);
                            ignore = removeEmptyEntires && i == startIndex;
                        }

                        if (!ignore)
                            yield return new StringDoubleSplitResult()
                            {
                                SecondarySplits = new StringSplitResult(outputStr, '\0', -1).CreateSingleton(),
                                Separator = i == endIndex ? '\0' : str[i],
                                SeparatorIndex = separatorIndex
                            };
                        startIndex = i + 1;
                    }
                    else
                    {
                        var output = new List<StringSplitResult>(posCount);
                        string outputStr;
                        bool ignore;
                        for (int j = 0; j < posCount; ++j)
                        {
                            var posPair = posList[j];
                            var pos = posPair.First;

                            if (trim)
                            {
                                outputStr = str.SubstringWithTrim(startIndex, pos - startIndex);
                                ignore = removeEmptyEntires && outputStr.Equals(string.Empty);
                            }
                            else
                            {
                                outputStr = str.Substring(startIndex, pos - startIndex);
                                ignore = removeEmptyEntires && i == startIndex;
                            }

                            if (!ignore)
                                output.Add(new StringSplitResult(outputStr, str[pos], posPair.Second));
                            startIndex = pos + 1;
                        }

                        if (trim)
                        {
                            outputStr = str.SubstringWithTrim(startIndex, i - startIndex);
                            ignore = removeEmptyEntires && outputStr.Equals(string.Empty);
                        }
                        else
                        {
                            outputStr = str.Substring(startIndex, i - startIndex);
                            ignore = removeEmptyEntires && i == startIndex;
                        }

                        if (!ignore)
                            output.Add(new StringSplitResult(outputStr, '\0', -1));

                        yield return new StringDoubleSplitResult()
                        {
                            SecondarySplits = output.ToArray(),
                            Separator = i == endIndex ? '\0' : str[i],
                            SeparatorIndex = separatorIndex
                        };

                        posList.Clear();
                    }
                }
                else if ((separatorIndex = secondaryPredicate(str[i])) != -1)
                    posList.Add(new Pair<int>(i, separatorIndex));

                ++i;
            }
        }

        /// <summary>
        /// Gets an object that can iterate through <see cref="StringDoubleSplitResult"/> objects that represent substring information in this string instance (or a part of the current string instance according to <paramref name="startIndex"/> and <paramref name="length"/>) that are delimited by Unicode characters satisfying the specified primary predicate and secondary predicate.
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
        /// <returns>An object that can iterate through <see cref="StringDoubleSplitResult"/> objects that represent substring information in this string instance (or a part of the current string instance) that are delimited by Unicode characters satisfying the specified two predicates.</returns>
        public static IEnumerator<StringDoubleSplitResult> GetDoubleSplitEnumeratorEx(this string str, Func<char, int> primaryPredicate, Func<char, int> secondaryPredicate, int startIndex, int length, bool removeEmptyEntires = false, bool trim = false)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerGetDoubleSplitEnumeratorEx(str, startIndex, endIndex, primaryPredicate, secondaryPredicate, removeEmptyEntires, trim);
        }

        /// <summary>
        /// Gets an object that can iterate through <see cref="StringDoubleSplitResult" /> objects that represent substring information in this string instance (or a part of the current string instance according to <paramref name="startIndex" />) that are delimited by Unicode characters satisfying the specified primary predicate and secondary predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="primaryPredicate">A function used to test each Unicode character of the current string. If a character passes this predicate, it returns a non-negative integer as the separator's index; otherwise, this function must return -1. Any character satisfying this predicate will be used as the primary separator. A primary spearator delimits substring arrays, for example, in "123,456;abc,def" which represent substring arrays { {"123", "456"}, {"abc", "def"} }, the semi-comma ';' is the primary separator.</param>
        /// <param name="secondaryPredicate">A function used to test each Unicode character of the current string. If a character passes this predicate, it returns a non-negative integer as the separator's index; otherwise, this function must return -1. Any character satisfying this predicate will be used as the secondary separator. A secondary separator delimits substrings in an array, for example, in "123,456;abc,def" which represent substring arrays { {"123", "456"}, {"abc", "def"} }, the comma ',' is the secondary separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="removeEmptyEntires">if set to <c>true</c> [remove empty entires].</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "123,   ,456;abc,def" split by comma ';' (primary separator) and ',' (secondary separator) is { {"123", "456"}, {"abc", "def"} }.</para></param>
        /// <returns>An object that can iterate through <see cref="StringDoubleSplitResult" /> objects that represent substring information in this string instance (or a part of the current string instance) that are delimited by Unicode characters satisfying the specified two predicates.</returns>
        public static IEnumerator<StringDoubleSplitResult> GetDoubleSplitEnumeratorEx(this string str, Func<char, int> primaryPredicate, Func<char, int> secondaryPredicate, int startIndex = 0, bool removeEmptyEntires = false, bool trim = false)
        {
            ExceptionHelper.NonNegativeArgumentRequired("startIndex", startIndex);
            return _innerGetDoubleSplitEnumeratorEx(str, startIndex, str.Length, primaryPredicate, secondaryPredicate, removeEmptyEntires, trim);
        }
    }
}
