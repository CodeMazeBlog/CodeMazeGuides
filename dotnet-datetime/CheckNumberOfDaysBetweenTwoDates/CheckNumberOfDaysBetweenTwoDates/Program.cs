using CheckNumberOfDaysBetweenTwoDates;

// Days until summer vacation
var summerVacationStart = new DateTime(2024, 6, 1);
var currentDate = new DateTime(2024, 1, 13);

int daysUntilVacation = NumberOfDaysBetweenTwoDates.CalculateDaysUntilVacation(summerVacationStart, currentDate);
Console.WriteLine($"Days until summer vacation: {daysUntilVacation}");

// Time of day
var currentDateAndTime = new DateTime(2024, 1, 13, 18, 0, 0);
TimeSpan untilVacation = summerVacationStart - currentDateAndTime;
Console.WriteLine($"Days: {untilVacation.Days}, TotalDays: {untilVacation.TotalDays}");
Console.WriteLine($"Calendar days: {(summerVacationStart.Date - currentDateAndTime.Date).Days}");

// DateOnly
var vacationStart = new DateOnly(2024, 6, 1);
var today = new DateOnly(2024, 1, 13);

int daysBetween = NumberOfDaysBetweenTwoDates.CalculateDaysBetweenDates(today, vacationStart);
Console.WriteLine($"Days between {today:yyyy-MM-dd} and {vacationStart:yyyy-MM-dd}: {daysBetween}");

// Days until an event in New York
var newYork = TimeZoneInfo.FindSystemTimeZoneById("America/New_York");
var eventLocalTime = new DateTime(2024, 9, 1, 10, 0, 0);
var eventDateTime = new DateTimeOffset(eventLocalTime, newYork.GetUtcOffset(eventLocalTime));
var currentDateTime = new DateTimeOffset(2024, 1, 13, 18, 0, 0, TimeSpan.FromHours(1));

Console.WriteLine($"Event offset: {eventDateTime.Offset}");

int daysUntilEvent = NumberOfDaysBetweenTwoDates.CalculateDaysUntilEvent(eventDateTime, currentDateTime);
Console.WriteLine($"Days until the event: {daysUntilEvent}");

// Daylight saving time
var beforeChange = new DateTimeOffset(2024, 3, 9, 12, 0, 0, TimeSpan.FromHours(-5));
var afterChange = new DateTimeOffset(2024, 3, 10, 12, 0, 0, TimeSpan.FromHours(-4));
TimeSpan offsetDifference = afterChange - beforeChange;
Console.WriteLine($"DateTimeOffset: {offsetDifference.TotalHours} hours, Days = {offsetDifference.Days}");

var localBefore = new DateTime(2024, 3, 9, 12, 0, 0);
var localAfter = new DateTime(2024, 3, 10, 12, 0, 0);
TimeSpan localDifference = localAfter - localBefore;
Console.WriteLine($"DateTime: {localDifference.TotalHours} hours, Days = {localDifference.Days}");
