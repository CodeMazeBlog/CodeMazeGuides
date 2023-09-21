namespace TestingTimeDependentCodeWithTimeProvider;

public class DiscountService : IDiscountService
{
    private readonly ITimer _timer;
    private readonly TimeProvider _timeProvider;

    public double SpecialDiscount { get; private set; } = 0;

    public DiscountService(TimeProvider timeProvider)
    {
        _timeProvider = timeProvider;

        _timer = _timeProvider.CreateTimer(
            _ => UpdateSpecialDiscount(),
            state: null,
            dueTime: TimeSpan.FromSeconds(5),
            period: TimeSpan.FromHours(1));
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

    private void UpdateSpecialDiscount()
    {
        var timeOfDay = _timeProvider.GetUtcNow().TimeOfDay;

        if (timeOfDay < TimeSpan.FromHours(6))
        {
            SpecialDiscount = 5;
        }
        else if (timeOfDay >= TimeSpan.FromHours(6) &&
                 timeOfDay < TimeSpan.FromHours(12))
        {
            SpecialDiscount = 4;
        }
        else if (timeOfDay >= TimeSpan.FromHours(12) &&
                 timeOfDay < TimeSpan.FromHours(18))
        {
            SpecialDiscount = 3;
        }
        else
        {
            SpecialDiscount = 2;
        }
    }
}
