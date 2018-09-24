using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace System
{
    /// <summary>
    /// Provides extension methods for mathematical calculations.
    /// </summary>
    public static class MathEx
    {


        #region MinMax

        /// <summary>
        /// Returns a value neither larger than <paramref name="maximum" />
        /// nor smaller than <paramref name="minimum" />.
        /// If the current value is neither smaller than <paramref name="minimum" /> nor larger than <paramref name="maximum" />, then the <paramref name="value" /> itself will be returned;
        /// if the current value is larger than <paramref name="maximum" />, then <paramref name="maximum" /> will be returned;
        /// if the current value is smaller than <paramref name="minimum" />, then <paramref name="minimum" /> will be returned.
        /// </summary>
        /// <typeparam name="T">The type of the current value. This type must be a comparable type.</typeparam>
        /// <param name="value">This comparable value.</param>
        /// <param name="minimum">The returned value will not be smaller than this value.</param>
        /// <param name="maximum">The returned value will not be larger than this value.</param>
        /// <returns>
        /// A value bounded between the <paramref name="minimum" /> and the <paramref name="maximum" />.
        /// </returns>
        public static T Bound<T>(this T value, T minimum, T maximum)
            where T : IComparable<T>
        {
            if (value.CompareTo(minimum) < 0) return minimum;
            else if (value.CompareTo(maximum) > 0) return maximum;
            else return value;
        }

        /// <summary>
        /// Returns a value not smaller than <paramref name="minimum" />.
        /// If the current value is not smaller than <paramref name="minimum" />, then the <paramref name="value" /> itself will be returned;
        /// if the current value is smaller than <paramref name="minimum" />, then <paramref name="minimum" /> will be returned.
        /// </summary>
        /// <typeparam name="T">The type of the current value. This type must be a comparable type.</typeparam>
        /// <param name="value">This comparable value.</param>
        /// <param name="minimum">The returned value will not be smaller than this value.</param>
        /// <returns>
        /// A value not smaller than <paramref name="minimum" />.
        /// </returns>
        public static T BoundedBelow<T>(this T value, T minimum) where T : IComparable<T>
        {
            if (value.CompareTo(minimum) < 0) return minimum;
            else return value;
        }

        /// <summary>
        /// Returns a value not larger than <paramref name="maximum" />.
        /// If the current value is not larger than <paramref name="maximum" />, then the <paramref name="value" /> itself will be returned;
        /// if the current value is larger than <paramref name="maximum" />, then <paramref name="maximum" /> will be returned.
        /// </summary>
        /// <typeparam name="T">The type of the current value. This type must be a comparable type.</typeparam>
        /// <param name="value">This comparable value.</param>
        /// <param name="maximum">The returned value will not be larger than this value.</param>
        /// <returns>
        /// A value not larger than <paramref name="maximum" />.
        /// </returns>
        public static T BoundedAbove<T>(this T value, T maximum) where T : IComparable<T>
        {
            if (value.CompareTo(maximum) > 0)
                return maximum;
            else return value;
        }

        #endregion

        #region Absolute Value

        /// <summary>
        /// Returns the absolute value of this System.Int32 integer.
        /// </summary>
        /// <param name="value">This System.Int32 integer.</param>
        /// <returns>The absolute value of this System.Int32 integer.</returns>
        public static int Absolute(this int value)
        {
            return value >= 0 ? value : -value;
        }

        /// <summary>
        /// Returns the absolute value of this System.Int64 integer.
        /// </summary>
        /// <param name="value">This System.Int64 integer.</param>
        /// <returns>The absolute value of this System.Int64 integer.</returns>
        public static long Absolute(this long value)
        {
            return value >= 0 ? value : -value;
        }

        /// <summary>
        /// Returns the absolute value of this System.Double number.
        /// </summary>
        /// <param name="value">This System.Double number.</param>
        /// <returns>The absolute value of this System.Double number.</returns>
        public static double Absolute(this double value)
        {
            return value >= 0 ? value : -value;
        }

        /// <summary>
        /// Returns the absolute value of this System.Single number.
        /// </summary>
        /// <param name="value">This System.Single number.</param>
        /// <returns>The absolute value of this System.Single number.</returns>
        public static float Absolute(this float value)
        {
            return value >= 0 ? value : -value;
        }

        /// <summary>
        /// Returns the absolute value of this System.Decimal number.
        /// </summary>
        /// <param name="value">This System.Decimal number.</param>
        /// <returns>The absolute value of this System.Decimal number.</returns>
        public static decimal Absolute(this decimal value)
        {
            return value >= 0 ? value : -value;
        }

        /// <summary>
        /// Returns the absolute value of this System.SBtye integer.
        /// </summary>
        /// <param name="value">This System.SBtye integer.</param>
        /// <returns>The absolute value of this System.SBtye integer.</returns>
        public static sbyte Absolute(this sbyte value)
        {
            return (sbyte)(value >= 0 ? value : -value);
        }

        #endregion

        #region Round

        /// <summary>
        /// Rounds a double-precision floating-point value to a specified number of fractional digits.
        /// </summary>
        /// <param name="value">A double-precision floating-point value to be rounded.</param>
        /// <param name="digits">The number of fractional digits in the return value.</param>
        /// <returns> The number nearest to <paramref name="value"/> 
        /// that contains a number of fractional digits equal to <paramref name="digits"/>.</returns>
        public static double Round(this double value, int digits)
        {
            return Math.Round(value, digits);
        }

        /// <summary>
        /// Rounds a single-precision floating-point value to a specified number of fractional digits.
        /// </summary>
        /// <param name="value">A single-precision floating-point value to be rounded.</param>
        /// <param name="digits">The number of fractional digits in the return value.</param>
        /// <returns> The number nearest to <paramref name="value"/> 
        /// that contains a number of fractional digits equal to <paramref name="digits"/>.</returns>
        public static float Round(this float value, int digits)
        {
            return Math.Round(value, digits).ToSingle();
        }

        /// <summary>
        /// Rounds a decimal value to a specified number of fractional digits.
        /// </summary>
        /// <param name="value">A decimal number to be rounded.</param>
        /// <param name="decimals">The number of decimal places in the return value.</param>
        /// <returns>The number nearest to <paramref name="value"/> 
        /// that contains a number of fractional digits equal to <paramref name="decimals"/>.</returns>
        public static decimal Round(this decimal value, int decimals)
        {
            return Math.Round(value, decimals);
        }

        /// <summary>
        /// Rounds a double-precision floating-point value to the nearest integral value.
        /// </summary>
        /// <param name="value">A double-precision floating-point value to be rounded.</param>
        /// <returns> The integral value nearest to <paramref name="value"/>.
        /// If the fractional component of a is halfway between
        /// two integers, one of which is even and the other odd, then the even number
        /// is returned.</returns>
        public static double Round(this double value)
        {
            return Math.Round(value);
        }

        /// <summary>
        /// Rounds a double-precision floating-point value to the nearest integer value.
        /// </summary>
        /// <param name="value">A double-precision floating-point value to be rounded.</param>
        /// <returns> The integer value nearest to <paramref name="value"/>.
        /// If the fractional component of a is halfway between
        /// two integers, one of which is even and the other odd, then the even number
        /// is returned.</returns>
        public static int RoundToInt(this double value)
        {
            return (int)Math.Round(value);
        }

        /// <summary>
        /// Rounds a single-precision floating-point value to the nearest integral value.
        /// </summary>
        /// <param name="value">A single-precision floating-point value to be rounded.</param>
        /// <returns> The integral value nearest to <paramref name="value"/>.
        /// If the fractional component of a is halfway between
        /// two integers, one of which is even and the other odd, then the even number
        /// is returned. Note that this method returns a System.Single instead of an
        /// integral type.</returns>
        public static float Round(this float value)
        {
            return (float)Math.Round((double)value);
        }

        /// <summary>
        /// Rounds a decimal value to the nearest integral value.
        /// </summary>
        /// <param name="value">A decimal number to be rounded.</param>
        /// <returns> The integral value nearest to <paramref name="value"/>.
        /// If the fractional component of a is halfway between
        /// two integers, one of which is even and the other odd, then the even number
        /// is returned. Note that this method returns a System.Single instead of an
        /// integral type.</returns>
        public static decimal Round(this decimal value)
        {
            return Math.Round(value);
        }

        /// <summary>
        /// Rounds a double-precision floating-point value to a specified number of fractional digits.
        /// </summary>
        /// <param name="value">A double-precision floating-point value to be rounded.</param>
        /// <param name="digits">The number of fractional digits in the return value.</param>
        /// <param name="mode">Specification for how to round value if it is midway between two other numbers.</param>
        /// <returns> The number nearest to <paramref name="value"/> 
        /// that contains a number of fractional digits equal to <paramref name="digits"/>.</returns>
        public static double Round(this double value, int digits, MidpointRounding mode)
        {
            return Math.Round(value, digits, mode);
        }

        /// <summary>
        /// Rounds a single-precision floating-point value to a specified number of fractional digits.
        /// </summary>
        /// <param name="value">A single-precision floating-point value to be rounded.</param>
        /// <param name="digits">The number of fractional digits in the return value.</param>
        /// <param name="mode">Specification for how to round value if it is midway between two other numbers.</param>
        /// <returns> The number nearest to <paramref name="value"/> 
        /// that contains a number of fractional digits equal to <paramref name="digits"/>.</returns>
        public static float Round(this float value, int digits, MidpointRounding mode)
        {
            return Math.Round(value, digits, mode).ToSingle();
        }

        /// <summary>
        /// Rounds a decimal value to a specified number of fractional digits.
        /// </summary>
        /// <param name="value">A decimal number to be rounded.</param>
        /// <param name="decimals">The number of decimal places in the return value.</param>
        /// <param name="mode">Specification for how to round value if it is midway between two other numbers.</param>
        /// <returns>The number nearest to <paramref name="value"/> 
        /// that contains a number of fractional digits equal to <paramref name="decimals"/>.</returns>
        public static decimal Round(this decimal value, int decimals, MidpointRounding mode)
        {
            return Math.Round(value, decimals, mode);
        }

        #endregion

        #region Power

        /// <summary>
        /// Returns a specified number raised to the specified power.
        /// </summary>
        /// <param name="value">A double-precision floating-point number to be raised to a power.</param>
        /// <param name="power">A double-precision floating-point number that specifies a power.</param>
        /// <returns>The current number raised to the specified <paramref name="power"/>.</returns>
        public static double Pow(this double value, double power)
        {
            return Math.Pow(value, power);
        }

        #endregion

        #region Two-dimensional Points

        /// <summary>
        /// Gets the bound of this array/list of points.
        /// </summary>
        /// <param name="points">An array/list of points represented by System.Drawing.Point objects.</param>
        /// <returns>A System.Drawing.Rectangle as the bound of this array/list of points.</returns>
        public static Rectangle GetBound(this IList<Point> points)
        {
            if (points == null || points.Count == 0) return Rectangle.Empty;

            var pt0 = points[0];
            int left = points[0].X, right = pt0.X, top = pt0.Y, bottom = pt0.Y;
            for (int i = 1; i < points.Count; i++)
            {
                var pt = points[i];
                if (left > pt.X) left = pt.X;
                else if (right < pt.X) right = pt.X;

                if (top > pt.Y) top = pt.Y;
                else if (bottom < pt.Y) bottom = pt.Y;
            }
            return new Rectangle(left, top, right - left + 1, bottom - top + 1);
        }

        /// <summary>
        /// Gets the distance from the current point to the another point.
        /// </summary>
        /// <param name="point">The current point.</param>
        /// <param name="anotherPoint">Another point.</param>
        /// <returns>The distance between the two points.</returns>
        public static double GetDistance(this Point point, Point anotherPoint)
        {
            var hspan = anotherPoint.X - point.X;
            var vspan = point.Y - anotherPoint.Y;
            return Math.Pow((double)hspan * hspan + (double)vspan * vspan, 0.5);
        }

        /// <summary>
        /// Gets the distance from the current point to the another point.
        /// </summary>
        /// <param name="point">The current point.</param>
        /// <param name="anotherPoint">Another point.</param>
        /// <returns>The distance between the two points.</returns>
        public static double GetDistance(this PointF point, PointF anotherPoint)
        {
            var hspan = anotherPoint.X - point.X;
            var vspan = point.Y - anotherPoint.Y;
            return Math.Pow(hspan * hspan + vspan * vspan, 0.5);
        }

        /// <summary>
        /// Gets the sine value from this point to the specified another point.
        /// </summary>
        /// <param name="point">The current point.</param>
        /// <param name="anotherPoint">Another point.</param>
        /// <returns>The sine value from this point to the specified another point.</returns>
        public static double GetSine(this Point point, Point anotherPoint)
        {
            if (point == anotherPoint) return double.NaN;
            var hspan = anotherPoint.X - point.X;
            var vspan = point.Y - anotherPoint.Y;
            var distance = Math.Pow((double)hspan * hspan + (double)vspan * vspan, 0.5);
            return vspan / distance;
        }

        /// <summary>
        /// Gets the cosine value from this point to the specified another point.
        /// </summary>
        /// <param name="point">The current point.</param>
        /// <param name="anotherPoint">Another point.</param>
        /// <returns>The cosine value from this point to the specified another point.</returns>
        public static double GetCosine(this Point point, Point anotherPoint)
        {
            if (point == anotherPoint) return double.NaN;
            var hspan = anotherPoint.X - point.X;
            var vspan = point.Y - anotherPoint.Y;
            var distance = Math.Pow((double)hspan * hspan + (double)vspan * vspan, 0.5);
            return hspan / distance;
        }

        /// <summary>
        /// Gets the tan value from this point to the specified another point.
        /// </summary>
        /// <param name="point">The current point.</param>
        /// <param name="anotherPoint">Another point.</param>
        /// <returns>The tan value from this point to the specified another point.</returns>
        public static double GetTan(this Point point, Point anotherPoint)
        {
            var hspan = anotherPoint.X - point.X;
            var vspan = point.Y - anotherPoint.Y;
            if (hspan == 0)
                return double.NaN;
            else
                return (double)vspan / hspan;
        }

        /// <summary>
        /// Gets the cotan value from this point to the specified another point.
        /// </summary>
        /// <param name="point">The current point.</param>
        /// <param name="anotherPoint">Another point.</param>
        /// <returns>The cotan value from this point to the specified another point.</returns>
        public static double GetCotan(this Point point, Point anotherPoint)
        {
            var hspan = anotherPoint.X - point.X;
            var vspan = point.Y - anotherPoint.Y;
            if (vspan == 0)
                return double.NaN;
            else
                return (double)hspan / vspan;
        }

        /// <summary>
        /// Gets the angle value from this point to the specified another point.
        /// </summary>
        /// <param name="point">The current point.</param>
        /// <param name="anotherPoint">Another point.</param>
        /// <returns>The angle value from this point to the specified another point.</returns>
        public static double GetAngle(this Point point, Point anotherPoint)
        {
            if (point == anotherPoint) return double.NaN;
            var hspan = anotherPoint.X - point.X;
            var vspan = point.Y - anotherPoint.Y;
            var distance = Math.Pow((double)hspan * hspan + (double)vspan * vspan, 0.5);
            var sine = vspan / distance;
            var temp = Math.Asin(sine);
            if (hspan >= 0 && vspan >= 0)
                return temp;
            else if (hspan >= 0 && vspan < 0)
                return Math.PI + Math.PI + temp;
            else
                return Math.PI - temp;
        }

        /// <summary>
        /// Gets the radian value from this point to the specified another point.
        /// </summary>
        /// <param name="point">The current point.</param>
        /// <param name="anotherPoint">Another point.</param>
        /// <returns>The angle value from the current point to the specified another value.</returns>
        public static double GetRadian(this Point point, Point anotherPoint)
        {
            return point.GetAngle(anotherPoint) * Math.PI / 180;
        }

        /// <summary>
        /// Gets the sine value from this point to the specified another point.
        /// </summary>
        /// <param name="point">The current point.</param>
        /// <param name="anotherPoint">Another point.</param>
        /// <returns>The sine value from this point to the specified another point.</returns>
        public static double GetSine(this PointF point, PointF anotherPoint)
        {
            if (point == anotherPoint) return double.NaN;
            var hspan = anotherPoint.X - point.X;
            var vspan = point.Y - anotherPoint.Y;
            var distance = Math.Pow((double)hspan * hspan + (double)vspan * vspan, 0.5);
            return vspan / distance;
        }

        /// <summary>
        /// Gets the cosine value from this point to the specified another point.
        /// </summary>
        /// <param name="point">The current point.</param>
        /// <param name="anotherPoint">Another point.</param>
        /// <returns>The cosine value from this point to the specified another point.</returns>
        public static double GetCosine(this PointF point, PointF anotherPoint)
        {
            if (point == anotherPoint) return double.NaN;
            var hspan = anotherPoint.X - point.X;
            var vspan = point.Y - anotherPoint.Y;
            var distance = Math.Pow((double)hspan * hspan + (double)vspan * vspan, 0.5);
            return hspan / distance;
        }

        /// <summary>
        /// Gets the tan value from this point to the specified another point.
        /// </summary>
        /// <param name="point">The current point.</param>
        /// <param name="anotherPoint">Another point.</param>
        /// <returns>The tan value from this point to the specified another point.</returns>
        public static double GetTan(this PointF point, PointF anotherPoint)
        {
            var hspan = anotherPoint.X - point.X;
            var vspan = point.Y - anotherPoint.Y;
            if (hspan == 0)
                return double.NaN;
            else
                return (double)vspan / hspan;
        }

        /// <summary>
        /// Gets the cotan value from this point to the specified another point.
        /// </summary>
        /// <param name="point">The current point.</param>
        /// <param name="anotherPoint">Another point.</param>
        /// <returns>The cotan value from this point to the specified another point.</returns>
        public static double GetCotan(this PointF point, PointF anotherPoint)
        {
            var hspan = anotherPoint.X - point.X;
            var vspan = point.Y - anotherPoint.Y;
            if (vspan == 0)
                return double.NaN;
            else
                return (double)hspan / vspan;
        }

        /// <summary>
        /// Gets the angle value from this point to the specified another point.
        /// </summary>
        /// <param name="point">The current point.</param>
        /// <param name="anotherPoint">Another point.</param>
        /// <returns>The angle value from this point to the specified another point.</returns>
        public static double GetAngle(this PointF point, PointF anotherPoint)
        {
            if (point == anotherPoint) return double.NaN;
            var hspan = anotherPoint.X - point.X;
            var vspan = point.Y - anotherPoint.Y;
            var distance = Math.Pow((double)hspan * hspan + (double)vspan * vspan, 0.5);
            var sine = vspan / distance;
            var temp = Math.Asin(sine);
            if (hspan >= 0 && vspan >= 0)
                return temp;
            else if (hspan >= 0 && vspan < 0)
                return Math.PI + Math.PI + temp;
            else
                return Math.PI - temp;
        }

        /// <summary>
        /// Gets the radian value from this point to the specified another point.
        /// </summary>
        /// <param name="point">The current point.</param>
        /// <param name="anotherPoint">Another point.</param>
        /// <returns>The angle value from the current point to the specified another value.</returns>
        public static double GetRadian(this PointF point, PointF anotherPoint)
        {
            return point.GetAngle(anotherPoint) * Math.PI / 180;
        }

        #endregion

    }
}
