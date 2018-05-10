using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public partial class StringReader
    {
        #region Predicate, Without Quotes
        
        /// <summary>
        /// Advances the reader and reads until a character satisfying <paramref name="predicate"/> is encountered.
        /// The reader's position after executing this method depends on the <paramref name="options"/>.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// If <c>ReadeOptions.ReadToEnd</c> is specified in <paramref name="options"/>, then a new reader will be returned encapsulating either a substring starting from the current position of the underlying string instance to the position of the first character satisfying the <paramref name="predicate" /> within the search scope when such character is found, or a substring starting from the current position of the underlying string instance to the end of the search scope if such character is not found.
        /// <para>If <c>ReadeOptions.ReadToEnd</c> is not specified, then a new reader will be returned encapsulating a substring starting from the current position of the underlying string instance to the position of the first character satisfying the <paramref name="predicate" /> within the search scope. When such character cannot be found, a <c>null</c> reference will be returned.</para>
        /// <para>The position of this reader after executing this method depends on if <c>ReadOptions.StopAfterKey</c> is specified. If <c>ReadOptions.StopAfterKey</c> is specified, then the character satisfying the <paramref name="predicate" /> is included in the returned new reader if <c>ReadOptions.DiscardKey</c> is also selected.</para>
        /// <para>NOTE that the white spaces at the beginning of the substring will be trimmed if <c>ReadeOptions.TrimStart</c> is specified, and the white spaces at the end of the substring will be trimmed if <c>ReadeOptions.TrimEnd</c> is specified. Also NOTE that <see cref="StringReader.EmptyReader"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public StringReader ReadToAsReader(Func<char, bool> predicate, ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey)
        {
            var idx = StringEx._innerIndexOf(UnderlyingString, predicate, CurrentPosition, EndPosition);
            return _innerReadToAsReader(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character satisfying <paramref name="predicate"/> is encountered.
        /// The current reader stops at the position of the key char and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope 
        /// if no character satisfying the <paramref name="predicate"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a new reader will be returned encapsulating either a substring starting from the current position of the underlying string instance to the position of the first character satisfying the <paramref name="predicate" /> within the search scope when such character is found, or a substring starting from the current position of the underlying string instance to the end of the search scope if such character is not found.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a new reader will be returned encapsulating a substring starting from the current position of the underlying string instance to the position of the first character satisfying the <paramref name="predicate" /> within the search scope when such character is found. When such character cannot be found, a <c>null</c> reference will be returned.</para>
        /// <para>NOTE that the white spaces at both ends of the substring will be trimmed. Also <see cref="StringReader.EmptyReader"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(Func<char, bool> predicate, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                ReadOptions.Default | ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                ReadOptions.Default | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(predicate, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character satisfying <paramref name="predicate" /> (key char) is encountered.
        /// The current reader stops at the position immediately after the encountered key char and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char.</param>
        /// <param name="discardKeychar"><c>true</c> if the key char will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a new reader will be returned encapsulating either a substring starting from the current position of the underlying string instance to the position of the first character satisfying the <paramref name="predicate" /> within the search scope when such character is found, or a substring starting from the current position of the underlying string instance to the end of the search scope if such character is not found.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a new reader will be returned encapsulating a substring starting from the current position of the underlying string instance to the position of the first character satisfying the <paramref name="predicate" /> within the search scope when such character is found. When such character cannot be found, a <c>null</c> reference will be returned.</para>
        /// <para>NOTE that whether the character is included in the returned new reader depends on <paramref name="discardKeychar"/>, and the white spaces at both ends of the substring will be trimmed. Also NOTE <see cref="StringReader.EmptyReader"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(Func<char, bool> predicate, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(predicate, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character satisfying <paramref name="predicate"/> is encountered.
        /// The current reader stops at the position of the key char.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if no character satisfying the <paramref name="predicate"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a new reader will be returned encapsulating either a substring starting from the current position of the underlying string instance to the position of the first character satisfying the <paramref name="predicate" /> within the search scope when such character is found, or a substring starting from the current position of the underlying string instance to the end of the search scope if such character is not found.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a new reader will be returned encapsulating a substring starting from the current position of the underlying string instance to the position of the first character satisfying the <paramref name="predicate" /> within the search scope when such character is found. When such character cannot be found, a <c>null</c> reference will be returned.</para>
        /// <para>NOTE that <see cref="StringReader.EmptyReader"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public StringReader ReadBeforeAsReader(Func<char, bool> predicate, bool readToEndIfKeycharNotFound = true)
        {
            return ReadToAsReader(predicate, readToEndIfKeycharNotFound ? ReadOptions.Default | ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until a character satisfying <paramref name="predicate" /> (key char) is encountered.
        /// The current reader stops at the position immediately after the position of the key char.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char.</param>
        /// <param name="discardKeychar"><c>true</c> if the key char will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope 
        /// if no character satisfying the <paramref name="predicate"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a new reader will be returned encapsulating either a substring starting from the current position of the underlying string instance to the position of the first character satisfying the <paramref name="predicate" /> within the search scope when such character is found, or a substring starting from the current position of the underlying string instance to the end of the search scope if such character is not found.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a new reader will be returned encapsulating a substring starting from the current position of the underlying string instance to the position of the first character satisfying the <paramref name="predicate" /> within the search scope when such character is found. When such character cannot be found, a <c>null</c> reference will be returned.</para>
        /// <para>NOTE that whether the character is included in the returned new reader depends on <paramref name="discardKeychar"/>, and <see cref="StringReader.EmptyReader"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public StringReader ReadAfterAsReader(Func<char, bool> predicate, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(predicate, options);
        }

        #endregion

        #region Predicate, Single Pair of Quotes

        /// <summary>
        /// Advances the reader and reads until a character satisfying <paramref name="predicate" /> (key char) is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when a key char is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when a key char is encountered inside a pair of quotes.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// If <c>ReadeOptions.ReadToEnd</c> is specified in <paramref name="options"/>, then a new reader will be returned encapsulating either a substring starting from the current position of the underlying string instance to the position of the first character satisfying the <paramref name="predicate" /> within the search scope when such character is found, or a substring starting from the current position of the underlying string instance to the end of the search scope if such character is not found.
        /// <para>If <c>ReadeOptions.ReadToEnd</c> is not specified, then a new reader will be returned encapsulating a substring starting from the current position of the underlying string instance to the position of the first character satisfying the <paramref name="predicate" /> within the search scope. When such character cannot be found, a <c>null</c> reference will be returned.</para>
        /// <para>The position of this reader after executing this method depends on if <c>ReadOptions.StopAfterKey</c> is specified. If <c>ReadOptions.StopAfterKey</c> is specified, then the character satisfying the <paramref name="predicate" /> is included in the returned new reader if <c>ReadOptions.DiscardKey</c> is also selected.</para>
        /// <para>NOTE that the white spaces at the beginning of the substring will be trimmed if <c>ReadeOptions.TrimStart</c> is specified, and the white spaces at the end of the substring will be trimmed if <c>ReadeOptions.TrimEnd</c> is specified. Also NOTE that <see cref="StringReader.EmptyReader"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public StringReader ReadToAsReader(Func<char, bool> predicate, char leftQuote, char rightQuote,
            ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, predicate, CurrentPosition, EndPosition, leftQuote, rightQuote);
            return _innerReadToAsReader(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character satisfying <paramref name="predicate" /> (key char) is encountered outside quotes.
        /// The current reader stops at the position of the key char and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when a key char is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when a key char is encountered inside a pair of quotes.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a new reader will be returned encapsulating either a substring starting from the current position of the underlying string instance to the position of the first character satisfying the <paramref name="predicate" /> within the search scope when such character is found, or a substring starting from the current position of the underlying string instance to the end of the search scope if such character is not found.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a new reader will be returned encapsulating a substring starting from the current position of the underlying string instance to the position of the first character satisfying the <paramref name="predicate" /> within the search scope when such character is found. When such character cannot be found, a <c>null</c> reference will be returned.</para>
        /// <para>NOTE that the white spaces at both ends of the substring will be trimmed. Also <see cref="StringReader.EmptyReader"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(Func<char, bool> predicate, char leftQuote, char rightQuote, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.Default | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(predicate, leftQuote, rightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character satisfying <paramref name="predicate" /> (key char) is encountered outside quotes.
        /// The current reader stops at the position immediately after the encountered key char and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when a key char is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when a key char is encountered inside a pair of quotes.</param>
        /// <param name="discardKeychar">If set to <c>true</c>, the predicate
        /// will be discarded and not be included in the returned substring.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a new reader will be returned encapsulating either a substring starting from the current position of the underlying string instance to the position of the first character satisfying the <paramref name="predicate" /> within the search scope when such character is found, or a substring starting from the current position of the underlying string instance to the end of the search scope if such character is not found.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a new reader will be returned encapsulating a substring starting from the current position of the underlying string instance to the position of the first character satisfying the <paramref name="predicate" /> within the search scope when such character is found. When such character cannot be found, a <c>null</c> reference will be returned.</para>
        /// <para>NOTE that whether the character is included in the returned new reader depends on <paramref name="discardKeychar"/>, and the white spaces at both ends of the substring will be trimmed. Also NOTE <see cref="StringReader.EmptyReader"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(Func<char, bool> predicate, char leftQuote, char rightQuote, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(predicate, leftQuote, rightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character satisfying <paramref name="predicate" /> (key char) is encountered outside quotes.
        /// The current reader stops at the position of the key char.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when a key char is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when a key char is encountered inside a pair of quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if no character satisfying the <paramref name="predicate"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a new reader will be returned encapsulating either a substring starting from the current position of the underlying string instance to the position of the first character satisfying the <paramref name="predicate" /> within the search scope when such character is found, or a substring starting from the current position of the underlying string instance to the end of the search scope if such character is not found.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a new reader will be returned encapsulating a substring starting from the current position of the underlying string instance to the position of the first character satisfying the <paramref name="predicate" /> within the search scope when such character is found. When such character cannot be found, a <c>null</c> reference will be returned.</para>
        /// <para>NOTE that <see cref="StringReader.EmptyReader"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public StringReader ReadBeforeAsReader(Func<char, bool> predicate, char leftQuote, char rightQuote, bool readToEndIfKeycharNotFound = true)
        {
            return ReadToAsReader(predicate, leftQuote, rightQuote, readToEndIfKeycharNotFound ? ReadOptions.Default | ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until a character satisfying <paramref name="predicate" /> (key char) is encountered outside quotes.
        /// The current reader stops at the position immediately after the position of the key char.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char.</param>
        /// <param name="leftQuote">The left quote. The reader will not stop when a key char is encountered inside a pair of quotes.</param>
        /// <param name="rightQuote">The right quote. The reader will not stop when a key char is encountered inside a pair of quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the key char will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if no character satisfying the <paramref name="predicate"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a new reader will be returned encapsulating either a substring starting from the current position of the underlying string instance to the position of the first character satisfying the <paramref name="predicate" /> within the search scope when such character is found, or a substring starting from the current position of the underlying string instance to the end of the search scope if such character is not found.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a new reader will be returned encapsulating a substring starting from the current position of the underlying string instance to the position of the first character satisfying the <paramref name="predicate" /> within the search scope when such character is found. When such character cannot be found, a <c>null</c> reference will be returned.</para>
        /// <para>NOTE that whether the character is included in the returned new reader depends on <paramref name="discardKeychar"/>, and <see cref="StringReader.EmptyReader"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public StringReader ReadAfterAsReader(Func<char, bool> predicate, char leftQuote, char rightQuote, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(predicate, leftQuote, rightQuote, options);
        }

        #endregion

        #region Predicate, Multiple Pairs of Quotes

        /// <summary>
        /// Advances the reader and reads until a character satisfying <paramref name="predicate" /> (key char) is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when a key char is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when a key char is encountered inside a pair of quotes.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// If <c>ReadeOptions.ReadToEnd</c> is specified in <paramref name="options"/>, then a new reader will be returned encapsulating either a substring starting from the current position of the underlying string instance to the position of the first character satisfying the <paramref name="predicate" /> within the search scope when such character is found, or a substring starting from the current position of the underlying string instance to the end of the search scope if such character is not found.
        /// <para>If <c>ReadeOptions.ReadToEnd</c> is not specified, then a new reader will be returned encapsulating a substring starting from the current position of the underlying string instance to the position of the first character satisfying the <paramref name="predicate" /> within the search scope. When such character cannot be found, a <c>null</c> reference will be returned.</para>
        /// <para>The position of this reader after executing this method depends on if <c>ReadOptions.StopAfterKey</c> is specified. If <c>ReadOptions.StopAfterKey</c> is specified, then the character satisfying the <paramref name="predicate" /> is included in the returned new reader if <c>ReadOptions.DiscardKey</c> is also selected.</para>
        /// <para>NOTE that the white spaces at the beginning of the substring will be trimmed if <c>ReadeOptions.TrimStart</c> is specified, and the white spaces at the end of the substring will be trimmed if <c>ReadeOptions.TrimEnd</c> is specified. Also NOTE that <see cref="StringReader.EmptyReader"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public StringReader ReadToAsReader(Func<char, bool> predicate, char[] leftQuotes, char[] rightQuotes,
            ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, predicate, CurrentPosition, EndPosition, leftQuotes, rightQuotes);
            return _innerReadToAsReader(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character satisfying <paramref name="predicate" /> (key char) is encountered outside quotes.
        /// The current reader stops at the position of the key char and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when a key char is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when a key char is encountered inside a pair of quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope 
        /// if no character satisfying the <paramref name="predicate"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a new reader will be returned encapsulating either a substring starting from the current position of the underlying string instance to the position of the first character satisfying the <paramref name="predicate" /> within the search scope when such character is found, or a substring starting from the current position of the underlying string instance to the end of the search scope if such character is not found.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a new reader will be returned encapsulating a substring starting from the current position of the underlying string instance to the position of the first character satisfying the <paramref name="predicate" /> within the search scope when such character is found. When such character cannot be found, a <c>null</c> reference will be returned.</para>
        /// <para>NOTE that the white spaces at both ends of the substring will be trimmed. Also <see cref="StringReader.EmptyReader"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(Func<char, bool> predicate, char[] leftQuotes, char[] rightQuotes, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                ReadOptions.Default | ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                ReadOptions.Default | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(predicate, leftQuotes, rightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character satisfying <paramref name="predicate" /> (key char) is encountered outside quotes.
        /// The current reader stops at the position immediately after the encountered key char and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when a key char is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when a key char is encountered inside a pair of quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the key char will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope 
        /// if no character satisfying the <paramref name="predicate"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a new reader will be returned encapsulating either a substring starting from the current position of the underlying string instance to the position of the first character satisfying the <paramref name="predicate" /> within the search scope when such character is found, or a substring starting from the current position of the underlying string instance to the end of the search scope if such character is not found.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a new reader will be returned encapsulating a substring starting from the current position of the underlying string instance to the position of the first character satisfying the <paramref name="predicate" /> within the search scope when such character is found. When such character cannot be found, a <c>null</c> reference will be returned.</para>
        /// <para>NOTE that whether the character is included in the returned new reader depends on <paramref name="discardKeychar"/>, and the white spaces at both ends of the substring will be trimmed. Also NOTE <see cref="StringReader.EmptyReader"/> will be returned if the length of the substring after trim is 0.</para>
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(Func<char, bool> predicate, char[] leftQuotes, char[] rightQuotes, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(predicate, leftQuotes, rightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character satisfying <paramref name="predicate" /> (key char) is encountered outside quotes.
        /// The current reader stops at the position of the key char.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when a key char is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when a key char is encountered inside a pair of quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if no character satisfying the <paramref name="predicate"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a new reader will be returned encapsulating either a substring starting from the current position of the underlying string instance to the position of the first character satisfying the <paramref name="predicate" /> within the search scope when such character is found, or a substring starting from the current position of the underlying string instance to the end of the search scope if such character is not found.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a new reader will be returned encapsulating a substring starting from the current position of the underlying string instance to the position of the first character satisfying the <paramref name="predicate" /> within the search scope when such character is found. When such character cannot be found, a <c>null</c> reference will be returned.</para>
        /// <para>NOTE that <see cref="StringReader.EmptyReader"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public StringReader ReadBeforeAsReader(Func<char, bool> predicate, char[] leftQuotes, char[] rightQuotes, bool readToEndIfKeycharNotFound = true)
        {
            return ReadToAsReader(predicate, leftQuotes, rightQuotes, readToEndIfKeycharNotFound ? ReadOptions.Default | ReadOptions.ReadToEnd : ReadOptions.Default);
        }

        /// <summary>
        /// Advances the reader and reads until a character satisfying <paramref name="predicate" /> (key char) is encountered outside quotes.
        /// The current reader stops at the position immediately after the position of the key char.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char.</param>
        /// <param name="leftQuotes">
        /// An array of Unicode characters as the left quotes.
        /// A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="rightQuotes" />.
        /// The reader will not stop when a key char is encountered inside a pair of quotes.</param>
        /// <param name="rightQuotes">
        /// An array of Unicode characters as the right quotes.
        /// A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="leftQuotes" />.
        /// The reader will not stop when a key char is encountered inside a pair of quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the key char will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if no character satisfying the <paramref name="predicate"/> is found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// If <paramref name="readToEndIfKeycharNotFound"/> is <c>true</c>, then a new reader will be returned encapsulating either a substring starting from the current position of the underlying string instance to the position of the first character satisfying the <paramref name="predicate" /> within the search scope when such character is found, or a substring starting from the current position of the underlying string instance to the end of the search scope if such character is not found.
        /// <para>If <paramref name="readToEndIfKeycharNotFound"/> is <c>false</c>, then a new reader will be returned encapsulating a substring starting from the current position of the underlying string instance to the position of the first character satisfying the <paramref name="predicate" /> within the search scope when such character is found. When such character cannot be found, a <c>null</c> reference will be returned.</para>
        /// <para>NOTE that whether the character is included in the returned new reader depends on <paramref name="discardKeychar"/>, and <see cref="StringReader.EmptyReader"/> will be returned if the length of the substring is 0.</para>
        /// </returns>
        public StringReader ReadAfterAsReader(Func<char, bool> predicate, char[] leftQuotes, char[] rightQuotes, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(predicate, leftQuotes, rightQuotes, options);
        }

        #endregion

        #region Predicate, Two-Layer Quotes #1

        /// <summary>
        /// Advances the reader and reads until a character satisfying the specified <paramref name="predicate" /> (key char) is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char. The reader will not stop when a key char is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(Func<char, bool> predicate, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote,
            ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, predicate, CurrentPosition, EndPosition, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote);
            return _innerReadToAsReader(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character satisfying the specified <paramref name="predicate" /> (key char) is encountered outside quotes.
        /// The current reader stops at the position of the key char and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char. The reader will not stop when a key char is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the key char is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(Func<char, bool> predicate, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                ReadOptions.Default | ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                ReadOptions.Default | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(predicate, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character satisfying the specified <paramref name="predicate" /> (key char) is encountered outside quotes.
        /// The current reader stops at the position immediately after the encountered key char and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char. The reader will not stop when a key char is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the key char will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the key char is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(Func<char, bool> predicate, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(predicate, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character satisfying the specified <paramref name="predicate" /> (key char) is encountered outside quotes.
        /// The current reader stops at the position of the key char.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char. The reader will not stop when a key char is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the key char is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(Func<char, bool> predicate, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ? ReadOptions.Default | ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadToAsReader(predicate, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character satisfying the specified <paramref name="predicate" /> (key char) is encountered outside quotes.
        /// The current reader stops at the position immediately after the position of the key char.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char. The reader will not stop when a key char is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the key char will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the key char is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(Func<char, bool> predicate, char primaryLeftQuote, char primaryRightQuote, char secondaryLeftQuote, char secondaryRightQuote, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(predicate, primaryLeftQuote, primaryRightQuote, secondaryLeftQuote, secondaryRightQuote, options);
        }

        #endregion

        #region Predicate, Two-Layer Quotes #2

        /// <summary>
        /// Advances the reader and reads until a character satisfying the specified <paramref name="predicate" /> (key char) is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char. The reader will not stop when a key char is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(Func<char, bool> predicate, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes,
            ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, predicate, CurrentPosition, EndPosition, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes);
            return _innerReadToAsReader(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character satisfying the specified <paramref name="predicate" /> (key char) is encountered outside quotes.
        /// The current reader stops at the position of the key char and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char. The reader will not stop when a key char is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the key char is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(Func<char, bool> predicate, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                ReadOptions.Default | ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                ReadOptions.Default | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(predicate, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character satisfying the specified <paramref name="predicate" /> (key char) is encountered outside quotes.
        /// The current reader stops at the position immediately after the encountered key char and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char. The reader will not stop when a key char is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the key char will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the key char is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(Func<char, bool> predicate, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(predicate, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character satisfying the specified <paramref name="predicate" /> (key char) is encountered outside quotes.
        /// The current reader stops at the position of the key char.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char. The reader will not stop when a key char is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the key char is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(Func<char, bool> predicate, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ? ReadOptions.Default | ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadToAsReader(predicate, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character satisfying the specified <paramref name="predicate" /> (key char) is encountered outside quotes.
        /// The current reader stops at the position immediately after the position of the key char.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char. The reader will not stop when a key char is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuote">Specifies the Unicode character as the primary left quote.</param>
        /// <param name="primaryRightQuote">Specifies the Unicode character as the primary right quote.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the key char will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the key char is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(Func<char, bool> predicate, char primaryLeftQuote, char primaryRightQuote, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(predicate, primaryLeftQuote, primaryRightQuote, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        #endregion

        #region Predicate, Two-Layer Quotes #3

        /// <summary>
        /// Advances the reader and reads until a character satisfying the specified <paramref name="predicate" /> (key char) is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char. The reader will not stop when a key char is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(Func<char, bool> predicate, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote,
            ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, predicate, CurrentPosition, EndPosition, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote);
            return _innerReadToAsReader(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character satisfying the specified <paramref name="predicate" /> (key char) is encountered outside quotes.
        /// The current reader stops at the position of the key char and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char. The reader will not stop when a key char is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the key char is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(Func<char, bool> predicate, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                ReadOptions.Default | ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                ReadOptions.Default | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(predicate, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character satisfying the specified <paramref name="predicate" /> (key char) is encountered outside quotes.
        /// The current reader stops at the position immediately after the encountered key char and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char. The reader will not stop when a key char is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the key char will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the key char is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(Func<char, bool> predicate, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(predicate, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character satisfying the specified <paramref name="predicate" /> (key char) is encountered outside quotes.
        /// The current reader stops at the position of the key char.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char. The reader will not stop when a key char is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the key char is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(Func<char, bool> predicate, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ? ReadOptions.Default | ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadToAsReader(predicate, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character satisfying the specified <paramref name="predicate" /> (key char) is encountered outside quotes.
        /// The current reader stops at the position immediately after the position of the key char.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char. The reader will not stop when a key char is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuote">Specifies the Unicode character as the secondary left quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuote">Specifies the Unicode character as the secondary right quote. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the key char will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the key char is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(Func<char, bool> predicate, char[] primaryLeftQuotes, char[] primaryRightQuotes, char secondaryLeftQuote, char secondaryRightQuote, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(predicate, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuote, secondaryRightQuote, options);
        }

        #endregion

        #region Predicate, Two-Layer Quotes #4

        /// <summary>
        /// Advances the reader and reads until a character satisfying the specified <paramref name="predicate" /> (key char) is encountered outside quotes.
        /// The reader's position after executing this method depends on the <paramref name="options" />.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char. The reader will not stop when a key char is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="options">Specifies the reading options.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadToAsReader(Func<char, bool> predicate, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes,
            ReadOptions options = ReadOptions.StopAfterKey | ReadOptions.DiscardKey | ReadOptions.ReadToEnd)
        {
            var idx = StringEx._innerIndexOfWithQuotes(UnderlyingString, predicate, CurrentPosition, EndPosition, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes);
            return _innerReadToAsReader(idx, 1, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character satisfying the specified <paramref name="predicate" /> (key char) is encountered outside quotes.
        /// The current reader stops at the position of the key char and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char. The reader will not stop when a key char is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the key char is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeWithTrimAsReader(Func<char, bool> predicate, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ?
                ReadOptions.Default | ReadOptions.TrimStart | ReadOptions.TrimEnd | ReadOptions.ReadToEnd :
                ReadOptions.Default | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            return ReadToAsReader(predicate, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character satisfying the specified <paramref name="predicate" /> (key char) is encountered outside quotes.
        /// The current reader stops at the position immediately after the encountered key char and the white-spaces at both ends of the returned new reader will be trimmed.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char. The reader will not stop when a key char is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the key char will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the key char is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterWithTrimAsReader(Func<char, bool> predicate, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey | ReadOptions.TrimStart | ReadOptions.TrimEnd;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(predicate, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character satisfying the specified <paramref name="predicate" /> (key char) is encountered outside quotes.
        /// The current reader stops at the position of the key char.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char. The reader will not stop when a key char is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the key char is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadBeforeAsReader(Func<char, bool> predicate, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool readToEndIfKeycharNotFound = true)
        {
            var options = readToEndIfKeycharNotFound ? ReadOptions.Default | ReadOptions.ReadToEnd : ReadOptions.Default;
            return ReadToAsReader(predicate, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        /// <summary>
        /// Advances the reader and reads until a character satisfying the specified <paramref name="predicate" /> (key char) is encountered outside quotes.
        /// The current reader stops at the position immediately after the position of the key char.
        /// </summary>
        /// <param name="predicate">A method to test each character of the reading scope and determines whether it is a key char. The reader will not stop when a key char is encountered inside a pair of primary/secondary quotes.</param>
        /// <param name="primaryLeftQuotes">Specifies an array of Unicode characters as the primary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="primaryRightQuotes" />.</param>
        /// <param name="primaryRightQuotes">Specifies an array of Unicode characters as the primary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="primaryLeftQuotes" />.</param>
        /// <param name="secondaryLeftQuotes">Specifies an array of Unicode characters as the secondary left quotes. A left quote of an index of this array corresponds to the right quote of that index of the array specified by <paramref name="secondaryRightQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="secondaryRightQuotes">Specifies an array of Unicode characters as the secondary right quotes. A right quote of an index of this array corresponds to the left quote of that index of the array specified by <paramref name="secondaryLeftQuotes" />. Secondary quotes are escaped when they are inside a pair of primary quotes.</param>
        /// <param name="discardKeychar"><c>true</c> if the key char will be discarded and not be included in the returned substring; otherwise, <c>false</c>.</param>
        /// <param name="readToEndIfKeycharNotFound"><c>true</c> if the reader should read to the end of the reading scope if the key char is not found; otherwise, <c>false</c>.</param>
        /// <returns>
        /// A new string reader that encapsulates a substring read from the underlying string instance of the current reader.
        /// </returns>
        public StringReader ReadAfterAsReader(Func<char, bool> predicate, char[] primaryLeftQuotes, char[] primaryRightQuotes, char[] secondaryLeftQuotes, char[] secondaryRightQuotes, bool discardKeychar = true, bool readToEndIfKeycharNotFound = true)
        {
            var options = ReadOptions.StopAfterKey;
            if (discardKeychar) options |= ReadOptions.DiscardKey;
            if (readToEndIfKeycharNotFound) options |= ReadOptions.ReadToEnd;
            return ReadToAsReader(predicate, primaryLeftQuotes, primaryRightQuotes, secondaryLeftQuotes, secondaryRightQuotes, options);
        }

        #endregion
    }
}
