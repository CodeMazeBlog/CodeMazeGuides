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

            var text = new List<string>
            {
                main,
                Convert.ToString(toFind)
            };

            int actual = _countChars.CountCharsUsingLinqCount(text);

            Assert.Equal(2, actual);
        }

        [Fact]
        public void WhenSearchCharUsingForeachThenReturnNumberOfOccurences()
        {
            string main = "Mary Had A Little Lamb";
            char toFind = 'L';

            var text = new List<string>
            {
                main,
                Convert.ToString(toFind)
            };

            int actual = _countChars.CountCharsUsingForeach(text);

            Assert.Equal(2, actual);
        }

        [Fact]
        public void WhenSearchCharUsingSpanThenReturnNumberOfOccurences()
        {
            string main = "Mary Had A Little Lamb";
            char toFind = 'L';

            var text = new List<string>
            {
                main,
                Convert.ToString(toFind)
            };

            int actual = _countChars.CountCharsUsingForeachSpan(text);

            Assert.Equal(2, actual);
        }

        [Fact]
        public void WhenSearchCharUsingIndexThenReturnNumberOfOccurences()
        {
            string main = "Mary Had A Little Lamb";
            char toFind = 'L';

            var text = new List<string>
            {
                main,
                Convert.ToString(toFind)
            };

            int actual = _countChars.CountCharsUsingIndex(text);

            Assert.Equal(2, actual);
        }

        [Fact]
        public void WhenSearchCharUsingForThenReturnNumberOfOccurences()
        {
            string main = "Mary Had A Little Lamb";
            char toFind = 'L';

            var text = new List<string>
            {
                main,
                Convert.ToString(toFind)
            };

            int actual = _countChars.CountCharsUsingFor(text);

            Assert.Equal(2, actual);
        }

        [Fact]
        public void WhenSearchCharUsingForReverseThenReturnNumberOfOccurences()
        {
            string main = "Mary Had A Little Lamb";
            char toFind = 'L';

            var text = new List<string>
            {
                main,
                Convert.ToString(toFind)
            };

            int actual = _countChars.CountCharsUsingForReverseIteration(text);

            Assert.Equal(2, actual);
        }

        [Fact]
        public void WhenSearchCharUsingSplitThenReturnNumberOfOccurences()
        {
            string main = "Mary Had A Little Lamb";
            char toFind = 'L';

            var text = new List<string>
            {
                main,
                Convert.ToString(toFind)
            };

            int actual = _countChars.CountCharsUsingSplit(text);

            Assert.Equal(2, actual);
        }

        [Fact]
        public void WhenSearchStringUsingSplitThenReturnNumberOfOccurences()
        {
            string main = "Mary Had A Little Lamb";
            string toFind = "Mary";

            var text = new List<string>
            {
                main,
                toFind
            };

            int actual = _countChars.CountCharsUsingSplit(text);

            Assert.Equal(1, actual);
        }

        [Fact]
        public void WhenSearchCharUsingReplaceThenReturnNumberOfOccurences()
        {
            string main = "Mary Had A Little Lamb";
            char toFind = 'L';

            var text = new List<string>
            {
                main,
                Convert.ToString(toFind)
            };

            int actual = _countChars.CountCharsUsingReplace(text);

            Assert.Equal(2, actual);
        }

        [Fact]
        public void WhenSearchStringUsingReplaceThenReturnNumberOfOccurences()
        {
            string main = "Mary Had A Little Lamb";
            string toFind = "Mary";

            var text = new List<string>
            {
                main,
                toFind
            };

            int actual = _countChars.CountCharsUsingReplace(text);

            Assert.Equal(1, actual);
        }

        [Fact]
        public void WhenSearchCharUsingRegexThenReturnNumberOfOccurences()
        {
            string main = "Mary Had A Little Lamb";
            char toFind = 'L';

            var text = new List<string>
            {
                main,
                Convert.ToString(toFind)
            };

            int actual = _countChars.CountCharsUsingRegex(text);

            Assert.Equal(2, actual);
        }

        [Fact]
        public void WhenSearchStringUsingRegexThenReturnNumberOfOccurences()
        {
            string main = "Mary Had A Little Lamb";
            string toFind = "Mary";

            var text = new List<string>
            {
                main,
                toFind
            };

            int actual = _countChars.CountCharsUsingRegex(text);

            Assert.Equal(1, actual);
        }
    }
}