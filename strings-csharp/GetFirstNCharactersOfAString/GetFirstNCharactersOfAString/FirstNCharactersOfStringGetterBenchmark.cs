using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Order;

namespace GetFirstNCharactersOfAString;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class FirstNCharactersOfStringGetterBenchmark
{
    private readonly FirstNCharactersOfStringGetter _firstNCharactersOfStringGetter;
    private readonly Consumer _consumer;

    public FirstNCharactersOfStringGetterBenchmark()
    {
        _consumer = new Consumer();
        _firstNCharactersOfStringGetter
            = new FirstNCharactersOfStringGetter();
    }

    [Benchmark]
    public ReadOnlySpan<char> UseForLoop()
        => _firstNCharactersOfStringGetter.UseForLoop();

    [Benchmark]
    public ReadOnlySpan<char> UseRemove()
        => _firstNCharactersOfStringGetter.UseRemove();

    [Benchmark]
    public void UseLINQEnumerable()
        => _firstNCharactersOfStringGetter.UseLINQEnumerable().Consume(_consumer);

    [Benchmark]
    public ReadOnlySpan<char> UseAsSpan()
        => _firstNCharactersOfStringGetter.UseAsSpan();

    [Benchmark]
    public ReadOnlySpan<char> UseAsSpanWithRangeOperator()
        => _firstNCharactersOfStringGetter.UseAsSpanWithRangeOperator();

    [Benchmark]
    public ReadOnlySpan<char> UseToCharArray()
        => _firstNCharactersOfStringGetter.UseToCharArray();
}