using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Collections.Generic
{
    public enum TreeSearchMode
    {
        PreOrder,
        PostOrder,
        BreadthFirst,
        InOrder
    }

    /// <summary>
    /// Represents a binary tree (or a binary tree node, which can be viewed as a binary tree).
    /// </summary>
    /// <typeparam name="T">The type of values stored in the binary tree.</typeparam>
    public interface IBinaryTree<T> : ITree<T>
    {
        /// <summary>
        /// Gets the left child of this binary tree node.
        /// </summary>
        IBinaryTree<T> LeftChild { get; }
        /// <summary>
        /// Gets the right child of this binary tree node.
        /// </summary>
        IBinaryTree<T> RightChild { get; }
    }

    /// <summary>
    /// Represents a binary tree (or a tree node, which can be viewed as a tree).
    /// </summary>
    /// <typeparam name="T">The type of values stored in this tree node.</typeparam>
    public class BinaryTree<T> : IBinaryTree<T>
    {
        /// <summary>
        /// Gets or set the value of this binary tree node.
        /// </summary>
        public T Value { get; set; }

        BinaryTree<T> _parent;
        ITree<T> ITree<T>.Parent { get { return _parent; } }
        /// <summary>
        /// Gets the parent of this binary tree node. If this tree node is root, a null reference will be returned.
        /// </summary>
        public BinaryTree<T> Parent
        {
            get { return _parent; }
        }

        BinaryTree<T> _left;
        IBinaryTree<T> IBinaryTree<T>.LeftChild { get { return _left; } }
        /// <summary>
        /// Gets or sets the left child.
        /// </summary>
        public BinaryTree<T> LeftChild
        {
            get { return _left; }
            set
            {
                _left = value; 
                if (value != null)
                    value._parent = this;
            }
        }

        BinaryTree<T> _right;
        IBinaryTree<T> IBinaryTree<T>.RightChild { get { return _right; } }
        /// <summary>
        /// Gets or sets the right child.
        /// </summary>
        public BinaryTree<T> RightChild
        {
            get { return _right; }
            set
            {
                _right = value;
                if (value != null)
                    value._parent = this;
            }
        }

        IList<ITree<T>> ITree<T>.Children
        {
            get
            {
                return new ITree<T>[] { _left, _right };
            }
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.IBinaryTree{T}"/> is identical (same structure same data, but not necessarily same type) to the current <see cref="System.BinaryTree{T}"/>.
        /// </summary>
        /// <param name="tree">The <see cref="System.IBinaryTree{T}"/> to compare.</param>
        /// <returns>true if the two trees are identical, otherwise false.</returns>
        public bool Equals(IBinaryTree<T> tree)
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
        /// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="System.BinaryTree{T}"/>.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>true if the objects are equal, otherwise false.</returns>
        public override bool Equals(object obj)
        {
            var t2 = obj as IBinaryTree<T>;
            if (t2 == null) return false;
            else return this.Equals(t2);
        }

        public override string ToString()
        {
            return this.ToString(TreeSearchMode.BreadthFirst);
        }


        //public void InOrderSearch(Func<TreeSearchItem<BinaryTree<T>>, bool> process, object argument = null)
        //{
        //    var s = new Stack<Pair<BinaryTree<T>, int>>();
        //    BinaryTree<T> root = this;
        //    int no = 0;
        //    int status = 0;
        //    while (true)
        //    {
        //        if (root != null && status == 0)
        //            process(new TreeSearchItem<BinaryTree<T>>(root, no++, SpecialPosition.First, argument));

        //        if (status == 0)
        //        {
        //            if (root._left != null)
        //            {
        //                s.Push(new Pair<BinaryTree<T>, int>(root, 0));
        //                root = root._left;
        //                status = 0;
        //            }
        //            else if (root._right != null)
        //            {
        //                s.Push(new Pair<BinaryTree<T>, int>(root, 1));
        //                root = root._right;
        //                status = 0;
        //            }
        //            else
        //            {
        //                if (s.Count == 0) break;
        //                var item = s.Pop();
        //                root = item.Value1;
        //                status = item.Value2 + 1;
        //            }
        //        }
        //        else if (status == 1)
        //        {
        //            if (root._right != null)
        //            {
        //                s.Push(new Pair<BinaryTree<T>, int>(root, 1));
        //                root = root._right;
        //                status = 0;
        //            }
        //            else status = 2;
        //        }
        //        else if (status == 2)
        //        {
        //            if (s.Count == 0) break;
        //            var item = s.Pop();
        //            root = item.Value1;
        //            status = item.Value2 + 1;
        //        }
        //    }

        //}

        /// <summary>
        /// Search every node in this treeview in pre-order.
        /// </summary>
        /// <param name="t">This treeview.</param>
        /// <param name="process">An operation performed on every node in the treeview.</param>
        /// <param name="argument">An argument passed into the process.</param>
        //public void PreOrderSearch(Func<TreeSearchItem<BinaryTree<T>>, bool> process, object argument = null)
        //{
        //    var s = new Stack<Pair<BinaryTree<T>, int>>();
        //    int no = 0;
        //    int count = 2;
        //    SpecialPosition sp;
        //    var Nodes = new BinaryTree<T>[2];
        //    Nodes[0] = LeftNode;
        //    Nodes[1] = RightNode;

        //    for (int i = 0; i < 2; i++)
        //    {
        //        var thisRoot = Nodes[i];
        //        sp = SpecialPosition.NotSpecial;
        //        if (i == 0) sp |= SpecialPosition.First;
        //        count += 2;
        //        count--;
        //        if (count == 0)
        //            sp |= SpecialPosition.Last;
        //        process(new TreeSearchItem<BinaryTree<T>>(thisRoot, no++, sp, argument));

        //        BinaryTree<T> n = thisRoot;
        //        int idx = 0;


        //        s.Push(new Pair<BinaryTree<T>, int>(n, 0));
        //        var nNodes = new BinaryTree<T>[2];
        //        nNodes[0] = n.LeftNode;
        //        nNodes[1] = n.RightNode;

        //        while (n != thisRoot || idx != 2)
        //        {
        //            n = nNodes[idx];
        //            count += 2;

        //            sp = SpecialPosition.NotSpecial;
        //            count--;
        //            if (count == 0)
        //                sp |= SpecialPosition.Last;

        //            if (!process(new TreeSearchItem<BinaryTree<T>>(n, no++, sp, argument)))
        //                break;

        //            if (nNodes.Length == 0)
        //            {
        //                var p = s.Peek();
        //                idx = ++p.Value2;
        //                while (idx == 2 && p.Value1 != thisRoot)
        //                {
        //                    s.Pop();
        //                    p = s.Peek();
        //                    idx = ++p.Value2;
        //                }
        //                n = p.Value1;
        //            }
        //            else
        //            {
        //                s.Push(new Pair<BinaryTree<T>, int>(n, 0));
        //                idx = 0;
        //            }
        //        }
        //        s.Pop();
        //    }
        //}

        /// <summary>
        /// Search every node in this treeview breadth-first (BFS).
        /// </summary>
        /// <param name="t">This treeview.</param>
        /// <param name="process">An operation performed on every node in the treeview.</param>
        /// <param name="argument">An argument passed into the process.</param>
        //public void BreadthFirstSearch(Action<TreeSearchItem<BinaryTree<T>>> process,
        //    object argument = null,
        //    bool processNullTree = false)
        //{
        //    var q = new Queue<BinaryTree<T>>();

        //    int no = 0;

        //    if (processNullTree || this != null)
        //        q.Enqueue(this);

        //    while (q.Count > 0)
        //    {
        //        var thisNode = q.Dequeue();
        //        if (thisNode != null)
        //        {
        //            if (processNullTree || thisNode.LeftNode != null)
        //                q.Enqueue(thisNode.LeftNode);
        //            if (processNullTree || thisNode.RightNode != null)
        //                q.Enqueue(thisNode.RightNode);
        //        }

        //        SpecialPosition sp = SpecialPosition.NotSpecial;
        //        if (no == 0)
        //            sp |= SpecialPosition.First;
        //        if (q.Count == 0)
        //            sp |= SpecialPosition.Last;

        //        process(new TreeSearchItem<BinaryTree<T>>(thisNode, no++, sp, argument));
        //    }
        //}
    }
}
