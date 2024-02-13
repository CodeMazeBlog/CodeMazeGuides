namespace Tests
{
    public class EqualStringTests
    {
        private readonly FirstNCharactersOfStringGetter _firstNCharactersOfStringGetter;
        private readonly string _stringToTest = "Code";
        private readonly int _numberOfCharacters = 4;

        public EqualStringTests()
        {
            _firstNCharactersOfStringGetter = new FirstNCharactersOfStringGetter(_stringToTest, _numberOfCharacters);
        }

        [Fact]
        public void WhenUseRemoveIsCalledWithEqualString_ThenReturnsTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseRemove();

            Assert.Equal(_stringToTest, result);
        }

        [Fact]
        public void WhenUseLINQIsCalledWithEqualString_ThenReturnsTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseLINQ();

            Assert.Equal(_stringToTest, result);
        }

        [Fact]
        public void WhenUseRangeOperatorIsCalledWithEqualString_ThenReturnsTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseRangeOperator();

            Assert.Equal(_stringToTest, result);
        }

        [Fact]
        public void WhenUseAsSpanIsCalledWithEqualString_ThenReturnsTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseAsSpan();

            Assert.Equal(_stringToTest, result);
        }

        [Fact]
        public void WhenUseToCharArrayIsCalledWithEqualString_ThenReturnsTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseToCharArray();

            Assert.Equal(_stringToTest, result);
        }

        [Fact]
        public void WhenUsePadRightIsCalledWithEqualString_ThenReturnsTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UsePadRight();

            Assert.Equal(_stringToTest, result);
        }
    }
}