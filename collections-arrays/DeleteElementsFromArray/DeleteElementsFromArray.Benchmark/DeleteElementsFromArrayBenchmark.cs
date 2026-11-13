using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using DeleteElementsFromAnArray;

namespace BenchmarkRunner;

[InProcess]
[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class DeleteElementsFromAnArrayBenchmark
{
    private readonly int[] _myArray = FillArray();

    private readonly int _key = 7;

    [Benchmark]
    public int[] DeleteWithArrayCopy() => Methods.DeleteWithArrayCopy(_myArray, _key);

    [Benchmark]
    public int[] DeleteWithBufferCopy() => Methods.DeleteWithBufferCopy(_myArray, _key);

    [Benchmark]
    public int[] DeleteWithArraySegment() => Methods.DeleteWithArraySegment(_myArray, _key);

    [Benchmark]
    public int[] DeleteWithLoop() => Methods.DeleteWithLoop(_myArray, _key);

    [Benchmark]
    public int[] DeleteWithCollectionExpression() => Methods.DeleteWithCollectionExpression(_myArray, _key);

    [Benchmark]
    public int[] DeleteWithFindAll() => Methods.DeleteWithFindAll(_myArray, _key);

    [Benchmark]
    public int[] DeleteWithWhere() => Methods.DeleteWithWhere(_myArray, _key);

    [Benchmark]
    public int[] DeleteWithRemoveAll() => Methods.DeleteWithRemoveAll(_myArray, _key);

    [Benchmark]
    public int[] DeleteWithList() => Methods.DeleteWithList(_myArray, _key);

    [Benchmark]
    public int[] DeleteWithPooledArray() => Methods.DeleteWithPooledArray(_myArray, _key);

    private static int[] FillArray()
    {
        var rnd = new Random(42);
        var myArray = new int[1000];

        for (int i = 0; i < 1000; i++)
        {
            myArray[i] = rnd.Next(1, 10);
        }

        return myArray;
    }
}
