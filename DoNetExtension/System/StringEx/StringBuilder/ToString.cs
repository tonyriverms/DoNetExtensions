using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class StringEx
    {
        public static string ToStringThenClear(this StringBuilder builder)
        {
            var str = builder.ToString();
            builder.Clear();
            return str;
        }

        /// <summary>
        /// Converts the value of this instance to a <see cref="System.String"/> with white spaces at both ends removed.
        /// </summary>
        /// <param name="builder">The current <see cref="System.Text.StringBuilder"/> object.</param>
        /// <returns>A string whose value is the same as this instance except for white spaces at both ends are removed.</returns>
        public static string ToStringWithTrim(this StringBuilder builder)
        {
            var endIndex = builder.Length;
            if (endIndex == 0) return string.Empty;

            int startIndex = 0;
            while (builder[startIndex].IsWhiteSpace())
            {
                ++startIndex;
                if (startIndex == endIndex) return string.Empty;
            }

            --endIndex;
            while (builder[endIndex].IsWhiteSpace())
                --endIndex;

            return builder.ToString(startIndex, endIndex - startIndex + 1);
        }

        /// <summary>
        /// Converts the value of this instance to a <see cref="System.String"/> with white spaces at the beginning removed.
        /// </summary>
        /// <param name="builder">The current <see cref="System.Text.StringBuilder"/> object.</param>
        /// <returns>A string whose value is the same as this instance except for white spaces at the beginning are removed.</returns>
        public static string ToStringWithTrimStart(this StringBuilder builder)
        {
            var endIndex = builder.Length;
            if (endIndex == 0) return string.Empty;

            int startIndex = 0;
            while (builder[startIndex].IsWhiteSpace())
            {
                ++startIndex;
                if (startIndex == endIndex) return string.Empty;
            }

            return builder.ToString(startIndex, endIndex - startIndex);
        }

        /// <summary>
        /// Converts the value of this instance to a <see cref="System.String"/> with white spaces at the end removed.
        /// </summary>
        /// <param name="builder">The current <see cref="System.Text.StringBuilder"/> object.</param>
        /// <returns>A string whose value is the same as this instance except for white spaces at the end are removed.</returns>
        public static string ToStringWithTrimEnd(this StringBuilder builder)
        {
            var endIndex = builder.Length - 1;
            if (endIndex == -1) return string.Empty;


            while (builder[endIndex].IsWhiteSpace())
            {
                if (endIndex == 0) return string.Empty;
                --endIndex;
            }
           
            return builder.ToString(0, endIndex + 1);
        }
    }
}
