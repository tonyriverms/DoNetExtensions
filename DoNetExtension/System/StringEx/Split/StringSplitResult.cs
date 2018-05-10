using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// Stores the result of a string split.
    /// </summary>
    public class StringSplitResult
    {
        /// <summary>
        /// Gets the substring split from the original string.
        /// </summary>
        /// <value>
        /// The substring split from the original string.
        /// </value>
        public string SplitText { internal set; get; }

        /// <summary>
        /// Gets index of the separator. The value of this property can be -1, indicating the current split is at the end of the original string.
        /// </summary>
        /// <value>
        /// The index of the separator.
        /// </value>
        public int SeparatorIndex { internal set; get; }

        /// <summary>
        /// Gets the separator. The value of this property can be a <see cref="System.Char"/> or a <see cref="System.String"/>.
        /// </summary>
        /// <value>
        /// The separator.
        /// </value>
        public dynamic Separator { internal set; get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringSplitResult"/> class.
        /// </summary>
        /// <param name="splitText">The substring split from the original string.</param>
        /// <param name="separator">The separator that splits the substring from the original string.</param>
        /// <param name="separatorIndex">The index of the separator.</param>
        public StringSplitResult(string splitText, dynamic separator, int separatorIndex)
        {
            SplitText = splitText;
            Separator = separator;
            SeparatorIndex = separatorIndex;
        }

        /// <summary>
        /// Converts this object to its equivalent string representation.
        /// </summary>
        /// <returns>A new string instance which is a concatenation of property <see cref="SplitText"/> and <see cref="Separator"/> if the value of <see cref="Separator"/> is not '\0'; 
        /// otherwise, the value of property <see cref="SplitText"/>.</returns>
        public override string ToString()
        {
            if (Separator is string)
                return SplitText + Separator;
            else if (Separator is char)
            {
                if (Separator == '\0')
                    return SplitText;
                else
                    return SplitText + Separator;
            }
            else throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the hash code for this object. NOTE that this method does not count <see cref="SeparatorIndex"/> property, and so two <see cref="System.StringSplitResult" /> objects determined "not equal" by <see cref="Equals"/> method may generate the same hash code.
        /// </summary>
        /// <returns>
        /// The hash code for this object.
        /// </returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to the current <see cref="System.StringSplitResult" /> object.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this <see cref="System.StringSplitResult" /> object.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to the current <see cref="System.StringSplitResult" /> object, in which case the argument <paramref name="obj"/> is also a <see cref="System.StringSplitResult" /> object and its properties <see cref="SplitText"/>, <paramref name="Separator" /> and <paramref name="SeparatorIndex" /> are equal to the corresponding properties of this object; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var anotherSplit = obj as StringSplitResult;
            if (obj == null) return false;
            else return SeparatorIndex == anotherSplit.SeparatorIndex && SplitText == anotherSplit.SplitText && Separator == anotherSplit.Separator;
        }
    }

    /// <summary>
    /// Stores the result of a string split. The substring split from the original string is represented by a <see cref="System.StringReader"/>.
    /// </summary>
    public class StringReaderSplitResult
    {
        /// <summary>
        /// Gets the <see cref="System.StringReader"/> object representing the substring split from the original string.
        /// </summary>
        /// <value>
        /// A <see cref="System.StringReader"/> object representing the substring split from the original string.
        /// </value>
        public StringReader SplitReader { internal set; get; }

        /// <summary>
        /// Gets index of the separator. The value of this property can be -1, indicating the current split is at the end of the original string.
        /// </summary>
        /// <value>
        /// The index of the separator.
        /// </value>
        public int SeparatorIndex { internal set; get; }

        /// <summary>
        /// Gets the separator. The value of this property can be a <see cref="System.Char"/> or a <see cref="System.String"/>.
        /// </summary>
        /// <value>
        /// The separator.
        /// </value>
        public dynamic Separator { internal set; get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringReaderSplitResult"/> class.
        /// </summary>
        /// <param name="substringReader">A <see cref="System.StringReader"/> object representing the substring split from the original string.</param>
        /// <param name="separator">The separator that splits the substring from the original string.</param>
        /// <param name="separatorIndex">The index of the separator.</param>
        public StringReaderSplitResult(StringReader substringReader, dynamic separator, int separatorIndex)
        {
            SplitReader = substringReader;
            Separator = separator;
            SeparatorIndex = separatorIndex;
        }

        /// <summary>
        /// Converts this object to its equivalent string representation.
        /// </summary>
        /// <returns>A new string instance which is a concatenation of property <see cref="Text"/> and <see cref="Separator"/> if the value of <see cref="Separator"/> is not '\0'; 
        /// otherwise, the value of property <see cref="Text"/>.</returns>
        public override string ToString()
        {
            if (Separator is string)
                return SplitReader + Separator;
            else if (Separator is char)
            {
                if (Separator == '\0')
                    return SplitReader;
                else
                    return SplitReader + Separator;
            }
            else throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the hash code for this object. NOTE that this method does not count <see cref="SeparatorIndex"/> property, and so two <see cref="System.StringReaderSplitResult" /> objects determined "not equal" by <see cref="Equals"/> method may generate the same hash code.
        /// </summary>
        /// <returns>
        /// The hash code for this object.
        /// </returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to the current <see cref="System.StringReaderSplitResult" /> object.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this <see cref="System.StringReaderSplitResult" /> object.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="System.Object" /> is equal to the current <see cref="System.StringReaderSplitResult" /> object, in which case the argument <paramref name="obj"/> is also a <see cref="System.StringReaderSplitResult" /> object, and its properties <paramref name="Separator" /> and <paramref name="SeparatorIndex" /> are equal to the corresponding properties of this object, and the reading scope of its property <see cref="SplitReader"/> equals the reading scope of this object's <see cref="SplitReader"/> property; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var anotherSplit = obj as StringReaderSplitResult;
            if (obj == null) return false;
            else return SeparatorIndex == anotherSplit.SeparatorIndex && SplitReader.ReadingScopeEquals(anotherSplit.SplitReader) && Separator == anotherSplit.Separator;
        }
    }
}
