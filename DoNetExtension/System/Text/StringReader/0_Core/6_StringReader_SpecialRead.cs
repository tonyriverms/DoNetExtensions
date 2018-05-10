using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public partial class StringReader
    {
        /// <summary>
        /// Reads an unsigned integer from the beginning of the current reading scope. This method only supports ASCII digits.
        /// </summary>
        /// <param name="discardFirstNonDigitIfReadingSucceeds">If set to <c>true</c>, the reader advances to the position after the first non-digit character if any integer is read; otherwise, the reader stops at the encountered non-digit character.</param>
        /// <returns>The unsinged integer read from the current reading scope if there is one; otherwise <c>-1</c>.</returns>
        public int ReadUnsignedInteger(bool discardFirstNonDigitIfReadingSucceeds = true)
        {
            if (EOF || !First.IsASCIIDigit()) return -1;
            int value = 0;

            do
            {
                value = value * 10 + (First - '0');
                Advance();
                if (EOF) return value;
            }
            while (First.IsASCIIDigit());

            if (discardFirstNonDigitIfReadingSucceeds) Advance();
            return value;
        }

        public int? ReadInteger(bool discardFirstNonDigitIfReadingSucceeds = true)
        {
            if (EOF) return null;
            var pos = CurrentPosition;
            var negative = false;
            if (First == '-')
            {
                negative = true;
                Advance();
            }
            else if (First == '+') Advance();
            TrimStart();

            var integer = ReadUnsignedInteger(discardFirstNonDigitIfReadingSucceeds);
            if (integer == -1)
            {
                CurrentPosition = pos;
                return null;
            }
            else return negative ? -integer : integer;
        }

        /// <summary>
        /// Reads an unsigned (non-negative) decimal from the beginning of the current reading scope of the <see cref="UnderlyingString"/> represented by ASCII characters. For reading with the sign, use <see cref="ReadDecimal(bool)"/>.
        /// </summary>
        /// <param name="discardFirstNonDigitIfReadingSucceeds">If set to <c>true</c>, and if the reading of decimal succeeds, the first non-ASCII-digit character will be discarded after reading.</param>
        /// <returns>An unsigned (non-negative) decimal read from the current reading scope of the <see cref="UnderlyingString"/>.</returns>
        public double ReadUnsignedDecimal(bool discardFirstNonDigitIfReadingSucceeds = true)
        {
            if (EOF || !First.IsASCIIDigit()) return -1f;
            double value = 0;

            do
            {
                value = value * 10 + (First - '0');
                Advance();
                if (EOF) return value;
            }
            while (First.IsASCIIDigit());

            TrimStart();
            if (First == '.')
            {
                AdvanceToNextNonWhiteSpace();
                if (EOF || !First.IsASCIIDigit()) return -1f;
                else
                {
                    double @base = 10;
                    do
                    {
                        value += (First - '0') / @base;
                        @base *= 10;
                        Advance();
                        if (EOF) return value;
                    }
                    while (First.IsASCIIDigit());
                }
            }

            if (discardFirstNonDigitIfReadingSucceeds) Advance();
            return value;
        }

        /// <summary>
        /// Reads a decimal from the beginning of the current reading scope of the <see cref="UnderlyingString"/> represented by ASCII characters with its sign. For reading without the sign, use <see cref="ReadUnsignedDecimal(bool)"/>.
        /// </summary>
        /// <param name="discardFirstNonDigitIfReadingSucceeds">If set to <c>true</c>, and if the reading of decimal succeeds, the first non-ASCII-digit character will be discarded after reading.</param>
        /// <returns>A decimal read from the current reading scope of the <see cref="UnderlyingString"/> if such decimal exists; otherwise, <c>null</c>.</returns>
        public double? ReadDecimal(bool discardFirstNonDigitIfReadingSucceeds = true)
        {
            if (EOF) return null;
            var pos = CurrentPosition;
            var negative = false;
            if (First == '-')
            {
                negative = true;
                Advance();
            }
            else if (First == '+') Advance();
            TrimStart();

            var number = ReadUnsignedDecimal(discardFirstNonDigitIfReadingSucceeds);
            if (number == -1f)
            {
                CurrentPosition = pos;
                return null;
            }
            else return negative ? -number : number;
        }

        public string ReadQuotedString(char quote)
        {
            if (Read(quote)) return ReadTo(quote, ReadOptions.StopAfterKey | ReadOptions.DiscardKey);
            else return null;
        }



        /// <summary>
        /// Reads a string consisting of ASCII letters and digits, plus characters specified in <paramref name="additionalChars"/> at the beginning of the reading scope.
        /// </summary>
        /// <param name="additionalChars">Specifies additional characters to read.</param>
        /// <returns>A string at the beginning of the current reading scope, consisting of ASCII letters and digits plus <paramref name="additionalChars"/>.</returns>
        public string ReadASCIILettersAndDigits(params char[] additionalChars)
        {
            var pos = CurrentPosition;
            while (!EOF && (First.IsASCIILetterOrDigit() || First.In(additionalChars))) Advance();
            return UnderlyingString.Substring(pos, CurrentPosition - pos);
        }


        /// <summary>
        /// Reads a variable name from this reader. The valid first character of the variable name can either be a ASCII letter, or '_'; and a valid variable name character (except the first character) can either be a ASCII letter or ASCII digit or '_'.
        /// </summary>
        /// <returns>A variable name read from this reader.</returns>
        public string ReadVariableName()
        {
            var pos = CurrentPosition; //! DO NOT use MarkPosition; it is for external use.
            if (First.IsASCIILetter() || First == '_') Advance();
            else return null;

            while (!EOF && First.IsASCIILetterOrDigit() || First == '_') Advance();
            return UnderlyingString.Substring(pos, CurrentPosition - pos);
        }

        /// <summary>
        /// Reads a WAS reference name from this reader. The valid first character of the variable name can either be a ASCII letter, or '_'; and a valid variable name character (except the first character) can either be a ASCII letter or ASCII digit or '_' or '-'.
        /// </summary>
        /// <returns>A variable name read from this reader.</returns>
        public string ReadWASReferenceName()
        {
            var pos = CurrentPosition; //! DO NOT use MarkPosition; it is for external use.
            if (First.IsASCIILetter() || First == '_') Advance();
            else return null;

            while (!EOF && First.IsASCIILetterOrDigit() || First == '_' || First == '-') Advance();
            return UnderlyingString.Substring(pos, CurrentPosition - pos);
        }

        /// <summary>
        /// Reads a variable name from this reader. The valid first character of the variable name is defined by the <paramref name="isValidVariableFirstChr"/>, and a valid variable name character (except the first character) is defined by <paramref name="isValidVariableChr"/>.
        /// </summary>
        /// <returns>A variable name read from this reader.</returns>
        public string ReadVariableName(Func<char, bool> isValidVariableFirstChr, Func<char, bool> isValidVariableChr)
        {
            var pos = CurrentPosition; //! DO NOT use MarkPosition; it is for external use.
            if (isValidVariableFirstChr(First)) Advance();
            else return null;

            while (!EOF && isValidVariableChr(First)) Advance();
            return UnderlyingString.Substring(pos, CurrentPosition - pos);
        }
    }

}
