namespace Tests
{
    public class LongerStringTests
    {
        private readonly FirstNCharactersOfStringGetter _firstNCharactersOfStringGetter;
        private readonly string _stringToTest = "CodeMazeGuides";
        private readonly int _numberOfCharacters = 8;

        public LongerStringTests()
        {
            _firstNCharactersOfStringGetter = new FirstNCharactersOfStringGetter(_stringToTest, _numberOfCharacters);
        }

        [Fact]
        public void WhenUseRemoveIsCalledWithEqualString_ThenReturnsTheFirstEightCharactersOfTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseRemove();

            Assert.Equal("CodeMaze", result);
        }

        [Fact]
        public void WhenUseLINQIsCalledWithEqualString_ThenReturnsTheFirstEightCharactersOfTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseLINQ();

            Assert.Equal("CodeMaze", result);
        }

        [Fact]
        public void WhenUseRangeOperatorIsCalledWithEqualString_ThenReturnsTheFirstEightCharactersOfTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseRangeOperator();

            Assert.Equal("CodeMaze", result);
        }

        [Fact]
        public void WhenUseAsSpanIsCalledWithEqualString_ThenReturnsTheFirstEightCharactersOfTheInputStringg()
        {
            var result = _firstNCharactersOfStringGetter.UseAsSpan();

            Assert.Equal("CodeMaze", result);
        }

        [Fact]
        public void WhenUseToCharArrayIsCalledWithEqualString_ThenReturnsTheFirstEightCharactersOfTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseToCharArray();

            Assert.Equal("CodeMaze", result);
        }

        [Fact]
        public void WhenUsePadRightIsCalledWithEqualString_ThenReturnsTheFirstEightCharactersOfTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UsePadRight();

            Assert.Equal("CodeMaze", result);
        }
    }
}