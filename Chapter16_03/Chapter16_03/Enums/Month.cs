using System;

namespace Chapter16_03.Enums
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
        public static Month Make(int monthIndex)
        {
            if (!Enum.IsDefined(typeof(Month), monthIndex))
                throw new ArgumentException($"Invalid month index {monthIndex}");

            Month result = (Month)Enum.ToObject(typeof(Month), monthIndex);
            return result;
        }
    }
}
