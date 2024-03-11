using ConvertingStringToCharArrayInCSharp;

namespace ConvertingStringToCharArrayInCSharpTests
{
    public class StringHelperTests
    {
        private const string INPUT_STRING = "Hello, World!";

        [Fact]
        public void GivenStringToCharArray_WhenValidInput_ThenReturnsCharArray()
        {
            char[] result = StringHelper.ConvertStringToCharArray(INPUT_STRING);

            Assert.Equal(INPUT_STRING.ToCharArray(), result);
        }

        [Fact]
        public void GivenStringToCharArrayUsingReadOnlySpan_WhenValidInput_ThenReturnsReadOnlySpan()
        {
            ReadOnlySpan<char> result = StringHelper.ConvertStringToCharArrayUsingReadOnlySpan(INPUT_STRING);

            Assert.True(INPUT_STRING.AsSpan().SequenceEqual(result));
        }

        [Fact]
        public void GivenStringToChar_WhenValidInput_ThenReturnsChar()
        {
            string inputString = "A";

            char result = StringHelper.ConvertSingleCharacterStringToChar(inputString);

            Assert.Equal('A', result);
        }

        [Fact]
        public void GivenStringArrayToCharArray_WhenValidInput_ThenReturnsCharArray()
        {
            string[] stringArray = { INPUT_STRING.Substring(0, 7), INPUT_STRING.Substring(7) };

            char[] resultLoop = StringHelper.ConvertStringArrayToCharArrayUsingLoop(stringArray);
            char[] resultLinq = StringHelper.ConvertStringArrayToCharArrayUsingLinq(stringArray);

            Assert.Equal(INPUT_STRING.ToCharArray(), resultLoop);
            Assert.Equal(INPUT_STRING.ToCharArray(), resultLinq);
        }

        [Fact]
        public void GivenStringToChar_WhenInvalidInput_ThenThrowsArgumentException()
        {
            string inputString = "AB";

            Assert.Throws<FormatException>(() => StringHelper.ConvertSingleCharacterStringToChar(inputString));
        }
    }
}