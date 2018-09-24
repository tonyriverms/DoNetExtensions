using System;
using System.Collections.Generic;
using System.IO;

namespace System
{
    /// <summary>
    /// Represents two values or objects in a mutable pair.
    /// </summary>
    /// <typeparam name="T1">The type of the first value or object.</typeparam>
    /// <typeparam name="T2">The type of the second value or object.</typeparam>
    public class Pair<T1, T2>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pair&lt;T1, T2&gt;"/> class.
        /// </summary>
        public Pair() : base() { }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Pair`2" /> class.
        /// </summary>
        /// <param name="item1">The first value or object.</param>
        /// <param name="item2">The second value or object.</param>
        public Pair(T1 item1, T2 item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        /// <summary>
        /// Gets the first value or object.
        /// </summary>
        public T1 Item1 { get; set; }

        /// <summary>
        /// Gets the second value or object.
        /// </summary>
        public T2 Item2 { get; set; }

        public static implicit operator Pair<T1, T2>(KeyValuePair<T1, T2> pair)
        {
            return new Pair<T1, T2>(pair.Key, pair.Value);
        }

        public static implicit operator Pair<T1, T2>(Tuple<T1, T2> pair)
        {
            return new Pair<T1, T2>(pair.Item1, pair.Item2);
        }

        public static implicit operator Pair<T1, T2>((T1, T2) pair)
        {
            return new Pair<T1, T2>(pair.Item1, pair.Item2);
        }

        public static implicit operator KeyValuePair<T1, T2>(Pair<T1, T2> pair)
        {
            return new KeyValuePair<T1, T2>(pair.Item1, pair.Item2);
        }

        public static implicit operator Tuple<T1, T2>(Pair<T1, T2> pair)
        {
            return new Tuple<T1, T2>(pair.Item1, pair.Item2);
        }

        public static implicit operator (T1, T2) (Pair<T1, T2> pair)
        {
            return (pair.Item1, pair.Item2);
        }

        public static Pair<T1, T2> operator +(Pair<T1, T2> pair1, (T1, T2) pair2)
        {
            pair1.Item1 += (dynamic)pair2.Item1;
            pair1.Item2 += (dynamic)pair2.Item2;
            return pair1;
        }

        public static Pair<T1, T2> operator +(Pair<T1, T2> pair1, Tuple<T1, T2> pair2)
        {
            pair1.Item1 += (dynamic)pair2.Item1;
            pair1.Item2 += (dynamic)pair2.Item2;
            return pair1;
        }

        public static (T1, T2) operator +((T1, T2) pair2, Pair<T1, T2> pair1)
        {
            return ((T1)(pair2.Item1 + (dynamic)pair1.Item1), (T2)(pair2.Item2 + (dynamic)pair1.Item2));
        }

        public static Tuple<T1, T2> operator +(Tuple<T1, T2> pair2, Pair<T1, T2> pair1)
        {
            return new Tuple<T1, T2>((T1)(pair2.Item1 + (dynamic)pair1.Item1), (T2)(pair2.Item2 + (dynamic)pair1.Item2));
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="separator">The separator that separates the string representations of <c>Value1</c> and <c>Value2</c> of in the returned string.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public string ToString(char separator)
        {
            return $"({Item1}{separator}{Item2})";
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"({Item1},{Item2})";
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is also a <see cref="System.Pair&lt;T1, T2&gt;"/> with the same parameter types as this instance, and both <c>Value1</c> and <c>Value2</c> of the specified <see cref="System.Pair&lt;T1, T2&gt;" /> are respectively equal to the <c>Value1</c> and <c>Value2</c> of this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (!(obj is Pair<T1, T2> target)) return false;
            return Item1.Equals(target.Item1) && Item2.Equals(target.Item2);
        }

        /// <summary>
        /// Returns a hash code for this instance. Item either <see cref="Item1"/> or <see cref="Item2"/> is changed, then the previously computed hash code may not represent the current objects in the pair.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            var code1 = Item1.GetHashCode();
            var code2 = Item2.GetHashCode();
            return (int)((UInt32)(code1 & 0xFFFF0000) | (UInt32)(code2 & 0x0000FFFF));
        }
    }

    /// <summary>
    /// Represents three values or objects in a mutable triple.
    /// </summary>
    /// <typeparam name="T1">The type of the first value or object.</typeparam>
    /// <typeparam name="T2">The type of the second value or object.</typeparam>
    /// <typeparam name="T3">The type of the third value or object.</typeparam>
    public class Triple<T1, T2, T3>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Triple{T1, T2, T3}"/> class.
        /// </summary>
        public Triple() : base() { }


        /// <summary>
        /// Initializes a new instance of the <see cref="Triple{T1, T2, T3}"/> class.
        /// </summary>
        /// <param name="item1">The first value or object.</param>
        /// <param name="item2">The second value or object.</param>
        /// <param name="item3">The third value or object.</param>
        public Triple(T1 item1, T2 item2, T3 item3)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }

        /// <summary>
        /// Gets the first value or object.
        /// </summary>
        public T1 Item1 { get; set; }

        /// <summary>
        /// Gets the second value or object.
        /// </summary>
        public T2 Item2 { get; set; }

        /// <summary>
        /// Gets the third value or object.
        /// </summary>
        public T3 Item3 { get; set; }


        public static implicit operator Triple<T1, T2, T3>(Tuple<T1, T2, T3> triple)
        {
            return new Triple<T1, T2, T3>(triple.Item1, triple.Item2, triple.Item3);
        }

        public static implicit operator Triple<T1, T2, T3>((T1, T2, T3) triple)
        {
            return new Triple<T1, T2, T3>(triple.Item1, triple.Item2, triple.Item3);
        }


        public static implicit operator Tuple<T1, T2, T3>(Triple<T1, T2, T3> triple)
        {
            return new Tuple<T1, T2, T3>(triple.Item1, triple.Item2, triple.Item3);
        }

        public static implicit operator (T1, T2, T3) (Triple<T1, T2, T3> triple)
        {
            return (triple.Item1, triple.Item2, triple.Item3);
        }


        public static Triple<T1, T2, T3> operator +(Triple<T1, T2, T3> triple1, (T1, T2, T3) triple2)
        {
            triple1.Item1 += (dynamic)triple2.Item1;
            triple1.Item2 += (dynamic)triple2.Item2;
            triple1.Item3 += (dynamic)triple2.Item3;
            return triple1;
        }

        public static Triple<T1, T2, T3> operator +(Triple<T1, T2, T3> triple1, Tuple<T1, T2, T3> triple2)
        {
            triple1.Item1 += (dynamic)triple2.Item1;
            triple1.Item2 += (dynamic)triple2.Item2;
            triple1.Item3 += (dynamic)triple2.Item3;
            return triple1;
        }

        public static (T1, T2, T3) operator +((T1, T2, T3) triple2, Triple<T1, T2, T3> triple1)
        {
            return ((T1)(triple2.Item1 + (dynamic)triple1.Item1), (T2)(triple2.Item2 + (dynamic)triple1.Item2), (T3)(triple2.Item3 + (dynamic)triple1.Item3));
        }

        public static Tuple<T1, T2, T3> operator +(Tuple<T1, T2, T3> triple2, Triple<T1, T2, T3> triple1)
        {
            return new Tuple<T1, T2, T3>((T1)(triple2.Item1 + (dynamic)triple1.Item1), (T2)(triple2.Item2 + (dynamic)triple1.Item2), (T3)(triple2.Item3 + (dynamic)triple1.Item3));
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="separator">The separator that separates the string representations of <c>Value1</c> and <c>Value2</c> of in the returned string.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public string ToString(char separator)
        {
            return $"({Item1}{separator}{Item2}{separator}{Item3})";
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"({Item1},{Item2},{Item3})";
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is also a <see cref="System.Pair&lt;T1, T2&gt;"/> with the same parameter types as this instance, and both <c>Value1</c> and <c>Value2</c> of the specified <see cref="System.Pair&lt;T1, T2&gt;" /> are respectively equal to the <c>Value1</c> and <c>Value2</c> of this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (!(obj is Triple<T1, T2, T3> target)) return false;
            return Item1.Equals(target.Item1) && Item2.Equals(target.Item2) && Item3.Equals(target.Item3);
        }

        /// <summary>
        /// Returns a hash code for this instance. Item either <see cref="Item1"/> or <see cref="Item2"/> or <see cref="Item3"/> is changed, then the previously computed hash code may not represent the current objects in the pair.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            var hash = 17;
            hash = hash * 31 + Item1.GetHashCode();
            hash = hash * 31 + Item2.GetHashCode();
            hash = hash * 31 + Item3.GetHashCode();
            return hash;
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// Represents two values or objects of the same type in pair.
    /// </summary>
    /// <typeparam name="T">The type of the two values or objects.</typeparam>
    public class Pair<T> : Pair<T, T>
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Pair`1" /> class.
        /// </summary>
        public Pair() { }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Pair`1" /> class.
        /// </summary>
        /// <param name="firstValue">The first value or object.</param>
        /// <param name="secondValue">The second value or object.</param>
        public Pair(T firstValue, T secondValue)
            : base(firstValue, secondValue) { }

        public static implicit operator Pair<T>(KeyValuePair<T, T> pair)
        {
            return new Pair<T>(pair.Key, pair.Value);
        }

        public static implicit operator Pair<T>(Tuple<T, T> pair)
        {
            return new Pair<T>(pair.Item1, pair.Item2);
        }

        public static implicit operator Pair<T>((T, T) pair)
        {
            return new Pair<T>(pair.Item1, pair.Item2);
        }

        public static implicit operator KeyValuePair<T, T>(Pair<T> pair)
        {
            return new KeyValuePair<T, T>(pair.Item1, pair.Item2);
        }

        public static implicit operator Tuple<T, T>(Pair<T> pair)
        {
            return new Tuple<T, T>(pair.Item1, pair.Item2);
        }

        public static implicit operator (T, T) (Pair<T> pair)
        {
            return (pair.Item1, pair.Item2);
        }

        public static Pair<T> operator +(Pair<T> pair1, T value)
        {
            pair1.Item1 += (dynamic)value;
            pair1.Item2 += (dynamic)value;
            return pair1;
        }

        public static Pair<T> operator +(Pair<T> pair1, (T, T) pair2)
        {
            pair1.Item1 += (dynamic)pair2.Item1;
            pair1.Item2 += (dynamic)pair2.Item2;
            return pair1;
        }

        public static Pair<T> operator +(Pair<T> pair1, Tuple<T, T> pair2)
        {
            pair1.Item1 += (dynamic)pair2.Item1;
            pair1.Item2 += (dynamic)pair2.Item2;
            return pair1;
        }

        public static (T, T) operator +((T, T) pair2, Pair<T> pair1)
        {
            return ((T)(pair1.Item1 + (dynamic)pair2.Item1), (T)(pair1.Item2 + (dynamic)pair2.Item2));
        }

        public static Tuple<T, T> operator +(Tuple<T, T> pair2, Pair<T> pair1)
        {
            return new Tuple<T, T>((T)(pair1.Item1 + (dynamic)pair2.Item1), (T)(pair1.Item2 + (dynamic)pair2.Item2));
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// Represents three values or objects of the same type in triple.
    /// </summary>
    /// <typeparam name="T">The type of the three values or objects.</typeparam>
    public class Triple<T> : Triple<T, T, T>
    {

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Triple`1" /> class.
        /// </summary>
        public Triple() { }


        /// <summary>
        /// Initializes a new instance of the <see cref="Triple{T}"/> class.
        /// </summary>
        /// <param name="item1">The first value or object.</param>
        /// <param name="item2">The second value or object.</param>
        /// <param name="item3">The third value or object.</param>
        public Triple(T item1, T item2, T item3)
            : base(item1, item2, item3) { }



        public static implicit operator Triple<T>(Tuple<T, T, T> triple)
        {
            return new Triple<T>(triple.Item1, triple.Item2, triple.Item3);
        }

        public static implicit operator Triple<T>((T, T, T) triple)
        {
            return new Triple<T>(triple.Item1, triple.Item2, triple.Item3);
        }

        public static implicit operator Tuple<T, T, T>(Triple<T> triple)
        {
            return new Tuple<T, T, T>(triple.Item1, triple.Item2, triple.Item3);
        }

        public static implicit operator (T, T, T) (Triple<T> triple)
        {
            return (triple.Item1, triple.Item2, triple.Item3);
        }

        public static Triple<T> operator +(Triple<T> triple, T value)
        {
            triple.Item1 += (dynamic)value;
            triple.Item2 += (dynamic)value;
            triple.Item3 += (dynamic)value;
            return triple;
        }

        public static Triple<T> operator +(Triple<T> triple1, (T, T, T) triple2)
        {
            triple1.Item1 += (dynamic)triple2.Item1;
            triple1.Item2 += (dynamic)triple2.Item2;
            triple1.Item3 += (dynamic)triple2.Item3;
            return triple1;
        }

        public static Triple<T> operator +(Triple<T> triple1, Tuple<T, T, T> triple2)
        {
            triple1.Item1 += (dynamic)triple2.Item1;
            triple1.Item2 += (dynamic)triple2.Item2;
            triple1.Item3 += (dynamic)triple2.Item3;
            return triple1;
        }

        public static (T, T, T) operator +((T, T, T) triple2, Triple<T> triple1)
        {
            return ((T)(triple1.Item1 + (dynamic)triple2.Item1), (T)(triple1.Item2 + (dynamic)triple2.Item2), (T)(triple1.Item3 + (dynamic)triple2.Item3));
        }

        public static Tuple<T, T, T> operator +(Tuple<T, T, T> triple2, Triple<T> triple1)
        {
            return new Tuple<T, T, T>((T)(triple1.Item1 + (dynamic)triple2.Item1), (T)(triple1.Item2 + (dynamic)triple2.Item2), (T)(triple1.Item3 + (dynamic)triple2.Item3));
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// Gets an enumerator that iterates through two sequences of the same type and yields pairs of objects in the two sequences.
    /// </summary>
    /// <typeparam name="T">The type of objects in the two sequences.</typeparam>
    public class PairEnumerator<T> : IEnumerator<Pair<T>>
    {
        IEnumerator<T> _e1;
        IEnumerator<T> _e2;
        Pair<T> _current;

        /// <summary>
        /// Initializes a new instance of the <see cref="PairEnumerator{T}"/> class.
        /// </summary>
        /// <param name="enum1">An enumerator that goes through the first sequence of objects of type <typeparamref name="T"/>.</param>
        /// <param name="enum2">An enumerator that goes through the second sequence of objects of type <typeparamref name="T"/>.</param>
        public PairEnumerator(IEnumerator<T> enum1, IEnumerator<T> enum2)
        {
            _e1 = enum1;
            _e2 = enum2;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PairEnumerator{T}"/> class.
        /// </summary>
        /// <param name="seq1">The first sequence of objects of type <typeparamref name="T"/>.</param>
        /// <param name="seq2">The second sequence of objects of type <typeparamref name="T"/>.</param>
        public PairEnumerator(IEnumerable<T> seq1, IEnumerable<T> seq2)
        {
            _e1 = seq1.GetEnumerator();
            _e2 = seq2.GetEnumerator();
        }

        /// <summary>
        /// Gets the current pair of objects.
        /// </summary>
        /// <value>The current pair of objects.</value>
        public Pair<T> Current => _current;

        /// <summary>
        /// Disposes the underlying enumerators used to go through the two sequences.
        /// </summary>
        public void Dispose()
        {
            _current = null;
            _e1.Dispose();
            _e2.Dispose();
        }

        object Collections.IEnumerator.Current => _current;

        /// <summary>
        /// Advances the enumerator to the next pair of objects.
        /// </summary>
        /// <returns><c>true</c> if the enumerator was successfully advanced to the next pair; <c>false</c> if the enumerator has passed the end of the collection.</returns>
        public bool MoveNext()
        {
            if (!_e1.MoveNext()) return false;
            if (!_e2.MoveNext()) return false;
            _current = new Pair<T>(_e1.Current, _e2.Current);
            return true;
        }

        /// <summary>
        /// Sets the enumerator to its initial position. Only works if both the enumerators of the two underlying sequences support reset.
        /// </summary>
        public void Reset()
        {
            _e1.Reset();
            _e2.Reset();
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// Gets an enumerator that iterates through two sequences of the different types and yields pairs of objects in the two sequences.
    /// </summary>
    /// <typeparam name="T1">The type of objects in the first sequence.</typeparam>
    /// <typeparam name="T2">The type of objects in the second sequence.</typeparam>
    public class PairEnumerator<T1, T2> : IEnumerator<Pair<T1, T2>>
    {
        IEnumerator<T1> _e1;
        IEnumerator<T2> _e2;
        Pair<T1, T2> _current;

        /// <summary>
        /// Initializes a new instance of the <see cref="PairEnumerator{T}"/> class.
        /// </summary>
        /// <param name="enum1">An enumerator that goes through the first sequence of objects of type <typeparamref name="T1"/>.</param>
        /// <param name="enum2">An enumerator that goes through the second sequence of objects of type <typeparamref name="T2"/>.</param>
        public PairEnumerator(IEnumerator<T1> enum1, IEnumerator<T2> enum2)
        {
            _e1 = enum1;
            _e2 = enum2;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PairEnumerator{T}"/> class.
        /// </summary>
        /// <param name="seq1">The first sequence of objects of type <typeparamref name="T1"/>.</param>
        /// <param name="seq2">The second sequence of objects of type <typeparamref name="T2"/>.</param>
        public PairEnumerator(IEnumerable<T1> seq1, IEnumerable<T2> seq2)
        {
            _e1 = seq1.GetEnumerator();
            _e2 = seq2.GetEnumerator();
        }

        /// <summary>
        /// Gets the current pair of objects.
        /// </summary>
        /// <value>The current pair of objects.</value>
        public Pair<T1, T2> Current => _current;

        /// <summary>
        /// Disposes the underlying enumerators used to go through the two sequences.
        /// </summary>
        public void Dispose()
        {
            _current = null;
            _e1.Dispose();
            _e2.Dispose();
        }

        object Collections.IEnumerator.Current
        {
            get { return _current; }
        }


        /// <summary>
        /// Advances the enumerator to the next pair of objects.
        /// </summary>
        /// <returns><c>true</c> if the enumerator was successfully advanced to the next pair; <c>false</c> if the enumerator has passed the end of the collection.</returns>
        public bool MoveNext()
        {
            if (!_e1.MoveNext()) return false;
            if (!_e2.MoveNext()) return false;
            _current = new Pair<T1, T2>(_e1.Current, _e2.Current);
            return true;
        }

        /// <summary>
        /// Sets the enumerator to its initial position. Only works if both the enumerators of the two underlying sequences support reset.
        /// </summary>
        public void Reset()
        {
            _e1.Reset();
            _e2.Reset();
        }
    }
}