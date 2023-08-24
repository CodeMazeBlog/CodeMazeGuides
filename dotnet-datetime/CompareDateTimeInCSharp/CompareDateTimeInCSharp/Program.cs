namespace CompareDateTimeInCSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //DateTime Comparison using Compare() method
            var firstDate = new DateTime(2023, 5, 1);
            var secondDate = new DateTime(2023, 5, 2);

            var result = DateTime.Compare(firstDate, secondDate);

            ShowResult(firstDate, secondDate, result);

            //DateTime Comparison using CompareTo(DateTime) method
            result = firstDate.CompareTo(secondDate);

            ShowResult(firstDate, secondDate, result);

            //DateTime Comparison using CompareTo(object) method
            object objectDateTime = new DateTime(2023, 5, 3);
            result = firstDate.CompareTo(objectDateTime);

            ShowResult(firstDate, Convert.ToDateTime(objectDateTime), result);

            //DateTime Comparison using Equals(DateTime) method
            DateTimeComparisonWithEquals(firstDate, secondDate);

            //DateTime Comparison using Relational Operators
            DateTimeComparisonWithRelationalOperator(firstDate, secondDate);

            // Comparing DateTime objects in a specific time zone
            var isDateInSameTimeZone = Examples.IsDateInSameTimeZone();
            if (isDateInSameTimeZone)
            {
                Console.WriteLine("All dates are in same timezone.");
            }

            // Using relational operators to compare DateTime objects with precision issues
            var isDatePrecisionSame = Examples.IsDatePrecisionSame();
            if (isDatePrecisionSame)
            {
                Console.WriteLine("All dates are same.");
            }
            else
            {
                Console.WriteLine("Date precisions are different.");
            }
        }

        private static void ShowResult(DateTime firstDate, DateTime secondDate, int result)
        {
            if (result < 0)
            {
                Console.WriteLine($"{firstDate} is earlier than {secondDate}");
            }
            else if (result == 0)
            {
                Console.WriteLine($"{firstDate} is the same as {secondDate}");
            }
            else
            {
                Console.WriteLine($"{firstDate} is later than {secondDate}");
            }
        }

        private static void DateTimeComparisonWithRelationalOperator(DateTime firstDate, DateTime secondDate)
        {
            if (firstDate < secondDate)
            {
                Console.WriteLine($"{firstDate} is earlier than {secondDate}");
            }
            else if (firstDate > secondDate)
            {
                Console.WriteLine($"{firstDate} is later than {secondDate}");
            }
            else
            {
                Console.WriteLine($"{firstDate} is the same as {secondDate}");
            }
        }

        private static void DateTimeComparisonWithEquals(DateTime firstDate, DateTime secondDate)
        {
            if (firstDate.Equals(secondDate))
            {
                Console.WriteLine($"{firstDate} is the same as {secondDate}");
            }
            else
            {
                Console.WriteLine($"{firstDate} is not the same as {secondDate}");
            }
        }
    }
}