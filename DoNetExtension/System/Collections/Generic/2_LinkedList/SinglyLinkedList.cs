using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
	/// <summary>
	/// Represents a singly-linked list.
	/// </summary>
	/// <typeparam name="T">Specifies the element type of the linked list.</typeparam>
	/// <remarks>
	/// SinglyLinkedList{T} is a general-purpose singly-linked list. It supports enumerators and implements the <see cref="ICollection"/> interface, consistent with other collection classes in the .NET Framework. In comparison with <see cref="System.Collections.Generic.LinkedList{T}"/>, which is doubly-linked, this class saves some memory and has slightly higher performance. Each node of this singly-linked list is represented by a <see cref="SinglyLinkedListNode{T}"/>, which only points forward to the next node and DOES NOT provide a reference to its attached list like <see cref="System.Collections.Generic.LinkedListNode{T}"/>. In other words, each node only has two properties - <c>Value</c> and <c>Next</c>.
	/// <para>Because each node of a <see cref="SinglyLinkedListNode{T}"/> does not refer to the attached list, the list does not perform attachment validation when a node is added or removed from the list. In this case, any usage of this singly-linked list must ensure the attachment.</para>
	/// </remarks>
	public class SinglyLinkedList<T> : ICollection<T>, IEnumerable<T>, ICollection, IEnumerable
	{
		class Enumerator : IEnumerator<T>
		{
			SinglyLinkedListNode<T> _firstNode;
			SinglyLinkedListNode<T> _currNode;

			internal Enumerator(SinglyLinkedListNode<T> firstNode)
			{
				_firstNode = firstNode;
			}

			public T Current
			{
				get { return _currNode.Value; }
			}

			object IEnumerator.Current
			{
				get { return _currNode.Value; }
			}

			public bool MoveNext()
			{
				if (_firstNode == null) return false;
				else if (_currNode == null)
				{
					_currNode = _firstNode;
					return true;
				}
				else
				{
					var next = _currNode.Next;
					if (next == null) return false;
					else
					{
						_currNode = next;
						return true;
					}
				}
			}

			void IDisposable.Dispose() { }


			public void Reset()
			{
				_currNode = null;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SinglyLinkedList{T}"/> class.
		/// </summary>
		public SinglyLinkedList() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="SinglyLinkedList{T}"/> class that contains elements copied from the specified <see cref="IEnumerable{T}"/> and has sufficient capacity to accommodate the number of elements copied.
		/// </summary>
		/// <param name="enumerable">The <see cref="IEnumerable{T}"/> whose elements are copied to the new <see cref="SinglyLinkedList{T}"/>.</param>
		public SinglyLinkedList(IEnumerable<T> enumerable)
		{
			var enumerator = enumerable.GetEnumerator();
			if (enumerator.MoveNext())
			{
				First = Last = new SinglyLinkedListNode<T>(enumerator.Current);
				Count = 1;
			}

			while (enumerator.MoveNext())
			{
				var newNode = new SinglyLinkedListNode<T>(enumerator.Current);
				Last.Next = newNode;
				Last = newNode;
				++Count;
			}
		}

		/// <summary>
		/// Gets the first node of the <see cref="SinglyLinkedList{T}" />.
		/// </summary>
		/// <value>The first node of the <see cref="SinglyLinkedList{T}" />.</value>
		public SinglyLinkedListNode<T> First { private set; get; }

		/// <summary>
		/// Gets the last node of the <see cref="SinglyLinkedList{T}" />.
		/// </summary>
		/// <value>The last node of the <see cref="SinglyLinkedList{T}" />.</value>
		public SinglyLinkedListNode<T> Last { private set; get; }

		/// <summary>
		/// Adds a new node containing the specified value at the start of the <see cref="SinglyLinkedList{T}" />.
		/// </summary>
		/// <param name="value">The value to add at the start of the <see cref="SinglyLinkedList{T}" />.</param>
		/// <remarks>
		/// <see cref="SinglyLinkedList{T}" /> accepts <c>null</c> as a valid Value for reference types and allows duplicate values. If the <see cref="SinglyLinkedList{T}" /> is empty, the new node becomes the <see cref="First"/> and the <see cref="Last"/>.
		/// </remarks>
		public void AddFirst(T value)
		{
			if (First == null)
			{
				First = Last = new SinglyLinkedListNode<T>(value);
				Count = 1;
			}
			else
			{
				First = new SinglyLinkedListNode<T>(value, First);
				++Count;
			}
		}

		/// <summary>
		/// Adds the specified node at the start of the <see cref="SinglyLinkedList{T}" />.
		/// </summary>
		/// <param name="node">The <see cref="SinglyLinkedListNode{T}"/> to add at the start of the <see cref="SinglyLinkedList{T}" />.</param>
		public void AddFirst(SinglyLinkedListNode<T> node)
		{
			if (First == null)
			{
				First = Last = node;
				node.Next = null;
				Count = 1;
			}
			else
			{
				node.Next = First;
				First = node;
				++Count;
			}
		}

		/// <summary>
		/// Adds a sequence of values at the beginning of the <see cref="SinglyLinkedList{T}" />.
		/// </summary>
		/// <param name="values">The values to add at the beginning of the <see cref="SinglyLinkedList{T}" />.</param>
		public void AddFirst(IEnumerable<T> values)
		{
			int i = 0;
			if (First == null)
			{
				foreach (var value in values)
				{
					if (i == 0) First = Last = new SinglyLinkedListNode<T>(value);
					else First = new SinglyLinkedListNode<T>(value, First);
					++i;
				}
			}
			else
			{
				foreach (var value in values)
				{
					First = new SinglyLinkedListNode<T>(value, First);
					++i;
				}
			}

			Count += i;
		}

        /// <summary>
        /// Adds an array of values at the beginning of the <see cref="SinglyLinkedList{T}" />.
        /// </summary>
        /// <param name="values">The values to add at the beginning of the <see cref="SinglyLinkedList{T}" />.</param>
        public void AddFirst(T[] values)
		{
			var len = values.Length;
			if (len == 1) AddLast(values[0]);
			else
			{
				if (First == null)
				{
					First = Last = new SinglyLinkedListNode<T>(values[0]);
					for (int i = 1; i < len; ++i)
						First = new SinglyLinkedListNode<T>(values[i], First);
				}
				else
				{
					for (int i = 0; i < len; ++i)
						First = new SinglyLinkedListNode<T>(values[i], First);
				}
				Count += len;
			}
		}

		/// <summary>
		/// Adds the specified value at the end of the <see cref="SinglyLinkedList{T}" />.
		/// </summary>
		/// <param name="value">The value to add at the end of the <see cref="SinglyLinkedList{T}" />.</param>
		/// <remarks>
		/// <see cref="SinglyLinkedList{T}" /> accepts <c>null</c> as a valid Value for reference types and allows duplicate values. If the <see cref="SinglyLinkedList{T}" /> is empty, the new node becomes the <see cref="First"/> and the <see cref="Last"/>.
		/// </remarks>
		public void AddLast(T value)
		{
			if (First == null)
			{
				First = Last = new SinglyLinkedListNode<T>(value);
				Count = 1;
			}
			else
			{
				var newNode = new SinglyLinkedListNode<T>(value);
				Last.Next = newNode;
				Last = newNode;
				++Count;
			}
		}

		/// <summary>
		/// Adds a sequence of values at the end of the <see cref="SinglyLinkedList{T}" />.
		/// </summary>
		/// <param name="values">The values to add at the end of the <see cref="SinglyLinkedList{T}" />.</param>
		public void AddLast(IEnumerable<T> values)
		{
			int i = 0;
			if(First == null)
			{
				foreach (var value in values)
				{
					if (i == 0) First = Last = new SinglyLinkedListNode<T>(value);
					else
					{
						var newNode = new SinglyLinkedListNode<T>(value);
						Last.Next = newNode;
						Last = newNode;
					}
					++i;
				}
			}
			else
			{
				foreach (var value in values)
				{
					var newNode = new SinglyLinkedListNode<T>(value);
					Last.Next = newNode;
					Last = newNode;
					++i;
				}
			}

			Count += i;
		}

		/// <summary>
		/// Adds an array of values at the end of the <see cref="SinglyLinkedList{T}" />.
		/// </summary>
		/// <param name="values">The values to add at the end of the <see cref="SinglyLinkedList{T}" />.</param>
		public void AddLast(T[] values)
		{
			var len = values.Length;
			if (len == 1) AddLast(values[0]);
			else
			{
				if (First == null)
				{
					First = Last = new SinglyLinkedListNode<T>(values[0]);
					for (int i = 1; i < len; ++i)
					{
						var newNode = new SinglyLinkedListNode<T>(values[i]);
						Last.Next = newNode;
						Last = newNode;
					}
				}
				else
				{
					for (int i = 0; i < len; ++i)
					{
						var newNode = new SinglyLinkedListNode<T>(values[i]);
						Last.Next = newNode;
						Last = newNode;
					}
				}
				Count += len;
			}
		}

		/// <summary>
		/// Adds the specified node at the end of the <see cref="SinglyLinkedList{T}" />.
		/// </summary>
		/// <param name="node">The <see cref="SinglyLinkedListNode{T}"/> to add at the end of the <see cref="SinglyLinkedList{T}" />.</param>
		public void AddLast(SinglyLinkedListNode<T> node)
		{
			if (First == null)
			{
				First = Last = node;
				node.Next = null;
				Count = 1;
			}
			else
			{
				Last.Next = node;
				Last = node;
				node.Next = null;
				++Count;
			}
		}

		/// <summary>
		/// Adds a new node containing the specified value after the specified existing node in the <see cref="SinglyLinkedList{T}" />.
		/// </summary>
		/// <param name="node">The <see cref="SinglyLinkedListNode{T}" /> after which to insert another <see cref="SinglyLinkedListNode{T}" /> containing value.</param>
		/// <param name="value">The value to add to the <see cref="SinglyLinkedList{T}" />.</param>
		public void AddAfter(SinglyLinkedListNode<T> node, T value)
		{
			if (node == Last)
			{
				var newNode = new SinglyLinkedListNode<T>(value);
				Last = node.Next = newNode;
			}
			else
			{
				var newNode = new SinglyLinkedListNode<T>(value, node.Next);
				node.Next = newNode;
			}
			++Count;
		}

		/// <summary>
		/// Adds the specified <paramref name="nodeToAdd"/> after the specified existing node in the <see cref="SinglyLinkedList{T}" />.
		/// </summary>
		/// <param name="node">The <see cref="SinglyLinkedListNode{T}" /> after which to insert <paramref name="nodeToAdd"/>.</param>
		/// <param name="nodeToAdd">Another <see cref="SinglyLinkedListNode{T}" /> to add after the <paramref name="node"/>.</param>
		public void AddAfter(SinglyLinkedListNode<T> node, SinglyLinkedListNode<T> nodeToAdd)
		{
			if (node == Last)
			{
				Last = node.Next = nodeToAdd;
				nodeToAdd.Next = null;
			}
			else
			{
				nodeToAdd.Next = node.Next;
				node.Next = nodeToAdd;
			}
			++Count;
		}

		/// <summary>
		/// Removes all nodes from the <see cref="SinglyLinkedList{T}" />.
		/// </summary>
		public void Clear()
		{
			Count = 0;
			First = Last = null;
		}

		/// <summary>
		/// Determines whether the <see cref="SinglyLinkedList{T}" /> contains a specific value.
		/// </summary>
		/// <param name="value">The value to locate in the <see cref="SinglyLinkedList{T}" />.</param>
		/// <returns>true if <paramref name="value" /> is found in the <see cref="SinglyLinkedList{T}" />; otherwise, false.</returns>
		public bool Contains(T value)
		{
			var node = First;
			while (node != null)
			{
				if (node.Value.Equals(value)) return true;
				else node = node.Next;
			}
			return false;
		}

		/// <summary>
		/// Finds the first node that contains the specified value. The <see cref="SinglyLinkedList{T}" /> is searched forward starting at First and ending at Last.
		/// </summary>
		/// <param name="value">The value to locate in the <see cref="SinglyLinkedList{T}" />.</param>
		/// <returns>The first <see cref="SinglyLinkedListNode{T}" /> that contains the specified value, if found; otherwise, <c>null</c>.</returns>
		/// <remarks>This method performs a linear search; therefore, this method is an O(<c>n</c>) operation, where <c>n</c> is <see cref="Count"/>.</remarks>
		public SinglyLinkedListNode<T> Find(T value)
		{
			var node = First;
			while (node != null)
			{
				if (node.Value.Equals(value)) return node;
				else node = node.Next;
			}
			return null;
		}

		/// <summary>
		/// Copies the entire <see cref="SinglyLinkedList{T}" /> to a compatible one-dimensional <see cref="System.Array"/>, starting at the specified index of the target array.
		/// </summary>
		/// <param name="array">The one-dimensional Array that is the destination of the elements copied from <see cref="SinglyLinkedList{T}" />. The Array must have zero-based indexing.</param>
		/// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
		public void CopyTo(T[] array, int arrayIndex)
		{
			var node = First;
			while (node != null)
			{
				array[arrayIndex] = node.Value;
				++arrayIndex;
			}
		}

		/// <summary>
		/// Gets the number of elements contained in the <see cref="SinglyLinkedList{T}" />.
		/// </summary>
		/// <value>The number of nodes actually contained in the <see cref="SinglyLinkedList{T}" />.</value>
		/// <returns>The number of elements contained in the <see cref="SinglyLinkedList{T}" />.</returns>
		public int Count { private set; get; }

		/// <summary>
		/// Removes the first occurrence of a specific <paramref name="value"/> from the <see cref="SinglyLinkedList{T}" />.
		/// </summary>
		/// <param name="value">The value to remove from the <see cref="SinglyLinkedList{T}" />.</param>
		/// <returns><c>true</c> if <paramref name="value" /> was successfully removed from the <see cref="SinglyLinkedList{T}" />; otherwise, <c>false</c>.</returns>
		public bool Remove(T value)
		{
			SinglyLinkedListNode<T> prev = null;
			var node = First;
			while (node != null)
			{
				if (node.Value.Equals(value))
				{
					if(prev == null)
					{
						First = First.Next;
						if (First == null) Last = null;
					}
					else if(node.Next == null)
					{
						prev.Next = null;
						Last = prev;
					}
					else prev.Next = node.Next;

					--Count;
					return true;
				}
				else
				{
					prev = node;
					node = node.Next;
				}
			}
			return false;
		}

		/// <summary>
		/// Removes the specified node from the <see cref="SinglyLinkedList{T}" />.
		/// </summary>
		/// <param name="node">The node to remove from the <see cref="SinglyLinkedList{T}" />.</param>
		/// <returns><c>true</c> if <paramref name="node"/> was successfully removed from the <see cref="SinglyLinkedList{T}" />; otherwise, <c>false</c>.</returns>
		public bool Remove(SinglyLinkedListNode<T> node)
		{
			SinglyLinkedListNode<T> prev = null;
			var tmpNode = First;
			while (tmpNode != null)
			{
				if (tmpNode == node)
				{
					if (prev == null)
					{
						First = First.Next;
						if (First == null) Last = null;
					}
					else if (tmpNode.Next == null)
					{
						prev.Next = null;
						Last = prev;
					}
					else prev.Next = tmpNode.Next;

					--Count;
					return true;
				}
				else
				{
					prev = tmpNode;
					tmpNode = tmpNode.Next;
				}
			}
			return false;
		}

		/// <summary>
		/// Removes the node at the start of the <see cref="SinglyLinkedList{T}" />.
		/// </summary>
		public void RemoveFirst()
		{
			if (First != null)
			{
				First = First.Next;
				if (First == null)
				{
					Last = null;
					Count = 0;
				}
				else --Count;
			}
		}

		/// <summary>
		/// Returns an enumerator that iterates through the <see cref="SinglyLinkedList{T}" />.
		/// </summary>
		/// <returns>A <see cref="System.Collections.Generic.IEnumerator{T}" /> that can be used to iterate through the <see cref="SinglyLinkedList{T}" />.</returns>
		/// <remarks>At first the enumerator is positioned before the first node. At this position, <c>Current</c> is undefined. When you first call the <c>MoveNext</c> method, the enumerator move to the first node. After that, the enumerator moves to the next node each time <c>MoveNext</c> is called, until the last node is reached. When the last node is reached after <c>MoveNext</c> is called, the next call of <c>MoveNext</c> will return <c>false</c>.</remarks>
		public IEnumerator<T> GetEnumerator()
		{
			return new Enumerator(First);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			var node = First;
			while (node != null)
			{
				yield return node.Value;
				node = node.Next;
			}
		}

		void ICollection.CopyTo(Array array, int index)
		{
			var node = First;
			while (node != null)
			{
				array.SetValue(node.Value, index);
				++index;
			}
		}

		int ICollection.Count
		{
			get { return this.Count; }
		}

		bool ICollection.IsSynchronized
		{
			get { return false; }
		}

		object _syncRoot;
		object ICollection.SyncRoot
		{
			get
			{
				if (_syncRoot == null)
				{
					Interlocked.CompareExchange<object>(ref _syncRoot, new object(), null);
				}
				return this._syncRoot;
			}

		}

		bool ICollection<T>.IsReadOnly
		{
			get { return false; }
		}

		void ICollection<T>.Add(T item)
		{
			AddLast(item);
		}
	}


	/// <summary>
	/// Represents a node in a <see cref="SinglyLinkedList{T}"/>.
	/// </summary>
	/// <typeparam name="T">Specifies the element type of the linked list.</typeparam>
	/// <remarks>
	/// Each element of the <see cref="SinglyLinkedList{T}"/> collection is a <see cref="SinglyLinkedListNode{T}"/>. The <see cref="SinglyLinkedListNode{T}"/> contains a value and a reference to the next node. Unlike a <see cref="System.Collections.Generic.LinkedListNode{T}"/>, this class does not reference to the previous node and the list it belongs to, which saves 8 Bytes on a machine that uses 32-bit memory architecture (like a x86 machine), and 16 Bytes on a machine that uses 64-bit memory architecture (like a x64 machine).
	/// </remarks>
	public class SinglyLinkedListNode<T>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SinglyLinkedListNode{T}" /> class.
		/// </summary>
		/// <param name="value">The value to contain in the <see cref="SinglyLinkedListNode{T}" />.</param>
		internal SinglyLinkedListNode(T value)
		{
			Value = value;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SinglyLinkedListNode{T}"/> class.
		/// </summary>
		/// <param name="value">The value to contain in the <see cref="SinglyLinkedListNode{T}" />.</param>
		/// <param name="next">The next <see cref="SinglyLinkedListNode{T}" />, or <c>null</c> if the current node is the last in the <see cref="SinglyLinkedList{T}" />.</param>
		public SinglyLinkedListNode(T value, SinglyLinkedListNode<T> next)
		{
			Value = value;
			Next = next;
		}

		/// <summary>
		/// Gets the next <see cref="SinglyLinkedListNode{T}" /> node.
		/// </summary>
		/// <value>A reference to the next node in the <see cref="SinglyLinkedList{T}" />, or <c>null</c> if the current node is the last element of the <see cref="SinglyLinkedList{T}" />.</value>
		public SinglyLinkedListNode<T> Next { internal set; get; }

		/// <summary>
		/// Gets or sets the value contained in the node.
		/// </summary>
		/// <value>The value contained in the node.</value>
		public T Value { set; get; }
	}
}
