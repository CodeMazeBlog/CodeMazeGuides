namespace DefaultInterfaceMethod
{
    public class MyMonthCalendar : IMonthCalendar
    {
        private DateTime _date;

        DateTime ICalendar.Date { get => _date; set => _date = value; }
    }
}
