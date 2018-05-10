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
        /// Sets a bit to 1 in a byte. The returned value is a new byte instance carrying the edited value.
        /// </summary>
        /// <param name="b">The byte the method edits.</param>
        /// <param name="index">The index position (the right most bit is of index 0) of the bit to be set.</param>
        /// <returns>A new byte instance carrying the edited value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte SetBitOne(this byte b, int index)
        {
            switch (index)
            {
                case 0: return b.SetBitOneAt0();
                case 1: return b.SetBitOneAt1();
                case 2: return b.SetBitOneAt2();
                case 3: return b.SetBitOneAt3();
                case 4: return b.SetBitOneAt4();
                case 5: return b.SetBitOneAt5();
                case 6: return b.SetBitOneAt6();
                case 7: return b.SetBitOneAt7();
                default: throw (new ArgumentOutOfRangeException(GeneralResources.ERR_InvalidBitPosition));
            }
        }

        /// <summary>
        /// Sets the bit at position 0 (the right most bit) to 1 in a byte. The returned value is a new byte instance carrying the edited value.
        /// </summary>
        /// <param name="b">The byte the method edits.</param>
        /// <returns>A new byte instance carrying the edited value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte SetBitOneAt0(this byte b)
        {
            return (byte)(b | 0x01);
        }

        /// <summary>
        /// Sets the bit at position 1 (the right most bit is of position 0) to 1 in a byte. The returned value is a new byte instance carrying the edited value.
        /// </summary>
        /// <param name="b">The byte the method edits.</param>
        /// <returns>A new byte instance carrying the edited value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte SetBitOneAt1(this byte b)
        {
            return (byte)(b | 0x02);
        }

        /// <summary>
        /// Sets the bit at position 2 (the right most bit is of position 0) to 1 in a byte. The returned value is a new byte instance carrying the edited value.
        /// </summary>
        /// <param name="b">The byte the method edits.</param>
        /// <returns>A new byte instance carrying the edited value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte SetBitOneAt2(this byte b)
        {
            return (byte)(b | 0x04);
        }

        /// <summary>
        /// Sets the bit at position 3 (the right most bit is of position 0) to 1 in a byte. The returned value is a new byte instance carrying the edited value.
        /// </summary>
        /// <param name="b">The byte the method edits.</param>
        /// <returns>A new byte instance carrying the edited value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte SetBitOneAt3(this byte b)
        {
            return (byte)(b | 0x08);
        }

        /// <summary>
        /// Sets the bit at position 4 (the right most bit is of position 0) to 1 in a byte. The returned value is a new byte instance carrying the edited value.
        /// </summary>
        /// <param name="b">The byte the method edits.</param>
        /// <returns>A new byte instance carrying the edited value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte SetBitOneAt4(this byte b)
        {
            return (byte)(b | 0x10);
        }

        /// <summary>
        /// Sets the bit at position 5 (the right most bit is of position 0) to 1 in a byte. The returned value is a new byte instance carrying the edited value.
        /// </summary>
        /// <param name="b">The byte the method edits.</param>
        /// <returns>A new byte instance carrying the edited value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte SetBitOneAt5(this byte b)
        {
            return (byte)(b | 0x20);
        }

        /// <summary>
        /// Sets the bit at position 6 (the right most bit is of position 0) to 1 in a byte. The returned value is a new byte instance carrying the edited value.
        /// </summary>
        /// <param name="b">The byte the method edits.</param>
        /// <returns>A new byte instance carrying the edited value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte SetBitOneAt6(this byte b)
        {
            return (byte)(b | 0x40);
        }

        /// <summary>
        /// Sets the bit at position 7 (the left most bit) to 1 in a byte. The returned value is a new byte instance carrying the edited value.
        /// </summary>
        /// <param name="b">The byte the method edits.</param>
        /// <returns>A new byte instance carrying the edited value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte SetBitOneAt7(this byte b)
        {
            return (byte)(b | 0x80);
        }

        /// <summary>
        /// Sets a bit to 1 in a byte array.
        /// </summary>
        /// <param name="bytes">The byte array.</param>
        /// <param name="index">The position of the bit (The bit of index position 0 is the right most bit of byte at position 0 in the array) to set.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetBitOne(this byte[] bytes, int index)
        {
            var idx1 = index / 8;
            var idx2 = index % 8;
            bytes[idx1] = bytes[idx1].SetBitOne(idx2);
        }

        /// <summary>
        /// Sets a bit to 1 directly on a byte through a byte pointer.
        /// </summary>
        /// <param name="bptr">The pointer of the byte the method edits.</param>
        /// <param name="index">The position (this right most bit is of position 0) of the bit to be set.</param>
        /// <returns>The input byte pointer which now points to the altered byte value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static byte* SetBitOne(byte* bptr, int index)
        {
            *bptr = (*bptr).SetBitOne(index);
            return bptr;
        }
    }
}
