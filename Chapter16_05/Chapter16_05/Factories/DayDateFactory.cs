using Chapter16_05.Enums;
using System;

namespace Chapter16_05.Factories
{
    public abstract class DayDateFactory
    {
        private static DayDateFactory factory = new SpreadsheetDateFactory();

        public static void setInstance(DayDateFactory factory)
        {
            DayDateFactory.factory = factory;
        }

        protected abstract DayDate _makeDate(int ordinal);
        protected abstract DayDate _makeDate(int day, Month month, int year);
        protected abstract DayDate _makeDate(int day, int month, int year);
        protected abstract DayDate _makeDate(DateTime date);
        protected abstract int _getMinimumYear();
        protected abstract int _getMaximumYear();

        public static DayDate makeDate(int ordinal) => factory._makeDate(ordinal);
        public static DayDate makeDate(int day, Month month, int year) => factory._makeDate(day, month, year);
        public static DayDate makeDate(int day, int month, int year) => factory._makeDate(day, month, year);
        public static DayDate makeDate(DateTime date) => factory._makeDate(date);
        public static int GetMinimumYear() => factory._getMinimumYear();
        public static int GetMaximumYear() => factory._getMaximumYear();
    }
}
