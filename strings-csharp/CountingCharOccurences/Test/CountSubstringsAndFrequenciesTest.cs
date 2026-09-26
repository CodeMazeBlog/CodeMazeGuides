using CountingCharOccurences;

namespace Test
{
    public class CountSubstringsAndFrequenciesTest
    {
        private static readonly CountSubstringsAndFrequencies _counter = new CountSubstringsAndFrequencies();

        [Fact]
        public void WhenCountSubstringNonOverlappingThenMatchesDoNotOverlap()
        {
            string main = "aaaa";
            string toFind = "aa";

            int actual = _counter.CountSubstringNonOverlapping(main, toFind);

            Assert.Equal(2, actual);
        }

        [Fact]
        public void WhenCountSubstringOverlappingThenMatchesOverlap()
        {
            string main = "aaaa";
            string toFind = "aa";

            int actual = _counter.CountSubstringOverlapping(main, toFind);

            Assert.Equal(3, actual);
        }

        [Fact]
        public void WhenCountEveryCharUsingLinqThenReturnFrequencyOfEachChar()
        {
            string main = "hello world";

            var actual = _counter.CountEveryCharUsingLinq(main);

            Assert.Equal(3, actual['l']);
            Assert.Equal(2, actual['o']);
        }

        [Fact]
        public void WhenCountEveryCharUsingLoopThenReturnSameFrequenciesAsLinq()
        {
            string main = "hello world";

            var actual = _counter.CountEveryCharUsingLoop(main);

            Assert.Equal(_counter.CountEveryCharUsingLinq(main), actual);
        }
    }
}
