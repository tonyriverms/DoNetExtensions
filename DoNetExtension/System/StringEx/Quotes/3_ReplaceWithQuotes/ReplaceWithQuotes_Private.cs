using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class StringEx
    {
        static string _innerReplaceWithQuotes(this string str, Func<char, bool> predicate, char newChar, int startIndex, int endIndex, char leftQuote, char rightQuote)
        {
            var sb = StringBuilderCache.Acquire(str.Length);
            if (startIndex != 0) sb.Append(str.Substring(0, startIndex));
            int i;
            while ((i = _innerIndexOfWithQuotes(str, predicate, startIndex, endIndex, leftQuote, rightQuote)) != -1)
            {
                sb.Append(str.Substring(startIndex, i - startIndex));
                sb.Append(newChar);
                startIndex = i + 1;
            }

            sb.Append(str.Substring(startIndex));
            return StringBuilderCache.GetStringAndRelease(sb);
        }

        static string _innerReplaceWithQuotes(string str, Func<char, bool> predicate, char newChar, int startIndex, int endIndex, char[] leftQuotes, char[] rightQuotes)
        {
            var sb = StringBuilderCache.Acquire(str.Length);
            if (startIndex != 0) sb.Append(str.Substring(0, startIndex));
            int i;
            while ((i = _innerIndexOfWithQuotes(str, predicate, startIndex, endIndex, leftQuotes, rightQuotes)) != -1)
            {
                sb.Append(str.Substring(startIndex, i - startIndex));
                sb.Append(newChar);
                startIndex = i + 1;
            }

            sb.Append(str.Substring(startIndex));
            return StringBuilderCache.GetStringAndRelease(sb);
        }

        static string _innerReplaceWithQuotes(this string str, Func<char, bool> predicate, char newChar, int startIndex, int endIndex, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote)
        {
            var sb = StringBuilderCache.Acquire(str.Length);
            if (startIndex != 0) sb.Append(str.Substring(0, startIndex));
            int i;
            while ((i = _innerIndexOfWithQuotes(str, predicate, startIndex, endIndex, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote)) != -1)
            {
                sb.Append(str.Substring(startIndex, i - startIndex));
                sb.Append(newChar);
                startIndex = i + 1;
            }

            sb.Append(str.Substring(startIndex));
            return StringBuilderCache.GetStringAndRelease(sb);
        }

        static string _innerReplaceWithQuotes(this string str, Func<char, bool> predicate, char newChar, int startIndex, int endIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote)
        {
            var sb = StringBuilderCache.Acquire(str.Length);
            if (startIndex != 0) sb.Append(str.Substring(0, startIndex));
            int i;
            while ((i = _innerIndexOfWithQuotes(str, predicate, startIndex, endIndex, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote)) != -1)
            {
                sb.Append(str.Substring(startIndex, i - startIndex));
                sb.Append(newChar);
                startIndex = i + 1;
            }

            sb.Append(str.Substring(startIndex));
            return StringBuilderCache.GetStringAndRelease(sb);
        }

        static string _innerReplaceWithQuotes(this string str, Func<char, bool> predicate, char newChar, int startIndex, int endIndex, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            var sb = StringBuilderCache.Acquire(str.Length);
            if (startIndex != 0) sb.Append(str.Substring(0, startIndex));
            int i;
            while ((i = _innerIndexOfWithQuotes(str, predicate, startIndex, endIndex, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes)) != -1)
            {
                sb.Append(str.Substring(startIndex, i - startIndex));
                sb.Append(newChar);
                startIndex = i + 1;
            }

            sb.Append(str.Substring(startIndex));
            return StringBuilderCache.GetStringAndRelease(sb);
        }

        static string _innerReplaceWithQuotes(this string str, Func<char, bool> predicate, char newChar, int startIndex, int endIndex, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes)
        {
            var sb = StringBuilderCache.Acquire(str.Length);
            if (startIndex != 0) sb.Append(str.Substring(0, startIndex));
            int i;
            while ((i = _innerIndexOfWithQuotes(str, predicate, startIndex, endIndex, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes)) != -1)
            {
                sb.Append(str.Substring(startIndex, i - startIndex));
                sb.Append(newChar);
                startIndex = i + 1;
            }

            sb.Append(str.Substring(startIndex));
            return StringBuilderCache.GetStringAndRelease(sb);
        }

        static string _innerReplaceWithQuotes(string str, string oldValue, string newValue, int startIndex, int endIndex, char leftQuote = '{', char rightQuote = '}', StringComparison comparisonType = StringComparison.Ordinal)
        {
            var oldValueLen = oldValue.Length;
            var sb = StringBuilderCache.Acquire(str.Length);
            if (startIndex != 0) sb.Append(str.Substring(0, startIndex));
            int i;
            while ((i = _innerIndexOfWithQuotes(str, oldValue, startIndex, endIndex, leftQuote, rightQuote, comparisonType)) != -1)
            {
                sb.Append(str.Substring(startIndex, i - startIndex));
                sb.Append(newValue);
                startIndex = i + oldValueLen;
            }

            sb.Append(str.Substring(startIndex));
            return StringBuilderCache.GetStringAndRelease(sb);
        }

        static string _innerReplaceWithQuotes(string str, string oldValue, string newValue, int startIndex, int endIndex, char[] leftQuotes, char[] rightQuotes, StringComparison comparisonType = StringComparison.Ordinal)
        {
            var oldValueLen = oldValue.Length;
            var sb = StringBuilderCache.Acquire(str.Length);
            if (startIndex != 0) sb.Append(str.Substring(0, startIndex));
            int i;
            while ((i = _innerIndexOfWithQuotes(str, oldValue, startIndex, endIndex, leftQuotes, rightQuotes, comparisonType)) != -1)
            {
                sb.Append(str.Substring(startIndex, i - startIndex));
                sb.Append(newValue);
                startIndex = i + oldValueLen;
            }

            sb.Append(str.Substring(startIndex));
            return StringBuilderCache.GetStringAndRelease(sb);
        }

        static string _innerReplaceWithQuotes(string str, string[] oldValues, string newValue, int startIndex, int endIndex, char leftQuote = '{', char rightQuote = '}', StringComparison comparisonType = StringComparison.Ordinal)
        {
            var sb = StringBuilderCache.Acquire(str.Length);
            if (startIndex != 0) sb.Append(str.Substring(0, startIndex));
            StringSearchResult i;
            while ((i = _innerIndexOfWithQuotes(str, oldValues, startIndex, endIndex, leftQuote, rightQuote, comparisonType)) != null)
            {
                sb.Append(str.Substring(startIndex, i.Position - startIndex));
                sb.Append(newValue);
                startIndex = i.Position + i.Value.Length;
            }

            sb.Append(str.Substring(startIndex));
            return StringBuilderCache.GetStringAndRelease(sb);
        }

        static string _innerReplaceWithQuotes(string str, string[] oldValues, string newValue, int startIndex, int endIndex, char[] leftQuotes, char[] rightQuotes, StringComparison comparisonType = StringComparison.Ordinal)
        {
            var sb = StringBuilderCache.Acquire(str.Length);
            if (startIndex != 0) sb.Append(str.Substring(0, startIndex));
            StringSearchResult i;
            while ((i = _innerIndexOfWithQuotes(str, oldValues, startIndex, endIndex, leftQuotes, rightQuotes, comparisonType)) != null)
            {
                sb.Append(str.Substring(startIndex, i.Position - startIndex));
                sb.Append(newValue);
                startIndex = i.Position + i.Value.Length;
            }

            sb.Append(str.Substring(startIndex));
            return StringBuilderCache.GetStringAndRelease(sb);
        }
    }
}
