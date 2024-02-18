using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace CheckIfDateIsLessThanOrEqualToToday;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class DateComparerBenchmark
{
    private readonly DateComparer _dateComparer;

    public DateComparerBenchmark()
    {
        _dateComparer
            = new DateComparer(DateTime.Today.ToString("MM/dd/yyyy"));
    }

    [Benchmark]
    public bool CheckWithComparisonOperator() =>
        _dateComparer.CheckWithComparisonOperator();

    [Benchmark]
    public bool CheckWithCompareTo() =>
        _dateComparer.CheckWithCompareTo();

    [Benchmark]
    public bool CheckWithDayNumber() =>
        _dateComparer.CheckWithDayNumber();

    [Benchmark]
    public bool CheckWithTimeSpan() =>
        _dateComparer.CheckWithTimeSpan();
}