using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace HowToConvertAStreamToAFileInCSharp;

[InProcess]
[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class ConvertAStreamToAFileInCSharpBenchmark
{
    private readonly MemoryStream _stream = new();
    private string _destinationPath = string.Empty;

    [GlobalSetup]
    public void Setup()
    {
        _destinationPath = Path.Combine(AppContext.BaseDirectory, "Files");

        using var fileStream = File.OpenRead(Path.Combine(_destinationPath, "source.png"));
        fileStream.CopyTo(_stream);
    }

    [GlobalCleanup]
    public void Cleanup() => _stream.Dispose();

    [Benchmark]
    public void CopyToBenchmark()
    {
        ConvertAStreamToAFileInCSharp.CopyToFile(_stream, Path.Combine(_destinationPath, "CopyTo.png"));
    }

    [Benchmark]
    public async Task CopyToAsyncBenchmark()
    {
        await ConvertAStreamToAFileInCSharp.CopyToFileAsync(_stream, Path.Combine(_destinationPath, "CopyToAsync.png"));
    }

    [Benchmark]
    public void WriteBenchmark()
    {
        ConvertAStreamToAFileInCSharp.WriteToFileStream(_stream, Path.Combine(_destinationPath, "Write.png"));
    }

    [Benchmark]
    public void WriteByteBenchmark()
    {
        ConvertAStreamToAFileInCSharp.WriteByteToFileStream(_stream, Path.Combine(_destinationPath, "WriteByte.png"));
    }

    [Benchmark]
    public void WriteAllBytesBenchmark()
    {
        ConvertAStreamToAFileInCSharp.WriteAllBytesFile(_stream, Path.Combine(_destinationPath, "WriteAllBytes.png"));
    }
}
