using Delegate;

namespace TestProject
{
    public class DelegateTest
    {
        public delegate void Display(string firstName, string lastName);
        public delegate int Sum(int value1, int value2);

        [Fact]
        public void Test_DisplayDelegate()
        {
            string expectedOutput = "John Abraham";
            Display displayDel = DelegateProgram.DisplayMethod;
            Sum sumDel = DelegateProgram.GetSum;

            
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            DelegateProgram.DisplayMethod("John", "Abraham");

            Assert.Equal(expectedOutput, sw.ToString());
        }

        [Fact]
        public void Test_SumDelegate()
        {
            int expectedOutput = 20;
            Sum sumDel = DelegateProgram.GetSum;

            var output = sumDel(10, 10);
            Assert.Equal(expectedOutput, output);
        }
    }
}