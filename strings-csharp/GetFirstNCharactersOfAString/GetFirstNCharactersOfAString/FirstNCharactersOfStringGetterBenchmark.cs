using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Order;

namespace GetFirstNCharactersOfAString;

[InProcess]
[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class FirstNCharactersOfStringGetterBenchmark
{
    private readonly FirstNCharactersOfStringGetter _firstNCharactersOfStringGetter = new();
    private readonly Consumer _consumer = new();

    [Benchmark]
    public ReadOnlySpan<char> UseSubstring()
        => _firstNCharactersOfStringGetter.UseSubstring();

    [Benchmark]
    public ReadOnlySpan<char> UseRangeOperator()
        => _firstNCharactersOfStringGetter.UseRangeOperator();

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
    public string UseAsSpanThenToString()
        => _firstNCharactersOfStringGetter.UseAsSpan().ToString();

    [Benchmark]
    public ReadOnlySpan<char> UseAsSpanWithRangeOperator()
        => _firstNCharactersOfStringGetter.UseAsSpanWithRangeOperator();

    [Benchmark]
    public ReadOnlySpan<char> UseToCharArray()
        => _firstNCharactersOfStringGetter.UseToCharArray();
}
