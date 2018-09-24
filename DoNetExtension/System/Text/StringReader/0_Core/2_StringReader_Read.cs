using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace System.Text
{
    public partial class StringReader
    {

        #region Advance


        /// <summary>
        /// Advances the reader's position to the next character if the reader's current reading scope is not empty.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Advance()
        {
            if (!EOF) ++CurrentPosition;
        }


        /// <summary>
        /// Adds an integer <paramref name="advance"/> to the reader's current position.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Advance(int advance)
        {
            var endPos = CurrentPosition + advance;
            if (endPos > EndPosition) endPos = EndPosition;
            else if (endPos < 0) endPos = 0;

            CurrentPosition = endPos;
        }

        /// <summary>
        /// Advances the reader to the position of the next non-whitespace character.
        /// </summary>
        public void AdvanceToNextNonWhiteSpace()
        {
            Advance();
            TrimStart();
        }

        /// <summary>
        /// Advances the reader's position to the next character if the reader's current reading scope is not empty.
        /// </summary>
        /// <returns><c>true</c> if the reader's current reading scope is not empty and the reader's position is advanced, <c>false</c> otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool AdvanceChar()
        {
            if (EOF) return false;
            else
            {
                ++CurrentPosition;
                return true;
            }
        }

        #endregion

        #region Read Char without ComparisonType

        /// <summary>
        /// If the current reading scope is non-empty (<see cref="EOF"/> is <c>false</c>), returns the character at the reader's current position and advances the reader's position to the next character; otherwise returns <c>'\0'</c>.
        /// </summary>
        /// <returns>The character at the reader's current position if the reader's current reading scope is not empty; '\0' if the reader has reached the end of the reading scope.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public char Read()
        {
            if (EOF) return '\0';
            var readChar = First;
            ++CurrentPosition;
            return readChar;

        }

        /// <summary>
        /// If the current reading scope is non-empty (<see cref="EOF"/> is <c>false</c>), reads the character at the reader's current position to <paramref name="c"/>, advances the reader's position to the next character and retruns <c>true</c>; otherwise, returns <c>false</c> and <paramref name="c"/> is set '\0'.
        /// </summary>
        /// <param name="c">The character at the reader's current position if the reader's current reading scope is not empty; '\0' if the reader has reached the end of the reading scope.</param>
        /// <returns><c>true</c> if the reader's current reading scope is not empty; <c>false</c> otherwise.</returns>
        public bool Read(out char c)
        {
            if (EOF)
            {
                c = '\0';
                return false;
            }
            c = First;
            ++CurrentPosition;

            return true;
        }

        /// <summary>
        /// Determines whether the <paramref name="keyChr"/> character equals the first character (first non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>) of the reader's reading scope without considering <see cref="ComparisonType"/>.
        /// If so, the reader advances to the next character; otherwise, the reader remains where it was if <paramref name="ignoreWhiteSpaces"/> is set <c>false</c>, or the reader stops at the first non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>.
        /// </summary>
        /// <param name="keyChr">The character to be compared with the first character (first non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>) of the reader's reading scope.</param>
        /// <param name="ignoreWhiteSpaces">If set to <c>true</c>, the white spaces at the beginning of the reader's current reading scope will be ignored.</param>
        /// <returns>
        ///   <c>true</c> if the target character equals the first character (first non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>) of the reader's reading scope; otherwise, <c>false</c>.
        /// </returns>
        public bool Read(char keyChr, bool ignoreWhiteSpaces = true)
        {
            if (ignoreWhiteSpaces) TrimStart();
            if (EOF) return false;
            if (UnderlyingString[CurrentPosition] == keyChr)
            {
                ++CurrentPosition;
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Determines whether the first character (first non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>) of the reader's reading scope is in the specified <paramref name="keyChrs"/> without considering <see cref="ComparisonType"/>.
        /// If so, the reader advances to the next character; otherwise, the reader remains where it was if <paramref name="ignoreWhiteSpaces"/> is set <c>false</c>, or the reader stops at the first non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>.
        /// </summary>
        /// <param name="keyChrs">The characters to check against the first character (first non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>) of the reader's reading scope.</param>
        /// <param name="ignoreWhiteSpaces">If set to <c>true</c>, the white spaces at the beginning of the reader's current reading scope will be ignored.</param>
        /// <returns>
        /// The index of the first character (first non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>) in the array <paramref name="keyChrs"/>; or -1 if none of <paramref name="keyChrs"/> is encountered.
        /// </returns>
        public int Read(char[] keyChrs, bool ignoreWhiteSpaces = true)
        {
            if (ignoreWhiteSpaces) TrimStart();
            if (EOF) return -1;
            var curr = UnderlyingString[CurrentPosition];

            for (int i = 0, j = keyChrs.Length; i < j; ++i)
            {
                var target = keyChrs[i];
                if (curr == target)
                {
                    ++CurrentPosition;
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Reads the non-letter and non-digit character (defined by <see cref="Char.IsLetterOrDigit(char)"/>) at the reader's current position (<see cref="First"/>) and advances the reader's position to the next character. If <see cref="First"/> is a letter or digit, the reader remains where it was.
        /// </summary>
        /// <returns><c>true</c> if the character at the reader's current position is a letter or digit; otherwise, <c>false</c>.</returns>
        public bool ReadNonLetterOrDigit()
        {
            if (!EOF && !First.IsLetterOrDigit())
            {
                ++CurrentPosition;
                return true;
            }
            else return false;
        }



        /// <summary>
        /// Tries reading the whitespace character (defined by <see cref="Char.IsWhiteSpace(char)"/>) at the reader's current position (<see cref="First"/>) and advances the reader's position to the next character. If <see cref="First"/> is not a whitespace, the reader remains where it was.
        /// </summary>
        /// <returns><c>true</c> if the character at the reader's current position is a white space; otherwise, <c>false</c>.</returns>
        public bool ReadWhiteSpace()
        {
            if (!EOF && First.IsWhiteSpace())
            {
                ++CurrentPosition;
                return true;
            }
            else return false;
        }


        /// <summary>
        /// Tries reading the whitespace character (defined by <see cref="Char.IsWhiteSpace(char)" />) at the reader's current position (<see cref="First" />), returns the whitespace character, and advances the reader's position to the next character. If <see cref="First" /> is not a whitespace, the reader remains where it was.
        /// </summary>
        /// <param name="whitespace">Returns the whitespace character if there is one at the beginning of the reading scope.</param>
        /// <returns>
        ///   <c>true</c> if the character at the reader's current position is a white space; otherwise, <c>false</c>.
        /// </returns>
        public bool ReadWhiteSpace(out char whitespace)
        {
            if (!EOF && First.IsWhiteSpace())
            {
                whitespace = First;
                ++CurrentPosition;
                return true;
            }

            whitespace = '\0';
            return false;
        }

        /// <summary>
        /// Tries reading a number of whitespace characters (defined by <see cref="Char.IsWhiteSpace(char)" />) at the beginning of the current reading scope; if successful, the reader advances; otherwise the reader keeps its current position and returns <c>false</c>
        /// </summary>
        /// <param name="len">The number of white spaces expected to be at the beginning of the reading scope.</param>
        /// <param name="breaksOnNewLine">if set to <c>true</c>, then breaks the white space reading on a new line character.</param>
        /// <returns>
        ///   <c>true</c> if the specified number of white spaces exist at the beginning of the current reading scope; otherwise, false.
        /// </returns>
        public bool ReadWhiteSpace(int len, bool breaksOnNewLine = true)
        {
            var spaces = new char[len];
            var currPosBackup = CurrentPosition;
            for (var i = 0; i < len; ++i)
            {
                if (EOF || (breaksOnNewLine && First.In(Environment.NewLine)) || First.IsNotWhiteSpace())
                {
                    CurrentPosition = currPosBackup;
                    return false;
                }

                spaces[i] = First;
                ++CurrentPosition;
            }

            return true;
        }

        /// <summary>
        /// Tries reading a number of whitespace characters (defined by <see cref="Char.IsWhiteSpace(char)" />) at the beginning of the current reading scope; if successful, the reader advances and returns the whiite spaces; otherwise the reader keeps its current position and returns <c>false</c>.
        /// </summary>
        /// <param name="len">The number of white spaces expected to read.</param>
        /// <param name="whitespace">Returns a string consisting of the white spaces.</param>
        /// <param name="breaksOnNewLine">if set to <c>true</c>, then breaks the white space reading on a new line character.</param>
        /// <returns>
        ///   <c>true</c> if the specified number of white spaces exist at the beginning of the current reading scope; otherwise, false.
        /// </returns>
        public bool ReadWhiteSpace(int len, out string whitespace, bool breaksOnNewLine = true)
        {
            var spaces = new char[len];
            var currPosBackup = CurrentPosition;
            for (var i = 0; i < len; ++i)
            {
                if (EOF || (breaksOnNewLine && First.In(Environment.NewLine)) || First.IsNotWhiteSpace())
                {
                    CurrentPosition = currPosBackup;
                    whitespace = null;
                    return false;
                }

                spaces[i] = First;
                ++CurrentPosition;
            }

            whitespace = new string(spaces);
            return true;
        }




        #endregion

        #region ReadTo Char/Whitespace without ComparisonType

        string _innerSubstringForDoubleEscape(char keyChr, int escapeCount, int start, int length)
        {
            if (escapeCount == 0) return UnderlyingString.Substring(start, length);
            var output = new char[length - escapeCount];
            int i = 0;
            length += start;
            while (start < length) //length is used as "end"
            {
                if (UnderlyingString[start] == keyChr) //the non-escape keychar can only appear at the end
                {
                    start += 2;
                    output[i++] = keyChr;
                }
                else output[i++] = UnderlyingString[start++];
            }
            return new string(output);
        }

        /// <summary>
        /// Advances the reader and reads until a character specified by <paramref name="keychar" /> is encountered.
        /// The <see cref="CurrentPosition"/> after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keychar">The reader stops when this character is encountered.</param>
        /// <param name="doubleKeycharEscape">if set to <c>true</c>, an occurrence of double <paramref name="keychar"/> will be an escape of the <paramref name="keychar"/>. For example, if the <paramref name="keychar"/> is single quote <c>'</c>, then the double <c>'</c> in <c>'ab''cd'</c> is an escape of <c>'</c> if this parameter is set <c>true</c>.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>If <see cref="ReadOptions.ReadToEnd"/> is specified in <paramref name="options" />, then a substring starting from the current position of the reading scope to the position of the first occurrence of <paramref name="keychar" /> within the search scope when the keychar is found, or a substring starting from the current position of the reading scope to the end of the search scope if such character is not found. If <see cref="ReadOptions.ReadToEnd"/> is not specified, then <c>null</c> is returned if <paramref name="keychar"/> is not found.
        /// <para>If <see cref="ReadOptions.StopAfterKey"/> is specified, then the reader stops at the position after the encountered <paramref name="keychar" />; otherwise the reader stops at the position of the encountered <paramref name="keychar" />.</para>
        /// <para>The <paramref name="keychar" /> is not included in the returned substring if <see cref="ReadOptions.DiscardKey"/> is specified.</para>
        /// <para>The white spaces at the beginning of the substring will be trimmed if <see cref="ReadOptions.TrimStart"/> is specified, and the white spaces at the end of the substring will be trimmed if <see cref="ReadOptions.TrimEnd"/> is specified. <see cref="String.Empty" /> will be returned if the length of the substring after trim is 0.</para></returns>
        public string ReadTo(char keychar, bool doubleKeycharEscape, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey)
        {
            if (options.HasFlag(ReadOptions.TrimStart)) TrimStart();

            var start = CurrentPosition;
            var escapeCount = 0;
            while (true)
            {
                if (EOF)
                {
                    if (options.HasFlag(ReadOptions.ReadToEnd))
                    {
                        if (options.HasFlag(ReadOptions.TrimEnd)) TrimEnd();
                        return _innerSubstringForDoubleEscape(keychar, escapeCount, start, EndPosition);
                    }
                    else return null;
                }
                if (UnderlyingString[CurrentPosition] == keychar)
                {
                    ++CurrentPosition;
                    if (!doubleKeycharEscape || EOF || UnderlyingString[CurrentPosition] != keychar)
                    {
                        var length = CurrentPosition - start;
                        if (options.HasFlag(ReadOptions.DiscardKey))
                        {
                            --length;
                            if (options.HasFlag(ReadOptions.TrimEnd))
                            {
                                var tmpPos = CurrentPosition - 1;
                                while (length > 0 && UnderlyingString[tmpPos].IsWhiteSpace())
                                {
                                    --length;
                                    --tmpPos;
                                }
                            }
                        }
                        if (!options.HasFlag(ReadOptions.StopAfterKey)) --CurrentPosition;
                        if (length == 0) return string.Empty;
                        else return _innerSubstringForDoubleEscape(keychar, escapeCount, start, length);
                    }
                    else
                    {
                        ++escapeCount;
                        ++CurrentPosition;
                    }

                }
                else ++CurrentPosition;
            }
        }

        /// <summary>
        /// Advances the reader and reads until the first whitespace is encountered.
        /// The <see cref="CurrentPosition"/> after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>If <see cref="ReadOptions.ReadToEnd"/> is specified in <paramref name="options" />, then a substring starting from the current position of the reading scope to the position of the first whitespace within the search scope, or a substring starting from the current position of the reading scope to the end of the scope if no whitespace is found;
        /// If <see cref="ReadOptions.ReadToEnd"/> is not specified, then <c>null</c> is returned if no whitespace is found.
        /// <para>If <see cref="ReadOptions.StopAfterKey"/> is specified, then the reader stops at the position after the first whitespace; otherwise the reader stops at the position of the encountered whitespace.</para>
        /// <para>The whitespace is included in the returned substring if neither <see cref="ReadOptions.DiscardKey"/> nor <see cref="ReadOptions.TrimEnd"/> is specified.</para>
        /// <para>The whitespaces at the beginning of the returned substring will be trimmed if <see cref="ReadOptions.TrimStart"/> is specified; <see cref="String.Empty" /> will be returned if the length of the substring after trim is 0.</para></returns>
        public string ReadToWhiteSpace(ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            if (options.HasFlag(ReadOptions.TrimStart)) TrimStart();
            var start = CurrentPosition;
            while (true)
            {
                if (EOF)
                {
                    if (options.HasFlag(ReadOptions.ReadToEnd))
                        return UnderlyingString.Substring(start, CurrentPosition - start);
                    else return null;
                }

                var c = First;
                if (c.IsWhiteSpace())
                {
                    var length = CurrentPosition - start;
                    if (!options.HasFlag(ReadOptions.DiscardKey) && !options.HasFlag(ReadOptions.TrimEnd)) ++length;
                    if (options.HasFlag(ReadOptions.StopAfterKey)) Advance();
                    if (length == 0) return string.Empty;
                    else return UnderlyingString.Substring(start, length);

                }
                else ++CurrentPosition;
            }
        }

        /// <summary>
        /// Advances the reader and reads until the first whitespace or a character of <paramref name="keyChr"/> is encountered.
        /// The <see cref="CurrentPosition"/> after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keyChr">An additional character that can stop the reading.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>If <see cref="ReadOptions.ReadToEnd"/> is specified in <paramref name="options" />, then a substring starting from the current position of the reading scope to the position of the first whitespace or <paramref name="keyChr"/> within the search scope, or a substring starting from the current position of the reading scope to the end of the scope if neither whitespace nor <paramref name="keyChr"/> is found;
        /// If <see cref="ReadOptions.ReadToEnd"/> is not specified, then <c>null</c> is returned if neither whitespace nor <paramref name="keyChr"/> is found.
        /// <para>If <see cref="ReadOptions.StopAfterKey"/> is specified, then the reader stops at the position after the first whitespace; otherwise the reader stops at the position of the encountered whitespace or <paramref name="keyChr"/>.</para>
        /// <para>The whitespace or <paramref name="keyChr"/> is included in the returned substring if neither <see cref="ReadOptions.DiscardKey"/> nor <see cref="ReadOptions.TrimEnd"/> is specified.</para>
        /// <para>The whitespaces at the beginning of the returned substring will be trimmed if <see cref="ReadOptions.TrimStart"/> is specified; <see cref="String.Empty" /> will be returned if the length of the substring after trim is 0.</para></returns>
        public string ReadToWhiteSpaceOrChar(char keyChr, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            if (options.HasFlag(ReadOptions.TrimStart)) TrimStart();
            var start = CurrentPosition;
            while (true)
            {
                if (EOF)
                {
                    if (options.HasFlag(ReadOptions.ReadToEnd))
                        return UnderlyingString.Substring(start, CurrentPosition - start);
                    else return null;
                }

                var c = First;
                if (c.IsWhiteSpace() || c == keyChr)
                {
                    var length = CurrentPosition - start;
                    if (!options.HasFlag(ReadOptions.DiscardKey) && !options.HasFlag(ReadOptions.TrimEnd)) ++length;
                    if (options.HasFlag(ReadOptions.StopAfterKey)) Advance();
                    if (length == 0) return string.Empty;
                    else return UnderlyingString.Substring(start, length);

                }
                else ++CurrentPosition;
            }
        }

        /// <summary>
        /// Advances the reader and reads until the first whitespace or a character in <paramref name="keyChrs"/> is encountered.
        /// The <see cref="CurrentPosition"/> after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="keyChrs">Additional characters that can stop the reading.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>If <see cref="ReadOptions.ReadToEnd"/> is specified in <paramref name="options" />, then a substring starting from the current position of the reading scope to the position of the first whitespace or <paramref name="keyChrs"/> within the search scope, or a substring starting from the current position of the reading scope to the end of the scope if neither whitespace nor <paramref name="keyChrs"/> is found;
        /// If <see cref="ReadOptions.ReadToEnd"/> is not specified, then <c>null</c> is returned if neither whitespace nor a character in <paramref name="keyChrs"/> is found.
        /// <para>If <see cref="ReadOptions.StopAfterKey"/> is specified, then the reader stops at the position after the first whitespace; otherwise the reader stops at the position of the encountered whitespace or a character in <paramref name="keyChrs"/>.</para>
        /// <para>The whitespace or a character in <paramref name="keyChrs"/> is included in the returned substring if neither <see cref="ReadOptions.DiscardKey"/> nor <see cref="ReadOptions.TrimEnd"/> is specified.</para>
        /// <para>The whitespaces at the beginning of the returned substring will be trimmed if <see cref="ReadOptions.TrimStart"/> is specified; <see cref="String.Empty" /> will be returned if the length of the substring after trim is 0.</para></returns>
        public string ReadToWhiteSpaceOrChar(char[] keyChrs, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            if (options.HasFlag(ReadOptions.TrimStart)) TrimStart();
            var start = CurrentPosition;
            while (true)
            {
                if (EOF)
                {
                    if (options.HasFlag(ReadOptions.ReadToEnd))
                        return UnderlyingString.Substring(start, CurrentPosition - start);
                    else return null;
                }

                var c = First;
                if (c.IsWhiteSpace() || c.In(keyChrs))
                {
                    var length = CurrentPosition - start;
                    if (!options.HasFlag(ReadOptions.DiscardKey) && !options.HasFlag(ReadOptions.TrimEnd)) ++length;
                    if (options.HasFlag(ReadOptions.StopAfterKey)) Advance();
                    if (length == 0) return string.Empty;
                    else return UnderlyingString.Substring(start, length);

                }
                else ++CurrentPosition;
            }
        }

        #endregion

        #region Count Char without ComparisonType

        /// <summary>
        /// Counts the number of occurrences of the specified <paramref name="keyChr"/> character that appears at the beginning of the current reading scope until the first <paramref name="keyChr"/> character is encountered (first non-white-space non-<paramref name="keyChr"/> character if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>). The reader will advance the position to the non-<paramref name="keyChr"/> character that stops the counting.
        /// </summary>
        /// <param name="keyChr">The target character.</param>
        /// <param name="ignoreWhiteSpaces">If set to <c>true</c>, the white spaces at the beginning of the reader's current reading scope will be ignored.</param>
        /// <returns>The number of occurrences of the specified <paramref name="keyChr"/> character that appears at the beginning of the current reading scope.</returns>
        public int Count(char keyChr, bool ignoreWhiteSpaces = true)
        {
            int count = 0;
            while (true)
            {
                if (ignoreWhiteSpaces) TrimStart();
                if (EOF) return count;
                if (UnderlyingString[CurrentPosition] == keyChr)
                {
                    ++CurrentPosition;
                    ++count;
                }
                else return count;
            }
        }

        #endregion

        #region Read Char with ComparisonType

        /// <summary>
        /// Determines whether the <paramref name="keyChr"/> character equals the first character (first non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>) of the reader's reading scope, considering <see cref="ComparisonType"/>.
        /// If so, the reader advances to the next character; otherwise, the reader remains where it was if <paramref name="ignoreWhiteSpaces"/> is set <c>false</c>, or the reader stops at the first non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>.
        /// </summary>
        /// <param name="keyChr">The target character.</param>
        /// <param name="ignoreWhiteSpaces">If set to <c>true</c>, the white spaces at the beginning of the reader's current reading scope will be ignored.</param>
        /// <returns>
        ///   <c>true</c> if the target character equals the first character (first non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>) of the reader's reading scope when considering <see cref="ComparisonType"/>; otherwise, <c>false</c>.
        /// </returns>
        public bool ReadChar(char keyChr, bool ignoreWhiteSpaces = true)
        {
            if (ignoreWhiteSpaces) TrimStart();
            if (EOF) return false;
            if (UnderlyingString[CurrentPosition].ToString().Equals(keyChr.ToString(), ComparisonType))
            {
                ++CurrentPosition;
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Determines whether the first character (first non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>) of the reader's reading scope is in the specified <paramref name="keyChrs"/>.
        /// If so, the reader advances to the next character; otherwise, the reader remains where it was if <paramref name="ignoreWhiteSpaces"/> is set <c>false</c>, or the reader stops at the first non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>.
        /// </summary>
        /// <param name="keyChrs">The characters to check against the first character (first non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>) of the reader's reading scope.</param>
        /// <param name="ignoreWhiteSpaces">If set to <c>true</c>, the white spaces at the beginning of the reader's current reading scope will be ignored.</param>
        /// <returns>
        /// The index of the first character (first non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>) in the array <paramref name="keyChrs"/>; or -1 if none of <paramref name="keyChrs"/> is encountered.
        /// </returns>
        public int ReadChar(char[] keyChrs, bool ignoreWhiteSpaces = true)
        {
            if (ignoreWhiteSpaces) TrimStart();
            if (EOF) return -1;
            var curr = UnderlyingString[CurrentPosition].ToString();

            for (int i = 0, j = keyChrs.Length; i < j; ++i)
            {
                var target = keyChrs[i].ToString();
                if (curr.Equals(target, ComparisonType))
                {
                    ++CurrentPosition;
                    return i;
                }
            }

            return -1;
        }

        #endregion

        #region Read String without ComparisonType


        /// <summary>
        /// Determines whether a substring specified by <paramref name="keyStr" /> is at the reader's current position without considering <see cref="ComparisonType"/> (equivalent to <see cref="StringComparison.Ordinal"/>).
        /// If so, the reader advances to the end of this substring; otherwise, the reader remains where it was.
        /// </summary>
        /// <param name="keyStr">The target substring.</param>
        /// <param name="ignoreWhiteSpaces">If set to <c>true</c>, the white spaces at the beginning of the reader's current reading scope will be ignored.</param>
        /// <returns><c>true</c> if the target substring is at the reader's current position (with white spaces ignored if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>) and the reader has advanced to the end of this substring;
        /// otherwise, <c>false</c>.</returns>
        public bool Read(string keyStr, bool ignoreWhiteSpaces = true)
        {
            var i = ignoreWhiteSpaces ? _ignoreSpacesAtTheBeginning() : CurrentPosition;
            if (i != -1 && UnderlyingString.StartsWith(i, keyStr, StringComparison.Ordinal))
            {
                CurrentPosition = i + keyStr.Length;
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Determines whether one of the substrings specified by <paramref name="keyStrs" /> is at the reader's current position without considering <see cref="ComparisonType" /> (equivalent to <see cref="StringComparison.Ordinal" />). If so, the reader advances to the end of this substring and returns the index of the hit substring; otherwise, the reader remains where it was and returns <c>-1</c>.
        /// </summary>
        /// <param name="keyStrs">The target substrings.</param>
        /// <param name="index">Substring in <paramref name="keyStrs"/> starting at and after this index are matched against the beginning of the reader's current reading scope.</param>
        /// <param name="ignoreWhiteSpaces">If set to <c>true</c>, the white spaces at the beginning of the reader's current reading scope will be ignored.</param>
        /// <returns>The index of matched key substring if one of <paramref name="keyStrs" /> is at the reader's current position (with white spaces ignored if <paramref name="ignoreWhiteSpaces" /> is set <c>true</c>) and the reader has advanced to the end of this substring;
        /// otherwise, <c>-1</c>.</returns>
        public int Read(string[] keyStrs, int index = 0, bool ignoreWhiteSpaces = true)
        {
            var i = ignoreWhiteSpaces ? _ignoreSpacesAtTheBeginning() : CurrentPosition;
            var targetCount = keyStrs.Length;
            while (index < targetCount)
            {
                var target = keyStrs[index];
                if (UnderlyingString.StartsWith(i, target, StringComparison.OrdinalIgnoreCase))
                {
                    i += target.Length;
                    CurrentPosition = i;
                    return index;
                }
                ++index;
            }

            return -1;
        }

        /// <summary>
        /// Determines whether a substring specified by <paramref name="keyStr" /> is at the reader's current position without considering both case and <see cref="ComparisonType"/> (equivalent to <see cref="StringComparison.OrdinalIgnoreCase"/>).
        /// <para>If so, the reader advances to the end of this substring; otherwise, the reader remains where it was.</para>
        /// </summary>
        /// <param name="keyStr">The target substring.</param>
        /// <param name="ignoreWhiteSpaces">If set to <c>true</c>, the white spaces at the beginning of the reader's current reading scope will be ignored.</param>
        /// <returns><c>true</c> if the target substring is at the reader's current position (with white spaces ignored if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>) and the reader has advanced to the end of this substring;
        /// otherwise, <c>false</c>.</returns>
        public bool ReadIgCase(string keyStr, bool ignoreWhiteSpaces = true)
        {
            var i = ignoreWhiteSpaces ? _ignoreSpacesAtTheBeginning() : CurrentPosition;
            if (i != -1 && UnderlyingString.StartsWith(i, keyStr, StringComparison.OrdinalIgnoreCase))
            {
                CurrentPosition = i + keyStr.Length;
                return true;
            }
            else return false;
        }


        /// <summary>
        /// Determines whether one of the substrings specified by <paramref name="keyStrs" /> is at the reader's current position without considering both case and <see cref="ComparisonType" /> (equivalent to <see cref="StringComparison.OrdinalIgnoreCase" />).
        /// <para>If so, the reader advances to the end of this substring and returns the index of the hit substring; otherwise, the reader remains where it was.</para>
        /// </summary>
        /// <param name="keyStrs">The target substrings.</param>
        /// <param name="index">Substring in <paramref name="keyStrs"/> starting at and after this index are matched against the beginning of the reader's current reading scope.</param>
        /// <param name="ignoreWhiteSpaces">If set to <c>true</c>, the white spaces at the beginning of the reader's current reading scope will be ignored.</param>
        /// <returns><c>true</c> if one of <paramref name="keyStrs" /> is at the reader's current position (with white spaces ignored if <paramref name="ignoreWhiteSpaces" /> is set <c>true</c>) and the reader has advanced to the end of this substring;
        /// otherwise, <c>false</c>.</returns>
        public int ReadIgCase(string[] keyStrs, int index = 0, bool ignoreWhiteSpaces = true)
        {
            var i = ignoreWhiteSpaces ? _ignoreSpacesAtTheBeginning() : CurrentPosition;
            var targetCount = keyStrs.Length;
            while (index < targetCount)
            {
                var target = keyStrs[index];
                if (UnderlyingString.StartsWith(i, target, StringComparison.OrdinalIgnoreCase))
                {
                    i += target.Length;
                    CurrentPosition = i;
                    return index;
                }
                ++index;
            }

            return -1;
        }

        #endregion

        #region Read String with ComparisonType

        int _ignoreSpacesAtTheBeginning()
        {
            var i = CurrentPosition;
            while (UnderlyingString[i].IsWhiteSpace())
            {
                ++i;
                if (i == EndPosition) return -1;
            }
            return i;
        }

        /*
        int _ignoreSpacesAtTheEnd()
        {
            var i = EndPosition - 1;
            while (UnderlyingString[i].IsWhiteSpace())
            {
                if (i == CurrentPosition) return -1;
                --i;
            }
            return i;
        } */

        /// <summary>
        /// Determines whether a substring specified by <paramref name="keyStr" /> is at the reader's current position.
        /// If so, the reader advances to the end of this substring; otherwise, the reader remains where it was.
        /// </summary>
        /// <param name="keyStr">The target substring.</param>
        /// <param name="ignoreWhiteSpaces">If set to <c>true</c>, the white spaces at the beginning of the reader's current reading scope will be ignored.</param>
        /// <returns><c>true</c> if the target substring is at the reader's current position (with white spaces ignored if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>) and the reader has advanced to the end of this substring;
        /// otherwise, <c>false</c>.</returns>
        public bool ReadString(string keyStr, bool ignoreWhiteSpaces = true)
        {
            var i = ignoreWhiteSpaces ? _ignoreSpacesAtTheBeginning() : CurrentPosition;
            if (i != -1 && UnderlyingString.StartsWith(i, keyStr, ComparisonType))
            {
                CurrentPosition = i + keyStr.Length;
                return true;
            }
            else return false;
        }

        #endregion

        #region Count Char with ComparisonType

        /// <summary>
        /// Counts the number of occurrences of the specified <paramref name="keyChr"/> character that appears at the beginning of the current reading scope until the first <paramref name="keyChr"/> character is encountered (first non-white-space non-<paramref name="keyChr"/> character if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>). Comparison of characters will consider <see cref="ComparisonType"/>. The reader will advance the position to the non-<paramref name="keyChr"/> character that stops the counting.
        /// </summary>
        /// <param name="keyChr">The target character.</param>
        /// <param name="ignoreWhiteSpaces">If set to <c>true</c>, the white spaces at the beginning of the reader's current reading scope will be ignored.</param>
        /// <returns>The number of occurrences of the specified <paramref name="keyChr"/> character that appears at the beginning of the current reading scope, considering <see cref="ComparisonType"/>.</returns>
        public int CountChar(char keyChr, bool ignoreWhiteSpaces = true)
        {
            int count = 0;
            var targetStr = keyChr.ToString();
            while (true)
            {
                if (ignoreWhiteSpaces) TrimStart();
                if (EOF) return count;
                if (UnderlyingString[CurrentPosition].ToString().Equals(targetStr, ComparisonType))
                {
                    ++CurrentPosition;
                    ++count;
                }
                else return count;
            }
        }

        #endregion

        #region Read Char by Predicate

        /// <summary>
        /// Determines whether the first character (first non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>) of the reader's reading scope satisfies the specified <paramref name="predicate"/>.
        /// If so, the reader advances to the next character; otherwise, the reader remains where it was if <paramref name="ignoreWhiteSpaces"/> is set <c>false</c>, or the reader stops at the first non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>.
        /// </summary>
        /// <param name="predicate">The predicate to check against the first character (first non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>) of the reader's reading scope.</param>
        /// <param name="ignoreWhiteSpaces">If set to <c>true</c>, the white spaces at the beginning of the reader's current reading scope will be ignored.</param>
        /// <returns>
        /// If the first character (first non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>) of the reader's reading scope satisfies the specified <paramref name="predicate"/>, then this method returns that character; otherwise, this method returns '\0'.
        /// </returns>
        public char ReadChar(Func<char, bool> predicate, bool ignoreWhiteSpaces = true)
        {
            if (ignoreWhiteSpaces) TrimStart();
            if (EOF) return '\0';

            var c = UnderlyingString[CurrentPosition];
            if (predicate(c))
            {
                ++CurrentPosition;
                return c;
            }

            return '\0';
        }

        #endregion

        #region Read String by Predicate

        /// <summary>
        /// Advances the reader and reads consecutive characters satisfying a specified <paramref name="predicate"/>.
        /// The read will stop at the first encountered character that does not satisfy the <paramref name="predicate"/>.
        /// </summary>
        /// <param name="predicate">A method used to test each character.</param>
        /// <returns>A string instance consists of consecutive characters satisfying the specified <paramref name="predicate"/>.</returns>
        public string ReadString(Func<char, bool> predicate)
        {
            var sb = new StringBuilder();
            for (; CurrentPosition < EndPosition; ++CurrentPosition)
            {
                var c = UnderlyingString[CurrentPosition];
                if (predicate(c)) sb.Append(c);
                else break;
            }
            return sb.ToString();
        }

        #endregion

        #region Read Word without ComparisonType

        /// <summary>
        /// If the reader's current reading scope starts with <paramref name="keyWord" /> followed by either <see cref="EOF" /> or a <paramref name="keyChr" />, then reads <paramref name="keyWord" /> from the beginning of the current reading scope and advances the reader to the character at or after <paramref name="keyChr" /> (depending on <paramref name="stopAfterWordSeparator"/>), without considering <see cref="ComparisonType" /> (equivalent to <see cref="StringComparison.Ordinal" />).
        /// </summary>
        /// <param name="keyWord">The target substring.</param>
        /// <param name="keyChr">The <paramref name="keyWord"/> is expected to be followed by this character.</param>
        /// <param name="ignoreWhiteSpaces">If set to <c>true</c>, the white spaces at the beginning of the reader's current reading scope will be ignored.</param>
        /// <param name="stopAfterWordSeparator">If set to <c>true</c>, the reader stops after <paramref name="keyChr"/> if the reading is successful; otherwise, the reader stops at <paramref name="keyChr"/> if the reading is successful.</param>
        /// <returns><c>true</c> if the reader's current reading scope starts with <paramref name="keyWord" /> followed by <paramref name="keyChr"/>, <c>false</c> otherwise.</returns>
        public bool Read(string keyWord, char keyChr, bool ignoreWhiteSpaces = true, bool stopAfterWordSeparator = true)
        {
            var currPos = CurrentPosition;
            if (Read(keyWord, ignoreWhiteSpaces) && (EOF || (stopAfterWordSeparator && Read(keyChr, false)) || (!stopAfterWordSeparator && First == keyChr))) return true;

            CurrentPosition = currPos;
            return false;
        }

        /// <summary>
        /// If the reader's current reading scope starts with <paramref name="keyWord" /> followed by either <see cref="EOF" /> or a <paramref name="keyChr" />, then reads <paramref name="keyWord" /> from the beginning of the current reading scope and advances the reader to the character at or after <paramref name="keyChr" /> (depending on <paramref name="stopAfterWordSeparator"/>), without considering both case and <see cref="ComparisonType" /> (equivalent to <see cref="StringComparison.OrdinalIgnoreCase" />).
        /// </summary>
        /// <param name="keyWord">The target substring.</param>
        /// <param name="keyChr">The <paramref name="keyWord"/> is expected to be followed by this character.</param>
        /// <param name="ignoreWhiteSpaces">If set to <c>true</c>, the white spaces at the beginning of the reader's current reading scope will be ignored.</param>
        /// <param name="stopAfterWordSeparator">If set to <c>true</c>, the reader stops after <paramref name="keyChr"/> if the reading is successful; otherwise, the reader stops at <paramref name="keyChr"/> if the reading is successful.</param>
        /// <returns><c>true</c> if the reader's current reading scope starts with <paramref name="keyWord" /> followed by <paramref name="keyChr"/>, <c>false</c> otherwise.</returns>
        public bool ReadIgCase(string keyWord, char keyChr, bool ignoreWhiteSpaces = true, bool stopAfterWordSeparator = true)
        {
            var currPos = CurrentPosition;
            if (ReadIgCase(keyWord, ignoreWhiteSpaces) && (EOF || (stopAfterWordSeparator && Read(keyChr, false)) || (!stopAfterWordSeparator && First == keyChr))) return true;

            CurrentPosition = currPos;
            return false;
        }

        /// <summary>
        /// If the reader's current reading scope starts with <paramref name="keyWord" /> followed by either <see cref="EOF" /> or character satisfying <paramref name="isWordSeparator" />, then reads <paramref name="keyWord" /> from the beginning of the current reading scope and advances the reader to the character at or after the character satisfying <paramref name="isWordSeparator" /> (depending on <paramref name="stopAfterWordSeparator"/>), without considering <see cref="ComparisonType" /> (equivalent to <see cref="StringComparison.Ordinal" />).
        /// </summary>
        /// <param name="keyWord">The target substring.</param>
        /// <param name="isWordSeparator">A predicate that defines what characters are expected to follow <paramref name="keyWord"/>.</param>
        /// <param name="ignoreWhiteSpaces">If set to <c>true</c>, the white spaces at the beginning of the reader's current reading scope will be ignored.</param>
        /// <param name="stopAfterWordSeparator">If set to <c>true</c>, the reader stops after the character defined by <paramref name="isWordSeparator"/> if the reading is successful; otherwise, the reader stops at the character satisfying <paramref name="isWordSeparator"/> if the reading is successful.</param>
        /// <returns><c>true</c> if the reader's current reading scope starts with <paramref name="keyWord" /> followed by a characater defined by <paramref name="isWordSeparator"/>, <c>false</c> otherwise.</returns>
        public bool Read(string keyWord, Func<char, bool> isWordSeparator, bool ignoreWhiteSpaces = true, bool stopAfterWordSeparator = true)
        {
            var currPos = CurrentPosition;
            if (Read(keyWord, ignoreWhiteSpaces) && (EOF || (stopAfterWordSeparator && ReadChar(isWordSeparator, false) != '\0') || (!stopAfterWordSeparator && isWordSeparator(First)))) return true;

            CurrentPosition = currPos;
            return false;
        }

        /// <summary>
        /// If the reader's current reading scope starts with <paramref name="keyWord" /> followed by either <see cref="EOF" /> or character satisfying <paramref name="isWordSeparator" />, then reads <paramref name="keyWord" /> from the beginning of the current reading scope and advances the reader to the character at or after the character satisfying <paramref name="isWordSeparator" /> (depending on <paramref name="stopAfterWordSeparator"/>), without considering both case and <see cref="ComparisonType" /> (equivalent to <see cref="StringComparison.OrdinalIgnoreCase" />).
        /// </summary>
        /// <param name="keyWord">The target substring.</param>
        /// <param name="isWordSeparator">A predicate that defines what characters are expected to follow <paramref name="keyWord"/>.</param>
        /// <param name="ignoreWhiteSpaces">If set to <c>true</c>, the white spaces at the beginning of the reader's current reading scope will be ignored.</param>
        /// <param name="stopAfterWordSeparator">If set to <c>true</c>, the reader stops after the character defined by <paramref name="isWordSeparator"/> if the reading is successful; otherwise, the reader stops at the character satisfying <paramref name="isWordSeparator"/> if the reading is successful.</param>
        /// <returns><c>true</c> if the reader's current reading scope starts with <paramref name="keyWord" /> followed by a characater defined by <paramref name="isWordSeparator"/>, <c>false</c> otherwise.</returns>
        public bool ReadIgCase(string keyWord, Func<char, bool> isWordSeparator, bool ignoreWhiteSpaces = true, bool stopAfterWordSeparator = true)
        {
            var currPos = CurrentPosition;
            if (ReadIgCase(keyWord, ignoreWhiteSpaces) && (EOF || (stopAfterWordSeparator && ReadChar(isWordSeparator, false) != '\0') || (!stopAfterWordSeparator && isWordSeparator(First)))) return true;

            CurrentPosition = currPos;
            return false;
        }

        /// <summary>
        /// If the reader's current reading scope starts with <paramref name="keyWord" /> followed by either <see cref="EOF" /> or a non-letter non-digit character (defined by <see cref="Char.IsLetterOrDigit(char)" />), then reads <paramref name="keyWord" /> from the beginning of the current reading scope and advances the reader to the character after the non-letter non-digit character, without considering <see cref="ComparisonType" /> (equivalent to <see cref="StringComparison.Ordinal" />).
        /// </summary>
        /// <param name="keyWord">The target substring.</param>
        /// <param name="ignoreWhiteSpaces">If set to <c>true</c>, the white spaces at the beginning of the reader's current reading scope will be ignored.</param>
        /// <param name="stopAfterWordSeparator">If set to <c>true</c>, the reader stops after non-letter non-digit character if the reading is successful; otherwise, the reader stops at the non-letter non-digit if the reading is successful.</param>
        /// <returns><c>true</c> if the reader's current reading scope starts with <paramref name="keyWord" /> followed by a non-letter non-digit character, <c>false</c> otherwise.</returns>
        public bool ReadFollowedByNonLetterOrDigit(string keyWord, bool ignoreWhiteSpaces = true, bool stopAfterWordSeparator = true)
        {
            var currPos = CurrentPosition;
            if (Read(keyWord, ignoreWhiteSpaces) && (EOF || (stopAfterWordSeparator && ReadNonLetterOrDigit()) || (!stopAfterWordSeparator && !First.IsLetterOrDigit())))
                return true;

            CurrentPosition = currPos;
            return false;

        }

        /// <summary>
        /// If the reader's current reading scope starts with <paramref name="keyWord" /> followed by either <see cref="EOF" /> or a non-letter non-digit character (defined by <see cref="Char.IsLetterOrDigit(char)" />), then reads <paramref name="keyWord" /> from the beginning of the current reading scope and advances the reader to the character after the non-letter non-digit character, without considering both case and <see cref="ComparisonType" /> (equivalent to <see cref="StringComparison.OrdinalIgnoreCase" />).
        /// </summary>
        /// <param name="keyWord">The target substring.</param>
        /// <param name="ignoreWhiteSpaces">If set to <c>true</c>, the white spaces at the beginning of the reader's current reading scope will be ignored.</param>
        /// <param name="stopAfterWordSeparator">If set to <c>true</c>, the reader stops after non-letter non-digit character if the reading is successful; otherwise, the reader stops at the non-letter non-digit if the reading is successful.</param>
        /// <returns><c>true</c> if the reader's current reading scope starts with <paramref name="keyWord" /> followed by a non-letter non-digit character, <c>false</c> otherwise.</returns>
        public bool ReadIgCaseFollowedByNonLetterOrDigit(string keyWord, bool ignoreWhiteSpaces = true, bool stopAfterWordSeparator = true)
        {
            var currPos = CurrentPosition;
            if (ReadIgCase(keyWord, ignoreWhiteSpaces) && (EOF || (stopAfterWordSeparator && ReadNonLetterOrDigit()) || (!stopAfterWordSeparator && !First.IsLetterOrDigit())))
                return true;

            CurrentPosition = currPos;
            return false;

        }

        /// <summary>
        /// If the reader's current reading scope starts with <paramref name="keyWord"/> followed by either <see cref="EOF"/> or a whitespace character (defined by <see cref="Char.IsLetterOrDigit(char)"/>), then reads <paramref name="keyWord"/> from the beginning of the current reading scope and advances the reader to the character after the whitespace character, without considering <see cref="ComparisonType"/> (equivalent to <see cref="StringComparison.Ordinal"/>).
        /// </summary>
        /// <param name="keyWord">The target substring.</param>
        /// <param name="ignoreWhiteSpaces">If set to <c>true</c>, the white spaces at the beginning of the reader's current reading scope will be ignored.</param>
        /// <returns><c>true</c> if the reader's current reading scope starts with <paramref name="keyWord"/> followed by a whitespace character, <c>false</c> otherwise.</returns>
        public bool ReadFollowedByWhiteSpace(string keyWord, bool ignoreWhiteSpaces = true)
        {
            var currPos = CurrentPosition;
            if (Read(keyWord, ignoreWhiteSpaces) && (EOF || ReadWhiteSpace()))
                return true;

            CurrentPosition = currPos;
            return false;
        }

        /// <summary>
        /// If the reader's current reading scope starts with <paramref name="keyWord"/> followed by either <see cref="EOF"/> or a whitespace character (defined by <see cref="Char.IsLetterOrDigit(char)"/>), then reads <paramref name="keyWord"/> from the beginning of the current reading scope and advances the reader to the character after the whitespace character, without considering both case and <see cref="ComparisonType"/> (equivalent to <see cref="StringComparison.OrdinalIgnoreCase"/>).
        /// </summary>
        /// <param name="keyWord">The target substring.</param>
        /// <param name="ignoreWhiteSpaces">If set to <c>true</c>, the white spaces at the beginning of the reader's current reading scope will be ignored.</param>
        /// <returns><c>true</c> if the reader's current reading scope starts with <paramref name="keyWord"/> followed by a whitespace character, <c>false</c> otherwise.</returns>
        public bool ReadIgCaseFollowedByWhiteSpace(string keyWord, bool ignoreWhiteSpaces = true)
        {
            var currPos = CurrentPosition;
            if (ReadIgCase(keyWord, ignoreWhiteSpaces) && (EOF || ReadWhiteSpace()))
                return true;

            CurrentPosition = currPos;
            return false;
        }

        #endregion

        #region Read Word with ComparisonType

        /// <summary>
        /// If the reader's current reading scope starts with <paramref name="keyWord" /> followed by either <see cref="EOF" /> or a <paramref name="keyChr" />, then reads <paramref name="keyWord" /> from the beginning of the current reading scope and advances the reader to the character at or after <paramref name="keyChr" /> (depending on <paramref name="stopAfterWordSeparator"/>).
        /// </summary>
        /// <param name="keyWord">The target substring.</param>
        /// <param name="keyChr">The <paramref name="keyWord"/> is expected to be followed by this character.</param>
        /// <param name="ignoreWhiteSpaces">If set to <c>true</c>, the white spaces at the beginning of the reader's current reading scope will be ignored.</param>
        /// <param name="stopAfterWordSeparator">If set to <c>true</c>, the reader stops after <paramref name="keyChr"/> if the reading is successful; otherwise, the reader stops at <paramref name="keyChr"/> if the reading is successful.</param>
        /// <returns><c>true</c> if the reader's current reading scope starts with <paramref name="keyWord" /> followed by <paramref name="keyChr"/>, <c>false</c> otherwise.</returns>
        public bool ReadString(string keyWord, char keyChr, bool ignoreWhiteSpaces = true, bool stopAfterWordSeparator = true)
        {
            var currPos = CurrentPosition;
            if (ReadString(keyWord, ignoreWhiteSpaces) && (EOF || (stopAfterWordSeparator && Read(keyChr, false)) || (!stopAfterWordSeparator && First == keyChr))) return true;

            CurrentPosition = currPos;
            return false;
        }

        /// <summary>
        /// If the reader's current reading scope starts with <paramref name="keyWord" /> followed by either <see cref="EOF" /> or character satisfying <paramref name="isWordSeparator" />, then reads <paramref name="keyWord" /> from the beginning of the current reading scope and advances the reader to the character at or after the character satisfying <paramref name="isWordSeparator" /> (depending on <paramref name="stopAfterWordSeparator"/>).
        /// </summary>
        /// <param name="keyWord">The target substring.</param>
        /// <param name="isWordSeparator">A predicate that defines what characters are expected to follow <paramref name="keyWord"/>.</param>
        /// <param name="ignoreWhiteSpaces">If set to <c>true</c>, the white spaces at the beginning of the reader's current reading scope will be ignored.</param>
        /// <param name="stopAfterWordSeparator">If set to <c>true</c>, the reader stops after the character defined by <paramref name="isWordSeparator"/> if the reading is successful; otherwise, the reader stops at the character satisfying <paramref name="isWordSeparator"/> if the reading is successful.</param>
        /// <returns><c>true</c> if the reader's current reading scope starts with <paramref name="keyWord" /> followed by a characater defined by <paramref name="isWordSeparator"/>, <c>false</c> otherwise.</returns>
        public bool ReadString(string keyWord, Func<char, bool> isWordSeparator, bool ignoreWhiteSpaces = true, bool stopAfterWordSeparator = true)
        {
            var currPos = CurrentPosition;
            if (ReadString(keyWord, ignoreWhiteSpaces) && (EOF || (stopAfterWordSeparator && ReadChar(isWordSeparator, false) != '\0') || (!stopAfterWordSeparator && isWordSeparator(First)))) return true;

            CurrentPosition = currPos;
            return false;
        }

        /// <summary>
        /// If the reader's current reading scope starts with <paramref name="keyWord"/> followed by either <see cref="EOF"/> or a non-letter non-digit character (defined by <see cref="Char.IsLetterOrDigit(char)"/>), then reads <paramref name="keyWord"/> from the beginning of the current reading scope and advances the reader to the character after the non-letter non-digit character.
        /// </summary>
        /// <param name="keyWord">The target substring.</param>
        /// <param name="ignoreWhiteSpaces">If set to <c>true</c>, the white spaces at the beginning of the reader's current reading scope will be ignored.</param>
        /// <returns><c>true</c> if the reader's current reading scope starts with <paramref name="keyWord"/> followed by a non-letter non-digit character, <c>false</c> otherwise.</returns>
        public bool ReadStringFollowedByNonLetterOrDigit(string keyWord, bool ignoreWhiteSpaces = true)
        {
            var currPos = CurrentPosition;
            if (ReadString(keyWord, ignoreWhiteSpaces) && (EOF || ReadNonLetterOrDigit()))
                return true;

            CurrentPosition = currPos;
            return false;

        }

        /// <summary>
        /// If the reader's current reading scope starts with <paramref name="keyWord"/> followed by either <see cref="EOF"/> or a whitespace character (defined by <see cref="Char.IsLetterOrDigit(char)"/>), then reads <paramref name="keyWord"/> from the beginning of the current reading scope and advances the reader to the character after the whitespace character.
        /// </summary>
        /// <param name="keyWord">The target substring.</param>
        /// <param name="ignoreWhiteSpaces">If set to <c>true</c>, the white spaces at the beginning of the reader's current reading scope will be ignored.</param>
        /// <returns><c>true</c> if the reader's current reading scope starts with <paramref name="keyWord"/> followed by a whitespace character, <c>false</c> otherwise.</returns>
        public bool ReadStringFollowedByWhiteSpace(string keyWord, bool ignoreWhiteSpaces = true)
        {
            var currPos = CurrentPosition;
            if (ReadString(keyWord, ignoreWhiteSpaces) && (EOF || ReadWhiteSpace()))
                return true;

            CurrentPosition = currPos;
            return false;
        }


        #endregion

        #region Substring
        public string Substring(int startIndex, int length)
        {
            ExceptionHelper.ArgumentRangeRequired(nameof(startIndex), startIndex, 0, true, EndPosition, false);
            ExceptionHelper.ForwardCheckStartIndexAndLength(startIndex, length, EndPosition - CurrentPosition, nameof(startIndex), nameof(length));
            return InnerSubstring(startIndex, length);
        }

        internal string InnerSubstring(int startIndex, int length)
        {
            return UnderlyingString.Substring(startIndex + CurrentPosition, length);
        }

        public string Substring(int startIndex)
        {
            ExceptionHelper.ArgumentRangeRequired(nameof(startIndex), startIndex, 0, true, EndPosition, false);
            return InnerSubstring(startIndex);
        }

        internal string InnerSubstring(int startIndex)
        {
            return UnderlyingString.Substring(CurrentPosition + startIndex, EndPosition - CurrentPosition - startIndex);
        }
        #endregion

    }
}
