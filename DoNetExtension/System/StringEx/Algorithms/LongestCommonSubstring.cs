using System.Text;

namespace System
{
    public static partial class StringEx
    {
        /// <summary>
        /// Gets the length of the longest common substring.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="stringToCompare">The string to compare.</param>
        /// <returns>The length of the longest common substring.</returns>
        public static int LongestCommonSubstring(this string source, string stringToCompare)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(stringToCompare))
                return 0;

            var num = new int[source.Length, stringToCompare.Length];
            var maxLen = 0;

            for (var i = 0; i < source.Length; i++)
            {
                for (var j = 0; j < stringToCompare.Length; ++j)
                {
                    if (source[i] != stringToCompare[j])
                        num[i, j] = 0;
                    else
                    {
                        if ((i == 0) || (j == 0))
                            num[i, j] = 1;
                        else
                            num[i, j] = 1 + num[i - 1, j - 1];

                        if (num[i, j] > maxLen)
                            maxLen = num[i, j];
                    }
                }
            }
            return maxLen;
        }

        /// <summary>
        /// Gets the the longest common substring and its length.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="stringToCompare">The string to compare.</param>
        /// <param name="lcs">Returns the longest common substring.</param>
        /// <returns>
        /// The length of the longest common substring.
        /// </returns>
        public static int LongestCommonSubstring(string source, string stringToCompare, out string lcs)
        {
            lcs = string.Empty;
            if (source.IsNullOrEmpty() || stringToCompare.IsNullOrEmpty())
                return 0;

            var num = new int[source.Length, stringToCompare.Length];
            var maxLen = 0;
            var lastSubsBegin = 0;
            var sequenceBuilder = new StringBuilder();

            for (var i = 0; i < source.Length; i++)
            {
                for (var j = 0; j < stringToCompare.Length; j++)
                {
                    if (source[i] != stringToCompare[j])
                        num[i, j] = 0;
                    else
                    {
                        if ((i == 0) || (j == 0))
                            num[i, j] = 1;
                        else
                            num[i, j] = 1 + num[i - 1, j - 1];

                        if (num[i, j] > maxLen)
                        {
                            maxLen = num[i, j];
                            var thisSubsBegin = i - num[i, j] + 1;
                            if (lastSubsBegin == thisSubsBegin)
                                //if the current LCS is the same as the last time this block ran
                                sequenceBuilder.Append(source[i]);
                            else //this block resets the string builder if a different LCS is found
                            {
                                lastSubsBegin = thisSubsBegin;
                                sequenceBuilder.Length = 0; //clear it
                                sequenceBuilder.Append(source.Substring(lastSubsBegin, (i + 1) - lastSubsBegin));
                            }
                        }
                    }
                }
            }
            lcs = sequenceBuilder.ToString();
            return maxLen;
        }
    }
}
