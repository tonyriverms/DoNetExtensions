using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_Extension_Library.System.ArrayEx;

namespace System
{
    /// <summary>
    /// Specifies algorithms to generate distinct random values.
    /// </summary>
    public enum DistinctRandomAlgorithms
    {
        /// <summary>
        /// Simply uses a hashtable to prevent repetition, suitable for generating few distinct random values from a wide range.
        /// </summary>
        SimpleHash,
        /// <summary>
        /// Suits when the ratio of the number of generated random values to the number of all possible values is high (typically higher than 20%) 
        /// and the latter is not large (typically smaller than 1000).
        /// </summary>
        Swap,
        /// <summary>
        /// Suits when the ratio of the number of generated random values to the number of all possible values is high (typically higher than 20%) 
        /// and the latter is not quite small (typically larger than 1000).
        /// </summary>
        SwapHash,
        /// <summary>
        /// Let the system determine which algorithm should be applied.
        /// </summary>
        Auto
    }

    public static partial class ArrayEx
    {
        /// <summary>
        /// Puts each element of this <see cref="System.Collections.Generic.IList{T}"/> at a random position. This method implements the Fisher–Yates shuffle.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The current list.</param>
        /// <param name="random">A <see cref="System.Random"/> object used to generate random positions.</param>
        public static void Shuffle<T>(this IList<T> list, Random random = null)
        {
            if (random == null) random = new Random();
            var length = list.Count;

            while (length > 1)
            {
                var val = random.Next(0, length);
                --length;
                T temp = list[length];
                list[length] = list[val];
                list[val] = temp;
            }
        }

        /// <summary>
        /// Puts each element of this <see cref="System.Array"/> at a random position. This method implements the Fisher–Yates shuffle.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">The current array.</param>
        /// <param name="random">A <see cref="System.Random"/> object used to generate random positions.</param>
        public static void Shuffle<T>(this T[] array, Random random = null)
        {
            if (random == null) random = new Random();
            var length = array.Length;

            while (length > 1)
            {
                var val = random.Next(0, length);
                --length;
                T temp = array[length];
                array[length] = array[val];
                array[val] = temp;
            }
        }

        /// <summary>
        /// Randomly copies non-null elements of this <see cref="System.Collections.Generic.IList{T}" /> to an empty destination list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The current list.</param>
        /// <param name="destination">The destination list to which the elements of the current list are copied.</param>
        /// <param name="random">A <see cref="System.Random"/> object used to generate random positions.</param>
        /// <exception cref="System.ArgumentNullException">Occurs when <paramref name="destination"/> is <c>null</c>.</exception>
        /// <exception cref="System.ArgumentException">Occurs when <paramref name="destination"/> is non-empty.</exception>
        public static void ShuffleCopyNonNull<T>(this IList<T> list, IList<T> destination, Random random = null)
        {
            if (random == null) random = new Random();
            if (destination == null) throw new ArgumentNullException("destination");
            if (destination.Count != 0) throw new ArgumentException(ArrayExResources.ERR_ArrayEx_ShuffleCopyNonNull_EmptyDestination);

            var count = list.Count;
            var max = 0;
            for (int i = 0; i < count; ++i)
            {
                var value = list[i];
                if (value != null)
                {
                    var j = random.Next(0, max + 1);
                    if (j == max) destination.Add(value);
                    else
                    {
                        destination.Add(destination[j]);
                        destination[j] = value;
                    }
                    ++max;
                }
            }
        }

        /// <summary>
        /// Gets an enumerator that enumerates elements of the array in a random manner.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">The array.</param>
        /// <param name="count">The total number of elements the enumerator should enumerate before reset.</param>
        /// <param name="algorithm">The algorithm used to prevent an element from being accessed twice.</param>
        /// <param name="random">A <see cref="System.Random" /> object that generates random numbers.
        /// If this argument is not specified, a new <see cref="System.Random" /> instance will be used.</param>
        /// <returns>An enumerator that randomly enumerates elements of the array.</returns>
        public static IEnumerator<T> GetRandomEnumerator<T>(this T[] array, int count, 
            DistinctRandomAlgorithms algorithm = DistinctRandomAlgorithms.Auto, Random random = null)
        {
            var range = array.Length;
            if (random == null) random = new Random();

            switch (algorithm)
            {
                default:
                    {
                        var ratio = (double)count / range;
                        if (ratio > 0.2) goto case DistinctRandomAlgorithms.Swap;
                        else goto case DistinctRandomAlgorithms.SimpleHash;
                    }
                case DistinctRandomAlgorithms.SimpleHash:
                    {
                        var hasheset = new HashSet<int>();
                        while (count != 0)
                        {
                            --count;
                            int val;
                            do
                                val = random.Next(0, range);
                            while (hasheset.Contains(val));
                            hasheset.Add(val);
                            yield return array[val];
                        }

                        break;
                    }
                case DistinctRandomAlgorithms.Swap:
                    {
                        var tempArr = new int[range];

                        int val;
                        var length2 = count; //max is used to store "length" here

                        while (count != 0)
                        {
                            val = random.Next(0, range);
                            --range;
                            --count;

                            if (tempArr[val] == 0)
                                yield return array[val];
                            else
                                yield return array[tempArr[val]];

                            tempArr[val] = tempArr[range] == 0 ? range : tempArr[range];
                        }

                        break;
                    }
                case DistinctRandomAlgorithms.SwapHash:
                    {
                        var dict = new Dictionary<int, int>();
                        int val;

                        while (count != 0)
                        {
                            val = random.Next(0, range);
                            --range;
                            --count;

                            int tval1, tval2;
                            var exist1 = dict.TryGetValue(val, out tval1);
                            var exist2 = dict.TryGetValue(range, out tval2);

                            if (exist1)
                            {
                                dict[val] = exist2 ? tval2 : range;
                                yield return array[tval1];
                            }
                            else
                            {
                                dict.Add(val, exist2 ? tval2 : range);
                                yield return array[val];
                            }
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// Gets an enumerator that enumerates all elements of the array in a random manner.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">The array.</param>
        /// <param name="algorithm">The algorithm used to prevent an element from being accessed twice.</param>
        /// <param name="random">A <see cref="System.Random" /> object that generates random numbers.
        /// If this argument is not specified, a new <see cref="System.Random" /> instance will be used.</param>
        /// <returns>
        /// An enumerator that randomly enumerates elements of the array.
        /// </returns>
        public static IEnumerator<T> GetRandomEnumerator<T>(this T[] array, 
            DistinctRandomAlgorithms algorithm = DistinctRandomAlgorithms.Auto, Random random = null)
        {
            return GetRandomEnumerator<T>(array, array.Length, algorithm, random);
        }

        /// <summary>
        /// Gets an enumerator that enumerates elements of the <see cref="System.Collections.Generic.IList{T}"/> in a random manner.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list.</param>
        /// <param name="count">The total number of elements the enumerator should enumerate before reset.</param>
        /// <param name="algorithm">The algorithm used to prevent an element from being accessed twice.</param>
        /// <param name="random">A <see cref="System.Random" /> object that generates random numbers.
        /// If this argument is not specified, a new <see cref="System.Random" /> instance will be used.</param>
        /// <returns>An enumerator that randomly enumerates elements of the list.</returns>
        public static IEnumerator<T> GetRandomEnumerator<T>(this IList<T> list, int count,
            DistinctRandomAlgorithms algorithm = DistinctRandomAlgorithms.Auto, Random random = null)
        {
            var range = list.Count;
            if (random == null) random = new Random();

            switch (algorithm)
            {
                default:
                    {
                        var ratio = (double)count / range;
                        if (ratio > 0.2) goto case DistinctRandomAlgorithms.Swap;
                        else goto case DistinctRandomAlgorithms.SimpleHash;
                    }
                case DistinctRandomAlgorithms.SimpleHash:
                    {
                        var hasheset = new HashSet<int>();
                        while (count != 0)
                        {
                            --count;
                            int val;
                            do
                                val = random.Next(0, range);
                            while (hasheset.Contains(val));
                            hasheset.Add(val);
                            yield return list[val];
                        }

                        break;
                    }
                case DistinctRandomAlgorithms.Swap:
                    {
                        var tempArr = new int[range];

                        int val;
                        var length2 = count; //max is used to store "length" here

                        while (count != 0)
                        {
                            val = random.Next(0, range);
                            --range;
                            --count;

                            if (tempArr[val] == 0)
                                yield return list[val];
                            else
                                yield return list[tempArr[val]];

                            tempArr[val] = tempArr[range] == 0 ? range : tempArr[range];
                        }

                        break;
                    }
                case DistinctRandomAlgorithms.SwapHash:
                    {
                        var dict = new Dictionary<int, int>();
                        int val;

                        while (count != 0)
                        {
                            val = random.Next(0, range);
                            --range;
                            --count;

                            int tval1, tval2;
                            var exist1 = dict.TryGetValue(val, out tval1);
                            var exist2 = dict.TryGetValue(range, out tval2);

                            if (exist1)
                            {
                                dict[val] = exist2 ? tval2 : range;
                                yield return list[tval1];
                            }
                            else
                            {
                                dict.Add(val, exist2 ? tval2 : range);
                                yield return list[val];
                            }
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// Gets an enumerator that enumerates all elements of the <see cref="System.Collections.Generic.IList{T}"/> in a random manner.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="array">The list.</param>
        /// <param name="algorithm">The algorithm used to prevent an element from being accessed twice.</param>
        /// <param name="random">A <see cref="System.Random" /> object that generates random numbers.
        /// If this argument is not specified, a new <see cref="System.Random" /> instance will be used.</param>
        /// <returns>
        /// An enumerator that randomly enumerates elements of the list.
        /// </returns>
        public static IEnumerator<T> GetRandomEnumerator<T>(this IList<T> list,
            DistinctRandomAlgorithms algorithm = DistinctRandomAlgorithms.Auto, Random random = null)
        {
            return GetRandomEnumerator<T>(list, list.Count, algorithm, random);
        }

        /// <summary>
        /// Gets an enumerator that enumerates elements of the <see cref="System.Collections.Generic.IEnumerable{T}"/> sequence in a random manner.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="sequence">The enumerable sequence.</param>
        /// <param name="count">The total number of elements the enumerator should enumerate before reset.</param>
        /// <param name="algorithm">The algorithm used to prevent an element from being accessed twice.</param>
        /// <param name="random">A <see cref="System.Random" /> object that generates random numbers.
        /// If this argument is not specified, a new <see cref="System.Random" /> instance will be used.</param>
        /// <returns>An enumerator that randomly enumerates elements of the sequence.</returns>
        public static IEnumerator<T> GetRandomEnumerator<T>(this IEnumerable<T> sequence, int count,
            DistinctRandomAlgorithms algorithm = DistinctRandomAlgorithms.Auto, Random random = null)
        {
            var range = sequence.Count(); 
            if (random == null) random = new Random();

            switch (algorithm)
            {
                default:
                    {
                        var ratio = (double)count / range;
                        if (ratio > 0.2) goto case DistinctRandomAlgorithms.Swap;
                        else goto case DistinctRandomAlgorithms.SimpleHash;
                    }
                case DistinctRandomAlgorithms.SimpleHash:
                    {
                        var hasheset = new HashSet<int>();
                        while (count != 0)
                        {
                            --count;
                            int val;
                            do
                                val = random.Next(0, range);
                            while (hasheset.Contains(val));
                            hasheset.Add(val);
                            yield return sequence.ElementAt(val);
                        }

                        break;
                    }
                case DistinctRandomAlgorithms.Swap:
                    {
                        var tempArr = new int[range];

                        int val;
                        var length2 = count; //max is used to store "length" here

                        while (count != 0)
                        {
                            val = random.Next(0, range);
                            --range;
                            --count;

                            if (tempArr[val] == 0)
                                yield return sequence.ElementAt(val);
                            else
                                yield return sequence.ElementAt(tempArr[val]);

                            tempArr[val] = tempArr[range] == 0 ? range : tempArr[range];
                        }

                        break;
                    }
                case DistinctRandomAlgorithms.SwapHash:
                    {
                        var dict = new Dictionary<int, int>();
                        int val;

                        while (count != 0)
                        {
                            val = random.Next(0, range);
                            --range;
                            --count;

                            int tval1, tval2;
                            var exist1 = dict.TryGetValue(val, out tval1);
                            var exist2 = dict.TryGetValue(range, out tval2);

                            if (exist1)
                            {
                                dict[val] = exist2 ? tval2 : range;
                                yield return sequence.ElementAt(tval1);
                            }
                            else
                            {
                                dict.Add(val, exist2 ? tval2 : range);
                                yield return sequence.ElementAt(val);
                            }
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// Gets an enumerator that enumerates elements of the <see cref="System.Collections.Generic.IEnumerable{T}" /> sequence in a random manner.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="sequence">The enumerable sequence.</param>
        /// <param name="algorithm">The algorithm used to prevent an element from being accessed twice.</param>
        /// <param name="random">A <see cref="System.Random" /> object that generates random numbers.
        /// If this argument is not specified, a new <see cref="System.Random" /> instance will be used.</param>
        /// <returns>
        /// An enumerator that randomly enumerates elements of the sequence.
        /// </returns>
        public static IEnumerator<T> GetRandomEnumerator<T>(this IEnumerable<T> sequence,
            DistinctRandomAlgorithms algorithm = DistinctRandomAlgorithms.Auto, Random random = null)
        {
            var range = sequence.Count();
            var count = range;
            if (random == null) random = new Random();

            switch (algorithm)
            {
                default:
                    {
                        var ratio = (double)count / range;
                        if (ratio > 0.2) goto case DistinctRandomAlgorithms.Swap;
                        else goto case DistinctRandomAlgorithms.SimpleHash;
                    }
                case DistinctRandomAlgorithms.SimpleHash:
                    {
                        var hasheset = new HashSet<int>();
                        while (count != 0)
                        {
                            --count;
                            int val;
                            do
                                val = random.Next(0, range);
                            while (hasheset.Contains(val));
                            hasheset.Add(val);
                            yield return sequence.ElementAt(val);
                        }

                        break;
                    }
                case DistinctRandomAlgorithms.Swap:
                    {
                        var tempArr = new int[range];
                        int val;

                        while (count != 0)
                        {
                            val = random.Next(0, range);
                            --range;
                            --count;

                            if (tempArr[val] == 0)
                                yield return sequence.ElementAt(val);
                            else
                                yield return sequence.ElementAt(tempArr[val]);

                            tempArr[val] = tempArr[range] == 0 ? range : tempArr[range];
                        }

                        break;
                    }
                case DistinctRandomAlgorithms.SwapHash:
                    {
                        var dict = new Dictionary<int, int>();
                        int val;

                        while (count != 0)
                        {
                            val = random.Next(0, range);
                            --range;
                            --count;

                            int tval1, tval2;
                            var exist1 = dict.TryGetValue(val, out tval1);
                            var exist2 = dict.TryGetValue(range, out tval2);

                            if (exist1)
                            {
                                dict[val] = exist2 ? tval2 : range;
                                yield return sequence.ElementAt(tval1);
                            }
                            else
                            {
                                dict.Add(val, exist2 ? tval2 : range);
                                yield return sequence.ElementAt(val);
                            }
                        }

                        break;
                    }
            }
        }
    }
}
