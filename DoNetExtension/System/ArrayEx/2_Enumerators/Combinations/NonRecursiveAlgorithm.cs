using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class ArrayEx
    {
        static IEnumerator<T[]> _combNonRecursive<T>(T[] array, int startIndex, int endIndex, int length, int k)
        {
            var idxes = CreateConsecutiveIntegers(0, k - 1);
            var output = array.SubArray(startIndex, k);
            yield return output.Copy();

            while (true)
            {
                var currDepth = k - 1;
                while (currDepth != -1)
                {
                    ++idxes[currDepth];
                    if (idxes[currDepth] == length + 1 + currDepth - k)
                        --currDepth;
                    else
                    {
                        var preIndex = idxes[currDepth];
                        output[currDepth] = array[startIndex + preIndex];

                        while (currDepth != k - 1)
                        {
                            ++currDepth;
                            idxes[currDepth] = ++preIndex;
                            output[currDepth] = array[startIndex + preIndex];
                        }

                        yield return output.Copy();
                        break;
                    }
                }

                if (currDepth == -1) break;
            }
        }

        static IEnumerator<T[]> _combNonRecursive<T>(T[] array, int startIndex, int endIndex, int length, int outputStartIndex, int startK, int endK)
        {
            if (startK <= endK)
            {
                for (int k = startK; k <= endK; ++k)
                {
                    var innerIE = _combNonRecursive<T>(array, startIndex, endIndex, length, k);
                    while (innerIE.MoveNext()) yield return innerIE.Current;
                }
            }
            else
            {
                for (int k = startK; k >= endK; --k)
                {
                    var innerIE = _combNonRecursive<T>(array, startIndex, endIndex, length, k);
                    while (innerIE.MoveNext()) yield return innerIE.Current;
                }
            }
        }

        static IEnumerator<T[]> _combNonRecursive<T>(T[] array, int startIndex, int endIndex, int length, int outputStartIndex, int startK, int endK, int[] counts)
        {
            var countIdx = 0;
            var countLen = counts.Length;
            int count = 0;

            var k = startK;
            while (true)
            {
                if (countIdx < countLen) count = counts[countIdx];
                else count = -1;

                var innerIE = _combNonRecursive<T>(array, startIndex, endIndex, length, k);

                var i = 0;
                while (innerIE.MoveNext() && (count == -1 || i < count))
                {
                    yield return innerIE.Current;
                    ++i;
                }
                ++countIdx;

                if (k == endK) break;
                k = startK > endK ? k - 1 : k + 1;
            }
        }
    }
}
