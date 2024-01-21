using ValidateNumberIsPositiveOrNegative;

namespace ValidateNumberIsPositiveOrNegativeTests
{
    [TestFixture]
    public class ValidateNumberTest
    {
        [TestCase(60, 1)]
        [TestCase(-30, -1)]
        [TestCase(0, 0)]
        public void GivenNumber_WhenUsingConditionalMethod_ThenPrintResult(int number, int expectedOutput)
        {
            // Arrange - Nothing to arrange in this case

            // Act
                var actualOutput= NumberValidation.IsPositiveOrNegativeUsingConditionalMethod(number);

            // Assert
            Assert.That(expectedOutput, Is.EqualTo(actualOutput));
        }
        [TestCase(60, 1)]
        [TestCase(-30, -1)]
        public void GivenNumber_WhenUsingLeftShiftMethod_ThenPrintResult(int number, int expectedOutput)
        {
            // Arrange - Nothing to arrange in this case

            // Act
            var actualOutput = NumberValidation.IsPositiveOrNegativeUsingLeftShiftMethod(number);

            // Assert
            Assert.That(expectedOutput, Is.EqualTo(actualOutput));
        }
        [TestCase(60, 1)]
        [TestCase(-30, -1)]
        public void GivenNumber_WhenUsingRightShiftMethod_ThenPrintResult(int number, int expectedOutput)
        {
            // Act
            var actualOutput = NumberValidation.IsPositiveOrNegativeUsingRightShiftMethod(number);

            // Assert
            Assert.That(expectedOutput, Is.EqualTo(actualOutput));
        }
        [TestCase(60, 1)]
        [TestCase(-30, -1)]
        public void GivenNumber_WhenUsingMathAbsMethod_ThenPrintResult(int number, int expectedOutput)
        {
            // Act
            var actualOutput = NumberValidation.IsPositiveOrNegativeUsingMathAbsMethod(number);

            // Assert
            Assert.That(expectedOutput, Is.EqualTo(actualOutput));
        }

        [TestCase(60, 1)]
        [TestCase(-30, -1)]
        [TestCase(0, 0)]
        public void GivenNumber_WhenUsingMathSign_ThenPrintResult(int number, int expectedOutput)
        {            
            // Act
            var actualOutput = NumberValidation.IsPositiveOrNegativeUsingMathSignMethod(number);

            // Assert
            Assert.That(expectedOutput, Is.EqualTo(actualOutput));
        }
        [TestCase(60, 1)]
        [TestCase(-30, -1)]
        public void GivenNumber_WhenUsingIsPositiveOrNegative_ThenPrintResult(int number, int expectedOutput)
        {
            // Act
            var actualOutput = NumberValidation.IsPositiveOrNegative(number);

            // Assert
            Assert.That(expectedOutput, Is.EqualTo(actualOutput));
        }
    }
}