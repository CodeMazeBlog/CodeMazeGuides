using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace FastestWayToReadATextFileInCsharp
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class WaysToReadATextFileInCsharpBenchmark
    {
        private static readonly string _sampleFilePath
           = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.Parent.FullName, "BenchmarkTextFile.txt");

        private WaysToReadATextFileInCsharp _textFileReader = new(_sampleFilePath);

        [Benchmark]
        public void UseFileReadAllLines()
         => _textFileReader.UseFileReadAllLines();

        [Benchmark]
        public void UseFileReadAllText()
         => _textFileReader.UseFileReadAllText();

        [Benchmark]
        public void UseFileReadLines()
         => _textFileReader.UseFileReadLines();

        [Benchmark]
        public void UseStreamReaderReadLine()
         => _textFileReader.UseStreamReaderReadLine();

        [Benchmark]
        public void UseStreamReaderReadToEnd()
         => _textFileReader.UseStreamReaderReadToEnd();

        [Benchmark]
        public void UseStreamReaderReadBlock()
         => _textFileReader.UseStreamReaderReadBlock();

        [Benchmark]
        public void UseBufferedStreamObject()
         => _textFileReader.UseBufferedStreamObject();
    }
}