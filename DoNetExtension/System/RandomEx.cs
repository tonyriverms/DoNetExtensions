using System_Extension_Library.System;

namespace System
{
    /// <summary>
    /// Provides extension methods for <see cref="System.Random"/> class.
    /// </summary>
    public static class RandomEx
    {
        /// <summary>
        /// Gets a randomly constructed string.
        /// </summary>
        /// <param name="rnd">A <see cref="System.Random"/> instance.</param>
        /// <param name="boundChr1">A digit value bound that represents a Unicode character.</param>
        /// <param name="boundChr2">Another digit value bound that represents a Unicode character.</param>
        /// <param name="length">The length of the output string.</param>
        /// <returns>The random output string.</returns>
        public static string NextString(this Random rnd, char boundChr1, char boundChr2, int length)
        {
            int min, max;
            if (boundChr1 < boundChr2)
            {
                min = boundChr1;
                max = boundChr2 + 1;
            }
            else
            {
                min = boundChr2;
                max = boundChr1 + 1;
            }
            char[] str = new char[length];
            while (length-- > 0)
                str[length] = (char)rnd.Next(min, max);
            return new string(str);
        }

        /// <summary>
        /// Gets a randomly constructed string.
        /// </summary>
        /// <param name="r">A <see cref="System.Random"/> instance.</param>
        /// <param name="boundChr1">A digit value bound that represents a Unicode character.</param>
        /// <param name="boundChr2">Another digit value bound that represents a Unicode character.</param>
        /// <param name="minlen">The minimum length of the output string.</param>
        /// <param name="maxlen">The maximum length of the output string.</param>
        /// <returns>The random output string.</returns>
        public static string NextString(this Random r, char boundChr1, char boundChr2, int minlen, int maxlen)
        {
            return r.NextString(boundChr1, boundChr2, (new Random()).Next(minlen, maxlen + 1));
        }

        /// <summary>
        /// Gets a random integer within a specific range.
        /// </summary>
        /// <param name="rnd">A <see cref="System.Random" /> instance.</param>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">The upper bound of the random number returned.
        /// <paramref name="maxValue" /> must be greater than or equal to <paramref name="minValue" />.
        /// <para>Whether this bound is inclusive is determined by the third argument <paramref name="maxValueInclusive" />.</para></param>
        /// <param name="maxValueInclusive">Specifies whether <paramref name="maxValue" /> can be returned.</param>
        /// <returns>
        /// A random integer.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when <paramref name="minValue"/> is greater than <paramref name="maxValue"/>.</exception>
        public unsafe static int Next(this Random rnd, int minValue, int maxValue, bool maxValueInclusive)
        {
            ExceptionHelper.MinMaxArgumentCheck(minValue, maxValue);
            if (minValue == maxValue) return minValue;
            else
            {
                var buffer = new byte[4];
                rnd.NextBytes(buffer);
                fixed (byte* bufferPtr = buffer)
                {
                    var randomValue = *((uint*)bufferPtr);
                    return (int)(randomValue % (uint)(maxValue - minValue + (maxValueInclusive ? 1 : 0))) + minValue;
                }
            }
        }

        /// <summary>
        /// Gets a random 64-bit integer within a specific range.
        /// </summary>
        /// <param name="rnd">A <see cref="System.Random" /> instance.</param>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">The exclusive upper bound of the random number returned.
        /// <paramref name="maxValue" /> must be greater than or equal to <paramref name="minValue" />.
        /// <para>Whether this bound is inclusive is determined by the third argument <paramref name="maxValueInclusive" />.</para></param>
        /// <returns>
        /// A random 64-bit integer.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when <paramref name="minValue" /> is greater than <paramref name="maxValue" />.</exception>
        public unsafe static long Next(this Random rnd, long minValue, long maxValue)
        {
            ExceptionHelper.MinMaxArgumentCheck(minValue, maxValue);
            if (minValue == maxValue) return minValue;
            else
            {
                var buffer = new byte[8];
                rnd.NextBytes(buffer);
                fixed (byte* bufferPtr = buffer)
                {
                    var randomValue = *((ulong*)bufferPtr);
                    return (long)(randomValue % (ulong)(maxValue - minValue)) + minValue;
                }
            }
        }

        /// <summary>
        /// Gets a random 64-bit integer within a specific range.
        /// </summary>
        /// <param name="rnd">A <see cref="System.Random" /> instance.</param>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">The upper bound of the random number returned.
        /// <paramref name="maxValue" /> must be greater than or equal to <paramref name="minValue" />.
        /// <para>Whether this bound is inclusive is determined by the third argument <paramref name="maxValueInclusive" />.</para></param>
        /// <param name="maxValueInclusive">Specifies whether <paramref name="maxValue" /> can be returned.</param>
        /// <returns>
        /// A 64-bit random integer.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when <paramref name="minValue" /> is greater than <paramref name="maxValue" />.</exception>
        public unsafe static long Next(this Random rnd, long minValue, long maxValue, bool maxValueInclusive)
        {
            ExceptionHelper.MinMaxArgumentCheck(minValue, maxValue);
            if (minValue == maxValue) return minValue;
            else
            {
                var buffer = new byte[8];
                rnd.NextBytes(buffer);
                fixed (byte* bufferPtr = buffer)
                {
                    var randomValue = *((ulong*)bufferPtr);
                    return (long)(randomValue % (ulong)(maxValue - minValue + (maxValueInclusive ? 1 : 0))) + minValue;
                }
            }
        }

        /// <summary>
        /// Returns a random bool value.
        /// </summary>
        /// <param name="rnd">A <see cref="System.Random"/> instance.</param>
        /// <returns>A random bool value.</returns>
        public static bool NextBoolean(this Random rnd)
        {
            double val = rnd.NextDouble();
            if (val < 0.5) return true;
            else if (val > 0.5) return false;
            else
            {
                int tc = Environment.TickCount;
                if (tc % 2 == 0) return true;
                else return false;
            }
        }

        /// <summary>
        /// Returns a random bool value.
        /// </summary>
        /// <returns>A random bool value.</returns>
        public static bool NextBoolean()
        {
            var rnd = new Random();
            return rnd.NextBoolean();
        }

        /// <summary>
        /// Returns a random bool value.
        /// </summary>
        /// <param name="rnd">The Random instance to generate the random value.</param>
        /// <param name="probabilityOfTrue">The odds of returning true. The value must be set between 0 and 1.</param>
        /// <returns>A random bool value.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when <paramref name="probabilityOfTrue"/> is smaller than 0 or greater than 1.</exception>
        public static bool NextBoolean(this Random rnd, double probabilityOfTrue)
        {
            ExceptionHelper.ArgumentRangeRequired("probabilityOfTrue", probabilityOfTrue, 0, true, 1, true);
            if (probabilityOfTrue == 1) return true;
            else if (probabilityOfTrue == 0) return false;
            else
            {
                double val = rnd.NextDouble();

                if (val < probabilityOfTrue) return true;
                else if (val > probabilityOfTrue) return false;
                else
                {
                    int tc = Environment.TickCount;
                    if (tc % 2 == 0) return true;
                    else return false;
                }
            }
        }

        /// <summary>
        /// Returns a random bool value.
        /// </summary>
        /// <param name="probabilityOfTrue">The odds of returning true. The value must be set between 0 and 1.</param>
        /// <returns>A random bool value.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when <paramref name="probabilityOfTrue"/> is smaller than 0 or greater than 1.</exception>
        public static bool NextBoolean(double probabilityOfTrue)
        {
            var rnd = new Random();
            return rnd.NextBoolean(probabilityOfTrue);
        }

        /// <summary>
        /// Gets a random <see cref="System.Double"/> number within a specific range.
        /// </summary>
        /// <param name="rnd">A <see cref="System.Random"/> instance.</param>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">The inclusive upper bound of the random number returned.</param>
        /// <returns>A random <see cref="System.Double"/> number.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when <paramref name="min"/> is greater than <paramref name="max"/>.</exception>
        public static double NextDouble(this Random rnd, double minValue, double maxValue)
        {
            ExceptionHelper.MinMaxArgumentCheck(minValue, maxValue);
            if (minValue == maxValue) return minValue;
            else return rnd.NextDouble() * (maxValue - minValue) + minValue;
        }

        /// <summary>
        /// Gets a random number within a specific range. The first argument <paramref name="value1"/> can be larger than <paramref name="value2"/>.
        /// </summary>
        /// <param name="rnd">A <see cref="System.Random"/> instance.</param>
        /// <param name="value1">One inclusive bound of the random number returned.</param>
        /// <param name="value2">The other inclusive bound of the random number returned.</param>
        /// <returns>System.Double.</returns>
        public static double NextDoubleBetween(this Random rnd, double value1, double value2)
        {
            if (value1 == value2) return value1;
            else return rnd.NextDouble() * (value2 - value1) + value1;
        }
    }
}
