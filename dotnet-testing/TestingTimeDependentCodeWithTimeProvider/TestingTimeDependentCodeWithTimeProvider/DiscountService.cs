using System;
using System.Threading;

namespace TestingTimeDependentCodeWithTimeProvider;

public class DiscountService : IDiscountService, IDisposable
{
    private readonly ITimer _timer;
    private readonly TimeProvider _timeProvider;
    private double _specialDiscount = 0;
    private bool _disposed = false;

    public double SpecialDiscount
    { 
        get => _specialDiscount;
        set => _specialDiscount = value;
    }

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

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if(_disposed) return;

        if(disposing)
        {
            _timer?.Dispose();
        }

        _disposed = true;
    }

    private void UpdateSpecialDiscount()
    {
        var timeOfDay = _timeProvider.GetUtcNow().TimeOfDay;

        if (timeOfDay < TimeSpan.FromHours(6))
        {
            Interlocked.Exchange(ref _specialDiscount, 5);
        }
        else if (timeOfDay >= TimeSpan.FromHours(6) &&
                 timeOfDay < TimeSpan.FromHours(12))
        {
            Interlocked.Exchange(ref _specialDiscount, 4);
        }
        else if (timeOfDay >= TimeSpan.FromHours(12) &&
                 timeOfDay < TimeSpan.FromHours(18))
        {
            Interlocked.Exchange(ref _specialDiscount, 3);
        }
        else
        {
            Interlocked.Exchange(ref _specialDiscount, 2);
        }
    }
}
