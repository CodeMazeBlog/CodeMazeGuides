using NodaTime;

var currentInstant = SystemClock.Instance.GetCurrentInstant();

Console.WriteLine($"Current Instant: {currentInstant}");