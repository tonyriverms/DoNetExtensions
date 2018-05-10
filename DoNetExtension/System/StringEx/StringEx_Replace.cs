using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class StringEx
    {
        public static string Replace(this string str, string[] oldValues, string[] newValues)
        {
            if (oldValues == null) throw new ArgumentNullException("oldValues");
            if (newValues == null)
                str = str.Remove(oldValues);
            else
            {
                var count = Math.Min(oldValues.Length, newValues.Length);
                for (int i = 0; i < count; ++i)
                    str = str.Replace(oldValues[i], newValues[i]);
            }
            return str;
        }

        /// <summary>
        /// Returns a new string in which all occurrences of all specified Unicode characters in this instance are replaced with another specified Unicode character.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="oldChars">The Unicode characters to be replaced.</param>
        /// <param name="newChar">The Unicode character to replace all occurrences of characters in <paramref name="oldChars"/>.</param>
        /// <returns>A string that is equivalent to this instance except that all instances of <paramref name="oldChars"/> are replaced with <paramref name="newChar"/>. 
        /// If none of <paramref name="oldChars"/> is not found in the current instance, the method returns a duplicate of the current instance. </returns>
        public static string Replace(this string str, char[] oldChars, char newChar)
        {
            var strLen = str.Length;
            var sb = new StringBuilder(strLen);
            for (int i = 0; i < strLen; ++i)
            {
                if (str[i].In(oldChars))
                    sb.Append(newChar);
                else
                    sb.Append(str[i]);
            }

            return sb.ToString();
        }

        #region Without Replacement Count

        /// <summary>
        /// Returns a new string (except the case when no replacements are made and the original string is returned) in which all occurrences of a specified string in the specified searching scope of this instance are replaced with another specified string.
        /// By default, the case-sensitive rules and the current culture are used to perform the replaces.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="oldValue">The string to be replaced.</param>
        /// <param name="newValue">The string to replace the occurrences of <paramref name="oldValue" />.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="length">The number of characters to search. The parameter determines the search ending position along with <paramref name="startIndex" />.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search.</param>
        /// <returns>
        /// A string that is equivalent to the current string except that all instances of <paramref name="oldValue" /> are replaced with <paramref name="newValue" /> in the specified searching scope.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs if <paramref name="startIndex" /> or <paramref name="startIndex" /> + <paramref name="length" /> does not indicate a valid position in the string.</exception>
        public static string Replace(this string str, string oldValue, string newValue, int startIndex, int length, StringComparison comparisonType = StringComparison.CurrentCulture)
        {
            var strlen = str.Length;
            if (startIndex < 0 || startIndex >= strlen) throw new ArgumentOutOfRangeException("startIndex");
            var endIndex = startIndex + length;
            if (endIndex > strlen) throw new ArgumentOutOfRangeException("length");

            startIndex = str.IndexOf(oldValue, startIndex, length, comparisonType);
            if (startIndex == -1) return str;
            else
            {
                var preIndex = 0;
                var oldValueLen = oldValue.Length;
                var sb = new StringBuilder(strlen);
                while (true)
                {
                    sb.Append(str.Substring(preIndex, startIndex - preIndex));
                    sb.Append(newValue);
                    preIndex = startIndex + oldValueLen;
                    startIndex = str.IndexOf(oldValue, preIndex, endIndex - preIndex, comparisonType);
                    if (startIndex == -1)
                    {
                        sb.Append(str.Substring(preIndex));
                        break;
                    }
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// Returns a new string (except the case when no replacements are made and the original string is returned) in which all occurrences of a specified string in the specified searching scope of this instance are replaced with another specified string.
        /// The search for substrings uses case-sensitive ordinal rules. Use this method to perform fast and linguistically independent replaces.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="oldValue">The string to be replaced.</param>
        /// <param name="newValue">The string to replace the occurrences of <paramref name="oldValue" />.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="length">The number of characters to search. The parameter determines the search ending position along with <paramref name="startIndex" />.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search.</param>
        /// <returns>
        /// A string that is equivalent to the current string except that all instances of <paramref name="oldValue" /> are replaced with <paramref name="newValue" /> in the specified searching scope.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs if <paramref name="startIndex" /> or <paramref name="startIndex" /> + <paramref name="length" /> does not indicate a valid position in the string.</exception>
        public static string ReplaceOrdinal(this string str, string oldValue, string newValue, int startIndex, int length)
        {
            return Replace(str, oldValue, newValue, startIndex, length, StringComparison.Ordinal);
        }

        /// <summary>
        /// Returns a new string (except the case when no replacements are made and the original string is returned) in which all occurrences of a specified string in the specified searching scope of this instance are replaced with another specified string.
        /// By default, the case-sensitive rules and the current culture are used to perform the replaces.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="oldValue">The string to be replaced.</param>
        /// <param name="newValue">The string to replace the occurrences of <paramref name="oldValue" />.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search.</param>
        /// <returns>
        /// A string that is equivalent to the current string except that all instances of <paramref name="oldValue" /> are replaced with <paramref name="newValue" /> in the specified searching scope.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs if <paramref name="startIndex" /> or <paramref name="startIndex" /> + <paramref name="length" /> does not indicate a valid position in the string.</exception>
        public static string Replace(this string str, string oldValue, string newValue, int startIndex = 0, StringComparison comparisonType = StringComparison.CurrentCulture)
        {
            return Replace(str, oldValue, newValue, startIndex, str.Length - startIndex, comparisonType);
        }

        /// <summary>
        /// Returns a new string (except the case when no replacements are made and the original string is returned) in which all occurrences of a specified string in the specified searching scope of this instance are replaced with another specified string.
        /// The search for substrings uses case-sensitive ordinal rules. Use this method to perform fast and linguistically independent replaces.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="oldValue">The string to be replaced.</param>
        /// <param name="newValue">The string to replace the occurrences of <paramref name="oldValue" />.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search.</param>
        /// <returns>
        /// A string that is equivalent to the current string except that all instances of <paramref name="oldValue" /> are replaced with <paramref name="newValue" /> in the specified searching scope.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs if <paramref name="startIndex" /> or <paramref name="startIndex" /> + <paramref name="length" /> does not indicate a valid position in the string.</exception>
        public static string ReplaceOrdinal(this string str, string oldValue, string newValue, int startIndex = 0)
        {
            return Replace(str, oldValue, newValue, startIndex, str.Length - startIndex, StringComparison.Ordinal);
        }

        #endregion

        #region With Replacement Count

        /// <summary>
        /// Returns a new string (except the case when no replacements are made and the original string is returned) in which all occurrences of a specified string in the specified searching scope of this instance are replaced with another specified string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="oldValue">The string to be replaced.</param>
        /// <param name="newValue">The string to replace the occurrences of <paramref name="oldValue" />.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="length">The number of characters to search. The parameter determines the search ending position along with <paramref name="startIndex" />.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search.</param>
        /// <param name="countOfReplacements">Returns the number of replacements that are made.</param>
        /// <returns>
        /// A string that is equivalent to the current string except that all instances of <paramref name="oldValue" /> are replaced with <paramref name="newValue" /> in the specified searching scope.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs if <paramref name="startIndex" /> or <paramref name="startIndex" /> + <paramref name="length" /> does not indicate a valid position in the string.</exception>
        public static string Replace(this string str, string oldValue, string newValue, int startIndex, int length,
            StringComparison comparisonType, out int countOfReplacements)
        {
            var strlen = str.Length;
            if (startIndex < 0 || startIndex >= strlen) throw new ArgumentOutOfRangeException("startIndex");
            var endIndex = startIndex + length;
            if (endIndex > strlen) throw new ArgumentOutOfRangeException("length");
            countOfReplacements = 0;

            startIndex = str.IndexOf(oldValue, startIndex, length, comparisonType);
            if (startIndex == -1) return str;
            else
            {
                var preIndex = 0;
                var oldValueLen = oldValue.Length;
                var sb = new StringBuilder(strlen);
                while (true)
                {
                    sb.Append(str.Substring(preIndex, startIndex - preIndex));
                    sb.Append(newValue);
                    ++countOfReplacements;
                    preIndex = startIndex + oldValueLen;
                    startIndex = str.IndexOf(oldValue, preIndex, endIndex - preIndex, comparisonType);
                    if (startIndex == -1)
                    {
                        sb.Append(str.Substring(preIndex));
                        break;
                    }
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// Returns a new string (except the case when no replacements are made and the original string is returned) in which all occurrences of a specified string in the specified searching scope of this instance are replaced with another specified string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="oldValue">The string to be replaced.</param>
        /// <param name="newValue">The string to replace the occurrences of <paramref name="oldValue" />.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search.</param>
        /// <param name="countOfReplacements">Returns the number of replacements that are made.</param>
        /// <returns>
        /// A string that is equivalent to the current string except that all instances of <paramref name="oldValue" /> are replaced with <paramref name="newValue" /> in the specified searching scope.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs if <paramref name="startIndex" /> or <paramref name="startIndex" /> + <paramref name="length" /> does not indicate a valid position in the string.</exception>
        public static string Replace(this string str, string oldValue, string newValue, int startIndex,
            StringComparison comparisonType, out int countOfReplacements)
        {
            return Replace(str, oldValue, newValue, startIndex, str.Length - startIndex, comparisonType, out countOfReplacements);
        }

        /// <summary>
        /// Returns a new string (except the case when no replacements are made and the original string is returned) in which all occurrences of a specified string in the specified searching scope of this instance are replaced with another specified string.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="oldValue">The string to be replaced.</param>
        /// <param name="newValue">The string to replace the occurrences of <paramref name="oldValue" />.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search.</param>
        /// <param name="countOfReplacements">Returns the number of replacements that are made.</param>
        /// <returns>
        /// A string that is equivalent to the current string except that all instances of <paramref name="oldValue" /> are replaced with <paramref name="newValue" /> in the specified searching scope.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs if <paramref name="startIndex" /> or <paramref name="startIndex" /> + <paramref name="length" /> does not indicate a valid position in the string.</exception>
        public static string Replace(this string str, string oldValue, string newValue,
            StringComparison comparisonType, out int countOfReplacements)
        {
            return Replace(str, oldValue, newValue, 0, str.Length, comparisonType, out countOfReplacements);
        }

        /// <summary>
        /// Returns a new string (except the case when no replacements are made and the original string is returned) in which all occurrences of a specified string in the specified searching scope of this instance are replaced with another specified string.
        /// The search for substrings uses case-sensitive rules and the current culture.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="oldValue">The string to be replaced.</param>
        /// <param name="newValue">The string to replace the occurrences of <paramref name="oldValue" />.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="length">The number of characters to search. The parameter determines the search ending position along with <paramref name="startIndex" />.</param>
        /// <param name="countOfReplacements">Returns the number of replacements that are made.</param>
        /// <returns>
        /// A string that is equivalent to the current string except that all instances of <paramref name="oldValue" /> are replaced with <paramref name="newValue" /> in the specified searching scope.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs if <paramref name="startIndex" /> or <paramref name="startIndex" /> + <paramref name="length" /> does not indicate a valid position in the string.</exception>
        public static string Replace(this string str, string oldValue, string newValue, int startIndex, int length, out int countOfReplacements)
        {
            return Replace(str, oldValue, newValue, startIndex, length, StringComparison.CurrentCulture, out countOfReplacements);
        }

        /// <summary>
        /// Returns a new string (except the case when no replacements are made and the original string is returned) in which all occurrences of a specified string in the specified searching scope of this instance are replaced with another specified string.
        /// The search for substrings uses case-sensitive rules and the current culture.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="oldValue">The string to be replaced.</param>
        /// <param name="newValue">The string to replace the occurrences of <paramref name="oldValue" />.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="countOfReplacements">Returns the number of replacements that are made.</param>
        /// <returns>
        /// A string that is equivalent to the current string except that all instances of <paramref name="oldValue" /> are replaced with <paramref name="newValue" /> in the specified searching scope.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs if <paramref name="startIndex" /> or <paramref name="startIndex" /> + <paramref name="length" /> does not indicate a valid position in the string.</exception>
        public static string Replace(this string str, string oldValue, string newValue, int startIndex, out int countOfReplacements)
        {
            return Replace(str, oldValue, newValue, startIndex, str.Length - startIndex, StringComparison.CurrentCulture, out countOfReplacements);
        }

        /// <summary>
        /// Returns a new string (except the case when no replacements are made and the original string is returned) in which all occurrences of a specified string in the specified searching scope of this instance are replaced with another specified string.
        /// The search for substrings uses case-sensitive rules and the current culture.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="oldValue">The string to be replaced.</param>
        /// <param name="newValue">The string to replace the occurrences of <paramref name="oldValue" />.</param>
        /// <param name="countOfReplacements">Returns the number of replacements that are made.</param>
        /// <returns>
        /// A string that is equivalent to the current string except that all instances of <paramref name="oldValue" /> are replaced with <paramref name="newValue" /> in the specified searching scope.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs if <paramref name="startIndex" /> or <paramref name="startIndex" /> + <paramref name="length" /> does not indicate a valid position in the string.</exception>
        public static string Replace(this string str, string oldValue, string newValue, out int countOfReplacements)
        {
            return Replace(str, oldValue, newValue, 0, str.Length, StringComparison.CurrentCulture, out countOfReplacements);
        }

        /// <summary>
        /// Returns a new string (except the case when no replacements are made and the original string is returned) in which all occurrences of a specified string in the specified searching scope of this instance are replaced with another specified string.
        /// The search for substrings uses case-sensitive ordinal rules. Use this method to perform fast and linguistically independent replaces.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="oldValue">The string to be replaced.</param>
        /// <param name="newValue">The string to replace the occurrences of <paramref name="oldValue" />.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="length">The number of characters to search. The parameter determines the search ending position along with <paramref name="startIndex" />.</param>
        /// <param name="countOfReplacements">Returns the number of replacements that are made.</param>
        /// <returns>
        /// A string that is equivalent to the current string except that all instances of <paramref name="oldValue" /> are replaced with <paramref name="newValue" /> in the specified searching scope.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs if <paramref name="startIndex" /> or <paramref name="startIndex" /> + <paramref name="length" /> does not indicate a valid position in the string.</exception>
        public static string ReplaceOrdinal(this string str, string oldValue, string newValue, int startIndex, int length, out int countOfReplacements)
        {
            return Replace(str, oldValue, newValue, startIndex, length, StringComparison.Ordinal, out countOfReplacements);
        }

        /// <summary>
        /// Returns a new string (except the case when no replacements are made and the original string is returned) in which all occurrences of a specified string in the specified searching scope of this instance are replaced with another specified string.
        /// The search for substrings uses case-sensitive ordinal rules. Use this method to perform fast and linguistically independent replaces.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="oldValue">The string to be replaced.</param>
        /// <param name="newValue">The string to replace the occurrences of <paramref name="oldValue" />.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="countOfReplacements">Returns the number of replacements that are made.</param>
        /// <returns>
        /// A string that is equivalent to the current string except that all instances of <paramref name="oldValue" /> are replaced with <paramref name="newValue" /> in the specified searching scope.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs if <paramref name="startIndex" /> or <paramref name="startIndex" /> + <paramref name="length" /> does not indicate a valid position in the string.</exception>
        public static string ReplaceOrdinal(this string str, string oldValue, string newValue, int startIndex, out int countOfReplacements)
        {
            return Replace(str, oldValue, newValue, startIndex, str.Length - startIndex, StringComparison.Ordinal, out countOfReplacements);
        }

        /// <summary>
        /// Returns a new string (except the case when no replacements are made and the original string is returned) in which all occurrences of a specified string in the specified searching scope of this instance are replaced with another specified string.
        /// The search for substrings uses case-sensitive ordinal rules. Use this method to perform fast and linguistically independent replaces.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="oldValue">The string to be replaced.</param>
        /// <param name="newValue">The string to replace the occurrences of <paramref name="oldValue" />.</param>
        /// <param name="countOfReplacements">Returns the number of replacements that are made.</param>
        /// <returns>
        /// A string that is equivalent to the current string except that all instances of <paramref name="oldValue" /> are replaced with <paramref name="newValue" /> in the specified searching scope.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs if <paramref name="startIndex" /> or <paramref name="startIndex" /> + <paramref name="length" /> does not indicate a valid position in the string.</exception>
        public static string ReplaceOrdinal(this string str, string oldValue, string newValue, out int countOfReplacements)
        {
            return Replace(str, oldValue, newValue, 0, str.Length, StringComparison.Ordinal, out countOfReplacements);
        }

        public static string Replace(this string str, string[] oldValues, string newValue)
        {
            var valueCount = oldValues.Length;
            for (int i = 0; i < valueCount; ++i)
                str = str.Replace(oldValues[i], newValue);
            return str;
        }

        #endregion

    }
}
