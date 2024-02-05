using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace CheckIfDateIsLessThanOrEqualToToday;

[MemoryDiagnoser(false)]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class CheckDateMethodsBenchmark
{
    private readonly CheckDateMethods _checkDateMethods;

    public CheckDateMethodsBenchmark()
    {
        _checkDateMethods
            = new CheckDateMethods(DateTime.Today.ToString("MM/dd/yyyy"));
    }

    [Benchmark]
    public bool CheckWithComparisonOperator() =>
        _checkDateMethods.CheckWithComparisonOperator();

    [Benchmark]
    public bool CheckWithCompareTo() =>
        _checkDateMethods.CheckWithCompareTo();

    [Benchmark]
    public bool CheckWithCompare() =>
        _checkDateMethods.CheckWithCompare();

    [Benchmark]
    public bool CheckWithTimeSpan() =>
        _checkDateMethods.CheckWithTimeSpan();

    [Benchmark]
    public bool CheckWithLINQ() =>
        _checkDateMethods.CheckWithLINQ();
}