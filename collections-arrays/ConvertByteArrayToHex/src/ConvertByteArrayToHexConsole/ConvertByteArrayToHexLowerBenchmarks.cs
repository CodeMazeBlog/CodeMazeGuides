using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ConvertByteArrayToHexLibrary;

namespace ConvertByteArrayToHexConsole;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[MemoryDiagnoser]
public class ConvertByteArrayToHexLowerBenchmarks
{
    private static readonly int[] Sizes =
    {
        128,
        4096,
        //1_048_576
    };

    private readonly List<byte[]> _sourceData = new();

    public ConvertByteArrayToHexLowerBenchmarks()
    {
        var random = new Random(42);

        foreach (var size in Sizes)
        {
            var array = GC.AllocateUninitializedArray<byte>(size);
            random.NextBytes(array);
            _sourceData.Add(array);
        }
    }

    public IEnumerable<object> ArrayData()
    {
        foreach (var array in _sourceData)
            yield return array;
    }

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public string ConvertToLowerHexUsingStringBuilderAppend(byte[] source) =>
        ConversionHelpers.ToHexStringWithStringBuilderAppend(source, true);

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public string ConvertToLowerHexUsingBitManipulation(byte[] source) =>
        ConversionHelpers.ToHexStringWithBitManipulation(source, true);

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public string ConvertToLowerHexUsingAlphabetSpanLookup(byte[] source) =>
        ConversionHelpers.ToHexStringWithAlphabetSpanLookup(source, true);

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public string ConvertToLowerHexUsingLookup(byte[] source) => ConversionHelpers.ToHexStringWithLookup(source, true);

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public string ConvertToLowerHexUsingLookupNetStandard20(byte[] source) =>
        ConversionHelpers.ToHexStringWithLookupNetStandard20(source, true);

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public string ConvertToLowerHexUsingConvert(byte[] source) =>
        ConversionHelpers.ToHexStringWithConvert(source, true);
}