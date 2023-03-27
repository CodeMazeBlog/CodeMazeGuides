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

        private static readonly FileStream _benchmarkStream
            = new(_sampleFilePath, FileMode.Open, FileAccess.Read);

        [Benchmark]
        public void UseTheStreamDotReadMethod()
        {
            var convertStreamToByteArray = new ConvertStreamToByteArray(_benchmarkStream);

            convertStreamToByteArray.UseTheStreamDotReadMethod();
        }


        [Benchmark]
        public void UseAMemoryStream()
        {
            var convertStreamToByteArray = new ConvertStreamToByteArray(_benchmarkStream);

            convertStreamToByteArray.UseAMemoryStream();
        }

        [Benchmark]
        public void UseABufferedStream()
        {
            var convertStreamToByteArray = new ConvertStreamToByteArray(_benchmarkStream);

            convertStreamToByteArray.UseABufferedStream();
        }

        [Benchmark]
        public void UseAStreamReader()
        {
            var convertStreamToByteArray = new ConvertStreamToByteArray(_benchmarkStream);

            convertStreamToByteArray.UseAStreamReader();
        }

        [Benchmark]
        public void UseABinaryReader()
        {
            var convertStreamToByteArray = new ConvertStreamToByteArray(_benchmarkStream);

            convertStreamToByteArray.UseABinaryReader();
        }
    }
}