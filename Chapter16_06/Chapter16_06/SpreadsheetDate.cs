using Chapter16_06.Enums;
using System;

namespace Chapter16_06
{
    public class SpreadsheetDate : DayDate
    {
        public const int EARLIEST_DATE_ORDINAL = 2;
        public const int LATEST_DATE_ORDINAL = 2958465;
        public const int MINIMUM_YEAR_SUPPORTED = 1900;
        public const int MAXIMUM_YEAR_SUPPORTED = 9999;
        private static int[] AGGREGATE_DAYS_TO_END_OF_PRECEDING_MONTH = { 0, 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365 };
        private static int[] LEAP_YEAR_AGGREGATE_DAYS_TO_END_OF_PRECEDING_MONTH = { 0, 0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335, 366 };
        private int ordinalDay;
        private int day;
        private Month month;
        private int year;

        public SpreadsheetDate(int day, Month month, int year)
        {
            if (year < MINIMUM_YEAR_SUPPORTED || year > MAXIMUM_YEAR_SUPPORTED)
                throw new ArgumentException($"The 'year' argument must be in range {MINIMUM_YEAR_SUPPORTED} to {MAXIMUM_YEAR_SUPPORTED}");

            if (day < 1 || day > DateUtil.LastDayOfMonth(month, year))
                throw new ArgumentException("Invalid 'day' argument.");

            this.year = year;
            this.month = month;
            this.day = day;
            ordinalDay = CalcOrdinal(day, month, year);
        }

        public SpreadsheetDate(int day, int month, int year)
            : this(day, MonthExtensions.Parse(month), year)
        {

        }

        public SpreadsheetDate(int serial)
        {
            if (serial < EARLIEST_DATE_ORDINAL || serial > LATEST_DATE_ORDINAL)
                throw new ArgumentException("SpreadsheetDate: Serial must be in range 2 to 2958465.");

            ordinalDay = serial;
            CalcDayMonthYear();
        }

        public override int GetOrdinalDay()
        {
            return ordinalDay;
        }

        public override int GetYear()
        {
            return this.year;
        }

        public override Month GetMonth()
        {
            return this.month;
        }

        public override int GetDayOfMonth()
        {
            return this.day;
        }

        protected override Day GetDayOfWeekForOrdinalZero() => Day.SATURDAY;


        public override bool Equals(Object o)
        {
            if (!(o is DayDate))
                return false;

            DayDate date = (DayDate)o;
            return date.GetOrdinalDay() == GetOrdinalDay();
        }

        public int HashCode() => GetOrdinalDay();

        public int CompareTo(Object other) => DaySince((DayDate)other);

        private int CalcOrdinal(int day, Month month, int year)
        {
            int leapDaysForYear = DateUtil.LeapYearCount(year - 1);
            int daysUpToYear = (year - MINIMUM_YEAR_SUPPORTED) * 365 + leapDaysForYear;
            int daysUpToMonth = AGGREGATE_DAYS_TO_END_OF_PRECEDING_MONTH[(int)month];
            if (DateUtil.IsLeapYear(year) && month > Month.FEBRUARY)
                daysUpToMonth++;
            int daysInMonth = day - 1;
            return daysUpToYear + daysUpToMonth + daysInMonth + EARLIEST_DATE_ORDINAL;
        }

        private void CalcDayMonthYear()
        {
            int days = ordinalDay - EARLIEST_DATE_ORDINAL;
            int overestimatedYear = MINIMUM_YEAR_SUPPORTED + days / 365;
            int nonLeapDays = days - DateUtil.LeapYearCount(overestimatedYear);
            int underestimatedYear = MINIMUM_YEAR_SUPPORTED + nonLeapDays / 365;
            year = HuntForYearContaining(ordinalDay, underestimatedYear);
            int firstOrdinalYear = FirstOrdinalOfYear(year);
            month = HuntForMonthContaining(ordinalDay, firstOrdinalYear);
            day = ordinalDay - firstOrdinalYear - DaysBeforeThisMonth((int)month);
        }

        private Month HuntForMonthContaining(int anOrdinal, int firstOrdinalOfYear)
        {
            int daysIntoThisYear = anOrdinal - firstOrdinalOfYear;
            int aMonth = 1;
            while (DaysBeforeThisMonth(aMonth) < daysIntoThisYear)
                aMonth++;
            return MonthExtensions.Parse(aMonth - 1);
        }

        private int DaysBeforeThisMonth(int aMonth)
        {
            if (DateUtil.IsLeapYear(year))
                return LEAP_YEAR_AGGREGATE_DAYS_TO_END_OF_PRECEDING_MONTH[aMonth] - 1;
            else return AGGREGATE_DAYS_TO_END_OF_PRECEDING_MONTH[aMonth] - 1;
        }

        private int HuntForYearContaining(int anOrdinalDay, int startingYear)
        {
            int aYear = startingYear;
            while (FirstOrdinalOfYear(aYear) <= anOrdinalDay)
                aYear++;
            return aYear - 1;
        }

        private int FirstOrdinalOfYear(int year) => CalcOrdinal(1, Month.JANUARY, year);

        public static DayDate createInstance(DateTime date) => new SpreadsheetDate(date.Day, (int)MonthExtensions.Parse(date.Month + 1), date.Year);
    }
}
