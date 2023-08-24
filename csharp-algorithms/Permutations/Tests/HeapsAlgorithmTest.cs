using ListAllThePermutationsOfStringInCSharp;

namespace Tests
{
    [TestClass]
    public class HeapsAlgorithmTest
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
        public void GivenNumber_WhenRunningWithDifferentAlgorithms_ThenExpectTheSameResults(int number)
        {
            TestHelper.AssertAreAlgorithms(new ImprovedAlgorithm(), new HeapsAlgorithm(), (byte)number);
        }
    }
}