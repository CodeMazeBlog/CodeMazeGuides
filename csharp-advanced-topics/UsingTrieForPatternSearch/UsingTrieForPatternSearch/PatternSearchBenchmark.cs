using BenchmarkDotNet.Attributes;

namespace UsingTrieForPatternSearch
{
    public class PatternSearchBenchmark
    {
        private const string _text = "abcdefghijklmnopqrstuvwxyz";
        private const string _pattern = "cd";
        private const int _iterations = 1000000;
        private readonly Trie _trie;

        public PatternSearchBenchmark()
        {
            _trie = new Trie();
            _trie.AddWord(_pattern);
        }

        [Benchmark]
        public void TrieSearch()
        {
            for (int i = 0; i < _iterations; i++)
            {
                _trie.Search(_text);
            }
        }

        [Benchmark]
        public void HashSetSearch()
        {
            for (int i = 0; i < _iterations; i++)
            {
                HashSetPatternSearcher.Search(_text, _pattern);
            }
        }

        [Benchmark]
        public void ListSearch()
        {
            for (int i = 0; i < _iterations; i++)
            {
                ListPatternSearcher.Search(_text, _pattern);
            }
        }

        [Benchmark]
        public void SortedListSearch()
        {
            for (int i = 0; i < _iterations; i++)
            {
                SortedListPatternSearcher.Search(_text, _pattern);
            }
        }
    }
}
