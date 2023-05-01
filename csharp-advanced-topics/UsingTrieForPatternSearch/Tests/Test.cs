using UsingTrieForPatternSearch;

namespace Tests
{
    public class Test
    {        
        [Fact]
        public void WhenGivenExistingWord_ThenTrieSearch_ReturnsTrue()
        {
            var trie = new Trie();
            var text = "The quick brown fox jumps over the lazy dog";
            
            foreach (var word in text.Split(' '))
            {
                trie.AddWord(word);
            }

            var expected = true;
            var actual = trie.Search("quick");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenGivenNonExistingWord_ThenTrieSearch_ReturnsFalse()
        {
            var trie = new Trie();
            var text = "The quick brown fox jumps over the lazy dog";

            foreach (var word in text.Split(' '))
            {
                trie.AddWord(word);
            }

            var expected = false;
            var actual = trie.Search("earth");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenGivenEmptyText_ThenHashSetSearch_ReturnsFalse()
        {
            var text = "";
            var pattern = "abc";
            var expected = false;

            var actual = HashSetPatternSearcher.Search(text, pattern);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenGivenEmptyPattern_ThenHashSetSearch_ReturnsFalse()
        {
            var text = "abc";
            var pattern = "";
            var expected = false;

            var actual = HashSetPatternSearcher.Search(text, pattern);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenPatternNotInText_ThenHashSetSearch_ReturnsFalse()
        {
            var text = "abc";
            var pattern = "def";
            var expected = false;

            var actual = HashSetPatternSearcher.Search(text, pattern);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenPatternInText_ThenHashSetSearch_ReturnsTrue()
        {
            var text = "abcxyz";
            var pattern = "cx";
            var expected = true;

            var actual = HashSetPatternSearcher.Search(text, pattern);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenGivenEmptyText_ThenListSearch_ReturnsFalse()
        {
            var text = "";
            var pattern = "abc";
            var expected = false;

            var actual = ListPatternSearcher.Search(text, pattern);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenGivenEmptyPattern_ThenListSearch_ReturnsFalse()
        {
            var text = "abc";
            var pattern = "";
            var expected = false;

            var actual = ListPatternSearcher.Search(text, pattern);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenPatternNotInText_ThenListSearch_ReturnsFalse()
        {
            var text = "abc";
            var pattern = "def";
            var expected = false;

            var actual = ListPatternSearcher.Search(text, pattern);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenPatternInText_ThenListSearch_ReturnsTrue()
        {
            var text = "abcxyz";
            var pattern = "cx";
            var expected = true;

            var actual = ListPatternSearcher.Search(text, pattern);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenPatternInTextMultipleTimes_ThenListSearch_ReturnsTrue()
        {
            var text = "abcxyzcx";
            var pattern = "cx";
            var expected = true;

            var actual = ListPatternSearcher.Search(text, pattern);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenGivenEmptyText_ThenSortedListSearch_ReturnsFalse()
        {
            var text = "";
            var pattern = "abc";
            var expected = false;

            var actual = SortedListPatternSearcher.Search(text, pattern);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenGivenEmptyPattern_ThenSortedListSearch_ReturnsFalse()
        {
            var text = "abc";
            var pattern = "";
            var expected = false;

            var actual = SortedListPatternSearcher.Search(text, pattern);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenPatternNotInText_ThenSortedListSearch_ReturnsFalse()
        {
            var text = "abc";
            var pattern = "def";
            var expected = false;

            var actual = SortedListPatternSearcher.Search(text, pattern);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenPatternInText_ThenSortedListSearch_ReturnsTrue()
        {
            var text = "abcxyz";
            var pattern = "cx";
            var expected = true;

            var actual = SortedListPatternSearcher.Search(text, pattern);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenPatternInTextMultipleTimes_ThenSortedListSearch_ReturnsTrue()
        {
            var text = "abcxyzcx";
            var pattern = "cx";
            var expected = true;

            var actual = SortedListPatternSearcher.Search(text, pattern);

            Assert.Equal(expected, actual);
        }
    }
}