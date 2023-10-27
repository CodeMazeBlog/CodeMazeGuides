using ActionAndFuncDelegates;

namespace Tests
{
    public class Tests
    {
        private readonly PrintRepository printRepository;
        private readonly FuncRepository funcRepository;

        public Tests()
        {
            printRepository = new PrintRepository();
            funcRepository = new FuncRepository();
        }

        [Fact]
        public void GivenStringInput_WhenActionIsCalled_ThenPrintsTheInput()
        {
            Action<string> printAction = printRepository.DisplayInput;

            var input = "Michael";

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            printAction(input);

            //assert
            var output = stringWriter.ToString();

            Assert.Equal($"{input}\r\n", output);
        }

        [Fact]
        public void GivenStringInput_WhenActionIsCalled_ThenActionPrintsItTroughAnonymous()
        {
            Action<string> printActionByDelegate = delegate (string input)
            {
                Console.WriteLine(input);
            };

            var input = "Michael";

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            printActionByDelegate(input);

            //assert
            var output = stringWriter.ToString();

            Assert.Equal($"{input}\r\n", output);
        }

        [Fact]
        public void GivenStringInput_WhenActionIsCalled_ThenActionPrintsItTroughLambda()
        {
            Action<string> printActionByLambda = message => Console.WriteLine(message);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var input = "Hello, world!";

            printActionByLambda(input);

            //assert
            var output = stringWriter.ToString();

            Assert.Equal($"{input}\r\n", output);
        }

        [Fact]
        public void WhenPassedEvenNumber_FuncReturnsTheCorrectResultOfTheRefferencedMethod()
        {
            Func<int, bool> isEvenFunc = funcRepository.IsNumberEven;

            var result = isEvenFunc(10);

            Assert.True(result);
        }

        [Fact]
        public void WhenPassedEvenNumber_FuncReturnsTheCorrectResultOfTheAnonymousMethod()
        {
            Func<int, bool> isEvenFuncByAnonymous = delegate (int x)
            {
                return x % 2 == 0;
            };

            var result = isEvenFuncByAnonymous(10);

            Assert.True(result);
        }

        [Fact]
        public void WhenPassedEvenNumber_FuncReturnsTheCorrectResultOfTheLambdaMethod()
        {
            Func<int, bool> isEvenFuncByLambda = x => x % 2 == 0;

            var result = isEvenFuncByLambda(10);

            Assert.True(result);
        }
        [Fact]
        public void WhenPassedNonEvenNumber_FuncReturnsTheCorrectResultOfTheRefferencedMethod()
        {
            Func<int, bool> isEvenFunc = funcRepository.IsNumberEven;

            var result = isEvenFunc(11);

            Assert.False(result);
        }

        [Fact]
        public void WhenPassedNonEvenNumber_FuncReturnsTheCorrectResultOfTheAnonymousMethod()
        {
            Func<int, bool> isEvenFuncByAnonymous = delegate (int x)
            {
                return x % 2 == 0;
            };

            var result = isEvenFuncByAnonymous(13);

            Assert.False(result);
        }

        [Fact]
        public void WhenPassedNonEvenNumber_FuncReturnsTheCorrectResultOfTheLambdaMethod()
        {
            Func<int, bool> isEvenFuncByLambda = x => x % 2 == 0;

            var result = isEvenFuncByLambda(13);

            Assert.False(result);
        }
    }
}