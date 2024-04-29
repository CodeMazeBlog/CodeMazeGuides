using System.Globalization;

namespace CheckIfDateIsLessThanOrEqualToToday;

public class DateComparer
{
    private readonly DateOnly _todayDate;
    private readonly DateOnly _dateToCheck;
    private readonly DateTime _todayDateTime;
    private readonly DateTime _dateTimeToCheck;

    public DateComparer(string dateString = "01/01/2024")
    {
        _todayDate = DateOnly.FromDateTime(DateTime.Today);
        if (!DateOnly.TryParseExact(dateString, "MM/dd/yyyy",
            CultureInfo.InvariantCulture, DateTimeStyles.None, out _dateToCheck))
        {
            // Handle a case where the input date string is invalid
        }

        _todayDateTime = _todayDate.ToDateTime(TimeOnly.MinValue);
        _dateTimeToCheck = _dateToCheck.ToDateTime(TimeOnly.MinValue);
    }

    public bool CheckWithComparisonOperator() => _dateToCheck <= _todayDate;

    public bool CheckWithCompareTo() => _dateToCheck.CompareTo(_todayDate) <= 0;

    public bool CheckWithDayNumber() => _dateToCheck.DayNumber <= _todayDate.DayNumber;

    public bool CheckWithTimeSpan()
    {
        TimeSpan timeDifference = _dateTimeToCheck - _todayDateTime;

        return timeDifference.TotalDays <= 0;
    }
}