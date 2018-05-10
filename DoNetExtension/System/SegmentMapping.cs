using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// Represents a segment mapping.
    /// A segment mapping maps a segment of the first series (like a consecutive part of an array or a string) 
    /// to a segment of the second series.
    /// </summary>
    public class SegmentMapping
    {
        /// <summary>
        /// Initializes a new instance of System.SegmentMapping object.
        /// </summary>
        public SegmentMapping()
        {
            OriginalEndPosition = OriginalStartPosition = MappingStartPosition = MappingEndPosition = -1;
        }

        /// <summary>
        /// Gets or sets the start position of the original segment in the first series.
        /// </summary>
        public int OriginalStartPosition { get; set; }
        /// <summary>
        /// Gets or sets the end position of the original segment in the first series.
        /// </summary>
        public int OriginalEndPosition { get; set; }
        /// <summary>
        /// Gets or sets the start position of the target segment in the second series.
        /// </summary>
        public int MappingStartPosition { get; set; }
        /// <summary>
        /// Gets or sets the end position of the target segment in the second series.
        /// </summary>
        public int MappingEndPosition { get; set; }

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3}", OriginalStartPosition, OriginalEndPosition, MappingStartPosition, MappingEndPosition);
        }
    }
}
