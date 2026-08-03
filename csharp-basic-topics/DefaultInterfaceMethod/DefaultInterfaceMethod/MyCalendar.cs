using System;

namespace DefaultInterfaceMethod
{
    public class MyCalendar : IYearCalendar, IMonthCalendar
    {
        public DateTime Date { get; set; }

        DateTime ICalendar.Date { get => Date; set => Date = value; }

        public string ShowMessage()
        {
            return $"Today is {Date}";
        }
    }
}
