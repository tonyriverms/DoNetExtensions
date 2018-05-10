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
        /// Reads a bit from a byte. The returned value is a bool value representing the value of the retrieved bit, <c>true</c> for 1 while <c>false</c> for 0.
        /// </summary>
        /// <param name="b">The byte to read from.</param>
        /// <param name="index">The index position (the right most bit is of position 0) of the bit to retrieve.</param>
        /// <returns>A bool value representing the value of the retrieved bit, <c>true</c> for 1 while <c>false</c> for 0.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GetBit(this byte b, int index)
        {
            switch (index)
            {
                case 0: return b.GetBitAt0();
                case 1: return b.GetBitAt1();
                case 2: return b.GetBitAt2();
                case 3: return b.GetBitAt3();
                case 4: return b.GetBitAt4();
                case 5: return b.GetBitAt5();
                case 6: return b.GetBitAt6();
                case 7: return b.GetBitAt7();
                default: throw (new ArgumentOutOfRangeException(GeneralResources.ERR_InvalidBitPosition));
            }
        }


        /// <summary>
        /// Gets the bit at position 0 (the right most bit) in a byte. The returned value is a bool value representing the value of the retrieved bit, <c>true</c> for 1 while <c>false</c> for 0.
        /// </summary>
        /// <param name="b">The byte to read from.</param>
        /// <returns>A bool value representing the value of the retrieved bit, <c>true</c> for 1 while <c>false</c> for 0.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GetBitAt0(this byte b)
        {
            return Convert.ToBoolean(b & 0x01);
        }

        /// <summary>
        /// Gets the bit at position 1 (the right most bit is of position 0) in a byte. The returned value is a bool value representing the value of the retrieved bit, <c>true</c> for 1 while <c>false</c> for 0.
        /// </summary>
        /// <param name="b">The byte to read from.</param>
        /// <returns>A bool value representing the value of the retrieved bit, <c>true</c> for 1 while <c>false</c> for 0.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GetBitAt1(this byte b)
        {
            return Convert.ToBoolean(b & 0x02);
        }

        /// <summary>
        /// Gets the bit at position 2 (the right most bit is of position 0) in a byte. The returned value is a bool value representing the value of the retrieved bit, <c>true</c> for 1 while <c>false</c> for 0.
        /// </summary>
        /// <param name="b">The byte to read from.</param>
        /// <returns>A bool value representing the value of the retrieved bit, <c>true</c> for 1 while <c>false</c> for 0.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GetBitAt2(this byte b)
        {
            return Convert.ToBoolean(b & 0x04);
        }

        /// <summary>
        /// Gets the bit at position 3 (the right most bit is of position 0) in a byte. The returned value is a bool value representing the value of the retrieved bit, <c>true</c> for 1 while <c>false</c> for 0.
        /// </summary>
        /// <param name="b">The byte to read from.</param>
        /// <returns>A bool value representing the value of the retrieved bit, <c>true</c> for 1 while <c>false</c> for 0.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GetBitAt3(this byte b)
        {
            return Convert.ToBoolean(b & 0x08);
        }

        /// <summary>
        /// Gets the bit at position 4 (the right most bit is of position 0) in a byte. The returned value is a bool value representing the value of the retrieved bit, <c>true</c> for 1 while <c>false</c> for 0.
        /// </summary>
        /// <param name="b">The byte to read from.</param>
        /// <returns>A bool value representing the value of the retrieved bit, <c>true</c> for 1 while <c>false</c> for 0.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GetBitAt4(this byte b)
        {
            return Convert.ToBoolean(b & 0x10);
        }

        /// <summary>
        /// Gets the bit at position 5 (the right most bit is of position 0) in a byte. The returned value is a bool value representing the value of the retrieved bit, <c>true</c> for 1 while <c>false</c> for 0.
        /// </summary>
        /// <param name="b">The byte to read from.</param>
        /// <returns>A bool value representing the value of the retrieved bit, <c>true</c> for 1 while <c>false</c> for 0.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GetBitAt5(this byte b)
        {
            return Convert.ToBoolean(b & 0x20);
        }

        /// <summary>
        /// Gets the bit at position 6 (the right most bit is of position 0) in a byte. The returned value is a bool value representing the value of the retrieved bit, <c>true</c> for 1 while <c>false</c> for 0.
        /// </summary>
        /// <param name="b">The byte to read from.</param>
        /// <returns>A bool value representing the value of the retrieved bit, <c>true</c> for 1 while <c>false</c> for 0.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GetBitAt6(this byte b)
        {
            return Convert.ToBoolean(b & 0x40);
        }

        /// <summary>
        /// Gets the bit at position 7 (the left most bit) in a byte. The returned value is a bool value representing the value of the retrieved bit, <c>true</c> for 1 while <c>false</c> for 0.
        /// </summary>
        /// <param name="b">The byte to read from.</param>
        /// <returns>A bool value representing the value of the retrieved bit, <c>true</c> for 1 while <c>false</c> for 0.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GetBitAt7(this byte b)
        {
            return Convert.ToBoolean(b & 0x80);
        }

        /// <summary>
        /// Gets a bit in a byte array.
        /// </summary>
        /// <param name="bytes">The byte array.</param>
        /// <param name="index">The position of the bit (The bit of index position 0 is the right most bit of byte at position 0 in the array) to get.</param>
        /// <returns><c>true</c> if the bit reads 1; <c>false</c> if the bit reads 0.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GetBit(this byte[] bytes, int index)
        {
            var idx1 = index / 8;
            var idx2 = index % 8;
            return bytes[idx1].GetBit(idx2);
        }
    }
}
