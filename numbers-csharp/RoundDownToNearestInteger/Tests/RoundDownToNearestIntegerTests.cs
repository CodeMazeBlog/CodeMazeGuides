using RoundDownToNearestInteger;

namespace Tests
{
    [TestClass]
    public class RoundDownToNearestIntegerTests
    {
        private double[] testCases = new double[] { 2.5, 1.75, 1.5, 1.25, -1.25, -1.5, -1.75, -2.5 };

        [TestMethod]
        public void WhenRoundingUsingMathFloor_ThenCorrectResult()
        {
            var result = RoundingMethods.RoundDownUsingMathFloor(testCases);
            var expected = new int[] { 2, 1, 1, 1, -2, -2, -2, -3 };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenRoundingUsingMathTruncate_ThenCorrectResult()
        {
            var result = RoundingMethods.RoundDownUsingMathTruncate(testCases);
            var expected = new int[] { 2, 1, 1, 1, -1, -1, -1, -2 };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenRoundingUsingMathRoundWithToEvenMode_ThenCorrectResult()
        {
            var result = RoundingMethods.RoundDownUsingMathRoundWithToEvenMode(testCases);
            var expected = new int[] { 2, 2, 2, 1, -1, -2, -2, -2 };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenRoundingUsingMathRoundWithAwayFromZeroMode_ThenCorrectResult()
        {
            var result = RoundingMethods.RoundDownUsingMathRoundWithAwayFromZeroMode(testCases);
            var expected = new int[] { 3, 2, 2, 1, -1, -2, -2, -3 };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenRoundingUsingMathRoundWithToZeroMode_ThenCorrectResult()
        {
            var result = RoundingMethods.RoundDownUsingMathRoundWithToZeroMode(testCases);
            var expected = new int[] { 2, 1, 1, 1, -1, -1, -1, -2 };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenRoundingUsingMathRoundWithToNegativeInfinityMode_ThenCorrectResult()
        {
            var result = RoundingMethods.RoundDownUsingMathRoundWithToNegativeInfinityMode(testCases);
            var expected = new int[] { 2, 1, 1, 1, -2, -2, -2, -3 };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenRoundingUsingMathRoundWithToPositiveInfinityMode_ThenCorrectResult()
        {
            var result = RoundingMethods.RoundDownUsingMathRoundWithToPositiveInfinityMode(testCases);
            var expected = new int[] { 3, 2, 2, 2, -1, -1, -1, -2 };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenRoundingUsingConvertToInt32_ThenCorrectResult()
        {
            var result = RoundingMethods.RoundDownUsingConvertToInt32(testCases);
            var expected = new int[] { 2, 2, 2, 1, -1, -2, -2, -2 };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenRoundingUsingCasting_ThenCorrectResult()
        {
            var result = RoundingMethods.RoundDownUsingCasting(testCases);
            var expected = new int[] { 2, 1, 1, 1, -1, -1, -1, -2 };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenRoundingUsingSubtractionWithModulo_ThenCorrectResult()
        {
            var result = RoundingMethods.RoundDownUsingSubtractionWithModulo(testCases);
            var expected = new int[] { 2, 1, 1, 1, -1, -1, -1, -2 };

            CollectionAssert.AreEqual(expected, result);
        }
    }
}