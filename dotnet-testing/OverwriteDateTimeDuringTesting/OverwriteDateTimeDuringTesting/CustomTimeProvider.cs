using OverwriteDateTimeDuringTesting.Abstractions;

namespace OverwriteDateTimeDuringTesting;

public class CustomTimeProvider : ICustomTimeProvider
{
    public DateTime Now => DateTime.Now;
}
