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
        public void WhenUseForLoopIsCalledWithEqualString_ThenReturnsTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseForLoop();

            Assert.Equal(_stringToTest.Length, result.Length);
            Assert.Equal(_stringToTest, result.ToString());
        }

        [Fact]
        public void WhenUseRemoveIsCalledWithEqualString_ThenReturnsTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseRemove();

            Assert.Equal(_stringToTest.Length, result.Length);
            Assert.Equal(_stringToTest, result.ToString());
        }

        [Fact]
        public void WhenUseLINQIsCalledWithEqualString_ThenReturnsTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseLINQ();

            Assert.Equal(_stringToTest.Length, result.Length);
            Assert.Equal(_stringToTest, result.ToString());
        }

        [Fact]
        public void WhenUseAsSpanIsCalledWithEqualString_ThenReturnsTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseAsSpan();

            Assert.Equal(_stringToTest.Length, result.Length);
            Assert.Equal(_stringToTest, result.ToString());
        }

        [Fact]
        public void WhenUseAsSpanWithRangeOperatorIsCalledWithEqualString_ThenReturnsTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseAsSpanWithRangeOperator();

            Assert.Equal(_stringToTest.Length, result.Length);
            Assert.Equal(_stringToTest, result.ToString());
        }

        [Fact]
        public void WhenUseReadOnlyMemoryIsCalledWithEqualString_ThenReturnsTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseReadOnlyMemory();

            Assert.Equal(_stringToTest.Length, result.Length);
            Assert.Equal(_stringToTest, result.ToString());
        }

        [Fact]
        public void WhenUseToCharArrayIsCalledWithEqualString_ThenReturnsTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseToCharArray();

            Assert.Equal(_stringToTest.Length, result.Length);
            Assert.Equal(_stringToTest, result.ToString());
        }
    }
}