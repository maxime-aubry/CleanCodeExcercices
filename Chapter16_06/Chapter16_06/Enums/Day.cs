using System;

namespace Chapter16_06.Enums
{
    public enum Day
    {
        SUNDAY = 1,
        MONDAY = 2,
        TUESDAY = 3,
        WEDNESDAY = 4,
        THURSDAY = 5,
        FRIDAY = 6,
        SATURDAY = 7
    }

    public static class DayExtensions
    {
        private static readonly DateFormatSymbols dateSymbols = new DateFormatSymbols();

        public static Day Parse(int dayIndex)
        {
            if (!Enum.IsDefined(typeof(Month), dayIndex))
                throw new ArgumentException($"Invalid day index {dayIndex}");

            Day result = (Day)Enum.ToObject(typeof(Day), dayIndex);
            return result;
        }

        public static Day Parse(string expression)
        {
            expression = expression.Trim();
            foreach (Day day in Enum.GetValues(typeof(Day)))
            {
                if (Matches(expression, day))
                    return day;
            }

            throw new ArgumentException($"Invalid day expression {expression}");
        }

        private static bool Matches(string expression, Day day)
        {
            if (expression.Equals(day.ToString(true), StringComparison.InvariantCultureIgnoreCase)
                || expression.Equals(day.ToString(false), StringComparison.InvariantCultureIgnoreCase))
                return true;

            return false;
        }

        public static string ToString(this Day day, bool shortened = false)
        {
            if (shortened)
                return dateSymbols.getShortWeekdays()[(int)day - 1];
            else
                return dateSymbols.getWeekdays()[(int)day - 1];
        }
    }
}
