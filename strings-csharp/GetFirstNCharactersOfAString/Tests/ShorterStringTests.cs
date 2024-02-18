namespace Tests
{
    public class ShorterStringTests
    {
        private readonly FirstNCharactersOfStringGetter _firstNCharactersOfStringGetter;
        private readonly string _stringToTest = "Cod";
        private readonly int _numberOfCharacters = 8;

        public ShorterStringTests()
        {
            _firstNCharactersOfStringGetter = new FirstNCharactersOfStringGetter(_stringToTest, _numberOfCharacters);
        }

        [Fact]
        public void WhenUseForLoopIsCalledWithShorterString_ThenReturnsTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseForLoop();

            Assert.Equal(_stringToTest.Length, result.Length);
            Assert.Equal(_stringToTest, result.ToString());
        }

        [Fact]
        public void WhenUseRemoveIsCalledWithShorterString_ThenReturnsTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseRemove();

            Assert.Equal(_stringToTest.Length, result.Length);
            Assert.Equal(_stringToTest, result.ToString());
        }

        [Fact]
        public void WhenUseLINQIsCalledWithShorterString_ThenReturnsTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseLINQ();

            Assert.Equal(_stringToTest.Length, result.Length);
            Assert.Equal(_stringToTest, result.ToString());
        }

        [Fact]
        public void WhenUseAsSpanIsCalledWithShorterString_ThenReturnsTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseAsSpan();

            Assert.Equal(_stringToTest.Length, result.Length);
            Assert.Equal(_stringToTest, result.ToString());
        }

        [Fact]
        public void WhenUseAsSpanWithRangeOperatorIsCalledWithShorterString_ThenReturnsTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseAsSpanWithRangeOperator();

            Assert.Equal(_stringToTest.Length, result.Length);
            Assert.Equal(_stringToTest, result.ToString());
        }

        [Fact]
        public void WhenUseReadOnlyMemoryIsCalledWithShorterString_ThenReturnsTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseReadOnlyMemory();

            Assert.Equal(_stringToTest.Length, result.Length);
            Assert.Equal(_stringToTest, result.ToString());
        }

        [Fact]
        public void WhenUseToCharArrayIsCalledWithShorterString_ThenReturnsTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseToCharArray();

            Assert.Equal(_stringToTest.Length, result.Length);
            Assert.Equal(_stringToTest, result.ToString());
        }
    }
}