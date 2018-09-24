using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Text
{
    public partial class StringReader
    {
        /// <summary>
        /// Gets an enumerator that iterates through key/value pairs represented by this <see cref="StringReader"/> if its reading scope follows certain syntax.
        /// </summary>
        /// <param name="keyDelimiter">The Unicode character that delimits key and value in each pair. In each pair, only the first character that equals this argument will be recognized as a delimiter, and it cannot be escaped.</param>
        /// <param name="pairDelimiter">The Unicode character that delimits key/value pairs. This delimiter is escapable.</param>
        /// <param name="leftQuote">The Unicode character as the left escaping quote for <paramref name="pairDelimiter" />. Use '\0' to indicate the escape is disabled.</param>
        /// <param name="rightQuote">The Unicode character as the right escape quote for <paramref name="pairDelimiter" />.</param>
        /// <param name="trimValue"><c>true</c> if the white spaces at both ends of the value of each returned pair is trimmed; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An enumerator that iterates through key/value pairs represented by this <see cref="StringReader"/>.
        /// </returns>
        /// <remarks>
        /// To parse the current reading scope as key/value pairs, the reading scope must follow the syntax <c>(&lt;key&gt; &lt;key/value delimiter&gt; [&lt;left escaping quote&gt;]&lt;value&gt; &lt;pair delimiter&gt;[&lt;right escaping quote&gt;]) (...n)</c>.
        /// <para>If the <paramref name="pairDelimiter" /> is ';' (default value) and the escape is disabled, this string must follow the syntax <c>(&lt;key&gt; = &lt;value&gt;;) (...n)</c>, which is exactly the same as a standard database connection string.</para>
        /// </remarks>
        public IEnumerator<KeyValuePair<string, string>> GetKeyValuePairEnumerator(char keyDelimiter = '=', char pairDelimiter = ';', char leftQuote = '[', char rightQuote = ']', bool trimValue = true)
        {
            if (!EOF)
            {
                Trim();
                if (!EOF)
                {
                    Trim();
                    while (!EOF)
                    {
                        var itemReader = ReadAfterWithTrimAsReader(pairDelimiter, leftQuote, rightQuote, true, true);
                        var key = itemReader.ReadAfterWithTrimAsReader(keyDelimiter, leftQuote, rightQuote, true, false);
                        if (key == null) yield return new KeyValuePair<string, string>(itemReader.ReadToEnd(), null);
                        else
                        {
                            key.RemoveMatchedEnds(leftQuote, rightQuote);
                            itemReader.RemoveMatchedEnds(leftQuote, rightQuote);
                            yield return new KeyValuePair<string, string>(key, trimValue ? itemReader.ReadToEndWithTrim() : itemReader.ReadToEnd());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets an enumerator that iterates through key/value pairs represented by this <see cref="StringReader"/> if its reading scope follows certain syntax.
        /// </summary>
        /// <param name="keyDelimiter">The Unicode character that delimits key and value in each pair. In each pair, only the first character that equals this argument will be recognized as a delimiter, and it cannot be escaped.</param>
        /// <param name="pairDelimiter">The Unicode character that delimits key/value pairs. This delimiter is escapable.</param>
        /// <param name="leftQuote">The Unicode character as the left escaping quote for <paramref name="pairDelimiter" />. Use '\0' to indicate the escape is disabled.</param>
        /// <param name="rightQuote">The Unicode character as the right escape quote for <paramref name="pairDelimiter" />.</param>
        /// <param name="trimValue"><c>true</c> if the white spaces at both ends of the value of each returned pair is trimmed; otherwise, <c>false</c>.</param>
        /// <returns>
        /// An enumerator that iterates through key/value pairs represented by this <see cref="StringReader"/>. In each returned pair, the value is represented by a <see cref="StringReader"/>.
        /// </returns>
        /// <remarks>
        /// To parse the current reading scope as key/value pairs, the reading scope must follow the syntax <c>(&lt;key&gt; &lt;key/value delimiter&gt; [&lt;left escaping quote&gt;]&lt;value&gt; &lt;pair delimiter&gt;[&lt;right escaping quote&gt;]) (...n)</c>.
        /// <para>If the <paramref name="pairDelimiter" /> is ';' (default value) and the escape is disabled, this string must follow the syntax <c>(&lt;key&gt; = &lt;value&gt;;) (...n)</c>, which is exactly the same as a standard database connection string.</para>
        /// </remarks>
        public IEnumerator<KeyValuePair<string, StringReader>> GetKeyValuePairReaderEnumerator(char keyDelimiter = '=', char pairDelimiter = ';', char leftQuote = '[', char rightQuote = ']', bool trimValue = true)
        {
            if (!EOF)
            {
                Trim();
                if (!EOF)
                {
                    Trim();
                    while (!EOF)
                    {
                        var itemReader = ReadAfterWithTrimAsReader(pairDelimiter, leftQuote, rightQuote, true, true);
                        var key = itemReader.ReadAfterWithTrimAsReader(keyDelimiter, leftQuote, rightQuote, true, false);
                        if (key == null) yield return new KeyValuePair<string, StringReader>(itemReader.ToString(), null);
                        else
                        {
                            key.RemoveMatchedEnds(leftQuote, rightQuote);
                            itemReader.RemoveMatchedEnds(leftQuote, rightQuote);
                            if (trimValue) itemReader.Trim();
                            yield return new KeyValuePair<string, StringReader>(key, itemReader);
                        }
                    }
                }
            }
        }
    }
}
