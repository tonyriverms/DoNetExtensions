using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_Extension_Library.System;
using System_Extension_Library.System.StringEx;

namespace System
{
    public static partial class StringEx
    {
        static void _searchLeftQuote(string str, ref int i, int endIndex, char leftQuote, char rightQuote)
        {
            var sameQuote = leftQuote == rightQuote;
            if (sameQuote)
            {
                i = str.LastIndexOf(rightQuote, i - 1);
                if (i == -1) throw new FormatException(StringExResources.ERR_Quotes_QuoteMismatch);
            }
            else
            {
                var stackNum = 1;
                while (true)
                {
                    --i;
                    if (i == endIndex) throw new FormatException(StringExResources.ERR_Quotes_QuoteMismatch);
                    var c = str[i];
                    if (c == rightQuote) ++stackNum;
                    else if (c == leftQuote) --stackNum;
                    if (stackNum == 0) break;
                }
            }
        }

        static void _searchLeftQuote(string str, ref int i, int endIndex, char leftQuote, char rightQuote, char[] escapes)
        {
            var sameQuote = (leftQuote == rightQuote);
            if (sameQuote)
            {
                i = _innerLastIndexOfWithEscape(str, c2 => c2 == rightQuote, i - 1, endIndex, c3 => c3.In(escapes));
                if (i == -1) throw new FormatException(); //quotes do not match
            }
            else
            {
                var stackNum = 1;
                while (true)
                {
                    --i;
                    if (i == endIndex) throw new FormatException(); //quote mis match

                    i = _innerLastIndexOfWithEscape(str, c2 => c2 == leftQuote || c2 == rightQuote, i, endIndex, c3 => c3.In(escapes));
                    if (i == -1) throw new FormatException(); //quotes do not match
                    var c = str[i];
                    if (c == rightQuote) ++stackNum;
                    else --stackNum;
                    if (stackNum == 0) break;
                }
            }
        }

        static void _searchLeftQuote(string str, ref int i, int endIndex, char leftQuote, char rightQuote, char escapesA, char escapesB)
        {
            var sameQuote = (leftQuote == rightQuote);
            if (sameQuote)
            {
                i = _innerLastIndexOfWithQuotes(str, leftQuote, i - 1, endIndex, escapesA, escapesB);
                if (i == -1) throw new FormatException(StringExResources.ERR_Quotes_QuoteMismatch); //quotes do not match
            }
            else
            {
                var stackNum = 1;
                while (true)
                {
                    --i;
                    if (i == endIndex) throw new FormatException(StringExResources.ERR_Quotes_QuoteMismatch); //quote mis match

                    i = _innerLastIndexOfWithQuotes(str, cc => cc == leftQuote || cc == rightQuote, i, endIndex, escapesA, escapesB);
                    if (i == -1) throw new FormatException(); //quotes do not match
                    var c = str[i];
                    if (c == rightQuote) ++stackNum;
                    else
                    {
                        --stackNum;
                        if (stackNum == 0) break;
                    }
                }
            }
        }

        static void _searchLeftQuote(string str, ref int i, int endIndex, char leftQuote, char rightQuote, char[] escapesA, char[] escapesB)
        {
            var sameQuote = (leftQuote == rightQuote);
            if (sameQuote)
            {
                i = _innerLastIndexOfWithQuotes(str, leftQuote, i - 1, endIndex, escapesA, escapesB);
                if (i == -1) throw new FormatException(StringExResources.ERR_Quotes_QuoteMismatch); //quotes do not match
            }
            else
            {
                var stackNum = 1;
                while (true)
                {
                    --i;
                    if (i == endIndex) throw new FormatException(StringExResources.ERR_Quotes_QuoteMismatch); //quote mis match

                    i = _innerLastIndexOfWithQuotes(str, cc => cc == leftQuote || cc == rightQuote, i, endIndex, escapesA, escapesB);
                    if (i == -1) throw new FormatException(); //quotes do not match
                    var c = str[i];
                    if (c == rightQuote) ++stackNum;
                    else
                    {
                        --stackNum;
                        if (stackNum == 0) break;
                    }
                }
            }
        }


        #region One-Layer Qutoes / Predicate

        static int _innerLastIndexOfWithQuotes(string str, Func<char, bool> predicate, int startIndex, int endIndex, char leftQuote, char rightQuote)
        {
            var sameQuote = leftQuote == rightQuote;
            while(startIndex > endIndex)
            {
                var c = str[startIndex];
                if (c == rightQuote) _searchLeftQuote(str, ref startIndex, endIndex, leftQuote, rightQuote);
                else if (predicate(c)) return startIndex;
                --startIndex;
            }

            return -1;
        }

        static int _innerLastIndexOfWithQuotes(string str, Func<char, bool> predicate, int startIndex, int endIndex, char[] leftQuotes, char[] rightQuotes)
        {
            while(startIndex > endIndex)
            {
                var c = str[startIndex];
                var quoteIdx = rightQuotes.IndexOf(c);
                if (quoteIdx != -1) _searchLeftQuote(str, ref startIndex, endIndex, leftQuotes[quoteIdx], rightQuotes[quoteIdx]);
                else if (predicate(c)) return startIndex;
                --startIndex;
            }

            return -1;
        }

        #endregion

        #region One-Layer Qutoes / Single Key Char

        static int _innerLastIndexOfWithQuotes(string str, char keychar, int startIndex, int endIndex, char leftQuote, char rightQuote)
        {
            var sameQuote = leftQuote == rightQuote;
            while (startIndex > endIndex)
            {
                var c = str[startIndex];
                if (c == rightQuote) _searchLeftQuote(str, ref startIndex, endIndex, leftQuote, rightQuote);
                else if (c == keychar) return startIndex;
                --startIndex;
            }

            return -1;
        }

        static int _innerLastIndexOfWithQuotes(string str, char keychar, int startIndex, int endIndex, char[] leftQuotes, char[] rightQuotes)
        {
            while (startIndex > endIndex)
            {
                var c = str[startIndex];
                var quoteIdx = rightQuotes.IndexOf(c);
                if (quoteIdx != -1) _searchLeftQuote(str, ref startIndex, endIndex, leftQuotes[quoteIdx], rightQuotes[quoteIdx]);
                else if (c == keychar) return startIndex;
                --startIndex;
            }

            return -1;
        }

        #endregion

        #region One-Layer Qutoes / Multiple Key Chars

        static int _innerLastIndexOfWithQuotes(string str, char[] keychars, int startIndex, int endIndex, char leftQuote, char rightQuote)
        {
            var sameQuote = leftQuote == rightQuote;
            while (startIndex > endIndex)
            {
                var c = str[startIndex];
                if (c == rightQuote) _searchLeftQuote(str, ref startIndex, endIndex, leftQuote, rightQuote);
                else if (c.In(keychars)) return startIndex;
                --startIndex;
            }

            return -1;
        }

        static int _innerLastIndexOfWithQuotes(string str, char[] keychars, int startIndex, int endIndex, char[] leftQuotes, char[] rightQuotes)
        {
            while (startIndex > endIndex)
            {
                var c = str[startIndex];
                var quoteIdx = rightQuotes.IndexOf(c);
                if (quoteIdx != -1) _searchLeftQuote(str, ref startIndex, endIndex, leftQuotes[quoteIdx], rightQuotes[quoteIdx]);
                else if (c.In(keychars)) return startIndex;
                --startIndex;
            }

            return -1;
        }

        #endregion

        #region Two-Layer Quotes / Predicate

        static int _innerLastIndexOfWithQuotes(string str, Func<char, bool> predicate, int startIndex, int endIndex, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote)
        {
            char c;
            while (startIndex > endIndex)
            {
                c = str[startIndex];
                if (c == primaryLeftQuote) _searchLeftQuote(str, ref startIndex, endIndex, primaryLeftQuote, primaryRightQuote);
                else if (c == secondaryRightQuote) _searchLeftQuote(str, ref startIndex, endIndex, secondaryLeftQuote, secondaryRightQuote, primaryLeftQuote, primaryRightQuote);
                else if (predicate(c)) return startIndex;
                --startIndex;
            }

            return -1;
        }

        static int _innerLastIndexOfWithQuotes(string str, Func<char, bool> predicate, int startIndex, int endIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote)
        {
            if (primaryLeftQuotes == null)
            {
                if (primaryRightQuotes == null)
                    return _innerLastIndexOfWithQuotes(str, predicate, startIndex, endIndex, secondaryLeftQuote, secondaryRightQuote);
                else throw new ArgumentNullException("primaryLeftQuotes");
            }
            else if (primaryRightQuotes == null)
                throw new ArgumentNullException("primaryRightQuotes");

            char c;
            int quoteIdx;
            while (startIndex > endIndex)
            {
                c = str[startIndex];
                quoteIdx = primaryRightQuotes.IndexOf(c);
                if (quoteIdx != -1) _searchLeftQuote(str, ref startIndex, endIndex, primaryLeftQuotes[quoteIdx], c);
                else if (c == secondaryRightQuote) _searchLeftQuote(str, ref startIndex, endIndex, secondaryLeftQuote, secondaryRightQuote, primaryLeftQuotes, primaryRightQuotes);
                else if (predicate(c)) return startIndex;
                --startIndex;
            }

            return -1;
        }

        static int _innerLastIndexOfWithQuotes(string str, Func<char, bool> predicate, int startIndex, int endIndex, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            char c;
            int quoteIdx;
            while (startIndex > endIndex)
            {
                c = str[startIndex];
                if (c == primaryLeftQuote) _searchLeftQuote(str, ref startIndex, endIndex, primaryLeftQuote, primaryRightQuote);
                else
                {
                    quoteIdx = secondaryRightQuotes.IndexOf(c);
                    if (quoteIdx != -1) _searchLeftQuote(str, ref startIndex, endIndex, secondaryLeftQuotes[quoteIdx], c, primaryLeftQuote, primaryRightQuote);
                    else if (predicate(c)) return startIndex;
                }
                --startIndex;
            }

            return -1;
        }

        static int _innerLastIndexOfWithQuotes(string str, Func<char, bool> predicate, int startIndex, int endIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            if (primaryLeftQuotes == null)
            {
                if (primaryRightQuotes == null)
                    return _innerLastIndexOfWithQuotes(str, predicate, startIndex, endIndex, secondaryLeftQuotes, secondaryRightQuotes);
                else throw new ArgumentNullException("primaryLeftQuotes");
            }
            else if (primaryRightQuotes == null)
                throw new ArgumentNullException("primaryRightQuotes");

            char c;
            int quoteIdx;
            while (startIndex > endIndex)
            {
                c = str[startIndex];
                quoteIdx = primaryRightQuotes.IndexOf(c);
                if (quoteIdx != -1) _searchLeftQuote(str, ref startIndex, endIndex, primaryLeftQuotes[quoteIdx], c);
                else
                {
                    quoteIdx = secondaryRightQuotes.IndexOf(c);
                    if (quoteIdx != -1) _searchLeftQuote(str, ref startIndex, endIndex, secondaryLeftQuotes[quoteIdx], c, primaryLeftQuotes, primaryRightQuotes);
                    else if (predicate(c)) return startIndex;
                }
                --startIndex;
            }

            return -1;
        }

        #endregion

        #region Two-Layer Quotes / Single Key Char

        static int _innerLastIndexOfWithQuotes(string str, char keychar, int startIndex, int endIndex, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote)
        {
            char c;
            while (startIndex > endIndex)
            {
                c = str[startIndex];
                if (c == primaryLeftQuote) _searchLeftQuote(str, ref startIndex, endIndex, primaryLeftQuote, primaryRightQuote);
                else if (c == secondaryRightQuote) _searchLeftQuote(str, ref startIndex, endIndex, secondaryLeftQuote, secondaryRightQuote, primaryLeftQuote, primaryRightQuote);
                else if (c == keychar) return startIndex;
                --startIndex;
            }

            return -1;
        }

        static int _innerLastIndexOfWithQuotes(string str, char keychar, int startIndex, int endIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote)
        {
            if (primaryLeftQuotes == null)
            {
                if (primaryRightQuotes == null)
                    return _innerLastIndexOfWithQuotes(str, keychar, startIndex, endIndex, secondaryLeftQuote, secondaryRightQuote);
                else throw new ArgumentNullException("primaryLeftQuotes");
            }
            else if (primaryRightQuotes == null)
                throw new ArgumentNullException("primaryRightQuotes");

            char c;
            int quoteIdx;
            while (startIndex > endIndex)
            {
                c = str[startIndex];
                quoteIdx = primaryRightQuotes.IndexOf(c);
                if (quoteIdx != -1) _searchLeftQuote(str, ref startIndex, endIndex, primaryLeftQuotes[quoteIdx], c);
                else if (c == secondaryRightQuote) _searchLeftQuote(str, ref startIndex, endIndex, secondaryLeftQuote, secondaryRightQuote, primaryLeftQuotes, primaryRightQuotes);
                else if (c == keychar) return startIndex;
                --startIndex;
            }

            return -1;
        }

        static int _innerLastIndexOfWithQuotes(string str, char keychar, int startIndex, int endIndex, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            char c;
            int quoteIdx;
            while (startIndex > endIndex)
            {
                c = str[startIndex];
                if (c == primaryLeftQuote) _searchLeftQuote(str, ref startIndex, endIndex, primaryLeftQuote, primaryRightQuote);
                else
                {
                    quoteIdx = secondaryRightQuotes.IndexOf(c);
                    if (quoteIdx != -1) _searchLeftQuote(str, ref startIndex, endIndex, secondaryLeftQuotes[quoteIdx], c, primaryLeftQuote, primaryRightQuote);
                    else if (c == keychar) return startIndex;
                }
                --startIndex;
            }

            return -1;
        }

        static int _innerLastIndexOfWithQuotes(string str, char keychar, int startIndex, int endIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            if (primaryLeftQuotes == null)
            {
                if (primaryRightQuotes == null)
                    return _innerLastIndexOfWithQuotes(str, keychar, startIndex, endIndex, secondaryLeftQuotes, secondaryRightQuotes);
                else throw new ArgumentNullException("primaryLeftQuotes");
            }
            else if (primaryRightQuotes == null)
                throw new ArgumentNullException("primaryRightQuotes");

            char c;
            int quoteIdx;
            while (startIndex > endIndex)
            {
                c = str[startIndex];
                quoteIdx = primaryRightQuotes.IndexOf(c);
                if (quoteIdx != -1) _searchLeftQuote(str, ref startIndex, endIndex, primaryLeftQuotes[quoteIdx], c);
                else
                {
                    quoteIdx = secondaryRightQuotes.IndexOf(c);
                    if (quoteIdx != -1) _searchLeftQuote(str, ref startIndex, endIndex, secondaryLeftQuotes[quoteIdx], c, primaryLeftQuotes, primaryRightQuotes);
                    else if (c == keychar) return startIndex;
                }
                --startIndex;
            }

            return -1;
        }

        #endregion

        #region Two-Layer Quotes / Multiple Key Chars

        static int _innerLastIndexOfWithQuotes(string str, char[] keychars, int startIndex, int endIndex, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote)
        {
            char c;
            while (startIndex > endIndex)
            {
                c = str[startIndex];
                if (c == primaryLeftQuote) _searchLeftQuote(str, ref startIndex, endIndex, primaryLeftQuote, primaryRightQuote);
                else if (c == secondaryRightQuote) _searchLeftQuote(str, ref startIndex, endIndex, secondaryLeftQuote, secondaryRightQuote, primaryLeftQuote, primaryRightQuote);
                else if (c.In(keychars)) return startIndex;
                --startIndex;
            }

            return -1;
        }

        static int _innerLastIndexOfWithQuotes(string str, char[] keychars, int startIndex, int endIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote)
        {
            if (primaryLeftQuotes == null)
            {
                if (primaryRightQuotes == null)
                    return _innerLastIndexOfWithQuotes(str, keychars, startIndex, endIndex, secondaryLeftQuote, secondaryRightQuote);
                else throw new ArgumentNullException("primaryLeftQuotes");
            }
            else if (primaryRightQuotes == null)
                throw new ArgumentNullException("primaryRightQuotes");

            char c;
            int quoteIdx;
            while (startIndex > endIndex)
            {
                c = str[startIndex];
                quoteIdx = primaryRightQuotes.IndexOf(c);
                if (quoteIdx != -1) _searchLeftQuote(str, ref startIndex, endIndex, primaryLeftQuotes[quoteIdx], c);
                else if (c == secondaryRightQuote) _searchLeftQuote(str, ref startIndex, endIndex, secondaryLeftQuote, secondaryRightQuote, primaryLeftQuotes, primaryRightQuotes);
                else if (c.In(keychars)) return startIndex;
                --startIndex;
            }

            return -1;
        }

        static int _innerLastIndexOfWithQuotes(string str, char[] keychars, int startIndex, int endIndex, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            char c;
            int quoteIdx;
            while (startIndex > endIndex)
            {
                c = str[startIndex];
                if (c == primaryLeftQuote) _searchLeftQuote(str, ref startIndex, endIndex, primaryLeftQuote, primaryRightQuote);
                else
                {
                    quoteIdx = secondaryRightQuotes.IndexOf(c);
                    if (quoteIdx != -1) _searchLeftQuote(str, ref startIndex, endIndex, secondaryLeftQuotes[quoteIdx], c, primaryLeftQuote, primaryRightQuote);
                    else if (c.In(keychars)) return startIndex;
                }
                --startIndex;
            }

            return -1;
        }

        static int _innerLastIndexOfWithQuotes(string str, char[] keychars, int startIndex, int endIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            if (primaryLeftQuotes == null)
            {
                if (primaryRightQuotes == null)
                    return _innerLastIndexOfWithQuotes(str, keychars, startIndex, endIndex, secondaryLeftQuotes, secondaryRightQuotes);
                else throw new ArgumentNullException("primaryLeftQuotes");
            }
            else if (primaryRightQuotes == null)
                throw new ArgumentNullException("primaryRightQuotes");

            char c;
            int quoteIdx;
            while (startIndex > endIndex)
            {
                c = str[startIndex];
                quoteIdx = primaryRightQuotes.IndexOf(c);
                if (quoteIdx != -1) _searchLeftQuote(str, ref startIndex, endIndex, primaryLeftQuotes[quoteIdx], c);
                else
                {
                    quoteIdx = secondaryRightQuotes.IndexOf(c);
                    if (quoteIdx != -1) _searchLeftQuote(str, ref startIndex, endIndex, secondaryLeftQuotes[quoteIdx], c, primaryLeftQuotes, primaryRightQuotes);
                    else if (c.In(keychars)) return startIndex;
                }
                --startIndex;
            }

            return -1;
        }

        #endregion
    }
}
