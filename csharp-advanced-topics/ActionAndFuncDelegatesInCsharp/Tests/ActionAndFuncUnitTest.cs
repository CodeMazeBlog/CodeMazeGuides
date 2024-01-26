using ActionAndFuncDelegatesInCsharp;

namespace Tests
{
    public class ActionAndFuncUnitTest
    {
        [Fact]
        public void WhenActionDelegateIsCalled_ThenAddActionNumbersMethodIsInvoked()
        {
            var i = 4;
            var j = 8;
            var stringWriter = new StringWriter();
            var expectedOutput = $"The addition's sum: {i + j}";

            Console.SetOut(stringWriter);
            Program.AddActionNumbers(i, j);
            var actualOutput = stringWriter.ToString().Trim();

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void WhenFuncDelegateIsCalled_ThenAddFuncNumbersMethodIsInvoked()
        {
            var i = 4;
            var j = 8;
            var expectedSum = i + j;
            var actualSum = Program.AddFuncNumbers(i, j);

            Assert.Equal(expectedSum, actualSum);
        }
    }
}