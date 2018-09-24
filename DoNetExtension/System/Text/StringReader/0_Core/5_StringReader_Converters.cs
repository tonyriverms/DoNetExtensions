namespace System.Text
{
    public partial class StringReader
    {
        /// <summary>
        /// Performs an implicit conversion from <see cref="System.StringReader"/> to <see cref="System.String"/>.
        /// </summary>
        /// <param name="reader">The <see cref="System.StringReader"/> to convert.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator string(StringReader reader)
        {
            return reader.ToString();
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="System.StringReader"/>.
        /// </summary>
        /// <param name="str">The <see cref="System.String"/> to convert.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator StringReader(string str)
        {
            return new StringReader(str);
        }
    }
}