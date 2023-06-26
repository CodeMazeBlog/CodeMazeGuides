using System.Xml.Linq;

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
        public void whenOneParameterIsPassed_ActionPrintsItTroughRefferencedMethod()
        {
            Action<string> printAction = Print;

            var name = "John";

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            printAction(name);

            //assert
            var output = stringWriter.ToString();

            Assert.Equal($"{name}\r\n", output);
        }

        [Fact]
        public void whenTwoParameterAreGiven_ActionPrintsTheSumTroughRefferencedMethod()
        {
            Action<int, int> printSumAction = PrintSum;



            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            printSumAction.Invoke(2, 3);

            var expectedResult = 5;

            //assert
            var output = stringWriter.ToString();

            Assert.Equal($"{expectedResult}\r\n", output);
        }

        [Fact]
        public void whenPassedEvenNumber_FuncReturnsTheCorrectResultOfTheRefferencedMethod()
        {
            Func<int, bool> isEvenFunc = IsNumberEven;

            var result = isEvenFunc(10);

            Assert.True(result);
        }

        [Fact]
        public void whenIntegerParamIsGiven_FuncCorrectlyReturnsTheSquareTroughLambda()
        {
            Func<int, int> squareFunc = x => x * x;

            int squareResult = squareFunc(5);

            Assert.Equal(25, squareResult);
        }

        [Fact]
        public void whenStringParamIsGiven_ActionPrintsItTroughLambda()
        {
            Action<string> printMessageAction = message => Console.WriteLine(message);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var param = "Hello, world!";

            printMessageAction(param);

            //assert
            var output = stringWriter.ToString();

            Assert.Equal($"{param}\r\n", output);
        }
    }
}