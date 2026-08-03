namespace DefaultInterfaceMethod
{
    public class MyYearCalendar : IYearCalendar
    {
        private DateTime _date;

        DateTime ICalendar.Date { get => _date; set => _date = value; }
    }
}
