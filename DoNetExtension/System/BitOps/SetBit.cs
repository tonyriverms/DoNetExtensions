using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class BitOperations
    {
        /// <summary>
        /// Sets a bit in a byte array.
        /// </summary>
        /// <param name="bytes">The byte array.</param>
        /// <param name="index">The position of the bit (The bit of index position 0 is the right most bit of byte at position 0 in the array) to set.</param>
        /// <param name="value">A bool value represents the bit value; <c>true</c> for 1 and <c>false</c> for 0.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetBit(this byte[] bytes, int index, bool value)
        {
            var idx1 = index / 8;
            var idx2 = index % 8;
            bytes[idx1] = bytes[idx1].SetBit(idx2, value);
        }

        /// <summary>
        /// Sets a bit in a byte. The returned value is a new byte instance carrying the edited value.
        /// </summary>
        /// <param name="b">The byte the method edits.</param>
        /// <param name="index">The position of the bit (the right most bit is of index position 0) to be set.</param>
        /// <param name="value">A bool value indicating whether the bit will be set 0 or 1; <c>true</c> for 1 and <c>false</c> for 0.</param>
        /// <returns>A new byte instance carrying the edited value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte SetBit(this byte b, int index, bool value)
        {
            if (value)
                return b.SetBitOne(index);
            else
                return b.SetBitZero(index);
        }

        /// <summary>
        /// Sets a bit directly on a byte through a byte pointer.
        /// </summary>
        /// <param name="bptr">The pointer of the byte the method edits.</param>
        /// <param name="index">The position (the right most bit is of index position 0) of the bit to be set.</param>
        /// <param name="value">A bool value indicating whether the bit will be set 0 or 1; true for 1 and false for 0.</param>
        public unsafe static void SetBit(byte* bptr, int index, bool value)
        {
            if (value)
                *bptr = (*bptr).SetBitOne(index);
            else
                *bptr = (*bptr).SetBitZero(index);
        }
    }
}
