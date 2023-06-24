
namespace Tests
{
    public class Tests
    {
        void Print(string name)
        {
            Console.WriteLine(name);
        }

        void PrintSum(int x, int y) { Console.WriteLine(x + y); }

        bool IsNumberEven(int number) { return number % 2 == 0; }


        [Fact]
        public void whenPassedOneParameter_ActionCorrectlyPrintsTheNameResultFromTheReferencedFunction()
        {
            Action<string> printAction = Print;

            string name = "John";

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            printAction(name);

            //assert
            var output = stringWriter.ToString();

            Assert.Equal($"{name}\r\n", output);
        }

        [Fact]
        public void whenPassedTwoParameters_ActionCorrectlyInvokesTheReferencedFunctionThatPrintsTheSum()
        {
            Action<int, int> printSumAction = PrintSum;

            int expectedResult = 2 + 3;


            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            printSumAction(2, 3);

            //assert
            var output = stringWriter.ToString();

            Assert.Equal($"{expectedResult}\r\n", output);
        }

        [Fact]
        public void whenGivenOneIntegerParameter_FuncCorrectlyReturnsTheResultFromTheInvokedMehod()
        {
            Func<int, bool> isEvenFunc = IsNumberEven;

            var result = isEvenFunc(10);

            //assert
            Assert.True(result);
        }

        [Fact]
        public void whenGivenOneIntegerParameter_FuncReturnsTheSquareResultWithLambdaExpression()
        {
            Func<int, int> squareFunc = x => x * x;
            
            int squareResult = squareFunc(5);

            //assert
            Assert.Equal(squareResult, 25);
        }

        [Fact]
        public void whenGivenOneParameter_ActionCorrectlyPrintsItWithLambdaExpression()
        {
            Action<string> printMessageAction = message => Console.WriteLine(message);

            var hello = "Hello, world!";

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            printMessageAction(hello);

            //assert
            var output = stringWriter.ToString();

            Assert.Equal($"{hello}\r\n", output);
        }
    }
}