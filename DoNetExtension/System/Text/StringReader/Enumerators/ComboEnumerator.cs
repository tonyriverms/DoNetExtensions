using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Text
{
    public partial class StringReader
    {
        static string[] _comboEnumKeywordsParse(StringReader partReader, char parameterSeparator)
        {
            var keywordList = new List<string>(7);
            partReader.RemoveBrackets();
            var keywordsEnum = partReader.GetSplitReaderEnumeratorWithQuotes(parameterSeparator, '[', ']');
            StringReader keywordReader;
            while (keywordsEnum.MoveNext())
            {
                keywordReader = keywordsEnum.Current;
                keywordReader.RemoveBrackets();
                keywordReader.Trim();
                keywordList.Add(keywordReader.ReadToEnd());
            }
            return keywordList.ToArray();
        }

        static int[,] _comboEnumDepthParse(string[] exps, char parameterSeparator)
        {
            var dlen = exps.Length;
            var depths = new int[dlen, 2];

            for (int i = 0; i < dlen; ++i)
            {
                var depthStr = exps[i];
                var depthPair = depthStr.BiSplit('-');
                if (depthPair == null)
                {
                    int depth;
                    if (int.TryParse(depthStr, out depth))
                        depths[i, 0] = depths[i, 1] = depth;
                    else return null;
                }
                else
                {
                    if (!int.TryParse(depthPair.Item1, out depths[i, 0])) return null;
                    if (!int.TryParse(depthPair.Item2, out depths[i, 1])) return null;
                }
            }

            return depths;
        }

        static int[] _comboEnumCountParse(string[] exps)
        {
            var countLen = exps.Length;
            var counts = new int[countLen];
            for (int i = 0; i < countLen; ++i)
            {
                var countStr = exps[i].Trim();
                int val;
                if (!int.TryParse(countStr, out val))
                {
                    counts = null;
                    break;
                }
                counts[i] = val;
            }
            return counts;
        }

        static byte[] _comboModeParse(string[] exps)
        {
            return exps.Select(exp =>
            {
                return _comboModeParse(exp);
            }).ToArray();
        }

        static byte _comboModeParse(string exp)
        {
            if (exp.Equals("static", StringComparison.InvariantCultureIgnoreCase)) return (byte)1;
            else if (exp.Equals("random", StringComparison.InvariantCultureIgnoreCase)) return (byte)2;
            else if (exp.Equals("deep random", StringComparison.InvariantCultureIgnoreCase)) return (byte)3;
            else return (byte)0;
        }

        /// <summary>
        /// Views the current reading scope as a combination expression and returns an enumerator that can iterate through certain combinations. For detailed remarks, <see cref="String.GetComboEnumerator" />.
        /// </summary>
        /// <param name="parameterGroupSeparator">A Unicode character used as the separator to delimit different types of arguments.</param>
        /// <param name="parameterSeparator">A Unicode character used as the separator to delimit different arguments of the same type.</param>
        /// <param name="parameterLeftBracket">A Unicode character right paired by the <paramref name="parameterRightBracket" /> to bracket the argument part.</param>
        /// <param name="parameterRightBracket">A Unicode character left paired by the <paramref name="parameterLeftBracket" /> to bracket the argument part.</param>
        /// <param name="leftQuote">A Unicode character right paired by the <paramref name="rightQuote" /> to escape <paramref name="parameterGroupSeparator" /> and <paramref name="parameterSeparator" />.</param>
        /// <param name="rightQuote">A Unicode character left paired by the <paramref name="leftQuote" /> to escape <paramref name="parameterGroupSeparator" /> and <paramref name="parameterSeparator" />.</param>
        /// <returns>An enumerator object that can be used to iterate through combinations.</returns>
        /// <exception cref="System.FormatException">Occurs the current reading scope cannot be parsed as a combination expression.</exception>
        public IEnumerator<string[]> GetComboEnumerator(char parameterGroupSeparator = ';', char parameterSeparator = ',',
            char parameterLeftBracket = '(', char parameterRightBracket = ')', char leftQuote = '[', char rightQuote = ']')
        {
            return GetComboEnumerator<string>(null);
        }

        /// <summary>
        /// Views the current reading scope as a combination expression and returns an enumerator that can iterate through certain combinations. This overload supports build-in data conversion from <see cref="System.String"/> to another output type <typeparamref name="T"/>. For detailed remarks, <see cref="String.GetComboEnumerator" />.
        /// </summary>
        /// <typeparam name="T">The type of objects generated by the returned enumerator.</typeparam>
        /// <param name="converter">Provides a method that converts each string instance of a combination to an object of type <typeparamref name="T"/>.</param>
        /// <param name="parameterGroupSeparator">A Unicode character used as the separator to delimit different types of arguments.</param>
        /// <param name="parameterSeparator">A Unicode character used as the separator to delimit different arguments of the same type.</param>
        /// <param name="parameterLeftBracket">A Unicode character right paired by the <paramref name="parameterRightBracket" /> to bracket the argument part.</param>
        /// <param name="parameterRightBracket">A Unicode character left paired by the <paramref name="parameterLeftBracket" /> to bracket the argument part.</param>
        /// <param name="leftQuote">A Unicode character right paired by the <paramref name="rightQuote" /> to escape <paramref name="parameterGroupSeparator" /> and <paramref name="parameterSeparator" />.</param>
        /// <param name="rightQuote">A Unicode character left paired by the <paramref name="leftQuote" /> to escape <paramref name="parameterGroupSeparator" /> and <paramref name="parameterSeparator" />.</param>
        /// <returns>An enumerator object that can be used to iterate through combinations.</returns>
        /// <exception cref="System.FormatException">Occurs the current reading scope cannot be parsed as a combination expression.</exception>
        public IEnumerator<T[]> GetComboEnumerator<T>(Func<string, T> converter, char parameterGroupSeparator = ';', char parameterSeparator = ',',
            char parameterLeftBracket = '(', char parameterRightBracket = ')', char leftQuote = '[', char rightQuote = ']')
        {
            string[] keywords = null;
            int[,] depths = null;
            int[] counts = null;
            byte[] modes = null;

            if (ReverseReadChar(parameterRightBracket))
            {
                var validPredicates = new string[] { "cube", "point", "square" };
                int predicateIndex;
                if ((predicateIndex = Read(validPredicates, parameterLeftBracket)) != -1)
                {
                    switch (predicateIndex)
                    {
                        case 0:
                            {
                                var parts = GetSplitReaderEnumeratorWithQuotes(parameterGroupSeparator, leftQuote, rightQuote);

                                if (parts.MoveNext()) keywords = _comboEnumKeywordsParse(parts.Current, parameterSeparator);
                                if (parts.MoveNext())
                                {
                                    var exps = parts.Current.GetSplitEnumerator(parameterSeparator, trim: true).ToArray();
                                    depths = _comboEnumDepthParse(exps, parameterSeparator);
                                    if (depths == null) modes = _comboModeParse(exps);
                                }
                                if (parts.MoveNext())
                                {
                                    var exps = parts.Current.GetSplitEnumerator(parameterSeparator, trim: true).ToArray();
                                    counts = _comboEnumCountParse(exps);
                                    if (counts == null) modes = _comboModeParse(exps);
                                }
                                if (parts.MoveNext())
                                {
                                    var exps = parts.Current.GetSplitEnumerator(parameterSeparator, trim: true).ToArray();
                                    modes = _comboModeParse(exps);
                                }
                                break;
                            }
                        case 1:
                        case 2:
                            {
                                var parts = GetSplitReaderEnumeratorWithQuotes(parameterGroupSeparator, leftQuote, rightQuote);
                                if (parts.MoveNext()) keywords = _comboEnumKeywordsParse(parts.Current, parameterSeparator);
                                if (parts.MoveNext())
                                {
                                    var exp = parts.Current.ReadToEndWithTrim();
                                    modes = _comboModeParse(exp).Singleton();
                                }

                                depths = new int[1, 2] { { 1, predicateIndex } };
                                break;
                            }
                        default: throw new FormatException();
                    }

                    if (keywords == null) throw new FormatException();
                    var keywordCount = keywords.Length;
                    if (keywordCount == 1)
                    {
                        if (converter == null) yield return (T[])(object)keywords;
                        else yield return new T[] { converter(keywords[0]) };
                    }
                    else
                    {
                        T[] convertedKeywords;
                        T[] randomizedKeywords;
                        if (converter == null)
                        {
                            if (typeof(T).Equals(typeof(string)))
                            {
                                convertedKeywords = (T[])(object)keywords;
                                randomizedKeywords = convertedKeywords.Copy();
                            }
                            else
                            {
                                convertedKeywords = new T[keywordCount];
                                randomizedKeywords = new T[keywordCount];
                                for (int i = 0; i < keywordCount; ++i)
                                    convertedKeywords[i] = randomizedKeywords[i] = (T)(object)keywords[i];
                            }
                        }
                        else
                        {
                            convertedKeywords = new T[keywordCount];
                            randomizedKeywords = new T[keywordCount];
                            for (int i = 0; i < keywordCount; ++i)
                                convertedKeywords[i] = randomizedKeywords[i] = converter(keywords[i]);
                        }

                        if (depths == null) depths = new int[1, 2] { { 1, keywordCount } };
                        var dlen = depths.GetLength(0);
                        for (int i = 0; i < dlen; ++i)
                        {
                            var startDepth = depths[i, 0];
                            var endDepth = depths[i, 1];
                            int[] currCounts = null;
                            if (counts != null)
                            {
                                currCounts = new int[endDepth - startDepth + 1];
                                currCounts.SetAll<int>(value: (counts.Length == 1 ? counts[0] : counts[i]));
                            }
                            IEnumerator<T[]> e = null;

                            var mode = modes == null ? 0 : (modes.Length == 1 ? modes[0] : modes[i]);
                            switch (mode)
                            {
                                case 0:
                                    {
                                        e = currCounts != null ?
                                            convertedKeywords.GetMultiCombinationEnumerator(startDepth, endDepth, currCounts) :
                                            convertedKeywords.GetMultiCombinationEnumerator(startDepth, endK: endDepth);
                                        break;
                                    }
                                case 1:
                                    {
                                        e = currCounts != null ?
                                            randomizedKeywords.GetMultiCombinationEnumerator(startDepth, endDepth, currCounts) :
                                            randomizedKeywords.GetMultiCombinationEnumerator(startDepth, endK: endDepth);
                                        break;
                                    }
                                case 2:
                                    {
                                        if (i == 0)
                                            randomizedKeywords.Shuffle();
                                        e = currCounts != null ?
                                            randomizedKeywords.GetMultiCombinationEnumerator(startDepth, endDepth, currCounts) :
                                            randomizedKeywords.GetMultiCombinationEnumerator(startDepth, endK: endDepth);
                                        break;
                                    }
                                case 3:
                                    {
                                        randomizedKeywords.Shuffle();
                                        e = currCounts != null ?
                                            randomizedKeywords.GetMultiCombinationEnumerator(startDepth, endDepth, currCounts) :
                                            randomizedKeywords.GetMultiCombinationEnumerator(startDepth, endK: endDepth);
                                        break;
                                    }
                            }

                            while (e.MoveNext()) yield return e.Current;
                        }
                    }

                }
                else
                {
                    if (converter == null) yield return new T[] { (T)(object)ReadToEnd() };
                    else yield return new T[] { converter(ReadToEnd()) };
                }
            }
            else
            {
                if (converter == null) yield return new T[] { (T)(object)ReadToEnd() };
                else yield return new T[] { converter(ReadToEnd()) };
            }
        }
    }
}
