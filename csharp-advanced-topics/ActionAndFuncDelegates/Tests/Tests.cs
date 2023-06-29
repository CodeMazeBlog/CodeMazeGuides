using ActionAndFuncDelegates;

namespace Tests
{
    public class Tests
    {

        private readonly PrintRepository printRepository;
        private readonly MathOperationsRepository mathOperations;
        private StringWriter stringWriter;

        public Tests()
        {
            printRepository = new PrintRepository();
            mathOperations = new MathOperationsRepository();
            stringWriter = new StringWriter();
        }

        [Fact]
        public void GivenStringInput_WhenActionIsCalled_ThenPrintsTheInput()
        {

            Action<string> printAction = printRepository.DisplayInput;

            var input = "Michael";

            SetUpStringWriter();

            printAction(input);

            var output = stringWriter.ToString();

            // assert

            Assert.Equal($"{input}", output.Trim());
        }

        [Fact]
        public void GivenTwoNumbers_WhenActionIsInvoked_ThenPrintsCorrectAddition()
        {
            Action<int, int> printSumAction = printRepository.DisplaySum;

            SetUpStringWriter();

            var firstNumber = 2;
            var secondNumber = 3;

            printSumAction.Invoke(firstNumber, secondNumber);

            var expectedResult = firstNumber + secondNumber;

            var output = stringWriter.ToString();

            //assert

            Assert.Equal($"{expectedResult}", output.Trim());
        }


        [Fact]
        public void GivenStringInput_WhenActionIsCalled_ThenPrintsItTroughLambda()
        {
            Action<string> printMessageAction = message => Console.WriteLine(message);

            SetUpStringWriter();

            var input = "Hello, world!";

            printMessageAction(input);

            var output = stringWriter.ToString();

            // assert

            Assert.Equal($"{input}", output.Trim());
        }

        [Fact]
        public void GivenAnEvenNumber_WhenFuncIsInvoked_ThenReturnsTheCorrectBooleanValue()
        {
            Func<int, bool> isEvenFunc = mathOperations.IsNumberEven;

            var result = isEvenFunc(10);

            Assert.True(result);
        }

        [Fact]
        public void GivenOneNumber_WhenFuncIsInvoked_ThenCorrectlyReturnsTheSquareTroughLambda()
        {
            Func<int, int> squareFunc = x => x * x;

            int squareResult = squareFunc(5);

            Assert.Equal(25, squareResult);
        }

        [Fact]

        private void SetUpStringWriter()
        {
            Console.SetOut(stringWriter);
        }

    }
}