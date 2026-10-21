using BenchmarkDotNet.Attributes;

namespace ConvertCharArray2String.Benchmarks;

[MemoryDiagnoser]
public class CharArrayToStringBenchmarks
{
    private char[] _charArray = [];

    [Params(9, 1000)]
    public int Length { get; set; }

    [GlobalSetup]
    public void Setup() =>
        _charArray = Enumerable.Range(0, Length).Select(i => (char)('a' + i % 26)).ToArray();

    [Benchmark(Baseline = true)]
    public string StringConstructor() => new string(_charArray);

    [Benchmark]
    public string StringConcat() => string.Concat(_charArray);

    [Benchmark]
    public string StringJoin() => string.Join("", _charArray);
}
