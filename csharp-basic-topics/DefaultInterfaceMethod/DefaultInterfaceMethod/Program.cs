namespace DefaultInterfaceMethod
{
    public class Program
    {
        static void Main(string[] args)
        {
            IYearCalendar calYear = new MyYearCalendar();
            calYear.Date = DateTime.Now.Date;
            Console.WriteLine(calYear.ShowMessage());

            IMonthCalendar calMonth = new MyMonthCalendar();
            calMonth.Date = DateTime.Now.Date;
            Console.WriteLine(calMonth.ShowMessage());

            ICalendar cal = new MyCalendar();
            cal.Date = DateTime.Now.Date;
            Console.WriteLine(cal.ShowMessage());

            Console.ReadLine();
        }
    }
}