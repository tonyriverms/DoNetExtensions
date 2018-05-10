using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_Extension_Library.System;
using DoNetExtension.System;

namespace System
{
    public static partial class ArrayEx
    {
        /// <summary>
        /// Gets an array of ordered consecutive 8-bit bytes.
        /// </summary>
        /// <param name="min">The minimum value in the array.</param>
        /// <param name="max">The maximum value in the array.</param>
        /// <param name="descending">Indicates whether the array elements are in descending order or ascending order.
        /// If <c>true</c>, argument <paramref name="min" /> will be placed at the end of the array and argument <paramref name="max" /> be the first element;
        /// if <c>false</c>, argument <paramref name="min" /> will be placed at the beginning of the array and argument <paramref name="max" /> be the last element.</param>
        /// <returns>
        /// An array of consecutive 8-bit bytes.
        /// </returns>
        /// <exception cref="System.ArgumentException">Occurs when <paramref name="min" /> is larger than <paramref name="max" />.</exception>
        public static byte[] CreateConsecutiveBytes(byte min, byte max, bool descending = false)
        {
            int i = 0;
            if (min <= max)
            {
                var result = new byte[max - min + 1];
                if (descending)
                {
                    while (min <= max)
                    {
                        result.SetValue(max, i);
                        --max;
                        ++i;
                    }
                }
                else
                {
                    while (min <= max)
                    {
                        result.SetValue(min, i);
                        ++min;
                        ++i;
                    }
                }
                return result;
            }
            else throw (new ArgumentException(GeneralResources.ERR_InvalidMinMax.Scan("min", "max")));
        }

        /// <summary>
        /// Gets an array of ordered consecutive 8-bit signed bytes.
        /// </summary>
        /// <param name="min">The minimum value in the array.</param>
        /// <param name="max">The maximum value in the array.</param>
        /// <param name="descending">Indicates whether the array elements are in descending order or ascending order.
        /// If <c>true</c>, argument <paramref name="min" /> will be placed at the end of the array and argument <paramref name="max" /> be the first element;
        /// if <c>false</c>, argument <paramref name="min" /> will be placed at the beginning of the array and argument <paramref name="max" /> be the last element.</param>
        /// <returns>
        /// An array of consecutive 8-bit signed bytes.
        /// </returns>
        /// <exception cref="System.ArgumentException">Occurs when <paramref name="min" /> is larger than <paramref name="max" />.</exception>
        public static sbyte[] CreateConsecutiveSBytes(sbyte min, sbyte max, bool descending = false)
        {
            int i = 0;
            if (min <= max)
            {
                var result = new sbyte[max - min + 1];
                if (descending)
                {
                    while (min <= max)
                    {
                        result.SetValue(max, i);
                        --max;
                        ++i;
                    }
                }
                else
                {
                    while (min <= max)
                    {
                        result.SetValue(min, i);
                        ++min;
                        ++i;
                    }
                }
                return result;
            }
            else throw (new ArgumentException(GeneralResources.ERR_InvalidMinMax.Scan("min", "max")));
        }

        /// <summary>
        /// Gets an array of ordered consecutive 16-bit integers.
        /// </summary>
        /// <param name="min">The minimum value in the array.</param>
        /// <param name="max">The maximum value in the array.</param>
        /// <param name="descending">Indicates whether the array elements are in descending order or ascending order.
        /// If <c>true</c>, argument <paramref name="min" /> will be placed at the end of the array and argument <paramref name="max" /> be the first element;
        /// if <c>false</c>, argument <paramref name="min" /> will be placed at the beginning of the array and argument <paramref name="max" /> be the last element.</param>
        /// <returns>
        /// An array of consecutive 16-bit integers.
        /// </returns>
        /// <exception cref="System.ArgumentException">Occurs when <paramref name="min" /> is larger than <paramref name="max" />.</exception>
        public static short[] CreateConsecutiveShorts(short min, short max, bool descending = false)
        {
            int i = 0;
            if (min <= max)
            {
                var result = new short[max - min + 1];
                if (descending)
                {
                    while (min <= max)
                    {
                        result.SetValue(max, i);
                        --max;
                        ++i;
                    }
                }
                else
                {
                    while (min <= max)
                    {
                        result.SetValue(min, i);
                        ++min;
                        ++i;
                    }
                }
                return result;
            }
            else throw (new ArgumentException(GeneralResources.ERR_InvalidMinMax.Scan("min", "max")));
        }

        /// <summary>
        /// Gets an array of ordered consecutive 16-bit unsigned integers.
        /// </summary>
        /// <param name="min">The minimum value in the array.</param>
        /// <param name="max">The maximum value in the array.</param>
        /// <param name="descending">Indicates whether the array elements are in descending order or ascending order.
        /// If <c>true</c>, argument <paramref name="min" /> will be placed at the end of the array and argument <paramref name="max" /> be the first element;
        /// if <c>false</c>, argument <paramref name="min" /> will be placed at the beginning of the array and argument <paramref name="max" /> be the last element.</param>
        /// <returns>
        /// An array of consecutive 16-bit unsigned integers.
        /// </returns>
        /// <exception cref="System.ArgumentException">Occurs when <paramref name="min" /> is larger than <paramref name="max" />.</exception>
        public static ushort[] CreateConsecutiveUShorts(ushort min, ushort max, bool descending = false)
        {
            int i = 0;
            if (min <= max)
            {
                var result = new ushort[max - min + 1];
                if (descending)
                {
                    while (min <= max)
                    {
                        result.SetValue(max, i);
                        --max;
                        ++i;
                    }
                }
                else
                {
                    while (min <= max)
                    {
                        result.SetValue(min, i);
                        ++min;
                        ++i;
                    }
                }
                return result;
            }
            else throw (new ArgumentException(GeneralResources.ERR_InvalidMinMax.Scan("min", "max")));
        }

        /// <summary>
        /// Gets an array of ordered consecutive integers.
        /// </summary>
        /// <param name="min">The minimum value in the array.</param>
        /// <param name="max">The maximum value in the array.</param>
        /// <param name="descending">Indicates whether the array elements are in descending order or ascending order.
        /// If <c>true</c>, argument <paramref name="min" /> will be placed at the end of the array and argument <paramref name="max" /> be the first element;
        /// if <c>false</c>, argument <paramref name="min" /> will be placed at the beginning of the array and argument <paramref name="max" /> be the last element.</param>
        /// <returns>
        /// An array of consecutive integers.
        /// </returns>
        /// <exception cref="System.ArgumentException">Occurs when <paramref name="min" /> is larger than <paramref name="max" />.</exception>
        public static int[] CreateConsecutiveIntegers(int min, int max, bool descending = false)
        {
            int i = 0;
            if (min <= max)
            {
                var result = new int[max - min + 1];
                if (descending)
                {
                    while (min <= max)
                    {
                        result.SetValue(max, i);
                        --max;
                        ++i;
                    }
                }
                else
                {
                    while (min <= max)
                    {
                        result.SetValue(min, i);
                        ++min;
                        ++i;
                    }
                }
                return result;
            }
            else throw (new ArgumentException(GeneralResources.ERR_InvalidMinMax.Scan("min", "max")));
        }

        /// <summary>
        /// Gets an array of ordered consecutive unsigned integers.
        /// </summary>
        /// <param name="min">The minimum value in the array.</param>
        /// <param name="max">The maximum value in the array.</param>
        /// <param name="descending">Indicates whether the array elements are in descending order or ascending order.
        /// If <c>true</c>, argument <paramref name="min" /> will be placed at the end of the array and argument <paramref name="max" /> be the first element;
        /// if <c>false</c>, argument <paramref name="min" /> will be placed at the beginning of the array and argument <paramref name="max" /> be the last element.</param>
        /// <returns>
        /// An array of consecutive unsigned integers.
        /// </returns>
        /// <exception cref="System.ArgumentException">Occurs when <paramref name="min" /> is larger than <paramref name="max" />.</exception>
        public static uint[] CreateConsecutiveUIntegers(uint min, uint max, bool descending = false)
        {
            int i = 0;
            if (min <= max)
            {
                var result = new uint[max - min + 1];
                if (descending)
                {
                    while (min <= max)
                    {
                        result.SetValue(max, i);
                        --max;
                        ++i;
                    }
                }
                else
                {
                    while (min <= max)
                    {
                        result.SetValue(min, i);
                        ++min;
                        ++i;
                    }
                }
                return result;
            }
            else throw (new ArgumentException(GeneralResources.ERR_InvalidMinMax.Scan("min", "max")));
        }

        /// <summary>
        /// Gets an array of ordered consecutive 64-bit integers.
        /// </summary>
        /// <param name="min">The minimum value in the array.</param>
        /// <param name="max">The maximum value in the array.</param>
        /// <param name="descending">Indicates whether the array elements are in descending order or ascending order.
        /// If <c>true</c>, argument <paramref name="min" /> will be placed at the end of the array and argument <paramref name="max" /> be the first element;
        /// if <c>false</c>, argument <paramref name="min" /> will be placed at the beginning of the array and argument <paramref name="max" /> be the last element.</param>
        /// <returns>
        /// An array of consecutive 64-bit integers.
        /// </returns>
        /// <exception cref="System.ArgumentException">Occurs when <paramref name="min" /> is larger than <paramref name="max" />.</exception>
        public static long[] CreateConsecutiveLongs(long min, long max, bool descending = false)
        {
            int i = 0;
            if (min <= max)
            {
                var result = new long[max - min + 1];
                if (descending)
                {
                    while (min <= max)
                    {
                        result.SetValue(max, i);
                        --max;
                        ++i;
                    }
                }
                else
                {
                    while (min <= max)
                    {
                        result.SetValue(min, i);
                        ++min;
                        ++i;
                    }
                }
                return result;
            }
            else throw (new ArgumentException(GeneralResources.ERR_InvalidMinMax.Scan("min", "max")));
        }

        /// <summary>
        /// Gets an array of ordered consecutive 64-bit unsigned integers.
        /// </summary>
        /// <param name="min">The minimum value in the array.</param>
        /// <param name="max">The maximum value in the array.</param>
        /// <param name="descending">Indicates whether the array elements are in descending order or ascending order.
        /// If <c>true</c>, argument <paramref name="min" /> will be placed at the end of the array and argument <paramref name="max" /> be the first element;
        /// if <c>false</c>, argument <paramref name="min" /> will be placed at the beginning of the array and argument <paramref name="max" /> be the last element.</param>
        /// <returns>
        /// An array of consecutive 64-bit unsigned integers.
        /// </returns>
        /// <exception cref="System.ArgumentException">Occurs when <paramref name="min" /> is larger than <paramref name="max" />.</exception>
        public static ulong[] CreateConsecutiveULongs(ulong min, ulong max, bool descending = false)
        {
            int i = 0;
            if (min <= max)
            {
                var result = new ulong[max - min + 1];
                if (descending)
                {
                    while (min <= max)
                    {
                        result.SetValue(max, i);
                        --max;
                        ++i;
                    }
                }
                else
                {
                    while (min <= max)
                    {
                        result.SetValue(min, i);
                        ++min;
                        ++i;
                    }
                }
                return result;
            }
            else throw (new ArgumentException(GeneralResources.ERR_InvalidMinMax.Scan("min", "max")));
        }
    }
}
