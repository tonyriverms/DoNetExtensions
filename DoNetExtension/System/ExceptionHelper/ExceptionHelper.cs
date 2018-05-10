using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System_Extension_Library.System;
using DoNetExtension.System;

namespace System
{
    /// <summary>
    /// Provides frequently used exceptions and messages.
    /// </summary>
    public static class ExceptionHelper
    {
        /// <summary>
        /// For internal use only. Checks if the length of an array equals a specified value.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">The array to check.</param>
        /// <param name="validLength">The length of the specified <paramref name="array"/> must equal this value.</param>
        /// <param name="nameForTheArrayToCheck">The name for the array to check.</param>
        /// <exception cref="System.ArgumentException">Occurs when the length of the specified array does not equal the valid value.</exception>
        internal static void ArrayLengthCheck<T>(Array array, int validLength, string nameForTheArrayToCheck = "array")
        {
            if (array.Length != validLength)
                throw new ArgumentException(GeneralResources.ERR_ArrayLengthMustBeEqualToASpecificValue.Scan(nameForTheArrayToCheck, validLength));
        }

        /// <summary>
        /// Checks if <paramref name="min"/> is smaller or equal to <paramref name="max"/>. If not, an <see cref="ArgumentOutOfRangeException"/> will be thrown.
        /// </summary>
        /// <param name="min">The "min" argument.</param>
        /// <param name="max">The "max" argument.</param>
        /// <param name="argNameForMin">The name for the "min" argument.</param>
        /// <param name="argNameForMax">The name for the "max argument".</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when <paramref name="min"/> is greater than <paramref name="max"/>.</exception>
        public static void MinMaxArgumentCheck(dynamic min, dynamic max, string argNameForMin = "minValue", string argNameForMax = "maxValue")
        {
            if (min > max)
                throw (new ArgumentOutOfRangeException(argNameForMin, GeneralResources.ERR_InvalidMinMax.Scan(argNameForMin, argNameForMax)));
        }

        /// <summary>
        /// For internal use only. Checks whether the arguments <paramref name="startIndex"/> and <paramref name="length"/> are valid for a forward search method.
        /// </summary>
        /// <param name="startIndex">The start index indicating the position of the first character of the search scope.</param>
        /// <param name="length">The length of the search scope.</param>
        /// <param name="searchLimit">The maximum value that <paramref name="startIndex"/> plus <paramref name="length"/> can reach.</param>
        /// <param name="argNameForStartIndex">The argument name for <paramref name="startIndex"/> which will be displayed in the exception message.</param>
        /// <param name="argNameForLength">The argument name for <paramref name="length"/> which will be displayed in the exception message.</param>
        /// <returns>The end index, namely <paramref name="startIndex"/> plus <paramref name="length"/>.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when the value of either <paramref name="startIndex"/> or <paramref name="length"/> is not valid.</exception>
        internal static int ForwardCheckStartIndexAndLength(int startIndex, int length, int searchLimit, string argNameForStartIndex = "startIndex", string argNameForLength = "length")
        {
            if (searchLimit == 0)
            {
                if (startIndex != 0)
                    throw new ArgumentOutOfRangeException(ExceptionHelper.GetArgumentOutOfRangeMessage(argNameForStartIndex, 0, true, 0, true));
                else if (length != 0)
                    throw new ArgumentOutOfRangeException(ExceptionHelper.GetArgumentOutOfRangeMessage(argNameForLength, 0, true, 0, true));
                else return 0;
            }
            else
            {
                NonNegativeArgumentRequired(argNameForLength, length);
                ArgumentRangeRequired<int>(argNameForStartIndex, startIndex, 0, true, searchLimit - 1, true);
                var endIndex = startIndex + length;
                if (endIndex > searchLimit) throw new ArgumentOutOfRangeException(ExceptionHelper.GetArgumentOutOfRangeMessage(argNameForLength, 0, true, searchLimit - startIndex, true));
                return endIndex;
            }
        }

        /// <summary>
        /// For internal use only. Checks whether the arguments <paramref name="startIndex"/> and <paramref name="length"/> are valid for a backward search method.
        /// </summary>
        /// <param name="startIndex">The start index indicating the position of the last character of the search scope.</param>
        /// <param name="length">The length of the search scope.</param>
        /// <param name="startIndexLimit">The integer immediately larger than maximum value which <paramref name="startIndex"/> can reach.</param>
        /// <param name="argNameForStartIndex">The argument name for <paramref name="startIndex"/> which will be displayed in the exception message.</param>
        /// <param name="argNameForLength">The argument name for <paramref name="length"/> which will be displayed in the exception message.</param>
        /// <returns>The end index, namely <paramref name="startIndex"/> plus <paramref name="length"/>.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Occurs when the value of either <paramref name="startIndex"/> or <paramref name="length"/> is not valid.</exception>
        internal static int BackwardCheckStartIndexAndLength(int startIndex, int length, int startIndexLimit, string argNameForStartIndex = "startIndex", string argNameForLength = "length")
        {
            if (startIndexLimit == 0)
            {
                if (startIndex != 0)
                    throw new ArgumentOutOfRangeException(ExceptionHelper.GetArgumentOutOfRangeMessage(argNameForStartIndex, 0, true, 0, true));
                else if (length != 0)
                    throw new ArgumentOutOfRangeException(ExceptionHelper.GetArgumentOutOfRangeMessage(argNameForLength, 0, true, 0, true));
                else return 0;
            }
            else
            {
                NonNegativeArgumentRequired(argNameForLength, length);
                ArgumentRangeRequired<int>(argNameForStartIndex, startIndex, 0, true, startIndexLimit - 1, true);
                var endIndex = startIndex - length;
                if (endIndex < -1) throw new ArgumentOutOfRangeException(ExceptionHelper.GetArgumentOutOfRangeMessage(argNameForLength, 0, true, startIndex + 1, true));
                return endIndex;
            }
        }

        /// <summary>
        /// Throws a <see cref="System.ArgumentOutOfRangeException"/> when the provided argument is out of range.
        /// </summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="argumentName">The name of the argument. This name will be displayed in the exception message.</param>
        /// <param name="argumentValue">The value of the argument.</param>
        /// <param name="lowerBound">The lower bound of the valid range.</param>
        /// <param name="lowerBoundInclusive"><c>true</c> to indicate the lower bound is inclusive; otherwise, <c>false</c>.</param>
        /// <param name="higherBound">The higher bound of the valid range.</param>
        /// <param name="higherBoundInclusive"><c>true</c> to indicate the higher bound is inclusive; otherwise, <c>false</c>.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static void ArgumentRangeRequired<T>(string argumentName, T argumentValue, T lowerBound, bool lowerBoundInclusive, T higherBound, bool higherBoundInclusive) where T : IComparable
        {
            var lowerBoundTest = lowerBoundInclusive ? argumentValue.CompareTo(lowerBound) < 0 : argumentValue.CompareTo(lowerBound) <= 0;
            var higherBoundTest = higherBoundInclusive ? argumentValue.CompareTo(higherBound) > 0 : argumentValue.CompareTo(higherBound) >= 0;
            if (!lowerBoundTest && !higherBoundTest) return;
            throw new ArgumentOutOfRangeException(argumentName, GetArgumentOutOfRangeMessage(argumentName, lowerBound, lowerBoundInclusive, higherBound, higherBoundInclusive));
        }

        /// <summary>
        /// Gets a message indicating the value of an argument is out of valid range.
        /// </summary>
        /// <param name="argumentName">The name of the argument whose value is out of range.</param>
        /// <param name="lowerBound">The lower bound of the valid range.</param>
        /// <param name="lowerBoundInclusive"><c>true</c> to indicate the lower bound is inclusive; otherwise, <c>false</c>.</param>
        /// <param name="higherBound">The higher bound of the valid range.</param>
        /// <param name="higherBoundInclusive"><c>true</c> to indicate the higher bound is inclusive; otherwise, <c>false</c>.</param>
        /// <returns>A message indicating some argument's value is out of valid range.</returns>
        internal static string GetArgumentOutOfRangeMessage(string argumentName, dynamic lowerBound, bool lowerBoundInclusive, dynamic higherBound, bool higherBoundInclusive)
        {
            return GeneralResources.ERR_ArgumentOutOfRange.Scan(argumentName,
                (object)lowerBound, lowerBoundInclusive ? "inclusive" : "exclusive",
                (object)higherBound, higherBoundInclusive ? "inclusive" : "exclusive");
        }

        /// <summary>
        /// Throws a <see cref="System.ArgumentOutOfRangeException" /> when the provided argument is not positive.
        /// </summary>
        /// <param name="argumentName">The name of the argument whose value should be positive. This name will be displayed in the exception message.</param>
        /// <param name="argumentValue">The value of the argument.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        internal static void PositiveArgumentRequired(string argumentName, dynamic argumentValue)
        {
            if (argumentValue > 0) return;
            throw new ArgumentOutOfRangeException(argumentName, GetPositiveArgumentRequiredMessage(argumentName));
        }

        /// <summary>
        /// Gets a message indicating an argument value should be positive yet it is assigned a non-positive value.
        /// </summary>
        /// <param name="argumentName">The name of the argument whose value should be positive.</param>
        /// <returns>A message indicating the argument of the provided name should be positive.</returns>
        internal static string GetPositiveArgumentRequiredMessage(string argumentName)
        {
            return GeneralResources.ERR_PositiveArgumentRequired.Scan(argumentName);
        }

        /// <summary>
        /// Throws a <see cref="System.ArgumentOutOfRangeException" /> when the provided argument is negative.
        /// </summary>
        /// <param name="argumentName">The name of the argument whose value should not be negative. This name will be displayed in the exception message.</param>
        /// <param name="argumentValue">The value of the argument.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void NonNegativeArgumentRequired(string argumentName, dynamic argumentValue)
        {
            if (argumentValue < 0)
                throw new ArgumentOutOfRangeException(argumentName, GetNonNegativeArgumentRequiredMessage(argumentName));
        }

        /// <summary>
        /// Gets a message indicating an argument value should be non-negative yet it is assigned a negative value.
        /// </summary>
        /// <param name="argumentName">The name of the argument whose value should be non-negative.</param>
        /// <returns>A message indicating the argument of the provided name should be non-negative.</returns>
        internal static string GetNonNegativeArgumentRequiredMessage(string argumentName)
        {
            return GeneralResources.ERR_NonNegativeArgumentRequired.Scan(argumentName);
        }

        /// <summary>
        /// Throws a <see cref="System.ArgumentNullException" /> when the provided <paramref name="array" /> is <c>null</c>, or throws a <see cref="System.ArgumentException" /> when the provided <paramref name="array" /> is <c>empty</c>.
        /// </summary>
        /// <typeparam name="T">The type of the element in the array.</typeparam>
        /// <param name="array">The array.</param>
        /// <param name="arrayName">Provides the name of the array that will be shown in the exception message.</param>
        /// <returns>The number of elements contained in <paramref name="array" />. This return is for your convenience.</returns>
        /// <exception cref="System.ArgumentNullException">Occurs when <paramref name="array" /> is <c>null</c>.</exception>
        /// <exception cref="System.ArgumentException">Occurs when <paramref name="array" /> is empty.</exception>
        public static int NonEmptyArrayRequired<T>(T[] array, string arrayName = "array")
        {
            if (array == null) throw new ArgumentNullException(GeneralResources.ERR_NullArray.Scan(arrayName));
            var arrayLen = array.Length;
            if (arrayLen == 0) throw new ArgumentException(GeneralResources.ERR_EmptyArray.Scan(arrayName));
            return arrayLen;
        }

        /// <summary>
        /// Throws a <see cref="System.ArgumentNullException" /> when the provided <paramref name="list" /> is <c>null</c>, or throws a <see cref="System.ArgumentException" /> when the provided <paramref name="list" /> is <c>empty</c>.
        /// </summary>
        /// <typeparam name="T">The type of the element in the list.</typeparam>
        /// <param name="list">The list.</param>
        /// <param name="listName">Provides the name of the list that will be shown in the exception message.</param>
        /// <returns>The number of elements contained in <paramref name="list" />. This return is for your convenience.</returns>
        /// <exception cref="System.ArgumentNullException">Occurs when <paramref name="list" /> is <c>null</c>.</exception>
        /// <exception cref="System.ArgumentException">Occurs when <paramref name="list" /> is empty.</exception>
        public static int NonEmptyListRequired<T>(IList<T> list, string listName = "list")
        {
            if (list == null) throw new ArgumentNullException(GeneralResources.ERR_NullList.Scan(listName));
            var weightCount = list.Count;
            if (weightCount == 0) throw new ArgumentException(GeneralResources.ERR_EmptyList.Scan(listName));
            return weightCount;
        }

        /// <summary>
        /// Throws a <see cref="System.ArgumentNullException" /> when the provided <paramref name="collection" /> is <c>null</c>, or throws a <see cref="System.ArgumentException" /> when the provided <paramref name="collection" /> is <c>empty</c>.
        /// </summary>
        /// <typeparam name="T">The type of the element in the collection.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="collectionName">Name of the collection.</param>
        /// <returns>The number of elements contained in <paramref name="collection" />. This return is for your convenience.</returns>
        /// <exception cref="System.ArgumentNullException">Occurs when <paramref name="collection" /> is <c>null</c>.</exception>
        /// <exception cref="System.ArgumentException">Occurs when <paramref name="collection" /> is empty.</exception>
        public static int NonEmptyCollectionRequired<T>(IEnumerable<T> collection, string collectionName = "collection")
        {
            if (collection == null) throw new ArgumentNullException(GeneralResources.ERR_NullCollection.Scan(collectionName));
            var collectionCount = collection.Count();
            if (collectionCount == 0) throw new ArgumentException(GeneralResources.ERR_EmptyCollection.Scan(collectionName));
            return collectionCount;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> when the lengths of <paramref name="array1"/> and <paramref name="array2"/> are not equal.
        /// </summary>
        /// <typeparam name="TArray1">The type of element in <paramref name="array1"/>.</typeparam>
        /// <typeparam name="TArray2">The type of element in <paramref name="array2"/>.</typeparam>
        /// <param name="array1">The first array, whose length must be equal to <paramref name="array2"/>. This argument cannot be <c>null</c>.</param>
        /// <param name="array2">The second array, whose length must be equal to <paramref name="array1"/>. This argument cannot be <c>null</c>.</param>
        /// <param name="array1Name">The name for <paramref name="array1"/>.</param>
        /// <param name="array2Name">The name for <paramref name="array2"/>.</param>
        /// <returns>The length of <paramref name="array1"/> and <paramref name="array2"/>.</returns>
        /// <exception cref="System.ArgumentException">Occurs when the lengths of <paramref name="array1"/> and <paramref name="array2"/> are not equal.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int EqualArrayLengthRequired<TArray1, TArray2>(TArray1[] array1, TArray2[] array2, string array1Name, string array2Name)
        {
            var arrLen = array1.Length;
            if (arrLen != array2.Length) throw new ArgumentException(GeneralResources.ERR_EqualArrayLengthRequired.Scan(array1Name, array2Name));
            return arrLen;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> when the lengths of <paramref name="array1"/> and <paramref name="array2"/> are not equal; or only one of <paramref name="array1"/> and <paramref name="array2"/> is <c>null</c>.
        /// </summary>
        /// <typeparam name="TArray1">The type of element in <paramref name="array1"/>.</typeparam>
        /// <typeparam name="TArray2">The type of element in <paramref name="array2"/>.</typeparam>
        /// <param name="array1">The first array, whose length must be equal to <paramref name="array2"/>. This argument can be <c>null</c>, in which case <paramref name="array2"/> should also be <c>null</c>.</param>
        /// <param name="array2">The second array, whose length must be equal to <paramref name="array1"/>. This argument can be <c>null</c>, in which case <paramref name="array1"/> should also be <c>null</c>.</param>
        /// <param name="array1Name">The name for <paramref name="array1"/>.</param>
        /// <param name="array2Name">The name for <paramref name="array2"/>.</param>
        /// <returns>The length of <paramref name="array1"/> and <paramref name="array2"/>.</returns>
        /// <exception cref="System.ArgumentException">Occurs when the lengths of <paramref name="array1"/> and <paramref name="array2"/> are not equal; or only one of <paramref name="array1"/> and <paramref name="array2"/> is <c>null</c>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int EqualArrayLengthRequiredOrBothNull<TArray1, TArray2>(TArray1[] array1, TArray2[] array2, string array1Name, string array2Name)
        {
            if (array1 == null)
            {
                if (array2 == null) return 0;
                else throw new ArgumentException(GeneralResources.ERR_EqualArrayLengthRequired.Scan(array1Name, array2Name));
            }
            else
            {
                var arrLen = array1.Length;
                if (arrLen != array2.Length) throw new ArgumentException(GeneralResources.ERR_EqualArrayLengthRequired.Scan(array1Name, array2Name));
                return arrLen;
            }
        }
    }
}
