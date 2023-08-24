namespace CompareDateTimeInCSharp
{
    public class Examples
    {
        public static bool IsDateInSameTimeZone()
        {
            var firstDate = new DateTime(2021, 05, 06, 12, 0, 0, DateTimeKind.Local);
            var secondDate = new DateTime(2021, 05, 06, 12, 0, 0, DateTimeKind.Utc);
            var firstDateAsUtc = firstDate.ToUniversalTime();

            if (firstDateAsUtc.Equals(secondDate))
            {
                return true;
            }

            return false;
        }

        public static bool IsDatePrecisionSame()
        {
            var firstDate = new DateTime(2021, 05, 06, 12, 0, 0);
            var secondDate = new DateTime(2021, 05, 06, 12, 0, 0, 500);

            if (firstDate == secondDate)
            {
                return true;
            }

            return false;
        }
    }
}
