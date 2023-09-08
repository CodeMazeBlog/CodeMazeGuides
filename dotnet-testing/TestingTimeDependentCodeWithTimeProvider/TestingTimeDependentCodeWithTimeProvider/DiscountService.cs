namespace TestingTimeDependentCodeWithTimeProvider;

public class DiscountService : IDiscountService
{
    private readonly TimeProvider _timeProvider;

    public DiscountService(TimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }

    public double CalculateDiscount()
    {
        var now = _timeProvider.GetUtcNow();
        
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
