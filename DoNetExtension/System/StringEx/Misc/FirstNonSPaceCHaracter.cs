namespace System
{
    public partial class StringEx
    {
        /// <summary>
        /// Gets the last non-white-space Unicode character in the string at and before the search starting position specified by <paramref name="startIndex"/>.
        /// </summary>
        /// <param name="str">The current string.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <returns>The last non-white-space Unicode character at and before the search starting position.</returns>
        public static char LastNonSpaceCharacter(this string str, int startIndex)
        {
            if (startIndex < 0) return '\0';
            char c;
            while ((c = str[startIndex]).IsWhiteSpace())
            {
                if (startIndex == 0) return '\0';
                --startIndex;
            }

            return c;
        }

        /// <summary>
        /// Gets the first non-white-space Unicode character in the string at and after the search starting position specified by <paramref name="startIndex"/>.
        /// </summary>
        /// <param name="str">The current string.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <returns>The first non-white-space Unicode character at and after the search starting position.</returns>
        public static char FirstNonSpaceCharacter(this string str, int startIndex)
        {
            if (startIndex >= str.Length) return '\0';
            char c;
            while ((c = str[startIndex]).IsWhiteSpace())
            {
                ++startIndex;
                if (startIndex == str.Length) return '\0';
            }

            return c;
        }

        /// <summary>
        /// Gets the index of the last non-white-space Unicode character in the string at and before the search starting position specified by <paramref name="startIndex"/>.
        /// </summary>
        /// <param name="str">The current string.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <returns>The index of the last non-white-space Unicode character at and before the search starting position.</returns>
        public static int IndexOfLastNonSpaceCharacter(this string str, int startIndex)
        {
            if (startIndex < 0) return -1;
            char c;
            while ((c = str[startIndex]).IsWhiteSpace())
            {
                if (startIndex == 0) return -1;
                --startIndex;
            }

            return startIndex;
        }

        /// <summary>
        /// Gets the index of the first non-white-space Unicode character in the string at and after the search starting position specified by <paramref name="startIndex"/>.
        /// </summary>
        /// <param name="str">The current string.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <returns>The index of the first non-white-space Unicode character at and after the search starting position.</returns>
        public static int IndexOfFirstNonSpaceCharacter(this string str, int startIndex)
        {
            if (startIndex >= str.Length) return -1;
            char c;
            while ((c = str[startIndex]).IsWhiteSpace())
            {
                ++startIndex;
                if (startIndex == str.Length) return -1;
            }

            return startIndex;
        }
    }
}
