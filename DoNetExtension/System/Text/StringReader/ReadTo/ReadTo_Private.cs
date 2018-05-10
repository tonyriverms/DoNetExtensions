using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public partial class StringReader
    {
        string _trim(int startIndex, int endIndex, bool trimStart, bool trimEnd)
        {
            if (startIndex == endIndex) return string.Empty;

            if (trimStart)
            {
                while (UnderlyingString[startIndex].IsWhiteSpace())
                {
                    ++startIndex;
                    if (startIndex >= endIndex) return string.Empty;
                }
            }

            if (trimEnd)
            {
                while (UnderlyingString[endIndex - 1].IsWhiteSpace())
                {
                    --endIndex;
                    if (endIndex <= startIndex) return string.Empty;
                }
            }

            return UnderlyingString.Substring(startIndex, endIndex - startIndex);
        }

        string _innerReadTo(int hitIndex, int advance, ReadOptions options)
        {
            var trimStart = options.HasFlag(ReadOptions.TrimStart);
            var trimEnd = options.HasFlag(ReadOptions.TrimEnd);
            var readToEnd = options.HasFlag(ReadOptions.ReadToEnd);

            if (hitIndex == -1)
            {
                if (readToEnd)
                {
                    var output = _trim(CurrentPosition, EndPosition, trimStart, trimEnd);
                    CurrentPosition = EndPosition;
                    return output;
                }
                else return null;
            }
            else
            {
                string output;
                var stopAfterKeyword = options.HasFlag(ReadOptions.StopAfterKey);
                if (stopAfterKeyword)
                {
                    var discardKeyword = options.HasFlag(ReadOptions.DiscardKey);
                    if (discardKeyword)
                    {
                        output = _trim(CurrentPosition, hitIndex, trimStart, trimEnd);
                        CurrentPosition = hitIndex + advance;
                    }
                    else
                    {
                        hitIndex += advance;
                        output = _trim(CurrentPosition, hitIndex, trimStart, trimEnd);
                        CurrentPosition = hitIndex;
                    }
                }
                else
                {
                    output = _trim(CurrentPosition, hitIndex, trimStart, trimEnd);
                    CurrentPosition = hitIndex;
                }
                return output;
            }
        }

        StringReader _trimAsReader(int startIndex, int endIndex, bool trimStart, bool trimEnd)
        {
            if (startIndex == endIndex) return EmptyReader;

            if (trimStart)
            {
                while (UnderlyingString[startIndex].IsWhiteSpace())
                {
                    ++startIndex;
                    if (startIndex >= endIndex) return EmptyReader;
                }
            }

            if (trimEnd)
            {
                while (UnderlyingString[endIndex - 1].IsWhiteSpace())
                {
                    --endIndex;
                    if (endIndex <= startIndex) return EmptyReader;
                }
            }

            return StringReader.InternalCreate(UnderlyingString, startIndex, endIndex);
        }

        StringReader _innerReadToAsReader(int endIndex, int advance, ReadOptions options)
        {
            var trimStart = options.HasFlag(ReadOptions.TrimStart);
            var trimEnd = options.HasFlag(ReadOptions.TrimEnd);
            var readToEnd = options.HasFlag(ReadOptions.ReadToEnd);

            if (endIndex == -1)
            {
                if (readToEnd)
                {
                    var output = _trimAsReader(CurrentPosition, EndPosition, trimStart, trimEnd);
                    CurrentPosition = EndPosition;
                    return output;
                }
                else return null;
            }
            else
            {
                StringReader output;
                var stopAfterIndicator = options.HasFlag(ReadOptions.StopAfterKey);
                if (stopAfterIndicator)
                {
                    var discardIndicator = options.HasFlag(ReadOptions.DiscardKey);
                    if (discardIndicator)
                    {
                        output = _trimAsReader(CurrentPosition, endIndex, trimStart, trimEnd);
                        CurrentPosition = endIndex + advance;
                    }
                    else
                    {
                        endIndex += advance;
                        output = _trimAsReader(CurrentPosition, endIndex, trimStart, trimEnd);
                        CurrentPosition = endIndex;
                    }
                }
                else
                {
                    output = _trimAsReader(CurrentPosition, endIndex, trimStart, trimEnd);
                    CurrentPosition = endIndex;
                }
                return output;
            }
        }

        string _innerReverseReadTo(int hitIndex, int advance, ReadOptions options)
        {
            var trimStart = options.HasFlag(ReadOptions.TrimStart);
            var trimEnd = options.HasFlag(ReadOptions.TrimEnd);
            var readToEnd = options.HasFlag(ReadOptions.ReadToEnd);

            if (hitIndex == -1)
            {
                if (readToEnd)
                {
                    var output = _trim(CurrentPosition, EndPosition, trimStart, trimEnd);
                    EndPosition = CurrentPosition;
                    return output;
                }
                else return null;
            }
            else
            {
                string output;
                var stopAfterKeyword = options.HasFlag(ReadOptions.StopAfterKey);
                if (stopAfterKeyword)
                {
                    var discardKeyword = options.HasFlag(ReadOptions.DiscardKey);
                    if (discardKeyword)
                        output = _trim(hitIndex + advance, EndPosition, trimStart, trimEnd);
                    else
                        output = _trim(hitIndex, EndPosition, trimStart, trimEnd);
                    EndPosition = hitIndex;
                }
                else
                {
                    hitIndex += advance;
                    output = _trim(hitIndex, EndPosition, trimStart, trimEnd);
                    EndPosition = hitIndex;
                }
                return output;
            }
        }
    }
}
