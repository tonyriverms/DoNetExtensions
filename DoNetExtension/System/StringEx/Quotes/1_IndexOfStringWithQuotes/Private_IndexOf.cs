using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_Extension_Library.System;

namespace System
{
    public static partial class StringEx
    {
        #region One-Layer Quotes

        static int _innerIndexOfWithQuotes(string str, string value, int startIndex, int endIndex, char leftQuote, char rightQuote, StringComparison comparisonType)
        {
            var valuePosition = str.IndexOf(value, startIndex, endIndex - startIndex, comparisonType);
            if (valuePosition == -1) return -1;

            while (startIndex < endIndex)
            {
                if (startIndex == valuePosition) return startIndex;
                else
                {
                    var c = str[startIndex];
                    if (c == leftQuote)
                    {
                        _searchRightQuote(str, ref startIndex, endIndex, leftQuote, rightQuote);
                        if (valuePosition <= startIndex)
                        {
                            valuePosition = str.IndexOf(value, startIndex + 1, endIndex - startIndex - 1, comparisonType);
                            if (valuePosition == -1) return -1;
                        }
                    }
                    ++startIndex;
                }
            }
            return -1;
        }

        static int _innerIndexOfWithQuotes(string str, string value, int startIndex, int endIndex, char[] leftQuotes, char[] rightQuotes, StringComparison comparisonType)
        {
            var valuePosition = str.IndexOf(value, startIndex, endIndex - startIndex, comparisonType);
            if (valuePosition == -1) return -1;

            while (startIndex < endIndex)
            {
                if (startIndex == valuePosition) return startIndex;
                else
                {
                    var c = str[startIndex];
                    var quoteIndex = leftQuotes.IndexOf(c);
                    if (quoteIndex != -1)
                    {
                        _searchRightQuote(str, ref startIndex, endIndex, leftQuotes[quoteIndex], rightQuotes[quoteIndex]);

                        if (valuePosition <= startIndex)
                        {
                            valuePosition = str.IndexOf(value, startIndex + 1, endIndex - startIndex - 1, comparisonType);
                            if (valuePosition == -1 || valuePosition >= endIndex) return -1;
                        }
                    }
                    ++startIndex;
                }
            }
            return -1;
        }

        static StringSearchResult _innerIndexOfWithQuotes(string str, string[] values, int startIndex, int endIndex, char leftQuote, char rightQuote, StringComparison comparisonType)
        {
            var idxResult = str.IndexOfAny(values, startIndex, endIndex - startIndex, comparisonType);
            if (idxResult == null) return null;

            int i = startIndex;
            while (i < endIndex)
            {
                if (i == idxResult.Position)
                    return idxResult;
                else
                {
                    var c = str[i];
                    if (c == leftQuote)
                    {
                        _searchRightQuote(str, ref i, endIndex, leftQuote, rightQuote);
                        if (idxResult.Position <= i)
                        {
                            idxResult = str.IndexOfAny(values, i + 1, endIndex - i - 1, comparisonType);
                            if (idxResult == null || idxResult.Position >= endIndex)
                                return null;
                        }
                    }
                    ++i;
                }
            }
            return null;
        }

        static StringSearchResult _innerIndexOfWithQuotes(string str, string[] values, int startIndex, int endIndex, char[] leftQuotes, char[] rightQuotes, StringComparison comparisonType)
        {
            var idxResult = str.IndexOfAny(values, startIndex, endIndex - startIndex, comparisonType);
            if (idxResult == null) return null;

            int i = startIndex;
            while (i < endIndex)
            {
                if (i == idxResult.Position)
                    return idxResult;
                else
                {
                    var c = str[i];
                    var quoteIndex = leftQuotes.IndexOf(c);
                    if (quoteIndex != -1)
                    {
                        var leftQuote = leftQuotes[quoteIndex];
                        var rightQuote = rightQuotes[quoteIndex];
                        _searchRightQuote(str, ref i, endIndex, leftQuote, rightQuote);

                        if (idxResult.Position <= i)
                        {
                            idxResult = str.IndexOfAny(values, i + 1, endIndex - i - 1, comparisonType);
                            if (idxResult == null || idxResult.Position >= endIndex)
                                return null;
                        }
                    }
                    ++i;
                }
            }
            return null;
        }

        #endregion

        #region Two-Layer Quotes

        internal static int _innerIndexOfWithQuotes(string str, string value, int startIndex, int endIndex, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, StringComparison comparisonType)
        {
            var valuePosition = str.IndexOf(value, startIndex, endIndex - startIndex, comparisonType);
            if (valuePosition == -1) return -1;

            while (startIndex < endIndex)
            {
                if (startIndex == valuePosition) return startIndex;
                else
                {
                    var c = str[startIndex];
                    bool quoteHit;
                    if (c == primaryLeftQuote)
                    {
                        _searchRightQuote(str, ref startIndex, endIndex, primaryLeftQuote, primaryRightQuote);
                        quoteHit = true;
                    }
                    else if (c == secondaryLeftQuote)
                    {
                        _searchRightQuote(str, ref startIndex, endIndex, secondaryLeftQuote, secondaryRightQuote, primaryLeftQuote, primaryRightQuote);
                        quoteHit = true;
                    }
                    else quoteHit = false;

                    if (quoteHit && valuePosition <= startIndex)
                    {
                        valuePosition = str.IndexOf(value, startIndex + 1, endIndex - startIndex - 1, comparisonType);
                        if (valuePosition == -1) return -1;
                    }
                    ++startIndex;
                }
            }
            return -1;
        }

        internal static int _innerIndexOfWithQuotes(string str, string value, int startIndex, int endIndex, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, StringComparison comparisonType)
        {
            var valuePosition = str.IndexOf(value, startIndex, endIndex - startIndex, comparisonType);
            if (valuePosition == -1) return -1;

            while (startIndex < endIndex)
            {
                if (startIndex == valuePosition) return startIndex;
                else
                {
                    var c = str[startIndex];
                    bool quoteHit;
                    if (c == primaryLeftQuote)
                    {
                        _searchRightQuote(str, ref startIndex, endIndex, primaryLeftQuote, primaryRightQuote);
                        quoteHit = true;
                    }
                    else
                    {
                        var quoteIdx = secondaryLeftQuotes.IndexOf(c);
                        if (quoteIdx != -1)
                        {
                            _searchRightQuote(str, ref startIndex, endIndex, c, secondaryRightQuotes[quoteIdx], primaryLeftQuote, primaryRightQuote);
                            quoteHit = true;
                        }
                        else quoteHit = false;
                    }

                    if (quoteHit && valuePosition <= startIndex)
                    {
                        valuePosition = str.IndexOf(value, startIndex + 1, endIndex - startIndex - 1, comparisonType);
                        if (valuePosition == -1) return -1;
                    }
                    ++startIndex;
                }
            }
            return -1;
        }

        internal static int _innerIndexOfWithQuotes(string str, string value, int startIndex, int endIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, StringComparison comparisonType)
        {
            var valuePosition = str.IndexOf(value, startIndex, endIndex - startIndex, comparisonType);
            if (valuePosition == -1) return -1;

            while (startIndex < endIndex)
            {
                if (startIndex == valuePosition) return startIndex;
                else
                {
                    var c = str[startIndex];
                    bool quoteHit;
                    var quoteIdx = primaryLeftQuotes.IndexOf(c);

                    if (quoteIdx != -1)
                    {
                        _searchRightQuote(str, ref startIndex, endIndex, c, primaryRightQuotes[quoteIdx]);
                        quoteHit = true;
                    }
                    else if (c == secondaryLeftQuote)
                    {
                        _searchRightQuote(str, ref startIndex, endIndex, secondaryLeftQuote, secondaryRightQuote, primaryLeftQuotes, primaryRightQuotes);
                        quoteHit = true;
                    }
                    else quoteHit = false;

                    if (quoteHit && valuePosition <= startIndex)
                    {
                        valuePosition = str.IndexOf(value, startIndex + 1, endIndex - startIndex - 1, comparisonType);
                        if (valuePosition == -1) return -1;
                    }
                    ++startIndex;
                }
            }
            return -1;
        }

        internal static int _innerIndexOfWithQuotes(string str, string value, int startIndex, int endIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, StringComparison comparisonType)
        {
            var valuePosition = str.IndexOf(value, startIndex, endIndex - startIndex, comparisonType);
            if (valuePosition == -1) return -1;

            while (startIndex < endIndex)
            {
                if (startIndex == valuePosition) return startIndex;
                else
                {
                    var c = str[startIndex];
                    bool quoteHit;
                    var quoteIdx = primaryLeftQuotes.IndexOf(c);

                    if (quoteIdx != -1)
                    {
                        _searchRightQuote(str, ref startIndex, endIndex, c, primaryRightQuotes[quoteIdx]);
                        quoteHit = true;
                    }
                    else
                    {
                        quoteIdx = secondaryLeftQuotes.IndexOf(c);
                        if (quoteIdx != -1)
                        {
                            _searchRightQuote(str, ref startIndex, endIndex, c, secondaryRightQuotes[quoteIdx], primaryLeftQuotes, primaryRightQuotes);
                            quoteHit = true;
                        }
                        else quoteHit = false;
                    }

                    if (quoteHit && valuePosition <= startIndex)
                    {
                        valuePosition = str.IndexOf(value, startIndex + 1, endIndex - startIndex - 1, comparisonType);
                        if (valuePosition == -1) return -1;
                    }
                    ++startIndex;
                }
            }
            return -1;
        }

        internal static StringSearchResult _innerIndexOfWithQuotes(string str, string[] values, int startIndex, int endIndex, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, StringComparison comparisonType)
        {
            var valuePositionInfo = str.IndexOfAny(values, startIndex, endIndex - startIndex, comparisonType);
            if (valuePositionInfo == null) return null;

            while (startIndex < endIndex)
            {
                if (startIndex == valuePositionInfo.Position) return valuePositionInfo;
                else
                {
                    var c = str[startIndex];
                    bool quoteHit;
                    if (c == primaryLeftQuote)
                    {
                        _searchRightQuote(str, ref startIndex, endIndex, primaryLeftQuote, primaryRightQuote);
                        quoteHit = true;
                    }
                    else if (c == secondaryLeftQuote)
                    {
                        _searchRightQuote(str, ref startIndex, endIndex, secondaryLeftQuote, secondaryRightQuote, primaryLeftQuote, primaryRightQuote);
                        quoteHit = true;
                    }
                    else quoteHit = false;

                    if (quoteHit && valuePositionInfo.Position <= startIndex)
                    {
                        valuePositionInfo = str.IndexOfAny(values, startIndex + 1, endIndex - startIndex - 1, comparisonType);
                        if (valuePositionInfo == null) return null;
                    }
                    ++startIndex;
                }
            }
            return null;
        }

        internal static StringSearchResult _innerIndexOfWithQuotes(string str, string[] values, int startIndex, int endIndex, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, StringComparison comparisonType)
        {
            var valuePosition = str.IndexOfAny(values, startIndex, endIndex - startIndex, comparisonType);
            if (valuePosition == null) return null;

            while (startIndex < endIndex)
            {
                if (startIndex == valuePosition.Position) return valuePosition;
                else
                {
                    var c = str[startIndex];
                    bool quoteHit;
                    if (c == primaryLeftQuote)
                    {
                        _searchRightQuote(str, ref startIndex, endIndex, primaryLeftQuote, primaryRightQuote);
                        quoteHit = true;
                    }
                    else
                    {
                        var quoteIdx = secondaryLeftQuotes.IndexOf(c);
                        if (quoteIdx != -1)
                        {
                            _searchRightQuote(str, ref startIndex, endIndex, c, secondaryRightQuotes[quoteIdx], primaryLeftQuote, primaryRightQuote);
                            quoteHit = true;
                        }
                        else quoteHit = false;
                    }

                    if (quoteHit && valuePosition.Position <= startIndex)
                    {
                        valuePosition = str.IndexOfAny(values, startIndex + 1, endIndex - startIndex - 1, comparisonType);
                        if (valuePosition == null) return null;
                    }
                    ++startIndex;
                }
            }
            return null;
        }

        internal static StringSearchResult _innerIndexOfWithQuotes(string str, string[] values, int startIndex, int endIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, StringComparison comparisonType)
        {
            var valuePosition = str.IndexOfAny(values, startIndex, endIndex - startIndex, comparisonType);
            if (valuePosition == null) return null;

            while (startIndex < endIndex)
            {
                if (startIndex == valuePosition.Position) return valuePosition;
                else
                {
                    var c = str[startIndex];
                    bool quoteHit;
                    var quoteIdx = primaryLeftQuotes.IndexOf(c);

                    if (quoteIdx != -1)
                    {
                        _searchRightQuote(str, ref startIndex, endIndex, c, primaryRightQuotes[quoteIdx]);
                        quoteHit = true;
                    }
                    else if (c == secondaryLeftQuote)
                    {
                        _searchRightQuote(str, ref startIndex, endIndex, secondaryLeftQuote, secondaryRightQuote, primaryLeftQuotes, primaryRightQuotes);
                        quoteHit = true;
                    }
                    else quoteHit = false;

                    if (quoteHit && valuePosition.Position <= startIndex)
                    {
                        valuePosition = str.IndexOfAny(values, startIndex + 1, endIndex - startIndex - 1, comparisonType);
                        if (valuePosition == null) return null;
                    }
                    ++startIndex;
                }
            }
            return null;
        }

        internal static StringSearchResult _innerIndexOfWithQuotes(string str, string[] values, int startIndex, int endIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, StringComparison comparisonType)
        {
            var valuePosition = str.IndexOfAny(values, startIndex, endIndex - startIndex, comparisonType);
            if (valuePosition == null) return null;

            while (startIndex < endIndex)
            {
                if (startIndex == valuePosition.Position) return valuePosition;
                else
                {
                    var c = str[startIndex];
                    bool quoteHit;
                    var quoteIdx = primaryLeftQuotes.IndexOf(c);

                    if (quoteIdx != -1)
                    {
                        _searchRightQuote(str, ref startIndex, endIndex, c, primaryRightQuotes[quoteIdx]);
                        quoteHit = true;
                    }
                    else
                    {
                        quoteIdx = secondaryLeftQuotes.IndexOf(c);
                        if (quoteIdx != -1)
                        {
                            _searchRightQuote(str, ref startIndex, endIndex, c, secondaryRightQuotes[quoteIdx], primaryLeftQuotes, primaryRightQuotes);
                            quoteHit = true;
                        }
                        else quoteHit = false;
                    }

                    if (quoteHit && valuePosition.Position <= startIndex)
                    {
                        valuePosition = str.IndexOfAny(values, startIndex + 1, endIndex - startIndex - 1, comparisonType);
                        if (valuePosition == null) return null;
                    }
                    ++startIndex;
                }
            }
            return null;
        }

        #endregion
    }
}
