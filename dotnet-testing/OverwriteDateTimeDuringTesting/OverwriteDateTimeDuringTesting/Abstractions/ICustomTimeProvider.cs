namespace OverwriteDateTimeDuringTesting.Abstractions;

public interface ICustomTimeProvider
{
    DateTime Now { get; }
}
