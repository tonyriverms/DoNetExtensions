using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// Stores the result of a substring search (usually by the <c>IndexOfAny</c> method).
    /// </summary>
    public class StringSearchResult
    {
        /// <summary>
        /// The position of the found substring (property <c>Value</c>) in the original string.
        /// </summary>
        public int Position;
        /// <summary>
        /// The found substring.
        /// </summary>
        public string Value;
        /// <summary>
        /// The index of the found substring in the string array to search.
        /// </summary>
        public int HitIndex;
    }

    /// <summary>
    /// Specifies how to perform the IndexOfAll method.
    /// </summary>
    public enum IndexOfAllMode
    {
        /// <summary>
        /// Returns the indexes of the first occurrences of all target strings.
        /// <para>
        /// For example, searching "a", "b", "c" in "babaca" will return 1, 0, 4.
        /// </para>
        /// </summary>
        Normal,
        /// <summary>
        /// Linearly searches the original string and returns the indexes of the first occurrences of target strings sequentially.
        /// <para>
        /// For example, searching "a", "b", "c" in "babaca" will return 1, 2, 4.
        /// </para>
        /// </summary>
        Sequential
    }

    /// <summary>
    /// Specifies how to determine a search is successful when seeking a variety of targets in a string instance.
    /// </summary>
    public enum StringSeekMode : byte
    {
        /// <summary>
        /// The search is successful if any of the targets is hit.
        /// </summary>
        Any = 1,
        /// <summary>
        /// The search is successful if all the targets are hit.
        /// </summary>
        All = 2,
        /// <summary>
        /// The search is successful if the first target is hit.
        /// </summary>
        First = 3,
        /// <summary>
        /// The search is successful if the last target is hit.
        /// </summary>
        Last = 4,
        /// <summary>
        /// The search is successful if all the targets are hit sequentially.
        /// <para>For string "aa, bb, cc, dd" as example, if the targets are {"bb", "cc"}, then the search will succeed; 
        /// if the targets are {"cc", "bb"} the search will fail.</para>
        /// </summary>
        SequentialAll = 5,

    }

    /// <summary>
    /// Provides options for string string search.
    /// </summary>
    public class StringSeekOption
    {
        /// <summary>
        /// Indicating where to start to search the start indicator and the end indicator.
        /// </summary>
        public int StartPosition;
        /// <summary>
        /// Indicates the start of the string to search.
        /// </summary>
        public string StartIndicator;
        /// <summary>
        /// Indicates the end of the string to search.
        /// </summary>
        public string EndIndicator;
        /// <summary>
        /// The values to search.
        /// </summary>
        public string[] Values;
        /// <summary>
        /// Indicates searching method.
        /// </summary>
        public StringSeekMode Mode;
    }
}
