using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System_Extension_Library.System;
using System_Extension_Library.System.ArrayEx;
using DoNetExtension.System;

namespace System
{
    public static partial class ArrayEx
    {
        #region Strings

        /// <summary>
        /// Gets a random string array.
        /// </summary>
        /// <param name="minChr">The "minimum" possible character in each element of the string array. 
        /// A character is considered "smaller" than another if its representation integer is also smaller.</param>
        /// <param name="maxChr">The "maximum" possible character in each element of the string array.
        /// A character is considered "larger" than another if its representation integer is also larger.</param>
        /// <param name="minStringLen">Specifies the minimum possible string length in the array.</param>
        /// <param name="maxStringLen">Specifies the maximum possible string length in the array.</param>
        /// <param name="minLength">Specifies the minimum length of the string array.</param>
        /// <param name="maxLength">Specifies the maximum length of the string array.</param>
        /// <param name="random">A <see cref="System.Random" /> object that generates random values.
        /// If this argument is not specified, a new <see cref="System.Random" /> instance will be used.</param>
        /// <returns>A random string array.</returns>
        public static string[] CreateRandomStrings(char minChr, char maxChr, int minStringLen, int maxStringLen, int minLength, int maxLength, Random random = null)
        {
            if (random == null) random = new Random();
            var count = random.Next(minLength, maxLength + 1);
            var arr = new string[count];
            for (int i = 0; i < arr.Length; ++i)
                arr[i] = random.NextString(minChr, maxChr, minStringLen, maxStringLen);
            return arr;
        }

        #endregion

        #region Booleans

        /// <summary>
        /// Gets a random bool array.
        /// </summary>
        /// <param name="length">The length of the array.</param>
        /// <param name="random">A <see cref="System.Random" /> object that generates random numbers.
        /// If this argument is not specified, a new <see cref="System.Random" /> instance will be used.</param>
        /// <returns>
        /// A random bool array.
        /// </returns>
        public static bool[] CreateRandomBoolArray(int length, Random random = null)
        {
            var arr = new bool[length];
            if (random == null) random = new Random();
            while (length != 0)
                arr[--length] = random.NextBoolean();

            return arr;

        }

        /// <summary>
        /// Gets a random bool array whose length is inclusively between <paramref name="minLength" /> and <paramref name="maxLength" />.
        /// </summary>
        /// <param name="minLength">Specifies the minimum length of the random array.</param>
        /// <param name="maxLength">Specifies the maximum length of the random array.</param>
        /// <param name="random">
        /// A <see cref="System.Random"/> object that generates random values. 
        /// If this argument is not specified, a new <see cref="System.Random"/> instance will be used.
        /// </param>
        /// <returns>
        /// A random bool array.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when <paramref name="minLength"/> or <paramref name="maxLength"/> is non-positive.</exception>
        /// <exception cref="System.ArgumentException">
        /// Occurs when <paramref name="minLength"/> is larger than <paramref name="maxLength"/> or 
        /// <paramref name="maxLength"/> equals the maximum integer a <see cref="System.Int32"/> integer can represent.
        /// </exception>
        public static bool[] CreateRandomBoolArray(int minLength, int maxLength, Random random = null)
        {
            if (minLength <= 0)
                throw new ArgumentOutOfRangeException("minLength", minLength, GeneralResources.ERR_PositiveValueRequired.Scan("minLength"));

            if (maxLength <= 0)
                throw new ArgumentOutOfRangeException("maxLength", minLength, GeneralResources.ERR_PositiveValueRequired.Scan("maxLength"));

            if (minLength > maxLength)
                throw new ArgumentException(GeneralResources.ERR_InvalidMinMax.Scan("minLength", "maxLength"));

            if (maxLength == int.MaxValue)
                throw new ArgumentException(GeneralResources.ERR_InvalidValue.Scan("maxLength"));

            ++maxLength;
            if (random == null) random = new Random();

            return CreateRandomBoolArray
                (random.Next(minLength, maxLength), random);
        }

        #endregion

        #region Bytes

        /// <summary>
        /// Gets a random byte array without repetition of elements.
        /// </summary>
        /// <param name="length">Specifies the length of the random array.</param>
        /// <returns>A random byte array without repetition of elements.</returns>
        public static byte[] CreateDistinctRandomBytes(byte length, DistinctRandomAlgorithms algorithm = DistinctRandomAlgorithms.Auto, Random random = null)
        {
            return CreateDistinctRandomBytes(byte.MinValue, byte.MaxValue - 1, length, algorithm, random);
        }

        /// <summary>
        /// Gets a random byte array of random length without repetition of elements.
        /// </summary>
        /// <param name="minLength">The minimum length of the array.</param>
        /// <param name="maxLength">The maximum length of the array.</param>
        /// <param name="algorithm">Specifies the algorithm used.</param>
        /// <param name="random">A <see cref="System.Random" /> object that generates random bytes.
        /// If this argument is not specified, a new <see cref="System.Random" /> instance will be used.</param>
        /// <returns>
        /// A random byte array without repetition of elements.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when <paramref name="minLength"/> or <paramref name="maxLength"/> is non-positive.</exception>
        /// <exception cref="System.ArgumentException">Occurs when <paramref name="minLength"/> is larger than <paramref name="maxLength"/> or <paramref name="maxLength"/> equals the maximum integer a <see cref="System.Int32"/> integer can represent.</exception>
        public static byte[] CreateDistinctRandomBytes(byte minLength, byte maxLength, DistinctRandomAlgorithms algorithm = DistinctRandomAlgorithms.Auto, Random random = null)
        {
            if (minLength == 0)
                throw new ArgumentOutOfRangeException("minLength", minLength, GeneralResources.ERR_PositiveValueRequired.Scan("minLength"));

            if (maxLength == 0)
                throw new ArgumentOutOfRangeException("maxLength", minLength, GeneralResources.ERR_PositiveValueRequired.Scan("maxLength"));

            if (minLength > maxLength)
                throw new ArgumentException(GeneralResources.ERR_InvalidMinMax.Scan("minLength", "maxLength"));

            if (maxLength == sbyte.MaxValue)
                throw new ArgumentException(GeneralResources.ERR_InvalidValue.Scan("maxLength"));

            ++maxLength;
            if (random == null) random = new Random();
            return CreateDistinctRandomBytes
                ((byte)random.Next(minLength, maxLength), algorithm, random);
        }

        /// <summary>
        /// Gets a random byte array without repetition of elements.
        /// </summary>
        /// <param name="min">The minium possible value in the random array.</param>
        /// <param name="max">The maxium possible value in the random array.</param>
        /// <param name="length">Specifies the length of the random array.</param>
        /// <param name="algorithm">Specifies the algorithm used.</param>
        /// <param name="random">A <see cref="System.Random" /> object that generates random bytes.
        /// If this argument is not specified, a new <see cref="System.Random" /> instance will be used.</param>
        /// <returns>
        /// A random byte array without repetition of elements.
        /// </returns>
        /// <exception cref="System.ArgumentException">Occurs when <paramref name="min" /> is larger than <paramref name="max" />.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when <paramref name="max" /> equals the maximum number a <see cref="System.Int32" /> integer can represent.</exception>
        /// <exception cref="System.InvalidOperationException">Occurs when the value of <paramref name="length" /> is smaller than <paramref name="max" /> - <paramref name="min" /> + 1.</exception>
        public static byte[] CreateDistinctRandomBytes(byte min, byte max, byte length, DistinctRandomAlgorithms algorithm = DistinctRandomAlgorithms.Auto, Random random = null)
        {
            if (min > max)
                throw (new ArgumentException(GeneralResources.ERR_InvalidMinMax.Scan("min", "max")));

            if (max == byte.MaxValue)
                throw (new ArgumentOutOfRangeException("max"));

            ++max;

            var range = (byte)(max - min);
            if (range < length)
                throw new InvalidOperationException(ArrayExResources.ERR_ArrayEx_UnableToCreateDistinctRandomArray);

            if (range == length)
            {
                var arr = CreateConsecutiveBytes(min, max);
                arr.Shuffle(random);
                return arr;
            }
            else
            {
                var arr = new byte[length];
                if (random == null) random = new Random();

                switch (algorithm)
                {
                    default:
                        {
                            var ratio = (double)length / range;
                            if (ratio > 0.2) goto case DistinctRandomAlgorithms.Swap;
                            else goto case DistinctRandomAlgorithms.SimpleHash;
                        }
                    case DistinctRandomAlgorithms.SimpleHash:
                        {
                            var hasheset = new HashSet<byte>();
                            while (length != 0)
                            {
                                byte val;
                                do
                                    val = (byte)random.Next(min, max);
                                while (hasheset.Contains(val));
                                hasheset.Add(val);
                                arr[--length] = val;
                            }

                            break;
                        }
                    case DistinctRandomAlgorithms.Swap:
                        {
                            var tempArr = new byte[range];

                            byte val;
                            var length2 = length; //max is used to store "length" here

                            while (length != 0)
                            {
                                val = (byte)random.Next(0, range);
                                --range;
                                --length;

                                if (tempArr[val] == 0)
                                    arr[length] = (byte)((int)val + min);
                                else
                                    arr[length] = (byte)((int)tempArr[val] + min);

                                tempArr[val] = tempArr[range] == 0 ? range : tempArr[range];
                            }

                            break;
                        }
                    case DistinctRandomAlgorithms.SwapHash:
                        {
                            var dict = new Dictionary<int, byte>();
                            var mark = range - length;
                            byte val;
                            var tarr = new byte[length];
                            var length2 = length;

                            while (length != 0)
                            {
                                val = (byte)random.Next(0, range);
                                --range;
                                --length;

                                if (val < mark)
                                {
                                    byte tval1;
                                    var exist1 = dict.TryGetValue(val, out tval1);
                                    byte tval2 = tarr[length];
                                    var exist2 = tval2 != 0;

                                    if (exist1)
                                    {
                                        dict[val] = exist2 ? tval2 : range;
                                        tarr[length] = tval1;
                                    }
                                    else
                                    {
                                        dict.Add(val, exist2 ? tval2 : range);
                                        tarr[length] = val;
                                    }
                                }
                                else
                                {
                                    var idx = val - mark;
                                    if (tarr[idx] == 0)
                                    {
                                        if (tarr[length] == 0)
                                        {
                                            tarr[length] = val;
                                            tarr[idx] = range;
                                        }
                                        else
                                        {
                                            tarr[idx] = tarr[length];
                                            tarr[length] = val;
                                        }
                                    }
                                    else
                                    {
                                        if (tarr[length] == 0)
                                        {
                                            tarr[length] = tarr[idx];
                                            tarr[idx] = range;
                                        }
                                        else
                                        {
                                            var temp = tarr[idx];
                                            tarr[idx] = tarr[length];
                                            tarr[length] = temp;
                                        }
                                    }
                                }
                            }

                            for (int i = 0; i < length2;)
                            {
                                arr[i] = (byte)((int)min + tarr[i]);
                                ++i;
                            }

                            break;
                        }
                }


                return arr;
            }
        }


        /// <summary>
        /// Gets a non-empty random byte array that contains at most 102400 bytes.
        /// </summary>
        /// <returns>A random byte array.</returns>
        public static byte[] CreateRandomBytes()
        {
            return CreateRandomBytes(byte.MinValue, byte.MaxValue, 1, 102400);
        }

        /// <summary>
        /// Gets a random byte array of the specified length.
        /// </summary>
        /// <param name="length">Specifies the length of the random array.</param>
        /// <param name="random">
        /// A <see cref="System.Random"/> object that generates random numbers. 
        /// If this argument is not specified, a new <see cref="System.Random"/> instance will be used.
        /// </param>
        /// <returns>
        /// A random byte array.
        /// </returns>
        public static byte[] CreateRandomBytes(long length, Random random)
        {
            return CreateRandomBytes(byte.MinValue, byte.MaxValue, length, random);
        }

        /// <summary>
        /// Gets a random byte array whose length is inclusively between <paramref name="minLength" /> and <paramref name="maxLength" />.
        /// </summary>
        /// <param name="minLength">Specifies the minimum length of the random array.</param>
        /// <param name="maxLength">Specifies the maximum length of the random array.</param>
        /// <param name="random">A <see cref="System.Random" /> object that generates random numbers.
        /// If this argument is not specified, a new <see cref="System.Random" /> instance will be used.</param>
        /// <returns>
        /// A random byte array.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when <paramref name="minLength" /> or <paramref name="maxLength" /> is non-positive.</exception>
        /// <exception cref="System.ArgumentException">Occurs when <paramref name="minLength" /> is larger than <paramref name="maxLength" /> or
        /// <paramref name="maxLength" /> equals the maximum integer a <see cref="System.Int64" /> integer can represent.</exception>
        public static byte[] CreateRandomBytes(long minLength, long maxLength, Random random = null)
        {
            if (minLength <= 0)
                throw new ArgumentOutOfRangeException("minLength", minLength, GeneralResources.ERR_PositiveValueRequired.Scan("minLength"));

            if (maxLength <= 0)
                throw new ArgumentOutOfRangeException("maxLength", minLength, GeneralResources.ERR_PositiveValueRequired.Scan("maxLength"));

            if (minLength > maxLength)
                throw new ArgumentException(GeneralResources.ERR_InvalidMinMax.Scan("minLength", "maxLength"));

            if (maxLength == long.MaxValue)
                throw new ArgumentException(GeneralResources.ERR_InvalidValue.Scan("maxLength"));
            ++maxLength;

            if (random == null) random = new Random();

            return CreateRandomBytes
                (random.Next(minLength, maxLength), random);
        }

        /// <summary>
        /// Gets a random byte array whose length is inclusively between <paramref name="minLength" /> and <paramref name="maxLength" />.
        /// You may specify the maximum and minimum possible value that occurs in the returned array.
        /// </summary>
        /// <param name="min">The minium possible value in the random array.</param>
        /// <param name="max">The maxium possible value in the random array.</param>
        /// <param name="minLength">Specifies the minimum length of the random array.</param>
        /// <param name="maxLength">Specifies the maximum length of the random array.</param>
        /// <param name="random">A <see cref="System.Random" /> object that generates random numbers.
        /// If this argument is not specified, a new <see cref="System.Random" /> instance will be used.</param>
        /// <returns>
        /// A random byte array.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when <paramref name="minLength"/> or <paramref name="maxLength"/> is non-positive.</exception>
        /// <exception cref="System.ArgumentException">Occurs when <paramref name="minLength" /> is larger than <paramref name="maxLength" /> or
        /// <paramref name="maxLength" /> equals the maximum integer a <see cref="System.Int64" /> integer can represent.</exception>
        public static byte[] CreateRandomBytes(byte min, byte max, long minLength, long maxLength, Random random = null)
        {
            if (minLength <= 0)
                throw new ArgumentOutOfRangeException
                    ("minLength", minLength, GeneralResources.ERR_PositiveValueRequired.Scan("minLength"));

            if (maxLength <= 0)
                throw new ArgumentOutOfRangeException
                    ("maxLength", minLength, GeneralResources.ERR_PositiveValueRequired.Scan("maxLength"));

            if (minLength > maxLength)
                throw (new ArgumentException(GeneralResources.ERR_InvalidMinMax
                    .Scan("minLength", "maxLength")));

            if (maxLength == long.MaxValue)
                throw new ArgumentException(GeneralResources.ERR_InvalidValue.Scan("maxLength"));
            ++maxLength;

            if (random == null) random = new Random();
            return CreateRandomBytes(min, max, random.Next(minLength, maxLength), random);
        }

        /// <summary>
        /// Gets a random byte array of the specified length.
        /// </summary>
        /// <param name="min">The minium possible value in the random array.</param>
        /// <param name="max">The maxium possible value in the random array.</param>
        /// <param name="length">Specifies the length of the random array.</param>
        /// <param name="random">A <see cref="System.Random" /> object that generates random numbers.
        /// If this argument is not specified, a new <see cref="System.Random" /> instance will be used.</param>
        /// <returns>
        /// A random byte array.
        /// </returns>
        /// <exception cref="System.ArgumentException">Occurs when <paramref name="min" /> is larger than <paramref name="max" />.</exception>
        public static byte[] CreateRandomBytes(byte min, byte max, long length, Random random = null)
        {
            if (min > max)
                throw (new ArgumentException(GeneralResources.ERR_InvalidMinMax.Scan("min", "max")));

            var bmax = max + 1;
            var arr = new byte[length];

            if (random == null) random = new Random();

            while (length-- > 0)
                arr[length] = (byte)random.Next(min, bmax);

            return arr;
        }

        #endregion

        #region Int16 Integers

        /// <summary>
        /// Gets a random <see cref="System.Int16"/> integer array without repetition of elements.
        /// </summary>
        /// <param name="length">Specifies the length of the random array.</param>
        /// <returns>A random <see cref="System.Int16"/> integer array without repetition of elements.</returns>
        public static short[] CreateDistinctRandomShorts(ushort length, DistinctRandomAlgorithms algorithm = DistinctRandomAlgorithms.Auto, Random random = null)
        {
            return CreateDistinctRandomShorts(short.MinValue, short.MaxValue - 1, length, algorithm, random);
        }

        /// <summary>
        /// Gets a random short <see cref="System.Int16"/> integer array of random length without repetition of elements.
        /// </summary>
        /// <param name="minLength">The minimum length of the array.</param>
        /// <param name="maxLength">The maximum length of the array.</param>
        /// <param name="algorithm">Specifies the algorithm used.</param>
        /// <param name="random">A <see cref="System.Random" /> object that generates random numbers.
        /// If this argument is not specified, a new <see cref="System.Random" /> instance will be used.</param>
        /// <returns>
        /// A random short integer array without repetition of elements.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when <paramref name="minLength"/> or <paramref name="maxLength"/> is non-positive.</exception>
        /// <exception cref="System.ArgumentException">Occurs when <paramref name="minLength"/> is larger than <paramref name="maxLength"/> or <paramref name="maxLength"/> equals the maximum integer a <see cref="System.Int32"/> integer can represent.</exception>
        public static short[] CreateDistinctRandomShorts(ushort minLength, ushort maxLength, DistinctRandomAlgorithms algorithm = DistinctRandomAlgorithms.Auto, Random random = null)
        {
            if (minLength <= 0)
                throw new ArgumentOutOfRangeException("minLength", minLength, GeneralResources.ERR_PositiveValueRequired.Scan("minLength"));

            if (maxLength <= 0)
                throw new ArgumentOutOfRangeException("maxLength", minLength, GeneralResources.ERR_PositiveValueRequired.Scan("maxLength"));

            if (minLength > maxLength)
                throw new ArgumentException(GeneralResources.ERR_InvalidMinMax.Scan("minLength", "maxLength"));

            if (maxLength == ushort.MaxValue)
                throw new ArgumentException(GeneralResources.ERR_InvalidValue.Scan("maxLength"));

            ++maxLength;
            if (random == null) random = new Random();
            return CreateDistinctRandomShorts
                ((ushort)random.Next(minLength, maxLength), algorithm, random);
        }

        /// <summary>
        /// Gets a random <see cref="System.Int16"/> integer array without repetition of elements.
        /// </summary>
        /// <param name="min">The minium possible value in the random array.</param>
        /// <param name="max">The maxium possible value in the random array.</param>
        /// <param name="length">Specifies the length of the random array.</param>
        /// <param name="algorithm">Specifies the algorithm used.</param>
        /// <param name="random">A <see cref="System.Random" /> object that generates random numbers.
        /// If this argument is not specified, a new <see cref="System.Random" /> instance will be used.</param>
        /// <returns>
        /// A random <see cref="System.Int16"/> integer array without repetition of elements.
        /// </returns>
        /// <exception cref="System.ArgumentException">Occurs when <paramref name="min" /> is larger than <paramref name="max" />.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when <paramref name="max" /> equals the maximum number a <see cref="System.Int32" /> integer can represent.</exception>
        /// <exception cref="System.InvalidOperationException">Occurs when the value of <paramref name="length" /> is smaller than <paramref name="max" /> - <paramref name="min" /> + 1.</exception>
        public static short[] CreateDistinctRandomShorts(short min, short max, ushort length, DistinctRandomAlgorithms algorithm = DistinctRandomAlgorithms.Auto, Random random = null)
        {
            if (min > max)
                throw (new ArgumentException(GeneralResources.ERR_InvalidMinMax.Scan("min", "max")));

            if (max == short.MaxValue)
                throw (new ArgumentOutOfRangeException("max"));

            ++max;

            var range = (ushort)(max - min);
            if (range < length)
                throw new InvalidOperationException(ArrayExResources.ERR_ArrayEx_UnableToCreateDistinctRandomArray);

            if (range == length)
            {
                var arr = CreateConsecutiveShorts(min, max);
                arr.Shuffle(random);
                return arr;
            }
            else
            {
                var arr = new short[length];

                if (random == null) random = new Random();

                switch (algorithm)
                {
                    default:
                        {
                            var ratio = (double)length / range;
                            if (ratio > 0.2)
                            {
                                if (length > 1000) goto case DistinctRandomAlgorithms.SwapHash;
                                else goto case DistinctRandomAlgorithms.Swap;
                            }
                            else goto case DistinctRandomAlgorithms.SimpleHash;
                        }
                    case DistinctRandomAlgorithms.SimpleHash:
                        {
                            var hasheset = new HashSet<short>();
                            while (length != 0)
                            {
                                short val;
                                do
                                    val = (short)random.Next(min, max);
                                while (hasheset.Contains(val));
                                hasheset.Add(val);
                                arr[--length] = val;
                            }

                            break;
                        }
                    case DistinctRandomAlgorithms.Swap:
                        {
                            var tempArr = new ushort[range];

                            ushort val;
                            var length2 = length; //max is used to store "length" here

                            while (length != 0)
                            {
                                val = (ushort)random.Next(0, range);
                                --range;
                                --length;

                                if (tempArr[val] == 0)
                                    arr[length] = (short)((int)val + min);
                                else
                                    arr[length] = (short)((int)tempArr[val] + min);

                                tempArr[val] = tempArr[range] == 0 ? range : tempArr[range];
                            }

                            break;
                        }
                    case DistinctRandomAlgorithms.SwapHash:
                        {
                            var dict = new Dictionary<int, ushort>();
                            var mark = range - length;
                            ushort val;
                            var tarr = new ushort[length];
                            var length2 = length;

                            while (length != 0)
                            {
                                val = (ushort)random.Next(0, range);
                                --range;
                                --length;

                                if (val < mark)
                                {
                                    ushort tval1;
                                    var exist1 = dict.TryGetValue(val, out tval1);
                                    ushort tval2 = tarr[length];
                                    var exist2 = tval2 != 0;

                                    if (exist1)
                                    {
                                        dict[val] = exist2 ? tval2 : range;
                                        tarr[length] = tval1;
                                    }
                                    else
                                    {
                                        dict.Add(val, exist2 ? tval2 : range);
                                        tarr[length] = val;
                                    }
                                }
                                else
                                {
                                    var idx = val - mark;
                                    if (tarr[idx] == 0)
                                    {
                                        if (tarr[length] == 0)
                                        {
                                            tarr[length] = val;
                                            tarr[idx] = range;
                                        }
                                        else
                                        {
                                            tarr[idx] = tarr[length];
                                            tarr[length] = val;
                                        }
                                    }
                                    else
                                    {
                                        if (tarr[length] == 0)
                                        {
                                            tarr[length] = tarr[idx];
                                            tarr[idx] = range;
                                        }
                                        else
                                        {
                                            var temp = tarr[idx];
                                            tarr[idx] = tarr[length];
                                            tarr[length] = temp;
                                        }
                                    }
                                }
                            }

                            for (int i = 0; i < length2;)
                            {
                                arr[i] = (short)((int)min + tarr[i]);
                                ++i;
                            }

                            break;
                        }
                }


                return arr;
            }
        }

        /// <summary>
        /// Gets a non-empty random <see cref="System.Int16"/> integer array that contains at most 2621440 integers.
        /// </summary>
        /// <returns>A random <see cref="System.Int16"/> integer array.</returns>
        public static short[] CreateRandomShorts()
        {
            return CreateRandomShorts(short.MinValue, short.MaxValue - 1, 1, 2621440);
        }

        /// <summary>
        /// Gets a random <see cref="System.Int16"/> integer array of the specified length.
        /// </summary>
        /// <param name="length">Specifies the length of the random array.</param>
        /// <param name="random">
        /// A <see cref="System.Random"/> object that generates random numbers. 
        /// If this argument is not specified, a new <see cref="System.Random"/> instance will be used.
        /// </param>
        /// <returns>
        /// A random <see cref="System.Int16"/> integer array.
        /// </returns>
        public static short[] CreateRandomShorts(long length, Random random)
        {
            return CreateRandomShorts(short.MinValue, short.MaxValue - 1, length, random);
        }

        /// <summary>
        /// Gets a random <see cref="System.Int16" /> integer array whose length is inclusively between <paramref name="minLength" /> and <paramref name="maxLength" />.
        /// </summary>
        /// <param name="minLength">Specifies the minimum length of the random array.</param>
        /// <param name="maxLength">Specifies the maximum length of the random array.</param>
        /// <param name="random">A <see cref="System.Random" /> object that generates random numbers.
        /// If this argument is not specified, a new <see cref="System.Random" /> instance will be used.</param>
        /// <returns>
        /// A random <see cref="System.Int16" /> integer array.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when <paramref name="minLength" /> or <paramref name="maxLength" /> is non-positive.</exception>
        /// <exception cref="System.ArgumentException">Occurs when <paramref name="minLength" /> is larger than <paramref name="maxLength" /> or
        /// <paramref name="maxLength" /> equals the maximum integer a <see cref="System.Int64" /> integer can represent.</exception>
        public static short[] CreateRandomShorts(long minLength, long maxLength, Random random = null)
        {
            if (minLength <= 0)
                throw new ArgumentOutOfRangeException("minLength", minLength, GeneralResources.ERR_PositiveValueRequired.Scan("minLength"));

            if (maxLength <= 0)
                throw new ArgumentOutOfRangeException("maxLength", minLength, GeneralResources.ERR_PositiveValueRequired.Scan("maxLength"));

            if (minLength > maxLength)
                throw new ArgumentException(GeneralResources.ERR_InvalidMinMax.Scan("minLength", "maxLength"));

            if (maxLength == long.MaxValue)
                throw new ArgumentException(GeneralResources.ERR_InvalidValue.Scan("maxLength"));
            ++maxLength;

            if (random == null) random = new Random();

            return CreateRandomShorts
                (random.Next(minLength, maxLength), random);
        }

        /// <summary>
        /// Gets a random <see cref="System.Int16"/> integer array whose length is inclusively between <paramref name="minLength" /> and <paramref name="maxLength" />.
        /// You may specify the maximum and minimum possible value that occurs in the returned array.
        /// </summary>
        /// <param name="min">The minium possible value in the random array.</param>
        /// <param name="max">The maxium possible value in the random array.</param>
        /// <param name="minLength">Specifies the minimum length of the random array.</param>
        /// <param name="maxLength">Specifies the maximum length of the random array.</param>
        /// <param name="random">A <see cref="System.Random" /> object that generates random numbers.
        /// If this argument is not specified, a new <see cref="System.Random" /> instance will be used.</param>
        /// <returns>
        /// A random <see cref="System.Int16"/> integer array.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when <paramref name="minLength"/> or <paramref name="maxLength"/> is non-positive.</exception>
        /// <exception cref="System.ArgumentException">Occurs when <paramref name="minLength" /> is larger than <paramref name="maxLength" /> or
        /// <paramref name="maxLength" /> equals the maximum integer a <see cref="System.Int64" /> integer can represent.</exception>
        public static short[] CreateRandomShorts(short min, short max, long minLength, long maxLength, Random random = null)
        {
            if (minLength <= 0)
                throw new ArgumentOutOfRangeException
                    ("minLength", minLength, GeneralResources.ERR_PositiveValueRequired.Scan("minLength"));

            if (maxLength <= 0)
                throw new ArgumentOutOfRangeException
                    ("maxLength", minLength, GeneralResources.ERR_PositiveValueRequired.Scan("maxLength"));

            if (minLength > maxLength)
                throw (new ArgumentException(GeneralResources.ERR_InvalidMinMax.Scan("minLength", "maxLength")));

            if (maxLength == long.MaxValue)
                throw new ArgumentException(GeneralResources.ERR_InvalidValue.Scan("maxLength"));
            ++maxLength;

            if (random == null) random = new Random();
            return CreateRandomShorts(min, max, random.Next(minLength, maxLength), random);
        }

        /// <summary>
        /// Gets a random <see cref="System.Int16"/> integer array of the specified length.
        /// </summary>
        /// <param name="min">The minium possible value in the random array.</param>
        /// <param name="max">The maxium possible value in the random array.</param>
        /// <param name="length">Specifies the length of the random array.</param>
        /// <param name="random">A <see cref="System.Random"/> object that generates random numbers. 
        /// If this argument is not specified, a new <see cref="System.Random"/> instance will be used.</param>
        /// <returns>
        /// A random <see cref="System.Int16"/> integer array.
        /// </returns>
        /// <exception cref="System.ArgumentException">Occurs when <paramref name="min"/> is larger than <paramref name="max"/>.</exception>
        public static short[] CreateRandomShorts(short min, short max, long length, Random random = null)
        {
            if (min > max)
                throw (new ArgumentException(GeneralResources.ERR_InvalidMinMax.Scan("min", "max")));

            var bmax = max + 1;

            var arr = new short[length];
            if (random == null) random = new Random();

            while (length != 0)
                arr[--length] = (short)random.Next(min, bmax);

            return arr;
        }

        #endregion

        #region Int32 Integers

        /// <summary>
        /// Gets a random integer array without repetition of elements.
        /// </summary>
        /// <param name="length">Specifies the length of the random array.</param>
        /// <returns>A random integer array without repetition of elements.</returns>
        public static int[] CreateDistinctRandomIntegers(int length, DistinctRandomAlgorithms algorithm = DistinctRandomAlgorithms.Auto, Random random = null)
        {
            return CreateDistinctRandomIntegers(int.MinValue, int.MaxValue - 1, length, algorithm, random);
        }

        /// <summary>
        /// Gets a random integer array of random length without repetition of elements.
        /// </summary>
        /// <param name="minLength">The minimum length of the array.</param>
        /// <param name="maxLength">The maximum length of the array.</param>
        /// <param name="algorithm">Specifies the algorithm used.</param>
        /// <param name="random">A <see cref="System.Random" /> object that generates random numbers.
        /// If this argument is not specified, a new <see cref="System.Random" /> instance will be used.</param>
        /// <returns>
        /// A random integer array without repetition of elements.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when <paramref name="minLength"/> or <paramref name="maxLength"/> is non-positive.</exception>
        /// <exception cref="System.ArgumentException">Occurs when <paramref name="minLength"/> is larger than <paramref name="maxLength"/> or <paramref name="maxLength"/> equals the maximum integer a <see cref="System.Int32"/> integer can represent.</exception>
        public static int[] CreateDistinctRandomIntegers(int minLength, int maxLength, DistinctRandomAlgorithms algorithm = DistinctRandomAlgorithms.Auto, Random random = null)
        {
            if (minLength <= 0)
                throw new ArgumentOutOfRangeException("minLength", minLength, GeneralResources.ERR_PositiveValueRequired.Scan("minLength"));

            if (maxLength <= 0)
                throw new ArgumentOutOfRangeException("maxLength", minLength, GeneralResources.ERR_PositiveValueRequired.Scan("maxLength"));

            if (minLength > maxLength)
                throw new ArgumentException(GeneralResources.ERR_InvalidMinMax.Scan("minLength", "maxLength"));

            if (maxLength == int.MaxValue)
                throw new ArgumentException(GeneralResources.ERR_InvalidValue.Scan("maxLength"));

            ++maxLength;
            if (random == null) random = new Random();
            return CreateDistinctRandomIntegers
                (random.Next(minLength, maxLength), algorithm, random);
        }

        /// <summary>
        /// Gets a random integer array without repetition of elements.
        /// </summary>
        /// <param name="min">The minium possible value in the random array.</param>
        /// <param name="max">The maxium possible value in the random array.</param>
        /// <param name="length">Specifies the length of the random array.</param>
        /// <param name="algorithm">Specifies the algorithm used.</param>
        /// <param name="random">A <see cref="System.Random" /> object that generates random numbers.
        /// If this argument is not specified, a new <see cref="System.Random" /> instance will be used.</param>
        /// <returns>
        /// A random integer array without repetition of elements.
        /// </returns>
        /// <exception cref="System.ArgumentException">Occurs when <paramref name="min" /> is larger than <paramref name="max" />.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when <paramref name="max" /> equals the maximum number a <see cref="System.Int32" /> integer can represent.</exception>
        /// <exception cref="System.InvalidOperationException">Occurs when the value of <paramref name="length" /> is smaller than <paramref name="max" /> - <paramref name="min" /> + 1.</exception>
        public static int[] CreateDistinctRandomIntegers(int min, int max, int length, DistinctRandomAlgorithms algorithm = DistinctRandomAlgorithms.Auto, Random random = null)
        {
            if (min > max)
                throw (new ArgumentException(GeneralResources.ERR_InvalidMinMax.Scan("min", "max")));

            if (max == int.MaxValue)
                throw (new ArgumentOutOfRangeException("max"));

            ++max;

            var range = max - min;
            if (range < length)
                throw new InvalidOperationException(ArrayExResources.ERR_ArrayEx_UnableToCreateDistinctRandomArray);

            if (range == length)
            {
                var arr = CreateConsecutiveIntegers(min, max);
                arr.Shuffle(new Random());
                return arr;
            }
            else
            {
                var arr = new int[length];

                if (random == null) random = new Random();

                switch (algorithm)
                {
                    default:
                        {
                            var ratio = (double)length / range;
                            if (ratio > 0.2)
                            {
                                if (length > 1000) goto case DistinctRandomAlgorithms.SwapHash;
                                else goto case DistinctRandomAlgorithms.Swap;
                            }
                            else goto case DistinctRandomAlgorithms.SimpleHash;
                        }
                    case DistinctRandomAlgorithms.SimpleHash:
                        {
                            var hasheset = new HashSet<int>();
                            while (length != 0)
                            {
                                int val;
                                do
                                    val = random.Next(min, max);
                                while (hasheset.Contains(val));
                                hasheset.Add(val);
                                arr[--length] = val;
                            }

                            break;
                        }
                    case DistinctRandomAlgorithms.Swap:
                        {
                            var tempArr = new int[range];

                            int val;
                            max = length; //max is used to store "length" here

                            while (length != 0)
                            {
                                val = random.Next(0, range);
                                --range;
                                --length;

                                if (tempArr[val] == 0)
                                    arr[length] = val + min;
                                else
                                    arr[length] = tempArr[val] + min;

                                tempArr[val] = tempArr[range] == 0 ? range : tempArr[range];
                            }

                            break;
                        }
                    case DistinctRandomAlgorithms.SwapHash:
                        {
                            var dict = new Dictionary<int, int>();
                            var mark = range - length;
                            int val;

                            while (length != 0)
                            {
                                val = random.Next(0, range);
                                --range;
                                --length;

                                if (val < mark)
                                {
                                    int tval1;
                                    var exist1 = dict.TryGetValue(val, out tval1);
                                    int tval2 = arr[length];
                                    var exist2 = tval2 != 0;

                                    if (exist1)
                                    {
                                        dict[val] = exist2 ? tval2 : range;
                                        arr[length] = min + tval1;
                                    }
                                    else
                                    {
                                        dict.Add(val, exist2 ? tval2 : range);
                                        arr[length] = min + val;
                                    }
                                }
                                else
                                {
                                    var idx = val - mark;
                                    if (arr[idx] == 0)
                                    {
                                        if (arr[length] == 0)
                                        {
                                            arr[length] = min + val;
                                            arr[idx] = range;
                                        }
                                        else
                                        {
                                            arr[idx] = arr[length];
                                            arr[length] = min + val;
                                        }
                                    }
                                    else
                                    {
                                        if (arr[length] == 0)
                                        {
                                            arr[length] = min + arr[idx];
                                            arr[idx] = range;
                                        }
                                        else
                                        {
                                            var temp = arr[idx];
                                            arr[idx] = arr[length];
                                            arr[length] = min + temp;
                                        }
                                    }
                                }
                            }

                            break;
                        }
                }


                return arr;
            }
        }

        /// <summary>
        /// Gets a non-empty random integer array that contains at most 2621440 integers.
        /// </summary>
        /// <returns>A random integer array.</returns>
        public static int[] CreateRandomIntegers()
        {
            return CreateRandomIntegers(int.MinValue, int.MaxValue - 1, 1, 2621440);
        }

        /// <summary>
        /// Gets a random integer array of the specified length.
        /// </summary>
        /// <param name="length">Specifies the length of the random array.</param>
        /// <param name="random">
        /// A <see cref="System.Random"/> object that generates random numbers. 
        /// If this argument is not specified, a new <see cref="System.Random"/> instance will be used.
        /// </param>
        /// <returns>
        /// A random integer array.
        /// </returns>
        public static int[] CreateRandomIntegers(long length, Random random)
        {
            return CreateRandomIntegers(int.MinValue, int.MaxValue - 1, length, random);
        }

        /// <summary>
        /// Gets a random integer array whose length is inclusively between <paramref name="minLength" /> and <paramref name="maxLength" />.
        /// </summary>
        /// <param name="minLength">Specifies the minimum length of the random array.</param>
        /// <param name="maxLength">Specifies the maximum length of the random array.</param>
        /// <param name="random">A <see cref="System.Random" /> object that generates random numbers.
        /// If this argument is not specified, a new <see cref="System.Random" /> instance will be used.</param>
        /// <returns>
        /// A random integer array.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when <paramref name="minLength" /> or <paramref name="maxLength" /> is non-positive.</exception>
        /// <exception cref="System.ArgumentException">Occurs when <paramref name="minLength" /> is larger than <paramref name="maxLength" /> or
        /// <paramref name="maxLength" /> equals the maximum integer a <see cref="System.Int64" /> integer can represent.</exception>
        public static int[] CreateRandomIntegers(long minLength, long maxLength, Random random = null)
        {
            if (minLength <= 0)
                throw new ArgumentOutOfRangeException("minLength", minLength, GeneralResources.ERR_PositiveValueRequired.Scan("minLength"));

            if (maxLength <= 0)
                throw new ArgumentOutOfRangeException("maxLength", minLength, GeneralResources.ERR_PositiveValueRequired.Scan("maxLength"));

            if (minLength > maxLength)
                throw new ArgumentException(GeneralResources.ERR_InvalidMinMax.Scan("minLength", "maxLength"));

            if (maxLength == long.MaxValue)
                throw new ArgumentException(GeneralResources.ERR_InvalidValue.Scan("maxLength"));
            ++maxLength;

            if (random == null) random = new Random();

            return CreateRandomIntegers
                (random.Next(minLength, maxLength), random);
        }

        /// <summary>
        /// Gets a random integer array whose length is inclusively between <paramref name="minLength" /> and <paramref name="maxLength" />.
        /// You may specify the maximum and minimum possible value that occurs in the returned array.
        /// </summary>
        /// <param name="min">The minium possible value in the random array.</param>
        /// <param name="max">The maxium possible value in the random array.</param>
        /// <param name="minLength">Specifies the minimum length of the random array.</param>
        /// <param name="maxLength">Specifies the maximum length of the random array.</param>
        /// <param name="random">A <see cref="System.Random" /> object that generates random numbers.
        /// If this argument is not specified, a new <see cref="System.Random" /> instance will be used.</param>
        /// <returns>
        /// A random integer array.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when <paramref name="minLength"/> or <paramref name="maxLength"/> is non-positive.</exception>
        /// <exception cref="System.ArgumentException">Occurs when <paramref name="minLength" /> is larger than <paramref name="maxLength" /> or
        /// <paramref name="maxLength" /> equals the maximum integer a <see cref="System.Int64" /> integer can represent.</exception>
        public static int[] CreateRandomIntegers(int min, int max, long minLength, long maxLength, Random random = null)
        {
            if (minLength <= 0)
                throw new ArgumentOutOfRangeException
                    ("minLength", minLength, GeneralResources.ERR_PositiveValueRequired.Scan("minLength"));

            if (maxLength <= 0)
                throw new ArgumentOutOfRangeException
                    ("maxLength", minLength, GeneralResources.ERR_PositiveValueRequired.Scan("maxLength"));

            if (minLength > maxLength)
                throw (new ArgumentException(GeneralResources.ERR_InvalidMinMax.Scan("minLength", "maxLength")));


            if (maxLength == long.MaxValue)
                throw new ArgumentException(GeneralResources.ERR_InvalidValue.Scan("maxLength"));
            ++maxLength;

            if (random == null) random = new Random();
            return CreateRandomIntegers(min, max, random.Next(minLength, maxLength), random);
        }

        /// <summary>
        /// Gets a random integer array of the specified length.
        /// </summary>
        /// <param name="min">The minimum possible value in the random array.</param>
        /// <param name="max">The maximum possible value in the random array.</param>
        /// <param name="length">Specifies the length of the random array.</param>
        /// <param name="random">A <see cref="System.Random"/> object that generates random numbers. 
        /// If this argument is not specified, a new <see cref="System.Random"/> instance will be used.</param>
        /// <returns>
        /// A random integer array.
        /// </returns>
        /// <exception cref="System.ArgumentException">Occurs when <paramref name="min"/> is larger than <paramref name="max"/>.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when <paramref name="max"/> equals the maximum number a <see cref="System.Int32"/> integer can represent.</exception>
        public static int[] CreateRandomIntegers(int min, int max, long length, Random random = null)
        {
            if (min > max)
                throw (new ArgumentException(GeneralResources.ERR_InvalidMinMax.Scan("min", "max")));

            if (max == int.MaxValue)
                throw (new ArgumentOutOfRangeException("max"));
            ++max;

            var arr = new int[length];

            if (random == null) random = new Random();

            while (length != 0)
                arr[--length] = random.Next(min, max);

            return arr;
        }

        #endregion

        #region Int64 Integers

        /// <summary>
        /// Gets a random <see cref="System.Int64"/> integer array without repetition of elements.
        /// </summary>
        /// <param name="length">Specifies the length of the random array.</param>
        /// <returns>A random <see cref="System.Int64"/> integer array without repetition of elements.</returns>
        public static long[] CreateDistinctRandomLongs(long length, DistinctRandomAlgorithms algorithm = DistinctRandomAlgorithms.Auto, Random random = null)
        {
            return CreateDistinctRandomLongs(long.MinValue, long.MaxValue - 1, length, algorithm, random);
        }

        /// <summary>
        /// Gets a random <see cref="System.Int64"/> array of random length without repetition of elements.
        /// </summary>
        /// <param name="minLength">The minimum length of the array.</param>
        /// <param name="maxLength">The maximum length of the array.</param>
        /// <param name="algorithm">Specifies the algorithm used.</param>
        /// <param name="random">A <see cref="System.Random" /> object that generates random numbers.
        /// If this argument is not specified, a new <see cref="System.Random" /> instance will be used.</param>
        /// <returns>
        /// A random <see cref="System.Int64"/> integer array without repetition of elements.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when <paramref name="minLength"/> or <paramref name="maxLength"/> is non-positive.</exception>
        /// <exception cref="System.ArgumentException">Occurs when <paramref name="minLength"/> is larger than <paramref name="maxLength"/> or <paramref name="maxLength"/> equals the maximum integer a <see cref="System.Int32"/> integer can represent.</exception>
        public static long[] CreateDistinctRandomLongs(long minLength, long maxLength, DistinctRandomAlgorithms algorithm = DistinctRandomAlgorithms.Auto, Random random = null)
        {
            if (minLength <= 0)
                throw new ArgumentOutOfRangeException("minLength", minLength, GeneralResources.ERR_PositiveValueRequired.Scan("minLength"));

            if (maxLength <= 0)
                throw new ArgumentOutOfRangeException("maxLength", minLength, GeneralResources.ERR_PositiveValueRequired.Scan("maxLength"));

            if (minLength > maxLength)
                throw new ArgumentException(GeneralResources.ERR_InvalidMinMax.Scan("minLength", "maxLength"));

            if (maxLength == long.MaxValue)
                throw new ArgumentException(GeneralResources.ERR_InvalidValue.Scan("maxLength"));

            ++maxLength;
            if (random == null) random = new Random();
            return CreateDistinctRandomLongs
                (random.Next(minLength, maxLength), algorithm, random);
        }

        /// <summary>
        /// Gets a random <see cref="System.Int64"/> integer array without repetition of elements.
        /// </summary>
        /// <param name="min">The minium possible value in the random array.</param>
        /// <param name="max">The maxium possible value in the random array.</param>
        /// <param name="length">Specifies the length of the random array.</param>
        /// <param name="algorithm">Specifies the algorithm used.</param>
        /// <param name="random">A <see cref="System.Random" /> object that generates random numbers.
        /// If this argument is not specified, a new <see cref="System.Random" /> instance will be used.</param>
        /// <returns>
        /// A random <see cref="System.Int64"/> integer array without repetition of elements.
        /// </returns>
        /// <exception cref="System.ArgumentException">Occurs when <paramref name="min" /> is larger than <paramref name="max" />.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when <paramref name="max" /> equals the maximum number a <see cref="System.Int32" /> integer can represent.</exception>
        /// <exception cref="System.InvalidOperationException">Occurs when the value of <paramref name="length" /> is smaller than <paramref name="max" /> - <paramref name="min" /> + 1.</exception>
        public static long[] CreateDistinctRandomLongs(long min, long max, long length, DistinctRandomAlgorithms algorithm = DistinctRandomAlgorithms.Auto, Random random = null)
        {
            if (min > max)
                throw (new ArgumentException(GeneralResources.ERR_InvalidMinMax.Scan("min", "max")));

            if (max == long.MaxValue)
                throw (new ArgumentOutOfRangeException("max"));

            ++max;

            var range = max - min;
            if (range < length)
                throw new InvalidOperationException(ArrayExResources.ERR_ArrayEx_UnableToCreateDistinctRandomArray);

            if (range == length)
            {
                var arr = CreateConsecutiveLongs(min, max);
                arr.Shuffle(new Random());
                return arr;
            }
            else
            {
                var arr = new long[length];

                if (random == null) random = new Random();

                switch (algorithm)
                {
                    default:
                        {
                            var ratio = (double)length / range;
                            if (ratio > 0.2)
                            {
                                if (length > 1000) goto case DistinctRandomAlgorithms.SwapHash;
                                else goto case DistinctRandomAlgorithms.Swap;
                            }
                            else goto case DistinctRandomAlgorithms.SimpleHash;
                        }
                    case DistinctRandomAlgorithms.SimpleHash:
                        {
                            var hasheset = new HashSet<long>();
                            while (length != 0)
                            {
                                long val;
                                do
                                    val = random.Next(min, max);
                                while (hasheset.Contains(val));
                                hasheset.Add(val);
                                arr[--length] = val;
                            }

                            break;
                        }
                    case DistinctRandomAlgorithms.Swap:
                        {
                            var tempArr = new long[range];

                            long val;
                            max = length; //max is used to store "length" here

                            while (length != 0)
                            {
                                val = random.Next(0, range);
                                --range;
                                --length;

                                if (tempArr[val] == 0)
                                    arr[length] = val + min;
                                else
                                    arr[length] = tempArr[val] + min;

                                tempArr[val] = tempArr[range] == 0 ? range : tempArr[range];
                            }

                            break;
                        }
                    case DistinctRandomAlgorithms.SwapHash:
                        {
                            var dict = new Dictionary<long, long>();
                            var mark = range - length;
                            long val;

                            while (length != 0)
                            {
                                val = random.Next(0, range);
                                --range;
                                --length;

                                if (val < mark)
                                {
                                    long tval1;
                                    var exist1 = dict.TryGetValue(val, out tval1);
                                    long tval2 = arr[length];
                                    var exist2 = tval2 != 0;

                                    if (exist1)
                                    {
                                        dict[val] = exist2 ? tval2 : range;
                                        arr[length] = min + tval1;
                                    }
                                    else
                                    {
                                        dict.Add(val, exist2 ? tval2 : range);
                                        arr[length] = min + val;
                                    }
                                }
                                else
                                {
                                    var idx = val - mark;
                                    if (arr[idx] == 0)
                                    {
                                        if (arr[length] == 0)
                                        {
                                            arr[length] = min + val;
                                            arr[idx] = range;
                                        }
                                        else
                                        {
                                            arr[idx] = arr[length];
                                            arr[length] = min + val;
                                        }
                                    }
                                    else
                                    {
                                        if (arr[length] == 0)
                                        {
                                            arr[length] = min + arr[idx];
                                            arr[idx] = range;
                                        }
                                        else
                                        {
                                            var temp = arr[idx];
                                            arr[idx] = arr[length];
                                            arr[length] = min + temp;
                                        }
                                    }
                                }
                            }

                            break;
                        }
                }


                return arr;
            }
        }

        /// <summary>
        /// Gets a non-empty random <see cref="System.Int64"/> integer array that contains at most 2621440 integers.
        /// </summary>
        /// <returns>A random <see cref="System.Int64"/> integer array.</returns>
        public static long[] CreateRandomLongs()
        {
            return CreateRandomLongs(long.MinValue, long.MaxValue - 1, 1, 2621440);
        }

        /// <summary>
        /// Gets a random integer array of the specified length.
        /// </summary>
        /// <param name="length">Specifies the length of the random array.</param>
        /// <param name="random">
        /// A <see cref="System.Random"/> object that generates random numbers. 
        /// If this argument is not specified, a new <see cref="System.Random"/> instance will be used.
        /// </param>
        /// <returns>
        /// A random <see cref="System.Int64"/> integer array.
        /// </returns>
        public static long[] CreateRandomLongs(long length, Random random)
        {
            return CreateRandomLongs(long.MinValue, long.MaxValue - 1, length, random);
        }

        /// <summary>
        /// Gets a random <see cref="System.Int64"/> integer array whose length is inclusively between <paramref name="minLength" /> and <paramref name="maxLength" />.
        /// </summary>
        /// <param name="minLength">Specifies the minimum length of the random array.</param>
        /// <param name="maxLength">Specifies the maximum length of the random array.</param>
        /// <param name="random">
        /// A <see cref="System.Random"/> object that generates random numbers. 
        /// If this argument is not specified, a new <see cref="System.Random"/> instance will be used.
        /// </param>
        /// <returns>
        /// A random <see cref="System.Int64"/> integer array.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when <paramref name="minLength"/> or <paramref name="maxLength"/> is non-positive.</exception>
        /// <exception cref="System.ArgumentException">
        /// Occurs when <paramref name="minLength"/> is larger than <paramref name="maxLength"/> or 
        /// <paramref name="maxLength"/> equals the maximum integer a <see cref="System.Int64"/> integer can represent.
        /// </exception>
        public static long[] CreateRandomLongs(long minLength, long maxLength, Random random = null)
        {
            if (minLength <= 0)
                throw new ArgumentOutOfRangeException("minLength", minLength, GeneralResources.ERR_PositiveValueRequired.Scan("minLength"));

            if (maxLength <= 0)
                throw new ArgumentOutOfRangeException("maxLength", minLength, GeneralResources.ERR_PositiveValueRequired.Scan("maxLength"));

            if (minLength > maxLength)
                throw new ArgumentException(GeneralResources.ERR_InvalidMinMax.Scan("minLength", "maxLength"));

            if (maxLength == long.MaxValue)
                throw new ArgumentException(GeneralResources.ERR_InvalidValue.Scan("maxLength"));

            ++maxLength;
            if (random == null) random = new Random();

            return CreateRandomLongs
                (random.Next(minLength, maxLength), random);
        }

        /// <summary>
        /// Gets a random <see cref="System.Int64" /> integer array whose length is inclusively between <paramref name="minLength" /> and <paramref name="maxLength" />.
        /// You may specify the maximum and minimum possible value that occurs in the returned array.
        /// </summary>
        /// <param name="min">The minium possible value in the random array.</param>
        /// <param name="max">The maxium possible value in the random array.</param>
        /// <param name="minLength">Specifies the minimum length of the random array.</param>
        /// <param name="maxLength">Specifies the maximum length of the random array.</param>
        /// <param name="random">A <see cref="System.Random" /> object that generates random numbers.
        /// If this argument is not specified, a new <see cref="System.Random" /> instance will be used.</param>
        /// <returns>
        /// A random <see cref="System.Int64" /> integer array.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when <paramref name="minLength" /> or <paramref name="maxLength" /> is non-positive.</exception>
        /// <exception cref="System.ArgumentException">Occurs when <paramref name="minLength" /> is larger than <paramref name="maxLength" /> or
        /// <paramref name="maxLength" /> equals the maximum integer a <see cref="System.Int64" /> integer can represent.</exception>
        public static long[] CreateRandomLongs(long min, long max, long minLength, long maxLength, Random random = null)
        {
            if (minLength <= 0)
                throw new ArgumentOutOfRangeException
                    ("minLength", minLength, GeneralResources.ERR_PositiveValueRequired.Scan("minLength"));

            if (maxLength <= 0)
                throw new ArgumentOutOfRangeException
                    ("maxLength", minLength, GeneralResources.ERR_PositiveValueRequired.Scan("maxLength"));

            if (minLength > maxLength)
                throw (new ArgumentException(GeneralResources.ERR_InvalidMinMax
                    .Scan("minLength", "maxLength")));

            if (maxLength == long.MaxValue)
                throw new ArgumentException(GeneralResources.ERR_InvalidValue.Scan("maxLength"));
            ++maxLength;

            if (random == null) random = new Random();
            return CreateRandomLongs(min, max, random.Next(minLength, maxLength), random);
        }

        /// <summary>
        /// Gets a random <see cref="System.Int64"/> integer array of the specified length.
        /// </summary>
        /// <param name="min">The minium possible value in the random array.</param>
        /// <param name="max">The maxium possible value in the random array.</param>
        /// <param name="length">Specifies the length of the random array.</param>
        /// <param name="random">A <see cref="System.Random"/> object that generates random numbers. 
        /// If this argument is not specified, a new <see cref="System.Random"/> instance will be used.</param>
        /// <returns>
        /// A random <see cref="System.Int64"/> integer array.
        /// </returns>
        /// <exception cref="System.ArgumentException">Occurs when <paramref name="min"/> is larger than <paramref name="max"/>.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when <paramref name="max"/> equals the maximum number a <see cref="System.Int32"/> integer can represent.</exception>
        public static long[] CreateRandomLongs(long min, long max, long length, Random random = null)
        {
            if (min > max)
                throw (new ArgumentException(GeneralResources.ERR_InvalidMinMax.Scan("min", "max")));

            if (max == long.MaxValue)
                throw (new ArgumentOutOfRangeException("max"));
            ++max;

            var arr = new long[length];

            if (random == null) random = new Random();

            while (length != 0)
                arr[--length] = random.Next(min, max);

            return arr;
        }

        #endregion
    }
}
