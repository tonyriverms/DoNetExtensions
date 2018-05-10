using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace System
{
    /// <summary>
    /// Represents a substring of a string instance.
    /// </summary>
    public class SubString
    {
        string _text;
        int _startIndex;
        int _endIndex;

        /// <summary>
        /// Initializes a new instance of System.Substring.
        /// </summary>
        /// <param name="source">The source string to which this substring belongs.</param>
        /// <param name="startIndex">Indicates the position of this substring in the source string.</param>
        /// <param name="endIndex">Indicates the position after the last character of this substring in the source string.</param>
        /// <param name="newInstance">Indicates whether to create a new stirng instance. 
        /// <para>If set true, the substring will be copied to a new string instance; 
        /// otherwise, only start and end positions are recorded in this object. By default, this value is set true.</para>
        /// <para>If you are intended to operate on a large amount of substrings, set this value to false to save time and system memory.</para></param>
        public SubString(string source, int startIndex, int endIndex, bool newInstance = true)
        {
            _startIndex = startIndex;
            _endIndex = endIndex;
            if (newInstance)
                _text = source.Substring(startIndex, endIndex - startIndex);
            else
                _text = source;
            _onlyPositionInfo = !newInstance;
        }


        /// <summary>
        /// Gets a System.String instance with the same value as the substring this System.SubString object represents.
        /// </summary>
        /// <param name="cacheString">Indicating whether to cache the returned System.String instance.
        /// <para>If this parameter is set true, the returned string representation will be stored for future use 
        /// (next time this reserved string instance will be immediately returned).</para></param>
        /// <returns>A System.String representation of this substring.</returns>
        public string ToString(bool cacheString)
        {
            if (_onlyPositionInfo)
            {
                var rlt = _text.Substring(_startIndex, _endIndex - _startIndex);
                if (cacheString)
                {
                    _text = rlt;
                    _onlyPositionInfo = false;
                }
                return rlt;
            }
            return _text;
        }

        /// <summary>
        /// Gets a System.String instance with the same value as the substring this System.SubString object represents.
        /// </summary>
        public override string ToString()
        {
            return ToString(true);
        }

        /// <summary>
        /// Gets the position of this substring in the source string.
        /// </summary>
        public int StartIndex
        {
            get { return _startIndex; }
            set
            {
                if (_onlyPositionInfo) _startIndex = value;
                else throw new InvalidOperationException();
            }
        }
        /// <summary>
        /// Gets the position after the last character of this substring in the source string.
        /// </summary>
        public int EndIndex
        {
            get { return _endIndex; }
            set
            {
                if (_onlyPositionInfo) _endIndex = value;
                else throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Gets the length of this substring.
        /// </summary>
        public int Length { get { return _endIndex - _startIndex; } }
        bool _onlyPositionInfo;

        /// <summary>
        /// Returns the hash code for this substring. 
        /// This hash code is exactly the same as the hash code for a System.String with the same value this System.SubString represents.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            if (_onlyPositionInfo)
                return _text.GetHashCode(_startIndex, _endIndex - _startIndex);
            else
                return _text.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified System.Object is equal to the current substring. This method will return true if
        /// <para>1. <paramref name="obj"/> is a System.SubString representing the same substring.</para>
        /// <para>2. <paramref name="obj"/> is a System.String with the same value as the substring this System.SubString represents.</para>
        /// </summary>
        /// <param name="obj">The System.Object to compare with the current substring.</param>
        /// <returns>true if the specified Object is equal to the current substring; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            var tempStr = obj as string;
            if (tempStr == null)
            {
                var target = obj as SubString;
                if (target == null)
                    return false;
                else
                {
                    if (Length != target.Length)
                        return false;

                    if (_onlyPositionInfo && target._onlyPositionInfo)
                        return _text.StartsWith(_startIndex, target._text, target._startIndex);

                    if (_onlyPositionInfo && !target._onlyPositionInfo)
                        return _text.StartsWith(_startIndex, target._text);

                    if (!_onlyPositionInfo && target._onlyPositionInfo)
                        return target._text.StartsWith(target._startIndex, _text);

                    return _text == target._text;
                }
            }
            else
            {
                if (_onlyPositionInfo)
                    return _text.StartsWith(_startIndex, tempStr);
                else return _text == tempStr;
            }
        }
    }
}
