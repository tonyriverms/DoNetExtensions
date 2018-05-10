using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class ArrayEx
    {
        /// <summary>
        /// Converts an array/list of objects to a byte array. Supported objects include
        /// <para>1. all system integers, numbers and their array/list (except System.Decimal and its array/list);</para>
        /// <para>2. System.Char and its array/list;</para>
        /// <para>3. System.DateTime and its array/list;</para>
        /// <para>4. System.String and its array/list (encoded by Unicode); </para>
        /// <para>5. a struct whose size is able to be determined by System.Runtime.InteropServices.Marshal.SizeOf method (however, array/list of structs is not supported);</para>
        /// <para>6. any other type that has a method named ToBytes.</para>
        /// <para>!!! This is intended to be an one-way conversion and the byte array cannot be converted back to objects 
        /// unless you know all the details of the byte array's format.</para>
        /// </summary>
        /// <param name="array">The current array/list of objects.</param>
        /// <returns></returns>
        public static byte[] ToBytes(this IList<object> array)
        {
            var len = array.Count;
            var byteCount = 0;
            var preBytes = new byte[len][];
            var sizes = new Int32[len];
            for (int i = 0; i < len; ++i)
            {
                if (array[i] == null)
                    continue;
                var type = array[i].GetType();
                if (type.Equals(typeof(string)))
                {
                    var str = array[i] as string;
                    if (!str.IsNullOrEmpty())
                    {
                        preBytes[i] = Encoding.Unicode.GetBytes(str);
                        byteCount += preBytes[i].Length;
                    }
                }
                else if (type.Equals(typeof(string[])))
                {
                    var strs = array[i] as string[];
                    var ms = new MemoryStream();
                    if (!strs.IsNullOrEmpty())
                    {
                        foreach (var str in strs)
                            if (!str.IsNullOrEmpty())
                                ms.WriteBytes(Encoding.Unicode.GetBytes(str));

                        preBytes[i] = ms.ToArray();
                        byteCount += preBytes[i].Length;
                    }
                }
                else if (type.IsGenericType &&
                    type.GetInterface("IList") != null &&
                    type.GetGenericArguments()[0].Equals(typeof(string)))
                {
                    var strs = array[i] as IList<string>;
                    var ms = new MemoryStream();
                    if (!strs.IsNullOrEmpty())
                    {
                        foreach (var str in strs)
                            if (!str.IsNullOrEmpty())
                                ms.WriteBytes(Encoding.Unicode.GetBytes(str));

                        preBytes[i] = ms.ToArray();
                        byteCount += preBytes[i].Length;
                    }
                }
                else
                {
                    bool success = false;
                    try
                    {
                        sizes[i] = Marshal.SizeOf(type);
                        byteCount += sizes[i];
                        success = true;
                    }
                    catch { }

                    if (!success)
                    {
                        try
                        {
                            dynamic obj = array[i];
                            preBytes[i] = obj.ToBytes();
                            byteCount += preBytes[i].Length;
                            success = true;
                        }
                        catch { }
                    }

                    if (!success)
                    {
                        try
                        {
                            dynamic obj = array[i];
                            preBytes[i] = ToBytes(obj);
                            byteCount += preBytes[i].Length;
                            success = true;
                        }
                        catch { }
                    }

                    if (!success)
                        throw new InvalidCastException();

                }
            }
            var bytes = new byte[byteCount];

            byteCount = 0;
            for (int i = 0; i < len; i++)
            {
                if (preBytes[i] != null)
                {
                    preBytes[i].CopyTo(bytes, byteCount);
                    byteCount += preBytes[i].Length;
                    continue;
                }
                else if (array[i] == null)
                    continue;
                GCHandle gch = GCHandle.Alloc(array[i], GCHandleType.Pinned);
                try
                {
                    Marshal.Copy(gch.AddrOfPinnedObject(), bytes, byteCount, bytes.Length - byteCount);
                    byteCount += sizes[i];
                    gch.Free();
                }
                catch (Exception ex)
                {
                    gch.Free();
                    throw ex;
                }
            }
            return bytes;
        }

        /// <summary>
        /// Converts the current array/list of System.SBytes to its equivalent byte array representation.
        /// </summary>
        /// <param name="array">The current array/list of System.SBytes.</param>
        /// <returns>A byte array converted from the current System.SByte array/list.</returns>
        public unsafe static byte[] ToBytes(this IList<SByte> array)
        {
            var len = array.Count;
            var bytes = new byte[len];

            fixed (byte* bytePtr = bytes)
            {
                var intPtr = (SByte*)bytePtr;
                for (int i = 0; i < len; ++i)
                    intPtr[i] = array[i];
            }
            return bytes;
        }

        /// <summary>
        /// Converts the current array/list of System.SBytes to its equivalent byte array representation.
        /// </summary>
        /// <param name="array">The current array/list of System.SBytes.</param>
        /// <param name="safe">Specifies whether the safe .NET class System.IO.MemoryStream should be used to perform the conversion rather than unsafe pointers.</param>
        /// <returns>A byte array converted from the current System.SByte array/list.</returns>
        public static byte[] ToBytes(this IList<SByte> array, bool safe)
        {
            if (safe)
            {
                var ms = new MemoryStream();
                foreach (var integer in array)
                    ms.WriteSByte(integer);
                return ms.ToArray();
            }
            else return ToBytes(array);
        }


        /// <summary>
        /// Converts the current array/list of System.Chars to its equivalent byte array representation.
        /// </summary>
        /// <param name="array">The current array/list of System.Chars.</param>
        /// <returns>A byte array converted from the current System.Char array/list.</returns>
        public unsafe static byte[] ToBytes(this IList<Char> array)
        {
            var len = array.Count;
            var bytes = new byte[len];

            fixed (byte* bytePtr = bytes)
            {
                var intPtr = (Char*)bytePtr;
                for (int i = 0; i < len; ++i)
                    intPtr[i] = array[i];
            }
            return bytes;
        }

        /// <summary>
        /// Converts the current array/list of System.Chars to its equivalent byte array representation.
        /// </summary>
        /// <param name="array">The current array/list of System.SBytes.</param>
        /// <param name="safe">Specifies whether the safe .NET class System.IO.MemoryStream should be used to perform the conversion rather than unsafe pointers.</param>
        /// <returns>A byte array converted from the current System.Char array/list.</returns>
        public static byte[] ToBytes(this IList<Char> array, bool safe)
        {
            if (safe)
            {
                var ms = new MemoryStream();
                foreach (var integer in array)
                    ms.WriteChar(integer);
                return ms.ToArray();
            }
            else return ToBytes(array);
        }

        /// <summary>
        /// Converts the current array/list of System.Int16 integers to its equivalent byte array representation.
        /// </summary>
        /// <param name="array">The current array/list of System.Int16 integers.</param>
        /// <returns>A byte array converted from the current System.Int16 array/list.</returns>
        public unsafe static byte[] ToBytes(this IList<Int16> array)
        {
            var len = array.Count;
            var bytes = new byte[len * sizeof(Int16)];

            fixed (byte* bytePtr = bytes)
            {
                var intPtr = (Int16*)bytePtr;
                for (int i = 0; i < len; ++i)
                    intPtr[i] = array[i];
            }
            return bytes;
        }

        /// <summary>
        /// Converts the current array/list of System.Int16 integers to its equivalent byte array representation.
        /// </summary>
        /// <param name="array">The current array/list of System.Int16 integers.</param>
        /// <param name="safe">Specifies whether the safe .NET class System.IO.MemoryStream should be used to perform the conversion rather than unsafe pointers.</param>
        /// <returns>A byte array converted from the current System.Int16 array/list.</returns>
        public static byte[] ToBytes(this IList<Int16> array, bool safe)
        {
            if (safe)
            {
                var ms = new MemoryStream();
                foreach (var integer in array)
                    ms.WriteInt16(integer);
                return ms.ToArray();
            }
            else return ToBytes(array);
        }

        /// <summary>
        /// Converts the current array/list of System.UInt16 integers to its equivalent byte array representation.
        /// </summary>
        /// <param name="array">The current array/list of System.UInt16 integers.</param>
        /// <returns>A byte array converted from the current System.UInt16 array/list.</returns>
        public unsafe static byte[] ToBytes(this IList<UInt16> array)
        {
            var len = array.Count;
            var bytes = new byte[len * sizeof(UInt16)];

            fixed (byte* bytePtr = bytes)
            {
                var intPtr = (UInt16*)bytePtr;
                for (int i = 0; i < len; ++i)
                    intPtr[i] = array[i];
            }
            return bytes;
        }

        /// <summary>
        /// Converts the current array/list of System.UInt16 integers to its equivalent byte array representation.
        /// </summary>
        /// <param name="array">The current array/list of System.UInt16 integers.</param>
        /// <param name="safe">Specifies whether the safe .NET class System.IO.MemoryStream should be used to perform the conversion rather than unsafe pointers.</param>
        /// <returns>A byte array converted from the current System.UInt16 array/list.</returns>
        public static byte[] ToBytes(this IList<UInt16> array, bool safe)
        {
            if (safe)
            {
                var ms = new MemoryStream();
                foreach (var integer in array)
                    ms.WriteUInt16(integer);
                return ms.ToArray();
            }
            else return ToBytes(array);
        }

        /// <summary>
        /// Converts the current array/list of System.Int32 integers to its equivalent byte array representation.
        /// </summary>
        /// <param name="array">The current array/list of System.Int32 integers.</param>
        /// <returns>A byte array converted from the current System.Int32 array/list.</returns>
        public unsafe static byte[] ToBytes(this IList<Int32> array)
        {
            var len = array.Count;
            var bytes = new byte[len * sizeof(Int32)];

            fixed (byte* bytePtr = bytes)
            {
                var intPtr = (Int32*)bytePtr;
                for (int i = 0; i < len; ++i)
                    intPtr[i] = array[i];
            }
            return bytes;
        }

        /// <summary>
        /// Converts the current array/list of System.Int32 integers to its equivalent byte array representation.
        /// </summary>
        /// <param name="array">The current array/list of System.Int32 integers.</param>
        /// <param name="safe">Specifies whether the safe .NET class System.IO.MemoryStream should be used to perform the conversion rather than unsafe pointers.</param>
        /// <returns>A byte array converted from the current System.Int32 array/list.</returns>
        public static byte[] ToBytes(this IList<Int32> array, bool safe)
        {
            if (safe)
            {
                var ms = new MemoryStream();
                foreach (var integer in array)
                    ms.WriteInt32(integer);
                return ms.ToArray();
            }
            else return ToBytes(array);
        }

        /// <summary>
        /// Converts the current array/list of System.UInt32 integers to its equivalent byte array representation.
        /// </summary>
        /// <param name="array">The current array/list of System.UInt32 integers.</param>
        /// <returns>A byte array converted from the current System.UInt32 array/list.</returns>
        public unsafe static byte[] ToBytes(this IList<UInt32> array)
        {
            var len = array.Count;
            var bytes = new byte[len * sizeof(UInt32)];

            fixed (byte* bytePtr = bytes)
            {
                var intPtr = (UInt32*)bytePtr;
                for (int i = 0; i < len; ++i)
                    intPtr[i] = array[i];
            }
            return bytes;
        }

        /// <summary>
        /// Converts the current array/list of System.UInt32 integers to its equivalent byte array representation.
        /// </summary>
        /// <param name="array">The current array/list of System.UInt32 integers.</param>
        /// <param name="safe">Specifies whether the safe .NET class System.IO.MemoryStream should be used to perform the conversion rather than unsafe pointers.</param>
        /// <returns>A byte array converted from the current System.UInt32 array/list.</returns>
        public static byte[] ToBytes(this IList<UInt32> array, bool safe)
        {
            if (safe)
            {
                var ms = new MemoryStream();
                foreach (var integer in array)
                    ms.WriteUInt32(integer);
                return ms.ToArray();
            }
            else return ToBytes(array);
        }

        /// <summary>
        /// Converts the current array/list of System.Int64 integers to its equivalent byte array representation.
        /// </summary>
        /// <param name="array">The current array/list of System.Int64 integers.</param>
        /// <returns>A byte array converted from the current System.Int64 array/list.</returns>
        public unsafe static byte[] ToBytes(this IList<Int64> array)
        {
            var len = array.Count;
            var bytes = new byte[len * sizeof(Int64)];

            fixed (byte* bytePtr = bytes)
            {
                var intPtr = (Int64*)bytePtr;
                for (int i = 0; i < len; ++i)
                    intPtr[i] = array[i];
            }
            return bytes;
        }

        /// <summary>
        /// Converts the current array/list of System.Int64 integers to its equivalent byte array representation.
        /// </summary>
        /// <param name="array">The current array/list of System.Int64 integers.</param>
        /// <param name="safe">Specifies whether the safe .NET class System.IO.MemoryStream should be used to perform the conversion rather than unsafe pointers.</param>
        /// <returns>A byte array converted from the current System.Int64 array/list.</returns>
        public static byte[] ToBytes(this IList<Int64> array, bool safe)
        {
            if (safe)
            {
                var ms = new MemoryStream();
                foreach (var integer in array)
                    ms.WriteInt64(integer);
                return ms.ToArray();
            }
            else return ToBytes(array);
        }

        /// <summary>
        /// Converts the current array/list of System.UInt64 integers to its equivalent byte array representation.
        /// </summary>
        /// <param name="array">The current array/list of System.UInt64 integers.</param>
        /// <returns>A byte array converted from the current System.UInt64 array/list.</returns>
        public unsafe static byte[] ToBytes(this IList<UInt64> array)
        {
            var len = array.Count;
            var bytes = new byte[len * sizeof(UInt64)];

            fixed (byte* bytePtr = bytes)
            {
                var intPtr = (UInt64*)bytePtr;
                for (int i = 0; i < len; ++i)
                    intPtr[i] = array[i];
            }
            return bytes;
        }

        /// <summary>
        /// Converts the current array/list of System.UInt64 integers to its equivalent byte array representation.
        /// </summary>
        /// <param name="array">The current array/list of System.UInt64 integers.</param>
        /// <param name="safe">Specifies whether the safe .NET class System.IO.MemoryStream should be used to perform the conversion rather than unsafe pointers.</param>
        /// <returns>A byte array converted from the current System.UInt64 array/list.</returns>
        public static byte[] ToBytes(this IList<UInt64> array, bool safe)
        {
            if (safe)
            {
                var ms = new MemoryStream();
                foreach (var integer in array)
                    ms.WriteUInt64(integer);
                return ms.ToArray();
            }
            else return ToBytes(array);
        }

        /// <summary>
        /// Converts the current array/list of System.Singles to its equivalent byte array representation.
        /// </summary>
        /// <param name="array">The current array/list of System.Singles.</param>
        /// <returns>A byte array converted from the current System.Single array/list.</returns>
        public unsafe static byte[] ToBytes(this IList<Single> array)
        {
            var len = array.Count;
            var bytes = new byte[len * sizeof(Single)];

            fixed (byte* bytePtr = bytes)
            {
                var intPtr = (Single*)bytePtr;
                for (int i = 0; i < len; ++i)
                    intPtr[i] = array[i];
            }
            return bytes;
        }

        /// <summary>
        /// Converts the current array/list of System.Singles to its equivalent byte array representation.
        /// </summary>
        /// <param name="array">The current array/list of System.Singles.</param>
        /// <param name="safe">Specifies whether the safe .NET class System.IO.MemoryStream should be used to perform the conversion rather than unsafe pointers.</param>
        /// <returns>A byte array converted from the current System.Single array/list.</returns>
        public static byte[] ToBytes(this IList<Single> array, bool safe)
        {
            if (safe)
            {
                var ms = new MemoryStream();
                foreach (var value in array)
                    ms.WriteSingle(value);
                return ms.ToArray();
            }
            else return ToBytes(array);
        }

        /// <summary>
        /// Converts the current array/list of System.Doubles to its equivalent byte array representation.
        /// </summary>
        /// <param name="array">The current array/list of System.Doubles.</param>
        /// <returns>A byte array converted from the current System.Double array/list.</returns>
        public unsafe static byte[] ToBytes(this IList<Double> array)
        {
            var len = array.Count;
            var bytes = new byte[len * sizeof(Double)];

            fixed (byte* bytePtr = bytes)
            {
                var intPtr = (Double*)bytePtr;
                for (int i = 0; i < len; ++i)
                    intPtr[i] = array[i];
            }
            return bytes;
        }

        /// <summary>
        /// Converts the current array/list of System.Doubles to its equivalent byte array representation.
        /// </summary>
        /// <param name="array">The current array/list of System.Doubles.</param>
        /// <param name="safe">Specifies whether the safe .NET class System.IO.MemoryStream should be used to perform the conversion rather than unsafe pointers.</param>
        /// <returns>A byte array converted from the current System.Double array/list.</returns>
        public static byte[] ToBytes(this IList<Double> array, bool safe)
        {
            if (safe)
            {
                var ms = new MemoryStream();
                foreach (var value in array)
                    ms.WriteDouble(value);
                return ms.ToArray();
            }
            else return ToBytes(array);
        }

        /// <summary>
        /// Converts the current array/list of System.DateTimes to its equivalent byte array representation.
        /// </summary>
        /// <param name="array">The current array/list of System.DateTimes.</param>
        /// <returns>A byte array converted from the current System.DateTime array/list.</returns>
        public unsafe static byte[] ToBytes(this IList<DateTime> array)
        {
            var len = array.Count;
            var bytes = new byte[len * sizeof(DateTime)];

            fixed (byte* bytePtr = bytes)
            {
                var intPtr = (DateTime*)bytePtr;
                for (int i = 0; i < len; ++i)
                    intPtr[i] = array[i];
            }
            return bytes;
        }

        /// <summary>
        /// Converts the current array/list of System.DateTimes to its equivalent byte array representation.
        /// </summary>
        /// <param name="array">The current array/list of System.DateTimes.</param>
        /// <param name="safe">Specifies whether the safe .NET class System.IO.MemoryStream should be used to perform the conversion rather than unsafe pointers.</param>
        /// <returns>A byte array converted from the current System.DateTime array/list.</returns>
        public static byte[] ToBytes(this IList<DateTime> array, bool safe)
        {
            if (safe)
            {
                var ms = new MemoryStream();
                foreach (var value in array)
                    ms.WriteDateTime(value);
                return ms.ToArray();
            }
            else return ToBytes(array);
        }
    }
}
