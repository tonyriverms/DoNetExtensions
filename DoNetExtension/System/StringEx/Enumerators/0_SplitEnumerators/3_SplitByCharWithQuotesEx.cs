using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_Extension_Library.System;
using System_Extension_Library.System.StringEx;

namespace System
{
    public static partial class StringEx
    {
        class _innerSplitWithQuotesEnumeratorEx01 : IEnumerator<StringSplitResult>
        {
            string _str;
            Func<char, int> _predicate;
            int _startIndex;
            int _endIndex;
            char _leftQuote;
            char _rightQuote;
            bool _removeEmptyEntries;
            bool _trim;
            bool _keepQuotes;
            bool _sameQuote;

            int _i;
            StringSplitResult _curr;
            StringBuilder sb;

            internal _innerSplitWithQuotesEnumeratorEx01(string str, Func<char, int> predicate, int startIndex, int endIndex,
                char leftQuote, char rightQuote, bool removeEmptyEntries, bool trim, bool keepQuotes)
            {
                _str = str;
                _predicate = predicate;
                _i = _startIndex = startIndex;
                _endIndex = endIndex;
                _removeEmptyEntries = removeEmptyEntries;
                _trim = trim;
                _leftQuote = leftQuote;
                _rightQuote = rightQuote;
                _sameQuote = leftQuote == rightQuote;
                _keepQuotes = keepQuotes;
                sb = new StringBuilder();
            }

            public StringSplitResult Current
            {
                get { return _curr; }
            }

            public void Dispose()
            {
                _str = null;
                _curr = null;
                _predicate = null;
            }

            object Collections.IEnumerator.Current
            {
                get { return _curr; }
            }

            public bool MoveNext()
            {
                if (_i == -1) return false;
                var eof = _i == _endIndex;
                char c = '\0';
                int separatorIndex = -1;
                while (!eof)
                {
                    c = _str[_i];

                    if (c == _leftQuote)
                    {
                        if (_keepQuotes) sb.Append(_leftQuote);
                        var stackNum = 1;

                        while (true)
                        {
                            ++_i;
                            if (_i == _endIndex) throw new FormatException(StringExResources.ERR_Quotes_QuoteMismatch);
                            c = _str[_i];

                            if (c == _leftQuote && !_sameQuote)
                            {
                                sb.Append(_leftQuote);
                                ++stackNum;
                            }
                            else if (c == _rightQuote)
                            {
                                --stackNum;
                                if (stackNum == 0 || _sameQuote)
                                {
                                    if (_keepQuotes) sb.Append(_rightQuote);
                                    break;
                                }
                                sb.Append(_rightQuote);
                            }
                            else sb.Append(c);
                        }
                        ++_i;
                    }
                    else if ((separatorIndex = _predicate(c)) != -1)
                    {
                        if (_trim)
                        {
                            var trimmedStr = sb.ToStringWithTrim();
                            sb.Clear();
                            if (!_removeEmptyEntries || trimmedStr.Length != 0)
                            {
                                _curr = new StringSplitResult(trimmedStr, c, separatorIndex);
                                ++_i;
                                return true;
                            }
                            else ++_i;
                        }
                        else
                        {
                            if (!_removeEmptyEntries || sb.Length != 0)
                            {
                                _curr = new StringSplitResult(sb.ToString(), c, separatorIndex);
                                sb.Clear();
                                ++_i;
                                return true;
                            }
                            else ++_i;
                        }
                    }
                    else
                    {
                        sb.Append(c);
                        ++_i;
                    }

                    eof = _i == _endIndex;
                }

                if (_trim)
                {
                    var trimmedStr = sb.ToStringWithTrim();
                    sb.Clear();
                    if (!_removeEmptyEntries || trimmedStr.Length != 0)
                    {
                        _curr = new StringSplitResult(trimmedStr, '\0', -1);
                        _i = -1;
                        return true;
                    }
                    else
                    {
                        _i = -1;
                        return false;
                    }
                }
                else
                {
                    if (!_removeEmptyEntries || sb.Length != 0)
                    {
                        _curr = new StringSplitResult(sb.ToString(), '\0', -1);
                        sb.Clear();
                        _i = -1;
                        return true;
                    }
                    else
                    {
                        _i = -1;
                        return false;
                    }
                }

            }

            public void Reset()
            {
                _curr = null;
                _i = _startIndex;
            }
        }

        public static IEnumerator<StringSplitResult> GetSplitEnumeratorWithQuotesEx(this string str, Func<char, int> predicate, int startIndex, int length,
            char leftQuote = '{', char rightQuote = '}', bool removeEmptyEntries = false, bool trim = false, bool keepQuotes = true)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return new _innerSplitWithQuotesEnumeratorEx01(str, predicate, startIndex, endIndex, leftQuote, rightQuote, removeEmptyEntries, trim, keepQuotes);
        }

        public static IEnumerator<StringSplitResult> GetSplitEnumeratorWithQuotesEx(this string str, Func<char, int> predicate, int startIndex,
            char leftQuote = '{', char rightQuote = '}', bool removeEmptyEntries = false, bool trim = false, bool keepQuotes = true, bool keepSeparator = false)
        {
            ExceptionHelper.NonNegativeArgumentRequired("startIndex", startIndex);
            return new _innerSplitWithQuotesEnumeratorEx01(str, predicate, startIndex, str.Length, leftQuote, rightQuote, removeEmptyEntries, trim, keepQuotes);
        }

        public static IEnumerator<StringSplitResult> GetSplitEnumeratorWithQuotesEx(this string str, Func<char, int> predicate,
            char leftQuote = '{', char rightQuote = '}', bool removeEmptyEntries = false, bool trim = false, bool keepQuotes = true, bool keepSeparator = false)
        {
            return new _innerSplitWithQuotesEnumeratorEx01(str, predicate, 0, str.Length, leftQuote, rightQuote, removeEmptyEntries, trim, keepQuotes);
        }

        public static IEnumerator<StringSplitResult> GetSplitEnumeratorWithQuotesEx(this string str, char[] separators, int startIndex, int length, char leftQuote = '{', char rightQuote = '}',
            bool removeEmptyEntries = true, bool keepQuotes = true, bool keepSeparator = false)
        {
            return GetSplitEnumeratorWithQuotesEx(str, c => separators.IndexOf(c), startIndex, length, leftQuote, rightQuote, removeEmptyEntries, keepQuotes, keepSeparator);
        }

        public static IEnumerator<StringSplitResult> GetSplitEnumeratorWithQuotesEx(this string str, char[] separators, int startIndex = 0, char leftQuote = '{', char rightQuote = '}',
            bool removeEmptyEntries = true, bool keepQuotes = true, bool keepSeparator = false)
        {
            return GetSplitEnumeratorWithQuotesEx(str, c => separators.IndexOf(c), startIndex, str.Length - startIndex, leftQuote, rightQuote, removeEmptyEntries, keepQuotes, keepSeparator);
        }
    }
}
