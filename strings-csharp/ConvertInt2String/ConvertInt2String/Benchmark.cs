using System.Text;
using BenchmarkDotNet.Attributes;

namespace ConvertInt2String;

[MemoryDiagnoser]
public class IntToStringBenchmarks
{
    [Params(3, 1_234_567)]
    public int Number { get; set; }

    [Benchmark(Baseline = true)]
    public string IntToString() => Number.ToString();

    [Benchmark]
    public string ConvertToString() => Convert.ToString(Number);

    [Benchmark]
    public string StringFormat() => string.Format("{0}", Number);

    [Benchmark]
    public string StringInterpolation() => $"{Number}";

    [Benchmark]
    public string StringConcat() => string.Concat(string.Empty, Number);

    [Benchmark]
    public string StringJoin() => string.Join(string.Empty, Number);

    [Benchmark]
    public string PlusSign() => string.Empty + Number;

    [Benchmark]
    public string StringBuilderAppend() => new StringBuilder().Append(Number).ToString();
}
