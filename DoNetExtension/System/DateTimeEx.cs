namespace System
{
    public static class DateTimeEx
    {
        /// <summary>
        /// Converts the value of the current <see cref="DateTime"/> object to its equivalent HTTP-formated string representation.
        /// </summary>
        /// <param name="dateTime">This <see cref="System.DateTime"/> object to convert.</param>
        /// <returns>A string representing date and time, usually used as HTTP headers.</returns>
        public static string ToHttpHeaderString(this DateTime dateTime)
        {
            return dateTime.ToUniversalTime().ToString("r");
        }

        /// <summary>
        /// Converts the current <see cref="System.DateTime"/> object to its equivalent unix time stamp as a <see cref="long"/>. A single unit in this timestamp represents 1 second.
        /// </summary>
        /// <param name="dateTime">This <see cref="System.DateTime"/> object to convert.</param>
        /// <returns>A unix time stamp represented by a <see cref="long"/> indicating seconds passed since Jan 01 1970 00:00:00.</returns>
        public static long ToUnixTimeStamp(this DateTime dateTime)
        {
            return (long)(dateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
        }

        /// <summary>
        /// Converts the current <see cref="System.DateTime"/> object to its equivalent unix time stamp a a <see cref="long"/>. A single unit in this timestamp represents 1 millisecond.
        /// </summary>
        /// <param name="dateTime">This <see cref="System.DateTime"/> object to convert.</param>
        /// <returns>A unix time stamp represented by a <see cref="long"/> indicating seconds passed since Jan 01 1970 00:00:00.</returns>
        public static long ToUnixTimeStampMilliseconds(this DateTime dateTime)
        {
            return (long)(dateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds;
        }

        /// <summary>
        /// Converts the current <see cref="System.DateTime"/> object to its equivalent unix time stamp represented by a <see cref="double"/>. The milliseconds are represented by the decimal part of this <see cref="double"/>.
        /// </summary>
        /// <param name="dateTime">This <see cref="System.DateTime"/> object to convert.</param>
        /// <returns>The unix time stamp represented by a <see cref="double"/> indicating seconds passed since Jan 01 1970 00:00:00.</returns>
        public static double ToUnixTimeStampDouble(this DateTime dateTime)
        {
            return (dateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
        }

        /// <summary>
        /// Converts the current <see cref="System.DateTime"/> object to its equivalent unix time stamp a a <see cref="double"/>. A single unit in this timestamp represents 1 millisecond.
        /// </summary>
        /// <param name="dateTime">This <see cref="System.DateTime"/> object to convert.</param>
        /// <returns>A unix time stamp represented by a <see cref="long"/> indicating seconds passed since Jan 01 1970 00:00:00.</returns>
        public static double ToUnixTimeStampMillisecondsDouble(this DateTime dateTime)
        {
            return (dateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds;
        }

        /// <summary>
        /// Gets the next sharp clock from time represented by the current System.DateTime object.
        /// </summary>
        /// <param name="dateTime">This System.DateTime object.</param>
        /// <returns>The next sharp clock represented by a <see cref="System.DateTime"/> object.</returns>
        public static DateTime NextSharp(this DateTime dateTime)
        {
            var now = DateTime.Now;
            if (now.Hour == 23) return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddDays(1);
            else return new DateTime(now.Year, now.Month, now.Day, now.Hour + 1, 0, 0);
        }

        /// <summary>
        /// Gets the sharp clock from time represented by the current System.DateTime object.
        /// </summary>
        /// <param name="dateTime">This System.DateTime object.</param>
        /// <returns>The sharp clock represented by a <see cref="System.DateTime"/> object.</returns>
        public static DateTime Sharp(this DateTime dateTime)
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                DateTime.Now.Hour, 0, 0);
        }

        /// <summary>
        /// Evenly divides a timespan into several time points between the beginning time point and the end time point. 
        /// </summary>
        /// <param name="source">This System.DateTime as the beginning time point.</param>
        /// <param name="destination">A System.DateTime as the end time point.</param>
        /// <param name="splitCount">Indicates how many time points between the beginning time point and the end time point are returned.</param>
        /// <returns>Time points between the beginning time point and the end time point the evenly divide the timespan.</returns>
        public static DateTime[] Divide(this DateTime source, DateTime destination, int splitCount)
        {
            if (splitCount == 1) return new DateTime[] { source, destination };

            var splits = new DateTime[splitCount + 1];
            splits[0] = source; splits[splitCount] = destination;
            var step = (destination - source).TotalMilliseconds / splitCount;
            for (int i = 1; i < splitCount; i++)
                splits[i] = splits[i - 1].AddMilliseconds(step);
            return splits;
        }

        /// <summary>
        /// Determines whether the time represented by the current System.DateTime object is a future time.
        /// </summary>
        /// <param name="datetime">This System.DateTime object.</param>
        /// <returns>true if the time represented by the current System.DateTime object is a future time; otherwise, false.</returns>
        public static bool IsFuture(this DateTime datetime)
        {
            return datetime > DateTime.Now;
        }

        /// <summary>
        /// Determines whether the time represented by the current System.DateTime object is a past time.
        /// </summary>
        /// <param name="datetime">This System.DateTime object.</param>
        /// <returns>true if the time represented by the current System.DateTime object is a past time; otherwise, false.</returns>
        public static bool IsPast(this DateTime datetime)
        {
            return datetime < DateTime.Now;
        }

        /// <summary>
        /// Gets the passed seconds from the time represented by this System.DateTime object till now.
        /// <para>NOTE that if this System.DateTime object represents a future time, 
        /// the returned value will be negative, indicating seconds to go.</para>
        /// </summary>
        /// <param name="datetime">This System.DateTime object.</param>
        /// <returns>The passed seconds from the time represented by this System.DateTime object till now.</returns>
        public static double SecondsPassed(this DateTime datetime)
        {
            return (DateTime.Now - datetime).TotalSeconds;
        }

        /// <summary>
        /// Gets the passed ticks from the time represented by this System.DateTime object till now.
        /// <para>NOTE that if this System.DateTime object represents a future time, 
        /// the returned value will be negative, indicating ticks to go.</para>
        /// </summary>
        /// <param name="datetime">This System.DateTime object.</param>
        /// <returns>The passed ticks from the time represented by this System.DateTime object till now.</returns>
        public static long TicksPassed(this DateTime datetime)
        {
            return (DateTime.Now - datetime).Ticks;
        }

        /// <summary>
        /// Gets the passed miliseconds from the time represented by this System.DateTime object till now.
        /// <para>NOTE that if this System.DateTime object represents a future time, 
        /// the returned value will be negative, indicating seconds to go.</para>
        /// </summary>
        /// <param name="datetime">This System.DateTime object.</param>
        /// <returns>The passed miliseconds from the time represented by this System.DateTime object till now.</returns>
        public static double MiliSecondsPassed(this DateTime datetime)
        {
            return (DateTime.Now - datetime).TotalMilliseconds;
        }

        /// <summary>
        /// Gets the passed minutes from the time represented by this System.DateTime object till now.
        /// <para>NOTE that if this System.DateTime object represents a future time, 
        /// the returned value will be negative, indicating minutes to go.</para>
        /// </summary>
        /// <param name="datetime">This System.DateTime object.</param>
        /// <returns>The passed minutes from the time represented by this System.DateTime object till now.</returns>
        public static double MinutesPassed(this DateTime datetime)
        {
            return (DateTime.Now - datetime).TotalMinutes;
        }

        /// <summary>
        /// Gets the passed hours from the time represented by this System.DateTime object till now.
        /// <para>NOTE that if this System.DateTime object represents a future time, 
        /// the returned value will be negative, indicating hours to go.</para>
        /// </summary>
        /// <param name="datetime">This System.DateTime object.</param>
        /// <returns>The passed hours from the time represented by this System.DateTime object till now.</returns>
        public static double HoursPassed(this DateTime datetime)
        {
            return (DateTime.Now - datetime).TotalHours;
        }

        /// <summary>
        /// Gets the passed days from the time represented by this System.DateTime object till now.
        /// <para>NOTE that if this System.DateTime object represents a future time, 
        /// the returned value will be negative, indicating hours to go.</para>
        /// </summary>
        /// <param name="datetime">This System.DateTime object.</param>
        /// <returns>The passed days from the time represented by this System.DateTime object till now.</returns>
        public static double DaysPassed(this DateTime datetime)
        {
            return (DateTime.Now - datetime).TotalDays;
        }

        /// <summary>
        /// Gets the timespan from the time represented by this System.DateTime object till now.
        /// <para>NOTE that if this System.DateTime object represents a future time, 
        /// the returned value is a timespan to go.</para>
        /// </summary>
        /// <param name="datetime">This System.DateTime object.</param>
        /// <returns>The timespan from the time represented by this System.DateTime object till now.</returns>
        public static TimeSpan TimeSpanPassed(this DateTime datetime)
        {
            return (DateTime.Now - datetime);
        }

        /// <summary>
        /// Gets the seconds to go from now to the time this System.DateTime represents.
        /// <para>NOTE that if this System.DateTime object represents a past time, 
        /// the returned value will be negative, indicating seconds passed.</para>
        /// </summary>
        /// <param name="datetime">This System.DateTime object.</param>
        /// <returns>The seconds to go from now to the time this System.DateTime represents.</returns>
        public static double SecondsToGo(this DateTime datetime)
        {
            return (datetime - DateTime.Now).TotalSeconds;
        }

        /// <summary>
        /// Gets the miliseconds to go from now to the time this System.DateTime represents.
        /// <para>NOTE that if this System.DateTime object represents a past time, 
        /// the returned value will be negative, indicating seconds passed.</para>
        /// </summary>
        /// <param name="datetime">This System.DateTime object.</param>
        /// <returns>The miliseconds to go from now to the time this System.DateTime represents.</returns>
        public static double MilisecondsToGo(this DateTime datetime)
        {
            return (datetime - DateTime.Now).TotalMilliseconds;
        }

        /// <summary>
        /// Gets the ticks to go from now to the time this System.DateTime represents.
        /// <para>NOTE that if this System.DateTime object represents a past time, 
        /// the returned value will be negative, indicating ticks passed.</para>
        /// </summary>
        /// <param name="datetime">This System.DateTime object.</param>
        /// <returns>The ticks to go from now to the time this System.DateTime represents.</returns>
        public static long TicksToGo(this DateTime datetime)
        {
            return (datetime - DateTime.Now).Ticks;
        }

        /// <summary>
        /// Gets the minutes to go from now to the time this System.DateTime represents.
        /// <para>NOTE that if this System.DateTime object represents a past time, 
        /// the returned value will be negative, indicating minutes passed.</para>
        /// </summary>
        /// <param name="datetime">This System.DateTime object.</param>
        /// <returns>The minutes to go from now to the time this System.DateTime represents.</returns>
        public static double MinutesToGo(this DateTime datetime)
        {
            return (datetime - DateTime.Now).TotalMinutes;
        }

        /// <summary>
        /// Gets the hours to go from now to the time this System.DateTime represents.
        /// <para>NOTE that if this System.DateTime object represents a past time, 
        /// the returned value will be negative, indicating hours passed.</para>
        /// </summary>
        /// <param name="datetime">This System.DateTime object.</param>
        /// <returns>The hours to go from now to the time this System.DateTime represents.</returns>
        public static double HoursToGo(this DateTime datetime)
        {
            return (datetime - DateTime.Now).TotalHours;
        }

        /// <summary>
        /// Gets the days to go from now to the time this System.DateTime represents.
        /// <para>NOTE that if this System.DateTime object represents a past time, 
        /// the returned value will be negative, indicating days passed.</para>
        /// </summary>
        /// <param name="datetime">This System.DateTime object.</param>
        /// <returns>The days to go from now to the time this System.DateTime represents.</returns>
        public static double DaysToGo(this DateTime datetime)
        {
            return (datetime - DateTime.Now).TotalDays;
        }

        /// <summary>
        /// Gets the timespan to go from now to the time this System.DateTime represents.
        /// <para>NOTE that if this System.DateTime object represents a past time, 
        /// the returned value will be negative, indicating timespan passed.</para>
        /// </summary>
        /// <param name="datetime">This System.DateTime object.</param>
        /// <returns>The timespan to go from now to the time this System.DateTime represents.</returns>
        public static TimeSpan TimeSpanToGo(this DateTime datetime)
        {
            return (datetime - DateTime.Now);
        }
    }
}
