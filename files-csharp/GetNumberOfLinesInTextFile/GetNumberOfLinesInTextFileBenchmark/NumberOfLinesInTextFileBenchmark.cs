using BenchmarkDotNet.Attributes;
using GetNumberOfLinesInTextFile;

namespace GetNumberOfLinesInTextFileBenchmark
{
    [MemoryDiagnoser(false)]
    public class NumberOfLinesInTextFileBenchmark
    {
        const string SmallFileName = "SmallFile.txt";
        const string LargeFileName = "LargeFile.txt";

        [Benchmark]
        public void CountLinesUsingReadAllLines() => FileHelper.CountLinesUsingReadAllLinesMethod(SmallFileName);

        [Benchmark]
        public void CountLinesUsingStreamReader() => FileHelper.CountLinesUsingStreamReader(SmallFileName);

        [Benchmark]
        public void CountLinesUsingReadLines() => FileHelper.CountLinesUsingReadLinesMethod(SmallFileName);
    }
}
