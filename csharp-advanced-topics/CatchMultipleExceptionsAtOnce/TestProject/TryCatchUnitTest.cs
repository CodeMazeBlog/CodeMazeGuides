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

            var result1 = CatchExamples.StrDivision_MultipleCatches(strNumerator, strDenominator);
            var result2 = CatchExamples.StrDivision_SingleCatch(strNumerator, strDenominator);
            var result3 = CatchExamples.StrDivision_OptimizedSingleCatch(strNumerator, strDenominator);

            Assert.IsTrue(result1 == 5 && result2 == 5 && result3 == 5);
        }

        [TestMethod]
        public void WhenIncorrectInputFormat_ThenInCorrectOutput()
        {
            string strNumerator = "rg4", strDenominator = "0";

            var result1 = CatchExamples.StrDivision_MultipleCatches(strNumerator, strDenominator);
            var result2 = CatchExamples.StrDivision_SingleCatch(strNumerator, strDenominator);
            var result3 = CatchExamples.StrDivision_OptimizedSingleCatch(strNumerator, strDenominator);

            Assert.IsTrue(result1 == -1 && result2 == -1 && result3 == -1);
        }

        [TestMethod]
        public void WhenDivisionByZeroError_ThenInCorrectOutput()
        {
            string strNumerator = "4", strDenominator = "0";

            var result1 = CatchExamples.StrDivision_MultipleCatches(strNumerator, strDenominator);
            var result2 = CatchExamples.StrDivision_SingleCatch(strNumerator, strDenominator);
            var result3 = CatchExamples.StrDivision_OptimizedSingleCatch(strNumerator, strDenominator);

            Assert.IsTrue(result1 == -1 && result2 == -1 && result3 == -1);
        }

        [TestMethod]
        public void WhenOverflowError_ThenInCorrectOutput()
        {
            string strNumerator = "400", strDenominator = "20";

            var result1 = CatchExamples.StrDivision_MultipleCatches(strNumerator, strDenominator);
            var result2 = CatchExamples.StrDivision_SingleCatch(strNumerator, strDenominator);
            var result3 = CatchExamples.StrDivision_OptimizedSingleCatch(strNumerator, strDenominator);

            Assert.IsTrue(result1 == -1 && result2 == -1 && result3 == -1);
        }

        [TestMethod]
        public void WhenInvalidRangeError_ThenInCorrectOutput()
        {
            string strNumerator = "11", strDenominator = "15";

            var result1 = CatchExamples.StrDivision_MultipleCatches(strNumerator, strDenominator);
            var result2 = CatchExamples.StrDivision_SingleCatch(strNumerator, strDenominator);
            var result3 = CatchExamples.StrDivision_OptimizedSingleCatch(strNumerator, strDenominator);

            Assert.IsTrue(result1 == -1 && result2 == -1 && result3 == -1);
        }
    }
}