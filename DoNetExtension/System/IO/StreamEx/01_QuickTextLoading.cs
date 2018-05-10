using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.IO
{
    public static partial class StringEx
    {
        #region Integers


        /// <summary>
        /// Treat the current string instance as a file path to a text file, and loads the <see cref="int"/> array from the text file. Each line of text in the file should represent one number. There should not be empty lines in the file. 
        /// </summary>
        /// <param name="path">The current string instance as a path to a text file.</param>
        /// <param name="encoding">Provides the encoding for the text file.</param>
        /// <returns>The <see cref="int"/> array read from the text file.</returns>
        public static int[] LoadIntegers(this string path, Encoding encoding)
        {
            var lines = File.ReadAllLines(path);
            var count = lines.Length;
            var output = new int[count];
            for (int i = 0; i < count; ++i)
                output[i] = lines[i].ToInt32();
            return output;
        }

        /// <summary>
        /// Treat the current string instance as a file path to a text file, and loads a <see cref="int"/> array from the text file. Each line of text in the file should represent one number. There should not be empty lines in the file. The default encoding is <see cref="Encoding.UTF8"/>.
        /// </summary>
        /// <param name="path">The current string instance as a path to a text file.</param>
        /// <returns>The <see cref="int"/> array read from the text file.</returns>
        public static int[] LoadIntegers(this string path)
        {
            return LoadIntegers(path, Encoding.UTF8);
        }

        /// <summary>
        /// Treat the current string instance as a file path to a text file, and loads a <see cref="long"/> array from the text file. Each line of text in the file should represent one number. There should not be empty lines in the file. 
        /// </summary>
        /// <param name="path">The current string instance as a path to a text file.</param>
        /// <param name="encoding">Provides the encoding for the text file.</param>
        /// <returns>The <see cref="long"/> array read from the text file.</returns>
        public static long[] LoadLongIntegers(this string path, Encoding encoding)
        {
            var lines = File.ReadAllLines(path);
            var count = lines.Length;
            var output = new long[count];
            for (int i = 0; i < count; ++i)
                output[i] = lines[i].ToInt64();
            return output;
        }

        /// <summary>
        /// Treat the current string instance as a file path to a text file, and loads the <see cref="long"/> array from the text file. Each line of text in the file should represent one number. There should not be empty lines in the file. The default encoding is <see cref="Encoding.UTF8"/>.
        /// </summary>
        /// <param name="path">The current string instance as a path to a text file.</param>
        /// <returns>The <see cref="long"/> array read from the text file.</returns>
        public static long[] LoadLongIntegers(this string path)
        {
            return LoadLongIntegers(path, Encoding.UTF8);
        }

        /// <summary>
        /// Treat the current string instance as a file path to a text file, and loads the <see cref="int"/> arrays from the text file. 
        /// <para>Each line of text in the file represents one array, and substrings separated by spaces are integer elements in the array.</para>
        /// <para>Empty lines are ignored. Multiple white spaces in a line are treated as a single white space.</para>
        /// </summary>
        /// <param name="path">The current string instance as a path to a text file.</param>
        /// <param name="encoding">Provides the encoding for the text file.</param>
        /// <returns>The <see cref="int"/> arrays read from the text file.</returns>
        public static int[][] LoadInt32Arrays(this string path, Encoding encoding)
        {
            var list = new List<int[]>();
            using (var fs = new FileStream(path, FileMode.Open))
            {
                using (var sr = new StreamReader(fs, encoding))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var arr = line.ToInt32Array();
                        if (arr.IsNotEmpty()) list.Add(arr);
                    }
                }
            }
            return list.ToArray();
        }


        /// <summary>
        /// Treat the current string instance as a file path to a text file, and loads the <see cref="int"/> arrays from the text file. The default encoding is <see cref="Encoding.UTF8"/>.
        /// <para>Each line of text in the file represents one array, and substrings separated by spaces are integer elements in the array.</para>
        /// <para>Empty lines are ignored. Multiple white spaces in a line are treated as a single white space.</para>
        /// </summary>
        /// <param name="path">The current string instance as a path to a text file.</param>
        /// <returns>The <see cref="int"/> arrays read from the text file.</returns>
        public static int[][] LoadInt32Arrays(this string path)
        {
            return LoadInt32Arrays(path, Encoding.UTF8);
        }

        /// <summary>
        /// Treat the current string instance as a file path to a text file, and loads the string arrays from the text file. 
        /// <para>Each line of text in the file represents one array, and substrings separated by spaces are elements in the array.</para>
        /// <para>Empty lines are ignored. Multiple white spaces in a line are treated as a single white space.</para>
        /// </summary>
        /// <param name="path">The current string instance as a path to a text file.</param>
        /// <param name="encoding">Provides the encoding for the text file.</param>
        /// <returns>The string arrays read from the text file.</returns>
        public static string[][] LoadStringArrays(this string path, Encoding encoding)
        {
            var list = new List<string[]>();
            using (var fs = new FileStream(path, FileMode.Open))
            {
                using (var sr = new StreamReader(fs, encoding))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var strs = line.SplitBySpaces(StringSplitOptions.RemoveEmptyEntries);
                        if (strs.IsNotEmpty())
                            list.Add(strs);
                    }
                }
            }
            return list.ToArray();
        }

        /// <summary>
        /// Treats the current string instance as a file path to a text file, and loads the string arrays from the text file. The default encoding is <see cref="Encoding.UTF8"/>.
        /// <para>Each line of text in the file represents one array, and substrings separated by spaces are elements in the array.</para>
        /// <para>Empty lines are ignored. Multiple white spaces in a line are treated as a single white space.</para>
        /// </summary>
        /// <param name="path">The current string instance as a path to a text file.</param>
        /// <returns>The string arrays read from the text file.</returns>
        public static string[][] LoadStringArrays(this string path)
        {
            return LoadStringArrays(path, Encoding.UTF8);
        }

        /// <summary>
        /// Treats the current string instance as a file path to a text file, and loads a string-keyed dictionary from the text file. 
        /// <para>Each line of text in the file represents a dictionary entry. Each line is first split by the specified <paramref name="delimiter"/> into a string array; The first element in the array is used as the key, while the remaining elements are converted as <see cref="double"/> values associated with the key.</para>
        /// </summary>
        /// <param name="path">The current string instance as a path to a text file.</param>
        /// <param name="delimiter">The delimiter that separates key and values.</param>
        /// <param name="encoding">Provides the encoding for the text file.</param>
        /// <returns>The string-keyed dictionary read from the text file.</returns>
        public static Dictionary<string, double[]> LoadStringDictionary(this string path, string delimiter, Encoding encoding)
        {
            var dict = new Dictionary<string, double[]>();
            using (var fs = new FileStream(path, FileMode.Open))
            {
                using (var sr = new StreamReader(fs))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var strs = line.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

                        var valueCount = strs.Length - 1;
                        if (valueCount > 0)
                        {
                            var values = new double[valueCount];
                            for (int i = 0, j = 1; i < valueCount; ++i, ++j)
                                values[i] = strs[j].ToDouble();
                            dict.Add(strs[0], values);
                        }
                    }
                }
            }
            return dict;
        }

        /// <summary>
        /// Treats the current string instance as a file path to a text file, and loads a string-keyed dictionary from the text file. The default encoding is <see cref="Encoding.UTF8"/>.
        /// <para>Each line of text in the file represents a dictionary entry. Each line is first split by the specified <paramref name="delimiter" /> into a string array; The first element in the array is used as the key, while the remaining elements are converted as <see cref="double" /> values associated with the key.</para>
        /// </summary>
        /// <param name="path">The current string instance as a path to a text file.</param>
        /// <param name="delimiter">The delimiter that separates key and values.</param>
        /// <returns>The string-keyed dictionary read from the text file.</returns>
        public static Dictionary<string, double[]> LoadStringDictionary(this string path, string delimiter)
        {
            return LoadStringDictionary(path, delimiter, Encoding.UTF8);
        }

        #endregion
    }
}
