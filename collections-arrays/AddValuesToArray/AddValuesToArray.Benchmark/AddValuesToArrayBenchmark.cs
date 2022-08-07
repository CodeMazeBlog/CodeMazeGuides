using BenchmarkDotNet.Attributes;

namespace AddValuesToArray.Benchmark;

public class AddValuesToArrayBenchmark
{
    public IEnumerable<object> ArraySize()
    {
        yield return 1_000;
        yield return 10_000;
    }

    [Benchmark]
    [ArgumentsSource(nameof(ArraySize))]
    public void ArrayIndexInitilizer(int arraySize)
    {
        AddValuesToArrayMethods.ArrayIndexInitilizer(arraySize);
    }

    [Benchmark]
    [ArgumentsSource(nameof(ArraySize))]
    public void SetValueMethod(int arraySize)
    {
        AddValuesToArrayMethods.SetValueMethod(arraySize);
    }

    [Benchmark]
    [ArgumentsSource(nameof(ArraySize))]
    public void LinqList(int arraySize)
    {
        AddValuesToArrayMethods.LinqList(arraySize);
    }

    [Benchmark]
    [ArgumentsSource(nameof(ArraySize))]
    public void LinqConcat(int arraySize)
    {
        AddValuesToArrayMethods.LinqConcat(arraySize);
    }

    [Benchmark]
    [ArgumentsSource(nameof(ArraySize))]
    public void LinqAppend(int arraySize)
    {
        AddValuesToArrayMethods.LinqAppend(arraySize);
    }

    [Benchmark]
    [ArgumentsSource(nameof(ArraySize))]
    public void ArrayResize(int arraySize)
    {
        AddValuesToArrayMethods.ArrayResize(arraySize);
    }
}
