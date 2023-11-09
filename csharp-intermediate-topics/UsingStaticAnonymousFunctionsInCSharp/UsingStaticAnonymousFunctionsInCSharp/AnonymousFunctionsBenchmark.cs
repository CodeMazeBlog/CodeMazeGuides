using BenchmarkDotNet.Attributes;

namespace UsingStaticAnonymousFunctionsInCSharp;

[MemoryDiagnoser]
public class AnonymousFunctionsBenchmark
{
    private int numNonConst = 10;
    private const int numConst = 10;

    public int Calculate(Func<int, int> func)
    {
        return func(6);
    }        

    [Benchmark]
    public int MultiplyNonStatic()
    {
        return Calculate(num => numNonConst * num);
    }

    [Benchmark]
    public int MultiplyNonStaticWithConst()
    {
        return Calculate(num => numConst * num);
    }

    [Benchmark]
    public int MultiplyStatic()
    {
        return Calculate(static num => numConst * num);
    }
}
