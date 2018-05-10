using System;
using System.Collections.Generic;
using System.IO;

namespace System
{
    /// <summary>
    /// The base class for classes representing a pair of values.
    /// </summary>
    /// <typeparam name="T1">The type of the first value or object.</typeparam>
    /// <typeparam name="T2">The type of the second value or object.</typeparam>
    public abstract class PairValueBase<T1, T2>
    {
        protected T1 Value1;
        protected T2 Value2;

        /// <summary>
        /// Initializes a new instance of the <see cref="PairValueBase&lt;T1, T2&gt;"/> class.
        /// </summary>
        protected PairValueBase() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PairValueBase&lt;T1, T2&gt;"/> class.
        /// </summary>
        /// <param name="value1">The first value or object.</param>
        /// <param name="value2">The second value of object.</param>
        protected PairValueBase(T1 value1, T2 value2)
        {
            Value1 = value1;
            Value2 = value2;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <c>true</c> if the specified <see cref="System.Object" /> is also a <see cref="System.PairValueBase&lt;T1, T2&gt;"/> with the same parameter types as this instance, 
        /// and both <c>Value1</c> and <c>Value2</c> of the specified <see cref="System.PairValueBase&lt;T1, T2&gt;" /> are respectively equal to the <c>Value1</c> and <c>Value2</c> of this instance; 
        /// otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            var target = obj as PairValueBase<T1, T2>;
            if (target == null)
                return false;
            else return this.Value1.Equals(target.Value1) && this.Value2.Equals(target.Value2);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            var code1 = Value1.GetHashCode();
            var code2 = Value2.GetHashCode();
            return (int)((UInt32)(code1 & 0xFFFF0000) | (UInt32)(code2 & 0x0000FFFF));
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
            return "{0}{1}{2}".Scan(Value1, separator, Value2);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "{0},{1}".Scan(Value1, Value2);
        }

        public static implicit operator KeyValuePair<T1, T2>(PairValueBase<T1, T2> pairBase)
        {
            return new KeyValuePair<T1, T2>(pairBase.Value1, pairBase.Value2);
        }
    }

    /// <summary>
    /// Represents two values or objects of the same type in pair.
    /// </summary>
    /// <typeparam name="T">The type of the two values or objects.</typeparam>
    public class Pair<T> : PairValueBase<T, T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pair{T}"/> class.
        /// </summary>
        public Pair() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pair{T}"/> class.
        /// </summary>
        /// <param name="firstValue">The first value or object.</param>
        /// <param name="secondValue">The second value or object.</param>
        public Pair(T firstValue, T secondValue)
            : base(firstValue, secondValue) { }

        /// <summary>
        /// Gets the first value or object.
        /// </summary>
        public T First { get { return Value1; } set { Value1 = value; } }

        /// <summary>
        /// Gets the second value or object.
        /// </summary>
        public T Second { get { return Value2; } set { Value2 = value; } }

        public static implicit operator Pair<T>(KeyValuePair<T, T> pair)
        {
            return new Pair<T>(pair.Key, pair.Value);
        }
    }

    /// <summary>
    /// Represents two values or objects of different types in pair.
    /// </summary>
    /// <typeparam name="T1">The type of the first value or object.</typeparam>
    /// <typeparam name="T2">The type of the second value or object.</typeparam>
    public class Pair<T1, T2> : PairValueBase<T1, T2>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pair&lt;T1, T2&gt;"/> class.
        /// </summary>
        public Pair() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pair&lt;T1, T2&gt;"/> class.
        /// </summary>
        /// <param name="firstValue">The first value or object.</param>
        /// <param name="secondValue">The second value or object.</param>
        public Pair(T1 firstValue, T2 secondValue)
            : base(firstValue, secondValue)
        {
        }

        /// <summary>
        /// Gets the first value or object.
        /// </summary>
        public T1 First
        {
            get { return Value1; }
            set { Value1 = value; }
        }

        /// <summary>
        /// Gets the second value or object.
        /// </summary>
        public T2 Second
        {
            get { return Value2; }
            set { Value2 = value; }
        }

        public static implicit operator Pair<T1, T2>(KeyValuePair<T1, T2> pair)
        {
            return new Pair<T1, T2>(pair.Key, pair.Value);
        }
    }

    /// <summary>
    /// Represents a range defined by two comparable values or objects.
    /// </summary>
    /// <typeparam name="T">The <see cref="IComparable"/> type of the bounds of this range.</typeparam>
    public class Range<T> : PairValueBase<T, T> where T : IComparable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Range{T}"/> class.
        /// </summary>
        protected Range() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="System.Range{T}"/> class.
        /// </summary>
        /// <param name="lowerBound">The lower bound of this range.</param>
        /// <param name="higherBound">The higher bound of this range.</param>
        public Range(T lowerBound, T higherBound) 
        {
            if (lowerBound.CompareTo(higherBound) <= 0) { Value1 = lowerBound; Value2 = higherBound; }
            else throw new ArgumentException();
        }

        /// <summary>
        /// Gets or sets the lower bound of this range.
        /// </summary>
        public T LowerBound
        {
            get { return Value1; }
            set { if (Value1.CompareTo(Value2) > 0) throw new InvalidOperationException(); Value1 = value; }
        }

        /// <summary>
        /// Gets or sets the upper bound of this range.
        /// </summary>
        public T UpperBound
        {
            get { return Value2; }
            set { if (Value2.CompareTo(Value1) < 0) throw new InvalidOperationException(); Value2 = value; }
        }

        /// <summary>
        /// Determines whether this range can enclose another range.
        /// </summary>
        /// <param name="range">Another range.</param>
        /// <returns><c>true</c> if the given range can be enclosed; otherwise <c>false</c>.</returns>
        public bool CanEnclose(Range<T> range)
        {
            return Value1.CompareTo(range.Value1) <= 0 && Value2.CompareTo(range.Value2) >= 0;
        }

        /// <summary>
        /// Identifys whether this range can enclose a given value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if the given value can be enclosed; otherwise <c>false</c>.</returns>
        public bool CanEnclose(T value)
        {
            return Value1.CompareTo(value) <= 0 && Value2.CompareTo(value) >= 0;
        }

        /// <summary>
        /// Enlarges this range.
        /// </summary>
        /// <param name="value">If this value is smaller than the lower bound of this range, the lower bound decreases to this value. 
        /// Likewise the higher bound.</param>
        public void Enlarge(T value)
        {
            if (Value1.CompareTo(value) > 0) Value1 = value;
            else if (Value2.CompareTo(value) < 0) Value2 = value;
        }

        /// <summary>
        /// Enlarges this range.
        /// </summary>
        /// <param name="range">Another range which this range will be enlarged to rightly contain.</param>
        public void Enlarge(Range<T> range)
        {
            if (Value1.CompareTo(range.Value1) > 0) Value1 = range.Value1;
            if (Value2.CompareTo(range.Value2) < 0) Value2 = range.Value2;
        }

        /// <summary>
        /// Reduces this range.
        /// </summary>
        /// <param name="range">Another range which this range will be reduced to be rightly contained.</param>
        public void Reduce(Range<T> range)
        {
            if (Value1.CompareTo(range.Value1) < 0) Value1 = range.Value1;
            if (Value2.CompareTo(range.Value2) > 0) Value2 = range.Value2;
        }

        /// <summary>
        /// Determines if this range intersects with another range.
        /// </summary>
        /// <param name="anotherRange">Another range.</param>
        /// <returns><c>true</c> if this range intersects with another range provided; otherwise <c>false</c>.</returns>
        public bool IntersectWith(Range<T> anotherRange)
        {
            return ((LowerBound.CompareTo(anotherRange.LowerBound) >= 0 && LowerBound.CompareTo(anotherRange.UpperBound) <= 0) ||
                (UpperBound.CompareTo(anotherRange.UpperBound) <= 0 && UpperBound.CompareTo(anotherRange.LowerBound) >= 0) ||
                (LowerBound.CompareTo(anotherRange.LowerBound) <= 0 && UpperBound.CompareTo(anotherRange.UpperBound) >= 0));
        }

        public static bool operator >(Range<T> range1, Range<T> range2)
        {
            return range1.Value1.CompareTo(range2.Value2) > 0;
        }

        public static bool operator >=(Range<T> range1, Range<T> range2)
        {
            return range1.Value1.CompareTo(range2.Value2) > 0 ||
                (range1.Value1.CompareTo(range2.Value1) == 0 && range1.Value2.CompareTo(range2.Value2) == 0);
        }

        public static bool operator <(Range<T> range1, Range<T> range2)
        {
            return range1.Value2.CompareTo(range2.Value1) < 0;
        }

        public static bool operator <=(Range<T> range1, Range<T> range2)
        {
            return range1.Value2.CompareTo(range2.Value1) < 0 ||
                (range1.Value1.CompareTo(range2.Value1) == 0 && range1.Value2.CompareTo(range2.Value2) == 0);
        }

        public static bool operator ==(Range<T> range1, Range<T> range2)
        {
            return (range1 == null && range2 == null) || range1.Value1.CompareTo(range2.Value1) == 0 && range1.Value2.CompareTo(range2.Value2) == 0;
        }

        public static bool operator !=(Range<T> range1, Range<T> range2)
        {
            return (range1 == null && range2 == null) || range1.Value1.CompareTo(range2.Value1) != 0 || range1.Value2.CompareTo(range2.Value2) != 0;
        }
    }

     public class PairEnumerator<T> : IEnumerator<Pair<T>>
     {
         IEnumerator<T> _e1;
         IEnumerator<T> _e2;
         Pair<T> _current;

         public PairEnumerator(IEnumerator<T> enum1, IEnumerator<T> enum2)
         {
             _e1 = enum1;
             _e2 = enum2;
         }

         public PairEnumerator(IEnumerable<T> collection1, IEnumerable<T> collection2)
         {
             _e1 = collection1.GetEnumerator();
             _e2 = collection2.GetEnumerator();
         }

         public Pair<T> Current
         {
             get { return _current; }
         }

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

         public bool MoveNext()
         {
             if (!_e1.MoveNext()) return false;
             if (!_e2.MoveNext()) return false;
             _current = new Pair<T>(_e1.Current, _e2.Current);
             return true;
         }

         public void Reset()
         {
             _e1.Reset();
             _e2.Reset();
         }
     }

    public class PairEnumerator<T1, T2> : IEnumerator<Pair<T1, T2>>
    {
        IEnumerator<T1> _e1;
        IEnumerator<T2> _e2;

        public PairEnumerator(IEnumerator<T1> enum1, IEnumerator<T2> enum2)
        {
            _e1 = enum1;
            _e2 = enum2;
        }

        public PairEnumerator(IEnumerable<T1> collection1, IEnumerable<T2> collection2)
        {
            _e1 = collection1.GetEnumerator();
            _e2 = collection2.GetEnumerator();
        }

        Pair<T1, T2> _current;
        public Pair<T1, T2> Current
        {
            get { return _current; }
        }

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

        public bool MoveNext()
        {
            if (!_e1.MoveNext()) return false;
            if (!_e2.MoveNext()) return false;
            _current = new Pair<T1, T2>(_e1.Current, _e2.Current);
            return true;
        }

        public void Reset()
        {
            _e1.Reset();
            _e2.Reset();
        }
    }
}