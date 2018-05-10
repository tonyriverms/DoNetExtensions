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
        static void _searchRightQuote(string str, ref int i, int endIndex, char leftQuote, char rightQuote)
        {
            var sameQuote = leftQuote == rightQuote;
            if (sameQuote)
            {
                i = str.IndexOf(leftQuote, i + 1);
                if (i == -1) throw new FormatException(StringExResources.ERR_Quotes_QuoteMismatch);
            }
            else
            {
                var stackNum = 1;
                while (true)
                {
                    ++i;
                    if (i == endIndex) throw new FormatException(StringExResources.ERR_Quotes_QuoteMismatch);
                    var c = str[i];
                    if (c == leftQuote) ++stackNum;
                    else if (c == rightQuote)
                    {
                        --stackNum;
                        if (stackNum == 0) break;
                    }
                }
            }
        }

        static void _searchRightQuote(string str, ref int i, int endIndex, char leftQuote, char rightQuote, char[] escapes)
        {
            var sameQuote = (leftQuote == rightQuote);
            if (sameQuote)
            {
                i = _innerIndexOfWithEscape(str, c2 => c2 == rightQuote, i + 1, endIndex, c3 => c3.In(escapes));
                if (i == -1) throw new FormatException(); //quotes do not match
            }
            else
            {
                var stackNum = 1;
                while (true)
                {
                    ++i;
                    if (i == endIndex) throw new FormatException(); //quote mis match

                    i = _innerIndexOfWithEscape(str, c2 => c2 == leftQuote || c2 == rightQuote, i, endIndex, c3 => c3.In(escapes));
                    if (i == -1) throw new FormatException(); //quotes do not match
                    var c = str[i];
                    if (c == leftQuote) ++stackNum;
                    else --stackNum;
                    if (stackNum == 0) break;
                }
            }
        }

        static void _searchRightQuote(string str, ref int i, int endIndex, char leftQuote, char rightQuote, char escapesA, char escapesB)
        {
            var sameQuote = (leftQuote == rightQuote);
            if (sameQuote)
            {
                i = _innerIndexOfWithQuotes(str, rightQuote, i + 1, endIndex, escapesA, escapesB);
                if (i == -1) throw new FormatException(); //quotes do not match
            }
            else
            {
                var stackNum = 1;
                while (true)
                {
                    ++i;
                    if (i == endIndex) throw new FormatException(StringExResources.ERR_Quotes_QuoteMismatch); //quote mis match
                    i = _innerIndexOfWithQuotes(str, cc => cc == leftQuote || cc == rightQuote, i, endIndex, escapesA, escapesB);
                    if (i == -1) throw new FormatException(StringExResources.ERR_Quotes_QuoteMismatch); //quotes do not match
                    var c = str[i];
                    if (c == leftQuote) ++stackNum;
                    else
                    {
                        --stackNum;
                        if (stackNum == 0) break;
                    }
                }
            }
        }

        static void _searchRightQuote(string str, ref int i, int endIndex, char leftQuote, char rightQuote, char[] escapesA, char[] escapesB)
        {
            var sameQuote = (leftQuote == rightQuote);
            if (sameQuote)
            {
                i = _innerIndexOfWithQuotes(str, rightQuote, i + 1, endIndex, escapesA, escapesB);
                if (i == -1) throw new FormatException(); //quotes do not match
            }
            else
            {
                var stackNum = 1;
                while (true)
                {
                    ++i;
                    if (i == endIndex) throw new FormatException(StringExResources.ERR_Quotes_QuoteMismatch); //quote mis match
                    i = _innerIndexOfWithQuotes(str, cc => cc == leftQuote || cc == rightQuote, i, endIndex, escapesA, escapesB);
                    if (i == -1) throw new FormatException(StringExResources.ERR_Quotes_QuoteMismatch); //quotes do not match
                    var c = str[i];
                    if (c == leftQuote) ++stackNum;
                    else
                    {
                        --stackNum;
                        if (stackNum == 0) break;
                    }
                }
            }
        }

        #region One-Layer Qutoes / Predicate

        internal static int _innerIndexOfWithQuotes(string str, Func<char, bool> predicate, int startIndex, int endIndex, char leftQuote, char rightQuote)
        {
            var sameQuote = leftQuote == rightQuote;
            while (startIndex < endIndex)
            {
                char c = str[startIndex];
                if (c == leftQuote) _searchRightQuote(str, ref startIndex, endIndex, leftQuote, rightQuote);
                else if (predicate(c)) return startIndex;
                ++startIndex;
            }

            return -1;
        }

        internal static int _innerIndexOfWithQuotes(string str, Func<char, bool> predicate, int startIndex, int endIndex, char[] leftQuotes, char[] rightQuotes)
        {
            while (startIndex < endIndex)
            {
                char c = str[startIndex];
                var quoteIndex = leftQuotes.IndexOf(c);

                if (quoteIndex != -1) _searchRightQuote(str, ref startIndex, endIndex, leftQuotes[quoteIndex], rightQuotes[quoteIndex]);
                else if (predicate(c)) return startIndex;
                ++startIndex;
            }

            return -1;
        }

        #endregion

        #region One-Layer Qutoes / Single Key Char

        internal static int _innerIndexOfWithQuotes(string str, char keychar, int startIndex, int endIndex, char leftQuote, char rightQuote)
        {
            var sameQuote = leftQuote == rightQuote;
            while (startIndex < endIndex)
            {
                char c = str[startIndex];
                if (c == leftQuote) _searchRightQuote(str, ref startIndex, endIndex, leftQuote, rightQuote);
                else if (c == keychar) return startIndex;
                ++startIndex;
            }

            return -1;
        }

        internal static int _innerIndexOfWithQuotes(string str, char keyChar, int startIndex, int endIndex, char[] leftQuotes, char[] rightQuotes)
        {
            while (startIndex < endIndex)
            {
                char c = str[startIndex];
                var quoteIndex = leftQuotes.IndexOf(c);

                if (quoteIndex != -1) _searchRightQuote(str, ref startIndex, endIndex, leftQuotes[quoteIndex], rightQuotes[quoteIndex]);
                else if (c == keyChar) return startIndex;
                ++startIndex;
            }

            return -1;
        }

        #endregion

        #region One-Layer Qutoes / Multiple Key Chars

        internal static int _innerIndexOfWithQuotes(string str, char[] keychars, int startIndex, int endIndex, char leftQuote, char rightQuote)
        {
            var sameQuote = leftQuote == rightQuote;
            while (startIndex < endIndex)
            {
                char c = str[startIndex];
                if (c == leftQuote) _searchRightQuote(str, ref startIndex, endIndex, leftQuote, rightQuote);
                else if (c.In(keychars)) return startIndex;
                ++startIndex;
            }

            return -1;
        }

        internal static int _innerIndexOfWithQuotes(string str, char[] keychars, int startIndex, int endIndex, char leftQuote, char rightQuote, out int hitIndex)
        {
            var sameQuote = leftQuote == rightQuote;

            while (startIndex < endIndex)
            {
                char c = str[startIndex];
                if (c == leftQuote) _searchRightQuote(str, ref startIndex, endIndex, leftQuote, rightQuote);
                else if ((hitIndex = keychars.IndexOf(c)) != -1) return startIndex;
                ++startIndex;
            }

            hitIndex = -1;
            return -1;
        }

        internal static int _innerIndexOfWithQuotes(string str, char[] keychars, int startIndex, int endIndex, char[] leftQuotes, char[] rightQuotes)
        {
            while (startIndex < endIndex)
            {
                char c = str[startIndex];
                var quoteIndex = leftQuotes.IndexOf(c);

                if (quoteIndex != -1) _searchRightQuote(str, ref startIndex, endIndex, leftQuotes[quoteIndex], rightQuotes[quoteIndex]);
                else if (c.In(keychars)) return startIndex;
                ++startIndex;
            }

            return -1;
        }

        internal static int _innerIndexOfWithQuotes(string str, char[] keychars, int startIndex, int endIndex, char[] leftQuotes, char[] rightQuotes, out int hitIndex)
        {
            while (startIndex < endIndex)
            {
                char c = str[startIndex];
                var quoteIndex = leftQuotes.IndexOf(c);

                if (quoteIndex != -1) _searchRightQuote(str, ref startIndex, endIndex, leftQuotes[quoteIndex], rightQuotes[quoteIndex]);
                else if ((hitIndex = keychars.IndexOf(c)) != -1) return startIndex;
                ++startIndex;
            }

            hitIndex = -1;
            return -1;
        }

        #endregion

        #region Two-Layer Quotes / Predicate

        internal static int _innerIndexOfWithQuotes(string str, Func<char, bool> predicate, int startIndex, int endIndex, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote)
        {
            char c;
            while (startIndex < endIndex)
            {
                c = str[startIndex];
                if (c == primaryLeftQuote) _searchRightQuote(str, ref startIndex, endIndex, primaryLeftQuote, primaryRightQuote);
                else if (c == secondaryLeftQuote) _searchRightQuote(str, ref startIndex, endIndex, secondaryLeftQuote, secondaryRightQuote, primaryLeftQuote, primaryRightQuote);
                else if (predicate(c)) return startIndex;
                ++startIndex;
            }

            return -1;
        }

        internal static int _innerIndexOfWithQuotes(string str, Func<char, bool> predicate, int startIndex, int endIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote)
        {
            if (primaryLeftQuotes == null)
            {
                if (primaryRightQuotes == null)
                    return _innerIndexOfWithQuotes(str, predicate, startIndex, endIndex, secondaryLeftQuote, secondaryRightQuote);
                else throw new ArgumentNullException("primaryLeftQuotes");
            }
            else if (primaryRightQuotes == null)
                throw new ArgumentNullException("primaryRightQuotes");

            char c;
            int quoteIdx;
            while (startIndex < endIndex)
            {
                c = str[startIndex];
                quoteIdx = primaryLeftQuotes.IndexOf(c);
                if (quoteIdx != -1) _searchRightQuote(str, ref startIndex, endIndex, c, primaryRightQuotes[quoteIdx]);
                else if (c == secondaryLeftQuote) _searchRightQuote(str, ref startIndex, endIndex, secondaryLeftQuote, secondaryRightQuote, primaryLeftQuotes, primaryRightQuotes);
                else if (predicate(c)) return startIndex;
                ++startIndex;
            }

            return -1;
        }

        internal static int _innerIndexOfWithQuotes(string str, Func<char, bool> predicate, int startIndex, int endIndex, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            char c;
            int quoteIdx;
            while (startIndex < endIndex)
            {
                c = str[startIndex];
                if (c == primaryLeftQuote) _searchRightQuote(str, ref startIndex, endIndex, primaryLeftQuote, primaryRightQuote);
                else
                {
                    quoteIdx = secondaryLeftQuotes.IndexOf(c);
                    if (quoteIdx != -1) _searchRightQuote(str, ref startIndex, endIndex, c, secondaryRightQuotes[quoteIdx], primaryLeftQuote, primaryRightQuote);
                    else if (predicate(c)) return startIndex;
                }
                ++startIndex;
            }

            return -1;
        }

        internal static int _innerIndexOfWithQuotes(string str, Func<char, bool> predicate, int startIndex, int endIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            if (primaryLeftQuotes == null)
            {
                if (primaryRightQuotes == null)
                    return _innerIndexOfWithQuotes(str, predicate, startIndex, endIndex, secondaryLeftQuotes, secondaryRightQuotes);
                else throw new ArgumentNullException("primaryLeftQuotes");
            }
            else if (primaryRightQuotes == null)
                throw new ArgumentNullException("primaryRightQuotes");

            char c;
            int quoteIdx;
            while (startIndex < endIndex)
            {
                c = str[startIndex];
                quoteIdx = primaryLeftQuotes.IndexOf(c);
                if (quoteIdx != -1) _searchRightQuote(str, ref startIndex, endIndex, c, primaryRightQuotes[quoteIdx]);
                else
                {
                    quoteIdx = secondaryLeftQuotes.IndexOf(c);
                    if (quoteIdx != -1) _searchRightQuote(str, ref startIndex, endIndex, c, secondaryRightQuotes[quoteIdx], primaryLeftQuotes, primaryRightQuotes);
                    else if (predicate(c)) return startIndex;
                }
                ++startIndex;
            }

            return -1;
        }

        #endregion

        #region Two-Layer Quotes / Single Key Char

        internal static int _innerIndexOfWithQuotes(string str, char keychar, int startIndex, int endIndex, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote)
        {
            char c;
            while (startIndex < endIndex)
            {
                c = str[startIndex];
                if (c == primaryLeftQuote) _searchRightQuote(str, ref startIndex, endIndex, primaryLeftQuote, primaryRightQuote);
                else if (c == secondaryLeftQuote) _searchRightQuote(str, ref startIndex, endIndex, secondaryLeftQuote, secondaryRightQuote, primaryLeftQuote, primaryRightQuote);
                else if (c == keychar) return startIndex;
                ++startIndex;
            }

            return -1;
        }

        internal static int _innerIndexOfWithQuotes(string str, char keychar, int startIndex, int endIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote)
        {
            if (primaryLeftQuotes == null)
            {
                if (primaryRightQuotes == null)
                    return _innerIndexOfWithQuotes(str, keychar, startIndex, endIndex, secondaryLeftQuote, secondaryRightQuote);
                else throw new ArgumentNullException("primaryLeftQuotes");
            }
            else if (primaryRightQuotes == null)
                throw new ArgumentNullException("primaryRightQuotes");

            char c;
            int quoteIdx;
            while (startIndex < endIndex)
            {
                c = str[startIndex];
                quoteIdx = primaryLeftQuotes.IndexOf(c);
                if (quoteIdx != -1) _searchRightQuote(str, ref startIndex, endIndex, c, primaryRightQuotes[quoteIdx]);
                else if (c == secondaryLeftQuote) _searchRightQuote(str, ref startIndex, endIndex, secondaryLeftQuote, secondaryRightQuote, primaryLeftQuotes, primaryRightQuotes);
                else if (c == keychar) return startIndex;
                ++startIndex;
            }

            return -1;
        }

        internal static int _innerIndexOfWithQuotes(string str, char keychar, int startIndex, int endIndex, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            char c;
            int quoteIdx;
            while (startIndex < endIndex)
            {
                c = str[startIndex];
                if (c == primaryLeftQuote) _searchRightQuote(str, ref startIndex, endIndex, primaryLeftQuote, primaryRightQuote);
                else
                {
                    quoteIdx = secondaryLeftQuotes.IndexOf(c);
                    if (quoteIdx != -1) _searchRightQuote(str, ref startIndex, endIndex, c, secondaryRightQuotes[quoteIdx], primaryLeftQuote, primaryRightQuote);
                    else if (c == keychar) return startIndex;
                }
                ++startIndex;
            }

            return -1;
        }

        internal static int _innerIndexOfWithQuotes(string str, char keychar, int startIndex, int endIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            if (primaryLeftQuotes == null)
            {
                if (primaryRightQuotes == null)
                    return _innerIndexOfWithQuotes(str, keychar, startIndex, endIndex, secondaryLeftQuotes, secondaryRightQuotes);
                else throw new ArgumentNullException("primaryLeftQuotes");
            }
            else if (primaryRightQuotes == null)
                throw new ArgumentNullException("primaryRightQuotes");

            char c;
            int quoteIdx;
            while (startIndex < endIndex)
            {
                c = str[startIndex];
                quoteIdx = primaryLeftQuotes.IndexOf(c);
                if (quoteIdx != -1) _searchRightQuote(str, ref startIndex, endIndex, c, primaryRightQuotes[quoteIdx]);
                else
                {
                    quoteIdx = secondaryLeftQuotes.IndexOf(c);
                    if (quoteIdx != -1) _searchRightQuote(str, ref startIndex, endIndex, c, secondaryRightQuotes[quoteIdx], primaryLeftQuotes, primaryRightQuotes);
                    else if (c == keychar) return startIndex;
                }
                ++startIndex;
            }

            return -1;
        }

        #endregion

        #region Two-Layer Quotes / Multiple Key Chars

        internal static int _innerIndexOfWithQuotes(string str, char[] keychars, int startIndex, int endIndex, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote)
        {
            char c;
            while (startIndex < endIndex)
            {
                c = str[startIndex];
                if (c == primaryLeftQuote) _searchRightQuote(str, ref startIndex, endIndex, primaryLeftQuote, primaryRightQuote);
                else if (c == secondaryLeftQuote) _searchRightQuote(str, ref startIndex, endIndex, secondaryLeftQuote, secondaryRightQuote, primaryLeftQuote, primaryRightQuote);
                else if (c.In(keychars)) return startIndex;
                ++startIndex;
            }

            return -1;
        }

        internal static int _innerIndexOfWithQuotes(string str, char[] keychars, int startIndex, int endIndex, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex)
        {
            char c;
            while (startIndex < endIndex)
            {
                c = str[startIndex];
                if (c == primaryLeftQuote) _searchRightQuote(str, ref startIndex, endIndex, primaryLeftQuote, primaryRightQuote);
                else if (c == secondaryLeftQuote) _searchRightQuote(str, ref startIndex, endIndex, secondaryLeftQuote, secondaryRightQuote, primaryLeftQuote, primaryRightQuote);
                else if ((hitIndex = keychars.IndexOf(c)) != -1) return startIndex;
                ++startIndex;
            }

            hitIndex = -1;
            return -1;
        }

        internal static int _innerIndexOfWithQuotes(string str, char[] keychars, int startIndex, int endIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote)
        {
            if (primaryLeftQuotes == null)
            {
                if (primaryRightQuotes == null)
                    return _innerIndexOfWithQuotes(str, keychars, startIndex, endIndex, secondaryLeftQuote, secondaryRightQuote);
                else throw new ArgumentNullException("primaryLeftQuotes");
            }
            else if (primaryRightQuotes == null)
                throw new ArgumentNullException("primaryRightQuotes");

            char c;
            int quoteIdx;
            while (startIndex < endIndex)
            {
                c = str[startIndex];
                quoteIdx = primaryLeftQuotes.IndexOf(c);
                if (quoteIdx != -1) _searchRightQuote(str, ref startIndex, endIndex, c, primaryRightQuotes[quoteIdx]);
                else if (c == secondaryLeftQuote) _searchRightQuote(str, ref startIndex, endIndex, secondaryLeftQuote, secondaryRightQuote, primaryLeftQuotes, primaryRightQuotes);
                else if (c.In(keychars)) return startIndex;
                ++startIndex;
            }

            return -1;
        }

        internal static int _innerIndexOfWithQuotes(string str, char[] keychars, int startIndex, int endIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, out int hitIndex)
        {
            if (primaryLeftQuotes == null)
            {
                if (primaryRightQuotes == null)
                    return _innerIndexOfWithQuotes(str, keychars, startIndex, endIndex, secondaryLeftQuote, secondaryRightQuote, out hitIndex);
                else throw new ArgumentNullException("primaryLeftQuotes");
            }
            else if (primaryRightQuotes == null)
                throw new ArgumentNullException("primaryRightQuotes");

            char c;
            int quoteIdx;
            while (startIndex < endIndex)
            {
                c = str[startIndex];
                quoteIdx = primaryLeftQuotes.IndexOf(c);
                if (quoteIdx != -1) _searchRightQuote(str, ref startIndex, endIndex, c, primaryRightQuotes[quoteIdx]);
                else if (c == secondaryLeftQuote) _searchRightQuote(str, ref startIndex, endIndex, secondaryLeftQuote, secondaryRightQuote, primaryLeftQuotes, primaryRightQuotes);
                else if ((hitIndex = keychars.IndexOf(c)) != -1) return startIndex;
                ++startIndex;
            }

            hitIndex = -1;
            return -1;
        }

        internal static int _innerIndexOfWithQuotes(string str, char[] keychars, int startIndex, int endIndex, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            char c;
            int quoteIdx;
            while (startIndex < endIndex)
            {
                c = str[startIndex];
                if (c == primaryLeftQuote) _searchRightQuote(str, ref startIndex, endIndex, primaryLeftQuote, primaryRightQuote);
                else
                {
                    quoteIdx = secondaryLeftQuotes.IndexOf(c);
                    if (quoteIdx != -1) _searchRightQuote(str, ref startIndex, endIndex, c, secondaryRightQuotes[quoteIdx], primaryLeftQuote, primaryRightQuote);
                    else if (c.In(keychars)) return startIndex;
                }
                ++startIndex;
            }

            return -1;
        }

        internal static int _innerIndexOfWithQuotes(string str, char[] keychars, int startIndex, int endIndex, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex)
        {
            char c;
            int quoteIdx;
            while (startIndex < endIndex)
            {
                c = str[startIndex];
                if (c == primaryLeftQuote) _searchRightQuote(str, ref startIndex, endIndex, primaryLeftQuote, primaryRightQuote);
                else
                {
                    quoteIdx = secondaryLeftQuotes.IndexOf(c);
                    if (quoteIdx != -1) _searchRightQuote(str, ref startIndex, endIndex, c, secondaryRightQuotes[quoteIdx], primaryLeftQuote, primaryRightQuote);
                    else if ((hitIndex = keychars.IndexOf(c)) != -1) return startIndex;
                }
                ++startIndex;
            }

            hitIndex = -1;
            return -1;
        }

        internal static int _innerIndexOfWithQuotes(string str, char[] keychars, int startIndex, int endIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            if (primaryLeftQuotes == null)
            {
                if (primaryRightQuotes == null)
                    return _innerIndexOfWithQuotes(str, keychars, startIndex, endIndex, secondaryLeftQuotes, secondaryRightQuotes);
                else throw new ArgumentNullException("primaryLeftQuotes");
            }
            else if (primaryRightQuotes == null)
                throw new ArgumentNullException("primaryRightQuotes");

            char c;
            int quoteIdx;
            while (startIndex < endIndex)
            {
                c = str[startIndex];
                quoteIdx = primaryLeftQuotes.IndexOf(c);
                if (quoteIdx != -1) _searchRightQuote(str, ref startIndex, endIndex, c, primaryRightQuotes[quoteIdx]);
                else
                {
                    quoteIdx = secondaryLeftQuotes.IndexOf(c);
                    if (quoteIdx != -1) _searchRightQuote(str, ref startIndex, endIndex, c, secondaryRightQuotes[quoteIdx], primaryLeftQuotes, primaryRightQuotes);
                    else if (c.In(keychars)) return startIndex;
                }
                ++startIndex;
            }

            return -1;
        }

        internal static int _innerIndexOfWithQuotes(string str, char[] keychars, int startIndex, int endIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, out int hitIndex)
        {
            if (primaryLeftQuotes == null)
            {
                if (primaryRightQuotes == null)
                    return _innerIndexOfWithQuotes(str, keychars, startIndex, endIndex, secondaryLeftQuotes, secondaryRightQuotes, out hitIndex);
                else throw new ArgumentNullException("primaryLeftQuotes");
            }
            else if (primaryRightQuotes == null)
                throw new ArgumentNullException("primaryRightQuotes");

            char c;
            int quoteIdx;
            while (startIndex < endIndex)
            {
                c = str[startIndex];
                quoteIdx = primaryLeftQuotes.IndexOf(c);
                if (quoteIdx != -1) _searchRightQuote(str, ref startIndex, endIndex, c, primaryRightQuotes[quoteIdx]);
                else
                {
                    quoteIdx = secondaryLeftQuotes.IndexOf(c);
                    if (quoteIdx != -1) _searchRightQuote(str, ref startIndex, endIndex, c, secondaryRightQuotes[quoteIdx], primaryLeftQuotes, primaryRightQuotes);
                    else if ((hitIndex = keychars.IndexOf(c)) != -1) return startIndex;
                }
                ++startIndex;
            }

            hitIndex = -1;
            return -1;
        }

        #endregion
    }
}
