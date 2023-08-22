using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace FastestWayToReadATextFileInCsharp;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class WaysToReadATextFileInCsharpBenchmark
{
    private static readonly string _sampleFilePath
       = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.Parent.FullName, "BenchmarkTextFile.txt");

    private readonly WaysToReadATextFileInCsharp _textFileReader = new(_sampleFilePath);

    [Benchmark]
    public string UseFileReadAllLines()
     => _textFileReader.UseFileReadAllLines();

    [Benchmark]
    public string UseFileReadAllText()
     => _textFileReader.UseFileReadAllText();

    [Benchmark]
    public string UseFileReadLines()
     => _textFileReader.UseFileReadLines();

    [Benchmark]
    public string UseStreamReaderReadLine()
     => _textFileReader.UseStreamReaderReadLine();

    [Benchmark]
    public string UseStreamReaderReadToEnd()
     => _textFileReader.UseStreamReaderReadToEnd();

    [Benchmark]
    public string UseStreamReaderReadBlock()
     => _textFileReader.UseStreamReaderReadBlock();

    [Benchmark]
    public string UseStreamReaderReadBlockWithSpan()
     => _textFileReader.UseStreamReaderReadBlockWithSpan();

    [Benchmark]
    public string UseBufferedStreamObject()
     => _textFileReader.UseBufferedStreamObject();

    [Benchmark]
    public string UseBufferedStreamObjectWithNoFileStreamBuffer()
     => _textFileReader.UseBufferedStreamObjectWithNoFileStreamBuffer();
}