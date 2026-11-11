using BenchmarkDotNet.Attributes;
using CopyArrayElements;

namespace BenchmarkRunner;

[MemoryDiagnoser]
public class ElementCopierBenchmark
{
    private static readonly ElementCopier elementCopier = new();
    private Article[] benchMarkSourceArray = [];

    [Params(1000, 10000)]
    public int Size { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        benchMarkSourceArray = Enumerable
            .Repeat(new Article { Title = "Title", LastUpdate = DateTime.Now }, Size)
            .ToArray();
    }

    [Benchmark]
    public Article[] CopyUsingAssignment() => elementCopier.CopyUsingAssignment(benchMarkSourceArray);

    [Benchmark]
    public Article[] CopyUsingArrayClass() => elementCopier.CopyUsingArrayClass(benchMarkSourceArray);

    [Benchmark]
    public Article[] CopyUsingClone() => elementCopier.CopyUsingClone(benchMarkSourceArray);

    [Benchmark]
    public Article[] CopyUsingCopyTo() => elementCopier.CopyUsingCopyTo(benchMarkSourceArray);

    [Benchmark]
    public Article[] CopyUsingRange() => elementCopier.CopyUsingRange(benchMarkSourceArray);

    [Benchmark]
    public Article[] CopyUsingSpan() => elementCopier.CopyUsingSpan(benchMarkSourceArray);

    [Benchmark]
    public Article[] CopyUsingCollectionExpression() => elementCopier.CopyUsingCollectionExpression(benchMarkSourceArray);

    [Benchmark]
    public Article[] CopyUsingLinq() => elementCopier.CopyUsingLinq(benchMarkSourceArray);

    [Benchmark]
    public Article[] ManuallyCopy() => elementCopier.ManuallyCopy(benchMarkSourceArray);
}
