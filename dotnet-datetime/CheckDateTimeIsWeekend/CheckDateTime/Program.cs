using System.Globalization;
using CheckDateTime;

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

// Checks for Sat-Sun weekends

var date = DateTime.Now;
if (date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
{
    Console.WriteLine("Weekend");
}
else
{
    Console.WriteLine("Workday");
}

date = new DateTime(2021, 10, 10);
if (date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
{
    Console.WriteLine("Weekend");
}
else
{
    Console.WriteLine("Workday");
}

// The same check through the extension method

Console.WriteLine(new DateTime(2021, 10, 10).IsWeekend()); // True
Console.WriteLine(new DateTime(2021, 10, 8).IsWeekend());  // False

// Checks for Fri-Sat weekends

HashSet<DayOfWeek> fridaySaturday = [DayOfWeek.Friday, DayOfWeek.Saturday];

Console.WriteLine(new DateTime(2021, 10, 10).IsWeekend(fridaySaturday)); // False
Console.WriteLine(new DateTime(2021, 10, 8).IsWeekend(fridaySaturday));  // True

// DayOfWeek as a number and as a name

Console.WriteLine((int)DayOfWeek.Sunday);   // 0
Console.WriteLine((int)DayOfWeek.Saturday); // 6

var sunday = new DateTime(2021, 10, 10);
Console.WriteLine(sunday.DayOfWeek);                                   // Sunday
Console.WriteLine(sunday.ToString("dddd", new CultureInfo("de-DE")));  // Sonntag

// Weekday/weekend check with custom date formatting

date = DateTime.Now;
Console.WriteLine($"The date {date:dddd, dd MMMM yyyy} is a {(date.IsWeekend() ? "weekend day" : "workday")}");

date = new DateTime(2021, 10, 10);
Console.WriteLine($"The date {date:dddd, dd MMMM yyyy} is a {(date.IsWeekend() ? "weekend day" : "workday")}");
