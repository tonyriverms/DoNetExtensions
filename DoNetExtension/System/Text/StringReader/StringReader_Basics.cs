using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public class StringReaderStatus
    {
        internal int _currPosition;
        internal int _endIndex;
    }

    /// <summary>
    /// Provides rich methods to extract information from a string instance.
    /// </summary>
    public partial class StringReader
    {
        static StringReader _emtpyReader;
        public static StringReader EmptyReader 
        {
            get
            {
                if (_emtpyReader == null) _emtpyReader = new StringReader();
                return _emtpyReader;
            }
        }



        public StringReaderStatus PreserveStatus()
        {
            return new StringReaderStatus()
            {
                _currPosition = CurrentPosition,
                _endIndex = EndPosition
            };
        }

        public void RestoreStatus(StringReaderStatus status)
        {
            CurrentPosition = status._currPosition;
            EndPosition = status._endIndex;
        }


        public bool Contains(char value)
        {
            var startIndex = CurrentPosition;
            var endIndex = EndPosition;

            while (startIndex < endIndex)
            {
                if (UnderlyingString[startIndex] == value)
                    return true;
                ++startIndex;
            }

            return false;
        }

        /// <summary>
        /// Advances the reader and reads all spaces from the reader's current position until a non-space character is encountered.
        /// </summary>
        /// <returns>The white-spaces read from the underlying string.</returns>
        public string ReadSpaces()
        {
            return ReadString(c => { return c.IsWhiteSpace(); });
        }

        /// <summary>
        /// Advances the reader and reads all non-space characters from the reader's current position until a white-space character is encountered.
        /// </summary>
        /// <returns>The non-space characters read from the underlying string.</returns>
        public string ReadNonSpaces()
        {
            return ReadString(c => { return !c.IsWhiteSpace(); });
        }

        /// <summary>
        /// Advances the reader until a character not satisfying the specified <paramref name="predicate"/> is encountered.
        /// </summary>
        /// <param name="predicate">A method used to test each character.</param>
        /// <returns>The number of characters the reader has advanced.</returns>
        public int Skip(Func<char, bool> predicate)
        {
            var characterSkipped = 0;
            for (; CurrentPosition < EndPosition && predicate(UnderlyingString[CurrentPosition]); ++CurrentPosition, ++characterSkipped) ;
            return characterSkipped;
        }

        /// <summary>
        /// Advances the reader until a non-space character is encountered.
        /// </summary>
        /// <returns>The number of white-spaces the reader has advanced.</returns>
        public int SkipSpaces()
        {
            var spaceSkipped = 0;
            for (; CurrentPosition < EndPosition && UnderlyingString[CurrentPosition].IsWhiteSpace(); ++CurrentPosition, ++spaceSkipped) ;
            return spaceSkipped;
        }

        /// <summary>
        /// Advances the reader until a white-space character is encountered.
        /// </summary>
        /// <returns>The number of non-space characters the reader has advanced.</returns>
        public int SkipNonSpaces()
        {
            var characterSkipped = 0;
            for (; CurrentPosition < EndPosition && !UnderlyingString[CurrentPosition].IsWhiteSpace(); ++CurrentPosition, ++characterSkipped) ;
            return characterSkipped;
        }

        /// <summary>
        /// Returns a substring of the underlying string instance of this reader, starting from the current position to the limit of this reader.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that is a substring of the underlying string instance of this reader.
        /// </returns>
        public override string ToString()
        {
            return UnderlyingString.Substring(CurrentPosition, EndPosition - CurrentPosition);
        }

        /// <summary>
        /// Determines whether the current scope of the underlying string equals a specified string instance.
        /// </summary>
        /// <param name="value">The value to compare.</param>
        /// <returns><c>true</c> if the current scope of the underlying string equals the specified <paramref name="value"/>.</returns>
        public bool Equals(string value)
        {
            var length = EndPosition - CurrentPosition;
            if(length != value.Length) return false;
            return string.Compare(UnderlyingString, CurrentPosition, value, 0, length, ComparisonType) == 0;
        }
        
    }
}
