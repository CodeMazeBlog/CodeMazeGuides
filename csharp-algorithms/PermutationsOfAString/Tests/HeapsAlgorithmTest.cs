using PermutationsOfAString;

namespace Tests
{
    [TestClass]
    public class PanditasAlgorithmTest
    {
        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        [DataRow(7)]
        [DataRow(8)]
        [DataRow(9)]
        [DataRow(10)]
        public void GivenNumber_WhenRunningWithDifferentAlgorithms_ThenExpectTheSameResults(int number)
        {
            TestHelper.AssertAreAlgorithms(new HeapsAlgorithm(), new PanditasAlgorithm(), (byte)number);
        }
    }
}