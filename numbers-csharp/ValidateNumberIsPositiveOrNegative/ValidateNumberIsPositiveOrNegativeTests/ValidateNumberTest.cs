using ValidateNumberIsPositiveOrNegative;

namespace ValidateNumberIsPositiveOrNegativeTests
{
    [TestFixture]
    public class ValidateNumberTest
    {
        [TestCase(89, 1)]
        [TestCase(-30, -1)]
        [TestCase(0, 0)]
        public void GivenIntegerNumber_WhenUsingConditionalMethod_ThenVerifyResult(int number, int expectedOutput)
        {
            // Arrange - Nothing to arrange in this case

            // Act
            var actualOutput= NumberValidation.IsPositiveOrNegativeUsingConditionalMethod(number);

            // Assert
            Assert.That(expectedOutput, Is.EqualTo(actualOutput));
        }

        [TestCase(30.0, 1)]
        [TestCase(-30.0, -1)]
        [TestCase(0.0, 0)]
        [TestCase(-9223372036854775808, -1)]
        public void GivenDoubleNumber_WhenUsingConditionalMethod_ThenVerifyResult(double number, double expectedOutput)
        {
            // Act
            var actualOutput = NumberValidation.IsPositiveOrNegativeUsingConditionalMethod(number);

            // Assert
            Assert.That(expectedOutput, Is.EqualTo(actualOutput));
        }

        [TestCase(89, 1)]
        [TestCase(-30, -1)]
        [TestCase(0, 0)]
        public void GivenIntegerNumber_WhenUsingLeftShiftMethod_ThenVerifyResult(int number, int expectedOutput)
        {
            // Act
            var actualOutput = NumberValidation.IsPositiveOrNegativeUsingLeftShiftMethod(number);

            // Assert
            Assert.That(expectedOutput, Is.EqualTo(actualOutput));
        }

        [TestCase(42L, 1)]
        [TestCase(-42L, -1)]
        [TestCase(0, 0)]
        public void GivenLongNumber_WhenUsingLeftShiftMethod_ThenVerifyResult(long number, int expectedOutput)
        {
            // Act
            var actualOutput = NumberValidation.IsPositiveOrNegativeUsingLeftShiftMethod(number);

            // Assert
            Assert.That(expectedOutput, Is.EqualTo(actualOutput));
        }

        [TestCase(89, 1)]
        [TestCase(-30, -1)]
        [TestCase(0, 0)]
        public void GivenIntegerNumber_WhenUsingRightShiftMethod_ThenVerifyResult(int number, int expectedOutput)
        {
            // Act
            var actualOutput = NumberValidation.IsPositiveOrNegativeUsingRightShiftMethod(number);

            // Assert
            Assert.That(expectedOutput, Is.EqualTo(actualOutput));
        }

        [TestCase(42L, 1)]
        [TestCase(-42L, -1)]
        [TestCase(0, 0)]
        public void GivenLongNumber_WhenUsingRightShiftMethod_ThenVerifyResult(long number, int expectedOutput)
        {
            // Act
            var actualOutput = NumberValidation.IsPositiveOrNegativeUsingRightShiftMethod(number);

            // Assert
            Assert.That(expectedOutput, Is.EqualTo(actualOutput));
        }

        [TestCase(30, 1)]
        [TestCase(-30, -1)]
        [TestCase(0, 0)]
        public void GivenIntegerNumber_WhenUsingMathAbsMethod_ThenVerifyResult(int number, int expectedOutput)
        {
            // Act
            var actualOutput = NumberValidation.IsPositiveOrNegativeUsingMathAbsMethod(number);

            // Assert
            Assert.That(expectedOutput, Is.EqualTo(actualOutput));
        }

        [TestCase(43.0, 1)]
        [TestCase(-9223372036854775808, -1)]
        [TestCase(-42L, -1)]
        [TestCase(0, 0)]
        public void GivenDoubleNumber_WhenUsingMathAbsMethod_ThenVerifyResult(double number, int expectedOutput)
        {
            // Act
            var actualOutput = NumberValidation.IsPositiveOrNegativeUsingMathAbsMethod(number);

            // Assert
            Assert.That(expectedOutput, Is.EqualTo(actualOutput));
        }

        [TestCase(30, 1)]
        [TestCase(-30, -1)]
        [TestCase(0, 0)]
        public void GivenIntegerNumber_WhenUsingMathSign_ThenVerifyResult(int number, int expectedOutput)
        {            
            // Act
            var actualOutput = NumberValidation.IsPositiveOrNegativeUsingMathSignMethod(number);

            // Assert
            Assert.That(expectedOutput, Is.EqualTo(actualOutput));
        }

        [TestCase(43.0, 1)]
        [TestCase(-30.0, -1)]
        [TestCase(-30, -1)]
        [TestCase(-9223372036854775808, -1)]
        [TestCase(0, 0)]
        public void GivenDoubleNumber_WhenUsingMathSign_ThenVerifyResult(double number, int expectedOutput)
        {
            // Act
            var actualOutput = NumberValidation.IsPositiveOrNegativeUsingMathSignMethod(number);

            // Assert
            Assert.That(expectedOutput, Is.EqualTo(actualOutput));
        }

        [TestCase(60, 1)]
        [TestCase(-30, -1)]
        [TestCase(0, 0)]
        public void GivenIntegerNumber_WhenUsingIsPositiveOrNegative_ThenVerifyResult(int number, int expectedOutput)
        {
            // Act
            var actualOutput = NumberValidation.IsPositiveOrNegativeUsingBuiltInMethod(number);

            // Assert
            Assert.That(expectedOutput, Is.EqualTo(actualOutput));
        }

        [TestCase(60.0, 1)]
        [TestCase(-30.0, -1)]
        [TestCase(0.0, 0)]
        public void GivenDoubleNumber_WhenUsingIsPositiveOrNegative_ThenVerifyeResult(double number, int expectedOutput)
        {
            // Act
            var actualOutput = NumberValidation.IsPositiveOrNegativeUsingBuiltInMethod(number);

            // Assert
            Assert.That(expectedOutput, Is.EqualTo(actualOutput));
        }        
    }
}