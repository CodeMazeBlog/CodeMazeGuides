using ActionAndFuncDelegates;

namespace Tests
{
    public class Tests
    {

        private readonly PrintRepository printRepository;

        public Tests()
        {
            printRepository = new PrintRepository();

        }

        [Fact]
        public void GivenStringInput_WhenActionIsCalled_ThenPrintsTheInput()
        {

            Action<string> printAction = printRepository.DisplayInput;

            var input = "Michael";

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            printAction(input);

            var output = stringWriter.ToString();

            // assert

            Assert.Equal($"{input}\r\n", output);
        }

        [Fact]
        public void GivenTwoNumbers_WhenActionIsInvoked_ThenPrintsCorrectAddition()
        {
            Action<int, int> printSumAction = printRepository.DispalySum;

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var firstNumber = 2;
            var secondNumber = 3;

            printSumAction.Invoke(firstNumber, secondNumber);

            var expectedResult = firstNumber + secondNumber;

            var output = stringWriter.ToString();

            //assert

            Assert.Equal($"{expectedResult}\r\n", output);
        }


        [Fact]
        public void GivenStringInput_WhenActionIsCalled_ThenActionPrintsItTroughLambda()
        {
            Action<string> printMessageAction = message => Console.WriteLine(message);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var input = "Hello, world!";

            printMessageAction(input);

            var output = stringWriter.ToString();

            // assert

            Assert.Equal($"{input}\r\n", output);
        }

        //[Fact]
        //public void whenPassedEvenNumber_FuncReturnsTheCorrectResultOfTheRefferencedMethod()
        //{
        //    Func<int, bool> isEvenFunc = IsNumberEven;

        //    var result = isEvenFunc(10);

        //    Assert.True(result);
        //}

        //[Fact]
        //public void whenIntegerParamIsGiven_FuncCorrectlyReturnsTheSquareTroughLambda()
        //{
        //    Func<int, int> squareFunc = x => x * x;

        //    int squareResult = squareFunc(5);

        //    Assert.Equal(25, squareResult);
        //}

    }
}