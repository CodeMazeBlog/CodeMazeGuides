using ListAllThePermutationsOfStringInCSharp;

namespace Tests
{
    [TestClass]
    public class ImprovedAlgorithmTest
    {
        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        public void GivenNumber_WhenRunningWithDifferentAlgorithms_ThenExpectTheSameResults(int number)
        {
            TestHelper.AssertAreAlgorithms(new BasicAlgorithm(), new ImprovedAlgorithm(), (byte)number);
        }
    }
}