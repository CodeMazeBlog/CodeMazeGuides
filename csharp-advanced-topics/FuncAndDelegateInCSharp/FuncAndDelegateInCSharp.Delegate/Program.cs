using System;

namespace FuncAndDelegateInCSharp.Delegate
{
    class Program
    {
        delegate string GetDateByZone(TimeZoneInfo timeZone);
        static void Main(string[] args)
        {
            GetDateByZone format = GetDate;
            Console.WriteLine($"{format(TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"))}");
            Console.WriteLine($"{format(TimeZoneInfo.FindSystemTimeZoneById("UTC"))}");

        }

        static string GetDate(TimeZoneInfo zone)
        {
           DateTime date = TimeZoneInfo.ConvertTime(DateTime.Now, zone);
            return $"The date in time zone {zone.DisplayName} is: {date.ToString("yyyy-MM-dd HH:mm")}";
        }

    }
}
