using CheckNumberOfMonthsBetweenTwoDates;

var subscriptionStart = new DateOnly(2023, 5, 14);
var subscriptionEndDate = DateOnly.FromDateTime(DateTime.Today);

int totalMonthsSubscribed = NumberOfMonthsBetweenTwoDates.CalculateSubscriptionDuration(subscriptionStart, subscriptionEndDate);
Console.WriteLine($"User has been subscribed for {totalMonthsSubscribed} months.");

var courseStart = new DateTime(2023, 9, 12);
var courseEndDate = DateTime.Today;

double courseDuration = NumberOfMonthsBetweenTwoDates.CalculateCourseDuration(courseStart, courseEndDate);
Console.WriteLine($"This course has been online for {courseDuration:F2} months.");