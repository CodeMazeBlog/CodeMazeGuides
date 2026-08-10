namespace CompareDateTimeInCSharp
{
    public class Examples
    {
        public static bool IsDateInSameTimeZone()
        {
            var firstDate = new DateTime(2021, 05, 06, 12, 0, 0, DateTimeKind.Local);
            var secondDate = new DateTime(2021, 05, 06, 12, 0, 0, DateTimeKind.Utc);
            var firstDateAsUtc = firstDate.ToUniversalTime();

            return firstDateAsUtc.Equals(secondDate);
        }

        public static bool IsDatePrecisionSame()
        {
            var firstDate = new DateTime(2021, 05, 06, 12, 0, 0);
            var secondDate = new DateTime(2021, 05, 06, 12, 0, 0, 500);

            return firstDate == secondDate;
        }

        public static (bool AreClose, bool SameDay, bool SameDayViaDateOnly) CompareWithTolerance()
        {
            var firstDate = new DateTime(2021, 05, 06, 12, 0, 0);
            var secondDate = new DateTime(2021, 05, 06, 12, 0, 0, 500);

            var tolerance = TimeSpan.FromMilliseconds(1);
            var areClose = (firstDate - secondDate).Duration() <= tolerance;

            var sameDay = firstDate.Date == secondDate.Date;
            var sameDayViaDateOnly = DateOnly.FromDateTime(firstDate) == DateOnly.FromDateTime(secondDate);

            return (areClose, sameDay, sameDayViaDateOnly);
        }
    }
}
