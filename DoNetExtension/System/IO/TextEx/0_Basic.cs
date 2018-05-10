using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.IO
{
    public static partial class TextEx
    {
        #region Must-have Navigations

        /// <summary>
        /// Advances the reader to the position after the next occurrence of the specified <paramref name="keychar" />.
        /// </summary>
        /// <param name="reader">The <paramref name="reader" /> will advance its position to the character immediately after the next occurrence of this <paramref name="keychar" />.</param>
        /// <param name="keychar">The value.</param>
        /// <remarks>This method differs from <see cref="SkipTo(TextReader, char)"/> only in that it does not return a <see cref="bool"/> value indicating if the <paramref name="keychar"/> is encountered during reading.</remarks>
        public static void AdvanceTo(this TextReader reader, char keychar)
        {
            while (reader.Read() != keychar) ;
        }

        /// <summary>
        /// Reads until the specified <paramref name="keychar" /> is encountered. <paramref name="keychar" /> will not be included in the returned string.
        /// </summary>
        /// <param name="reader">A <see cref="TextReader" /> object.</param>
        /// <param name="keychar">The <paramref name="reader" /> will advance its position to the character immediately after the next occurrence of this <paramref name="keychar" />.</param>
        /// <param name="returnIfKeycharNotFound"><c>true</c> if a string starting from the reader's current position to the end should be returned if no <paramref name="keychar"/> is encountered in reading; <c>false</c> if <c>null</c> should be returned in this situation.</param>
        /// <returns>A <see cref="string" /> read from the <see cref="TextReader" /> from its current position to the position of the specified <paramref name="keychar" />, or to the end of the <paramref name="reader"/> if no such <paramref name="keychar"/> is found.</returns>
        public static string ReadTo(this TextReader reader, char keychar, bool returnIfKeycharNotFound = true)
        {
            var sb = StringBuilderCache.Acquire();
            int ci;
            while ((ci = reader.Read()) != -1)
            {
                if (ci == keychar) return StringBuilderCache.GetStringAndRelease(sb);
                else sb.Append((char)ci);
            }

            if (returnIfKeycharNotFound) return StringBuilderCache.GetStringAndRelease(sb);
            else
            {
                StringBuilderCache.Release(sb);
                return null;
            }
        }

        /// <summary>
        /// Reads next piece of string with spaces defined by <see cref="char.IsWhiteSpace(char)"/> is encountered as delimiters. The whitespaces will not be included in the returned string.
        /// </summary>
        /// <param name="reader">A <see cref="TextReader" /> object.</param>
        /// <returns>A <see cref="string"/> piece retrieved from the <paramref name="reader"/>.</returns>
        public static string ReadPiece(this TextReader reader)
        {
            int ci;
            while ((ci = reader.Read()) != -1 && ((char)ci).IsWhiteSpace()) ;

            if (ci == -1) return null;
            else
            {
                var sb = StringBuilderCache.Acquire();
                sb.Append((char)ci);
                while ((ci = reader.Read()) != -1 && !((char)ci).IsWhiteSpace()) sb.Append((char)ci);
                return StringBuilderCache.GetStringAndRelease(sb);
            }
        }

        /// <summary>
        /// Reads a specified number of string pieces delimited by whitespaces defined by <see cref="char.IsWhiteSpace(char)"/>.
        /// </summary>
        /// <param name="reader">A <see cref="TextReader" /> object.</param>
        /// <param name="count">The number of string pieces to read.</param>
        /// <returns>An array of <see cref="string"/> pieces retrieved from the <paramref name="reader"/>.</returns>
        public static string[] ReadPieces(this TextReader reader, int count)
        {
            var output = new string[count];
            for (int i = 0; i < count; ++i)
                output[i] = reader.ReadPiece();
            return output;
        }



        /// <summary>
        /// Reads until the specified <paramref name="keychar" /> is encountered. <paramref name="keychar" /> will be included at the end of the returned string.
        /// </summary>
        /// <param name="reader">A <see cref="TextReader" /> object.</param>
        /// <param name="keychar">The <paramref name="reader" /> will advance its position to the character immediately after the next occurrence of this <paramref name="keychar" />.</param>
        /// <param name="returnIfKeycharNotFound"><c>true</c> if a string starting from the reader's current position to the end should be returned if no <paramref name="keychar"/> is encountered in reading; <c>false</c> if <c>null</c> should be returned in this situation.</param>
        /// <returns>A <see cref="string" /> read from the <see cref="TextReader" /> from its current position to the position of the specified <paramref name="keychar" /> with <paramref name="keychar"/> at the end of the returned <see cref="string"/>, or to the end of the <paramref name="reader"/> if no such <paramref name="keychar"/> is found.</returns>
        public static string ReadAfter(this TextReader reader, char keychar, bool returnIfKeycharNotFound = true)
        {
            var sb = StringBuilderCache.Acquire();
            int ci;
            while ((ci = reader.Read()) != -1)
            {
                if (ci == keychar)
                {
                    sb.Append(keychar);
                    return StringBuilderCache.GetStringAndRelease(sb);
                }
                else sb.Append((char)ci);
            }

            if (returnIfKeycharNotFound) return StringBuilderCache.GetStringAndRelease(sb);
            else
            {
                StringBuilderCache.Release(sb);
                return null;
            }
        }

        /// <summary>
        /// Advances the reader to the position after the next occurrence of the specified <paramref name="keychar" />.
        /// </summary>
        /// <param name="reader">A <see cref="TextReader" /> object.</param>
        /// <param name="keychar">The <paramref name="reader" /> will advance its position to the character immediately after the next occurrence of this <paramref name="keychar" />.</param>
        /// <returns><c>true</c> if <paramref name="keychar"/> is encountered, <c>false</c> otherwise.</returns>
        public static bool SkipTo(this TextReader reader, char keychar)
        {
            int ci;
            while ((ci = reader.Read()) != keychar) ;
            return ci != -1;
        }

        /// <summary>
        /// Skips white spaces defined by <see cref="char.IsWhiteSpace(char)"/> and returns the next non-whitespace character.
        /// </summary>
        /// <param name="reader">A <see cref="TextReader" /> object.</param>
        /// <returns>The next non-whitespace retrieved from the <paramref name="reader"/>.</returns>
        public static char ReadNonWhitespace(this TextReader reader)
        {
            int ci;
            while ((ci = reader.Read()) != -1 && ((char)ci).IsWhiteSpace()) ;
            return (char)ci;
        }

        /// <summary>
        /// Reads until the specified <paramref name="keyword" /> is encountered. <paramref name="keyword" /> will not be included in the returned string.
        /// </summary>
        /// <param name="reader">A <see cref="TextReader" /> object.</param>
        /// <param name="keyword">The <paramref name="reader" /> will advance its position to the character immediately after the next occurrence of this <paramref name="keyword" />.</param>
        /// <param name="returnIfKeywordNotFound"><c>true</c> if a string starting from the reader's current position to the end should be returned if no <paramref name="keyword"/> is encountered in reading; <c>false</c> if <c>null</c> should be returned in this situation.</param>
        /// <returns>A <see cref="string" /> read from the <see cref="TextReader" /> from its current position to the position of the specified <paramref name="keyword" />, or to the end of the <paramref name="reader"/> if no such <paramref name="keyword"/> is found.</returns>
        public static string ReadTo(this TextReader reader, string keyword, bool returnIfKeywordNotFound = true)
        {
            var i = 0;
            int ci;
            var sb = StringBuilderCache.Acquire();
            while ((ci = reader.Read()) != -1)
            {
                var c = (char)ci;
                if (c == keyword[i])
                {
                    ++i;
                    if (i == keyword.Length)
                        return StringBuilderCache.GetStringAndRelease(sb);
                }
                else
                {
                    if (i != 0)
                    {
                        sb.Append(keyword.Substring(0, i));
                        i = 0;
                    }

                    if (c == keyword[0]) ++i;
                    else sb.Append(c);
                }
            }

            if (returnIfKeywordNotFound) return StringBuilderCache.GetStringAndRelease(sb);
            else
            {
                StringBuilderCache.Release(sb);
                return null;
            }
        }

        public static string ReadTo(this TextReader reader, string keyword, string delimiter, bool returnIfKeywordNotFound = false)
        {
            if (delimiter == Environment.NewLine) return _innerReadToNewlineDelimiter(reader, keyword, returnIfKeywordNotFound);
            var i = 0;
            var j = 0;
            int ci;
            var sb = StringBuilderCache.Acquire();
            while ((ci = reader.Read()) != -1)
            {
                var c = (char)ci;

                if (c == delimiter[j])
                {
                    ++j;
                    if (j == delimiter.Length) break;
                }
                else
                {
                    if (c == delimiter[0]) j = 1;
                    else j = 0;
                }

                if (c == keyword[i])
                {
                    ++i;
                    if (i == keyword.Length)
                        return StringBuilderCache.GetStringAndRelease(sb);
                }
                else
                {
                    if (i != 0)
                    {
                        sb.Append(keyword.Substring(0, i));
                        i = 0;
                    }

                    if (c == keyword[0]) ++i;
                    else sb.Append(c);
                }

            }

            if (returnIfKeywordNotFound) return StringBuilderCache.GetStringAndRelease(sb);
            else
            {
                StringBuilderCache.Release(sb);
                return null;
            }
        }

        static string _innerReadToNewlineDelimiter(this TextReader reader, string keyword, bool returnIfKeywordNotFound)
        {
            var i = 0;
            var j = 0;
            int ci;
            var sb = StringBuilderCache.Acquire();
            var delimiter = Environment.NewLine;
            bool secondHit = false;
            while ((ci = reader.Read()) != -1)
            {
                var c = (char)ci;
                if (c == delimiter[j])
                {
                    ++j;
                    if (j == delimiter.Length)
                    {
                        if (secondHit) break;
                        else
                        {
                            while ((ci = reader.Read()) != -1 && ci != delimiter[0] && ((char)ci).IsWhiteSpace()) ;
                            if (ci == -1) break;
                            else if (ci == delimiter[0])
                            {
                                secondHit = true;
                                j = 1;
                                continue;
                            }
                            else c = (char)ci;
                        }
                    }
                }
                else if (c == delimiter.Last())
                {
                    while ((ci = reader.Read()) != -1 && ci != delimiter[0] && ((char)ci).IsWhiteSpace()) ;
                    if (ci == -1) break;
                    else if (ci == delimiter[0])
                    {
                        secondHit = true;
                        j = 1;
                        continue;
                    }
                    else c = (char)ci;
                }
                else
                {
                    if (c == delimiter[0]) j = 1;
                    else j = 0;
                }

                if (c == keyword[i])
                {
                    ++i;
                    if (i == keyword.Length)
                        return StringBuilderCache.GetStringAndRelease(sb);
                }
                else
                {
                    if (i != 0)
                    {
                        sb.Append(keyword.Substring(0, i));
                        i = 0;
                    }

                    if (c == keyword[0]) ++i;
                    else sb.Append(c);
                }

            }

            if (returnIfKeywordNotFound) return StringBuilderCache.GetStringAndRelease(sb);
            else
            {
                StringBuilderCache.Release(sb);
                return null;
            }
        }

        /// <summary>
        /// Reads until the specified <paramref name="keyword" /> is encountered. <paramref name="keyword" /> will be included at the end of the returned string.
        /// </summary>
        /// <param name="reader">A <see cref="TextReader" /> object.</param>
        /// <param name="keyword">The <paramref name="reader" /> will advance its position to the character immediately after the next occurrence of this <paramref name="keyword" />.</param>
        /// <param name="returnIfKeywordNotFound"><c>true</c> if a string starting from the reader's current position to the end should be returned if no <paramref name="keyword"/> is encountered in reading; <c>false</c> if <c>null</c> should be returned in this situation.</param>
        /// <returns>A <see cref="string" /> read from the <see cref="TextReader" /> from its current position to the position of the specified <paramref name="keyword" /> with <paramref name="keyword"/> at the end of the returned <see cref="string"/>, or to the end of the <paramref name="reader"/> if no such <paramref name="keyword"/> is found.</returns>
        public static string ReadAfter(this TextReader reader, string keyword, bool returnIfKeywordNotFound = true)
        {
            var i = 0;
            int ci;
            var sb = StringBuilderCache.Acquire();
            while ((ci = reader.Read()) != -1)
            {
                var c = (char)ci;
                if (c == keyword[i])
                {
                    ++i;
                    if (i == keyword.Length)
                    {
                        sb.Append(keyword);
                        return StringBuilderCache.GetStringAndRelease(sb);
                    }
                }
                else
                {
                    if (i != 0)
                    {
                        sb.Append(keyword.Substring(0, i));
                        i = 0;
                    }

                    if (c == keyword[0]) ++i;
                    else sb.Append(c);
                }
            }

            if (returnIfKeywordNotFound) return StringBuilderCache.GetStringAndRelease(sb);
            else
            {
                StringBuilderCache.Release(sb);
                return null;
            }
        }

        /// <summary>
        /// Advances the reader to the position after the next occurrence of the specified <paramref name="keyword" />.
        /// </summary>
        /// <param name="reader">A <see cref="TextReader" /> object.</param>
        /// <param name="keyword">The <paramref name="reader" /> will advance its position to the character immediately after the next occurrence of this <paramref name="keyword" />.</param>
        /// <returns><c>true</c> if <paramref name="keyword"/> is encountered, <c>false</c> otherwise.</returns>
        public static bool SkipTo(this TextReader reader, string keyword)
        {
            var i = 0;
            int ci;
            while ((ci = reader.Read()) != -1)
            {
                var c = (char)ci;
                if (c == keyword[i])
                {
                    ++i;
                    if (i == keyword.Length) return true;
                }
                else
                {
                    if (c == keyword[0]) i = 1;
                    else i = 0;
                }
            }

            return false;
        }

        public static bool SkipTo(this TextReader reader, string keyword, string delimiter)
        {
            if (delimiter == Environment.NewLine) return _innerSkipToNewlineDelimiter(reader, keyword);
            var i = 0;
            var j = 0;
            int ci;
            while ((ci = reader.Read()) != -1)
            {
                var c = (char)ci;

                if (c == delimiter[j])
                {
                    ++j;
                    if (j == delimiter.Length) break;
                }
                else
                {
                    if (c == delimiter[0]) j = 1;
                    else j = 0;
                }

                if (c == keyword[i])
                {
                    ++i;
                    if (i == keyword.Length)
                        return true;
                }
                else
                {
                    if (c == keyword[0]) i = 1;
                    else i = 0;
                }

            }

            return false;
        }

        static bool _innerSkipToNewlineDelimiter(this TextReader reader, string keyword)
        {
            var i = 0;
            var j = 0;
            int ci;
            var delimiter = Environment.NewLine;
            bool secondHit = false;
            while ((ci = reader.Read()) != -1)
            {
                var c = (char)ci;
                if (c == delimiter[j])
                {
                    ++j;
                    if (j == delimiter.Length)
                    {
                        if (secondHit) break;
                        else
                        {
                            while ((ci = reader.Read()) != -1 && ci != delimiter[0] && ((char)ci).IsWhiteSpace()) ;
                            if (ci == -1) break;
                            else if (ci == delimiter[0])
                            {
                                secondHit = true;
                                j = 1;
                                continue;
                            }
                            else c = (char)ci;
                        }
                    }
                }
                else
                {
                    if (c == delimiter[0]) j = 1;
                    else j = 0;
                }

                if (c == keyword[i])
                {
                    ++i;
                    if (i == keyword.Length)
                        return true;
                }
                else
                {
                    if (c == keyword[0]) i = 1;
                    else i = 0;
                }

            }

            return false;
        }

        #endregion

        #region Number Reading

        /// <summary>
        /// Reads the next integer at most 32-bit large.
        /// </summary>
        /// <param name="reader">A <see cref="TextReader" /> object.</param>
        /// <returns>The next integer; or <c>null</c> if reading fails.</returns>
        public static int? ReadInteger(this TextReader reader)
        {
            int ci;
            var negative = false;
            int num = 0;
            while ((ci = reader.Read()) != -1)
            {
                var c = (char)ci;
                if (ci == '+')
                {
                    c = reader.ReadNonWhitespace();
                    if (!c.IsASCIIDigit()) return null;
                    num = c - '0';
                    break;
                }
                else if (ci == '-')
                {
                    negative = true;
                    c = reader.ReadNonWhitespace();
                    if (!c.IsASCIIDigit()) return null;
                    num = c - '0';
                    break;
                }
                else if (c.IsASCIIDigit())
                {
                    num = c - '0';
                    break;
                }
            }

            while ((ci = reader.Read()) != -1 && ((char)ci).IsASCIIDigit())
                num = num * 10 + ci - '0';

            return negative ? -num : num;
        }

        /// <summary>
        /// Reads the next number as a <see cref="double"/>.
        /// </summary>
        /// <param name="reader">A <see cref="TextReader" /> object.</param>
        /// <returns>The next number as a <see cref="double"/>; or <c>null</c> if reading fails.</returns>
        public static double? ReadNumber(this TextReader reader)
        {
            int ci;
            var negative = false;
            double num = 0;
            while ((ci = reader.Read()) != -1)
            {
                var c = (char)ci;
                if (ci == '+')
                {
                    c = reader.ReadNonWhitespace();
                    if (!c.IsASCIIDigit()) return null;
                    num = c - '0';
                    break;
                }
                else if (ci == '-')
                {
                    negative = true;
                    c = reader.ReadNonWhitespace();
                    if (!c.IsASCIIDigit()) return null;
                    num = c - '0';
                    break;
                }
                else if (c.IsASCIIDigit())
                {
                    num = c - '0';
                    break;
                }
            }

            while ((ci = reader.Read()) != -1 && ((char)ci).IsASCIIDigit())
                num = num * 10 + ci - '0';

            if (ci == '.')
            {
                double @base = 10;
                while ((ci = reader.Read()) != -1 && ((char)ci).IsASCIIDigit())
                {
                    num += (ci - '0') / @base;
                    @base *= 10;
                }
            }

            return negative ? -num : num;
        }

        #endregion


        public static string ReadNonEmptyLine(this StreamReader reader)
        {
            if (reader.EndOfStream) return null;
            var line = reader.ReadLine();
            while (line.IsNullOrEmpty())
            {
                if (reader.EndOfStream) return null;
                line = reader.ReadLine();
            }

            return line;
        }

        public static string ReadNonBlankLine(this StreamReader reader)
        {
            if (reader.EndOfStream) return null;
            var line = reader.ReadLine();
            while (line.IsNullOrEmptyOrBlank())
            {
                if (reader.EndOfStream) return null;
                line = reader.ReadLine();
            }

            return line;
        }

        public static string ReadNonBlankLineWithTrim(this StreamReader reader)
        {
            if (reader.EndOfStream) return null;
            var line = reader.ReadLine().Trim();
            while (line.IsNullOrEmpty())
            {
                if (reader.EndOfStream) return null;
                line = reader.ReadLine().Trim();
            }

            return line;
        }

        public static string AdvanceToLineBlock(this StreamReader reader, int lineBlockIndex)
        {
            string line;
            line = reader.ReadNonBlankLine();

            while (lineBlockIndex > 0)
            {
                line = reader.ReadNonBlankLine();
                if (line == null) return null;
                --lineBlockIndex;
            }

            return line;
        }

        public static void AdvanceToEmptyLine(this StreamReader reader)
        {
            string line;
            while (!reader.EndOfStream && !(line = reader.ReadLine()).IsNullOrEmpty()) ;
        }

        public static void AdvanceToBlankLine(this StreamReader reader)
        {
            string line;
            while (!reader.EndOfStream && !(line = reader.ReadLine()).IsNullOrEmptyOrBlank()) ;
        }

        public static string AdvanceToLineBlockWithTrim(this StreamReader reader, int lineBlockIndex)
        {
            var line = reader.ReadNonBlankLineWithTrim();

            while (lineBlockIndex > 0)
            {
                reader.AdvanceToBlankLine();
                line = reader.ReadNonBlankLineWithTrim();
                if (line == null) return null;
                --lineBlockIndex;
            }

            return line;
        }

        public static IEnumerator<string> GetLineEnumerator(this StreamReader reader)
        {
            while (!reader.EndOfStream)
                yield return reader.ReadLine();
        }

        public static void LineReplace(this StreamReader reader, TextWriter output, string[] oldValues, string[] newValues)
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                line = line.Replace(oldValues, newValues);
                output.WriteLine(line);
            }
        }

        public static void LineReplace(this StreamReader reader, string outputPath, string[] oldValues, string[] newValues, Encoding encoding = null)
        {
            using (var fs = File.Create(outputPath))
            {
                var sw = new StreamWriter(fs, encoding);
                LineReplace(reader, sw, oldValues, newValues);
                sw.Flush();
            }
        }

        public static void WriteLines(this TextWriter writer, string[] lines)
        {
            var count = lines.Length;
            for (int i = 0; i < count; ++i)
                writer.WriteLine(lines[i]);
        }

        public static void WriteLines(this TextWriter writer, string[] lines, int start, int length)
        {
            var end = start + length;
            for (int i = start; i < end; ++i)
                writer.WriteLine(lines[i]);
        }

        public static void Write(this TextWriter writer, params object[] objs)
        {
            for (int i = 0, j = objs.Length; i < j; ++i)
                writer.Write(objs[i]);
        }

        /// <summary>
        /// Writes the text representations of several objects concatenated by a delimiter to the current text writer.
        /// </summary>
        /// <param name="writer">A <see cref="TextWriter"/> object.</param>
        /// <param name="delimiter">The delimiter to concatenate text representations.</param>
        /// <param name="objs">The objects whose text representations are to be concatenated.</param>
        public static void WriteWithDelimiter<T>(this TextWriter writer, char delimiter, params T[] objs)
        {
            int i = 0;
            int j = objs.Length - 1;
            for (; i < j; ++i)
            {
                writer.Write(objs[i]);
                writer.Write(delimiter);
            }

            writer.Write(objs[i]);
        }

        /// <summary>
        /// Writes the text representations of objects in a collection concatenated by a delimiter to the current text writer.
        /// </summary>
        /// <param name="writer">A <see cref="TextWriter"/> object.</param>
        /// <param name="delimiter">The delimiter to concatenate text representations.</param>
        /// <param name="collection">The collection of objects whose text representations are to be concatenated.</param>
        public static void WriteWithDelimiter<T>(this TextWriter writer, char delimiter, IEnumerable<T> collection)
        {
            var e = collection.GetEnumerator();
            if (e.MoveNext())
                writer.Write(e.Current);
            while (e.MoveNext())
            {
                writer.Write(delimiter);
                writer.Write(e.Current);
            }
        }

        /// <summary>
        /// Writes the text representations of several objects concatenated by a delimiter to the current text writer as a single line.
        /// </summary>
        /// <param name="writer">A <see cref="TextWriter"/> object.</param>
        /// <param name="delimiter">The delimiter to concatenate text representations.</param>
        /// <param name="objs">The objects whose text representations are to be concatenated.</param>
        public static void WriteLineWithDelimiter<T>(this TextWriter writer, char delimiter, params T[] objs)
        {
            writer.WriteWithDelimiter(delimiter, objs);
            writer.WriteLine();
        }

        /// <summary>
        /// Writes the text representations of objects in a collection concatenated by a delimiter to the current text writer as a single line.
        /// </summary>
        /// <param name="writer">A <see cref="TextWriter"/> object.</param>
        /// <param name="delimiter">The delimiter to concatenate text representations.</param>
        /// <param name="collection">The collection of objects whose text representations are to be concatenated.</param>
        public static void WriteLineWithDelimiter<T>(this TextWriter writer, char delimiter, IEnumerable<T> collection)
        {
            writer.WriteWithDelimiter(delimiter, collection);
            writer.WriteLine();
        }

        public static void Advance(this TextReader reader, int lineCount)
        {
            while (lineCount > 0)
            {
                reader.ReadLine();
                --lineCount;
            }
        }

    }
}
