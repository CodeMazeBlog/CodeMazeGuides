// See https://aka.ms/new-console-template for more information
public class SystemDateTimeProvider : IDateTimeProvider
{
    public DateTime GetDateTimeUTC()
        => DateTime.UtcNow;
}
