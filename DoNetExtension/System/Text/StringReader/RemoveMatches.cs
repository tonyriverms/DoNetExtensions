using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public partial class StringReader
    {
        static bool _isMatchedBrackets(char leftQuote, char rightQuote)
        {
            return
                (leftQuote == '[' && rightQuote == ']') ||
                (leftQuote == '(' && rightQuote == ')') ||
                (leftQuote == '{' && rightQuote == '}') ||
                (leftQuote == '<' && rightQuote == '>');
        }

        static bool _isMatchedQuotes(char leftQuote, char rightQuote)
        {
            return
                (leftQuote == '\'' && rightQuote == '\'') ||
                (leftQuote == '"' && rightQuote == '"');
        }

        static char _getMatchedCharacter(char c)
        {
            switch (c)
            {
                case '(':
                    return ')';
                case '[':
                    return ']';
                case '{':
                    return '}';
                case '<':
                    return '>';
                case '\'':
                case '"':
                    return c;
                default:
                    throw new ArgumentException();
            }
        }

        void _innerRemoveBrackets()
        {
            if (EndPosition - CurrentPosition > 1 && _isMatchedBrackets(First, Last))
            {
                ++CurrentPosition;
                --EndPosition;
            }
        }
        void _innerRemoveQuotes()
        {
            if (EndPosition - CurrentPosition > 1 && _isMatchedQuotes(First, Last))
            {
                ++CurrentPosition;
                --EndPosition;
            }
        }

        void _innerRemoveQuotesAndBrackets()
        {
            if (EndPosition - CurrentPosition > 1 && (_isMatchedBrackets(First, Last) || _isMatchedQuotes(First, Last)))
            {
                ++CurrentPosition;
                --EndPosition;
            }
        }

        bool _innerRemoveMatches(char leftQuote, char rightQuote)
        {
            if (EndPosition - CurrentPosition > 1 && First == leftQuote && Last == rightQuote)
            {
                ++CurrentPosition;
                --EndPosition;
                return true;
            }
            return false;
        }

        /// <summary>
        /// If the first character (the first non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is <c>true</c>) of the reading scope equals <paramref name="value1"/> and the last character (the last non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is <c>true</c>) of the reading scope equals <paramref name="rightQuote"/>, then they are removed from the reading scope.
        /// </summary>
        /// <param name="value1">The character to match against the first character of the reading scope.</param>
        /// <param name="value2">The character to match against the last character of the reading scope.</param>
        /// <param name="ignoreWhiteSpaces"><c>true</c> if white spaces at both ends of the reading scope will be trimmed before trying to match characters; otherwise, <c>false</c>. NOTE that if this argument is set <c>true</c>, the white spaces will be trimmed even if the first character and the last character of the trimmed reading scope are not matched.</param>
        /// <returns><c>true</c> if the first character (the first non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is <c>true</c>) of the reading scope equals <paramref name="value1"/> and the last character (the last non-whitespace character if <paramref name="ignoreWhiteSpaces"/> is <c>true</c>) of the reading scope equals <paramref name="rightQuote"/>; otherwise, <c>false</c>.</returns>
        public bool RemoveMatchedEnds(char value1, char value2, bool ignoreWhiteSpaces = true)
        {
            if (ignoreWhiteSpaces)
            {
                while (!EOF && First.IsWhiteSpace()) ++CurrentPosition;
                while (!EOF && Last.IsWhiteSpace()) --EndPosition;
            }
            return _innerRemoveMatches(value1, value2);
        }

        /// <summary>
        /// Removes the first character and the last character of the reading scope if they are matched brackets.
        /// Matched brackets include '[' and ']', '(' and ')', '{' and '}', '&lt;' and '&gt;'.
        /// </summary>
        /// <param name="ignoreSpaces"><c>true</c> if white spaces at both ends of the reading scope will be trimmed before trying to find matched characters; otherwise, <c>false</c>. NOTE that if this argument is set <c>true</c>, the white spaces will be trimmed even if the first character and the last character of the trimmed reading scope are not matched brackets.</param>
        public void RemoveBrackets(bool ignoreSpaces = true)
        {
            if (ignoreSpaces)
            {
                while (!EOF && First.IsWhiteSpace()) ++CurrentPosition;
                while (!EOF && Last.IsWhiteSpace()) --EndPosition;
            }
            _innerRemoveBrackets();
        }

        /// <summary>
        /// Removes the first character and the last character of the reading scope if they are matched quotes and brackets.
        /// Matched quotes and brackets include a pair of single-quotes ('''), a pair of double-quotes ('"'), '[' and ']', '(' and ')', '{' and '}', '&lt;' and '&gt;'.
        /// </summary>
        /// <param name="ignoreSpaces"><c>true</c> if white spaces at both ends of the reading scope will be trimmed before trying to find matched characters; otherwise, <c>false</c>. NOTE that if this argument is set <c>true</c>, the white spaces will be trimmed even if the first character and the last character of the trimmed reading scope are not matched quotes and brackets.</param>
        public void RemoveBracketsAndQuotes(bool ignoreSpaces = true)
        {
            if (ignoreSpaces)
            {
                while (!EOF && First.IsWhiteSpace()) ++CurrentPosition;
                while (!EOF && Last.IsWhiteSpace()) --EndPosition;
            }
            _innerRemoveQuotesAndBrackets();
        }

        /// <summary>
        /// Removes the first character and the last character of the reading scope if they are matched quotes.
        /// Matched quotes include a pair of single-quotes ('''), a pair of double-quotes ('"').
        /// </summary>
        /// <param name="ignoreSpaces"><c>true</c> if white spaces at both ends of the reading scope will be trimmed before trying to find matched characters; otherwise, <c>false</c>. NOTE that if this argument is set <c>true</c>, the white spaces will be trimmed even if the first character and the last character of the trimmed reading scope are not matched quotes.</param>
        public void RemoveQuotes(bool ignoreSpaces = true)
        {
            if (ignoreSpaces)
            {
                while (!EOF && First.IsWhiteSpace()) ++CurrentPosition;
                while (!EOF && Last.IsWhiteSpace()) --EndPosition;
            }
            _innerRemoveQuotes();
        }

        /// <summary>
        /// Removes the first character and the last character of the reading scope if they are a pair of square brackets ('[' and  ']').
        /// </summary>
        /// <param name="ignoreSpaces"><c>true</c> if white spaces at both ends of the reading scope will be trimmed before trying to find matched characters; otherwise, <c>false</c>. NOTE that if this argument is set <c>true</c>, the white spaces will be trimmed even if the first character and the last character of the trimmed reading scope are not a pair of square brackets.</param>
        public void RemoveSquareBrackets(bool ignoreSpaces = true)
        {
            if (ignoreSpaces)
            {
                while (!EOF && First.IsWhiteSpace()) ++CurrentPosition;
                while (!EOF && Last.IsWhiteSpace()) --EndPosition;
            }

            if (EndPosition - CurrentPosition > 1 && First == '[' && Last == ']')
            {
                ++CurrentPosition;
                --EndPosition;
            }
        }

        /// <summary>
        /// Removes the first character and the last character of the reading scope if they are a pair of angle brackets ('&lt;' and  '&gt;').
        /// </summary>
        /// <param name="ignoreSpaces"><c>true</c> if white spaces at both ends of the reading scope will be trimmed before trying to find matched characters; otherwise, <c>false</c>. NOTE that if this argument is set <c>true</c>, the white spaces will be trimmed even if the first character and the last character of the trimmed reading scope are not a pair of angle brackets.</param>
        public void RemoveAngleBrackets(bool ignoreSpaces = true)
        {
            if (ignoreSpaces)
            {
                while (!EOF && First.IsWhiteSpace()) ++CurrentPosition;
                while (!EOF && Last.IsWhiteSpace()) --EndPosition;
            }

            if (EndPosition - CurrentPosition > 1 && First == '<' && Last == '>')
            {
                ++CurrentPosition;
                --EndPosition;
            }
        }

        /// <summary>
        /// Removes the first character and the last character of the reading scope if they are a pair of round brackets ('(' and  ')').
        /// </summary>
        /// <param name="ignoreSpaces"><c>true</c> if white spaces at both ends of the reading scope will be trimmed before trying to find matched characters; otherwise, <c>false</c>. NOTE that if this argument is set <c>true</c>, the white spaces will be trimmed even if the first character and the last character of the trimmed reading scope are not a pair of round brackets.</param>
        public void RemoveRoundBrackets(bool ignoreSpaces = true)
        {
            if (ignoreSpaces)
            {
                while (!EOF && First.IsWhiteSpace()) ++CurrentPosition;
                while (!EOF && Last.IsWhiteSpace()) --EndPosition;
            }

            if (EndPosition - CurrentPosition > 1 && First == '(' && Last == ')')
            {
                ++CurrentPosition;
                --EndPosition;
            }
        }

        /// <summary>
        /// Removes the first character and the last character of the reading scope if they are a pair of braces ('{' and  '}').
        /// </summary>
        /// <param name="ignoreSpaces"><c>true</c> if white spaces at both ends of the reading scope will be trimmed before trying to find matched characters; otherwise, <c>false</c>. NOTE that if this argument is set <c>true</c>, the white spaces will be trimmed even if the first character and the last character of the trimmed reading scope are not a pair of braces.</param>
        public void RemoveBraces(bool ignoreSpaces = true)
        {
            if (ignoreSpaces)
            {
                while (!EOF && First.IsWhiteSpace()) ++CurrentPosition;
                while (!EOF && Last.IsWhiteSpace()) --EndPosition;
            }

            if (EndPosition - CurrentPosition > 1 && First == '{' && Last == '}')
            {
                ++CurrentPosition;
                --EndPosition;
            }
        }
    }
}
