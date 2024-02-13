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
        public void WhenUseRemoveIsCalledWithShorterString_ThenReturnsTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseRemove();

            Assert.Equal(_stringToTest, result);
        }

        [Fact]
        public void WhenUseLINQIsCalledWithShorterString_ThenReturnsTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseLINQ();

            Assert.Equal(_stringToTest, result);
        }

        [Fact]
        public void WhenUseRangeOperatorIsCalledWithShorterString_ThenReturnsTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseRangeOperator();

            Assert.Equal(_stringToTest, result);
        }

        [Fact]
        public void WhenUseAsSpanIsCalledWithShorterString_ThenReturnsTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseAsSpan();

            Assert.Equal(_stringToTest, result);
        }

        [Fact]
        public void WhenUseToCharArrayIsCalledWithShorterString_ThenReturnsTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseToCharArray();

            Assert.Equal(_stringToTest, result);
        }

        [Fact]
        public void WhenUsePadRightIsCalledWithShorterString_ThenReturnsTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UsePadRight();

            Assert.Equal(_stringToTest, result);
        }
    }
}