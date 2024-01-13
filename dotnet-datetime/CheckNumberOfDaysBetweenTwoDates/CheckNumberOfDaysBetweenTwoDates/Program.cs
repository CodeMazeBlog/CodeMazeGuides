using CheckNumberOfDaysBetweenTwoDates;
class Program
{
    static void Main()
    {
        DateTime summerVacationStart = new DateTime(2024, 6, 1);

        int daysUntilVacation = NumberOfDaysBetweenTwoDates.CalculateDaysUntilVacation(summerVacationStart);
        Console.WriteLine($"Days until summer vacation: {daysUntilVacation}");

        DateTimeOffset eventDateTime = new DateTimeOffset(2024, 9, 1, 10, 0, 0, new TimeSpan(-5, 0, 0));
        DateTimeOffset currentDateTime = DateTimeOffset.Now;

        int daysUntilEvent = DifferentTimeZone.CalculateDaysUntilEvent(eventDateTime, currentDateTime);
        Console.WriteLine($"Days until the event: {daysUntilEvent}");
    }
}