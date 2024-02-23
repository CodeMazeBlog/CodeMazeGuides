using BenchmarkDotNet.Attributes;
using CountEnumMembers;

namespace CountEnumMembersBenchmark
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        [Benchmark]
        public int MeasureGetValues()
        {
            var getvalues = Enum.GetValues(typeof(Months));
            return getvalues.Length;
        }

        [Benchmark]
        public int MeasureGetNames()
        {
            var getnames = Enum.GetNames(typeof(Months));
            return getnames.Length;
        }
    }
}
