namespace OverwriteDateTimeDuringTesting.Constants;

public static class Messages
{
    public const string FlightDepartsInMoreThanTwoHours
        = "Flight from {0} to {1} departs in more than 2 hours.";
    public const string FlightDepartsInLessThanTwoHours
        = "Flight from {0} to {1} departs in less than 2 hours.";
    public const string FlightDepartsInLessThanOneHour
        = "Flight from {0} to {0} departs in less than 1 hour.";
    public const string FlightDepartsInLessThanThirtyMinutes
        = "Flight from {0} to {0} departs in less than 30 minutes.";
    public const string FlightAlreadyDeparted
        = "Flight from {0} to {1} has already departed.";
}
