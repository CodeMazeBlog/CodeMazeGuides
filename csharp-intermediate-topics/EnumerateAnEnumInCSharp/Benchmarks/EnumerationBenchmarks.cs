using BenchmarkDotNet.Attributes;
using EnumerateAnEnumInCSharp;

namespace Benchmarks;

[MemoryDiagnoser]
public class EnumerationBenchmarks
{
    [Benchmark(Baseline = true)]
    public ConsoleColor[] GenericGetValues() => Enum.GetValues<ConsoleColor>();

    [Benchmark]
    public Array GetValuesWithType() => Enum.GetValues(typeof(ConsoleColor));

    [Benchmark]
    public ConsoleColor[] Reflection() => EnumHelper.GetValuesWithReflection<ConsoleColor>();
}
