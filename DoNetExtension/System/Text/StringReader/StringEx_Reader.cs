using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Text
{
    public partial class StringReader
    {
        public int ReadingScopeLength { get { return EndPosition - CurrentPosition; } }

        public int GetReadingScopeHashCode()
        {
            return UnderlyingString.GetHashCode(CurrentPosition, ReadingScopeLength);
        }

        public bool ReadingScopeEquals(string value)
        {
            if (value == null) return EOF;
            if (value.Length != ReadingScopeLength) return false;
            for (int i = CurrentPosition, j = 0; i < EndPosition; ++i, ++j)
            {
                if (UnderlyingString[i] != value[j])
                    return false;
            }
            return true;
        }

        public bool ReadingScopeEquals(StringReader reader)
        {
            if (reader == null) return EOF;
            if (reader.ReadingScopeLength != ReadingScopeLength) return false;
            for (int i = CurrentPosition, j = reader.CurrentPosition; i < EndPosition; ++i, ++j)
            {
                if (UnderlyingString[i] != reader.UnderlyingString[j])
                    return false;
            }
            return true;
        }

        #region Read

        public string ReadLine(ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.TrimStart | ReadOptions.TrimEnd)
        {
            return ReadTo(Environment.NewLine, options);
        }

        public enum TrimMode
        {
            TrimAll,
            KeepIndent,
            NoTrim
        }

        /// <summary>
        /// Reads an indented block from the underlying string. An indented block consists of several lines where each line starts with some white space. The number of whitespace characters is at least <paramref name="indentLevel"/>.
        /// </summary>
        /// <param name="indentLevel">The indent level indicating the number of spaces ahead of the text in each line of this indented block.</param>
        /// <param name="trimStart"><see cref="TrimMode.NoTrim"/> if the white spaces at the start of every line of the block should be be trimmed; <see cref="TrimMode.KeepIndent"/> if a number of whitespaces is preserved while others are trimmed where the number is <paramref name="indentLevel"/>; <see cref="TrimMode.TrimAll"/> if all white spaces are trimmed.</param>
        /// <param name="trimEnd"><c>true</c> if all white spaces at the end of every line of the block are trimmed.</param>
        /// <returns></returns>
        public string ReadIndentedBlock(int indentLevel = 1, TrimMode trimStart = TrimMode.NoTrim, bool trimEnd = false)
        {
            var sb = new StringBuilder();
            if (indentLevel == 1)
            {
                while (First.NotIn(Environment.NewLine) && First.IsWhiteSpace())
                {
                    if (trimStart != TrimMode.TrimAll) sb.Append(Read());
                    var option = ReadOptions.StopAfterKey;
                    if (trimStart != TrimMode.NoTrim) option |= ReadOptions.TrimStart;
                    if (trimEnd) option |= ReadOptions.TrimEnd;
                    sb.Append(ReadLine(option));
                }
            }
            else
            {
                while (ReadWhiteSpace(indentLevel, out string whitespace))
                {
                    if (trimStart != TrimMode.TrimAll) sb.Append(whitespace);
                    var option = ReadOptions.StopAfterKey;
                    if (trimStart != TrimMode.NoTrim) option |= ReadOptions.TrimStart;
                    if (trimEnd) option |= ReadOptions.TrimEnd;
                    sb.Append(ReadLine(option));
                }

            }

            return sb.ToString();
        }

        #endregion

        //#region Skip

        //#region SkipTo Using String Indicator

        //public bool SkipTo(string indicator, SeekToMode mode = SeekToMode.StopAfterKeyword)
        //{
        //    var idx = UnderlyingString.IndexOf(indicator, CurrentPosition);
        //    return _innerSkipTo(idx, indicator.Length, mode);
        //}

        //public bool SkipTo(string indicator, char leftEscapeQuote, char rightEscapeQuote, SeekToMode mode = SeekToMode.StopAfterKeyword)
        //{
        //    var idx = UnderlyingString.IndexOfWithQuotes(indicator, CurrentPosition, EndPosition - CurrentPosition, leftEscapeQuote, rightEscapeQuote);
        //    return _innerSkipTo(idx, indicator.Length, mode);
        //}

        //public bool SkipTo(string[] indicators, SeekToMode mode = SeekToMode.StopAfterKeyword)
        //{
        //    var idx = UnderlyingString.IndexOfAny(indicators, CurrentPosition);
        //    return _innerSkipTo(idx.Position, idx.Value.Length, mode);
        //}

        //public bool SkipTo(string[] indicators, char leftEscapeQuote, char rightEscapeQuote, SeekToMode mode = SeekToMode.StopAfterKeyword)
        //{
        //    var idx = UnderlyingString.IndexOfAnyWithQuotes(indicators, CurrentPosition, EndPosition - CurrentPosition, leftEscapeQuote, rightEscapeQuote);
        //    return _innerSkipTo(idx.Position, idx.Value.Length, mode);
        //}

        //#endregion

        //public void SkipLine()
        //{
        //     SkipTo(Environment.NewLine);
        //}


        //#endregion

    }
}
