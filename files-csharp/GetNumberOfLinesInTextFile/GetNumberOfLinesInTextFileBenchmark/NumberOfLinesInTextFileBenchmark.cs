using BenchmarkDotNet.Attributes;
using GetNumberOfLinesInTextFile;

namespace GetNumberOfLinesInTextFileBenchmark
{
    public class NumberOfLinesInTextFileBenchmark
    {
        const string FileName = "Sample.txt";

        [Benchmark]
        public void CountLinesUsingReadAllLinesMethod() => FileHelper.CountLinesUsingReadAllLinesMethod(FileName);

        [Benchmark]
        public void CountLinesUsingStreamReader() => FileHelper.CountLinesUsingStreamReader(FileName);

        [Benchmark]
        public void CountLinesUsingReadLines() => FileHelper.CountLinesUsingReadLinesMethod(FileName);
    }
}
