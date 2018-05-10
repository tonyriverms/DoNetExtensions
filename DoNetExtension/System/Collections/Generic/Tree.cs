using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System_Extension_Library.System.Collections.Generic;

namespace System.Collections.Generic
{
    /// <summary>
    /// Represents a general tree (or a tree node, which can be viewed as a tree).
    /// </summary>
    /// <typeparam name="T">The type of values stored in the tree.</typeparam>
    public interface ITree<T>
    {
        /// <summary>
        /// Gets the children of this tree node.
        /// In any implementation, a null reference should be returned if this tree node has no children.
        /// </summary>
        IList<ITree<T>> Children { get; }
        /// <summary>
        /// Gets the parent of this tree node.
        /// In any implementation, a null reference should be returned if this tree node is the root.
        /// </summary>
        ITree<T> Parent { get; }
        /// <summary>
        /// Gets the value of this tree node.
        /// </summary>
        T Value { get; }
    }

    /// <summary>
    /// Represents a general tree (or a tree node, which can be viewed as a tree).
    /// </summary>
    /// <typeparam name="T">The type of values stored in this tree node.</typeparam>
    public class Tree<T> : ITree<T>
    {
        /// <summary>
        /// Gets or sets the value of this tree node.
        /// </summary>
        public T Value { get; set; }

        Tree<T> _parent;
        ITree<T> ITree<T>.Parent { get { return _parent; } }
        /// <summary>
        /// Gets or sets the parent of this tree node. If this tree node is root, a null reference will be returned.
        /// </summary>
        public Tree<T> Parent
        {
            get { return _parent; }
            set
            {
                if (_parent != value)
                {
                    if (_parent == null || (_parent._children != null && _parent._children.Remove(this)))
                    {
                        if (value != null) value._children.Add(this);
                        _parent = value;
                    }
                }
            }
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.ITree{T}"/> is identical (same structure and same data, but not necessarily same type) to the current <see cref="System.Tree{T}"/>.
        /// </summary>
        /// <param name="tree">The <see cref="System.ITree{T}"/> to compare.</param>
        /// <returns>true if the two trees are identical, otherwise false.</returns>
        public bool Equals(ITree<T> tree)
        {
            if (this == tree) return true;
            else
            {
                var ie1 = this.GetBreadthFirstEnumerator();
                var ie2 = tree.GetBreadthFirstEnumerator();
                while (ie1.MoveNext())
                {
                    if (ie2.MoveNext())
                    {
                        var curr1 = ie1.Current;
                        var curr2 = ie2.Current;
                        var isNull1 = (curr1 == null);
                        var isNull2 = (curr2 == null);

                        if (isNull1 != isNull2) return false;
                        else if (!isNull1)
                        {
                            var v1 = curr1.Value;
                            var v2 = curr2.Value;
                            isNull1 = (v1 == null);
                            isNull2 = (v2 == null);
                            if (isNull1 != isNull2 || (!isNull1 && !v1.Equals(v2)))
                                return false;
                        }
                    }
                    else return false;
                }

                if (ie2.MoveNext())
                    return false;

                return true;
            }
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="System.Tree{T}"/>.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>true if the objects are equal, otherwise false.</returns>
        public override bool Equals(object obj)
        {
            var tree = obj as ITree<T>;
            if (tree == null) return false;
            else return this.Equals(tree);
        }

        IList<Tree<T>> _children;
        IList<ITree<T>> ITree<T>.Children { get { return _children.Cast<ITree<T>>().ToArray(); } }

        /// <summary>
        /// Gets or sets the child nodes of this tree node.
        /// </summary>
        public IList<Tree<T>> Children
        {
            get { return _children; }
            set
            {
                if (_children == null) _children = new List<Tree<T>>();
                else _children.Clear();

                if (!value.IsNullOrEmpty())
                {
                    _children.AddRange(value, 0);
                    foreach (var child in value)
                    {
                        if (child != null)
                            child._parent = this;
                    }
                }
            }
        }

        /// <summary>
        /// Changes the children list to the specified type.
        /// </summary>
        /// <typeparam name="TList">A type that implements <see cref="IList{T}" /> interface and has a public default constructor.</typeparam>
        public void SetChildrenListType<TList>() where TList : IList<Tree<T>>, new()
        {
            if (_children == null) _children = new TList();
            else
            {
                if (typeof(TList).Equals(_children.GetType())) return;
                var nlist = new TList();
                nlist.AddRange(_children, 0);
                _children = nlist;
            }
        }

        /// <summary>
        /// Removes the specified child node from this tree node.
        /// </summary>
        /// <param name="child">The child node to remove.</param>
        /// <returns>true if the child node is successfully removed.</returns>
        public bool RemoveChild(Tree<T> child)
        {
            if (child.Parent != this)
                throw new InvalidOperationException(GenericResources.ERR_Tree_NotParent);

            var rlt = _children.Remove(child);
            if (rlt)
            {
                child._parent = null;
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Adds a new child node to this tree node.
        /// </summary>
        /// <returns>The added new child node.</returns>
        public Tree<T> AddChild()
        {
            if (_children == null)
                _children = new List<Tree<T>>();
            var child = new Tree<T>() { _parent = this };
            _children.Add(child);
            return child;
        }

        /// <summary>
        /// Adds a new child node with the specified value to this tree node.
        /// </summary>
        /// <param name="value">The value of the child node to add.</param>
        /// <returns>
        /// The added new child node.
        /// </returns>
        public Tree<T> AddChild(T value)
        {
            if (_children == null)
                _children = new List<Tree<T>>();
            var child = new Tree<T>() { _parent = this, Value = value };
            _children.Add(child);
            return child;
        }
    }
}
