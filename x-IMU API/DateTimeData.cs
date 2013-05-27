using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace x_IMU_API
{
    /// <summary>
    /// Date/Time data class.
    /// </summary>
    public class DateTimeData : xIMUdata
    {
        /// <summary>
        /// Private year value.
        /// </summary>
        private int year;

        /// <summary>
        /// Private month value.
        /// </summary>
        private int month;

        /// <summary>
        /// Private day value.
        /// </summary>
        private int day;

        /// <summary>
        /// Private hours value.
        /// </summary>
        private int hours;

        /// <summary>
        /// Private minutes value.
        /// </summary>
        private int minutes;

        /// <summary>
        /// Private seconds value.
        /// </summary>
        private int seconds;

        /// <summary>
        /// Gets or sets the year. Value must be from 2000 2099.
        /// </summary>
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                if ((value < 2000) | (value > 2099))
                {
                    throw new Exception("Year value must 2000 to 2099");
                }
                year = value;
            }
        }

        /// <summary>
        /// Gets or sets the month. Value must be from 1 to 12.
        /// </summary>
        public int Month
        {
            get
            {
                return month;
            }
            set
            {
                if ((value < 1) | (value > 12))
                {
                    throw new Exception("Month value must 1 to 12");
                }
                month = value;
            }
        }

        /// <summary>
        /// Gets or sets the day. Value must be from 1 to 31.
        /// </summary>
        public int Day
        {
            get
            {
                return day;
            }
            set
            {
                if ((value < 1) | (value > 31))
                {
                    throw new Exception("Date value must 1 to 31");
                }
                day = value;
            }
        }

        /// <summary>
        /// Gets or sets the hours. Value must be from 0 to 23.
        /// </summary>
        public int Hours
        {
            get
            {
                return hours;
            }
            set
            {
                if ((value < 0) | (value > 23))
                {
                    throw new Exception("Hours value must 00 to 23");
                }
                hours = value;
            }
        }

        /// <summary>
        /// Gets or sets the minutes. Value must be from 0 to 59.
        /// </summary>
        public int Minutes
        {
            get
            {
                return minutes;
            }
            set
            {
                if ((value < 0) | (value > 59))
                {
                    throw new Exception("Minutes value must 0 to 59");
                }
                minutes = value;
            }
        }

        /// <summary>
        /// Gets or sets the seconds. Value must be from 0 to 59.
        /// </summary>
        public int Seconds
        {
            get
            {
                return seconds;
            }
            set
            {
                if ((value < 0) | (value > 59))
                {
                    throw new Exception("Seconds value must 0 to 59");
                }
                seconds = value;
            }
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="DateTimeData"/> class.
        /// </summary>
        public DateTimeData()
            : this(2000, 1, 1, 0, 0, 0)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="DateTimeData"/> class.
        /// </summary>
        /// <param name="dateTime">
        /// <see cref="DateTime"/> object.
        /// </param>
        public DateTimeData(DateTime dateTime)
            : this(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="DateTimeData"/> class.
        /// </summary>
        /// <param name="year">
        /// Year. Value must be from 2000 2099.
        /// </param>
        /// <param name="month">
        /// Month. Value must be from 1 to 12.
        /// </param>
        /// <param name="day">
        /// Date. Value must be from 1 to 31.
        /// </param>
        /// <param name="hours">
        /// Hours. Value must be from 0 to 23.
        /// </param>
        /// <param name="minutes">
        /// Minutes. Value must be from 0 to 59.
        /// </param>
        /// <param name="seconds">
        /// Seconds. Value must be from 0 to 59.
        /// </param>
        public DateTimeData(int year, int month, int day, int hours, int minutes, int seconds)
        {
            Year = year;
            Month = month;
            Day = day;
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        /// <summary>
        /// Converts values to <see cref="DateTime"/> object.
        /// </summary>
        /// <returns>
        /// <see cref="DateTime"/>  object.
        /// </returns>
        public DateTime ConvertToDateTime()
        {
            return new DateTime(Year, Month, Day, Hours, Minutes, Seconds);
        }

        /// <summary>
        /// Set values from DateTime object.
        /// </summary>
        /// <param name="dateTime">
        /// <see cref="DateTime"/> object.
        /// </param>
        public void SetFromDateTime(DateTime dateTime)
        {
            Year = dateTime.Year;
            Month = dateTime.Month;
            Day = dateTime.Day;
            Hours = dateTime.Hour;
            Minutes = dateTime.Minute;
            Seconds = dateTime.Second;
        }

        /// <summary>
        /// Converts data to string of Comma Separated Variables.
        /// </summary>
        /// <returns>
        /// CSV text line.
        /// </returns>
        public string ConvertToCSVstring()
        {
            return Year.ToString() + "," + Month.ToString() + "," + Day.ToString() + "," + Hours.ToString() + "," + Minutes.ToString() + "," + Seconds.ToString();
        }
    }
}