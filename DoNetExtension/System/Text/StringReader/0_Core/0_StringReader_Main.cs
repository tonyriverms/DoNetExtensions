using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Text
{
    public partial class StringReader
    {
        #region Underlying String & Reading Scope

        /// <summary>
        /// Gets the underlying string instance that this string reader is currently reading.
        /// </summary>
        /// <value>
        /// The underlying string.
        /// </value>
        public string UnderlyingString { private set; get; }

        /// <summary>
        /// Gets the position next to the last character within the reading scope.
        /// </summary>
        /// <value>
        /// The position that defines the end of the reading scope.
        /// </value>
        public int EndPosition { private set; get; }

        /// <summary>
        /// Gets the reader's current position. The reader's reading scope is from this position to the character previous to the <see cref="EndPosition"/>.
        /// </summary>
        /// <value>
        /// The reader's current position.
        /// </value>
        public int CurrentPosition { protected set; get; }

        /// <summary>
        /// Gets or sets the culture, case, and sort rules to be used in string operations.
        /// By default, this property is set <c>Ordinal</c> out of efficiency consideration.
        /// </summary>
        /// <value>
        /// An enumeration value that indicates the culture, case, and sort rules to be used in string operations.
        /// </value>
        public StringComparison ComparisonType { get; set; }

        #endregion

        #region Basic Properties

        /// <summary>
        /// Gets a value indicating whether the reader's current reading scope is empty (<see cref="CurrentPosition"/> equals <see cref="EndPosition"/>).
        /// </summary>
        /// <value>
        ///   <c>true</c> if the reader's current reading scope is empty; otherwise, <c>false</c>.
        /// </value>
        public bool EOF => CurrentPosition == EndPosition;

        /// <summary>
        /// Gets a value indicating whether the current reading scope is empty or contains only whitespace characters.
        /// </summary>
        /// <value><c>true</c> if this instance is empty or contains only whitespace characters; otherwise, <c>false</c>.</value>
        public bool IsEmptyOrBlank
        {
            get
            {
                for (int i = CurrentPosition, j = EndPosition; i < j; ++i)
                {
                    if (!UnderlyingString[i].IsWhiteSpace())
                        return false;
                }

                return true;
            }
        }

        /// <summary>
        /// Gets the length of the current reading scope defined by <see cref="CurrentPosition"/> and <see cref="EndPosition"/>.
        /// </summary>
        /// <value>The length of the reading scope defined by <see cref="CurrentPosition"/> and <see cref="EndPosition"/>.</value>
        public int Length => EndPosition - CurrentPosition;

        /// <summary>
        /// Gets the first character of the reading scope.
        /// </summary>
        /// <value>The first character of the reading scope.</value>
        public char First => UnderlyingString[CurrentPosition];


        /// <summary>
        /// Gets the character immediately before the reader's current position. Requires <see cref="CurrentPosition"/> not to equal zero.
        /// </summary>
        /// <value>
        /// The character immediately before the reader's current position.
        /// </value>
        public char Previous => UnderlyingString[CurrentPosition - 1];

        /// <summary>
        /// Gets the character immediately after the reader's current position.
        /// </summary>
        /// <value>
        /// The character immediately after the reader's current position.
        /// </value>
        public char Next => UnderlyingString[CurrentPosition + 1];

        /// <summary>
        /// Gets the last character of the reading scope.
        /// </summary>
        /// <value>The last character of the reading scope.</value>
        public char Last => UnderlyingString[EndPosition - 1];

        /// <summary>
        /// Gets the <see cref="System.Char"/> of the underlying string instance using an index relative to the reader's current position.
        /// For example, 0 indicates the character at the reader's current position, 
        /// 1 indicates the character next to the reader's current position, 
        /// and -1 indicates the character previous to the reader's current position.
        /// </summary>
        /// <value>
        /// A <see cref="System.Char"/> of the underlying string instance.
        /// </value>
        /// <param name="index">The index relative to the reader's current position.</param>
        /// <returns></returns>
        /// <exception cref="System.IndexOutOfRangeException">Occurs when the <paramref name="index"/> is out of range.</exception>
        public char this[int index]
        {
            get
            {
                index += CurrentPosition;
                if (index < EndPosition && index >= 0) return UnderlyingString[index];
                else throw new IndexOutOfRangeException();
            }
        }

        #endregion

        /// <summary>
        /// Gets a substring starting from the specified <paramref name="prevPos" /> to the character previous to the <see cref="CurrentPosition" />. <para>Note this method returns <c>null</c> if <paramref name="prevPos" /> equals <see cref="CurrentPosition" />.</para>
        /// </summary>
        /// <param name="prevPos">Provides a position prior to the reader's <see cref="CurrentPosition"/>.</param>
        /// <returns>A substring starting from the specified <paramref name="prevPos" /> to the character previous to the <see cref="CurrentPosition" />. Note the first character of the current reading scope is not contained in the returned substring. <c>null</c> is returned if <paramref name="prevPos" /> equals <see cref="CurrentPosition" />.</returns>
        /// <exception cref="System.ArgumentException"><paramref name="prevPos" /> is larger than <see cref="CurrentPosition" />.</exception>
        public string SubstringBeforeCurrentPosition(int prevPos)
        {
            if (prevPos < CurrentPosition) return InnerSubstringBeforeCurrentPosition(prevPos);
            if (prevPos == CurrentPosition) return null;
            throw new ArgumentException(nameof(prevPos));
        }

        /// <summary>
        /// For internal use only. The internal version of <see cref="SubstringBeforeCurrentPosition"/> without argument check.
        /// </summary>
        /// <param name="prevPos">Provides a position prior to the reader's <see cref="CurrentPosition"/>.</param>
        /// <returns>A substring starting from the specified <paramref name="prevPos" /> to the character previous to the <see cref="CurrentPosition" />. Note the first character of the current reading scope is not contained in the returned substring. <c>null</c> is returned if <paramref name="prevPos" /> equals <see cref="CurrentPosition" />.</returns>
        internal string InnerSubstringBeforeCurrentPosition(int prevPos)
        {
            return CurrentPosition == prevPos ? null : UnderlyingString.Substring(prevPos, CurrentPosition - prevPos);
        }

        /// <summary>
        /// For internal use only. The same as <see cref="SubstringBeforeCurrentPosition"/> except that the white spaces at the end of returned string are trimmed.
        /// </summary>
        /// <param name="prevPos">Provides a position prior to the reader's <see cref="CurrentPosition"/>.</param>
        /// <returns>A substring starting from the specified <paramref name="prevPos" /> to the character previous to the <see cref="CurrentPosition" />. Note the first character of the current reading scope is not contained in the returned substring. <c>null</c> is returned if <paramref name="prevPos" /> equals <see cref="CurrentPosition" />.</returns>
        internal string InnerSubstringBeforeCurrentPositionWithTrimEnd(int prevPos)
        {
            if (prevPos == CurrentPosition) return null;
            var pos = CurrentPosition - 1;
            while (UnderlyingString[pos].IsWhiteSpace())
            {
                --pos;
                if (pos < prevPos) return null;
            }
            return UnderlyingString.Substring(prevPos, pos + 1 - prevPos);
        }

        /// <summary>
        /// Advances the reader's position to the first non-white-space character within the reading scope. If there exists no non-white-space character, then <see cref="EOF"/> will be <c>true</c> after executing this method.
        /// </summary>
        public void TrimStart()
        {
            if (EOF) return;
            while (UnderlyingString[CurrentPosition].IsWhiteSpace())
            {
                ++CurrentPosition;
                if (EOF) return;
            }
        }

        /// <summary>
        /// Regresses the reader's end position to the last non-white-space character within the reading scope. If there exists no non-white-space character, then <see cref="EOF"/> will be <c>true</c> after executing this method.
        /// </summary>
        public void TrimEnd()
        {
            if (EOF) return;
            while (UnderlyingString[EndPosition - 1].IsWhiteSpace())
            {
                --EndPosition;
                if (EOF) return;
            }
        }

        /// <summary>
        /// Advances the reader's position to the first non-white-space character as well as regresses the reader's end position to the last non-whilte-space within the reading scope. If there exists no non-white-space character, then <see cref="EOF"/> will be <c>true</c> after executing this method.
        /// </summary>
        public void Trim()
        {
            TrimStart();
            TrimEnd();
        }



        #region Constructors

        /// <summary>
        /// For internal use only. Creates a new <see cref="StringReader"/> instance with the specified <paramref name="startIndex"/> and <paramref name="endIndex"/>.
        /// </summary>
        /// <param name="s">The string instance to read.</param>
        /// <param name="startIndex">Specifies the initial position of the reader.</param>
        /// <param name="endIndex">Specifies the end position of the reading scope.</param>
        /// <returns>A new <see cref="StringReader"/> instance.</returns>
        internal static StringReader InternalCreate(string s, int startIndex, int endIndex)
        {
            return new StringReader()
            {
                UnderlyingString = s,
                CurrentPosition = startIndex,
                EndPosition = endIndex,
                ComparisonType = StringComparison.Ordinal
            };
        }

        /// <summary>
        /// For internal use only. Initializes a new instance of the <see cref="StringReader"/> class.
        /// </summary>
        internal StringReader() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringReader"/> class.
        /// </summary>
        /// <param name="s">The string instance to read.</param>
        /// <param name="comparisonType">Specifies a <see cref="StringComparison"/> value for string comparisons in various methods of the <see cref="StringReader"/> class.</param>
        public StringReader(string s, StringComparison comparisonType)
        {
            UnderlyingString = s;
            EndPosition = s.Length;
            ComparisonType = comparisonType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringReader"/> class from a <see cref="StringReader"/> instance. This constructor copies <see cref="UnderlyingString"/>, <see cref="CurrentPosition"/>, <see cref="EndPosition"/> and <see cref="ComparisonType"/> of <paramref name="anotherReader"/> to the new instance, but does not copy <see cref="MarkedPosition"/> property.
        /// </summary>
        /// <param name="anotherReader">Another <see cref="StringReader"/> instance.</param>
        public StringReader(StringReader anotherReader)
        {
            UnderlyingString = anotherReader.UnderlyingString;
            EndPosition = anotherReader.EndPosition;
            CurrentPosition = anotherReader.CurrentPosition;
            ComparisonType = anotherReader.ComparisonType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringReader"/> class.
        /// </summary>
        /// <param name="s">The string instance to read.</param>
        /// <param name="startIndex">
        /// Specifies the initial position of the reader.
        /// </param>
        /// <param name="length">
        /// Specifies the maximum number of characters this reader can read from its initial position.
        /// This argument together with <paramref name="startIndex"/> determines this reader's reading scope.
        /// </param>
        public StringReader(string s, int startIndex, int length)
        {
            var endIndex = ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, s.Length);
            UnderlyingString = s;
            CurrentPosition = startIndex;
            EndPosition = endIndex;
            ComparisonType = StringComparison.Ordinal;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringReader"/> class.
        /// </summary>
        /// <param name="s">The string instance to read.</param>
        /// <param name="startIndex">
        /// Specifies the initial position of the reader. 
        /// The reader's reading scope is from this initial position to the end of the underlying string.
        /// </param>
        public StringReader(string s, int startIndex = 0)
        {
            var strLen = s.Length;
            if (startIndex < 0 && startIndex >= strLen)
                throw new ArgumentOutOfRangeException(ExceptionHelper.GetArgumentOutOfRangeMessage("startIndex", 0, true, strLen, false));

            UnderlyingString = s;
            CurrentPosition = startIndex;
            EndPosition = strLen;
            ComparisonType = StringComparison.Ordinal;
        }

        #endregion
    }
}
