using BenchmarkDotNet.Attributes;
using CountEnumMembers;

namespace CountEnumMembersBenchmark
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        [Benchmark]
        public int MeasureGetNames()
        {
            var getnames = Enum.GetNames(typeof(Months)).Length;
            return getnames;
        }

        [Benchmark]
        public int MeasureGetValues()
        {
            var getvalues = Enum.GetValues(typeof(Months)).Length;
            return getvalues;
        }
    }
}