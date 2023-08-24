using StringArrayToString;

namespace Tests
{
    public class Tests
    {
        private readonly string[] _array = { "Code", "Maze", "C#"};
        private readonly string _result = "CodeMazeC#";
        private readonly ArrayConverter _arrayConverter = new();

        [Fact]
        public void GivenAnArray_WhenUsingLoopStringAdditionAssignment_ThenConvertIntoString()
        {
            var result = _arrayConverter.UsingLoopStringAdditionAssignment(_array);

            Assert.Equal(_result, result);

        }

        [Fact]
        public void GivenAnArray_WhenUsingLoopStringBuilder_ThenConvertIntoString()
        {
            var result = _arrayConverter.UsingLoopStringBuilder(_array);

            Assert.Equal(_result, result);
        }

        [Fact]
        public void GivenAnArray_WhenUsingStringJoin_ThenConvertIntoString()
        {
            var result = _arrayConverter.UsingStringJoin(_array);

            Assert.Equal(_result, result);
        }

        [Fact]
        public void GivenAnArray_WhenUsingStringConcat_ThenConvertIntoString()
        {
            var result = _arrayConverter.UsingStringConcat(_array);

            Assert.Equal(_result, result);
        }

        [Fact]
        public void GivenAnArray_WhenUsingAggregation_ThenConvertIntoString()
        {
            var result = _arrayConverter.UsingAggregation(_array);

            Assert.Equal(_result, result);
        }
    }
}