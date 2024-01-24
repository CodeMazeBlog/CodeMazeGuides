using ValidateNumberIsPositiveOrNegative;

namespace ValidateNumberIsPositiveOrNegativeTests
{
    [TestFixture]
    public class ValidateNumberTest
    {
        [TestCase(60, 1)]
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

        [TestCase(60.0, 1)]
        [TestCase(-30.0, -1)]
        [TestCase(0.0, 0)]
        public void GivenDoubleNumber_WhenUsingConditionalMethod_ThenVerifyResult(double number, double expectedOutput)
        {
            // Arrange - Nothing to arrange in this case

            // Act
            var actualOutput = NumberValidation.IsPositiveOrNegativeUsingConditionalMethod(number);

            // Assert
            Assert.That(expectedOutput, Is.EqualTo(actualOutput));
        }

        [TestCase(60, 1)]
        [TestCase(-30, -1)]
        [TestCase(0, 0)]
        public void GivenNumber_WhenUsingLeftShiftMethod_ThenVerifyResult(int number, int expectedOutput)
        {
            // Arrange - Nothing to arrange in this case

            // Act
            var actualOutput = NumberValidation.IsPositiveOrNegativeUsingLeftShiftMethod(number);

            // Assert
            Assert.That(expectedOutput, Is.EqualTo(actualOutput));
        }
        //TODO: Remove once agreed.
        //[TestCase(60, false)]
        //[TestCase(-42, true)]
        //public void GivenNumber_WhenUsingRotateLeftShiftMethod_ThenVerifyResult(int number, bool expectedOutput)
        //{
        //    // Arrange - Nothing to arrange in this case

        //    // Act
        //    var actualOutput = NumberValidation.IsNegativeShift(number);

        //    // Assert
        //    Assert.That(expectedOutput, Is.EqualTo(actualOutput));
        //}

        [TestCase(60, 1)]
        [TestCase(-30, -1)]
        [TestCase(0, 0)]
        public void GivenNumber_WhenUsingRightShiftMethod_ThenVerifyResult(int number, int expectedOutput)
        {
            // Act
            var actualOutput = NumberValidation.IsPositiveOrNegativeUsingRightShiftMethod(number);

            // Assert
            Assert.That(expectedOutput, Is.EqualTo(actualOutput));
        }

        [TestCase(60, 1)]
        [TestCase(-30, -1)]
        [TestCase(0, 0)]
        public void GivenNumber_WhenUsingMathAbsMethod_ThenVerifyResult(int number, int expectedOutput)
        {
            // Act
            var actualOutput = NumberValidation.IsPositiveOrNegativeUsingMathAbsMethod(number);

            // Assert
            Assert.That(expectedOutput, Is.EqualTo(actualOutput));
        }

        [TestCase(60, 1)]
        [TestCase(-30, -1)]
        [TestCase(0, 0)]
        public void GivenNumber_WhenUsingMathSign_ThenVerifyResult(int number, int expectedOutput)
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
        public void GivenDoubleNumber_WhenUsingIsPositiveOrNegative_ThenVerifyeResult(double number, double expectedOutput)
        {
            // Act
            var actualOutput = NumberValidation.IsPositiveOrNegativeUsingBuiltInMethod(number);

            // Assert
            Assert.That(expectedOutput, Is.EqualTo(actualOutput));
        }
    }
}