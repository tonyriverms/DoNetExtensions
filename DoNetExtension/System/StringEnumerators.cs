using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// Supports simple iteration of substrings in a string instance.
    /// <para>For example, suppose "&lt;" and "&gt;" are used as the indicators, iterating "&lt;div&gt;abc&lt;/div&gt;" will get "&lt;div&gt;" and "&lt;/div&gt;"</para>
    /// </summary>
    internal class StringEnumerator1 : IEnumerator<string>
    {
        internal StringEnumerator1(string innerString, string startIndicator, string endIndicator,
            bool includeStartIndicator = false, bool includeEndIndicator = false)
        {
            _str = innerString;
            _startIndicator = startIndicator;
            _endIndicator = endIndicator;
            _includeStartIndicator = includeStartIndicator;
            _includeEndIndicator = includeEndIndicator;
        }

        int _sidx;
        int _ssidx;
        int _eidx;
        int _eeidx;
        string _str;
        string _startIndicator;
        string _endIndicator;
        bool _includeStartIndicator;
        bool _includeEndIndicator;
        string _current;

        /// <summary>
        /// Gets the current substring.
        /// </summary>
        public string Current
        { get { return _current; } }

        /// <summary>
        /// Gets the position of the current substring in the original string.
        /// </summary>
        public int StartPosition
        { get { return _ssidx; } }

        /// <summary>
        /// Gets the end position of the current substring in the original string.
        /// </summary>
        public int EndPosition
        { get { return _eeidx; } }

        /// <summary>
        /// Gets the indicator makring the beginning of each substring to iterate.
        /// </summary>
        public string StartIndicator { get { return _startIndicator; } }
        /// <summary>
        /// Gets the indicator makring the end of each substring to iterate.
        /// </summary>
        public string EndIndicator { get { return _endIndicator; } }

        /// <summary>
        /// Gets a value indicating whether the end of the original string is reached.
        /// </summary>
        public bool EndOfString
        {
            get { return _sidx == -1 || _eidx == -1; }
        }

        /// <summary>
        /// Advances the enumerator to the next desired substring.
        /// </summary>
        /// <returns>true if the enumerator was successfully advanced to the next substring; false if the enumerator has passed the end of the original string.</returns>
        public bool MoveNext()
        {
            _sidx = _eidx;
            _ssidx = _sidx = _str.IndexOf(_startIndicator, _sidx);
            if (_sidx == -1) return false;
            _sidx += +_startIndicator.Length;
            if (!_includeStartIndicator)
                _ssidx = _sidx;

            _eeidx = _eidx = _str.IndexOf(_endIndicator, _sidx);
            if (_eidx == -1) return false;
            _eidx += _endIndicator.Length;
            if (_includeEndIndicator)
                _eeidx = _eidx;

            var len = _eeidx - _ssidx;
            if (len == 0) _current = "";
            else
                _current = _str.Substring(_ssidx, len);

            return true;
        }

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the beginning of the original string.
        /// </summary>
        public void Reset()
        {
            _sidx = 0;
            _eidx = 0;
            _current = null;
        }

        /// <summary>
        /// Disposes this enumerator.
        /// </summary>
        public void Dispose()
        {
            _str = null;
            _startIndicator = null;
            _endIndicator = null;
            _current = null;
        }

        object Collections.IEnumerator.Current
        {
            get { return _current; }
        }
    }

    /// <summary>
    /// Supports simple iteration of substrings in a string instance.
    /// <para>For example, suppose "&lt;" and "&gt;" are used as the indicators, iterating "&lt;div&gt;abc&lt;/div&gt;" will get "&lt;div&gt;" and "&lt;/div&gt;"</para>
    /// </summary>
    internal class StringEnumerator2 : IEnumerator<string>
    {
        internal StringEnumerator2(string innerString, char startIndicator, char endIndicator,
            bool includeStartIndicator = false, bool includeEndIndicator = false)
        {
            _str = innerString;
            _startIndicator = startIndicator;
            _endIndicator = endIndicator;
            _includeStartIndicator = includeStartIndicator;
            _includeEndIndicator = includeEndIndicator;
        }

        int _sidx;
        int _ssidx;
        int _eidx;
        int _eeidx;
        string _str;
        char _startIndicator;
        char _endIndicator;
        bool _includeStartIndicator;
        bool _includeEndIndicator;
        string _current;

        /// <summary>
        /// Gets the current substring.
        /// </summary>
        public string Current
        { get { return _current; } }

        /// <summary>
        /// Gets the position of the current substring in the original string.
        /// </summary>
        public int StartPosition
        { get { return _ssidx; } }

        /// <summary>
        /// Gets the end position of the current substring in the original string.
        /// </summary>
        public int EndPosition
        { get { return _eeidx; } }

        /// <summary>
        /// Gets the indicator makring the beginning of each substring to iterate.
        /// </summary>
        public char StartIndicator { get { return _startIndicator; } }
        /// <summary>
        /// Gets the indicator makring the end of each substring to iterate.
        /// </summary>
        public char EndIndicator { get { return _endIndicator; } }

        /// <summary>
        /// Gets a value indicating whether the end of the original string is reached.
        /// </summary>
        public bool EndOfString
        {
            get { return _eidx == -1; }
        }

        /// <summary>
        /// Advances the enumerator to the next desired substring.
        /// </summary>
        /// <returns>true if the enumerator was successfully advanced to the next substring; false if the enumerator has passed the end of the original string.</returns>
        public bool MoveNext()
        {
            _sidx = _eidx;
            _ssidx = _sidx = _str.IndexOf(_startIndicator, _sidx);
            if (_sidx == -1) return false;
            _sidx++;
            if (!_includeStartIndicator)
                _ssidx = _sidx;

            _eeidx = _eidx = _str.IndexOf(_endIndicator, _sidx);
            if (_eidx == -1) return false;
            _eidx++;
            if (_includeEndIndicator)
                _eeidx = _eidx;

            var len = _eeidx - _ssidx;
            if (len == 0) _current = "";
            else
                _current = _str.Substring(_ssidx, len);

            return true;
        }

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the beginning of the original string.
        /// </summary>
        public void Reset()
        {
            _sidx = 0;
            _eidx = 0;
            _current = null;
        }

        /// <summary>
        /// Disposes this enumerator.
        /// </summary>
        public void Dispose()
        {
            _str = null;
            _current = null;
        }

        object Collections.IEnumerator.Current
        {
            get { return _current; }
        }
    }

    /// <summary>
    /// Supports simple iteration of substrings in a string instance.
    /// <para>For example, suppose "&lt;" and "&gt;" are used as the indicators, iterating "&lt;div&gt;abc&lt;/div&gt;" will get "&lt;div&gt;" and "&lt;/div&gt;"</para>
    /// </summary>
    internal class StringEnumerator3 : IEnumerator<string>
    {
        internal StringEnumerator3(string innerString, string separator,
            bool includeSeparator = false)
        {
            _str = innerString;
            _separator = separator;
            _includeSeparator = includeSeparator;
        }

        int _sidx;
        int _eidx;
        int _eeidx;
        string _str;
        string _separator;
        bool _includeSeparator;
        string _current;

        /// <summary>
        /// Gets the current substring.
        /// </summary>
        public string Current
        { get { return _current; } }

        /// <summary>
        /// Gets the position of the current substring in the original string.
        /// </summary>
        public int StartPosition
        { get { return _sidx; } }

        /// <summary>
        /// Gets the end position of the current substring in the original string.
        /// </summary>
        public int EndPosition
        { get { return _eeidx; } }

        /// <summary>
        /// Gets the separator that separates each substring.
        /// </summary>
        public string Separator { get { return _separator; } }

        /// <summary>
        /// Gets a value indicating whether the end of the original string is reached.
        /// </summary>
        public bool EndOfString
        {
            get { return _sidx == -1 || _eidx == -1; }
        }

        /// <summary>
        /// Advances the enumerator to the next desired substring.
        /// </summary>
        /// <returns>true if the enumerator was successfully advanced to the next substring; false if the enumerator has passed the end of the original string.</returns>
        public bool MoveNext()
        {
            _sidx = _eidx;
            _eeidx = _eidx = _str.IndexOf(_separator, _sidx);
            if (_eidx == -1) return false;

            _eidx += _separator.Length;
            if (_includeSeparator)
                _eeidx = _eidx;

            var len = _eeidx - _sidx;
            if (len == 0) _current = "";
            else _current = _str.Substring(_sidx, len);

            return true;
        }

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the beginning of the original string.
        /// </summary>
        public void Reset()
        {
            _eidx = 0;
            _current = null;
        }

        /// <summary>
        /// Disposes this enumerator.
        /// </summary>
        public void Dispose()
        {
            _str = null;
            _separator = null;
            _current = null;
        }

        object Collections.IEnumerator.Current
        {
            get { return _current; }
        }
    }

    /// <summary>
    /// Supports simple iteration of substrings in a string instance.
    /// <para>For example, suppose "&lt;" and "&gt;" are used as the indicators, iterating "&lt;div&gt;abc&lt;/div&gt;" will get "&lt;div&gt;" and "&lt;/div&gt;"</para>
    /// </summary>
    internal class StringEnumerator4 : IEnumerator<string>
    {
        internal StringEnumerator4(string innerString, char separator,
            bool includeSeparator = false)
        {
            _str = innerString;
            _separator = separator;
            _includeSeparator = includeSeparator;
        }

        int _sidx;
        int _eidx;
        int _eeidx;
        string _str;
        char _separator;
        bool _includeSeparator;
        string _current;

        /// <summary>
        /// Gets the current substring.
        /// </summary>
        public string Current
        { get { return _current; } }

        /// <summary>
        /// Gets the position of the current substring in the original string.
        /// </summary>
        public int StartPosition
        { get { return _sidx; } }

        /// <summary>
        /// Gets the end position of the current substring in the original string.
        /// </summary>
        public int EndPosition
        { get { return _eeidx; } }

        /// <summary>
        /// Gets the separator that separates each substring.
        /// </summary>
        public char Separator { get { return _separator; } }

        /// <summary>
        /// Gets a value indicating whether the end of the original string is reached.
        /// </summary>
        public bool EndOfString
        {
            get { return _eidx == -1; }
        }

        /// <summary>
        /// Advances the enumerator to the next desired substring.
        /// </summary>
        /// <returns>true if the enumerator was successfully advanced to the next substring; false if the enumerator has passed the end of the original string.</returns>
        public bool MoveNext()
        {
            _sidx = _eidx;
            _eeidx = _eidx = _str.IndexOf(_separator, _sidx);
            if (_eidx == -1) return false;

            _eidx++;
            if (_includeSeparator)
                _eeidx = _eidx;

            var len = _eeidx - _sidx;
            if (len == 0) _current = "";
            else _current = _str.Substring(_sidx, len);

            return true;
        }

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the beginning of the original string.
        /// </summary>
        public void Reset()
        {
            _eidx = 0;
            _current = null;
        }

        /// <summary>
        /// Disposes this enumerator.
        /// </summary>
        public void Dispose()
        {
            _str = null;
            _current = null;
        }

        object Collections.IEnumerator.Current
        {
            get { return _current; }
        }
    }
}
