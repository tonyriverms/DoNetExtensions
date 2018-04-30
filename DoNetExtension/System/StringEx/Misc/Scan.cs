using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System
{


    public static partial class StringEx
    {
        /// <summary>
        /// Replaces one or more format items with the string representation of a specified object.
        /// <para>This is a dummy of the <c>string.Format</c> method for convenience.</para>
        /// </summary>
        /// <param name="str">This string instance that contains one or more format items.</param>
        /// <param name="arg0">The object to format.</param>
        /// <returns>A copy of the original string in which the format items are replaced by the string representation of <paramref name="arg0"/>.</returns>
        public static string Scan(this string str, object arg0)
        {
            return string.Format(str, arg0);
        }

        /// <summary>
        /// Replaces format items with the string representation of two specified objects.
        /// <para>This is a dummy of the <c>string.Format</c> method for convenience.</para>
        /// </summary>
        /// <param name="str">This string instance that contains one or more format items.</param>
        /// <param name="arg0">The first object to format.</param>
        /// <param name="arg1">The second object to format.</param>
        /// <returns>A copy of the original string in which the format items are replaced by the string representations of <paramref name="arg0"/> and <paramref name="arg1"/>.</returns>
        public static string Scan(this string str, object arg0, object arg1)
        {
            return string.Format(str, arg0, arg1);
        }

        /// <summary>
        /// Replaces format items with the string representation of three specified objects.
        /// <para>This is a dummy of the <c>string.Format</c> method for convenience.</para>
        /// </summary>
        /// <param name="str">This string instance that contains one or more format items.</param>
        /// <param name="arg0">The first object to format.</param>
        /// <param name="arg1">The second object to format.</param>
        /// <param name="arg2">The third object to format.</param>
        /// <returns>A copy of the original string in which the format items are replaced by the string representations of <paramref name="arg0"/>, <paramref name="arg1"/> and <paramref name="arg2"/>.</returns>
        public static string Scan(this string str, object arg0, object arg1, object arg2)
        {
            return string.Format(str, arg0, arg1, arg2);
        }

        /// <summary>
        /// Replaces each format item in this string with the string representation of a corresponding object in a specified array.
        /// <para>This is a dummy of the <c>string.Format</c> method for convenience.</para>
        /// </summary>
        /// <param name="str">This string instance that contains one or more format items.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>A copy of the original string in which the format items are replaced by the string representation of the corresponding objects in <paramref name="args"/>.</returns>
        public static string Scan(this string str, params object[] args)
        {
            return string.Format(str, args);
        }


    }
}
