using BenchmarkDotNet.Attributes;

namespace UsingTrieForPatternSearch
{
    public class PatternSearchBenchmark
    {
        private const string _text = "abcdefghijklmnopqrstuvwxyz";
        private const string _pattern = "cd";
        private const int _iterations = 1000000;

        [Benchmark]
        public void TrieSearch()
        {
            var trie = new Trie();
            trie.AddWord(_pattern);

            for (int i = 0; i < _iterations; i++)
            {
                trie.Search(_text);
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
