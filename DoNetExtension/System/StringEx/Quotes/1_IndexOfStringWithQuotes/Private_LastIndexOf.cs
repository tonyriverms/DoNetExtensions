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

        static int _innerLastIndexOfWithQuotes(this string str, string value, int startIndex, int endIndex, char leftQuote, char rightQuote, StringComparison comparisonType)
        {
            var idxResult = str.LastIndexOf(value, startIndex, startIndex - endIndex, comparisonType);
            if (idxResult == -1) return -1;

            while (startIndex > endIndex)
            {
                if (startIndex == idxResult) return startIndex;
                else
                {
                    var c = str[startIndex];
                    if (c == rightQuote)
                    {
                        _searchLeftQuote(str, ref startIndex, endIndex, leftQuote, rightQuote);
                        if (idxResult >= startIndex)
                        {
                            idxResult = str.LastIndexOf(value, startIndex - 1, startIndex - 1 - endIndex, comparisonType);
                            if (idxResult == -1) return -1;
                        }
                    }
                    --startIndex;
                }
            }
            return -1;
        }

        static int _innerLastIndexOfWithQuotes(this string str, string value, int startIndex, int endIndex, char[] leftQuotes, char[] rightQuotes, StringComparison comparisonType)
        {
            var idxResult = str.LastIndexOf(value, startIndex, startIndex - endIndex, comparisonType);
            if (idxResult == -1) return -1;

            while (startIndex > endIndex)
            {
                if (startIndex == idxResult) return startIndex;
                else
                {
                    var c = str[startIndex];
                    var quoteIndex = rightQuotes.IndexOf(c);
                    if (quoteIndex != -1)
                    {
                        var leftQuote = leftQuotes[quoteIndex];
                        var rightQuote = rightQuotes[quoteIndex];
                        _searchLeftQuote(str, ref startIndex, endIndex, leftQuote, rightQuote);

                        if (idxResult >= startIndex)
                        {
                            idxResult = str.LastIndexOf(value, startIndex - 1, startIndex - 1 - endIndex, comparisonType);
                            if (idxResult == -1) return -1;
                        }
                    }
                    --startIndex;
                }
            }
            return -1;
        }

        static StringSearchResult _innerLastIndexOfWithQuotes(this string str, string[] values, int startIndex, int endIndex, char leftQuote, char rightQuote, StringComparison comparisonType)
        {
            var idxResult = str.LastIndexOfAny(values, startIndex, startIndex - endIndex, comparisonType);
            if (idxResult == null) return null;

            while (startIndex > endIndex)
            {
                if (startIndex == idxResult.Position)
                    return idxResult;
                else
                {
                    var c = str[startIndex];
                    if (c == rightQuote)
                    {
                        _searchLeftQuote(str, ref startIndex, endIndex, leftQuote, rightQuote);
                        if (idxResult.Position >= startIndex)
                        {
                            if (startIndex == 0) return null;
                            idxResult = str.LastIndexOfAny(values, startIndex - 1, startIndex - 1 - endIndex, comparisonType);
                            if (idxResult == null) return null;
                        }
                    }
                    --startIndex;
                }
            }
            return null;
        }

        static StringSearchResult _innerLastIndexOfWithQuotes(this string str, string[] values, int startIndex, int endIndex, char[] leftQuotes, char[] rightQuotes, StringComparison comparisonType)
        {
            var idxResult = str.LastIndexOfAny(values, startIndex, startIndex - endIndex, comparisonType);
            if (idxResult == null) return null;

            while (startIndex > endIndex)
            {
                if (startIndex == idxResult.Position)
                    return idxResult;
                else
                {
                    var c = str[startIndex];
                    var quoteIndex = rightQuotes.IndexOf(c);
                    if (quoteIndex != -1)
                    {
                        var leftQuote = leftQuotes[quoteIndex];
                        var rightQuote = rightQuotes[quoteIndex];
                        _searchLeftQuote(str, ref startIndex, endIndex, leftQuote, rightQuote);

                        if (idxResult.Position >= startIndex)
                        {
                            if (startIndex == 0) return null;
                            idxResult = str.LastIndexOfAny(values, startIndex - 1, startIndex - 1 - endIndex, comparisonType);
                            if (idxResult == null) return null;
                        }
                    }
                    --startIndex;
                }
            }
            return null;
        }
        #endregion

        #region Two-Layer Quotes

        static int _innerLastIndexOfWithQuotes(this string str, string value, int startIndex, int endIndex, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, StringComparison comparisonType)
        {
            var valuePosition = str.LastIndexOf(value, startIndex, startIndex - endIndex, comparisonType);
            if (valuePosition == -1) return -1;

            while (startIndex > endIndex)
            {
                if (startIndex == valuePosition) return startIndex;
                else
                {
                    var c = str[startIndex];
                    bool quoteHit;
                    if (c == primaryRightQuote)
                    {
                        _searchLeftQuote(str, ref startIndex, endIndex, primaryLeftQuote, primaryRightQuote);
                        quoteHit = true;
                    }
                    else if (c == secondaryRightQuote)
                    {
                        _searchLeftQuote(str, ref startIndex, endIndex, secondaryLeftQuote, secondaryRightQuote, primaryLeftQuote, primaryRightQuote);
                        quoteHit = true;
                    }
                    else quoteHit = false;

                    if (quoteHit && valuePosition >= startIndex)
                    {
                        valuePosition = str.LastIndexOf(value, startIndex - 1, startIndex - 1 - endIndex, comparisonType);
                        if (valuePosition == -1) return -1;
                    }
                    --startIndex;
                }
            }
            return -1;
        }

        static int _innerLastIndexOfWithQuotes(this string str, string value, int startIndex, int endIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, StringComparison comparisonType)
        {
            var valuePosition = str.LastIndexOf(value, startIndex, startIndex - endIndex, comparisonType);
            if (valuePosition == -1) return -1;
            int quoteIdx;

            while (startIndex > endIndex)
            {
                if (startIndex == valuePosition) return startIndex;
                else
                {
                    var c = str[startIndex];
                    bool quoteHit;
                    quoteIdx = primaryRightQuotes.IndexOf(c);
                    if (quoteIdx != -1)
                    {
                        _searchLeftQuote(str, ref startIndex, endIndex, primaryLeftQuotes[quoteIdx], c);
                        quoteHit = true;
                    }
                    else if (c == secondaryRightQuote)
                    {
                        _searchLeftQuote(str, ref startIndex, endIndex, secondaryLeftQuote, secondaryRightQuote, primaryLeftQuotes, primaryRightQuotes);
                        quoteHit = true;
                    }
                    else quoteHit = false;

                    if (quoteHit && valuePosition >= startIndex)
                    {
                        valuePosition = str.LastIndexOf(value, startIndex - 1, startIndex - 1 - endIndex, comparisonType);
                        if (valuePosition == -1) return -1;
                    }
                    --startIndex;
                }
            }
            return -1;
        }

        static int _innerLastIndexOfWithQuotes(this string str, string value, int startIndex, int endIndex, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, StringComparison comparisonType)
        {
            var valuePosition = str.LastIndexOf(value, startIndex, startIndex - endIndex, comparisonType);
            if (valuePosition == -1) return -1;

            while (startIndex > endIndex)
            {
                if (startIndex == valuePosition) return startIndex;
                else
                {
                    var c = str[startIndex];
                    bool quoteHit;
                    if (c == primaryRightQuote)
                    {
                        _searchLeftQuote(str, ref startIndex, endIndex, primaryLeftQuote, primaryRightQuote);
                        quoteHit = true;
                    }
                    else
                    {
                        var quoteIdx = secondaryRightQuotes.IndexOf(c);
                        if (quoteIdx != -1)
                        {
                            _searchLeftQuote(str, ref startIndex, endIndex, secondaryLeftQuotes[quoteIdx], c, primaryLeftQuote, primaryRightQuote);
                            quoteHit = true;
                        }
                        else quoteHit = false;
                    }

                    if (quoteHit && valuePosition >= startIndex)
                    {
                        valuePosition = str.LastIndexOf(value, startIndex - 1, startIndex - 1 - endIndex, comparisonType);
                        if (valuePosition == -1) return -1;
                    }
                    --startIndex;
                }
            }
            return -1;
        }

        static int _innerLastIndexOfWithQuotes(this string str, string value, int startIndex, int endIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, StringComparison comparisonType)
        {
            var valuePosition = str.LastIndexOf(value, startIndex, startIndex - endIndex, comparisonType);
            if (valuePosition == -1) return -1;
            int quoteIdx;

            while (startIndex > endIndex)
            {
                if (startIndex == valuePosition) return startIndex;
                else
                {
                    var c = str[startIndex];
                    bool quoteHit;
                    quoteIdx = primaryRightQuotes.IndexOf(c);
                    if (quoteIdx != -1)
                    {
                        _searchLeftQuote(str, ref startIndex, endIndex, primaryLeftQuotes[quoteIdx], c);
                        quoteHit = true;
                    }
                    else
                    {
                        quoteIdx = secondaryRightQuotes.IndexOf(c);
                        if (quoteIdx != -1)
                        {
                            _searchLeftQuote(str, ref startIndex, endIndex, secondaryLeftQuotes[quoteIdx], c, primaryLeftQuotes, primaryRightQuotes);
                            quoteHit = true;
                        }
                        else quoteHit = false;
                    }

                    if (quoteHit && valuePosition >= startIndex)
                    {
                        valuePosition = str.LastIndexOf(value, startIndex - 1, startIndex - 1 - endIndex, comparisonType);
                        if (valuePosition == -1) return -1;
                    }
                    --startIndex;
                }
            }
            return -1;
        }

        static StringSearchResult _innerLastIndexOfWithQuotes(this string str, string[] values, int startIndex, int endIndex, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, StringComparison comparisonType)
        {
            var valuePosition = str.LastIndexOfAny(values, startIndex, startIndex - endIndex, comparisonType);
            if (valuePosition == null) return null;

            while (startIndex > endIndex)
            {
                if (startIndex == valuePosition.Position) return valuePosition;
                else
                {
                    var c = str[startIndex];
                    bool quoteHit;
                    if (c == primaryRightQuote)
                    {
                        _searchLeftQuote(str, ref startIndex, endIndex, primaryLeftQuote, primaryRightQuote);
                        quoteHit = true;
                    }
                    else if (c == secondaryRightQuote)
                    {
                        _searchLeftQuote(str, ref startIndex, endIndex, secondaryLeftQuote, secondaryRightQuote, primaryLeftQuote, primaryRightQuote);
                        quoteHit = true;
                    }
                    else quoteHit = false;

                    if (quoteHit && valuePosition.Position >= startIndex)
                    {
                        valuePosition = str.LastIndexOfAny(values, startIndex - 1, startIndex - 1 - endIndex, comparisonType);
                        if (valuePosition == null) return null;
                    }
                    --startIndex;
                }
            }
            return null;
        }

        static StringSearchResult _innerLastIndexOfWithQuotes(this string str, string[] values, int startIndex, int endIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, StringComparison comparisonType)
        {
            var valuePosition = str.LastIndexOfAny(values, startIndex, startIndex - endIndex, comparisonType);
            if (valuePosition == null) return null;
            int quoteIdx;

            while (startIndex > endIndex)
            {
                if (startIndex == valuePosition.Position) return valuePosition;
                else
                {
                    var c = str[startIndex];
                    bool quoteHit;
                    quoteIdx = primaryRightQuotes.IndexOf(c);
                    if (quoteIdx != -1)
                    {
                        _searchLeftQuote(str, ref startIndex, endIndex, primaryLeftQuotes[quoteIdx], c);
                        quoteHit = true;
                    }
                    else if (c == secondaryRightQuote)
                    {
                        _searchLeftQuote(str, ref startIndex, endIndex, secondaryLeftQuote, secondaryRightQuote, primaryLeftQuotes, primaryRightQuotes);
                        quoteHit = true;
                    }
                    else quoteHit = false;

                    if (quoteHit && valuePosition.Position >= startIndex)
                    {
                        valuePosition = str.LastIndexOfAny(values, startIndex - 1, startIndex - 1 - endIndex, comparisonType);
                        if (valuePosition == null) return null;
                    }
                    --startIndex;
                }
            }
            return null;
        }

        static StringSearchResult _innerLastIndexOfWithQuotes(this string str, string[] values, int startIndex, int endIndex, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, StringComparison comparisonType)
        {
            var valuePosition = str.LastIndexOfAny(values, startIndex, startIndex - endIndex, comparisonType);
            if (valuePosition == null) return null;

            while (startIndex > endIndex)
            {
                if (startIndex == valuePosition.Position) return valuePosition;
                else
                {
                    var c = str[startIndex];
                    bool quoteHit;
                    if (c == primaryRightQuote)
                    {
                        _searchLeftQuote(str, ref startIndex, endIndex, primaryLeftQuote, primaryRightQuote);
                        quoteHit = true;
                    }
                    else
                    {
                        var quoteIdx = secondaryRightQuotes.IndexOf(c);
                        if (quoteIdx != -1)
                        {
                            _searchLeftQuote(str, ref startIndex, endIndex, secondaryLeftQuotes[quoteIdx], c, primaryLeftQuote, primaryRightQuote);
                            quoteHit = true;
                        }
                        else quoteHit = false;
                    }

                    if (quoteHit && valuePosition.Position >= startIndex)
                    {
                        valuePosition = str.LastIndexOfAny(values, startIndex - 1, startIndex - 1 - endIndex, comparisonType);
                        if (valuePosition == null) return null;
                    }
                    --startIndex;
                }
            }
            return null;
        }

        static StringSearchResult _innerLastIndexOfWithQuotes(this string str, string[] values, int startIndex, int endIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, StringComparison comparisonType)
        {
            var valuePosition = str.LastIndexOfAny(values, startIndex, startIndex - endIndex, comparisonType);
            if (valuePosition == null) return null;
            int quoteIdx;

            while (startIndex > endIndex)
            {
                if (startIndex == valuePosition.Position) return valuePosition;
                else
                {
                    var c = str[startIndex];
                    bool quoteHit;
                    quoteIdx = primaryRightQuotes.IndexOf(c);
                    if (quoteIdx != -1)
                    {
                        _searchLeftQuote(str, ref startIndex, endIndex, primaryLeftQuotes[quoteIdx], c);
                        quoteHit = true;
                    }
                    else
                    {
                        quoteIdx = secondaryRightQuotes.IndexOf(c);
                        if (quoteIdx != -1)
                        {
                            _searchLeftQuote(str, ref startIndex, endIndex, secondaryLeftQuotes[quoteIdx], c, primaryLeftQuotes, primaryRightQuotes);
                            quoteHit = true;
                        }
                        else quoteHit = false;
                    }

                    if (quoteHit && valuePosition.Position >= startIndex)
                    {
                        valuePosition = str.LastIndexOfAny(values, startIndex - 1, startIndex - 1 - endIndex, comparisonType);
                        if (valuePosition == null) return null;
                    }
                    --startIndex;
                }
            }
            return null;
        }
        #endregion
    }
}
