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
        /// Gets an enumerator that iterates through key/value pairs represented by this string instance (or a substring of it), if this string follows certain syntax.
        /// </summary>
        /// <param name="expression">This string instance.</param>
        /// <param name="startIndex">Specifies where the representation of key/value pairs starts.</param>
        /// <param name="length">Specifies the length of the representation.</param>
        /// <param name="keyDelimiter">The Unicode character that delimits key and value in each pair.
        /// In each pair, only the first character that equals this argument will be recognized as a delimiter, and it cannot be escaped.</param>
        /// <param name="pairDelimiter">The Unicode character that delimits key/value pairs. This delimiter is escapable.</param>
        /// <param name="leftQuote">The Unicode character as the left escape quote for <paramref name="pairDelimiter" />. Use '\0' to indicate the escape is disabled and
        /// all three argument <paramref name="leftQuote" />, <paramref name="rightQuote" /> and <paramref name="escape" /> are ineffective.</param>
        /// <param name="rightQuote">The Unicode character as the right escape quote for <paramref name="pairDelimiter" />.</param>
        /// <param name="trimValue"><c>true</c> if the white spaces at both ends of the value of each returned pair is trimmed; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An enumerator that iterates through key/value pairs represented by this string instance.
        /// </returns>
        /// <remarks>
        /// This string must follow the syntax "(&lt;key&gt; &lt;keyDelimiter&gt; &lt;leftQuote&gt;?&lt;value&gt; &lt;pairDelimiter&gt;&lt;rightQuote&gt;?) (...n)"
        /// If the <paramref name="pairDelimiter" /> is ';' (default value) and the escape is disabled, this string must follow the syntax "(&lt;key&gt; = &lt;value&gt;;) (...n)" which is exactly the same as a standard database connection string.
        /// </remarks>
        public static IEnumerator<KeyValuePair<string, string>> GetKeyValuePairEnumerator(this string expression, int startIndex, int length, char keyDelimiter = '=',
            char pairDelimiter = ';', char leftQuote = '[', char rightQuote = ']', bool trimValue = true)
        {
            var reader = new StringReader(expression, startIndex, length);
            return reader.GetKeyValuePairEnumerator(keyDelimiter, pairDelimiter, leftQuote, rightQuote, trimValue);
        }

        /// <summary>
        /// Gets an enumerator that iterates through key/value pairs represented by this string instance (or a substring of it), if this string follows certain syntax.
        /// </summary>
        /// <param name="expression">This string instance.</param>
        /// <param name="startIndex">Specifies where the representation of key/value pairs starts.</param>
        /// <param name="keyDelimiter">The Unicode character that delimits key and value in each pair.
        /// In each pair, only the first character that equals this argument will be recognized as a delimiter, and it cannot be escaped.</param>
        /// <param name="pairDelimiter">The Unicode character that delimits key/value pairs. This delimiter is escapable.</param>
        /// <param name="leftQuote">The Unicode character as the left escape quote for <paramref name="pairDelimiter" />. Use '\0' to indicate the escape is disabled and
        /// all three argument <paramref name="leftQuote" />, <paramref name="rightQuote" /> and <paramref name="escape" /> are ineffective.</param>
        /// <param name="rightQuote">The Unicode character as the right escape quote for <paramref name="pairDelimiter" />.</param>
        /// <param name="trimValue"><c>true</c> if the white spaces at both ends of the value of each returned pair is trimmed; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An enumerator that iterates through key/value pairs represented by this string instance.
        /// </returns>
        /// <remarks>
        /// This string must follow the syntax "(&lt;key&gt; &lt;keyDelimiter&gt; &lt;leftQuote&gt;?&lt;value&gt; &lt;pairDelimiter&gt;&lt;rightQuote&gt;?) (...n)"
        /// If the <paramref name="pairDelimiter" /> is ';' (default value) and the escape is disabled, this string must follow the syntax "(&lt;key&gt; = &lt;value&gt;;) (...n)" which is exactly the same as a standard database connection string.
        /// </remarks>
        public static IEnumerator<KeyValuePair<string, string>> GetKeyValuePairEnumerator(this string expression, int startIndex, char keyDelimiter = '=',
            char pairDelimiter = ';', char leftQuote = '[', char rightQuote = ']', bool trimValue = true)
        {
            return GetKeyValuePairEnumerator(expression, startIndex, expression.Length - startIndex, keyDelimiter, pairDelimiter, leftQuote, rightQuote, trimValue);
        }

        /// <summary>
        /// Gets an enumerator that iterates through key/value pairs represented by this string instance, if this string follows certain syntax.
        /// </summary>
        /// <param name="expression">This string instance.</param>
        /// <param name="keyDelimiter">The Unicode character that delimits key and value in each pair.
        /// In each pair, only the first character that equals this argument will be recognized as a delimiter, and it cannot be escaped.</param>
        /// <param name="pairDelimiter">The Unicode character that delimits key/value pairs. This delimiter is escapable.</param>
        /// <param name="leftQuote">The Unicode character as the left escape quote for <paramref name="pairDelimiter" />. Use '\0' to indicate the escape is disabled and
        /// all three argument <paramref name="leftQuote" />, <paramref name="rightQuote" /> and <paramref name="escape" /> are ineffective.</param>
        /// <param name="rightQuote">The Unicode character as the right escape quote for <paramref name="pairDelimiter" />.</param>
        /// <param name="trimValue"><c>true</c> if the white spaces at both ends of the value of each returned pair is trimmed; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An enumerator that iterates through key/value pairs represented by this string instance.
        /// </returns>
        /// <remarks>
        /// This string must follow the syntax "(&lt;key&gt; &lt;keyDelimiter&gt; &lt;leftQuote&gt;?&lt;value&gt; &lt;pairDelimiter&gt;&lt;rightQuote&gt;?) (...n)"
        /// If the <paramref name="pairDelimiter" /> is ';' (default value) and the escape is disabled, this string must follow the syntax "(&lt;key&gt; = &lt;value&gt;;) (...n)" which is exactly the same as a standard database connection string.
        /// </remarks>
        public static IEnumerator<KeyValuePair<string, string>> GetKeyValuePairEnumerator(this string expression, char keyDelimiter = '=',
            char pairDelimiter = ';', char leftQuote = '[', char rightQuote = ']', bool trimValue = true)
        {
            return GetKeyValuePairEnumerator(expression, 0, expression.Length, keyDelimiter, pairDelimiter, leftQuote, rightQuote, trimValue);
        }
    }
}
