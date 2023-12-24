using ActionAndFuncDelegates;
using System.Text;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void Action_Logs_Parameters_To_Console()
        {
            StringWriter sw = new();
            Console.SetOut(sw);

            Program.greet("Fred");

            string expectedOutput = "Hello, Fred!";
            string actualOutput = sw.ToString().Trim();
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Func_Returns_A_Value()
        {
            int product = Program.multiply(8, 5);

            Func<string, int> stringLength = (str) => str.Length;
            int length = Program.stringLength("Love Func!");

            int expectedProduct = 8 * 5;
            int expectLength = 10;
            Assert.Equal(expectedProduct, product);
            Assert.Equal(expectLength, length);
        }

        [Fact]
        public void Action_Prints_List_Item_To_Console()
        {
            StringWriter sw = new();
            Console.SetOut(sw);

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            numbers.ForEach(Program.processNumber);

            string actualOutput = sw.ToString().Trim();

            const string expectedOutput = "Processing:1\r\nProcessing:2\r\nProcessing:3\r\nProcessing:4\r\nProcessing:5\r\nProcessing:6";

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Func_Handles_Division_Gracefully()
        {
            int divisionResult = Program.safeDivision(20, 5);

            Assert.Equal(4, divisionResult);
        }

        [Fact]
        public void Func_Returns_Zero_When_Its_Divided_By_Zero()
        {
            int divisionResult = Program.safeDivision(20, 0);

            Assert.Equal(0, divisionResult);
        }
    }
}