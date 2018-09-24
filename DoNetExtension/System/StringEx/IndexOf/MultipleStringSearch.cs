using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// Provides methods (Aho-Corasick algorithm) to search occurrences of multiple keywords. These methods are most efficient when there are many short keywords distinguishable by the beginning few characters.
    /// <para>NOTE this class does not support case-insensitive or culture-sensitive search. To perform case-insensitive search, you may first lower-case both the keywords and the target text.</para>
    /// </summary>
    public class MultipleStringSearch
    {
        class InnerNode
        {
            internal char _char;
            internal InnerNode _parent;
            internal InnerNode _failure;
            internal InnerNode[] _transitionsArr;
            private HybridDictionary<char, InnerNode> _transitionDict;
            internal HybridDictionary<string, int> _results;

            /// <summary>
            /// Initialize tree node with specified character
            /// </summary>
            /// <param name="parent">Parent node</param>
            /// <param name="c">Character</param>
            internal InnerNode(InnerNode parent, char c)
            {
                _char = c;
                _parent = parent;
                _results = new HybridDictionary<string, int>();
                _transitionsArr = new InnerNode[] { };
                _transitionDict = new HybridDictionary<char, InnerNode>();
            }


            /// <summary>
            /// Adds pattern ending in this node
            /// </summary>
            /// <param name="result">Pattern</param>
            internal void AddResult(string result, int index)
            {
                if (!_results.ContainsKey(result))
                    _results.Add(result, index);
            }

            /// <summary>
            /// Adds transition node
            /// </summary>
            /// <param name="node">Node</param>
            internal void AddTransition(InnerNode node)
            {
                _transitionDict.Add(node._char, node);
                var ar = new InnerNode[_transitionDict.Values.Count];
                _transitionDict.Values.CopyTo(ar, 0);
                _transitionsArr = ar;
            }


            /// <summary>
            /// Returns transition to specified character (if exists)
            /// </summary>
            /// <param name="c">Character</param>
            /// <returns>Returns TreeNode or null</returns>
            internal InnerNode GetTransition(char c)
            {
                InnerNode rlt;
                if (_transitionDict.TryGetValue(c, out rlt)) return rlt;
                else return null;
            }


            /// <summary>
            /// Returns true if node contains transition to specified character
            /// </summary>
            /// <param name="c">Character</param>
            /// <returns>True if transition exists</returns>
            internal bool ContainsTransition(char c)
            {
                return _transitionDict.ContainsKey(c);
            }
        }

        InnerNode _root;

        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleStringSearch"/> class.
        /// </summary>
        /// <param name="keywords">The keywords.</param>
        public MultipleStringSearch(string[] keywords)
        {
            _buildTree(keywords);
        }

        void _buildTree(string[] keywords)
        {
            //build keyword tree and transition function
            _root = new InnerNode(null, ' ');
            var keywordCount = keywords.Length;
            for (int i = 0; i < keywordCount; ++i)
            {
                var p = keywords[i];

                // add pattern to tree
                InnerNode nd = _root;
                foreach (var c in p)
                {
                    InnerNode ndNew = null;
                    foreach (InnerNode trans in nd._transitionsArr)
                        if (trans._char == c) { ndNew = trans; break; }

                    if (ndNew == null)
                    {
                        ndNew = new InnerNode(nd, c);
                        nd.AddTransition(ndNew);
                    }
                    nd = ndNew;
                }
                nd.AddResult(p, i);
            }

            // Find failure functions
            var nodes = new List<InnerNode>();
            // level 1 nodes - fail to root node
            foreach (InnerNode nd in _root._transitionsArr)
            {
                nd._failure = _root;
                foreach (InnerNode trans in nd._transitionsArr) nodes.Add(trans);
            }
            // other nodes - using BFS
            while (nodes.Count != 0)
            {
                var newNodes = new List<InnerNode>();
                foreach (InnerNode nd in nodes)
                {
                    InnerNode r = nd._parent._failure;
                    char c = nd._char;

                    while (r != null && !r.ContainsTransition(c)) r = r._failure;
                    if (r == null)
                        nd._failure = _root;
                    else
                    {
                        nd._failure = r.GetTransition(c);
                        foreach (var result in nd._failure._results)
                            nd.AddResult(result.Key, result.Value);
                    }

                    // add child nodes to BFS list 
                    foreach (InnerNode child in nd._transitionsArr)
                        newNodes.Add(child);
                }
                nodes = newNodes;
            }
            _root._failure = _root;
        }

        /// <summary>
        /// Searches the specified text and returns all occurrences of any keyword.
        /// </summary>
        /// <param name="text">The text to search.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <returns>
        /// An array of <see cref="StringSearchResult" /> objects that store the search result; null if the search fails.
        /// </returns>
        public StringSearchResult[] FindAll(string text, int startIndex = 0)
        {
            var rlt = new List<StringSearchResult>();
            InnerNode ptr = _root;

            while (startIndex < text.Length)
            {
                InnerNode trans = null;
                while (trans == null)
                {
                    trans = ptr.GetTransition(text[startIndex]);
                    if (ptr == _root) break;
                    if (trans == null) ptr = ptr._failure;
                }
                if (trans != null) ptr = trans;

                foreach (var found in ptr._results)
                {
                    rlt.Add(new StringSearchResult()
                    {
                        Position = startIndex - found.Key.Length + 1,
                        Value = found.Key,
                        HitIndex = found.Value
                    });
                }
                ++startIndex;
            }

            if (rlt.Count == 0) return null;
            return rlt.ToArray();
        }


        /// <summary>
        /// Searches the specified text and returns the first occurrence of any keyword.
        /// </summary>
        /// <param name="text">The text to search.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <returns>
        /// A <see cref="StringSearchResult" /> object that stores the search result; null if the search fails.
        /// </returns>
        public StringSearchResult FindFirst(string text, int startIndex = 0)
        {
            var ptr = _root;

            while (startIndex < text.Length)
            {
                InnerNode trans = null;
                while (trans == null)
                {
                    trans = ptr.GetTransition(text[startIndex]);
                    if (ptr == _root) break;
                    if (trans == null) ptr = ptr._failure;
                }
                if (trans != null) ptr = trans;

                foreach (var found in ptr._results)
                {
                    return new StringSearchResult()
                    {
                        Position = startIndex - found.Key.Length + 1,
                        Value = found.Key,
                        HitIndex = found.Value
                    };
                }
                ++startIndex;
            }
            return null;
        }


        /// <summary>
        /// Searches the specified text and determines if it contains any occurrence of any keyword.
        /// </summary>
        /// <param name="text">The text to search.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <returns>
        ///   <c>true</c> if the text searched contains any occurrence of any keyword; otherwise, <c>false</c>.
        /// </returns>
        public bool ContainsAny(string text, int startIndex = 0)
        {
            InnerNode ptr = _root;

            while (startIndex < text.Length)
            {
                InnerNode trans = null;
                while (trans == null)
                {
                    trans = ptr.GetTransition(text[startIndex]);
                    if (ptr == _root) break;
                    if (trans == null) ptr = ptr._failure;
                }
                if (trans != null) ptr = trans;

                if (ptr._results.Count > 0) return true;
                ++startIndex;
            }
            return false;
        }
    }
}
