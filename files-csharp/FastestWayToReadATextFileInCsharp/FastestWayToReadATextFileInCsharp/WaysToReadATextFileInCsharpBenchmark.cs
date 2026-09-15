using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Order;

namespace FastestWayToReadATextFileInCsharp;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[HideColumns(Column.Gen0, Column.Gen1, Column.Gen2)]
public class WaysToReadATextFileInCsharpBenchmark
{
    private static readonly string SampleFilePath
       = Path.Combine(AppContext.BaseDirectory, "BenchmarkTextFile.txt");

    private readonly WaysToReadATextFileInCsharp _textFileReader = new(SampleFilePath);

    [Benchmark]
    public string FileReadAllLines()
     => _textFileReader.UseFileReadAllLines();

    [Benchmark]
    public string FileReadAllText()
     => _textFileReader.UseFileReadAllText();

    [Benchmark]
    public string FileReadLines()
     => _textFileReader.UseFileReadLines();

    [Benchmark]
    public string StreamReaderReadLine()
     => _textFileReader.UseStreamReaderReadLine();

    [Benchmark]
    public string StreamReaderReadToEnd()
     => _textFileReader.UseStreamReaderReadToEnd();

    [Benchmark]
    public string StreamReaderReadBlock()
     => _textFileReader.UseStreamReaderReadBlock();

    [Benchmark]
    public string StreamReaderReadBlockWithSpan()
     => _textFileReader.UseStreamReaderReadBlockWithSpan();

    [Benchmark]
    public string StreamReaderReadBlockWithArrayPool()
     => _textFileReader.UseStreamReaderReadBlockWithArrayPool();

    [Benchmark]
    public string BufferedStreamObject()
     => _textFileReader.UseBufferedStreamObject();

    [Benchmark]
    public string BufferedStreamWithNoFileStreamBuffer()
     => _textFileReader.UseBufferedStreamObjectWithNoFileStreamBuffer();

    [Benchmark]
    public async Task<string> FileReadAllTextAsync()
     => await _textFileReader.UseFileReadAllTextAsync();

    [Benchmark]
    public async Task<string> FileReadLinesAsync()
     => await _textFileReader.UseFileReadLinesAsync();

    [Benchmark]
    public async Task<string> StreamReaderReadToEndAsync()
     => await _textFileReader.UseStreamReaderReadToEndAsync();
}