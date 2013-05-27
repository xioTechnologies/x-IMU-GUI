using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xIMU_API
{
    /// <summary>
    /// Date/Time data class.
    /// </summary>
    public class DateTimeData : xIMUdata
    {
        #region Variables

        private int privYear;
        private int privMonth;
        private int privDate;
        private int privHours;
        private int privMinutes;
        private int privSeconds;

        #endregion

        #region Properties

        /// <summary>
        /// Year. Must be of value 2000 2099.
        /// </summary>
        /// <exception cref="System.Exception">
        /// Thrown if invalid year specified.
        /// </exception>
        public int Year
        {
            get
            {
                return privYear;
            }
            set
            {
                if ((value < 2000) | (value > 2099))
                {
                    throw new Exception("Year value must 2000 to 2099");
                }
                else privYear = value;
            }
        }

        /// <summary>
        /// Month. Must be of value 1 to 12.
        /// </summary>
        /// <exception cref="System.Exception">
        /// Thrown if invalid month specified.
        /// </exception>
        public int Month
        {
            get
            {
                return privMonth;
            }
            set
            {
                if ((value < 1) | (value > 12))
                {
                    throw new Exception("Month value must 1 to 12");
                }
                else privMonth = value;
            }
        }

        /// <summary>
        /// Date. Must be of value 1 to 31.
        /// </summary>
        /// <exception cref="System.Exception">
        /// Thrown if invalid date specified.
        /// </exception>
        public int Date
        {
            get
            {
                return privDate;
            }
            set
            {
                if ((value < 1) | (value > 31))
                {
                    throw new Exception("Date value must 1 to 31");
                }
                else privDate = value;
            }
        }

        /// <summary>
        /// Hours. Must be of value 0 to 23.
        /// </summary>
        /// <exception cref="System.Exception">
        /// Thrown if invalid hours specified.
        /// </exception>
        public int Hours
        {
            get
            {
                return privHours;
            }
            set
            {
                if ((value < 0) | (value > 23))
                {
                    throw new Exception("Hours value must 00 to 23");
                }
                else privHours = value;
            }
        }

        /// <summary>
        /// Minutes. Must be of value 0 to 59.
        /// </summary>
        /// <exception cref="System.Exception">
        /// Thrown if invalid minutes specified.
        /// </exception>
        public int Minutes
        {
            get
            {
                return privMinutes;
            }
            set
            {
                if ((value < 0) | (value > 59))
                {
                    throw new Exception("Minutes value must 0 to 59");
                }
                else privMinutes = value;
            }
        }

        /// <summary>
        /// Seconds. Must be of value 0 to 59.
        /// </summary>
        /// <exception cref="System.Exception">
        /// Thrown if invalid seconds specified.
        /// </exception>
        public int Seconds
        {
            get
            {
                return privSeconds;
            }
            set
            {
                if ((value < 0) | (value > 59))
                {
                    throw new Exception("Seconds value must 0 to 59");
                }
                else privSeconds = value;
            }
        }

        /// <summary>
        /// <see cref="DateTime"/> object representation of data.
        /// </summary>
        public DateTime DateTimeObject
        {
            get
            {
                return new DateTime(Year, Month, Date, Hours, Minutes, Seconds);
            }
            set
            {
                Year = value.Year;
                Month = value.Month;
                Date = value.Day;
                Hours = value.Hour;
                Minutes = value.Minute;
                Seconds = value.Second;
            }
        }

        #endregion

        #region Constructors

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
        /// Year. Must be of value 2000 2099.
        /// </param>
        /// <param name="month">
        /// Month. Must be of value 1 to 12.
        /// </param>
        /// <param name="date">
        /// Date. Must be of value 1 to 31.
        /// </param>
        /// <param name="hours">
        /// Hours. Must be of value 0 to 23.
        /// </param>
        /// <param name="minutes">
        /// Minutes. Must be of value 0 to 59.
        /// </param>
        /// <param name="seconds">
        /// Seconds. Must be of value 0 to 59.
        /// </param>
        public DateTimeData(int year, int month, int date, int hours, int minutes, int seconds)
        {
            Year = year;
            Month = month;
            Date = date;
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Converts date/time data to string.
        /// </summary>
        /// <returns>
        /// Date/time data as string.
        /// </returns>
        public string ConvertToString()
        {
            return String.Format("{0:F}", DateTimeObject);
        }

        #endregion
    }
}
