using BenchmarkDotNet.Attributes;

namespace HowToConvertAStreamToAFileInCSharp;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
public class ConvertAStreamToAFileInCSharpBenchmark
{
    public static MemoryStream Stream { get; set; } = new MemoryStream();

    public static string DestinationPath { get; set; } = string.Empty;

    [Benchmark]
    public void CopyToBenchmark()
    {
        ConvertAStreamToAFileInCSharp.CopyToFile(Stream, Path.Combine([DestinationPath, "CopyTo.png"]));
    }

    [Benchmark]
    public void WriteBenchmark()
    {
        ConvertAStreamToAFileInCSharp.WriteToFileStream(Stream, Path.Combine([DestinationPath, "Write.png"]));
    }

    [Benchmark]
    public void WriteByteBenchmark()
    {
        ConvertAStreamToAFileInCSharp.WriteByteToFileStream(Stream, Path.Combine([DestinationPath, "WriteByte.png"]));
    }

    [Benchmark]
    public void WriteAllBytesBenchmark()
    {
        ConvertAStreamToAFileInCSharp.WriteAllBytesFile(Stream, Path.Combine([DestinationPath, "WriteAllBytes.png"]));
    }
}