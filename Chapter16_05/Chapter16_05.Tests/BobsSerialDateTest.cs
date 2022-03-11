using Chapter16_05.Enums;
using Chapter16_05.Factories;
using NUnit.Framework;
using System;

namespace Chapter16_05.Tests
{
    public class BobsDayDateTest
    {
        private static SpreadsheetDate d(int day, Month month, int year) => new SpreadsheetDate(day, month, year);

        //[Test]
        //public void TestIsValidWeekdayCode()
        //{
        //    for (int day = 1; day <= 7; day++)
        //        Assert.IsTrue(DayDate.IsValidWeekdayCode(day));
        //    Assert.IsFalse(DayDate.IsValidWeekdayCode(0));
        //    Assert.IsFalse(DayDate.IsValidWeekdayCode(8));
        //}

        [Test]
        public void TestStringToWeekdayCode()
        {
            try
            {
                DayExtensions.Make("Hello");
                Assert.Fail("Invalid Day String should throw exception");
            }
            catch (ArgumentException e)
            {

            }

            Assert.AreEqual(Day.MONDAY, DayExtensions.Make("Monday"));
            Assert.AreEqual(Day.MONDAY, DayExtensions.Make("Mon"));
            Assert.AreEqual(Day.MONDAY, DayExtensions.Make("monday"));
            Assert.AreEqual(Day.MONDAY, DayExtensions.Make("MONDAY"));
            Assert.AreEqual(Day.MONDAY, DayExtensions.Make("mon"));

            Assert.AreEqual(Day.TUESDAY, DayExtensions.Make("Tuesday"));
            Assert.AreEqual(Day.TUESDAY, DayExtensions.Make("Tue"));
            Assert.AreEqual(Day.TUESDAY, DayExtensions.Make("tuesday"));
            Assert.AreEqual(Day.TUESDAY, DayExtensions.Make("TUESDAY"));
            Assert.AreEqual(Day.TUESDAY, DayExtensions.Make("tue"));

            Assert.AreEqual(Day.WEDNESDAY, DayExtensions.Make("Wednesday"));
            Assert.AreEqual(Day.WEDNESDAY, DayExtensions.Make("Wed"));
            Assert.AreEqual(Day.WEDNESDAY, DayExtensions.Make("wednesday"));
            Assert.AreEqual(Day.WEDNESDAY, DayExtensions.Make("WEDNESDAY"));
            Assert.AreEqual(Day.WEDNESDAY, DayExtensions.Make("wed"));

            Assert.AreEqual(Day.THURSDAY, DayExtensions.Make("Thursday"));
            Assert.AreEqual(Day.THURSDAY, DayExtensions.Make("Thu"));
            Assert.AreEqual(Day.THURSDAY, DayExtensions.Make("thursday"));
            Assert.AreEqual(Day.THURSDAY, DayExtensions.Make("THURSDAY"));
            Assert.AreEqual(Day.THURSDAY, DayExtensions.Make("thu"));

            Assert.AreEqual(Day.FRIDAY, DayExtensions.Make("Friday"));
            Assert.AreEqual(Day.FRIDAY, DayExtensions.Make("Fri"));
            Assert.AreEqual(Day.FRIDAY, DayExtensions.Make("friday"));
            Assert.AreEqual(Day.FRIDAY, DayExtensions.Make("FRIDAY"));
            Assert.AreEqual(Day.FRIDAY, DayExtensions.Make("fri"));

            Assert.AreEqual(Day.SATURDAY, DayExtensions.Make("Saturday"));
            Assert.AreEqual(Day.SATURDAY, DayExtensions.Make("Sat"));
            Assert.AreEqual(Day.SATURDAY, DayExtensions.Make("saturday"));
            Assert.AreEqual(Day.SATURDAY, DayExtensions.Make("SATURDAY"));
            Assert.AreEqual(Day.SATURDAY, DayExtensions.Make("sat"));

            Assert.AreEqual(Day.SUNDAY, DayExtensions.Make("Sunday"));
            Assert.AreEqual(Day.SUNDAY, DayExtensions.Make("Sun"));
            Assert.AreEqual(Day.SUNDAY, DayExtensions.Make("sunday"));
            Assert.AreEqual(Day.SUNDAY, DayExtensions.Make("SUNDAY"));
            Assert.AreEqual(Day.SUNDAY, DayExtensions.Make("sun"));
        }

        [Test]
        public void TestWeekdayCodeToString()
        {
            Assert.AreEqual("Sunday", DayExtensions.Make((int)Day.SUNDAY).ToString(false));
            Assert.AreEqual("Monday", DayExtensions.Make((int)Day.MONDAY).ToString(false));
            Assert.AreEqual("Tuesday", DayExtensions.Make((int)Day.TUESDAY).ToString(false));
            Assert.AreEqual("Wednesday", DayExtensions.Make((int)Day.WEDNESDAY).ToString(false));
            Assert.AreEqual("Thursday", DayExtensions.Make((int)Day.THURSDAY).ToString(false));
            Assert.AreEqual("Friday", DayExtensions.Make((int)Day.FRIDAY).ToString(false));
            Assert.AreEqual("Saturday", DayExtensions.Make((int)Day.SATURDAY).ToString(false));
        }

        //[Test]
        //public void TestIsValidMonthCode()
        //{
        //    for (int i = 1; i <= 12; i++)
        //        Assert.IsTrue(DayDate.IsValidMonthCode(i));
        //    Assert.IsFalse(DayDate.IsValidMonthCode(0));
        //    Assert.IsFalse(DayDate.IsValidMonthCode(13));
        //}

        [Test]
        public void TestMonthToQuarter()
        {
            Assert.AreEqual(1, DayDate.MonthCodeToQuarter(Month.JANUARY));
            Assert.AreEqual(1, DayDate.MonthCodeToQuarter(Month.FEBRUARY));
            Assert.AreEqual(1, DayDate.MonthCodeToQuarter(Month.MARCH));
            Assert.AreEqual(2, DayDate.MonthCodeToQuarter(Month.APRIL));
            Assert.AreEqual(2, DayDate.MonthCodeToQuarter(Month.MAY));
            Assert.AreEqual(2, DayDate.MonthCodeToQuarter(Month.JUNE));
            Assert.AreEqual(3, DayDate.MonthCodeToQuarter(Month.JULY));
            Assert.AreEqual(3, DayDate.MonthCodeToQuarter(Month.AUGUST));
            Assert.AreEqual(3, DayDate.MonthCodeToQuarter(Month.SEPTEMBER));
            Assert.AreEqual(4, DayDate.MonthCodeToQuarter(Month.OCTOBER));
            Assert.AreEqual(4, DayDate.MonthCodeToQuarter(Month.NOVEMBER));
            Assert.AreEqual(4, DayDate.MonthCodeToQuarter(Month.DECEMBER));

            //try
            //{
            //    DayDate.MonthCodeToQuarter(-1);
            //    Assert.Fail("Invalid Month Code should throw exception");
            //}
            //catch (ArgumentException e)
            //{

            //}
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

            //try
            //{
            //    MonthExtensions.ToString(-1);
            //    Assert.Fail("Invalid month code should throw exception");
            //}
            //catch (ArgumentException e)
            //{

            //}
        }

        [Test]
        public void TestStringToMonthCode()
        {
            Assert.AreEqual(Month.JANUARY, MonthExtensions.Make(1));
            Assert.AreEqual(Month.FEBRUARY, MonthExtensions.Make(2));
            Assert.AreEqual(Month.MARCH, MonthExtensions.Make(3));
            Assert.AreEqual(Month.APRIL, MonthExtensions.Make(4));
            Assert.AreEqual(Month.MAY, MonthExtensions.Make(5));
            Assert.AreEqual(Month.JUNE, MonthExtensions.Make(6));
            Assert.AreEqual(Month.JULY, MonthExtensions.Make(7));
            Assert.AreEqual(Month.AUGUST, MonthExtensions.Make(8));
            Assert.AreEqual(Month.SEPTEMBER, MonthExtensions.Make(9));
            Assert.AreEqual(Month.OCTOBER, MonthExtensions.Make(10));
            Assert.AreEqual(Month.NOVEMBER, MonthExtensions.Make(11));
            Assert.AreEqual(Month.DECEMBER, MonthExtensions.Make(12));

            try
            {
                Assert.AreEqual(-1, MonthExtensions.Make(0));
                Assert.Fail("Invalid month string code should throw exception");
            }
            catch (ArgumentException e)
            {

            }

            try
            {
                Assert.AreEqual(-1, MonthExtensions.Make(13));
                Assert.Fail("Invalid month string code should throw exception");
            }
            catch (ArgumentException e)
            {

            }

            try
            {
                Assert.AreEqual(-1, MonthExtensions.Make("Hello"));
                Assert.Fail("Invalid month string code should throw exception");
            }
            catch (ArgumentException e)
            {

            }

            for (int m = 1; m <= 12; m++)
            {
                Assert.AreEqual(MonthExtensions.Make(m), MonthExtensions.Make(MonthExtensions.ToString(MonthExtensions.Make(m), false)));
                Assert.AreEqual(MonthExtensions.Make(m), MonthExtensions.Make(MonthExtensions.ToString(MonthExtensions.Make(m), true)));
            }

            Assert.AreEqual(Month.JANUARY, MonthExtensions.Make("jan"));
            Assert.AreEqual(Month.FEBRUARY, MonthExtensions.Make("feb"));
            Assert.AreEqual(Month.MARCH, MonthExtensions.Make("mar"));
            Assert.AreEqual(Month.APRIL, MonthExtensions.Make("apr"));
            Assert.AreEqual(Month.MAY, MonthExtensions.Make("may"));
            Assert.AreEqual(Month.JUNE, MonthExtensions.Make("jun"));
            Assert.AreEqual(Month.JULY, MonthExtensions.Make("jul"));
            Assert.AreEqual(Month.AUGUST, MonthExtensions.Make("aug"));
            Assert.AreEqual(Month.SEPTEMBER, MonthExtensions.Make("sep"));
            Assert.AreEqual(Month.OCTOBER, MonthExtensions.Make("oct"));
            Assert.AreEqual(Month.NOVEMBER, MonthExtensions.Make("nov"));
            Assert.AreEqual(Month.DECEMBER, MonthExtensions.Make("dec"));

            Assert.AreEqual(Month.JANUARY, MonthExtensions.Make("JAN"));
            Assert.AreEqual(Month.FEBRUARY, MonthExtensions.Make("FEB"));
            Assert.AreEqual(Month.MARCH, MonthExtensions.Make("MAR"));
            Assert.AreEqual(Month.APRIL, MonthExtensions.Make("APR"));
            Assert.AreEqual(Month.MAY, MonthExtensions.Make("MAY"));
            Assert.AreEqual(Month.JUNE, MonthExtensions.Make("JUN"));
            Assert.AreEqual(Month.JULY, MonthExtensions.Make("JUL"));
            Assert.AreEqual(Month.AUGUST, MonthExtensions.Make("AUG"));
            Assert.AreEqual(Month.SEPTEMBER, MonthExtensions.Make("SEP"));
            Assert.AreEqual(Month.OCTOBER, MonthExtensions.Make("OCT"));
            Assert.AreEqual(Month.NOVEMBER, MonthExtensions.Make("NOV"));
            Assert.AreEqual(Month.DECEMBER, MonthExtensions.Make("DEC"));

            Assert.AreEqual(Month.JANUARY, MonthExtensions.Make("january"));
            Assert.AreEqual(Month.FEBRUARY, MonthExtensions.Make("february"));
            Assert.AreEqual(Month.MARCH, MonthExtensions.Make("march"));
            Assert.AreEqual(Month.APRIL, MonthExtensions.Make("april"));
            Assert.AreEqual(Month.MAY, MonthExtensions.Make("may"));
            Assert.AreEqual(Month.JUNE, MonthExtensions.Make("june"));
            Assert.AreEqual(Month.JULY, MonthExtensions.Make("july"));
            Assert.AreEqual(Month.AUGUST, MonthExtensions.Make("august"));
            Assert.AreEqual(Month.SEPTEMBER, MonthExtensions.Make("september"));
            Assert.AreEqual(Month.OCTOBER, MonthExtensions.Make("october"));
            Assert.AreEqual(Month.NOVEMBER, MonthExtensions.Make("november"));
            Assert.AreEqual(Month.DECEMBER, MonthExtensions.Make("december"));

            Assert.AreEqual(Month.JANUARY, MonthExtensions.Make("JANUARY"));
            Assert.AreEqual(Month.FEBRUARY, MonthExtensions.Make("FEBRUARY"));
            Assert.AreEqual(Month.MARCH, MonthExtensions.Make("MARCH"));
            Assert.AreEqual(Month.APRIL, MonthExtensions.Make("APRIL"));
            Assert.AreEqual(Month.MAY, MonthExtensions.Make("MAY"));
            Assert.AreEqual(Month.JUNE, MonthExtensions.Make("JUNE"));
            Assert.AreEqual(Month.JULY, MonthExtensions.Make("JULY"));
            Assert.AreEqual(Month.AUGUST, MonthExtensions.Make("AUGUST"));
            Assert.AreEqual(Month.SEPTEMBER, MonthExtensions.Make("SEPTEMBER"));
            Assert.AreEqual(Month.OCTOBER, MonthExtensions.Make("OCTOBER"));
            Assert.AreEqual(Month.NOVEMBER, MonthExtensions.Make("NOVEMBER"));
            Assert.AreEqual(Month.DECEMBER, MonthExtensions.Make("DECEMBER"));
        }

        [Test]
        public void TestIsValidWeekInMonthCode()
        {
            for (int w = 0; w <= 4; w++)
                Assert.IsTrue(DayDate.IsValidWeekInMonthCode(w));
            Assert.IsFalse(DayDate.IsValidWeekInMonthCode(5));
        }

        [Test]
        public void TestIsLeapYear()
        {
            Assert.IsFalse(DayDate.IsLeapYear(1900));
            Assert.IsFalse(DayDate.IsLeapYear(1901));
            Assert.IsFalse(DayDate.IsLeapYear(1902));
            Assert.IsFalse(DayDate.IsLeapYear(1903));
            Assert.IsTrue(DayDate.IsLeapYear(1904));
            Assert.IsTrue(DayDate.IsLeapYear(1908));
            Assert.IsFalse(DayDate.IsLeapYear(1955));
            Assert.IsTrue(DayDate.IsLeapYear(1964));
            Assert.IsTrue(DayDate.IsLeapYear(1980));
            Assert.IsTrue(DayDate.IsLeapYear(2000));
            Assert.IsFalse(DayDate.IsLeapYear(2001));
            Assert.IsFalse(DayDate.IsLeapYear(2100));
        }

        [Test]
        public void TestLeapYearCount()
        {
            Assert.AreEqual(0, DayDate.LeapYearCount(1900));
            Assert.AreEqual(0, DayDate.LeapYearCount(1901));
            Assert.AreEqual(0, DayDate.LeapYearCount(1902));
            Assert.AreEqual(0, DayDate.LeapYearCount(1903));
            Assert.AreEqual(1, DayDate.LeapYearCount(1904));
            Assert.AreEqual(1, DayDate.LeapYearCount(1905));
            Assert.AreEqual(1, DayDate.LeapYearCount(1906));
            Assert.AreEqual(1, DayDate.LeapYearCount(1907));
            Assert.AreEqual(2, DayDate.LeapYearCount(1908));
            Assert.AreEqual(24, DayDate.LeapYearCount(1999));
            Assert.AreEqual(25, DayDate.LeapYearCount(2001));
            Assert.AreEqual(49, DayDate.LeapYearCount(2101));
            Assert.AreEqual(73, DayDate.LeapYearCount(2201));
            Assert.AreEqual(97, DayDate.LeapYearCount(2301));
            Assert.AreEqual(122, DayDate.LeapYearCount(2401));
        }

        [Test]
        public void TestLastDayOfMonth()
        {
            Assert.AreEqual(31, DayDate.LastDayOfMonth(Month.JANUARY, 1901));
            Assert.AreEqual(28, DayDate.LastDayOfMonth(Month.FEBRUARY, 1901));
            Assert.AreEqual(31, DayDate.LastDayOfMonth(Month.MARCH, 1901));
            Assert.AreEqual(30, DayDate.LastDayOfMonth(Month.APRIL, 1901));
            Assert.AreEqual(31, DayDate.LastDayOfMonth(Month.MAY, 1901));
            Assert.AreEqual(30, DayDate.LastDayOfMonth(Month.JUNE, 1901));
            Assert.AreEqual(31, DayDate.LastDayOfMonth(Month.JULY, 1901));
            Assert.AreEqual(31, DayDate.LastDayOfMonth(Month.AUGUST, 1901));
            Assert.AreEqual(30, DayDate.LastDayOfMonth(Month.SEPTEMBER, 1901));
            Assert.AreEqual(31, DayDate.LastDayOfMonth(Month.OCTOBER, 1901));
            Assert.AreEqual(30, DayDate.LastDayOfMonth(Month.NOVEMBER, 1901));
            Assert.AreEqual(31, DayDate.LastDayOfMonth(Month.DECEMBER, 1901));
            Assert.AreEqual(29, DayDate.LastDayOfMonth(Month.FEBRUARY, 1904));
        }

        [Test]
        public void TestAddDays()
        {
            DayDate newYears = d(1, Month.JANUARY, 1900);
            Assert.AreEqual(d(2, Month.JANUARY, 1900), DayDate.AddDays(1, newYears));
            Assert.AreEqual(d(1, Month.FEBRUARY, 1900), DayDate.AddDays(31, newYears));
            Assert.AreEqual(d(1, Month.JANUARY, 1901), DayDate.AddDays(365, newYears));
            Assert.AreEqual(d(31, Month.DECEMBER, 1904), DayDate.AddDays(5 * 365, newYears));
        }

        [Test]
        public void TestAddMonths()
        {
            Assert.AreEqual(d(1, Month.FEBRUARY, 1900), DayDate.AddMonths(1, d(1, Month.JANUARY, 1900)));
            Assert.AreEqual(d(28, Month.FEBRUARY, 1900), DayDate.AddMonths(1, d(31, Month.JANUARY, 1900)));
            Assert.AreEqual(d(28, Month.FEBRUARY, 1900), DayDate.AddMonths(1, d(30, Month.JANUARY, 1900)));
            Assert.AreEqual(d(28, Month.FEBRUARY, 1900), DayDate.AddMonths(1, d(29, Month.JANUARY, 1900)));
            Assert.AreEqual(d(28, Month.FEBRUARY, 1900), DayDate.AddMonths(1, d(28, Month.JANUARY, 1900)));
            Assert.AreEqual(d(27, Month.FEBRUARY, 1900), DayDate.AddMonths(1, d(27, Month.JANUARY, 1900)));

            Assert.AreEqual(d(30, Month.JUNE, 1900), DayDate.AddMonths(5, d(31, Month.JANUARY, 1900)));
            Assert.AreEqual(d(30, Month.JUNE, 1901), DayDate.AddMonths(17, d(31, Month.JANUARY, 1900)));

            Assert.AreEqual(d(29, Month.FEBRUARY, 1904), DayDate.AddMonths(49, d(31, Month.JANUARY, 1900)));
        }

        [Test]
        public void TestAddYears()
        {
            Assert.AreEqual(d(1, Month.JANUARY, 1901), DayDate.AddYears(1, d(1, Month.JANUARY, 1900)));
            Assert.AreEqual(d(28, Month.FEBRUARY, 1905), DayDate.AddYears(1, d(29, Month.FEBRUARY, 1904)));
            Assert.AreEqual(d(28, Month.FEBRUARY, 1905), DayDate.AddYears(1, d(28, Month.FEBRUARY, 1904)));
            Assert.AreEqual(d(28, Month.FEBRUARY, 1904), DayDate.AddYears(1, d(28, Month.FEBRUARY, 1903)));
        }

        [Test]
        public void TestGetPreviousDayOfWeek()
        {
            Assert.AreEqual(d(24, Month.FEBRUARY, 2006), DayDate.GetPreviousDayOfWeek(Day.FRIDAY, d(1, Month.MARCH, 2006)));
            Assert.AreEqual(d(22, Month.FEBRUARY, 2006), DayDate.GetPreviousDayOfWeek(Day.WEDNESDAY, d(1, Month.MARCH, 2006)));
            Assert.AreEqual(d(29, Month.FEBRUARY, 2004), DayDate.GetPreviousDayOfWeek(Day.SUNDAY, d(3, Month.MARCH, 2004)));
            Assert.AreEqual(d(29, Month.DECEMBER, 2004), DayDate.GetPreviousDayOfWeek(Day.WEDNESDAY, d(5, Month.JANUARY, 2005)));

            //try
            //{
            //    DayDate.GetPreviousDayOfWeek(-1, d(1, Month.JANUARY, 2006));
            //    Assert.Fail("Invalid day of week code should throw exception");
            //}
            //catch (ArgumentException e)
            //{

            //}
        }

        [Test]
        public void TestGetFollowingDayOfWeek()
        {
            Assert.AreEqual(d(1, Month.JANUARY, 2005), DayDate.GetFollowingDayOfWeek(Day.SATURDAY, d(25, Month.DECEMBER, 2004)));
            Assert.AreEqual(d(1, Month.JANUARY, 2005), DayDate.GetFollowingDayOfWeek(Day.SATURDAY, d(26, Month.DECEMBER, 2004)));
            Assert.AreEqual(d(3, Month.MARCH, 2004), DayDate.GetFollowingDayOfWeek(Day.WEDNESDAY, d(28, Month.FEBRUARY, 2004)));

            //try
            //{
            //    DayDate.GetFollowingDayOfWeek(-1, d(1, Month.JANUARY, 2006));
            //    Assert.Fail("Invalid day of week code should throw exception");
            //}
            //catch (ArgumentException e)
            //{

            //}
        }

        [Test]
        public void TestGetNearestDayOfWeek()
        {
            Assert.AreEqual(d(16, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.SUNDAY, d(16, Month.APRIL, 2006)));
            Assert.AreEqual(d(16, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.SUNDAY, d(17, Month.APRIL, 2006)));
            Assert.AreEqual(d(16, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.SUNDAY, d(18, Month.APRIL, 2006)));
            Assert.AreEqual(d(16, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.SUNDAY, d(19, Month.APRIL, 2006)));
            Assert.AreEqual(d(23, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.SUNDAY, d(20, Month.APRIL, 2006)));
            Assert.AreEqual(d(23, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.SUNDAY, d(21, Month.APRIL, 2006)));
            Assert.AreEqual(d(23, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.SUNDAY, d(22, Month.APRIL, 2006)));

            Assert.AreEqual(d(17, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.MONDAY, d(16, Month.APRIL, 2006)));
            Assert.AreEqual(d(17, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.MONDAY, d(17, Month.APRIL, 2006)));
            Assert.AreEqual(d(17, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.MONDAY, d(18, Month.APRIL, 2006)));
            Assert.AreEqual(d(17, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.MONDAY, d(19, Month.APRIL, 2006)));
            Assert.AreEqual(d(17, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.MONDAY, d(20, Month.APRIL, 2006)));
            Assert.AreEqual(d(24, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.MONDAY, d(21, Month.APRIL, 2006)));
            Assert.AreEqual(d(24, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.MONDAY, d(22, Month.APRIL, 2006)));

            Assert.AreEqual(d(18, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.TUESDAY, d(16, Month.APRIL, 2006)));
            Assert.AreEqual(d(18, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.TUESDAY, d(17, Month.APRIL, 2006)));
            Assert.AreEqual(d(18, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.TUESDAY, d(18, Month.APRIL, 2006)));
            Assert.AreEqual(d(18, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.TUESDAY, d(19, Month.APRIL, 2006)));
            Assert.AreEqual(d(18, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.TUESDAY, d(20, Month.APRIL, 2006)));
            Assert.AreEqual(d(18, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.TUESDAY, d(21, Month.APRIL, 2006)));
            Assert.AreEqual(d(25, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.TUESDAY, d(22, Month.APRIL, 2006)));

            Assert.AreEqual(d(19, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.WEDNESDAY, d(16, Month.APRIL, 2006)));
            Assert.AreEqual(d(19, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.WEDNESDAY, d(17, Month.APRIL, 2006)));
            Assert.AreEqual(d(19, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.WEDNESDAY, d(18, Month.APRIL, 2006)));
            Assert.AreEqual(d(19, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.WEDNESDAY, d(19, Month.APRIL, 2006)));
            Assert.AreEqual(d(19, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.WEDNESDAY, d(20, Month.APRIL, 2006)));
            Assert.AreEqual(d(19, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.WEDNESDAY, d(21, Month.APRIL, 2006)));
            Assert.AreEqual(d(19, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.WEDNESDAY, d(22, Month.APRIL, 2006)));

            Assert.AreEqual(d(13, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.THURSDAY, d(16, Month.APRIL, 2006)));
            Assert.AreEqual(d(20, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.THURSDAY, d(17, Month.APRIL, 2006)));
            Assert.AreEqual(d(20, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.THURSDAY, d(18, Month.APRIL, 2006)));
            Assert.AreEqual(d(20, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.THURSDAY, d(19, Month.APRIL, 2006)));
            Assert.AreEqual(d(20, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.THURSDAY, d(20, Month.APRIL, 2006)));
            Assert.AreEqual(d(20, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.THURSDAY, d(21, Month.APRIL, 2006)));
            Assert.AreEqual(d(20, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.THURSDAY, d(22, Month.APRIL, 2006)));

            Assert.AreEqual(d(14, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.FRIDAY, d(16, Month.APRIL, 2006)));
            Assert.AreEqual(d(14, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.FRIDAY, d(17, Month.APRIL, 2006)));
            Assert.AreEqual(d(21, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.FRIDAY, d(18, Month.APRIL, 2006)));
            Assert.AreEqual(d(21, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.FRIDAY, d(19, Month.APRIL, 2006)));
            Assert.AreEqual(d(21, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.FRIDAY, d(20, Month.APRIL, 2006)));
            Assert.AreEqual(d(21, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.FRIDAY, d(21, Month.APRIL, 2006)));
            Assert.AreEqual(d(21, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.FRIDAY, d(22, Month.APRIL, 2006)));

            Assert.AreEqual(d(15, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.SATURDAY, d(16, Month.APRIL, 2006)));
            Assert.AreEqual(d(15, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.SATURDAY, d(17, Month.APRIL, 2006)));
            Assert.AreEqual(d(15, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.SATURDAY, d(18, Month.APRIL, 2006)));
            Assert.AreEqual(d(22, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.SATURDAY, d(19, Month.APRIL, 2006)));
            Assert.AreEqual(d(22, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.SATURDAY, d(20, Month.APRIL, 2006)));
            Assert.AreEqual(d(22, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.SATURDAY, d(21, Month.APRIL, 2006)));
            Assert.AreEqual(d(22, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(Day.SATURDAY, d(22, Month.APRIL, 2006)));

            //try
            //{
            //    DayDate.GetNearestDayOfWeek(-1, d(1, Month.JANUARY, 2006));
            //    Assert.Fail("Invalid day of week code should throw exception");
            //}
            //catch (ArgumentException e)
            //{

            //}
        }

        [Test]
        public void TestEndOfCurrentMonth()
        {
            DayDate date = DayDateFactory.makeDate(2);
            Assert.AreEqual(d(31, Month.JANUARY, 2006), date.GetEndOfCurrentMonth(d(1, Month.JANUARY, 2006)));
            Assert.AreEqual(d(28, Month.FEBRUARY, 2006), date.GetEndOfCurrentMonth(d(1, Month.FEBRUARY, 2006)));
            Assert.AreEqual(d(31, Month.MARCH, 2006), date.GetEndOfCurrentMonth(d(1, Month.MARCH, 2006)));
            Assert.AreEqual(d(30, Month.APRIL, 2006), date.GetEndOfCurrentMonth(d(1, Month.APRIL, 2006)));
            Assert.AreEqual(d(31, Month.MAY, 2006), date.GetEndOfCurrentMonth(d(1, Month.MAY, 2006)));
            Assert.AreEqual(d(30, Month.JUNE, 2006), date.GetEndOfCurrentMonth(d(1, Month.JUNE, 2006)));
            Assert.AreEqual(d(31, Month.JULY, 2006), date.GetEndOfCurrentMonth(d(1, Month.JULY, 2006)));
            Assert.AreEqual(d(31, Month.AUGUST, 2006), date.GetEndOfCurrentMonth(d(1, Month.AUGUST, 2006)));
            Assert.AreEqual(d(30, Month.SEPTEMBER, 2006), date.GetEndOfCurrentMonth(d(1, Month.SEPTEMBER, 2006)));
            Assert.AreEqual(d(31, Month.OCTOBER, 2006), date.GetEndOfCurrentMonth(d(1, Month.OCTOBER, 2006)));
            Assert.AreEqual(d(30, Month.NOVEMBER, 2006), date.GetEndOfCurrentMonth(d(1, Month.NOVEMBER, 2006)));
            Assert.AreEqual(d(31, Month.DECEMBER, 2006), date.GetEndOfCurrentMonth(d(1, Month.DECEMBER, 2006)));
            Assert.AreEqual(d(29, Month.FEBRUARY, 2008), date.GetEndOfCurrentMonth(d(1, Month.FEBRUARY, 2008)));
        }

        [Test]
        public void TestWeekInMonthToString()
        {
            Assert.AreEqual("First", DayDate.WeekInMonthToString(DayDate.FIRST_WEEK_IN_MONTH));
            Assert.AreEqual("Second", DayDate.WeekInMonthToString(DayDate.SECOND_WEEK_IN_MONTH));
            Assert.AreEqual("Third", DayDate.WeekInMonthToString(DayDate.THIRD_WEEK_IN_MONTH));
            Assert.AreEqual("Fourth", DayDate.WeekInMonthToString(DayDate.FOURTH_WEEK_IN_MONTH));
            Assert.AreEqual("Last", DayDate.WeekInMonthToString(DayDate.LAST_WEEK_IN_MONTH));

            try
            {
                DayDate.WeekInMonthToString(-1);
                Assert.Fail("Invalid week code should throw exception");
            }
            catch (ArgumentException e)
            {

            }
        }

        [Test]
        public void TestRelativeToString()
        {
            Assert.AreEqual("Preceding", DayDate.RelativeToString(DayDate.PRECEDING));
            Assert.AreEqual("Nearest", DayDate.RelativeToString(DayDate.NEAREST));
            Assert.AreEqual("Following", DayDate.RelativeToString(DayDate.FOLLOWING));

            try
            {
                DayDate.RelativeToString(-1000);
                Assert.Fail("Invalid relative code should throw exception");
            }
            catch (ArgumentException e)
            {

            }
        }

        [Test]
        public void TestCreateInstanceFromDDMMYYY()
        {
            DayDate date = DayDateFactory.makeDate(1, Month.JANUARY, 1900);
            Assert.AreEqual(1, date.GetDayOfMonth());
            Assert.AreEqual(Month.JANUARY, date.GetMonth());
            Assert.AreEqual(1900, date.GetYYYY());
            Assert.AreEqual(2, date.ToSerial());
        }

        [Test]
        public void TestCreateInstanceFromSerial()
        {
            Assert.AreEqual(d(1, Month.JANUARY, 1900), DayDateFactory.makeDate(2));
            Assert.AreEqual(d(1, Month.JANUARY, 1901), DayDateFactory.makeDate(367));
        }

        /*[Test]
        public void TestCreateInstanceFromJavaDate()
        {
            Assert.AreEqual(d(1, Month.JANUARY, 1900), DayDate.CreateInstance(new DateTime(1900, 1, 1)));
            Assert.AreEqual(d(1, Month.JANUARY, 2006), DayDate.CreateInstance(new DateTime(2006, 1, 1)));
        }*/
    }
}