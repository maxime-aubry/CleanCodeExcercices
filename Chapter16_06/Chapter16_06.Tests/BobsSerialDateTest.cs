using Chapter16_06.Enums;
using Chapter16_06.Factories;
using NUnit.Framework;
using System;

namespace Chapter16_06.Tests
{
    public class BobsDayDateTest
    {
        private static SpreadsheetDate d(int day, Month month, int year) => new SpreadsheetDate(day, month, year);

        [Test]
        public void TestStringToWeekdayCode()
        {
            try
            {
                DayExtensions.Parse("Hello");
                Assert.Fail("Invalid Day String should throw exception");
            }
            catch (ArgumentException e)
            {

            }

            Assert.AreEqual(Day.MONDAY, DayExtensions.Parse("Monday"));
            Assert.AreEqual(Day.MONDAY, DayExtensions.Parse("Mon"));
            Assert.AreEqual(Day.MONDAY, DayExtensions.Parse("monday"));
            Assert.AreEqual(Day.MONDAY, DayExtensions.Parse("MONDAY"));
            Assert.AreEqual(Day.MONDAY, DayExtensions.Parse("mon"));

            Assert.AreEqual(Day.TUESDAY, DayExtensions.Parse("Tuesday"));
            Assert.AreEqual(Day.TUESDAY, DayExtensions.Parse("Tue"));
            Assert.AreEqual(Day.TUESDAY, DayExtensions.Parse("tuesday"));
            Assert.AreEqual(Day.TUESDAY, DayExtensions.Parse("TUESDAY"));
            Assert.AreEqual(Day.TUESDAY, DayExtensions.Parse("tue"));

            Assert.AreEqual(Day.WEDNESDAY, DayExtensions.Parse("Wednesday"));
            Assert.AreEqual(Day.WEDNESDAY, DayExtensions.Parse("Wed"));
            Assert.AreEqual(Day.WEDNESDAY, DayExtensions.Parse("wednesday"));
            Assert.AreEqual(Day.WEDNESDAY, DayExtensions.Parse("WEDNESDAY"));
            Assert.AreEqual(Day.WEDNESDAY, DayExtensions.Parse("wed"));

            Assert.AreEqual(Day.THURSDAY, DayExtensions.Parse("Thursday"));
            Assert.AreEqual(Day.THURSDAY, DayExtensions.Parse("Thu"));
            Assert.AreEqual(Day.THURSDAY, DayExtensions.Parse("thursday"));
            Assert.AreEqual(Day.THURSDAY, DayExtensions.Parse("THURSDAY"));
            Assert.AreEqual(Day.THURSDAY, DayExtensions.Parse("thu"));

            Assert.AreEqual(Day.FRIDAY, DayExtensions.Parse("Friday"));
            Assert.AreEqual(Day.FRIDAY, DayExtensions.Parse("Fri"));
            Assert.AreEqual(Day.FRIDAY, DayExtensions.Parse("friday"));
            Assert.AreEqual(Day.FRIDAY, DayExtensions.Parse("FRIDAY"));
            Assert.AreEqual(Day.FRIDAY, DayExtensions.Parse("fri"));

            Assert.AreEqual(Day.SATURDAY, DayExtensions.Parse("Saturday"));
            Assert.AreEqual(Day.SATURDAY, DayExtensions.Parse("Sat"));
            Assert.AreEqual(Day.SATURDAY, DayExtensions.Parse("saturday"));
            Assert.AreEqual(Day.SATURDAY, DayExtensions.Parse("SATURDAY"));
            Assert.AreEqual(Day.SATURDAY, DayExtensions.Parse("sat"));

            Assert.AreEqual(Day.SUNDAY, DayExtensions.Parse("Sunday"));
            Assert.AreEqual(Day.SUNDAY, DayExtensions.Parse("Sun"));
            Assert.AreEqual(Day.SUNDAY, DayExtensions.Parse("sunday"));
            Assert.AreEqual(Day.SUNDAY, DayExtensions.Parse("SUNDAY"));
            Assert.AreEqual(Day.SUNDAY, DayExtensions.Parse("sun"));
        }

        [Test]
        public void TestWeekdayCodeToString()
        {
            Assert.AreEqual("Sunday", DayExtensions.Parse((int)Day.SUNDAY).ToString(false));
            Assert.AreEqual("Monday", DayExtensions.Parse((int)Day.MONDAY).ToString(false));
            Assert.AreEqual("Tuesday", DayExtensions.Parse((int)Day.TUESDAY).ToString(false));
            Assert.AreEqual("Wednesday", DayExtensions.Parse((int)Day.WEDNESDAY).ToString(false));
            Assert.AreEqual("Thursday", DayExtensions.Parse((int)Day.THURSDAY).ToString(false));
            Assert.AreEqual("Friday", DayExtensions.Parse((int)Day.FRIDAY).ToString(false));
            Assert.AreEqual("Saturday", DayExtensions.Parse((int)Day.SATURDAY).ToString(false));
        }

        [Test]
        public void TestMonthToQuarter()
        {
            Assert.AreEqual(1, MonthExtensions.Quarter(Month.JANUARY));
            Assert.AreEqual(1, MonthExtensions.Quarter(Month.FEBRUARY));
            Assert.AreEqual(1, MonthExtensions.Quarter(Month.MARCH));
            Assert.AreEqual(2, MonthExtensions.Quarter(Month.APRIL));
            Assert.AreEqual(2, MonthExtensions.Quarter(Month.MAY));
            Assert.AreEqual(2, MonthExtensions.Quarter(Month.JUNE));
            Assert.AreEqual(3, MonthExtensions.Quarter(Month.JULY));
            Assert.AreEqual(3, MonthExtensions.Quarter(Month.AUGUST));
            Assert.AreEqual(3, MonthExtensions.Quarter(Month.SEPTEMBER));
            Assert.AreEqual(4, MonthExtensions.Quarter(Month.OCTOBER));
            Assert.AreEqual(4, MonthExtensions.Quarter(Month.NOVEMBER));
            Assert.AreEqual(4, MonthExtensions.Quarter(Month.DECEMBER));
        }

        [Test]
        public void TestMonthCodeToString()
        {
            Assert.AreEqual("January", MonthExtensions.ToString(Month.JANUARY, false));
            Assert.AreEqual("February", MonthExtensions.ToString(Month.FEBRUARY));
            Assert.AreEqual("March", MonthExtensions.ToString(Month.MARCH, false));
            Assert.AreEqual("April", MonthExtensions.ToString(Month.APRIL, false));
            Assert.AreEqual("May", MonthExtensions.ToString(Month.MAY, false));
            Assert.AreEqual("June", MonthExtensions.ToString(Month.JUNE, false));
            Assert.AreEqual("July", MonthExtensions.ToString(Month.JULY, false));
            Assert.AreEqual("August", MonthExtensions.ToString(Month.AUGUST, false));
            Assert.AreEqual("September", MonthExtensions.ToString(Month.SEPTEMBER, false));
            Assert.AreEqual("October", MonthExtensions.ToString(Month.OCTOBER, false));
            Assert.AreEqual("November", MonthExtensions.ToString(Month.NOVEMBER, false));
            Assert.AreEqual("December", MonthExtensions.ToString(Month.DECEMBER, false));

            Assert.AreEqual("Jan", MonthExtensions.ToString(Month.JANUARY, true));
            Assert.AreEqual("Feb", MonthExtensions.ToString(Month.FEBRUARY, true));
            Assert.AreEqual("Mar", MonthExtensions.ToString(Month.MARCH, true));
            Assert.AreEqual("Apr", MonthExtensions.ToString(Month.APRIL, true));
            Assert.AreEqual("May", MonthExtensions.ToString(Month.MAY, true));
            Assert.AreEqual("Jun", MonthExtensions.ToString(Month.JUNE, true));
            Assert.AreEqual("Jul", MonthExtensions.ToString(Month.JULY, true));
            Assert.AreEqual("Aug", MonthExtensions.ToString(Month.AUGUST, true));
            Assert.AreEqual("Sep", MonthExtensions.ToString(Month.SEPTEMBER, true));
            Assert.AreEqual("Oct", MonthExtensions.ToString(Month.OCTOBER, true));
            Assert.AreEqual("Nov", MonthExtensions.ToString(Month.NOVEMBER, true));
            Assert.AreEqual("Dec", MonthExtensions.ToString(Month.DECEMBER, true));
        }

        [Test]
        public void TestStringToMonthCode()
        {
            Assert.AreEqual(Month.JANUARY, MonthExtensions.Parse(1));
            Assert.AreEqual(Month.FEBRUARY, MonthExtensions.Parse(2));
            Assert.AreEqual(Month.MARCH, MonthExtensions.Parse(3));
            Assert.AreEqual(Month.APRIL, MonthExtensions.Parse(4));
            Assert.AreEqual(Month.MAY, MonthExtensions.Parse(5));
            Assert.AreEqual(Month.JUNE, MonthExtensions.Parse(6));
            Assert.AreEqual(Month.JULY, MonthExtensions.Parse(7));
            Assert.AreEqual(Month.AUGUST, MonthExtensions.Parse(8));
            Assert.AreEqual(Month.SEPTEMBER, MonthExtensions.Parse(9));
            Assert.AreEqual(Month.OCTOBER, MonthExtensions.Parse(10));
            Assert.AreEqual(Month.NOVEMBER, MonthExtensions.Parse(11));
            Assert.AreEqual(Month.DECEMBER, MonthExtensions.Parse(12));

            try
            {
                Assert.AreEqual(-1, MonthExtensions.Parse(0));
                Assert.Fail("Invalid month string code should throw exception");
            }
            catch (ArgumentException e)
            {

            }

            try
            {
                Assert.AreEqual(-1, MonthExtensions.Parse(13));
                Assert.Fail("Invalid month string code should throw exception");
            }
            catch (ArgumentException e)
            {

            }

            try
            {
                Assert.AreEqual(-1, MonthExtensions.Parse("Hello"));
                Assert.Fail("Invalid month string code should throw exception");
            }
            catch (ArgumentException e)
            {

            }

            for (int m = 1; m <= 12; m++)
            {
                Assert.AreEqual(MonthExtensions.Parse(m), MonthExtensions.Parse(MonthExtensions.ToString(MonthExtensions.Parse(m), false)));
                Assert.AreEqual(MonthExtensions.Parse(m), MonthExtensions.Parse(MonthExtensions.ToString(MonthExtensions.Parse(m), true)));
            }

            Assert.AreEqual(Month.JANUARY, MonthExtensions.Parse("jan"));
            Assert.AreEqual(Month.FEBRUARY, MonthExtensions.Parse("feb"));
            Assert.AreEqual(Month.MARCH, MonthExtensions.Parse("mar"));
            Assert.AreEqual(Month.APRIL, MonthExtensions.Parse("apr"));
            Assert.AreEqual(Month.MAY, MonthExtensions.Parse("may"));
            Assert.AreEqual(Month.JUNE, MonthExtensions.Parse("jun"));
            Assert.AreEqual(Month.JULY, MonthExtensions.Parse("jul"));
            Assert.AreEqual(Month.AUGUST, MonthExtensions.Parse("aug"));
            Assert.AreEqual(Month.SEPTEMBER, MonthExtensions.Parse("sep"));
            Assert.AreEqual(Month.OCTOBER, MonthExtensions.Parse("oct"));
            Assert.AreEqual(Month.NOVEMBER, MonthExtensions.Parse("nov"));
            Assert.AreEqual(Month.DECEMBER, MonthExtensions.Parse("dec"));

            Assert.AreEqual(Month.JANUARY, MonthExtensions.Parse("JAN"));
            Assert.AreEqual(Month.FEBRUARY, MonthExtensions.Parse("FEB"));
            Assert.AreEqual(Month.MARCH, MonthExtensions.Parse("MAR"));
            Assert.AreEqual(Month.APRIL, MonthExtensions.Parse("APR"));
            Assert.AreEqual(Month.MAY, MonthExtensions.Parse("MAY"));
            Assert.AreEqual(Month.JUNE, MonthExtensions.Parse("JUN"));
            Assert.AreEqual(Month.JULY, MonthExtensions.Parse("JUL"));
            Assert.AreEqual(Month.AUGUST, MonthExtensions.Parse("AUG"));
            Assert.AreEqual(Month.SEPTEMBER, MonthExtensions.Parse("SEP"));
            Assert.AreEqual(Month.OCTOBER, MonthExtensions.Parse("OCT"));
            Assert.AreEqual(Month.NOVEMBER, MonthExtensions.Parse("NOV"));
            Assert.AreEqual(Month.DECEMBER, MonthExtensions.Parse("DEC"));

            Assert.AreEqual(Month.JANUARY, MonthExtensions.Parse("january"));
            Assert.AreEqual(Month.FEBRUARY, MonthExtensions.Parse("february"));
            Assert.AreEqual(Month.MARCH, MonthExtensions.Parse("march"));
            Assert.AreEqual(Month.APRIL, MonthExtensions.Parse("april"));
            Assert.AreEqual(Month.MAY, MonthExtensions.Parse("may"));
            Assert.AreEqual(Month.JUNE, MonthExtensions.Parse("june"));
            Assert.AreEqual(Month.JULY, MonthExtensions.Parse("july"));
            Assert.AreEqual(Month.AUGUST, MonthExtensions.Parse("august"));
            Assert.AreEqual(Month.SEPTEMBER, MonthExtensions.Parse("september"));
            Assert.AreEqual(Month.OCTOBER, MonthExtensions.Parse("october"));
            Assert.AreEqual(Month.NOVEMBER, MonthExtensions.Parse("november"));
            Assert.AreEqual(Month.DECEMBER, MonthExtensions.Parse("december"));

            Assert.AreEqual(Month.JANUARY, MonthExtensions.Parse("JANUARY"));
            Assert.AreEqual(Month.FEBRUARY, MonthExtensions.Parse("FEBRUARY"));
            Assert.AreEqual(Month.MARCH, MonthExtensions.Parse("MARCH"));
            Assert.AreEqual(Month.APRIL, MonthExtensions.Parse("APRIL"));
            Assert.AreEqual(Month.MAY, MonthExtensions.Parse("MAY"));
            Assert.AreEqual(Month.JUNE, MonthExtensions.Parse("JUNE"));
            Assert.AreEqual(Month.JULY, MonthExtensions.Parse("JULY"));
            Assert.AreEqual(Month.AUGUST, MonthExtensions.Parse("AUGUST"));
            Assert.AreEqual(Month.SEPTEMBER, MonthExtensions.Parse("SEPTEMBER"));
            Assert.AreEqual(Month.OCTOBER, MonthExtensions.Parse("OCTOBER"));
            Assert.AreEqual(Month.NOVEMBER, MonthExtensions.Parse("NOVEMBER"));
            Assert.AreEqual(Month.DECEMBER, MonthExtensions.Parse("DECEMBER"));
        }

        [Test]
        public void TestIsLeapYear()
        {
            Assert.IsFalse(DateUtil.IsLeapYear(1900));
            Assert.IsFalse(DateUtil.IsLeapYear(1901));
            Assert.IsFalse(DateUtil.IsLeapYear(1902));
            Assert.IsFalse(DateUtil.IsLeapYear(1903));
            Assert.IsTrue(DateUtil.IsLeapYear(1904));
            Assert.IsTrue(DateUtil.IsLeapYear(1908));
            Assert.IsFalse(DateUtil.IsLeapYear(1955));
            Assert.IsTrue(DateUtil.IsLeapYear(1964));
            Assert.IsTrue(DateUtil.IsLeapYear(1980));
            Assert.IsTrue(DateUtil.IsLeapYear(2000));
            Assert.IsFalse(DateUtil.IsLeapYear(2001));
            Assert.IsFalse(DateUtil.IsLeapYear(2100));
        }

        [Test]
        public void TestLeapYearCount()
        {
            Assert.AreEqual(0, DateUtil.LeapYearCount(1900));
            Assert.AreEqual(0, DateUtil.LeapYearCount(1901));
            Assert.AreEqual(0, DateUtil.LeapYearCount(1902));
            Assert.AreEqual(0, DateUtil.LeapYearCount(1903));
            Assert.AreEqual(1, DateUtil.LeapYearCount(1904));
            Assert.AreEqual(1, DateUtil.LeapYearCount(1905));
            Assert.AreEqual(1, DateUtil.LeapYearCount(1906));
            Assert.AreEqual(1, DateUtil.LeapYearCount(1907));
            Assert.AreEqual(2, DateUtil.LeapYearCount(1908));
            Assert.AreEqual(24, DateUtil.LeapYearCount(1999));
            Assert.AreEqual(25, DateUtil.LeapYearCount(2001));
            Assert.AreEqual(49, DateUtil.LeapYearCount(2101));
            Assert.AreEqual(73, DateUtil.LeapYearCount(2201));
            Assert.AreEqual(97, DateUtil.LeapYearCount(2301));
            Assert.AreEqual(122, DateUtil.LeapYearCount(2401));
        }

        [Test]
        public void TestLastDayOfMonth()
        {
            Assert.AreEqual(31, DateUtil.LastDayOfMonth(Month.JANUARY, 1901));
            Assert.AreEqual(28, DateUtil.LastDayOfMonth(Month.FEBRUARY, 1901));
            Assert.AreEqual(31, DateUtil.LastDayOfMonth(Month.MARCH, 1901));
            Assert.AreEqual(30, DateUtil.LastDayOfMonth(Month.APRIL, 1901));
            Assert.AreEqual(31, DateUtil.LastDayOfMonth(Month.MAY, 1901));
            Assert.AreEqual(30, DateUtil.LastDayOfMonth(Month.JUNE, 1901));
            Assert.AreEqual(31, DateUtil.LastDayOfMonth(Month.JULY, 1901));
            Assert.AreEqual(31, DateUtil.LastDayOfMonth(Month.AUGUST, 1901));
            Assert.AreEqual(30, DateUtil.LastDayOfMonth(Month.SEPTEMBER, 1901));
            Assert.AreEqual(31, DateUtil.LastDayOfMonth(Month.OCTOBER, 1901));
            Assert.AreEqual(30, DateUtil.LastDayOfMonth(Month.NOVEMBER, 1901));
            Assert.AreEqual(31, DateUtil.LastDayOfMonth(Month.DECEMBER, 1901));
            Assert.AreEqual(29, DateUtil.LastDayOfMonth(Month.FEBRUARY, 1904));
        }

        [Test]
        public void TestPlusDays()
        {
            DayDate newYears = d(1, Month.JANUARY, 1900);
            Assert.AreEqual(d(2, Month.JANUARY, 1900), newYears.PlusDays(1));
            Assert.AreEqual(d(1, Month.FEBRUARY, 1900), newYears.PlusDays(31));
            Assert.AreEqual(d(1, Month.JANUARY, 1901), newYears.PlusDays(365));
            Assert.AreEqual(d(31, Month.DECEMBER, 1904), newYears.PlusDays(5 * 365));
        }

        [Test]
        public void TestPlusMonths()
        {
            Assert.AreEqual(d(1, Month.FEBRUARY, 1900), d(1, Month.JANUARY, 1900).PlusMonths(1));
            Assert.AreEqual(d(28, Month.FEBRUARY, 1900), d(31, Month.JANUARY, 1900).PlusMonths(1));
            Assert.AreEqual(d(28, Month.FEBRUARY, 1900), d(30, Month.JANUARY, 1900).PlusMonths(1));
            Assert.AreEqual(d(28, Month.FEBRUARY, 1900), d(29, Month.JANUARY, 1900).PlusMonths(1));
            Assert.AreEqual(d(28, Month.FEBRUARY, 1900), d(28, Month.JANUARY, 1900).PlusMonths(1));
            Assert.AreEqual(d(27, Month.FEBRUARY, 1900), d(27, Month.JANUARY, 1900).PlusMonths(1));

            Assert.AreEqual(d(30, Month.JUNE, 1900), d(31, Month.JANUARY, 1900).PlusMonths(5));
            Assert.AreEqual(d(30, Month.JUNE, 1901), d(31, Month.JANUARY, 1900).PlusMonths(17));

            Assert.AreEqual(d(29, Month.FEBRUARY, 1904), d(31, Month.JANUARY, 1900).PlusMonths(49));
        }

        [Test]
        public void TestPlusYears()
        {
            Assert.AreEqual(d(1, Month.JANUARY, 1901), d(1, Month.JANUARY, 1900).PlusYears(1));
            Assert.AreEqual(d(28, Month.FEBRUARY, 1905), d(29, Month.FEBRUARY, 1904).PlusYears(1));
            Assert.AreEqual(d(28, Month.FEBRUARY, 1905), d(28, Month.FEBRUARY, 1904).PlusYears(1));
            Assert.AreEqual(d(28, Month.FEBRUARY, 1904), d(28, Month.FEBRUARY, 1903).PlusYears(1));
        }

        [Test]
        public void TestGetPreviousDayOfWeek()
        {
            Assert.AreEqual(d(24, Month.FEBRUARY, 2006), d(1, Month.MARCH, 2006).GetPreviousDayOfWeek(Day.FRIDAY));
            Assert.AreEqual(d(22, Month.FEBRUARY, 2006), d(1, Month.MARCH, 2006).GetPreviousDayOfWeek(Day.WEDNESDAY));
            Assert.AreEqual(d(29, Month.FEBRUARY, 2004), d(3, Month.MARCH, 2004).GetPreviousDayOfWeek(Day.SUNDAY));
            Assert.AreEqual(d(29, Month.DECEMBER, 2004), d(5, Month.JANUARY, 2005).GetPreviousDayOfWeek(Day.WEDNESDAY));
        }

        [Test]
        public void TestGetFollowingDayOfWeek()
        {
            Assert.AreEqual(d(1, Month.JANUARY, 2005), d(25, Month.DECEMBER, 2004).GetFollowingDayOfWeek(Day.SATURDAY));
            Assert.AreEqual(d(1, Month.JANUARY, 2005), d(26, Month.DECEMBER, 2004).GetFollowingDayOfWeek(Day.SATURDAY));
            Assert.AreEqual(d(3, Month.MARCH, 2004), d(28, Month.FEBRUARY, 2004).GetFollowingDayOfWeek(Day.WEDNESDAY));
        }

        [Test]
        public void TestGetNearestDayOfWeek()
        {
            Assert.AreEqual(d(16, Month.APRIL, 2006), d(16, Month.APRIL, 2006).GetNearestDayOfWeek(Day.SUNDAY));
            Assert.AreEqual(d(16, Month.APRIL, 2006), d(17, Month.APRIL, 2006).GetNearestDayOfWeek(Day.SUNDAY));
            Assert.AreEqual(d(16, Month.APRIL, 2006), d(18, Month.APRIL, 2006).GetNearestDayOfWeek(Day.SUNDAY));
            Assert.AreEqual(d(16, Month.APRIL, 2006), d(19, Month.APRIL, 2006).GetNearestDayOfWeek(Day.SUNDAY));
            Assert.AreEqual(d(23, Month.APRIL, 2006), d(20, Month.APRIL, 2006).GetNearestDayOfWeek(Day.SUNDAY));
            Assert.AreEqual(d(23, Month.APRIL, 2006), d(21, Month.APRIL, 2006).GetNearestDayOfWeek(Day.SUNDAY));
            Assert.AreEqual(d(23, Month.APRIL, 2006), d(22, Month.APRIL, 2006).GetNearestDayOfWeek(Day.SUNDAY));

            Assert.AreEqual(d(17, Month.APRIL, 2006), d(16, Month.APRIL, 2006).GetNearestDayOfWeek(Day.MONDAY));
            Assert.AreEqual(d(17, Month.APRIL, 2006), d(17, Month.APRIL, 2006).GetNearestDayOfWeek(Day.MONDAY));
            Assert.AreEqual(d(17, Month.APRIL, 2006), d(18, Month.APRIL, 2006).GetNearestDayOfWeek(Day.MONDAY));
            Assert.AreEqual(d(17, Month.APRIL, 2006), d(19, Month.APRIL, 2006).GetNearestDayOfWeek(Day.MONDAY));
            Assert.AreEqual(d(17, Month.APRIL, 2006), d(20, Month.APRIL, 2006).GetNearestDayOfWeek(Day.MONDAY));
            Assert.AreEqual(d(24, Month.APRIL, 2006), d(21, Month.APRIL, 2006).GetNearestDayOfWeek(Day.MONDAY));
            Assert.AreEqual(d(24, Month.APRIL, 2006), d(22, Month.APRIL, 2006).GetNearestDayOfWeek(Day.MONDAY));

            Assert.AreEqual(d(18, Month.APRIL, 2006), d(16, Month.APRIL, 2006).GetNearestDayOfWeek(Day.TUESDAY));
            Assert.AreEqual(d(18, Month.APRIL, 2006), d(17, Month.APRIL, 2006).GetNearestDayOfWeek(Day.TUESDAY));
            Assert.AreEqual(d(18, Month.APRIL, 2006), d(18, Month.APRIL, 2006).GetNearestDayOfWeek(Day.TUESDAY));
            Assert.AreEqual(d(18, Month.APRIL, 2006), d(19, Month.APRIL, 2006).GetNearestDayOfWeek(Day.TUESDAY));
            Assert.AreEqual(d(18, Month.APRIL, 2006), d(20, Month.APRIL, 2006).GetNearestDayOfWeek(Day.TUESDAY));
            Assert.AreEqual(d(18, Month.APRIL, 2006), d(21, Month.APRIL, 2006).GetNearestDayOfWeek(Day.TUESDAY));
            Assert.AreEqual(d(25, Month.APRIL, 2006), d(22, Month.APRIL, 2006).GetNearestDayOfWeek(Day.TUESDAY));

            Assert.AreEqual(d(19, Month.APRIL, 2006), d(16, Month.APRIL, 2006).GetNearestDayOfWeek(Day.WEDNESDAY));
            Assert.AreEqual(d(19, Month.APRIL, 2006), d(17, Month.APRIL, 2006).GetNearestDayOfWeek(Day.WEDNESDAY));
            Assert.AreEqual(d(19, Month.APRIL, 2006), d(18, Month.APRIL, 2006).GetNearestDayOfWeek(Day.WEDNESDAY));
            Assert.AreEqual(d(19, Month.APRIL, 2006), d(19, Month.APRIL, 2006).GetNearestDayOfWeek(Day.WEDNESDAY));
            Assert.AreEqual(d(19, Month.APRIL, 2006), d(20, Month.APRIL, 2006).GetNearestDayOfWeek(Day.WEDNESDAY));
            Assert.AreEqual(d(19, Month.APRIL, 2006), d(21, Month.APRIL, 2006).GetNearestDayOfWeek(Day.WEDNESDAY));
            Assert.AreEqual(d(19, Month.APRIL, 2006), d(22, Month.APRIL, 2006).GetNearestDayOfWeek(Day.WEDNESDAY));

            Assert.AreEqual(d(13, Month.APRIL, 2006), d(16, Month.APRIL, 2006).GetNearestDayOfWeek(Day.THURSDAY));
            Assert.AreEqual(d(20, Month.APRIL, 2006), d(17, Month.APRIL, 2006).GetNearestDayOfWeek(Day.THURSDAY));
            Assert.AreEqual(d(20, Month.APRIL, 2006), d(18, Month.APRIL, 2006).GetNearestDayOfWeek(Day.THURSDAY));
            Assert.AreEqual(d(20, Month.APRIL, 2006), d(19, Month.APRIL, 2006).GetNearestDayOfWeek(Day.THURSDAY));
            Assert.AreEqual(d(20, Month.APRIL, 2006), d(20, Month.APRIL, 2006).GetNearestDayOfWeek(Day.THURSDAY));
            Assert.AreEqual(d(20, Month.APRIL, 2006), d(21, Month.APRIL, 2006).GetNearestDayOfWeek(Day.THURSDAY));
            Assert.AreEqual(d(20, Month.APRIL, 2006), d(22, Month.APRIL, 2006).GetNearestDayOfWeek(Day.THURSDAY));

            Assert.AreEqual(d(14, Month.APRIL, 2006), d(16, Month.APRIL, 2006).GetNearestDayOfWeek(Day.FRIDAY));
            Assert.AreEqual(d(14, Month.APRIL, 2006), d(17, Month.APRIL, 2006).GetNearestDayOfWeek(Day.FRIDAY));
            Assert.AreEqual(d(21, Month.APRIL, 2006), d(18, Month.APRIL, 2006).GetNearestDayOfWeek(Day.FRIDAY));
            Assert.AreEqual(d(21, Month.APRIL, 2006), d(19, Month.APRIL, 2006).GetNearestDayOfWeek(Day.FRIDAY));
            Assert.AreEqual(d(21, Month.APRIL, 2006), d(20, Month.APRIL, 2006).GetNearestDayOfWeek(Day.FRIDAY));
            Assert.AreEqual(d(21, Month.APRIL, 2006), d(21, Month.APRIL, 2006).GetNearestDayOfWeek(Day.FRIDAY));
            Assert.AreEqual(d(21, Month.APRIL, 2006), d(22, Month.APRIL, 2006).GetNearestDayOfWeek(Day.FRIDAY));

            Assert.AreEqual(d(15, Month.APRIL, 2006), d(16, Month.APRIL, 2006).GetNearestDayOfWeek(Day.SATURDAY));
            Assert.AreEqual(d(15, Month.APRIL, 2006), d(17, Month.APRIL, 2006).GetNearestDayOfWeek(Day.SATURDAY));
            Assert.AreEqual(d(15, Month.APRIL, 2006), d(18, Month.APRIL, 2006).GetNearestDayOfWeek(Day.SATURDAY));
            Assert.AreEqual(d(22, Month.APRIL, 2006), d(19, Month.APRIL, 2006).GetNearestDayOfWeek(Day.SATURDAY));
            Assert.AreEqual(d(22, Month.APRIL, 2006), d(20, Month.APRIL, 2006).GetNearestDayOfWeek(Day.SATURDAY));
            Assert.AreEqual(d(22, Month.APRIL, 2006), d(21, Month.APRIL, 2006).GetNearestDayOfWeek(Day.SATURDAY));
            Assert.AreEqual(d(22, Month.APRIL, 2006), d(22, Month.APRIL, 2006).GetNearestDayOfWeek(Day.SATURDAY));
        }

        [Test]
        public void TestEndOfCurrentMonth()
        {
            DayDate date = DayDateFactory.MakeDate(2);
            Assert.AreEqual(d(31, Month.JANUARY, 2006), d(1, Month.JANUARY, 2006).GetEndOfMonth());
            Assert.AreEqual(d(28, Month.FEBRUARY, 2006), d(1, Month.FEBRUARY, 2006).GetEndOfMonth());
            Assert.AreEqual(d(31, Month.MARCH, 2006), d(1, Month.MARCH, 2006).GetEndOfMonth());
            Assert.AreEqual(d(30, Month.APRIL, 2006), d(1, Month.APRIL, 2006).GetEndOfMonth());
            Assert.AreEqual(d(31, Month.MAY, 2006), d(1, Month.MAY, 2006).GetEndOfMonth());
            Assert.AreEqual(d(30, Month.JUNE, 2006), d(1, Month.JUNE, 2006).GetEndOfMonth());
            Assert.AreEqual(d(31, Month.JULY, 2006), d(1, Month.JULY, 2006).GetEndOfMonth());
            Assert.AreEqual(d(31, Month.AUGUST, 2006), d(1, Month.AUGUST, 2006).GetEndOfMonth());
            Assert.AreEqual(d(30, Month.SEPTEMBER, 2006), d(1, Month.SEPTEMBER, 2006).GetEndOfMonth());
            Assert.AreEqual(d(31, Month.OCTOBER, 2006), d(1, Month.OCTOBER, 2006).GetEndOfMonth());
            Assert.AreEqual(d(30, Month.NOVEMBER, 2006), d(1, Month.NOVEMBER, 2006).GetEndOfMonth());
            Assert.AreEqual(d(31, Month.DECEMBER, 2006), d(1, Month.DECEMBER, 2006).GetEndOfMonth());
            Assert.AreEqual(d(29, Month.FEBRUARY, 2008), d(1, Month.FEBRUARY, 2008).GetEndOfMonth());
        }

        [Test]
        public void TestCreateInstanceFromDDMMYYY()
        {
            DayDate date = DayDateFactory.MakeDate(1, Month.JANUARY, 1900);
            Assert.AreEqual(1, date.GetDayOfMonth());
            Assert.AreEqual(Month.JANUARY, date.GetMonth());
            Assert.AreEqual(1900, date.GetYear());
            Assert.AreEqual(2, date.GetOrdinalDay());
        }

        [Test]
        public void TestCreateInstanceFromSerial()
        {
            Assert.AreEqual(d(1, Month.JANUARY, 1900), DayDateFactory.MakeDate(2));
            Assert.AreEqual(d(1, Month.JANUARY, 1901), DayDateFactory.MakeDate(367));
        }
    }
}