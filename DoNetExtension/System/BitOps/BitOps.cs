using System.Runtime.CompilerServices;
using DoNetExtension.System;

namespace System
{
    public enum BitOperationMode
    {
        Or, And, NotAnd, NotOr, ExclusiveOr, InclusiveOr
    }

    /// <summary>
    /// Provides methods to operate on byte or bytes at bit level.
    /// </summary>
    public static partial class BitOperations
    {
        public static UInt32 FoldAsUInt32(this UInt32[] values, BitOperationMode mode)
        {
            int count = values.Length;
            int i, j;
            int k = 0;
            var barr = values.ToBooleans();
            UInt32 rlt = 0;
            switch (mode)
            {
                default:
                    {
                        for (i = 0; i < sizeof(UInt32); i++)
                        {
                            bool b = false;
                            for (j = 0; j < count; j++)
                            {
                                b |= barr[k++];
                                if (b)
                                {
                                    k += count - j - 1;
                                    break;
                                }
                            }
                            rlt.SetBit(i, b);
                        }
                        return rlt;
                    }
                case BitOperationMode.And:
                    {
                        for (i = 0; i < sizeof(UInt32); i++)
                        {
                            bool b = false;
                            for (j = 0; j < count; j++)
                            {
                                b &= barr[k++];
                                if (!b)
                                {
                                    k += count - j - 1;
                                    break;
                                }
                            }
                            rlt.SetBit(i, b);
                        }
                        return rlt;
                    }
                case BitOperationMode.NotOr:
                    {
                        for (i = 0; i < sizeof(UInt32); i++)
                        {
                            bool b = false;
                            for (j = 0; j < count; j++)
                            {
                                b |= !barr[k++];
                                if (b)
                                {
                                    k += count - j - 1;
                                    break;
                                }
                            }
                            rlt.SetBit(i, b);
                        }
                        return rlt;
                    }
                case BitOperationMode.NotAnd:
                    {
                        for (i = 0; i < sizeof(UInt32); i++)
                        {
                            bool b = false;
                            for (j = 0; j < count; j++)
                            {
                                b &= !barr[k++];
                                if (!b)
                                {
                                    k += count - j - 1;
                                    break;
                                }
                            }
                            rlt.SetBit(i, b);
                        }
                        return rlt;
                    }
            }
        }

        public static bool[] ToBooleans(this UInt32[] values)
        {
            var rlt = new bool[values.Length * sizeof(UInt32)];
            int j = 0, k = 0;
            for (int i = 0; i < rlt.Length; i++)
            {
                rlt[i] = values[j].GetBit(k++);
                if (k == sizeof(UInt32))
                {
                    j++;
                    k = 0;
                }
            }
            return rlt;
        }

        public static bool[] ToBooleans(this UInt32 value)
        {
            var rlt = new bool[sizeof(UInt32)];
            for (int i = 0; i < rlt.Length; i++)
                rlt[i] = value.GetBit(i);
            return rlt;
        }

        public static byte SetBits(this byte source, int startPosition, int length, byte value, bool high = false)
        {
            if (length > 8 - startPosition)
                throw new InvalidOperationException();

            return (byte)(
                ((byte)(source >> (8 - startPosition)) << (8 - startPosition)) |
                ((byte)(source << (startPosition + length)) >> (startPosition + length)) |
                ((byte)(high ? (byte)((value >> (8 - length)) << (8 - length - startPosition)) : (byte)(value << (8 - length)) >> startPosition))
                );
        }

        public static byte SetBitsAtLeft(this byte source, int length, byte value, bool high = false)
        {
            if (length > 8)
                throw new InvalidOperationException();

            return (byte)(((byte)(source << length) >> length) |
                (high ? ((byte)(value >> (8 - length)) << (8 - length)) : (value << (8 - length))));
        }

        public static byte SetBitsAtRight(this byte source, int length, byte value, bool high = false)
        {
            if (length > 8)
                throw new InvalidOperationException();

            return (byte)(((byte)(source >> length) << length) | (high ? (value >> (8 - length)) : (byte)(value << (8 - length)) >> (8 - length)));
        }

        public static byte GetBits(this byte source, int startPosition, int length, bool high = false)
        {
            if (high)
                return (byte)(((byte)(source >> (8 - length - startPosition))) << (8 - length));
            else
                return (byte)(((byte)(source << startPosition)) >> (8 - length));
        }

        public static byte GetBitsAtLeft(this byte source, int length, bool high = false)
        {
            if (high)
                return (byte)(((byte)(source >> (8 - length))) << (8 - length));
            else
                return (byte)(((byte)(source >> (8 - length))));
        }

        public static byte GetBitsAtRight(this byte source, int length, bool high = false)
        {
            if (high)
                return (byte)(((byte)(source << (8 - length))));
            else
                return (byte)(((byte)(source << (8 - length))) >> (8 - length));
        }

        /// <summary>
        /// Converts a section of length 32 of this boolean array to a 32-bit unsigned integer. 
        /// Each boolean value sequentially represents a bit in the integer, true for 1 and false for 0.
        /// </summary>
        /// <param name="values">An array of boolean values.</param>
        /// <returns>The created integer.</returns>
        public unsafe static UInt32 ToUInt32(params bool[] values)
        {
            var endIndex = Math.Min(sizeof(UInt32), values.Length);
            UInt32 rlt = 0;
            byte* ptr = (byte*)(&rlt);

            int i = 0, j = 0;
            for (; i < endIndex; i++)
            {
                SetBit(ptr, j++, values[i]);
                if (j == sizeof(byte))
                {
                    ptr++;
                    j = 0;
                }
            }
            return rlt;
        }

        /// <summary>
        /// Converts the first 32 values of this boolean array to a 32-bit unsigned integer. 
        /// Each boolean value sequentially represents a bit in the integer, true for 1 and false for 0.
        /// </summary>
        /// <param name="values">An array of boolean values.</param>
        /// <param name="startIndex">The position in the array where the boolean value represents the leftmost bit of the byte.</param>
        /// <returns>The created integer.</returns>
        public unsafe static UInt32 ToUInt32(this bool[] values, int startIndex)
        {
            var endIndex = Math.Min(startIndex + sizeof(UInt32), values.Length);
            UInt32 rlt = 0;
            byte* ptr = (byte*)(&rlt);

            int j = 0;
            int i = startIndex;
            for (; i < endIndex; i++)
            {
                SetBit(ptr, j++, values[i]);
                if (j == sizeof(byte))
                {
                    ptr++;
                    j = 0;
                }
            }
            return rlt;
        }

        /// <summary>
        /// Converts a section of length 8 of this boolean array to a 8-bit byte. 
        /// Each boolean value sequentially represents a bit in the byte, true for 1 and false for 0.
        /// </summary>
        /// <param name="values">An array of boolean values.</param>
        /// <param name="startIndex">The position in the array where the boolean value represents the leftmost bit of the byte.</param>
        /// <returns>The created byte.</returns>
        public static byte ToByte(this bool[] values, int startIndex = 0)
        {
            var endIndex = Math.Min(startIndex + 8, values.Length);
            byte rlt = 0;
            for (int i = startIndex, j = 0; i < endIndex; i++, j++)
                rlt = rlt.SetBit(j, values[i]);
            return rlt;
        }

        /// <summary>
        /// Converts a the first 8 values of this boolean array to a 8-bit byte. 
        /// Each boolean value sequentially represents a bit in the byte, true for 1 and false for 0.
        /// </summary>
        /// <param name="values">An array of boolean values.</param>
        /// <returns>The created byte.</returns>
        public static byte ToByte(params bool[] values)
        {
            var endIndex = Math.Min(8, values.Length);
            byte rlt = 0;
            for (int i = 0; i < endIndex; i++)
                rlt = rlt.SetBit(i, values[i]);
            return rlt;
        }

        /// <summary>
        /// Sets a bit on a 32-bit integer through a pointer.
        /// </summary>
        /// <param name="iptr">The pointer of the integer the method edits.</param>
        /// <param name="index">The position of the bit to be set.</param>
        /// <param name="value">A bool value indicating whether the bit will be set 0 or 1; true for 1 and false for 0.</param>
        /// <returns>The input pointer which now points to the edited value.</returns>
        public unsafe static UInt32* SetBit(UInt32* iptr, int index, bool value)
        {
            if (index >= 32) throw new ArgumentOutOfRangeException(GeneralResources.ERR_InvalidBitPosition);
            byte* ptr = (byte*)(iptr);
            int s = index / 8;
            int p = index % 8;
            ptr += s;
            SetBit(ptr, p, value);
            return iptr;
        }

        /// <summary>
        /// Sets a bit in a 64-bit integer. The returned value is a new integer instance carring the edited value.
        /// </summary>
        /// <param name="i">The integer the method edits.</param>
        /// <param name="index">The position of the bit to be set.</param>
        /// <param name="value">A bool value indicating whether the bit will be set 0 or 1; true for 1 and false for 0.</param>
        /// <returns>A new integer instance carrying the edited value.</returns>
        public unsafe static UInt64 SetBit(this UInt64 i, int index, bool value)
        {
            if (index >= 64) throw new ArgumentOutOfRangeException(GeneralResources.ERR_InvalidBitPosition);
            byte* ptr = (byte*)(&i);
            int s = index / 8;
            int p = index % 8;
            ptr += s;
            SetBit(ptr, p, value);
            return i;
        }

        /// <summary>
        /// Reads a bit from a 64-bit integer.
        /// </summary>
        /// <param name="i">The integer to read from.</param>
        /// <param name="index">The position of the bit.</param>
        /// <returns>A bool value representing the value of the bit, true for 1 while false for 0.</returns>
        public unsafe static bool GetBit(this UInt64 i, int index)
        {
            if (index >= 64) throw new ArgumentOutOfRangeException(GeneralResources.ERR_InvalidBitPosition);
            byte* ptr = (byte*)(&i);
            int s = index / 8;
            int p = index % 8;
            return GetBit(ptr[s], p);
        }

        /// <summary>
        /// Sets a bit in a 32-bit integer. The returned value is a new integer instance carring the edited value.
        /// </summary>
        /// <param name="i">The integer the method edits.</param>
        /// <param name="index">The position of the bit to be set.</param>
        /// <param name="value">A bool value indicating whether the bit will be set 0 or 1; true for 1 and false for 0.</param>
        /// <returns>A new integer instance carrying the edited value.</returns>
        public unsafe static UInt32 SetBit(this UInt32 i, int index, bool value)
        {
            if (index >= 32) throw new ArgumentOutOfRangeException(GeneralResources.ERR_InvalidBitPosition);
            byte* ptr = (byte*)(&i);
            int s = index / 8;
            int p = index % 8;
            ptr += s;
            SetBit(ptr, p, value);
            return i;
        }

        /// <summary>
        /// Reads a bit from a 32-bit integer.
        /// </summary>
        /// <param name="i">The integer to read from.</param>
        /// <param name="index">The position of the bit.</param>
        /// <returns>A bool value representing the value of the bit, true for 1 while false for 0.</returns>
        public unsafe static bool GetBit(this UInt32 i, int index)
        {
            if (index >= 32) throw new ArgumentOutOfRangeException(GeneralResources.ERR_InvalidBitPosition);
            byte* ptr = (byte*)(&i);
            int s = index / 8;
            int p = index % 8;
            return GetBit(ptr[s], p);
        }
    }
}