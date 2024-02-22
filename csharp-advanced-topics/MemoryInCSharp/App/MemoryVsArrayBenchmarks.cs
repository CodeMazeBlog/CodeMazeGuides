using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace App;

[MemoryDiagnoser]
[RankColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class MemoryVsArrayBenchmarks
{
    private const int Size = 10_000_000; 
    private readonly int[] _array;
    private readonly Memory<int> _memory;

   public MemoryVsArrayBenchmarks()
    {
        _array = Enumerable.Range(0, Size).ToArray();
        _memory = new Memory<int>(_array);
    }

    [Benchmark]
    public async Task ModifyStandardArrayElementsAsync()
    {
        await Task.Run(() =>
        {
            for (var i = 0; i < _array.Length; i++)
            {
                _array[i] = i * 2;
            }
        });
    }

    [Benchmark]
    public async Task ModifyMemoryArrayElementsAsync()
    {
        await Task.Run(() =>
        {
            var span = _memory.Span;
            for (var i = 0; i < span.Length; i++)
            {
                span[i] = i * 2;
            }
        });
    }
    
    public static Summary RunBenchmarks()
    {
        return BenchmarkRunner.Run<MemoryVsArrayBenchmarks>();
    }
}