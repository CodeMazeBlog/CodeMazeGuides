using Xunit;
using ActionFuncDelegate;

namespace ActionFuncDelegateTest
{
    [TestClass]
    public class UnitTest1
    {
        [Fact]
        public void PrintNumber_WhenGivenNumber_ThenPrintTheResult()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);

            // Act
            ActionFuncDelegate;

            // Assert
            var output = writer.GetStringBuilder().ToString().Trim();
            Assert.Equal("Result = 2", output);
        }
    }
}