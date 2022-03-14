namespace Chapter16_06.Enums
{
    public enum DateInterval
    {
        CLOSED,
        CLOSED_LEFT,
        CLOSED_RIGHT,
        OPEN,
    }

    public static class DateIntervalExtensions
    {
        public static bool IsIn(int d, int left, int right) => IsInOpen(d, left, right)
            || IsInClosedLeft(d, left, right)
            || IsInClosedRight(d, left, right)
            || IsInClosed(d, left, right);
        private static bool IsInOpen(int d, int left, int right) => (d > left && d < right);
        private static bool IsInClosedLeft(int d, int left, int right) => (d >= left && d < right);
        private static bool IsInClosedRight(int d, int left, int right) => (d > left && d <= right);
        private static bool IsInClosed(int d, int left, int right) => (d >= left && d <= right);
    }
}
