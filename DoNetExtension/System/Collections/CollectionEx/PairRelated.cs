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
            return pairCollection.Select(pair => pair.Item1).ToArray();
        }

        public static T2[] GetSecondValues<T1, T2>(this ICollection<Pair<T1, T2>> pairCollection)
        {
            return pairCollection.Select(pair => pair.Item2).ToArray();
        }

        public static Pair<T1[], T2[]> Decompose<T1, T2>(this ICollection<Pair<T1, T2>> pairCollection)
        {
            var list1 = new LinkedList<T1>();
            var list2 = new LinkedList<T2>();

            foreach (var pair in pairCollection)
            {
                list1.AddLast(pair.Item1);
                list2.AddLast(pair.Item2);
            }

            return new Pair<T1[], T2[]>(list1.ToArray(), list2.ToArray());
        }

        public static T1[] GetFristValues<T1, T2>(this IList<Pair<T1, T2>> pairList)
        {
            var len = pairList.Count;
            var output = new T1[len];
            for (int i = 0; i < len; ++i)
                output[i] = pairList[i].Item1;
            return output;
        }

        public static T2[] GetSecondValues<T1, T2>(this IList<Pair<T1, T2>> pairList)
        {
            var len = pairList.Count;
            var output = new T2[len];
            for (int i = 0; i < len; ++i)
                output[i] = pairList[i].Item2;
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
                list1[i] = pair.Item1;
                list2[i] = pair.Item2;
            }

            return new Pair<T1[], T2[]>(list1, list2);
        }

        #region  ListAdd

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
        /// <typeparam name="TValue1">The type of the first value of the pair to add.</typeparam>
        /// <typeparam name="TValue2">The type of the second value of the pair to add.</typeparam>
        /// <param name="list">The list to operate on.</param>
        /// <param name="value1">The first value of the pair.</param>
        /// <param name="value2">The second value of the pair.</param>
        public static void Add<TValue1, TValue2>(this IList<(TValue1, TValue2)> list, TValue1 value1, TValue2 value2)
        {
            list.Add((value1, value2));
        }

        /// <summary>
        /// Adds a triple of values to this list of pairs.
        /// </summary>
        /// <typeparam name="TValue1">The type of the first value of the triple to add.</typeparam>
        /// <typeparam name="TValue2">The type of the second value of the triple to add.</typeparam>
        /// <typeparam name="TValue3">The type of the thrid value of the triple to add.</typeparam>
        /// <param name="list">The list to operate on.</param>
        /// <param name="value1">The first value of the triple.</param>
        /// <param name="value2">The second value of the triple.</param>
        /// <param name="value3">The third value of the triple.</param>
        public static void Add<TValue1, TValue2, TValue3>(this IList<Triple<TValue1, TValue2, TValue3>> list, TValue1 value1, TValue2 value2, TValue3 value3)
        {
            list.Add(new Triple<TValue1, TValue2, TValue3>(value1, value2, value3));
        }

        /// <summary>
        /// Adds a triple of values to this list of pairs.
        /// </summary>
        /// <typeparam name="TValue1">The type of the first value of the triple to add.</typeparam>
        /// <typeparam name="TValue2">The type of the second value of the triple to add.</typeparam>
        /// <typeparam name="TValue3">The type of the thrid value of the triple to add.</typeparam>
        /// <param name="list">The list to operate on.</param>
        /// <param name="value1">The first value of the triple.</param>
        /// <param name="value2">The second value of the triple.</param>
        /// <param name="value3">The third value of the triple.</param>
        public static void Add<TValue1, TValue2, TValue3>(this IList<(TValue1, TValue2, TValue3)> list, TValue1 value1, TValue2 value2, TValue3 value3)
        {
            list.Add((value1, value2, value3));
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
        /// Adds a triple of values to this list of triples. 
        /// </summary>
        /// <typeparam name="T">The type of the values of the triple.</typeparam>
        /// <param name="list">The list to operate on.</param>
        /// <param name="value1">The first value of the triple.</param>
        /// <param name="value2">The second value of the triple.</param>
        /// <param name="value3">The third value of the triple.</param>
        public static void Add<T>(this IList<Triple<T>> list, T value1, T value2, T value3)
        {
            list.Add(new Triple<T>(value1, value2, value3));
        }

        #endregion


        #region DictionaryAdd

        /// <summary>
        /// Adds a pair of values and its associated key to this dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of the key associated with the value pair.</typeparam>
        /// <typeparam name="TValue1">The type of the first value of the pair.</typeparam>
        /// <typeparam name="TValue2">The type of the second value of the pair.</typeparam>
        /// <param name="dict">The dictionary to operate on.</param>
        /// <param name="key">The key associated with the value pair.</param>
        /// <param name="value1">The first value of the pair.</param>
        /// <param name="value2">The second value of the pair.</param>
        public static void Add<TKey, TValue1, TValue2>(this IDictionary<TKey, (TValue1, TValue2)> dict, TKey key, TValue1 value1, TValue2 value2)
        {
            dict.Add(key, (value1, value2));
        }

        /// <summary>
        /// Adds a triple of values and its associated key to this dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of the key associated with the value triple.</typeparam>
        /// <typeparam name="TValue1">The type of the first value of the triple.</typeparam>
        /// <typeparam name="TValue2">The type of the second value of the triple.</typeparam>
        /// <typeparam name="TValue3">The type of the third value of the triple.</typeparam>
        /// <param name="dict">The dictionary to operate on.</param>
        /// <param name="key">The key associated with the value triple.</param>
        /// <param name="value1">The first value of the triple.</param>
        /// <param name="value2">The second value of the triple.</param>
        /// <param name="value3">The third value of the triple.</param>
        public static void Add<TKey, TValue1, TValue2, TValue3>(this IDictionary<TKey, (TValue1, TValue2, TValue3)> dict, TKey key, TValue1 value1, TValue2 value2, TValue3 value3)
        {
            dict.Add(key, (value1, value2, value3));
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


        /// <summary>
        /// Adds a triple of values and its associated key to this dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of the key associated with the value triple.</typeparam>
        /// <typeparam name="TValue">The type of the values of the triple.</typeparam>
        /// <param name="dict">The dictionary to operate on.</param>
        /// <param name="key">The key associated with the value triple.</param>
        /// <param name="value1">The first value of the triple.</param>
        /// <param name="value2">The second value of the triple.</param>
        /// <param name="value3">The second value of the triple.</param>
        public static void Add<TKey, TValue>(this IDictionary<TKey, Triple<TValue>> dict, TKey key, TValue value1, TValue value2, TValue value3)
        {
            dict.Add(key, new Triple<TValue>(value1, value2, value3));
        }

        /// <summary>
        /// Adds a triple of values and its associated key to this dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of the key associated with the value triple.</typeparam>
        /// <typeparam name="TValue1">The type of the first value of the triple.</typeparam>
        /// <typeparam name="TValue2">The type of the second value of the triple.</typeparam>
        /// <typeparam name="TValue3">The type of the third value of the triple.</typeparam>
        /// <param name="dict">The dictionary to operate on.</param>
        /// <param name="key">The key associated with the value triple.</param>
        /// <param name="value1">The first value of the triple.</param>
        /// <param name="value2">The second value of the triple.</param>
        /// <param name="value3">The second value of the triple.</param>
        public static void Add<TKey, TValue1, TValue2, TValue3>(this IDictionary<TKey, Triple<TValue1, TValue2, TValue3>> dict, TKey key, TValue1 value1, TValue2 value2, TValue3 value3)
        {
            dict.Add(key, new Triple<TValue1, TValue2, TValue3>(value1, value2, value3));
        }


        #endregion

    }
}
