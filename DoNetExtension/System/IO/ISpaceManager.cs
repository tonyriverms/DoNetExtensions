using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.IO
{
    /// <summary>
    /// Represents methods supporting record management.
    /// </summary>
    public interface ISpaceManager
    {
        /// <summary>
        /// Trys to get an available section capable of data of specified length. 
        /// </summary>
        /// <param name="length">The length of the section you want to apply.</param>
        /// <returns>The position of the section; -1 if no available section.</returns>
        long ApplySection(int length);

        /// <summary>
        /// Frees an occupied section.
        /// </summary>
        /// <param name="position">The position of the section to free.</param>
        /// <param name="length">The length of the section to free.</param>
        void FreeSection(long position, int length);
        
        /// <summary>
        /// Frees occupied sections of the same length.
        /// </summary>
        /// <param name="positions">The positions of the sections to free.</param>
        /// <param name="length">The length of the section to free.</param>
        void FreeSections(IList<long> positions, int length);
    }

    public static class StreamExtensionForISpaceManager
    {
        public static void WriteSpaceManager(this Stream stream, StreamStaticManager manager, WritingMode mode)
        {
            manager.SaveToStream(stream, mode);
        }

        public static StreamStaticManager ReadSpaceManager(this Stream stream, StreamStaticManager manager)
        {
            return new StreamStaticManager(stream);
        }
    }

    public class StreamStaticManager : ISpaceManager
    {
        List<long> _availables;
        int _length;

        internal void SaveToStream(Stream stream, WritingMode mode)
        {
            stream.WriteInt32(_length);
            stream.WriteList(_availables, mode);
        }

        internal StreamStaticManager(Stream stream)
        {
            _length = stream.ReadInt32();
            _availables = new List<long>();
            stream.ReadList(_availables);
        }

        public StreamStaticManager(int sectionLength)
        {
            _length = sectionLength;
            _availables = new List<long>();
        }

        #region ISpaceManager Members

        long ISpaceManager.ApplySection(int length)
        {
            if (_availables.Count > 0)
                return _availables[_availables.Count - 1];
            else return -1;
        }

        void ISpaceManager.FreeSection(long position, int length)
        {
            _availables.Add(position);
        }

        void ISpaceManager.FreeSections(IList<long> positions, int length)
        {
            _availables.AddRange(positions);
        }

        #endregion
    }


}
