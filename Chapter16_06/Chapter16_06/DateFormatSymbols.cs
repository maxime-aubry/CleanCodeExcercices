namespace Chapter16_06
{
    public class DateFormatSymbols
    {
        public string[] getShortWeekdays()
        {
            return new string[]
            {
                "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"
            };
        }

        public string[] getWeekdays()
        {
            return new string[]
            {
                "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
            };
        }

        public string[] getShortMonths()
        {
            return new string[]
            {
                "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
            };
        }

        public string[] getMonths()
        {
            return new string[]
            {
                "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"
            };
        }
    }
}
