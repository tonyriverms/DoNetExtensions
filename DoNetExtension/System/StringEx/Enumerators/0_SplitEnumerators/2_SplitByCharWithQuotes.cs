using System.Collections.Generic;
using System.Text;
using System_Extension_Library.System.StringEx;

namespace System
{
    public static partial class StringEx
    {
        class _innerSplitWithQuotesEnumerator01 : IEnumerator<string>
        {
            string _str;
            Func<char, bool> _predicate;
            int _startIndex;
            int _endIndex;
            char _leftQuote;
            char _rightQuote;
            bool _removeEmptyEntries;
            bool _trim;
            bool _keepSeparator;
            bool _keepQuotes;
            bool _sameQuote;

            int _i;
            StringBuilder sb;

            internal _innerSplitWithQuotesEnumerator01(string str, Func<char, bool> predicate, int startIndex, int endIndex,
                char leftQuote, char rightQuote, bool removeEmptyEntries, bool trim, bool keepQuotes, bool keepSeparator)
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
                _keepSeparator = keepSeparator;
                sb = new StringBuilder();
            }

            public string Current { get; private set; }

            public void Dispose()
            {
                _str = null;
                Current = null;
                _predicate = null;
            }

            object Collections.IEnumerator.Current
            {
                get { return Current; }
            }

            public bool MoveNext()
            {
                if (_i == -1) return false;
                var eof = _i == _endIndex;
                char c = '\0';

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
                    else if (_predicate(c))
                    {
                        if (_trim)
                        {
                            var trimmedStr = sb.ToStringWithTrim();
                            sb.Clear();
                            if (!_removeEmptyEntries || trimmedStr.Length != 0)
                            {
                                Current = _keepSeparator ? trimmedStr + c : trimmedStr;
                                ++_i;
                                return true;
                            }
                            else ++_i;
                        }
                        else
                        {
                            if (!_removeEmptyEntries || sb.Length != 0)
                            {
                                if (_keepSeparator) sb.Append(c);
                                Current = sb.ToString();
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
                        Current = _keepSeparator ? trimmedStr + c : trimmedStr;
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
                        Current = sb.ToString();
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
                Current = null;
                _i = _startIndex;
            }
        }

        class _innerSplitWithQuotesEnumerator02 : IEnumerator<string>
        {
            string _str;
            char _separator;
            int _startIndex;
            int _endIndex;
            char _leftQuote;
            char _rightQuote;
            bool _removeEmptyEntries;
            bool _trim;
            bool _keepSeparator;
            bool _keepQuotes;
            bool _sameQuote;

            int _i;
            StringBuilder sb;

            internal _innerSplitWithQuotesEnumerator02(string str, char separator, int startIndex, int endIndex,
                char leftQuote, char rightQuote, bool removeEmptyEntries, bool trim, bool keepQuotes, bool keepSeparator)
            {
                _str = str;
                _separator = separator;
                _i = _startIndex = startIndex;
                _endIndex = endIndex;
                _removeEmptyEntries = removeEmptyEntries;
                _trim = trim;
                _leftQuote = leftQuote;
                _rightQuote = rightQuote;
                _sameQuote = leftQuote == rightQuote;
                _keepQuotes = keepQuotes;
                _keepSeparator = keepSeparator;
                sb = new StringBuilder();
            }

            public string Current { get; private set; }

            public void Dispose()
            {
                _str = null;
                Current = null;
            }

            object Collections.IEnumerator.Current
            {
                get { return Current; }
            }

            public bool MoveNext()
            {
                if (_i == -1) return false;
                var eof = _i == _endIndex;
                char c = '\0';

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
                    else if (c == _separator)
                    {
                        if (_trim)
                        {
                            var trimmedStr = sb.ToStringWithTrim();
                            sb.Clear();
                            if (!_removeEmptyEntries || trimmedStr.Length != 0)
                            {
                                Current = _keepSeparator ? trimmedStr + c : trimmedStr;
                                ++_i;
                                return true;
                            }
                            else ++_i;
                        }
                        else
                        {
                            if (!_removeEmptyEntries || sb.Length != 0)
                            {
                                if (_keepSeparator) sb.Append(c);
                                Current = sb.ToString();
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
                        Current = _keepSeparator ? trimmedStr + c : trimmedStr;
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
                        Current = sb.ToString();
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
                Current = null;
                _i = _startIndex;
            }
        }

        class _innerSplitWithQuotesEnumerator03 : IEnumerator<string>
        {
            string _str;
            char[] _separators;
            int _startIndex;
            int _endIndex;
            char _leftQuote;
            char _rightQuote;
            bool _removeEmptyEntries;
            bool _trim;
            bool _keepSeparator;
            bool _keepQuotes;
            bool _sameQuote;

            int _i;
            string _curr;
            StringBuilder sb;

            internal _innerSplitWithQuotesEnumerator03(string str, char[] separators, int startIndex, int endIndex,
                char leftQuote, char rightQuote, bool removeEmptyEntries, bool trim, bool keepQuotes, bool keepSeparator)
            {
                _str = str;
                _separators = separators;
                _i = _startIndex = startIndex;
                _endIndex = endIndex;
                _removeEmptyEntries = removeEmptyEntries;
                _trim = trim;
                _leftQuote = leftQuote;
                _rightQuote = rightQuote;
                _sameQuote = leftQuote == rightQuote;
                _keepQuotes = keepQuotes;
                _keepSeparator = keepSeparator;
                sb = new StringBuilder();
            }

            public string Current
            {
                get { return _curr; }
            }

            public void Dispose()
            {
                _str = null;
                _curr = null;
                _separators = null;
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
                    else if (c.In(_separators))
                    {
                        if (_trim)
                        {
                            var trimmedStr = sb.ToStringWithTrim();
                            sb.Clear();
                            if (!_removeEmptyEntries || trimmedStr.Length != 0)
                            {
                                _curr = _keepSeparator ? trimmedStr + c : trimmedStr;
                                ++_i;
                                return true;
                            }
                            else ++_i;
                        }
                        else
                        {
                            if (!_removeEmptyEntries || sb.Length != 0)
                            {
                                if (_keepSeparator) sb.Append(c);
                                _curr = sb.ToString();
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
                        _curr = _keepSeparator ? trimmedStr + c : trimmedStr;
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
                        _curr = sb.ToString();
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

        class _innerSplitWithQuotesEnumerator04 : IEnumerator<string>
        {
            string _str;
            Func<char, bool> _predicate;
            int _startIndex;
            int _endIndex;
            char[] _leftQuotes;
            char[] _rightQuotes;
            bool _removeEmptyEntries;
            bool _trim;
            bool _keepSeparator;
            bool _keepQuotes;

            int _i;
            string _curr;
            StringBuilder sb;

            internal _innerSplitWithQuotesEnumerator04(string str, Func<char, bool> predicate, int startIndex, int endIndex,
                char[] leftQuotes, char[] rightQuotes, bool removeEmptyEntries, bool trim, bool keepQuotes, bool keepSeparator)
            {
                _str = str;
                _predicate = predicate;
                _i = _startIndex = startIndex;
                _endIndex = endIndex;
                _removeEmptyEntries = removeEmptyEntries;
                _trim = trim;
                _leftQuotes = leftQuotes;
                _rightQuotes = rightQuotes;
                _keepQuotes = keepQuotes;
                _keepSeparator = keepSeparator;
                sb = new StringBuilder();
            }

            public string Current
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
                int quoteIndex;
                while (!eof)
                {
                    c = _str[_i];
                    quoteIndex = _leftQuotes.IndexOf(c);
                    if (quoteIndex != -1)
                    {
                        if (_keepQuotes) sb.Append(c);
                        var stackNum = 1;
                        var leftQuote = c;
                        var rightQuote = _rightQuotes[quoteIndex];
                        var sameQuote = leftQuote == rightQuote;
                        while (true)
                        {
                            ++_i;
                            if (_i == _endIndex) throw new FormatException(StringExResources.ERR_Quotes_QuoteMismatch);
                            c = _str[_i];

                            if (c == leftQuote && !sameQuote)
                            {
                                sb.Append(leftQuote);
                                ++stackNum;
                            }
                            else if (c == rightQuote)
                            {
                                --stackNum;
                                if (stackNum == 0 || sameQuote)
                                {
                                    if (_keepQuotes) sb.Append(rightQuote);
                                    break;
                                }
                                sb.Append(rightQuote);
                            }
                            else sb.Append(c);
                        }
                        ++_i;
                    }
                    else if (_predicate(c))
                    {
                        if (_trim)
                        {
                            var trimmedStr = sb.ToStringWithTrim();
                            sb.Clear();
                            if (!_removeEmptyEntries || trimmedStr.Length != 0)
                            {
                                _curr = _keepSeparator ? trimmedStr + c : trimmedStr;
                                ++_i;
                                return true;
                            }
                            else ++_i;
                        }
                        else
                        {
                            if (!_removeEmptyEntries || sb.Length != 0)
                            {
                                if (_keepSeparator) sb.Append(c);
                                _curr = sb.ToString();
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
                        _curr = _keepSeparator ? trimmedStr + c : trimmedStr;
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
                        _curr = sb.ToString();
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

        class _innerSplitWithQuotesEnumerator05 : IEnumerator<string>
        {
            string _str;
            char _separator;
            int _startIndex;
            int _endIndex;
            char[] _leftQuotes;
            char[] _rightQuotes;
            bool _removeEmptyEntries;
            bool _trim;
            bool _keepSeparator;
            bool _keepQuotes;

            int _i;
            StringBuilder sb;

            internal _innerSplitWithQuotesEnumerator05(string str, char separator, int startIndex, int endIndex,
                char[] leftQuotes, char[] rightQuotes, bool removeEmptyEntries, bool trim, bool keepQuotes, bool keepSeparator)
            {
                _str = str;
                _separator = separator;
                _i = _startIndex = startIndex;
                _endIndex = endIndex;
                _removeEmptyEntries = removeEmptyEntries;
                _trim = trim;
                _leftQuotes = leftQuotes;
                _rightQuotes = rightQuotes;
                _keepQuotes = keepQuotes;
                _keepSeparator = keepSeparator;
                sb = new StringBuilder();
            }

            public string Current { get; private set; }

            public void Dispose()
            {
                _str = null;
                Current = null;
            }

            object Collections.IEnumerator.Current => Current;

            public bool MoveNext()
            {
                if (_i == -1) return false;
                var eof = _i == _endIndex;
                char c = '\0';
                int quoteIndex;
                while (!eof)
                {
                    c = _str[_i];
                    quoteIndex = _leftQuotes.IndexOf(c);
                    if (quoteIndex != -1)
                    {
                        if (_keepQuotes) sb.Append(c);
                        var stackNum = 1;
                        var leftQuote = c;
                        var rightQuote = _rightQuotes[quoteIndex];
                        var sameQuote = leftQuote == rightQuote;
                        while (true)
                        {
                            ++_i;
                            if (_i == _endIndex) throw new FormatException(StringExResources.ERR_Quotes_QuoteMismatch);
                            c = _str[_i];

                            if (c == leftQuote && !sameQuote)
                            {
                                sb.Append(leftQuote);
                                ++stackNum;
                            }
                            else if (c == rightQuote)
                            {
                                --stackNum;
                                if (stackNum == 0 || sameQuote)
                                {
                                    if (_keepQuotes) sb.Append(rightQuote);
                                    break;
                                }
                                sb.Append(rightQuote);
                            }
                            else sb.Append(c);
                        }
                        ++_i;
                    }
                    else if (c == _separator)
                    {
                        if (_trim)
                        {
                            var trimmedStr = sb.ToStringWithTrim();
                            sb.Clear();
                            if (!_removeEmptyEntries || trimmedStr.Length != 0)
                            {
                                Current = _keepSeparator ? trimmedStr + c : trimmedStr;
                                ++_i;
                                return true;
                            }
                            else ++_i;
                        }
                        else
                        {
                            if (!_removeEmptyEntries || sb.Length != 0)
                            {
                                if (_keepSeparator) sb.Append(c);
                                Current = sb.ToString();
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
                        Current = _keepSeparator ? trimmedStr + c : trimmedStr;
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
                        Current = sb.ToString();
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
                Current = null;
                _i = _startIndex;
            }
        }

        class _innerSplitWithQuotesEnumerator06 : IEnumerator<string>
        {
            string _str;
            char[] _separators;
            int _startIndex;
            int _endIndex;
            char[] _leftQuotes;
            char[] _rightQuotes;
            bool _removeEmptyEntries;
            bool _trim;
            bool _keepSeparator;
            bool _keepQuotes;

            int _i;
            string _curr;
            StringBuilder sb;

            internal _innerSplitWithQuotesEnumerator06(string str, char[] separators, int startIndex, int endIndex,
                char[] leftQuotes, char[] rightQuotes, bool removeEmptyEntries, bool trim, bool keepQuotes, bool keepSeparator)
            {
                _str = str;
                _separators = separators;
                _i = _startIndex = startIndex;
                _endIndex = endIndex;
                _removeEmptyEntries = removeEmptyEntries;
                _trim = trim;
                _leftQuotes = leftQuotes;
                _rightQuotes = rightQuotes;
                _keepQuotes = keepQuotes;
                _keepSeparator = keepSeparator;
                sb = new StringBuilder();
            }

            public string Current
            {
                get { return _curr; }
            }

            public void Dispose()
            {
                _str = null;
                _curr = null;
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
                int quoteIndex;
                while (!eof)
                {
                    c = _str[_i];
                    quoteIndex = _leftQuotes.IndexOf(c);
                    if (quoteIndex != -1)
                    {
                        if (_keepQuotes) sb.Append(c);
                        var stackNum = 1;
                        var leftQuote = c;
                        var rightQuote = _rightQuotes[quoteIndex];
                        var sameQuote = leftQuote == rightQuote;
                        while (true)
                        {
                            ++_i;
                            if (_i == _endIndex) throw new FormatException(StringExResources.ERR_Quotes_QuoteMismatch);
                            c = _str[_i];

                            if (c == leftQuote && !sameQuote)
                            {
                                sb.Append(leftQuote);
                                ++stackNum;
                            }
                            else if (c == rightQuote)
                            {
                                --stackNum;
                                if (stackNum == 0 || sameQuote)
                                {
                                    if (_keepQuotes) sb.Append(rightQuote);
                                    break;
                                }
                                sb.Append(rightQuote);
                            }
                            else sb.Append(c);
                        }
                        ++_i;
                    }
                    else if (c.In(_separators))
                    {
                        if (_trim)
                        {
                            var trimmedStr = sb.ToStringWithTrim();
                            sb.Clear();
                            if (!_removeEmptyEntries || trimmedStr.Length != 0)
                            {
                                _curr = _keepSeparator ? trimmedStr + c : trimmedStr;
                                ++_i;
                                return true;
                            }
                            else ++_i;
                        }
                        else
                        {
                            if (!_removeEmptyEntries || sb.Length != 0)
                            {
                                if (_keepSeparator) sb.Append(c);
                                _curr = sb.ToString();
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
                        _curr = _keepSeparator ? trimmedStr + c : trimmedStr;
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
                        _curr = sb.ToString();
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

        /// <summary>
        /// Gets an object that can iterate through substrings in this string instance (or a part of this string according to <paramref name="startIndex"/> and <paramref name="length"/>)
        /// that are delimited by Unicode characters outside quotes and satisfying the specified predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character of the current string. Any character satisfying this predicate will be used as a separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="leftQuote">The left quote paired by <paramref name="rightQuote"/> to escape separators.</param>
        /// <param name="rightQuote">The right quote paired by <paramref name="leftQuote"/> to escape separators.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepQuotes"><c>true</c> if the quotes should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance (or a part of the current string instance)
        /// that are delimited by Unicode characters outside quotes and satisfying the specified predicate.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static IEnumerator<string> GetSplitEnumeratorWithQuotes(this string str, Func<char, bool> predicate, int startIndex, int length,
            char leftQuote = '{', char rightQuote = '}', bool removeEmptyEntries = false, bool trim = false, bool keepQuotes = true, bool keepSeparator = false)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return new _innerSplitWithQuotesEnumerator01(str, predicate, startIndex, endIndex, leftQuote, rightQuote, removeEmptyEntries, trim, keepQuotes, keepSeparator);
        }

        /// <summary>
        /// Gets an object that can iterate through substrings in this string instance (or a part of this string according to <paramref name="startIndex"/>)
        /// that are delimited by Unicode characters outside quotes and satisfying the specified predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character of the current string. Any character satisfying this predicate will be used as a separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="leftQuote">The left quote paired by <paramref name="rightQuote" /> to escape separators.</param>
        /// <param name="rightQuote">The right quote paired by <paramref name="leftQuote" /> to escape separators.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepQuotes"><c>true</c> if the quotes should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance (or a part of the current string instance)
        /// that are delimited by Unicode characters outside quotes and satisfying the specified predicate.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static IEnumerator<string> GetSplitEnumeratorWithQuotes(this string str, Func<char, bool> predicate, int startIndex,
            char leftQuote = '{', char rightQuote = '}', bool removeEmptyEntries = false, bool trim = false, bool keepQuotes = true, bool keepSeparator = false)
        {
            ExceptionHelper.NonNegativeArgumentRequired("startIndex", startIndex);
            return new _innerSplitWithQuotesEnumerator01(str, predicate, startIndex, str.Length, leftQuote, rightQuote, removeEmptyEntries, trim, keepQuotes, keepSeparator);
        }

        /// <summary>
        /// Gets an object that can iterate through substrings in this string instance
        /// that are delimited by Unicode characters outside quotes and satisfying the specified predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character of the current string. Any character that passes this test will be used as a separator.</param>
        /// <param name="leftQuote">The left quote paired by <paramref name="rightQuote" /> to escape separators.</param>
        /// <param name="rightQuote">The right quote paired by <paramref name="leftQuote" /> to escape separators.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepQuotes"><c>true</c> if the quotes should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance that are delimited by Unicode characters outside quotes and satisfying the specified predicate.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static IEnumerator<string> GetSplitEnumeratorWithQuotes(this string str, Func<char, bool> predicate,
            char leftQuote = '{', char rightQuote = '}', bool removeEmptyEntries = false, bool trim = false, bool keepQuotes = true, bool keepSeparator = false)
        {
            return new _innerSplitWithQuotesEnumerator01(str, predicate, 0, str.Length, leftQuote, rightQuote, removeEmptyEntries, trim, keepQuotes, keepSeparator);
        }

        /// <summary>
        /// Gets an object that can iterate through substrings in this string instance (or a part of this string)
        /// that are delimited by Unicode separators outside quotes.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separator">The separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="leftQuote">The left quote paired by <paramref name="rightQuote"/> to escape separators.</param>
        /// <param name="rightQuote">The right quote paired by <paramref name="leftQuote"/> to escape separators.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepQuotes"><c>true</c> if the quotes should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance (or a part of the current string instance)
        /// that are delimited by Unicode characters outside quotes.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static IEnumerator<string> GetSplitEnumeratorWithQuotes(this string str, char separator, int startIndex, int length, char leftQuote = '{', char rightQuote = '}',
            bool removeEmptyEntries = false, bool trim = false, bool keepQuotes = true, bool keepSeparator = false)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return new _innerSplitWithQuotesEnumerator02(str, separator, startIndex, endIndex, leftQuote, rightQuote, removeEmptyEntries, trim, keepQuotes, keepSeparator);
        }

        /// <summary>
        /// Gets an object that can iterate through substrings in this string instance (or a part of this string)
        /// that are delimited by Unicode separators outside quotes.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separator">The separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="leftQuote">The left quote paired by <paramref name="rightQuote" /> to escape separators.</param>
        /// <param name="rightQuote">The right quote paired by <paramref name="leftQuote" /> to escape separators.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="keepQuotes"><c>true</c> if the quotes should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance (or a part of the current string instance)
        /// that are delimited by Unicode characters outside quotes.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static IEnumerator<string> GetSplitEnumeratorWithQuotes(this string str, char separator, int startIndex, char leftQuote = '{', char rightQuote = '}',
            bool removeEmptyEntries = false, bool trim = false, bool keepQuotes = true, bool keepSeparator = false)
        {
            ExceptionHelper.NonNegativeArgumentRequired("startIndex", startIndex);
            return new _innerSplitWithQuotesEnumerator02(str, separator, startIndex, str.Length, leftQuote, rightQuote, removeEmptyEntries, trim, keepQuotes, keepSeparator);
        }

        /// <summary>
        /// Gets an object that can iterate through substrings in this string instance that are delimited by Unicode separators outside quotes.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separator">The separator.</param>
        /// <param name="leftQuote">The left quote paired by <paramref name="rightQuote" /> to escape separators.</param>
        /// <param name="rightQuote">The right quote paired by <paramref name="leftQuote" /> to escape separators.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="keepQuotes"><c>true</c> if the quotes should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance that are delimited by Unicode characters outside quotes.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static IEnumerator<string> GetSplitEnumeratorWithQuotes(this string str, char separator, char leftQuote = '{', char rightQuote = '}',
            bool removeEmptyEntries = false, bool trim = false, bool keepQuotes = true, bool keepSeparator = false)
        {
            return new _innerSplitWithQuotesEnumerator02(str, separator, 0, str.Length, leftQuote, rightQuote, removeEmptyEntries, trim, keepQuotes, keepSeparator);
        }

        /// <summary>
        /// Gets an object that can iterate through substrings in this string instance (or a part of this string)
        /// that are delimited by Unicode separators outside quotes.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separators">Any character in this array will be used as a separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="leftQuote">The left quote paired by <paramref name="rightQuote"/> to escape separators.</param>
        /// <param name="rightQuote">The right quote paired by <paramref name="leftQuote"/> to escape separators.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepQuotes"><c>true</c> if the quotes should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance (or a part of the current string instance)
        /// that are delimited by Unicode characters outside quotes.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static IEnumerator<string> GetSplitEnumeratorWithQuotes(this string str, char[] separators, int startIndex, int length, char leftQuote = '{', char rightQuote = '}', bool removeEmptyEntries = true, bool trim = false, bool keepQuotes = true, bool keepSeparator = false)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return new _innerSplitWithQuotesEnumerator03(str, separators, startIndex, endIndex, leftQuote, rightQuote, removeEmptyEntries, trim, keepQuotes, keepSeparator);
        }

        /// <summary>
        /// Gets an object that can iterate through substrings in this string instance (or a part of this string according to <paramref name="startIndex"/>)
        /// that are delimited by Unicode separators outside quotes.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separators">Any character in this array will be used as a separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="leftQuote">The left quote paired by <paramref name="rightQuote" /> to escape separators.</param>
        /// <param name="rightQuote">The right quote paired by <paramref name="leftQuote" /> to escape separators.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepQuotes"><c>true</c> if the quotes should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance (or a part of the current string instance)
        /// that are delimited by Unicode characters outside quotes.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static IEnumerator<string> GetSplitEnumeratorWithQuotes(this string str, char[] separators, int startIndex, char leftQuote = '{', char rightQuote = '}',
            bool removeEmptyEntries = false, bool trim = false, bool keepQuotes = true, bool keepSeparator = false)
        {
            ExceptionHelper.NonNegativeArgumentRequired("startIndex", startIndex);
            return new _innerSplitWithQuotesEnumerator03(str, separators, startIndex, str.Length, leftQuote, rightQuote, removeEmptyEntries, trim, keepQuotes, keepSeparator);
        }

        /// <summary>
        /// Gets an object that can iterate through substrings in this string instance (or a part of this string according to <paramref name="startIndex"/>)
        /// that are delimited by Unicode separators outside quotes.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separators">Any character in this array will be used as a separator.</param>
        /// <param name="leftQuote">The left quote paired by <paramref name="rightQuote" /> to escape separators.</param>
        /// <param name="rightQuote">The right quote paired by <paramref name="leftQuote" /> to escape separators.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepQuotes"><c>true</c> if the quotes should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance (or a part of the current string instance)
        /// that are delimited by Unicode characters outside quotes.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static IEnumerator<string> GetSplitEnumeratorWithQuotes(this string str, char[] separators, char leftQuote = '{', char rightQuote = '}',
            bool removeEmptyEntries = false, bool trim = false, bool keepQuotes = true, bool keepSeparator = false)
        {
            return new _innerSplitWithQuotesEnumerator03(str, separators, 0, str.Length, leftQuote, rightQuote, removeEmptyEntries, trim, keepQuotes, keepSeparator);
        }

        /// <summary>
        /// Gets an object that can iterate through substrings in this string instance (or a part of this string according to <paramref name="startIndex"/> and <paramref name="length"/>)
        /// that are delimited by Unicode characters outside quotes and satisfying the specified predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character of the current string. Any character satisfying this predicate will be used as a separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="leftQuotes">Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.</param>
        /// <param name="rightQuotes">Specifies an array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepQuotes"><c>true</c> if the quotes should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance (or a part of the current string instance)
        /// that are delimited by Unicode characters outside quotes and satisfying the specified predicate.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static IEnumerator<string> GetSplitEnumeratorWithQuotes(this string str, Func<char, bool> predicate, int startIndex, int length,
            char[] leftQuotes, char[] rightQuotes, bool removeEmptyEntries = false, bool trim = false, bool keepQuotes = true, bool keepSeparator = false)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return new _innerSplitWithQuotesEnumerator04(str, predicate, startIndex, endIndex, leftQuotes, rightQuotes, removeEmptyEntries, trim, keepQuotes, keepSeparator);
        }

        /// <summary>
        /// Gets an object that can iterate through substrings in this string instance (or a part of this string according to <paramref name="startIndex"/>)
        /// that are delimited by Unicode characters outside quotes and satisfying the specified predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character of the current string. Any character satisfying this predicate will be used as a separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="leftQuotes">Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.</param>
        /// <param name="rightQuotes">Specifies an array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepQuotes"><c>true</c> if the quotes should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance (or a part of the current string instance)
        /// that are delimited by Unicode characters outside quotes and satisfying the specified predicate.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static IEnumerator<string> GetSplitEnumeratorWithQuotes(this string str, Func<char, bool> predicate, int startIndex,
             char[] leftQuotes, char[] rightQuotes, bool removeEmptyEntries = false, bool trim = false, bool keepQuotes = true, bool keepSeparator = false)
        {
            ExceptionHelper.NonNegativeArgumentRequired("startIndex", startIndex);
            return new _innerSplitWithQuotesEnumerator04(str, predicate, startIndex, str.Length, leftQuotes, rightQuotes, removeEmptyEntries, trim, keepQuotes, keepSeparator);
        }

        /// <summary>
        /// Gets an object that can iterate through substrings in this string instance
        /// that are delimited by Unicode characters outside quotes and satisfying the specified predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character of the current string. Any character that passes this test will be used as a separator.</param>
        /// <param name="leftQuotes">Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.</param>
        /// <param name="rightQuotes">Specifies an array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepQuotes"><c>true</c> if the quotes should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance that are delimited by Unicode characters outside quotes and satisfying the specified predicate.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static IEnumerator<string> GetSplitEnumeratorWithQuotes(this string str, Func<char, bool> predicate,
            char[] leftQuotes, char[] rightQuotes, bool removeEmptyEntries = false, bool trim = false, bool keepQuotes = true, bool keepSeparator = false)
        {
            return new _innerSplitWithQuotesEnumerator04(str, predicate, 0, str.Length, leftQuotes, rightQuotes, removeEmptyEntries, trim, keepQuotes, keepSeparator);
        }

        /// <summary>
        /// Gets an object that can iterate through substrings in this string instance (or a part of this string)
        /// that are delimited by Unicode separators outside quotes.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separator">The separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="leftQuotes">Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.</param>
        /// <param name="rightQuotes">Specifies an array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepQuotes"><c>true</c> if the quotes should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance (or a part of the current string instance)
        /// that are delimited by Unicode characters outside quotes.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static IEnumerator<string> GetSplitEnumeratorWithQuotes(this string str, char separator, int startIndex, int length, char[] leftQuotes, char[] rightQuotes,
            bool removeEmptyEntries = false, bool trim = false, bool keepQuotes = true, bool keepSeparator = false)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return new _innerSplitWithQuotesEnumerator05(str, separator, startIndex, endIndex, leftQuotes, rightQuotes, removeEmptyEntries, trim, keepQuotes, keepSeparator);
        }

        /// <summary>
        /// Gets an object that can iterate through substrings in this string instance (or a part of this string)
        /// that are delimited by Unicode separators outside quotes.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separator">The separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="leftQuotes">Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.</param>
        /// <param name="rightQuotes">Specifies an array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="keepQuotes"><c>true</c> if the quotes should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance (or a part of the current string instance)
        /// that are delimited by Unicode characters outside quotes.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static IEnumerator<string> GetSplitEnumeratorWithQuotes(this string str, char separator, int startIndex, char[] leftQuotes, char[] rightQuotes,
            bool removeEmptyEntries = false, bool trim = false, bool keepQuotes = true, bool keepSeparator = false)
        {
            ExceptionHelper.NonNegativeArgumentRequired("startIndex", startIndex);
            return new _innerSplitWithQuotesEnumerator05(str, separator, startIndex, str.Length, leftQuotes, rightQuotes, removeEmptyEntries, trim, keepQuotes, keepSeparator);
        }

        /// <summary>
        /// Gets an object that can iterate through substrings in this string instance that are delimited by Unicode separators outside quotes.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separator">The separator.</param>
        /// <param name="leftQuotes">Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.</param>
        /// <param name="rightQuotes">Specifies an array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="keepQuotes"><c>true</c> if the quotes should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance that are delimited by Unicode characters outside quotes.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static IEnumerator<string> GetSplitEnumeratorWithQuotes(this string str, char separator, char[] leftQuotes, char[] rightQuotes,
            bool removeEmptyEntries = false, bool trim = false, bool keepQuotes = true, bool keepSeparator = false)
        {
            return new _innerSplitWithQuotesEnumerator05(str, separator, 0, str.Length, leftQuotes, rightQuotes, removeEmptyEntries, trim, keepQuotes, keepSeparator);
        }

        /// <summary>
        /// Gets an object that can iterate through substrings in this string instance (or a part of this string)
        /// that are delimited by Unicode separators outside quotes.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separators">Any character in this array will be used as a separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="leftQuotes">Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.</param>
        /// <param name="rightQuotes">Specifies an array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepQuotes"><c>true</c> if the quotes should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance (or a part of the current string instance)
        /// that are delimited by Unicode characters outside quotes.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static IEnumerator<string> GetSplitEnumeratorWithQuotes(this string str, char[] separators, int startIndex, int length, char[] leftQuotes, char[] rightQuotes, bool removeEmptyEntries = true, bool trim = false, bool keepQuotes = true, bool keepSeparator = false)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return new _innerSplitWithQuotesEnumerator06(str, separators, startIndex, endIndex, leftQuotes, rightQuotes, removeEmptyEntries, trim, keepQuotes, keepSeparator);
        }

        /// <summary>
        /// Gets an object that can iterate through substrings in this string instance (or a part of this string according to <paramref name="startIndex"/>)
        /// that are delimited by Unicode separators outside quotes.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separators">Any character in this array will be used as a separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="leftQuotes">Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.</param>
        /// <param name="rightQuotes">Specifies an array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepQuotes"><c>true</c> if the quotes should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance (or a part of the current string instance)
        /// that are delimited by Unicode characters outside quotes.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static IEnumerator<string> GetSplitEnumeratorWithQuotes(this string str, char[] separators, int startIndex, char[] leftQuotes, char[] rightQuotes,
            bool removeEmptyEntries = false, bool trim = false, bool keepQuotes = true, bool keepSeparator = false)
        {
            ExceptionHelper.NonNegativeArgumentRequired("startIndex", startIndex);
            return new _innerSplitWithQuotesEnumerator06(str, separators, startIndex, str.Length, leftQuotes, rightQuotes, removeEmptyEntries, trim, keepQuotes, keepSeparator);
        }

        /// <summary>
        /// Gets an object that can iterate through substrings in this string instance (or a part of this string according to <paramref name="startIndex"/>)
        /// that are delimited by Unicode separators outside quotes.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separators">Any character in this array will be used as a separator.</param>
        /// <param name="leftQuotes">Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.</param>
        /// <param name="rightQuotes">Specifies an array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be removed from the returned substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepQuotes"><c>true</c> if the quotes should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance (or a part of the current string instance)
        /// that are delimited by Unicode characters outside quotes.
        /// </returns>
        /// <exception cref="System.FormatException">Occurs when there is a quote mismatch in the string instance.</exception>
        public static IEnumerator<string> GetSplitEnumeratorWithQuotes(this string str, char[] separators, char[] leftQuotes, char[] rightQuotes,
            bool removeEmptyEntries = false, bool trim = false, bool keepQuotes = true, bool keepSeparator = false)
        {
            return new _innerSplitWithQuotesEnumerator06(str, separators, 0, str.Length, leftQuotes, rightQuotes, removeEmptyEntries, trim, keepQuotes, keepSeparator);
        }
    }
}
