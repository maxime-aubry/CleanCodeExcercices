using Chapter16_03.Enums;
using NUnit.Framework;
using System;

namespace Chapter16_03.Tests
{
    public class BobsDayDateTest
    {
        private static SpreadsheetDate d(int day, Month month, int year) => new SpreadsheetDate(day, month, year);

        [Test]
        public void TestIsValidWeekdayCode()
        {
            for (int day = 1; day <= 7; day++)
                Assert.IsTrue(DayDate.IsValidWeekdayCode(day));
            Assert.IsFalse(DayDate.IsValidWeekdayCode(0));
            Assert.IsFalse(DayDate.IsValidWeekdayCode(8));
        }

        [Test]
        public void TestStringToWeekdayCode()
        {
            Assert.AreEqual(-1, DayDate.StringToWeekdayCode("Hello"));

            Assert.AreEqual(DayDate.MONDAY, DayDate.StringToWeekdayCode("Monday"));
            Assert.AreEqual(DayDate.MONDAY, DayDate.StringToWeekdayCode("Mon"));
            //Assert.AreEqual(DayDate.MONDAY, DayDate.StringToWeekdayCode("monday"));
            //Assert.AreEqual(DayDate.MONDAY, DayDate.StringToWeekdayCode("MONDAY"));
            //Assert.AreEqual(DayDate.MONDAY, DayDate.StringToWeekdayCode("mon"));

            Assert.AreEqual(DayDate.TUESDAY, DayDate.StringToWeekdayCode("Tuesday"));
            Assert.AreEqual(DayDate.TUESDAY, DayDate.StringToWeekdayCode("Tue"));
            //Assert.AreEqual(DayDate.TUESDAY, DayDate.StringToWeekdayCode("tuesday"));
            //Assert.AreEqual(DayDate.TUESDAY, DayDate.StringToWeekdayCode("TUESDAY"));
            //Assert.AreEqual(DayDate.TUESDAY, DayDate.StringToWeekdayCode("tue"));
            //Assert.AreEqual(DayDate.TUESDAY, DayDate.StringToWeekdayCode("tues"));

            Assert.AreEqual(DayDate.WEDNESDAY, DayDate.StringToWeekdayCode("Wednesday"));
            Assert.AreEqual(DayDate.WEDNESDAY, DayDate.StringToWeekdayCode("Wed"));
            //Assert.AreEqual(DayDate.WEDNESDAY, DayDate.StringToWeekdayCode("wednesday"));
            //Assert.AreEqual(DayDate.WEDNESDAY, DayDate.StringToWeekdayCode("WEDNESDAY"));
            //Assert.AreEqual(DayDate.WEDNESDAY, DayDate.StringToWeekdayCode("wed"));

            Assert.AreEqual(DayDate.THURSDAY, DayDate.StringToWeekdayCode("Thursday"));
            Assert.AreEqual(DayDate.THURSDAY, DayDate.StringToWeekdayCode("Thu"));
            //Assert.AreEqual(DayDate.THURSDAY, DayDate.StringToWeekdayCode("thursday"));
            //Assert.AreEqual(DayDate.THURSDAY, DayDate.StringToWeekdayCode("THURSDAY"));
            //Assert.AreEqual(DayDate.THURSDAY, DayDate.StringToWeekdayCode("thu"));
            //Assert.AreEqual(DayDate.THURSDAY, DayDate.StringToWeekdayCode("thurs"));

            Assert.AreEqual(DayDate.FRIDAY, DayDate.StringToWeekdayCode("Friday"));
            Assert.AreEqual(DayDate.FRIDAY, DayDate.StringToWeekdayCode("Fri"));
            //Assert.AreEqual(DayDate.FRIDAY, DayDate.StringToWeekdayCode("friday"));
            //Assert.AreEqual(DayDate.FRIDAY, DayDate.StringToWeekdayCode("FRIDAY"));
            //Assert.AreEqual(DayDate.FRIDAY, DayDate.StringToWeekdayCode("fri"));

            Assert.AreEqual(DayDate.SATURDAY, DayDate.StringToWeekdayCode("Saturday"));
            Assert.AreEqual(DayDate.SATURDAY, DayDate.StringToWeekdayCode("Sat"));
            //Assert.AreEqual(DayDate.SATURDAY, DayDate.StringToWeekdayCode("saturday"));
            //Assert.AreEqual(DayDate.SATURDAY, DayDate.StringToWeekdayCode("SATURDAY"));
            //Assert.AreEqual(DayDate.SATURDAY, DayDate.StringToWeekdayCode("sat"));

            Assert.AreEqual(DayDate.SUNDAY, DayDate.StringToWeekdayCode("Sunday"));
            Assert.AreEqual(DayDate.SUNDAY, DayDate.StringToWeekdayCode("Sun"));
            //Assert.AreEqual(DayDate.SUNDAY, DayDate.StringToWeekdayCode("sunday"));
            //Assert.AreEqual(DayDate.SUNDAY, DayDate.StringToWeekdayCode("SUNDAY"));
            //Assert.AreEqual(DayDate.SUNDAY, DayDate.StringToWeekdayCode("sun"));
        }

        [Test]
        public void TestWeekdayCodeToString()
        {
            Assert.AreEqual("Sunday", DayDate.WeekdayCodeToString(DayDate.SUNDAY));
            Assert.AreEqual("Monday", DayDate.WeekdayCodeToString(DayDate.MONDAY));
            Assert.AreEqual("Tuesday", DayDate.WeekdayCodeToString(DayDate.TUESDAY));
            Assert.AreEqual("Wednesday", DayDate.WeekdayCodeToString(DayDate.WEDNESDAY));
            Assert.AreEqual("Thursday", DayDate.WeekdayCodeToString(DayDate.THURSDAY));
            Assert.AreEqual("Friday", DayDate.WeekdayCodeToString(DayDate.FRIDAY));
            Assert.AreEqual("Saturday", DayDate.WeekdayCodeToString(DayDate.SATURDAY));
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
            Assert.AreEqual("January", DayDate.MonthCodeToString(Month.JANUARY));
            Assert.AreEqual("February", DayDate.MonthCodeToString(Month.FEBRUARY));
            Assert.AreEqual("March", DayDate.MonthCodeToString(Month.MARCH));
            Assert.AreEqual("April", DayDate.MonthCodeToString(Month.APRIL));
            Assert.AreEqual("May", DayDate.MonthCodeToString(Month.MAY));
            Assert.AreEqual("June", DayDate.MonthCodeToString(Month.JUNE));
            Assert.AreEqual("July", DayDate.MonthCodeToString(Month.JULY));
            Assert.AreEqual("August", DayDate.MonthCodeToString(Month.AUGUST));
            Assert.AreEqual("September", DayDate.MonthCodeToString(Month.SEPTEMBER));
            Assert.AreEqual("October", DayDate.MonthCodeToString(Month.OCTOBER));
            Assert.AreEqual("November", DayDate.MonthCodeToString(Month.NOVEMBER));
            Assert.AreEqual("December", DayDate.MonthCodeToString(Month.DECEMBER));

            Assert.AreEqual("Jan", DayDate.MonthCodeToString(Month.JANUARY, true));
            Assert.AreEqual("Feb", DayDate.MonthCodeToString(Month.FEBRUARY, true));
            Assert.AreEqual("Mar", DayDate.MonthCodeToString(Month.MARCH, true));
            Assert.AreEqual("Apr", DayDate.MonthCodeToString(Month.APRIL, true));
            Assert.AreEqual("May", DayDate.MonthCodeToString(Month.MAY, true));
            Assert.AreEqual("Jun", DayDate.MonthCodeToString(Month.JUNE, true));
            Assert.AreEqual("Jul", DayDate.MonthCodeToString(Month.JULY, true));
            Assert.AreEqual("Aug", DayDate.MonthCodeToString(Month.AUGUST, true));
            Assert.AreEqual("Sep", DayDate.MonthCodeToString(Month.SEPTEMBER, true));
            Assert.AreEqual("Oct", DayDate.MonthCodeToString(Month.OCTOBER, true));
            Assert.AreEqual("Nov", DayDate.MonthCodeToString(Month.NOVEMBER, true));
            Assert.AreEqual("Dec", DayDate.MonthCodeToString(Month.DECEMBER, true));

            //try
            //{
            //    DayDate.MonthCodeToString(-1);
            //    Assert.Fail("Invalid month code should throw exception");
            //}
            //catch (ArgumentException e)
            //{

            //}
        }

        [Test]
        public void TestStringToMonthCode()
        {
            Assert.AreEqual(Month.JANUARY, DayDate.StringToMonthCode("1"));
            Assert.AreEqual(Month.FEBRUARY, DayDate.StringToMonthCode("2"));
            Assert.AreEqual(Month.MARCH, DayDate.StringToMonthCode("3"));
            Assert.AreEqual(Month.APRIL, DayDate.StringToMonthCode("4"));
            Assert.AreEqual(Month.MAY, DayDate.StringToMonthCode("5"));
            Assert.AreEqual(Month.JUNE, DayDate.StringToMonthCode("6"));
            Assert.AreEqual(Month.JULY, DayDate.StringToMonthCode("7"));
            Assert.AreEqual(Month.AUGUST, DayDate.StringToMonthCode("8"));
            Assert.AreEqual(Month.SEPTEMBER, DayDate.StringToMonthCode("9"));
            Assert.AreEqual(Month.OCTOBER, DayDate.StringToMonthCode("10"));
            Assert.AreEqual(Month.NOVEMBER, DayDate.StringToMonthCode("11"));
            Assert.AreEqual(Month.DECEMBER, DayDate.StringToMonthCode("12"));

            try
            {
                Assert.AreEqual(-1, DayDate.StringToMonthCode("0"));
                Assert.Fail("Invalid month string code should throw exception");
            }
            catch (ArgumentException e)
            {

            }

            try
            {
                Assert.AreEqual(-1, DayDate.StringToMonthCode("13"));
                Assert.Fail("Invalid month string code should throw exception");
            }
            catch (ArgumentException e)
            {

            }

            try
            {
                Assert.AreEqual(-1, DayDate.StringToMonthCode("Hello"));
                Assert.Fail("Invalid month string code should throw exception");
            }
            catch (ArgumentException e)
            {

            }

            for (int m = 1; m <= 12; m++)
            {
                Assert.AreEqual(MonthExtensions.Make(m), DayDate.StringToMonthCode(DayDate.MonthCodeToString(MonthExtensions.Make(m), false)));
                Assert.AreEqual(MonthExtensions.Make(m), DayDate.StringToMonthCode(DayDate.MonthCodeToString(MonthExtensions.Make(m), true)));
            }

            Assert.AreEqual(Month.JANUARY, DayDate.StringToMonthCode("jan"));
            Assert.AreEqual(Month.FEBRUARY, DayDate.StringToMonthCode("feb"));
            Assert.AreEqual(Month.MARCH, DayDate.StringToMonthCode("mar"));
            Assert.AreEqual(Month.APRIL, DayDate.StringToMonthCode("apr"));
            Assert.AreEqual(Month.MAY, DayDate.StringToMonthCode("may"));
            Assert.AreEqual(Month.JUNE, DayDate.StringToMonthCode("jun"));
            Assert.AreEqual(Month.JULY, DayDate.StringToMonthCode("jul"));
            Assert.AreEqual(Month.AUGUST, DayDate.StringToMonthCode("aug"));
            Assert.AreEqual(Month.SEPTEMBER, DayDate.StringToMonthCode("sep"));
            Assert.AreEqual(Month.OCTOBER, DayDate.StringToMonthCode("oct"));
            Assert.AreEqual(Month.NOVEMBER, DayDate.StringToMonthCode("nov"));
            Assert.AreEqual(Month.DECEMBER, DayDate.StringToMonthCode("dec"));

            Assert.AreEqual(Month.JANUARY, DayDate.StringToMonthCode("JAN"));
            Assert.AreEqual(Month.FEBRUARY, DayDate.StringToMonthCode("FEB"));
            Assert.AreEqual(Month.MARCH, DayDate.StringToMonthCode("MAR"));
            Assert.AreEqual(Month.APRIL, DayDate.StringToMonthCode("APR"));
            Assert.AreEqual(Month.MAY, DayDate.StringToMonthCode("MAY"));
            Assert.AreEqual(Month.JUNE, DayDate.StringToMonthCode("JUN"));
            Assert.AreEqual(Month.JULY, DayDate.StringToMonthCode("JUL"));
            Assert.AreEqual(Month.AUGUST, DayDate.StringToMonthCode("AUG"));
            Assert.AreEqual(Month.SEPTEMBER, DayDate.StringToMonthCode("SEP"));
            Assert.AreEqual(Month.OCTOBER, DayDate.StringToMonthCode("OCT"));
            Assert.AreEqual(Month.NOVEMBER, DayDate.StringToMonthCode("NOV"));
            Assert.AreEqual(Month.DECEMBER, DayDate.StringToMonthCode("DEC"));

            Assert.AreEqual(Month.JANUARY, DayDate.StringToMonthCode("january"));
            Assert.AreEqual(Month.FEBRUARY, DayDate.StringToMonthCode("february"));
            Assert.AreEqual(Month.MARCH, DayDate.StringToMonthCode("march"));
            Assert.AreEqual(Month.APRIL, DayDate.StringToMonthCode("april"));
            Assert.AreEqual(Month.MAY, DayDate.StringToMonthCode("may"));
            Assert.AreEqual(Month.JUNE, DayDate.StringToMonthCode("june"));
            Assert.AreEqual(Month.JULY, DayDate.StringToMonthCode("july"));
            Assert.AreEqual(Month.AUGUST, DayDate.StringToMonthCode("august"));
            Assert.AreEqual(Month.SEPTEMBER, DayDate.StringToMonthCode("september"));
            Assert.AreEqual(Month.OCTOBER, DayDate.StringToMonthCode("october"));
            Assert.AreEqual(Month.NOVEMBER, DayDate.StringToMonthCode("november"));
            Assert.AreEqual(Month.DECEMBER, DayDate.StringToMonthCode("december"));

            Assert.AreEqual(Month.JANUARY, DayDate.StringToMonthCode("JANUARY"));
            Assert.AreEqual(Month.FEBRUARY, DayDate.StringToMonthCode("FEBRUARY"));
            Assert.AreEqual(Month.MARCH, DayDate.StringToMonthCode("MARCH"));
            Assert.AreEqual(Month.APRIL, DayDate.StringToMonthCode("APRIL"));
            Assert.AreEqual(Month.MAY, DayDate.StringToMonthCode("MAY"));
            Assert.AreEqual(Month.JUNE, DayDate.StringToMonthCode("JUNE"));
            Assert.AreEqual(Month.JULY, DayDate.StringToMonthCode("JULY"));
            Assert.AreEqual(Month.AUGUST, DayDate.StringToMonthCode("AUGUST"));
            Assert.AreEqual(Month.SEPTEMBER, DayDate.StringToMonthCode("SEPTEMBER"));
            Assert.AreEqual(Month.OCTOBER, DayDate.StringToMonthCode("OCTOBER"));
            Assert.AreEqual(Month.NOVEMBER, DayDate.StringToMonthCode("NOVEMBER"));
            Assert.AreEqual(Month.DECEMBER, DayDate.StringToMonthCode("DECEMBER"));
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
            Assert.AreEqual(d(24, Month.FEBRUARY, 2006), DayDate.GetPreviousDayOfWeek(DayDate.FRIDAY, d(1, Month.MARCH, 2006)));
            Assert.AreEqual(d(22, Month.FEBRUARY, 2006), DayDate.GetPreviousDayOfWeek(DayDate.WEDNESDAY, d(1, Month.MARCH, 2006)));
            Assert.AreEqual(d(29, Month.FEBRUARY, 2004), DayDate.GetPreviousDayOfWeek(DayDate.SUNDAY, d(3, Month.MARCH, 2004)));
            Assert.AreEqual(d(29, Month.DECEMBER, 2004), DayDate.GetPreviousDayOfWeek(DayDate.WEDNESDAY, d(5, Month.JANUARY, 2005)));

            try
            {
                DayDate.GetPreviousDayOfWeek(-1, d(1, Month.JANUARY, 2006));
                Assert.Fail("Invalid day of week code should throw exception");
            }
            catch (ArgumentException e)
            {

            }
        }

        [Test]
        public void TestGetFollowingDayOfWeek()
        {
            Assert.AreEqual(d(1, Month.JANUARY, 2005), DayDate.GetFollowingDayOfWeek(DayDate.SATURDAY, d(25, Month.DECEMBER, 2004)));
            Assert.AreEqual(d(1, Month.JANUARY, 2005), DayDate.GetFollowingDayOfWeek(DayDate.SATURDAY, d(26, Month.DECEMBER, 2004)));
            Assert.AreEqual(d(3, Month.MARCH, 2004), DayDate.GetFollowingDayOfWeek(DayDate.WEDNESDAY, d(28, Month.FEBRUARY, 2004)));

            try
            {
                DayDate.GetFollowingDayOfWeek(-1, d(1, Month.JANUARY, 2006));
                Assert.Fail("Invalid day of week code should throw exception");
            }
            catch (ArgumentException e)
            {

            }
        }

        [Test]
        public void TestGetNearestDayOfWeek()
        {
            Assert.AreEqual(d(16, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.SUNDAY, d(16, Month.APRIL, 2006)));
            Assert.AreEqual(d(16, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.SUNDAY, d(17, Month.APRIL, 2006)));
            Assert.AreEqual(d(16, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.SUNDAY, d(18, Month.APRIL, 2006)));
            Assert.AreEqual(d(16, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.SUNDAY, d(19, Month.APRIL, 2006)));
            Assert.AreEqual(d(23, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.SUNDAY, d(20, Month.APRIL, 2006)));
            Assert.AreEqual(d(23, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.SUNDAY, d(21, Month.APRIL, 2006)));
            Assert.AreEqual(d(23, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.SUNDAY, d(22, Month.APRIL, 2006)));

            Assert.AreEqual(d(17, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.MONDAY, d(16, Month.APRIL, 2006)));
            Assert.AreEqual(d(17, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.MONDAY, d(17, Month.APRIL, 2006)));
            Assert.AreEqual(d(17, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.MONDAY, d(18, Month.APRIL, 2006)));
            Assert.AreEqual(d(17, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.MONDAY, d(19, Month.APRIL, 2006)));
            Assert.AreEqual(d(17, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.MONDAY, d(20, Month.APRIL, 2006)));
            Assert.AreEqual(d(24, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.MONDAY, d(21, Month.APRIL, 2006)));
            Assert.AreEqual(d(24, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.MONDAY, d(22, Month.APRIL, 2006)));

            Assert.AreEqual(d(18, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.TUESDAY, d(16, Month.APRIL, 2006)));
            Assert.AreEqual(d(18, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.TUESDAY, d(17, Month.APRIL, 2006)));
            Assert.AreEqual(d(18, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.TUESDAY, d(18, Month.APRIL, 2006)));
            Assert.AreEqual(d(18, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.TUESDAY, d(19, Month.APRIL, 2006)));
            Assert.AreEqual(d(18, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.TUESDAY, d(20, Month.APRIL, 2006)));
            Assert.AreEqual(d(18, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.TUESDAY, d(21, Month.APRIL, 2006)));
            Assert.AreEqual(d(25, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.TUESDAY, d(22, Month.APRIL, 2006)));

            Assert.AreEqual(d(19, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.WEDNESDAY, d(16, Month.APRIL, 2006)));
            Assert.AreEqual(d(19, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.WEDNESDAY, d(17, Month.APRIL, 2006)));
            Assert.AreEqual(d(19, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.WEDNESDAY, d(18, Month.APRIL, 2006)));
            Assert.AreEqual(d(19, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.WEDNESDAY, d(19, Month.APRIL, 2006)));
            Assert.AreEqual(d(19, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.WEDNESDAY, d(20, Month.APRIL, 2006)));
            Assert.AreEqual(d(19, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.WEDNESDAY, d(21, Month.APRIL, 2006)));
            Assert.AreEqual(d(19, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.WEDNESDAY, d(22, Month.APRIL, 2006)));

            Assert.AreEqual(d(13, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.THURSDAY, d(16, Month.APRIL, 2006)));
            Assert.AreEqual(d(20, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.THURSDAY, d(17, Month.APRIL, 2006)));
            Assert.AreEqual(d(20, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.THURSDAY, d(18, Month.APRIL, 2006)));
            Assert.AreEqual(d(20, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.THURSDAY, d(19, Month.APRIL, 2006)));
            Assert.AreEqual(d(20, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.THURSDAY, d(20, Month.APRIL, 2006)));
            Assert.AreEqual(d(20, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.THURSDAY, d(21, Month.APRIL, 2006)));
            Assert.AreEqual(d(20, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.THURSDAY, d(22, Month.APRIL, 2006)));

            Assert.AreEqual(d(14, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.FRIDAY, d(16, Month.APRIL, 2006)));
            Assert.AreEqual(d(14, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.FRIDAY, d(17, Month.APRIL, 2006)));
            Assert.AreEqual(d(21, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.FRIDAY, d(18, Month.APRIL, 2006)));
            Assert.AreEqual(d(21, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.FRIDAY, d(19, Month.APRIL, 2006)));
            Assert.AreEqual(d(21, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.FRIDAY, d(20, Month.APRIL, 2006)));
            Assert.AreEqual(d(21, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.FRIDAY, d(21, Month.APRIL, 2006)));
            Assert.AreEqual(d(21, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.FRIDAY, d(22, Month.APRIL, 2006)));

            Assert.AreEqual(d(15, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.SATURDAY, d(16, Month.APRIL, 2006)));
            Assert.AreEqual(d(15, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.SATURDAY, d(17, Month.APRIL, 2006)));
            Assert.AreEqual(d(15, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.SATURDAY, d(18, Month.APRIL, 2006)));
            Assert.AreEqual(d(22, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.SATURDAY, d(19, Month.APRIL, 2006)));
            Assert.AreEqual(d(22, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.SATURDAY, d(20, Month.APRIL, 2006)));
            Assert.AreEqual(d(22, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.SATURDAY, d(21, Month.APRIL, 2006)));
            Assert.AreEqual(d(22, Month.APRIL, 2006), DayDate.GetNearestDayOfWeek(DayDate.SATURDAY, d(22, Month.APRIL, 2006)));

            try
            {
                DayDate.GetNearestDayOfWeek(-1, d(1, Month.JANUARY, 2006));
                Assert.Fail("Invalid day of week code should throw exception");
            }
            catch (ArgumentException e)
            {

            }
        }

        [Test]
        public void TestEndOfCurrentMonth()
        {
            DayDate date = DayDate.CreateInstance(2);
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
            DayDate date = DayDate.CreateInstance(1, Month.JANUARY, 1900);
            Assert.AreEqual(1, date.GetDayOfMonth());
            Assert.AreEqual(Month.JANUARY, date.GetMonth());
            Assert.AreEqual(1900, date.GetYYYY());
            Assert.AreEqual(2, date.ToSerial());
        }

        [Test]
        public void TestCreateInstanceFromSerial()
        {
            Assert.AreEqual(d(1, Month.JANUARY, 1900), DayDate.CreateInstance(2));
            Assert.AreEqual(d(1, Month.JANUARY, 1901), DayDate.CreateInstance(367));
        }

        /*[Test]
        public void TestCreateInstanceFromJavaDate()
        {
            Assert.AreEqual(d(1, Month.JANUARY, 1900), DayDate.CreateInstance(new DateTime(1900, 1, 1)));
            Assert.AreEqual(d(1, Month.JANUARY, 2006), DayDate.CreateInstance(new DateTime(2006, 1, 1)));
        }*/
    }
}