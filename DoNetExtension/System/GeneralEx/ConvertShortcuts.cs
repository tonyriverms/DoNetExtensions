using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_Extension_Library.System.GeneralEx;

namespace System
{
    public static partial class GeneralEx
    {
        #region Data Conversion

        /// <summary>
        /// Converts the value of this value to a System.Char value.
        /// </summary>
        /// <param name="value">This value.</param>
        /// <returns>A <see cref="System.Char"/> value that is equivalent to <paramref name="value"/>.</returns>
        public static Char ToChar<T>(this T value) where T : struct
        {
            return Convert.ToChar(value);
        }

        /// <summary>
        /// Converts the string instance to a <see cref="System.Char"/> value if it represents such a value in a recognizable format.
        /// </summary>
        /// <param name="str">The string instance.</param>
        /// <returns>An <see cref="System.Char"/> value that is equivalent to the string instance.</returns>
        public static Char ToChar(this string str)
        {
            try
            {
                return Convert.ToChar(str);
            }
            catch (FormatException formatEx)
            {
                throw new FormatException(GeneralExResources.ERR_ConvertShortcuts_ParsingError.Scan(str, "System.Char"), formatEx);
            }
        }

        /// <summary>
        /// Converts the value of this value to a <see cref="System.Boolean"/> value.
        /// </summary>
        /// <param name="value">This value.</param>
        /// <returns>A <see cref="System.Boolean"/> value that is equivalent to <paramref name="value"/>.</returns>
        public static Boolean ToBoolean<T>(this T value) where T : struct
        {
            return Convert.ToBoolean(value);
        }

        /// <summary>
        /// Converts the string instance to a <see cref="System.Boolean"/> value if it represents such a value in a recognizable format.
        /// </summary>
        /// <param name="str">The string instance.</param>
        /// <returns>An <see cref="System.Boolean"/> value that is equivalent to the string instance.</returns>
        public static bool ToBoolean(this string str)
        {
            str = str.Trim().ToUpperInvariant();
            switch (str)
            {
                case "TRUE":
                case "T":
                case "YES":
                case "1":
                case "ON":
                    return true;
                case "FALSE":
                case "F":
                case "NO":
                case "0":
                case "OFF":
                    return false;
                default:
                    throw new FormatException(GeneralExResources.ERR_ConvertShortcuts_ParsingError.Scan(str, "System.Boolean"));
            }
        }

        public static bool? TryBoolean(this string str)
        {
            str = str.Trim().ToUpperInvariant();
            switch (str)
            {
                case "TRUE":
                case "T":
                case "YES":
                case "1":
                case "ON":
                    return true;
                case "FALSE":
                case "F":
                case "NO":
                case "0":
                case "OFF":
                    return false;
                default:
                    return null;
            }
        }

        /// <summary>
        /// Converts the <paramref name="value"/> to a <see cref="System.DateTime"/>.
        /// </summary>
        /// <param name="value">This value.</param>
        /// <returns>A <see cref="System.DateTime"/> equivalent to <paramref name="value"/>.</returns>
        public static DateTime ToDateTime<T>(this T value) where T : struct
        {
            return Convert.ToDateTime(value);
        }

        /// <summary>
        /// Converts the first 8 bytes (defined by <c>sizeof(DateTime)</c>) of this byte array <paramref name="bytes"/> to a <see cref="DateTime"/>. 
        /// </summary>
        /// <param name="bytes">This bytes array.</param>
        /// <returns>A <see cref="DateTime"/> equivalent to the current byte array.</returns>
        public unsafe static DateTime ToDateTime(this byte[] bytes)
        {
            var dt = new DateTime();
            var dtref = (byte*)&dt;
            for (int i = 0; i < sizeof(DateTime); ++i)
            {
                *dtref = bytes[i];
                ++dtref;
            }
            return dt;
        }

        /// <summary>
        /// Converts the string instance to a <see cref="System.DateTime"/> value if it represents such a value in a recognizable format.
        /// </summary>
        /// <param name="str">The string instance.</param>
        /// <returns>An <see cref="System.DateTime"/> value that is equivalent to the string instance.</returns>
        public static DateTime ToDateTime(this string str)
        {
            try
            {
                if (str.Equals("max", StringComparison.OrdinalIgnoreCase) || str.Equals("maximum", StringComparison.OrdinalIgnoreCase))
                    return DateTime.MaxValue;
                else if (str.Equals("min", StringComparison.OrdinalIgnoreCase) || str.Equals("minimum", StringComparison.OrdinalIgnoreCase))
                    return DateTime.MinValue;
                else return Convert.ToDateTime(str);
            }
            catch (FormatException formatEx)
            {
                throw new FormatException(GeneralExResources.ERR_ConvertShortcuts_ParsingError.Scan(str, "System.DateTime"), formatEx);
            }
        }

        /// <summary>
        /// Converts the value of this value to a 8-bit signed integer.
        /// </summary>
        /// <param name="value">This value.</param>
        /// <returns>An 8-bit signed integer that is equivalent to <paramref name="value"/>.</returns>
        public static SByte ToSByte<T>(this T value) where T : struct
        {
            return Convert.ToSByte(value);
        }

        /// <summary>
        /// Converts the string instance to a 8-bit unsigned integer if it represents such an integer in a recognizable format.
        /// </summary>
        /// <param name="str">The string instance.</param>
        /// <returns>An 8-bit unsigned integer that is equivalent to the string instance.</returns>
        public static SByte ToSByte(this string str)
        {
            try
            {
                if (str.Equals("max", StringComparison.OrdinalIgnoreCase) || str.Equals("maximum", StringComparison.OrdinalIgnoreCase))
                    return SByte.MaxValue;
                else if (str.Equals("min", StringComparison.OrdinalIgnoreCase) || str.Equals("minimum", StringComparison.OrdinalIgnoreCase))
                    return SByte.MinValue;
                else return Convert.ToSByte(str);
            }
            catch (FormatException formatEx)
            {
                throw new FormatException(GeneralExResources.ERR_ConvertShortcuts_ParsingError.Scan(str, "System.SByte"), formatEx);
            }
        }

        /// <summary>
        /// Converts the value of this value to a 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">This value.</param>
        /// <returns>An 8-bit unsigned integer that is equivalent to <paramref name="value"/>.</returns>
        public static Byte ToByte<T>(this T value) where T : struct
        {
            return Convert.ToByte(value);
        }

        /// <summary>
        /// Converts the string instance to a 8-bit signed integer if it represents such an integer in a recognizable format.
        /// </summary>
        /// <param name="str">The string instance.</param>
        /// <returns>An 8-bit signed integer that is equivalent to the string instance.</returns>
        public static Byte ToByte(this string str)
        {
            try
            {
                if (str.Equals("max", StringComparison.OrdinalIgnoreCase) || str.Equals("maximum", StringComparison.OrdinalIgnoreCase))
                    return Byte.MaxValue;
                else if (str.Equals("min", StringComparison.OrdinalIgnoreCase) || str.Equals("minimum", StringComparison.OrdinalIgnoreCase))
                    return Byte.MinValue;
                else return Convert.ToByte(str);
            }
            catch (FormatException formatEx)
            {
                throw new FormatException(GeneralExResources.ERR_ConvertShortcuts_ParsingError.Scan(str, "System.Byte"), formatEx);
            }
        }

        /// <summary>
        /// Converts the value of this value to a 16-bit signed integer.
        /// </summary>
        /// <param name="value">This value.</param>
        /// <returns>A 16-bit signed integer that is equivalent to <paramref name="value"/>.</returns>
        public static Int16 ToInt16<T>(this T value) where T : struct
        {
            return Convert.ToInt16(value);
        }

        /// <summary>
        /// Converts the string instance to a 16-bit signed integer if it represents such an integer in a recognizable format.
        /// </summary>
        /// <param name="str">The string instance.</param>
        /// <returns>A 16-bit signed integer that is equivalent to the string instance.</returns>
        public static Int16 ToInt16(this string str)
        {
            try
            {
                if (str.Equals("max", StringComparison.OrdinalIgnoreCase) || str.Equals("maximum", StringComparison.OrdinalIgnoreCase))
                    return Int16.MaxValue;
                else if (str.Equals("min", StringComparison.OrdinalIgnoreCase) || str.Equals("minimum", StringComparison.OrdinalIgnoreCase))
                    return Int16.MinValue;
                else return Convert.ToInt16(str);
            }
            catch (FormatException formatEx)
            {
                throw new FormatException(GeneralExResources.ERR_ConvertShortcuts_ParsingError.Scan(str, "System.Int16"), formatEx);
            }
        }

        /// <summary>
        /// Converts the value of this value to a 16-bit signed integer.
        /// </summary>
        /// <param name="value">This value.</param>
        /// <returns>A 16-bit signed integer that is equivalent to <paramref name="value"/>.</returns>
        public static UInt16 ToUInt16<T>(this T value) where T : struct
        {
            return Convert.ToUInt16(value);
        }

        /// <summary>
        /// Converts the string instance to a 16-bit unsigned integer if it represents such an integer in a recognizable format.
        /// </summary>
        /// <param name="str">The string instance.</param>
        /// <returns>A 16-bit unsigned integer that is equivalent to the string instance.</returns>
        public static UInt16 ToUInt16(this string str)
        {
            try
            {
                if (str.Equals("max", StringComparison.OrdinalIgnoreCase) || str.Equals("maximum", StringComparison.OrdinalIgnoreCase))
                    return UInt16.MaxValue;
                else if (str.Equals("min", StringComparison.OrdinalIgnoreCase) || str.Equals("minimum", StringComparison.OrdinalIgnoreCase))
                    return UInt16.MinValue;
                else return Convert.ToUInt16(str);
            }
            catch (FormatException formatEx)
            {
                throw new FormatException(GeneralExResources.ERR_ConvertShortcuts_ParsingError.Scan(str, "System.UInt16"), formatEx);
            }
        }

        /// <summary>
        /// Converts the current object to a 32-bit signed integer.
        /// </summary>
        /// <param name="value">This value.</param>
        /// <returns>A 32-bit signed integer that is equivalent to <paramref name="value"/>.</returns>
        public static int ToInt32<T>(this T value)
        {
            return Convert.ToInt32(value);
        }

        /// <summary>
        /// Converts the current object to a 32-bit signed integer if it is not <c>null</c>; otherwise, returns a <c>null</c> reference.
        /// </summary>
        /// <param name="value">This value.</param>
        /// <returns>A 32-bit signed integer that is equivalent to <paramref name="value"/> if it is not <c>null</c>; otherwise, <c>null</c>.</returns>
        public static int? ToInt32OrNull<T>(this T value)
        {
            return value as int?;
        }

        /// <summary>
        /// Converts the string instance to a 32-bit signed integer if it represents such an integer in a recognizable format.
        /// </summary>
        /// <param name="str">The string instance.</param>
        /// <returns>A 32-bit signed integer that is equivalent to the string instance.</returns>
        public static Int32 ToInt32(this string str)
        {
            try
            {
                if (str.Equals("max", StringComparison.OrdinalIgnoreCase) || str.Equals("maximum", StringComparison.OrdinalIgnoreCase))
                    return Int32.MaxValue;
                else if (str.Equals("min", StringComparison.OrdinalIgnoreCase) || str.Equals("minimum", StringComparison.OrdinalIgnoreCase))
                    return Int32.MinValue;
                else return Convert.ToInt32(str);
            }
            catch (FormatException formatEx)
            {
                throw new FormatException(GeneralExResources.ERR_ConvertShortcuts_ParsingError.Scan(str, "System.Int32"), formatEx);
            }
        }

        /// <summary>
        /// Converts the value of this value to a 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">This value.</param>
        /// <returns>A 32-bit unsigned integer that is equivalent to <paramref name="value"/>.</returns>
        public static UInt32 ToUInt32<T>(this T value) where T : struct
        {
            return Convert.ToUInt32(value);
        }

        /// <summary>
        /// Converts the string instance to a 32-bit unsigned integer if it represents such an integer in a recognizable format.
        /// </summary>
        /// <param name="str">The string instance.</param>
        /// <returns>A 32-bit signed uninteger that is equivalent to the string instance.</returns>
        public static UInt32 ToUInt32(this string str)
        {
            try
            {
                if (str.Equals("max", StringComparison.OrdinalIgnoreCase) || str.Equals("maximum", StringComparison.OrdinalIgnoreCase))
                    return UInt32.MaxValue;
                else if (str.Equals("min", StringComparison.OrdinalIgnoreCase) || str.Equals("minimum", StringComparison.OrdinalIgnoreCase))
                    return UInt32.MinValue;
                else return Convert.ToUInt32(str);
            }
            catch (FormatException formatEx)
            {
                throw new FormatException(GeneralExResources.ERR_ConvertShortcuts_ParsingError.Scan(str, "System.UInt32"), formatEx);
            }
        }

        /// <summary>
        /// Converts the value of this value to a 64-bit signed integer.
        /// </summary>
        /// <param name="value">This value.</param>
        /// <returns>A 64-bit signed integer that is equivalent to <paramref name="value"/>.</returns>
        public static Int64 ToInt64<T>(this T value) where T : struct
        {
            return Convert.ToInt64(value);
        }

        /// <summary>
        /// Converts the string instance to a 64-bit signed integer if it represents such an integer in a recognizable format.
        /// </summary>
        /// <param name="str">The string instance.</param>
        /// <returns>A 64-bit signed integer that is equivalent to the string instance.</returns>
        public static Int64 ToInt64(this string str)
        {
            try
            {
                if (str.Equals("max", StringComparison.OrdinalIgnoreCase) || str.Equals("maximum", StringComparison.OrdinalIgnoreCase))
                    return Int64.MaxValue;
                else if (str.Equals("min", StringComparison.OrdinalIgnoreCase) || str.Equals("minimum", StringComparison.OrdinalIgnoreCase))
                    return Int64.MinValue;
                else return Convert.ToInt64(str);
            }
            catch (FormatException formatEx)
            {
                throw new FormatException(GeneralExResources.ERR_ConvertShortcuts_ParsingError.Scan(str, "System.Int64"), formatEx);
            }
        }

        /// <summary>
        /// Converts the value of this value to a 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">This value.</param>
        /// <returns>A 64-bit unsigned integer that is equivalent to <paramref name="value"/>.</returns>
        public static UInt64 ToUInt64<T>(this T value) where T : struct
        {
            return Convert.ToUInt64(value);
        }

        /// <summary>
        /// Converts the string instance to a 64-bit unsigned integer if it represents such an integer in a recognizable format.
        /// </summary>
        /// <param name="str">The string instance.</param>
        /// <returns>A 64-bit signed uninteger that is equivalent to the string instance.</returns>
        public static UInt64 ToUInt64(this string str)
        {
            try
            {
                if (str.Equals("max", StringComparison.OrdinalIgnoreCase) || str.Equals("maximum", StringComparison.OrdinalIgnoreCase))
                    return UInt64.MaxValue;
                else if (str.Equals("min", StringComparison.OrdinalIgnoreCase) || str.Equals("minimum", StringComparison.OrdinalIgnoreCase))
                    return UInt64.MinValue;
                else return Convert.ToUInt64(str);
            }
            catch (FormatException formatEx)
            {
                throw new FormatException(GeneralExResources.ERR_ConvertShortcuts_ParsingError.Scan(str, "System.UInt64"), formatEx);
            }
        }

        /// <summary>
        /// Converts the value of this value to a double-precision floating-point number.
        /// </summary>
        /// <param name="value">This value.</param>
        /// <returns>A double-precision floating-point number that is equivalent to <paramref name="value"/>.</returns>
        public static Double ToDouble<T>(this T value) where T : struct
        {
            return Convert.ToDouble(value);
        }

        /// <summary>
        /// Converts the string instance to a double-precision floating-point number if it represents such a number in a recognizable format.
        /// </summary>
        /// <param name="str">The string instance.</param>
        /// <returns>A double-precision floating-point number that is equivalent to the string instance.</returns>
        public static Double ToDouble(this string str)
        {
            try
            {
                if (str.Equals("max", StringComparison.OrdinalIgnoreCase) || str.Equals("maximum", StringComparison.OrdinalIgnoreCase))
                    return Double.MaxValue;
                else if (str.Equals("min", StringComparison.OrdinalIgnoreCase) || str.Equals("minimum", StringComparison.OrdinalIgnoreCase))
                    return Double.MinValue;
                else return Convert.ToDouble(str);
            }
            catch (FormatException formatEx)
            {
                throw new FormatException(GeneralExResources.ERR_ConvertShortcuts_ParsingError.Scan(str, "System.Double"), formatEx);
            }
        }

        /// <summary>
        /// Converts the value of this value to a single-precision floating-point number.
        /// </summary>
        /// <param name="value">This value.</param>
        /// <returns>A single-precision floating-point number that is equivalent to <paramref name="value"/>.</returns>
        public static Single ToSingle<T>(this T value) where T : struct
        {
            return Convert.ToSingle(value);
        }

        /// <summary>
        /// Converts the string instance to a single-precision floating-point number if it represents such a number in a recognizable format.
        /// </summary>
        /// <param name="str">The string instance.</param>
        /// <returns>A single-precision floating-point number that is equivalent to the string instance.</returns>
        public static Single ToSingle(this string str)
        {
            try
            {
                if (str.Equals("max", StringComparison.OrdinalIgnoreCase) || str.Equals("maximum", StringComparison.OrdinalIgnoreCase))
                    return Single.MaxValue;
                else if (str.Equals("min", StringComparison.OrdinalIgnoreCase) || str.Equals("minimum", StringComparison.OrdinalIgnoreCase))
                    return Single.MinValue;
                else return Convert.ToSingle(str);
            }
            catch (FormatException formatEx)
            {
                throw new FormatException(GeneralExResources.ERR_ConvertShortcuts_ParsingError.Scan(str, "System.Single"), formatEx);
            }
        }

        #endregion
    }
}
