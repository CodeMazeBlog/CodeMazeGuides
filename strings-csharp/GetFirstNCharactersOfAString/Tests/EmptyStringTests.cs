namespace Tests
{
    public class EmptyStringTests
    {
        private readonly FirstNCharactersOfStringGetter _firstNCharactersOfStringGetter;
        private readonly string _stringToTest = string.Empty;
        private readonly int _numberOfCharacters = 8;

        public EmptyStringTests()
        {
            _firstNCharactersOfStringGetter = new FirstNCharactersOfStringGetter(_stringToTest, _numberOfCharacters);
        }

        [Fact]
        public void WhenUseRemoveIsCalledWithEqualString_ThenReturnsInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseRemove();

            Assert.Equal(_stringToTest, result);
        }

        [Fact]
        public void WhenUseLINQIsCalledWithEqualString_ThenReturnsInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseLINQ();

            Assert.Equal(_stringToTest, result);
        }

        [Fact]
        public void WhenUseRangeOperatorIsCalledWithEqualString_ThenReturnsInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseRangeOperator();

            Assert.Equal(_stringToTest, result);
        }

        [Fact]
        public void WhenUseAsSpanIsCalledWithEqualString_ThenReturnsInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseAsSpan();

            Assert.Equal(_stringToTest, result);
        }

        [Fact]
        public void WhenUseToCharArrayIsCalledWithEqualString_ThenReturnsInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseToCharArray();

            Assert.Equal(_stringToTest, result);
        }

        [Fact]
        public void WhenUsePadRightIsCalledWithEqualString_ThenReturnsInputString()
        {
            var result = _firstNCharactersOfStringGetter.UsePadRight();

            Assert.Equal(_stringToTest, result);
        }
    }
}
