using FuncDelegate;

namespace TestProject
{
    public class FuncTest
    {
        Func<int, int, int> sumDel = FuncProgram.GetSum;

        [Fact]
        public void Test_Action_DisplayDelegate()
        {
            int expectedOutput = 20;
            var output = sumDel(10, 10);
            Assert.Equal(expectedOutput, output);
        }
    }
}
