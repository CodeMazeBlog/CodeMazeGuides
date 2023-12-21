namespace Tests
{
    public class Tests
    {
        [Fact]
        public void Action_Logs_Parameters_To_Console()
        {
            StringWriter sw = new();
            Console.SetOut(sw);

            Action<string> greet = (name) => Console.WriteLine($"Hello, {name}!");
            greet("Fred");

            string expectedOutput = "Hello, Fred!";
            string actualOutput = sw.ToString().Trim();
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Func_Returns_A_Value()
        {
            Func<int, int, int> multiply = (a, b) => a * b;
            int product = multiply(8, 5);

            Func<string, int> stringLength = (str) => str.Length;
            int length = stringLength("Love Func!");

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

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            Action<int> processNumber = (number) => Console.Write($"Processing:{number}");
            numbers.ForEach(processNumber);


            string actualOutput = sw.ToString().Trim();
            string expectedOutput = "";
            foreach (var number in numbers)
            {
                expectedOutput += $"Processing:{number}";
            }

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Func_Handles_Division_Gracefully()
        {
            Func<int, int, int> safeDivision = (a, b) => b != 0 ? a / b : 0;
            int divisionResult = safeDivision(20, 5);
            
            Assert.Equal(4, divisionResult);
        }

        [Fact]
        public void Func_Returns_Zero_When_Its_Divided_By_Zero()
        {
            Func<int, int, int> safeDivision = (a, b) => b != 0 ? a / b : 0;
            int divisionResult = safeDivision(20, 0);

            Assert.Equal(0, divisionResult);
        }

        


    }
}