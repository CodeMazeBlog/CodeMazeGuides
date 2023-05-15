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

        [GlobalSetup]
        public void Setup()
        {
           _convertStreamToByteArray = new ConvertStreamToByteArray();
        }

        [Benchmark]
        public void UseStreamDotReadMethod()
        {
            using var _benchmarkStream = new FileStream(_sampleFilePath, FileMode.Open, FileAccess.Read);
            _convertStreamToByteArray.UseStreamDotReadMethod(_benchmarkStream);
        }

        [Benchmark]
        public void UseMemoryStream()
        {
            using var _benchmarkStream = new FileStream(_sampleFilePath, FileMode.Open, FileAccess.Read);
            _convertStreamToByteArray.UseMemoryStream(_benchmarkStream);
        }

        [Benchmark]
        public void UseBufferedStream()
        {
            using var _benchmarkStream = new FileStream(_sampleFilePath, FileMode.Open, FileAccess.Read);
            _convertStreamToByteArray.UseBufferedStream(_benchmarkStream);
        }

        [Benchmark]
        public void UseStreamReader()
        {
            using var _benchmarkStream = new FileStream(_sampleFilePath, FileMode.Open, FileAccess.Read);
            _convertStreamToByteArray.UseStreamReader(_benchmarkStream);
        }

        [Benchmark]
        public void UseBinaryReader()
        {
            using var _benchmarkStream = new FileStream(_sampleFilePath, FileMode.Open, FileAccess.Read);
            _convertStreamToByteArray.UseBinaryReader(_benchmarkStream);
        }
    }
}