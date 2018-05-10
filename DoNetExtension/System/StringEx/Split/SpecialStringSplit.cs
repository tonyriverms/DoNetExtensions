using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// Specifies some special way to split a string.
    /// </summary>
    public enum SpecialStringSplit
    {
        /// <summary>
        /// Gets all ASCII segments. For example, "i*" "1ove" "you[" will be extracted from "i*我1ove爱you[你们".
        /// </summary>
        GetASCIIParts,
        /// <summary>
        /// Gets all non-ASCII segments. For example, "我" "爱" "你们" will be extracted from "i*我1ove爱you[你们".
        /// </summary>
        GetNonASCIIParts,
        /// <summary>
        /// Splits into ASCII segments and non-ASCII segments. For example, "i*我1ove爱you[你们" will be split into "i*" "我" "love" "爱" "you[" "你们".
        /// </summary>
        SplitASCIIPartsAndNonASCIIParts,
        /// <summary>
        /// Splits into ASCII segments and non-ASCII characters. For example, "i*我1ove爱you[你们" will be split into "i*" "我" "love" "爱" "you[" "你" "们".
        /// </summary>
        SplitASCIIPartsAndNonASCIIChars
    }
}
