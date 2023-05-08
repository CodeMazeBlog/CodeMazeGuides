namespace CompareDateTimeInCSharp
{
    public class Examples
    {
        public static bool IsDatePast(DateTime date)
        {
            if (DateTime.Compare(date, DateTime.Now) < 0)
            {
                return true;
            }
            return false;
        }

        public static bool IsDateWithinRange(DateTime date, DateTime startDate, DateTime endDate)
        {
            if (date >= startDate && date <= endDate)
            {
                return true;
            }

            return false;

        }

        public static bool IsDateInFuture(DateTime date)
        {
            if (date.CompareTo(DateTime.Now) > 0)
            {
                return true;
            }
            return false;
        }

        public static bool IsDateInSameTimeZone()
        {
            var firstDate = new DateTime(2021, 05, 06, 12, 0, 0, DateTimeKind.Local);
            var secondDate = new DateTime(2021, 05, 06, 12, 0, 0, DateTimeKind.Utc);
            var firstDateAsUtc = firstDate.ToUniversalTime();
            
            if(firstDateAsUtc.Equals(secondDate))
            {
                return true;
            }
            return false;
        }

        public static bool IsDatePrecisionSame() 
        {
            var firstDate = new DateTime(2021, 05, 06, 12, 0, 0);
            var secondDate = new DateTime(2021, 05, 06, 12, 0, 1);

            if(firstDate == secondDate)
            {
                return true;
            }
            return false;
        }
    }
}
