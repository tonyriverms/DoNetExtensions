using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Text
{
    public partial class StringReader
    {
        /// <summary>
        /// Advances the reader to the beginning of the next line. If the current line is the last line, the reader advances to the end of the underlying string.
        /// </summary>
        /// <param name="skipBlankLines"><c>true</c> to indicate the reader should skip all blank lines it encounters before a non-empty line is reached.
        /// If no non-empty line is found, the reader will advance to the end of the underlying string.
        /// </param>
        public void SeekToNextLine(bool skipBlankLines = true)
        {
            var newline = Environment.NewLine;
            var idx = UnderlyingString.IndexOf(newline, CurrentPosition, EndPosition - CurrentPosition, ComparisonType);
            if (idx == -1) CurrentPosition = EndPosition;
            else CurrentPosition = idx + newline.Length;

            while (UnderlyingString.StartsWith(CurrentPosition, newline))
            {
                CurrentPosition += newline.Length;
                if (CurrentPosition > EndPosition)
                {
                    CurrentPosition = EndPosition;
                    break;
                }
            }
        }
    }
}
