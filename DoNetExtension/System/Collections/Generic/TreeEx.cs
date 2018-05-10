using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System_Extension_Library.System.Collections.Generic;
using System.IO;

namespace System.Collections.Generic
{
    class _inSearchEnumerator<T> : IEnumerator<IBinaryTree<T>>
    {
        IBinaryTree<T> _root;
        Stack<Pair<IBinaryTree<T>, bool>> _stack;
        IBinaryTree<T> _curr;
        bool _right;
        bool _begin;

        internal _inSearchEnumerator(IBinaryTree<T> root)
        {
            _root = root;
            _stack = new Stack<Pair<IBinaryTree<T>, bool>>();
        }

        public IBinaryTree<T> Current
        {
            get
            {
                if (!_begin)
                    throw new InvalidOperationException();
                return _curr;
            }
        }

        public void Dispose()
        {
            _stack.Clear();
            _root = null;
            _curr = null;
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            if (!_begin)
            {
                _begin = true;
                _curr = _root;
                
                while (_curr.LeftChild != null)
                {
                    _stack.Push(new Pair<IBinaryTree<T>, bool>(_curr, false));
                    _curr = _curr.LeftChild;
                }

                _right = (_curr.RightChild != null);
            }
            else if (_curr.RightChild == null && (_curr.LeftChild == null || _right))
            {
                if (_right)
                    _stack.Pop();

                if (_stack.Count == 0)
                    return false;

                var pre = _stack.Peek();
                var preNode = pre.First;
                var preIdx = pre.Second;
                while (preIdx)
                {
                    _stack.Pop();

                    if (_stack.Count == 0)
                        return false;
                    pre = _stack.Peek();
                    preNode = pre.First;
                    preIdx = pre.Second;
                }
                _curr = preNode;
                _right = true;
            }
            else if (_right)
            {
                _stack.Peek().Second = true;

                _curr = _curr.RightChild;

                while (_curr.LeftChild != null)
                {
                    _stack.Push(new Pair<IBinaryTree<T>, bool>(_curr, false));
                    _curr = _curr.LeftChild;
                }

                _right = (_curr.RightChild != null);
            }

            return true;
        }

        public void Reset()
        {
            _curr = null;
            _right = false;
            _begin = false;
            _stack.Clear();
        }
    }

    class _preSearchEnumerator<T> : IEnumerator<ITree<T>>
    {
        ITree<T> _root;
        Stack<Pair<ITree<T>, int>> _stack;
        ITree<T> _curr;
        bool _begin;
        internal _preSearchEnumerator(ITree<T> root)
        {
            _root = root;
            _stack = new Stack<Pair<ITree<T>, int>>();
        }

        public ITree<T> Current
        {
            get
            {
                if (!_begin)
                    throw new InvalidOperationException();
                return _curr;
            }
        }

        public void Dispose()
        {
            _stack.Clear();
            _root = null;
            _curr = null;
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            if (!_begin)
            {
                _curr = _root;
                _begin = true;
            }
            else if (_curr != null && _curr.Children != null && _curr.Children.Count > 0)
            {
                _stack.Push(new Pair<ITree<T>, int>(_curr, 1));
                _curr = _curr.Children[0];
            }
            else
            {
                if (_stack.Count == 0)
                    return false;

                var pre = _stack.Peek();
                var preNodes = pre.First.Children;
                var preIdx = pre.Second;
                while (preIdx == preNodes.Count)
                {
                    _stack.Pop();

                    if (_stack.Count == 0)
                        return false;

                    pre = _stack.Peek();
                    preNodes = pre.First.Children;
                    preIdx = pre.Second;
                }
                _curr = preNodes[pre.Second++];
            }
            return true;
        }

        public void Reset()
        {
            _curr = null;
            _begin = false;
            _stack.Clear();
        }
    }

    class _postSearchEnumerator<T> : IEnumerator<ITree<T>>
    {
        ITree<T> _root;
        Stack<Pair<ITree<T>, int>> _stack;
        ITree<T> _curr;
        bool _pop;
        bool _begin;

        internal _postSearchEnumerator(ITree<T> root)
        {
            _root = root;
            _stack = new Stack<Pair<ITree<T>, int>>();
        }

        public ITree<T> Current
        {
            get
            {
                if (!_begin)
                    throw new InvalidOperationException();
                return _curr;
            }
        }

        public void Dispose()
        {
            _stack.Clear();
            _root = null;
            _curr = null;
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            if (!_begin)
            {
                _curr = _root;
                _begin = true;

                while (_curr != null && _curr.Children != null && _curr.Children.Count > 0)
                {
                    _stack.Push(new Pair<ITree<T>, int>(_curr, 1));
                    _curr = _curr.Children[0];
                }
            }
            else if (_curr == null || _curr.Children == null || _pop || _curr.Children.Count == 0)
            {
                if (_stack.Count == 0)
                    return false;

                var pre = _stack.Peek();
                var preNode = pre.First;
                var preNodes = preNode.Children;
                var preIdx = pre.Second;
                if (preIdx == preNodes.Count)
                {
                    _pop = true;
                    _stack.Pop();
                    _curr = preNode;
                }
                else
                {
                    _pop = false;
                    _curr = preNodes[pre.Second++];
                    if (_curr != null)
                    {
                        var currNodes = _curr.Children;
                        while (currNodes != null && currNodes.Count > 0)
                        {
                            _stack.Push(new Pair<ITree<T>, int>(_curr, 1));
                            _curr = currNodes[0];
                            if (_curr == null) break;
                            currNodes = _curr.Children;
                        }
                    }
                }
            }
            return true;
        }

        public void Reset()
        {
            _begin = false;
            _curr = null;
            _pop = false;
            _stack.Clear();
        }
    }

    class _breadthSearchEnumerator<T> : IEnumerator<ITree<T>>
    {
        ITree<T> _root;
        Queue<IList<ITree<T>>> _queue;
        ITree<T> _curr;
        IList<ITree<T>> _currArr;
        int _currIdx;
        bool _begin;

        internal _breadthSearchEnumerator(ITree<T> root)
        {
            _root = root;
            _queue = new Queue<IList<ITree<T>>>();
        }

        public ITree<T> Current
        {
            get
            {
                if (!_begin)
                    throw new InvalidOperationException();
                return _curr;
            }
        }

        public void Dispose()
        {
            _queue.Clear();
            _currArr = null;
            _root = null;
            _curr = null;
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            if (!_begin)
            {
                _curr = _root;
                _begin = true;
                if (_curr != null)
                {
                    var currNodes = _curr.Children;
                    if (currNodes != null && currNodes.Count > 0)
                    {
                        _currArr = currNodes;
                        _currIdx = 0;
                    }
                }
            }
            else if (_currArr == null)
                return false;
            else if (_currIdx < _currArr.Count)
            {
                _curr = _currArr[_currIdx++];
                if (_curr != null)
                {
                    var currNodes = _curr.Children;
                    if (currNodes != null && currNodes.Count > 0)
                        _queue.Enqueue(currNodes);
                }
            }
            else if (_currIdx == _currArr.Count)
            {
                if (_queue.Count == 0) return false;
                else
                {
                    _currArr = _queue.Dequeue();
                    _curr = _currArr[0];
                    if (_curr != null)
                    {
                        var currNodes = _curr.Children;
                        if (currNodes != null && currNodes.Count > 0)
                            _queue.Enqueue(currNodes);
                    }
                    _currIdx = 1;
                }
            }

            return true;
        }

        public void Reset()
        {
            _begin = false;
            _curr = null;
            _currArr = null;
            _currIdx = 0;
            _queue.Clear();
        }
    }

    class _breadthSearchEnumeratorForBTree<T> : IEnumerator<IBinaryTree<T>>
    {
        IBinaryTree<T> _root;
        Queue<IBinaryTree<T>> _queue;
        IBinaryTree<T> _curr;
        bool _begin;

        internal _breadthSearchEnumeratorForBTree(IBinaryTree<T> root)
        {
            _root = root;
            _queue = new Queue<IBinaryTree<T>>();
        }

        public IBinaryTree<T> Current
        {
            get
            {
                if (!_begin)
                    throw new InvalidOperationException();
                return _curr;
            }
        }

        public void Dispose()
        {
            _queue.Clear();
            _root = null;
            _curr = null;
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            if (!_begin)
            {
                _curr = _root;
                _begin = true;
                _queue.Enqueue(_curr.LeftChild);
                _queue.Enqueue(_curr.RightChild);
            }
            else if (_queue.Count > 0)
            {
                _curr = _queue.Dequeue();
                if (_curr != null)
                {
                    _queue.Enqueue(_curr.LeftChild);
                    _queue.Enqueue(_curr.RightChild);
                }
            }
            else return false;
            return true;
        }

        public void Reset()
        {
            _begin = false;
            _curr = null;
            _queue.Clear();
        }
    }

    public static class TreeEx
    {
        #region General Operations

        public static int GetDepth<T>(this ITree<T> tree)
        {
            int i = 1;
            while (tree.Parent != null)
            {
                i++;
                tree = tree.Parent;
            }
            return i;
        }

        static string _toString<T>(IEnumerator<ITree<T>> ie)
        {
            StringBuilder sb = new StringBuilder();

            while (ie.MoveNext())
            {
                var node = ie.Current;
                if (node != null)
                {
                    var value = node.Value;
                    var s1 = (value == null) ? "(null)" : value.ToString();
                    sb.AppendLine(new string('-', node.GetDepth() - 1) + s1);
                }
            }
            return sb.ToString();
        }

        public static string ToString<T>(this Tree<T> tree, TreeSearchMode mode)
        {
            StringBuilder sb = new StringBuilder();
            IEnumerator<ITree<T>> ie = null;
            switch (mode)
            {
                case TreeSearchMode.BreadthFirst:
                    {
                        ie = tree.GetBreadthFirstEnumerator();
                        break;
                    }
                case TreeSearchMode.PostOrder:
                    {
                        ie = tree.GetPostOrderEnumerator();
                        break;
                    }
                case TreeSearchMode.PreOrder:
                    {
                        ie = tree.GetPreOrderEnumerator();
                        break;
                    }
                default:
                    {
                        throw new InvalidOperationException();
                    }
            }

            return _toString(ie);
        }

        public static string ToString<T>(this BinaryTree<T> tree, TreeSearchMode mode)
        {
            StringBuilder sb = new StringBuilder();
            IEnumerator<ITree<T>> ie = null;
            switch (mode)
            {
                case TreeSearchMode.BreadthFirst:
                    {
                        ie = tree.GetBreadthFirstEnumerator();
                        break;
                    }
                case TreeSearchMode.PostOrder:
                    {
                        ie = tree.GetPostOrderEnumerator();
                        break;
                    }
                case TreeSearchMode.PreOrder:
                    {
                        ie = tree.GetPreOrderEnumerator();
                        break;
                    }
                case TreeSearchMode.InOrder:
                    {
                        ie = tree.GetInOrderEnumerator();
                        break;
                    }
                default:
                    {
                        throw new InvalidOperationException();
                    }
            }

            return _toString(ie);
        }

        #endregion

        #region Stream Operations

        public static void WriteBinaryTree<T>(this Stream stream, IBinaryTree<T> tree, Action<Stream, T> writeValue)
        {
            var ie = tree.GetBreadthFirstEnumerator();
            while (ie.MoveNext())
            {
                var node = (IBinaryTree<T>)ie.Current;
                if (node == null) continue;

                byte tag = 0;
                var isNull = !typeof(T).IsValueType && node.Value == null;
                tag = tag.SetBit(0, isNull);
                tag = tag.SetBit(1, node.LeftChild == null);
                tag = tag.SetBit(2, node.RightChild == null);
                stream.WriteByte(tag);
                if (!isNull) writeValue(stream, node.Value);
            }
        }

        public static void WriteBinaryTree<T>(this BitStream stream, IBinaryTree<T> tree, Action<BitStream, T> writeValue)
        {
            var ie = tree.GetBreadthFirstEnumerator();
            while (ie.MoveNext())
            {
                var node = (IBinaryTree<T>)ie.Current;
                if (node == null) continue;

                var isNull = !typeof(T).IsValueType && node.Value == null;
                stream.WriteBit(isNull);
                stream.WriteBit(node.LeftChild == null);
                stream.WriteBit(node.RightChild == null);
                if (!isNull) writeValue(stream, node.Value);
            }
        }

        public static BinaryTree<T> ReadBinaryTree<T>(this Stream stream, Func<Stream, T> readValue)
        {
            var q = new Queue<BinaryTree<T>>();
            var root = new BinaryTree<T>();
            q.Enqueue(root);
            byte tag;
            while (q.Count > 0)
            {
                var t = q.Dequeue();
                tag = (byte)stream.ReadByte();
                bool isNull = tag.GetBit(0);
                bool leftNull = tag.GetBit(1);
                bool rightNull = tag.GetBit(2);

                if (isNull)
                    t.Value = default(T);
                else
                    t.Value = readValue(stream);

                if (leftNull)
                    t.LeftChild = null;
                else
                {
                    t.LeftChild = new BinaryTree<T>();
                    q.Enqueue(t.LeftChild);
                }

                if (rightNull)
                    t.RightChild = null;
                else
                {
                    t.RightChild = new BinaryTree<T>();
                    q.Enqueue(t.RightChild);
                }
            }
            return root;
        }

        public static BinaryTree<T> ReadBinaryTree<T>(this BitStream stream, Func<Stream, T> readValue)
        {
            var q = new Queue<BinaryTree<T>>();
            var root = new BinaryTree<T>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var t = q.Dequeue();
                bool isNull = stream.ReadBit();
                bool leftNull = stream.ReadBit();
                bool rightNull = stream.ReadBit();

                if (isNull)
                    t.Value = default(T);
                else
                    t.Value = readValue(stream);

                if (leftNull)
                    t.LeftChild = null;
                else
                {
                    t.LeftChild = new BinaryTree<T>();
                    q.Enqueue(t.LeftChild);
                }

                if (rightNull)
                    t.RightChild = null;
                else
                {
                    t.RightChild = new BinaryTree<T>();
                    q.Enqueue(t.RightChild);
                }
            }
            return root;
        }

        public static void WriteTree<T>(this Stream stream, ITree<T> tree, Action<Stream, T> writeValue)
        {
            var ie = tree.GetBreadthFirstEnumerator();
            while (ie.MoveNext())
            {
                var node = ie.Current;
                if (node == null) stream.WriteByte(1);
                else
                {
                    byte tag = 0;
                    var isValueNull = !typeof(T).IsValueType && node.Value == null;
                    tag = tag.SetBit(1, isValueNull);
                    stream.WriteByte(tag);
                    if (node.Children == null)
                        stream.WriteInt32(0);
                    else
                        stream.WriteInt32(node.Children.Count);
                    if (!isValueNull) writeValue(stream, node.Value);
                }
            }
        }

        public static void WriteTree<T>(this BitStream stream, ITree<T> tree, Action<BitStream, T> writeValue)
        {
            var ie = tree.GetBreadthFirstEnumerator();
            while (ie.MoveNext())
            {
                var node = ie.Current;
                if (node == null) stream.WriteBit(true);
                else
                {
                    stream.WriteBit(false);
                    var isValueNull = !typeof(T).IsValueType && node.Value == null;
                    stream.WriteBit(isValueNull);
                    if (node.Children == null)
                        stream.WriteDeltaCode(0);
                    else
                        stream.WriteDeltaCode(node.Children.Count);
                    if (!isValueNull) writeValue(stream, node.Value);
                }
            }
        }

        public static Tree<T> ReadTree<T>(this Stream stream, Func<Stream, T> readValue)
        {
            var q = new Queue<Pair<Tree<T>, int>>();
            var root = new Tree<T>();
            q.Enqueue(root, 0);
            byte tag;
            while (q.Count > 0)
            {
                var t = q.Dequeue();
                var node = t.First;

                tag = (byte)stream.ReadByte();
                bool isNull = tag.GetBit(0);
                bool isValueNull = tag.GetBit(1);

                if (isNull)
                {
                    if (node.Parent == null)
                        return null;
                    else
                        node.Parent.Children[t.Second] = null;
                }
                else
                {
                    var len = stream.ReadInt32();
                    for (int i = 0; i < len; i++)
                        q.Enqueue(node.AddChild(), i);

                    if (isValueNull)
                        node.Value = default(T);
                    else
                        node.Value = readValue(stream);
                }
            }
            return root;
        }

        public static Tree<T> ReadTree<T>(this BitStream stream, Func<BitStream, T> readValue)
        {
            var q = new Queue<Pair<Tree<T>, int>>();
            var root = new Tree<T>();
            q.Enqueue(root, 0);
            while (q.Count > 0)
            {
                var t = q.Dequeue();
                var node = t.First.Parent;
                bool isNull = stream.ReadBit();
                bool isValueNull = stream.ReadBit();

                if (isNull)
                {
                    if (node.Parent == null)
                        return null;
                    else
                        node.Parent.Children[t.Second] = null;
                }
                else
                {
                    var len = stream.ReadGammaCode();
                    for (int i = 0; i < len; i++)
                        q.Enqueue(node.AddChild(), i);

                    if (isValueNull)
                        node.Value = default(T);
                    else
                        node.Value = readValue(stream);
                }
            }
            return root;
        }

        public static void WriteDictionaryTree<TKey, TValue>(this Stream stream, DTree<TKey, TValue> tree, 
            Action<Stream, KeyValuePair<TKey, TValue>> writeValue)
        {
            var ie = tree.GetBreadthFirstEnumerator();
            while (ie.MoveNext())
            {
                var node = ie.Current;
                if (node == null) stream.WriteByte(1);
                else
                {
                    byte tag = 0;
                    var isValueNull = (node.Value.Key == null && node.Value.Value == null);
                    tag = tag.SetBit(1, isValueNull);
                    stream.WriteByte(tag);
                    if (node.Children == null)
                        stream.WriteInt32(0);
                    else
                        stream.WriteInt32(node.Children.Count);
                    if (!isValueNull) writeValue(stream, node.Value);
                }
            }
        }

        public static void WriteDictionaryTree<TKey, TValue>(this BitStream stream, DTree<TKey, TValue> tree,
            Action<Stream, KeyValuePair<TKey, TValue>> writeValue)
        {
            var ie = tree.GetBreadthFirstEnumerator();
            while (ie.MoveNext())
            {
                var node = ie.Current;
                if (node == null) stream.WriteBit(true);
                else
                {
                    stream.WriteBit(false);
                    var isValueNull = (node.Value.Key == null && node.Value.Value == null);
                    stream.WriteBit(isValueNull);
                    if (node.Children == null)
                        stream.WriteDeltaCode(0);
                    else
                        stream.WriteDeltaCode(node.Children.Count);
                    if (!isValueNull) writeValue(stream, node.Value);
                }
            }
        }

        public static DTree<TKey, TValue> ReadDictionaryTree<TKey, TValue>(this Stream stream, 
            Func<Stream, KeyValuePair<TKey, TValue>> readValue, Action<DTree<TKey, TValue>> nodeCreated = null)
        {
            var q = new Queue<DTree<TKey, TValue>>();
            DTree<TKey, TValue> root;

            var tag = (byte)stream.ReadByte();
            bool isNull = tag.GetBit(0);
            bool isValueNull = tag.GetBit(1);
            if (isNull)
                return null;
            else
            {
                var len = stream.ReadInt32();
                if (!isValueNull)
                {
                    var kp = readValue(stream);
                    root = new DTree<TKey, TValue>(kp.Key, kp.Value);
                }
                else root = new DTree<TKey, TValue>();

                if (nodeCreated != null)
                    nodeCreated(root);

                for (int i = 0; i < len; i++)
                    q.Enqueue(root);
            }

            while (q.Count > 0)
            {
                var parent = q.Dequeue();
                tag = (byte)stream.ReadByte();
                isNull = tag.GetBit(0);
                isValueNull = tag.GetBit(1);

                if (isNull)
                    throw new InvalidOperationException();
                else
                {
                    var len = stream.ReadInt32();
                    DTree<TKey, TValue> newNode;
                    if (!isValueNull)
                    {
                        var kp = readValue(stream);
                        newNode = parent.AddChild(kp.Key, kp.Value);
                        if (newNode == null)
                            throw new InvalidDataException();
                        if (nodeCreated != null && newNode != null)
                            nodeCreated(newNode);
                    }
                    else throw new InvalidOperationException();

                    for (int i = 0; i < len; i++)
                        q.Enqueue(newNode);
                }
            }
            return root;
        }

        public static DTree<TKey, TValue> ReadDictionaryTree<TKey, TValue>(this BitStream stream,
            Func<Stream, KeyValuePair<TKey, TValue>> readValue, Action<DTree<TKey, TValue>> nodeCreated = null)
        {
            var q = new Queue<DTree<TKey, TValue>>();
            DTree<TKey, TValue> root;

            bool isNull = stream.ReadBit();
            bool isValueNull = stream.ReadBit();
            if (isNull)
                return null;
            else
            {
                var len = stream.ReadDeltaCode();
                if (!isValueNull)
                {
                    var kp = readValue(stream);
                    root = new DTree<TKey, TValue>(kp.Key, kp.Value);
                }
                else root = new DTree<TKey, TValue>();

                if (nodeCreated != null)
                    nodeCreated(root);

                for (int i = 0; i < len; i++)
                    q.Enqueue(root);
            }

            while (q.Count > 0)
            {
                var parent = q.Dequeue();
                isNull = stream.ReadBit();
                isValueNull = stream.ReadBit();

                if (isNull)
                    throw new InvalidOperationException();
                else
                {
                    var len = stream.ReadDeltaCode();
                    DTree<TKey, TValue> newNode;
                    if (!isValueNull)
                    {
                        var kp = readValue(stream);
                        newNode = parent.AddChild(kp.Key, kp.Value);
                        if (newNode == null)
                            throw new InvalidDataException();
                        if (nodeCreated != null)
                            nodeCreated(newNode);
                    }
                    else throw new InvalidOperationException();

                    for (int i = 0; i < len; i++)
                        q.Enqueue(newNode);
                }
            }
            return root;
        }

        

        #endregion

        #region Quick Creation

        public static Tree<T>[] ToTreeNodes<T>(this T[] inputs, T nullNodeIndicator)
        {
            var output = new Tree<T>[inputs.Length];

            for (int i = 0; i < inputs.Length; i++)
            {
                var value = inputs[i];
                if (value.Equals(nullNodeIndicator))
                    output[i] = null;
                else
                {
                    output[i] = new Tree<T>();
                    output[i].Value = inputs[i];
                }
            }

            return output;
        }

        public static Tree<T>[] ToTrees<T>(this T[][] inputs, T nullChildIndicator)
        {
            var queue = new Queue<Tree<T>[]>(inputs.Length);
            var roots = inputs[0].ToTreeNodes(nullChildIndicator);
            queue.Enqueue(roots);
            var i = 1;

            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();

                for (int j = 0; j < curr.Length; j++)
                {
                    if (curr[j] == null) continue;

                    if (i < inputs.Length)
                    {
                        Tree<T>[] nodes;
                        curr[j].Children = nodes = inputs[i++].ToTreeNodes(nullChildIndicator);
                        queue.Enqueue(nodes);
                    }
                }
            }
            return roots;
        }

        public static Tree<T> ToTree<T>(this T[][] inputs, T nullChildIndicator)
        {
            return inputs.ToTrees<T>(nullChildIndicator)[0];
        }

        public static BinaryTree<T> ToBinaryTree<T>(this T[] inputs, T nullChildIndicator)
        {
            var queue = new Queue<BinaryTree<T>>(inputs.Length);
            var root = new BinaryTree<T>();
            queue.Enqueue(root);
            int idx = 0;

            var len = inputs.Length;
            int count = 1;

            while (queue.Count > 0)
            {
                var p = queue.Dequeue();
                if (p == null)
                {
                    idx++;
                    continue;
                }

                p.Value = inputs[idx];
                

                var diff = len - count;
                if (diff >= 2)
                {
                    count += 2;

                    var idx2 = idx + idx + 1;
                    if (inputs[idx2].Equals(nullChildIndicator))
                        p.LeftChild = null;
                    else
                        p.LeftChild = new BinaryTree<T>();

                    idx2++;
                    if (inputs[idx2].Equals(nullChildIndicator))
                        p.RightChild = null;
                    else
                        p.RightChild = new BinaryTree<T>();

                    queue.Enqueue((BinaryTree<T>)p.LeftChild);
                    queue.Enqueue((BinaryTree<T>)p.RightChild);
                }
                else if (diff == 1)
                {
                    count++;
                    if (inputs[idx + idx + 1].Equals(nullChildIndicator))
                        p.LeftChild = null;
                    else
                        p.LeftChild = new BinaryTree<T>();
                    queue.Enqueue((BinaryTree<T>)p.LeftChild);
                }

                idx++;
            }

            return root;
        }

        #endregion

        #region Path Operations

        public static DTree<string, TValue> AddByPath<TValue>(this DTree<string, TValue> tree, string[] path, TValue value, Action<DTree<string, TValue>> nodeAdded = null)
        {
            var node = tree.TryAdd(path, value, nodeAdded);
            if (node == null)
                throw new InvalidOperationException(GenericResources.ERR_Common_PathAlreadyExist);
            else return node;
        }

        public static DTree<StringSplitResult, TValue> AddByPath<TValue>(this DTree<StringSplitResult, TValue> tree,
            StringSplitResult[] path, TValue value, Action<DTree<StringSplitResult, TValue>> nodeAdded = null)
        {
            var node = tree.TryAdd(path, value, nodeAdded);
            if (node == null)
                throw new InvalidOperationException(GenericResources.ERR_Common_PathAlreadyExist);
            else return node;
        }

        public static TKey[] GetPath<TKey, TValue>(this IDTree<TKey, TValue> tree)
        {
            List<TKey> _list = new List<TKey>();
            _list.Add(tree.Key);

            while (tree.Parent != null)
            {
                tree = (IDTree<TKey, TValue>)tree.Parent;
                _list.Add(tree.Key);
            }

            var len = _list.Count;
            var output = new TKey[len];
            for (int i = len - 1, j = 0; i >= 0; i--, j++)
                output[j] = _list[i];

            return output;
        }

        #endregion

        #region Search

        public static IEnumerator<ITree<T>> GetBreadthFirstEnumerator<T>(this ITree<T> tree)
        {
            return new _breadthSearchEnumerator<T>(tree);
        }

        public static IEnumerator<ITree<T>> GetBreadthFirstEnumerator<T>(this IBinaryTree<T> tree)
        {
            return new _breadthSearchEnumeratorForBTree<T>(tree);
        }

        public static IEnumerator<ITree<T>> GetPreOrderEnumerator<T>(this ITree<T> tree)
        {
            return new _preSearchEnumerator<T>(tree);
        }

        public static IEnumerator<ITree<T>> GetPostOrderEnumerator<T>(this ITree<T> tree)
        {
            return new _postSearchEnumerator<T>(tree);
        }

        public static IEnumerator<IBinaryTree<T>> GetInOrderEnumerator<T>(this IBinaryTree<T> tree)
        {
            return new _inSearchEnumerator<T>(tree);
        }

        #endregion
    }
}
