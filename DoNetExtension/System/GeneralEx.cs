using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.CompilerServices;

namespace System
{
    public enum HashAlgorithms
    {
        DefaultStringHash,
        MurmurHash2,
        MurmurHash3
    }

    public class WeakReferenceAsKey : WeakReference
    {
        public WeakReferenceAsKey(object target) : base(target) { }

        public override int GetHashCode()
        {
            if (IsAlive)
                return Target.GetHashCode();
            else throw new InvalidOperationException();
        }

        public override bool Equals(object obj)
        {
            if (IsAlive)
                return Target.Equals(obj);
            else throw new InvalidOperationException();
        }
    }

    /// <summary>
    /// Provides extension methods for a variety of built-in framework classes.
    /// </summary>
    public static partial class GeneralEx
    {


        #region Swap

        /// <summary>
        /// Swaps the values of two long integers.
        /// </summary>
        /// <param name="x">The first long integer.</param>
        /// <param name="y">The second long integer.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap(this ref long x, ref long y)
        {
            x ^= y;
            y ^= x;
            x ^= y;
        }


        /// <summary>
        /// Swaps the values of two unsigned long integers.
        /// </summary>
        /// <param name="x">The first unsigned long integer.</param>
        /// <param name="y">The second unsigned long integer.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap(this ref ulong x, ref ulong y)
        {
            x ^= y;
            y ^= x;
            x ^= y;
        }

        /// <summary>
        /// Swaps the values of two integers.
        /// </summary>
        /// <param name="x">The first integer.</param>
        /// <param name="y">The second integer.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap(this ref int x, ref int y)
        {
            x ^= y;
            y ^= x;
            x ^= y;
        }

        /// <summary>
        /// Swaps the values of two unsigned integers.
        /// </summary>
        /// <param name="x">The first unsigned integer.</param>
        /// <param name="y">The second unsigned integer.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap(this ref uint x, ref uint y)
        {
            x ^= y;
            y ^= x;
            x ^= y;
        }


        /// <summary>
        /// Swaps the values of two short integers.
        /// </summary>
        /// <param name="x">The first short integer.</param>
        /// <param name="y">The second short integer.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap(this ref short x, ref short y)
        {
            x ^= y;
            y ^= x;
            x ^= y;
        }

        /// <summary>
        /// Swaps the values of two unsigned short integers.
        /// </summary>
        /// <param name="x">The first unsigned short integer.</param>
        /// <param name="y">The second unsigned short integer.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap(this ref ushort x, ref ushort y)
        {
            x ^= y;
            y ^= x;
            x ^= y;
        }

        /// <summary>
        /// Swaps the values of two bytes.
        /// </summary>
        /// <param name="x">The first byte.</param>
        /// <param name="y">The second byte.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap(this ref byte x, ref byte y)
        {
            x ^= y;
            y ^= x;
            x ^= y;
        }


        /// <summary>
        /// Swaps the values of two signed bytes.
        /// </summary>
        /// <param name="x">The first signed byte.</param>
        /// <param name="y">The second signed byte.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap(this ref sbyte x, ref sbyte y)
        {
            x ^= y;
            y ^= x;
            x ^= y;
        }

        /// <summary>
        /// Swaps the values of two characters.
        /// </summary>
        /// <param name="x">The first character.</param>
        /// <param name="y">The second character.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap(this ref char x, ref char y)
        {
            x ^= y;
            y ^= x;
            x ^= y;
        }

        /// <summary>
        /// Swaps the values of two bool values.
        /// </summary>
        /// <param name="x">The first bool value.</param>
        /// <param name="y">The second bool value.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap(this ref bool x, ref bool y)
        {
            x ^= y;
            y ^= x;
            x ^= y;
        }

        /// <summary>
        /// Swaps the values of two <see cref="float"/> values.
        /// </summary>
        /// <param name="x">The first <see cref="float"/> value.</param>
        /// <param name="y">The second <see cref="float"/> value.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap(this ref float x, ref float y)
        {
            var z = x;
            x = y;
            y = z;
        }


        /// <summary>
        /// Swaps the values of two <see cref="double"/> values.
        /// </summary>
        /// <param name="x">The first <see cref="double"/> value.</param>
        /// <param name="y">The second <see cref="double"/> value.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap(this ref double x, ref double y)
        {
            var z = x;
            x = y;
            y = z;
        }

        /// <summary>
        /// Swaps the values of two <see cref="DateTime"/> values.
        /// </summary>
        /// <param name="x">The first <see cref="DateTime"/> value.</param>
        /// <param name="y">The second <see cref="DateTime"/> value.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap(this ref DateTime x, ref DateTime y)
        {
            var z = x;
            x = y;
            y = z;
        }

        /// <summary>
        /// Swaps the values of two <see cref="DateTime"/> values.
        /// </summary>
        /// <param name="x">The first <see cref="DateTime"/> value.</param>
        /// <param name="y">The second <see cref="DateTime"/> value.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap<T>(this ref T x, ref T y) where T : struct
        {
            var z = x;
            x = y;
            y = z;
        }

        #endregion

        #region In

        /// <summary>
        /// Determines whether this string is a substring of another string instance.
        /// </summary>
        /// <param name="str">The current string.</param>
        /// <param name="target">Checks if this string contains the current string as a substring.</param>
        /// <returns>
        ///   <c>true</c> if <paramref name="target"/> contains the current string as a substring; otherwise, <c>false</c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool In(this string str, string target)
        {
            return target.Contains(str);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool InAny(this string str, string[] targets, StringComparison comparison = StringComparison.Ordinal)
        {
            var count = targets.Length;
            for (var i = 0; i < count; ++i)
                if (targets[i] != null && targets[i].Contains(str, comparison)) return true;
            return false;
        }

        /// <summary>
        /// Determines whether this object is in a sequence. If the sequence is null or empty, <c>false</c> is always returned.
        /// </summary>
        /// <typeparam name="T">The type of this object.</typeparam>
        /// <param name="obj">This object.</param>
        /// <param name="sequence">A sequence of objects.</param>
        /// <returns><c>true</c> if this object is found in the specified sequence; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool In<T>(this T obj, IEnumerable<T> sequence)
        {
            return sequence != null && sequence.Contains(obj);
        }

        /// <summary>
        /// Determines whether this object is in any of the provided sequences. If <paramref name="sequences"/> is null or empty, <c>false</c> is always returned.
        /// </summary>
        /// <typeparam name="T">The type of this object.</typeparam>
        /// <param name="obj">This object.</param>
        /// <param name="sequences">An array of sequences to check.</param>
        /// <returns><c>true</c> if this object is found in any of the provided sequences; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool InAny<T>(this T obj, params IEnumerable<T>[] sequences)
        {
            if (sequences.IsNullOrEmpty()) return false;
            foreach (var seq in sequences)
            {
                if (obj.In(seq))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Determines whether this object is in all of the provided sequences. If <paramref name="sequences"/> is null or empty, <c>false</c> is always returned.
        /// </summary>
        /// <typeparam name="T">The type of this object.</typeparam>
        /// <param name="obj">This object.</param>
        /// <param name="sequences">An array of sequences to check.</param>
        /// <returns><c>true</c> if this object is found in all of the provided sequences; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool InAll<T>(this T obj, params IEnumerable<T>[] sequences)
        {
            if (sequences.IsNullOrEmpty()) return false;
            foreach (var seq in sequences)
            {
                if (!obj.In(seq))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Determines whether this object is a key in a dictionary. If the dictionary is null or empty, <c>false</c> is always returned.
        /// </summary>
        /// <typeparam name="T">The type of the object as well as the key of the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of value of the dictionary.</typeparam>
        /// <param name="obj">This object.</param>
        /// <param name="dict">The dictionary.</param>
        /// <returns><c>true</c> if <paramref name="obj"/> is a key in <paramref name="dict"/>, <c>false</c> otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool In<T, TValue>(this T obj, IDictionary<T, TValue> dict)
        {
            return dict != null && dict.ContainsKey(obj);
        }

        /// <summary>
        /// Determines whether this object is a key in any of the provided dictionaries. If the <paramref name="dicts"/> is null or empty, <c>false</c> is always returned.
        /// </summary>
        /// <typeparam name="T">The type of the object as well as the key of the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of value of the dictionary.</typeparam>
        /// <param name="obj">This object.</param>
        /// <param name="dicts">The dictionaryies to check.</param>
        /// <returns><c>true</c> if <paramref name="obj"/> is a key in any of the provided <paramref name="dicts"/>, <c>false</c> otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool InAny<T, TValue>(this T obj, params IDictionary<T, TValue>[] dicts)
        {
            if (dicts.IsNullOrEmpty()) return false;
            foreach (var dict in dicts)
            {
                if (obj.In(dict))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Determines whether this object is a key in all of the provided dictionaries. If the <paramref name="dicts"/> is null or empty, <c>false</c> is always returned.
        /// </summary>
        /// <typeparam name="T">The type of the object as well as the key of the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of value of the dictionary.</typeparam>
        /// <param name="obj">This object.</param>
        /// <param name="dicts">The dictionaryies to check.</param>
        /// <returns><c>true</c> if <paramref name="obj"/> is a key in all of the provided <paramref name="dicts"/>, <c>false</c> otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool InAll<T, TValue>(this T obj, params IDictionary<T, TValue>[] dicts)
        {
            if (dicts.IsNullOrEmpty()) return false;
            foreach (var dict in dicts)
            {
                if (!obj.In(dict))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Determines whether this object is in an array/list. If the array/list is null or empty, this method always returns <c>false</c>.
        /// </summary>
        /// <typeparam name="T">The type of this object.</typeparam>
        /// <param name="obj">This object.</param>
        /// <param name="list">An array/list of objects.</param>
        /// <returns><c>true</c> if this object is in the specified array/list; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool In<T>(this T obj, IList<T> list)
        {
            return list != null && list.Contains(obj);
        }

        /// <summary>
        /// Determines whether this object is in an array of objects. NOTE that if the array is <c>null</c> or empty, this method always returns <c>false</c>.
        /// </summary>
        /// <typeparam name="T">The type of this object.</typeparam>
        /// <param name="obj">This object.</param>
        /// <param name="array">An array of objects.</param>
        /// <returns><c>true</c> if this object is in the specified array; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool In<T>(this T obj, params T[] array)
        {
            return array != null && Array.IndexOf(array, obj) != -1;
        }

        /// <summary>
        /// Determines whether this comparable object is in a range. The lowerbound is included; the upperbound is excluded.
        /// <para>For example, either 1 or 2 is in the range from 1 to 3, but 3 is not in the range from 1 to 3.</para>
        /// </summary>
        /// <typeparam name="T">A type that implements <see cref="System.IComparable{T}"/> interface.</typeparam>
        /// <param name="obj">This comparable object.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <returns><c>true</c> if this comparable object is inside the range specified by <paramref name="lowerBound"/> and <paramref name="upperBound"/>; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool In<T>(this T obj, T lowerBound, T upperBound) where T : IComparable<T>
        {
            return obj.CompareTo(lowerBound) >= 0 && obj.CompareTo(upperBound) < 0;
        }

        /// <summary>
        /// Determines whether this byte is in a range. The lowerbound is included; the upperbound is excluded.
        /// <para>For example, either 1 or 2 is in the range from 1 to 3, but 3 is not in the range from 1 to 3.</para>
        /// </summary>
        /// <param name="val">This byte.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <returns><c>true</c> if this byte is inside the range specified by <paramref name="lowerBound"/> and <paramref name="upperBound"/>; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool In(this byte val, byte lowerBound, byte upperBound)
        {
            return val >= lowerBound && val < upperBound;
        }

        /// <summary>
        /// Determines whether this byte is in a range with steps. The lowerbound is included; the upperbound is excluded.
        /// <para>For example, either 1 or 3 is in the range from 1 to 5 with step 2, but 5 is not in this range with step.</para></summary>
        /// <param name="val">This byte.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <param name="step">The step size of the range.</param>
        /// <returns>
        ///   <c>true</c> if this byte is inside the range specified by <paramref name="lowerBound" /> and <paramref name="upperBound" /> with step <paramref name="step"/>; otherwise, <c>false</c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool In(this byte val, byte lowerBound, byte upperBound, byte step)
        {
            return val >= lowerBound && val < upperBound && (val - lowerBound) % step == 0;
        }

        /// <summary>
        /// Determines whether this signed byte is in a range. The lowerbound is included; the upperbound is excluded.
        /// <para>For example, either 1 or 2 is in the range from 1 to 3, but 3 is not in the range from 1 to 3.</para>
        /// </summary>
        /// <param name="val">This signed byte.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <returns><c>true</c> if this signed byte is inside the range specified by <paramref name="lowerBound"/> and <paramref name="upperBound"/>; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool In(this sbyte val, sbyte lowerBound, sbyte upperBound)
        {
            return val >= lowerBound && val < upperBound;
        }

        /// <summary>
        /// Determines whether this signed byte is in a range with steps. The lowerbound is included; the upperbound is excluded.
        /// <para>For example, either 1 or 3 is in the range from 1 to 5 with step 2, but 5 is not in this range with step.</para></summary>
        /// <param name="val">This signed byte.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <param name="step">The step size of the range.</param>
        /// <returns>
        ///   <c>true</c> if this signed byte is inside the range specified by <paramref name="lowerBound" /> and <paramref name="upperBound" /> with step <paramref name="step"/>; otherwise, <c>false</c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool In(this sbyte val, sbyte lowerBound, sbyte upperBound, sbyte step)
        {
            return val >= lowerBound && val < upperBound && (val - lowerBound) % step == 0;
        }

        /// <summary>
        /// Determines whether this integer is in a range. The lowerbound is included; the upperbound is excluded.
        /// <para>For example, either 1 or 2 is in the range from 1 to 3, but 3 is not in the range from 1 to 3.</para>
        /// </summary>
        /// <param name="val">This integer.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <returns><c>true</c> if this integer is inside the range specified by <paramref name="lowerBound"/> and <paramref name="upperBound"/>; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool In(this short val, short lowerBound, short upperBound)
        {
            return val >= lowerBound && val < upperBound;
        }

        /// <summary>
        /// Determines whether this integer is in a range with steps. The lowerbound is included; the upperbound is excluded.
        /// <para>For example, either 1 or 3 is in the range from 1 to 5 with step 2, but 5 is not in this range with step.</para></summary>
        /// <param name="val">This integer.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <param name="step">The step size of the range.</param>
        /// <returns>
        ///   <c>true</c> if this integer is inside the range specified by <paramref name="lowerBound" /> and <paramref name="upperBound" /> with step <paramref name="step"/>; otherwise, <c>false</c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool In(this short val, short lowerBound, short upperBound, short step)
        {
            return val >= lowerBound && val < upperBound && (val - lowerBound) % step == 0;
        }

        /// <summary>
        /// Determines whether this integer is in a range. The lowerbound is included; the upperbound is excluded.
        /// <para>For example, either 1 or 2 is in the range from 1 to 3, but 3 is not in the range from 1 to 3.</para>
        /// </summary>
        /// <param name="val">This integer.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <returns><c>true</c> if this integer is inside the range specified by <paramref name="lowerBound"/> and <paramref name="upperBound"/>; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool In(this ushort val, short lowerBound, ushort upperBound)
        {
            return val >= lowerBound && val < upperBound;
        }

        /// <summary>
        /// Determines whether this integer is in a range with steps. The lowerbound is included; the upperbound is excluded.
        /// <para>For example, either 1 or 3 is in the range from 1 to 5 with step 2, but 5 is not in this range with step.</para></summary>
        /// <param name="val">This integer.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <param name="step">The step size of the range.</param>
        /// <returns>
        ///   <c>true</c> if this integer is inside the range specified by <paramref name="lowerBound" /> and <paramref name="upperBound" /> with step <paramref name="step"/>; otherwise, <c>false</c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool In(this ushort val, ushort lowerBound, ushort upperBound, ushort step)
        {
            return val >= lowerBound && val < upperBound && (val - lowerBound) % step == 0;
        }

        /// <summary>
        /// Determines whether this integer is in a range. The lowerbound is included; the upperbound is excluded.
        /// <para>For example, either 1 or 2 is in the range from 1 to 3, but 3 is not in the range from 1 to 3.</para>
        /// </summary>
        /// <param name="val">This integer.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <returns><c>true</c> if this integer is inside the range specified by <paramref name="lowerBound"/> and <paramref name="upperBound"/>; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool In(this int val, int lowerBound, int upperBound)
        {
            return val >= lowerBound && val < upperBound;
        }

        /// <summary>
        /// Determines whether this integer is in a range with steps. The lowerbound is included; the upperbound is excluded.
        /// <para>For example, either 1 or 3 is in the range from 1 to 5 with step 2, but 5 is not in this range with step.</para></summary>
        /// <param name="val">This integer.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <param name="step">The step size of the range.</param>
        /// <returns>
        ///   <c>true</c> if this integer is inside the range specified by <paramref name="lowerBound" /> and <paramref name="upperBound" /> with step <paramref name="step"/>; otherwise, <c>false</c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool In(this int val, int lowerBound, int upperBound, int step)
        {
            return val >= lowerBound && val < upperBound && (val - lowerBound) % step == 0;
        }

        /// <summary>
        /// Determines whether this integer is in a range. The lowerbound is included; the upperbound is excluded.
        /// <para>For example, either 1 or 2 is in the range from 1 to 3, but 3 is not in the range from 1 to 3.</para>
        /// </summary>
        /// <param name="val">This integer.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <returns><c>true</c> if this integer is inside the range specified by <paramref name="lowerBound"/> and <paramref name="upperBound"/>; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool In(this uint val, uint lowerBound, uint upperBound)
        {
            return val >= lowerBound && val < upperBound;
        }

        /// <summary>
        /// Determines whether this integer is in a range with steps. The lowerbound is included; the upperbound is excluded.
        /// <para>For example, either 1 or 3 is in the range from 1 to 5 with step 2, but 5 is not in this range with step.</para></summary>
        /// <param name="val">This integer.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <param name="step">The step size of the range.</param>
        /// <returns>
        ///   <c>true</c> if this integer is inside the range specified by <paramref name="lowerBound" /> and <paramref name="upperBound" /> with step <paramref name="step"/>; otherwise, <c>false</c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool In(this uint val, uint lowerBound, uint upperBound, uint step)
        {
            return val >= lowerBound && val < upperBound && (val - lowerBound) % step == 0;
        }

        /// <summary>
        /// Determines whether this integer is in a range. The lowerbound is included; the upperbound is excluded.
        /// <para>For example, either 1 or 2 is in the range from 1 to 3, but 3 is not in the range from 1 to 3.</para>
        /// </summary>
        /// <param name="val">This integer.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <returns><c>true</c> if this integer is inside the range specified by <paramref name="lowerBound"/> and <paramref name="upperBound"/>; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool In(this long val, long lowerBound, long upperBound)
        {
            return val >= lowerBound & val < upperBound;
        }

        /// <summary>
        /// Determines whether this integer is in a range with steps. The lowerbound is included; the upperbound is excluded.
        /// <para>For example, either 1 or 3 is in the range from 1 to 5 with step 2, but 5 is not in this range with step.</para></summary>
        /// <param name="val">This integer.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <param name="step">The step size of the range.</param>
        /// <returns>
        ///   <c>true</c> if this integer is inside the range specified by <paramref name="lowerBound" /> and <paramref name="upperBound" /> with step <paramref name="step"/>; otherwise, <c>false</c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool In(this long val, long lowerBound, long upperBound, long step)
        {
            return val >= lowerBound && val < upperBound && (val - lowerBound) % step == 0;
        }

        /// <summary>
        /// Determines whether this integer is in a range. The lowerbound is included; the upperbound is excluded.
        /// <para>For example, either 1 or 2 is in the range from 1 to 3, but 3 is not in the range from 1 to 3.</para>
        /// </summary>
        /// <param name="val">This integer.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <returns><c>true</c> if this integer is inside the range specified by <paramref name="lowerBound"/> and <paramref name="upperBound"/>; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool In(this ulong val, ulong lowerBound, ulong upperBound)
        {
            return val >= lowerBound && val < upperBound;
        }

        /// <summary>
        /// Determines whether this integer is in a range with steps. The lowerbound is included; the upperbound is excluded.
        /// <para>For example, either 1 or 3 is in the range from 1 to 5 with step 2, but 5 is not in this range with step.</para></summary>
        /// <param name="val">This integer.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <param name="step">The step size of the range.</param>
        /// <returns>
        ///   <c>true</c> if this integer is inside the range specified by <paramref name="lowerBound" /> and <paramref name="upperBound" /> with step <paramref name="step"/>; otherwise, <c>false</c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool In(this ulong val, ulong lowerBound, ulong upperBound, ulong step)
        {
            return val >= lowerBound && val < upperBound && (val - lowerBound) % step == 0;
        }

        /// <summary>
        /// Determines whether this floating number is in a range. The lowerbound is included; the upperbound is excluded.
        /// <para>For example, either 1 or 1.5 is in the range from 1.0 to 3.0, but 3.0 is not in the range from 1.0 to 3.0.</para>
        /// </summary>
        /// <param name="val">This floating number.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <returns><c>true</c> if this floating number is inside the range specified by <paramref name="lowerBound"/> and <paramref name="upperBound"/>; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool In(this double val, double lowerBound, double upperBound)
        {
            return val >= lowerBound && val < upperBound;
        }

        /// <summary>
        /// Determines whether this floating number is in a range. The lowerbound is included; the upperbound is excluded.
        /// <para>For example, either 1 or 1.5 is in the range from 1.0 to 3.0, but 3.0 is not in the range from 1.0 to 3.0.</para>
        /// </summary>
        /// <param name="val">This floating number.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <returns><c>true</c> if this floating number is inside the range specified by <paramref name="lowerBound"/> and <paramref name="upperBound"/>; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool In(this float val, float lowerBound, float upperBound)
        {
            return val >= lowerBound && val < upperBound;
        }

        /// <summary>
        /// Determines whether this <see cref="Decimal"/> is in a range. The lowerbound is included; the upperbound is excluded.
        /// <para>For example, either 1 or 1.5 is in the range from 1.0 to 3.0, but 3.0 is not in the range from 1.0 to 3.0.</para>
        /// </summary>
        /// <param name="val">This <see cref="Decimal"/> number.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <returns><c>true</c> if this <see cref="Decimal"/> number is inside the range specified by <paramref name="lowerBound"/> and <paramref name="upperBound"/>; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool In(this decimal val, decimal lowerBound, decimal upperBound)
        {
            return val >= lowerBound && val < upperBound;
        }

        /// <summary>
        /// Determines whether this <see cref="DateTime"/> is in a range. The lowerbound is included; the upperbound is excluded.
        /// <para>For example, either "12:00, March 21, 2018" or "14:00, March 21, 2018" is in the range from "12:00, March 21, 2018" to "23:00, March 21, 2018", but "23:00, March 21, 2018" is not in this range.</para>
        /// </summary>
        /// <param name="val">This <see cref="DateTime"/>.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <returns><c>true</c> if this provided <see cref="DateTime"/> is inside the range specified by <paramref name="lowerBound"/> and <paramref name="upperBound"/>; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool In(this DateTime val, DateTime lowerBound, DateTime upperBound)
        {
            return val >= lowerBound && val < upperBound;
        }

        #endregion

        #region Between

        /// <summary>
        /// Determines whether this comparable object is inclusively between two bounds.
        /// <para>For example, both 1,2 is inclusively between 1 and 3.</para>
        /// </summary>
        /// <typeparam name="T">A type that conforms to System.IComparable{T} interface.</typeparam>
        /// <param name="obj">This comparable object.</param>
        /// <param name="lowerBound">The lower bound to compare.</param>
        /// <param name="upperBound">The upper bound to compare.</param>
        /// <returns>true if this comparable object is inclusively between the given bounds; otherwise, false.</returns>
        public static bool InclusiveBetween<T>(this T obj, T lowerBound, T upperBound) where T : IComparable<T>
        {
            return obj.CompareTo(lowerBound) >= 0 && obj.CompareTo(upperBound) <= 0;
        }

        /// <summary>
        /// Determines whether this comparable object is between two bounds.
        /// <para>For example, both 2 is between 1 and 3, but 1 is not between 1 and 3.</para>
        /// </summary>
        /// <typeparam name="T">A type that conforms to System.IComparable{T} interface.</typeparam>
        /// <param name="obj">This comparable object.</param>
        /// <param name="lowerBound">The lower bound to compare.</param>
        /// <param name="upperBound">The upper bound to compare.</param>
        /// <returns>true if this comparable object is between the given bounds; otherwise, false.</returns>
        public static bool Between<T>(this T obj, T lowerBound, T upperBound) where T : IComparable<T>
        {
            return obj.CompareTo(lowerBound) > 0 && obj.CompareTo(upperBound) < 0;
        }


        #endregion


        #region NotIn

        /// <summary>
        /// Determines whether this object is in a sequence. If the sequence is null or empty, <c>false</c> is always returned.
        /// </summary>
        /// <typeparam name="T">The type of this object.</typeparam>
        /// <param name="obj">This object.</param>
        /// <param name="sequence">A sequence of objects.</param>
        /// <returns><c>true</c> if this object is found in the specified sequence; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotIn<T>(this T obj, IEnumerable<T> sequence)
        {
            return sequence == null || !sequence.Contains(obj);
        }

        /// <summary>
        /// Determines whether this object is a key in a dictionary. If the dictionary is null or empty, <c>false</c> is always returned.
        /// </summary>
        /// <typeparam name="T">The type of the object as well as the key of the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of value of the dictionary.</typeparam>
        /// <param name="obj">This object.</param>
        /// <param name="dict">The dictionary.</param>
        /// <returns><c>true</c> if <paramref name="obj"/> is a key in <paramref name="dict"/>, <c>false</c> otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotIn<T, TValue>(this T obj, IDictionary<T, TValue> dict)
        {
            return dict == null || !dict.ContainsKey(obj);
        }

        /// <summary>
        /// Determines whether this object is in an array/list. If the array/list is null or empty, this method always returns <c>false</c>.
        /// </summary>
        /// <typeparam name="T">The type of this object.</typeparam>
        /// <param name="obj">This object.</param>
        /// <param name="list">An array/list of objects.</param>
        /// <returns><c>true</c> if this object is in the specified array/list; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotIn<T>(this T obj, IList<T> list)
        {
            return list == null || !list.Contains(obj);
        }

        /// <summary>
        /// Determines whether this object is in an array of objects. NOTE that if the array is <c>null</c> or empty, this method always returns <c>false</c>.
        /// </summary>
        /// <typeparam name="T">The type of this object.</typeparam>
        /// <param name="obj">This object.</param>
        /// <param name="array">An array of objects.</param>
        /// <returns><c>true</c> if this object is in the specified array; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotIn<T>(this T obj, params T[] array)
        {
            return array == null || Array.IndexOf(array, obj) == -1;
        }

        /// <summary>
        /// Determines whether this comparable object is NOT in a range. The lowerbound for the range is included for the range; the upperbound is excluded.
        /// <para>For example, either 0 or 3 is NOT in the range from 1 to 3, but 1 is in the range from 1 to 3.</para>
        /// </summary>
        /// <typeparam name="T">A type that implements <see cref="System.IComparable{T}"/> interface.</typeparam>
        /// <param name="obj">This comparable object.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <returns><c>true</c> if this comparable object is NOT inside the range specified by <paramref name="lowerBound"/> and <paramref name="upperBound"/>; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotIn<T>(this T obj, T lowerBound, T upperBound) where T : IComparable<T>
        {
            return obj.CompareTo(lowerBound) < 0 || obj.CompareTo(upperBound) >= 0;
        }

        /// <summary>
        /// Determines whether this byte is NOT in a range. The lowerbound for the range is included for the range; the upperbound is excluded.
        /// <para>For example, either 0 or 3 is NOT in the range from 1 to 3, but 1 is in the range from 1 to 3.</para>
        /// </summary>
        /// <param name="val">This byte.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <returns><c>true</c> if this byte is NOT inside the range specified by <paramref name="lowerBound"/> and <paramref name="upperBound"/>; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotIn(this byte val, byte lowerBound, byte upperBound)
        {
            return val < lowerBound || val > upperBound;
        }


        /// <summary>
        /// Determines whether this byte is NOT in a range with some step. The lowerbound for the range is included for the range; the upperbound is excluded.
        /// <para>For example, range from 1 to 5 with step 2 represents two numbers 1,3. Therefore only 1 or 3 is in this range while others are not.</para></summary>
        /// <param name="val">This byte.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <param name="step">The step of this range.</param>
        /// <returns>
        ///   <c>true</c> if this byte is NOT inside the range specified by <paramref name="lowerBound" /> and <paramref name="upperBound" /> with step <paramref name="step"/>; otherwise, <c>false</c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotIn(this byte val, byte lowerBound, byte upperBound, byte step)
        {
            return val < lowerBound || val > upperBound || (val - lowerBound) % step != 0;
        }



        /// <summary>
        /// Determines whether this signed byte is NOT in a range. The lowerbound for the range is included for the range; the upperbound is excluded.
        /// <para>For example, either 0 or 3 is NOT in the range from 1 to 3, but 1 is in the range from 1 to 3.</para>
        /// </summary>
        /// <param name="val">This signed byte.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <returns><c>true</c> if this signed byte is NOT inside the range specified by <paramref name="lowerBound"/> and <paramref name="upperBound"/>; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotIn(this sbyte val, sbyte lowerBound, sbyte upperBound)
        {
            return val < lowerBound || val > upperBound;
        }

        /// <summary>
        /// Determines whether this signed byte is NOT in a range with some step. The lowerbound for the range is included for the range; the upperbound is excluded.
        /// <para>For example, range from 1 to 5 with step 2 represents two numbers 1,3. Therefore only 1 or 3 is in this range while others are not.</para></summary>
        /// <param name="val">This signed byte.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <param name="step">The step of this range.</param>
        /// <returns>
        ///   <c>true</c> if this signed byte is NOT inside the range specified by <paramref name="lowerBound" /> and <paramref name="upperBound" /> with step <paramref name="step"/>; otherwise, <c>false</c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotIn(this sbyte val, sbyte lowerBound, sbyte upperBound, sbyte step)
        {
            return val < lowerBound || val > upperBound || (val - lowerBound) % step != 0;
        }


        /// <summary>
        /// Determines whether this integer is NOT in a range. The lowerbound for the range is included for the range; the upperbound is excluded.
        /// <para>For example, either 0 or 3 is NOT in the range from 1 to 3, but 1 is in the range from 1 to 3.</para>
        /// </summary>
        /// <param name="val">This integer.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <returns><c>true</c> if this integer is NOT inside the range specified by <paramref name="lowerBound"/> and <paramref name="upperBound"/>; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotIn(this short val, short lowerBound, short upperBound)
        {
            return val < lowerBound || val > upperBound;
        }


        /// <summary>
        /// Determines whether this integer is NOT in a range with some step. The lowerbound for the range is included for the range; the upperbound is excluded.
        /// <para>For example, range from 1 to 5 with step 2 represents two numbers 1,3. Therefore only 1 or 3 is in this range while others are not.</para></summary>
        /// <param name="val">This integer.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <param name="step">The step of this range.</param>
        /// <returns>
        ///   <c>true</c> if this integer is NOT inside the range specified by <paramref name="lowerBound" /> and <paramref name="upperBound" /> with step <paramref name="step"/>; otherwise, <c>false</c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotIn(this short val, short lowerBound, short upperBound, short step)
        {
            return val < lowerBound || val > upperBound || (val - lowerBound) % step != 0;
        }

        /// <summary>
        /// Determines whether this integer is NOT in a range. The lowerbound for the range is included for the range; the upperbound is excluded.
        /// <para>For example, either 0 or 3 is NOT in the range from 1 to 3, but 1 is in the range from 1 to 3.</para>
        /// </summary>
        /// <param name="val">This integer.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <returns><c>true</c> if this integer is NOT inside the range specified by <paramref name="lowerBound"/> and <paramref name="upperBound"/>; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotIn(this ushort val, ushort lowerBound, ushort upperBound)
        {
            return val < lowerBound || val > upperBound;
        }

        /// <summary>
        /// Determines whether this integer is NOT in a range with some step. The lowerbound for the range is included for the range; the upperbound is excluded.
        /// <para>For example, range from 1 to 5 with step 2 represents two numbers 1,3. Therefore only 1 or 3 is in this range while others are not.</para></summary>
        /// <param name="val">This integer.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <param name="step">The step of this range.</param>
        /// <returns>
        ///   <c>true</c> if this integer is NOT inside the range specified by <paramref name="lowerBound" /> and <paramref name="upperBound" /> with step <paramref name="step"/>; otherwise, <c>false</c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotIn(this ushort val, ushort lowerBound, ushort upperBound, ushort step)
        {
            return val < lowerBound || val > upperBound || (val - lowerBound) % step != 0;
        }


        /// <summary>
        /// Determines whether this integer is NOT in a range. The lowerbound for the range is included for the range; the upperbound is excluded.
        /// <para>For example, either 0 or 3 is NOT in the range from 1 to 3, but 1 is in the range from 1 to 3.</para>
        /// </summary>
        /// <param name="val">This integer.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <returns><c>true</c> if this integer is NOT inside the range specified by <paramref name="lowerBound"/> and <paramref name="upperBound"/>; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotIn(this int val, int lowerBound, int upperBound)
        {
            return val < lowerBound || val > upperBound;
        }

        /// <summary>
        /// Determines whether this integer is NOT in a range with some step. The lowerbound for the range is included for the range; the upperbound is excluded.
        /// <para>For example, range from 1 to 5 with step 2 represents two numbers 1,3. Therefore only 1 or 3 is in this range while others are not.</para></summary>
        /// <param name="val">This integer.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <param name="step">The step of this range.</param>
        /// <returns>
        ///   <c>true</c> if this integer is NOT inside the range specified by <paramref name="lowerBound" /> and <paramref name="upperBound" /> with step <paramref name="step"/>; otherwise, <c>false</c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotIn(this int val, int lowerBound, int upperBound, int step)
        {
            return val < lowerBound || val > upperBound || (val - lowerBound) % step != 0;
        }

        /// <summary>
        /// Determines whether this integer is NOT in a range. The lowerbound for the range is included for the range; the upperbound is excluded.
        /// <para>For example, either 0 or 3 is NOT in the range from 1 to 3, but 1 is in the range from 1 to 3.</para>
        /// </summary>
        /// <param name="val">This integer.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <returns><c>true</c> if this integer is NOT inside the range specified by <paramref name="lowerBound"/> and <paramref name="upperBound"/>; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotIn(this uint val, uint lowerBound, uint upperBound)
        {
            return val < lowerBound || val > upperBound;
        }

        /// <summary>
        /// Determines whether this integer is NOT in a range with some step. The lowerbound for the range is included for the range; the upperbound is excluded.
        /// <para>For example, range from 1 to 5 with step 2 represents two numbers 1,3. Therefore only 1 or 3 is in this range while others are not.</para></summary>
        /// <param name="val">This integer.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <param name="step">The step of this range.</param>
        /// <returns>
        ///   <c>true</c> if this integer is NOT inside the range specified by <paramref name="lowerBound" /> and <paramref name="upperBound" /> with step <paramref name="step"/>; otherwise, <c>false</c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotIn(this uint val, uint lowerBound, uint upperBound, uint step)
        {
            return val < lowerBound || val > upperBound || (val - lowerBound) % step != 0;
        }

        /// <summary>
        /// Determines whether this integer is NOT in a range. The lowerbound for the range is included for the range; the upperbound is excluded.
        /// <para>For example, either 0 or 3 is NOT in the range from 1 to 3, but 1 is in the range from 1 to 3.</para>
        /// </summary>
        /// <param name="val">This integer.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <returns><c>true</c> if this integer is NOT inside the range specified by <paramref name="lowerBound"/> and <paramref name="upperBound"/>; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotIn(this long val, long lowerBound, long upperBound)
        {
            return val < lowerBound || val > upperBound;
        }

        /// <summary>
        /// Determines whether this integer is NOT in a range with some step. The lowerbound for the range is included for the range; the upperbound is excluded.
        /// <para>For example, range from 1 to 5 with step 2 represents two numbers 1,3. Therefore only 1 or 3 is in this range while others are not.</para></summary>
        /// <param name="val">This integer.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <param name="step">The step of this range.</param>
        /// <returns>
        ///   <c>true</c> if this integer is NOT inside the range specified by <paramref name="lowerBound" /> and <paramref name="upperBound" /> with step <paramref name="step"/>; otherwise, <c>false</c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotIn(this long val, long lowerBound, long upperBound, long step)
        {
            return val < lowerBound || val > upperBound || (val - lowerBound) % step != 0;
        }

        /// <summary>
        /// Determines whether this integer is NOT in a range. The lowerbound for the range is included for the range; the upperbound is excluded.
        /// <para>For example, either 0 or 3 is NOT in the range from 1 to 3, but 1 is in the range from 1 to 3.</para>
        /// </summary>
        /// <param name="val">This integer.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <returns><c>true</c> if this integer is NOT inside the range specified by <paramref name="lowerBound"/> and <paramref name="upperBound"/>; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotIn(this ulong val, ulong lowerBound, ulong upperBound)
        {
            return val < lowerBound || val > upperBound;
        }

        /// <summary>
        /// Determines whether this integer is NOT in a range with some step. The lowerbound for the range is included for the range; the upperbound is excluded.
        /// <para>For example, range from 1 to 5 with step 2 represents two numbers 1,3. Therefore only 1 or 3 is in this range while others are not.</para></summary>
        /// <param name="val">This integer.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <param name="step">The step of this range.</param>
        /// <returns>
        ///   <c>true</c> if this integer is NOT inside the range specified by <paramref name="lowerBound" /> and <paramref name="upperBound" /> with step <paramref name="step"/>; otherwise, <c>false</c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotIn(this ulong val, ulong lowerBound, ulong upperBound, ulong step)
        {
            return val < lowerBound || val > upperBound || (val - lowerBound) % step != 0;
        }

        /// <summary>
        /// Determines whether this floating number is NOT in a range. The lowerbound for the range is included for the range; the upperbound is excluded.
        /// <para>For example, either 0.0 or 3.0 is NOT in the range from 1.0 to 3.0, but 1.0 is in this range.</para>
        /// </summary>
        /// <param name="val">This floating number.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <returns><c>true</c> if this floating number is NOT inside the range specified by <paramref name="lowerBound"/> and <paramref name="upperBound"/>; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotIn(this double val, double lowerBound, double upperBound)
        {
            return val < lowerBound || val > upperBound;
        }

        /// <summary>
        /// Determines whether this floating number is NOT in a range. The lowerbound for the range is included for the range; the upperbound is excluded.
        /// <para>For example, either 0.0 or 3.0 is NOT in the range from 1.0 to 3.0, but 1.0 is in this range.</para>
        /// </summary>
        /// <param name="val">This floating number.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <returns><c>true</c> if this floating number is NOT inside the range specified by <paramref name="lowerBound"/> and <paramref name="upperBound"/>; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotIn(this double val, float lowerBound, float upperBound)
        {
            return val < lowerBound || val > upperBound;
        }

        /// <summary>
        /// Determines whether this decimal number is NOT in a range. The lowerbound for the range is included for the range; the upperbound is excluded.
        /// <para>For example, either 0.0 or 3.0 is NOT in the range from 1.0 to 3.0, but 1.0 is in this range.</para>
        /// </summary>
        /// <param name="val">This decimal number.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <returns><c>true</c> if this decimal number is NOT inside the range specified by <paramref name="lowerBound"/> and <paramref name="upperBound"/>; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotIn(this decimal val, decimal lowerBound, decimal upperBound)
        {
            return val < lowerBound || val > upperBound;
        }

        /// <summary>
        /// Determines whether this <see cref="DateTime"/> is NOT in a range. The lowerbound is included for the range; the upperbound is excluded.
        /// <para>For example, either "23:00, March 21, 2018" or "16:00, March 20, 2018" is NOT in the range from "12:00, March 21, 2018" to "23:00, March 21, 2018", but "12:00, March 21, 2018" is in this range.</para>
        /// </summary>
        /// <param name="val">This <see cref="DateTime"/>.</param>
        /// <param name="lowerBound">The inclusive lower bound for the range.</param>
        /// <param name="upperBound">The exclusive upper bound for the range.</param>
        /// <returns><c>true</c> if this provided <see cref="DateTime"/> is NOT inside the range specified by <paramref name="lowerBound"/> and <paramref name="upperBound"/>; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotIn(this DateTime val, DateTime lowerBound, DateTime upperBound)
        {
            return val < lowerBound || val > upperBound;
        }

        #endregion

        #region Two Halfs

        /// <summary>
        /// Gets the lower 4 bits of this byte positioned the lower half of the returned byte. For example, the return value of <see cref="Low(byte)"/> of 01100100 is 00000100.
        /// </summary>
        /// <param name="value">This byte.</param>
        /// <returns>The lower 4 bits of this byte.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte Low(this byte value)
        {
            return (byte)(value & 0x0F);
        }

        /// <summary>
        /// Gets the higher 4 bits of this byte positioned the lower half of the returned byte. For example, the return value of <see cref="High(byte)"/> of 01100100 is 00000110.
        /// </summary>
        /// <param name="value">This byte.</param>
        /// <returns>The higher 4 bits of this byte.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte High(this byte value)
        {
            return (byte)(((byte)value & 0xF0) >> 4);
        }

        /// <summary>
        /// Gets the lower 8 bits of this 16-bit integer, represented by a 8-bit byte.
        /// </summary>
        /// <param name="value">This 16-bit integer.</param>
        /// <returns>The lower 8 bits of this 16-bit integer, represented by a 8-bit byte.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Byte Low(this Int16 value)
        {
            var ptr = (Byte*)&value;
            return ptr[0];
        }

        /// <summary>
        /// Gets the higher 8 bits of this 16-bit integer.
        /// </summary>
        /// <param name="value">This 16-bit integer.</param>
        /// <returns>The higher 8 bits of this 16-bit integer, represented by a 8-bit byte.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Byte High(this Int16 value)
        {
            var ptr = (Byte*)&value;
            return ptr[1];
        }

        /// <summary>
        /// Gets the lower 8 bits of this 16-bit unsigned integer, represented by a 8-bit byte.
        /// </summary>
        /// <param name="value">This 16-bit integer.</param>
        /// <returns>The lower 8 bits of this 16-bit unsigned integer, represented by a 8-bit byte.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Byte Low(this UInt16 value)
        {
            var ptr = (Byte*)&value;
            return ptr[0];
        }

        /// <summary>
        /// Gets the higher 8 bits of this 16-bit unsigned integer, represented by a 8-bit byte.
        /// </summary>
        /// <param name="value">This 16-bit integer.</param>
        /// <returns>The higher 8 bits of this 16-bit unsigned integer, represented by a 8-bit byte.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Byte High(this UInt16 value)
        {
            var ptr = (Byte*)&value;
            return ptr[1];
        }

        /// <summary>
        /// Gets the lower 16 bits of this 32-bit integer, represented by a 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">This 32-bit integer.</param>
        /// <returns>The lower 16 bits of this 32-bit integer, represented by a 16-bit unsigned integer.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 Low(this Int32 value)
        {
            var ptr = (UInt16*)&value;
            return ptr[0];
        }

        /// <summary>
        /// Gets the higher 16 bits of this 32-bit integer, represented by a 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">This 32-bit integer.</param>
        /// <returns>The higher 16 bits of this 32-bit unsigned integer, represented by a 16-bit unsigned integer.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 High(this Int32 value)
        {
            var ptr = (UInt16*)&value;
            return ptr[1];
        }

        /// <summary>
        /// Gets the lower 16 bits of this 32-bit unsigned integer, represented by a 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">This 32-bit integer.</param>
        /// <returns>The lower 16 bits of this 32-bit integer, represented by a 16-bit unsigned integer.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 Low(this UInt32 value)
        {
            var ptr = (UInt16*)&value;
            return ptr[0];
        }

        /// <summary>
        /// Gets the higher 16 bits of this 32-bit unsigned integer, represented by a 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">This 32-bit integer.</param>
        /// <returns>The higher 16 bits of this 32-bit unsigned integer, represented by a 16-bit unsigned integer.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt16 High(this UInt32 value)
        {
            var ptr = (UInt16*)&value;
            return ptr[1];
        }

        /// <summary>
        /// Gets the lower 32 bits of this 64-bit integer, represented by a 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">This 64-bit integer.</param>
        /// <returns>The lower 32 bits of this 64-bit integer, represented by a 32-bit unsigned integer.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 Low(this Int64 value)
        {
            var ptr = (UInt32*)&value;
            return ptr[0];
        }

        /// <summary>
        /// Gets the higher 32 bits of this 64-bit integer, represented by a 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">This 64-bit integer.</param>
        /// <returns>The lower 32 bits of this 64-bit integer, represented by a 32-bit unsigned integer.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 High(this Int64 value)
        {
            var ptr = (UInt32*)&value;
            return ptr[1];
        }

        /// <summary>
        /// Gets the lower 32 bits of this 64-bit unsigned integer, represented by a 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">This 64-bit integer.</param>
        /// <returns>The lower 32 bits of this 64-bit unsigned integer, represented by a 32-bit unsigned integer.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 Low(this UInt64 value)
        {
            var ptr = (UInt32*)&value;
            return ptr[0];
        }

        /// <summary>
        /// Gets the higher 32 bits of this 64-bit unsigned integer, represented by a 32-bit unsigned integer
        /// </summary>
        /// <param name="value">This 64-bit integer.</param>
        /// <returns>The lower 32 bits of this 64-bit unsigned integer, represented by a 32-bit unsigned integer.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UInt32 High(this UInt64 value)
        {
            var ptr = (UInt32*)&value;
            return ptr[1];
        }

        #endregion

        #region To Hex

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent hex string representation.
        /// </summary>
        /// <param name="number">This integer.</param>
        /// <param name="fullLength">Indicates whether this integer will be converted to a full-length hex equivalent. 
        /// For example, integer 10 will be converted to "A" if this parameter is set false and "000000000000000A" if otherwise.</param>
        /// <returns>A hex string equivalent to the current integer.</returns>
        public static string ToHex(this ulong number, bool fullLength = true)
        {
            return string.Format("{0:X" + (fullLength ? (sizeof(ulong) * 2).ToString() : "") + "}", number);
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent hex string representation.
        /// </summary>
        /// <param name="number">This integer.</param>
        /// <param name="fullLength">Indicates whether this integer will be converted to a full-length hex equivalent. 
        /// For example, integer 10 will be converted to "A" if this parameter is set false and "000000000000000A" if otherwise.</param>
        /// <returns>A hex string equivalent to the current integer.</returns>
        public static string ToHex(this long number, bool fullLength = true)
        {
            return string.Format("{0:X" + (fullLength ? (sizeof(long) * 2).ToString() : "") + "}", number);
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent hex string representation.
        /// </summary>
        /// <param name="number">This integer.</param>
        /// <param name="fullLength">Indicates whether this integer will be converted to a full-length hex equivalent. 
        /// For example, integer 10 will be converted to "A" if this parameter is set false and "0000000A" if otherwise.</param>
        /// <returns>A hex string equivalent to the current integer.</returns>
        public static string ToHex(this uint number, bool fullLength = true)
        {
            return string.Format("{0:X" + (fullLength ? (sizeof(uint) * 2).ToString() : "") + "}", number);
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent hex string representation.
        /// </summary>
        /// <param name="number">This integer.</param>
        /// <param name="fullLength">Indicates whether this integer will be converted to a full-length hex equivalent. 
        /// For example, integer 10 will be converted to "A" if this parameter is set false and "0000000A" if otherwise.</param>
        /// <returns>A hex string equivalent to the current integer.</returns>
        public static string ToHex(this int number, bool fullLength = true)
        {
            return string.Format("{0:X" + (fullLength ? (sizeof(int) * 2).ToString() : "") + "}", number);
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent hex string representation.
        /// </summary>
        /// <param name="number">This integer.</param>
        /// <param name="fullLength">Indicates whether this integer will be converted to a full-length hex equivalent. 
        /// For example, integer 10 will be converted to "A" if this parameter is set false and "000A" if otherwise.</param>
        /// <returns>A hex string equivalent to the current integer.</returns>
        public static string ToHex(this ushort number, bool fullLength = true)
        {
            return string.Format("{0:X" + (fullLength ? (sizeof(ushort) * 2).ToString() : "") + "}", number);
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent hex string representation.
        /// </summary>
        /// <param name="number">This integer.</param>
        /// <param name="fullLength">Indicates whether this integer will be converted to a full-length hex equivalent. 
        /// For example, integer 10 will be converted to "A" if this parameter is set false and "000A" if otherwise.</param>
        /// <returns>A hex string equivalent to the current integer.</returns>
        public static string ToHex(this short number, bool fullLength = true)
        {
            return string.Format("{0:X" + (fullLength ? (sizeof(short) * 2).ToString() : "") + "}", number);
        }

        /// <summary>
        /// Converts this byte to its equivalent hex string representation.
        /// </summary>
        /// <param name="number">This integer.</param>
        /// <param name="fullLength">Indicates whether this integer will be converted to a full-length hex equivalent. 
        /// For example, integer 10 will be converted to "A" if this parameter is set false and "0A" if otherwise.</param>
        /// <returns>A hex string equivalent to the current byte.</returns>
        public static string ToHex(this byte number, bool fullLength = true)
        {
            return string.Format("{0:X" + (fullLength ? "2" : "") + "}", number);
        }

        /// <summary>
        /// Converts this byte to its equivalent hex string representation.
        /// </summary>
        /// <param name="number">This integer.</param>
        /// <param name="fullLength">Indicates whether this integer will be converted to a full-length hex equivalent. 
        /// For example, integer 10 will be converted to "A" if this parameter is set false and "0A" if otherwise.</param>
        /// <returns>A hex string equivalent to the current byte.</returns>
        public static string ToHex(this sbyte number, bool fullLength = true)
        {
            return string.Format("{0:X" + (fullLength ? "2" : "") + "}", number);
        }

        /// <summary>
        /// Converts this byte array to its equivalent hex string representation. For example, array {5, 18, 123, 214} will be converted to "05127BD6".
        /// </summary>
        /// <param name="bytes">This byte array.</param>
        /// <returns>A hex string equivalent to the current byte array.</returns>
        public static string ToHex(this byte[] bytes)
        {
            var sb = new StringBuilder(bytes.Length * 2 + 1);
            for (int i = 0; i < bytes.Length; i++)
                sb.Append(bytes[i].ToHex());
            return sb.ToString();
        }

        /// <summary>
        /// Converts this byte array to its equivalent hex string representation. A Unicode character is used to delimiter values.
        /// For example, array {5, 18, 123, 214} will be converted to "05 12 7B D6" if a single space is used as the delimiter.
        /// </summary>
        /// <param name="bytes">This byte array.</param>
        /// <param name="delimiter">The delimiter used to delimit the hex string representations in the output string.</param>
        /// <returns>A hex string equivalent to the current byte array.</returns>
        public static string ToHex(this byte[] bytes, char delimiter)
        {
            if (bytes.Length == 0) return null;
            var sb = new StringBuilder(bytes.Length * 3);

            for (int i = 0; i < bytes.Length; i++)
            {
                if (i != 0) sb.Append(delimiter);
                sb.Append(bytes[i].ToHex());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Converts this byte array to its equivalent hex string representation. A string is used to delimiter values.
        /// For example, array {5, 18, 123, 214} will be converted to "05 , 12 , 7B , D6" if string " , " is used as the delimiter.
        /// </summary>
        /// <param name="bytes">This byte array.</param>
        /// <param name="delimiter">The delimiter used to delimit the hex string representations in the output string.</param>
        /// <returns>A hex string equivalent to the current byte array.</returns>
        public static string ToHex(this byte[] bytes, string delimiter)
        {
            var sb = new StringBuilder(bytes.Length * (2 + delimiter.Length));
            for (int i = 0; i < bytes.Length; i++)
            {
                if (i != 0) sb.Append(delimiter);
                sb.Append(bytes[i].ToHex());
            }
            return sb.ToString();
        }

        #endregion

        #region To Bytes

        /// <summary>
        /// Converts the numeric value of this instance to a byte array.
        /// </summary>
        /// <param name="value">This value.</param>
        /// <returns>A byte array converted from the numeric value of the current instance.</returns>
        public static unsafe byte[] ToBytes(this UInt32 value)
        {
            byte[] buffer = new byte[sizeof(UInt32)];
            fixed (byte* numRef = buffer)
            {
                *((UInt32*)numRef) = value;
            }
            return buffer;
        }

        /// <summary>
        /// Converts the numeric value of this instance to a byte array.
        /// </summary>
        /// <param name="value">This value.</param>
        /// <returns>A byte array converted from the numeric value of the current instance.</returns>
        public static unsafe byte[] ToBytes(this UInt64 value)
        {
            byte[] buffer = new byte[sizeof(UInt64)];
            fixed (byte* numRef = buffer)
            {
                *((UInt64*)numRef) = value;
            }
            return buffer;
        }

        /// <summary>
        /// Converts the numeric value of this instance to a byte array.
        /// </summary>
        /// <param name="value">This value.</param>
        /// <returns>A byte array converted from the numeric value of the current instance.</returns>
        public static unsafe byte[] ToBytes(this UInt16 value)
        {
            byte[] buffer = new byte[sizeof(UInt16)];
            fixed (byte* numRef = buffer)
            {
                *((UInt16*)numRef) = value;
            }
            return buffer;
        }

        /// <summary>
        /// Converts the numeric value of this instance to a byte array.
        /// </summary>
        /// <param name="value">This value.</param>
        /// <returns>A byte array converted from the numeric value of the current instance.</returns>
        public static unsafe byte[] ToBytes(this Int32 value)
        {
            byte[] buffer = new byte[sizeof(Int32)];
            fixed (byte* numRef = buffer)
            {
                *((Int32*)numRef) = value;
            }
            return buffer;
        }

        /// <summary>
        /// Converts the numeric value of this instance to a byte array.
        /// </summary>
        /// <param name="value">This value.</param>
        /// <returns>A byte array converted from the numeric value of the current instance.</returns>
        public static unsafe byte[] ToBytes(this Int64 value)
        {
            byte[] buffer = new byte[sizeof(Int64)];
            fixed (byte* numRef = buffer)
            {
                *((Int64*)numRef) = value;
            }
            return buffer;
        }

        /// <summary>
        /// Converts the numeric value of this instance to a byte array.
        /// </summary>
        /// <param name="value">This value.</param>
        /// <returns>A byte array converted from the numeric value of the current instance.</returns>
        public static unsafe byte[] ToBytes(this Int16 value)
        {
            byte[] buffer = new byte[sizeof(Int16)];
            fixed (byte* numRef = buffer)
            {
                *((Int16*)numRef) = value;
            }
            return buffer;
        }

        /// <summary>
        /// Converts the numeric value of this instance to a byte array.
        /// </summary>
        /// <param name="value">This value.</param>
        /// <returns>A byte array converted from the numeric value of the current instance.</returns>
        public static unsafe byte[] ToBytes(this Double value)
        {
            byte[] buffer = new byte[sizeof(Double)];
            fixed (byte* numRef = buffer)
            {
                *((Double*)numRef) = value;
            }
            return buffer;
        }

        /// <summary>
        /// Converts the numeric value of this instance to a byte array.
        /// </summary>
        /// <param name="value">This value.</param>
        /// <returns>A byte array converted from the numeric value of the current instance.</returns>
        public static unsafe byte[] ToBytes(this Single value)
        {
            byte[] buffer = new byte[sizeof(Single)];
            fixed (byte* numRef = buffer)
            {
                *((Single*)numRef) = value;
            }
            return buffer;
        }

        /// <summary>
        /// Converts the numeric value of this instance to a byte array.
        /// </summary>
        /// <param name="value">This value.</param>
        /// <returns>A byte array converted from the numeric value of the current instance.</returns>
        public static unsafe byte[] ToBytes(this DateTime value)
        {
            byte[] buffer = new byte[sizeof(DateTime)];
            fixed (byte* numRef = buffer)
            {
                *((DateTime*)numRef) = value;
            }
            return buffer;
        }

        #endregion



        #region Misc

        /// <summary>
        /// Returns <c>true</c> if the current object is a <c>null</c> reference.
        /// </summary>
        /// <param name="obj">The current object.</param>
        /// <returns>Returns <c>true</c> if the current object is a <c>null</c> reference; otherwise, returns <c>false</c>.</returns>
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        /// <summary>
        /// Returns <c>true</c> if the current object is not a <c>null</c> reference.
        /// </summary>
        /// <param name="obj">The current object.</param>
        /// <returns>Returns <c>true</c> if the current object is not a <c>null</c> reference; otherwise, returns <c>false</c>.</returns>
        public static bool IsNotNull(this object obj)
        {
            return obj != null;
        }

        /// <summary>
        /// Restarts this System.Timers.Timer object.
        /// </summary>
        /// <param name="timer">The System.Timers.Timer object to reset.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Reset(this System.Timers.Timer timer)
        {
            timer.Stop();
            timer.Start();
        }

        /// <summary>
        /// Converts the value of this instance to a string.
        /// </summary>
        /// <param name="builder">A System.StringBuilder object.</param>
        /// <param name="clear">Specifies whether to clear the content of this System.StringBuilder object after conversion.</param>
        /// <returns>A string whose value is the same as this instance.</returns>
        public static string ToString(this StringBuilder builder, bool clear)
        {
            var str = builder.ToString();
            if (clear) builder.Clear();
            return str;
        }

        #endregion
    }

    /// <summary>
    /// Provides methods to swap values of two objects.
    /// </summary>
    public static class Swapper
    {
        /// <summary>
        /// Swap the values of two objects.
        /// </summary>
        /// <param name="x">The first object.</param>
        /// <param name="y">The second object.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap<T>(ref T x, ref T y)
        {
            T z = y;
            y = x;
            x = z;
        }
    }
}

