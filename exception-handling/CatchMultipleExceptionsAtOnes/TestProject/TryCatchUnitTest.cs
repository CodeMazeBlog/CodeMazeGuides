using CatchMultipleExceptionsAtOnes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace TestProject
{
    [TestClass]
    public class TryCatchUnitTest
    {
        [TestMethod]
        public void WhenCorrectInput_ThenCorrectOutput()
        {
            string numerator = "10", denominator = "2";

            var result1 = CatchExamples.MultipleCatches(numerator, denominator);
            var result2 = CatchExamples.SingleCatchWithWhen(numerator, denominator);
            var result3 = CatchExamples.SingleCatchSwitchCase(numerator, denominator);
            var result4 = CatchExamples.SingleCatchSwitchPattern(numerator, denominator);

            Assert.IsTrue(result1 == 5 && result2 == 5 && result3 == 5 && result4 == 5);
        }

        [TestMethod]
        public void WhenIncorrectInputFormat_ThenInCorrectOutput()
        {
            string numerator = "rg4", denominator = "0";

            var result1 = CatchExamples.MultipleCatches(numerator, denominator);
            var result2 = CatchExamples.SingleCatchWithWhen(numerator, denominator);
            var result3 = CatchExamples.SingleCatchSwitchCase(numerator, denominator);
            var result4 = CatchExamples.SingleCatchSwitchPattern(numerator, denominator);

            Assert.IsTrue(result1 == -1 && result2 == -1 && result3 == -1 && result4 == -1);
        }

        [TestMethod]
        public void WhenDivisionByZeroError_ThenInCorrectOutput()
        {
            string numerator = "4", denominator = "0";

            var result1 = CatchExamples.MultipleCatches(numerator, denominator);
            var result2 = CatchExamples.SingleCatchWithWhen(numerator, denominator);
            var result3 = CatchExamples.SingleCatchSwitchCase(numerator, denominator);
            var result4 = CatchExamples.SingleCatchSwitchPattern(numerator, denominator);

            Assert.IsTrue(result1 == -1 && result2 == -1 && result3 == -1 && result4 == -1);
        }

        [TestMethod]
        public void WhenOverflowError_ThenInCorrectOutput()
        {
            string numerator = "-1", denominator = "20";

            var result1 = CatchExamples.MultipleCatches(numerator, denominator);
            var result2 = CatchExamples.SingleCatchWithWhen(numerator, denominator);
            var result3 = CatchExamples.SingleCatchSwitchCase(numerator, denominator);
            var result4 = CatchExamples.SingleCatchSwitchPattern(numerator, denominator);

            Assert.IsTrue(result1 == -1 && result2 == -1 && result3 == -1 && result4 == -1);
        }
    }
}