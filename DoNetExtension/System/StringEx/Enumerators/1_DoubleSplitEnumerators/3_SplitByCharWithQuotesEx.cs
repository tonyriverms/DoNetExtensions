using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class StringEx
    {
        static IEnumerator<StringDoubleSplitResult> _innerGetDoubleSplitEnumeratorWithQuotesEx(string str, int startIndex, int endIndex, Func<char, int> primaryPredicate, Func<char, int> secondaryPredicate, char leftQuote, char rightQuote, bool removeEmptyEntires = false, bool trim = false, bool keepQuotes = true)
        {
            var i = startIndex;
            var posList = new List<StringSplitResult>(13);
            char c = '\0';
            int separatorIdx = -1;
            var sb = new StringBuilder();
            while (i <= endIndex)
            {
                var eof = i == endIndex;
                var split = eof || (separatorIdx = primaryPredicate((c = str[i]))) != -1;
                if (split)
                {
                    posList.Add(new StringSplitResult(trim ? sb.ToStringWithTrim() : sb.ToString(), '\0', -1));
                    sb.Clear();
                    yield return eof ?
                        new StringDoubleSplitResult()
                        {
                            SecondarySplits = posList.ToArray(),
                            Separator = '\0',
                            SeparatorIndex = -1
                        } :
                        new StringDoubleSplitResult()
                        {
                            SecondarySplits = posList.ToArray(),
                            Separator = c,
                            SeparatorIndex = separatorIdx
                        };

                    posList.Clear();
                }
                else if ((separatorIdx = secondaryPredicate(c)) != -1)
                {
                    posList.Add(new StringSplitResult(trim ? sb.ToStringWithTrim() : sb.ToString(), c, separatorIdx));
                    sb.Clear();
                }
                else if (c == leftQuote)
                {
                    var matchedQuoteIdx = str.IndexOfNextMatch(leftQuote, rightQuote, i);
                    if (keepQuotes) sb.Append(str, i, matchedQuoteIdx - i + 1);
                    else sb.Append(str, i + 1, matchedQuoteIdx - i);
                }
                ++i;
            }
        }

        static IEnumerator<StringDoubleSplitResult> _innerGetDoubleSplitEnumeratorWithQuotesEx(string str, int startIndex, int endIndex, Func<char, int> primaryPredicate, Func<char, int> secondaryPredicate, char[] leftQuotes, char[] rightQuotes, bool removeEmptyEntires = false, bool trim = false, bool keepQuotes = true)
        {
            var i = startIndex;
            var posList = new List<StringSplitResult>(13);
            char c = '\0';
            int separatorIdx = -1;
            var sb = new StringBuilder();
            while (i <= endIndex)
            {
                var eof = i == endIndex;
                var split = eof || (separatorIdx = primaryPredicate((c = str[i]))) != -1;
                if (split)
                {
                    posList.Add(new StringSplitResult(trim ? sb.ToStringWithTrim() : sb.ToString(), '\0', -1));
                    sb.Clear();
                    yield return eof ?
                        new StringDoubleSplitResult()
                        {
                            SecondarySplits = posList.ToArray(),
                            Separator = '\0',
                            SeparatorIndex = -1
                        } :
                        new StringDoubleSplitResult()
                        {
                            SecondarySplits = posList.ToArray(),
                            Separator = c,
                            SeparatorIndex = separatorIdx
                        };

                    posList.Clear();
                }
                else if ((separatorIdx = secondaryPredicate(c)) != -1)
                {
                    posList.Add(new StringSplitResult(trim ? sb.ToStringWithTrim() : sb.ToString(), c, separatorIdx));
                    sb.Clear();
                }
                else
                {
                    var quoteIdx = leftQuotes.IndexOf(c);
                    if (quoteIdx != -1)
                    {
                        var matchedQuoteIdx = str.IndexOfNextMatch(c, rightQuotes[quoteIdx], i);
                        if (keepQuotes) sb.Append(str, i, matchedQuoteIdx - i + 1);
                        else sb.Append(str, i + 1, matchedQuoteIdx - i);
                    }
                }
                ++i;
            }
        }

        public static IEnumerator<StringDoubleSplitResult> GetDoubleSplitEnumeratorWithQuotesEx(string str, int startIndex, int length, Func<char, int> primaryPredicate, Func<char, int> secondaryPredicate, char leftQuote, char rightQuote, bool removeEmptyEntires = false, bool trim = false, bool keepQuotes = true)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerGetDoubleSplitEnumeratorWithQuotesEx(str, startIndex, endIndex, primaryPredicate, secondaryPredicate, leftQuote, rightQuote, removeEmptyEntires, trim, keepQuotes);
        }

        public static IEnumerator<StringDoubleSplitResult> GetDoubleSplitEnumeratorWithQuotesEx(string str, int startIndex, int length, Func<char, int> primaryPredicate, Func<char, int> secondaryPredicate, char[] leftQuotes, char[] rightQuotes, bool removeEmptyEntires = false, bool trim = false, bool keepQuotes = true)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return _innerGetDoubleSplitEnumeratorWithQuotesEx(str, startIndex, endIndex, primaryPredicate, secondaryPredicate, leftQuotes, rightQuotes, removeEmptyEntires, trim, keepQuotes);
        }
    }
}
