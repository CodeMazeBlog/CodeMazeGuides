using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using CaseInsensitiveSubstringSearch;

namespace BenchmarkRunner
{
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class CaseInsensitiveSubstringSearchBenchmark
    {
        private const string SourceString =
            "A quick brown fox jumps over the lazy dog. The lazy dog barks loudly. The brown fox runs away quickly.";
        private const string SubStringToSearch = "loudly";

        [Benchmark]
        public bool StringContains()
            => SubstringSearch.StringContains(SourceString, SubStringToSearch);

        [Benchmark]
        public bool StringIndexOf()
            => SubstringSearch.StringIndexOf(SourceString, SubStringToSearch);

        [Benchmark]
        public bool StringToUpperInvariant()
            => SubstringSearch.StringToUpperInvariant(SourceString, SubStringToSearch);

        [Benchmark]
        public bool RegexIsMatch()
            => SubstringSearch.RegexIsMatch(SourceString, SubStringToSearch);

        [Benchmark]
        public bool LinqStringEquals()
            => SubstringSearch.LinqStringEquals(SourceString, SubStringToSearch, ' ');
    }
}
