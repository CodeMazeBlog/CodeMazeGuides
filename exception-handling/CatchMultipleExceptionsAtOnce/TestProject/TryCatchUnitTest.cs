using CM223;
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
            string strNumerator = "10", strDenominator = "2";

            var result1 = CatchExamples.MultipleCatches(strNumerator, strDenominator);
            var result2 = CatchExamples.SingleCatchWithWhen(strNumerator, strDenominator);
            var result3 = CatchExamples.SingleSimplecatch(strNumerator, strDenominator);
            var result4 = CatchExamples.SingleCatch_SwitchCase(strNumerator, strDenominator);
            var result5 = CatchExamples.SingleCatch_SwitchWhen(strNumerator, strDenominator);

            Assert.IsTrue(result1 == 5 && result2 == 5 && result3 == 5 && result4 == 5 && result5 == 5);
        }

        [TestMethod]
        public void WhenIncorrectInputFormat_ThenInCorrectOutput()
        {
            string strNumerator = "rg4", strDenominator = "0";

            var result1 = CatchExamples.MultipleCatches(strNumerator, strDenominator);
            var result2 = CatchExamples.SingleCatchWithWhen(strNumerator, strDenominator);
            var result3 = CatchExamples.SingleSimplecatch(strNumerator, strDenominator);
            var result4 = CatchExamples.SingleCatch_SwitchCase(strNumerator, strDenominator);
            var result5 = CatchExamples.SingleCatch_SwitchWhen(strNumerator, strDenominator);

            Assert.IsTrue(result1 == -1 && result2 == -1 && result3 == -1 && result4 == -1 && result5 == -1);
        }

        [TestMethod]
        public void WhenDivisionByZeroError_ThenInCorrectOutput()
        {
            string strNumerator = "4", strDenominator = "0";

            var result1 = CatchExamples.MultipleCatches(strNumerator, strDenominator);
            var result2 = CatchExamples.SingleCatchWithWhen(strNumerator, strDenominator);
            var result3 = CatchExamples.SingleSimplecatch(strNumerator, strDenominator);
            var result4 = CatchExamples.SingleCatch_SwitchCase(strNumerator, strDenominator);
            var result5 = CatchExamples.SingleCatch_SwitchWhen(strNumerator, strDenominator);

            Assert.IsTrue(result1 == -1 && result2 == -1 && result3 == -1 && result4 == -1 && result5 == -1);
        }

        [TestMethod]
        public void WhenOverflowError_ThenInCorrectOutput()
        {
            string strNumerator = "4294967296", strDenominator = "20";

            var result1 = CatchExamples.MultipleCatches(strNumerator, strDenominator);
            var result2 = CatchExamples.SingleCatchWithWhen(strNumerator, strDenominator);
            var result3 = CatchExamples.SingleSimplecatch(strNumerator, strDenominator);
            var result4 = CatchExamples.SingleCatch_SwitchCase(strNumerator, strDenominator);
            var result5 = CatchExamples.SingleCatch_SwitchWhen(strNumerator, strDenominator);

            Assert.IsTrue(result1 == -1 && result2 == -1 && result3 == -1 && result4 == -1 && result5 == -1);
        }
    }
}