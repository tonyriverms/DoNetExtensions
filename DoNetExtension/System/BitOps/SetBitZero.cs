using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DoNetExtension.System;

namespace System
{
    public static partial class BitOperations
    {
        /// <summary>
        /// Sets a bit to 0 in a byte. The returned value is a new byte instance carrying the edited value.
        /// </summary>
        /// <param name="b">The byte the method edits.</param>
        /// <param name="index">The index position (the right most bit is of position 0) of the bit to be set.</param>
        /// <returns>A new byte instance carrying the edited value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte SetBitZero(this byte b, int index)
        {
            switch (index)
            {
                case 0: return b.SetBitZeroAt0();
                case 1: return b.SetBitZeroAt1();
                case 2: return b.SetBitZeroAt2();
                case 3: return b.SetBitZeroAt3();
                case 4: return b.SetBitZeroAt4();
                case 5: return b.SetBitZeroAt5();
                case 6: return b.SetBitZeroAt6();
                case 7: return b.SetBitZeroAt7();
                default: throw (new ArgumentOutOfRangeException(GeneralResources.ERR_InvalidBitPosition));
            }
        }

        /// <summary>
        /// Sets the bit at position 0 (the right most bit) to 0 in a byte. The returned value is a new byte instance carrying the edited value.
        /// </summary>
        /// <param name="b">The byte the method edits.</param>
        /// <returns>A new byte instance carrying the edited value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte SetBitZeroAt0(this byte b)
        {
            return (byte)(b & ~0x01);
        }

        /// <summary>
        /// Sets the bit at position 1 (the right most bit is of position 0) to 0 in a byte. The returned value is a new byte instance carrying the edited value.
        /// </summary>
        /// <param name="b">The byte the method edits.</param>
        /// <returns>A new byte instance carrying the edited value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte SetBitZeroAt1(this byte b)
        {
            return (byte)(b & ~0x02);
        }

        /// <summary>
        /// Sets the bit at position 2 (the right most bit is of position 0) to 0 in a byte. The returned value is a new byte instance carrying the edited value.
        /// </summary>
        /// <param name="b">The byte the method edits.</param>
        /// <returns>A new byte instance carrying the edited value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte SetBitZeroAt2(this byte b)
        {
            return (byte)(b & ~0x04);
        }

        /// <summary>
        /// Sets the bit at position 3 (the right most bit is of position 0) to 0 in a byte. The returned value is a new byte instance carrying the edited value.
        /// </summary>
        /// <param name="b">The byte the method edits.</param>
        /// <returns>A new byte instance carrying the edited value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte SetBitZeroAt3(this byte b)
        {
            return (byte)(b & ~0x08);
        }

        /// <summary>
        /// Sets the bit at position 4 (the right most bit is of position 0) to 0 in a byte. The returned value is a new byte instance carrying the edited value.
        /// </summary>
        /// <param name="b">The byte the method edits.</param>
        /// <returns>A new byte instance carrying the edited value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte SetBitZeroAt4(this byte b)
        {
            return (byte)(b & ~0x10);
        }

        /// <summary>
        /// Sets the bit at position 5 (the right most bit is of position 0) to 0 in a byte. The returned value is a new byte instance carrying the edited value.
        /// </summary>
        /// <param name="b">The byte the method edits.</param>
        /// <returns>A new byte instance carrying the edited value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte SetBitZeroAt5(this byte b)
        {
            return (byte)(b & ~0x20);
        }

        /// <summary>
        /// Sets the bit at position 6 (the right most bit is of position 0) to 0 in a byte. The returned value is a new byte instance carrying the edited value.
        /// </summary>
        /// <param name="b">The byte the method edits.</param>
        /// <returns>A new byte instance carrying the edited value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte SetBitZeroAt6(this byte b)
        {
            return (byte)(b & ~0x40);
        }

        /// <summary>
        /// Sets the bit at position 7 (the left most bit) to 0 in a byte. The returned value is a new byte instance carrying the edited value.
        /// </summary>
        /// <param name="b">The byte the method edits.</param>
        /// <returns>A new byte instance carrying the edited value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte SetBitZeroAt7(this byte b)
        {
            return (byte)(b & ~0x80);
        }

        /// <summary>
        /// Sets a bit to 0 in a byte array.
        /// </summary>
        /// <param name="bytes">The byte array.</param>
        /// <param name="index">The position of the bit (The bit of index position 0 is the right most bit of byte at position 0 in the array) to set.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetBitZero(this byte[] bytes, int index)
        {
            var idx1 = index / 8;
            var idx2 = index % 8;
            bytes[idx1] = bytes[idx1].SetBitZero(idx2);
        }

        /// <summary>
        /// Sets a bit to 0 directly on a byte through a byte pointer.
        /// </summary>
        /// <param name="bptr">The pointer of the byte the method edits.</param>
        /// <param name="index">The position (the right most bit is of position 0) of the bit to be set.</param>
        /// <returns>The input byte pointer which now points to the altered byte value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static byte* SetBitZero(byte* bptr, int index)
        {
            *bptr = (*bptr).SetBitZero(index);
            return bptr;
        }
    }
}
