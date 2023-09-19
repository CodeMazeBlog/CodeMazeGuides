using System.Timers;
using Timer = System.Timers.Timer;

namespace TestingTimeDependentCodeWithTimeProvider;

public class DiscountService : IDiscountService
{
    private readonly ITimer _timer;
    private readonly TimeProvider _timeProvider;

    public int InvocationCount { get; private set; } = 0;

    public DiscountService(TimeProvider timeProvider)
    {
        _timeProvider = timeProvider;

        _timer = _timeProvider.CreateTimer(
            _ => InvocationCount++,
            state: null,
            dueTime: TimeSpan.FromSeconds(5),
            period: TimeSpan.FromMinutes(5));
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
