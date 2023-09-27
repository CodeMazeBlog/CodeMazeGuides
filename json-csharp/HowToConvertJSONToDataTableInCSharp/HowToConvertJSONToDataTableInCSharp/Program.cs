using BenchmarkDotNet.Running;

namespace HowToConvertJSONToDataTableInCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<ConvertMethodsBenchMark>();
        }
    }
}