using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class HashEx
    {
        #region System Hash

        /// <summary>
        /// Serves as a hash function for this byte array using system algorithm provided by Microsoft.NET 4 platform.
        /// <para>NOTE that the <c>GetHashCode</c> of a byte array DOES NOT hash the content. Use this method instead.</para>
        /// </summary>
        /// <param name="bytes">A byte array.</param>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public unsafe static int SystemHash(this byte[] bytes)
        {
            fixed (byte* dataPtr = bytes)
            {
                int length = bytes.Length;
                int num = 0x15051505;
                int num2 = num;
                int* numPtr = (int*)dataPtr;
                for (int i = length; i > 0; i -= 8)
                {
                    if (i == 1)
                    {
                        byte* numPtr8 = (byte*)numPtr;
                        num = (((num << 5) + num) + (num >> 0x1b)) ^ ((((int)numPtr8[0] << 24) & 0x0000FFFF));
                        break;
                    }
                    else if (i == 2)
                    {
                        Int16* numPtr16 = (Int16*)numPtr;
                        num = (((num << 5) + num) + (num >> 0x1b)) ^ ((((int)numPtr16[0] << 16) & 0x0000FFFF));
                        break;
                    }
                    else if (i == 3)
                    {
                        Int16* numPtr16 = (Int16*)numPtr;
                        byte* numPtr8 = (byte*)numPtr;
                        num = (((num << 5) + num) + (num >> 0x1b)) ^ ((((int)numPtr16[0] << 16) | ((int)numPtr8[2] << 8)));
                    }
                    else if (i == 4)
                    {
                        num = (((num << 5) + num) + (num >> 0x1b)) ^ numPtr[0];
                        break;
                    }
                    else
                        num = (((num << 5) + num) + (num >> 0x1b)) ^ numPtr[0];

                    if (i == 5 || i == 6)
                        num2 = (((num2 << 5) + num2) + (num2 >> 0x1b)) ^ ((int)(numPtr[1] & 0x0000FFFF));
                    else
                        num2 = (((num2 << 5) + num2) + (num2 >> 0x1b)) ^ numPtr[1];

                    numPtr += 2;
                }
                return (num + (num2 * 0x5d588b65));
            }
        }

        /// <summary>
        /// Serves as a hash function that returns a 64-bit integer hash code for this string instance. This method uses a 64-bit variant of the hash algorithm provided by Microsoft.NET 4 platform.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <returns>A 64-bit signed integer hash code.</returns>
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public static unsafe Int64 GetHashCode64(this string str)
        {
            fixed (char* strPtr = str)
            {
                char* chPtr = strPtr;
                var length = str.Length;

                ulong num = 0x1505150515051505;
                ulong num2 = num;
                ulong* numPtr = (ulong*)chPtr;

                while (length > 6) //! note that when length is 7, the actual bytes is 16, which is 2*(7+1).
                {
                    num = (((num << 10) + num) + (num >> 0x36)) ^ numPtr[0];
                    num2 = (((num2 << 10) + num2) + (num2 >> 0x36)) ^ numPtr[1];
                    numPtr += 2;
                    length -= 8;
                }

                switch(length)
                {
                    case 6:
                    case 5:
                        {
                            num = (((num << 10) + num) + (num >> 0x36)) ^ numPtr[0];
                            num2 = (((num2 << 10) + num2) + (num2 >> 0x36)) ^ ((ulong)(numPtr[1] & 0x0000FFFFFFFFFFFF));
                            break;
                        }
                    case 4:
                    case 3:
                        {
                            num = (((num << 10) + num) + (num >> 0x36)) ^ numPtr[0];
                            break;
                        }
                    case 2:
                    case 1:
                        {
                            num = (((num << 10) + num) + (num >> 0x36)) ^ ((uint)(numPtr[0] & 0x00000000FFFFFFFF));
                            break;
                        }
                }

                return (Int64)((num + (num2 * 0x5d588b65)));
            }
        }

        /// <summary>
        /// Serves as a hash function for a sub string of this string instance.
        /// </summary>
        /// <param name="str">This string instance.</param>
        /// <param name="startIndex">Indicating the position where the hash begins.</param>
        /// <param name="length">Indication the length of the substring to hash.</param>
        /// <returns>A 32-bit signed integer as the hash code of the specified sub string.</returns>
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public static unsafe int GetHashCode(this string str, int startIndex, int length)
        {
            fixed (char* sptr = str)
            {
                char* chPtr = sptr;
                chPtr += startIndex;

                int num = 0x15051505;
                int num2 = num;
                int* numPtr = (int*)chPtr;
                for (int i = length; i > startIndex; i -= 4)
                {
                    if (i == 1)
                    {
                        num = (((num << 5) + num) + (num >> 0x1b)) ^ ((int)(numPtr[0] & 0x0000FFFF));
                        break;
                    }
                    else if (i == 2)
                    {
                        num = (((num << 5) + num) + (num >> 0x1b)) ^ numPtr[0];
                        break;
                    }
                    else
                        num = (((num << 5) + num) + (num >> 0x1b)) ^ numPtr[0];

                    if (i == 3)
                        num2 = (((num2 << 5) + num2) + (num2 >> 0x1b)) ^ ((int)(numPtr[1] & 0x0000FFFF));
                    else
                        num2 = (((num2 << 5) + num2) + (num2 >> 0x1b)) ^ numPtr[1];

                    numPtr += 2;
                }
                return (num + (num2 * 0x5d588b65));
            }
        }

        #endregion

        #region Murmur3 Hash

        static unsafe void _innerHash(byte* bptr, int byteCount, out Int64 high, out Int64 low, uint seed = 0xEE6B27EB)
        {
            ulong length = 0;
            ulong h1 = 0;
            ulong h2 = 0;

            h1 = seed;
            length = 0L;
            int pos = 0;
            ulong remaining = (ulong)byteCount;

            while (remaining >= murmur3_readSize)
            {
                ulong k1 = *((UInt64*)(&bptr[pos]));
                pos += 8;

                ulong k2 = *((UInt64*)(&bptr[pos]));
                pos += 8;

                length += murmur3_readSize;
                remaining -= murmur3_readSize;

                h1 ^= murmur3_mixKey1(k1);
                h1 = h1.murmur3_rotateLeft(27);
                h1 += h2;
                h1 = h1 * 5 + 0x52dce729;

                h2 ^= murmur3_mixKey2(k2);
                h2 = h2.murmur3_rotateLeft(31);
                h2 += h1;
                h2 = h2 * 5 + 0x38495ab5;
            }

            if (remaining > 0)
                _processRemaining(bptr, ref length, remaining, pos, ref h1, ref h2);

            h1 ^= length;
            h2 ^= length;

            h1 += h2;
            h2 += h1;

            h1 = murmur3_mixFinal(h1);
            h2 = murmur3_mixFinal(h2);

            h1 += h2;
            h2 += h1;

            high = (Int64)(*((Int64*)&h2));
            low = (Int64)(*((Int64*)&h1));
        }

        public static unsafe void MurmurHash128(this byte[] bytes, out Int64 high, out Int64 low, uint seed)
        {
            fixed (byte* bPtr = bytes)
            {
                _innerHash(bPtr, bytes.Length, out high, out low, seed);
            }
        }

        public static unsafe void MurmurHash128(this string str, out Int64 high, out Int64 low, uint seed)
        {
            fixed (char* chPtr = str)
            {
                _innerHash((byte*)chPtr, str.Length + str.Length, out high, out low, seed);
            }
        }

        public static unsafe Int64 MurmurHash64(this byte[] bytes, uint seed)
        {
            Int64 high, low;
            MurmurHash128(bytes, out high, out low, seed);
            return low;
        }

        public static unsafe Int64 MurmurHash64(this string str, uint seed)
        {
            Int64 high, low;
            MurmurHash128(str, out high, out low, seed);
            return low;
        }

        public static unsafe Int32 MurmurHash(this byte[] bytes, uint seed)
        {
            Int64 high, low;
            MurmurHash128(bytes, out high, out low, seed);
            return (int)(low >> 32);
        }

        public static unsafe Int32 MurmurHash(this string str, uint seed)
        {
            Int64 high, low;
            MurmurHash128(str, out high, out low, seed);
            return (int)(low >> 32);
        }

        public static unsafe void MurmurHash128(this byte[] bytes, out Int64 high, out Int64 low)
        {
            fixed (byte* bPtr = bytes)
            {
                _innerHash(bPtr, bytes.Length, out high, out low);
            }
        }

        public static unsafe void MurmurHash128(this string str, out Int64 high, out Int64 low)
        {
            fixed (char* chPtr = str)
            {
                _innerHash((byte*)chPtr, str.Length + str.Length, out high, out low);
            }
        }

        public static unsafe Int64 MurmurHash64(this byte[] bytes)
        {
            Int64 high, low;
            MurmurHash128(bytes, out high, out low);
            return low;
        }

        public static unsafe Int64 MurmurHash64(this string str)
        {
            Int64 high, low;
            MurmurHash128(str, out high, out low);
            return low;
        }

        public static unsafe Int32 MurmurHash(this byte[] bytes)
        {
            Int64 high, low;
            MurmurHash128(bytes, out high, out low);
            return (int)(low >> 32);
        }

        public static unsafe Int32 MurmurHash(this string str)
        {
            Int64 high, low;
            MurmurHash128(str, out high, out low);
            return (int)(low >> 32);
        }

        #region private methods
        const ulong murmur3_c1 = 0x87c37b91114253d5L;
        const ulong murmur3_c2 = 0x4cf5ad432745937fL;
        const ulong murmur3_readSize = 16;
        static unsafe void _processRemaining(byte* bb, ref ulong length, ulong remaining, int pos, ref UInt64 h1, ref UInt64 h2)
        {
            ulong k1 = 0;
            ulong k2 = 0;
            length += remaining;

            // little endian (x86) processing
            switch (remaining)
            {
                case 15:
                    k2 ^= (ulong)bb[pos + 14] << 48; // fall through
                    goto case 14;
                case 14:
                    k2 ^= (ulong)bb[pos + 13] << 40; // fall through
                    goto case 13;
                case 13:
                    k2 ^= (ulong)bb[pos + 12] << 32; // fall through
                    goto case 12;
                case 12:
                    k2 ^= (ulong)bb[pos + 11] << 24; // fall through
                    goto case 11;
                case 11:
                    k2 ^= (ulong)bb[pos + 10] << 16; // fall through
                    goto case 10;
                case 10:
                    k2 ^= (ulong)bb[pos + 9] << 8; // fall through
                    goto case 9;
                case 9:
                    k2 ^= (ulong)bb[pos + 8]; // fall through
                    goto case 8;
                case 8:
                    k1 ^= *((UInt64*)(&bb[pos]));
                    break;
                case 7:
                    k1 ^= (ulong)bb[pos + 6] << 48; // fall through
                    goto case 6;
                case 6:
                    k1 ^= (ulong)bb[pos + 5] << 40; // fall through
                    goto case 5;
                case 5:
                    k1 ^= (ulong)bb[pos + 4] << 32; // fall through
                    goto case 4;
                case 4:
                    k1 ^= (ulong)bb[pos + 3] << 24; // fall through
                    goto case 3;
                case 3:
                    k1 ^= (ulong)bb[pos + 2] << 16; // fall through
                    goto case 2;
                case 2:
                    k1 ^= (ulong)bb[pos + 1] << 8; // fall through
                    goto case 1;
                case 1:
                    k1 ^= (ulong)bb[pos]; // fall through
                    break;
                default:
                    throw new Exception("Something went wrong with remaining bytes calculation.");
            }

            h1 ^= murmur3_mixKey1(k1);
            h2 ^= murmur3_mixKey2(k2);
        }

        static ulong murmur3_mixFinal(ulong k)
        {
            // avalanche bits
            k ^= k >> 33;
            k *= 0xff51afd7ed558ccdL;
            k ^= k >> 33;
            k *= 0xc4ceb9fe1a85ec53L;
            k ^= k >> 33;
            return k;
        }

        static ulong murmur3_mixKey1(ulong k1)
        {
            k1 *= murmur3_c1;
            k1 = k1.murmur3_rotateLeft(31);
            k1 *= murmur3_c2;
            return k1;
        }

        private static ulong murmur3_mixKey2(ulong k2)
        {
            k2 *= murmur3_c2;
            k2 = k2.murmur3_rotateLeft(33);
            k2 *= murmur3_c1;
            return k2;
        }

        static ulong murmur3_rotateLeft(this ulong original, int bits)
        {
            return (original << bits) | (original >> (64 - bits));
        }

        static ulong murmur3_rotateRight(this ulong original, int bits)
        {
            return (original >> bits) | (original << (64 - bits));
        }
        #endregion

        #endregion
    }
}
