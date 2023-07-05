namespace FuncAndActionInCSharp.Test
{
    public class UnitTest
    {
        [Fact]
        public void Test()
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