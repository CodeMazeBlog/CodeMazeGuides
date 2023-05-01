using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace HowToConvertAStreamToAByteArray
{
    [MemoryDiagnoser(false)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class ConvertMethodsBenchmark
    {
        private static readonly string _sampleFilePath
            = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.Parent.FullName, "benchmarkfile.txt");

        [Benchmark]
        public void UseTheStreamDotReadMethod()
        {
            using var benchmarkStream = new FileStream(_sampleFilePath, FileMode.Open, FileAccess.Read);
            var convertStreamToByteArray = new ConvertStreamToByteArray(benchmarkStream);

            convertStreamToByteArray.UseTheStreamDotReadMethod();
        }

        [Benchmark]
        public void UseAMemoryStream()
        {
            using var benchmarkStream = new FileStream(_sampleFilePath, FileMode.Open, FileAccess.Read);
            var convertStreamToByteArray = new ConvertStreamToByteArray(benchmarkStream);

            convertStreamToByteArray.UseAMemoryStream();
        }

        [Benchmark]
        public void UseABufferedStream()
        {
            using var benchmarkStream = new FileStream(_sampleFilePath, FileMode.Open, FileAccess.Read);
            var convertStreamToByteArray = new ConvertStreamToByteArray(benchmarkStream);

            convertStreamToByteArray.UseABufferedStream();
        }

        [Benchmark]
        public void UseAStreamReader()
        {
            using var benchmarkStream = new FileStream(_sampleFilePath, FileMode.Open, FileAccess.Read);
            var convertStreamToByteArray = new ConvertStreamToByteArray(benchmarkStream);

            convertStreamToByteArray.UseAStreamReader();
        }

        [Benchmark]
        public void UseABinaryReader()
        {
            using var benchmarkStream = new FileStream(_sampleFilePath, FileMode.Open, FileAccess.Read);
            var convertStreamToByteArray = new ConvertStreamToByteArray(benchmarkStream);

            convertStreamToByteArray.UseABinaryReader();
        }
    }
}