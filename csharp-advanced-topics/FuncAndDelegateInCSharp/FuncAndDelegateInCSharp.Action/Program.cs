using System;
using System.Threading;

namespace FuncAndDelegateInCSharp.Action
{
    class Program
    {

        static void Main(string[] args)
        {
            Action<TimeZoneInfo> format = GetDate;
            format(TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            Thread.Sleep(2000);
            format(TimeZoneInfo.FindSystemTimeZoneById("UTC"));
           



        }

        static void GetDate(TimeZoneInfo zone)
        {
            DateTime date = TimeZoneInfo.ConvertTime(DateTime.Now, zone);
            Console.WriteLine($"The date in time zone {zone.DisplayName} is: {date.ToString("yyyy-MM-dd HH:mm")}");
        }
    }
}
