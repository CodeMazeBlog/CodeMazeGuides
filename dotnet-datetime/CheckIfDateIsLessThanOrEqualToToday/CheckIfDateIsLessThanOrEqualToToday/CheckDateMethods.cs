using System.Globalization;

namespace CheckIfDateIsLessThanOrEqualToToday;

public class CheckDateMethods
{
    public readonly DateTime _dateToCheck;

    public CheckDateMethods(string dateString = "01/01/2024")
    {
        if (!DateTime.TryParseExact(dateString, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _dateToCheck))
        {
            // Handle a case where the input date string is invalid
        }
    }

    public bool CheckWithComparisonOperator() => _dateToCheck <= DateTime.Today;

    public bool CheckWithCompareTo() => _dateToCheck.CompareTo(DateTime.Today) <= 0;

    public bool CheckWithCompare() => DateTime.Compare(_dateToCheck, DateTime.Today) <= 0;

    public bool CheckWithTimeSpan()
    {
        TimeSpan timeDifference = _dateToCheck - DateTime.Today;

        return timeDifference.TotalDays <= 0;
    }

    public bool CheckWithLINQ() => new List<DateTime> { _dateToCheck }.Any(d => d <= DateTime.Today);
}