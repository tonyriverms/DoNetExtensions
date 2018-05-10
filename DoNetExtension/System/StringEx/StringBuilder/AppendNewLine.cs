using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class StringEx
    {
        /// <summary>
        /// Appends a copy of the string representation of the specified object followed by the default line terminator to the end of the current <see cref="StringBuilder"/> object.
        /// </summary>
        /// <param name="builder">The current <see cref="System.Text.StringBuilder"/> object.</param>
        /// <param name="value">Th object whose string representation is to be appended.</param>
        /// <returns>The current <see cref="System.Text.StringBuilder"/> object.</returns>
        public static StringBuilder AppendLine(this StringBuilder builder, object value)
        {
            if (value == null)
                return builder;
            return builder.AppendLine(value.ToString());
        }

        /// <summary>
        /// Appends the default line terminator followed by a copy of the specified string to the end of the current <see cref="System.Text.StringBuilder"/> object.
        /// <para>NOTE that this method differs from the <see cref="StringBuilder.AppendLine(string)"/> in that it appends the line terminator before the specified string.</para>
        /// </summary>
        /// <param name="builder">The current <see cref="System.Text.StringBuilder"/> object.</param>
        /// <param name="value">The string to append.</param>
        public static void AppendNewLine(this StringBuilder builder, string value)
        {
            builder.AppendLine();
            builder.Append(value);
        }

        /// <summary>
        /// Appends the default line terminator followed by a new-line indent (a number of specified Unicode characters) to the end of the current <see cref="System.Text.StringBuilder"/> object.
        /// </summary>
        /// <param name="builder">The current <see cref="System.Text.StringBuilder"/> object.</param>
        /// <param name="indentChar">The Unicode characters used to fill the indent.</param>
        /// <param name="indent">The length of the indent.</param>
        public static void AppendNewLine(this StringBuilder builder, char indentChar, int indent)
        {
            builder.AppendLine();
            if (indent != 0)
                builder.Append(indentChar, indent);
        }

        /// <summary>
        /// Appends the default line terminator followed by a new-line indent (a number of spaces) to the end of the current <see cref="System.Text.StringBuilder"/> object.
        /// </summary>
        /// <param name="builder">The current <see cref="System.Text.StringBuilder"/> object.</param>
        /// <param name="indent">The length of the indent.</param>
        public static void AppendNewLine(this StringBuilder builder, int indent)
        {
            AppendNewLine(builder, ' ', indent);
        }

        /// <summary>
        /// Appends the default line terminator followed by a new-line indent (a number of specified Unicode characters) to the end of the current <see cref="System.Text.StringBuilder" /> object, and then appends a copy of the specified string to the end of the current <see cref="System.Text.StringBuilder" /> object.
        /// </summary>
        /// <param name="builder">The current <see cref="System.Text.StringBuilder" /> object.</param>
        /// <param name="value">The string to append after the line terminator and the indent are appended.</param>
        /// <param name="indentChar">The Unicode characters used to fill the indent.</param>
        /// <param name="indent">The length of the indent.</param>
        public static void AppendNewLine(this StringBuilder builder, string value, char indentChar, int indent)
        {
            builder.AppendLine();
            if (indent != 0)
                builder.Append(indentChar, indent);
            builder.Append(value);
        }

        /// <summary>
        /// Appends the default line terminator followed by a new-line indent (a number of spaces) to the end of the current <see cref="System.Text.StringBuilder" /> object, and then appends a copy of the specified string to the end of the current <see cref="System.Text.StringBuilder" /> object.
        /// </summary>
        /// <param name="builder">The current <see cref="System.Text.StringBuilder" /> object.</param>
        /// <param name="value">The string to append after the line terminator and the indent are appended.</param>
        /// <param name="indent">The length of the indent.</param>
        public static void AppendNewLine(this StringBuilder builder, string value, int indent)
        {
            AppendNewLine(builder, value, ' ', indent);
        }
    }
}
