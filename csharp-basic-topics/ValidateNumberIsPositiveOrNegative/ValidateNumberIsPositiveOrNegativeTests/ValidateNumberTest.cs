namespace ValidateNumberIsPositiveOrNegativeTests
{
    [TestFixture]
    public class ValidateNumberTest
    {
        [TestCase(60, "IsPositiveOrNegative_ConditionalMethod - 60 is positive number.")]
        [TestCase(-30, "IsPositiveOrNegative_ConditionalMethod - -30 is negative number.")]
        [TestCase(0, "IsPositiveOrNegative_ConditionalMethod - The 0 is zero.")]
        public void GivenNumber_WhenUsingConditionalMethod_ThenPrintResult(int number, string expectedOutput)
        {
            // Arrange - Nothing to arrange in this case

            // Act
            using (ConsoleOutputRedirector outputRedirector = new ConsoleOutputRedirector())
            {
                 Program.IsPositiveOrNegative_ConditionalMethod(number);
                string actualOutput = outputRedirector.GetOutput();

                // Assert
                Assert.AreEqual(expectedOutput, actualOutput.Trim());
            }
        }
        [TestCase(60, "IsPositiveOrNegative_LeftShiftMethod - 60 is a positive number (using Left shift).")]
        [TestCase(-30, "IsPositiveOrNegative_LeftShiftMethod - -30 is a negative number (using left shift).")]
        public void GivenNumber_WhenUsingLeftShiftMethod_ThenPrintResult(int number, string expectedOutput)
        {
            // Arrange - Nothing to arrange in this case

            // Act
            using (ConsoleOutputRedirector outputRedirector = new ConsoleOutputRedirector())
            {
                Program.IsPositiveOrNegative_LeftShiftMethod(number);
                string actualOutput = outputRedirector.GetOutput();

                // Assert
                Assert.AreEqual(expectedOutput, actualOutput.Trim());
            }
        }
        [TestCase(60, "IsPositiveOrNegative_RightShiftMethod - 60 is a positive number (using right shift).")]
        [TestCase(-30, "IsPositiveOrNegative_RightShiftMethod - -30 is a negative number (using right shift).")]
        public void GivenNumber_WhenUsingRightShiftMethod_ThenPrintResult(int number, string expectedOutput)
        {
            // Arrange - Nothing to arrange in this case

            // Act
            using (ConsoleOutputRedirector outputRedirector = new ConsoleOutputRedirector())
            {
                Program.IsPositiveOrNegative_RightShiftMethod(number);
                string actualOutput = outputRedirector.GetOutput();

                // Assert
                Assert.AreEqual(expectedOutput, actualOutput.Trim());
            }
        }
        [TestCase(60, "IsPositiveOrNegative_MathAbsMethod - 60 is a positive number.")]
        [TestCase(-30, "IsPositiveOrNegative_MathAbsMethod - -30 is a negative number.")]
        public void GivenNumber_WhenUsingMathAbsMethod_ThenPrintResult(int number, string expectedOutput)
        {
            // Arrange - Nothing to arrange in this case

            // Act
            using (ConsoleOutputRedirector outputRedirector = new ConsoleOutputRedirector())
            {
                Program.IsPositiveOrNegative_MathAbsMethod(number);
                string actualOutput = outputRedirector.GetOutput();

                // Assert
                Assert.AreEqual(expectedOutput, actualOutput.Trim());
            }
        }

        [TestCase(60, "IsPositiveOrNegative_MathSignMethod - 60 is a positive number.")]
        [TestCase(-30, "IsPositiveOrNegative_MathSignMethod - -30 is a negative number.")]
        [TestCase(0, "IsPositiveOrNegative_MathSignMethod - The 0 is zero.")]
        public void GivenNumber_WhenUsingMathSign_ThenPrintResult(int number, string expectedOutput)
        {
            // Arrange - Nothing to arrange in this case

            // Act
            using (ConsoleOutputRedirector outputRedirector = new ConsoleOutputRedirector())
            {
                Program.IsPositiveOrNegative_MathSignMethod(number);
                string actualOutput = outputRedirector.GetOutput();

                // Assert
                Assert.AreEqual(expectedOutput, actualOutput.Trim());
            }
        }
        [TestCase(60, "IsPositiveOrNegative - The 60 is positive.")]
        [TestCase(-30, "IsPositiveOrNegative - The -30 is negative.")]
        public void GivenNumber_WhenUsingIsPositiveOrNegative_ThenPrintResult(int number, string expectedOutput)
        {
            // Arrange - Nothing to arrange in this case

            // Act
            using (ConsoleOutputRedirector outputRedirector = new ConsoleOutputRedirector())
            {
                Program.IsPositiveOrNegative(number);
                string actualOutput = outputRedirector.GetOutput();

                // Assert
                Assert.AreEqual(expectedOutput, actualOutput.Trim());
            }
        }
    }
    public class ConsoleOutputRedirector : IDisposable
    {
        private readonly StringWriter stringWriter;
        private readonly TextWriter originalOutput;

        public ConsoleOutputRedirector()
        {
            stringWriter = new StringWriter();
            originalOutput = Console.Out;
            Console.SetOut(stringWriter);
        }

        public string GetOutput()
        {
            return stringWriter.ToString();
        }

        public void Dispose()
        {
            Console.SetOut(originalOutput);
            stringWriter.Dispose();
        }
    }
}