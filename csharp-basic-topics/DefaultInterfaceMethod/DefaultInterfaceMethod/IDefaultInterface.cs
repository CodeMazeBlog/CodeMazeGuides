using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultInterfaceMethod
{
    public interface ICalendar
    {
        public DateTime date { get; set; }
        public string ShowMessage()
        {
            return "Default Calendar";
        }
    }
    public interface IYearCalendar : ICalendar
    {
        public bool IsLeapYear()
        {
            if (date.Year % 400 == 0)
                return true;
            if (date.Year % 100 == 0)
                return false;
            if (date.Year % 4 == 0)
                return true;

            return false;
        }
        string ICalendar.ShowMessage()
        {
            if (IsLeapYear())
                return $"{date} is a leap year";
            else
                return $"{date} is not a leap year";
        }

    }
    public interface IMonthCalendar : ICalendar
    {
        public bool Is31DaysMonth()
        {
            if (DateTime.DaysInMonth(date.Year, date.Month) > 30)
                return true;

            return false;
        }
        string ICalendar.ShowMessage()
        {
            if (Is31DaysMonth())
                return $"{date} has 31 days";
            else
                return $"{date} does not has 31 days";
        }

    }
    public class MyYearCalendar : IYearCalendar
    {
        public DateTime date;
        DateTime ICalendar.date { get => date; set => date = value; }
    }
    public class MyMonthCalendar : IMonthCalendar
    {
        public DateTime date;
        DateTime ICalendar.date { get => date; set => date = value; }
    }
    public class MyCalendar : IYearCalendar, IMonthCalendar
    {
        public DateTime date;
        DateTime ICalendar.date { get => date; set => date = value; }

        public string ShowMessage()
        {
            return $"Today is {date}";
        }
    }
}
