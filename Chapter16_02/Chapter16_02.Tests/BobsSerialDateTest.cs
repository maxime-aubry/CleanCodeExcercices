using NUnit.Framework;
using System;

namespace Chapter16_02.Tests
{
    public class BobsSerialDateTest
    {
        private static SpreadsheetDate d(int day, int month, int year) => new SpreadsheetDate(day, month, year);

        [Test]
        public void TestIsValidWeekdayCode()
        {
            for (int day = 1; day <= 7; day++)
                Assert.IsTrue(SerialDate.IsValidWeekdayCode(day));
            Assert.IsFalse(SerialDate.IsValidWeekdayCode(0));
            Assert.IsFalse(SerialDate.IsValidWeekdayCode(8));
        }

        [Test]
        public void TestStringToWeekdayCode()
        {
            Assert.AreEqual(-1, SerialDate.StringToWeekdayCode("Hello"));

            Assert.AreEqual(SerialDate.MONDAY, SerialDate.StringToWeekdayCode("Monday"));
            Assert.AreEqual(SerialDate.MONDAY, SerialDate.StringToWeekdayCode("Mon"));
            //Assert.AreEqual(SerialDate.MONDAY, SerialDate.StringToWeekdayCode("monday"));
            //Assert.AreEqual(SerialDate.MONDAY, SerialDate.StringToWeekdayCode("MONDAY"));
            //Assert.AreEqual(SerialDate.MONDAY, SerialDate.StringToWeekdayCode("mon"));

            Assert.AreEqual(SerialDate.TUESDAY, SerialDate.StringToWeekdayCode("Tuesday"));
            Assert.AreEqual(SerialDate.TUESDAY, SerialDate.StringToWeekdayCode("Tue"));
            //Assert.AreEqual(SerialDate.TUESDAY, SerialDate.StringToWeekdayCode("tuesday"));
            //Assert.AreEqual(SerialDate.TUESDAY, SerialDate.StringToWeekdayCode("TUESDAY"));
            //Assert.AreEqual(SerialDate.TUESDAY, SerialDate.StringToWeekdayCode("tue"));
            //Assert.AreEqual(SerialDate.TUESDAY, SerialDate.StringToWeekdayCode("tues"));

            Assert.AreEqual(SerialDate.WEDNESDAY, SerialDate.StringToWeekdayCode("Wednesday"));
            Assert.AreEqual(SerialDate.WEDNESDAY, SerialDate.StringToWeekdayCode("Wed"));
            //Assert.AreEqual(SerialDate.WEDNESDAY, SerialDate.StringToWeekdayCode("wednesday"));
            //Assert.AreEqual(SerialDate.WEDNESDAY, SerialDate.StringToWeekdayCode("WEDNESDAY"));
            //Assert.AreEqual(SerialDate.WEDNESDAY, SerialDate.StringToWeekdayCode("wed"));

            Assert.AreEqual(SerialDate.THURSDAY, SerialDate.StringToWeekdayCode("Thursday"));
            Assert.AreEqual(SerialDate.THURSDAY, SerialDate.StringToWeekdayCode("Thu"));
            //Assert.AreEqual(SerialDate.THURSDAY, SerialDate.StringToWeekdayCode("thursday"));
            //Assert.AreEqual(SerialDate.THURSDAY, SerialDate.StringToWeekdayCode("THURSDAY"));
            //Assert.AreEqual(SerialDate.THURSDAY, SerialDate.StringToWeekdayCode("thu"));
            //Assert.AreEqual(SerialDate.THURSDAY, SerialDate.StringToWeekdayCode("thurs"));

            Assert.AreEqual(SerialDate.FRIDAY, SerialDate.StringToWeekdayCode("Friday"));
            Assert.AreEqual(SerialDate.FRIDAY, SerialDate.StringToWeekdayCode("Fri"));
            //Assert.AreEqual(SerialDate.FRIDAY, SerialDate.StringToWeekdayCode("friday"));
            //Assert.AreEqual(SerialDate.FRIDAY, SerialDate.StringToWeekdayCode("FRIDAY"));
            //Assert.AreEqual(SerialDate.FRIDAY, SerialDate.StringToWeekdayCode("fri"));

            Assert.AreEqual(SerialDate.SATURDAY, SerialDate.StringToWeekdayCode("Saturday"));
            Assert.AreEqual(SerialDate.SATURDAY, SerialDate.StringToWeekdayCode("Sat"));
            //Assert.AreEqual(SerialDate.SATURDAY, SerialDate.StringToWeekdayCode("saturday"));
            //Assert.AreEqual(SerialDate.SATURDAY, SerialDate.StringToWeekdayCode("SATURDAY"));
            //Assert.AreEqual(SerialDate.SATURDAY, SerialDate.StringToWeekdayCode("sat"));

            Assert.AreEqual(SerialDate.SUNDAY, SerialDate.StringToWeekdayCode("Sunday"));
            Assert.AreEqual(SerialDate.SUNDAY, SerialDate.StringToWeekdayCode("Sun"));
            //Assert.AreEqual(SerialDate.SUNDAY, SerialDate.StringToWeekdayCode("sunday"));
            //Assert.AreEqual(SerialDate.SUNDAY, SerialDate.StringToWeekdayCode("SUNDAY"));
            //Assert.AreEqual(SerialDate.SUNDAY, SerialDate.StringToWeekdayCode("sun"));
        }

        [Test]
        public void TestWeekdayCodeToString()
        {
            Assert.AreEqual("Sunday", SerialDate.WeekdayCodeToString(SerialDate.SUNDAY));
            Assert.AreEqual("Monday", SerialDate.WeekdayCodeToString(SerialDate.MONDAY));
            Assert.AreEqual("Tuesday", SerialDate.WeekdayCodeToString(SerialDate.TUESDAY));
            Assert.AreEqual("Wednesday", SerialDate.WeekdayCodeToString(SerialDate.WEDNESDAY));
            Assert.AreEqual("Thursday", SerialDate.WeekdayCodeToString(SerialDate.THURSDAY));
            Assert.AreEqual("Friday", SerialDate.WeekdayCodeToString(SerialDate.FRIDAY));
            Assert.AreEqual("Saturday", SerialDate.WeekdayCodeToString(SerialDate.SATURDAY));
        }

        [Test]
        public void TestIsValidMonthCode()
        {
            for (int i = 1; i <= 12; i++)
                Assert.IsTrue(SerialDate.IsValidMonthCode(i));
            Assert.IsFalse(SerialDate.IsValidMonthCode(0));
            Assert.IsFalse(SerialDate.IsValidMonthCode(13));
        }

        [Test]
        public void TestMonthToQuarter()
        {
            Assert.AreEqual(1, SerialDate.MonthCodeToQuarter(SerialDate.JANUARY));
            Assert.AreEqual(1, SerialDate.MonthCodeToQuarter(SerialDate.FEBRUARY));
            Assert.AreEqual(1, SerialDate.MonthCodeToQuarter(SerialDate.MARCH));
            Assert.AreEqual(2, SerialDate.MonthCodeToQuarter(SerialDate.APRIL));
            Assert.AreEqual(2, SerialDate.MonthCodeToQuarter(SerialDate.MAY));
            Assert.AreEqual(2, SerialDate.MonthCodeToQuarter(SerialDate.JUNE));
            Assert.AreEqual(3, SerialDate.MonthCodeToQuarter(SerialDate.JULY));
            Assert.AreEqual(3, SerialDate.MonthCodeToQuarter(SerialDate.AUGUST));
            Assert.AreEqual(3, SerialDate.MonthCodeToQuarter(SerialDate.SEPTEMBER));
            Assert.AreEqual(4, SerialDate.MonthCodeToQuarter(SerialDate.OCTOBER));
            Assert.AreEqual(4, SerialDate.MonthCodeToQuarter(SerialDate.NOVEMBER));
            Assert.AreEqual(4, SerialDate.MonthCodeToQuarter(SerialDate.DECEMBER));

            try
            {
                SerialDate.MonthCodeToQuarter(-1);
                Assert.Fail("Invalid Month Code should throw exception");
            }
            catch (ArgumentException e)
            {

            }
        }

        [Test]
        public void TestMonthCodeToString()
        {
            Assert.AreEqual("January", SerialDate.MonthCodeToString(SerialDate.JANUARY));
            Assert.AreEqual("February", SerialDate.MonthCodeToString(SerialDate.FEBRUARY));
            Assert.AreEqual("March", SerialDate.MonthCodeToString(SerialDate.MARCH));
            Assert.AreEqual("April", SerialDate.MonthCodeToString(SerialDate.APRIL));
            Assert.AreEqual("May", SerialDate.MonthCodeToString(SerialDate.MAY));
            Assert.AreEqual("June", SerialDate.MonthCodeToString(SerialDate.JUNE));
            Assert.AreEqual("July", SerialDate.MonthCodeToString(SerialDate.JULY));
            Assert.AreEqual("August", SerialDate.MonthCodeToString(SerialDate.AUGUST));
            Assert.AreEqual("September", SerialDate.MonthCodeToString(SerialDate.SEPTEMBER));
            Assert.AreEqual("October", SerialDate.MonthCodeToString(SerialDate.OCTOBER));
            Assert.AreEqual("November", SerialDate.MonthCodeToString(SerialDate.NOVEMBER));
            Assert.AreEqual("December", SerialDate.MonthCodeToString(SerialDate.DECEMBER));

            Assert.AreEqual("Jan", SerialDate.MonthCodeToString(SerialDate.JANUARY, true));
            Assert.AreEqual("Feb", SerialDate.MonthCodeToString(SerialDate.FEBRUARY, true));
            Assert.AreEqual("Mar", SerialDate.MonthCodeToString(SerialDate.MARCH, true));
            Assert.AreEqual("Apr", SerialDate.MonthCodeToString(SerialDate.APRIL, true));
            Assert.AreEqual("May", SerialDate.MonthCodeToString(SerialDate.MAY, true));
            Assert.AreEqual("Jun", SerialDate.MonthCodeToString(SerialDate.JUNE, true));
            Assert.AreEqual("Jul", SerialDate.MonthCodeToString(SerialDate.JULY, true));
            Assert.AreEqual("Aug", SerialDate.MonthCodeToString(SerialDate.AUGUST, true));
            Assert.AreEqual("Sep", SerialDate.MonthCodeToString(SerialDate.SEPTEMBER, true));
            Assert.AreEqual("Oct", SerialDate.MonthCodeToString(SerialDate.OCTOBER, true));
            Assert.AreEqual("Nov", SerialDate.MonthCodeToString(SerialDate.NOVEMBER, true));
            Assert.AreEqual("Dec", SerialDate.MonthCodeToString(SerialDate.DECEMBER, true));

            try
            {
                SerialDate.MonthCodeToString(-1);
                Assert.Fail("Invalid month code should throw exception");
            }
            catch (ArgumentException e)
            {

            }
        }

        [Test]
        public void TestStringToMonthCode()
        {
            Assert.AreEqual(SerialDate.JANUARY, SerialDate.StringToMonthCode("1"));
            Assert.AreEqual(SerialDate.FEBRUARY, SerialDate.StringToMonthCode("2"));
            Assert.AreEqual(SerialDate.MARCH, SerialDate.StringToMonthCode("3"));
            Assert.AreEqual(SerialDate.APRIL, SerialDate.StringToMonthCode("4"));
            Assert.AreEqual(SerialDate.MAY, SerialDate.StringToMonthCode("5"));
            Assert.AreEqual(SerialDate.JUNE, SerialDate.StringToMonthCode("6"));
            Assert.AreEqual(SerialDate.JULY, SerialDate.StringToMonthCode("7"));
            Assert.AreEqual(SerialDate.AUGUST, SerialDate.StringToMonthCode("8"));
            Assert.AreEqual(SerialDate.SEPTEMBER, SerialDate.StringToMonthCode("9"));
            Assert.AreEqual(SerialDate.OCTOBER, SerialDate.StringToMonthCode("10"));
            Assert.AreEqual(SerialDate.NOVEMBER, SerialDate.StringToMonthCode("11"));
            Assert.AreEqual(SerialDate.DECEMBER, SerialDate.StringToMonthCode("12"));

            Assert.AreEqual(-1, SerialDate.StringToMonthCode("0"));
            Assert.AreEqual(-1, SerialDate.StringToMonthCode("13"));

            Assert.AreEqual(-1, SerialDate.StringToMonthCode("Hello"));

            for (int m = 1; m <= 12; m++)
            {
                Assert.AreEqual(m, SerialDate.StringToMonthCode(SerialDate.MonthCodeToString(m, false)));
                Assert.AreEqual(m, SerialDate.StringToMonthCode(SerialDate.MonthCodeToString(m, true)));
            }

            //Assert.AreEqual(1, SerialDate.StringToMonthCode("jan"));
            //Assert.AreEqual(2, SerialDate.StringToMonthCode("feb"));
            //Assert.AreEqual(3, SerialDate.StringToMonthCode("mar"));
            //Assert.AreEqual(4, SerialDate.StringToMonthCode("apr"));
            //Assert.AreEqual(5, SerialDate.StringToMonthCode("may"));
            //Assert.AreEqual(6, SerialDate.StringToMonthCode("jun"));
            //Assert.AreEqual(7, SerialDate.StringToMonthCode("jul"));
            //Assert.AreEqual(8, SerialDate.StringToMonthCode("aug"));
            //Assert.AreEqual(9, SerialDate.StringToMonthCode("sep"));
            //Assert.AreEqual(10, SerialDate.StringToMonthCode("oct"));
            //Assert.AreEqual(11, SerialDate.StringToMonthCode("nov"));
            //Assert.AreEqual(12, SerialDate.StringToMonthCode("dec"));

            //Assert.AreEqual(1, SerialDate.StringToMonthCode("JAN"));
            //Assert.AreEqual(2, SerialDate.StringToMonthCode("FEB"));
            //Assert.AreEqual(3, SerialDate.StringToMonthCode("MAR"));
            //Assert.AreEqual(4, SerialDate.StringToMonthCode("APR"));
            //Assert.AreEqual(5, SerialDate.StringToMonthCode("MAY"));
            //Assert.AreEqual(6, SerialDate.StringToMonthCode("JUN"));
            //Assert.AreEqual(7, SerialDate.StringToMonthCode("JUL"));
            //Assert.AreEqual(8, SerialDate.StringToMonthCode("AUG"));
            //Assert.AreEqual(9, SerialDate.StringToMonthCode("SEP"));
            //Assert.AreEqual(10, SerialDate.StringToMonthCode("OCT"));
            //Assert.AreEqual(11, SerialDate.StringToMonthCode("NOV"));
            //Assert.AreEqual(12, SerialDate.StringToMonthCode("DEC"));

            //Assert.AreEqual(1, SerialDate.StringToMonthCode("january"));
            //Assert.AreEqual(2, SerialDate.StringToMonthCode("february"));
            //Assert.AreEqual(3, SerialDate.StringToMonthCode("march"));
            //Assert.AreEqual(4, SerialDate.StringToMonthCode("april"));
            //Assert.AreEqual(5, SerialDate.StringToMonthCode("may"));
            //Assert.AreEqual(6, SerialDate.StringToMonthCode("june"));
            //Assert.AreEqual(7, SerialDate.StringToMonthCode("july"));
            //Assert.AreEqual(8, SerialDate.StringToMonthCode("august"));
            //Assert.AreEqual(9, SerialDate.StringToMonthCode("september"));
            //Assert.AreEqual(10, SerialDate.StringToMonthCode("october"));
            //Assert.AreEqual(11, SerialDate.StringToMonthCode("november"));
            //Assert.AreEqual(12, SerialDate.StringToMonthCode("december"));

            //Assert.AreEqual(1, SerialDate.StringToMonthCode("JANUARY"));
            //Assert.AreEqual(2, SerialDate.StringToMonthCode("FEBRUARY"));
            //Assert.AreEqual(3, SerialDate.StringToMonthCode("MARCH"));
            //Assert.AreEqual(4, SerialDate.StringToMonthCode("APRIL"));
            //Assert.AreEqual(5, SerialDate.StringToMonthCode("MAY"));
            //Assert.AreEqual(6, SerialDate.StringToMonthCode("JUNE"));
            //Assert.AreEqual(7, SerialDate.StringToMonthCode("JULY"));
            //Assert.AreEqual(8, SerialDate.StringToMonthCode("AUGUST"));
            //Assert.AreEqual(9, SerialDate.StringToMonthCode("SEPTEMBER"));
            //Assert.AreEqual(10, SerialDate.StringToMonthCode("OCTOBER"));
            //Assert.AreEqual(11, SerialDate.StringToMonthCode("NOVEMBER"));
            //Assert.AreEqual(12, SerialDate.StringToMonthCode("DECEMBER"));
        }

        [Test]
        public void TestIsValidWeekInMonthCode()
        {
            for (int w = 0; w <= 4; w++)
                Assert.IsTrue(SerialDate.IsValidWeekInMonthCode(w));
            Assert.IsFalse(SerialDate.IsValidWeekInMonthCode(5));
        }

        [Test]
        public void TestIsLeapYear()
        {
            Assert.IsFalse(SerialDate.IsLeapYear(1900));
            Assert.IsFalse(SerialDate.IsLeapYear(1901));
            Assert.IsFalse(SerialDate.IsLeapYear(1902));
            Assert.IsFalse(SerialDate.IsLeapYear(1903));
            Assert.IsTrue(SerialDate.IsLeapYear(1904));
            Assert.IsTrue(SerialDate.IsLeapYear(1908));
            Assert.IsFalse(SerialDate.IsLeapYear(1955));
            Assert.IsTrue(SerialDate.IsLeapYear(1964));
            Assert.IsTrue(SerialDate.IsLeapYear(1980));
            Assert.IsTrue(SerialDate.IsLeapYear(2000));
            Assert.IsFalse(SerialDate.IsLeapYear(2001));
            Assert.IsFalse(SerialDate.IsLeapYear(2100));
        }

        [Test]
        public void TestLeapYearCount()
        {
            Assert.AreEqual(0, SerialDate.LeapYearCount(1900));
            Assert.AreEqual(0, SerialDate.LeapYearCount(1901));
            Assert.AreEqual(0, SerialDate.LeapYearCount(1902));
            Assert.AreEqual(0, SerialDate.LeapYearCount(1903));
            Assert.AreEqual(1, SerialDate.LeapYearCount(1904));
            Assert.AreEqual(1, SerialDate.LeapYearCount(1905));
            Assert.AreEqual(1, SerialDate.LeapYearCount(1906));
            Assert.AreEqual(1, SerialDate.LeapYearCount(1907));
            Assert.AreEqual(2, SerialDate.LeapYearCount(1908));
            Assert.AreEqual(24, SerialDate.LeapYearCount(1999));
            Assert.AreEqual(25, SerialDate.LeapYearCount(2001));
            Assert.AreEqual(49, SerialDate.LeapYearCount(2101));
            Assert.AreEqual(73, SerialDate.LeapYearCount(2201));
            Assert.AreEqual(97, SerialDate.LeapYearCount(2301));
            Assert.AreEqual(122, SerialDate.LeapYearCount(2401));
        }

        [Test]
        public void TestLastDayOfMonth()
        {
            Assert.AreEqual(31, SerialDate.LastDayOfMonth(SerialDate.JANUARY, 1901));
            Assert.AreEqual(28, SerialDate.LastDayOfMonth(SerialDate.FEBRUARY, 1901));
            Assert.AreEqual(31, SerialDate.LastDayOfMonth(SerialDate.MARCH, 1901));
            Assert.AreEqual(30, SerialDate.LastDayOfMonth(SerialDate.APRIL, 1901));
            Assert.AreEqual(31, SerialDate.LastDayOfMonth(SerialDate.MAY, 1901));
            Assert.AreEqual(30, SerialDate.LastDayOfMonth(SerialDate.JUNE, 1901));
            Assert.AreEqual(31, SerialDate.LastDayOfMonth(SerialDate.JULY, 1901));
            Assert.AreEqual(31, SerialDate.LastDayOfMonth(SerialDate.AUGUST, 1901));
            Assert.AreEqual(30, SerialDate.LastDayOfMonth(SerialDate.SEPTEMBER, 1901));
            Assert.AreEqual(31, SerialDate.LastDayOfMonth(SerialDate.OCTOBER, 1901));
            Assert.AreEqual(30, SerialDate.LastDayOfMonth(SerialDate.NOVEMBER, 1901));
            Assert.AreEqual(31, SerialDate.LastDayOfMonth(SerialDate.DECEMBER, 1901));
            Assert.AreEqual(29, SerialDate.LastDayOfMonth(SerialDate.FEBRUARY, 1904));
        }

        [Test]
        public void TestAddDays()
        {
            SerialDate newYears = d(1, SerialDate.JANUARY, 1900);
            Assert.AreEqual(d(2, SerialDate.JANUARY, 1900), SerialDate.AddDays(1, newYears));
            Assert.AreEqual(d(1, SerialDate.FEBRUARY, 1900), SerialDate.AddDays(31, newYears));
            Assert.AreEqual(d(1, SerialDate.JANUARY, 1901), SerialDate.AddDays(365, newYears));
            Assert.AreEqual(d(31, SerialDate.DECEMBER, 1904), SerialDate.AddDays(5 * 365, newYears));
        }

        [Test]
        public void TestAddMonths()
        {
            Assert.AreEqual(d(1, SerialDate.FEBRUARY, 1900), SerialDate.AddMonths(1, d(1, SerialDate.JANUARY, 1900)));
            Assert.AreEqual(d(28, SerialDate.FEBRUARY, 1900), SerialDate.AddMonths(1, d(31, SerialDate.JANUARY, 1900)));
            Assert.AreEqual(d(28, SerialDate.FEBRUARY, 1900), SerialDate.AddMonths(1, d(30, SerialDate.JANUARY, 1900)));
            Assert.AreEqual(d(28, SerialDate.FEBRUARY, 1900), SerialDate.AddMonths(1, d(29, SerialDate.JANUARY, 1900)));
            Assert.AreEqual(d(28, SerialDate.FEBRUARY, 1900), SerialDate.AddMonths(1, d(28, SerialDate.JANUARY, 1900)));
            Assert.AreEqual(d(27, SerialDate.FEBRUARY, 1900), SerialDate.AddMonths(1, d(27, SerialDate.JANUARY, 1900)));

            Assert.AreEqual(d(30, SerialDate.JUNE, 1900), SerialDate.AddMonths(5, d(31, SerialDate.JANUARY, 1900)));
            Assert.AreEqual(d(30, SerialDate.JUNE, 1901), SerialDate.AddMonths(17, d(31, SerialDate.JANUARY, 1900)));

            Assert.AreEqual(d(29, SerialDate.FEBRUARY, 1904), SerialDate.AddMonths(49, d(31, SerialDate.JANUARY, 1900)));
        }

        [Test]
        public void TestAddYears()
        {
            Assert.AreEqual(d(1, SerialDate.JANUARY, 1901), SerialDate.AddYears(1, d(1, SerialDate.JANUARY, 1900)));
            Assert.AreEqual(d(28, SerialDate.FEBRUARY, 1905), SerialDate.AddYears(1, d(29, SerialDate.FEBRUARY, 1904)));
            Assert.AreEqual(d(28, SerialDate.FEBRUARY, 1905), SerialDate.AddYears(1, d(28, SerialDate.FEBRUARY, 1904)));
            Assert.AreEqual(d(28, SerialDate.FEBRUARY, 1904), SerialDate.AddYears(1, d(28, SerialDate.FEBRUARY, 1903)));
        }

        [Test]
        public void TestGetPreviousDayOfWeek()
        {
            Assert.AreEqual(d(24, SerialDate.FEBRUARY, 2006), SerialDate.GetPreviousDayOfWeek(SerialDate.FRIDAY, d(1, SerialDate.MARCH, 2006)));
            Assert.AreEqual(d(22, SerialDate.FEBRUARY, 2006), SerialDate.GetPreviousDayOfWeek(SerialDate.WEDNESDAY, d(1, SerialDate.MARCH, 2006)));
            Assert.AreEqual(d(29, SerialDate.FEBRUARY, 2004), SerialDate.GetPreviousDayOfWeek(SerialDate.SUNDAY, d(3, SerialDate.MARCH, 2004)));
            Assert.AreEqual(d(29, SerialDate.DECEMBER, 2004), SerialDate.GetPreviousDayOfWeek(SerialDate.WEDNESDAY, d(5, SerialDate.JANUARY, 2005)));

            try
            {
                SerialDate.GetPreviousDayOfWeek(-1, d(1, SerialDate.JANUARY, 2006));
                Assert.Fail("Invalid day of week code should throw exception");
            }
            catch (ArgumentException e)
            {

            }
        }

        [Test]
        public void TestGetFollowingDayOfWeek()
        {
            Assert.AreEqual(d(1, SerialDate.JANUARY, 2005), SerialDate.GetFollowingDayOfWeek(SerialDate.SATURDAY, d(25, SerialDate.DECEMBER, 2004)));
            Assert.AreEqual(d(1, SerialDate.JANUARY, 2005), SerialDate.GetFollowingDayOfWeek(SerialDate.SATURDAY, d(26, SerialDate.DECEMBER, 2004)));
            Assert.AreEqual(d(3, SerialDate.MARCH, 2004), SerialDate.GetFollowingDayOfWeek(SerialDate.WEDNESDAY, d(28, SerialDate.FEBRUARY, 2004)));

            try
            {
                SerialDate.GetFollowingDayOfWeek(-1, d(1, SerialDate.JANUARY, 2006));
                Assert.Fail("Invalid day of week code should throw exception");
            }
            catch (ArgumentException e)
            {

            }
        }

        [Test]
        public void TestGetNearestDayOfWeek()
        {
            Assert.AreEqual(d(16, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.SUNDAY, d(16, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(16, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.SUNDAY, d(17, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(16, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.SUNDAY, d(18, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(16, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.SUNDAY, d(19, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(23, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.SUNDAY, d(20, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(23, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.SUNDAY, d(21, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(23, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.SUNDAY, d(22, SerialDate.APRIL, 2006)));

            Assert.AreEqual(d(17, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.MONDAY, d(16, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(17, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.MONDAY, d(17, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(17, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.MONDAY, d(18, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(17, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.MONDAY, d(19, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(17, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.MONDAY, d(20, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(24, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.MONDAY, d(21, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(24, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.MONDAY, d(22, SerialDate.APRIL, 2006)));

            Assert.AreEqual(d(18, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.TUESDAY, d(16, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(18, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.TUESDAY, d(17, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(18, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.TUESDAY, d(18, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(18, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.TUESDAY, d(19, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(18, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.TUESDAY, d(20, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(18, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.TUESDAY, d(21, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(25, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.TUESDAY, d(22, SerialDate.APRIL, 2006)));

            Assert.AreEqual(d(19, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.WEDNESDAY, d(16, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(19, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.WEDNESDAY, d(17, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(19, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.WEDNESDAY, d(18, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(19, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.WEDNESDAY, d(19, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(19, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.WEDNESDAY, d(20, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(19, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.WEDNESDAY, d(21, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(19, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.WEDNESDAY, d(22, SerialDate.APRIL, 2006)));

            Assert.AreEqual(d(13, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.THURSDAY, d(16, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(20, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.THURSDAY, d(17, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(20, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.THURSDAY, d(18, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(20, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.THURSDAY, d(19, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(20, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.THURSDAY, d(20, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(20, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.THURSDAY, d(21, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(20, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.THURSDAY, d(22, SerialDate.APRIL, 2006)));

            Assert.AreEqual(d(14, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.FRIDAY, d(16, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(14, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.FRIDAY, d(17, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(21, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.FRIDAY, d(18, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(21, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.FRIDAY, d(19, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(21, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.FRIDAY, d(20, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(21, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.FRIDAY, d(21, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(21, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.FRIDAY, d(22, SerialDate.APRIL, 2006)));

            Assert.AreEqual(d(15, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.SATURDAY, d(16, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(15, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.SATURDAY, d(17, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(15, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.SATURDAY, d(18, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(22, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.SATURDAY, d(19, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(22, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.SATURDAY, d(20, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(22, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.SATURDAY, d(21, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(22, SerialDate.APRIL, 2006), SerialDate.GetNearestDayOfWeek(SerialDate.SATURDAY, d(22, SerialDate.APRIL, 2006)));

            try
            {
                SerialDate.GetNearestDayOfWeek(-1, d(1, SerialDate.JANUARY, 2006));
                Assert.Fail("Invalid day of week code should throw exception");
            }
            catch (ArgumentException e)
            {

            }
        }

        [Test]
        public void TestEndOfCurrentMonth()
        {
            SerialDate date = SerialDate.CreateInstance(2);
            Assert.AreEqual(d(31, SerialDate.JANUARY, 2006), date.GetEndOfCurrentMonth(d(1, SerialDate.JANUARY, 2006)));
            Assert.AreEqual(d(28, SerialDate.FEBRUARY, 2006), date.GetEndOfCurrentMonth(d(1, SerialDate.FEBRUARY, 2006)));
            Assert.AreEqual(d(31, SerialDate.MARCH, 2006), date.GetEndOfCurrentMonth(d(1, SerialDate.MARCH, 2006)));
            Assert.AreEqual(d(30, SerialDate.APRIL, 2006), date.GetEndOfCurrentMonth(d(1, SerialDate.APRIL, 2006)));
            Assert.AreEqual(d(31, SerialDate.MAY, 2006), date.GetEndOfCurrentMonth(d(1, SerialDate.MAY, 2006)));
            Assert.AreEqual(d(30, SerialDate.JUNE, 2006), date.GetEndOfCurrentMonth(d(1, SerialDate.JUNE, 2006)));
            Assert.AreEqual(d(31, SerialDate.JULY, 2006), date.GetEndOfCurrentMonth(d(1, SerialDate.JULY, 2006)));
            Assert.AreEqual(d(31, SerialDate.AUGUST, 2006), date.GetEndOfCurrentMonth(d(1, SerialDate.AUGUST, 2006)));
            Assert.AreEqual(d(30, SerialDate.SEPTEMBER, 2006), date.GetEndOfCurrentMonth(d(1, SerialDate.SEPTEMBER, 2006)));
            Assert.AreEqual(d(31, SerialDate.OCTOBER, 2006), date.GetEndOfCurrentMonth(d(1, SerialDate.OCTOBER, 2006)));
            Assert.AreEqual(d(30, SerialDate.NOVEMBER, 2006), date.GetEndOfCurrentMonth(d(1, SerialDate.NOVEMBER, 2006)));
            Assert.AreEqual(d(31, SerialDate.DECEMBER, 2006), date.GetEndOfCurrentMonth(d(1, SerialDate.DECEMBER, 2006)));
            Assert.AreEqual(d(29, SerialDate.FEBRUARY, 2008), date.GetEndOfCurrentMonth(d(1, SerialDate.FEBRUARY, 2008)));
        }

        [Test]
        public void TestWeekInMonthToString()
        {
            Assert.AreEqual("First", SerialDate.WeekInMonthToString(SerialDate.FIRST_WEEK_IN_MONTH));
            Assert.AreEqual("Second", SerialDate.WeekInMonthToString(SerialDate.SECOND_WEEK_IN_MONTH));
            Assert.AreEqual("Third", SerialDate.WeekInMonthToString(SerialDate.THIRD_WEEK_IN_MONTH));
            Assert.AreEqual("Fourth", SerialDate.WeekInMonthToString(SerialDate.FOURTH_WEEK_IN_MONTH));
            Assert.AreEqual("Last", SerialDate.WeekInMonthToString(SerialDate.LAST_WEEK_IN_MONTH));

            try
            {
                SerialDate.WeekInMonthToString(-1);
                Assert.Fail("Invalid week code should throw exception");
            }
            catch (ArgumentException e)
            {

            }
        }

        [Test]
        public void TestRelativeToString()
        {
            Assert.AreEqual("Preceding", SerialDate.RelativeToString(SerialDate.PRECEDING));
            Assert.AreEqual("Nearest", SerialDate.RelativeToString(SerialDate.NEAREST));
            Assert.AreEqual("Following", SerialDate.RelativeToString(SerialDate.FOLLOWING));

            try
            {
                SerialDate.RelativeToString(-1000);
                Assert.Fail("Invalid relative code should throw exception");
            }
            catch (ArgumentException e)
            {

            }
        }

        [Test]
        public void TestCreateInstanceFromDDMMYYY()
        {
            SerialDate date = SerialDate.CreateInstance(1, SerialDate.JANUARY, 1900);
            Assert.AreEqual(1, date.GetDayOfMonth());
            Assert.AreEqual(SerialDate.JANUARY, date.GetMonth());
            Assert.AreEqual(1900, date.GetYYYY());
            Assert.AreEqual(2, date.ToSerial());
        }

        [Test]
        public void TestCreateInstanceFromSerial()
        {
            Assert.AreEqual(d(1, SerialDate.JANUARY, 1900), SerialDate.CreateInstance(2));
            Assert.AreEqual(d(1, SerialDate.JANUARY, 1901), SerialDate.CreateInstance(367));
        }

        /*[Test]
        public void TestCreateInstanceFromJavaDate()
        {
            Assert.AreEqual(d(1, SerialDate.JANUARY, 1900), SerialDate.CreateInstance(new DateTime(1900, 1, 1)));
            Assert.AreEqual(d(1, SerialDate.JANUARY, 2006), SerialDate.CreateInstance(new DateTime(2006, 1, 1)));
        }*/
    }
}