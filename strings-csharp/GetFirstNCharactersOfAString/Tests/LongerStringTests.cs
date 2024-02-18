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
        public void WhenUseForLoopIsCalledWithEqualString_ThenReturnsTheFirstEightCharactersOfTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseForLoop();

            Assert.Equal("CodeMaze".Length, result.Length);
            Assert.Equal("CodeMaze", result.ToString());
        }

        [Fact]
        public void WhenUseRemoveIsCalledWithEqualString_ThenReturnsTheFirstEightCharactersOfTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseRemove();

            Assert.Equal("CodeMaze".Length, result.Length);
            Assert.Equal("CodeMaze", result.ToString());
        }

        [Fact]
        public void WhenUseLINQIsCalledWithEqualString_ThenReturnsTheFirstEightCharactersOfTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseLINQ();

            Assert.Equal("CodeMaze".Length, result.Length);
            Assert.Equal("CodeMaze", result.ToString());
        }

        [Fact]
        public void WhenUseAsSpanIsCalledWithEqualString_ThenReturnsTheFirstEightCharactersOfTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseAsSpan();

            Assert.Equal("CodeMaze".Length, result.Length);
            Assert.Equal("CodeMaze", result.ToString());
        }

        [Fact]
        public void WhenUseAsSpanWithRangeOperatorIsCalledWithEqualString_ThenReturnsTheFirstEightCharactersOfTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseAsSpanWithRangeOperator();

            Assert.Equal("CodeMaze".Length, result.Length);
            Assert.Equal("CodeMaze", result.ToString());
        }

        [Fact]
        public void WhenUseReadOnlyMemoryIsCalledWithEqualString_ThenReturnsTheFirstEightCharactersOfTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseReadOnlyMemory();

            Assert.Equal("CodeMaze".Length, result.Length);
            Assert.Equal("CodeMaze", result.ToString());
        }

        [Fact]
        public void WhenUseToCharArrayIsCalledWithEqualString_ThenReturnsTheFirstEightCharactersOfTheInputString()
        {
            var result = _firstNCharactersOfStringGetter.UseToCharArray();

            Assert.Equal("CodeMaze".Length, result.Length);
            Assert.Equal("CodeMaze", result.ToString());
        }
    }
}