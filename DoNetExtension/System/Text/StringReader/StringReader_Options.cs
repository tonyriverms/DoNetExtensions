using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public partial class StringReader
    {

        /// <summary>
        /// Specifies options for <see cref="ReadTo"/> methods.
        /// </summary>
        [Flags]
        public enum ReadOptions
        {
            /// <summary>
            /// The reader stops at the position of the keychar or the first character of the keyword.
            /// </summary>
            Default = 0,
            /// <summary>
            /// The reader stops at the position next to the keychar or the last character of the keyword.
            /// This option overrides <see cref="Default"/> if both are specified.
            /// </summary>
            StopAfterKey = 1,
            /// <summary>
            /// The keychar or the keyword will not be included in the returned string.
            /// </summary>
            DiscardKey = 2,
            /// <summary>
            /// The white spaces at the beginning of the returned string will be removed.
            /// </summary>
            TrimStart = 4,
            /// <summary>
            /// The white spaces at the end of the returned string will be removed.
            /// </summary>
            TrimEnd = 8,
            /// <summary>
            /// The read will advance and read to the end of the reading scope if the keychar or keyword is not found.
            /// </summary>
            ReadToEnd = 16
        }

    }
}
