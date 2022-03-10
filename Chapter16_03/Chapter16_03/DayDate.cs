using Chapter16_03.Enums;
using System;

namespace Chapter16_03
{
    [Serializable]
    public abstract class DayDate
    {
        public static DateFormatSymbols DATE_FORMAT_SYMBOLS = new DateFormatSymbols();
        public static int SERIAL_LOWER_BOUND = 2;
        public static int SERIAL_UPPER_BOUND = 2958465;
        public static int MINIMUM_YEAR_SUPPORTED = 1900;
        public static int MAXIMUM_YEAR_SUPPORTED = 9999;
        public static int MONDAY = Calendar.MONDAY;
        public static int TUESDAY = Calendar.TUESDAY;
        public static int WEDNESDAY = Calendar.WEDNESDAY;
        public static int THURSDAY = Calendar.THURSDAY;
        public static int FRIDAY = Calendar.FRIDAY;
        public static int SATURDAY = Calendar.SATURDAY;
        public static int SUNDAY = Calendar.SUNDAY;
        public static int[] LAST_DAY_OF_MONTH = {0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
        public static int[] AGGREGATE_DAYS_TO_END_OF_MONTH = {0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365};
        public static int[] AGGREGATE_DAYS_TO_END_OF_PRECEDING_MONTH = {0, 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365};
        public static int[] LEAP_YEAR_AGGREGATE_DAYS_TO_END_OF_MONTH = {0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335, 366};
        public static int[] LEAP_YEAR_AGGREGATE_DAYS_TO_END_OF_PRECEDING_MONTH = {0, 0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335, 366};
        public const int FIRST_WEEK_IN_MONTH = 1;
        public const int SECOND_WEEK_IN_MONTH = 2;
        public const int THIRD_WEEK_IN_MONTH = 3;
        public const int FOURTH_WEEK_IN_MONTH = 4;
        public const int LAST_WEEK_IN_MONTH = 0;
        public static int INCLUDE_NONE = 0;
        public static int INCLUDE_FIRST = 1;
        public static int INCLUDE_SECOND = 2;
        public static int INCLUDE_BOTH = 3;
        public const int PRECEDING = -1;
        public const int NEAREST = 0;
        public const int FOLLOWING = 1;
        private string description;

        /**
         * Default constructor.
         */
        protected DayDate()
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
         * Returns the quarter for the specified month.
         *
         * @param code  the month code (1-12).
         *
         * @return the quarter that the month belongs to.
         */
        public static int MonthCodeToQuarter(Month month)
        {
            switch (month)
            {
                case Month.JANUARY:
                case Month.FEBRUARY:
                case Month.MARCH:
                    return 1;
                case Month.APRIL:
                case Month.MAY:
                case Month.JUNE:
                    return 2;
                case Month.JULY:
                case Month.AUGUST:
                case Month.SEPTEMBER:
                    return 3;
                case Month.OCTOBER:
                case Month.NOVEMBER:
                case Month.DECEMBER:
                    return 4;
                default:
                    throw new ArgumentException("DayDate.monthCodeToQuarter: invalid month code.");
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
        public static string MonthCodeToString(Month month)
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
        public static string MonthCodeToString(Month month, bool shortened)
        {
            string[] months;

            if (shortened)
            {
                months = DATE_FORMAT_SYMBOLS.getShortMonths();
            }
            else
            {
                months = DATE_FORMAT_SYMBOLS.getMonths();
            }

            return months[(int)month - 1];
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
        public static Month StringToMonthCode(string s)
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
                result = -1;
                for (int i = 0; i < monthNames.Length; i++)
                {
                    if (s.Equals(shortMonthNames[i], StringComparison.InvariantCultureIgnoreCase))
                    {
                        result = i + 1;
                        break;
                    }
                    if (s.Equals(monthNames[i], StringComparison.InvariantCultureIgnoreCase))
                    {
                        result = i + 1;
                        break;
                    }
                }
            }

            return MonthExtensions.Make(result);
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
        public static int LastDayOfMonth(Month month, int yyyy)
        {
            int result = LAST_DAY_OF_MONTH[(int)month];
            if (month != Month.FEBRUARY)
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
        public static DayDate AddDays(int days, DayDate baseDate)
        {
            int serialDayNumber = baseDate.ToSerial() + days;
            return DayDate.CreateInstance(serialDayNumber);
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
        public static DayDate AddMonths(int months, DayDate baseDate)
        {
            int yy = (12 * baseDate.GetYYYY() + (int)baseDate.GetMonth() + months - 1) / 12;
            int mm = (12 * baseDate.GetYYYY() + (int)baseDate.GetMonth() + months - 1) % 12 + 1;
            int dd = Math.Min(
                baseDate.GetDayOfMonth(), DayDate.LastDayOfMonth(MonthExtensions.Make(mm), yy)
            );
            return DayDate.CreateInstance(dd, MonthExtensions.Make(mm), yy);
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
        public static DayDate AddYears(int years, DayDate baseDate)
        {
            int baseY = baseDate.GetYYYY();
            Month baseM = baseDate.GetMonth();
            int baseD = baseDate.GetDayOfMonth();

            int targetY = baseY + years;
            int targetD = Math.Min(
                baseD, DayDate.LastDayOfMonth(baseM, targetY)
            );

            return DayDate.CreateInstance(targetD, baseM, targetY);
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
        public static DayDate GetPreviousDayOfWeek(int targetWeekday, DayDate baseDate)
        {
            // check arguments...
            if (!DayDate.IsValidWeekdayCode(targetWeekday))
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

            return DayDate.AddDays(adjust, baseDate);
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
        public static DayDate GetFollowingDayOfWeek(int targetWeekday, DayDate baseDate)
        {
            // check arguments...
            if (!DayDate.IsValidWeekdayCode(targetWeekday))
            {
                throw new ArgumentException("Invalid day-of-the-week code.");
            }

            // find the date...
            int adjust;
            int baseDOW = baseDate.GetDayOfWeek();
            if (baseDOW >= targetWeekday)
            {
                adjust = 7 + Math.Min(0, targetWeekday - baseDOW);
            }
            else
            {
                adjust = Math.Max(0, targetWeekday - baseDOW);
            }

            return DayDate.AddDays(adjust, baseDate);
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
        public static DayDate GetNearestDayOfWeek(int targetDOW, DayDate baseDate)
        {
            // check arguments...
            if (!DayDate.IsValidWeekdayCode(targetDOW))
            {
                throw new ArgumentException("Invalid day-of-the-week code.");
            }

            // find the date...
            int delta = targetDOW - baseDate.GetDayOfWeek();
            int positiveDelta = delta + 7;
            int adjust = positiveDelta % 7;
            if (adjust > 3)
                adjust -= 7;
            return DayDate.AddDays(adjust, baseDate);
        }

        /**
         * Rolls the date forward to the last day of the month.
         *
         * @param base  the base date.
         *
         * @return a new serial date.
         */
        public DayDate GetEndOfCurrentMonth(DayDate baseDate)
        {
            int last = DayDate.LastDayOfMonth(baseDate.GetMonth(), baseDate.GetYYYY());
            return DayDate.CreateInstance(last, baseDate.GetMonth(), baseDate.GetYYYY());
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
                case DayDate.FIRST_WEEK_IN_MONTH: return "First";
                case DayDate.SECOND_WEEK_IN_MONTH: return "Second";
                case DayDate.THIRD_WEEK_IN_MONTH: return "Third";
                case DayDate.FOURTH_WEEK_IN_MONTH: return "Fourth";
                case DayDate.LAST_WEEK_IN_MONTH: return "Last";
                default:
                    throw new ArgumentException("DayDate.weekInMonthToString(): invalid code.");
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
        public static string RelativeToString(int relative)
        {
            switch (relative)
            {
                case DayDate.PRECEDING: return "Preceding";
                case DayDate.NEAREST: return "Nearest";
                case DayDate.FOLLOWING: return "Following";
                default:
                    throw new ArgumentException("ERROR : Relative To String");
            }
        }

        /**
         * Factory method that returns an instance of some concrete subclass of 
         * {@link DayDate}.
         *
         * @param day  the day (1-31).
         * @param month  the month (1-12).
         * @param yyyy  the year (in the range 1900 to 9999).
         *
         * @return An instance of {@link DayDate}.
         */
        public static DayDate CreateInstance(int day, Month month, int yyyy)
        {
            return new SpreadsheetDate(day, month, yyyy);
        }

        /**
         * Factory method that returns an instance of some concrete subclass of 
         * {@link DayDate}.
         *
         * @param serial  the serial number for the day (1 January 1900 = 2).
         *
         * @return a instance of DayDate.
         */
        public static DayDate CreateInstance(int serial)
        {
            return new SpreadsheetDate(serial);
        }

        /**
         * Factory method that returns an instance of a subclass of DayDate.
         *
         * @param date  A Java date object.
         *
         * @return a instance of DayDate.
         */
        public static DayDate CreateInstance(DateTime date)
        {
            return new SpreadsheetDate(date.Day, MonthExtensions.Make(date.Month), date.Year);
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
         * DayDate, we need to define a convention for the 'time of day'.
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
            return GetDayOfMonth() + "-" + DayDate.MonthCodeToString(GetMonth()) + "-" + GetYYYY();
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
        public abstract Month GetMonth();

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
        public abstract int Compare(DayDate other);

        /**
         * Returns true if this DayDate represents the same date as the 
         * specified DayDate.
         *
         * @param other  the date being compared to.
         *
         * @return <code>true</code> if this DayDate represents the same date as 
         *         the specified DayDate.
         */
        public abstract bool IsOn(DayDate other);

        /**
         * Returns true if this DayDate represents an earlier date compared to
         * the specified DayDate.
         *
         * @param other  The date being compared to.
         *
         * @return <code>true</code> if this DayDate represents an earlier date 
         *         compared to the specified DayDate.
         */
        public abstract bool IsBefore(DayDate other);

        /**
         * Returns true if this DayDate represents the same date as the 
         * specified DayDate.
         *
         * @param other  the date being compared to.
         *
         * @return <code>true</code> if this DayDate represents the same date
         *         as the specified DayDate.
         */
        public abstract bool IsOnOrBefore(DayDate other);

        /**
         * Returns true if this DayDate represents the same date as the 
         * specified DayDate.
         *
         * @param other  the date being compared to.
         *
         * @return <code>true</code> if this DayDate represents the same date
         *         as the specified DayDate.
         */
        public abstract bool IsAfter(DayDate other);

        /**
         * Returns true if this DayDate represents the same date as the 
         * specified DayDate.
         *
         * @param other  the date being compared to.
         *
         * @return <code>true</code> if this DayDate represents the same date
         *         as the specified DayDate.
         */
        public abstract bool IsOnOrAfter(DayDate other);

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
        public abstract bool IsInRange(DayDate d1, DayDate d2);

        /**
         * Returns <code>true</code> if this {@link DayDate} is within the 
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
        public abstract bool IsInRange(DayDate d1, DayDate d2, int include);

        /**
         * Returns the latest date that falls on the specified day-of-the-week and
         * is BEFORE this date.
         *
         * @param targetDOW  a code for the target day-of-the-week.
         *
         * @return the latest date that falls on the specified day-of-the-week and
         *         is BEFORE this date.
         */
        public DayDate GetPreviousDayOfWeek(int targetDOW)
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
        public DayDate GetFollowingDayOfWeek(int targetDOW)
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
        public DayDate GetNearestDayOfWeek(int targetDOW)
        {
            return GetNearestDayOfWeek(targetDOW, this);
        }
    }
}
