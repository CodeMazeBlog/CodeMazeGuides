using System;

namespace DefaultInterfaceMethod
{
    public class Program
    {
        static void Main(string[] args)
        {
            ICalendar calYear = new MyYearCalendar();
            calYear.date = DateTime.Now.Date;
            Console.WriteLine(calYear.ShowMessage());

            ICalendar calMonth = new MyMonthCalendar();
            calMonth.date = DateTime.Now.Date;
            Console.WriteLine(calMonth.ShowMessage());

            ICalendar cal = new MyCalendar();
            cal.date = DateTime.Now.Date;
            Console.WriteLine(cal.ShowMessage());
            Console.ReadLine();
        }
    }
}