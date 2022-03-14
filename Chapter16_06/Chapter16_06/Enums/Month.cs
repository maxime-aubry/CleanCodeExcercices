using System;

namespace Chapter16_06.Enums
{
    public enum Month
    {
        JANUARY = 1,
        FEBRUARY = 2,
        MARCH = 3,
        APRIL = 4,
        MAY = 5,
        JUNE = 6,
        JULY = 7,
        AUGUST = 8,
        SEPTEMBER = 9,
        OCTOBER = 10,
        NOVEMBER = 11,
        DECEMBER = 12,
    }

    public static class MonthExtensions
    {
        private static readonly DateFormatSymbols dateSymbols = new DateFormatSymbols();
        private static int[] lastDayOfMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        public static Month Parse(int monthIndex)
        {
            if (!Enum.IsDefined(typeof(Month), monthIndex))
                throw new ArgumentException($"Invalid month index {monthIndex}");

            Month result = (Month)Enum.ToObject(typeof(Month), monthIndex);
            return result;
        }

        public static Month Parse(string expression)
        {
            expression = expression.Trim();
            foreach (Month month in Enum.GetValues(typeof(Month)))
            {
                if (Matches(expression, month))
                    return month;
            }

            throw new ArgumentException($"Invalid month expression {expression}");
        }

        private static bool Matches(string expression, Month month)
        {
            if (expression.Equals(month.ToString(true), StringComparison.InvariantCultureIgnoreCase)
                || expression.Equals(month.ToString(false), StringComparison.InvariantCultureIgnoreCase))
                return true;

            return false;
        }

        public static string ToString(this Month month, bool shortened = false)
        {
            if (shortened)
                return dateSymbols.getShortMonths()[(int)month - 1];
            else
                return dateSymbols.getMonths()[(int)month - 1];
        }

        public static int Quarter(this Month month) => (1 + (((int)month - 1) / 3));

        public static int LastDay(this Month month) => lastDayOfMonth[(int)month];
    }
}
