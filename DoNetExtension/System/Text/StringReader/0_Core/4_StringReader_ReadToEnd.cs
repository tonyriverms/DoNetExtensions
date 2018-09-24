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
        /// Advances this reader to the end of the search scope and returns a substring starting from the current position to the end of the search scope. NOTE that after executing this method, this reader is marked <see cref="EOF"/> and is no longer readable.
        /// </summary>
        /// <returns>A substring of the underlying string of this reader, starting from the current position to the end of the reading scope, if the current reader is not marked EOF; otherwise, <see cref="String.Empty"/>.</returns>
        public string ReadToEnd()
        {
            if (CurrentPosition == EndPosition) return string.Empty;
            else
            {
                var output = UnderlyingString.Substring(CurrentPosition, EndPosition - CurrentPosition);
                CurrentPosition = EndPosition;
                return output;
            }
        }

        /// <summary>
        /// Advances this reader to the end of the search scope and returns a trimmed substring starting from the current position to the end of the search scope. NOTE that after executing this method, this reader is marked <see cref="EOF"/> and is no longer readable.
        /// </summary>
        /// <returns>A substring of the underlying string of this reader, starting from the current position to the end of the reading scope, if the current reader is not marked EOF; otherwise. NOTE that the white spaces at both ends of the substring are removed. If the current reader is marked EOF, then <see cref="String.Empty"/> will be returned.</returns>
        public string ReadToEndWithTrim()
        {
            return _trim(CurrentPosition, EndPosition, true, true);
        }

        /// <summary>
        /// Advances this reader to the end of the search scope and returns a new reader that encapsulates a substring starting from the current position to the end of the search scope. NOTE that after executing this method, the current reader is marked <see cref="EOF"/> and is no longer readable.
        /// </summary>
        /// <returns>A new reader encapsulating a substring of the underlying string of the current reader, starting from the current position to the end of the reading scope. NOTE that if the current reader is marked EOF, the returned reader is also marked EOF, of course.</returns>
        public StringReader ReadToEndAsReader()
        {
            var reader = new StringReader(this);
            CurrentPosition = EndPosition;
            return reader;
        }

        /// <summary>
        /// Advances this reader to the end of the search scope and returns a new reader that encapsulates a trimmed substring starting from the current position to the end of the search scope. NOTE that after executing this method, the current reader is marked <see cref="EOF"/> and is no longer readable.
        /// </summary>
        /// <returns>A new reader encapsulating a substring of the underlying string of the current reader, starting from the current position to the end of the reading scope. The white spaces at both ends of the substring are removed. NOTE that if the current reader is marked EOF, the returned reader is also marked EOF, of course.</returns>
        public StringReader ReadToEndWithTrimAsReader()
        {
            var reader = _trimAsReader(CurrentPosition, EndPosition, true, true);
            CurrentPosition = EndPosition;
            return reader;
        }
    }
}
