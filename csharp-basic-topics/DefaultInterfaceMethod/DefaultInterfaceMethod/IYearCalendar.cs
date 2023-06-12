namespace DefaultInterfaceMethod
{
    public interface IYearCalendar : ICalendar
    {
        public bool IsLeapYear()
        {
            if (Date.Year % 400 == 0)
                return true;
            if (Date.Year % 100 == 0)
                return false;
            if (Date.Year % 4 == 0)
                return true;

            return false;
        }

        string ICalendar.ShowMessage()
        {
            if (IsLeapYear())
                return $"{Date} is a leap year";
            else
                return $"{Date} is not a leap year";
        }

    }
}
