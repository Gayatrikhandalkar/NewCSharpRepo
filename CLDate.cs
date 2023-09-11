
using System.Globalization;

namespace SeleniumTestProject.Utilities
{
    public static class CLDate
    {
        public static String GenerateTodayDateWithFormat(String dateFormat)
        {
            return DateTime.Now.ToString(dateFormat, CultureInfo.InvariantCulture);
        }

        public static String FutureDateGenerator(int daysToAdd, String format)
        {
            DateTime today = DateTime.Now;
            DateTime date = today.AddDays(daysToAdd);
            return date.ToString(format);
        }
        public static String PastDateGeneration(int daysFromAdd, String format)
        {
            DateTime today = DateTime.Now;
            DateTime date = today.AddDays(daysFromAdd);
            return date.ToString(format, CultureInfo.InvariantCulture);
        }
    }
}
