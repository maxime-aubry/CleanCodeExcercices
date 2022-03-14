using Chapter16_06.Enums;

namespace Chapter16_06
{
    public static class DateUtil
    {
        private static readonly DateFormatSymbols dateSymbols = new DateFormatSymbols();

        public static string[] GetMonthNames() => dateSymbols.getMonths();

        public static bool IsLeapYear(int year)
        {
            bool fourth = ((year % 4) == 0);
            bool hundredth = ((year % 100) == 0);
            bool fourHundredth = ((year % 400) == 0);
            return fourth && (!hundredth || fourHundredth);
        }

        public static int LastDayOfMonth(Month month, int year)
        {
            if (month == Month.FEBRUARY && IsLeapYear(year))
                return month.LastDay() + 1;
            else
                return month.LastDay();
        }

        public static int LeapYearCount(int year)
        {
            int leap4 = (year - 1896) / 4;
            int leap100 = (year - 1800) / 100;
            int leap400 = (year - 1600) / 400;
            return leap4 - leap100 + leap400;
        }
    }
}
