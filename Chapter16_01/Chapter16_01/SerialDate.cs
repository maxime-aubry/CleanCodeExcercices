﻿using System;

namespace Chapter16_01
{
    [Serializable]
    public abstract class SerialDate : MonthConstants
    {
        /** For serialization. */
        //private static long serialVersionUID = -293716040467423637L;

        /** Date format symbols. */
        public static DateFormatSymbols DATE_FORMAT_SYMBOLS = new DateFormatSymbols();

        /** The serial number for 1 January 1900. */
        public static int SERIAL_LOWER_BOUND = 2;

        /** The serial number for 31 December 9999. */
        public static int SERIAL_UPPER_BOUND = 2958465;

        /** The lowest year value supported by this date format. */
        public static int MINIMUM_YEAR_SUPPORTED = 1900;

        /** The highest year value supported by this date format. */
        public static int MAXIMUM_YEAR_SUPPORTED = 9999;

        /** Useful constant for Monday. Equivalent to java.util.Calendar.MONDAY. */
        public static int MONDAY = Calendar.MONDAY;

        /** 
         * Useful constant for Tuesday. Equivalent to java.util.Calendar.TUESDAY. 
         */
        public static int TUESDAY = Calendar.TUESDAY;

        /** 
         * Useful constant for Wednesday. Equivalent to 
         * java.util.Calendar.WEDNESDAY. 
         */
        public static int WEDNESDAY = Calendar.WEDNESDAY;

        /** 
         * Useful constant for Thrusday. Equivalent to java.util.Calendar.THURSDAY. 
         */
        public static int THURSDAY = Calendar.THURSDAY;

        /** Useful constant for Friday. Equivalent to java.util.Calendar.FRIDAY. */
        public static int FRIDAY = Calendar.FRIDAY;

        /** 
         * Useful constant for Saturday. Equivalent to java.util.Calendar.SATURDAY.
         */
        public static int SATURDAY = Calendar.SATURDAY;

        /** Useful constant for Sunday. Equivalent to java.util.Calendar.SUNDAY. */
        public static int SUNDAY = Calendar.SUNDAY;

        /** The number of days in each month in non leap years. */
        public static int[] LAST_DAY_OF_MONTH = {0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

        /** The number of days in a (non-leap) year up to the end of each month. */
        public static int[] AGGREGATE_DAYS_TO_END_OF_MONTH = {0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365};

        /** The number of days in a year up to the end of the preceding month. */
        public static int[] AGGREGATE_DAYS_TO_END_OF_PRECEDING_MONTH = {0, 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365};

        /** The number of days in a leap year up to the end of each month. */
        public static int[] LEAP_YEAR_AGGREGATE_DAYS_TO_END_OF_MONTH = {0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335, 366};

        /** 
         * The number of days in a leap year up to the end of the preceding month. 
         */
        public static int[] LEAP_YEAR_AGGREGATE_DAYS_TO_END_OF_PRECEDING_MONTH = {0, 0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335, 366};

        /** A useful constant for referring to the first week in a month. */
        public const int FIRST_WEEK_IN_MONTH = 1;

        /** A useful constant for referring to the second week in a month. */
        public const int SECOND_WEEK_IN_MONTH = 2;

        /** A useful constant for referring to the third week in a month. */
        public const int THIRD_WEEK_IN_MONTH = 3;

        /** A useful constant for referring to the fourth week in a month. */
        public const int FOURTH_WEEK_IN_MONTH = 4;

        /** A useful constant for referring to the last week in a month. */
        public const int LAST_WEEK_IN_MONTH = 0;

        /** Useful range constant. */
        public static int INCLUDE_NONE = 0;

        /** Useful range constant. */
        public static int INCLUDE_FIRST = 1;

        /** Useful range constant. */
        public static int INCLUDE_SECOND = 2;

        /** Useful range constant. */
        public static int INCLUDE_BOTH = 3;

        /** 
         * Useful constant for specifying a day of the week relative to a fixed 
         * date. 
         */
        public const int PRECEDING = -1;

        /** 
         * Useful constant for specifying a day of the week relative to a fixed 
         * date. 
         */
        public const int NEAREST = 0;

        /** 
         * Useful constant for specifying a day of the week relative to a fixed 
         * date. 
         */
        public const int FOLLOWING = 1;

        /** A description for the date. */
        private string description;

        /**
         * Default constructor.
         */
        protected SerialDate()
        {
        }

        /**
         * Returns <code>true</code> if the supplied integer code represents a 
         * valid day-of-the-week, and <code>false</code> otherwise.
         *
         * @param code  the code being checked for validity.
         *
         * @return <code>true</code> if the supplied integer code represents a 
         *         valid day-of-the-week, and <code>false</code> otherwise.
         */
        public static bool IsValidWeekdayCode(int code)
        {
            switch (code)
            {
                case Calendar.SUNDAY:
                case Calendar.MONDAY:
                case Calendar.TUESDAY:
                case Calendar.WEDNESDAY:
                case Calendar.THURSDAY:
                case Calendar.FRIDAY:
                case Calendar.SATURDAY:
                    return true;
                default:
                    return false;
            }
        }

        /**
         * Converts the supplied string to a day of the week.
         *
         * @param s  a string representing the day of the week.
         *
         * @return <code>-1</code> if the string is not convertable, the day of 
         *         the week otherwise.
         */
        public static int StringToWeekdayCode(string s)
        {

            string[] shortWeekdayNames = DATE_FORMAT_SYMBOLS.getShortWeekdays();
            string[] weekDayNames = DATE_FORMAT_SYMBOLS.getWeekdays();

            int result = -1;
            s = s.Trim();
            for (int i = 0; i < weekDayNames.Length; i++)
            {
                if (s.Equals(shortWeekdayNames[i]))
                {
                    result = i + 1;
                    break;
                }
                if (s.Equals(weekDayNames[i]))
                {
                    result = i + 1;
                    break;
                }
            }
            return result;
        }

        /**
         * Returns a string representing the supplied day-of-the-week.
         * <P>
         * Need to find a better approach.
         *
         * @param weekday  the day of the week.
         *
         * @return a string representing the supplied day-of-the-week.
         */
        public static string WeekdayCodeToString(int weekday)
        {
            string[] weekdays = DATE_FORMAT_SYMBOLS.getWeekdays();
            return weekdays[weekday - 1];
        }

        /**
         * Returns an array of month names.
         *
         * @return an array of month names.
         */
        public static string[] GetMonths()
        {
            return GetMonths(false);
        }

        /**
         * Returns an array of month names.
         *
         * @param shortened  a flag indicating that shortened month names should 
         *                   be returned.
         *
         * @return an array of month names.
         */
        public static string[] GetMonths(bool shortened)
        {

            if (shortened)
            {
                return DATE_FORMAT_SYMBOLS.getShortMonths();
            }
            else
            {
                return DATE_FORMAT_SYMBOLS.getMonths();
            }
        }

        /**
         * Returns true if the supplied integer code represents a valid month.
         *
         * @param code  the code being checked for validity.
         *
         * @return <code>true</code> if the supplied integer code represents a 
         *         valid month.
         */
        public static bool IsValidMonthCode(int code)
        {
            switch (code)
            {
                case JANUARY:
                case FEBRUARY:
                case MARCH:
                case APRIL:
                case MAY:
                case JUNE:
                case JULY:
                case AUGUST:
                case SEPTEMBER:
                case OCTOBER:
                case NOVEMBER:
                case DECEMBER:
                    return true;
                default:
                    return false;
            }
        }

        /**
         * Returns the quarter for the specified month.
         *
         * @param code  the month code (1-12).
         *
         * @return the quarter that the month belongs to.
         */
        public static int MonthCodeToQuarter(int code)
        {
            switch (code)
            {
                case JANUARY:
                case FEBRUARY:
                case MARCH:
                    return 1;
                case APRIL:
                case MAY:
                case JUNE:
                    return 2;
                case JULY:
                case AUGUST:
                case SEPTEMBER:
                    return 3;
                case OCTOBER:
                case NOVEMBER:
                case DECEMBER:
                    return 4;
                default:
                    throw new ArgumentException("SerialDate.monthCodeToQuarter: invalid month code.");
            }
        }

        /**
         * Returns a string representing the supplied month.
         * <P>
         * The string returned is the long form of the month name taken from the 
         * default locale.
         *
         * @param month  the month.
         *
         * @return a string representing the supplied month.
         */
        public static string MonthCodeToString(int month)
        {
            return MonthCodeToString(month, false);
        }

        /**
         * Returns a string representing the supplied month.
         * <P>
         * The string returned is the long or short form of the month name taken 
         * from the default locale.
         *
         * @param month  the month.
         * @param shortened  if <code>true</code> return the abbreviation of the 
         *                   month.
         *
         * @return a string representing the supplied month.
         */
        public static string MonthCodeToString(int month, bool shortened)
        {
            // check arguments...
            if (!IsValidMonthCode(month))
            {
                throw new ArgumentException("SerialDate.monthCodeToString: month outside valid range.");
            }

            string[] months;

            if (shortened)
            {
                months = DATE_FORMAT_SYMBOLS.getShortMonths();
            }
            else
            {
                months = DATE_FORMAT_SYMBOLS.getMonths();
            }

            return months[month - 1];
        }

        /**
         * Converts a string to a month code.
         * <P>
         * This method will return one of the constants JANUARY, FEBRUARY, ..., 
         * DECEMBER that corresponds to the string.  If the string is not 
         * recognised, this method returns -1.
         *
         * @param s  the string to parse.
         *
         * @return <code>-1</code> if the string is not parseable, the month of the
         *         year otherwise.
         */
        public static int StringToMonthCode(string s)
        {
            string[] shortMonthNames = DATE_FORMAT_SYMBOLS.getShortMonths();
            string[] monthNames = DATE_FORMAT_SYMBOLS.getMonths();

            int result = -1;
            s = s.Trim();

            // first try parsing the string as an integer (1-12)...
            try
            {
                result = int.Parse(s);
            }
            catch (FormatException e)
            {
                // suppress
            }

            // now search through the month names...
            if ((result < 1) || (result > 12))
            {
                for (int i = 0; i < monthNames.Length; i++)
                {
                    if (s.Equals(shortMonthNames[i]))
                    {
                        result = i + 1;
                        break;
                    }
                    if (s.Equals(monthNames[i]))
                    {
                        result = i + 1;
                        break;
                    }
                }
            }

            return result;
        }

        /**
         * Returns true if the supplied integer code represents a valid 
         * week-in-the-month, and false otherwise.
         *
         * @param code  the code being checked for validity.
         * @return <code>true</code> if the supplied integer code represents a 
         *         valid week-in-the-month.
         */
        public static bool IsValidWeekInMonthCode(int code)
        {
            switch (code)
            {
                case FIRST_WEEK_IN_MONTH:
                case SECOND_WEEK_IN_MONTH:
                case THIRD_WEEK_IN_MONTH:
                case FOURTH_WEEK_IN_MONTH:
                case LAST_WEEK_IN_MONTH: return true;
                default: return false;
            }
        }

        /**
         * Determines whether or not the specified year is a leap year.
         *
         * @param yyyy  the year (in the range 1900 to 9999).
         *
         * @return <code>true</code> if the specified year is a leap year.
         */
        public static bool IsLeapYear(int yyyy)
        {
            if ((yyyy % 4) != 0)
            {
                return false;
            }
            else if ((yyyy % 400) == 0)
            {
                return true;
            }
            else if ((yyyy % 100) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /**
         * Returns the number of leap years from 1900 to the specified year 
         * INCLUSIVE.
         * <P>
         * Note that 1900 is not a leap year.
         *
         * @param yyyy  the year (in the range 1900 to 9999).
         *
         * @return the number of leap years from 1900 to the specified year.
         */
        public static int LeapYearCount(int yyyy)
        {
            int leap4 = (yyyy - 1896) / 4;
            int leap100 = (yyyy - 1800) / 100;
            int leap400 = (yyyy - 1600) / 400;
            return leap4 - leap100 + leap400;
        }

        /**
         * Returns the number of the last day of the month, taking into account 
         * leap years.
         *
         * @param month  the month.
         * @param yyyy  the year (in the range 1900 to 9999).
         *
         * @return the number of the last day of the month.
         */
        public static int LastDayOfMonth(int month, int yyyy)
        {
            int result = LAST_DAY_OF_MONTH[month];
            if (month != FEBRUARY)
            {
                return result;
            }
            else if (IsLeapYear(yyyy))
            {
                return result + 1;
            }
            else
            {
                return result;
            }
        }

        /**
         * Creates a new date by adding the specified number of days to the base 
         * date.
         *
         * @param days  the number of days to add (can be negative).
         * @param base  the base date.
         *
         * @return a new date.
         */
        public static SerialDate AddDays(int days, SerialDate baseDate)
        {
            int serialDayNumber = baseDate.ToSerial() + days;
            return SerialDate.CreateInstance(serialDayNumber);
        }

        /**
         * Creates a new date by adding the specified number of months to the base 
         * date.
         * <P>
         * If the base date is close to the end of the month, the day on the result
         * may be adjusted slightly:  31 May + 1 month = 30 June.
         *
         * @param months  the number of months to add (can be negative).
         * @param base  the base date.
         *
         * @return a new date.
         */
        public static SerialDate AddMonths(int months, SerialDate baseDate)
        {
            int yy = (12 * baseDate.GetYYYY() + baseDate.GetMonth() + months - 1) / 12;
            int mm = (12 * baseDate.GetYYYY() + baseDate.GetMonth() + months - 1) % 12 + 1;
            int dd = Math.Min(
                baseDate.GetDayOfMonth(), SerialDate.LastDayOfMonth(mm, yy)
            );
            return SerialDate.CreateInstance(dd, mm, yy);
        }

        /**
         * Creates a new date by adding the specified number of years to the base 
         * date.
         *
         * @param years  the number of years to add (can be negative).
         * @param base  the base date.
         *
         * @return A new date.
         */
        public static SerialDate AddYears(int years, SerialDate baseDate)
        {
            int baseY = baseDate.GetYYYY();
            int baseM = baseDate.GetMonth();
            int baseD = baseDate.GetDayOfMonth();

            int targetY = baseY + years;
            int targetD = Math.Min(
                baseD, SerialDate.LastDayOfMonth(baseM, targetY)
            );

            return SerialDate.CreateInstance(targetD, baseM, targetY);
        }

        /**
         * Returns the latest date that falls on the specified day-of-the-week and 
         * is BEFORE the base date.
         *
         * @param targetWeekday  a code for the target day-of-the-week.
         * @param base  the base date.
         *
         * @return the latest date that falls on the specified day-of-the-week and 
         *         is BEFORE the base date.
         */
        public static SerialDate GetPreviousDayOfWeek(int targetWeekday, SerialDate baseDate)
        {
            // check arguments...
            if (!SerialDate.IsValidWeekdayCode(targetWeekday))
            {
                throw new ArgumentException("Invalid day-of-the-week code.");
            }

            // find the date...
            int adjust;
            int baseDOW = baseDate.GetDayOfWeek();
            if (baseDOW > targetWeekday)
            {
                adjust = Math.Min(0, targetWeekday - baseDOW);
            }
            else
            {
                adjust = -7 + Math.Max(0, targetWeekday - baseDOW);
            }

            return SerialDate.AddDays(adjust, baseDate);
        }

        /**
         * Returns the earliest date that falls on the specified day-of-the-week
         * and is AFTER the base date.
         *
         * @param targetWeekday  a code for the target day-of-the-week.
         * @param base  the base date.
         *
         * @return the earliest date that falls on the specified day-of-the-week 
         *         and is AFTER the base date.
         */
        public static SerialDate GetFollowingDayOfWeek(int targetWeekday, SerialDate baseDate)
        {
            // check arguments...
            if (!SerialDate.IsValidWeekdayCode(targetWeekday))
            {
                throw new ArgumentException("Invalid day-of-the-week code.");
            }

            // find the date...
            int adjust;
            int baseDOW = baseDate.GetDayOfWeek();
            if (baseDOW > targetWeekday)
            {
                adjust = 7 + Math.Min(0, targetWeekday - baseDOW);
            }
            else
            {
                adjust = Math.Max(0, targetWeekday - baseDOW);
            }

            return SerialDate.AddDays(adjust, baseDate);
        }

        /**
         * Returns the date that falls on the specified day-of-the-week and is
         * CLOSEST to the base date.
         *
         * @param targetDOW  a code for the target day-of-the-week.
         * @param base  the base date.
         *
         * @return the date that falls on the specified day-of-the-week and is 
         *         CLOSEST to the base date.
         */
        public static SerialDate GetNearestDayOfWeek(int targetDOW, SerialDate baseDate)
        {

            // check arguments...
            if (!SerialDate.IsValidWeekdayCode(targetDOW))
            {
                throw new ArgumentException("Invalid day-of-the-week code.");
            }

            // find the date...
            int baseDOW = baseDate.GetDayOfWeek();
            int adjust = -Math.Abs(targetDOW - baseDOW);
            if (adjust >= 4)
            {
                adjust = 7 - adjust;
            }
            if (adjust <= -4)
            {
                adjust = 7 + adjust;
            }
            return SerialDate.AddDays(adjust, baseDate);
        }

        /**
         * Rolls the date forward to the last day of the month.
         *
         * @param base  the base date.
         *
         * @return a new serial date.
         */
        public SerialDate GetEndOfCurrentMonth(SerialDate baseDate)
        {
            int last = SerialDate.LastDayOfMonth(baseDate.GetMonth(), baseDate.GetYYYY());
            return SerialDate.CreateInstance(last, baseDate.GetMonth(), baseDate.GetYYYY());
        }

        /**
         * Returns a string corresponding to the week-in-the-month code.
         * <P>
         * Need to find a better approach.
         *
         * @param count  an integer code representing the week-in-the-month.
         *
         * @return a string corresponding to the week-in-the-month code.
         */
        public static string WeekInMonthToString(int count)
        {
            switch (count)
            {
                case SerialDate.FIRST_WEEK_IN_MONTH: return "First";
                case SerialDate.SECOND_WEEK_IN_MONTH: return "Second";
                case SerialDate.THIRD_WEEK_IN_MONTH: return "Third";
                case SerialDate.FOURTH_WEEK_IN_MONTH: return "Fourth";
                case SerialDate.LAST_WEEK_IN_MONTH: return "Last";
                default:
                    return "SerialDate.weekInMonthToString(): invalid code.";
            }
        }

        /**
         * Returns a string representing the supplied 'relative'.
         * <P>
         * Need to find a better approach.
         *
         * @param relative  a constant representing the 'relative'.
         *
         * @return a string representing the supplied 'relative'.
         */
        public static String RelativeToString(int relative)
        {
            switch (relative)
            {
                case SerialDate.PRECEDING: return "Preceding";
                case SerialDate.NEAREST: return "Nearest";
                case SerialDate.FOLLOWING: return "Following";
                default: return "ERROR : Relative To String";
            }
        }

        /**
         * Factory method that returns an instance of some concrete subclass of 
         * {@link SerialDate}.
         *
         * @param day  the day (1-31).
         * @param month  the month (1-12).
         * @param yyyy  the year (in the range 1900 to 9999).
         *
         * @return An instance of {@link SerialDate}.
         */
        public static SerialDate CreateInstance(int day, int month, int yyyy)
        {
            return new SpreadsheetDate(day, month, yyyy);
        }

        /**
         * Factory method that returns an instance of some concrete subclass of 
         * {@link SerialDate}.
         *
         * @param serial  the serial number for the day (1 January 1900 = 2).
         *
         * @return a instance of SerialDate.
         */
        public static SerialDate CreateInstance(int serial)
        {
            return new SpreadsheetDate(serial);
        }

        /**
         * Factory method that returns an instance of a subclass of SerialDate.
         *
         * @param date  A Java date object.
         *
         * @return a instance of SerialDate.
         */
        public static SerialDate CreateInstance(DateTime date)
        {
            return new SpreadsheetDate(date.Day, date.Month, date.Year);
        }

        /**
         * Returns the serial number for the date, where 1 January 1900 = 2 (this
         * corresponds, almost, to the numbering system used in Microsoft Excel for
         * Windows and Lotus 1-2-3).
         *
         * @return the serial number for the date.
         */
        public abstract int ToSerial();

        /**
         * Returns a java.util.Date.  Since java.util.Date has more precision than
         * SerialDate, we need to define a convention for the 'time of day'.
         *
         * @return this as <code>java.util.Date</code>.
         */
        public abstract DateTime ToDate();

        /**
         * Returns the description that is attached to the date.  It is not 
         * required that a date have a description, but for some applications it 
         * is useful.
         *
         * @return The description (possibly <code>null</code>).
         */
        public string GetDescription()
        {
            return this.description;
        }

        /**
         * Sets the description for the date.
         *
         * @param description  the description for this date (<code>null</code> 
         *                     permitted).
         */
        public void SetDescription(string description)
        {
            this.description = description;
        }

        /**
         * Converts the date to a string.
         *
         * @return  a string representation of the date.
         */
        public override string ToString()
        {
            return GetDayOfMonth() + "-" + SerialDate.MonthCodeToString(GetMonth()) + "-" + GetYYYY();
        }

        /**
         * Returns the year (assume a valid range of 1900 to 9999).
         *
         * @return the year.
         */
        public abstract int GetYYYY();

        /**
         * Returns the month (January = 1, February = 2, March = 3).
         *
         * @return the month of the year.
         */
        public abstract int GetMonth();

        /**
         * Returns the day of the month.
         *
         * @return the day of the month.
         */
        public abstract int GetDayOfMonth();

        /**
         * Returns the day of the week.
         *
         * @return the day of the week.
         */
        public abstract int GetDayOfWeek();

        /**
         * Returns the difference (in days) between this date and the specified 
         * 'other' date.
         * <P>
         * The result is positive if this date is after the 'other' date and
         * negative if it is before the 'other' date.
         *
         * @param other  the date being compared to.
         *
         * @return the difference between this and the other date.
         */
        public abstract int Compare(SerialDate other);

        /**
         * Returns true if this SerialDate represents the same date as the 
         * specified SerialDate.
         *
         * @param other  the date being compared to.
         *
         * @return <code>true</code> if this SerialDate represents the same date as 
         *         the specified SerialDate.
         */
        public abstract bool IsOn(SerialDate other);

        /**
         * Returns true if this SerialDate represents an earlier date compared to
         * the specified SerialDate.
         *
         * @param other  The date being compared to.
         *
         * @return <code>true</code> if this SerialDate represents an earlier date 
         *         compared to the specified SerialDate.
         */
        public abstract bool IsBefore(SerialDate other);

        /**
         * Returns true if this SerialDate represents the same date as the 
         * specified SerialDate.
         *
         * @param other  the date being compared to.
         *
         * @return <code>true</code> if this SerialDate represents the same date
         *         as the specified SerialDate.
         */
        public abstract bool IsOnOrBefore(SerialDate other);

        /**
         * Returns true if this SerialDate represents the same date as the 
         * specified SerialDate.
         *
         * @param other  the date being compared to.
         *
         * @return <code>true</code> if this SerialDate represents the same date
         *         as the specified SerialDate.
         */
        public abstract bool IsAfter(SerialDate other);

        /**
         * Returns true if this SerialDate represents the same date as the 
         * specified SerialDate.
         *
         * @param other  the date being compared to.
         *
         * @return <code>true</code> if this SerialDate represents the same date
         *         as the specified SerialDate.
         */
        public abstract bool IsOnOrAfter(SerialDate other);

        /**
         * Returns <code>true</code> if this {@link SerialDate} is within the 
         * specified range (INCLUSIVE).  The date order of d1 and d2 is not 
         * important.
         *
         * @param d1  a boundary date for the range.
         * @param d2  the other boundary date for the range.
         *
         * @return A boolean.
         */
        public abstract bool IsInRange(SerialDate d1, SerialDate d2);

        /**
         * Returns <code>true</code> if this {@link SerialDate} is within the 
         * specified range (caller specifies whether or not the end-points are 
         * included).  The date order of d1 and d2 is not important.
         *
         * @param d1  a boundary date for the range.
         * @param d2  the other boundary date for the range.
         * @param include  a code that controls whether or not the start and end 
         *                 dates are included in the range.
         *
         * @return A boolean.
         */
        public abstract bool IsInRange(SerialDate d1, SerialDate d2, int include);

        /**
         * Returns the latest date that falls on the specified day-of-the-week and
         * is BEFORE this date.
         *
         * @param targetDOW  a code for the target day-of-the-week.
         *
         * @return the latest date that falls on the specified day-of-the-week and
         *         is BEFORE this date.
         */
        public SerialDate GetPreviousDayOfWeek(int targetDOW)
        {
            return GetPreviousDayOfWeek(targetDOW, this);
        }

        /**
         * Returns the earliest date that falls on the specified day-of-the-week
         * and is AFTER this date.
         *
         * @param targetDOW  a code for the target day-of-the-week.
         *
         * @return the earliest date that falls on the specified day-of-the-week
         *         and is AFTER this date.
         */
        public SerialDate GetFollowingDayOfWeek(int targetDOW)
        {
            return GetFollowingDayOfWeek(targetDOW, this);
        }

        /**
         * Returns the nearest date that falls on the specified day-of-the-week.
         *
         * @param targetDOW  a code for the target day-of-the-week.
         *
         * @return the nearest date that falls on the specified day-of-the-week.
         */
        public SerialDate GetNearestDayOfWeek(int targetDOW)
        {
            return GetNearestDayOfWeek(targetDOW, this);
        }
    }
}
