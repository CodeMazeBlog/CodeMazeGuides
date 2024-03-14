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
            var getnames = Enum.GetNames<Months>().Length;
            return getnames;
        }

        [Benchmark]
        public int MeasureGetValues()
        {
            var getvalues = Enum.GetValues<Months>().Length;
            return getvalues;
        }

        [Benchmark]
        public int MeasureGetDistinctValues()
        {
            var distinct_values = Enum.GetValues(typeof(Seasons)).Cast<Seasons>().Distinct().Count();
            return distinct_values;
        }
    }
}