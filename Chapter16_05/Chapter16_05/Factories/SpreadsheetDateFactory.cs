using Chapter16_05.Enums;
using System;

namespace Chapter16_05.Factories
{
    internal class SpreadsheetDateFactory : DayDateFactory
    {
        protected override DayDate _makeDate(int ordinal) => new SpreadsheetDate(ordinal);
        protected override DayDate _makeDate(int day, Month month, int year) => new SpreadsheetDate(day, month, year);
        protected override DayDate _makeDate(int day, int month, int year) => new SpreadsheetDate(day, MonthExtensions.Make(month), year);
        protected override DayDate _makeDate(DateTime date) => new SpreadsheetDate(date.Day, MonthExtensions.Make(date.Month + 1), date.Year);
        protected override int _getMinimumYear() => SpreadsheetDate.MINIMUM_YEAR_SUPPORTED;
        protected override int _getMaximumYear() => SpreadsheetDate.MAXIMUM_YEAR_SUPPORTED;
    }
}
