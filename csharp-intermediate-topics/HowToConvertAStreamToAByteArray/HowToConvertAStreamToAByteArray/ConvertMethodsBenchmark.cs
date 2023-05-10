using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace HowToConvertAStreamToAByteArray
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class ConvertMethodsBenchmark
    {
        private static readonly string _sampleFilePath
            = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.Parent.FullName, "benchmarkfile.txt");

        private ConvertStreamToByteArray _convertStreamToByteArray;

        [IterationSetup]
        public void IterationSetup()
        {
           var benchmarkStream = new FileStream(_sampleFilePath, FileMode.Open, FileAccess.Read);
           _convertStreamToByteArray = new ConvertStreamToByteArray(benchmarkStream);
        }

        [Benchmark]
        public void UseStreamDotReadMethod()
        {
            _convertStreamToByteArray.UseStreamDotReadMethod();
        }

        [Benchmark]
        public void UseMemoryStream()
        {
            _convertStreamToByteArray.UseMemoryStream();
        }

        [Benchmark]
        public void UseBufferedStream()
        {
            _convertStreamToByteArray.UseBufferedStream();
        }

        [Benchmark]
        public void UseStreamReader()
        {
            _convertStreamToByteArray.UseStreamReader();
        }

        [Benchmark]
        public void UseBinaryReader()
        {
            _convertStreamToByteArray.UseBinaryReader();
        }
    }
}