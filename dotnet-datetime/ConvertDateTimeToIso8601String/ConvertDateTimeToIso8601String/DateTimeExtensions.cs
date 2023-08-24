using System.Globalization;
using System.Text.RegularExpressions;

namespace ConvertDateTimeToIso8601String
{
    public static class DateTimeExtensions
    {
        public static string ToUniversalIso8601(this DateTime dateTime)
        {
            return dateTime.ToUniversalTime().ToString("u").Replace(" ", "T");
        }

        public static string ToShortIso8601WeekDateString(this DateTime dateTime, bool useSeparator = true) 
        { 
            var separator = useSeparator ? "-" : string.Empty; 
            var culture = CultureInfo.InvariantCulture; 
            var format = culture.DateTimeFormat; 

            var weekOfYear = culture.Calendar.GetWeekOfYear(dateTime, format.CalendarWeekRule, format.FirstDayOfWeek);
            var weekPlaceHolder = $"{weekOfYear}".PadLeft(2, '0');

            return $"{dateTime.Year}{separator}W{weekPlaceHolder}"; 
        }

        public static string ToExtendedIso8601WeekDateString(this DateTime dateTime, bool useSeparator = true) 
        { 
            var separator = useSeparator ? "-" : string.Empty; 

            return $"{dateTime.ToShortIso8601WeekDateString(useSeparator)}{separator}{(int)dateTime.DayOfWeek}"; 
        }

        public static string ToIso8601OrdinalDateString(this DateTime dateTime, bool useSeparator = true) 
        { 
            var separator = useSeparator ? "-" : string.Empty; 
            var dayPlaceHolder = $"{dateTime.DayOfYear}".PadLeft(3, '0');
            
            return $"{dateTime.Year}{separator}{dayPlaceHolder}"; 
        }
    }
}