using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DoNetExtension.System.Collections.Generic;

namespace System.Collections.Generic
{
    class _dictTreeEnumerator<TKey, TValue> : IEnumerator<DTree<TKey, TValue>>
    {
        IEnumerator<ITree<KeyValuePair<TKey, TValue>>> _ie;

        internal _dictTreeEnumerator(IEnumerator<ITree<KeyValuePair<TKey, TValue>>> ie)
        {
            _ie = ie;
        }

        public DTree<TKey, TValue> Current
        {
            get { return (DTree<TKey, TValue>)_ie.Current; }
        }

        public void Dispose()
        {
            _ie.Dispose();
        }

        object IEnumerator.Current
        {
            get { return _ie.Current; }
        }

        public bool MoveNext()
        {
            return _ie.MoveNext();
        }

        public void Reset()
        {
            _ie.Reset();
        }
    }

    public interface IDTree<TKey, TValue> :
        ITree<KeyValuePair<TKey, TValue>>,
        IDictionary<IList<TKey>, TValue>,
        IEnumerable<DTree<TKey, TValue>>,
        IEnumerable<IList<TKey>>
    {
        TKey Key { get; }
    }

    public class DTree<TKey, TValue> : IDTree<TKey, TValue>
    {
        public DTree() { }

        public DTree(TKey key, TValue value)
        {
            _key = key;
            _value = value;
        }

        #region Basics

        TKey _key;
        TValue _value;
        KeyValuePair<TKey, TValue> ITree<KeyValuePair<TKey, TValue>>.Value
        {
            get
            {
                return new KeyValuePair<TKey, TValue>(_key, _value);
            }
        }
        /// <summary>
        /// Gets or sets the value of this tree node.
        /// </summary>
        public TValue Value { get { return _value; } set { _value = value; } }
        /// <summary>
        /// Gets the key associated with this tree node.
        /// </summary>
        public TKey Key { get { return _key; } }

        DTree<TKey, TValue> _parent;
        ITree<KeyValuePair<TKey, TValue>> ITree<KeyValuePair<TKey, TValue>>.Parent { get { return _parent; } }

        /// <summary>
        /// Gets or sets the parent of this tree node. If this tree node is root, a null reference will be returned.
        /// </summary>
        public DTree<TKey, TValue> Parent
        {
            get { return _parent; }
            set
            {
                if (_parent != value)
                {
                    if (_parent == null || _parent.RemoveChild(this))
                    {
                        if (value != null) value._children.Add(_key, value);
                        _parent = value;
                    }
                    else throw new InvalidOperationException();
                }
            }
        }

        IDictionary<TKey, DTree<TKey, TValue>> _children;
        IList<ITree<KeyValuePair<TKey, TValue>>> ITree<KeyValuePair<TKey, TValue>>.Children
        {
            get
            {
                if (_children == null) return null;
                else return _children.Values.ToArray();
            }
        }

        /// <summary>
        /// Adds a new child node with the specified key/value pair to this tree node.
        /// </summary>
        /// <param name="key">The key of the child node to add.</param>
        /// <param name="value">The value of the child node to add.</param>
        /// <returns>
        /// The added new child node.
        /// </returns>
        public DTree<TKey, TValue> AddChild(TKey key, TValue value)
        {
            if (_children == null)
                _children = new HybridDictionary<TKey, DTree<TKey, TValue>>();

            if (_children.ContainsKey(key))
                return null;
            else
            {
                var nt = new DTree<TKey, TValue>(key, value);
                nt.Parent = this;
                _children.Add(key, nt);
                return nt;
            }
        }

        /// <summary>
        /// Adds a new child node with the specified key/value pair to this tree node.
        /// </summary>
        /// <param name="pair">The key/value pair of the child node to add.</param>
        /// <returns>
        /// The added new child node.
        /// </returns>
        public DTree<TKey, TValue> AddChild(KeyValuePair<TKey, TValue> pair)
        {
            return AddChild(pair.Key, pair.Value);
        }

        /// <summary>
        /// Adds a child node to this tree node.
        /// </summary>
        /// <param name="node">The child node to add.</param>
        public void AddChild(DTree<TKey, TValue> node)
        {
            if (_children == null)
                _children = new HybridDictionary<TKey, DTree<TKey, TValue>>();

            node.Parent = this;
            _children.Add(node.Key, node);
        }

        /// <summary>
        /// Gets the child node associated with the specified key.
        /// </summary>
        /// <param name="childKey">The key of the child node.</param>
        /// <returns>The child node associated with the specified key.</returns>
        public DTree<TKey, TValue> this[TKey childKey]
        {
            get
            {
                return _children[childKey];
            }
        }

        /// <summary>
        /// Gets the child node associated with the specified key.
        /// </summary>
        /// <param name="childKey">The key of the child node.</param>
        /// <param name="child">Returns the child node associated with the specified key, if the key is found; otherwise, <c>null</c>.</param>
        /// <returns></returns>
        public bool TryGetChild(TKey childKey, out DTree<TKey, TValue> child)
        {
            if (_children.IsNullOrEmpty())
            {
                child = null;
                return false;
            }
            else return _children.TryGetValue(childKey, out child);
        }

        /// <summary>
        /// Removes the child node associated with the specified key.
        /// </summary>
        /// <param name="childKey">The key of the child remove.</param>
        /// <returns><c>true</c> if the child node associated with the specified key is successfully removed; otherwise, <c>false</c>.</returns>
        public bool RemoveChild(TKey key)
        {
            if (_children != null)
            {
                DTree<TKey, TValue> t;
                if (_children.TryGetValue(key, out t))
                {
                    t._parent = null;
                    return _children.Remove(key);
                }
                else return false;
            }
            else return false;
        }

        /// <summary>
        /// Removes the specified child node from this tree node.
        /// </summary>
        /// <param name="node">The child node to remove.</param>
        /// <returns>
        /// <c>true</c> if the child node is successfully removed; otherwise, <c>false</c>.
        /// </returns>
        public bool RemoveChild(DTree<TKey, TValue> node)
        {
            return RemoveChild(node._key);
        }

        /// <summary>
        /// Randomly returns a leaf descendant of this tree node.
        /// </summary>
        /// <returns>A random leaf descendant of this tree node.</returns>
        public DTree<TKey, TValue> Next()
        {
            var tree = this;
            var rnd = new Random();
            while (true)
            {
                var len = tree._children.Count;
                if (len > 1)
                    tree = tree._children.Values.ElementAt(rnd.Next(0, len));
                else if (len == 1)
                    tree = tree._children.Values.First();
                else break;
            }

            return tree;
        }

        /// <summary>
        /// Clears all descendants from this tree node.
        /// </summary>
        public void Clear()
        {
            foreach (var directChild in _children.Values)
                directChild._parent = null;
            _children.Clear();
        }

        /// <summary>
        /// Gets a value indicating whether this tree node has children.
        /// </summary>
        public bool HasChildren { get { return _children != null; } }

        /// <summary>
        /// Copies all path-value pairs in this tree to an existing one-dimensional <see cref="System.Array"/>, starting at the specified array index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="System.Array"/> that is the destination of the path-value pairs copied from this tree.</param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins. </param>
        public void CopyTo(KeyValuePair<IList<TKey>, TValue>[] array, int arrayIndex)
        {
            var enumerator = ((IEnumerable<KeyValuePair<IList<TKey>, TValue>>)this).GetEnumerator();
            for (int i = arrayIndex, j = array.Length; i < j; i++)
            {
                var next = enumerator.MoveNext();
                if (next) array[i] = enumerator.Current;
            }
        }

        /// <summary>
        /// Gets the number of direct children in this tree node.
        /// </summary>
        public int Count
        {
            get { return _children.Count; }
        }

        bool ICollection<KeyValuePair<IList<TKey>, TValue>>.IsReadOnly
        {
            get { return false; }
        }

        #endregion

        #region Path

        /// <summary>
        /// Determines whether the specified path exists in this tree.
        /// </summary>
        /// <param name="path">A path consists of several keys.</param>
        /// <returns><c>true</c> if the specified path exists in the current tree; otherwise, <c>false</c>.</returns>
        public bool ContainsPath(IList<TKey> path)
        {
            TKey key;
            DTree<TKey, TValue> stree = this;
            for (int i = 0; i < path.Count; i++)
            {
                key = path[i];
                if (!stree.TryGetChild(key, out stree)) return false;
            }

            return stree != null;
        }

        bool IDictionary<IList<TKey>, TValue>.ContainsKey(IList<TKey> key)
        {
            return ContainsPath(key);
        }

        /// <summary>
        /// Determines whether the specified path-value pair exists in this tree.
        /// </summary>
        /// <param name="path">A path-value pair.</param>
        /// <returns><c>true</c> if the specified path-value pair exists in the current tree; otherwise, <c>false</c>.</returns>
        public bool Contains(KeyValuePair<IList<TKey>, TValue> pair)
        {
            DTree<TKey, TValue> node;
            if (_innerGetNodeByPath(pair.Key, pair.Key.Count - 1, out node))
                return node._value.Equals(pair.Value);
            else return false;
        }

        bool _innerGetNodeByPath(IList<TKey> path, int endIdx, out DTree<TKey, TValue> node)
        {
            TKey key;
            DTree<TKey, TValue> stree = this;
            for (int i = 0; i < endIdx; i++)
            {
                key = path[i];
                if (!stree.TryGetChild(key, out stree))
                {
                    node = null;
                    return false;
                }
            }

            key = path[endIdx];
            if (!stree.TryGetChild(key, out stree))
            {
                node = null;
                return false;
            }
            else
            {
                node = stree;
                return true;
            }
        }

        /// <summary>
        /// Removes a descendant node associated with the specified path.
        /// </summary>
        /// <param name="path">A path consists of several keys.</param>
        /// <returns><c>true</c> if the specified path exists in this tree and the descendant node associated with that path is successfully removed.</returns>
        public bool Remove(IList<TKey> path)
        {
            var keylen = path.Count - 2;
            if (keylen == -2) return false;
            else if (keylen == -1)
                return !_children.IsNullOrEmpty() && _children.Remove(path[0]);
            else
            {
                DTree<TKey, TValue> parent;
                if (_innerGetNodeByPath(path, keylen, out parent))
                    return !parent._children.IsNullOrEmpty() && parent._children.Remove(path[keylen + 1]);
                else return false;
            }
        }

        /// <summary>
        /// Removes a descendant node associated with the specified path-value pair. 
        /// </summary>
        /// <param name="pair">The path-value pair to remove.</param>
        /// <returns><c>true</c> if the specified path exists in this tree and the descendant node associated with that path is successfully removed.</returns>
        public bool Remove(KeyValuePair<IList<TKey>, TValue> pair)
        {
            return Remove(pair.Key);
        }

        /// <summary>
        /// Gets the descendant node of this tree associated with the specified path. The path should already exist in this tree.
        /// </summary>
        /// <param name="path">A path consists of several keys.</param>
        /// <param name="node">Returns the descendant node associated with the specified path, if the path exists in this tree; otherwise, <c>null</c>.</param>
        /// <returns><c>true</c> if the specified path exists in this tree and the descendant node associated with that path is returned.</returns>
        public bool TryGetNode(IList<TKey> path, out DTree<TKey, TValue> node)
        {
            return _innerGetNodeByPath(path, path.Count - 1, out node);
        }

        /// <summary>
        /// Gets the value associated with the specified path in this tree. The path should already exist in this tree.
        /// </summary>
        /// <param name="path">A path consists of several keys.</param>
        /// <param name="value">Returns the value asociated with the specified path, if the path exists in this tree; otherwise, <c>null</c>.</param>
        /// <returns><c>true</c> if the specified path exists in this tree and the value associated with that path is returned.</returns>
        public bool TryGetValue(IList<TKey> path, out TValue value)
        {
            DTree<TKey, TValue> otree;
            var rlt = TryGetNode(path, out otree);
            if (rlt)
            {
                value = otree.Value;
                return true;
            }
            else
            {
                value = default(TValue);
                return false;
            }
        }

        /// <summary>
        /// Sets the value associated with the specified path in this tree. The path should already exist in this tree.
        /// </summary>
        /// <param name="path">A path consists of several keys.</param>
        /// <param name="value">The value to be associated with the specified path.</param>
        /// <returns><c>true</c> if the specified path exists in this tree and the value is successfully associated with that path.</returns>
        public bool TrySetValue(IList<TKey> path, TValue value)
        {
            DTree<TKey, TValue> otree;
            var rlt = TryGetNode(path, out otree);
            if (rlt)
            {
                otree.Value = value;
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Gets or sets the value associated with the specified path in this tree.
        /// An exception will be thrown if the path does not exist in this tree.
        /// </summary>
        public TValue this[IList<TKey> path]
        {
            get
            {
                TValue value;
                if (TryGetValue(path, out value)) return value;
                else throw new KeyNotFoundException();
            }
            set { if (!TrySetValue(path, value)) throw new KeyNotFoundException(); }
        }

        /// <summary>
        /// Adds a value together with the path it is to associate to this tree.
        /// </summary>
        /// <param name="path">A path consists of several keys.</param>
        /// <param name="value">The value associated with the specified path.</param>
        /// <param name="nodeCreated">A function called everytime a new node is created.</param>
        /// <returns>A node that stores the value associated with the specified path, if the path and value are both successfully added; 
        /// <c>null</c> if a value is already associated with the path. 
        /// This node is also the last node along the path.</returns>
        public DTree<TKey, TValue> TryAdd(IList<TKey> path, TValue value, Action<DTree<TKey, TValue>> nodeCreated = null)
        {
            try
            {
                TKey key;
                DTree<TKey, TValue> stree = this;
                DTree<TKey, TValue> ttree;
                var len = path.Count - 1;
                for (int i = 0; i < len; i++)
                {
                    key = path[i];
                    if (!stree.TryGetChild(key, out ttree))
                    {
                        stree = stree.AddChild(key, default(TValue));
                        if (nodeCreated != null) nodeCreated(stree);
                    }
                    else stree = ttree;
                }

                key = path[len];
                if (!stree.TryGetChild(key, out ttree))
                    return stree.AddChild(key, value);
                else
                    return null;
            }
            catch { return null; }
        }

        /// <summary>
        /// Adds a value together with the path it is to associate to this tree.
        /// An exception will be thrown if the path already exists in this tree.
        /// </summary>
        /// <param name="path">A path consists of several keys.</param>
        /// <param name="value">The value to be associated with the specified path.</param>
        /// <param name="nodeCreated">A function called everytime a new node is created.</param>
        /// <returns>
        /// The node that stores the value associated with the specified path, 
        /// if the path and value are successfully added; 
        /// otherwise a <see cref="System.ArgumentException"/> will be thrown.
        /// This node is also the last node along the path.
        /// </returns>
        public DTree<TKey, TValue> Add(IList<TKey> path, TValue value, Action<DTree<TKey, TValue>> nodeCreated)
        {
            var node = TryAdd(path, value, nodeCreated);
            if (node == null)
                throw new ArgumentException(GenericResources.ERR_Common_PathAlreadyExist);
            else return node;
        }

        /// <summary>
        /// Adds a value together with its associated path to this tree. 
        /// An exception will be thrown if the path already exists in this tree.
        /// </summary>
        /// <param name="pair">The path-value pair to add.</param>
        public void Add(KeyValuePair<IList<TKey>, TValue> pair)
        {
            TryAdd(pair.Key, pair.Value);
        }

        /// <summary>
        /// Adds a value together with the path it is to associate to this tree.
        /// An exception will be thrown if the path already exists in this tree.
        /// </summary>
        /// <param name="path">A path consists of several keys.</param>
        /// <param name="value">The value to be associated with the specified path.</param>
        /// <returns>
        /// The node that stores the value associated with the specified path, 
        /// if the path and value are successfully added; 
        /// otherwise a <see cref="System.ArgumentException"/> will be thrown.
        /// This node is also the last node along the path.
        /// </returns>
        public void Add(IList<TKey> key, TValue value)
        {
            Add(key, value);
        }

        #endregion

        #region Enumerators

        /// <summary>
        /// Gets a collection containing all paths in this tree.
        /// </summary>
        public IEnumerable<TKey[]> Paths
        {
            get { return ((IEnumerable<TKey[]>)this); }
        }

        /// <summary>
        /// Gets a collection containing all values in this tree.
        /// </summary>
        public IEnumerable<TValue> Values
        {
            get { return ((IEnumerable<TValue>)this); }
        }

        ICollection<IList<TKey>> IDictionary<IList<TKey>, TValue>.Keys { get { return Paths.ToArray(); } }
        ICollection<TValue> IDictionary<IList<TKey>, TValue>.Values { get { return ((IEnumerable<TValue>)this).ToArray(); } }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetBreadthFirstEnumerator();
        }

        IEnumerator<DTree<TKey, TValue>> IEnumerable<DTree<TKey, TValue>>.GetEnumerator()
        {
            return new _dictTreeEnumerator<TKey, TValue>(this.GetBreadthFirstEnumerator());
        }

        IEnumerator<KeyValuePair<IList<TKey>, TValue>> IEnumerable<KeyValuePair<IList<TKey>, TValue>>.GetEnumerator()
        {
            foreach (DTree<TKey, TValue> node in (IEnumerable<DTree<TKey, TValue>>)this)
                yield return new KeyValuePair<IList<TKey>, TValue>(node.GetPath(), node._value);
        }

        /// <summary>
        /// Returns an enumerator that iterates through all keys in this tree.
        /// </summary>
        /// <returns>An enumerator that iterates through all keys in this tree.</returns>
        public IEnumerator<TKey> GetKeyEnumerator()
        {
            foreach (DTree<TKey, TValue> node in (IEnumerable<DTree<TKey, TValue>>)this)
                yield return node._key;
        }

        /// <summary>
        /// Returns an enumerator that iterates through all paths in this tree.
        /// </summary>
        /// <returns>An enumerator that iterates through all paths in this tree.</returns>
        public IEnumerator<IList<TKey>> GetPathEnumerator()
        {
            foreach (DTree<TKey, TValue> node in (IEnumerable<DTree<TKey, TValue>>)this)
                yield return node.GetPath();
        }

        IEnumerator<IList<TKey>> IEnumerable<IList<TKey>>.GetEnumerator()
        {
            return GetPathEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through all values in this tree.
        /// </summary>
        /// <returns>An enumerator that iterates through all values in this tree.</returns>
        public IEnumerator<TValue> GetValueEnumerator()
        {
            foreach (DTree<TKey, TValue> node in (IEnumerable<DTree<TKey, TValue>>)this)
                yield return node._value;
        }

        #endregion
    }
}
