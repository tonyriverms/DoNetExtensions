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
        /// <summary>
        /// Reads the last character of the reader's reading scope and shrinks the end of the reading scope to the previous character.
        /// </summary>
        /// <returns>The last character of the reader's reading scope if the reading scope is not empty; '\0' if the reader has reached the end of the reading scope.</returns>
        public char ReverseRead()
        {
            if (!EOF)
            {
                var readChar = Last;
                --EndPosition;
                return readChar;
            }
            else return '\0';
        }


        /// <summary>
        /// Moves the end of the reading scope to the previous character if the reader's current reading scope is not empty.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Regress()
        {
            if (!EOF) --EndPosition;
        }

        /// <summary>
        /// Moves the end of the reading scope to the previous character if the reader's current reading scope is not empty.
        /// </summary>
        /// <returns><c>true</c> if the reader's current reading scope is not empty and the end position of the scope is moved to the previous character, <c>false</c> otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool RegressChar()
        {
            if (EOF) return false;
            else
            {
                --EndPosition;
                return true;
            }
        }

        /// <summary>
        /// Determines whether the <paramref name="target"/> character equals the last character (last non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>) of the reader's reading scope.
        /// If so, the end of the reader's reading scope shrinks to the previous character; otherwise, the reading scope remains the same if <paramref name="ignoreWhiteSpaces"/> is set <c>false</c>, or the end of the reading scope is moved to the position of the last non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>.
        /// </summary>
        /// <param name="target">The target character.</param>
        /// <param name="ignoreWhiteSpaces"><c>true</c> if all white-spaces are ignored before the <paramref name="target"/> character is encountered.</param>
        /// <returns>
        ///   <c>true</c> if the target character equals the last character (last non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>) of the reader's reading scope; otherwise, <c>false</c>.
        /// </returns>
        public bool ReverseReadChar(char target, bool ignoreWhiteSpaces = true)
        {
            if (ignoreWhiteSpaces) TrimEnd();
            if (EOF) return false;

            if (UnderlyingString[EndPosition - 1].ToString().Equals(target.ToString(), ComparisonType))
            {
                --EndPosition;
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Determines whether the last character (last non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>) of the reader's reading scope satisfies the specified <paramref name="predicate"/>.
        /// If so, the end of the reader's reading scope shrinks to the previous character; otherwise, the reading scope remains the same if <paramref name="ignoreWhiteSpaces"/> is set <c>false</c>, or the end of the reading scope is moved to the position of the last non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>.
        /// </summary>
        /// <param name="predicate">The predicate to test the character at the end of the reader's reading scope.</param>
        /// <param name="ignoreWhiteSpaces"><c>true</c> if all white-spaces are ignored before a character satisfying the <paramref name="predicate"/> is encountered.</param>
        /// <returns>
        /// If the last character (last non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>) of the reader's reading scope satisfies the specified <paramref name="predicate"/>, then this method returns that character; otherwise, this method returns '\0'.
        /// </returns>
        public char ReverseReadChar(Func<char, bool> predicate, bool ignoreWhiteSpaces = true)
        {
            if (ignoreWhiteSpaces) TrimEnd();
            if (EOF) return '\0';

            var endPos = EndPosition - 1;
            var c = UnderlyingString[endPos];
            if (predicate(c))
            {
                EndPosition = endPos;
                return c;
            }

            return '\0';
        }

        /// <summary>
        /// Determines whether the last character (last non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>) of the reader's reading scope is in the specified <paramref name="targets"/>.
        /// If so, the end of the reader's reading scope shrinks to the previous character; otherwise, the reader remains where it was if <paramref name="ignoreWhiteSpaces"/> is set <c>false</c>, or the end of the reader's reading scope is moved to the position of the last non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>.
        /// </summary>
        /// <param name="targets">The characters to check against the last character (last non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>) of the reader's reading scope.</param>
        /// <param name="ignoreWhiteSpaces"><c>true</c> if all white-spaces are ignored before a target character is encountered.</param>
        /// <returns>
        /// The index of the last character (last non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is set <c>true</c>) in the array <paramref name="targets"/>; or -1 if none of <paramref name="targets"/> is encountered.
        /// </returns>
        public int ReverseReadChar(char[] targets, bool ignoreWhiteSpaces = true)
        {
            if (ignoreWhiteSpaces) TrimEnd();
            if (EOF) return -1;
            var endPos = EndPosition - 1;
            var curr = UnderlyingString[endPos].ToString();

            for (int i = 0, j = targets.Length; i < j; ++i)
            {
                var target = targets[i].ToString();
                if (curr.Equals(target, ComparisonType))
                {
                    EndPosition = endPos;
                    return i;
                }
            }

            return -1;
        }
    }
}
