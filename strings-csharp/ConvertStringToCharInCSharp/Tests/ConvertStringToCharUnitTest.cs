using ConvertStringToCharArray;

namespace ConvertStringToCharArrayUnitTests
{
    public class ProgramTests
    {
        [Fact]
        public void GivenString_WhenConvertedWithCharParse_ThenCharArrayConverted()
        {
            string input = "C";
            char expected = 'C';
            char result = Program.ConvertUsingCharParse(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GivenString_WhenConvertedToCharArrayWithToCharArray_ThenCharArrayConverted()
        {
            string str = "Code Maze";
            char[] expected = str.ToCharArray();
            char[] result = Program.ConvertToCharArray(str);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GivenString_WhenConvertedToCharArrayWithForLoop_ThenCharArrayConverted()
        {
            string str = "Code Maze";
            char[] expected = str.ToCharArray();
            char[] result = Program.ConvertUsingForLoop(str);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GivenString_WhenConvertedToCharArrayWithReadOnlySpan_ThenCharArrayConverted()
        {
            string str = "Code Maze";
            char[] expected = str.ToCharArray();
            char[] result = Program.ConvertUsingReadOnlySpan(str);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GivenString_WhenConvertedToCharArrayWithUnsafeCode_ThenCharArrayConverted()
        {
            string str = "Code Maze";
            char[] expected = str.ToCharArray();
            char[] result = Program.ConvertUsingUnsafeCode(str);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GivenString_WhenConvertedToCharArrayWithLinq_ThenCharArrayConverted()
        {
            string str = "Code Maze";
            char[] expected = str.ToCharArray();
            char[] result = Program.ConvertUsingLinq(str);

            Assert.Equal(expected, result);
        }
    }
}