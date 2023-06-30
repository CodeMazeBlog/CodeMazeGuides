using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using ConvertByteArrayToHexLibrary;

namespace ConvertByteArrayToHexConsole;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
public class ConvertByteArrayToHexLowerBenchmarks
{
    private static readonly int[] Sizes =
    {
        32,
        128,
        4096,
        1_048_576
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
        ConversionHelpers.ToHexWithStringBuilderAppend(source, true);

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public string ConvertToLowerHexUsingTryFormatAndCreate(byte[] source) =>
        ConversionHelpers.ToHexWithTryFormatAndStringCreate(source, true);

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public string ConvertToLowerHexUsingBitManipulation(byte[] source) =>
        ConversionHelpers.ToHexWithBitManipulation(source, true);

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public string ConvertToLowerHexUsingAlphabetSpanLookup(byte[] source) =>
        ConversionHelpers.ToHexWithAlphabetSpanLookup(source, true);

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public string ConvertToLowerHexUsingLookup(byte[] source) =>
        ConversionHelpers.ToHexWithLookup(source, true);

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public string ConvertToLowerHexUsingLookupNetStandard20(byte[] source) =>
        ConversionHelpers.ToHexWithLookupNetStandard20(source, true);

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public string ConvertToLowerHexUsingConvert(byte[] source) =>
        ConversionHelpers.ToHexWithConvert(source, true);
}