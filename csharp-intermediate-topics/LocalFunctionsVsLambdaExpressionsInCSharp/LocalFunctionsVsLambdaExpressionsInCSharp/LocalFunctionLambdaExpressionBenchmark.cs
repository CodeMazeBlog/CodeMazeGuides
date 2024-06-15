namespace LocalFunctionsVsLambdaExpressionsInCSharp;

using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class LocalFunctionLambdaExpressionBenchmark
{
    [Benchmark]
    public void SquareAsLambda()
    {
        var lambda = (int x) => x * x;

        lambda(3);
    }

    [Benchmark]
    public void SquareAsLocal()
    {
        Square(3);

        int Square(int x)
        {
            return x * x;
        }
    }
}