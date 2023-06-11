using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using ConvertByteArrayToHexLibrary;

namespace ConvertByteArrayToHexConsole;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
public class ConvertByteArrayToHexUpperBenchmarks
{
    private static readonly int[] Sizes =
    {
        32,
        128,
        4096,
        1_048_576
    };

    private readonly List<byte[]> _sourceData = new();

    public ConvertByteArrayToHexUpperBenchmarks()
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
    public string ConvertToUpperHexUsingBitConverter(byte[] source) =>
        ConversionHelpers.ToHexWithBitConverter(source);

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public string ConvertToUpperHexUsingBitConverterNoDashes(byte[] source) =>
        ConversionHelpers.ToHexWithBitConverter(source, true);

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public string ConvertToUpperHexUsingStringBuilderAppend(byte[] source) =>
        ConversionHelpers.ToHexWithStringBuilderAppend(source);

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public string ConvertToUpperHexUsingTryFormatAndCreate(byte[] source) =>
        ConversionHelpers.ToHexWithTryFormatAndStringCreate(source);

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public string ConvertToUpperHexUsingBitManipulation(byte[] source) =>
        ConversionHelpers.ToHexWithBitManipulation(source);

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public string ConvertToUpperHexUsingAlphabetSpanLookup(byte[] source) =>
        ConversionHelpers.ToHexWithAlphabetSpanLookup(source);

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public string ConvertToUpperHexUsingLookup(byte[] source) =>
        ConversionHelpers.ToHexWithLookup(source);

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public string ConvertToUpperHexUsingLookupNetStandard20(byte[] source) =>
        ConversionHelpers.ToHexWithLookupNetStandard20(source);

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public string ConvertToUpperHexUsingConvert(byte[] source) =>
        ConversionHelpers.ToHexWithConvert(source);
}