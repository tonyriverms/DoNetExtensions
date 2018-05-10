using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class StringEx
    {
        class _innerSplitEnumeratorEx01 : IEnumerator<StringSplitResult>
        {
            string _str;
            Func<char, int> _predicate;
            int _startIndex;
            int _endIndex;
            bool _removeEmptyEntries;
            bool _trim;
            bool _keepSeparator;
            int _prevPosition;
            int _i;
            StringSplitResult _curr;

            internal _innerSplitEnumeratorEx01(string str, Func<char, int> predicate, int startIndex, int endIndex, bool removeEmptyEntries, bool trim)
            {
                _str = str;
                _predicate = predicate;
                _i = _prevPosition = _startIndex = startIndex;
                _endIndex = endIndex;
                _removeEmptyEntries = removeEmptyEntries;
                _trim = trim;
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

            public unsafe bool MoveNext()
            {
                if (_i == -1) return false;
                var eof = _i == _endIndex;
                char c = '\0';
                int separatorIndex = -1;
                fixed (char* ptr = _str)
                {
                    while (!eof)
                    {
                        if ((separatorIndex = _predicate((c = ptr[_i]))) != -1)
                        {
                            var len = _i - _prevPosition;
                            ++_i;
                            if (len == 0)
                            {
                                _prevPosition = _i;
                                if (!_removeEmptyEntries)
                                {
                                    _curr = new StringSplitResult(string.Empty, c, separatorIndex);
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
                                        _curr = new StringSplitResult(trimmedStr, c, separatorIndex);
                                        return true;
                                    }
                                }
                                else
                                {
                                    _curr = new StringSplitResult(_str.Substring(_prevPosition, len), c, separatorIndex);
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
                            _curr = new StringSplitResult(string.Empty, '\0', -1);
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
                            _curr = new StringSplitResult(_str.Substring(_prevPosition, _i - _prevPosition), '\0', -1);
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

        class _innerSplitEnumeratorEx02 : IEnumerator<StringSplitResult>
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
            StringSplitResult _curr;

            internal _innerSplitEnumeratorEx02(string str, char[] separators, int startIndex, int endIndex, bool removeEmptyEntries, bool trim)
            {
                _str = str;
                _separators = separators;
                _i = _prevPosition = _startIndex = startIndex;
                _endIndex = endIndex;
                _removeEmptyEntries = removeEmptyEntries;
                _trim = trim;
            }

            public StringSplitResult Current
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

            public unsafe bool MoveNext()
            {
                if (_i == -1) return false;
                var eof = _i == _endIndex;
                char c = '\0';
                int separatorIndex = -1;
                fixed (char* ptr = _str)
                {
                    while (!eof)
                    {
                        if ((separatorIndex = _separators.IndexOf((c = ptr[_i]))) != -1)
                        {
                            var len = _i - _prevPosition;
                            ++_i;
                            if (len == 0)
                            {
                                _prevPosition = _i;
                                if (!_removeEmptyEntries)
                                {
                                    _curr = new StringSplitResult(string.Empty, c, separatorIndex);
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
                                        _curr = new StringSplitResult(trimmedStr, c, separatorIndex);
                                        return true;
                                    }
                                }
                                else
                                {
                                    _curr = new StringSplitResult(_str.Substring(_prevPosition, len), c, separatorIndex);
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
                            _curr = new StringSplitResult(string.Empty, '\0', -1);
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
                            _curr = new StringSplitResult(_str.Substring(_prevPosition, _i - _prevPosition), '\0', -1);
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

        /// <summary>
        /// Gets an object that can iterate through information about substrings in this string instance (or a part of the current string instance according to <paramref name="startIndex" /> and <paramref name="length" />)
        /// that are delimited by Unicode characters satisfying the specified predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function used to test each Unicode character of the current string. If a character passes this predicate, it returns a non-negative integer as the separator's index; otherwise, this function must return -1. Any character satisfying this predicate will be used as the separator.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for characters satisfying <paramref name="predicate" /> starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if the returned enumerator should ignore empty substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <returns>
        /// An object that can iterate through information about substrings in the current string instance (or a part of the current string instance)
        /// that are delimited by Unicode characters satisfying the specified predicate.
        /// </returns>
        public static IEnumerator<StringSplitResult> GetSplitEnumeratorEx(this string str, Func<char, int> predicate, int startIndex, int length, bool removeEmptyEntries = false, bool trim = false)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return new _innerSplitEnumeratorEx01(str, predicate, startIndex, endIndex, removeEmptyEntries, trim);
        }

        /// <summary>
        /// Gets an object that can iterate through information about substrings in this string instance (or a part of the current string instance according to <paramref name="startIndex" />)
        /// that are delimited by Unicode characters satisfying the specified predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for characters satisfying <paramref name="predicate" /> starts.</param>
        /// <param name="predicate">A function used to test each Unicode character of the current string. If a character passes this predicate, it returns a non-negative integer as the separator's index; otherwise, this function must return -1. Any character satisfying this predicate will be used as the separator.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if the returned enumerator should ignore empty substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <returns>
        /// An object that can iterate through information about substrings in the current string instance that are delimited by Unicode characters satisfying the specified predicate.
        /// </returns>
        public static IEnumerator<StringSplitResult> GetSplitEnumeratorEx(this string str, Func<char, int> predicate, int startIndex, bool removeEmptyEntries = false, bool trim = false)
        {
            ExceptionHelper.NonNegativeArgumentRequired("startIndex", startIndex);
            return new _innerSplitEnumeratorEx01(str, predicate, startIndex, str.Length, removeEmptyEntries, trim);
        }

        /// <summary>
        /// Gets an object that can iterate through information about substrings in this string instance (or a part of the current string instance according to <paramref name="startIndex" />)
        /// that are delimited by Unicode characters satisfying the specified predicate.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="predicate">A function used to test each Unicode character of the current string. If a character passes this predicate, it returns a non-negative integer as the separator's index; otherwise, this function must return -1. Any character satisfying this predicate will be used as the separator.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if the returned enumerator should ignore empty substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <returns>
        /// An object that can iterate through information about substrings in the current string instance that are delimited by Unicode characters satisfying the specified predicate.
        /// </returns>
        public static IEnumerator<StringSplitResult> GetSplitEnumeratorEx(this string str, Func<char, int> predicate, bool removeEmptyEntries = false, bool trim = false)
        {
            return new _innerSplitEnumeratorEx01(str, predicate, 0, str.Length, removeEmptyEntries, trim);
        }

        /// <summary>
        /// Gets an object that can iterate through <see cref="StringSplitResult"/> objects that represent substring information in this string (or a part of the current string instance according to <paramref name="startIndex" /> and <paramref name="length" />) that are delimited by specified Unicode characters.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separators">A non-empty array of Unicode characters that delimit the substrings in the current string instance.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="length">A positive value indicating the number of characters to search starting from the position specified by <paramref name="startIndex" />.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if the returned enumerator should ignore empty substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <returns>
        /// An object that can iterate through information about substrings in the current string instance (or a part of the current string instance) that are delimited by the specified Unicode characters.
        /// </returns>
        public static IEnumerator<StringSplitResult> GetSplitEnumeratorEx(this string str, char[] separators, int startIndex, int length, bool removeEmptyEntries = false, bool trim = false)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, str.Length);
            return new _innerSplitEnumeratorEx02(str, separators, startIndex, endIndex, removeEmptyEntries, trim);
        }

        /// <summary>
        /// Gets an object that can iterate through <see cref="StringSplitResult"/> objects that represent substring information in this string (or a part of the current string instance according to <paramref name="startIndex" />)
        /// that are delimited by specified Unicode characters.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separators">A non-empty array of Unicode characters that delimit the substrings in the current string instance.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if the returned enumerator should ignore empty substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <returns>
        /// An object that can iterate through information about substrings in the current string instance (or a part of the current string instance) that are delimited by the specified Unicode characters.
        /// </returns>
        public static IEnumerator<StringSplitResult> GetSplitEnumeratorEx(this string str, char[] separators, int startIndex, bool removeEmptyEntries = false, bool trim = true)
        {
            ExceptionHelper.NonNegativeArgumentRequired("startIndex", startIndex);
            return new _innerSplitEnumeratorEx02(str, separators, startIndex, str.Length, removeEmptyEntries, trim);
        }

        /// <summary>
        /// Gets an object that can iterate through <see cref="StringSplitResult"/> objects that represent substring information in this string that are delimited by specified Unicode characters.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="separators">A non-empty array of Unicode characters that delimit the substrings in the current string instance.</param>
        /// <param name="startIndex">The zero-based position indicating where the search for separators starts.</param>
        /// <param name="removeEmptyEntries"><c>true</c> if the returned enumerator should ignore empty substrings; otherwise <c>false</c>.</param>
        /// <param name="trim">Indicates whether the returned substrings are trimmed.
        /// <para>NOTE that if <paramref name="removeEmptyEntries" /> is set <c>true</c>, then a substring containing only white spaces will not be returned;
        /// for example, in this case "ab,   ,cd" split by comma ',' is "ab" and "cd".</para></param>
        /// <returns>
        /// An object that can iterate through information about substrings in the current string instance that are delimited by the specified Unicode characters.
        /// </returns>
        public static IEnumerator<StringSplitResult> GetSplitEnumeratorEx(this string str, char[] separators, bool removeEmptyEntries = false, bool trim = true)
        {
            return new _innerSplitEnumeratorEx02(str, separators, 0, str.Length, removeEmptyEntries, trim);
        }
    }
}
