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
    public void UseForLoop()
        => _firstNCharactersOfStringGetter.UseForLoop();

    [Benchmark]
    public void UseRemove()
        => _firstNCharactersOfStringGetter.UseRemove();

    [Benchmark]
    public void UseLINQEnumerable()
        => ConsumerExtensions.Consume(_firstNCharactersOfStringGetter.UseLINQEnumerable(), _consumer);

    [Benchmark]
    public void UseAsSpan()
        => _firstNCharactersOfStringGetter.UseAsSpan();

    [Benchmark]
    public void UseAsSpanWithRangeOperator()
        => _firstNCharactersOfStringGetter.UseAsSpanWithRangeOperator();

    [Benchmark]
    public void UseToCharArray()
        => _firstNCharactersOfStringGetter.UseToCharArray();

    [Benchmark]
    public void UseAsMemory()
        => _firstNCharactersOfStringGetter.UseAsMemory();
}