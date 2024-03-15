namespace TestingTimeDependentCodeWithTimeProvider;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
