using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
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
