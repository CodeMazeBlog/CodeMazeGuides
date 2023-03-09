using ActionAndFuncDelegatesInCSharp;
using System.Text;

namespace Tests
{
    public class ExampleUnitTest
    {
        Example example = new();

        [Fact]
        public void GivenPrintMethod_WhenCalledWithValidStrValue_ThenPrintsValidStrValue()
        {
            string input = "Action and Func Delegates";
            StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            example.Print(input);

            string expectedOutput = input + Environment.NewLine;
            Assert.Equal(expectedOutput, consoleOutput.ToString());
        }

        [Fact]
        public void GivenPrintMethod_WhenCalledWithLargeStrValue_ThenPrintsLargeStrValue()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 1000000; i++)
            {
                sb.Append("a");
            }
            string longString = sb.ToString();

            using (ConsoleOutput consoleOutput = new ConsoleOutput())
            {
                example.Print(longString);

                string output = consoleOutput.GetOutput();

                Assert.Equal(longString, output.Trim());
            }
        }

        [Fact]
        public void GivenSumMethod_WhenCalledWithPositiveValues_ThenReturnsCorrectResult()
        {
            int x = 2;
            int y = 3;

            int result = example.Sum(x, y);

            Assert.Equal(5, result);
        }

        [Fact]
        public void GivenSumMethod_WhenXisZero_ThenReturnsCorrectResult()
        {
            int x = 0;
            int y = 5;

            int result = example.Sum(x, y);

            Assert.Equal(5, result);
        }

        [Fact]
        public void GivenSumMethod_WhenYisZero_ThenReturnsCorrectResult()
        {
            int x = 3;
            int y = 0;

            int result = example.Sum(x, y);

            Assert.Equal(3, result);
        }

        [Fact]
        public void GivenSumMethod_WhenBothAreZero_ThenReturnsCorrectResult()
        {
            int x = 0;
            int y = 0;

            int result = example.Sum(x, y);

            Assert.Equal(0, result);
        }

        [Fact]
        public void GivenSumMethod_WhenBothAreNegative_ThenReturnsCorrectResult()
        {
            int x = -2;
            int y = -3;

            int result = example.Sum(x, y);

            Assert.Equal(-5, result);
        }

        [Fact]
        public void GivenSumMethod_WhenXisNegative_ThenReturnsCorrectResult()
        {
            int x = -2;
            int y = 3;

            int result = example.Sum(x, y);

            Assert.Equal(1, result);
        }

        [Fact]
        public void GivenSumMethod_WhenYisNegative_ThenReturnsCorrectResult()
        {
            int x = 2;
            int y = -3;

            int result = example.Sum(x, y);

            Assert.Equal(-1, result);
        }

        private class ConsoleOutput : IDisposable
        {
            private readonly StringWriter _stringWriter;
            private readonly TextWriter _originalOutput;

            public ConsoleOutput()
            {
                _stringWriter = new StringWriter();
                _originalOutput = Console.Out;
                Console.SetOut(_stringWriter);
            }

            public string GetOutput()
            {
                return _stringWriter.ToString();
            }

            public void Dispose()
            {
                Console.SetOut(_originalOutput);
                _stringWriter.Dispose();
            }

            public void Record(Action action)
            {
                action();
            }
        }


    }
}
