using CheckNumberOfMonthsBetweenTwoDates;

var subscriptionStart = new DateTime(2023, 5, 14);
var endDate = DateTime.Today;

int totalMonthsSubscribed = NumberOfMonthsBetweenTwoDates.CalculateSubscriptionDuration(subscriptionStart, endDate);
Console.WriteLine($"User has been subscribed for {totalMonthsSubscribed} months.");

var courseStart = new DateTime(2023, 9, 12);

double courseDuration = NumberOfMonthsBetweenTwoDates.CalculateCourseDuration(courseStart, endDate);
Console.WriteLine($"This course has been online for {courseDuration:F2} months.");
