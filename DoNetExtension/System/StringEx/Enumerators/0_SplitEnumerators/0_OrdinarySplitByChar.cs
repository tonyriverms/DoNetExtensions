using System;
using System.Collections.Generic;
using System.Linq;

namespace System
{
    public static partial class StringEx
    {
        class _innerSplitEnumerator01 : IEnumerator<string>
        {
            string _str;
            Func<char, bool> _predicate;
            int _startIndex;
            int _endIndex;
            bool _removeEmptyEntries;
            bool _trim;
            bool _keepSeparator;
            int _prevPosition;
            int _i;

            internal _innerSplitEnumerator01(string str, Func<char, bool> predicate, int startIndex, int endIndex, bool removeEmptyEntries, bool trim, bool keepSeparator)
            {
                _str = str;
                _predicate = predicate;
                _i = _prevPosition = _startIndex = startIndex;
                _endIndex = endIndex;
                _removeEmptyEntries = removeEmptyEntries;
                _trim = trim;
                _keepSeparator = keepSeparator;
            }

            public string Current { get; private set; }

            public void Dispose()
            {
                _str = null;
                Current = null;
                _predicate = null;
            }

            object Collections.IEnumerator.Current => Current;

            public unsafe bool MoveNext()
            {
                if (_i == -1) return false;
                var eof = _i == _endIndex;
                char c = '\0';

                fixed (char* ptr = _str)
                {
                    while (!eof)
                    {
                        if (_predicate((c = ptr[_i])))
                        {
                            var len = _i - _prevPosition;
                            ++_i;
                            if (len == 0)
                            {
                                _prevPosition = _i;
                                if (!_removeEmptyEntries)
                                {
                                    Current = !_keepSeparator ? string.Empty : c.ToString();
                                    return true;
                                }
                            }
                            else
                            {
                                if (_trim)
                                {
                                    var trimmedStr = _str.SubstringWithTrim(_prevPosition, len);
                                    _prevPosition = _i;
                                    if (!_removeEmptyEntries || !trimmedStr.Equals(string.Empty))
                                    {
                                        Current = !_keepSeparator ? trimmedStr : trimmedStr + c;
                                        return true;
                                    }
                                }
                                else
                                {
                                    Current = _str.Substring(_prevPosition, !_keepSeparator ? len : len + 1);
                                    _prevPosition = _i;
                                    return true;
                                }
                            }
                        }
                        else ++_i;

                        eof = _i == _endIndex;
                    }

                    if (_i == _prevPosition)
                    {
                        if (!_removeEmptyEntries)
                        {
                            Current = string.Empty;
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
                        if (_trim)
                        {
                            var trimmedStr = _str.SubstringWithTrim(_prevPosition, _i - _prevPosition);
                            if (!_removeEmptyEntries || !trimmedStr.Equals(string.Empty))
                            {
                                Current = trimmedStr;
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
                            Current = _str.Substring(_prevPosition, _i - _prevPosition);
                            _i = -1;
                            return true;
                        }
                    }
                }
            }

            public void Reset()
            {
                _i = _prevPosition = _startIndex;
            }
        }

        class _innerSplitEnumerator02 : IEnumerator<string>
        {
            string _str;
            char _separator;
            int _startIndex;
            int _endIndex;
            bool _removeEmptyEntries;
            bool _trim;
            bool _keepSeparator;
            int _prevPosition;
            int _i;

            internal _innerSplitEnumerator02(string str, char separator, int startIndex, int endIndex, bool removeEmptyEntries, bool trim, bool keepSeparator)
            {
                _str = str;
                _separator = separator;
                _i = _prevPosition = _startIndex = startIndex;
                _endIndex = endIndex;
                _removeEmptyEntries = removeEmptyEntries;
                _trim = trim;
                _keepSeparator = keepSeparator;
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

                while (!eof)
                {
                    if (_separator == (c = _str[_i]))
                    {
                        var len = _i - _prevPosition;
                        ++_i;
                        if (len == 0)
                        {
                            _prevPosition = _i;
                            if (!_removeEmptyEntries)
                            {
                                Current = !_keepSeparator ? string.Empty : c.ToString();
                                return true;
                            }
                        }
                        else
                        {
                            if (_trim)
                            {
                                var trimmedStr = _str.SubstringWithTrim(_prevPosition, len);
                                _prevPosition = _i;
                                if (!_removeEmptyEntries || !trimmedStr.Equals(string.Empty))
                                {
                                    Current = !_keepSeparator ? trimmedStr : trimmedStr + c;
                                    return true;
                                }
                            }
                            else
                            {
                                Current = _str.Substring(_prevPosition, !_keepSeparator ? len : len + 1);
                                _prevPosition = _i;
                                return true;
                            }
                        }
                    }
                    else ++_i;

                    eof = _i == _endIndex;
                }

                if (_i == _prevPosition)
                {
                    if (!_removeEmptyEntries)
                    {
                        Current = string.Empty;
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
                    if (_trim)
                    {
                        var trimmedStr = _str.SubstringWithTrim(_prevPosition, _i - _prevPosition);
                        if (!_removeEmptyEntries || !trimmedStr.Equals(string.Empty))
                        {
                            Current = trimmedStr;
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
                        Current = _str.Substring(_prevPosition, _i - _prevPosition);
                        _i = -1;
                        return true;
                    }
                }
            }

            public void Reset()
            {
                _i = _prevPosition = _startIndex;
            }
        }

        class _innerSplitEnumerator03 : IEnumerator<string>
        {
            string _str;
            char[] _separators;
            int _startIndex;
            int _endIndex;
            bool _removeEmptyEntries;
            bool _trim;
            bool _keepSeparator;
            int _prevPosition;
            int _i;

            internal _innerSplitEnumerator03(string str, char[] separators, int startIndex, int endIndex, bool removeEmptyEntries, bool trim, bool keepSeparator)
            {
                _str = str;
                _separators = separators;
                _i = _prevPosition = _startIndex = startIndex;
                _endIndex = endIndex;
                _removeEmptyEntries = removeEmptyEntries;
                _trim = trim;
                _keepSeparator = keepSeparator;
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

                while (!eof)
                {
                    if (_separators.Contains((c = _str[_i])))
                    {
                        var len = _i - _prevPosition;
                        ++_i;
                        if (len == 0)
                        {
                            _prevPosition = _i;
                            if (!_removeEmptyEntries)
                            {
                                Current = !_keepSeparator ? string.Empty : c.ToString();
                                return true;
                            }
                        }
                        else
                        {
                            if (_trim)
                            {
                                var trimmedStr = _str.SubstringWithTrim(_prevPosition, len);
                                _prevPosition = _i;
                                if (!_removeEmptyEntries || !trimmedStr.Equals(string.Empty))
                                {
                                    Current = !_keepSeparator ? trimmedStr : trimmedStr + c;
                                    return true;
                                }
                            }
                            else
                            {
                                Current = _str.Substring(_prevPosition, !_keepSeparator ? len : len + 1);
                                _prevPosition = _i;
                                return true;
                            }
                        }
                    }
                    else ++_i;

                    eof = _i == _endIndex;
                }

                if (_i == _prevPosition)
                {
                    if (!_removeEmptyEntries)
                    {
                        Current = string.Empty;
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
                    if (_trim)
                    {
                        var trimmedStr = _str.SubstringWithTrim(_prevPosition, _i - _prevPosition);
                        if (!_removeEmptyEntries || !trimmedStr.Equals(string.Empty))
                        {
                            Current = trimmedStr;
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
                        Current = _str.Substring(_prevPosition, _i - _prevPosition);
                        _i = -1;
                        return true;
                    }
                }
            }

            public void Reset()
            {
                _i = _prevPosition = _startIndex;
            }
        }

        internal static IEnumerator<string> _innerGetSplitEnumerator(string str, Func<char, bool> predicate, int startIndex, int endIndex, bool removeEmptyEntries, bool trim, bool keepSeparator)
        {
            int previousPosition = startIndex;
            char c = '\0';
            for (int i = startIndex; i <= endIndex; ++i)
            {
                var eof = i == endIndex;
                if (i == endIndex || predicate((c = str[i])))
                {
                    var len = i - previousPosition;
                    if (len == 0)
                    {
                        if (!removeEmptyEntries)
                            yield return eof || !keepSeparator ? string.Empty : c.ToString();
                    }
                    else
                    {
                        if (trim)
                        {
                            var trimmedStr = str.SubstringWithTrim(previousPosition, len);
                            if (!removeEmptyEntries || !trimmedStr.Equals(string.Empty)) yield return eof || !keepSeparator ? trimmedStr : trimmedStr + c;
                        }
                        else yield return str.Substring(previousPosition, eof || !keepSeparator ? len : len + 1);
                    }
                    previousPosition = i + 1;
                }
            }
        }

        /// <summary>
        /// Gets an object that can iterate through substrings in this string instance (or a part of this string according to <paramref name="startIndex" /> and <paramref name="length" />) that are delimited by Unicode characters satisfying the specified predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character of the current string. Any character that passes this test will be used as a separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if the returned enumerator should ignore empty substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each substring returned by the enumerator; otherwise, <c>false</c>.</param>
        /// <returns>An object that can iterate through substrings in the current string instance (or a part of the current string instance)
        /// that are delimited by Unicode characters satisfying the specified predicate.</returns>
        public static IEnumerator<string> GetSplitEnumerator(this string str, Func<char, bool> predicate, int startIndex, int length, bool removeEmptyEntries = false, bool trim = false, bool keepSeparator = false)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return new _innerSplitEnumerator01(str, predicate, startIndex, endIndex, removeEmptyEntries, trim, keepSeparator);
        }

        /// <summary>
        /// Gets an object that can iterate through substrings in this string instance (or a part of this string according to <paramref name="startIndex" />) that are delimited by Unicode characters satisfying the specified predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character of the current string. Any character that passes this test will be used as a separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if the returned enumerator should ignore empty substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each substring returned by the enumerator; otherwise, <c>false</c>.</param>
        /// <returns>An object that can iterate through substrings in the current string instance that are delimited by Unicode characters satisfying the specified predicate.</returns>
        public static IEnumerator<string> GetSplitEnumerator(this string str, Func<char, bool> predicate, int startIndex, bool removeEmptyEntries = false, bool trim = false, bool keepSeparator = false)
        {
            ExceptionHelper.NonNegativeArgumentRequired("startIndex", startIndex);
            return new _innerSplitEnumerator01(str, predicate, startIndex, str.Length, removeEmptyEntries, trim, keepSeparator);
        }

        /// <summary>
        /// Gets an object that can iterate through substrings in this string instance that are delimited by Unicode characters satisfying the specified predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function to test each Unicode character of the current string. Any character that passes this test will be used as a separator.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if the returned enumerator should ignore empty substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each substring returned by the enumerator; otherwise, <c>false</c>.</param>
        /// <returns>An object that can iterate through substrings in the current string instance that are delimited by Unicode characters satisfying the specified predicate.</returns>
        public static IEnumerator<string> GetSplitEnumerator(this string str, Func<char, bool> predicate, bool removeEmptyEntries = false, bool trim = false, bool keepSeparator = false)
        {
            return new _innerSplitEnumerator01(str, predicate, 0, str.Length, removeEmptyEntries, trim, keepSeparator);
        }

        /// <summary>
        /// Gets an object that can iterate through substrings in this string (or a part of this string according to <paramref name="startIndex"/> and <paramref name="length"/>) that are delimited by the specified Unicode character.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separator">A Unicode character that delimits the substrings in the current string instance.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if the returned enumerator should ignore empty substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each substring returned by the enumerator; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance (or a part of the current string instance)
        /// that are delimited by the specified Unicode character.
        /// </returns>
        public static IEnumerator<string> GetSplitEnumerator(this string str, char separator, int startIndex, int length, bool removeEmptyEntries = false, bool trim = false, bool keepSeparator = false)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return new _innerSplitEnumerator02(str, separator, startIndex, endIndex, removeEmptyEntries, trim, keepSeparator);
        }

        /// <summary>
        /// Gets an object that can iterate through substrings in this string (or a part of this string according to <paramref name="startIndex"/>) that are delimited by the specified Unicode character.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separator">A Unicode character that delimits the substrings in the current string instance.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if the returned enumerator should ignore empty substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each substring returned by the enumerator; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance (or a part of the current string instance)
        /// that are delimited by the specified Unicode character.
        /// </returns>
        public static IEnumerator<string> GetSplitEnumerator(this string str, char separator, int startIndex, bool removeEmptyEntries = false, bool trim = false, bool keepSeparator = false)
        {
            ExceptionHelper.NonNegativeArgumentRequired("startIndex", startIndex);
            return new _innerSplitEnumerator02(str, separator, startIndex, str.Length, removeEmptyEntries, trim, keepSeparator);
        }

        /// <summary>
        /// Gets an object that can iterate through substrings in this string that are delimited by the specified Unicode character.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separator">A Unicode character that delimits the substrings in the current string instance.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if the returned enumerator should ignore empty substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each substring returned by the enumerator; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance (or a part of the current string instance)
        /// that are delimited by the specified Unicode character.
        /// </returns>
        public static IEnumerator<string> GetSplitEnumerator(this string str, char separator, bool removeEmptyEntries = false, bool trim = false, bool keepSeparator = false)
        {
            return new _innerSplitEnumerator02(str, separator, 0, str.Length, removeEmptyEntries, trim, keepSeparator);
        }

        /// <summary>
        /// Gets an object that can iterate through substrings in this string (or a part of this string according to <paramref name="startIndex"/> and <paramref name="length"/>) that are delimited by specified Unicode characters.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separators">A non-empty array of Unicode characters that delimit the substrings in the current string instance.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if the returned enumerator should ignore empty substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each substring returned by the enumerator; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance (or a part of the current string instance)
        /// that are delimited by the specified Unicode characters.
        /// </returns>
        public static IEnumerator<string> GetSplitEnumerator(this string str, char[] separators, int startIndex, int length, bool removeEmptyEntries = false, bool trim = false, bool keepSeparator = false)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return new _innerSplitEnumerator03(str, separators, startIndex, endIndex, removeEmptyEntries, trim, keepSeparator);
        }

        /// <summary>
        /// Gets an object that can iterate through substrings in this string (or a part of this string according to <paramref name="startIndex" />) that are delimited by specified Unicode characters.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separators">A non-empty array of Unicode characters that delimit the substrings in the current string instance.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if the returned enumerator should ignore empty substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each substring returned by the enumerator; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance (or a part of the current string instance)
        /// that are delimited by the specified Unicode characters.
        /// </returns>
        public static IEnumerator<string> GetSplitEnumerator(this string str, char[] separators, int startIndex, bool removeEmptyEntries = false, bool trim = false, bool keepSeparator = false)
        {
            ExceptionHelper.NonNegativeArgumentRequired("startIndex", startIndex);
            return new _innerSplitEnumerator03(str, separators, startIndex, str.Length, removeEmptyEntries, trim, keepSeparator);
        }

        /// <summary>
        /// Gets an object that can iterate through substrings in this string that are delimited by specified Unicode characters.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separators">A non-empty array of Unicode characters that delimit the substrings in the current string instance.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if the returned enumerator should ignore empty substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will be ignored by the returned enumerator;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <param name="keepSeparator"><c>true</c> if the separator should be included in each substring returned by the enumerator; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An object that can iterate through substrings in the current string instance (or a part of the current string instance)
        /// that are delimited by the specified Unicode characters.
        /// </returns>
        public static IEnumerator<string> GetSplitEnumerator(this string str, char[] separators, bool removeEmptyEntries = false, bool trim = false, bool keepSeparator = false)
        {
            return new _innerSplitEnumerator03(str, separators, 0, str.Length, removeEmptyEntries, trim, keepSeparator);
        }
    }
}
