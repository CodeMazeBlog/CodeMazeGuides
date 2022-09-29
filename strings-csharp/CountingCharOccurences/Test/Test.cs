using CountingCharOccurences;

namespace Test
{
    public class Test
    {
        private static readonly CountChars _countChars = new CountChars();

        [Fact]
        public void WhenSearchCharUsingCountThenReturnNumberOfOccurences()
        {
            string main = "Mary Had A Little Lamb";
            char toFind = 'L';

            int actual = _countChars.CountCharsUsingLinqCount(main, toFind);

            Assert.Equal(2, actual);
        }

        [Fact]
        public void WhenSearchCharUsingForeachThenReturnNumberOfOccurences()
        {
            string main = "Mary Had A Little Lamb";
            char toFind = 'L';

            int actual = _countChars.CountCharsUsingForeach(main, toFind);

            Assert.Equal(2, actual);
        }

        [Fact]
        public void WhenSearchCharUsingSpanThenReturnNumberOfOccurences()
        {
            string main = "Mary Had A Little Lamb";
            char toFind = 'L';

            int actual = _countChars.CountCharsUsingForeachSpan(main, toFind);

            Assert.Equal(2, actual);
        }

        [Fact]
        public void WhenSearchCharUsingIndexThenReturnNumberOfOccurences()
        {
            string main = "Mary Had A Little Lamb";
            char toFind = 'L';

            int actual = _countChars.CountCharsUsingIndex(main, toFind);

            Assert.Equal(2, actual);
        }

        [Fact]
        public void WhenSearchCharUsingForThenReturnNumberOfOccurences()
        {
            string main = "Mary Had A Little Lamb";
            char toFind = 'L';

            int actual = _countChars.CountCharsUsingFor(main, toFind);

            Assert.Equal(2, actual);
        }

        [Fact]
        public void WhenSearchCharUsingForReverseThenReturnNumberOfOccurences()
        {
            string main = "Mary Had A Little Lamb";
            char toFind = 'L';

            int actual = _countChars.CountCharsUsingForReverseIteration(main, toFind);

            Assert.Equal(2, actual);
        }

        [Fact]
        public void WhenSearchCharUsingForWithSpanThenReturnNumberOfOccurences()
        {
            string main = "Mary Had A Little Lamb";
            char toFind = 'L';

            int actual = _countChars.CountCharsUsingForWithSpan(main, toFind);

            Assert.Equal(2, actual);
        }

        [Fact]
        public void WhenSearchCharUsingSplitThenReturnNumberOfOccurences()
        {
            string main = "Mary Had A Little Lamb";
            char toFind = 'L';

            int actual = _countChars.CountCharsUsingSplit(main, toFind);

            Assert.Equal(2, actual);
        }

        [Fact]
        public void WhenSearchCharUsingReplaceThenReturnNumberOfOccurences()
        {
            string main = "Mary Had A Little Lamb";
            char toFind = 'L';

            int actual = _countChars.CountCharsUsingReplace(main, toFind);

            Assert.Equal(2, actual);
        }

        [Fact]
        public void WhenSearchCharUsingRegexThenReturnNumberOfOccurences()
        {
            string main = "Mary Had A Little Lamb";
            char toFind = 'L';

            int actual = _countChars.CountCharsUsingRegex(main, toFind);

            Assert.Equal(2, actual);
        }

        [Fact]
        public void WhenSearchCharUsingSpanCountThenReturnNumberOfOccurences()
        {
            string main = "Mary Had A Little Lamb";
            char toFind = 'L';

            int actual = _countChars.CountCharsUsingSpanCount(main, toFind);

            Assert.Equal(2, actual);
        }
    }
}