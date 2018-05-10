using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    public static partial class GenericCollectionEx
    {
        public static T1[] GetFristValues<T1, T2>(this ICollection<Pair<T1, T2>> pairCollection)
        {
            return pairCollection.Select(pair => pair.First).ToArray();
        }

        public static T2[] GetSecondValues<T1, T2>(this ICollection<Pair<T1, T2>> pairCollection)
        {
            return pairCollection.Select(pair => pair.Second).ToArray();
        }

        public static Pair<T1[], T2[]> Decompose<T1, T2>(this ICollection<Pair<T1, T2>> pairCollection)
        {
            var list1 = new LinkedList<T1>();
            var list2 = new LinkedList<T2>();

            foreach (var pair in pairCollection)
            {
                list1.AddLast(pair.First);
                list2.AddLast(pair.Second);
            }

            return new Pair<T1[], T2[]>(list1.ToArray(), list2.ToArray());
        }

        public static T1[] GetFristValues<T1, T2>(this IList<Pair<T1, T2>> pairList)
        {
            var len = pairList.Count;
            var output = new T1[len];
            for (int i = 0; i < len; ++i)
                output[i] = pairList[i].First;
            return output;
        }

        public static T2[] GetSecondValues<T1, T2>(this IList<Pair<T1, T2>> pairList)
        {
            var len = pairList.Count;
            var output = new T2[len];
            for (int i = 0; i < len; ++i)
                output[i] = pairList[i].Second;
            return output;
        }

        public static Pair<T1[], T2[]> Decompose<T1, T2>(this IList<Pair<T1, T2>> pairList)
        {
            var len = pairList.Count;
            var list1 = new T1[len];
            var list2 = new T2[len];

            for (int i = 0; i < len; ++i)
            {
                var pair = pairList[i];
                list1[i] = pair.First;
                list2[i] = pair.Second;
            }

            return new Pair<T1[], T2[]>(list1, list2);
        }

        /// <summary>
        /// Adds a pair of values to this list of pairs. 
        /// </summary>
        /// <typeparam name="TValue1">The type of the first value of the pair to add.</typeparam>
        /// <typeparam name="TValue2">The type of the second value of the pair to add.</typeparam>
        /// <param name="list">The list to operate on.</param>
        /// <param name="value1">The first value of the pair.</param>
        /// <param name="value2">The second value of the pair.</param>
        public static void Add<TValue1, TValue2>(this IList<Pair<TValue1, TValue2>> list, TValue1 value1, TValue2 value2)
        {
            list.Add(new Pair<TValue1, TValue2>(value1, value2));
        }

        /// <summary>
        /// Adds a pair of values to this list of pairs. 
        /// </summary>
        /// <typeparam name="T">The type of the values of the pair.</typeparam>
        /// <param name="list">The list to operate on.</param>
        /// <param name="value1">The first value of the pair.</param>
        /// <param name="value2">The second value of the pair.</param>
        public static void Add<T>(this IList<Pair<T>> list, T value1, T value2)
        {
            list.Add(new Pair<T>(value1, value2));
        }

        /// <summary>
        /// Adds a pair of values and its associated key to this dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of the key associated with the value pair.</typeparam>
        /// <typeparam name="TValue1">The type of the first value of the pair to add.</typeparam>
        /// <typeparam name="TValue2">The type of the second value of the pair to add.</typeparam>
        /// <param name="dict">The dictionary to operate on.</param>
        /// <param name="key">The key associated with the value pair.</param>
        /// <param name="value1">The first value of the pair.</param>
        /// <param name="value2">The second value of the pair.</param>
        public static void Add<TKey, TValue1, TValue2>(this IDictionary<TKey, Pair<TValue1, TValue2>> dict, TKey key, TValue1 value1, TValue2 value2)
        {
            dict.Add(key, new Pair<TValue1, TValue2>(value1, value2));
        }

        /// <summary>
        /// Adds a pair of values and its associated key to this dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of the key associated with the value pair.</typeparam>
        /// <typeparam name="TValue">The type of the values of the pair.</typeparam>
        /// <param name="dict">The dictionary to operate on.</param>
        /// <param name="key">The key associated with the value pair.</param>
        /// <param name="value1">The first value of the pair.</param>
        /// <param name="value2">The second value of the pair.</param>
        public static void Add<TKey, TValue>(this IDictionary<TKey, Pair<TValue>> dict, TKey key, TValue value1, TValue value2)
        {
            dict.Add(key, new Pair<TValue>(value1, value2));
        }
    }
}
