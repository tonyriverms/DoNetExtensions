using DoNetExtension.System.Collections.Generic;

namespace System.Collections.Generic
{
    /// <summary>
    /// A heap data structure for retrieving smallest element in a collection.
    /// </summary>
    /// <typeparam name="T">Type of elements in the heap.</typeparam>
    public class MinHeap<T>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MinHeap{T}"/> class.
        /// </summary>
        /// <param name="capacity">The initial capacity of the heap.</param>
        /// <param name="comparer">Provides an <see cref="IComparer{T}"/> to compare values in the heap.</param>
        public MinHeap(int capacity = DefaultCapacity, IComparer<T> comparer = null)
        {
            _heap = new T[capacity > 0 ? capacity : DefaultCapacity];
            Count = 0;
            _comparer = comparer ?? Comparer<T>.Default;
        }

        #endregion

        /// <summary>
        /// Gets the number of items in the priority queue.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Gets the first or topmost object in the priority queue, which is the
        /// object with the minimum value.
        /// </summary>
        public T Top => _heap[0];

        /// <summary>
        /// Pushes multiple object to the heap.
        /// </summary>
        /// <param name="obj">The objects to push.</param>
        public void Push(params T[] obj)
        {
            for (var i = 0; i < obj.Length; ++i)
                Push(obj[i]);
        }

        /// <summary>
        /// Pushes an object to the heap.
        /// </summary>
        /// <param name="obj">The object to push.</param>
        public void Push(T obj)
        {
            // increases the size of the array if necessary.
            if (Count == _heap.Length)
            {
                var temp = new T[Count * 2];
                for (var i = 0; i < Count; ++i)
                {
                    temp[i] = _heap[i];
                }
                _heap = temp;
            }

            var index = Count; // inserts as a leaf
            while (index != 0)
            {
                var parentIndex = _parent(index);
                if (_comparer.Compare(obj, _heap[parentIndex]) < 0)
                {
                    _heap[index] = _heap[parentIndex]; // no need to do actual swap, only needs to move parent
                    index = parentIndex;
                }
                else break; // we can insert here
            }

            _heap[index] = obj;
            ++Count;
        }

        #region Classic Algorithm

        //public T Pop2()
        //{
        //    if (Count == 0) throw new InvalidOperationException(GenericResources.ERR_Heap_EmptyHeap);

        //    var root = _heap[0];
        //    --Count;

        //    if (Count != 0)
        //    {
        //        var parent = 0;
        //        var leftChild = HeapLeftChild(parent);

        //        while (leftChild < Count)
        //        {
        //            var rightChild = leftChild + 1;
        //            var bestChild = rightChild < Count && _comparer.Compare(_heap[rightChild], _heap[leftChild]) < 0 ? rightChild : leftChild;


        //            if (_comparer.Compare(_heap[Count], _heap[bestChild]) > 0)
        //            {

        //                _heap[parent] = _heap[bestChild];
        //                parent = bestChild;
        //                leftChild = HeapLeftChild(parent);
        //            }
        //            else break;
        //        }

        //        _heap[parent] = _heap[Count];
        //        _heap[Count] = default;
        //    }

        //    return root;
        //}


        //private T[] PopAll2()
        //{
        //    var count = Count;
        //    var arr = new T[count];
        //    for (var i = 0; i < count; ++i)
        //        arr[i] = Pop();
        //    return arr;
        //}


        #endregion

        /// <summary>
        /// Removes the root from the heap, which is the minimum or maximum element depending on the comparer.
        /// </summary>
        public T Pop()
        {
            if (Count == 0) throw new InvalidOperationException(GenericResources.ERR_Heap_EmptyHeap);

            var root = _heap[0];
            --Count;

            if (Count != 0)
            {
                var parent = 0;
                var leftChild = _leftChild(parent);

                while (leftChild < Count)
                {
                    var rightChild = leftChild + 1;
                    var bestChild = rightChild < Count && _comparer.Compare(_heap[rightChild], _heap[leftChild]) < 0 ? rightChild : leftChild;



                    _heap[parent] = _heap[bestChild];
                    parent = bestChild;
                    leftChild = _leftChild(parent);
                }

                _heap[parent] = _heap[Count];
                _heap[Count] = default;

                int index = parent;
                var value = _heap[parent];

                while (index > 0)
                {
                    int parentIndex = _parent(index);
                    if (_comparer.Compare(value, _heap[parentIndex]) < 0)
                    {
                        // value is a better match than the parent node so exchange
                        // places to preserve the "heap" property.
                        var pivot = _heap[index];
                        _heap[index] = _heap[parentIndex];
                        _heap[parentIndex] = pivot;
                        index = parentIndex;
                    }
                    else
                    {
                        // Heap is balanced
                        break;
                    }
                }
            }

            return root;
        }

        /// <summary>
        /// Pops all elements in the heap.
        /// </summary>
        /// <returns>A sorted array of all elements in the heap.</returns>
        public T[] PopAll()
        {
            var count = Count;
            var arr = new T[count];
            for (var i = 0; i < count; ++i)
                arr[i] = Pop();
            return arr;
        }

        private static int _parent(int i) // calculate the parent node index given a child node's index
        {
            return (i - 1) / 2;
        }

        private static int _leftChild(int i) // calculate the left child's index given the parent's index
        {
            return (i * 2) + 1;
        }

        private T[] _heap;
        private readonly IComparer<T> _comparer;

        /// <summary>
        /// The default capacity of a <see cref="MinHeap{T}"/> class.
        /// </summary>
        public const int DefaultCapacity = 7;
    }
}
