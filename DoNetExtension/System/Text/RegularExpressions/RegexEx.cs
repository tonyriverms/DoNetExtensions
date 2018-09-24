using System.Linq;
using DoNetExtension.System.Text;

namespace System.Text.RegularExpressions
{
    //TODO: test and upgrade
    /// <summary>
    /// Provides some useful regular expressions.
    /// </summary>
    public static class RegexPatterns
    {
        public const string IntegerWithGroup = "([0-9]+)";

        public const string Integer = "[0-9]+";

        public const string NegativeIntegerWithGroups = @"(\-?)[ \t]*([0-9]+)";

        public const string NegativeInteger = @"\-?[ \t]*[0-9]+";

        public const string DecimalWithGroups = @"([0-9]+)\.([0-9]+)";

        public const string Decimal = @"[0-9]+\.[0-9]+";

        public const string NegativeDecimalWithGroups = @"(\-?)[ \t]*([0-9]+)\.([0-9]+)";

        public const string NegativeDecimal = @"\-?[ \t]*[0-9]+\.[0-9]+";

        public const string At = "@.+";

        public const string Tag = "#.+";

        public const string ASCIILettersAndDigits = "[0-9A-Za-z]+";

        public const string ASCIILetters = "[A-Za-z]+";

        public const string ASCIIDigits = "[0-9]+";

        /// <summary>
        /// Gets the pattern matching an apache log line. The groups indexed by 1-10 represents hostname, timestamp, verb, request, protocol, protocol version, response, size, referrer, and agent information.
        /// </summary>
        public static string ApacheLogLine
        {
            get
            {
                return RegexResources.REG_ApacheLogline;
            }
        }

        /// <summary>
        /// Gets the pattern matching any IP address without access to each number.
        /// </summary>
        public static string IPAddress
        {
            get
            {
                return RegexResources.REG_IPAddress;
            }
        }

        /// <summary>
        /// Gets the pattern matching any IP address with access to each number.
        /// </summary>
        public static string IPAddressWithAccessToEachNumber
        {
            get
            {
                return RegexResources.REG_IPAddressWithAccessToEachNumber;
            }
        }

        /// <summary>
        /// Gets a pattern matching both open and close HTML marks of specified HTML tags.
        /// </summary>
        /// <param name="tags">The HTML tags used to create the pattern. Use null if you want to match all HTML marks. Please make sure these tags are legal.</param>
        /// <returns>A pattern matching both open and close HTML marks of the specified HTML tags.</returns>
        public static string GetHTMLMarkPattern(params string[] tags)
        {
            StringBuilder sb = new StringBuilder();
            if (tags != null && tags.Length != 0)
            {
                for (int i = 0; i < tags.Length; i++)
                {
                    string tag = tags[i];
                    sb.Append(RegexResources.REG_HTMLMark_0.Replace("tag", tag));
                    if (i != tags.Length - 1) sb.Append("|");
                }
                return sb.ToString();
            }
            else return HTMLMark;
        }

        /// <summary>
        /// Gets a pattern matching any typical Email address.
        /// </summary>
        public static string EMailAddress
        {
            get
            {
                return RegexResources.REG_EmailAddress;
            }
        }

        /// <summary>
        /// Gets a pattern matching any HTML mark.
        /// </summary>
        public static string HTMLMark
        {
            get
            {
                return RegexResources.REG_HTMLMark;
            }
        }

        /// <summary>
        /// Gets a pattern matching any Chinese character.
        /// </summary>
        public static string ChineseCharacter
        {
            get
            {
                return RegexResources.REG_ChineseCharacter;
            }
        }

        /// <summary>
        /// Gets a pattern matching any double-byte (i.e. non-ASCII) character.
        /// </summary>
        public static string DoubleByteCharacter
        {
            get
            {
                return RegexResources.REG_DoubleByteCharacter;
            }
        }

        /// <summary>
        /// Gets a pattern matching any typical English word (i.e. only letters, "'" and "-").
        /// </summary>
        public static string TypicalEnglishWord
        {
            get
            {
                return RegexResources.REG_TypicalEnglishWord;
            }
        }

        /// <summary>
        /// Gets a pattern matching any English word that consists of letters, numbers, "'" and "-".
        /// </summary>
        public static string EnglishWord
        {
            get
            {
                return RegexResources.REG_EnglishWordWithNumber;
            }
        }

        static Regex _compiledHtmlMark;
        public static Regex CompiledHtmlMark
        {
            get
            {
                if (_compiledHtmlMark == null)
                    _compiledHtmlMark = new Regex(RegexPatterns.HTMLMark, RegexOptions.Compiled);
                return _compiledHtmlMark;
            }
        }

        static Regex _compiledAt;
        /// <summary>
        /// Gets the compiled <see cref="Regex"/> object for <see cref="At"/>.
        /// </summary>
        /// <value>The compiled <see cref="Regex"/> object for <see cref="At"/>.</value>
        public static Regex CompiledAt
        {
            get
            {
                if (_compiledAt == null)
                    _compiledAt = new Regex(At, RegexOptions.Compiled);
                return _compiledAt;
            }
        }


        static Regex _compiledTag;
        /// <summary>
        /// Gets the compiled <see cref="Regex"/> object for <see cref="Tag"/>.
        /// </summary>
        /// <value>The compiled <see cref="Regex"/> object for <see cref="Tag"/>.</value>
        public static Regex CompiledTag
        {
            get
            {
                if (_compiledTag == null)
                    _compiledTag = new Regex(Tag, RegexOptions.Compiled);
                return _compiledTag;
            }
        }

        static Regex _compiledASCIILetters;
        /// <summary>
        /// Gets the compiled <see cref="Regex"/> object for <see cref="ASCIILetters"/>.
        /// </summary>
        /// <value>The compiled <see cref="Regex"/> object for <see cref="ASCIILetters"/>.</value>
        public static Regex CompiledASCIILetters
        {
            get
            {
                if (_compiledASCIILetters == null)
                    _compiledASCIILetters = new Regex(Tag, RegexOptions.Compiled);
                return _compiledASCIILetters;
            }
        }

        static Regex _compiledASCIIDigits;
        /// <summary>
        /// Gets the compiled <see cref="Regex"/> object for <see cref="ASCIIDigits"/>.
        /// </summary>
        /// <value>The compiled <see cref="Regex"/> object for <see cref="ASCIIDigits"/>.</value>
        public static Regex CompiledASCIIDigits
        {
            get
            {
                if (_compiledASCIIDigits == null)
                    _compiledASCIIDigits = new Regex(Tag, RegexOptions.Compiled);
                return _compiledASCIIDigits;
            }
        }

        static Regex _compiledASCIILettersAndDigits;
        /// <summary>
        /// Gets the compiled <see cref="Regex"/> object for <see cref="ASCIILettersAndDigits"/>.
        /// </summary>
        /// <value>The compiled <see cref="Regex"/> object for <see cref="ASCIILettersAndDigits"/>.</value>
        public static Regex CompiledASCIILettersAndDigits
        {
            get
            {
                if (_compiledASCIILettersAndDigits == null)
                    _compiledASCIILettersAndDigits = new Regex(Tag, RegexOptions.Compiled);
                return _compiledASCIILettersAndDigits;
            }
        }
    }



    /// <summary>
    /// Provides extension methods for regular expressions.
    /// </summary>
    public static class RegexEx
    {
        public static bool IsMatchStart(this Regex regex, string value)
        {
            var match = regex.Match(value);
            return match != null && !match.Value.IsNullOrEmpty() && match.Index == 0;
        }

        public static bool IsMatchEnd(this Regex regex, string value)
        {
            var matches = regex.Matches(value);
            if (matches.Count != 0)
            {
                var lastMatch = matches[matches.Count - 1];
                return lastMatch.Index + lastMatch.Length == value.Length;
            }
            return false;
        }

        /// <summary>
        /// Gets a value indicating if this <see cref="Regex"/> matches the entire <paramref name="value"/>.
        /// </summary>
        /// <param name="regex">This regex.</param>
        /// <param name="value">The value to match.</param>
        /// <returns><c>true</c> if this <see cref="Regex"/> matches the entire <paramref name="value"/>, <c>false</c> otherwise.</returns>
        public static bool IsMatchWhole(this Regex regex, string value)
        {
            var match = regex.Match(value);
            return match != null && match.Index == 0 && match.Length == value.Length;
        }

        //TODO: more methods to be added

        #region Conforms

        /// <summary>
        /// Checks whether this string or its substring entirely matches the specified regular expression.
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <param name="regPattern">A regular expression.</param>
        /// <param name="options">Regular expression options.</param>
        /// <param name="startIndex">A zero-based character position in the current string that defines the leftmost position to be searched.</param>
        /// <param name="length">The number of characters to include in the search.</param>
        /// <returns>true if this string conforms to the specified regular expression; otherwise, false.</returns>
        public static bool REGMatchWhole(this string str, string regPattern, RegexOptions options = RegexOptions.None, int startIndex = 0, int length = 0)
        {
            if (length == 0) length = str.Length - startIndex;
            Regex reg = new Regex(regPattern, options);
            var match = reg.Match(str);
            return match != null && match.Index == startIndex && match.Length == length;
        }

        /// <summary>
        /// Checks whether this string or its substring entirely matches the specified <see cref="Regex"/>.
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <param name="regPattern">A regular expression represented by a <see cref="Regex"/> object.</param>
        /// <param name="startIndex">A zero-based character position in the current string that defines the leftmost position to be searched.</param>
        /// <param name="length">The number of characters to include in the search. <c>0</c> indicates all remaining characters starting from <paramref name="startIndex"/>.</param>
        /// <returns><c>true</c> if the specified substring entirely matches the specified regular expression represented by a <see cref="Regex"/> object; otherwise, false.</returns>
        public static bool REGMatchWhole(this string str, Regex regPattern, int startIndex, int length = 0)
        {
            if (length == 0) length = str.Length - startIndex;
            var match = regPattern.Match(str, startIndex, length);
            return match != null && match.Index == startIndex && match.Length == length;
        }

        /// <summary>
        /// Checks whether this string entirely matches the specified <see cref="Regex"/>.
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <param name="regPattern">A regular expression represented by a <see cref="Regex"/> object.</param>
        /// <returns><c>true</c> if this string entirely matches the specified regular expression represented by a <see cref="Regex"/> object; otherwise, false.</returns>
        public static bool REGMatchWhole(this string str, Regex regPattern)
        {
            var match = regPattern.Match(str);
            return match != null && match.Index == 0 && match.Length == str.Length;
        }

        #endregion

        #region Contains

        /// <summary>
        /// Checks whether at least one substring of this string instance conforms to the specified regular expression.
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <param name="regPattern">A regular expression.</param>
        /// <param name="options">Regular expression options.</param>
        /// <param name="startIndex">A zero-based character position in the current string that defines the leftmost position to be searched.</param>
        /// <param name="length">The number of characters to include in the search.</param>
        /// <returns>true if at least one substring of this string instance conforms to the specified regular expression; otherwise, false.</returns>
        public static bool REGContains(this string str, string regPattern, RegexOptions options = RegexOptions.None, int startIndex = 0, int length = 0)
        {
            if (length == 0) length = str.Length - startIndex;
            var reg = new Regex(regPattern, options);
            return reg.Match(str, startIndex, length) != null;
        }

        /// <summary>
        /// Checks whether at least one substring of this string instance conforms to the specified regular expression.
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <param name="regPattern">A regular expression represented by a <c>System.Text.RegularExpressions.RegEx</c> object.</param>
        /// <param name="startIndex">A zero-based character position in the current string that defines the leftmost position to be searched.</param>
        /// <param name="length">The number of characters to include in the search.</param>
        /// <returns>true if at least one substring of this string instance conforms to the specified regular expression represented by a <c>System.Text.RegularExpressions.RegEx</c> object; 
        /// otherwise, false.</returns>
        public static bool REGContains(this string str, Regex regPattern, int startIndex = 0, int length = 0)
        {
            if (length == 0) length = str.Length - startIndex;
            return regPattern.Match(str, startIndex, length) != null;
        }

        #endregion

        #region StartsWith & EndsWith

        /// <summary>
        /// Checks whether the beginning of this string (or a specified substring of this string instance) conforms to the specified regular expression.
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <param name="regPattern">A regular expression.</param>
        /// <param name="options">Regular expression options.</param>
        /// <param name="startIndex">A zero-based character position in the current string that defines the leftmost position to be searched.</param>
        /// <param name="length">The number of characters to include in the search.</param>
        /// <returns>true if the beginning of this string (or the specified substring of this string instance) conforms to the specified regular expression; otherwise, false.</returns>
        public static bool REGStartsWith(this string str, string regPattern, RegexOptions options = RegexOptions.None, int startIndex = 0, int length = 0)
        {
            return REGStartsWith(str, new Regex(regPattern, options), startIndex, length);
        }

        /// <summary>
        /// Checks whether the beginning of this string (or a specified substring of this string instance) conforms to the specified regular expression.
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <param name="regPattern">A regular expression.</param>
        /// <param name="match">Outputs the <see cref="Match"/> object if <paramref name="regPattern"/> is matched at the beginning of the string.</param>
        /// <param name="options">Regular expression options.</param>
        /// <param name="startIndex">A zero-based character position in the current string that defines the leftmost position to be searched.</param>
        /// <param name="length">The number of characters to include in the search.</param>
        /// <returns>true if the beginning of this string (or the specified substring of this string instance) conforms to the specified regular expression; otherwise, false.</returns>
        public static bool REGStartsWith(this string str, string regPattern, out Match match, RegexOptions options = RegexOptions.None, int startIndex = 0, int length = 0)
        {
            return REGStartsWith(str, new Regex(regPattern, options), out match, startIndex, length);
        }

        /// <summary>
        /// Checks whether the beginning of this string (or a specified substring of this string instance) conforms to the specified regular expression.
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <param name="regPattern">A regular expression represented by a <c>System.Text.RegularExpressions.RegEx</c> object.</param>
        /// <param name="startIndex">A zero-based character position in the current string that defines the leftmost position to be searched.</param>
        /// <param name="length">The number of characters to include in the search.</param>
        /// <returns>true if the beginning of this string (or the specified substring of this string instance) conforms to the specified regular expression
        /// represented by a <c>System.Text.RegularExpressions.RegEx</c> object; otherwise, false.</returns>
        public static bool REGStartsWith(this string str, Regex regPattern, int startIndex = 0, int length = 0)
        {
            if (length == 0) length = str.Length - startIndex;
            var match = regPattern.Match(str, startIndex, length);
            return match != null && !match.Value.IsNullOrEmpty() && match.Index == startIndex;
        }

        /// <summary>
        /// Checks whether the beginning of this string (or a specified substring of this string instance) conforms to the specified regular expression.
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <param name="regPattern">A regular expression represented by a <c>System.Text.RegularExpressions.RegEx</c> object.</param>
        /// <param name="match">Outputs the <see cref="Match"/> object if <paramref name="regPattern"/> is matched at the beginning of the string.</param>
        /// <param name="startIndex">A zero-based character position in the current string that defines the leftmost position to be searched.</param>
        /// <param name="length">The number of characters to include in the search.</param>
        /// <returns>true if the beginning of this string (or the specified substring of this string instance) conforms to the specified regular expression
        /// represented by a <c>System.Text.RegularExpressions.RegEx</c> object; otherwise, false.</returns>
        public static bool REGStartsWith(this string str, Regex regPattern, out Match match, int startIndex = 0, int length = 0)
        {
            if (length == 0) length = str.Length - startIndex;
            match = regPattern.Match(str, startIndex, length);
            if (match != null && !match.Value.IsNullOrEmpty() && match.Index == startIndex) return true;
            match = null;
            return false;
        }

        /// <summary>
        /// Checks whether the end of this string (or a specified substring of this string instance) conforms to the specified regular expression.
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <param name="regPattern">A regular expression.</param>
        /// <param name="options">Regular expression options.</param>
        /// <param name="startIndex">A zero-based character position in the current string that defines the leftmost position to be searched.</param>
        /// <param name="length">The number of characters to include in the search.</param>
        /// <returns>true if the end of this string (or the specified substring of this string instance) conforms to the specified regular expression; otherwise, false.</returns>
        public static bool REGEndsWith(this string str, string regPattern, RegexOptions options = RegexOptions.None, int startIndex = 0, int length = 0)
        {
            return REGEndsWith(str, new Regex(regPattern, options), startIndex, length);
        }

        /// <summary>
        /// Checks whether the end of this string (or a specified substring of this string instance) conforms to the specified regular expression.
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <param name="regPattern">A regular expression.</param>
        /// <param name="match">Outputs the <see cref="Match"/> object if <paramref name="regPattern"/> is matched at the end of the string.</param>
        /// <param name="options">Regular expression options.</param>
        /// <param name="startIndex">A zero-based character position in the current string that defines the leftmost position to be searched.</param>
        /// <param name="length">The number of characters to include in the search.</param>
        /// <returns>true if the end of this string (or the specified substring of this string instance) conforms to the specified regular expression; otherwise, false.</returns>
        public static bool REGEndsWith(this string str, string regPattern, out Match match, RegexOptions options = RegexOptions.None, int startIndex = 0, int length = 0)
        {
            return REGEndsWith(str, new Regex(regPattern, options), out match, startIndex, length);
        }

        /// <summary>
        /// Checks whether the end of this string (or a specified substring of this string instance) conforms to the specified regular expression.
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <param name="regPattern">A regular expression represented by a <c>System.Text.RegularExpressions.RegEx</c> object.</param>
        /// <param name="startIndex">A zero-based character position in the current string that defines the leftmost position to be searched.</param>
        /// <param name="length">The number of characters to include in the search.</param>
        /// <returns>true if the end of this string (or the specified substring of this string instance) conforms to the specified regular expression
        /// represented by a <c>System.Text.RegularExpressions.RegEx</c> object; otherwise, false.</returns>
        public static bool REGEndsWith(this string str, Regex regPattern, int startIndex = 0, int length = 0)
        {
            if (length == 0) length = str.Length - startIndex;
            var matches = regPattern.Matches(str.Substring(startIndex, length));
            if (matches == null || matches.Count == 0) return false;
            else
            {
                var match = matches[matches.Count - 1];
                if (match.Value.IsNullOrEmpty()) return false;
                return match.Index + match.Length == startIndex + length;
            }
        }

        /// <summary>
        /// Checks whether the end of this string (or a specified substring of this string instance) conforms to the specified regular expression.
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <param name="regPattern">A regular expression represented by a <c>System.Text.RegularExpressions.RegEx</c> object.</param>
        /// <param name="match">Outputs the <see cref="Match"/> object if <paramref name="regPattern"/> is matched at the end of the string.</param>
        /// <param name="startIndex">A zero-based character position in the current string that defines the leftmost position to be searched.</param>
        /// <param name="length">The number of characters to include in the search.</param>
        /// <returns>true if the end of this string (or the specified substring of this string instance) conforms to the specified regular expression
        /// represented by a <c>System.Text.RegularExpressions.RegEx</c> object; otherwise, false.</returns>
        public static bool REGEndsWith(this string str, Regex regPattern, out Match match, int startIndex = 0, int length = 0)
        {
            if (length == 0) length = str.Length - startIndex;
            var matches = regPattern.Matches(str.Substring(startIndex, length));
            if (matches == null || matches.Count == 0)
            {
                match = null;
                return false;
            }
            else
            {
                match = matches[matches.Count - 1];
                if (!match.Value.IsNullOrEmpty() && match.Index + match.Length == startIndex + length) return true;
                match = null;
                return false;

            }
        }

        #endregion

        /// <summary>
        /// Replaces a word in this string by a specified replacement. 
        /// This method only supports string in word-based (not character-based, like Chinese or Japanese) language.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="word">The word to replace.</param>
        /// <param name="replacement">The replacement word.</param>
        /// <param name="options">Regular expression options.</param>
        /// <returns>The string with the word replaced.</returns>
        public static string ReplaceByWord(this string str, string word, string replacement, RegexOptions options)
        {
            str = " " + str + " ";
            return str.REGReplace(string.Format("([^a-zA-Z])({0})([^a-zA-Z])", word),
                string.Format("$1{0}$3", replacement), options).Trim();
        }

        /// <summary>
        /// Replaces a word in this string by a specified replacement. 
        /// This method only supports string in word-based (not character-based, like Chinese or Japanese) language.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="word">The word to replace.</param>
        /// <param name="replacement">The replacement word.</param>
        /// <returns>The string with the word replaced.</returns>
        public static string ReplaceByWord(this string str, string word, string replacement)
        {
            return str.ReplaceByWord(word, replacement, RegexOptions.None);
        }

        /// <summary>
        /// Shrinks all blank spaces in this string to a single space.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveExcessiveBlanks(this string str)
        {
            return str.REGReplace(@"\s+", " ");
        }

        /// <summary>
        /// Checks whether a substring of this string contains a section that conforms to a given regular expression pattern.
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <param name="startIdx">The position of the substring to check.</param>
        /// <param name="regPattern">A regular expression pattern.</param>
        /// <param name="options">Regular expression options.</param>
        /// <returns>true if the substring contains a section that conforms to the given pattern; otherwise, false.</returns>
        public static bool REGContains(this string str, int startIdx, string regPattern, RegexOptions options)
        {
            Regex reg = new Regex(regPattern, options);
            return reg.IsMatch(str, startIdx);
        }

        /// <summary>
        /// Checks whether this string contains a section that conforms to a given regular expression pattern.
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <param name="regPattern">A regular expression pattern.</param>
        /// <param name="options">Regular expression options.</param>
        /// <returns>true if the string contains a section that conforms to the given pattern; otherwise, false.</returns>
        public static bool REGContains(this string str, string regPattern, RegexOptions options)
        {
            return str.REGContains(0, regPattern, options);
        }

        /// <summary>
        /// Checks whether this string contains a section that conforms to a given regular expression pattern.
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <param name="regPattern">A regular expression pattern.</param>
        /// <returns>true if the string contains a section that conforms to the given pattern; otherwise, false.</returns>
        public static bool REGContains(this string str, string regPattern)
        {
            return str.REGContains(regPattern, RegexOptions.None);
        }

        /// <summary>
        /// Replaces sections in this string that matches a given regular expression pattern by another specified string.
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <param name="regPattern">A regular expression pattern.</param>
        /// <param name="replacement">A replacement string.</param>
        /// <param name="options">Regular expression options.</param>
        /// <returns>The replaced string.</returns>
        public static string REGReplace(this string str, string regPattern, string replacement, RegexOptions options)
        {
            Regex reg = new Regex(regPattern, options);
            return reg.Replace(str, replacement);
        }

        /// <summary>
        /// Replaces sections in this string that matches a given regular expression pattern by another specified string.
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <param name="regPattern">A regular expression pattern.</param>
        /// <param name="replacement">A replacement string.</param>
        /// <returns>The replaced string.</returns>
        public static string REGReplace(this string str, string regPattern, string replacement)
        {
            return str.REGReplace(regPattern, replacement, RegexOptions.None);
        }

        /// <summary>
        /// Removes sections in this string that matches a given regular expression pattern.
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <param name="regPattern">A regular expression pattern.</param>
        /// <param name="options">Regular expression options.</param>
        /// <returns>The processed string.</returns>
        public static string REGRemove(this string str, string regPattern, RegexOptions options)
        {
            return str.REGReplace(regPattern, "", options);
        }

        /// <summary>
        /// Removes sections in this string that matches a given regular expression pattern.
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <param name="regPattern">A regular expression pattern.</param>
        /// <returns>The processed string.</returns>
        public static string REGRemove(this string str, string regPattern)
        {
            return str.REGReplace(regPattern, "", RegexOptions.None);
        }

        /// <summary>
        /// Finds the first match of a given regular expression pattern.
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <param name="startIdx">The position in the string where the finding starts.</param>
        /// <param name="regPattern">A regular expression pattern.</param>
        /// <param name="options">Regular expression options.</param>
        /// <returns>The position in the string where the match is found.</returns>
        public static Match REGMatch(this string str, int startIdx, string regPattern, RegexOptions options)
        {
            Regex reg = new Regex(regPattern, options);
            return reg.Match(str, startIdx);
        }

        /// <summary>
        /// Finds the first match of a given regular expression pattern.
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <param name="regPattern">A regular expression pattern.</param>
        /// <param name="options">Regular expression options.</param>
        /// <returns>The position in the string where the match is found.</returns>
        public static Match REGMatch(this string str, string regPattern, RegexOptions options)
        {
            return str.REGMatch(0, regPattern, options);
        }

        /// <summary>
        /// Finds the first match of a given regular expression pattern.
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <param name="regPattern">A regular expression pattern.</param>
        /// <returns>The position in the string where the match is found.</returns>
        public static Match REGMatch(this string str, string regPattern)
        {
            return str.REGMatch(regPattern, RegexOptions.None);
        }

        /// <summary>
        /// Finds all matches of a given regular expression pattern in this string.
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <param name="startIdx">The position in the string where the finding starts.</param>
        /// <param name="regPattern">A regular expression pattern.</param>
        /// <param name="options">Regular expression options.</param>
        /// <returns>The position in the string where the match is found.</returns>
        public static MatchCollection REGMatches(this string str, int startIdx, string regPattern, RegexOptions options)
        {
            Regex reg = new Regex(regPattern, options);
            return reg.Matches(str, startIdx);
        }

        /// <summary>
        /// Finds all matches of a given regular expression pattern in this string.
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <param name="regPattern">A regular expression pattern.</param>
        /// <param name="options">Regular expression options.</param>
        /// <returns>The position in the string where the match is found.</returns>
        public static MatchCollection REGMatches(this string str, string regPattern, RegexOptions options)
        {
            return str.REGMatches(0, regPattern, options);
        }

        /// <summary>
        /// Finds all matches of a given regular expression pattern in this string.
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <param name="regPattern">A regular expression pattern.</param>
        /// <returns>The position in the string where the match is found.</returns>
        public static MatchCollection REGMatches(this string str, string regPattern)
        {
            return str.REGMatches(regPattern, RegexOptions.None);
        }
    }
}

