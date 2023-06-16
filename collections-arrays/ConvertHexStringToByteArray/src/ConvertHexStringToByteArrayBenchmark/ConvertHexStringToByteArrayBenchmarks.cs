using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using ConvertHexStringToByteArray.Library;

namespace ConvertHexStringToByteArray.Benchmarks;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
public class ConvertHexStringToByteArrayBenchmarks
{
    private static readonly int[] Sizes =
    {
        32,
        128,
        4096,
        1_048_576
    };

    private readonly List<string> _sourceData = new();

    public ConvertHexStringToByteArrayBenchmarks()
    {
        var random = new Random(42);

        foreach (var size in Sizes)
        {
            var array = GC.AllocateUninitializedArray<byte>(size);
            random.NextBytes(array);
            _sourceData.Add(Convert.ToHexString(array));
        }
    }

    public IEnumerable<object> ArrayData()
    {
        foreach (var array in _sourceData)
            yield return array;
    }

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public byte[] ConvertToByteArrayUsingLookup(string source) =>
        ConversionHelpers.FromHexWithLookup(source);

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public byte[] ConvertToByteArrayUsingSwitchComputation(string source) =>
        ConversionHelpers.FromHexWithSwitchComputation(source);

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public byte[] ConvertToByteArrayUsingBitFiddle(string source) =>
        ConversionHelpers.FromHexWithBitFiddle(source);

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public byte[] ConvertToByteArrayUsingModularArithmetic(string source) =>
        ConversionHelpers.FromHexWithModularArithmetic(source);

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public byte[] ConvertToByteArrayUsingConvert(string source) =>
        ConversionHelpers.FromHexWithConvert(source);
}