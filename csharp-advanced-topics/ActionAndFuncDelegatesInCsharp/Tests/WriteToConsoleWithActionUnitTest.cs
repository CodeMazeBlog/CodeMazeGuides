using System.Text;

namespace ActionAndFuncDelegates.Tests
{
    public class WriteToConsoleWithActionUnitTest
    {
        [Fact]
        public void Test_WriteToConsoleWithAction()
        {
            var sb = new StringBuilder();
            Console.SetOut(new StringWriter(sb));

            Program.WriteToConsoleWithAction("Unit test");

            Assert.True(sb.ToString().Trim().Equals("Unit test"));
        }
    }
}
