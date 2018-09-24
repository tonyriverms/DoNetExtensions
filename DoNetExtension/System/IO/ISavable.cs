using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.IO
{
    /// <summary>
    /// Exposes interfaces to preserve the current object state in a <see cref="System.IO.Stream"/>, and to load data from a <see cref="System.IO.Stream"/>.
    /// </summary>
    public interface IBinarySavable
    {
        /// <summary>
        /// Writes the current object state to a <see cref="System.IO.Stream" />.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="args">Provides additional arguments.</param>
        void WriteToStream(Stream stream, params object[] args);

        /// <summary>
        /// Loads object state from a <see cref="System.IO.Stream" />.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="args">Provides additional arguments.</param>
        void LoadFromStream(Stream stream, params object[] args);
    }

    /// <summary>
    /// Exposes an interface to save the current object in a <see cref="System.IO.TextWriter"/> instance, and to load data from a <see cref="System.IO.TextReader"/> instance.
    /// </summary>
    public interface ITextSavable
    {
        /// <summary>
        /// Writes the current object state to a <see cref="System.IO.TextWriter" />.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="arg">Provides the external argument.</param>
        void WriteToText(TextWriter writer, object arg);

        /// <summary>
        /// Loads object state from a <see cref="System.IO.TextReader" />.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="arg">Provides the external argument.</param>
        void LoadFromText(TextReader reader, object arg);
    }

    public interface Progressable
    {
        double GlobalProgress { get; }
        double LocalProgress { get; }
    }
}
