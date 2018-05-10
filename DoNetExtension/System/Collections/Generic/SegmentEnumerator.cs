using System.Linq;

namespace System.Collections.Generic
{
    /// <summary>
    /// Supports a simple iteration over all/part of elements in an array/list.
    /// </summary>
    /// <typeparam name="T">The type of the elements of the array this enumerator enumerates.</typeparam>
    public class SegmentEnumerator<T> : IEnumerator<T>
    {
        IList<T> m_array;
        int m_start;
        int m_curridx;
        int m_end;

        /// <summary>
        /// Gets a value indicating how many elements this enumerator enumerates.
        /// </summary>
        public int Count
        {
            get { return m_end - m_start; }
        }

        /// <summary>
        /// Initializes a new instance of System.Collections.Generic.ListEnumerator{T} object.
        /// </summary>
        /// <param name="list">The array/list this enumerator enumerates.</param>
        /// <param name="startIndex">Specifies the position in the array/list where the enumerator starts to enumerate. 
        /// The enumerator will enumerate a number of elements since this position.</param>
        /// <param name="count">The total number of elements to enumerate.</param>
        public SegmentEnumerator(IList<T> list, int startIndex, int count)
        {
            m_array = list;
            m_start = startIndex;
            m_end = startIndex + count;
            m_curridx = startIndex - 1;
        }

        /// <summary>
        /// Initializes a new instance of System.Collections.Generic.ListEnumerator{T} object.
        /// </summary>
        /// <param name="list">Specifies the position in the array/list where the enumerator starts to enumerate. 
        /// The enumerator will enumerate all elements since this position.</param>
        /// <param name="startIndex">The index of the first element to enumerate.</param>
        public SegmentEnumerator(IList<T> list, int startIndex)
        {
            m_array = list;
            m_start = startIndex;
            m_end = list.Count;
            m_curridx = startIndex - 1;
        }

        /// <summary>
        /// Initializes a new instance of System.Collections.Generic.ListEnumerator{T} object.
        /// </summary>
        /// <param name="list">The array/list this enumerator enumerates.</param>
        public SegmentEnumerator(IList<T> list)
        {
            m_array = list;
            m_start = 0;
            m_end = list.Count;
            m_curridx = -1;
        }

        #region IEnumerator<T> Members

        T IEnumerator<T>.Current
        {
            get
            {
                {
                    return m_array[m_curridx];
                }
            }
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            m_array = null;
        }

        #endregion

        #region IEnumerator Members

        object IEnumerator.Current
        {
            get { return (object)m_array[m_curridx]; }
        }

        bool IEnumerator.MoveNext()
        {
            m_curridx++;
            return (m_curridx != m_end);
        }

        void IEnumerator.Reset()
        {
            m_curridx = m_start - 1;
        }

        #endregion
    }
}