namespace DefaultInterfaceMethod
{
    public interface IMonthCalendar : ICalendar
    {
        public bool Is31DaysMonth()
        {
            if (DateTime.DaysInMonth(Date.Year, Date.Month) > 30)
                return true;

            return false;
        }

        string ICalendar.ShowMessage()
        {
            if (Is31DaysMonth())
                return $"{Date} has 31 days";
            else
                return $"{Date} does not has 31 days";
        }
    }
}
