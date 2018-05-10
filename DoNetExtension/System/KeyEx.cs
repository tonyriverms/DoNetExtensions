using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace System
{
    /// <summary>
    /// Serves as a key for a combination of objects.
    /// </summary>
    public class Key
    {
        internal byte[] _bytes;

        /// <summary>
        /// Gets the byte representation of this System.Key object.
        /// </summary>
        /// <returns>An array of bytes equivalent to this System.Key object.</returns>
        public byte[] ToBytes()
        {
            return _bytes.Copy();
        }

        /// <summary>
        /// Gets the length of this System.Key object.
        /// </summary>
        public int Length { get { return _bytes.Length * 8; } }

        /// <summary>
        /// Serves as a hash function for this System.Key object.
        /// </summary>
        /// <returns>A hash code for the current System.Key object.</returns>
        public override int GetHashCode()
        {
            return _bytes.SystemHash();
        }

        /// <summary>
        ///  Determines whether the specified System.Object is equal to the current System.Key.
        /// </summary>
        /// <param name="obj">The System.Object to compare with the current System.Key.</param>
        /// <returns>true if the specified System.Object is equal to the current System.Key;
        /// otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            var anotherKey = obj as Key;
            if (anotherKey == null) return false;
            else
                return _bytes.SequenceEqual(anotherKey._bytes);
        }

        /// <summary>
        /// Initializes a new System.Key instance by a byte array.
        /// <para>!!! Note that the byte array passed into this constructor will be directly stored, not its copy. In other constructors, the copy of the data passed in will stored.</para>
        /// </summary>
        /// <param name="bytes">A byte array.</param>
        public Key(params byte[] bytes)
        {
            _bytes = bytes;
        }

        /// <summary>
        /// Initializes a new System.Key instance by an array of objects. Types supported to initialize a System.Key object include:
        /// <para>1. all system integers, numbers and their array/list (except System.Decimal and its array/list);</para>
        /// <para>2. System.Char and its array/list;</para>
        /// <para>3. System.DateTime and its array/list;</para>
        /// <para>4. System.String and its array/list (encoded by Unicode); </para>
        /// <para>5. a struct whose size is able to be determined by System.Runtime.InteropServices.Marshal.SizeOf method (however, array/list of structs is not supported);</para>
        /// <para>6. any other type that has a method named ToBytes.</para>
        /// </summary>
        /// <param name="bytes">An array of objects.</param>
        public Key(params object[] objs)
        {
            _bytes = objs.ToBytes();
        }

        /// <summary>
        /// Initializes a new System.Key instance by a signed byte array.
        /// </summary>
        /// <param name="bytes">A signed byte array.</param>
        public Key(params sbyte[] bytes)
        {
            _bytes = bytes.ToBytes();
        }

        /// <summary>
        /// Initializes a new System.Key instance by a System.Char array.
        /// </summary>
        /// <param name="array">A System.Char array.</param>
        public Key(params Char[] array)
        {
            _bytes = array.ToBytes();
        }

        /// <summary>
        /// Initializes a new System.Key instance by System.Int16 integers.
        /// </summary>
        /// <param name="values">System.Int16 integers.</param>
        public Key(params Int16[] values)
        {
            _bytes = values.ToBytes();
        }

        /// <summary>
        /// Initializes a new System.Key instance by System.Int32 integers.
        /// </summary>
        /// <param name="values">System.Int32 integers.</param>
        public Key(params Int32[] values)
        {
            _bytes = values.ToBytes();
        }

        /// <summary>
        /// Initializes a new System.Key instance by System.Int64 integers.
        /// </summary>
        /// <param name="values">System.Int64 integers.</param>
        public Key(params Int64[] values)
        {
            _bytes = values.ToBytes();
        }

        /// <summary>
        /// Initializes a new System.Key instance by System.UInt16 integers.
        /// </summary>
        /// <param name="values">System.UInt16 integers.</param>
        public Key(params UInt16[] values)
        {
            _bytes = values.ToBytes();
        }

        /// <summary>
        /// Initializes a new System.Key instance by System.UInt32 integers.
        /// </summary>
        /// <param name="values">System.UInt32 integers.</param>
        public Key(params UInt32[] values)
        {
            _bytes = values.ToBytes();
        }

        /// <summary>
        /// Initializes a new System.Key instance by System.UInt64 integers.
        /// </summary>
        /// <param name="values">System.UInt64 integers.</param>
        public Key(params UInt64[] values)
        {
            _bytes = values.ToBytes();
        }

        /// <summary>
        /// Initializes a new System.Key instance by System.Singles.
        /// </summary>
        /// <param name="values">System.Singles.</param>
        public Key(params Single[] values)
        {
            _bytes = values.ToBytes();
        }

        /// <summary>
        /// Initializes a new System.Key instance by System.Doubles.
        /// </summary>
        /// <param name="values">System.Doubles.</param>
        public Key(params Double[] values)
        {
            _bytes = values.ToBytes();
        }

        /// <summary>
        /// Initializes a new System.Key instance by System.DateTimes.
        /// </summary>
        /// <param name="values">System.DateTimes.</param>
        public Key(params DateTime[] values)
        {
            _bytes = values.ToBytes();
        }
    }
}
