using BenchmarkDotNet.Attributes;

namespace UsingStaticAnonymousFunctionsInCSharp;

[MemoryDiagnoser]
public class AnonymousFunctionsBenchmark
{
    private int _numNonConst = 10;
    private const int _numConst = 10;

    public int Calculate(Func<int, int> func)
    {
        return func(6);
    }           

    [Benchmark]
    public int MultiplyNonStaticWithConst()
    {
        return Calculate(num => _numConst * num);
    }

    [Benchmark]
    public int MultiplyStatic()
    {
        return Calculate(static num => _numConst * num);
    }

    [Benchmark]
    public int MultiplyNonStatic()
    {
        return Calculate(num => _numNonConst * num);
    }
}
