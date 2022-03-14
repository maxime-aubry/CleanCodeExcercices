using Chapter16_06.Enums;
using Chapter16_06.Factories;
using System;

namespace Chapter16_06
{
    [Serializable]
    public abstract class DayDate
    {
        public abstract int GetOrdinalDay();
        public abstract int GetYear();
        public abstract Month GetMonth();
        public abstract int GetDayOfMonth();
        protected abstract Day GetDayOfWeekForOrdinalZero();

        public DayDate PlusDays(int days) => DayDateFactory.MakeDate(GetOrdinalDay() + days);

        public DayDate PlusMonths(int months)
        {
            int thisMonthAsOrdinal = (int)GetMonth() - (int)Month.JANUARY;
            int thisMonthAndYearAsOrdinal = (12 * GetYear()) + thisMonthAsOrdinal;
            int resultMonthAndYearAsOrdinal = thisMonthAndYearAsOrdinal + months;
            int resultYear = resultMonthAndYearAsOrdinal / 12;
            int resultMonthAsOrdinal = resultMonthAndYearAsOrdinal % 12 + (int)Month.JANUARY;
            Month resultMonth = MonthExtensions.Parse(resultMonthAsOrdinal);
            int resultDay = CorrectLastDayOfMonth(GetDayOfMonth(), resultMonth, resultYear);
            return DayDateFactory.MakeDate(resultDay, resultMonth, resultYear);
        }

        public DayDate PlusYears(int years)
        {
            int resultYear = GetYear() + years;
            int resultDay = CorrectLastDayOfMonth(GetDayOfMonth(), GetMonth(), resultYear);
            return DayDateFactory.MakeDate(resultDay, GetMonth(), resultYear);
        }

        public int CorrectLastDayOfMonth(int day, Month month, int year)
        {
            int lastDayOfMonth = DateUtil.LastDayOfMonth(month, year);
            if (day > lastDayOfMonth)
                day = lastDayOfMonth;
            return day;
        }

        public DayDate GetPreviousDayOfWeek(Day targetDayOfWeek)
        {
            int offsetToTarget = (int)targetDayOfWeek - (int)GetDayOfWeek();
            if (offsetToTarget >= 0)
                offsetToTarget -= 7;
            return PlusDays(offsetToTarget);
        }

        public DayDate GetFollowingDayOfWeek(Day targetDayOfWeek)
        {
            int offsetToTarget = (int)targetDayOfWeek - (int)GetDayOfWeek();
            if (offsetToTarget <= 0)
                offsetToTarget += 7;
            return PlusDays(offsetToTarget);
        }

        public DayDate GetNearestDayOfWeek(Day targetDay)
        {
            int offsetToThisWeeksTarget = (int)targetDay - (int)GetDayOfWeek();
            int offsetToFutureTarget = (offsetToThisWeeksTarget + 7) % 7;
            int offsetToPreviousTarget = offsetToFutureTarget - 7;

            if (offsetToFutureTarget > 3)
                return PlusDays(offsetToPreviousTarget);
            else
                return PlusDays(offsetToFutureTarget);
        }

        public DayDate GetEndOfMonth()
        {
            Month month = GetMonth();
            int year = GetYear();
            int lastDay = DateUtil.LastDayOfMonth(month, year);
            return DayDateFactory.MakeDate(lastDay, month, year);
        }

        public DateTime ToDate() => new DateTime(GetYear(), (int)GetMonth() - 1, GetDayOfMonth());

        public override string ToString() => $"{GetDayOfMonth()}-{MonthExtensions.ToString(GetMonth(), false)}-{GetYear()}";

        public Day GetDayOfWeek()
        {
            Day startingDay = GetDayOfWeekForOrdinalZero();
            int startingOffset = (int)startingDay - (int)Day.SUNDAY;
            int ordinalOfDayOfWeek = (GetOrdinalDay() + startingOffset) % 7;
            return DayExtensions.Parse(ordinalOfDayOfWeek + (int)Day.SUNDAY);
        }

        public int DaySince(DayDate date) => GetOrdinalDay() - date.GetOrdinalDay();

        public bool IsOn(DayDate other) => GetOrdinalDay() == other.GetOrdinalDay();

        public bool IsBefore(DayDate other) => GetOrdinalDay() < other.GetOrdinalDay();

        public bool IsOnOrBefore(DayDate other) => GetOrdinalDay() <= other.GetOrdinalDay();

        public bool IsAfter(DayDate other) => GetOrdinalDay() > other.GetOrdinalDay();

        public bool IsOnOrAfter(DayDate other) => GetOrdinalDay() >= other.GetOrdinalDay();

        public bool IsInRange(DayDate d1, DayDate d2) => IsInRange(d1, d2, DateInterval.CLOSED);

        public bool IsInRange(DayDate d1, DayDate d2, DateInterval interval)
        {
            int left = Math.Min(d1.GetOrdinalDay(), d2.GetOrdinalDay());
            int right = Math.Max(d1.GetOrdinalDay(), d2.GetOrdinalDay());
            return DateIntervalExtensions.IsIn(GetOrdinalDay(), left, right);
        }
    }
}
