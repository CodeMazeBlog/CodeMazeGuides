using CheckNumberOfDaysBetweenTwoDates;

var summerVacationStart = new DateTime(2024, 6, 1);
var currentDate = DateTime.Today;

int daysUntilVacation = NumberOfDaysBetweenTwoDates.CalculateDaysUntilVacation(summerVacationStart, currentDate);
Console.WriteLine($"Days until summer vacation: {daysUntilVacation}");

var eventDateTime = new DateTimeOffset(2024, 9, 1, 10, 0, 0, new TimeSpan(-5, 0, 0));
var currentDateTime = DateTimeOffset.Now;

int daysUntilEvent = NumberOfDaysBetweenTwoDates.CalculateDaysUntilEvent(eventDateTime, currentDateTime);
Console.WriteLine($"Days until the event: {daysUntilEvent}");
