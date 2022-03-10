/* ========================================================================
 * JCommon : a free general purpose class library for the Java(tm) platform
 * ========================================================================
 *
 * (C) Copyright 2000-2006, by Object Refinery Limited and Contributors.
 * 
 * Project Info:  http://www.jfree.org/jcommon/index.html
 *
 * This library is free software; you can redistribute it and/or modify it 
 * under the terms of the GNU Lesser General Public License as published by 
 * the Free Software Foundation; either version 2.1 of the License, or 
 * (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful, but 
 * WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY 
 * or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public 
 * License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, 
 * USA.  
 *
 * [Java is a trademark or registered trademark of Sun Microsystems, Inc. 
 * in the United States and other countries.]
 *
 * --------------------
 * SpreadsheetDate.java
 * --------------------
 * (C) Copyright 2000-2006, by Object Refinery Limited and Contributors.
 *
 * Original Author:  David Gilbert (for Object Refinery Limited);
 * Contributor(s):   -;
 *
 * $Id: SpreadsheetDate.java,v 1.10 2006/08/29 13:59:30 mungady Exp $
 *
 * Changes
 * -------
 * 11-Oct-2001 : Version 1 (DG);
 * 05-Nov-2001 : Added getDescription() and setDescription() methods (DG);
 * 12-Nov-2001 : Changed name from ExcelDate.java to SpreadsheetDate.java (DG);
 *               Fixed a bug in calculating day, month and year from serial 
 *               number (DG);
 * 24-Jan-2002 : Fixed a bug in calculating the serial number from the day, 
 *               month and year.  Thanks to Trevor Hills for the report (DG);
 * 29-May-2002 : Added equals(Object) method (SourceForge ID 558850) (DG);
 * 03-Oct-2002 : Fixed errors reported by Checkstyle (DG);
 * 13-Mar-2003 : Implemented Serializable (DG);
 * 04-Sep-2003 : Completed isInRange() methods (DG);
 * 05-Sep-2003 : Implemented Comparable (DG);
 * 21-Oct-2003 : Added hashCode() method (DG);
 * 29-Aug-2006 : Removed redundant description attribute (DG);
 *
 */
using Chapter16_04.Enums;
using System;

namespace Chapter16_04
{
    public class SpreadsheetDate : DayDate
    {
        public const int EARLIEST_DATE_ORDINAL = 2;
        public const int LATEST_DATE_ORDINAL = 2958465;
        public const int MINIMUM_YEAR_SUPPORTED = 1900;
        public const int MAXIMUM_YEAR_SUPPORTED = 9999;

        /** 
         * The day number (1-Jan-1900 = 2, 2-Jan-1900 = 3, ..., 31-Dec-9999 = 
         * 2958465). 
         */
        private int serial;

        /** The day of the month (1 to 28, 29, 30 or 31 depending on the month). */
        private int day;

        /** The month of the year (1 to 12). */
        private Month month;

        /** The year (1900 to 9999). */
        private int year;

        /**
         * Creates a new date instance.
         *
         * @param day  the day (in the range 1 to 28/29/30/31).
         * @param month  the month (in the range 1 to 12).
         * @param year  the year (in the range 1900 to 9999).
         */
        public SpreadsheetDate(int day, Month month, int year)
        {
            if ((year >= 1900) && (year <= 9999))
            {
                this.year = year;
            }
            else
            {
                throw new ArgumentException("The 'year' argument must be in range 1900 to 9999.");
            }

            if ((month >= Month.JANUARY)
                    && (month <= Month.DECEMBER))
            {
                this.month = month;
            }
            else
            {
                throw new ArgumentException("The 'month' argument must be in the range 1 to 12.");
            }

            if ((day >= 1) && (day <= DayDate.LastDayOfMonth(month, year)))
            {
                this.day = day;
            }
            else
            {
                throw new ArgumentException("Invalid 'day' argument.");
            }

            // the serial number needs to be synchronised with the day-month-year...
            this.serial = CalcSerial(day, month, year);
        }

        /**
         * Standard constructor - creates a new date object representing the
         * specified day number (which should be in the range 2 to 2958465.
         *
         * @param serial  the serial number for the day (range: 2 to 2958465).
         */
        public SpreadsheetDate(int serial)
        {
            if ((serial >= EARLIEST_DATE_ORDINAL) && (serial <= LATEST_DATE_ORDINAL))
            {
                this.serial = serial;
            }
            else
            {
                throw new ArgumentException("SpreadsheetDate: Serial must be in range 2 to 2958465.");
            }

            // the day-month-year needs to be synchronised with the serial number...
            // get the year from the serial date
            int days = this.serial - EARLIEST_DATE_ORDINAL;
            // overestimated because we ignored leap days
            int overestimatedYYYY = 1900 + (days / 365);
            int leaps = DayDate.LeapYearCount(overestimatedYYYY);
            int nonleapdays = days - leaps;
            // underestimated because we overestimated years
            int underestimatedYYYY = 1900 + (nonleapdays / 365);

            if (underestimatedYYYY == overestimatedYYYY)
            {
                this.year = underestimatedYYYY;
            }
            else
            {
                int ss1 = CalcSerial(1, Month.JANUARY, underestimatedYYYY);
                while (ss1 <= this.serial)
                {
                    underestimatedYYYY = underestimatedYYYY + 1;
                    ss1 = CalcSerial(1, Month.JANUARY, underestimatedYYYY);
                }
                this.year = underestimatedYYYY - 1;
            }

            int ss2 = CalcSerial(1, Month.JANUARY, this.year);

            int[] daysToEndOfPrecedingMonth = AGGREGATE_DAYS_TO_END_OF_PRECEDING_MONTH;

            if (IsLeapYear(this.year))
            {
                daysToEndOfPrecedingMonth = LEAP_YEAR_AGGREGATE_DAYS_TO_END_OF_PRECEDING_MONTH;
            }

            // get the month from the serial date
            int mm = 1;
            int sss = ss2 + daysToEndOfPrecedingMonth[mm] - 1;
            while (sss < this.serial)
            {
                mm = mm + 1;
                sss = ss2 + daysToEndOfPrecedingMonth[mm] - 1;
            }
            this.month = MonthExtensions.Make(mm - 1);

            // what's left is d(+1);
            this.day = this.serial - ss2 - daysToEndOfPrecedingMonth[(int)this.month] + 1;
        }

        /**
         * Returns the serial number for the date, where 1 January 1900 = 2
         * (this corresponds, almost, to the numbering system used in Microsoft
         * Excel for Windows and Lotus 1-2-3).
         *
         * @return The serial number of this date.
         */
        public override int ToSerial()
        {
            return this.serial;
        }

        /**
         * Returns a <code>java.util.Date</code> equivalent to this date.
         *
         * @return The date.
         */
        public override DateTime ToDate()
        {
            /*Calendar calendar = Calendar.getInstance();
            calendar.set(GetYYYY(), GetMonth() - 1, GetDayOfMonth(), 0, 0, 0);
            return calendar.getTime();*/

            DateTime calendar = new DateTime(GetYYYY(), (int)GetMonth() - 1, GetDayOfMonth());
            return calendar;
        }

        /**
         * Returns the year (assume a valid range of 1900 to 9999).
         *
         * @return The year.
         */
        public override int GetYYYY()
        {
            return this.year;
        }

        /**
         * Returns the month (January = 1, February = 2, March = 3).
         *
         * @return The month of the year.
         */
        public override Month GetMonth()
        {
            return this.month;
        }

        /**
         * Returns the day of the month.
         *
         * @return The day of the month.
         */
        public override int GetDayOfMonth()
        {
            return this.day;
        }

        /**
         * Returns a code representing the day of the week.
         * <P>
         * The codes are defined in the {@link DayDate} class as: 
         * <code>SUNDAY</code>, <code>MONDAY</code>, <code>TUESDAY</code>, 
         * <code>WEDNESDAY</code>, <code>THURSDAY</code>, <code>FRIDAY</code>, and 
         * <code>SATURDAY</code>.
         *
         * @return A code representing the day of the week.
         */
        public override int GetDayOfWeek()
        {
            return (this.serial + 6) % 7 + 1;
        }

        /**
         * Tests the equality of this date with an arbitrary object.
         * <P>
         * This method will return true ONLY if the object is an instance of the
         * {@link DayDate} base class, and it represents the same day as this
         * {@link SpreadsheetDate}.
         *
         * @param object  the object to compare (<code>null</code> permitted).
         *
         * @return A boolean.
         */
        public override bool Equals(Object o)
        {
            if (o is DayDate)
            {
                DayDate s = (DayDate)o;
                return (s.ToSerial() == this.ToSerial());
            }
            else
            {
                return false;
            }
        }

        /**
         * Returns a hash code for this object instance.
         * 
         * @return A hash code.
         */
        public int HashCode()
        {
            return ToSerial();
        }

        /**
         * Returns the difference (in days) between this date and the specified 
         * 'other' date.
         *
         * @param other  the date being compared to.
         *
         * @return The difference (in days) between this date and the specified 
         *         'other' date.
         */
        public override int Compare(DayDate other)
        {
            return this.serial - other.ToSerial();
        }

        /**
         * Implements the method required by the Comparable interface.
         * 
         * @param other  the other object (usually another DayDate).
         * 
         * @return A negative integer, zero, or a positive integer as this object 
         *         is less than, equal to, or greater than the specified object.
         */
        public int CompareTo(Object o)
        {
            return Compare((DayDate)o);
        }

        /**
         * Returns true if this DayDate represents the same date as the
         * specified DayDate.
         *
         * @param other  the date being compared to.
         *
         * @return <code>true</code> if this DayDate represents the same date as
         *         the specified DayDate.
         */
        public override bool IsOn(DayDate other)
        {
            return (this.serial == other.ToSerial());
        }

        /**
         * Returns true if this DayDate represents an earlier date compared to
         * the specified DayDate.
         *
         * @param other  the date being compared to.
         *
         * @return <code>true</code> if this DayDate represents an earlier date
         *         compared to the specified DayDate.
         */
        public override bool IsBefore(DayDate other)
        {
            return (this.serial < other.ToSerial());
        }

        /**
         * Returns true if this DayDate represents the same date as the
         * specified DayDate.
         *
         * @param other  the date being compared to.
         *
         * @return <code>true</code> if this DayDate represents the same date
         *         as the specified DayDate.
         */
        public override bool IsOnOrBefore(DayDate other)
        {
            return (this.serial <= other.ToSerial());
        }

        /**
         * Returns true if this DayDate represents the same date as the
         * specified DayDate.
         *
         * @param other  the date being compared to.
         *
         * @return <code>true</code> if this DayDate represents the same date
         *         as the specified DayDate.
         */
        public override bool IsAfter(DayDate other)
        {
            return (this.serial > other.ToSerial());
        }

        /**
         * Returns true if this DayDate represents the same date as the
         * specified DayDate.
         *
         * @param other  the date being compared to.
         *
         * @return <code>true</code> if this DayDate represents the same date as
         *         the specified DayDate.
         */
        public override bool IsOnOrAfter(DayDate other)
        {
            return (this.serial >= other.ToSerial());
        }

        /**
         * Returns <code>true</code> if this {@link DayDate} is within the 
         * specified range (INCLUSIVE).  The date order of d1 and d2 is not 
         * important.
         *
         * @param d1  a boundary date for the range.
         * @param d2  the other boundary date for the range.
         *
         * @return A boolean.
         */
        public override bool IsInRange(DayDate d1, DayDate d2)
        {
            return IsInRange(d1, d2, DayDate.INCLUDE_BOTH);
        }

        /**
         * Returns true if this DayDate is within the specified range (caller
         * specifies whether or not the end-points are included).  The order of d1
         * and d2 is not important.
         *
         * @param d1  one boundary date for the range.
         * @param d2  a second boundary date for the range.
         * @param include  a code that controls whether or not the start and end 
         *                 dates are included in the range.
         *
         * @return <code>true</code> if this DayDate is within the specified 
         *         range.
         */
        public override bool IsInRange(DayDate d1, DayDate d2, int include)
        {
            int s1 = d1.ToSerial();
            int s2 = d2.ToSerial();
            int start = Math.Min(s1, s2);
            int end = Math.Max(s1, s2);
            int s = ToSerial();

            if (include == DayDate.INCLUDE_BOTH)
            {
                return (s >= start && s <= end);
            }
            else if (include == DayDate.INCLUDE_FIRST)
            {
                return (s >= start && s < end);
            }
            else if (include == DayDate.INCLUDE_SECOND)
            {
                return (s > start && s <= end);
            }
            else
            {
                return (s > start && s < end);
            }
        }

        /**
         * Calculate the serial number from the day, month and year.
         * <P>
         * 1-Jan-1900 = 2.
         *
         * @param d  the day.
         * @param m  the month.
         * @param y  the year.
         *
         * @return the serial number from the day, month and year.
         */
        private int CalcSerial(int d, Month m, int y)
        {
            int yy = ((y - 1900) * 365) + DayDate.LeapYearCount(y - 1);
            int mm = DayDate.AGGREGATE_DAYS_TO_END_OF_PRECEDING_MONTH[(int)m];
            if (m > Month.FEBRUARY)
            {
                if (DayDate.IsLeapYear(y))
                {
                    mm = mm + 1;
                }
            }
            int dd = d;
            return yy + mm + dd + 1;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
