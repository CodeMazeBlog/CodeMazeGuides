namespace FuncAndActionInCSharp.Test
{
    public class FuncUnitTest
    {
        [Fact]
        public void WhenAStringIsPassed_ThenCorrectLengthIsReturned()
        {
            // ARRANGE
            string testString = "Hello World!";
            Func<string, int> getStringLength = value => value.Length;

            // ACT
            int stringLength = getStringLength(testString);

            // ASSERT
            Assert.Equal(testString.Length, stringLength);
        }
    }
}