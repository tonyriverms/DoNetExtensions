using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.IO
{
    /// <summary>
    /// Defines check codes for IO data check.
    /// </summary>
    public enum IOChecks : long
    {
        /// <summary>
        /// Indicating the data to check is a string.
        /// </summary>
        String = 17,
        /// <summary>
        /// Indicating the data to check are booleans.
        /// </summary>
        Booleans = 11,
        /// <summary>
        /// Indicating the data to check is a common object.
        /// </summary>
        Common = 37,
        /// <summary>
        /// Indicating the data to check is a string hasheset.
        /// </summary>
        StringHashSet = 18,
        /// <summary>
        /// Indicating the data to check is a string list.
        /// </summary>
        StringList = 19,
        /// <summary>
        /// Indicating the data to check is a collection.
        /// </summary>
        Collection = 29,
        /// <summary>
        /// Indicating the data to check is a record stream.
        /// </summary>
        RecordStream = 41,
        /// <summary>
        /// Indicating the data to check is a datetime list.
        /// </summary>
        DateTimeList = 31
    }
}
