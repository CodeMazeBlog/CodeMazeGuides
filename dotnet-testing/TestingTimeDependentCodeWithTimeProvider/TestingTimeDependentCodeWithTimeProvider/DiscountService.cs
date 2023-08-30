namespace TestingTimeDependentCodeWithTimeProvider;

public class DiscountService : IDiscountService
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public DiscountService(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public double CalculateDiscount()
    {
        var now = _dateTimeProvider.UtcNow;

        return now.DayOfWeek switch
        {
            DayOfWeek.Monday => 1,
            DayOfWeek.Tuesday => 2,
            DayOfWeek.Wednesday => 3,
            DayOfWeek.Thursday => 4,
            DayOfWeek.Friday => 5,
            DayOfWeek.Saturday => 6,
            DayOfWeek.Sunday => 7,
            _ => 0
        };
    }
}
