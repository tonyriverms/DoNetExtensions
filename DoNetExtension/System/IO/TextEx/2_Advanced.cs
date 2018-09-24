using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.IO
{
    public static partial class TextEx
    {
        /// <summary>
        /// Copies non-empty lines in the current <see cref="StreamReader"/> to another <see cref="TextWriter"/>. You may associate multiple other <see cref="TextReader"/> objects with this non-empty line copy process.
        /// </summary>
        /// <param name="mainReader">The current <see cref="StreamReader"/>.</param>
        /// <param name="mainOutput">The main output where non-empty lines will be copied.</param>
        /// <param name="associatedReaders">The associated <see cref="TextReader"/> objects. If an non-empty line of the current <see cref="StreamReader"/> is copied to the <paramref name="mainOutput"/>, then the corresponding lines in each of these <see cref="associatedReaders"/> will be copied to the corresponding <see cref="TextReader"/> object of <paramref name="associatedOutputs"/>.</param>
        /// <param name="associatedOutputs">The associated <see cref="TextWriter"/> objects.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Occurs when one or more of <paramref name="mainReader"/>, <paramref name="mainOutput"/>, <paramref name="associatedReaders"/> and <paramref name="associatedReaders"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="System.ArgumentException">Occurs when the length of <paramref name="associatedReaders"/> is not equal to the length of <paramref name="associatedOutputs"/>.</exception>
        public static void CopyNonEmptyLines(this StreamReader mainReader, TextWriter mainOutput, TextReader[] associatedReaders, TextWriter[] associatedOutputs)
        {
            if (mainReader == null) throw new ArgumentNullException("mainReader");
            if (mainOutput == null) throw new ArgumentNullException("mainOutput");

            var readerLen = ExceptionHelper.EqualArrayLengthRequiredOrBothNull(associatedReaders, associatedOutputs, "associatedReaders", "associatedOutputs");
            while (!mainReader.EndOfStream)
            {
                var line = mainReader.ReadLine();
                if (!line.IsNullOrEmptyOrBlank())
                {
                    mainOutput.WriteLine(line);
                    for (int i = 0; i < readerLen; ++i)
                        associatedOutputs[i].WriteLine(associatedReaders[i].ReadLine());
                }
            }
        }

        /// <summary>
        /// Copies part of lines of each of these <paramref name="TextReader"/> objects to corresponding <see cref="TextWriter"/> objects.
        /// </summary>
        /// <param name="readers">The current <see cref="TextReader"/> objects.</param>
        /// <param name="outputs">The corresponding output <see cref="TextWriter"/> objects.</param>
        /// <param name="offset">Provides the current-postion based index of the line where the copy starts. If this argument is set 0, the copy starts from the current position of each of the <see cref="TextReader"/> objects.</param>
        /// <param name="lineCount">The number of lines to copy.</param>
        /// <exception cref="System.ArgumentNullException">Occurs when either <paramref name="readers"/> or <paramref name="outputs"/> is <c>null</c>.</exception>
        /// <exception cref="System.ArgumentException">Occurs when the length of <paramref name="readers"/> is not equal to the length of <paramref name="outputs"/>.</exception>
        public static void CopySublines(this TextReader[] readers, TextWriter[] outputs, int offset, int lineCount)
        {
            if (lineCount <= 0) return;
            if (readers == null) throw new ArgumentNullException("reader");
            if (outputs == null) throw new ArgumentNullException("output");
            var readerLen = ExceptionHelper.EqualArrayLengthRequired(readers, outputs, "readers", "outputs");

            for (int i = 0; i < readerLen; ++i)
            {
                var reader = readers[i];
                reader.Advance(offset);
                var output = outputs[i];
                var c = lineCount;
                while (c != 0)
                {
                    output.WriteLine(reader.ReadLine());
                    --c;
                }
            }
        }

        /// <summary>
        /// Copies part of lines of the current <see cref="TextReader"/> object to a <see cref="TextWriter"/> object.
        /// </summary>
        /// <param name="readers">The current <see cref="TextReader"/> object.</param>
        /// <param name="output">The output <see cref="TextWriter"/> object.</param>
        /// <param name="offset">Provides the current-postion based index of the line where the copy starts. If this argument is set 0, the copy starts from the current position of the <see cref="TextReader"/> object.</param>
        /// <param name="lineCount">The number of lines to copy.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Occurs when either <paramref name="reader"/> or <paramref name="output"/> is <c>null</c>.
        /// </exception>
        public static void CopySublines(this TextReader reader, TextWriter output, int offset, int lineCount)
        {
            if (lineCount <= 0) return;
            if (reader == null) throw new ArgumentNullException("reader");
            if (output == null) throw new ArgumentNullException("output");

            reader.Advance(offset);
            while (lineCount != 0)
            {
                output.WriteLine(reader.ReadLine());
                --lineCount;
            }
        }

        /// <summary>
        /// Roughly and randomly sample lines from an array of <see cref="System.IO.StreamReader"/> objects into an array of <see cref="System.IO.TextWriter"/> objects of the same array size. NOTE that this is not an accurate sampling method. For example, when <paramref name="sampleRate"/> is assigned 0.3, about but not exactly 30% of the lines will be sampled.
        /// </summary>
        /// <param name="readers">The <see cref="System.IO.StreamReader"/> objects to sample from.</param>
        /// <param name="outputs">The output <see cref="System.IO.TextWriter"/> objects.</param>
        /// <param name="sampleRate">The sample rate. For example, if this value is 0.3, then about 30% of the lines will be sampled from each reader and written into the corresponding writer.</param>
        /// <param name="rnd">The <see cref="System.Random"/> object used to perform random sampling.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Occurs when <see cref="readers"/> or <see cref="outputs"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="System.ArgumentException">Occurs when the sizes of <paramref name="readers"/> and <see cref="outputs"/> do not equal.</exception>
        public static void LineSample(this StreamReader[] readers, TextWriter[] outputs, double sampleRate, Random rnd = null)
        {
            if (readers == null) throw new ArgumentNullException("readers");
            if (outputs == null) throw new ArgumentNullException("outputs");
            var readerLen = ExceptionHelper.EqualArrayLengthRequired(readers, outputs, "readers", "outputs");
            if (rnd == null) rnd = new Random();

            while (true)
            {
                for (int i = 0; i < readerLen; ++i)
                {
                    var reader = readers[i];
                    if (reader.EndOfStream) return;
                }

                var r = rnd.NextDouble();

                if (r < sampleRate)
                {
                    for (int i = 0; i < readerLen; ++i)
                    {
                        var reader = readers[i];
                        var line = reader.ReadLine();
                        var writer = outputs[i];
                        writer.WriteLine(line);
                    }
                }
                else
                {
                    for (int i = 0; i < readerLen; ++i)
                    {
                        var reader = readers[i];
                        reader.ReadLine();
                    }
                }
            }
        }

        /// <summary>
        /// Roughly and randomly splits lines from each of an array of <see cref="System.IO.StreamReader"/> objects into corresponding two <see cref="System.IO.TextWriter"/> objects. NOTE that this is not an accurate spliting method. For example, when <paramref name="splitRate"/> is assigned 0.3, about but not exactly 30% of the lines will be copied to the first <see cref="System.IO.TextWriter"/> object.
        /// </summary>
        /// <param name="readers">The current <see cref="System.IO.StreamReader"/> objects.</param>
        /// <param name="outputs">An array of <see cref="System.IO.TextWriter"/> pairs. Lines of each of the <see cref="System.IO.StreamReader"/> object will be randomly split and written into the corresponding pair in this array.</param>
        /// <param name="splitRate">The split rate. For example, if this value is 0.3, then about 30% of the lines of each reader will be written into the first writer of the corresponding pair in <paramref name="outputs"/>, and the remaining about 70% of the lines will be written into the second writer.</param>
        /// <param name="rnd">The <see cref="System.Random"/> object used to perform random split.</param>
        /// <exception cref="System.ArgumentException">Occurs when the sizes of <paramref name="readers"/> and <see cref="outputs"/> do not equal.</exception>
        public static void RandomSplit(this StreamReader[] readers, Pair<TextWriter>[] outputs, double splitRate, Random rnd = null)
        {
            if (readers == null) throw new ArgumentNullException("readers");
            if (outputs == null) throw new ArgumentNullException("outputs");
            var readerLen = ExceptionHelper.EqualArrayLengthRequired(readers, outputs, "readers", "outputs");
            if (rnd == null) rnd = new Random();

            while (true)
            {
                for (int i = 0; i < readerLen; ++i)
                {
                    var reader = readers[i];
                    if (reader.EndOfStream) return;
                }

                var r = rnd.NextDouble();

                if (r < splitRate)
                {
                    for (int i = 0; i < readerLen; ++i)
                    {
                        var reader = readers[i];
                        var line = reader.ReadLine();
                        outputs[i].Item1.WriteLine(line);
                    }
                }
                else
                {
                    for (int i = 0; i < readerLen; ++i)
                    {
                        var reader = readers[i];
                        var line = reader.ReadLine();
                        outputs[i].Item2.WriteLine(line);
                    }
                }
            }
        }
    }
}
