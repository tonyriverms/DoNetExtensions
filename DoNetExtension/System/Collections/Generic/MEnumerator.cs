using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Collections.Generic
{
    /// <summary>
    /// Supports a simple sequential iteration over multiple generic collections enumerated by their own enumerators. 
    /// This class can be viewed as an enumerator of enumerators and the initial "M" stands for "multiple", "merged".
    /// </summary>
    /// <typeparam name="T">The type of the elements this enumerator enumerates.</typeparam>
    public class MEnumerator<T> : IEnumerator<T>
    {
        IEnumerator<T>[] _enumerators;
        int _currIdx;
        IEnumerator<T> _currentEnumerator;

        /// <summary>
        /// Initializes a new instance of System.Collections.MEnumerator{T} class.
        /// </summary>
        /// <param name="enumerators">An array of enumerators that enumerate the same type of elements.
        /// <para>Initially, this class sets the first enumerator in this array as the current enumerator. 
        /// You may advance the current enumerator by MoveNext method.
        /// If the current enumerator moves past the last element of the collection it enumerats, 
        /// then the next one in this array will become the current enumerator.
        /// </para></param>
        public MEnumerator(params IEnumerator<T>[] enumerators)
        {
            _enumerators = enumerators;
            _currIdx = 0;
            _currentEnumerator = _enumerators[0];
        }

        /// <summary>
        /// Gets the current element.
        /// </summary>
        public T Current
        {
            get { return _currentEnumerator.Current; }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            foreach (var enumerator in _enumerators)
                enumerator.Dispose();
        }

        object IEnumerator.Current
        {
            get { return _currentEnumerator.Current; }
        }

        /// <summary>
        /// Advances the enumerator to the next element of the current enumerator.
        /// <para>When this class is initialized, an array of enumerators is passed into the contructor. 
        /// Initially the first enumerator is the current enumerator and this method advances the current enumerator. 
        /// When the current enumerator moves past the last element of the collection it enumerates, 
        /// the next enumerator in the enumerator array will become the current enumerator. 
        /// If the current enumerator is the last one in the enumerator array, 
        /// and there is no more elements to enumerate, false will be returned by this method.</para>
        /// </summary>
        /// <returns>true if the enumerator was successfully advanced to the next element; 
        /// false if the enumerator has passed the end of the last enumerator.</returns>
        public bool MoveNext()
        {
            bool next;
            while (!(next = _currentEnumerator.MoveNext()))
            {
                _currIdx++;
                if (_currIdx == _enumerators.Length)
                    return false;
                else
                    _currentEnumerator = _enumerators[_currIdx];
            }

            return true;
        }

        /// <summary>
        /// Sets the the current enumerator to the first enumerator and 
        /// sets the first enumerator to its initial position, which is before its first element.
        /// </summary>
        public void Reset()
        {
            _currIdx = 0;
            foreach (var enumerator in _enumerators)
                enumerator.Reset();
        }
    }
}
