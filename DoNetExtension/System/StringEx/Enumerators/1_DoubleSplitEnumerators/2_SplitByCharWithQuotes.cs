using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class StringEx
    {
        class _innerDoubleSplitEnumerator01 : IEnumerator<string[]>
        {
            string _str;
            int _i;
            List<string> _posList;
            StringBuilder _sb;
            int _startIndex;
            int _endIndex;
            Func<char, bool> _primaryPredicate;
            Func<char, bool> _secondaryPredicate;
            char _leftQuote;
            char _rightQuote;
            bool _removeEmptyEntries;
            bool _removeEmptyGroup;
            bool _trim;
            bool _keepQuotes;
            string[] _curr;

            internal _innerDoubleSplitEnumerator01(string str, int startIndex, int endIndex, Func<char, bool> primaryPredicate, Func<char, bool> secondaryPredicate, char leftQuote, char rightQuote, bool removeEmptyEntries = false, bool removeEmptyGroup = false, bool trim = false, bool keepQuotes = true)
            {
                _str = str;
                _i = _startIndex = startIndex;
                _endIndex = endIndex;
                _primaryPredicate = primaryPredicate;
                _secondaryPredicate = secondaryPredicate;
                _leftQuote = leftQuote;
                _rightQuote = rightQuote;
                _removeEmptyEntries = removeEmptyEntries;
                _removeEmptyGroup = removeEmptyGroup;
                _trim = trim;
                _keepQuotes = keepQuotes;
                _posList = new List<string>(13);
                _sb = new StringBuilder();
            }

            public string[] Current
            {
                get { return _curr; }
            }

            public void Dispose()
            {
                _posList = null;
                _sb = null;
                _str = null;
                _primaryPredicate = null;
                _secondaryPredicate = null;
            }

            object Collections.IEnumerator.Current
            {
                get { return _curr; }
            }

            void _addToList()
            {
                if (_trim)
                {
                    var trimmedStr = _sb.ToStringWithTrim();
                    if (!_removeEmptyEntries || trimmedStr.Length != 0)
                        _posList.Add(trimmedStr);
                }
                else if (!_removeEmptyEntries || _sb.Length != 0) _posList.Add(_sb.ToString());
                _sb.Clear();
            }

            public bool MoveNext()
            {
                if (_i == -1) return false;
                char c = '\0';
                while (_i < _endIndex)
                {
                    if (_primaryPredicate((c = _str[_i])))
                    {
                        _addToList();
                        if (!_removeEmptyGroup || _posList.Count != 0)
                        {
                            _curr = _posList.ToArray();
                            _posList.Clear();
                            ++_i;
                            return true;
                        }
                    }
                    else if (_secondaryPredicate(c)) _addToList();
                    else if (c == _leftQuote)
                    {
                        var matchedQuoteIdx = _str.IndexOfNextMatch(_leftQuote, _rightQuote, _i);
                        if (_keepQuotes) _sb.Append(_str, _i, matchedQuoteIdx - _i + 1);
                        else _sb.Append(_str, _i + 1, matchedQuoteIdx - _i);
                    }
                    else _sb.Append(c);
                    ++_i;
                }

                _addToList();
                _i = -1;
                if (!_removeEmptyGroup || _posList.Count != 0)
                {
                    _curr = _posList.ToArray();
                    _posList.Clear();
                    return true;
                }
                else return false;
            }

            public void Reset()
            {
                _i = _startIndex;
            }
        }

        class _innerDoubleSplitEnumerator02 : IEnumerator<string[]>
        {
            string _str;
            int _i;
            List<string> _posList;
            StringBuilder _sb;
            int _startIndex;
            int _endIndex;
            Func<char, bool> _primaryPredicate;
            Func<char, bool> _secondaryPredicate;
            char[] _leftQuotes;
            char[] _rightQuotes;
            bool _removeEmptyEntries;
            bool _removeEmptyGroup;
            bool _trim;
            bool _keepQuotes;
            string[] _curr;

            internal _innerDoubleSplitEnumerator02(string str, int startIndex, int endIndex, Func<char, bool> primaryPredicate, Func<char, bool> secondaryPredicate, char[] leftQuotes, char[] rightQuotes, bool removeEmptyEntries = false, bool removeEmptyGroup = false, bool trim = false, bool keepQuotes = true)
            {
                _str = str;
                _i = _startIndex = startIndex;
                _endIndex = endIndex;
                _primaryPredicate = primaryPredicate;
                _secondaryPredicate = secondaryPredicate;
                _leftQuotes = leftQuotes;
                _rightQuotes = rightQuotes;
                _removeEmptyEntries = removeEmptyEntries;
                _removeEmptyGroup = removeEmptyGroup;
                _trim = trim;
                _keepQuotes = keepQuotes;
                _posList = new List<string>(13);
                _sb = new StringBuilder();
            }

            public string[] Current
            {
                get { return _curr; }
            }

            public void Dispose()
            {
                _posList = null;
                _sb = null;
                _str = null;
                _primaryPredicate = null;
                _secondaryPredicate = null;
            }

            object Collections.IEnumerator.Current
            {
                get { return _curr; }
            }

            void _addToList()
            {
                if (_trim)
                {
                    var trimmedStr = _sb.ToStringWithTrim();
                    if (!_removeEmptyEntries || trimmedStr.Length != 0)
                        _posList.Add(trimmedStr);
                }
                else if (!_removeEmptyEntries || _sb.Length != 0) _posList.Add(_sb.ToString());
                _sb.Clear();
            }

            public bool MoveNext()
            {
                if (_i == -1) return false;
                char c = '\0';
                while (_i < _endIndex)
                {
                    if (_primaryPredicate((c = _str[_i])))
                    {
                        _addToList();
                        if (!_removeEmptyGroup || _posList.Count != 0)
                        {
                            _curr = _posList.ToArray();
                            _posList.Clear();
                            ++_i;
                            return true;
                        }
                    }
                    else if (_secondaryPredicate(c)) _addToList();
                    else 
                    {
                        var quoteIdx = _leftQuotes.IndexOf(c);
                        if (quoteIdx != -1)
                        {
                            var matchedQuoteIdx = _str.IndexOfNextMatch(c, _rightQuotes[quoteIdx], _i);
                            if (_keepQuotes) _sb.Append(_str, _i, matchedQuoteIdx - _i + 1);
                            else _sb.Append(_str, _i + 1, matchedQuoteIdx - _i);
                        }
                        else _sb.Append(c);
                    }
                    ++_i;
                }

                _addToList();
                _i = -1;
                if (!_removeEmptyGroup || _posList.Count != 0)
                {
                    _curr = _posList.ToArray();
                    _posList.Clear();
                    return true;
                }
                else return false;
            }

            public void Reset()
            {
                _i = _startIndex;
            }
        }

        #region Predicate

        /// <summary>
        /// Gets an object that can iterate through groups of substrings in this string instance (or a part of the current string instance according to <paramref name="startIndex"/> and <paramref name="length"/>) that are delimited by Unicode characters outside quotes and satisfying the specified primary predicate and secondary predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="primaryPredicate">A function used to test each Unicode character of the current string. If a character passes this predicate, it returns a non-negative integer as the separator's index; otherwise, this function must return -1. Any character satisfying this predicate will be used as the primary separator. A primary spearator delimits substring arrays, for example, in "123,456;abc,def" which represent substring arrays { {"123", "456"}, {"abc", "def"} }, the semi-comma ';' is the primary separator.</param>
        /// <param name="secondaryPredicate">A function used to test each Unicode character of the current string. If a character passes this predicate, it returns a non-negative integer as the separator's index; otherwise, this function must return -1. Any character satisfying this predicate will be used as the secondary separator. A secondary separator delimits substrings in an array, for example, in "123,456;abc,def" which represent substring arrays { {"123", "456"}, {"abc", "def"} }, the comma ',' is the secondary separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="leftQuote">The left quote paired by <paramref name="rightQuote"/> to escape separators.</param>
        /// <param name="rightQuote">The right quote paired by <paramref name="leftQuote"/> to escape separators.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be ignored; otherwise <c>false</c>.</param>
        /// <param name="removeEmptyGroups"><c>true</c> if empty substring groups should be ignored by the returned enumerator; otherwise, <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepQuotes"><c>true</c> if the quotes should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>An object that can iterate through groups of substrings in this string instance (or a part of the current string instance) that are delimited by Unicode characters satisfying the specified two predicates.</returns>
        public static IEnumerator<string[]> GetDoubleSplitEnumeratorWithQuotes(this string str, Func<char, bool> primaryPredicate, Func<char, bool> secondaryPredicate, int startIndex, int length, char leftQuote = '{', char rightQuote = '}', bool removeEmptyEntries = false, bool removeEmptyGroups = false, bool trim = false, bool keepQuotes = true)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return new _innerDoubleSplitEnumerator01(str, startIndex, endIndex, primaryPredicate, secondaryPredicate, leftQuote, rightQuote, removeEmptyEntries, removeEmptyGroups, trim, keepQuotes);
        }


        /// <summary>
        /// Gets an object that can iterate through groups of substrings in this string instance (or a part of the current string instance according to <paramref name="startIndex"/>) that are delimited by Unicode characters outside quotes and satisfying the specified primary predicate and secondary predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="primaryPredicate">A function used to test each Unicode character of the current string. If a character passes this predicate, it returns a non-negative integer as the separator's index; otherwise, this function must return -1. Any character satisfying this predicate will be used as the primary separator. A primary spearator delimits substring arrays, for example, in "123,456;abc,def" which represent substring arrays { {"123", "456"}, {"abc", "def"} }, the semi-comma ';' is the primary separator.</param>
        /// <param name="secondaryPredicate">A function used to test each Unicode character of the current string. If a character passes this predicate, it returns a non-negative integer as the separator's index; otherwise, this function must return -1. Any character satisfying this predicate will be used as the secondary separator. A secondary separator delimits substrings in an array, for example, in "123,456;abc,def" which represent substring arrays { {"123", "456"}, {"abc", "def"} }, the comma ',' is the secondary separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="leftQuote">The left quote paired by <paramref name="rightQuote"/> to escape separators.</param>
        /// <param name="rightQuote">The right quote paired by <paramref name="leftQuote"/> to escape separators.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be ignored; otherwise <c>false</c>.</param>
        /// <param name="removeEmptyGroups"><c>true</c> if empty substring groups should be ignored by the returned enumerator; otherwise, <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepQuotes"><c>true</c> if the quotes should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>An object that can iterate through groups of substrings in this string instance (or a part of the current string instance) that are delimited by Unicode characters satisfying the specified two predicates.</returns>
        public static IEnumerator<string[]> GetDoubleSplitEnumeratorWithQuotes(this string str, Func<char, bool> primaryPredicate, Func<char, bool> secondaryPredicate, int startIndex, char leftQuote = '{', char rightQuote = '}', bool removeEmptyEntries = false, bool removeEmptyGroups = false, bool trim = false, bool keepQuotes = true)
        {
            ExceptionHelper.NonNegativeArgumentRequired("startIndex", startIndex);
            return new _innerDoubleSplitEnumerator01(str, startIndex, str.Length, primaryPredicate, secondaryPredicate, leftQuote, rightQuote, removeEmptyEntries, removeEmptyGroups, trim, keepQuotes);
        }


        /// <summary>
        /// Gets an object that can iterate through groups of substrings in this string instance that are delimited by Unicode characters outside quotes and satisfying the specified primary predicate and secondary predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="primaryPredicate">A function used to test each Unicode character of the current string. If a character passes this predicate, it returns a non-negative integer as the separator's index; otherwise, this function must return -1. Any character satisfying this predicate will be used as the primary separator. A primary spearator delimits substring arrays, for example, in "123,456;abc,def" which represent substring arrays { {"123", "456"}, {"abc", "def"} }, the semi-comma ';' is the primary separator.</param>
        /// <param name="secondaryPredicate">A function used to test each Unicode character of the current string. If a character passes this predicate, it returns a non-negative integer as the separator's index; otherwise, this function must return -1. Any character satisfying this predicate will be used as the secondary separator. A secondary separator delimits substrings in an array, for example, in "123,456;abc,def" which represent substring arrays { {"123", "456"}, {"abc", "def"} }, the comma ',' is the secondary separator.</param>
        /// <param name="leftQuote">The left quote paired by <paramref name="rightQuote"/> to escape separators.</param>
        /// <param name="rightQuote">The right quote paired by <paramref name="leftQuote"/> to escape separators.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be ignored; otherwise <c>false</c>.</param>
        /// <param name="removeEmptyGroups"><c>true</c> if empty substring groups should be ignored by the returned enumerator; otherwise, <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepQuotes"><c>true</c> if the quotes should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>An object that can iterate through groups of substrings in this string instance that are delimited by Unicode characters satisfying the specified two predicates.</returns>
        public static IEnumerator<string[]> GetDoubleSplitEnumeratorWithQuotes(this string str, Func<char, bool> primaryPredicate, Func<char, bool> secondaryPredicate, char leftQuote = '{', char rightQuote = '}', bool removeEmptyEntries = false, bool removeEmptyGroups = false, bool trim = false, bool keepQuotes = true)
        {
            return new _innerDoubleSplitEnumerator01(str, 0, str.Length, primaryPredicate, secondaryPredicate, leftQuote, rightQuote, removeEmptyEntries, removeEmptyGroups, trim, keepQuotes);
        }

        /// <summary>
        /// Gets an object that can iterate through groups of substrings in this string instance (or a part of the current string instance according to <paramref name="startIndex"/> and <paramref name="length"/>) that are delimited by Unicode characters outside quotes and satisfying the specified primary predicate and secondary predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="primaryPredicate">A function used to test each Unicode character of the current string. If a character passes this predicate, it returns a non-negative integer as the separator's index; otherwise, this function must return -1. Any character satisfying this predicate will be used as the primary separator. A primary spearator delimits substring arrays, for example, in "123,456;abc,def" which represent substring arrays { {"123", "456"}, {"abc", "def"} }, the semi-comma ';' is the primary separator.</param>
        /// <param name="secondaryPredicate">A function used to test each Unicode character of the current string. If a character passes this predicate, it returns a non-negative integer as the separator's index; otherwise, this function must return -1. Any character satisfying this predicate will be used as the secondary separator. A secondary separator delimits substrings in an array, for example, in "123,456;abc,def" which represent substring arrays { {"123", "456"}, {"abc", "def"} }, the comma ',' is the secondary separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="leftQuotes">Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.</param>
        /// <param name="rightQuotes">Specifies an array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be ignored; otherwise <c>false</c>.</param>
        /// <param name="removeEmptyGroups"><c>true</c> if empty substring groups should be ignored by the returned enumerator; otherwise, <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepQuotes"><c>true</c> if the quotes should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>An object that can iterate through groups of substrings in this string instance (or a part of the current string instance) that are delimited by Unicode characters satisfying the specified two predicates.</returns>
        public static IEnumerator<string[]> GetDoubleSplitEnumeratorWithQuotes(this string str, Func<char, bool> primaryPredicate, Func<char, bool> secondaryPredicate, int startIndex, int length, char[] leftQuotes, char[] rightQuotes, bool removeEmptyEntries = false, bool removeEmptyGroups = false, bool trim = false, bool keepQuotes = true)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return new _innerDoubleSplitEnumerator02(str, startIndex, endIndex, primaryPredicate, secondaryPredicate, leftQuotes, rightQuotes, removeEmptyEntries, removeEmptyGroups, trim, keepQuotes);
        }

        /// <summary>
        /// Gets an object that can iterate through groups of substrings in this string instance (or a part of the current string instance according to <paramref name="startIndex"/>) that are delimited by Unicode characters outside quotes and satisfying the specified primary predicate and secondary predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="primaryPredicate">A function used to test each Unicode character of the current string. If a character passes this predicate, it returns a non-negative integer as the separator's index; otherwise, this function must return -1. Any character satisfying this predicate will be used as the primary separator. A primary spearator delimits substring arrays, for example, in "123,456;abc,def" which represent substring arrays { {"123", "456"}, {"abc", "def"} }, the semi-comma ';' is the primary separator.</param>
        /// <param name="secondaryPredicate">A function used to test each Unicode character of the current string. If a character passes this predicate, it returns a non-negative integer as the separator's index; otherwise, this function must return -1. Any character satisfying this predicate will be used as the secondary separator. A secondary separator delimits substrings in an array, for example, in "123,456;abc,def" which represent substring arrays { {"123", "456"}, {"abc", "def"} }, the comma ',' is the secondary separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="leftQuotes">Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.</param>
        /// <param name="rightQuotes">Specifies an array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be ignored; otherwise <c>false</c>.</param>
        /// <param name="removeEmptyGroups"><c>true</c> if empty substring groups should be ignored by the returned enumerator; otherwise, <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepQuotes"><c>true</c> if the quotes should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>An object that can iterate through groups of substrings in this string instance (or a part of the current string instance) that are delimited by Unicode characters satisfying the specified two predicates.</returns>
        public static IEnumerator<string[]> GetDoubleSplitEnumeratorWithQuotes(this string str, Func<char, bool> primaryPredicate, Func<char, bool> secondaryPredicate, int startIndex, char[] leftQuotes, char[] rightQuotes, bool removeEmptyEntries = false, bool removeEmptyGroups = false, bool trim = false, bool keepQuotes = true)
        {
            ExceptionHelper.NonNegativeArgumentRequired("startIndex", startIndex);
            return new _innerDoubleSplitEnumerator02(str, startIndex, str.Length, primaryPredicate, secondaryPredicate, leftQuotes, rightQuotes, removeEmptyEntries, removeEmptyGroups, trim, keepQuotes);
        }

        /// <summary>
        /// Gets an object that can iterate through groups of substrings in this string instance that are delimited by Unicode characters outside quotes and satisfying the specified primary predicate and secondary predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="primaryPredicate">A function used to test each Unicode character of the current string. If a character passes this predicate, it returns a non-negative integer as the separator's index; otherwise, this function must return -1. Any character satisfying this predicate will be used as the primary separator. A primary spearator delimits substring arrays, for example, in "123,456;abc,def" which represent substring arrays { {"123", "456"}, {"abc", "def"} }, the semi-comma ';' is the primary separator.</param>
        /// <param name="secondaryPredicate">A function used to test each Unicode character of the current string. If a character passes this predicate, it returns a non-negative integer as the separator's index; otherwise, this function must return -1. Any character satisfying this predicate will be used as the secondary separator. A secondary separator delimits substrings in an array, for example, in "123,456;abc,def" which represent substring arrays { {"123", "456"}, {"abc", "def"} }, the comma ',' is the secondary separator.</param>
        /// <param name="leftQuotes">Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.</param>
        /// <param name="rightQuotes">Specifies an array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be ignored; otherwise <c>false</c>.</param>
        /// <param name="removeEmptyGroups"><c>true</c> if empty substring groups should be ignored by the returned enumerator; otherwise, <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepQuotes"><c>true</c> if the quotes should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>An object that can iterate through groups of substrings in this string instance that are delimited by Unicode characters satisfying the specified two predicates.</returns>
        public static IEnumerator<string[]> GetDoubleSplitEnumeratorWithQuotes(this string str, Func<char, bool> primaryPredicate, Func<char, bool> secondaryPredicate, char[] leftQuotes, char[] rightQuotes, bool removeEmptyEntries = false, bool removeEmptyGroups = false, bool trim = false, bool keepQuotes = true)
        {
            return new _innerDoubleSplitEnumerator02(str, 0, str.Length, primaryPredicate, secondaryPredicate, leftQuotes, rightQuotes, removeEmptyEntries, removeEmptyGroups, trim, keepQuotes);
        }

        #endregion

        #region Single Char

        /// <summary>
        /// Gets an object that can iterate through groups of substrings in this string instance (or a part of the current string instance according to <paramref name="startIndex"/> and <paramref name="length"/>) that are delimited by the primary and secondary Unicode separators outside quotes.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="primarySeparator">A primary spearator delimits substring groups, for example, in "123,456;abc,def" which represent substring arrays { {"123", "456"}, {"abc", "def"} }, the semi-comma ';' is the primary separator.</param>
        /// <param name="secondarySeparator">A secondary separator delimits substrings in a group, for example, in "123,456;abc,def" which represent substring arrays { {"123", "456"}, {"abc", "def"} }, the comma ',' is the secondary separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="leftQuote">The left quote paired by <paramref name="rightQuote"/> to escape separators.</param>
        /// <param name="rightQuote">The right quote paired by <paramref name="leftQuote"/> to escape separators.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be ignored; otherwise <c>false</c>.</param>
        /// <param name="removeEmptyGroups"><c>true</c> if empty substring groups should be ignored by the returned enumerator; otherwise, <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepQuotes"><c>true</c> if the quotes should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>An object that can iterate through groups of substrings in this string instance (or a part of the current string instance) that are delimited by the primary and secondary separators.</returns>
        public static IEnumerator<string[]> GetDoubleSplitEnumeratorWithQuotes(this string str, char primarySeparator, char secondarySeparator, int startIndex, int length, char leftQuote = '{', char rightQuote = '}', bool removeEmptyEntries = false, bool removeEmptyGroups = false, bool trim = false, bool keepQuotes = true)
        {
            ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return new _innerDoubleSplitEnumerator01(str, startIndex, str.Length, c1 => c1 == primarySeparator, c2 => c2 == secondarySeparator, leftQuote, rightQuote, removeEmptyEntries, removeEmptyGroups, trim, keepQuotes);
        }

        /// <summary>
        /// Gets an object that can iterate through groups of substrings in this string instance (or a part of the current string instance according to <paramref name="startIndex"/>) that are delimited by the primary and secondary Unicode separators outside quotes.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="primarySeparator">A primary spearator delimits substring groups, for example, in "123,456;abc,def" which represent substring arrays { {"123", "456"}, {"abc", "def"} }, the semi-comma ';' is the primary separator.</param>
        /// <param name="secondarySeparator">A secondary separator delimits substrings in a group, for example, in "123,456;abc,def" which represent substring arrays { {"123", "456"}, {"abc", "def"} }, the comma ',' is the secondary separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="leftQuote">The left quote paired by <paramref name="rightQuote"/> to escape separators.</param>
        /// <param name="rightQuote">The right quote paired by <paramref name="leftQuote"/> to escape separators.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be ignored; otherwise <c>false</c>.</param>
        /// <param name="removeEmptyGroups"><c>true</c> if empty substring groups should be ignored by the returned enumerator; otherwise, <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepQuotes"><c>true</c> if the quotes should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>An object that can iterate through groups of substrings in this string instance (or a part of the current string instance) that are delimited by the primary and secondary separators.</returns>
        public static IEnumerator<string[]> GetDoubleSplitEnumeratorWithQuotes(this string str, char primarySeparator, char secondarySeparator, int startIndex, char leftQuote = '{', char rightQuote = '}', bool removeEmptyEntries = false, bool removeEmptyGroups = false, bool trim = false, bool keepQuotes = true)
        {
            ExceptionHelper.NonNegativeArgumentRequired("startIndex", startIndex);
            return new _innerDoubleSplitEnumerator01(str, startIndex, str.Length, c1 => c1 == primarySeparator, c2 => c2 == secondarySeparator, leftQuote, rightQuote, removeEmptyEntries, removeEmptyGroups, trim, keepQuotes);
        }

        /// <summary>
        /// Gets an object that can iterate through groups of substrings in this string instance that are delimited by the primary and secondary Unicode separators outside quotes.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="primarySeparator">A primary spearator delimits substring groups, for example, in "123,456;abc,def" which represent substring arrays { {"123", "456"}, {"abc", "def"} }, the semi-comma ';' is the primary separator.</param>
        /// <param name="secondarySeparator">A secondary separator delimits substrings in a group, for example, in "123,456;abc,def" which represent substring arrays { {"123", "456"}, {"abc", "def"} }, the comma ',' is the secondary separator.</param>
        /// <param name="leftQuote">The left quote paired by <paramref name="rightQuote"/> to escape separators.</param>
        /// <param name="rightQuote">The right quote paired by <paramref name="leftQuote"/> to escape separators.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be ignored; otherwise <c>false</c>.</param>
        /// <param name="removeEmptyGroups"><c>true</c> if empty substring groups should be ignored by the returned enumerator; otherwise, <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepQuotes"><c>true</c> if the quotes should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>An object that can iterate through groups of substrings in this string instance (or a part of the current string instance) that are delimited by the primary and secondary separators.</returns>
        public static IEnumerator<string[]> GetDoubleSplitEnumeratorWithQuotes(this string str, char primarySeparator, char secondarySeparator, char leftQuote = '{', char rightQuote = '}', bool removeEmptyEntries = false, bool removeEmptyGroups = false, bool trim = false, bool keepQuotes = true)
        {
            return new _innerDoubleSplitEnumerator01(str, 0, str.Length, c1 => c1 == primarySeparator, c2 => c2 == secondarySeparator, leftQuote, rightQuote, removeEmptyEntries, removeEmptyGroups, trim, keepQuotes);
        }

        /// <summary>
        /// Gets an object that can iterate through groups of substrings in this string instance (or a part of the current string instance according to <paramref name="startIndex"/> and <paramref name="length"/>) that are delimited by the primary and secondary Unicode separators outside quotes.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="primarySeparator">A primary spearator delimits substring groups, for example, in "123,456;abc,def" which represent substring arrays { {"123", "456"}, {"abc", "def"} }, the semi-comma ';' is the primary separator.</param>
        /// <param name="secondarySeparator">A secondary separator delimits substrings in a group, for example, in "123,456;abc,def" which represent substring arrays { {"123", "456"}, {"abc", "def"} }, the comma ',' is the secondary separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="leftQuotes">Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.</param>
        /// <param name="rightQuotes">Specifies an array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be ignored; otherwise <c>false</c>.</param>
        /// <param name="removeEmptyGroups"><c>true</c> if empty substring groups should be ignored by the returned enumerator; otherwise, <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepQuotes"><c>true</c> if the quotes should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>An object that can iterate through groups of substrings in this string instance (or a part of the current string instance) that are delimited by the primary and secondary separators.</returns>
        public static IEnumerator<string[]> GetDoubleSplitEnumeratorWithQuotes(this string str, char primarySeparator, char secondarySeparator, int startIndex, int length, char[] leftQuotes, char[] rightQuotes, bool removeEmptyEntries = false, bool removeEmptyGroups = false, bool trim = false, bool keepQuotes = true)
        {
            ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return new _innerDoubleSplitEnumerator02(str, startIndex, str.Length, c1 => c1 == primarySeparator, c2 => c2 == secondarySeparator, leftQuotes, rightQuotes, removeEmptyEntries, removeEmptyGroups, trim, keepQuotes);
        }

        /// <summary>
        /// Gets an object that can iterate through groups of substrings in this string instance (or a part of the current string instance according to <paramref name="startIndex"/>) that are delimited by the primary and secondary Unicode separators outside quotes.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="primarySeparator">A primary spearator delimits substring groups, for example, in "123,456;abc,def" which represent substring arrays { {"123", "456"}, {"abc", "def"} }, the semi-comma ';' is the primary separator.</param>
        /// <param name="secondarySeparator">A secondary separator delimits substrings in a group, for example, in "123,456;abc,def" which represent substring arrays { {"123", "456"}, {"abc", "def"} }, the comma ',' is the secondary separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="leftQuotes">Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.</param>
        /// <param name="rightQuotes">Specifies an array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be ignored; otherwise <c>false</c>.</param>
        /// <param name="removeEmptyGroups"><c>true</c> if empty substring groups should be ignored by the returned enumerator; otherwise, <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepQuotes"><c>true</c> if the quotes should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>An object that can iterate through groups of substrings in this string instance (or a part of the current string instance) that are delimited by the primary and secondary separators.</returns>
        public static IEnumerator<string[]> GetDoubleSplitEnumeratorWithQuotes(this string str, char primarySeparator, char secondarySeparator, int startIndex, char[] leftQuotes, char[] rightQuotes, bool removeEmptyEntries = false, bool removeEmptyGroups = false, bool trim = false, bool keepQuotes = true)
        {
            ExceptionHelper.NonNegativeArgumentRequired("startIndex", startIndex);
            return new _innerDoubleSplitEnumerator02(str, startIndex, str.Length, c1 => c1 == primarySeparator, c2 => c2 == secondarySeparator, leftQuotes, rightQuotes, removeEmptyEntries, removeEmptyGroups, trim, keepQuotes);
        }

        /// <summary>
        /// Gets an object that can iterate through groups of substrings in this string instance that are delimited by the primary and secondary Unicode separators outside quotes.
        /// </summary>
        /// <param name="str">This string instance</param>
        /// <param name="primarySeparator">A primary spearator delimits substring groups, for example, in "123,456;abc,def" which represent substring arrays { {"123", "456"}, {"abc", "def"} }, the semi-comma ';' is the primary separator.</param>
        /// <param name="secondarySeparator">A secondary separator delimits substrings in a group, for example, in "123,456;abc,def" which represent substring arrays { {"123", "456"}, {"abc", "def"} }, the comma ',' is the secondary separator.</param>
        /// <param name="leftQuotes">Specifies an array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.</param>
        /// <param name="rightQuotes">Specifies an array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if empty strings should be ignored; otherwise <c>false</c>.</param>
        /// <param name="removeEmptyGroups"><c>true</c> if empty substring groups should be ignored by the returned enumerator; otherwise, <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepQuotes"><c>true</c> if the quotes should be included in each returned substring; otherwise, <c>false</c>.</param>
        /// <returns>An object that can iterate through groups of substrings in this string instance (or a part of the current string instance) that are delimited by the primary and secondary separators.</returns>
        public static IEnumerator<string[]> GetDoubleSplitEnumeratorWithQuotes(this string str, char primarySeparator, char secondarySeparator, char[] leftQuotes, char[] rightQuotes, bool removeEmptyEntries = false, bool removeEmptyGroups = false, bool trim = false, bool keepQuotes = true)
        {
            return new _innerDoubleSplitEnumerator02(str, 0, str.Length, c1 => c1 == primarySeparator, c2 => c2 == secondarySeparator, leftQuotes, rightQuotes, removeEmptyEntries, removeEmptyGroups, trim, keepQuotes);
        }
        #endregion
    }
}
